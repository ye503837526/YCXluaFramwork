using System;

public class FieldType
{
    public static Type mShot;
    public static Type mUShot;
    public static Type mInt;
    public static Type mUint;
    public static Type mLong;
    public static Type mULong;
    public static Type mFloat;
    public static Type mDouble;
    public static Type mByte;
    public static Type mSByte;
    public static Type mBool;
    public static Type mString;
    public static Type mNetProtocal;
    public static void Init()
    {
        short s = 0;
        ushort us = 0;
        int n = 0;
        uint un = 0;
        long l = 0;
        ulong ul = 0;
        float f = 0;
        double d = 0;
        byte b = 0;
        sbyte sb = 0;
        bool bl = false;
        string str = "";
        NetProtocol net = NetProtocol.None;
        mShot = s.GetType();
        mUShot = us.GetType();
        mInt = n.GetType();
        mUint = un.GetType();
        mLong = l.GetType();
        mULong = ul.GetType();
        mFloat = f.GetType();
        mDouble = d.GetType();
        mByte = b.GetType();
        mSByte = sb.GetType();
        mBool = bl.GetType();
        mString = str.GetType();
        mNetProtocal = net.GetType();
    }
}
