using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class M_capture : MISSION
{

    //敵を何体キャプチャしたか
    public ENEMY.EnemyKind TargetEnemy;
    public long requiredCaptureNum;

    public void awake(int MissionId, ENEMY.EnemyKind TargetEnemy, long requiredCaptureNum)
    {
        this.MissionId = MissionId;
        this.TargetEnemy = TargetEnemy;
        this.requiredCaptureNum = requiredCaptureNum;
    }

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
        ClearCondition = () => capturedNum >= requiredCaptureNum;
    }

    protected override void ResetVariable()
    {
        capturedNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMission();
        if (gameObject.GetComponent<DUNGEON>().window.activeSelf)
        {
            MissionExplainText.text = MissionLocal.capture(this);
        }
    }
}
