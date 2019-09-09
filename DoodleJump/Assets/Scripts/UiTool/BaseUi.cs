using GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//窗体的类型
public class UiType
{
    //设置默认值，取最常用的
    public E_ShowUIMode ShowUiMode=E_ShowUIMode.HideOther;
    public E_UiRootType UiRootType = E_UiRootType.Normal;
    public E_Audio audio = E_Audio.Play;
}

public class BaseUi : MonoBehaviour
{
    public UiType uiType;
    //当前窗体的ID
    protected E_UIID uiid = E_UIID.NullUi;
    public E_UIID Uiid
    {
        get { return uiid; }
    }
    //上一个跳转过来的窗体ID
    protected E_UIID beforeUiid = E_UIID.NullUi;
    public E_UIID BeforeUiid { get; set; }


    //声明一个属性判断窗体显示出来的时候是否要处理其他窗体
    public bool IsNeedDealWithUi
    {
        get
        {
            if (this.uiType.UiRootType == E_UiRootType.KeepAbove)
            {
                return false;
            }
            return true;
        }
    }


    public virtual void Awake()
    {
        if (uiType == null)
        {
            uiType=new UiType();
        }
        InitUiOnAwake();
        InitDataOnAwake();
    }
    //初始化界面元素（查找界面元素，获取监听等逻辑代码）
    protected virtual void InitUiOnAwake()
    {

    }
    //初始化界面数据（窗体的ID，类型）
    protected virtual void InitDataOnAwake()
    {
        AddListener();
    }
    //显示窗体的方法
    public virtual void ShowUI()
    {
        this.gameObject.SetActive(true);
    }

    public virtual void HideUI(Action del = null)
    {
        this.gameObject.SetActive(false);
        if (del != null)
        {
            del();
        }
        //保存数据
        Save();
    }

    protected virtual void Save()//保存数据
    {
        
    }
    //显示窗体播放音效
    protected virtual void PlayAudio()
    {

    }

    protected virtual void OnEnable()
    {
        if (this.uiType.audio == E_Audio.Play)
        {
            PlayAudio();
        }
    }

    protected virtual void OnDisable()
    {

    }

    protected virtual void Start()
    {

    }
    protected virtual void OnDestroy()
    {
        RemoveListener();
    }

    public virtual void AddListener()
    {

    }
    public virtual void RemoveListener()
    {

    }
    protected virtual void ToBackClick()
    {
        UiManager.Instance.ShowUI(BeforeUiid,false);
    }

    protected virtual void ToCloseClick()
    {
        UiManager.Instance.HideSingleUI(uiid);
    }
}
