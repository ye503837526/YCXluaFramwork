using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;
using SimServer.Net;

namespace SimServer
{
    public class LogicMain:Singleton<LogicMain>
    {
        public  void Init()
        {
            NetEvnentCtrl.AddEvent(NetProtocol.SECRET_REQUEST, HandleSceretRequest);
            NetEvnentCtrl.AddEvent(NetProtocol.Ping, HandlePingRequest);
            NetEvnentCtrl.AddEvent(NetProtocol.LOGIN_LOGIN_REQUEST, HandleLoginRequest);
        }
        //处理秘钥请求
        public void HandleSceretRequest(ClientSocket client,byte[] data)
        {
            Debug.Log("收到了客户端发来的消息！" + NetProtocol.SECRET_RESPONSE);
            //处理请求
            SecretRequest request = SerlializePacket.DeSerlialize<SecretRequest>(data);
            if (request.PublicSceret==ServerSocket.PublicKey)
            {
                client.Sceret = client.Sceret + ServerSocket.GetTimeStamp().ToString();
                Debug.Log("client.Sceret :"+ client.Sceret);
                //回复响应
                SecretResponse response = new SecretResponse();
                response.Sceret = client.Sceret;
                byte[] bytes= SerlializePacket.Serlialize(response);
                
                client.SendPacket(NetProtocol.SECRET_RESPONSE, bytes);
            }
            else
            {
                client.CloseSocket();
                Debug.LogError("请求公钥验证错误 断开连接！");
            }
          

        }
        public void HandlePingRequest(ClientSocket client, byte[] data)
        {
            Debug.Log("收到了心跳包 ");
            client.LastPingTime = ServerSocket.GetTimeStamp();
            Ping ping = new Ping();
            byte[] bytes=  SerlializePacket.Serlialize(ping);
            client.SendPacket(NetProtocol.Ping, bytes);
            Debug.Log("回应了心跳包 ");
        }

        public void HandleLoginRequest(ClientSocket client, byte[] data)
        {
            Debug.Log("收到了客户端发来的登录请求！" );
            LoginRequest request = SerlializePacket.DeSerlialize<LoginRequest>(data);
 
            Debug.Log("request.LoginType:"+ request.LoginType);
            Debug.Log("request.LoginType:" + request.Name);
            Debug.Log("request.LoginType:" + request.Gmaeid);

            LoginResponse response = new LoginResponse();
            response.name = "服务器给你起的名字";
            response.gold = 99999999;
            response.diamond = 888888888;
            Debug.Log("发送登录响应！");
            client.SendPacket(NetProtocol.LOGIN_LOGIN_RESPONSE, SerlializePacket.Serlialize(response));
        }
    }
}
