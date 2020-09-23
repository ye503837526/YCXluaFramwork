using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameFramwork
{
    //[CreateAssetMenu(fileName = "GameDefine", menuName = "CreatGameDefine", order = 0)]
    public enum LoadAssetType
    {
        Editor,
        AssetBundle,
    }
    public class GameDefine : ScriptableObject
    {
        private static GameDefine define;
        public static GameDefine Instanse
        {
            get
            {
                if (define == null)
                    define = Resources.Load<GameDefine>("GameDefine");
                return define;
            }
        }

        [Header("AssetBundle热更包配置下载地址")]
        public string AssetBundleDownURL = "http://192.168.124.71"; //AssetBundle下载地址
        [Header("Editor加载资源方式")]
        public LoadAssetType EditorLoadAssetType; //从AssetBundle中加载资源
    }
}