using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public abstract class ITEM_CONSUME : BASE {
    public abstract void Use();
    public void Effect()
    {
        Consume();
        Use();
    }
    public virtual void Consume()
    {
        main.ArtiCtrl.consumeItemNum[(int)kind]--;
    }

    public ArtiCtrl.ConsumeItemList kind;
    public string Name;
    public string Description;
    public void AwakeItem(ArtiCtrl.ConsumeItemList kind, string Name, string Description)
    {
        StartBASE();
        this.kind = kind;
        this.Name = Name;
        this.Description = Description;
    }
}
