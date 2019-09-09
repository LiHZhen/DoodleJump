using System;
using System.Collections;
using System.Collections.Generic;
using GameCore;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUi : BaseUi
{

    private Button startBtn;
    private Button rangeBtn;
    private Button settingBtn;
    private Button exitBtn;

    protected override void InitUiOnAwake()
    {
        base.InitUiOnAwake();
        startBtn = GameTool.GetTheChildComponent<Button>(gameObject, "StartBtn");
        rangeBtn = GameTool.GetTheChildComponent<Button>(gameObject, "RankBtn");
        settingBtn = GameTool.GetTheChildComponent<Button>(gameObject, "SettingBtn");
        exitBtn = GameTool.GetTheChildComponent<Button>(gameObject, "EndBtn");
    }

    protected override void Start()
    {
        startBtn.onClick.AddListener(ToStartUiClick);
        rangeBtn.onClick.AddListener(ToRangeUiClick);
        settingBtn.onClick.AddListener(ToSettingUiClick);
        exitBtn.onClick.AddListener(ToExitUiClick);
    }

    private void ToExitUiClick()
    {
        Application.Quit();
        Debug.Log("End");
    }

    private void ToSettingUiClick()
    {
        UiManager.Instance.ShowUI(E_UIID.SettingUi);
    }

    private void ToStartUiClick()
    {
        SceneManager.LoadScene(1);
        UiManager.Instance.ShowUI(E_UIID.PlayUi);
    }

    private void ToRangeUiClick()
    {
        UiManager.Instance.ShowUI(E_UIID.RangeUi);
    }

    protected override void InitDataOnAwake()
    {
        base.InitDataOnAwake();
        uiid = E_UIID.MainUi;
        uiType.UiRootType = E_UiRootType.Normal;
    }

}
