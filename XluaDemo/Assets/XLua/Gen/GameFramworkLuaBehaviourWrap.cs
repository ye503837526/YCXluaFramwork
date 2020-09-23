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
    public class GameFramworkLuaBehaviourWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(GameFramwork.LuaBehaviour);
			Utils.BeginObjectRegister(type, L, translator, 0, 3, 4, 3);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "LoadScript", _m_LoadScript);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "StopTimer", _m_StopTimer);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetTimer", _m_SetTimer);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "LuaTable", _g_get_LuaTable);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LuaScript", _g_get_LuaScript);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Parameter", _g_get_Parameter);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Injections", _g_get_Injections);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "LuaScript", _s_set_LuaScript);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Parameter", _s_set_Parameter);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Injections", _s_set_Injections);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 2, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "AddLuaComponent", _m_AddLuaComponent_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					GameFramwork.LuaBehaviour gen_ret = new GameFramwork.LuaBehaviour();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to GameFramwork.LuaBehaviour constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadScript(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameFramwork.LuaBehaviour gen_to_be_invoked = (GameFramwork.LuaBehaviour)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _scriptPath = LuaAPI.lua_tostring(L, 2);
                    
                        XLua.LuaTable gen_ret = gen_to_be_invoked.LoadScript( _scriptPath );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StopTimer(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameFramwork.LuaBehaviour gen_to_be_invoked = (GameFramwork.LuaBehaviour)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Coroutine _timer = (UnityEngine.Coroutine)translator.GetObject(L, 2, typeof(UnityEngine.Coroutine));
                    
                    gen_to_be_invoked.StopTimer( _timer );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetTimer(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameFramwork.LuaBehaviour gen_to_be_invoked = (GameFramwork.LuaBehaviour)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _delay = (float)LuaAPI.lua_tonumber(L, 2);
                    float _interval = (float)LuaAPI.lua_tonumber(L, 3);
                    int _loop = LuaAPI.xlua_tointeger(L, 4);
                    System.Action<int> _timer = translator.GetDelegate<System.Action<int>>(L, 5);
                    
                        UnityEngine.Coroutine gen_ret = gen_to_be_invoked.SetTimer( _delay, _interval, _loop, _timer );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddLuaComponent_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.GameObject _obj = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    string _luascript = LuaAPI.lua_tostring(L, 2);
                    
                        XLua.LuaTable gen_ret = GameFramwork.LuaBehaviour.AddLuaComponent( _obj, _luascript );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LuaTable(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameFramwork.LuaBehaviour gen_to_be_invoked = (GameFramwork.LuaBehaviour)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.LuaTable);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LuaScript(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameFramwork.LuaBehaviour gen_to_be_invoked = (GameFramwork.LuaBehaviour)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.LuaScript);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Parameter(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameFramwork.LuaBehaviour gen_to_be_invoked = (GameFramwork.LuaBehaviour)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.Parameter);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Injections(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameFramwork.LuaBehaviour gen_to_be_invoked = (GameFramwork.LuaBehaviour)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Injections);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LuaScript(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameFramwork.LuaBehaviour gen_to_be_invoked = (GameFramwork.LuaBehaviour)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.LuaScript = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Parameter(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameFramwork.LuaBehaviour gen_to_be_invoked = (GameFramwork.LuaBehaviour)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Parameter = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Injections(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GameFramwork.LuaBehaviour gen_to_be_invoked = (GameFramwork.LuaBehaviour)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Injections = (GameFramwork.Injection[])translator.GetObject(L, 2, typeof(GameFramwork.Injection[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
