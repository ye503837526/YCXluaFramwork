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
    public class GameFramworkHttpManagerWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(GameFramwork.HttpManager);
			Utils.BeginObjectRegister(type, L, translator, 0, 4, 0, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SendHttpPost", _m_SendHttpPost);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SendHttpGet", _m_SendHttpGet);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SendHttpDownSprite", _m_SendHttpDownSprite);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SendHttpDownTexture", _m_SendHttpDownTexture);
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					GameFramwork.HttpManager gen_ret = new GameFramwork.HttpManager();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to GameFramwork.HttpManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SendHttpPost(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameFramwork.HttpManager gen_to_be_invoked = (GameFramwork.HttpManager)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 5&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<UnityEngine.WWWForm>(L, 3)&& translator.Assignable<System.Action<string>>(L, 4)&& translator.Assignable<System.Action<string>>(L, 5)) 
                {
                    string _url = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.WWWForm _form = (UnityEngine.WWWForm)translator.GetObject(L, 3, typeof(UnityEngine.WWWForm));
                    System.Action<string> _finish = translator.GetDelegate<System.Action<string>>(L, 4);
                    System.Action<string> _error = translator.GetDelegate<System.Action<string>>(L, 5);
                    
                    gen_to_be_invoked.SendHttpPost( _url, _form, _finish, _error );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<UnityEngine.WWWForm>(L, 3)&& translator.Assignable<System.Action<string>>(L, 4)) 
                {
                    string _url = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.WWWForm _form = (UnityEngine.WWWForm)translator.GetObject(L, 3, typeof(UnityEngine.WWWForm));
                    System.Action<string> _finish = translator.GetDelegate<System.Action<string>>(L, 4);
                    
                    gen_to_be_invoked.SendHttpPost( _url, _form, _finish );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to GameFramwork.HttpManager.SendHttpPost!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SendHttpGet(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameFramwork.HttpManager gen_to_be_invoked = (GameFramwork.HttpManager)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Action<string>>(L, 3)&& translator.Assignable<System.Action<string>>(L, 4)) 
                {
                    string _url = LuaAPI.lua_tostring(L, 2);
                    System.Action<string> _finish = translator.GetDelegate<System.Action<string>>(L, 3);
                    System.Action<string> _error = translator.GetDelegate<System.Action<string>>(L, 4);
                    
                    gen_to_be_invoked.SendHttpGet( _url, _finish, _error );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Action<string>>(L, 3)) 
                {
                    string _url = LuaAPI.lua_tostring(L, 2);
                    System.Action<string> _finish = translator.GetDelegate<System.Action<string>>(L, 3);
                    
                    gen_to_be_invoked.SendHttpGet( _url, _finish );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to GameFramwork.HttpManager.SendHttpGet!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SendHttpDownSprite(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameFramwork.HttpManager gen_to_be_invoked = (GameFramwork.HttpManager)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Action<UnityEngine.Sprite>>(L, 3)&& translator.Assignable<System.Action<string>>(L, 4)) 
                {
                    string _url = LuaAPI.lua_tostring(L, 2);
                    System.Action<UnityEngine.Sprite> _finish = translator.GetDelegate<System.Action<UnityEngine.Sprite>>(L, 3);
                    System.Action<string> _error = translator.GetDelegate<System.Action<string>>(L, 4);
                    
                    gen_to_be_invoked.SendHttpDownSprite( _url, _finish, _error );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Action<UnityEngine.Sprite>>(L, 3)) 
                {
                    string _url = LuaAPI.lua_tostring(L, 2);
                    System.Action<UnityEngine.Sprite> _finish = translator.GetDelegate<System.Action<UnityEngine.Sprite>>(L, 3);
                    
                    gen_to_be_invoked.SendHttpDownSprite( _url, _finish );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to GameFramwork.HttpManager.SendHttpDownSprite!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SendHttpDownTexture(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameFramwork.HttpManager gen_to_be_invoked = (GameFramwork.HttpManager)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Action<UnityEngine.Texture>>(L, 3)&& translator.Assignable<System.Action<string>>(L, 4)) 
                {
                    string _url = LuaAPI.lua_tostring(L, 2);
                    System.Action<UnityEngine.Texture> _finish = translator.GetDelegate<System.Action<UnityEngine.Texture>>(L, 3);
                    System.Action<string> _error = translator.GetDelegate<System.Action<string>>(L, 4);
                    
                    gen_to_be_invoked.SendHttpDownTexture( _url, _finish, _error );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Action<UnityEngine.Texture>>(L, 3)) 
                {
                    string _url = LuaAPI.lua_tostring(L, 2);
                    System.Action<UnityEngine.Texture> _finish = translator.GetDelegate<System.Action<UnityEngine.Texture>>(L, 3);
                    
                    gen_to_be_invoked.SendHttpDownTexture( _url, _finish );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to GameFramwork.HttpManager.SendHttpDownTexture!");
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
