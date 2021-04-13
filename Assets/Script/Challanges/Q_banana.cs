using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static QuestCtrl.QuestId;

public class Q_banana : QUEST
{
    /*
    TO DO
    ・ChallangeQuestId をクエスト名のものに変える．
    ・クエストに制限を付ける場合は，QuestConditionをoverrideする．
    */

    public override int clearedNum { get => main.S.clear7; set => main.S.clear7 = value; }
    public override bool isCleared { get => main.S.iC_bananoon; set => main.S.iC_bananoon = value; }
    public override int maxClaredNum { get => main.S.mClear_bananoon; set => main.S.mClear_bananoon = value; }

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
        main.GameController.InstantiateEnemy(11, new Vector2(0, 100), true);
    }

    public override void changeQuestId()
    {
        main.QuestId = banana;
        main.QuestCtrl.startChallange = StartChallange;

    }
    public override void GetReward()
    {
        if (!main.QuestCtrl.Quests[(int)banana].isCleared)
        {
            isCleared = true;

            main.skillSetController.UnleashSkillSlot();
            StartCoroutine(main.InstantiateLogText("Extra Skill Slot is Unleashed!", main.TutorialController.iconSpriteAry[3]));
        }
    }

}
