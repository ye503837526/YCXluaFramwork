using UnityEngine;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using System.Text.RegularExpressions;
using GameFramwork;

public class LuaViewGenerator : EditorWindow
{
    /*
    [MenuItem("GameObject/Lua Tool(CA)/生成Lua UI代码(Shift+U) #P", false, 1)]
    public static void ExecuteGenerateLuaUICode()
    {
        ShowPaserView();
    }
    */
 


    [MenuItem("GameObject/Lua Tool(CA)/生成View解析代码(Shift+V) #V", false, 1)]
    public static void ExecuteGenerateLuaBehaviorCode()
    {
        ShowBehaviorView();
    }

    //transfrom
    private readonly string ArrayParseStr1 = @"
            for(int k#1 =0;k#1 < k#2;k#1++)
            {
                k#3[k#1] = k#4.GetChild(k#1);
            }
    ";

    //compment
    private readonly string ArrayParseStr2 = @"
            for(int k#1 =0;k#1 < k#2;k#1++)
            {
                k#3[k#1] = k#4.GetChild(k#1).GetComponent<k#5>();
            }
    ";

   public string buttonRegisterArray = @"
            int icouter = ui.#1.Length;
            for (int i = 0; i<icouter; i++)
            {
	            ui.#1[i].onClick.RemoveAllListeners();
	            int ii = i;
                ui.#1[i].onClick.AddListener(delegate ()
                {
                    On#2Clicked(ii);
                });
            }";

    public string buttonCallback1 = @"
        private void  On#1Clicked(#2#3)
        {

        }
        ";

    GameObject generatedobj = null;
    Color colorstatus = Color.white;
    string textstatus = "";
    string outputDir = "";
    private string context = "";
    private Vector2 vecscroll = Vector2.zero;
    string outfileName = "";
    string outdirName = "";
    string moduleName = "";

    //parser
    string headerString;
    string bodyString;
    string pathString;
    string funcString;
    string registerString;
    string contentString;
    private  Dictionary<string, int> exsisteNameList = new Dictionary<string, int>();
    private List<GameObject> parseObjectList = new List<GameObject>();

    public string GetCutPath(Transform root, Transform child)
    {
        string path = child.gameObject.name;
        Transform node = child;
        while (root != node.parent)
        {
            node = node.parent;
            if (node == null) break;

            path = path.Insert(0, "/");
            path = path.Insert(0, node.gameObject.name);
        };
        return path;
    }

    bool HasOuterChild(Transform transf)
    {
        if (transf.name.StartsWith("["))
            return true;
        int childCout = transf.childCount;
        for (int i = 0; i < childCout; i++)
        {
            Transform ts = transf.GetChild(i);
            if (ts.name.StartsWith("["))
                return true;

            bool bfind = HasOuterChild(ts);
            if (bfind)
                return true;
        }

        return false;
    }

    void ParseObjToLua(Transform startobj, Transform obj, string path, string tsName, string order)
    {
        int childCout = obj.childCount;
        for (int i = 0; i < childCout; i++)
        {
            Transform ts = obj.GetChild(i);
            string pathname = path + "/" + ts.name;
            string tschildName = (ts.name + order + i).Replace(" ", "");//移除空格
            tschildName = Regex.Replace(tschildName, @"\W", "");
            bool isfindchild = ts.name.EndsWith("#") ? false : true;
            if (!HasOuterChild(ts)) continue;

            //解析名称
            string panelname = ts.name.Trim();
            if (panelname.StartsWith("[") && panelname.IndexOf("]") > 1)
            {
                parseObjectList.Add(ts.gameObject);
            }

            //find child
            if (isfindchild)
            {
                ParseObjToLua(startobj, ts, pathname, tschildName, order + i);
            }
        }
    }

    public string ParserModuleName(string name)
    {
        string[] newstr = name.Replace("#","").Trim('_').Split('_');
        if(newstr == null || newstr.Length == 0)
        {
            return name;
        }
        return newstr[newstr.Length - 1];
    }

    public void GenerateLuaViewCode()
    {
        headerString = "";
        funcString = "";
        bodyString = "";
        pathString = "";
        registerString = "";

        GameObject canvasobj = Selection.gameObjects.Length > 0 ? Selection.gameObjects[0] : null;
        if (canvasobj == null)
        {
            Debug.Log("视图中没有选中ui根节点,请先选中物体~");
            return;
        }

        string tempname = canvasobj.transform.name;
        //string[] arrtemp = ParseModuleDir(tempname);

        exsisteNameList.Clear();
        parseObjectList.Clear();
        ParseObjToLua(canvasobj.transform, canvasobj.transform,tempname, "transform", "");

        string[] parsecodes = GenerateInjectionScript(canvasobj.transform,outfileName);
        contentString = LuaUiTemplate.lua_ui_behavior_template;
        contentString = contentString.Replace("#4", parsecodes[2]);
        contentString = contentString.Replace("#1", outfileName);
        contentString = contentString.Replace("#F", moduleName);
        contentString = contentString.Replace("#2", contain_parsecode ? parsecodes[1]:"");
        contentString = contentString.Replace("#3", "MediatorModule/View/" + moduleName + "/" + outfileName);
        contentString = contentString.Replace("#9", contain_parsecode? parsecodes[0]:"");

        contentString = contentString.Replace("#B", contain_parsecode? LuaUiTemplate.template_parsecode_1 : LuaUiTemplate.template_parsecode_0);
        contentString = contentString.Replace("#C", contain_parsecode ? LuaUiTemplate.template_parsecode_2 :"");
        string midname = outputDir.Replace("/",".");
        string headertemp = string.Format(LuaUiTemplate.template_parsecode_h, LuaEditorDefine.module_list[module_selectid], midname, outfileName);
        contentString = contentString.Replace("#D", contain_parsecode ?"": headertemp);
        contentString = contentString.Replace("#K", LuaEditorDefine.module_list[module_selectid]);
        Debug.Log("解析ui文件:" + moduleName);

        //refresh gui
        context = contentString;
    }
    private string RemoveSpecialWords(string name)
    {
        string wname = name.Trim();
        wname = wname.Replace(" ", "");
        wname = wname.Replace("#", "");
        wname = wname.Replace("$", "");
        wname = Regex.Replace(wname, @"\W", "");
        return wname;
    }

    private string CheckAndGetNewName(List<string> namelist, string transformname)
    {
        string name = RemoveSpecialWords(transformname);
        if (!namelist.Contains(name))
        {
            return name;
        }
        string newname = name;
        for (int i = 1; i < 1000; i++)
        {
            newname = name + i;
            if (!namelist.Contains(newname))
            {
                break;
            }
        }
        return newname;
    }

    Injection[] parse_injection_array()
    {
        List<string> namelist = new List<string>();
        Injection[] injections = new Injection[parseObjectList.Count];
        for (int i = 0; i < parseObjectList.Count; i++)
        {
            GameObject obj = parseObjectList[i];
            Injection inject = new Injection();
            string filedname = CheckAndGetNewName(namelist, obj.transform.name);
            inject.name = filedname;
            inject.value = obj;
            injections[i] = inject;
            namelist.Add(filedname);
        }
        return injections;
    }

    public string[] GenerateInjectionScript(Transform ts,string classname)
    {
        if (ts == null || parseObjectList.Count <= 0) return new string[] { "", "", "" };
        Injection[] injections = parse_injection_array();
        if (injections == null) return new string[] { "", "", "" };
        string code = "";
        string handlercode = "";
        string actioncode = " ";
        for (int i = 0; i < injections.Length; i++)
        {
            Injection inject = injections[i];
            Transform t = inject.value.transform;
            string name = inject.name;

            string tempname = t.name;
            string fieldtype = "Transform";
            string fieldname = tempname;

            if (tempname.StartsWith("[*"))
            {
                int midindex = tempname.IndexOf("]");
                string vtype = tempname.Substring(2, midindex - 1);
                vtype = vtype == "Panel" ? "RectTransform" : vtype;
                vtype = vtype == "Lua" ? "LuaBehaviour" : vtype;
                fieldtype = vtype;

                bool addevent = fieldtype.EndsWith("$") ? false : true;
                fieldtype = fieldtype.Replace("$", "");
                string line = string.Format(LuaUiTemplate.template_injection_template_arr2, name, name, fieldtype);
                code += line;

                if (addevent)
                {
                    if (fieldtype == "Button")
                    {
                        string handlerstr = string.Format(LuaUiTemplate.template_button_string_arr2, name, name);
                        handlercode += handlerstr;

                        string actionstr = string.Format(LuaUiTemplate.template_button_action_arr2, classname, name);
                        actioncode += actionstr;
                    }
                    else if (fieldtype == "Toggle" )
                    {
                        string handlerstr = string.Format(LuaUiTemplate.template_toggle_string_arr2, name, name);
                        handlercode += handlerstr;

                        string actionstr = string.Format(LuaUiTemplate.template_toggle_action_arr2, classname, name);
                        actioncode += actionstr;
                    }
                    else if (fieldtype == "InputField")
                    {
                        string handlerstr = string.Format(LuaUiTemplate.template_input_string_arr2, name, name);
                        handlercode += handlerstr;

                        string actionstr = string.Format(LuaUiTemplate.template_input_action_arr2, classname, name);
                        actioncode += actionstr;
                    }
                    else if (fieldtype == "Slider")
                    {
                        string handlerstr = string.Format(LuaUiTemplate.template_slider_string_arr2, name, name);
                        handlercode += handlerstr;

                        string actionstr = string.Format(LuaUiTemplate.template_slider_action_arr2, classname, name);
                        actioncode += actionstr;
                    }
                    else if(fieldtype == "TMP_InputField")
                    {
                        string handlerstr = string.Format(LuaUiTemplate.template_tmp_inputfield_string_arr2, name, name);
                        handlercode += handlerstr;

                        string actionstr = string.Format(LuaUiTemplate.template_tmp_inputfield_action_arr2, classname, name);
                        actioncode += actionstr;
                    }
                }
            }
            else if(tempname.StartsWith("["))
            {
                int midindex = tempname.IndexOf("]");
                string vtype = tempname.Substring(1, midindex - 1);
                vtype = vtype == "Panel" ? "RectTransform" : vtype;
                vtype = vtype == "Lua" ? "LuaBehaviour" : vtype;
                fieldtype = vtype;

                bool addevent = fieldtype.EndsWith("$") ? false : true;
                fieldtype = fieldtype.Replace("$", "");
                string line = string.Format(LuaUiTemplate.template_injection_template2, name, name, fieldtype);
                code += line;

                if (addevent)
                {
                    if (fieldtype == "Button")
                    {

                        string handlerstr = string.Format(LuaUiTemplate.template_button_string2, name, name);
                        handlercode += handlerstr;

                        string actionstr = string.Format(LuaUiTemplate.template_button_action2, classname, name);
                        actioncode += actionstr;

                    }
                    else if (fieldtype == "Toggle")
                    {
                        string handlerstr = string.Format(LuaUiTemplate.template_toggle_string2, name, name);
                        handlercode += handlerstr;

                        string actionstr = string.Format(LuaUiTemplate.template_toggle_action2, classname, name);
                        actioncode += actionstr;
                    }
                    else if (fieldtype == "InputField")
                    {
                        string handlerstr = string.Format(LuaUiTemplate.template_input_string2, name, name);
                        handlercode += handlerstr;

                        string actionstr = string.Format(LuaUiTemplate.template_input_action2, classname, name);
                        actioncode += actionstr;
                    }
                    else if (fieldtype == "Slider")
                    {
                        string handlerstr = string.Format(LuaUiTemplate.template_slider_string2, name, name);
                        handlercode += handlerstr;

                        string actionstr = string.Format(LuaUiTemplate.template_slider_action2, classname, name);
                        actioncode += actionstr;
                    }
                    else if(fieldtype == "TMP_InputField")
                    {
                        string handlerstr = string.Format(LuaUiTemplate.template_tmp_inputfield_string2, name, name);
                        handlercode += handlerstr;

                        string actionstr = string.Format(LuaUiTemplate.template_tmp_inputfield_action2, classname, name);
                        actioncode += actionstr;
                    }
                }
            }
        }
        //UpdateInjections(ts);
        string[] arr = new string[] { code, handlercode, actioncode };
        return arr;
    }

    public void UpdateInjections( )
    {
        GameObject selectobj = Selection.gameObjects.Length > 0 ? Selection.gameObjects[0] : null;
        Transform ts = selectobj.transform;
        Injection[] injections = parse_injection_array();
        LuaBehaviour behaviour = ts.GetComponent<LuaBehaviour>();
        if (behaviour == null)
        {
            if (EditorUtility.DisplayDialog("提示", "检测不到LuaBehaviour脚本，将自动为你添加，请确认！", "添加", "不添加"))
            {
                behaviour = ts.gameObject.AddComponent<LuaBehaviour>();
                behaviour.Injections = injections;
            }
        }
        else
        {
            behaviour.Injections = injections;
        }
    }

    public bool WriteFile(string filepath, string filename, string content, bool force = false)
    {
        if (!Directory.Exists(filepath))
        {
            Directory.CreateDirectory(filepath);
        }
        string path = filepath + filename + lua_file_afterfix;
        FileInfo viewfile = new FileInfo(path);
        if (!force && viewfile.Exists)
        {
            string msg = "写入" + path + "出错！\n文件已存在!若确实需要覆盖，安全起见，请手动删除原始文件!";
            EditorUtility.DisplayDialog("出错", msg, "确定");
            return false;
        }
        File.WriteAllText(path, content);
        Debug.Log("写入文件:" + path);
        AssetDatabase.Refresh();
        return true;
    }

    const string temp_prefix = "/Editor/LuaGenerator/";
    public string ReadTempFile(string filename)
    {
        string path = Application.dataPath + temp_prefix + filename;
        if(!File.Exists(path))
        {
            return "";
        }
        string data = File.ReadAllText(path);
        return data;
    }
    public void SaveTempFile(string filename, string data)
    {
        string path = Application.dataPath + temp_prefix + filename;
        File.WriteAllText(path, data);
    }

    int module_selectid = 1;
    bool[] check_list = {false,false,false,false};
    const string lua_path_fixed = "";
    const string lua_view_prefix = "GameData/";
    string lua_file_afterfix = ".txt";
    private string luaScriptPath = "";
    bool contain_parsecode = false;


    private string MakeModulePath()
    {
        string dir = "";
        string sub = LuaEditorDefine.module_list[module_selectid];
        dir = lua_view_prefix + sub + "/Lua/MediatorModule/View/";
        return dir;
    }

    private string MakeLuaScriptPath(string modulename,string viewname)
    {
        string dir = "";
        string sub = LuaEditorDefine.module_list[module_selectid];
        dir = lua_view_prefix +  sub +"/"+modulename + "/" + viewname + ".txt";
        return dir;
    }

    private string[] ParseModuleDir(string tempname)
    {
        string regname = tempname.Trim(' ').Trim('_').Replace("#", "");
        string modulename = "";
        string viewname = regname;
        string[] fileds = regname.Split('_');
        if( fileds!=null && fileds.Length >=2)
        {
            modulename = fileds[0];
            viewname = fileds[1];
        }
        string[] ret = new string[]{modulename,viewname};
        return ret;
    }

    private void LoadConfigure()
    {
        string lastmoduleid = ReadTempFile("temp.txt");
        module_selectid = 0;
        if(!string.IsNullOrEmpty(lastmoduleid))
        {
            int tempid = 0;
            int.TryParse(lastmoduleid, out tempid);
            if (tempid < LuaEditorDefine.module_list.Length) module_selectid = tempid;
        }
        check_list = new bool[LuaEditorDefine.module_list.Length];
        for(int i=0;i< LuaEditorDefine.module_list.Length;i++)
        {
            check_list[i] = i == module_selectid;
        }
        GameObject canvasobj = Selection.gameObjects.Length > 0 ? Selection.gameObjects[0] : null;
        if (canvasobj == null)
        {
            return;
        }
        string tempname = canvasobj.transform.name;
        int trimefix = tempname.LastIndexOf(']');
        if (trimefix >= 0)
        {
            tempname = tempname.Substring(trimefix + 1);
        }
        string temp = tempname.Trim('_').Trim('#').Replace("_", "/");
        int length = temp.LastIndexOf("/");
        outputDir = length >= 0? temp.Substring(0,length) : temp;
        string nametemp = length >= 0 ? temp.Substring(length + 1) : temp;
        moduleName = nametemp;
        outfileName = nametemp.Replace("#", "");
        luaScriptPath = MakeLuaScriptPath(outputDir, outfileName);
    }

    private void OnCheckChanged()
    {
        moduleName = outfileName.Trim();
        GenerateLuaViewCode();
    }

    private void OnViewModuleSelected(int index)
    {
        //outputDir = MakeModuleMiddlePath(index);
        string data = index >= 0 ? index.ToString() : "0";
        Debug.Log("Save:" + data);
        SaveTempFile("temp.txt", index.ToString());
    }

    private void AttackLuaScript()
    {
        GameObject selectobj = Selection.gameObjects.Length > 0 ? Selection.gameObjects[0] : null;
        if (selectobj == null)
        {
            return;
        }
        LuaBehaviour behaviour = selectobj.transform.GetComponent<LuaBehaviour>();
        if(behaviour == null)
        {
            return;
        }
        string sub = LuaEditorDefine.module_list[module_selectid];
        string newpath = sub + "/Lua/MediatorModule/View/" + outputDir + "/" + outfileName;
        behaviour.LuaScript = newpath;
    }

    void OnGUI()
    {
        EditorGUI.BeginChangeCheck();

        GUILayout.BeginVertical();
        vecscroll = EditorGUILayout.BeginScrollView(vecscroll);
        context = EditorGUILayout.TextArea(context);
        EditorGUILayout.EndScrollView();
        GUIStyle statestyle = new GUIStyle();
        statestyle.normal.textColor = Color.green;
        GUILayout.Label("说明:[]为需要解析组件，*表示组件为数组，#表示跳过此节点及所属子节点的解析，$表示不生成事件代码", statestyle);
        GUILayout.Label("路径:保存路径由根节点Transform名称决定，_将解析为文件夹.eg:A_B_CView->A/B/CView.prefab",statestyle);
        GUILayout.BeginHorizontal();
        GUILayout.Label("解析代码:", GUILayout.Width(60));
        contain_parsecode = GUILayout.Toggle(contain_parsecode, "包含", GUILayout.Width(80));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("选择模块:", GUILayout.Width(60));
        for (int i=0;i< LuaEditorDefine.module_list.Length;i++)
        {
            if (check_list[i] != GUILayout.Toggle(check_list[i], LuaEditorDefine.module_list[i],GUILayout.Width(120)))
            {
                check_list[i] = true;
                if (module_selectid != i)
                    check_list[module_selectid] = false;
                module_selectid = i;
                OnViewModuleSelected(module_selectid);
            }
        }
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.Label("脚本路径:"+ MakeModulePath(), GUILayout.Width(300));
        outputDir = EditorGUILayout.TextField(outputDir, GUILayout.Width(180));
        GUILayout.Label("/", GUILayout.Width(15));
        outfileName = EditorGUILayout.TextField(outfileName, GUILayout.Width(150));
        GUILayout.Label(lua_file_afterfix, GUILayout.Width(50));
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("更新LuaScript路径", GUILayout.Width(120)))
        {
            Debug.Log("path:" + Application.dataPath);
            AttackLuaScript();

        }
        if (GUILayout.Button("更新Injections绑定", GUILayout.Width(120)))
        {
            UpdateInjections();
        }
        if (GUILayout.Button("生成文件", GUILayout.Width(120)))
        {
            AttackLuaScript();
            UpdateInjections();
            string moduletemp = MakeModulePath();
            string midname = string.IsNullOrEmpty(outputDir) ? "" : (outputDir + "/");
            string newpath = Application.dataPath + "/"+ MakeModulePath() + "/" + outputDir+"/";
            Debug.Log("writefile:" + newpath + "/" + outfileName);
            WriteFile(newpath,outfileName, context, false);
            this.Close();
        }
        GUILayout.EndHorizontal();
        GUI.color = colorstatus;
        GUILayout.Label(textstatus);
        GUI.color = Color.white;
        GUILayout.EndVertical();

        if (EditorGUI.EndChangeCheck())
        {
            Debug.Log("Check Changed");
            OnCheckChanged();
        }
    }

    public static void ShowBehaviorView()
    {
        //创建窗口
        Rect r = new Rect(100, 50, 850, 600);
        LuaViewGenerator w = (LuaViewGenerator)GetWindowWithRect(typeof(LuaViewGenerator), r, true, "生成Lua View代码");
        w.LoadConfigure();
        w.GenerateLuaViewCode();
        w.Show();
        w.UpdateInjections();
    }

    void OnHierarchyChange()
    {
        Debug.Log("OnHierarchyChange");
    }




    void OnInspectorUpdate()
    {
        //这里开启窗口的重绘，不然窗口信息不会刷新
        this.Repaint();
    }


}

