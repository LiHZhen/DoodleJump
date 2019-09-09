using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//窗体显示类型
//把所有枚举写在一个类里

public enum E_MessageType//观察者模式消息类型
{
    Overwatch,
    NBA
}

public enum E_ShowUIMode//显示界面时需要隐藏窗体的类型
{
    //界面显示时不需要隐藏其他窗体
    DoNothing,
    //界面显示时需要隐藏其他窗体
    HideOther,
    //界面显示时需要隐藏全部窗体
    HideAll
}

public enum E_UiRootType//是否显示在最前方的窗体类型
{
    //保持在屏幕前方的窗体(对应DoNothing)
    KeepAbove,
    //普通的窗体(对应HideOther,HideAll)
    Normal
}

public enum E_Audio//显示窗体时是否播放声音
{
    Play,
    NotPlay
}

public enum E_UIID//UI的所有ID
{
    NullUi,
    MainUi,
    RangeUi,
    SettingUi,
    PlayUi,
}

public class GameDefine : MonoBehaviour
{
    //uiid对应预制体路径
    public static Dictionary<E_UIID, string> dicPath = new Dictionary<E_UIID, string>()
    {
        { E_UIID.MainUi,"UIPrefabs/MainUI"},
        { E_UIID.RangeUi,"UIPrefabs/RangeUi"},
        { E_UIID.SettingUi,"UIPrefabs/SettingUi"},
        { E_UIID.PlayUi,"UIPrefabs/PlayUi"},
    };

    public static Type GetUiScriptType(E_UIID uiid)
    {
        Type scriptType = null;
        switch (uiid)
        {
            case E_UIID.MainUi:
                scriptType = typeof(MainUi);
                break;
            case E_UIID.RangeUi:
                scriptType = typeof(RangeUi);
                break;
            case E_UIID.SettingUi:
                scriptType = typeof(SettingUi);
                break;
            case E_UIID.PlayUi:
                scriptType = typeof(PlayUi);
                break;
            default:
                break;
        }

        return scriptType;
    }

}
