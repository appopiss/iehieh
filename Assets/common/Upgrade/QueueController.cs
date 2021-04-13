using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class QueueController : BASE {


    public int queueCap()
    {
        return main.S.Queue_unleashed + main.S.Queue1_buyNum + main.S.Queue2_buyNum + main.S.Queue3_buyNum + main.S.Queue4_buyNum + (int)main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.Queue].GetCurrentValue();
    }
    public int queue;

    public int SBqueueCap()
    {
        return main.S.QueueInSlimeBank_buyNum1 + main.S.QueueInSlimeBank_buyNum2 + main.S.QueueInSlimeBank_buyNum3 + main.S.QueueInSlimeBank_buyNum4 + (int)main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.BankQueue].GetCurrentValue();
    }
    public int SBqueue;

    //public void ResetSuperQueueAlchemy()
    //{
    //    for (int i = 0; i < main.S.isSuperQueuedAlchemy.Length; i++)
    //    {
    //        main.S.isSuperQueuedAlchemy[i] = false;
    //    }
    //}
    //public bool IsUsingSuperQueueAlchemy()
    //{
    //    int tempNum = 0;
    //    for (int i = 0; i < main.S.isSuperQueuedAlchemy.Length; i++)
    //    {
    //        if (main.S.isSuperQueuedAlchemy[i])
    //            tempNum++;
    //    }

    //    if (tempNum == 0)
    //        return false;
    //    else if (tempNum==1)
    //        return true;
    //    else
    //    {
    //        for (int i = 0; i < main.S.isSuperQueuedAlchemy.Length; i++)
    //        {
    //            main.S.isSuperQueuedAlchemy[i] = false;
    //        }
    //        return false;
    //    }
    //}

    // Use this for initialization
    void Awake () {
		StartBASE();
	}

	// Use this for initialization
	void Start () {
        queue = queueCap();
        SBqueue = SBqueueCap();
        SuperQueueLoad();
    }

    // Update is called once per frame
    void Update () {
        if (queue > queueCap())
            queue = queueCap();
        if (SBqueue > SBqueueCap())
            SBqueue = SBqueueCap();
	}

    public void SuperQueueSave()
    {
        for (int i = 0; i < main.StoneUpgrade.Length; i++)
        {
            main.S.isSuperQueueAssignedforStoneUpgrade[i] = main.StoneUpgrade[i].assignedSuperQueue;
        }
        for (int i = 0; i < main.CristalUpgrade.Length; i++)
        {
            main.S.isSuperQueueAssignedforCrystalUpgrade[i] = main.CristalUpgrade[i].assignedSuperQueue;
        }
        for (int i = 0; i < main.LeafUpgrade.Length; i++)
        {
            main.S.isSuperQueueAssignedforLeafUpgrade[i] = main.LeafUpgrade[i].assignedSuperQueue;
        }
        for (int i = 0; i < main.StatusUpgrade.Length; i++)
        {
            main.S.isSuperQueueAssignedforStatusUpgrade[i] = main.StatusUpgrade[i].assignedSuperQueue;
        }
    }
    public void SuperQueueSBSave()
    {
        for (int i = 0; i < main.bankCtrl.BankUpgrades.Length; i++)
        {
            main.S.isSuperQueueSBAssigned[i] = main.bankCtrl.BankUpgrades[i].assignedSuperQueue;
        }
    }
    public void SuperQueueLoad()
    {
        for (int i = 0; i < main.StoneUpgrade.Length; i++)
        {
            if (main.S.isSuperQueueAssignedforStoneUpgrade[i])
            {
                main.StoneUpgrade[i].AssignSuperQueue();
            }
        }
        for (int i = 0; i < main.CristalUpgrade.Length; i++)
        {
            if (main.S.isSuperQueueAssignedforCrystalUpgrade[i])
            {
                main.CristalUpgrade[i].AssignSuperQueue();
            }
        }
        for (int i = 0; i < main.LeafUpgrade.Length; i++)
        {
            if (main.S.isSuperQueueAssignedforLeafUpgrade[i])
            {
                main.LeafUpgrade[i].AssignSuperQueue();
            }
        }
        for (int i = 0; i < main.StatusUpgrade.Length; i++)
        {
            if (main.S.isSuperQueueAssignedforStatusUpgrade[i])
            {
                main.StatusUpgrade[i].AssignSuperQueue();
            }
        }
        for (int i = 0; i < main.bankCtrl.BankUpgrades.Length; i++)
        {
            if (main.S.isSuperQueueSBAssigned[i])
            {
                main.bankCtrl.BankUpgrades[i].AssignSuperQueue();
            }
        }
    }
}
