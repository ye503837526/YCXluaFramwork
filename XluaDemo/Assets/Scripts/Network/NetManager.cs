using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;
namespace GameFramwork
{
    /// <summary>
    /// 网络管理器
    /// </summary>
    public class NetManager : Singleton<NetManager>
    {
        //公钥
        public string PublicKey = "yycm";
        //秘钥
        public string SecretKey { get; private set; }
        //Socket
        private Socket m_Socket;
        //读写数组
        private ByteArray m_ReadBuff;
        //IP
        private string m_Ip;
        //端口
        private int m_Port;
        //是否连接中
        private bool m_Connecting = false;
        //是否关闭中
        private bool m_Closing = false;
        //处理消息线程
        private Thread m_MsgThread;
        //心跳包线程
        private Thread m_HeartThread;
        //上一次发送心跳的时间
        static long lastPingTime;
        //上一次收到心跳包的时间
        static long lastPongTime;
        //写入队列
        private Queue<ByteArray> m_WriteQueue;
        //所有的消息队列
        private Queue<byte[]> m_MsgQueue;
        //Unity消息队列(心跳包除外)
        private Queue<byte[]> m_UnityMsgQueue;
        //消息列表长度
        private int m_MsgCount = 0;
        //心跳间隔
        public static long m_PingInterval = 30;
        //是否掉线或离线
        private bool m_OffNet = false;
        //是否链接成功过（只要链接成功过就是true，再也不会变成false）
        private bool m_IsConnectSuccessed = false;
        //是否开始重新连接
        private bool m_ReConnect = false;
        //重连失败次数
        private int m_ReconnectFialCount = 0;
        //是否第一次启动
        private bool m_IsOneStartUp = true;
        //当前网络状态
        private NetworkReachability m_CurNetWork = NetworkReachability.NotReachable;

        //检测网络是否断开  如果网络断开则进行重连
        public IEnumerator CheckNet()
        {
            m_CurNetWork = Application.internetReachability;
            float GameTime = Time.unscaledTime;
            while (true)
            {
                if ((Time.unscaledTime - GameTime) > 1)
                {
                    if (m_IsConnectSuccessed)
                    {
                        if (m_CurNetWork != Application.internetReachability)
                        {
                            ReConnect();
                            m_CurNetWork = Application.internetReachability;
                        }
                    }
                    GameTime = Time.unscaledTime;
                }
                yield return null;
            }
        }

        public void Update()
        {
            //捕获网络是否断开 如果断开弹出界面进行重连
            if (m_OffNet && m_IsConnectSuccessed)
            {
                NetStateEvntCtrl.FirstEvent(NetState.ReConnectFlag, "与服务器断开连接,是否重新连接服务器？");
                //弹框，确定是否重连
                GameObject nWindow = GameObject.Instantiate(Resources.Load<GameObject>("ReConnectWindow"));
                nWindow.transform.Find("SureButton").GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() =>
                {
                    //重新链接
                    ReConnect();
                    GameObject.Destroy(nWindow);
                });
                //退出游戏
                m_OffNet = false;
            }
            //断开链接后，链接服务器之后自动登录
            if (!string.IsNullOrEmpty(SecretKey) && m_Socket.Connected && m_ReConnect)
            {
                NetStateEvntCtrl.FirstEvent(NetState.ReConnectSucess, "服务器重连成功,请进行重连后的登录及逻辑操作！");
                m_ReConnect = false;
            }

            MsgUpdate();
        }

        void MsgUpdate()
        {
            if (m_Socket != null && m_Socket.Connected)
            {
                if (m_MsgCount == 0) return;
                byte[] msgByte = null;
                lock (m_UnityMsgQueue)
                {
                    if (m_UnityMsgQueue.Count > 0)
                    {
                        msgByte = m_UnityMsgQueue.Dequeue();
                        m_MsgCount--;
                    }
                }
                if (msgByte != null)
                {
                    NetProtocal netProtocal = SerlializePacket.DeSerializePortocol(msgByte, 0);
                    if (netProtocal == NetProtocal.None)
                    {
                        Close("NetProtocol  DeSerialize Fial  Sicket Close !");
                        return;
                    }
                    int protoByteLenght = msgByte.Length - 4;
                    byte[] bytes = new byte[protoByteLenght];
                    Array.Copy(msgByte,4,bytes,0, protoByteLenght);
                    msgByte = null;
                    NetEvnentCtrl.FirstEvent(netProtocal, bytes);
                }
            }
        }
        /// <summary>
        ///消息处理线程
        /// </summary>
        void MsgThread()
        {
            while (m_Socket != null && m_Socket.Connected)
            {
                if (m_MsgQueue.Count <= 0) continue;

                byte[] msgBytes = null;
                lock (m_MsgQueue)
                {
                    if (m_MsgQueue.Count > 0)
                    {
                        msgBytes = m_MsgQueue.Dequeue();

                    }
                }
                //这里过滤掉心跳包，保证消息网络消息的可靠性
                if (msgBytes != null)
                {
                    NetProtocal Protocal = SerlializePacket.DeSerializePortocol(msgBytes, 0);
                    if (Protocal == NetProtocal.Ping)
                    {
                        lastPongTime = GetTimeStamp();
                        Debug.Log("收到心跳包！！！！！！！");
                        m_MsgCount--;
                    }
                    else
                    {
                        lock (m_UnityMsgQueue)
                        {
                            m_UnityMsgQueue.Enqueue(msgBytes);
                        }
                    }
                }
                else
                {
                    break;
                }
            }
        }
        /// <summary>
        /// 心跳包处理线程
        /// </summary>
        void PingThread()
        {
            while (m_Socket != null && m_Socket.Connected)
            {
                long timeNow = GetTimeStamp();
                if (timeNow - lastPingTime > m_PingInterval)
                {
                    Ping ping = new Ping();
                    Debug.Log("发送心跳包");
                     byte[] bytes= SerlializePacket.Serlialize(ping);
                    SendPacket(NetProtocal.Ping, bytes);
                    lastPingTime = GetTimeStamp();
                }

                //如果心跳包过长时间没收到，就关闭连接
                if (timeNow - lastPongTime > m_PingInterval * 4)
                {
                    Close(" Heart Time Out ,  Close Socket !");
                }
            }
        }

        /// <summary>
        /// 重连方法
        /// </summary>
        public void ReConnect()
        {
            Debug.Log("重新连接服务器");
            Connect(m_Ip, m_Port);
            m_ReConnect = true;
        }
        /// <summary>
        /// 初始化状态
        /// </summary>
        void InitState()
        {
            //初始化变量
            m_Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            m_ReadBuff = new ByteArray();
            m_WriteQueue = new Queue<ByteArray>();
            m_Connecting = false;
            m_Closing = false;
            m_MsgQueue = new Queue<byte[]>();
            m_UnityMsgQueue = new Queue<byte[]>();
            m_MsgCount = 0;
            lastPingTime = GetTimeStamp();
            lastPongTime = GetTimeStamp();
            if (m_IsOneStartUp)
            {
                FieldType.InitFieldType();
                Main.Instanse.StartCoroutine(CheckNet());
            }
               
        }
        /// <summary>
        /// 链接服务器函数
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public void Connect(string ip, int port)
        {
            if (m_Socket != null && m_Socket.Connected)
            {
                Debug.LogError("链接失败，已经链接了！");
                return;
            }

            if (m_Connecting)
            {
                Debug.LogError("链接失败，正在链接中！");
                return;
            }
            InitState();
            m_Socket.NoDelay = true;
            m_Connecting = true;
            //开始连接
            m_Socket.BeginConnect(ip, port, ConnectCallback, m_Socket);
            m_Ip = ip;
            m_Port = port;
        }
        /// <summary>
        /// 链接回调
        /// </summary>
        /// <param name="ar"></param>
        void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                Socket socket = (Socket)ar.AsyncState;
                //连接回调触发 结束连接
                socket.EndConnect(ar);
                NetStateEvntCtrl.FirstEvent(NetState.ConnectSucc, "Socket Connect Sucess !");
                m_IsConnectSuccessed = true;
                m_ReconnectFialCount = 0;
                //开启消息处理
                m_MsgThread = new Thread(MsgThread);
                m_MsgThread.IsBackground = true;
                m_MsgThread.Start();
                m_Connecting = false;
                //开启心跳功能
                m_HeartThread = new Thread(PingThread);
                m_HeartThread.IsBackground = true;
                m_HeartThread.Start();
                //连接成功 发送消息 请求秘钥
                MsgHandleCore.Instance.SendSecreRequest(PublicKey);
                Debug.Log("Socket Connect Success");
                //开启异步接收消息
                m_Socket.BeginReceive(m_ReadBuff.Bytes, m_ReadBuff.WriteIdx, m_ReadBuff.Remain, 0, ReceiveCallBack, socket);
            }
            catch (SocketException ex)
            {
                Debug.LogError("Socket Connect fail:" + ex.ToString());
                m_Connecting = false;
                NetStateEvntCtrl.FirstEvent(NetState.ConnectError, "Socket Connect Error:" + ex.ToString());
                if (m_ReConnect)
                {
                    m_ReconnectFialCount++;
                    NetStateEvntCtrl.FirstEvent(NetState.ReconnectFail, m_ReconnectFialCount.ToString());
                }
            }
        }


        /// <summary>
        /// 接受数据回调
        /// </summary>
        /// <param name="ar"></param>
        void ReceiveCallBack(IAsyncResult ar)
        {
            try
            {
                Socket socket = (Socket)ar.AsyncState;
                //接收完成 触发接收回调 结束接收 返回接收长度
                int count = socket.EndReceive(ar);
                if (count <= 0)
                {
                    Close("Server  DisConnect Client Socket!");
                    //关闭链接
                    return;
                }
                //写入下标后移
                m_ReadBuff.WriteIdx += count;
                //接收数据
                OnReceiveData();
                if (m_ReadBuff.Remain < 8)
                {
                    m_ReadBuff.MoveBytes();
                    m_ReadBuff.ReSize(m_ReadBuff.Length * 2);
                }
                socket.BeginReceive(m_ReadBuff.Bytes, m_ReadBuff.WriteIdx, m_ReadBuff.Remain, 0, ReceiveCallBack, socket);
            }
            catch (SocketException ex)
            {
                Debug.LogError("Socket ReceiveCallBack fail:" + ex.ToString());
                Close("Socket ReceiveCallBack fail:" + ex.ToString());
            }
        }

        /// <summary>
        /// 对数据进行处理
        /// </summary>
        void OnReceiveData()
        {
            //长度小于包头 不完整
            if (m_ReadBuff.Length <= 4 || m_ReadBuff.ReadIdx < 0)
                return;

            int readIdx = m_ReadBuff.ReadIdx;
            byte[] bytes = m_ReadBuff.Bytes;
            //读取包头长度
            int bodyLength = BitConverter.ToInt32(bytes, readIdx);
            //消息长度小于包头长度，说明消息不完整
            if (m_ReadBuff.Length < bodyLength + 4)
            {
                return;
            }
            //读取下标偏移
            m_ReadBuff.ReadIdx += 4;
            try
            {
                //取出消息体
                byte[] msgBytes = new byte[bodyLength];
                Array.Copy(m_ReadBuff.Bytes, m_ReadBuff.ReadIdx, msgBytes, 0, msgBytes.Length);
                m_ReadBuff.ReadIdx += bodyLength;

                m_ReadBuff.CheckAndMoveBytes();
                //消息解析成功 放入队列
                lock (m_MsgQueue)
                {
                    m_MsgQueue.Enqueue(msgBytes);
                }
                m_MsgCount++;
                //消息接收完成判断是否还有数据未处理（处理粘包）
                if (m_ReadBuff.Length > 4)
                {
                    OnReceiveData();
                }
            }
            catch (Exception ex)
            {
                Close("Socket OnReceiveData error:" + ex.ToString());
            }
        }
        /// <summary>
        /// 发送数据包
        /// </summary>
        public void SendPacket(NetProtocal netProtocal, byte[] bytes)
        {
             SendMessage(SerlializePacket.MakePacket(netProtocal, bytes));
        }
        public void LuaSendPacket(int netProtocal, byte[] bytes)
        {
            NetProtocal protocal = (NetProtocal)netProtocal;
            SendPacket(protocal, bytes);
        }
        /// <summary>
        /// 发送数据到服务器
        /// </summary>
        /// <param name="msgBase"></param>
        private void SendMessage(byte[] sendBytes)
        {
            if (m_Socket == null || !m_Socket.Connected)
            {
                return;
            }
            if (m_Connecting)
            {
                Debug.LogError("正在链接服务器中，无法发送消息！");
                return;
            }
            if (m_Closing)
            {
                Debug.LogError("正在关闭链接中，无法发送消息!");
                return;
            }
            try
            {
                ByteArray ba = new ByteArray(sendBytes);
                int count = 0;
                //放入发送队列
                lock (m_WriteQueue)
                {
                    m_WriteQueue.Enqueue(ba);
                    count = m_WriteQueue.Count;
                }
                //单个消息第一时间发送
                if (count == 1)
                {
                    m_Socket.BeginSend(sendBytes, 0, sendBytes.Length, 0, SendCallBack, m_Socket);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError("SendMessage error:" + ex.ToString());
                Close("SendMessage error:" + ex.ToString());
            }
        }

        /// <summary>
        /// 发送结束回调
        /// </summary>
        /// <param name="ar"></param>
        void SendCallBack(IAsyncResult ar)
        {
            try
            {
                Socket socket = (Socket)ar.AsyncState;
                //发送结束后如果Socket断掉就不处理
                if (socket == null || !socket.Connected) return;
                //触发发送回调 结束发送 获取发送长度
                int count = socket.EndSend(ar);
                Debug.Log("发送完成 发送长度：" + count);
                //判断是否发送完成
                ByteArray ba;
                lock (m_WriteQueue)
                {
                    ba = m_WriteQueue.First();
                }
                ba.ReadIdx += count;
                //代表发送完整
                if (ba.Length == 0)
                {
                    lock (m_WriteQueue)
                    {
                        m_WriteQueue.Dequeue();
                        //发送完成后队列还有消息
                        if (m_WriteQueue.Count > 0)
                        {
                            ba = m_WriteQueue.First();
                        }
                        else
                        {
                            ba = null;
                        }
                    }
                }

                //发送不完整或发送完整且存在第二条数据
                if (ba != null)
                {
                    socket.BeginSend(ba.Bytes, ba.ReadIdx, ba.Length, 0, SendCallBack, socket);
                }
                //确保关闭链接前，先把消息发送出去
                else if (m_Closing)
                {
                    RealClose("Socket Close!");
                }
            }
            catch (SocketException ex)
            {
                Debug.LogError("SendCallBack error:" + ex.ToString());
                Close("SendCallBack error:" + ex.ToString());
            }
        }

        /// <summary>
        /// 关闭链接
        /// </summary>
        /// <param name="normal"></param>
        public void Close(string normal = "")
        {
            if (m_Socket == null || m_Connecting)
            {
                return;
            }

            if (m_Connecting) return;

            if (m_WriteQueue.Count > 0)
            {
                m_Closing = true;
            }
            else
            {
                RealClose(normal);
            }
        }
        /// <summary>
        /// 正式关闭
        /// </summary>
        /// <param name="normal"></param>
        void RealClose(string normal = "Socket Close!")
        {
            SecretKey = "";
            m_Socket.Close();
            NetStateEvntCtrl.FirstEvent(NetState.Close, normal);
            m_OffNet = true;
            if (m_HeartThread != null && m_HeartThread.IsAlive)
            {
                m_HeartThread.Abort();
                m_HeartThread = null;
            }
            if (m_MsgThread != null && m_MsgThread.IsAlive)
            {
                m_MsgThread.Abort();
                m_MsgThread = null;
            }
        }

        public void SetKey(string key)
        {
            SecretKey = key;
        }
        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public static long GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds);
        }
    }
}