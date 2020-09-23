using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 路径配置
/// </summary>
public class PathConfig
{
    /// <summary>
    /// 窗口界面路径
    /// </summary>
    public const string WindowPath = "Assets/GameData/Prefabs/Window/";
    /// <summary>
    /// 特效路径
    /// </summary>
    public const string EffectPath = "Assets/GameData/Prefabs/Effect/";
    /// <summary>
    /// 声音路径
    /// </summary>
    public const string AudioPath = "Assets/GameData/Sounds/";
    /// <summary>
    /// 鱼模型路径
    /// </summary>
    public const string FishPfbPath = "Assets/GameData/Fishing3D/Models/";
    /// <summary>
    /// 鱼路径
    /// </summary>
    public const string FishPath = "Assets/GameData/Fishing3D/Paths/";
    /// <summary>
    /// 鱼路径
    /// </summary>
    public const string ByteDataPath = "Assets/GameData/Data/Bytes/";



    //*******************座位预设物全路径***************************
    /// <summary>
    /// 通过座位号获取对应的座位预设物
    /// </summary>
    /// <param name="seat"></param>
    /// <returns></returns>
    public static string GetSeatPath(int seat)
    {
        switch (seat)
        {
            case 0:
                return "Assets/GameData/Fishing3D/Seat/Seat_A.prefab";
            case 1:
                return "Assets/GameData/Fishing3D/Seat/Seat_B.prefab";
            case 2:
                return "Assets/GameData/Fishing3D/Seat/Seat_C.prefab";
            case 3:
                return "Assets/GameData/Fishing3D/Seat/Seat_D.prefab";
        }
        return "";
    }
    //*******************炮台预设物全路径***************************
    /// <summary>
    /// 通过炮台类型获取与其对应的炮路径
    /// </summary>
    /// <param name="battery">炮台类型</param>
    /// <returns></returns>
    public static string GetGunPath(int batteryType)
    {
                return "Assets/GameData/Fishing3D/GunSpine/GunSpine_"+ batteryType + ".prefab";
    }
    //*******************子弹预设物全路径***************************
    /// <summary>
    /// 通过炮台类型获取与其对应的子弹路径
    /// </summary>
    /// <param name="battery">炮台类型</param>
    /// <returns></returns>
    public static string GetBulltePath(int batteryType)
    {
                return "Assets/GameData/Fishing3D/Bullet/Bullet_Vip" +batteryType +".prefab";
    }
    //*******************渔网预设物全路径***************************
    /// <summary>
    /// 通过炮台类型获取与其对应的渔网路径
    /// </summary>
    /// <param name="battery">炮台</param>
    /// <returns></returns>
    public static string TypeGetNetsPath(int batteryType)
    {
                return "Assets/GameData/Fishing3D/FishNets/_Effect_Buyu_LV"+ batteryType + ".prefab";
    }

}
