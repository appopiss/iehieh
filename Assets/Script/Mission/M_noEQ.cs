using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class M_noEQ : MISSION
{

    //public float HP;
    /*
    public override void Judge(float time)
    {
        if (DUNGEON.isNoEQ && !isCleared)
        {
            main.S.ECbyMission += GetEpicCoin();
            isCleared = true;
        }
    }
    */

    public IEnumerator isBaseCor()
    {

        while (true)
        {
            if (!main.missionCondition.isNoEQ())
                DUNGEON.isNoEQ = false;//一回でもEQしてたらfalse

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
        ClearTrigger = () => DUNGEON.isNoEQ;
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
        MissionExplainText.text = MissionLocal.noeq();
    }
}
