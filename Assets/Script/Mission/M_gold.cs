using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class M_gold : MISSION {

    /*
    public override void Judge(float time)
    {
        if(main.DeathPanel.gold >= goldNum && !isCleared)
        {
            main.S.ECbyMission += GetEpicCoin();
            isCleared = true;
        }
    }
    */

    public double goldNum;

    public void awake(int MissionId, double goldNum)
    {
        this.MissionId = MissionId;
        this.goldNum = goldNum;
    }

    // Use this for initialization
    void Awake () {
		StartBASE();
        AwakeMission();
        ClearTrigger = () => main.DeathPanel.gold >= goldNum;
    }

	// Use this for initialization
	void Start () {
        StartMission();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateMission();
        MissionExplainText.text = MissionLocal.gold(this);
    }
}
