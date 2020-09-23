namespace GameFramwork
{
    using UnityEngine;
    using XLua;
    using System.Collections.Generic;
    using System.IO;

    [System.Serializable]
    public class Injection
    {
        public string name;
        public GameObject value;
    }

    public class LuaClient : MonoBehaviour
    {
        //lua脚本路径
        private static string luaScriptsPath { get { return "Assets/GameData/"; } }
        internal static LuaEnv luaEnv = new LuaEnv(); //all lua behaviour shared one luaenv only!
        internal static float lastGCTime = 0;
        internal const float GCInterval = 1;//1 second 

        private void Update()
        {
            if (Time.time - lastGCTime > GCInterval)
            {
                luaEnv.Tick();
                lastGCTime = Time.time;
            }
        }

        private void Init()
        {
            luaEnv.AddLoader(LoadScript);
            luaEnv.DoString("require 'GameHall.Lua.Main' ");
        }

        /// <summary>
        /// 自定义Loader
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        private byte[] LoadScript(ref string filepath)
        {
            string path = filepath.Replace(".", "/");
            int index = path.IndexOf("/");
            string module = path.Substring(0, index);
            string scriptName = path.Substring(index + 1);
            //Debug.Log("scriptpath:"+ scriptName);
            string fillPath = luaScriptsPath + module+ "/"+scriptName +".txt";
            //string connect=  File.ReadAllText(fillPath);
            //string connect = ResourceManager.Instance.LoadResource<TextAsset>(fillPath).bytes;
            //return System.Text.Encoding.UTF8.GetBytes(connect);
            return ResourceManager.Instance.LoadResource<TextAsset>(fillPath).bytes;
        }

        private  void OnDestroy()
        {
            instance = null;
        }

        public  LuaEnv LuaEnv
        {
            get
            {
                return luaEnv;
            }
        }

        private static LuaClient instance;
        public static LuaClient Instance
        {
            get
            {
                if(instance == null)
                {
                    GameObject obj = new GameObject("LuaClient");
                    DontDestroyOnLoad(obj);
                    instance = obj.AddComponent<LuaClient>();
                    instance.Init();
                }
                return instance;
            }
        }

    }
}