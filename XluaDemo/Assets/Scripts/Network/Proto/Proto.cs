using System;
using System.Collections.Generic;
using ProtoBuf;

[ProtoContract]
public class ProtoTest
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
//心跳
[ProtoContract]
public class Ping 
{

}
