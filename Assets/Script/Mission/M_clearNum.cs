using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class M_clearNum : MISSION
{
    public int clearNum;

    /*
    public override void Judge(float time)
    {
        if (gameObject.GetComponent<DUNGEON>().dungeonClearNum >= clearNum-1 && !isCleared)//ずれるから-1したよ
        {
            main.S.ECbyMission += GetEpicCoin();
            isCleared = true;
        }
    }
    */

    public void awake(int MissionId, int clearNum)
    {
        this.MissionId = MissionId;
        this.clearNum = clearNum;
    }

    // Use this for initialization
    void Awake()
    {
        StartBASE();
        AwakeMission();
        ClearTrigger = () =>
        {
            if (main.S.ReincarnationNum == 0)
                return gameObject.GetComponent<DUNGEON>().dungeonClearNum >= clearNum - 1;
            else
                return gameObject.GetComponent<DUNGEON>().dungeonClearNumForMission >= clearNum - 1 || gameObject.GetComponent<DUNGEON>().dungeonClearNum >= clearNum - 1;
        };
    }

    protected override void ResetVariable()
    {
        gameObject.GetComponent<DUNGEON>().dungeonClearNumForMission = 0;
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
        MissionExplainText.text = MissionLocal.clearNum(this);
    }
}
