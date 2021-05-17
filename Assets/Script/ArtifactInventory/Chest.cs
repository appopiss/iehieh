using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.Serialization;
using System;
using IdleLibrary.Inventory;

[Serializable]
public class Chest
{
    [OdinSerialize] List<Action> recordedActions = new List<Action>();
    public int ChestNum => recordedActions.Count;
    public void OpenChest()
    {
        if (recordedActions.Count == 0) return;
        //チェストを空けるときの処理を行う
        var index = recordedActions.Count - 1;
        recordedActions[index]();
        //宝箱を減らす
        recordedActions.RemoveAt(index);
    }
    public void RegisterAction(Action action)
    {
        recordedActions.Add(action);
    }
    public Chest()
    {
        
    }
}
