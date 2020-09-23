using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Runtime.InteropServices;

public class BundleHotFix : EditorWindow
{
    [MenuItem("Tools/AssetBundle/打包热更包")]
    static void Init()
    {
        BundleHotFix window = (BundleHotFix)EditorWindow.GetWindow(typeof(BundleHotFix), false, "热更包界面", true);
        window.Show();
    }

    string md5Path = "请选择ABMD5版本文件";
    string hotCount = "1";
    OpenFileName m_OpenFileName = null;

    private void OnGUI()
    {
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        GUILayout.BeginHorizontal();
    
 
        md5Path = EditorGUILayout.TextField("ABMD5路径： ", md5Path, GUILayout.Width(350), GUILayout.Height(20));
    
        if (GUILayout.Button("选择版本ABMD5文件", GUILayout.Width(150), GUILayout.Height(20)))
        {
            m_OpenFileName = new OpenFileName();
            m_OpenFileName.structSize = Marshal.SizeOf(m_OpenFileName);
            m_OpenFileName.filter = "ABMD5文件(*.bytes)\0*.bytes";
            m_OpenFileName.file = new string(new char[256]);
            m_OpenFileName.maxFile = m_OpenFileName.file.Length;
            m_OpenFileName.fileTitle = new string(new char[64]);
            m_OpenFileName.maxFileTitle = m_OpenFileName.fileTitle.Length;
            m_OpenFileName.initialDir = (Application.dataPath + "/../Version").Replace("/", "\\");//默认路径
            m_OpenFileName.title = "选择MD5窗口";
            m_OpenFileName.flags = 0x00080000 | 0x00001000 | 0x00000800 | 0x00000008;
            if (LocalDialog.GetSaveFileName(m_OpenFileName))
            {
                Debug.Log(m_OpenFileName.file);
                md5Path = m_OpenFileName.file;
            }
        }
        
        GUILayout.EndHorizontal();

        EditorGUILayout.Space();
        GUILayout.BeginHorizontal();
        hotCount = EditorGUILayout.TextField("热更补丁版本：", hotCount, GUILayout.Width(350), GUILayout.Height(20));
        GUILayout.EndHorizontal();
        EditorGUILayout.Space();
        if (GUILayout.Button("开始打热更包", GUILayout.Width(510), GUILayout.Height(30)))
        {
            if (!string.IsNullOrEmpty(md5Path) && md5Path.EndsWith(".bytes"))
            {
                BundleEditor.Build(true, md5Path, hotCount);
            }
        }
    }
}
