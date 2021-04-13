using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class PQ_errand : ACHIEVEMENT
{
    // Use this for initialization
    void Awake()
    {
        //maxClearNumは最初に書いておこう．Awakeで初期化してるよ．
        AwakeQuest(0, Type.Permanent);
        CliantName = "The overprotective Dad";//"Sick girl's father";
        P_discription = "Thanks to you, my daughter is fine! But I'm worried if my daughter gets sick again, " +
            "would you please bring more of that fish as a spare?";
        //Parmanentの処理を書くよ．
        P_questName = "No worries if you are prepared";
        P_condition = () => main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.RainbowFish] >= 1;
        P_currentProgress = () => "Now you have " + main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.RainbowFish] + " / 1";
        P_unlockCondition = "Take 1 Rainbow Fish!";
        P_rewardText = "- Gold Cap + 50 for every clear of this quest";
    }

    //クエストの報酬
    public override void GetQuestPoint()
    {
        if (isParmanentMode())
        {
            main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.RainbowFish] -= 1;
            main.S.RainbowFishClearedNum++;
        }
    }

    // Use this for initialization
    void Start()
    {
        StartQuest();
    }

    // Update is called once per frame
    void Update()
    {
        GoldCapBonus = main.S.RainbowFishClearedNum * 50;
        UpdateQuest();
        //Debug.Log(Input.mousePosition-new Vector3(575,345));
    }
}
