#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using System;


namespace XLua
{
    public partial class DelegateBridge : DelegateBridgeBase
    {
		
		public void __Gen_Delegate_Imp0()
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                
                
                PCall(L, 0, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public double __Gen_Delegate_Imp1(double p0, double p1)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                
                LuaAPI.lua_pushnumber(L, p0);
                LuaAPI.lua_pushnumber(L, p1);
                
                PCall(L, 2, 1, errFunc);
                
                
                double __gen_ret = LuaAPI.lua_tonumber(L, errFunc + 1);
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp2(string p0)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                
                LuaAPI.lua_pushstring(L, p0);
                
                PCall(L, 1, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp3(double p0)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                
                LuaAPI.lua_pushnumber(L, p0);
                
                PCall(L, 1, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public int __Gen_Delegate_Imp4(int p0)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                
                LuaAPI.xlua_pushinteger(L, p0);
                
                PCall(L, 1, 1, errFunc);
                
                
                int __gen_ret = LuaAPI.xlua_tointeger(L, errFunc + 1);
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public UnityEngine.Vector3 __Gen_Delegate_Imp5(UnityEngine.Vector3 p0)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushUnityEngineVector3(L, p0);
                
                PCall(L, 1, 1, errFunc);
                
                
                UnityEngine.Vector3 __gen_ret;translator.Get(L, errFunc + 1, out __gen_ret);
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public XLuaTest.MyStruct __Gen_Delegate_Imp6(XLuaTest.MyStruct p0)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushXLuaTestMyStruct(L, p0);
                
                PCall(L, 1, 1, errFunc);
                
                
                XLuaTest.MyStruct __gen_ret;translator.Get(L, errFunc + 1, out __gen_ret);
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public XLuaTest.MyEnum __Gen_Delegate_Imp7(XLuaTest.MyEnum p0)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushXLuaTestMyEnum(L, p0);
                
                PCall(L, 1, 1, errFunc);
                
                
                XLuaTest.MyEnum __gen_ret;translator.Get(L, errFunc + 1, out __gen_ret);
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public decimal __Gen_Delegate_Imp8(decimal p0)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushDecimal(L, p0);
                
                PCall(L, 1, 1, errFunc);
                
                
                decimal __gen_ret;translator.Get(L, errFunc + 1, out __gen_ret);
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp9(System.Array p0)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.Push(L, p0);
                
                PCall(L, 1, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp10(bool p0)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                
                LuaAPI.lua_pushboolean(L, p0);
                
                PCall(L, 1, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public int __Gen_Delegate_Imp11(int p0, string p1, out Tutorial.CSCallLua.DClass p2)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                LuaAPI.xlua_pushinteger(L, p0);
                LuaAPI.lua_pushstring(L, p1);
                
                PCall(L, 2, 2, errFunc);
                
                p2 = (Tutorial.CSCallLua.DClass)translator.GetObject(L, errFunc + 2, typeof(Tutorial.CSCallLua.DClass));
                
                int __gen_ret = LuaAPI.xlua_tointeger(L, errFunc + 1);
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public System.Action __Gen_Delegate_Imp12()
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                
                PCall(L, 0, 1, errFunc);
                
                
                System.Action __gen_ret = translator.GetDelegate<System.Action>(L, errFunc + 1);
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public XLuaTest.InvokeLua.ICalc __Gen_Delegate_Imp13(int p0, string[] p1)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                LuaAPI.xlua_pushinteger(L, p0);
                if (p1 != null)  { for (int __gen_i = 0; __gen_i < p1.Length; ++__gen_i) LuaAPI.lua_pushstring(L, p1[__gen_i]); };
                
                PCall(L, 1 + (p1 == null ? 0 : p1.Length), 1, errFunc);
                
                
                XLuaTest.InvokeLua.ICalc __gen_ret = (XLuaTest.InvokeLua.ICalc)translator.GetObject(L, errFunc + 1, typeof(XLuaTest.InvokeLua.ICalc));
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp14(int p0)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                
                LuaAPI.xlua_pushinteger(L, p0);
                
                PCall(L, 1, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp15(float p0)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                
                LuaAPI.lua_pushnumber(L, p0);
                
                PCall(L, 1, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp16(object p0)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                
                PCall(L, 1, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp17(object p0, object p1)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                translator.PushAny(L, p1);
                
                PCall(L, 2, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp18(XLua.LuaTable p0)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.Push(L, p0);
                
                PCall(L, 1, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp19(XLua.LuaTable p0, int p1)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.Push(L, p0);
                LuaAPI.xlua_pushinteger(L, p1);
                
                PCall(L, 2, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp20(UnityEngine.EventSystems.PointerEventData p0)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.Push(L, p0);
                
                PCall(L, 1, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp21(long p0, long p1)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                
                LuaAPI.lua_pushint64(L, p0);
                LuaAPI.lua_pushint64(L, p1);
                
                PCall(L, 2, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp22(string p0, int p1)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                
                LuaAPI.lua_pushstring(L, p0);
                LuaAPI.xlua_pushinteger(L, p1);
                
                PCall(L, 2, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp23(string p0, float p1)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                
                LuaAPI.lua_pushstring(L, p0);
                LuaAPI.lua_pushnumber(L, p1);
                
                PCall(L, 2, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp24(int p0, byte[] p1)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                
                LuaAPI.xlua_pushinteger(L, p0);
                LuaAPI.lua_pushstring(L, p1);
                
                PCall(L, 2, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp25(XLua.LuaTable p0, object p1)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.Push(L, p0);
                translator.PushAny(L, p1);
                
                PCall(L, 2, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp26(UnityEngine.AsyncOperation p0)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.Push(L, p0);
                
                PCall(L, 1, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp27(string p0, string p1, UnityEngine.Transform p2)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                LuaAPI.lua_pushstring(L, p0);
                LuaAPI.lua_pushstring(L, p1);
                translator.Push(L, p2);
                
                PCall(L, 3, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp28(int p0, UnityEngine.Transform p1)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                LuaAPI.xlua_pushinteger(L, p0);
                translator.Push(L, p1);
                
                PCall(L, 2, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp29(UnityEngine.Vector2 p0)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushUnityEngineVector2(L, p0);
                
                PCall(L, 1, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp30(UnityEngine.SceneManagement.Scene p0, UnityEngine.SceneManagement.LoadSceneMode p1)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.Push(L, p0);
                translator.PushUnityEngineSceneManagementLoadSceneMode(L, p1);
                
                PCall(L, 2, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp31(string p0, UnityEngine.Object p1, object p2, object p3, object p4)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                LuaAPI.lua_pushstring(L, p0);
                translator.Push(L, p1);
                translator.PushAny(L, p2);
                translator.PushAny(L, p3);
                translator.PushAny(L, p4);
                
                PCall(L, 5, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp32(byte[] p0)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                
                LuaAPI.lua_pushstring(L, p0);
                
                PCall(L, 1, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp33(UnityEngine.Sprite p0)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.Push(L, p0);
                
                PCall(L, 1, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp34(UnityEngine.Texture p0)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.Push(L, p0);
                
                PCall(L, 1, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp35(System.IAsyncResult p0)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                
                PCall(L, 1, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp36(object p0, object p1, int p2, bool p3)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                translator.PushAny(L, p1);
                LuaAPI.xlua_pushinteger(L, p2);
                LuaAPI.lua_pushboolean(L, p3);
                
                PCall(L, 4, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public UnityEngine.GameObject __Gen_Delegate_Imp37(object p0, object p1)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                translator.PushAny(L, p1);
                
                PCall(L, 2, 1, errFunc);
                
                
                UnityEngine.GameObject __gen_ret = (UnityEngine.GameObject)translator.GetObject(L, errFunc + 1, typeof(UnityEngine.GameObject));
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public UnityEngine.GameObject __Gen_Delegate_Imp38(object p0, object p1, object p2, bool p3, bool p4, bool p5)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                translator.PushAny(L, p1);
                translator.PushAny(L, p2);
                LuaAPI.lua_pushboolean(L, p3);
                LuaAPI.lua_pushboolean(L, p4);
                LuaAPI.lua_pushboolean(L, p5);
                
                PCall(L, 6, 1, errFunc);
                
                
                UnityEngine.GameObject __gen_ret = (UnityEngine.GameObject)translator.GetObject(L, errFunc + 1, typeof(UnityEngine.GameObject));
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public UnityEngine.AudioClip __Gen_Delegate_Imp39(object p0, object p1)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                translator.PushAny(L, p1);
                
                PCall(L, 2, 1, errFunc);
                
                
                UnityEngine.AudioClip __gen_ret = (UnityEngine.AudioClip)translator.GetObject(L, errFunc + 1, typeof(UnityEngine.AudioClip));
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public UnityEngine.GameObject __Gen_Delegate_Imp40(object p0, object p1, bool p2, bool p3)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                translator.PushAny(L, p1);
                LuaAPI.lua_pushboolean(L, p2);
                LuaAPI.lua_pushboolean(L, p3);
                
                PCall(L, 4, 1, errFunc);
                
                
                UnityEngine.GameObject __gen_ret = (UnityEngine.GameObject)translator.GetObject(L, errFunc + 1, typeof(UnityEngine.GameObject));
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public long __Gen_Delegate_Imp41(object p0, object p1, object p2, LoadResPriority p3, bool p4, object p5, object p6, object p7, bool p8)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                translator.PushAny(L, p1);
                translator.PushAny(L, p2);
                translator.Push(L, p3);
                LuaAPI.lua_pushboolean(L, p4);
                translator.PushAny(L, p5);
                translator.PushAny(L, p6);
                translator.PushAny(L, p7);
                LuaAPI.lua_pushboolean(L, p8);
                
                PCall(L, 9, 1, errFunc);
                
                
                long __gen_ret = LuaAPI.lua_toint64(L, errFunc + 1);
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp42(object p0, object p1, bool p2, int p3, bool p4)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                translator.PushAny(L, p1);
                LuaAPI.lua_pushboolean(L, p2);
                LuaAPI.xlua_pushinteger(L, p3);
                LuaAPI.lua_pushboolean(L, p4);
                
                PCall(L, 5, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public bool __Gen_Delegate_Imp43(object p0, object p1, object p2, bool p3)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                translator.PushAny(L, p1);
                translator.PushAny(L, p2);
                LuaAPI.lua_pushboolean(L, p3);
                
                PCall(L, 4, 1, errFunc);
                
                
                bool __gen_ret = LuaAPI.lua_toboolean(L, errFunc + 1);
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp44(object p0, object p1, object p2, bool p3)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                translator.PushAny(L, p1);
                translator.PushAny(L, p2);
                LuaAPI.lua_pushboolean(L, p3);
                
                PCall(L, 4, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp45(object p0, object p1, object p2, object p3, object p4, object p5)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                translator.PushAny(L, p1);
                translator.PushAny(L, p2);
                translator.PushAny(L, p3);
                translator.PushAny(L, p4);
                translator.PushAny(L, p5);
                
                PCall(L, 6, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public string __Gen_Delegate_Imp46(object p0)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                
                PCall(L, 1, 1, errFunc);
                
                
                string __gen_ret = LuaAPI.lua_tostring(L, errFunc + 1);
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public bool __Gen_Delegate_Imp47(object p0)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                
                PCall(L, 1, 1, errFunc);
                
                
                bool __gen_ret = LuaAPI.lua_toboolean(L, errFunc + 1);
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp48(object p0, bool p1)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                LuaAPI.lua_pushboolean(L, p1);
                
                PCall(L, 2, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp49(object p0, object p1, bool p2)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                translator.PushAny(L, p1);
                LuaAPI.lua_pushboolean(L, p2);
                
                PCall(L, 3, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public System.Collections.IEnumerator __Gen_Delegate_Imp50(object p0, object p1, bool p2)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                translator.PushAny(L, p1);
                LuaAPI.lua_pushboolean(L, p2);
                
                PCall(L, 3, 1, errFunc);
                
                
                System.Collections.IEnumerator __gen_ret = (System.Collections.IEnumerator)translator.GetObject(L, errFunc + 1, typeof(System.Collections.IEnumerator));
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public LTDescr __Gen_Delegate_Imp51(object p0, float p1, object p2)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                LuaAPI.lua_pushnumber(L, p1);
                translator.PushAny(L, p2);
                
                PCall(L, 3, 1, errFunc);
                
                
                LTDescr __gen_ret = (LTDescr)translator.GetObject(L, errFunc + 1, typeof(LTDescr));
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public LTDescr __Gen_Delegate_Imp52(object p0, float p1, int p2, object p3)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                LuaAPI.lua_pushnumber(L, p1);
                LuaAPI.xlua_pushinteger(L, p2);
                translator.PushAny(L, p3);
                
                PCall(L, 4, 1, errFunc);
                
                
                LTDescr __gen_ret = (LTDescr)translator.GetObject(L, errFunc + 1, typeof(LTDescr));
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public LTDescr __Gen_Delegate_Imp53(object p0, float p1, float p2, float p3, object p4)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                LuaAPI.lua_pushnumber(L, p1);
                LuaAPI.lua_pushnumber(L, p2);
                LuaAPI.lua_pushnumber(L, p3);
                translator.PushAny(L, p4);
                
                PCall(L, 5, 1, errFunc);
                
                
                LTDescr __gen_ret = (LTDescr)translator.GetObject(L, errFunc + 1, typeof(LTDescr));
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public XLua.LuaEnv __Gen_Delegate_Imp54(object p0)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                
                PCall(L, 1, 1, errFunc);
                
                
                XLua.LuaEnv __gen_ret = (XLua.LuaEnv)translator.GetObject(L, errFunc + 1, typeof(XLua.LuaEnv));
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public XLua.LuaTable __Gen_Delegate_Imp55(object p0)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                
                PCall(L, 1, 1, errFunc);
                
                
                XLua.LuaTable __gen_ret = (XLua.LuaTable)translator.GetObject(L, errFunc + 1, typeof(XLua.LuaTable));
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public XLua.LuaTable __Gen_Delegate_Imp56(object p0, object p1)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                translator.PushAny(L, p1);
                
                PCall(L, 2, 1, errFunc);
                
                
                XLua.LuaTable __gen_ret = (XLua.LuaTable)translator.GetObject(L, errFunc + 1, typeof(XLua.LuaTable));
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public UnityEngine.Coroutine __Gen_Delegate_Imp57(object p0, float p1, float p2, int p3, object p4)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                LuaAPI.lua_pushnumber(L, p1);
                LuaAPI.lua_pushnumber(L, p2);
                LuaAPI.xlua_pushinteger(L, p3);
                translator.PushAny(L, p4);
                
                PCall(L, 5, 1, errFunc);
                
                
                UnityEngine.Coroutine __gen_ret = (UnityEngine.Coroutine)translator.GetObject(L, errFunc + 1, typeof(UnityEngine.Coroutine));
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public System.Collections.IEnumerator __Gen_Delegate_Imp58(object p0, float p1, float p2, int p3, object p4)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                LuaAPI.lua_pushnumber(L, p1);
                LuaAPI.lua_pushnumber(L, p2);
                LuaAPI.xlua_pushinteger(L, p3);
                translator.PushAny(L, p4);
                
                PCall(L, 5, 1, errFunc);
                
                
                System.Collections.IEnumerator __gen_ret = (System.Collections.IEnumerator)translator.GetObject(L, errFunc + 1, typeof(System.Collections.IEnumerator));
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public string __Gen_Delegate_Imp59()
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                
                
                PCall(L, 0, 1, errFunc);
                
                
                string __gen_ret = LuaAPI.lua_tostring(L, errFunc + 1);
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public byte[] __Gen_Delegate_Imp60(object p0, ref string p1)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                LuaAPI.lua_pushstring(L, p1);
                
                PCall(L, 2, 2, errFunc);
                
                p1 = LuaAPI.lua_tostring(L, errFunc + 2);
                
                byte[] __gen_ret = LuaAPI.lua_tobytes(L, errFunc + 1);
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public GameFramwork.LuaClient __Gen_Delegate_Imp61()
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                
                PCall(L, 0, 1, errFunc);
                
                
                GameFramwork.LuaClient __gen_ret = (GameFramwork.LuaClient)translator.GetObject(L, errFunc + 1, typeof(GameFramwork.LuaClient));
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public byte[] __Gen_Delegate_Imp62(object p0, object p1)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                translator.PushAny(L, p1);
                
                PCall(L, 2, 1, errFunc);
                
                
                byte[] __gen_ret = LuaAPI.lua_tobytes(L, errFunc + 1);
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public string __Gen_Delegate_Imp63(object p0, object p1)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                translator.PushAny(L, p1);
                
                PCall(L, 2, 1, errFunc);
                
                
                string __gen_ret = LuaAPI.lua_tostring(L, errFunc + 1);
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp64(NetProtocal p0, object p1)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.Push(L, p0);
                translator.PushAny(L, p1);
                
                PCall(L, 2, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp65(NetProtocal p0)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.Push(L, p0);
                
                PCall(L, 1, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp66(object p0, object p1, object p2, object p3, object p4)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                translator.PushAny(L, p1);
                translator.PushAny(L, p2);
                translator.PushAny(L, p3);
                translator.PushAny(L, p4);
                
                PCall(L, 5, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp67(object p0, object p1, object p2, object p3)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                translator.PushAny(L, p1);
                translator.PushAny(L, p2);
                translator.PushAny(L, p3);
                
                PCall(L, 4, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public System.Collections.IEnumerator __Gen_Delegate_Imp68(object p0)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                
                PCall(L, 1, 1, errFunc);
                
                
                System.Collections.IEnumerator __gen_ret = (System.Collections.IEnumerator)translator.GetObject(L, errFunc + 1, typeof(System.Collections.IEnumerator));
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp69(object p0, object p1, int p2)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                translator.PushAny(L, p1);
                LuaAPI.xlua_pushinteger(L, p2);
                
                PCall(L, 3, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp70(object p0, NetProtocal p1, object p2)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                translator.Push(L, p1);
                translator.PushAny(L, p2);
                
                PCall(L, 3, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp71(object p0, int p1, object p2)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                LuaAPI.xlua_pushinteger(L, p1);
                translator.PushAny(L, p2);
                
                PCall(L, 3, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public long __Gen_Delegate_Imp72()
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                
                
                PCall(L, 0, 1, errFunc);
                
                
                long __gen_ret = LuaAPI.lua_toint64(L, errFunc + 1);
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public byte[] __Gen_Delegate_Imp73(NetProtocal p0, object p1)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.Push(L, p0);
                translator.PushAny(L, p1);
                
                PCall(L, 2, 1, errFunc);
                
                
                byte[] __gen_ret = LuaAPI.lua_tobytes(L, errFunc + 1);
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public NetProtocal __Gen_Delegate_Imp74(object p0, int p1)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                LuaAPI.xlua_pushinteger(L, p1);
                
                PCall(L, 2, 1, errFunc);
                
                
                NetProtocal __gen_ret;translator.Get(L, errFunc + 1, out __gen_ret);
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp75(int p0, object p1)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                LuaAPI.xlua_pushinteger(L, p0);
                translator.PushAny(L, p1);
                
                PCall(L, 2, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public int __Gen_Delegate_Imp76(object p0, ref int p1)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                LuaAPI.xlua_pushinteger(L, p1);
                
                PCall(L, 2, 2, errFunc);
                
                p1 = LuaAPI.xlua_tointeger(L, errFunc + 2);
                
                int __gen_ret = LuaAPI.xlua_tointeger(L, errFunc + 1);
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public int __Gen_Delegate_Imp77(object p0, int p1, int p2)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                LuaAPI.xlua_pushinteger(L, p1);
                LuaAPI.xlua_pushinteger(L, p2);
                
                PCall(L, 3, 1, errFunc);
                
                
                int __gen_ret = LuaAPI.xlua_tointeger(L, errFunc + 1);
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public UnityEngine.Vector3 __Gen_Delegate_Imp78(object p0, UnityEngine.Vector3 p1, UnityEngine.Vector3 p2)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                translator.PushUnityEngineVector3(L, p1);
                translator.PushUnityEngineVector3(L, p2);
                
                PCall(L, 3, 1, errFunc);
                
                
                UnityEngine.Vector3 __gen_ret;translator.Get(L, errFunc + 1, out __gen_ret);
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public int __Gen_Delegate_Imp79(object p0, int p1, out double p2, ref string p3)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                LuaAPI.xlua_pushinteger(L, p1);
                LuaAPI.lua_pushstring(L, p3);
                
                PCall(L, 3, 3, errFunc);
                
                p2 = LuaAPI.lua_tonumber(L, errFunc + 2);
                p3 = LuaAPI.lua_tostring(L, errFunc + 3);
                
                int __gen_ret = LuaAPI.xlua_tointeger(L, errFunc + 1);
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public int __Gen_Delegate_Imp80(object p0, int p1, out double p2, ref string p3, object p4)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                LuaAPI.xlua_pushinteger(L, p1);
                LuaAPI.lua_pushstring(L, p3);
                translator.PushAny(L, p4);
                
                PCall(L, 4, 3, errFunc);
                
                p2 = LuaAPI.lua_tonumber(L, errFunc + 2);
                p3 = LuaAPI.lua_tostring(L, errFunc + 3);
                
                int __gen_ret = LuaAPI.xlua_tointeger(L, errFunc + 1);
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp81(object p0, int p1)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                LuaAPI.xlua_pushinteger(L, p1);
                
                PCall(L, 2, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public UnityEngine.GameObject __Gen_Delegate_Imp82(XLuaTest.StructTest p0, int p1, object p2)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.Push(L, p0);
                LuaAPI.xlua_pushinteger(L, p1);
                translator.PushAny(L, p2);
                
                PCall(L, 3, 1, errFunc);
                
                
                UnityEngine.GameObject __gen_ret = (UnityEngine.GameObject)translator.GetObject(L, errFunc + 1, typeof(UnityEngine.GameObject));
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public string __Gen_Delegate_Imp83(XLuaTest.StructTest p0)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.Push(L, p0);
                
                PCall(L, 1, 1, errFunc);
                
                
                string __gen_ret = LuaAPI.lua_tostring(L, errFunc + 1);
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp84(XLuaTest.StructTest p0, object p1)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.Push(L, p0);
                translator.PushAny(L, p1);
                
                PCall(L, 2, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public int __Gen_Delegate_Imp85(object p0)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                
                PCall(L, 1, 1, errFunc);
                
                
                int __gen_ret = LuaAPI.xlua_tointeger(L, errFunc + 1);
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public int __Gen_Delegate_Imp86(object p0, object p1)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                translator.PushAny(L, p1);
                
                PCall(L, 2, 1, errFunc);
                
                
                int __gen_ret = LuaAPI.xlua_tointeger(L, errFunc + 1);
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp87(int p0, int p1)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                
                LuaAPI.xlua_pushinteger(L, p0);
                LuaAPI.xlua_pushinteger(L, p1);
                
                PCall(L, 2, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp88(object p0, int p1, int p2)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                translator.PushAny(L, p0);
                LuaAPI.xlua_pushinteger(L, p1);
                LuaAPI.xlua_pushinteger(L, p2);
                
                PCall(L, 3, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
        
		static DelegateBridge()
		{
		    Gen_Flag = true;
		}
		
		public override Delegate GetDelegateByType(Type type)
		{
		
		    if (type == typeof(System.Action))
			{
			    return new System.Action(__Gen_Delegate_Imp0);
			}
		
		    if (type == typeof(UnityEngine.Events.UnityAction))
			{
			    return new UnityEngine.Events.UnityAction(__Gen_Delegate_Imp0);
			}
		
		    if (type == typeof(System.Func<double, double, double>))
			{
			    return new System.Func<double, double, double>(__Gen_Delegate_Imp1);
			}
		
		    if (type == typeof(System.Action<string>))
			{
			    return new System.Action<string>(__Gen_Delegate_Imp2);
			}
		
		    if (type == typeof(System.Action<double>))
			{
			    return new System.Action<double>(__Gen_Delegate_Imp3);
			}
		
		    if (type == typeof(XLuaTest.IntParam))
			{
			    return new XLuaTest.IntParam(__Gen_Delegate_Imp4);
			}
		
		    if (type == typeof(XLuaTest.Vector3Param))
			{
			    return new XLuaTest.Vector3Param(__Gen_Delegate_Imp5);
			}
		
		    if (type == typeof(XLuaTest.CustomValueTypeParam))
			{
			    return new XLuaTest.CustomValueTypeParam(__Gen_Delegate_Imp6);
			}
		
		    if (type == typeof(XLuaTest.EnumParam))
			{
			    return new XLuaTest.EnumParam(__Gen_Delegate_Imp7);
			}
		
		    if (type == typeof(XLuaTest.DecimalParam))
			{
			    return new XLuaTest.DecimalParam(__Gen_Delegate_Imp8);
			}
		
		    if (type == typeof(XLuaTest.ArrayAccess))
			{
			    return new XLuaTest.ArrayAccess(__Gen_Delegate_Imp9);
			}
		
		    if (type == typeof(System.Action<bool>))
			{
			    return new System.Action<bool>(__Gen_Delegate_Imp10);
			}
		
		    if (type == typeof(UnityEngine.Events.UnityAction<bool>))
			{
			    return new UnityEngine.Events.UnityAction<bool>(__Gen_Delegate_Imp10);
			}
		
		    if (type == typeof(Tutorial.CSCallLua.FDelegate))
			{
			    return new Tutorial.CSCallLua.FDelegate(__Gen_Delegate_Imp11);
			}
		
		    if (type == typeof(Tutorial.CSCallLua.GetE))
			{
			    return new Tutorial.CSCallLua.GetE(__Gen_Delegate_Imp12);
			}
		
		    if (type == typeof(XLuaTest.InvokeLua.CalcNew))
			{
			    return new XLuaTest.InvokeLua.CalcNew(__Gen_Delegate_Imp13);
			}
		
		    if (type == typeof(System.Action<int>))
			{
			    return new System.Action<int>(__Gen_Delegate_Imp14);
			}
		
		    if (type == typeof(System.Action<float>))
			{
			    return new System.Action<float>(__Gen_Delegate_Imp15);
			}
		
		    if (type == typeof(System.Action<object>))
			{
			    return new System.Action<object>(__Gen_Delegate_Imp16);
			}
		
		    if (type == typeof(System.Action<object, object>))
			{
			    return new System.Action<object, object>(__Gen_Delegate_Imp17);
			}
		
		    if (type == typeof(System.Action<XLua.LuaTable>))
			{
			    return new System.Action<XLua.LuaTable>(__Gen_Delegate_Imp18);
			}
		
		    if (type == typeof(System.Action<XLua.LuaTable, int>))
			{
			    return new System.Action<XLua.LuaTable, int>(__Gen_Delegate_Imp19);
			}
		
		    if (type == typeof(System.Action<UnityEngine.EventSystems.PointerEventData>))
			{
			    return new System.Action<UnityEngine.EventSystems.PointerEventData>(__Gen_Delegate_Imp20);
			}
		
		    if (type == typeof(System.Action<long, long>))
			{
			    return new System.Action<long, long>(__Gen_Delegate_Imp21);
			}
		
		    if (type == typeof(System.Action<string, int>))
			{
			    return new System.Action<string, int>(__Gen_Delegate_Imp22);
			}
		
		    if (type == typeof(System.Action<string, float>))
			{
			    return new System.Action<string, float>(__Gen_Delegate_Imp23);
			}
		
		    if (type == typeof(System.Action<int, byte[]>))
			{
			    return new System.Action<int, byte[]>(__Gen_Delegate_Imp24);
			}
		
		    if (type == typeof(System.Action<XLua.LuaTable, object>))
			{
			    return new System.Action<XLua.LuaTable, object>(__Gen_Delegate_Imp25);
			}
		
		    if (type == typeof(System.Action<UnityEngine.AsyncOperation>))
			{
			    return new System.Action<UnityEngine.AsyncOperation>(__Gen_Delegate_Imp26);
			}
		
		    if (type == typeof(System.Action<string, string, UnityEngine.Transform>))
			{
			    return new System.Action<string, string, UnityEngine.Transform>(__Gen_Delegate_Imp27);
			}
		
		    if (type == typeof(UnityEngine.Events.UnityAction<int, UnityEngine.Transform>))
			{
			    return new UnityEngine.Events.UnityAction<int, UnityEngine.Transform>(__Gen_Delegate_Imp28);
			}
		
		    if (type == typeof(UnityEngine.Events.UnityAction<UnityEngine.Vector2>))
			{
			    return new UnityEngine.Events.UnityAction<UnityEngine.Vector2>(__Gen_Delegate_Imp29);
			}
		
		    if (type == typeof(UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>))
			{
			    return new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>(__Gen_Delegate_Imp30);
			}
		
		    if (type == typeof(OnAsyncObjFinish))
			{
			    return new OnAsyncObjFinish(__Gen_Delegate_Imp31);
			}
		
		    if (type == typeof(GameFramwork.NetEvnentCtrl.ProtoListener))
			{
			    return new GameFramwork.NetEvnentCtrl.ProtoListener(__Gen_Delegate_Imp32);
			}
		
		    if (type == typeof(System.Action<UnityEngine.Sprite>))
			{
			    return new System.Action<UnityEngine.Sprite>(__Gen_Delegate_Imp33);
			}
		
		    if (type == typeof(System.Action<UnityEngine.Texture>))
			{
			    return new System.Action<UnityEngine.Texture>(__Gen_Delegate_Imp34);
			}
		
		    if (type == typeof(System.AsyncCallback))
			{
			    return new System.AsyncCallback(__Gen_Delegate_Imp35);
			}
		
		    return null;
		}
	}
    
}