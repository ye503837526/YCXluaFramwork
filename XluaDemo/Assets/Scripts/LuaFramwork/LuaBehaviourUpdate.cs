namespace GameFramwork
{
    using System;
    using UnityEngine;
    using XLua;

    public class LuaBehaviourUpdate : LuaBehaviour
    {
        protected Action<LuaTable> luaUpdate;
  

        protected override void AttachScript()
        {
            base.AttachScript();
            scriptEnv.Get("Update", out luaUpdate);
        }

        protected override void OnDestroy()
        {
            
            base.OnDestroy();
        }

        private void Update()
        {
            if(luaUpdate!=null)
            {
                luaUpdate(scriptEnv);
            }
        }
    }
}