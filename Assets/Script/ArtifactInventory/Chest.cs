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
        //�`�F�X�g���󂯂�Ƃ��̏������s��
        var index = recordedActions.Count - 1;
        recordedActions[index]();
        //�󔠂����炷
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
