using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameFramwork
{
    //所有的协议收发的一个单独类
    public class MsgHandleCore : Singleton<MsgHandleCore>
    {
        public void Init()
        {
            NetEvnentCtrl.AddEvent(NetProtocal.SECRET_RESPONSE, RcveSecreResponse);
        }
        //发送秘钥请求
        public void SendSecreRequest(string pSceret)
        {
            Debug.LogError("发送密钥请求");
            SecretRequest request = new SecretRequest();
            request.PublicSceret = pSceret;
            byte[] bytes= SerlializePacket.Serlialize(request);
            NetManager.Instance.SendPacket(NetProtocal.SECRET_REQUEST, bytes);
        }
        //接收秘钥响应
        public void RcveSecreResponse(byte[] data)
        {
            SecretResponse response = SerlializePacket.DeSerlialize<SecretResponse>(data);
            Debug.Log("收到秘钥响应 ：" + response.Sceret);
            NetManager.Instance.SetKey(response.Sceret);
        }

        public void Release()
        {
            NetEvnentCtrl.RemoveEvent(NetProtocal.SECRET_RESPONSE);
        }
    }
}