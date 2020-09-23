using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// 池类对象
/// </summary>
public class PooledClassObject
{
    private bool m_bDelete;

    //系统内部使用
    public virtual void New(object param)
    {
        
    }
    //外部调用
    public virtual void DestroyClass()
    {
     
    }
    //系统内部使用
    public virtual void Recycle()
    {
        
    }
    public bool IsDelete()
    {
        return m_bDelete;
    }
    //表明这个变量New的方式
    public bool m_bPoolNew = false;
    //这个变量不熟悉的地方千万不要使用
    public void SetDelete(bool delete)
    {
        m_bDelete = delete;
    }
}
/// <summary>
/// 类对对象池管理器
/// </summary>
public class PooledClassManager<T> where T : PooledClassObject, new()
{
    //对象列表
    private static List<T> m_ClassObjectPooledList = new  List<T>();
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

