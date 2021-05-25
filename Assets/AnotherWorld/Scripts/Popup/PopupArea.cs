using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using UnityEngine;
using static IdleLibrary.UsefulMethod;

public class PopupArea : POPUP
{
    [SerializeField] TextMeshProUGUI missionText, missionRewardText;
    public override void UpdateUI(LocationKind locationKind, string descriptionString, Sprite iconSprite = null)
    {
        this.locationKind = locationKind;
        UpdateText(descriptionString);
        if (iconSprite != null) UpdateIcon(iconSprite);
    }
    public void UpdateText(string missionStr, string missionRewardStr)
    {
        missionText.text = missionStr;
        missionRewardText.text = missionRewardStr;
    }
    protected override void Awake()
    {
        base.Awake();
        thisRect = gameObject.GetComponent<RectTransform>();
        setFalse(gameObject);
    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
