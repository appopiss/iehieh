using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class M_spendTime : MISSION
{
    public double requiredSpendTime;
    DUNGEON dungeon;
    // Use this for initialization
    void Awake()
    {
        StartBASE();
        AwakeMission();
        isUpdate = true;
        dungeon = gameObject.GetComponent<DUNGEON>();
    }

    // Use this for initialization
    void Start()
    {
        StartMission();
        ClearCondition = () => dungeon.spendTime >= requiredSpendTime;
    }

    public void awake(int MissionId, double requiredSpendTime)
    {
        this.MissionId = MissionId;
        this.requiredSpendTime = requiredSpendTime;
    }

    protected override void ResetVariable()
    {
        dungeon.spendTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMission();
        if (dungeon.window.activeSelf)
        {
            MissionExplainText.text = MissionLocal.spendtime(this, dungeon);
        }
    }
}
