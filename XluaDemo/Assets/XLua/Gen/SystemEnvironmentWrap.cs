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
    public class SystemEnvironmentWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(System.Environment);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 10, 19, 2);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "Exit", _m_Exit_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ExpandEnvironmentVariables", _m_ExpandEnvironmentVariables_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetCommandLineArgs", _m_GetCommandLineArgs_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetEnvironmentVariable", _m_GetEnvironmentVariable_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetEnvironmentVariables", _m_GetEnvironmentVariables_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetFolderPath", _m_GetFolderPath_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetLogicalDrives", _m_GetLogicalDrives_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetEnvironmentVariable", _m_SetEnvironmentVariable_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "FailFast", _m_FailFast_xlua_st_);
            
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "CommandLine", _g_get_CommandLine);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "CurrentDirectory", _g_get_CurrentDirectory);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "CurrentManagedThreadId", _g_get_CurrentManagedThreadId);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "ExitCode", _g_get_ExitCode);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "HasShutdownStarted", _g_get_HasShutdownStarted);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "MachineName", _g_get_MachineName);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "NewLine", _g_get_NewLine);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "OSVersion", _g_get_OSVersion);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "StackTrace", _g_get_StackTrace);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "TickCount", _g_get_TickCount);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "UserDomainName", _g_get_UserDomainName);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "UserInteractive", _g_get_UserInteractive);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "UserName", _g_get_UserName);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "Version", _g_get_Version);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "WorkingSet", _g_get_WorkingSet);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "Is64BitOperatingSystem", _g_get_Is64BitOperatingSystem);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "SystemPageSize", _g_get_SystemPageSize);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "Is64BitProcess", _g_get_Is64BitProcess);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "ProcessorCount", _g_get_ProcessorCount);
            
			Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "CurrentDirectory", _s_set_CurrentDirectory);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "ExitCode", _s_set_ExitCode);
            
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "System.Environment does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Exit_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    int _exitCode = LuaAPI.xlua_tointeger(L, 1);
                    
                    System.Environment.Exit( _exitCode );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ExpandEnvironmentVariables_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _name = LuaAPI.lua_tostring(L, 1);
                    
                        string gen_ret = System.Environment.ExpandEnvironmentVariables( _name );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCommandLineArgs_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    
                        string[] gen_ret = System.Environment.GetCommandLineArgs(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEnvironmentVariable_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string _variable = LuaAPI.lua_tostring(L, 1);
                    
                        string gen_ret = System.Environment.GetEnvironmentVariable( _variable );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.EnvironmentVariableTarget>(L, 2)) 
                {
                    string _variable = LuaAPI.lua_tostring(L, 1);
                    System.EnvironmentVariableTarget _target;translator.Get(L, 2, out _target);
                    
                        string gen_ret = System.Environment.GetEnvironmentVariable( _variable, _target );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Environment.GetEnvironmentVariable!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEnvironmentVariables_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 0) 
                {
                    
                        System.Collections.IDictionary gen_ret = System.Environment.GetEnvironmentVariables(  );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<System.EnvironmentVariableTarget>(L, 1)) 
                {
                    System.EnvironmentVariableTarget _target;translator.Get(L, 1, out _target);
                    
                        System.Collections.IDictionary gen_ret = System.Environment.GetEnvironmentVariables( _target );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Environment.GetEnvironmentVariables!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFolderPath_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& translator.Assignable<System.Environment.SpecialFolder>(L, 1)) 
                {
                    System.Environment.SpecialFolder _folder;translator.Get(L, 1, out _folder);
                    
                        string gen_ret = System.Environment.GetFolderPath( _folder );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<System.Environment.SpecialFolder>(L, 1)&& translator.Assignable<System.Environment.SpecialFolderOption>(L, 2)) 
                {
                    System.Environment.SpecialFolder _folder;translator.Get(L, 1, out _folder);
                    System.Environment.SpecialFolderOption _option;translator.Get(L, 2, out _option);
                    
                        string gen_ret = System.Environment.GetFolderPath( _folder, _option );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Environment.GetFolderPath!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLogicalDrives_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    
                        string[] gen_ret = System.Environment.GetLogicalDrives(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetEnvironmentVariable_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _variable = LuaAPI.lua_tostring(L, 1);
                    string _value = LuaAPI.lua_tostring(L, 2);
                    
                    System.Environment.SetEnvironmentVariable( _variable, _value );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.EnvironmentVariableTarget>(L, 3)) 
                {
                    string _variable = LuaAPI.lua_tostring(L, 1);
                    string _value = LuaAPI.lua_tostring(L, 2);
                    System.EnvironmentVariableTarget _target;translator.Get(L, 3, out _target);
                    
                    System.Environment.SetEnvironmentVariable( _variable, _value, _target );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Environment.SetEnvironmentVariable!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FailFast_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string _message = LuaAPI.lua_tostring(L, 1);
                    
                    System.Environment.FailFast( _message );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Exception>(L, 2)) 
                {
                    string _message = LuaAPI.lua_tostring(L, 1);
                    System.Exception _exception = (System.Exception)translator.GetObject(L, 2, typeof(System.Exception));
                    
                    System.Environment.FailFast( _message, _exception );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Environment.FailFast!");
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CommandLine(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, System.Environment.CommandLine);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CurrentDirectory(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, System.Environment.CurrentDirectory);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CurrentManagedThreadId(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, System.Environment.CurrentManagedThreadId);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ExitCode(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, System.Environment.ExitCode);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HasShutdownStarted(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, System.Environment.HasShutdownStarted);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MachineName(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, System.Environment.MachineName);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NewLine(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, System.Environment.NewLine);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OSVersion(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, System.Environment.OSVersion);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StackTrace(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, System.Environment.StackTrace);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TickCount(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, System.Environment.TickCount);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UserDomainName(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, System.Environment.UserDomainName);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UserInteractive(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, System.Environment.UserInteractive);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UserName(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, System.Environment.UserName);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Version(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, System.Environment.Version);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_WorkingSet(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushint64(L, System.Environment.WorkingSet);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Is64BitOperatingSystem(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, System.Environment.Is64BitOperatingSystem);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SystemPageSize(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, System.Environment.SystemPageSize);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Is64BitProcess(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, System.Environment.Is64BitProcess);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ProcessorCount(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, System.Environment.ProcessorCount);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CurrentDirectory(RealStatePtr L)
        {
		    try {
                
			    System.Environment.CurrentDirectory = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ExitCode(RealStatePtr L)
        {
		    try {
                
			    System.Environment.ExitCode = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
