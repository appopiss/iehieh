using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class ItemA : ITEM_CONSUME {
    public override void Use()
    {
        //使用時の効果を書く
    }
    private void Awake()
    {
        AwakeItem(ArtiCtrl.ConsumeItemList.itemA, "Power α", "This is ItemA");
        //名前と、詳細
    }
}