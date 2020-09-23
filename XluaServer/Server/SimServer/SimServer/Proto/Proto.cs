using System;
using System.Collections.Generic;
using ProtoBuf;


/// <summary>
/// 秘钥请求
/// </summary>
[ProtoContract]
public class SecretRequest 
{
    [ProtoMember(1)]
    public string PublicSceret;
}
/// <summary>
/// 秘钥响应
/// </summary>
[ProtoContract]
public class SecretResponse
{
    [ProtoMember(1)]
    public string Sceret;
}

[ProtoContract]
public class Ping
{ 

}
/// <summary>
/// 登录请求
/// </summary>
[ProtoContract]
public class LoginRequest
{
    [ProtoMember(1)]
    public int LoginType;
    [ProtoMember(2)]
    public string Name;
    [ProtoMember(3)]
    public int PassWord;
    [ProtoMember(4)]
    public int Gmaeid;
}
/// <summary>
/// 登录响应
/// </summary>
[ProtoContract]
public class LoginResponse
{
    [ProtoMember(1)]
    public string name;
    [ProtoMember(2)]
    public long gold;
    [ProtoMember(3)]
    public long diamond;
 
}