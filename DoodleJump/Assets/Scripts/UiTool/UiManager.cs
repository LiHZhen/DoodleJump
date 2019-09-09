﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameCore
{
    //UI管理类
    public class UiManager : UnitySingleton<UiManager>
    {
        //缓存打开过的窗体
        private Dictionary<E_UIID, BaseUi> dicAllUi;
        //缓存正在显示的窗体
        private Dictionary<E_UIID, BaseUi> dicShowUi;
        //缓存上一个窗体的ID
        private E_UIID beforeUIID = E_UIID.NullUi;
        //缓存画布
        private Transform canvas;
        //缓存画布下方的两个窗体关节点
        private Transform keepAboveUIRot;
        private Transform normalUIRoot;

        private bool firstTimeAwake = true;//初次实例化

        void Awake()
        {
            if (firstTimeAwake)
            {
                if (dicAllUi == null)
                {
                    dicAllUi = new Dictionary<E_UIID, BaseUi>();
                }
                if (dicShowUi == null)
                {
                    dicShowUi = new Dictionary<E_UIID, BaseUi>();
                }
                InitUIManager();
                firstTimeAwake = false;
            }
        }

        private void InitUIManager()//初始化窗体
        {
            canvas = this.transform.parent;
            //切换场景时画布不会被销毁
            DontDestroyOnLoad(canvas);
            if (keepAboveUIRot == null)
            {
                keepAboveUIRot = GameTool.FindTheChild(canvas.gameObject, "KeepAboveUIRot");
            }
            if (normalUIRoot == null)
            {
                normalUIRoot = GameTool.FindTheChild(canvas.gameObject, "NormalUIRoot");
            }
            ShowUI(E_UIID.MainUi);
        }

        public void HideSingleUI(E_UIID uiID)//供外界调用的隐藏窗体方法
        {
            if (dicShowUi.ContainsKey(uiID))
            {
                dicShowUi[uiID].HideUI();
                dicShowUi.Remove(uiID);
            }
        }

        public void ShowUI(E_UIID uiid, bool isSaveBeforeID = true)//显示窗体
        {
            if (uiid == E_UIID.NullUi)
            {
                //Debug.Log("窗体ID为NullUi");
                //return;
                uiid = E_UIID.MainUi;
            }
            BaseUi baseUi = JudgeShowUI(uiid);
            if (isSaveBeforeID)
            {
                baseUi.BeforeUiid = beforeUIID;
            }
        }

        private BaseUi JudgeShowUI(E_UIID uiid) //判断要显示的是哪个UI,返回现在显示的UI
        {
            //判断要显示的窗体是否正在显示，如果正在显示则不用处理
            if (dicShowUi.ContainsKey(uiid))
            {

                return null;

            }
            BaseUi baseUi = GetGaseUI(uiid);
            if (baseUi == null)//判断需要显示的窗体是否加载过
            {
                //拿到UIID然后向UI路径字典取值
                string path = GameDefine.dicPath[uiid];
                GameObject loadUi = Resources.Load<GameObject>(path);
                if (loadUi != null)
                {
                    //路径正确，实例化窗体
                    GameObject willShowUI = Instantiate(loadUi);
                    baseUi = willShowUI.GetComponent<BaseUi>();
                    Type type = GameDefine.GetUiScriptType(uiid);
                    if (baseUi == null)
                    {
                        //说明窗体是没有挂载脚本，自动添加对应的UI脚本
                        baseUi = willShowUI.AddComponent(type) as BaseUi;
                    }
                    else
                    {
                        baseUi = willShowUI.GetComponent(type) as BaseUi;
                    }
                    Transform uiRoot = GetTheRoot(baseUi);
                    GameTool.AddChildToParent(uiRoot, willShowUI.transform);
                    //位置不正确，重设UI位置
                    willShowUI.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
                    willShowUI.GetComponent<RectTransform>().anchoredPosition3D = Vector3.zero;

                    //窗体第一次加载，把该窗体缓存到aicAllUi字典。
                    dicAllUi.Add(uiid, baseUi);
                }
                else
                {
                    Debug.Log("没有加载到" + uiid + "预制体");
                }
            }
            else
            {
                baseUi.ShowUI();
            }
            UpdateShowUiHedeUi(baseUi);
            return baseUi;
        }

        private void UpdateShowUiHedeUi(BaseUi baseUi)//更新正在显示的字典并隐藏上一个显示的窗体
        {
            //判断窗体的类型是否需要隐藏其他窗体
            if (baseUi.IsNeedDealWithUi)
            {
                //判断当前是否有正在显示的窗体,第一次加载时为空
                if (dicShowUi.Count > 0)
                {
                    //隐藏所有窗体
                    if (baseUi.uiType.ShowUiMode == E_ShowUIMode.HideAll)
                    {
                        HideAllUI(true, baseUi);
                    }
                    else//隐藏所有窗体，不包括当前窗体
                    {
                        if (baseUi.uiType.ShowUiMode == E_ShowUIMode.HideOther)
                        {
                            HideAllUI(false, baseUi);
                        }
                    }
                }
            }
            dicShowUi.Add(baseUi.Uiid, baseUi);
        }

        public void HideAllUI(bool isHideKeepAboveUi, BaseUi baseUi)
        {
            if (isHideKeepAboveUi)//隐藏所有窗体
            {
                foreach (BaseUi item in dicShowUi.Values)
                {
                    item.HideUI();
                }
                dicShowUi.Clear();
            }
            else//隐藏除前方窗体外的窗体
            {
                List<E_UIID> listRemove = new List<E_UIID>();

                foreach (BaseUi item in dicShowUi.Values)
                {
                    if (item.uiType.UiRootType == E_UiRootType.KeepAbove)
                    {
                        continue;
                    }
                    else
                    {
                        item.HideUI();
                        listRemove.Add(item.Uiid);
                    }
                }

                for (int i = 0; i < listRemove.Count; i++)
                {
                    dicShowUi.Remove(listRemove[i]);
                    if (i == listRemove.Count - 1)
                    {
                        //记录上一个窗体的功能
                        beforeUIID = listRemove[i];

                    }
                }
            }
        }

        private BaseUi GetGaseUI(E_UIID uiid)//判断将要显示的窗体是否已经加载过
        {
            if (dicAllUi.ContainsKey(uiid))
            {
                return dicAllUi[uiid];//之前有加载过，返回uiid的字典
            }
            else
            {
                return null;//之前没有加载过,需要加载
            }
        }

        private Transform GetTheRoot(BaseUi baseUi)//获取ui的父节点
        {
            if (baseUi.uiType.UiRootType == E_UiRootType.KeepAbove)
            {
                return keepAboveUIRot;
            }
            else
            {
                return normalUIRoot;
            }
        }
    }

}