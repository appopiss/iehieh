using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static QuestCtrl.QuestId;

public class Q_golem : QUEST
{
    /*
    TO DO
    ・ChallangeQuestId をクエスト名のものに変える．
    ・クエストに制限を付ける場合は，QuestConditionをoverrideする．
    */

    public override int clearedNum { get => main.S.clear5; set => main.S.clear5 = value; }
    public override bool isCleared { get => main.S.iC_golem; set => main.S.iC_golem = value; }
    public override int maxClaredNum { get => main.S.mClear_golem; set => main.S.mClear_golem = value; }
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
        main.GameController.InstantiateEnemy(9, new Vector2(0, 0), true);
    }

    public override void changeQuestId()
    {
        main.QuestId = golem;
        main.QuestCtrl.startChallange = StartChallange;

    }
    public override void GetReward()
    {
        if (!isCleared)
        {
            isCleared = true;
            main.TutorialController.ResetCraftRank();
            main.TutorialController.ShowCraftRank();
            StartCoroutine(main.InstantiateLogText("<size=12>Rank \"C\" Equipment<size=10> is Unleashed!", main.TutorialController.iconSpriteAry[4]));
        }
    }

}
