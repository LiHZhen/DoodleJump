using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayUi : BaseUi {

    private Transform cameraTransform;
    private Text highText;
    public float source;
    public static PlayUi instance;

    private Button stopBtn;
    private GameObject stopWindow;
    private Button backBtn;
    private Button goOnBtn;

    private Button backBtn2;
    private Button returnBtn;
    private Text sourceText ;
    private GameObject endWindow;

    protected override void InitUiOnAwake()
    {
        base.InitUiOnAwake();

        highText = GameTool.GetTheChildComponent<Text>(gameObject, "HighText");
        instance = this;

        stopBtn = GameTool.GetTheChildComponent<Button>(gameObject, "StopBtn");
        backBtn = GameTool.GetTheChildComponent<Button>(gameObject, "BackBtn");
        goOnBtn = GameTool.GetTheChildComponent<Button>(gameObject, "GoOnBtn");
        stopWindow = GameTool.FindTheChild(gameObject, "StopWindow").gameObject;

        backBtn2 = GameTool.GetTheChildComponent<Button>(gameObject, "BackToMenuBtn");
        returnBtn= GameTool.GetTheChildComponent<Button>(gameObject, "ReturnBtn");
        sourceText = GameTool.GetTheChildComponent<Text>(gameObject, "SourceText");
        endWindow = GameTool.FindTheChild(gameObject, "OverWindow").gameObject;
    }
    protected override void InitDataOnAwake()
    {
        base.InitDataOnAwake();
        uiid = E_UIID.PlayUi;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        Time.timeScale = 1;
        stopWindow.SetActive(false);
        source = 0;
    }

    protected override void Start ()
    {
        source = 0;
        cameraTransform = Camera.main.transform;

        stopBtn.onClick.AddListener(StopBtnOnClick);
        backBtn.onClick.AddListener(ToBackClick);
        goOnBtn.onClick.AddListener(GoOnBtnClick);

        backBtn2.onClick.AddListener(ToBackClick);
        returnBtn.onClick.AddListener(ToReturnGame);
    }

    private void ToReturnGame()
    {
        SceneManager.LoadScene(1);
    }

    private void GoOnBtnClick()
    {
        stopWindow.SetActive(false);
        Time.timeScale = 1;
    }

    private void StopBtnOnClick()
    {
        Time.timeScale = 0;
        stopWindow.SetActive(true);
    }

    protected override void ToBackClick()
    {
        base.ToBackClick();
        SceneManager.LoadScene(0);
    }
	void Update ()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
        
        if ((int) ((cameraTransform.position.y) * 10) > source)
        {
            source = (int)((cameraTransform.position.y) * 10);
        }
        highText.text = "High:" + source;

        if (PlayerMove.isDead == true)
        {

        }
    }
}
