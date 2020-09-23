/*********************************************
 *
 *   Title: UnityWebRequest下载列表
 *
 *   Description: 封装 控制UnityWebRequest 下载的Post请求 Get请求
 *
 *   Author: jin
 *
 *   Date: 2019.7.1
 *
 *   Modify:YYCM
 * 
 *********************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public enum DownLoadType
{
    NONE,
    GET,
    POST,
    POSTMULTIPART,
    TEXTURE
}
public class UnityWebRequestTask
{
    /// <summary>
    /// 下载开始
    /// </summary>
    private Action<UnityWebRequest> m_DownLoadBegin;
    /// <summary>
    /// 下载结束
    /// </summary>
    public Action<UnityWebRequest> m_DownLoadFinish;
    /// <summary>
    /// 下载结束
    /// </summary>
    public Action<UnityWebRequest, UnityWebRequestTask,Sprite> m_DownLoadTextureFinish;
    /// <summary>
    /// 下载错误
    /// </summary>
    private Action<UnityWebRequest, UnityWebRequestTask> m_DownLoadError;
    /// <summary>
    /// 下载类型
    /// </summary>
    private DownLoadType m_DownLoadType;
    /// <summary>
    /// 下载地址
    /// </summary>
    public string m_Url { get; set; }

    private Sprite m_Sprite;

    private WWWForm m_WWWForm;
    /// <summary>
    /// 表单参数  和 WWWForm 用法类似
    /// 使用方式:
    /// m_FormSection.Add(new MultipartFormDataSection("参数1", 参数2));
    /// </summary>
    private List<IMultipartFormSection> m_FormSection = new List<IMultipartFormSection>();
    /// <summary>
    /// Get请求传参
    /// </summary>
    /// <param name="_url">地址</param>
    /// <param name="_type">参数类型</param>
    /// <param name="_downLoadBegin">开始下载</param>
    /// <param name="_downLoadFinish">下载完成</param>
    /// <param name="_downLoadError">错误回调</param>
    public UnityWebRequestTask(string _url, DownLoadType _type, Action<UnityWebRequest> _downLoadFinish, Action<UnityWebRequest> _downLoadBegin = null, Action<UnityWebRequest, UnityWebRequestTask> _downLoadError = null)
    {
        m_Url = _url;
        m_DownLoadType = _type;
        if (_downLoadBegin != null)
            m_DownLoadBegin = _downLoadBegin;
        if (_downLoadError != null)
            m_DownLoadError = _downLoadError;
        m_DownLoadFinish = _downLoadFinish;
    }
    /// <summary>
    /// 图片下载
    /// </summary>
    /// <param name="_url">地址</param>
    /// <param name="_type">参数类型</param>
    /// <param name="_downLoadBegin">开始下载</param>
    /// <param name="_downLoadFinish">下载完成</param>
    /// <param name="_downLoadError">错误回调</param>
    public UnityWebRequestTask(string _url, Action<UnityWebRequest, UnityWebRequestTask, Sprite> _downLoadFinish, Sprite _sprite = null, DownLoadType _type = DownLoadType.TEXTURE, Action<UnityWebRequest> _downLoadBegin = null, Action<UnityWebRequest, UnityWebRequestTask> _downLoadError = null)
    {
        m_Url = _url;
        m_DownLoadType = _type;
        m_Sprite = null;
        if (_sprite != null)
            m_Sprite = _sprite;
        if (_downLoadBegin != null)
            m_DownLoadBegin = _downLoadBegin;
        if (_downLoadError != null)
            m_DownLoadError = _downLoadError;
        m_DownLoadTextureFinish = _downLoadFinish;
    }
    /// <summary>
    /// Post请求传参
    /// </summary>
    /// <param name="_url">地址</param>
    /// <param name="_type">参数类型</param>
    /// <param name="_downLoadBegin">开始下载</param>
    /// <param name="_downLoadFinish">下载完成</param>
    /// <param name="_downLoadError">错误回调</param>
    /// <param name="_form">form参数</param>
    public UnityWebRequestTask(string _url, DownLoadType _type, WWWForm _form, Action<UnityWebRequest> _downLoadFinish, Action<UnityWebRequest> _downLoadBegin = null, Action<UnityWebRequest, UnityWebRequestTask> _downLoadError = null)
    {
        m_Url = _url;
        m_DownLoadType = _type;
        m_WWWForm = _form;
        m_DownLoadFinish = _downLoadFinish;
        if (_downLoadBegin != null)
            m_DownLoadBegin = _downLoadBegin;
        if (_downLoadError != null)
            m_DownLoadError = _downLoadError;
    }
    /// <summary>
    /// Post请求传参
    /// </summary>
    /// <param name="_url">地址</param>
    /// <param name="_type">参数类型</param>
    /// <param name="_downLoadBegin">开始下载</param>
    /// <param name="_downLoadFinish">下载完成</param>
    /// <param name="_downLoadError">错误回调</param>
    /// <param name="_section">参数</param>
    public UnityWebRequestTask(string _url, DownLoadType _type, List<IMultipartFormSection> _section, Action<UnityWebRequest> _downLoadFinish, Action<UnityWebRequest> _downLoadBegin = null, Action<UnityWebRequest, UnityWebRequestTask> _downLoadError = null)
    {
        m_Url = _url;
        m_DownLoadType = _type;
        m_FormSection = _section;
        m_DownLoadFinish = _downLoadFinish;
        if (_downLoadBegin != null)
            m_DownLoadBegin = _downLoadBegin;
        if (_downLoadError != null)
            m_DownLoadError = _downLoadError;
    }
    /// <summary>
    /// 开始下载
    /// </summary>
    /// <returns></returns>
    public IEnumerator DownLoad()
    {
        UnityWebRequest webRequest;
        switch (m_DownLoadType)
        {
            case DownLoadType.GET:
                webRequest = UnityWebRequest.Get(m_Url);
                break;
            case DownLoadType.POST:
                webRequest = UnityWebRequest.Post(m_Url, m_WWWForm);
                break;
            case DownLoadType.POSTMULTIPART:
                webRequest = UnityWebRequest.Post(m_Url, m_FormSection);
                break;
            case DownLoadType.TEXTURE:
                webRequest = UnityWebRequestTexture.GetTexture(m_Url);
                break;
            default:
                webRequest = new UnityWebRequest("http://www.baidu.com");
                break;
        }
        //if (m_DownLoadBegin != null)
        //{
        //    m_DownLoadBegin(webRequest);
        //}
        //等同于非空判断
        m_DownLoadBegin?.Invoke(webRequest);
        webRequest.timeout = 30;
        yield return webRequest.SendWebRequest();
        if (!webRequest.isNetworkError)
        {
            if (m_DownLoadType == DownLoadType.TEXTURE)
            {
               Texture2D texture2D = DownloadHandlerTexture.GetContent(webRequest);
               m_Sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f));
               m_DownLoadTextureFinish?.Invoke(webRequest, this, m_Sprite);
            }
            else
                m_DownLoadFinish?.Invoke(webRequest);
        }
        else
        {
            m_DownLoadError?.Invoke(webRequest, this);
            Debug.LogError("webRequest Error : " + webRequest.error);
            Debug.LogError("webRequest Error url : " + m_Url);
        }
    }
}