using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
namespace GameFramwork
{
    public class GameMapManager : Singleton<GameMapManager>
    {
        //加载场景完成回调
        public Action LoadSceneOverCallBack;
        //加载场景开始回调
        public Action LoadSceneEnterCallBack;
        //设置场景设置回调
        public Action SetSceneSettingCallBack;
        //当前场景名
        public string CurrentMapName { get; set; } = "Main";

        //场景加载是否完成
        public bool AlreadyLoadScene { get; set; }

        //切换场景进度条
        public static int LoadingProgress = 0;

        private MonoBehaviour m_Mono;

        /// <summary>
        /// 场景管理初始化
        /// </summary>
        /// <param name="mono"></param>
        public void Init(MonoBehaviour mono)
        {
            m_Mono = mono;
        }

        /// <summary>
        /// 加载场景
        /// </summary>
        /// <param name="name">场景名</param>
        public void LoadScene(string name, bool jumpLoading = false)
        {
            LoadingProgress = 0;

            //跳过加载
            if (jumpLoading == true)
            {
                Debug.LogError("跳过场景");
                LoadSceneEnterCallBack.SafeInvoke();
                CurrentMapName = name;
                SetSceneSettingCallBack.SafeInvoke();
                LoadSceneOverCallBack.SafeInvoke();
            }
            m_Mono.StartCoroutine(LoadSceneAsync(name, jumpLoading));
        }

        /// <summary>
        /// 设置场景环境
        /// </summary>
        /// <param name="name"></param>
        void SetSceneSetting(string name)
        {
            //设置各种场景环境，可以根据配表来,TODO:
            if (SetSceneSettingCallBack != null)
                SetSceneSettingCallBack();
        }
        /// <summary>
        ///异步加载场景 如果跳过加载就不显示进度，直接触发加载完成回调，场景在后台加载
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IEnumerator LoadSceneAsync(string name, bool jumpLoading)
        {
            if (LoadSceneEnterCallBack != null&&jumpLoading==false)
            {
                LoadSceneEnterCallBack();
            }
         
            ClearCache();
            AlreadyLoadScene = false;
            AsyncOperation unLoadScene = SceneManager.LoadSceneAsync(ConStr.EMPTYSCENE, LoadSceneMode.Single);
            while (unLoadScene != null && !unLoadScene.isDone)
            {
                yield return new WaitForEndOfFrame();
            }
            LoadingProgress = 0;
            int targetProgress = 0;
            AsyncOperation asyncScene = SceneManager.LoadSceneAsync(name);
            if (asyncScene != null && !asyncScene.isDone)
            {
                asyncScene.allowSceneActivation = false;
                while (asyncScene.progress < 0.9f)
                {
                    targetProgress = (int)asyncScene.progress * 100;
                    yield return new WaitForEndOfFrame();
                    //平滑过渡
                    while (LoadingProgress < targetProgress)
                    {
                        ++LoadingProgress;
                        yield return new WaitForEndOfFrame();
                    }
                }

                CurrentMapName = name;
                if (jumpLoading == false)
                    SetSceneSetting(name);
                //自行加载剩余的10%
                targetProgress = 100;
                while (LoadingProgress < targetProgress - 2)
                {
                    ++LoadingProgress;
                    yield return new WaitForEndOfFrame();
                }
                LoadingProgress = 100;
                asyncScene.allowSceneActivation = true;
                AlreadyLoadScene = true;
                if (LoadSceneOverCallBack != null && jumpLoading == false)
                {
                    LoadSceneOverCallBack();
                }
            }
        }

        /// <summary>
        /// 跳场景需要清除的东西
        /// </summary>
        private void ClearCache()
        {
            ObjectManager.Instance.ClearCache();
            ResourceManager.Instance.ClearCache();
        }
    }
}