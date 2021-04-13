using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class M_once : MISSION
{
    /*
    public override void Judge(float time)
    {
        if (DUNGEON.hitCount <=1 && !isCleared)
        {
            main.S.ECbyMission += GetEpicCoin();
            isCleared = true;
        }
    }
    */

    public void awake(int MissionId)
    {
        this.MissionId = MissionId;
    }

    // Use this for initialization
    void Awake()
    {
        StartBASE();
        AwakeMission();
        ClearTrigger = () => DUNGEON.hitCount <= 1;
    }

    // Use this for initialization
    void Start()
    {
        StartMission();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMission();
        MissionExplainText.text = MissionLocal.oneshot();
    }
}
