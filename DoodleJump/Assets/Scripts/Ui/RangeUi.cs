using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangeUi : BaseUi
{

    private Button backBtn;

    protected override void InitUiOnAwake()
    {
        base.InitUiOnAwake();
        backBtn = GameTool.GetTheChildComponent<Button>(gameObject, "BackBtn");
        backBtn.onClick.AddListener(ToBackClick);
    }
    protected override void InitDataOnAwake()
    {
        base.InitDataOnAwake();
        uiid = E_UIID.RangeUi;
    }
}
