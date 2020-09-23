    /// <summary>
    /// 数据包 用来扩展命令
    /// </summary>
    public class WfPacket:PooledClassObject
    {
        //协议号
        public NetProtocal Protocol=NetProtocal.None;
    }
