using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class MissionCondition : BASE {

    private void Awake()
    {
        StartBASE();
    }
    public bool isOnlyBase()
    {
        for (int i = 1; i < main.skillSlotCanvasAry.Length; i++)
        {
            if (main.skillSlotCanvasAry[i].currentSkill != null)
                return false;
        }
        return true;
    }
    public bool isNoEQ()
    {
        for (int i = 0; i < main.NewArtifacts.Length; i++)
        {
            if (main.NewArtifacts[i].isEquipped)
                return false;
        }
        return true;
    }


    public bool whenActiveSkill()
    {
        return main.GameController.currentDungeon == Main.Dungeon.Z_slimePools;
    }
}
