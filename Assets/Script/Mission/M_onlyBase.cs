using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class M_onlyBase : MISSION
{

    public float HP;

    public IEnumerator isBaseCor()
    {
        while (true)
        {
            if (!main.missionCondition.isOnlyBase())
                DUNGEON.isOnlyBase = false;

            yield return new WaitForSeconds(0.1f);
        }
    }

    public void awake(int MissionId)
    {
        this.MissionId = MissionId;
    }

    // Use this for initialization
    void Awake()
    {
        StartBASE();
        AwakeMission();
        ClearTrigger = () => DUNGEON.isOnlyBase;
    }

    // Use this for initialization
    void Start()
    {
        StartMission();
        StartCoroutine(isBaseCor());
    }   

    // Update is called once per frame
    void Update()
    {
        UpdateMission();
        MissionExplainText.text = MissionLocal.onlyBase();
    }
}
