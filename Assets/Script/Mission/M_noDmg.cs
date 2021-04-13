using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class M_noDmg : MISSION
{
    /*
    public override void Judge(float time)
    {
        if (!DUNGEON.isAttacked&&!isCleared)
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
        ClearTrigger = () => !DUNGEON.isAttacked;
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
        MissionExplainText.text = MissionLocal.nodamage();
    }
}
