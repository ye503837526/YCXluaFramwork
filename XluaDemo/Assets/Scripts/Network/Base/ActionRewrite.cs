using System;
public static class ActionRewrite
{
    public static void SafeInvoke(this Action evt)
    {
        if (evt != null)
        {
            evt();
        }
    }
    public static void SafeInvoke<T>(this Action<T> evt, T arg)
    {
        if (evt != null)
        {
            evt(arg);
        }
    }
    public static void SafeInvoke<T1, T2>(this Action<T1, T2> evt, T1 arg1, T2 arg2)
    {
        if (evt != null)
        {
            evt(arg1, arg2);
        }
    }
    public static void SafeInvoke<T1, T2, T3>(this Action<T1, T2, T3> evt, T1 arg1, T2 arg2, T3 arg3)
    {
        if (evt != null)
        {
            evt(arg1, arg2, arg3);
        }
    }
    public static TResult SafeInvoke<TResult>(this Func<TResult> evt)
    {
        if (evt != null)
        {
            return evt();
        }
        return default(TResult);
    }

    public static TResult SafeInvoke<T1, TResult>(this Func<T1, TResult> evt, T1 arg1)
    {
        if (evt != null)
        {
            return evt(arg1);
        }
        return default(TResult);
    }
}
