
 
using UnityEngine;
namespace GameFramwork
{
    public class Main : MonoBehaviour
    {
        public static Main Instanse;
        //场景节点
        public Transform SceneTrs;
        //回收池节点
        public Transform RecyclePoolTrs;
        //UI节点
        public Transform UIRoot;
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            Instanse = this;
            //初始化资源加载框架
            ResourceManager.Instance.Init(this, GameDefine.Instanse.EditorLoadAssetType == LoadAssetType.AssetBundle);
            //初始化资源管理器
            AssetsManager.Instance.Resource = ResourceManager.Instance.mAssetLoader;
            //初始化对象池管理框架
            ObjectManager.Instance.Init(RecyclePoolTrs, SceneTrs, UIRoot);
            //初始化热更补丁框架
            HotPatchManager.Instance.Init(this, GameDefine.Instanse.AssetBundleDownURL);
           
        }
        void Start()
        {
            //检查资源更新
            HotUpdaterManage.Instance.InitHotFix();
        }

        void Update()
        {
            NetManager.Instance.Update();
        }

        /// <summary>
        /// 资源热更完成 初始化游戏
        /// </summary>
        public void InitGame()
        {
            Debug.Log("资源热更完成 初始化游戏");
            //初始化消息处理中心
            MsgHandleCore.Instance.Init();
            //启动Lua
            XLua.LuaEnv luaEnv= LuaClient.Instance.LuaEnv;
            //NetManager.Instance.Connect("192.168.124.71", 8011);
        }
        void OnApplicationPause()
        {

        }
        void OnDestroy()
        {
            Debug.Log("Ondestroy");
        }
        void OnApplicationQuit()
        {
            Debug.Log("OnApplicationQuit");
            Exit();
        }

        private void Exit()
        {
#if UNITY_EDITOR
            //释放资源加载框架
            ResourceManager.Instance.ClearCache();
            //释放对象池管理框架
            ObjectManager.Instance.ClearCache();

            ResourceManager.Instance.ClearCache();
            Resources.UnloadUnusedAssets();
            Debug.Log("清空编辑器缓存");
#endif

            NetManager.Instance.Close();
            MsgHandleCore.Instance.Release();
            gameObject.SetActive(false);
            GameObject.DestroyImmediate(gameObject);

        }
    }
}