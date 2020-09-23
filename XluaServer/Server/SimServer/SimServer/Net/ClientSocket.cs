using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SimServer.Net
{
    public class ClientSocket
    {
        public string Sceret = "Yycm";
        public Socket Socket { get; set; }
         //上一次接收心跳的时间
        public long LastPingTime { get; set; } = 0;

        public ByteArray ReadBuff = new ByteArray();

        public int UserId = 0;

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="netProtocol">协议号</param>
        /// <param name="wfPacket">数据包</param>
        public void SendPacket(NetProtocol netProtocol,byte[] bytes)
        {
            ServerSocket.SendPacket(this,netProtocol, bytes);
        }
        public void CloseSocket()
        {
            ServerSocket.Instance.CloseClient(this);
        }
    }
}
