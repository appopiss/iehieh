using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;
using TMPro;

public class CurseCtrl : BASE {

    public TextMeshProUGUI NameText;
    public TextMeshProUGUI RestrictionText;
    public TextMeshProUGUI RewardText;
   // public TextMeshProUGUI CurrentIdText;
    public TextMeshProUGUI ConditionText;
    public TextMeshProUGUI CurrentCurseText;
    public RectTransform ParentCanvas;
    public Button SelectButton;
    public Button ToCurse;
    public Button Close;
    public Button CancelCurseButton;
    public GameObject ConfirmWindow;
    public CurseId CurrentCurseId { get => main.S.CurrentCurseId; set => main.S.CurrentCurseId = value; }
    public CurseId InputCurseId;
    public Action Input = () => { };
    public CurseReinFactor cf;
    public CURSE_RAIN[] Curses;
    public bool isCanceled;
    public Confirm_CurseRein Confirm_CurseRein;
    public ConfirmDefault ConfirmDefault;
    public RectTransform[] LevelCanvas;
    private void Start()
    {
        CancelCurseButton.onClick.AddListener(() =>
        {
            ConfirmDefault.StartConfirm(() => isCanceled = true, gameObject.transform,
                "Are you sure you want to cancel the current Curse? "
                );
        });
        ToCurse.onClick.AddListener(() => ParentCanvas.anchoredPosition = new Vector2(0, 0));
        Close.onClick.AddListener(() => ParentCanvas.anchoredPosition = new Vector2(-1200, 0));
        SelectButton.onClick.AddListener(() => {
            Input();
            //CurrentIdText.text = InputCurseId == CurseId.normal ? "Next Mode -> Normal" : "Next Mode -> " + NameText.text;
            //ParentCanvas.anchoredPosition = new Vector2(-1200, 0);
            Confirm_CurseRein cc = Instantiate(Confirm_CurseRein, gameObject.transform);
            cc.InputCurseId = Input;
            cc.NextText = "<color=red>Next Curse -> " + NameText.text;
            if (main.cc.InputCurseId == CurseId.normal)
                cc.NextText = "<color=red>Next Curse -> </color=red>No Curse";
        }
        );
    }
    private void Update()
    {
        if(CurrentCurseId == CurseId.normal)
        {
            CurrentCurseText.text = "";
        }
        else
        {
            CurrentCurseText.text = Curses[(int)CurrentCurseId-1].Name();
        }
    }
}
