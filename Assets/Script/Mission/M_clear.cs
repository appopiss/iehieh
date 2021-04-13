using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class M_clear : MISSION
{

    public float HP;

    /*
    public override void Judge(float time)
    {
        GetEpicCoin();
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
        ClearTrigger = () => true;
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
        MissionExplainText.text = MissionLocal.clear();
    }
}
