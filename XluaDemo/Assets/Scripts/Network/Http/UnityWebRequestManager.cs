/*********************************************
 *
 *   Title: UnityWebRequest下载管理器
 *
 *   Description: 统一获取需要请求的Web数据,用法很简单,只需要去声明 UnityWebRequestTask task = new UnityWebRequestTask(传递参数) 然后 AddTask(task)
 * 
 *   Author: jin
 *
 *   Date: 2019.7.1
 *
 *   Modify: YYCM
 * 
 *********************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UnityWebRequestManager : MonoSingleton<UnityWebRequestManager>
{
    /// <summary>
    /// 下载任务队列
    /// </summary>
    private Queue<UnityWebRequestTask> m_TaskQue = new Queue<UnityWebRequestTask>();
    /// <summary>
    /// 最大并发数
    /// </summary>
    private int m_MaxCount = 10;
    /// <summary>
    /// 当前下载数
    /// </summary>
    private int m_CurrentCount = 0;
    /// <summary>
    /// 是否下载完成
    /// </summary>
    private bool m_AllFinish = true;

    protected override void Awake()
    {
        base.Awake();
    }

    /// <summary>
    /// 添加下载任务
    /// </summary>
    /// <param name="task"></param>
    public void AddTask(UnityWebRequestTask task)
    {
        m_TaskQue.Enqueue(task);
        if (m_AllFinish)
            StartCoroutine(DownLoadQueue());
    }
    /// <summary>
    /// 添加下载图片任务
    /// </summary>
    /// <param name="task"></param>
    public void AddTextureTask(UnityWebRequestTask task)
    {
        m_TaskQue.Enqueue(task);
        if (m_AllFinish)
            StartCoroutine(DownLoadTextureQueue());
    }
    /// <summary>
    /// 开始下载任务
    /// </summary>
    /// <returns></returns>
    IEnumerator DownLoadQueue()
    {
        m_AllFinish = false;
        while (m_TaskQue.Count>0)
        {
            if (m_CurrentCount<m_MaxCount)
            {
                m_CurrentCount++;
                UnityWebRequestTask task = m_TaskQue.Dequeue();
                task.m_DownLoadFinish += delegate (UnityWebRequest webRequest)
                  {
                      m_CurrentCount--;
                  };
                StartCoroutine(task.DownLoad());
            }
            yield return null;
        }
        m_AllFinish = true;
    }
    /// <summary>
    /// 开始下载任务
    /// </summary>
    /// <returns></returns>
    IEnumerator DownLoadTextureQueue()
    {
        m_AllFinish = false;
        while (m_TaskQue.Count > 0)
        {
            if (m_CurrentCount < m_MaxCount)
            {
                m_CurrentCount++;
                UnityWebRequestTask task = m_TaskQue.Dequeue();
                task.m_DownLoadTextureFinish += delegate (UnityWebRequest webRequest,UnityWebRequestTask webRequestTask,Sprite sprite)
                {
                    m_CurrentCount--;
                };
                StartCoroutine(task.DownLoad());
            }
            yield return null;
        }
        m_AllFinish = true;
    }
}