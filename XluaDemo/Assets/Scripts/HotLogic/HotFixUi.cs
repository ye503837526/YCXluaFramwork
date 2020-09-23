
using GameFramwork;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotFixUi : MonoBehaviour
{
    public Image m_Image;
    public Text m_Tex;
    public Text m_SliderTopTex;
    [Header("热更信息界面")]
    public GameObject m_InfoPanel;
    public Text m_HotContentTex;
    private float m_SumTime = 0;
    private HotUpdaterManage mMain = null;

    public void Awake()
    {
        mMain = HotUpdaterManage.Instance;
        m_SumTime = 0;
        m_Image.fillAmount = 0;
        m_Tex.text = string.Format("{0:F}M/S", 0);
        HotPatchManager.Instance.ServerInfoError += ServerInfoError;
        HotPatchManager.Instance.ItemError += ItemError;

#if UNITY_EDITOR
        if (GameDefine.Instanse.EditorLoadAssetType==LoadAssetType.AssetBundle)
        {
            UnPackBundle();
        }
        else
        {
            StartOnFinish();
        }

#else
        UnPackBundle();
#endif
    }
    void UnPackBundle()
    {
        if (HotPatchManager.Instance.ComputeUnPackFile())
        {
            m_SliderTopTex.text = "解压中...";
            HotPatchManager.Instance.StartUnackFile(() =>
            {
                m_SumTime = 0;
                HotFix();
            });
        }
        else
        {
            HotFix();
        }
    }
    void HotFix()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            //提示网络错误，检测网络链接是否正常
            Debug.LogError(" HotFix 没有网络！");
            //提示网络错误，检测网络链接是否正常
            mMain.OpenCommonConfirm("网络链接失败", "网络链接失败，请检查网络链接是否正常？", () =>
            { Application.Quit(); }, () => { Application.Quit(); });
        }
        else
        {
            Debug.LogError(" HotFix 有网络！");
            CheckVersion();
        }
    }

    void CheckVersion()
    {
        HotPatchManager.Instance.CheckVersion((hot) =>
        {
            if (hot)
            {
                //提示玩家是否确定热更下载
                mMain.OpenCommonConfirm("热更确定", string.Format("当前版本为{0},有{1:F}M大小热更包，是否确定下载？", HotPatchManager.Instance.CurVersion, HotPatchManager.Instance.LoadSumSize / 1024.0f), OnClickStartDownLoad, OnClickCancleDownLoad);
            }
            else
            {
                Debug.Log("没有下载的东西或者下载完成 进入游戏");
                StartOnFinish();
            }
        });
    }

    void OnClickStartDownLoad()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
        {
            if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)
                mMain.OpenCommonConfirm("下载确认", "当前使用的是手机流量，是否继续下载？", StartDownLoad, OnClickCancleDownLoad);
            else
                StartDownLoad();
        }
        else
        {
            StartDownLoad();
        }
    }

    void OnClickCancleDownLoad()
    {
        Application.Quit();
    }

    /// <summary>
    /// 正式开始下载
    /// </summary>
    void StartDownLoad()
    {
        m_SliderTopTex.text = "下载中...";
        m_InfoPanel.SetActive(true);
        m_HotContentTex.text = HotPatchManager.Instance.CurrentPatches.Des;
       Main.Instanse.StartCoroutine(HotPatchManager.Instance.StartDownLoadAB(StartOnFinish));
    }

    /// <summary>
    /// 下载完成回调，或者没有下载的东西直接进入游戏
    /// </summary>
    void StartOnFinish()
    {
        Main.Instanse.StartCoroutine(OnFinish());
    }

    IEnumerator OnFinish()
    {
        yield return Main.Instanse.StartCoroutine(mMain.StartGame(m_Image, m_SliderTopTex));
        OnClose();
        Destroy(gameObject);
    }

    public void Update()
    {
        if (HotPatchManager.Instance.StartUnPack)
        {
            m_SumTime += Time.deltaTime;
            m_Image.fillAmount = HotPatchManager.Instance.GetUnpackProgress();
            float speed = (HotPatchManager.Instance.AlreadyUnPackSize / 1024.0f) / m_SumTime;
            m_Tex.text = string.Format("{0:F} M/S", speed);
        }

        if (HotPatchManager.Instance.StartDownload)
        {
            m_SumTime += Time.deltaTime;
            m_Image.fillAmount = HotPatchManager.Instance.GetProgress();
            float speed = (HotPatchManager.Instance.GetLoadSize() / 1024.0f) / m_SumTime;
            m_Tex.text = string.Format("{0:F} M/S", speed);
        }
    }

    public void OnClose()
    {
        HotPatchManager.Instance.ServerInfoError -= ServerInfoError;
        HotPatchManager.Instance.ItemError -= ItemError;
        //加载场景
       GameMapManager.Instance.LoadScene(ConStr.LOGINSCENE);
    }


    void ServerInfoError()
    {
        mMain.OpenCommonConfirm("服务器列表获取失败", "服务器列表获取失败，请检查网络链接是否正常？尝试重新下载！", CheckVersion, Application.Quit);
    }

    void ItemError(string all)
    {
        mMain.OpenCommonConfirm("资源下载失败", string.Format("{0}等资源下载失败，请重新尝试下载！", all), AnewDownload, Application.Quit);
    }

    void AnewDownload()
    {
        HotPatchManager.Instance.CheckVersion((hot) =>
        {
            if (hot)
            {
                StartDownLoad();
            }
            else
            {
                StartOnFinish();
            }
        });
    }
}
