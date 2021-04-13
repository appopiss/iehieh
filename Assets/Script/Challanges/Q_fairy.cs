using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static QuestCtrl.QuestId;
using static UsefulMethod;

public class Q_fairy : QUEST
{
    /*
    TO DO
    ・ChallangeQuestId をクエスト名のものに変える．
    ・クエストに制限を付ける場合は，QuestConditionをoverrideする．
    */

    public override int clearedNum { get => main.S.clear6; set => main.S.clear6 = value; }
    public override bool isCleared { get => main.S.iC_fairy; set => main.S.iC_fairy = value; }
    public override int maxClaredNum { get => main.S.mClear_fairy; set => main.S.mClear_fairy = value; }
    private void Awake()
    {
        AwakeQuest();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartQuest();
        setActive(main.BossHpSlider.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateQuest();
    }
    public override void GetReward()
    {
        if (!main.QuestCtrl.Quests[(int)fairy].isCleared)
        {
            isCleared = true;
            main.TutorialController.ResetCraftRank();
            main.TutorialController.ShowCraftRank();
            StartCoroutine(main.InstantiateLogText("<size=12>Rank \"B\" Equipment<size=10> is Unleashed!", main.TutorialController.iconSpriteAry[4]));
        }
    }
    // public override bool QuestCondition()
    // {
    //     return main.ally1.GetComponent<ALLY>().job == ALLY.Job.Angel;
    // }
    //ここに敵を出現させる処理を書く．
    public override void InstantiateEnemy()
    {
        InstantiateBoss(BossMonster, new Vector2(0, 80));
    }

    public override void changeQuestId()
    {
        main.QuestId = fairy;
        main.QuestCtrl.startChallange = StartChallange;

    }

}
