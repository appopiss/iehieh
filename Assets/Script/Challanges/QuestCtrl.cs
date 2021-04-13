using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static QuestCtrl.QuestId;

public class QuestCtrl : BASE {

    public Action startChallange;
    public Image OctBackground;
    public Image sumiImage;
    public QUEST[] Quests;
    public ENEMY BigMetalSlime;
    public double R_golem()
    {
        return Math.Pow(1.005, main.QuestCtrl.Quests[(int)golem].maxClaredNum) - 1;
    }
    public double R_fairy()
        
    {
        return Math.Pow(1.005, main.QuestCtrl.Quests[(int)fairy].maxClaredNum) - 1 + 0.0005 * main.QuestCtrl.Quests[(int)fairy].maxClaredNum;
    }
    public double R_slime()
    {
        return Math.Pow(1.005, main.QuestCtrl.Quests[(int)slimes].maxClaredNum) - 1;
    }
    public double R_bananoon()
    {
        return Math.Pow(1.005, main.QuestCtrl.Quests[(int)banana].maxClaredNum) - 1;
    }
    public double R_spider()
    {
        return Math.Pow(1.005, main.QuestCtrl.Quests[(int)spider].maxClaredNum) - 1 + 0.0005 * main.QuestCtrl.Quests[(int)spider].maxClaredNum;
    }
    //public double R_montblango()
    //{
    //    return Math.Pow(1.005, main.QuestCtrl.Quests[(int)montblango].maxClaredNum) - 1;
    //}
    public double R_octobaddie()
    {
        return Math.Pow(1.005, main.QuestCtrl.Quests[(int)octan].maxClaredNum) - 1 + 0.0005 * main.QuestCtrl.Quests[(int)octan].maxClaredNum;
    }

    public double R_distortion()
    {
        return Math.Pow(1.005, main.QuestCtrl.Quests[(int)distortion].maxClaredNum) - 1;
    }

    public double DropModifier(QuestCtrl.QuestId id)
    {
        return Mathf.Min(3.0f, (0.025f * main.QuestCtrl.Quests[(int)id].clearedNum));
    }


    public IEnumerator ResetQuest()
    {
        float RestTime = DeltaTimeFloatNotSub(DateTime.Today.AddDays(1).Subtract(DateTime.Now));
        while (true)
        {
            main.Texts[14].text = "Level resets in " + DateTime.Today.AddDays(1).Subtract(DateTime.Now).ToString(@"hh\:mm\:ss");
            yield return new WaitForSeconds(1.0f);
            RestTime -= 1.0f;
            if(RestTime <=0 &&main.GameController.battleMode != GameController.BattleMode.challange)
            {
                foreach(QUEST quest in main.QuestCtrl.Quests)
                {
                    quest.clearedNum = 0;
                }
                yield return new WaitForSeconds(3.0f);
                RestTime = DeltaTimeFloatNotSub(DateTime.Today.AddDays(1).Subtract(DateTime.Now));
            }
        }
    }

    public enum QuestId
    {
        nothing = -1,
        golem = 2,
        fairy = 1,
        banana = 4,
        slimes = 0,
        spider = 3,
        montblango = 5,
        distortion = 6,
        octan = 7
    }
    public void doDelegate()
    {
        startChallange();
        main.ally.combo = 0;
    }

	// Use this for initialization
	void Awake () {
		StartBASE();
	}

	// Use this for initialization
	void Start () {
        main.buttons[2].onClick.AddListener(doDelegate);
        StartCoroutine(ChangeTextCor());
        //StartCoroutine(ResetQuest());
        main.Texts[14].text = "";//レベルリセットをなくしたため。
        ////最後にプレイしたのが今日以前だったらdifficultyをリセットする．
        //if (DateTime.Today > main.lastTime) { 
        
        //    foreach (QUEST quest in main.QuestCtrl.Quests)
        //    {
        //       quest.clearedNum = 0;
        //    }
        //}
        //foreach (QUEST quest in main.QuestCtrl.Quests)
        //{
        //    quest.clearedNum = 0;
        //}
    }
    public void ChangeText()
    {
        switch (main.QuestId)
        {
            case nothing:
                main.Texts[1].text = "";
                main.Texts[2].text = "";
                main.Texts[3].text = "";
                main.Texts[10].text = "";
                break;
            case golem:
                main.Texts[1].text = "No one knows who made it, but it will crush you if you even think about approaching it.";
                main.Texts[2].text = "Condition : " + "Kill the Golem";

                main.Texts[3].text = "Reward : ";
                if (!main.QuestCtrl.Quests[(int)main.QuestId].isCleared)
                    main.Texts[3].text += "<color=green>";
                main.Texts[3].text += "Unleash Rank C Craft, 1 Equipment Slot";

                main.Texts[10].text = "Level : " + (main.QuestCtrl.Quests[(int)main.QuestId].clearedNum + 1);
                main.Texts[21].text = "Max Level reached : " + (main.QuestCtrl.Quests[(int)main.QuestId].maxClaredNum + 1);
                main.Texts[22].text = "Permanent reward : DEF + " + percent(R_golem()) + " ,  MDEF + " + percent(R_golem());
                main.Texts[32].text = "Drop Chance from the boss : + " + percent(DropModifier(main.QuestId));
                break;
            case fairy:
                main.Texts[1].text = "An ancient fairy who uses powerful magic.";
                main.Texts[2].text = "Condition : " + "Kill the Fairy";

                main.Texts[3].text = "Reward : ";
                if (!main.QuestCtrl.Quests[(int)main.QuestId].isCleared)
                    main.Texts[3].text += "<color=green>";
                main.Texts[3].text += "Unleash Rank B Craft, 1 Equipment Slot";

                main.Texts[10].text = "Level : " + (main.QuestCtrl.Quests[(int)main.QuestId].clearedNum + 1);
                main.Texts[21].text = "Max Level reached : " + (main.QuestCtrl.Quests[(int)main.QuestId].maxClaredNum + 1);
                main.Texts[22].text = "Permanent reward : MATK + " + percent(R_fairy());
                main.Texts[32].text = "Drop Chance from the boss : + " + percent(DropModifier(main.QuestId));
                break;
            case slimes:
                main.Texts[1].text = "The most royal slime you've ever seen.";
                main.Texts[2].text = "Condition : " + "Kill the Slime King";
                main.Texts[3].text = "Reward : ";
                if (!main.QuestCtrl.Quests[(int)main.QuestId].isCleared)
                    main.Texts[3].text += "<color=green>";
                main.Texts[3].text += "Unleash 1 Skill Slot, 1 Equipment Slot";
                main.Texts[10].text = "Level : " + (main.QuestCtrl.Quests[(int)main.QuestId].clearedNum + 1);
                main.Texts[21].text = "Max Level reached : " + (main.QuestCtrl.Quests[(int)main.QuestId].maxClaredNum + 1);
                main.Texts[22].text = "Permanent reward  : HP + " + percent(R_slime());
                main.Texts[32].text = "Drop Chance from the boss : + " + percent(DropModifier(main.QuestId));
                break;
            case banana:
                main.Texts[1].text = "Do not underestimate this odd creature. He may smell of rotten bananas and have a vacant stare, but his hidden power will obliterate you.";
                main.Texts[2].text = "Condition : " + "Kill the Bananoon";

                main.Texts[3].text = "Reward : ";
                if (!main.QuestCtrl.Quests[(int)main.QuestId].isCleared)
                    main.Texts[3].text += "<color=green>";
                main.Texts[3].text += "Unleash 1 Skill Slot, 1 Equipment Slot";

                main.Texts[10].text = "Level : " + (main.QuestCtrl.Quests[(int)main.QuestId].clearedNum + 1);
                main.Texts[21].text = "Max Level reached : " + (main.QuestCtrl.Quests[(int)main.QuestId].maxClaredNum + 1);
                main.Texts[22].text = "Permanent reward : SPD + " + percent(R_bananoon());
                main.Texts[32].text = "Drop Chance from the boss : + " + percent(DropModifier(main.QuestId));
                break;
            case spider:
                main.Texts[1].text = "The biggest, scariest looking spider you've ever seen. Will you be her next meal?";
                main.Texts[2].text = "Condition : " + "Kill the Deathpider";

                main.Texts[3].text = "Reward : ";
                if (!main.QuestCtrl.Quests[(int)main.QuestId].isCleared)
                    main.Texts[3].text += "<color=green>";
                main.Texts[3].text += "Unleash 1 Skill Slot, 1 Equipment Slot";
                main.Texts[10].text = "Level : " + (main.QuestCtrl.Quests[(int)main.QuestId].clearedNum + 1);
                main.Texts[21].text = "Max Level reached : " + (main.QuestCtrl.Quests[(int)main.QuestId].maxClaredNum + 1);
                main.Texts[22].text = "Permanent reward : ATK + " + percent(R_spider());
                main.Texts[32].text = "Drop Chance from the boss : + " + percent(DropModifier(main.QuestId));
                break;
            case octan:
                main.Texts[1].text = "Octop... hmm... Octobaddie?";
                main.Texts[2].text = "Condition : " + "Kill the Octobaddie";
                main.Texts[3].text = "Reward : ";
                if (!main.QuestCtrl.Quests[(int)main.QuestId].isCleared)
                    main.Texts[3].text += "<color=green>";
                main.Texts[3].text += "Unleash Rank A equipment, 1 Equipment Slot";

                main.Texts[10].text = "Level : " + (main.QuestCtrl.Quests[(int)main.QuestId].clearedNum + 1);
                main.Texts[21].text = "Max Level reached : " + (main.QuestCtrl.Quests[(int)main.QuestId].maxClaredNum + 1);
                main.Texts[22].text = "Permanent reward : MP + " + percent(R_octobaddie());
                main.Texts[32].text = "Drop Chance from the boss : + " + percent(DropModifier(main.QuestId));
                break;
            case montblango:
                main.Texts[1].text = "Get too close and the stench will kill you. By the way, Japanese often love to eat roasted chestnuts.";//"What is this thing? A pile of garbage come to life? Doesn't matter, get too close and the stench will kill you.";
                main.Texts[2].text = "Condition : " + "Kill the Montblango";
                main.Texts[3].text = "Reward : ";
                if (!main.QuestCtrl.Quests[(int)main.QuestId].isCleared)
                    main.Texts[3].text += "<color=green>";
                main.Texts[3].text += "Unleash REINCARNATION, 1 Heart Stone";

                main.Texts[10].text = "Level : " + (main.QuestCtrl.Quests[(int)main.QuestId].clearedNum + 1);
                main.Texts[21].text = "Max Level reached : " + (main.QuestCtrl.Quests[(int)main.QuestId].maxClaredNum + 1);
                main.Texts[22].text = "Permanent reward : " + main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.montblango].maxClaredNum * 200 + " Spirit Essence";
                main.Texts[32].text = "";
                break;
            case distortion:
                main.Texts[1].text = "This slime is phasing in and out of reality. If you value your existence, you'll steer clear of this gelatinous anamoly.";
                main.Texts[2].text = "Condition : " + "Kill the Distortion Slime";

                main.Texts[3].text = "Reward : ";
                if (!main.QuestCtrl.Quests[(int)main.QuestId].isCleared)
                    main.Texts[3].text += "<color=green>";
                main.Texts[3].text += "Unleash Rank S equipment,Curse Reincarnation, and 1 Equipment Slot";

                main.Texts[10].text = "Level : " + (main.QuestCtrl.Quests[(int)main.QuestId].clearedNum + 1);
                main.Texts[21].text = "Max Level reached : " + (main.QuestCtrl.Quests[(int)main.QuestId].maxClaredNum + 1);
                main.Texts[22].text = "Permanent reward : EXP + " + percent(R_distortion());
                main.Texts[32].text = "Drop Chance from the boss : + " + percent(DropModifier(main.QuestId));
                break;
        }


    }

    public IEnumerator ChangeTextCor()
    {
        while (true)
        {
            yield return new WaitUntil(() => main.GameController.currentCanvas == main.GameController.ChallangeCanvas);
            ChangeText();
            yield return new WaitForSeconds(0.443f);
        }

    }

    void Update()
    {
        
        if(main.GameController.currentCanvas == main.GameController.ChallangeCanvas)
        {
            if (main.GameController.battleMode == GameController.BattleMode.challange || startChallange == null || main.DeathPanel.isPanel)
            {
                main.buttons[2].interactable = false;
            }
            else
            {
                main.buttons[2].interactable = true;
            }

        }
        if (main.GameController.battleMode == GameController.BattleMode.normal || main.DeathPanel.isPanel)
        {
            setFalse(main.BossHpSlider.gameObject);
        }

    }
}



