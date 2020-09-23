using UnityEngine;
using System.IO;
using UnityEditor;

public class LuaModuleGenerator : EditorWindow
{

    [MenuItem("GameObject/Lua Tool(CA)/生成模块代码(Shift+M) #M", false, 1)]
    public static void ExecuteGenerateLuaBehaviorCode()
    {
        ShowModuleView();
    }

    public bool WriteFileWithFullName(string fullpath, string content, bool force = false)
    {
        string filepath = fullpath.Substring(0, fullpath.LastIndexOf("/"));
        if (!Directory.Exists(filepath))
        {
            Directory.CreateDirectory(filepath);
        }
        string path = fullpath + LuaEditorDefine.lua_file_afterfix;
        File.WriteAllText(path, content);
        Debug.Log("写入文件:" + path);
        AssetDatabase.Refresh();
        return true;
    }

    public bool WriteFile(string filepath, string filename, string content, bool force = false)
    {
        if (!Directory.Exists(filepath))
        {
            Directory.CreateDirectory(filepath);
        }
        string path = filepath + filename + LuaEditorDefine.lua_file_afterfix;
        FileInfo viewfile = new FileInfo(path);
        if (!force && viewfile.Exists)
        {
            string msg =  path + "已存在！\n文件已存在,是否覆盖？";
            if(EditorUtility.DisplayDialog("提示", msg, "覆盖","取消"))
            {
                File.WriteAllText(path, content);
                Debug.Log("写入文件:" + path);
            }
            else
            {
                //do noting
            }
            return false;
        }
        else
        {
            File.WriteAllText(path, content);
            Debug.Log("写入文件:" + path);
        }
        File.WriteAllText(path, content);
        Debug.Log("写入文件:" + path);
        AssetDatabase.Refresh();
        return true;
    }

    private Vector2 vecscroll = Vector2.zero;
    private string context = "";
    int module_selectid = 1;
    bool[] check_list = { false, false, false, false };
    string outputFile1 = "";
    string outputFile2 = "";
    string moduleName = "";

    const string temp_prefix = "/Editor/LuaGenerator/";
    public string ReadTempFile(string filename)
    {
        string path = Application.dataPath + temp_prefix + filename;
        if (!File.Exists(path))
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

    private string MakeModulePath()
    {
        string dir = "";
        string sub = LuaEditorDefine.module_list[module_selectid];
        dir = LuaEditorDefine.lua_view_prefix + sub + "/Lua/Module/"+moduleName+"/";
        return dir;
    }

    private void LoadConfigure()
    {
        string lastmoduleid = ReadTempFile("temp.txt");
        module_selectid = 0;
        if (!string.IsNullOrEmpty(lastmoduleid))
        {
            int tempid = 0;
            int.TryParse(lastmoduleid, out tempid);
            if (tempid < LuaEditorDefine.module_list.Length) module_selectid = tempid;
        }
        check_list = new bool[LuaEditorDefine.module_list.Length];
        for (int i = 0; i < LuaEditorDefine.module_list.Length; i++)
        {
            check_list[i] = i == module_selectid;
        }

        GameObject canvasobj = Selection.gameObjects.Length > 0 ? Selection.gameObjects[0] : null;
        if (canvasobj == null)
        {
            return;
        }
        string tempname = canvasobj.transform.name;
        string temp = tempname.Trim('_').Replace("_", "/");
        //outputDir1 = temp.Substring(0, temp.LastIndexOf("/"));
        string nametemp = temp.Substring(temp.LastIndexOf("/") + 1);
        moduleName = nametemp;
    }

    private void OnViewModuleSelected(int index)
    {
        //outputDir = MakeModuleMiddlePath(index);
        string data = index >= 0 ? index.ToString() : "0";
        Debug.Log("Save:" + data);
        SaveTempFile("temp.txt", index.ToString());
    }

    string content1;
    string content2;

    void OnGUI()
    {
        EditorGUI.BeginChangeCheck();
        GUILayout.BeginVertical();

        GUILayout.BeginHorizontal();
        GUILayout.Label("选择游戏:", GUILayout.Width(80));
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
        GUILayout.Label("输入模块名称:", GUILayout.Width(80));
        moduleName = GUILayout.TextField(moduleName, GUILayout.Width(160));
        GUILayout.EndHorizontal();
        GUILayout.Label("Manager路径:"+ MakeModulePath() + moduleName+"Manager", GUILayout.Width(500));
        GUILayout.Label("Model路径:" + MakeModulePath() + moduleName+"Model", GUILayout.Width(500));
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("生成文件", GUILayout.Width(120)))
        {
            //save file1
            string newpath1 = Application.dataPath + "/"+MakeModulePath();
            content1 = LuaUiTemplate.template_module_manager.Replace("#1", moduleName);
            content1 = content1.Replace("#K", LuaEditorDefine.module_list[module_selectid]);
            WriteFile(newpath1,moduleName+"Manager", content1, false);

            //save file2
            string newpath2 = Application.dataPath + "/" + MakeModulePath();
            content2 = LuaUiTemplate.template_module_model.Replace("#1", moduleName);
            content2 = content2.Replace("#K", LuaEditorDefine.module_list[module_selectid]);
            WriteFile(newpath2, moduleName+"Model" ,content2, false);
            this.Close();
        }
        GUILayout.EndHorizontal();
        GUI.color = Color.white;
        GUILayout.EndVertical();
        if (EditorGUI.EndChangeCheck())
        {
            Debug.Log("Check Changed");
            OnCheckChanged();
        }
    }

    void OnCheckChanged()
    {
        GenerateLuaModuleCode();
    }

    void GenerateLuaModuleCode()
    {

    }


    public static void ShowModuleView()
    {
        //创建窗口
        Rect r = new Rect(100, 50, 600, 400);
        LuaModuleGenerator w = (LuaModuleGenerator)GetWindowWithRect(typeof(LuaModuleGenerator), r, true, "生成Lua Module代码");
        w.LoadConfigure();
        w.GenerateLuaModuleCode();
        w.Show();
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

