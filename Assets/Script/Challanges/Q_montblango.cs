using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static QuestCtrl.QuestId;

public class Q_montblango : QUEST
{
    /*
    TO DO
    ・ChallangeQuestId をクエスト名のものに変える．
    ・クエストに制限を付ける場合は，QuestConditionをoverrideする．
    */

    public override int clearedNum { get => main.S.clear_montblango; set => main.S.clear_montblango = value; }
    public override bool isCleared { get => main.S.iC_montblango; set => main.S.iC_montblango = value; }
    public override int maxClaredNum { get => main.S.mClear_montblango; set => main.S.mClear_montblango = value; }
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
        InstantiateBoss(BossMonster, new Vector2(0, 100));
    }

    public override void changeQuestId()
    {
        main.QuestId = montblango;
        main.QuestCtrl.startChallange = StartChallange;

    }

    public override void GetReward()
    {
        if (!main.QuestCtrl.Quests[(int)montblango].isCleared)
        {
            isCleared = true;
            main.S.RP += 1;
            if (!main.S.isMontblangoBeated)
            {
                main.TutorialController.ReincarnationButton.GetComponent<RectTransform>().anchoredPosition += new Vector2(400, 0);
                main.S.isMontblangoBeated = true;
            }
        }

    }


}
