/*********************************************
 *   Title: 数据包序列化
 *   Description: 
 *   Author: 壹叶成名
 *   Date: 2020.3.29
 *   Modify: 
 *********************************************/
using ProtoBuf;
using System;
using System.IO;
namespace GameFramwork
{

    /// <summary>
    /// 数据包序列化
    /// </summary>
    public class SerlializePacket
    {

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

        public static T DeSerlialize<T>(byte[] bytesData, int offset=0)
        {
            using (var memory = new MemoryStream())
            {
                memory.Write(bytesData, offset, bytesData.Length- offset);
                memory.Position = 0L;
                T result = Serializer.Deserialize<T>(memory);
                return result;
            }
        }

        /// <summary>
        /// 合并包体
        /// </summary>
        /// <returns></returns>
        public static byte[] MakePacket(NetProtocal protocol, byte[] body)
        {
            //包体=协议号+结构体
            ByteArray ProtoArray = PooledClassManager<ByteArray>.Spawn();
            //消息头数组 储存着消息的总长度
            ByteArray HeadArray = PooledClassManager<ByteArray>.Spawn();
            //写入包头长度
            int headlength = body.Length+4;
            Write(headlength, HeadArray);
            //写入协议号
            Write((int)protocol, ProtoArray);
            //拷贝内容
            byte[] msg = new byte[body.Length + HeadArray.Length+ ProtoArray.Length];
            Array.Copy(HeadArray.Bytes, 0, msg, 0, HeadArray.Length);
            Array.Copy(ProtoArray.Bytes, 0, msg, HeadArray.Length, ProtoArray.Length);
            Array.Copy(body, 0, msg, HeadArray.Length+ ProtoArray.Length, body.Length);
            PooledClassManager<ByteArray>.Recycle(HeadArray);
            PooledClassManager<ByteArray>.Recycle(ProtoArray);
            return msg;
        }

        /// <summary>
        /// 反序列化协议
        /// </summary>
        /// <returns></returns>
        public static NetProtocal DeSerializePortocol(byte[] bytes, int readIdx)
        {
            int value = ReadInt(bytes, ref readIdx);
            return (NetProtocal)value;
        }


        public static void Write(int i, ByteArray packet)
        {
            ConvertTools.GetBytes(i, packet.Bytes, ref packet.WriteIdx);
        }

        public static int ReadInt(byte[] buffer, ref int ReadIndex)
        {
            return ConvertTools.ToInt32(buffer, ref ReadIndex);
        }

    }
}