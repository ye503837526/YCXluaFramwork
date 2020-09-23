/*********************************************
 *   Title: 数据包序列化
 *   Description: 
 *   Author: 壹叶成名
 *   Date: 2020.3.29
 *   Modify: 
 *********************************************/
using ProtoBuf;
using SimServer.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

/// <summary>
/// 数据包序列化
/// </summary>
public class SerlializePacket
{
    /// <summary>
    /// 序列化
    /// </summary>
    public static byte[] Serlialize<T>(T t)
    {
        using (var memory = new MemoryStream())
        {
            //将我们的协议类进行序列化转换成数组
            ProtoBuf.Serializer.Serialize<T>(memory, t);
            byte[] bytes = memory.ToArray();

            return bytes;
        }
    }
    /// <summary>
    /// 反序列化
    /// </summary>
    public static T DeSerlialize<T>(byte[] bytesData, int offset=4)
    {
        using (var memory = new MemoryStream())
        {
            memory.Write(bytesData, offset, bytesData.Length-offset);
            memory.Position = 0L;
            T result = Serializer.Deserialize<T>(memory);
            return result;
        }
    }
    /// <summary>
    /// 合并包体
    /// </summary>
    /// <returns></returns>
    public static byte[] MakePacket(NetProtocol protocol,byte[] bytes)
    {
        byte[] netProto = new byte[4];
        byte[] body = bytes;
        byte[] head = new byte[4];
        //写入包头长度
        int headlength = body.Length + netProto.Length;
        int writeindex = 0;
        Write(headlength,head ,ref writeindex);
        //写入协议号
        writeindex = 0;
        Write((int)protocol,netProto,ref writeindex);
        //拷贝内容
        byte[] msg = new byte[body.Length + netProto.Length + head.Length];
        Array.Copy(head,0, msg,0,head.Length);
        Array.Copy(netProto,0,msg,head.Length,netProto.Length);
        Array.Copy(body,0,msg,head.Length+netProto.Length,body.Length);
        return msg;
    }
    /// <summary>
    /// 反序列化协议
    /// </summary>
    /// <returns></returns>
    public static NetProtocol DeSerializePortocol(byte[] bytes, int readIdx)
    {
        int value = ReadInt(bytes, ref readIdx);
        return (NetProtocol)value;
    }
 

    public static void Write(int i, byte[] packet,ref int writeidex)
    {
        ConvertTools.GetBytes(i, packet, ref writeidex);
    }

    #region 数据读取
    public static int ReadInt(byte[] buffer, ref int ReadIndex)
    {
        return ConvertTools.ToInt32(buffer, ref ReadIndex);
    }
    #endregion
}
