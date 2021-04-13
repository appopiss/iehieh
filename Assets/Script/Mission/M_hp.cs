using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class M_hp : MISSION {

    public float HP;

    public void awake(int MissionId, float HP)
    {
        this.MissionId = MissionId;
        this.HP = HP;
    }

    // Use this for initialization
    void Awake () {
		StartBASE();
        AwakeMission();
        ClearTrigger = () => main.ally.currentHp >= main.ally.HP() * HP;
    }

	// Use this for initialization
	void Start () {
        StartMission();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateMission();
        MissionExplainText.text = MissionLocal.hp(this);
    }
}
