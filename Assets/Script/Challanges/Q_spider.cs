using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static QuestCtrl.QuestId;

public class Q_spider : QUEST
{
    /*
    TO DO
    ・ChallangeQuestId をクエスト名のものに変える．
    ・クエストに制限を付ける場合は，QuestConditionをoverrideする．
    */

    public override int clearedNum { get => main.S.clear_spider; set => main.S.clear_spider = value; }
    public override bool isCleared { get => main.S.iC_spider; set => main.S.iC_spider = value; }
    public override int maxClaredNum { get => main.S.mClear_spider; set => main.S.mClear_spider = value; }
    private void Awake()
    {
        AwakeQuest();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartQuest();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateQuest();
    }

    // public override bool QuestCondition()
    // {
    //     return main.ally1.GetComponent<ALLY>().job == ALLY.Job.Angel;
    // }
    //ここに敵を出現させる処理を書く．
    public override void InstantiateEnemy()
    {
        InstantiateBoss(BossMonster, new Vector2(0, -40));
    }

    public override void changeQuestId()
    {
        main.QuestId = spider;
        main.QuestCtrl.startChallange = StartChallange;

    }

    public override void GetReward()
    {
        if (!isCleared)
        {
            isCleared = true;
            main.skillSetController.UnleashSkillSlot();
            StartCoroutine(main.InstantiateLogText("Extra Skill Slot is Unleashed!", main.TutorialController.iconSpriteAry[3]));
        }
    }


}
