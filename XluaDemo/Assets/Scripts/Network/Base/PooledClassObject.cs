
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


