using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 网络状态
/// </summary>
public enum NetState
{
    ConnectSucc = 1,//连接成功
    ConnectFail = 2,//连接失败
    ConnectError=3,//连接出错
    Close = 4,//关闭
    ReConnectFlag=5,//重连信号 表示断线了 可以弹出重连界面了 
    ReConnectSucess=6,//重新连接成功
    ReconnectFail=7, //重新连接失败

}
/// <summary>
/// 网络连接事件管理器
/// </summary>
public class NetStateEvntCtrl
{
    public delegate void EventListener(string str);
    //连接事件集合
    private static Dictionary<NetState, EventListener> m_ListenerDic = new Dictionary<NetState, EventListener>();
    /// <summary>
    /// 监听链接事件
    /// </summary>
    /// <param name="netEvent"></param>
    /// <param name="listener"></param>
    public static void AddEventListener(NetState netEvent, EventListener listener)
    {
        if (m_ListenerDic.ContainsKey(netEvent))
        {
            m_ListenerDic[netEvent] += listener;
        }
        else
        {
            m_ListenerDic[netEvent] = listener;
        }
    }
    /// <summary>
    /// 移除监听事件
    /// </summary>
    /// <param name="netEvent">事件ID</param>
    /// <param name="listener">监听者</param>
    public static void RemoveEventListener(NetState netEvent, EventListener listener)
    {
        if (m_ListenerDic.ContainsKey(netEvent))
        {
            m_ListenerDic[netEvent] -= listener;
            if (m_ListenerDic[netEvent] == null)
            {
                m_ListenerDic.Remove(netEvent);
            }
        }
    }
    /// <summary>
    ///调用监听者
    /// </summary>
    /// <param name="netEvent"></param>
    /// <param name="str"></param>
    public static void FirstEvent(NetState netEvent, string str)
    {
        if (m_ListenerDic.ContainsKey(netEvent))
        {
            m_ListenerDic[netEvent](str);
        }
    }

}
