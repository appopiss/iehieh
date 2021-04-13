using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using static UsefulMethod;

public class IEBBONUS : BASE
{
    public enum BonusKind
    {
        ec,
        goldgain,
        goldcap,
        expgain,
        monstergoldcap,
        prof,
        eq,
    }
    [NonSerialized]
    public int id;
    public BonusKind kind;
    public Button purchaseButton;
    public GameObject unleashedImg;

    private void Start()
    {
        purchaseButton.onClick.AddListener(Buy);
    }
    void Buy()
    {
        if (CanBuy())
            main.S.isPurchasedIEBBonus[id] = true;
        main.iebCtrl.CalculateBonus();
    }
    bool CanBuy()
    {
        return main.iebCtrl.CurrentBonusPoint() > 0 && !IsPurchased();
    }
    public bool IsPurchased()
    {
        return main.S.isPurchasedIEBBonus[id];
    }
    // Update is called once per frame
    void Update()
    {
        if (!main.iebCtrl.thisOpenClose.isOpen)
            return;

        if (CanBuy())
            purchaseButton.interactable = true;
        else
            purchaseButton.interactable = false;
        if (IsPurchased())
            setActive(unleashedImg);
        else
            setFalse(unleashedImg);
    }
}
