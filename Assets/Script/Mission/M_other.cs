using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class M_other : MISSION
{
    public Func<string> otherText;

    // Use this for initialization
    void Awake()
    {
        StartBASE();
        AwakeMission();
        isUpdate = true;
    }

    // Use this for initialization
    void Start()
    {
        StartMission();
    }

    public void awake(int MissionId, Func<string> otherText, Func<bool> ClearCondition)
    {
        this.MissionId = MissionId;
        this.otherText = otherText;
        this.ClearCondition = ClearCondition;
    }

    protected override void ResetVariable()
    {
        switch (MissionId)
        {
            case 3:
                main.S.bigSlimeNumByBase = 0;
                break;
            case 31:
                main.S.purpleSlimeNum = 0;
                break;
            case 32:
                main.S.metalSlimeNum = 0;
                break;
            case 73:
                main.S.metalSlimeNum2 = 0;
                break;
            case 36:
                main.S.slimeBossNum = 0;
                break;
            case 42:
                main.S.normalBatNum = 0;
                break;
            case 61:
                main.S.yellowBatNum = 0;
                break;
            case 76:
                main.S.blackBatNum = 0;
                break;
            case 24:
                main.S.activeSkillAt15 = 0;
                break;
            case 3 + 384:
                main.S.hidden_bigSlimeNumByBase = 0;
                break;
            case 31 + 384:
                main.S.hidden_purpleSlimeNum = 0;
                break;
            case 32 + 384:
                main.S.hidden_metalSlimeNum = 0;
                break;
            case 73 + 384:
                main.S.hidden_metalSlimeNum2 = 0;
                break;
            case 36 + 384:
                main.S.hidden_slimeBossNum = 0;
                break;
            case 42 + 384:
                main.S.hidden_normalBatNum = 0;
                break;
            case 61 + 384:
                main.S.hidden_yellowBatNum = 0;
                break;
            case 76 + 384:
                main.S.hidden_blackBatNum = 0;
                break;
            case 24 + 384:
                main.S.hidden_activeSkillAt15 = 0;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMission();
        MissionExplainText.text = otherText();
    }
}
