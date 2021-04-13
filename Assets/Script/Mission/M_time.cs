using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class M_time : MISSION
{
    public float time;

    /*
    public override void Judge(float time)
    {
        if (time > 0)
        {
            if (time <= this.time && !isCleared)
            {
                main.S.ECbyMission += GetEpicCoin();
                isCleared = true;
            }
        }
    }
    */

    // Use this for initialization
    void Awake()
    {
        StartBASE();
        AwakeMission();
        ClearTrigger = () => time > 0 && DUNGEON.thisClearTime <= time;
    }

    public void awake(int MissionId, float  time)
    {
        this.MissionId = MissionId;
        this.time = time;
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
        MissionExplainText.text = MissionLocal.cleartime(this);
    }
}
