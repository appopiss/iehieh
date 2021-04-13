using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static QuestCtrl.QuestId;
using static UsefulMethod;
using System;

public class Q_octo : QUEST
{
    /*
    TO DO
    ・ChallangeQuestId をクエスト名のものに変える．
    ・クエストに制限を付ける場合は，QuestConditionをoverrideする．
    */

    public override int clearedNum { get => main.S.clear_octo; set => main.S.clear_octo = value; }
    public override bool isCleared { get => main.S.iC_octo; set => main.S.iC_octo = value; }
    public override int maxClaredNum { get => main.S.mClear_octo; set => main.S.mClear_octo = value; }
    private void Awake()
    {
        AwakeQuest();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartQuest();   
        setActive(main.BossHpSlider.gameObject);
        if(isCleared)
            Application.ExternalCall("kongregate.stats.submit", "OctKill", main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.octan].maxClaredNum + 1);
        if (!main.S.isAfterVer1101)
        {
            main.S.octoMaxReachedLevel = main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.octan].maxClaredNum;
            main.S.isAfterVer1101 = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateQuest();
    }
    public override void GetReward()
    {
        if (!main.QuestCtrl.Quests[(int)octan].isCleared)
        {
            isCleared = true;
            main.TutorialController.ResetCraftRank();
            main.TutorialController.ShowCraftRank();
            StartCoroutine(main.InstantiateLogText("<size=12>Rank \"A\" Equipment<size=10> is Unleashed!", main.TutorialController.iconSpriteAry[4]));
        }
        main.S.octoMaxReachedLevel = Math.Max(main.S.octoMaxReachedLevel, main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.octan].maxClaredNum);

    }
    //ここに敵を出現させる処理を書く．
    public override void InstantiateEnemy()
    {
        InstantiateBoss(BossMonster, new Vector2(0, 20));
    }

    public override void changeQuestId()
    {
        main.QuestId = octan;
        main.QuestCtrl.startChallange = StartChallange;

    }

}
