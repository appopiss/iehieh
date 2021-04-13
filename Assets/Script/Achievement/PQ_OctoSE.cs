using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class PQ_OctoSE : ACHIEVEMENT
{
    // Use this for initialization
    void Awake()
    {
        //maxClearNumは最初に書いておこう．Awakeで初期化してるよ．
        AwakeQuest(0, Type.Permanent);
        CliantName = "Octobaddie Otaku";//"Sick girl's father";
        P_discription = "Hehe, I LOVE LOVE LOOOOOOOOVE Octobaddie. His Eyes are soooooooo cute!!!! Please bring one and let me more and more crazyyyy.";
        //Parmanentの処理を書くよ．
        P_questName = "Octobaddie Essence?";
        P_condition = () => main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.octan].maxClaredNum >= (clearNum + 1) && main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.OctopusEye] >= 1;
        P_currentProgress = () => "Octobaddie Max Level Reached : " + (main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.octan].maxClaredNum) + " / " + (clearNum + 1)
            + "\n- Octopus Eye " + main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.OctopusEye] + " / 1";
        P_unlockCondition = "Defeat Octobaddie Lv " + (clearNum + 1) + "\n- Bring 1 Octopus Eye";
        P_rewardText = "- <sprite=\"se2\" index=0> " + (190 + (clearNum + 1) * 10);//200,210,220,....
    }

    //クエストの報酬
    public override void GetQuestPoint()
    {
        if (isParmanentMode())
        {
            main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.OctopusEye] -= 1;
            P_unlockCondition = "Defeat Octobaddie Lv " + (clearNum + 1) + "\n- Bring 1 Octopus Eye";
            P_rewardText = "- <sprite=\"se2\" index=0> " + (190 + (clearNum + 1) * 10);//200,210,220,....
        }
    }
    public override void ExtraUnlockCondition()
    {
        unlock.UnlockCondition = () => main.S.ReincarnationNum >= 1;
    }

    // Use this for initialization
    void Start()
    {
        StartQuest();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateQuest();
        SEbonus = (190 * clearNum + 10 * clearNum * (clearNum + 1) / 2) / 10;
    }
}
