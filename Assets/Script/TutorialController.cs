using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static QuestCtrl.QuestId;
using TMPro;

public class TutorialController : BASE {

    //解禁用
    public bool isUpgrade { get => main.S.isUpgrade; set => main.S.isUpgrade = value; }
    public bool isSkillSet { get => main.S.isSkillSet; set => main.S.isSkillSet = value; }
    public bool isSkillTree { get => main.S.isSkillTree; set => main.S.isSkillTree = value; }
    public bool isSlimeHideoutClear { get => main.S.isSlimeHideoutClear; set => main.S.isSlimeHideoutClear = value; }

    //解禁アイコン
    public Sprite[] iconSpriteAry;
    //DarkRitual
    public Button darkritualButton;
    //Bank
    public Button bankButton;
    //CraftRank
    public Button[] CraftRankButtonAry;
    //ReincarnationButton
    public Button ReincarnationButton;
    //Curse of Rein Button
    public Button CurseOfReincarnationButton;
    //TutorialCanvas
    public Canvas[] TutorialCanvasAry;

    //UPGRADEアイコン
    public bool isUpgradeIcon1 { get => main.S.isUpgradeIcon1; set => main.S.isUpgradeIcon1 = value; }
    public bool isUpgradeIcon2 { get => main.S.isUpgradeIcon2; set => main.S.isUpgradeIcon2 = value; }
    public bool isUpgradeIcon3 { get => main.S.isUpgradeIcon3; set => main.S.isUpgradeIcon3 = value; }
    public bool isUpgradeIcon4 { get => main.S.isUpgradeIcon4; set => main.S.isUpgradeIcon4 = value; }
    public bool isUpgradeIcon5 { get => main.S.isUpgradeIcon5; set => main.S.isUpgradeIcon5 = value; }
    public bool isUpgradeIcon6 { get => main.S.isUpgradeIcon6; set => main.S.isUpgradeIcon6 = value; }
    public bool isUpgradeIcon7 { get => main.S.isUpgradeIcon7; set => main.S.isUpgradeIcon7 = value; }
    public bool isUpgradeIcon8 { get => main.S.isUpgradeIcon8; set => main.S.isUpgradeIcon8 = value; }
    public bool isUpgradeIcon9 { get => main.S.isUpgradeIcon9; set => main.S.isUpgradeIcon9 = value; }
    public bool isUpgradeIcon10 { get => main.S.isUpgradeIcon10; set => main.S.isUpgradeIcon10 = value; }
    public bool isUpgradeIcon11 { get => main.S.isUpgradeIcon11; set => main.S.isUpgradeIcon11 = value; }
    public bool isUpgradeIcon12 { get => main.S.isUpgradeIcon12; set => main.S.isUpgradeIcon12 = value; }
    public bool isUpgradeIcon13 { get => main.S.isUpgradeIcon13; set => main.S.isUpgradeIcon13 = value; }
    public bool isUpgradeIcon14 { get => main.S.isUpgradeIcon14; set => main.S.isUpgradeIcon14 = value; }
    public bool isUpgradeIcon15 { get => main.S.isUpgradeIcon15; set => main.S.isUpgradeIcon15 = value; }
    //キャンバス
    public Transform BanCanvas;
    public Transform MenuCanvas;
    //public Transform IdleIconCanvas;
    public Transform IdleStoneCanvas;
    public Transform IdleCrystalCanvas;
    public Transform IdleLeafCanvas;
    public Transform IdleStatusCanvas;
    public Transform DungeonCanvas;

    public Transform ZoneCanvas;
    public Transform ChallengeCanvas;
    public Transform CraftRankCanvas;
    //テキスト
    public TextMeshProUGUI[] Texts;
    //ManualMode
    //public Toggle ManualToggle;
    //ActiveSkill
    public Canvas WarActiveSkillCanvas,WizActiveSkillCanvas,AngActiveSkillCanvas;

    public GameObject[] DailyQuest;

    // Use this for initialization
    void Awake () {
		StartBASE();
	}

	// Use this for initialization
	void Start () {
        if (!isUpgrade)
        {
            main.SR.gold = 100;
        }
        //メニュー
        ShowMenu();

        //アップグレード
        ShowUpgradeIcon();

        //DUNGEON
        ShowDungeon();
        //ZONE
        ShowZone();
        //CHALLENGE
        ShowChallenge();
        //CraftRank
        ShowCraftRank();
        ////SkillSlot
        //SkillSlot();
        //
        StartCoroutine(Resource100());
        //
        StartCoroutine(DarkRitual());
        StartCoroutine(Bank());

        if (!main.S.isWarActiveSkill)
        {
            setFalse(WarActiveSkillCanvas.gameObject);
            //WarActiveSkillCanvas.gameObject.GetComponent<RectTransform>().anchoredPosition += new Vector2(10000, 0);
        }
        if (!main.S.isWizActiveSkill)
        {
            setFalse(WizActiveSkillCanvas.gameObject);
            //WizActiveSkillCanvas.gameObject.GetComponent<RectTransform>().anchoredPosition += new Vector2(10000, 0);
        }
        if (!main.S.isAngActiveSkill)
        {
            setFalse(AngActiveSkillCanvas.gameObject);
            //AngActiveSkillCanvas.gameObject.GetComponent<RectTransform>().anchoredPosition += new Vector2(10000, 0);
        }
        if (!main.S.isSlimeHideoutClear)
        {
            TutorialCanvasAry[5].GetComponent<RectTransform>().anchoredPosition += new Vector2(-400, 0);
            TutorialCanvasAry[6].GetComponent<RectTransform>().anchoredPosition += new Vector2(400, 0);
        }
        if (!main.S.AddDQ1)
        {
            DailyQuest[1].GetComponent<RectTransform>().anchoredPosition += new Vector2(-400, 0);
        }
        if (!main.S.AddDQ2)
        {
            DailyQuest[2].GetComponent<RectTransform>().anchoredPosition += new Vector2(-400, 0);
        }
        if (!main.S.AddDQ3)
        {
            DailyQuest[3].GetComponent<RectTransform>().anchoredPosition += new Vector2(-400, 0);
        }
        if (!main.S.isMontblangoBeated)
        {
            ReincarnationButton.GetComponent<RectTransform>().anchoredPosition += new Vector2(-400, 0);
        }
        if (main.S.CurrentCurseId != CurseId.normal)
        {
            main.S.isDistortionBeated = true;
            main.QuestCtrl.Quests[(int)distortion].isCleared = true;
        }
        if (!main.S.isDistortionBeated)
        {
            CurseOfReincarnationButton.GetComponent<RectTransform>().anchoredPosition += new Vector2(-400, 0);
        }
        DailyQuestRarity();
    }

    public void DailyQuestRarity()
    {
        if (!main.S.RareDQ1 && !main.S.RareDQ2)
        {
            Texts[4].text = ": 80%\n: 10%\n: 6%\n: 3%\n: 1%";
        }
        else if (main.S.RareDQ1 && !main.S.RareDQ2)
        {
            Texts[4].text = ": 0%\n: 81%\n: 10%\n: 6%\n: 3%";
        }
        else if (!main.S.RareDQ1 && main.S.RareDQ2)
        {
            Texts[4].text = ": 80%\n: 0%\n: 11%\n: 6%\n: 3%";
        }
        else
        {
            Texts[4].text = ": 0%\n: 0%\n: 84%\n: 10%\n: 6%";
        }
    }


    public void SkillSlot()
    {
    //    //通常スロット
    //    if (main.S.isDungeon[11])
    //    {
    //        main.skillSlotCanvasAry[2].canEquipped = true;
    //    }


    //    //スライムによるスロット解禁
    //    if (main.QuestCtrl.Quests[(int)slimes].isCleared)
    //    {
    //        main.skillSlotCanvasAry[3].canEquipped = true;
    //    }
    //    ////フェアリによるスロット解禁
    //    //if (main.QuestCtrl.Quests[(int)fairy].isCleared)
    //    //{
    //    //}
    //    ////バナヌーンによるスロット解禁
    //    if (main.QuestCtrl.Quests[(int)banana].isCleared)
    //    {
    //        main.skillSlotCanvasAry[4].canEquipped = true;
    //    }
    //    //モンブランによるスロット解禁
    //    if (main.QuestCtrl.Quests[(int)montblango].isCleared)
    //    {
    //        main.skillSlotCanvasAry[5].canEquipped = true;
    //    }

    //    //グローバルスロット
    //    for (int i = 0; i < main.S.A_level[15]; i++)
    //    {
    //        main.skillSlotCanvasAry[7 + i].canEquipped = true;
    //    }

    }

    public void ShowMenu()
    {
        if (main.S.isUpgrade)
        {
            main.buttons[0].gameObject.GetComponent<Transform>().SetParent(MenuCanvas);//Upgrade
            if (main.S.isSkillTree)
            {
                main.buttons[1].gameObject.GetComponent<Transform>().SetParent(MenuCanvas);//SkillTree
                Texts[0].gameObject.SetActive(false);
                Texts[1].gameObject.SetActive(false);
                Texts[2].gameObject.SetActive(false);
                if (main.S.isSkillSet)
                {
                    main.buttons[8].gameObject.GetComponent<Transform>().SetParent(MenuCanvas);//Dungeon
                    if (main.S.isSlimeHideoutClear)
                    {
                        if (main.SR.isDungeon[15])
                        {
                          main.buttons[3].gameObject.GetComponent<Transform>().SetParent(MenuCanvas);//Challenge
                        }
                        main.buttons[7].gameObject.GetComponent<Transform>().SetParent(MenuCanvas);//Craft
                    }

                    if (main.S.isSlimeHideoutClear)
                    {
                        if(main.SR.isDungeon[9])
                        main.buttons[6].gameObject.GetComponent<Transform>().SetParent(MenuCanvas);//Quest
                        if (main.SR.isDungeon[12])
                        {
                            main.buttons[4].gameObject.GetComponent<Transform>().SetParent(MenuCanvas);//Rebirth
                        }
                    }
                }
            }
            //main.buttons[9].gameObject.GetComponent<Transform>().SetParent(MenuCanvas);//System
        }

    }
    public void ResetMenu()
    {
        main.buttons[0].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.buttons[1].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        //main.buttons[9].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.buttons[8].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.buttons[3].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.buttons[7].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.buttons[6].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.buttons[4].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
    }

    public void ShowUpgradeIcon()
    {
        if (main.S.isSlimeHideoutClear)
        {
            main.StatusUpgrade[4].gameObject.GetComponent<Transform>().SetParent(IdleStatusCanvas);//GoldUpgrade
            main.StatusUpgrade[5].gameObject.GetComponent<Transform>().SetParent(IdleStatusCanvas);//ExpUpgrade
        }
        if (main.S.isUpgradeIcon5)
            main.StatusUpgrade[3].gameObject.GetComponent<Transform>().SetParent(IdleStatusCanvas);

        if (main.S.isUpgradeIcon1)
        {
            main.StoneUpgrade[0].gameObject.GetComponent<Transform>().SetParent(IdleStoneCanvas);
            if (main.S.isUpgradeIcon4)
            {
                main.StoneUpgrade[1].gameObject.GetComponent<Transform>().SetParent(IdleStoneCanvas);
                if (main.S.isUpgradeIcon7)
                {
                    main.StoneUpgrade[2].gameObject.GetComponent<Transform>().SetParent(IdleStoneCanvas);
                }
            }
            main.StoneUpgrade[3].gameObject.GetComponent<Transform>().SetParent(IdleStoneCanvas);
            if (isSlimeHideoutClear)
            {
                main.StoneUpgrade[4].gameObject.GetComponent<Transform>().SetParent(IdleStoneCanvas);
            }
            if (main.S.isUpgradeIcon10)
            {
                main.StoneUpgrade[5].gameObject.GetComponent<Transform>().SetParent(IdleStoneCanvas);
                if (main.S.isUpgradeIcon9)
                {
                    main.StoneUpgrade[6].gameObject.GetComponent<Transform>().SetParent(IdleStoneCanvas);
                }
            }
            if (main.S.isUpgradeIcon8)
            {
                main.StatusUpgrade[0].gameObject.GetComponent<Transform>().SetParent(IdleStatusCanvas);
            }
        }
        if (main.S.isUpgradeIcon2)
        {
            main.CristalUpgrade[0].gameObject.GetComponent<Transform>().SetParent(IdleCrystalCanvas);
            if (main.S.isUpgradeIcon4)
            {
                main.CristalUpgrade[1].gameObject.GetComponent<Transform>().SetParent(IdleCrystalCanvas);
                if (main.S.isUpgradeIcon7)
                {
                    main.CristalUpgrade[2].gameObject.GetComponent<Transform>().SetParent(IdleCrystalCanvas);
                }
            }
            main.CristalUpgrade[3].gameObject.GetComponent<Transform>().SetParent(IdleCrystalCanvas);
            if (isSlimeHideoutClear)
            {
                main.CristalUpgrade[4].gameObject.GetComponent<Transform>().SetParent(IdleCrystalCanvas);
            }
            if (main.S.isUpgradeIcon10)
            {
                main.CristalUpgrade[5].gameObject.GetComponent<Transform>().SetParent(IdleCrystalCanvas);
                if (main.S.isUpgradeIcon9)
                {
                    main.CristalUpgrade[6].gameObject.GetComponent<Transform>().SetParent(IdleCrystalCanvas);
                }
            }
            if (main.S.isUpgradeIcon8)
            {
                main.StatusUpgrade[1].gameObject.GetComponent<Transform>().SetParent(IdleStatusCanvas);
            }
        }

        if (main.S.isUpgradeIcon3)
        {
            main.LeafUpgrade[0].gameObject.GetComponent<Transform>().SetParent(IdleLeafCanvas);
            if (main.S.isUpgradeIcon4)
            {
                main.LeafUpgrade[1].gameObject.GetComponent<Transform>().SetParent(IdleLeafCanvas);
                if (main.S.isUpgradeIcon7)
                {
                    main.LeafUpgrade[2].gameObject.GetComponent<Transform>().SetParent(IdleLeafCanvas);
                }
            }

            main.LeafUpgrade[3].gameObject.GetComponent<Transform>().SetParent(IdleLeafCanvas);
            if (isSlimeHideoutClear)
            {
                main.LeafUpgrade[4].gameObject.GetComponent<Transform>().SetParent(IdleLeafCanvas);
            }
            if (main.S.isUpgradeIcon10)
            {
                main.LeafUpgrade[5].gameObject.GetComponent<Transform>().SetParent(IdleLeafCanvas);
                if (main.S.isUpgradeIcon9)
                {
                    main.LeafUpgrade[6].gameObject.GetComponent<Transform>().SetParent(IdleLeafCanvas);
                }
            }
            if (main.S.isUpgradeIcon8)
            {
                main.StatusUpgrade[2].gameObject.GetComponent<Transform>().SetParent(IdleStatusCanvas);
            }
        }
        if(main.S.isUpgradeIcon11)
            main.StatusUpgrade[6].gameObject.GetComponent<Transform>().SetParent(IdleStatusCanvas);//LotteryUpgrade

    }
    public void ResetUpgradeIcon()
    {
        main.StoneUpgrade[0].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.StoneUpgrade[1].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.StoneUpgrade[2].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.StoneUpgrade[3].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.StoneUpgrade[4].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.StoneUpgrade[5].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.StoneUpgrade[6].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.StatusUpgrade[0].gameObject.GetComponent<Transform>().SetParent(BanCanvas);

        main.CristalUpgrade[0].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.CristalUpgrade[1].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.CristalUpgrade[2].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.CristalUpgrade[3].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.CristalUpgrade[4].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.CristalUpgrade[5].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.CristalUpgrade[6].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.StatusUpgrade[1].gameObject.GetComponent<Transform>().SetParent(BanCanvas);


        main.LeafUpgrade[0].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.LeafUpgrade[1].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.LeafUpgrade[2].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.LeafUpgrade[3].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.LeafUpgrade[4].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.LeafUpgrade[5].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.LeafUpgrade[6].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.StatusUpgrade[2].gameObject.GetComponent<Transform>().SetParent(BanCanvas);

        main.StatusUpgrade[3].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.StatusUpgrade[4].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.StatusUpgrade[5].gameObject.GetComponent<Transform>().SetParent(BanCanvas);//ExpUpgrade
        main.StatusUpgrade[6].gameObject.GetComponent<Transform>().SetParent(BanCanvas);//ExpUpgrade

    }

    public void ShowDungeon()
    {
        if (main.S.unleashDungeon1)
        {
            main.Texts[26].color = colorWhite;
            main.Texts[27].text = "Dungeon";

            if(main.SR.isDungeon[15])
                main.dungeonAry[32].gameObject.GetComponent<Transform>().SetParent(DungeonCanvas);
            if (main.SR.isDungeon[23])
                main.dungeonAry[33].gameObject.GetComponent<Transform>().SetParent(DungeonCanvas);
            if (main.SR.isDungeon[31])
                main.dungeonAry[34].gameObject.GetComponent<Transform>().SetParent(DungeonCanvas);
            if (main.SR.isDungeon[42])
                main.dungeonAry[43].gameObject.GetComponent<Transform>().SetParent(DungeonCanvas);
            if (main.SR.isDungeon[51])
                main.dungeonAry[52].gameObject.GetComponent<Transform>().SetParent(DungeonCanvas);
            if (main.SR.isDungeon[60])
                main.dungeonAry[61].gameObject.GetComponent<Transform>().SetParent(DungeonCanvas);
            if (main.SR.isDungeon[69])
                main.dungeonAry[70].gameObject.GetComponent<Transform>().SetParent(DungeonCanvas);
            if (main.SR.isDungeon[78])
                main.dungeonAry[79].gameObject.GetComponent<Transform>().SetParent(DungeonCanvas);
        }
        else
        {
            main.Texts[26].color = colorNothing;
            main.Texts[27].text = "   ???";
        }
    }
    public void ResetDungeon()
    {
        main.dungeonAry[32].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.dungeonAry[33].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.dungeonAry[34].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.dungeonAry[43].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.dungeonAry[52].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.dungeonAry[61].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.dungeonAry[70].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.dungeonAry[79].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
    }
    Color colorWhite = new Color(1, 1, 1, 1);
    Color colorNothing = new Color(0, 0, 0, 0);

    public void ShowZone()
    {
        main.ZoneCtrl.ZoneButton[0].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneSelectCanvas);//TheSlimeKingdom
        main.ZoneCtrl.SlimeZoneButton[0].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[0]);//SlimeSlums
        if (main.SR.isDungeon[0])
            main.ZoneCtrl.SlimeZoneButton[1].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[0]);//SlimeVillage
        if (main.SR.isDungeon[9])
            main.ZoneCtrl.SlimeZoneButton[2].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[0]);//SlimeSlums
        if (main.SR.isDungeon[10])
            main.ZoneCtrl.SlimeZoneButton[3].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[0]);//SlimeSlums
        if (main.SR.isDungeon[11])
            main.ZoneCtrl.SlimeZoneButton[4].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[0]);//SlimeSlums
        if (main.SR.isDungeon[12])
            main.ZoneCtrl.SlimeZoneButton[5].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[0]);//SlimeSlums
        if (main.SR.isDungeon[13])
            main.ZoneCtrl.SlimeZoneButton[6].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[0]);//SlimeSlums
        if (main.SR.isDungeon[14])
            main.ZoneCtrl.SlimeZoneButton[7].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[0]);//SlimeSlums

        if (main.SR.isDungeon[10])
        {
            main.ZoneCtrl.ZoneButton[1].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneSelectCanvas);//BatZone
            main.ZoneCtrl.BatZoneButton[0].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[1]);//Bat1
            if (main.SR.isDungeon[16])//Bat
                main.ZoneCtrl.BatZoneButton[1].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[1]);
            if (main.SR.isDungeon[17])//Bat
                main.ZoneCtrl.BatZoneButton[2].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[1]);
            if (main.SR.isDungeon[18])//Bat
                main.ZoneCtrl.BatZoneButton[3].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[1]);
            if (main.SR.isDungeon[19])//Bat
                main.ZoneCtrl.BatZoneButton[4].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[1]);
            if (main.SR.isDungeon[20])//Ba
                main.ZoneCtrl.BatZoneButton[5].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[1]);
            if (main.SR.isDungeon[21])//Bat
                main.ZoneCtrl.BatZoneButton[6].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[1]);
            if (main.SR.isDungeon[22])//Bat
                main.ZoneCtrl.BatZoneButton[7].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[1]);
        }

        if (main.SR.isDungeon[22])
        {
            main.ZoneCtrl.ZoneButton[2].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneSelectCanvas);//SpiderZone
            main.ZoneCtrl.SpiderZoneButton[0].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[2]);//Spider1
            if(main.SR.isDungeon[24])
                main.ZoneCtrl.SpiderZoneButton[1].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[2]);//Spider2
            if(main.SR.isDungeon[25])
                main.ZoneCtrl.SpiderZoneButton[2].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[2]);//Spider3
            if(main.SR.isDungeon[26])
                main.ZoneCtrl.SpiderZoneButton[3].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[2]);//Spider4
            if(main.SR.isDungeon[27])
                main.ZoneCtrl.SpiderZoneButton[4].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[2]);//Spider5
            if(main.SR.isDungeon[28])
                main.ZoneCtrl.SpiderZoneButton[5].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[2]);//Spider6
            if(main.SR.isDungeon[29])
                main.ZoneCtrl.SpiderZoneButton[6].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[2]);//Spider7
            if(main.SR.isDungeon[30])
                main.ZoneCtrl.SpiderZoneButton[7].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[2]);//Spider8
        }

        if (main.SR.isDungeon[28])
        {
            main.ZoneCtrl.ZoneButton[3].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneSelectCanvas);//FairyZone
            main.ZoneCtrl.FairyZoneButton[0].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[3]);//Spider1
            if (main.SR.isDungeon[35])//Fairy
                main.ZoneCtrl.FairyZoneButton[1].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[3]);//Fairy
            if (main.SR.isDungeon[36])//Fairy
                main.ZoneCtrl.FairyZoneButton[2].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[3]);//Fairy
            if (main.SR.isDungeon[37])//Fairy
                main.ZoneCtrl.FairyZoneButton[3].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[3]);//Fairy
            if (main.SR.isDungeon[38])//Fairy
                main.ZoneCtrl.FairyZoneButton[4].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[3]);//Fairy
            if (main.SR.isDungeon[39])//Fairy
                main.ZoneCtrl.FairyZoneButton[5].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[3]);//Fairy
            if (main.SR.isDungeon[40])//Fairy
                main.ZoneCtrl.FairyZoneButton[6].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[3]);//Fairy
            if (main.SR.isDungeon[41])//Fairy
                main.ZoneCtrl.FairyZoneButton[7].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[3]);//Fairy
        }

        if (main.SR.isDungeon[41])
        {
            main.ZoneCtrl.ZoneButton[4].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneSelectCanvas);//FoxZone
            main.ZoneCtrl.FoxZoneButton[0].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[4]);//Fox1
            if (main.SR.isDungeon[44])//Fairy
                main.ZoneCtrl.FoxZoneButton[1].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[4]);//Fox2
            if (main.SR.isDungeon[45])//Fox
                main.ZoneCtrl.FoxZoneButton[2].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[4]);//Fox3
            if (main.SR.isDungeon[46])//Fox
                main.ZoneCtrl.FoxZoneButton[3].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[4]);//Fox4
            if (main.SR.isDungeon[47])//Fox
                main.ZoneCtrl.FoxZoneButton[4].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[4]);//Fox5
            if (main.SR.isDungeon[48])//Fox
                main.ZoneCtrl.FoxZoneButton[5].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[4]);//Fox6
            if (main.SR.isDungeon[49])//Fox
                main.ZoneCtrl.FoxZoneButton[6].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[4]);//Fox7
            if (main.SR.isDungeon[50])//Fox
                main.ZoneCtrl.FoxZoneButton[7].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[4]);//Fox8
        }

        if (main.SR.isDungeon[48])
        {
            main.ZoneCtrl.ZoneButton[5].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneSelectCanvas);//MSlime
            main.ZoneCtrl.MSlimeZoneButton[0].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[5]);//MSlime1
            if (main.SR.isDungeon[53])//Fairy
                main.ZoneCtrl.MSlimeZoneButton[1].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[5]);//MSlime2
            if (main.SR.isDungeon[54])//MSlime
                main.ZoneCtrl.MSlimeZoneButton[2].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[5]);//MSlime3
            if (main.SR.isDungeon[55])//MSlime
                main.ZoneCtrl.MSlimeZoneButton[3].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[5]);//MSlime4
            if (main.SR.isDungeon[56])//MSlime
                main.ZoneCtrl.MSlimeZoneButton[4].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[5]);//MSlime5
            if (main.SR.isDungeon[57])//MSlime
                main.ZoneCtrl.MSlimeZoneButton[5].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[5]);//MSlime6
            if (main.SR.isDungeon[58])//MSlime
                main.ZoneCtrl.MSlimeZoneButton[6].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[5]);//MSlime7
            if (main.SR.isDungeon[59])//MSlime
                main.ZoneCtrl.MSlimeZoneButton[7].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[5]);//MSlime8
        }

        if (main.SR.isDungeon[59])
        {
            main.ZoneCtrl.ZoneButton[6].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneSelectCanvas);//MSlime
            main.ZoneCtrl.DevilFishZoneButton[0].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[6]);//DevilFish1
            if (main.SR.isDungeon[62])//DevilFish
                main.ZoneCtrl.DevilFishZoneButton[1].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[6]);//DevilFish2
            if (main.SR.isDungeon[63])//DevilFish
                main.ZoneCtrl.DevilFishZoneButton[2].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[6]);//DevilFish3
            if (main.SR.isDungeon[64])//DevilFish
                main.ZoneCtrl.DevilFishZoneButton[3].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[6]);//DevilFish4
            if (main.SR.isDungeon[65])//DevilFish
                main.ZoneCtrl.DevilFishZoneButton[4].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[6]);//DevilFish5
            if (main.SR.isDungeon[66])//DevilFish
                main.ZoneCtrl.DevilFishZoneButton[5].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[6]);//DevilFish6
            if (main.SR.isDungeon[67])//DevilFish
                main.ZoneCtrl.DevilFishZoneButton[6].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[6]);//DevilFish7
            if (main.SR.isDungeon[68])//DevilFish
                main.ZoneCtrl.DevilFishZoneButton[7].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[6]);//DevilFish8
        }

        if (main.SR.isDungeon[69])
        {
            main.ZoneCtrl.ZoneButton[7].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneSelectCanvas);//MSlime
            main.ZoneCtrl.BlobZoneButton[0].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[7]);
            if (main.SR.isDungeon[71])
                main.ZoneCtrl.BlobZoneButton[1].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[7]);
            if (main.SR.isDungeon[72])//DevilFish
                main.ZoneCtrl.BlobZoneButton[2].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[7]);
            if (main.SR.isDungeon[73])//DevilFish
                main.ZoneCtrl.BlobZoneButton[3].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[7]);
            if (main.SR.isDungeon[74])//DevilFish
                main.ZoneCtrl.BlobZoneButton[4].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[7]);
            if (main.SR.isDungeon[75])//DevilFish
                main.ZoneCtrl.BlobZoneButton[5].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[7]);
            if (main.SR.isDungeon[76])//DevilFish
                main.ZoneCtrl.BlobZoneButton[6].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[7]);
            if (main.SR.isDungeon[77])//DevilFish
                main.ZoneCtrl.BlobZoneButton[7].gameObject.GetComponent<Transform>().SetParent(main.ZoneCtrl.ZoneCanvas[7]);
        }

    }
    public void ResetZone()
    {
        //main.zoneAry[0].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        //main.zoneAry[1].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        //main.zoneAry[2].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        //main.zoneAry[3].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        //main.zoneAry[4].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
    }


    public IEnumerator Resource100()
    {
        yield return new WaitUntil(Done100);
        if (!isSkillTree)
        {
            TutorialCanvasAry[0].gameObject.GetComponent<RectTransform>().anchoredPosition += new Vector2(-10000, 0);
            isSkillTree = true;
            ResetMenu();
            ShowMenu();
            StartCoroutine(main.InstantiateLogText("New Content\n<size=12>\"SKILL TABLE\"<size=10> is Unleashed!", main.TutorialController.iconSpriteAry[11]));
            Texts[0].gameObject.SetActive(false);
            Texts[1].gameObject.SetActive(false);
            Texts[2].gameObject.SetActive(false);
        }
        yield break;
    }
    public IEnumerator DarkRitual()
    {
        if (!main.S.unleashDarkRitual)
        {
            darkritualButton.interactable = false;
            darkritualButton.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "???";
        }
        yield return new WaitUntil(() => main.S.unleashDarkRitual);
            darkritualButton.interactable = true ;
            darkritualButton.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Dark Ritual";
        yield break;
    }
    public IEnumerator Bank()
    {
        if (!main.S.unleashBank)
        {
            bankButton.interactable = false;
            bankButton.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "???";
        }
        yield return new WaitUntil(()=> main.S.unleashBank);
            bankButton.interactable = true ;
            bankButton.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Slime Bank";
        yield break;
    }

    public bool Done100()
    {
        if (main.S.job == ALLY.Job.Warrior)
        {
            if(main.S.totalGetStone >= 100)
            {
                return true;
            }
        }
        if (main.S.job == ALLY.Job.Wizard)
        {
            if(main.S.totalGetCrystal >= 100)
            {
                return true;
            }
        }
        if (main.S.job == ALLY.Job.Angel)
        {
            if(main.S.totalGetLeaf >= 100)
            {
                return true;
            }
        }
        return false;
    }
    public void ShowChallenge()
    {
        if (main.SR.isDungeon[15])
            main.QuestCtrl.Quests[(int)slimes].gameObject.GetComponent<Transform>().SetParent(ChallengeCanvas);
        if (main.SR.isDungeon[23])
            main.QuestCtrl.Quests[(int)golem].gameObject.GetComponent<Transform>().SetParent(ChallengeCanvas);
        if (main.SR.isDungeon[31])
            main.QuestCtrl.Quests[(int)spider].gameObject.GetComponent<Transform>().SetParent(ChallengeCanvas);
        if (main.SR.isDungeon[42])
            main.QuestCtrl.Quests[(int)fairy].gameObject.GetComponent<Transform>().SetParent(ChallengeCanvas);
        if (main.SR.isDungeon[51])
            main.QuestCtrl.Quests[(int)banana].gameObject.GetComponent<Transform>().SetParent(ChallengeCanvas);
        if (main.SR.isDungeon[60])
            main.QuestCtrl.Quests[(int)octan].gameObject.GetComponent<Transform>().SetParent(ChallengeCanvas);
        if (main.SR.isDungeon[69])
            main.QuestCtrl.Quests[(int)distortion].gameObject.GetComponent<Transform>().SetParent(ChallengeCanvas);
        if (main.SR.isDungeon[47])//5-4
            main.QuestCtrl.Quests[(int)montblango].gameObject.GetComponent<Transform>().SetParent(ChallengeCanvas);
    }
    public void ResetChallenge()
    {
        main.QuestCtrl.Quests[(int)slimes].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.QuestCtrl.Quests[(int)golem].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.QuestCtrl.Quests[(int)fairy].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.QuestCtrl.Quests[(int)banana].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.QuestCtrl.Quests[(int)spider].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.QuestCtrl.Quests[(int)montblango].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.QuestCtrl.Quests[(int)octan].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
        main.QuestCtrl.Quests[(int)distortion].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
    }
    public void ShowCraftRank()
    {
        if (main.QuestCtrl.Quests[(int)golem].isCleared)
            CraftRankButtonAry[0].gameObject.GetComponent<Transform>().SetParent(CraftRankCanvas);//RankC
        if (main.QuestCtrl.Quests[(int)fairy].isCleared)
            CraftRankButtonAry[1].gameObject.GetComponent<Transform>().SetParent(CraftRankCanvas);//RankB
        if (main.QuestCtrl.Quests[(int)octan].isCleared)
            CraftRankButtonAry[2].gameObject.GetComponent<Transform>().SetParent(CraftRankCanvas);//RankA
        if (main.QuestCtrl.Quests[(int)distortion].isCleared)
            CraftRankButtonAry[3].gameObject.GetComponent<Transform>().SetParent(CraftRankCanvas);//RankS?
    }
    public void ResetCraftRank()
    {
        
            CraftRankButtonAry[0].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
            CraftRankButtonAry[1].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
            CraftRankButtonAry[2].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
            CraftRankButtonAry[3].gameObject.GetComponent<Transform>().SetParent(BanCanvas);
    }

    // Update is called once per frame
    void Update () {
	}
}
