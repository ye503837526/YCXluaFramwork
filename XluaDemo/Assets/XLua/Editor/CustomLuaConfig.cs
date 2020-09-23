/*
 * Tencent is pleased to support the open source community by making xLua available.
 * Copyright (C) 2016 THL A29 Limited, a Tencent company. All rights reserved.
 * Licensed under the MIT License (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at
 * http://opensource.org/licenses/MIT
 * Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
*/

using System.Collections.Generic;
using System;
using UnityEngine;
using XLua;
using UnityEngine.Networking;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Reflection;
using System.Linq;

using UnityEngine.Events;
using TMPro;
using GameFramwork;
public static class CustomLuaConfig
{
    //lua中要使用到C#库的配置，比如C#标准库，或者Unity API，第三方库等。
    //Lua调用C#的APl需要加载静态列表中,因为这些API无法打标签。
    [LuaCallCSharp]
    public static List<Type> LuaCallCSharp = new List<Type>() {
                typeof(System.Object),
                typeof(UnityEngine.Object),
                typeof(Vector2),
                typeof(Vector3),
                typeof(Vector4),
                typeof(Quaternion),
                typeof(Color),
                typeof(Ray),
                typeof(Bounds),
                typeof(Ray2D),
                typeof(Time),
                typeof(GameObject),
                typeof(Component),
                typeof(Behaviour),
                typeof(Transform),
                typeof(Resources),
                typeof(TextAsset),
                typeof(Keyframe),
                typeof(AnimationCurve),
                typeof(AnimationClip),
                typeof(Animation),
                typeof(MonoBehaviour),
                typeof(ParticleSystem),
                typeof(SkinnedMeshRenderer),
                typeof(Renderer),
                typeof(UnityWebRequest),
                typeof(Light),
                typeof(Mathf),
                typeof(UnityEngine.Debug),
                typeof(Sprite),
                typeof(PlayerPrefs),
                typeof(Environment),
                typeof(GridLayoutGroup),
                typeof(HorizontalLayoutGroup),
                typeof(VerticalLayoutGroup),
                typeof(PointerEventData),
                typeof(AudioSource),
                typeof(AudioClip),
                typeof(Camera),
                typeof(Input),
                typeof(Texture2D),
                typeof(UnityEngine.SceneManagement.Scene),
                typeof(UnityEngine.SceneManagement.LoadSceneMode),
                typeof(UnityEngine.SceneManagement.SceneManager),
                typeof(UnityEngine.RectTransformUtility),
                typeof(Rect),
                //typeof(System.IO.File),--check
                typeof(Application),
                typeof(RuntimePlatform),
                typeof(GUIUtility),
                typeof(AsyncOperation),
                typeof(UnityEngine.SceneManagement.SceneManager),
                typeof(ColorUtility),
                typeof(Coroutine),
                //typeof(System.IDisposable),
                //typeof(ImageConversion),--check invalid  why??

                //----------------------------------delegate--------------------------------------
                typeof(System.Collections.Generic.List<int>),
                typeof(System.Collections.Generic.List<string>),
                typeof(Action<string>),
                typeof(Action<System.Object>),
                typeof(Action<System.Object,System.Object>),
                //typeof(ScrollView.ScrollRectEvent),
                //typeof(ScrollView.ScrollRenderEvent),
           

                //--------------------------------------ugui--------------------------------------
                typeof(Canvas),
                typeof(RectTransform),
                typeof(Button),
                typeof(Image),
                typeof(Text),
                typeof(InputField),
                typeof(Toggle),
                typeof(ToggleGroup),
                typeof(Slider),
                typeof(Dropdown),
                typeof(Dropdown.OptionData),

                //--------------------------------------utween--------------------------------------
                //typeof(uGUI.uTweenAlpha),
                //typeof(uGUI.uTweenColor),
                //typeof(uGUI.uTweenPosition),
                //typeof(uGUI.uTweenRotation),
                //typeof(uGUI.uTweenScale),
                //typeof(uGUI.uTweenValue),
                //typeof(uGUI.uTweenAnchoredPosition),
                //typeof(EaseType),
                //typeof(LoopStyle),

                //--------------------------------------custom--------------------------------------
                //typeof(LeanTween),
                //typeof(LeanTweenType),
                //typeof(LTDescr),
                //typeof(LeanAudio),
                //typeof(LeanAudioOptions),
                typeof(GameFramwork.XlueDemoHotTest),
             
                //TextMeshPro
                typeof(TextMeshProUGUI),
                typeof(TMP_InputField),
                //typeof(EmojiText),

                //注意加上nogc得标签
                //best http
                //typeof(BestHTTP.HTTPRequest),
                //typeof(BestHTTP.HTTPResponse),
                //typeof(BestHTTP.HTTPMethods),
                typeof(System.Uri),
                //typeof(UnityEngine.UI.ScrollView),
                //typeof(Spine.Unity.SkeletonGraphic),
                //typeof(Spine.Unity.SkeletonAnimation),
                //typeof(Spine.AnimationState),
                //typeof(Spine.Event),
                //typeof(Spine.TrackEntry),
                //typeof(Spine.AnimationState.TrackEntryDelegate),

                //-----------------framework--------------------------------
                   typeof(NetEvnentCtrl),
                   typeof(GameMapManager),
                   typeof(HttpManager),
                   typeof(TimerManager),
                //typeof(ResManager),
                //typeof(NetClient),
                //typeof(NetCmdBase),
                //typeof(GameEnum),
                //typeof(NetCmdType),
                //typeof(NetManager),
                //typeof(EventManager),
                //typeof(GameSceneManager),
                //typeof(BuyuGameManger),
                //typeof(SceneLogic),
                //typeof(AudioManager),
                //typeof(GameManager),
                //typeof(AssetManager),
                //typeof(NetSocket),
                //typeof(GameEventManager),
                //typeof(GameEventManager.EventListener),
                //typeof(CustomVerifier),
                //typeof(CmdHandler),
                //typeof(BinaryAsset),
                //typeof(ScrollRectHelper),
                typeof(LuaBehaviour),
                //typeof(LuaBehaviourFish3D),
                //typeof(TablePlayerInfo),
                //typeof(AnimBounce),
                //typeof(UI_Control_ScrollFlow),
                // typeof(UI_Control_ScrollFlow_Item),
                //-----------------netpack-----------------------
                //typeof(SC_GR_GF_SystemMessage),
                //typeof(SC_UserEnter),
                //typeof(SC_GR_UserStatus),
                //typeof(SC_GF_GameStatus),
                //typeof(SC_GR_UserScore),
                //typeof(SC_GR_SyncTable),
                //typeof(SC_GR_PlayerJoin),
                //typeof(SC_GR_RequestFailure),
                //typeof(SC_GR_LoadItemList),
                //typeof(SC_GR_ItemCountChange),
                //typeof(SC_GR_SyncPlayingScore),
                //typeof(SC_GR_MemberOrder),
                //typeof(SC_GR_GameConfig),
                //typeof(SC_LoginSuccess),
                //typeof(SC_LoginFail),
                //typeof(SC_GR_ErrorCode),
                //typeof(SystemMessageMgr),
                //typeof(CMD_GR_ConfigServer),
                //typeof(CMD_GF_C_UserExpression),
                //typeof(CMD_GF_S_UserExpression),

    };

    //C#静态调用Lua的配置（包括事件的原型），仅可以配delegate，interface
    [CSharpCallLua]
    public static List<Type> CSharpCallLua = new List<Type>() {
                typeof(Action),
                typeof(Func<double, double, double>),
                typeof(Action<string>),
                typeof(Action<int>),
                typeof(Action<double>),
                typeof(Action<float>),
                typeof(Action<System.Object>),
                typeof(Action<System.Object,System.Object>),
                typeof(Action<LuaTable>),
                typeof(Action<LuaTable,int>),
                typeof(Action<PointerEventData>),
                typeof(Action<long,long>),
                typeof(Action<string,int>),
                typeof(Action<string, float>),
                typeof(Action<int,byte[] >),
                typeof(Action<LuaTable, System.Object>),
                typeof(Action<AsyncOperation>),
                //typeof(VoidCall<NetCmdType, NetCmdPack>),
                //typeof(VoidCall),
                //typeof(VoidDelegate),
                //typeof(Spine.AnimationState.TrackEntryEventDelegate),
                //typeof(Spine.AnimationState.TrackEntryDelegate),
                typeof(Action<string,string,Transform>),
                typeof(UnityAction<bool>),
                //typeof(Action<System.Object,GameEventManager.EventArgument>),
                //typeof(Action<System.Object,NetCmdPack>),
                //typeof(Action<NetState,int>),

                typeof(UnityEngine.Events.UnityEvent<Vector2>),
                typeof(UnityEngine.Events.UnityEvent<int, Transform>),
                //typeof(ScrollView.ScrollRectEvent),
                //typeof(ScrollView.ScrollRenderEvent),
                typeof(UnityEngine.Events.UnityAction),
                typeof(UnityEngine.Events.UnityAction<int,Transform>),
                typeof(UnityEngine.Events.UnityAction<Vector2>),
                typeof(UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>),
                typeof(System.Collections.IEnumerator),
                //typeof(AliSDKAction),
                //typeof(System.IDisposable),


                //best http
                //typeof(BestHTTP.OnRequestFinishedDelegate),
                //typeof(BestHTTP.OnDownloadProgressDelegate),
                //typeof(BestHTTP.OnUploadProgressDelegate),
                //typeof(BestHTTP.OnBeforeRedirectionDelegate),
    };


    /***************热补丁可以参考这份自动化配置***************/
    /*
    [Hotfix]
    static IEnumerable<Type> HotfixInject
    {
        get
        {
            return (from type in Assembly.Load("Assembly-CSharp").GetTypes()
                    where type.Namespace == null || !type.Namespace.StartsWith("XLua")
                    select type);
        }
    }
    */
    //--------------begin 热补丁自动化配置-------------------------
    static bool hasGenericParameter(Type type)
    {
        if (type.IsGenericTypeDefinition) return true;
        if (type.IsGenericParameter) return true;
        if (type.IsByRef || type.IsArray)
        {
            return hasGenericParameter(type.GetElementType());
        }
        if (type.IsGenericType)
        {
            foreach (var typeArg in type.GetGenericArguments())
            {
                if (hasGenericParameter(typeArg))
                {
                    return true;
                }
            }
        }
        return false;
    }

    static bool typeHasEditorRef(Type type)
    {
        if (type.Namespace != null && (type.Namespace == "UnityEditor" || type.Namespace.StartsWith("UnityEditor.")))
        {
            return true;
        }
        if (type.IsNested)
        {
            return typeHasEditorRef(type.DeclaringType);
        }
        if (type.IsByRef || type.IsArray)
        {
            return typeHasEditorRef(type.GetElementType());
        }
        if (type.IsGenericType)
        {
            foreach (var typeArg in type.GetGenericArguments())
            {
                if (typeHasEditorRef(typeArg))
                {
                    return true;
                }
            }
        }
        return false;
    }

    static bool delegateHasEditorRef(Type delegateType)
    {
        if (typeHasEditorRef(delegateType)) return true;
        var method = delegateType.GetMethod("Invoke");
        if (method == null)
        {
            return false;
        }
        if (typeHasEditorRef(method.ReturnType)) return true;
        return method.GetParameters().Any(pinfo => typeHasEditorRef(pinfo.ParameterType));
    }

    //配置某Assembly下所有涉及到的delegate到CSharpCallLua下，Hotfix下拿不准那些delegate需要适配到lua function可以这么配置
    [CSharpCallLua]
    static IEnumerable<Type> AllDelegate
    {
        get
        {
            List<Type> allTypes = new List<Type>();
            BindingFlags flag = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public;
            /*
            var allAssemblys = new Assembly[]
            {
                Assembly.Load("Assembly-CSharp")
            };
            foreach (var t in (from assembly in allAssemblys from type in assembly.GetTypes() select type))
            {
                var p = t;
                while (p != null)
                {
                    allTypes.Add(p);
                    p = p.BaseType;
                }
            }
            allTypes = allTypes.Distinct().ToList();     
            */
            allTypes = hotfixList;
            var allMethods = from type in allTypes
                             from method in type.GetMethods(flag)
                             select method;
            var returnTypes = from method in allMethods
                              select method.ReturnType;
            var paramTypes = allMethods.SelectMany(m => m.GetParameters()).Select(pinfo => pinfo.ParameterType.IsByRef ? pinfo.ParameterType.GetElementType() : pinfo.ParameterType);
            var fieldTypes = from type in allTypes
                             from field in type.GetFields(flag)
                             select field.FieldType;
            IEnumerable<Type> targettype = (returnTypes.Concat(paramTypes).Concat(fieldTypes)).Where(t => t.BaseType == typeof(MulticastDelegate) && !hasGenericParameter(t) && !delegateHasEditorRef(t)).Distinct();
            return targettype;
        }
    }

    [Hotfix]
    public static List<Type> hotfixList
    {
        get
        {
            string[] allowNamespaces = new string[] {
                "GameFramwork",
            };

            return (from type in Assembly.Load("Assembly-CSharp").GetTypes()
                    where allowNamespaces.Contains(type.Namespace)
                    select type).ToList();
        }
    }

    //黑名单
    [BlackList]
    public static List<List<string>> BlackList = new List<List<string>>()  {
                new List<string>(){"System.Xml.XmlNodeList", "ItemOf"},
                new List<string>(){"UnityEngine.WWW", "movie"},
    #if UNITY_WEBGL
                new List<string>(){"UnityEngine.WWW", "threadPriority"},
    #endif
                new List<string>(){"UnityEngine.Texture2D", "alphaIsTransparency"},
                new List<string>(){"UnityEngine.Security", "GetChainOfTrustValue"},
                new List<string>(){"UnityEngine.CanvasRenderer", "onRequestRebuild"},
                new List<string>(){"UnityEngine.Light", "areaSize"},
                new List<string>(){"UnityEngine.Light", "lightmapBakeType"},
                new List<string>(){"UnityEngine.WWW", "MovieTexture"},
                new List<string>(){"UnityEngine.WWW", "GetMovieTexture"},
                new List<string>(){"UnityEngine.AnimatorOverrideController", "PerformOverrideClipListCleanup"},
    #if !UNITY_WEBPLAYER
                new List<string>(){"UnityEngine.Application", "ExternalEval"},
    #endif
                new List<string>(){"UnityEngine.GameObject", "networkView"}, //4.6.2 not support
                new List<string>(){"UnityEngine.Component", "networkView"},  //4.6.2 not support
                new List<string>(){"System.IO.FileInfo", "GetAccessControl", "System.Security.AccessControl.AccessControlSections"},
                new List<string>(){"System.IO.FileInfo", "SetAccessControl", "System.Security.AccessControl.FileSecurity"},
                new List<string>(){"System.IO.DirectoryInfo", "GetAccessControl", "System.Security.AccessControl.AccessControlSections"},
                new List<string>(){"System.IO.DirectoryInfo", "SetAccessControl", "System.Security.AccessControl.DirectorySecurity"},
                new List<string>(){"System.IO.DirectoryInfo", "CreateSubdirectory", "System.String", "System.Security.AccessControl.DirectorySecurity"},
                new List<string>(){"System.IO.DirectoryInfo", "Create", "System.Security.AccessControl.DirectorySecurity"},
                new List<string>(){"UnityEngine.MonoBehaviour", "runInEditMode"},

                //compile error...
                new List<string>(){"UnityEngine.Light", "SetLightDirty"},
                new List<string>(){"UnityEngine.Light", "shadowRadius"},
                new List<string>(){"UnityEngine.Light", "shadowAngle"},
                new List<string>(){"UnityEngine.UI.Text", "OnRebuildRequested"},
                new List<string>(){"System.Environment", "SystemDirectory" },
                new List<string>(){"UnityEngine.Input", "IsJoystickPreconfigured","System.String"},
            };

#if UNITY_2018_1_OR_NEWER
    [BlackList]
    public static Func<MemberInfo, bool> MethodFilter = (memberInfo) =>
    {
        if (memberInfo.DeclaringType.IsGenericType && memberInfo.DeclaringType.GetGenericTypeDefinition() == typeof(Dictionary<,>))
        {
            if (memberInfo.MemberType == MemberTypes.Constructor)
            {
                ConstructorInfo constructorInfo = memberInfo as ConstructorInfo;
                var parameterInfos = constructorInfo.GetParameters();
                if (parameterInfos.Length > 0)
                {
                    if (typeof(System.Collections.IEnumerable).IsAssignableFrom(parameterInfos[0].ParameterType))
                    {
                        return true;
                    }
                }
            }
            else if (memberInfo.MemberType == MemberTypes.Method)
            {
                var methodInfo = memberInfo as MethodInfo;
                if (methodInfo.Name == "TryAdd" || methodInfo.Name == "Remove" && methodInfo.GetParameters().Length == 2)
                {
                    return true;
                }
            }
        }
        return false;
    };
#endif

}
