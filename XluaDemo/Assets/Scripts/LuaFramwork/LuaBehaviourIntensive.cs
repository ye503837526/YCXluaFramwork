namespace GameFramwork
{
    using System;
    using UnityEngine;
    using XLua;

    public class LuaBehaviourIntensive : LuaBehaviour
    {
        protected Action<LuaTable,int> luaOnApplicationPause;
        protected Action<LuaTable,int> luaOnApplicationFocus;

        protected override void AttachScript()
        {
            base.AttachScript();
            scriptEnv.Get("OnApplicationPause", out luaOnApplicationPause);
            scriptEnv.Get("OnApplicationFocus", out luaOnApplicationFocus);
        }
    
        protected override void OnDestroy()
        {
            luaOnApplicationPause = null;
            luaOnApplicationFocus = null;
            base.OnDestroy();
        }

 //#if !UNITY_EDITOR && (UNITY_IPHONE || UNITY_ANDROID)
        void OnApplicationPause(bool pause)
        {
            if(luaOnApplicationPause != null)
            {
                luaOnApplicationPause(scriptEnv,pause?1:0);
            }
        }

        //游戏失去焦点也就是进入后台时 focus为false 切换回前台时 focus为true
        void OnApplicationFocus(bool focus)
        {
            if(luaOnApplicationFocus != null)
            {
                luaOnApplicationFocus(scriptEnv,focus?1:0);
            }
        }
//#endif
    }
}