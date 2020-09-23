
using GameFramwork;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotUpdaterManage:Singleton<HotUpdaterManage>
{
    public void InitHotFix()
    {
        //检测是否需要热更
        GameObject.Instantiate(Resources.Load<GameObject>("HotFixPanel"), Main.Instanse.UIRoot);
    }
    //开始游戏 热更完成之后调用
    public IEnumerator StartGame(Image image, Text text)
    {
        image.fillAmount = 0;
        yield return null;
        text.text = "加载本地数据... ...";
        AssetBundleManager.Instance.LoadAssetBundleConfig();
        image.fillAmount = 0.1f;
        yield return null;
        text.text = "加载dll... ...";
        image.fillAmount = 0.2f;
        yield return null;
        text.text = "加载数据表... ...";
        LoadConfiger();
        image.fillAmount = 0.4f;
        yield return null;
        text.text = "加载配置... ...";
        image.fillAmount = 0.7f;
        yield return null;
        text.text = "初始化地图... ...";
        GameMapManager.Instance.Init(Main.Instanse);
        image.fillAmount = 0.9f;
        yield return null;
        Main.Instanse.InitGame();
        text.text = "初始化游戏... ...";
        image.fillAmount = 1f;
        yield return null;
    }
    //打开确定热更按钮
    public void OpenCommonConfirm(string title, string str, UnityEngine.Events.UnityAction confirmAction, UnityEngine.Events.UnityAction cancleAction)
    {
        GameObject commonObj = GameObject.Instantiate(Resources.Load<GameObject>("CommonConfirm")) as GameObject;
        commonObj.transform.SetParent(Main.Instanse.UIRoot, false);
        CommonConfirm commonItem = commonObj.GetComponent<CommonConfirm>();
        commonItem.Show(title, str, confirmAction, cancleAction);
    }
    //加载配置表
    public void LoadConfiger()
    {

    }
  
}
