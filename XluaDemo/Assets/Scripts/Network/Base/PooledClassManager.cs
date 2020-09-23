using System;
using System.Collections.Generic;

/// <summary>
/// 类对对象池管理器
/// </summary>
public class PooledClassManager<T> where T : PooledClassObject, new()
{
    //对象列表
    private static List<T> m_ClassObjectPooledList = new List<T>();
    /// <summary>
    /// 取出类
    /// </summary>
    public static T Spawn(object param = null)
    {
        T hr = default(T);
        Type t = typeof(T);
        if (m_ClassObjectPooledList.Count > 0)
        {
            hr = m_ClassObjectPooledList[0];
            m_ClassObjectPooledList.RemoveAt(0);
        }
        else
        {
            hr = new T();
            hr.m_bPoolNew = true;
        }
        hr.New(param);
        hr.SetDelete(false);
        return hr;
    }
    /// <summary>
    /// 回收类
    /// </summary>
    /// <param name="classObject"></param>
    public static void Recycle(T classObject)
    {
        if (classObject == null)
        {
            return;
        }
        if (classObject.IsDelete())
        {
            return;
        }
        classObject.Recycle();
        classObject.SetDelete(true);
        m_ClassObjectPooledList.Add(classObject);
    }
}
