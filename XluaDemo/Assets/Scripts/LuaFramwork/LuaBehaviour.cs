namespace GameFramwork
{
    using System;
    using UnityEngine;
    using XLua;
    using System.Collections;
    using System.Collections.Generic;

    public class LuaBehaviour : MonoBehaviour
    {
        public string LuaScript;
        public string Parameter;
        public Injection[] Injections;
        protected Action<LuaTable> luaAwake;
        protected Action<LuaTable> luaStart;
        protected Action<LuaTable> luaOnDestroy;
        protected Action<LuaTable> luaOnEnable;
        protected Action<LuaTable> luaOnDisable;
        protected Action<LuaTable> luaOnApplicationQuit;
        protected LuaEnv luaEnv;
        protected LuaEnv LuaEnv
        {
            get
            {
                if (luaEnv == null)
                {
                    luaEnv = LuaClient.Instance.LuaEnv;
                }
                return luaEnv;
            }
        }

        protected LuaTable scriptEnv;
        public LuaTable LuaTable
        {
            get
            {
                if (scriptEnv == null)
                {
                    scriptEnv = LoadScript(LuaScript);
                }
                return scriptEnv;
            }
        }

        private bool isLoaded = false;
        private const string requireFormat = @"return require(""{0}"")";
        public LuaTable LoadScript(string scriptPath)
        {
            if (string.IsNullOrEmpty(scriptPath))
            {
                return null;
            }
            if (isLoaded)
            {
                return scriptEnv;
            }
            isLoaded = true;
            LuaScript = scriptPath;
            object[] objs = LuaEnv.DoString(string.Format(requireFormat,LuaScript),LuaScript);
            if(objs == null)
            {
                UnityEngine.Debug.LogError("LoadScriptError:"+LuaScript);
                return null;
            }
            LuaTable metatable = objs[0] as LuaTable;
            LuaFunction newfunc;
            metatable.Get("new",out newfunc);
            if(newfunc == null)
            {
 
                return null;
            }
            scriptEnv = newfunc.Func<LuaTable, LuaTable>(null);
            BindVariable();
            AttachScript();
            return scriptEnv;
        }

        protected virtual void BindVariable()
        {
            scriptEnv.Set("behaviour", this);
            scriptEnv.Set("transform", this.transform);
            scriptEnv.Set("gameObject", this.gameObject);
            if (Injections != null && Injections.Length > 0)
            {
                foreach (var injection in Injections)
                {
                    scriptEnv.Set(injection.name.Trim(), injection.value);
                }
            }
            if (!string.IsNullOrEmpty(Parameter))
            {
                scriptEnv.Set("parameter", Parameter);
            }
        }

        protected virtual void AttachScript()
        {
            scriptEnv.Get("Awake", out luaAwake);
            scriptEnv.Get("Start", out luaStart);
            scriptEnv.Get("OnDestroy", out luaOnDestroy);
            scriptEnv.Get("OnEnable", out luaOnEnable);
            scriptEnv.Get("OnDisable", out luaOnDisable);
            scriptEnv.Get("OnApplicationQuit", out luaOnApplicationQuit);
        }

        protected virtual void Awake()
        {
            LoadScript(LuaScript);
            if (luaAwake != null)
            {
                luaAwake(scriptEnv);
            }
        }

        protected virtual void OnEnable()
        {
            if (luaOnEnable !=null)
            {
                luaOnEnable(scriptEnv);
            }
        }

        protected virtual void OnDisable()
        {
            if(luaOnDisable != null)
            {
                luaOnDisable(scriptEnv);
            }
        }

        // Use this for initialization
        protected virtual void Start()
        {
            if (luaStart != null)
            {
                luaStart(scriptEnv);
            }
        }

        protected virtual void OnApplicationQuit()
        {
            if(luaOnApplicationQuit != null)
            {
                luaOnApplicationQuit(scriptEnv);
            }
        }

        protected virtual void OnDestroy()
        {
            if (luaOnDestroy != null)
            {
                luaOnDestroy(scriptEnv);
            }
            if (scriptEnv != null)
            {
                scriptEnv.Dispose();
                scriptEnv = null;
            }
            Injections = null;
            Parameter = null;
            luaOnDestroy = null;
            luaStart = null;
            luaOnEnable = null;
            luaOnDisable = null;
            luaOnApplicationQuit = null;
        }

        public void StopTimer(Coroutine timer)
        {
            StopCoroutine(timer);
        }

        public Coroutine SetTimer(float delay,float interval,int loop, Action<int> timer)
        {
            Coroutine cor =  StartCoroutine(ontimer(delay, interval, loop, timer));
            return cor;
        }

        private IEnumerator ontimer(float delay,float interval,int loop,Action<int> timer)
        {
            yield return new WaitForSeconds(delay);
            WaitForSeconds wait = new WaitForSeconds(interval);
            if(loop <= 0)
            {
                while(true)
                {
                    timer(0);
                    yield return wait;
                }
            }
            else
            {
                for(int i=0;i<loop;i++)
                {
                    timer(i);
                    yield return wait;
                }
            }
        }

        public static LuaTable AddLuaComponent(GameObject obj,string luascript)
        {
            LuaBehaviour behaviour = obj.AddComponent<LuaBehaviour>();
            return behaviour.LoadScript(luascript);
        }
    }
}