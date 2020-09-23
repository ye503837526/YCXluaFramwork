using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameFramwork
{
    public class TimerManager
    {

        /// <summary>
        /// 延迟调用
        /// </summary>
        /// <param name="gameObject">发起者</param>
        /// <param name="delayTime">延迟时间</param>
        /// <param name="callBack">回调</param>
        /// <returns></returns>
        public static LTDescr DelayCall(GameObject gameObject, float delayTime, Action callBack)
        {
            return LeanTween.delayedCall(gameObject, delayTime, callBack);
        }
        /// <summary>
        /// 延迟循环调用
        /// </summary>
        /// <param name="gameObject">发起者</param>
        /// <param name="delayTime">延迟时间</param>
        /// <param name="loopCount">循环次数</param>
        /// <param name="callBack">回调</param>
        /// <returns></returns>
        public static LTDescr DelayCallLoop(GameObject gameObject, float delayTime, int loopCount = 1, Action callBack = null)
        {
            LTDescr descr= LeanTween.delayedCall(gameObject, delayTime, callBack);
            descr.setLoopCount(loopCount).onCompleteOnRepeat = true;
            return descr;
        }
        /// <summary>
        ///  递增值
        /// </summary>
        /// <param name="gameObject">发起者</param>
        /// <param name="form">起始值</param>
        /// <param name="to">目标值</param>
        /// <param name="tiem">所需时间</param>
        /// <param name="action">结束回调</param>
        /// <returns></returns>
        public static LTDescr LerpValue(GameObject gameObject, float form, float to, float tiem, Action<float> onUpdate)
        {
            return LeanTween.value(gameObject, onUpdate, form, to, tiem);
        }
        /// <summary>
        ///添加持续更新 
        /// </summary>
        /// <param name="gameObject">发起者</param>
        /// <param name="time"> 时间</param>
        /// <param name="action">回调</param>
        /// <returns></returns>
        public static LTDescr AddUpdate(GameObject gameObject, float time, Action<float> onUpdate)
        {
            return LeanTween.value(gameObject, onUpdate, time, 0, time);
        }
        /// <summary>
        /// 取消计时器
        /// </summary>
        /// <param name="gameObject"></param>
        public static void Cancel(GameObject gameObject)
        {
            LeanTween.cancel(gameObject);
        }
        /// <summary>
        /// 取消计时器
        /// </summary>
        /// <param name="gameObject"></param>
        public static void CancelLT(LTDescr descr)
        {
            LeanTween.cancel(descr.uniqueId);
        }
        /// <summary>
        /// 取消计时器
        /// </summary>
        /// <param name="gameObject"></param>
        public static void CancelAll()
        {
            LeanTween.cancelAll();
        }
    }
}