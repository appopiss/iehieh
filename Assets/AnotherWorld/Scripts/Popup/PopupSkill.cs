using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using UnityEngine;
using static IdleLibrary.UsefulMethod;

public class PopupSkill : POPUP
{
    [SerializeField] TextMeshProUGUI effectText, passiveEffectText;
    public override void UpdateUI(LocationKind locationKind, string descriptionString, Sprite iconSprite = null)
    {
        this.locationKind = locationKind;
        UpdateText(descriptionString);
        if (iconSprite != null) UpdateIcon(iconSprite);
    }
    public void UpdateText(string effectStr, string passiveEffectStr)
    {
        effectText.text = effectStr;
        passiveEffectText.text = passiveEffectStr;
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
