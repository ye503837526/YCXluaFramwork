using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameFramwork
{
    /// <summary>
    /// 网络协议管理器(进行协议事件的派发)
    /// </summary>
    public class NetEvnentCtrl
    {
        //协议事件
        public delegate void ProtoListener(byte[] msg);
        //监听者集合
        private static Dictionary<NetProtocal, ProtoListener> mNetEventDic = new Dictionary<NetProtocal, ProtoListener>();
        //lua消息监听
        public static Action<int, byte[]> LuaListener;
        /// <summary>
        /// 一个协议希望只有一个监听
        /// </summary>
        public static void AddEvent(NetProtocal protocal, ProtoListener listener)
        {
            if (mNetEventDic.ContainsKey(protocal))
                Debug.LogError(protocal.ToString() + "事件已经添加监听者,请勿重复添加！");
            else
                mNetEventDic[protocal] = listener;

        }
        /// <summary>
        /// 移除事件
        /// </summary>
        /// <param name="protocal"></param>
        public static void RemoveEvent(NetProtocal protocal)
        {
            if (mNetEventDic.ContainsKey(protocal))
            {
                mNetEventDic[protocal] = null;
                mNetEventDic.Remove(protocal);
            }
        }
        /// <summary>
        /// 发射事件
        /// </summary>
        public static void FirstEvent(NetProtocal protocolEnum, byte[] msgBase)
        {
            if (mNetEventDic.ContainsKey(protocolEnum))
            {
                mNetEventDic[protocolEnum](msgBase);
            }
            LuaListener.SafeInvoke((int)protocolEnum, msgBase);
        }
    }
}