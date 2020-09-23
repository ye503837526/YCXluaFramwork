/// <summary>
/// 网络协议
/// </summary>
public enum NetProtocal
{
    None = 0,
    /// <summary>
    /// 心跳
    /// </summary>
    Ping=1,
    /// <summary>
    /// 秘钥请求
    /// </summary>
    SECRET_REQUEST =2,
    /// <summary>
    /// 秘钥响应
    /// </summary>
    SECRET_RESPONSE=3,
}

