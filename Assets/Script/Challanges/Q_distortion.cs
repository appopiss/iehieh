using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static QuestCtrl.QuestId;

public class Q_distortion : QUEST
{
    /*
    TO DO
    ・ChallangeQuestId をクエスト名のものに変える．
    ・クエストに制限を付ける場合は，QuestConditionをoverrideする．
    */

    public override int clearedNum { get => main.S.clear_distortion; set => main.S.clear_distortion = value; }
    public override bool isCleared { get => main.S.iC_distortion; set => main.S.iC_distortion = value; }
    public override int maxClaredNum { get => main.S.mClear_distortion; set => main.S.mClear_distortion = value; }
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
        InstantiateBoss(BossMonster, new Vector2(0, 70f));
    }

    public override void changeQuestId()
    {
        main.QuestId = distortion;
        main.QuestCtrl.startChallange = StartChallange;

    }

    public override void GetReward()
    {
        if (!main.QuestCtrl.Quests[(int)distortion].isCleared)
        {
            isCleared = true;
            main.S.RP += 1;//HS
            main.TutorialController.ResetCraftRank();
            main.TutorialController.ShowCraftRank();
            StartCoroutine(main.InstantiateLogText("<size=12>Rank \"S\" Equipmentand Curse of Reincarnation <size=10>are Unleashed! ", main.TutorialController.iconSpriteAry[4]));
            if (!main.S.isDistortionBeated)
            {
                main.TutorialController.CurseOfReincarnationButton.GetComponent<RectTransform>().anchoredPosition += new Vector2(400, 0);
                main.S.isDistortionBeated = true;
            }
        }
    }

}
