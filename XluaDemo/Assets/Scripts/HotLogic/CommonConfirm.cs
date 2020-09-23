using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommonConfirm : BaseItem
{
    public Text m_Title;
    public Text m_Des;
    public Button m_ConfirmBtn;
    public Button m_CancleBtn;

    public void Show(string title,string str, UnityEngine.Events.UnityAction confirmAction, UnityEngine.Events.UnityAction cancleAction)
    {
        m_Title.text = title;
        m_Des.text = str;
        AddButtonClickListener(m_ConfirmBtn,()=> 
        {
            confirmAction();
            Destroy(gameObject);
        });
        AddButtonClickListener(m_CancleBtn, ()=> 
        {
            cancleAction();
            Destroy(gameObject);
        });
    }
}
