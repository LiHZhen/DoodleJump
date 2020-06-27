using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangeUi : BaseUi
{
    public List<int> range = new List<int>(10);

    private Button backBtn;

    private Transform rangeList;

    protected override void InitUiOnAwake()
    {
        base.InitUiOnAwake();
        backBtn = GameTool.GetTheChildComponent<Button>(gameObject, "BackBtn");
        backBtn.onClick.AddListener(ToBackClick);
        rangeList=GameTool.FindTheChild(gameObject,"Range");

    }
    protected override void InitDataOnAwake()
    {
        base.InitDataOnAwake();
        uiid = E_UIID.RangeUi;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        range = RangeManager.Instance.range;
        for (int i = 0; i < rangeList.childCount; i++)
        {
            Text rangeText = GameTool.FindTheChild(rangeList.GetChild(i).gameObject, "RangeHigh").GetComponent<Text>();
            rangeText.text = range[i].ToString();
        }
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        RangeManager.Instance.SaveRange();
    }
}
