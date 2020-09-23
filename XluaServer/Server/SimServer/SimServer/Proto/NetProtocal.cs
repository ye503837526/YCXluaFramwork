using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 网络协议
/// </summary>
public enum NetProtocol
{
    None = 0,
    /// <summary>
    /// 心跳
    /// </summary>
    Ping = 1,
    /// <summary>
    /// 秘钥请求
    /// </summary>
    SECRET_REQUEST = 2,
    /// <summary>
    /// 秘钥响应
    /// </summary>
    SECRET_RESPONSE = 3,
    /// <summary>
    /// 登录请求
    /// </summary>
    LOGIN_LOGIN_REQUEST=10,
    /// <summary>
    /// 登录响应
    /// </summary>
    LOGIN_LOGIN_RESPONSE=11,
}

