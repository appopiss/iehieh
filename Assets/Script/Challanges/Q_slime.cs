using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static QuestCtrl.QuestId;
using static UsefulMethod;
using TMPro;

public class Q_slime : QUEST
{
    /*
    TO DO
    ・ChallangeQuestId をクエスト名のものに変える．
    ・クエストに制限を付ける場合は，QuestConditionをoverrideする．
    */

    public override int clearedNum { get => main.S.clear_Slime; set => main.S.clear_Slime = value; }
    public override bool isCleared { get => main.S.iC_slime; set => main.S.iC_slime = value; }
    public override int maxClaredNum { get => main.S.mClear_slime; set => main.S.mClear_slime = value; }
    public int SlimeChildKilled;

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
        if (!isCleared)
        {
            isCleared = true;
            main.skillSetController.UnleashSkillSlot();
            StartCoroutine(main.InstantiateLogText("Extra Skill Slot is Unleashed!", main.TutorialController.iconSpriteAry[3]));
                        Application.ExternalCall("kongregate.stats.submit", "DefeatSlimeKingPlayTimeMin", (long)(main.allTime/60));

        }
    }


    // public override bool QuestCondition()
    // {
    //     return main.ally1.GetComponent<ALLY>().job == ALLY.Job.Angel;
    // }
    //ここに敵を出現させる処理を書く．
    public override void InstantiateEnemy()
    {
        main.GameController.InstantiateEnemy(13, new Vector2(0, 50), true);
        SlimeChildKilled = 0;
        //if (!main.S.merciless&&main.quests[(int)ACHIEVEMENT.QuestList.merciless].isSeen[0])
        //    setActive(defeatText.gameObject);
    }

    public override void changeQuestId()
    {
        main.QuestId = slimes;
        main.QuestCtrl.startChallange = StartChallange;

    }

}
