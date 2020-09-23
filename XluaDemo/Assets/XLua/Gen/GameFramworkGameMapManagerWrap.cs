#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class GameFramworkGameMapManagerWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(GameFramwork.GameMapManager);
			Utils.BeginObjectRegister(type, L, translator, 0, 2, 5, 5);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Init", _m_Init);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "LoadScene", _m_LoadScene);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "CurrentMapName", _g_get_CurrentMapName);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "AlreadyLoadScene", _g_get_AlreadyLoadScene);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LoadSceneOverCallBack", _g_get_LoadSceneOverCallBack);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LoadSceneEnterCallBack", _g_get_LoadSceneEnterCallBack);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "SetSceneSettingCallBack", _g_get_SetSceneSettingCallBack);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "CurrentMapName", _s_set_CurrentMapName);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "AlreadyLoadScene", _s_set_AlreadyLoadScene);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "LoadSceneOverCallBack", _s_set_LoadSceneOverCallBack);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "LoadSceneEnterCallBack", _s_set_LoadSceneEnterCallBack);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "SetSceneSettingCallBack", _s_set_SetSceneSettingCallBack);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 1, 1);
			
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "LoadingProgress", _g_get_LoadingProgress);
            
			Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "LoadingProgress", _s_set_LoadingProgress);
            
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					GameFramwork.GameMapManager gen_ret = new GameFramwork.GameMapManager();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to GameFramwork.GameMapManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Init(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameFramwork.GameMapManager gen_to_be_invoked = (GameFramwork.GameMapManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.MonoBehaviour _mono = (UnityEngine.MonoBehaviour)translator.GetObject(L, 2, typeof(UnityEngine.MonoBehaviour));
                    
                    gen_to_be_invoked.Init( _mono );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadScene(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameFramwork.GameMapManager gen_to_be_invoked = (GameFramwork.GameMapManager)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    string _name = LuaAPI.lua_tostring(L, 2);
                    bool _jumpLoading = LuaAPI.lua_toboolean(L, 3);
                    
                    gen_to_be_invoked.LoadScene( _name, _jumpLoading );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _name = LuaAPI.lua_tostring(L, 2);
                    
                    gen_to_be_invoked.LoadScene( _name );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to GameFramwork.GameMapManager.LoadScene!");
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CurrentMapName(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameFramwork.GameMapManager gen_to_be_invoked = (GameFramwork.GameMapManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.CurrentMapName);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AlreadyLoadScene(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameFramwork.GameMapManager gen_to_be_invoked = (GameFramwork.GameMapManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.AlreadyLoadScene);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LoadSceneOverCallBack(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameFramwork.GameMapManager gen_to_be_invoked = (GameFramwork.GameMapManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.LoadSceneOverCallBack);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LoadSceneEnterCallBack(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameFramwork.GameMapManager gen_to_be_invoked = (GameFramwork.GameMapManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.LoadSceneEnterCallBack);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SetSceneSettingCallBack(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameFramwork.GameMapManager gen_to_be_invoked = (GameFramwork.GameMapManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.SetSceneSettingCallBack);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LoadingProgress(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, GameFramwork.GameMapManager.LoadingProgress);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CurrentMapName(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameFramwork.GameMapManager gen_to_be_invoked = (GameFramwork.GameMapManager)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.CurrentMapName = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_AlreadyLoadScene(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameFramwork.GameMapManager gen_to_be_invoked = (GameFramwork.GameMapManager)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.AlreadyLoadScene = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LoadSceneOverCallBack(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameFramwork.GameMapManager gen_to_be_invoked = (GameFramwork.GameMapManager)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.LoadSceneOverCallBack = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LoadSceneEnterCallBack(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameFramwork.GameMapManager gen_to_be_invoked = (GameFramwork.GameMapManager)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.LoadSceneEnterCallBack = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SetSceneSettingCallBack(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameFramwork.GameMapManager gen_to_be_invoked = (GameFramwork.GameMapManager)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.SetSceneSettingCallBack = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LoadingProgress(RealStatePtr L)
        {
		    try {
                
			    GameFramwork.GameMapManager.LoadingProgress = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
