using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace GameFramwork
{
    public class HttpManager:Singleton<HttpManager>
    {
        private UnityWebRequestManager nUnityWeb = new UnityWebRequestManager();
 
        /// <summary>
        /// 发送Post请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="form"></param>
        /// <param name="finish"></param>
        /// <param name="error"></param>
        public void SendHttpPost(string url,WWWForm form,Action<string> finish,Action<string> error=null )
        {
            
            UnityWebRequestTask task = new UnityWebRequestTask(url ,DownLoadType.POST, form,
            (request)=> {
                finish.SafeInvoke(request.downloadHandler.text);
            },null ,

            (webtask,unityweb)=> {
                error.SafeInvoke(webtask.downloadHandler.text);
            });
            nUnityWeb.AddTask(task);
        }
        /// <summary>
        /// 发送Get请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="finish"></param>
        /// <param name="error"></param>
        public void SendHttpGet(string url, Action<string> finish, Action<string> error = null)
        {

            UnityWebRequestTask task = new UnityWebRequestTask(url, DownLoadType.GET, 
            (request) => {
                finish.SafeInvoke(request.downloadHandler.text);
            }, null,

            (webtask, unityweb) => {
                error.SafeInvoke(webtask.downloadHandler.text);
            });
            nUnityWeb.AddTask(task);
        }
        /// <summary>
        /// 发送下载图片请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="finish"></param>
        /// <param name="error"></param>
        public void SendHttpDownSprite(string url, Action<Sprite> finish, Action<string> error = null)
        {
            UnityWebRequestTask task = new UnityWebRequestTask(url,(webRequest, webtask, sprite) => {
                finish.SafeInvoke(sprite);
            });
        }
        /// <summary>
        /// 发送下载Texture请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="finish"></param>
        /// <param name="error"></param>
        public void SendHttpDownTexture(string url, Action<Texture> finish, Action<string> error = null)
        {
            UnityWebRequestTask task = new UnityWebRequestTask(url, (webRequest, webtask, sprite) => {
                Texture2D texture2D = DownloadHandlerTexture.GetContent(webRequest);
                finish.SafeInvoke(texture2D);
            });
        }
    }
}