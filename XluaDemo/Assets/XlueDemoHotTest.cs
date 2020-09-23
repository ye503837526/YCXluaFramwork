using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProtoBuf;
using UnityEngine.UI;

namespace GameFramwork
{
    public class XlueDemoHotTest : MonoBehaviour
    {
        public void Start()
        {
            testHotFix();
            testHotEx();
            testAndroidHot();
        }

        //测试热更函数
        public void testHotFix()
        {
            Debug.Log("Mono testHotFix  ..........................");
        }
        //测试热更追加
        public void testHotEx()
        {
            Debug.Log("Mono testHotEx  ..........................");
        }
        public void testAndroidHot()
        {
            Debug.Log("Mono testAndroidHot  ..........................");
        }
    }
 
}