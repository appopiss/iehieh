using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static GameController.UpgradeMenu;
using TMPro;

public class GameController : BASE {

    
    public bool isAuto;
    public bool isDlcIEH2;
    //村
    public Main.Village currentVillage { get => main.SR.currentVillage; set => main.SR.currentVillage = value; }
    public Main.Dungeon currentDungeon { get => main.SR.currentDungeon; set => main.SR.currentDungeon = value; }
    public Button slimeVillage;
    public Button batVillage;
    public Button ballVillage;
    public Button fishVillage;
    public Button foxVillage;
    int ChiliRandomNum;

    public bool isFieldEffect;

    public int floorNum { get => main.SR.floorNum; set => main.SR.floorNum = value; }
    public int floorNum1 { get => main.SR.floorNum1; set => main.SR.floorNum1 = value; }
    public int floorNum2 { get => main.SR.floorNum2; set => main.SR.floorNum2 = value; }
    public int floorNum3 { get => main.SR.floorNum3; set => main.SR.floorNum3 = value; }
    public int floorNum4 { get => main.SR.floorNum4; set => main.SR.floorNum4 = value; }
    
    public int maxFloorNum { get => main.SR.maxFloorNum; set => main.SR.maxFloorNum = value; }
    public int maxFloorNum1 { get => main.SR.maxFloorNum1; set => main.SR.maxFloorNum1 = value; }
    public int maxFloorNum2 { get => main.SR.maxFloorNum2; set => main.SR.maxFloorNum2 = value; }
    public int maxFloorNum3 { get => main.SR.maxFloorNum3; set => main.SR.maxFloorNum3 = value; }
    public int maxFloorNum4 { get => main.SR.maxFloorNum4; set => main.SR.maxFloorNum4 = value; }

    public int SaveMaxFloorNum { get => main.S.maxFloorNum; set => main.S.maxFloorNum = value; }
    public int SaveMaxFloorNum1 { get => main.S.maxFloorNum1; set => main.S.maxFloorNum1 = value; }
    public int SaveMaxFloorNum2 { get => main.S.maxFloorNum2; set => main.S.maxFloorNum2 = value; }
    public int SaveMaxFloorNum3 { get => main.S.maxFloorNum3; set => main.S.maxFloorNum3 = value; }
    public int SaveMaxFloorNum4 { get => main.S.maxFloorNum4; set => main.S.maxFloorNum4 = value; }
    public Main.CurrentStage currentStage { get => main.SR.currentStage; set => main.SR.currentStage = value; }

    //3つ目のボタンを開放したかどうか．
    public bool FirstButton { get => main.S.FirstButton; set => main.S.FirstButton = value; }
    //3つのボタンを押したかどうか．
    public bool isJobbed { get => main.S.isJobbed; set => main.S.isJobbed = value; }

    public GameObject ChooseFirstWeapon;
    public GameObject HideIdleCanvas;
    public GameObject IdleCanvas;
    public GameObject NoRaycastImage;
    public GameObject SkillTreeCanvas;
    public GameObject VillageCanvas;
    public GameObject InventoryCanvas;
    public GameObject ChallangeCanvas;
    public GameObject U_statusCanvas;
    public GameObject[] HideResources;
    public GameObject JobchangeCanvas;
    public GameObject AchievementCanvas;
    public GameObject ArtifactCanvas;
    public GameObject currentCanvas;
    public UpgradeMenu UpgradeMode;
    public BattleMode battleMode;
    public GameObject Field;
    public Image ChallengeField;
    public Image ChallengeFieldAbove;
    public int Stage1WaveNum = 0;
    public int Stage2WaveNum = 10;
    public int Stage3WaveNum = 15;
    public int Stage4WaveNum = 20;
    public int Stage5WaveNum = 25;
    public int Stage6WaveNum = 40;
    public int Stage7WaveNum = 55;
    public int Stage8WaveNum = 80;
    //敵の出現に使う↓
    int randomEnemyNum;

    public enum UpgradeMenu
    {
        upgrade,
        skillTree,
        village,
        inventory,
        challange,
        jobchange,
        achievement,
        artifact
    }
    public enum BattleMode
    {
        normal,
        challange,
        dungeon
    }
        
	// Use this for initialization
	void Awake () {
		StartBASE();
        //Time.fixedDeltaTime = 0.01f;
        //Time.timeScale = 3.0f;
	}

	// Use this for initialization
	void Start () {
        
        if (isJobbed)
        {
            if (!main.TutorialController.isSlimeHideoutClear)
            {
                setFalse(main.GameController.ChallengeField.gameObject);
                //setFalse(main.DungeonBar.gameObject);
                setFalse(main.BossHpSlider.gameObject);
                if (main.DeathPanel.isPanel)
                {
                    main.DeathPanel.FadeAwayPanel();
                    main.DeathPanel.isPanel = false;
                }
                //main.dungeonAry[0].TryDungeon();
                //main.dungeonAry[(int)currentDungeon].TryDungeon();
            }
            else
            {
                setFalse(main.GameController.ChallengeField.gameObject);
                //setFalse(main.DungeonBar.gameObject);
                setFalse(main.BossHpSlider.gameObject);
                if (main.DeathPanel.isPanel)
                {
                    main.DeathPanel.FadeAwayPanel();
                    main.DeathPanel.isPanel = false;
                }
                //main.dungeonAry[(int)currentDungeon].TryDungeon();
                //initStage();仕様変更
            }

        }
        InitImageAlpha();
        //アイドルキャンバスの中のすべてのレイキャストを外す．
        if (!main.ally1.GetComponent<ALLY>().isDead)
        {
            UnRayCast();
        }
        main.buttons[0].onClick.AddListener(doChangeUpgrade);
        main.buttons[1].onClick.AddListener(doChangeSkillTree);
        main.buttons[8].onClick.AddListener(doChangeVillage);
        main.buttons[9].onClick.AddListener(doChangeInventory);
        main.buttons[3].onClick.AddListener(doChangeChallange);
        main.buttons[4].onClick.AddListener(doChangeJobchange);
        main.buttons[6].onClick.AddListener(doChangeAchievement);
        main.buttons[7].onClick.AddListener(doChangeArtifact);

        //StartCoroutine(ReleaseContent());
        //最初の3つのボタンの開放
        if (!FirstButton || !isJobbed)
        {
            ActiveObject(ChooseFirstWeapon);
            FirstButton = true;
        }
        StartCoroutine(StageController());
       // if (FirstButton && !isJobbed)
       // {
       //     ChooseFirstWeapon.GetComponent<Image>().color = new Color(1, 1, 1, 0);
       //     ChooseFirstWeapon.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, -140);
       // }
        currentCanvas = IdleCanvas;
        // if (FirstButton)
        // {
        //     Destroy(ChooseFirstWeaponObject);
        // }

        //VillageButton
        //slimeVillage.onClick.AddListener(()=> { battleMode = BattleMode.normal; currentVillage = Main.Village.slime; initStage(); });
        //batVillage.onClick.AddListener(()=> { battleMode = BattleMode.normal; currentVillage = Main.Village.bat; initStage(); });
        //ballVillage.onClick.AddListener(()=> { battleMode = BattleMode.normal; currentVillage = Main.Village.ball; initStage(); });
        //fishVillage.onClick.AddListener(()=> { battleMode = BattleMode.normal; currentVillage = Main.Village.fish; initStage(); });
        //foxVillage.onClick.AddListener(()=> { battleMode = BattleMode.normal; currentVillage = Main.Village.fox; initStage(); });
        StartCoroutine(ZoneCor());
        //Time.timeScale = 6.0f;
        trans = new Color(0, 0, 0, 0);
        black = new Color(0, 0, 0, 1);
        setActive(ChallengeField.gameObject);
        ChallengeFieldAbove.color = black;

    }

    // Update is called once per frame

    public bool isChili;
    Color trans;
    Color black;
    public GameObject hiddenImage;
    
    public void ChangeFieldSprite()
    {
        if (battleMode == BattleMode.normal)
        {

            ChallengeFieldAbove.color = trans;
            setFalse(main.GameController.ChallengeField.gameObject);
        }
        else if (battleMode == BattleMode.dungeon)
        {
            setActive(ChallengeField.gameObject);
            ChallengeFieldAbove.color = black;
            if (main.ZoneCtrl.isHidden)
                setActive(hiddenImage);
            else
                setFalse(hiddenImage);

            switch (currentDungeon)
                {
                    case Main.Dungeon.slimeHideout:
                        ChallengeField.sprite = main.ChallengeSpriteAry[8];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_slimeVillage:
                        ChallengeField.sprite = main.ChallengeSpriteAry[9];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_slimePlains:
                        ChallengeField.sprite = main.ChallengeSpriteAry[10];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_slimePits:
                        if (ChiliRandomNum < 1000)
                            ChallengeField.sprite = main.ChallengeSpriteAry[7];
                        else
                            ChallengeField.sprite = main.ChallengeSpriteAry[1];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_slimePools:
                        ChallengeField.sprite = main.ChallengeSpriteAry[11];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_slimeForest:
                        ChallengeField.sprite = main.ChallengeSpriteAry[12];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_slimeCastle:
                        ChallengeField.sprite = main.ChallengeSpriteAry[13];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_slimeThroneRoom:
                        ChallengeField.sprite = main.ChallengeSpriteAry[14];
                        isFieldEffect = false;
                        break;
                    //Bat
                    case Main.Dungeon.Z_batDarkForest:
                        ChallengeField.sprite = main.ChallengeSpriteAry[15];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_batCaveInTheWoods:
                        ChallengeField.sprite = main.ChallengeSpriteAry[16];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_batRuinedTemple:
                        ChallengeField.sprite = main.ChallengeSpriteAry[19];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_batTempleAntechamber:
                        ChallengeField.sprite = main.ChallengeSpriteAry[20];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_batCollapsedSanctuary:
                        ChallengeField.sprite = main.ChallengeSpriteAry[17];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_batUnderTemple:
                        ChallengeField.sprite = main.ChallengeSpriteAry[21];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_batBreedingGrounds:
                        ChallengeField.sprite = main.ChallengeSpriteAry[18];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_batBlackCorridor:
                        ChallengeField.sprite = main.ChallengeSpriteAry[22];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_batD:
                        ChallengeField.sprite = main.ChallengeSpriteAry[23];
                        isFieldEffect = false;
                        break;
                    //Spider
                    case Main.Dungeon.Z_spider1:
                        ChallengeField.sprite = main.ChallengeSpriteAry[24];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_spider2:
                        ChallengeField.sprite = main.ChallengeSpriteAry[25];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_spider3:
                        ChallengeField.sprite = main.ChallengeSpriteAry[26];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_spider4:
                        ChallengeField.sprite = main.ChallengeSpriteAry[27];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_spider5:
                        ChallengeField.sprite = main.ChallengeSpriteAry[28];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_spider6:
                        ChallengeField.sprite = main.ChallengeSpriteAry[29];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_spider7:
                        ChallengeField.sprite = main.ChallengeSpriteAry[30];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_spider8:
                        ChallengeField.sprite = main.ChallengeSpriteAry[31];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_spiderD:
                        ChallengeField.sprite = main.ChallengeSpriteAry[32];
                        isFieldEffect = false;
                        break;
                    //Fairy
                    case Main.Dungeon.Z_fairy1:
                        ChallengeField.sprite = main.ChallengeSpriteAry[37];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_fairy2:
                        ChallengeField.sprite = main.ChallengeSpriteAry[38];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_fairy3:
                        ChallengeField.sprite = main.ChallengeSpriteAry[39];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_fairy4:
                        ChallengeField.sprite = main.ChallengeSpriteAry[40];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_fairy5:
                        ChallengeField.sprite = main.ChallengeSpriteAry[41];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_fairy6:
                        ChallengeField.sprite = main.ChallengeSpriteAry[42];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_fairy7:
                        ChallengeField.sprite = main.ChallengeSpriteAry[43];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_fairy8:
                        ChallengeField.sprite = main.ChallengeSpriteAry[44];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_fairyD:
                        ChallengeField.sprite = main.ChallengeSpriteAry[35];
                        isFieldEffect = false;
                        break;
                    //Fox
                    case Main.Dungeon.Z_fox1:
                        ChallengeField.sprite = main.ChallengeSpriteAry[45];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_fox2:
                        ChallengeField.sprite = main.ChallengeSpriteAry[46];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_fox3:
                        ChallengeField.sprite = main.ChallengeSpriteAry[47];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_fox4:
                        ChallengeField.sprite = main.ChallengeSpriteAry[48];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_fox5:
                        ChallengeField.sprite = main.ChallengeSpriteAry[49];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_fox6:
                        ChallengeField.sprite = main.ChallengeSpriteAry[50];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_fox7:
                        ChallengeField.sprite = main.ChallengeSpriteAry[51];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_fox8:
                        ChallengeField.sprite = main.ChallengeSpriteAry[52];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_foxD:
                        ChallengeField.sprite = main.ChallengeSpriteAry[60];
                        isFieldEffect = false;
                        break;
                    //MS
                    case Main.Dungeon.Z_MS1:
                        ChallengeField.sprite = main.ChallengeSpriteAry[53];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_MS2:
                        if (ChiliRandomNum < 1000)
                            ChallengeField.sprite = main.ChallengeSpriteAry[7];
                        else
                            ChallengeField.sprite = main.ChallengeSpriteAry[1];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_MS3:
                        ChallengeField.sprite = main.ChallengeSpriteAry[54];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_MS4:
                        ChallengeField.sprite = main.ChallengeSpriteAry[55];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_MS5:
                        ChallengeField.sprite = main.ChallengeSpriteAry[56];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_MS6:
                        ChallengeField.sprite = main.ChallengeSpriteAry[57];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_MS7:
                        ChallengeField.sprite = main.ChallengeSpriteAry[58];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_MS8:
                        ChallengeField.sprite = main.ChallengeSpriteAry[59];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_MSD:
                        ChallengeField.sprite = main.ChallengeSpriteAry[61];
                        isFieldEffect = false;
                        break;

                    //DevilFish
                    case Main.Dungeon.Z_DF1:
                        ChallengeField.sprite = main.ChallengeSpriteAry[62];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_DF2:
                        ChallengeField.sprite = main.ChallengeSpriteAry[63];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_DF3:
                        ChallengeField.sprite = main.ChallengeSpriteAry[64];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_DF4:
                        ChallengeField.sprite = main.ChallengeSpriteAry[65];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_DF5:
                        ChallengeField.sprite = main.ChallengeSpriteAry[66];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_DF6:
                        ChallengeField.sprite = main.ChallengeSpriteAry[67];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_DF7:
                        ChallengeField.sprite = main.ChallengeSpriteAry[68];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_DF8:
                        ChallengeField.sprite = main.ChallengeSpriteAry[69];
                        isFieldEffect = false;
                        break;
                    case Main.Dungeon.Z_DFD:
                        ChallengeField.sprite = main.ChallengeSpriteAry[70];
                        isFieldEffect = false;
                        break;

                    //Blob
                    case Main.Dungeon.Z_BB1:
                        ChallengeField.sprite = main.ChallengeSpriteAry[73];
                        break;
                    case Main.Dungeon.Z_BB2:
                        ChallengeField.sprite = main.ChallengeSpriteAry[73];
                        break;
                    case Main.Dungeon.Z_BB3:
                        ChallengeField.sprite = main.ChallengeSpriteAry[73];
                        break;
                    case Main.Dungeon.Z_BB4:
                        ChallengeField.sprite = main.ChallengeSpriteAry[73];
                        break;
                    case Main.Dungeon.Z_BB5:
                        ChallengeField.sprite = main.ChallengeSpriteAry[73];
                        break;
                    case Main.Dungeon.Z_BB6:
                        ChallengeField.sprite = main.ChallengeSpriteAry[73];
                        break;
                    case Main.Dungeon.Z_BB7:
                        ChallengeField.sprite = main.ChallengeSpriteAry[73];
                        break;
                    case Main.Dungeon.Z_BB8:
                        ChallengeField.sprite = main.ChallengeSpriteAry[73];
                        break;
                    case Main.Dungeon.Z_BBD:
                        ChallengeField.sprite = main.ChallengeSpriteAry[73];
                        break;

                    default:
                        if (ChiliRandomNum < 1000)
                            ChallengeField.sprite = main.ChallengeSpriteAry[7];
                        else
                            ChallengeField.sprite = main.ChallengeSpriteAry[1];
                        isFieldEffect = false;
                        break;
                }
        }
        else if (battleMode == BattleMode.challange)
        {
            setActive(ChallengeField.gameObject);
            ChallengeFieldAbove.color = black;
            switch (main.QuestId)
            {
                case QuestCtrl.QuestId.golem:
                    ChallengeField.sprite = main.ChallengeSpriteAry[33];
                    break;
                case QuestCtrl.QuestId.spider:
                    ChallengeField.sprite = main.ChallengeSpriteAry[34];
                    break;
                case QuestCtrl.QuestId.fairy:
                    ChallengeField.sprite = main.ChallengeSpriteAry[35];
                    break;
                case QuestCtrl.QuestId.banana:
                    ChallengeField.sprite = main.ChallengeSpriteAry[36];
                    break;
                case QuestCtrl.QuestId.octan:
                    ChallengeField.sprite = main.ChallengeSpriteAry[67];
                    break;
                case QuestCtrl.QuestId.montblango:
                    if(!C_montblango.isCute)
                        ChallengeField.sprite = main.ChallengeSpriteAry[71];
                    else
                        ChallengeField.sprite = main.ChallengeSpriteAry[72];
                    break;
                default:
                    ChallengeField.sprite = main.ChallengeSpriteAry[0];
                    break;
            }

        }

    }


    void Update () {
        //isPanel中はトグルを操作できないようにする．
        if (main.DeathPanel.isPanel)
        {
            main.toggles[1].interactable = false;
        }
        else
        {
            main.toggles[1].interactable = true;
        }

        if (main.DeathPanel.isDead)
        {
            main.ally1.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            main.ally1.GetComponent<BoxCollider2D>().enabled = true;
        }

        //if (battleMode == BattleMode.normal) {
        //    ChallengeFieldAbove.color = trans;
        //    setFalse(main.GameController.ChallengeField.gameObject);
        //    //switch (currentVillage)
        //    //{
        //    //    case Main.Village.slime:
        //    //        main.slimeVillage.StageControl(0);
        //    //        isFieldEffect = false;
        //    //        break;

        //    //    case Main.Village.bat:
        //    //        main.batVillage.StageControl(8);
        //    //        isFieldEffect = false;
        //    //        break;
        //    //    case Main.Village.ball:
        //    //        main.ballVillage.StageControl(16);
        //    //        isFieldEffect = false;
        //    //        break;
        //    //    case Main.Village.fish:
        //    //        main.devilfishVillage.StageControl(24);
        //    //        isFieldEffect = true;
        //    //        break;
        //    //    case Main.Village.fox:
        //    //        main.foxVillage.StageControl(32);
        //    //        isFieldEffect = false;
        //    //        break;
        //    //    default:
        //    //        isFieldEffect = false;
        //    //        break;
        //    //}
        //}
        //else if(battleMode == BattleMode.dungeon)
        //{
        //    switch (currentDungeon)
        //    {
        //        case Main.Dungeon.slimeHideout:
        //            //setActive(ChallengeField.gameObject);
        //            //ChallengeFieldAbove.color = black;
        //            ChallengeField.sprite = main.ChallengeSpriteAry[8];
        //            isFieldEffect = false;
        //            break;
        //        case Main.Dungeon.Z_slimeVillage:
        //            //setActive(ChallengeField.gameObject);
        //            //ChallengeFieldAbove.color = black;
        //            ChallengeField.sprite = main.ChallengeSpriteAry[9];
        //            isFieldEffect = false;
        //            break;
        //        case Main.Dungeon.Z_slimePlains:
        //            //setActive(ChallengeField.gameObject);
        //            //ChallengeFieldAbove.color = black;
        //            ChallengeField.sprite = main.ChallengeSpriteAry[10];
        //            isFieldEffect = false;
        //            break;
        //        case Main.Dungeon.Z_slimePits:
        //            //setActive(ChallengeField.gameObject);
        //            //ChallengeFieldAbove.color = black;
        //            if (ChiliRandomNum< 1000)
        //                ChallengeField.sprite = main.ChallengeSpriteAry[7];
        //            else
        //                ChallengeField.sprite = main.ChallengeSpriteAry[1];
        //            isFieldEffect = false;
        //            break;
        //        case Main.Dungeon.Z_slimePools:
        //            //setActive(ChallengeField.gameObject);
        //            //ChallengeFieldAbove.color = black;
        //            ChallengeField.sprite = main.ChallengeSpriteAry[11];
        //            isFieldEffect = false;
        //            break;
        //        case Main.Dungeon.Z_slimeForest:
        //            //setActive(ChallengeField.gameObject);
        //            //ChallengeFieldAbove.color = black;
        //            ChallengeField.sprite = main.ChallengeSpriteAry[12];
        //            isFieldEffect = false;
        //            break;
        //        case Main.Dungeon.Z_slimeCastle:
        //            //setActive(ChallengeField.gameObject);
        //            //ChallengeFieldAbove.color = black;
        //            ChallengeField.sprite = main.ChallengeSpriteAry[13];
        //            isFieldEffect = false;
        //            break;
        //        case Main.Dungeon.Z_slimeThroneRoom:
        //            //setActive(ChallengeField.gameObject);
        //            //ChallengeFieldAbove.color = black;
        //            ChallengeField.sprite = main.ChallengeSpriteAry[14];
        //            isFieldEffect = false;
        //            break;
        //        //Bat
        //        case Main.Dungeon.Z_batDarkForest:
        //            //setActive(ChallengeField.gameObject);
        //            //ChallengeFieldAbove.color = black;
        //            ChallengeField.sprite = main.ChallengeSpriteAry[15];
        //            isFieldEffect = false;
        //            break;
        //        case Main.Dungeon.Z_batCaveInTheWoods:
        //            //setActive(ChallengeField.gameObject);
        //            //ChallengeFieldAbove.color = black;
        //            ChallengeField.sprite = main.ChallengeSpriteAry[16];
        //            isFieldEffect = false;
        //            break;
        //        case Main.Dungeon.Z_batRuinedTemple:
        //            //setActive(ChallengeField.gameObject);
        //            //ChallengeFieldAbove.color = black;
        //            ChallengeField.sprite = main.ChallengeSpriteAry[19];
        //            isFieldEffect = false;
        //            break;
        //        case Main.Dungeon.Z_batTempleAntechamber:
        //            //setActive(ChallengeField.gameObject);
        //            //ChallengeFieldAbove.color = black;
        //            ChallengeField.sprite = main.ChallengeSpriteAry[20];
        //            isFieldEffect = false;
        //            break;
        //        case Main.Dungeon.Z_batCollapsedSanctuary:
        //            //setActive(ChallengeField.gameObject);
        //            //ChallengeFieldAbove.color = black;
        //            ChallengeField.sprite = main.ChallengeSpriteAry[17];
        //            isFieldEffect = false;
        //            break;
        //        case Main.Dungeon.Z_batUnderTemple:
        //            //setActive(ChallengeField.gameObject);
        //            //ChallengeFieldAbove.color = black;
        //            ChallengeField.sprite = main.ChallengeSpriteAry[21];
        //            isFieldEffect = false;
        //            break;
        //        case Main.Dungeon.Z_batBreedingGrounds:
        //            //setActive(ChallengeField.gameObject);
        //            //ChallengeFieldAbove.color = black;
        //            ChallengeField.sprite = main.ChallengeSpriteAry[18];
        //            isFieldEffect = false;
        //            break;
        //        case Main.Dungeon.Z_batBlackCorridor:
        //            //setActive(ChallengeField.gameObject);
        //            //ChallengeFieldAbove.color = black;
        //            ChallengeField.sprite = main.ChallengeSpriteAry[22];
        //            isFieldEffect = false;
        //            break;
        //        case Main.Dungeon.Z_batD:
        //            //setActive(ChallengeField.gameObject);
        //            //ChallengeFieldAbove.color = black;
        //            ChallengeField.sprite = main.ChallengeSpriteAry[23];
        //            isFieldEffect = false;
        //            break;

        //        //case Main.Dungeon.batCave:
        //        //    setActive(ChallengeField.gameObject);
        //        //    ChallengeFieldAbove.color = black;
        //        //    ChallengeField.sprite = main.ChallengeSpriteAry[2];
        //        //    isFieldEffect = false;
        //        //    break;
        //        //case Main.Dungeon.sacredFairyCave:
        //        //    setActive(ChallengeField.gameObject);
        //        //    ChallengeFieldAbove.color = black;
        //        //    if (main.dungeonAry[2].dungeonFloorNum <= 9)
        //        //    {
        //        //        if (ChiliRandomNum < 1000)
        //        //            ChallengeField.sprite = main.ChallengeSpriteAry[7];
        //        //        else
        //        //            ChallengeField.sprite = main.ChallengeSpriteAry[1];
        //        //    }
        //        //    else
        //        //    {
        //        //        ChallengeField.sprite = main.ChallengeSpriteAry[3];
        //        //    }
        //        //    isFieldEffect = false;
        //        //    break;
        //        //case Main.Dungeon.spiderRuin:
        //        //    setActive(ChallengeField.gameObject);
        //        //    ChallengeFieldAbove.color = black;
        //        //    ChallengeField.sprite = main.ChallengeSpriteAry[2];
        //        //    isFieldEffect = false;
        //        //    break;
        //        //case Main.Dungeon.foxHome:
        //        //    setActive(ChallengeField.gameObject);
        //        //    ChallengeFieldAbove.color = black;
        //        //    if (ChiliRandomNum < 1000)
        //        //        ChallengeField.sprite = main.ChallengeSpriteAry[7];
        //        //    else
        //        //        ChallengeField.sprite = main.ChallengeSpriteAry[1];
        //        //    isFieldEffect = false;
        //        //    break;
        //        //case Main.Dungeon.slimeSecretBase:
        //        //    setActive(ChallengeField.gameObject);
        //        //    ChallengeFieldAbove.color = black;
        //        //    ChallengeField.GetComponent<Image>().sprite = main.ChallengeSpriteAry[4];
        //        //    isFieldEffect = true;
        //        //    break;
        //        //case Main.Dungeon.deepSeaCave:
        //        //    setActive(ChallengeField.gameObject);
        //        //    ChallengeFieldAbove.color = black;
        //        //    ChallengeField.GetComponent<Image>().sprite = main.ChallengeSpriteAry[5];
        //        //    isFieldEffect = true;
        //        //    break;
        //        //case Main.Dungeon.lavaCave:
        //        //    setActive(ChallengeField.gameObject);
        //        //    ChallengeFieldAbove.color = black;
        //        //    ChallengeField.GetComponent<Image>().sprite = main.ChallengeSpriteAry[6];
        //        //    isFieldEffect = false;
        //        //    break;

        //        //case Main.Dungeon.Z_slimeSlums:
        //        //    setActive(ChallengeField.gameObject);
        //        //    ChallengeFieldAbove.color = black;
        //        //    ChallengeField.GetComponent<Image>().sprite = main.ZoneCtrl.SlimeZone[0];
        //        //    isFieldEffect = false;
        //        //    break;
        //        ////case Main.Dungeon.Z_slimeVillage:
        //        ////    setActive(ChallengeField.gameObject);
        //        ////    ChallengeFieldAbove.color = black;
        //        ////    ChallengeField.GetComponent<Image>().sprite = main.ZoneCtrl.SlimeZone[1];
        //        ////    isFieldEffect = false;
        //        ////    break;
        //        default:
        //            //setActive(ChallengeField.gameObject);
        //            //ChallengeFieldAbove.color = black;
        //            if (ChiliRandomNum < 1000)
        //                ChallengeField.sprite = main.ChallengeSpriteAry[7];
        //            else
        //                ChallengeField.sprite = main.ChallengeSpriteAry[1];
        //            isFieldEffect = false;
        //            break;
        //    }
        //}
        //else if (battleMode == BattleMode.challange)
        //{
        //    switch (main.QuestId)
        //    {
        //        default:
        //            //setActive(ChallengeField.gameObject);
        //            //ChallengeFieldAbove.color = black;
        //            ChallengeField.sprite = main.ChallengeSpriteAry[0];
        //            break;
        //    }

        //}

        //////トウガラシが出ているかどうか
        ////if (ChallengeField.sprite == main.ChallengeSpriteAry[7])
        ////    isChili = true;
        ////else
        ////    isChili = false;

    }


    public void Initialize()
    {
        foreach (GameObject game in GameObject.FindGameObjectsWithTag("effect"))
        {
            Destroy(game);
        }
        foreach (GameObject game in GameObject.FindGameObjectsWithTag("enemy"))
        {
            Destroy(game);
        }
        foreach (GameObject game in GameObject.FindGameObjectsWithTag("enemyEffect"))
        {
            Destroy(game);
        }
        foreach (GameObject game in GameObject.FindGameObjectsWithTag("magicCircle"))
        {
            Destroy(game);
        }
        main.ally1.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -150);
        main.ally1.GetComponent<BoxCollider2D>().enabled = true;
        main.DeathPanel.isDead = false;
        main.QuestCtrl.sumiImage.color = new Color(0, 0, 0, 0f);
        main.QuestCtrl.OctBackground.color = new Color(0, 0, 0, 0f);
        //main.DeathPanel.initResult();
        main.ally1.GetComponent<ALLY>().condition = ALLY.Condition.MoveMode;
        isChili = false;
        ChiliRandomNum = UnityEngine.Random.Range(0, 10000);
        ChangeFieldSprite();
    }
    //敵を全滅させたらこれを呼ぶ．
    public void initStage()
    {
        main.DeathPanel.FadeAwayPanel();
        Initialize();
        //maxFloorNum = Math.Max(floorNum, maxFloorNum);
        //maxFloorNum1 = Math.Max(floorNum1, maxFloorNum1);
        //maxFloorNum2 = Math.Max(floorNum2, maxFloorNum2);
        //maxFloorNum3 = Math.Max(floorNum3, maxFloorNum3);
        //maxFloorNum4 = Math.Max(floorNum4, maxFloorNum4);
        //SaveMaxFloorNum = Math.Max(floorNum, SaveMaxFloorNum);
        //SaveMaxFloorNum1 = Math.Max(floorNum1, SaveMaxFloorNum1);
        //SaveMaxFloorNum2 = Math.Max(floorNum2, SaveMaxFloorNum2);
        //SaveMaxFloorNum3 = Math.Max(floorNum3, SaveMaxFloorNum3);
        //SaveMaxFloorNum4 = Math.Max(floorNum4, SaveMaxFloorNum4);

        //switch (currentVillage)
        //{
        //    case Main.Village.slime:
        //        main.slimeVillage.InstantiateEnemies(floorNum);
        //        break;
        //    case Main.Village.bat:
        //        main.batVillage.InstantiateEnemies1(floorNum1);
        //        break;
        //    case Main.Village.ball:
        //        main.ballVillage.InstantiateEnemies2(floorNum2);
        //        break;
        //    case Main.Village.fish:
        //        main.devilfishVillage.InstantiateEnemies3(floorNum3);
        //        break;
        //    case Main.Village.fox:
        //        main.foxVillage.InstantiateEnemies4(floorNum4);
        //        break;
        //    default:
        //        break;
        //}
    }



    public ENEMY InstantiateEnemy(int enemyIndex, Vector3 position, bool isChallange = false, double[] Status = null)
    {
        ENEMY game;
        if (isChallange)
        {
            if (main.cc.CurrentCurseId == CurseId.curse_of_metal)
            {
                game = Instantiate(main.QuestCtrl.BigMetalSlime, position + new Vector3(575, 325), new Quaternion(0, 0, 0, 0), main.Transforms[0]);
            }
            else
            {
                game = Instantiate(main.C_enemies[enemyIndex], position + new Vector3(575, 325), new Quaternion(0, 0, 0, 0), main.Transforms[0]);
            }
        }
        else
        {
            if (main.cc.CurrentCurseId == CurseId.curse_of_metal)
            {
                game = Instantiate(main.enemies[(int)ENEMY.EnemyKind.MetalSlime], position + new Vector3(575, 325), new Quaternion(0, 0, 0, 0), main.Transforms[0]);
            }
            else
            {
                game = Instantiate(main.enemies[enemyIndex], position + new Vector3(575, 325), new Quaternion(0, 0, 0, 0), main.Transforms[0]);
            }
        }
        if (Status != null)
        {
            game.InputStatus = Status;
        }
        game.gameObject.GetComponent<RectTransform>().anchoredPosition = position;//+ new Vector3(575, 325);
        //game.gameObject.GetComponent<RectTransform>().localPosition += new Vector3(0, 0, 6000);
        return game;
    }

    public void InitImageAlpha()
    {
        SetAllImageAndText(SkillTreeCanvas,false);
        SetAllImageAndText(ChallangeCanvas, false);
        SetAllImageAndText(JobchangeCanvas, false);
        SetAllImageAndText(AchievementCanvas, false);
        SetAllImageAndText(ArtifactCanvas, false);
        //AlphaToZero(SkillTreeCanvas);
        //AlphaToZero(ChallangeCanvas);
        //AlphaToZero(JobchangeCanvas);
        //AlphaToZero(AchievementCanvas);
        //AlphaToZero(ArtifactCanvas);
        if (!main.ally1.GetComponent<ALLY>().isDead)
        {
            AlphaToZero(HideIdleCanvas);
        }
        if (isJobbed||main.S.job != ALLY.Job.Novice)
        {
            Destroy(ChooseFirstWeapon);
            if(main.S.job != ALLY.Job.Novice)
            {
                applySkill(main.S.job);
            }
        }
    }
    public void applySkill(ALLY.Job job)
    {
        switch (job)
        {
            case ALLY.Job.Warrior:
                if(main.warriorSkillAry[0].P_level==0)
                    main.warriorSkillAry[0].P_level = 1;
                main.warriorSkillAry[0].canGetExp = true;
                main.skillSlotCanvasAry[0].currentSkill = main.warriorSkillAry[0];
                break;
            case ALLY.Job.Wizard:
                if(main.wizardSkillAry[0].P_level == 0)
                    main.wizardSkillAry[0].P_level = 1;
                main.wizardSkillAry[0].canGetExp = true;
                main.skillSlotCanvasAry[0].currentSkill = main.wizardSkillAry[0];
                break;
            case ALLY.Job.Angel:
                if (main.angelSkillAry[0].P_level == 0)
                    main.angelSkillAry[0].P_level = 1;
                main.angelSkillAry[0].canGetExp = true;
                main.skillSlotCanvasAry[0].currentSkill = main.angelSkillAry[0];
                break;
        }
    }

    public void AlphaToZero(GameObject go)
    {
        foreach (GameObject game in GetAllChildren.GetAllImage(go))
        {
            if (game.HasComponent<Image>())
            {
                game.GetComponent<Image>().color -= new Color(0, 0, 0, 1);
            }
            else
            {
                game.GetComponent<TextMeshProUGUI>().color -= new Color(0, 0, 0, 1);
            }
        }
    }

    public void SetAllImageAndText(GameObject go,bool active)
    {
        if (go == InventoryCanvas)
            return;

        if (!active)
        {
            foreach (GameObject game in GetAllChildren.AllImageAndText(go))
            {

                if (game.HasComponent<Image>()&&!game.HasComponent<Button>())
                {
                    game.GetComponent<Image>().enabled = false;
                }

               //if (game.HasComponent<Button>())
               //{
               //    game.GetComponent<Image>().enabled = false;
               //}

                if (game.HasComponent<TextMeshProUGUI>())
                {
                    game.GetComponent<TextMeshProUGUI>().enabled = false;
                }

            }
        }
        else
        {
            foreach (GameObject game in GetAllChildren.AllImageAndText(go))
            {

                if (game.HasComponent<Image>())
                {
                    game.GetComponent<Image>().enabled = true;
                }

               // if (game.HasComponent<Button>())
               // {
               //     game.GetComponent<Image>().enabled = true;
               // }

                if (game.HasComponent<TextMeshProUGUI>())
                {
                    game.GetComponent<TextMeshProUGUI>().enabled = true;
                }
            }
        }
        Canvas.ForceUpdateCanvases();
    }

    public void UnRayCast()
    {
        foreach (GameObject game in GetAllChildren.GetAllImage(HideIdleCanvas))
        {
            if (game.HasComponent<Image>())
            {
                game.GetComponent<Image>().raycastTarget = false;
            }
            else
            {
                game.GetComponent<TextMeshProUGUI>().raycastTarget = false;
            }
        }
    }

    public void DoRayCast()
    {
        foreach (GameObject game in GetAllChildren.GetAllImage(HideIdleCanvas))
        {
            if (game.HasComponent<Image>())
            {
                game.GetComponent<Image>().raycastTarget = true;
            }
            else
            {
                game.GetComponent<TextMeshProUGUI>().raycastTarget = true;
            }
        }
        NoRaycastImage.GetComponent<Image>().raycastTarget = false;
    }

    public void ActiveObject(GameObject parent)
    {
        foreach(GameObject game in GetAllChildren.GetAllImage(parent))
        {
            StartCoroutine(ActiveObjectCor(game));
        }
    }

    public IEnumerator ActiveObjectCor(GameObject game)
    {
        for (int i = 0; i < 20; i++)
        {
            if(game == null) { continue; }
            if (game.HasComponent<Image>())
            {
                if(game.name == "HideImage")
                {
                    if(game.GetComponent<Image>().color.a >= 0.59)
                    {
                        break;
                    }
                }
                game.GetComponent<Image>().color += new Color(0, 0, 0, 0.05f);
                yield return new WaitForSeconds(0.01f);
            }
            else
            {
                game.GetComponent<TextMeshProUGUI>().color += new Color(0, 0, 0, 0.05f);
                yield return new WaitForSeconds(0.01f);
            }

        }
    }
    public void FalseObject(GameObject parent)
    {
        foreach (GameObject game in GetAllChildren.GetAllImage(parent))
        {
            StartCoroutine(FalseObjectCor(game));
        }
    }
    public IEnumerator FalseObjectCor(GameObject game)
    {
        for (int i = 0; i < 20; i++)
        {
            if (game.HasComponent<Image>())
            {
                game.GetComponent<Image>().color -= new Color(0, 0, 0, 0.05f);
                yield return new WaitForSeconds(0.01f);
            }
            else
            {
                game.GetComponent<TextMeshProUGUI>().color -= new Color(0, 0, 0, 0.05f);
                yield return new WaitForSeconds(0.01f);
            }

        }
    }



    public IEnumerator StageController()
    {
        while (true)
        {
            yield return new WaitUntil(() => battleMode == BattleMode.normal && GameObject.FindGameObjectsWithTag("enemy").Length == 0 && isJobbed);
            switch (currentVillage)
            {
                case Main.Village.slime:
                    floorNum++;
                    break;
                case Main.Village.bat:
                    floorNum1++;
                    break;
                case Main.Village.ball:
                    floorNum2++;
                    break;
                case Main.Village.fish:
                    floorNum3++;
                    break;
                case Main.Village.fox:
                    floorNum4++;
                    break;
                default:
                    break;
            }
            initStage();
            yield return new WaitForSeconds(0.05f);
        }
    }

    public IEnumerator ZoneCor()
    {
        while (true)
        {
            yield return new WaitUntil(() =>
            {
                return main.ally1.GetComponent<ALLY>().currentHp <= 0 &&main.GameController.battleMode == GameController.BattleMode.normal && !main.DeathPanel.isPanel;
            });

            yield return StartCoroutine(ShowDeathPanel());
            //yield return new WaitUntil(()=>main.DeathPanel.isPanel);
        }
    }

    public IEnumerator ShowDeathPanel()
    {
        main.DeathPanel.isPanel = true;
        if (!main.toggles[1].isOn)
        {
            main.DeathPanel.titleText.text = "You died ...";
            yield return main.DeathPanel.ActiveCor(main.deathPanel.gameObject);
            yield return main.DeathPanel.ActiveCor(main.DeathPanel.titleText.gameObject);
            main.DeathPanel.expText.text = "Total Exp Gained " + tDigit(main.DeathPanel.exp);
            yield return main.DeathPanel.ActiveCor(main.DeathPanel.expText.gameObject);
            main.DeathPanel.goldText.text = "Total Gold Gained " + tDigit(main.DeathPanel.gold);
            yield return main.DeathPanel.ActiveCor(main.DeathPanel.goldText.gameObject);
            main.DeathPanel.timeText.text = "Survival time " + DoubleTimeToDate(main.DeathPanel.C_time);
            yield return main.DeathPanel.ActiveCor(main.DeathPanel.timeText.gameObject);
            main.DeathPanel.AddMaterialText();
            for (int i = 0; i < main.DeathPanel.materialTexts.Length; i++)
            {
                StartCoroutine(main.DeathPanel.ActiveCor(main.DeathPanel.materialTexts[i].gameObject));
            }
            yield return new WaitForSeconds(2.0f);
            main.DeathPanel.FadeAwayPanel();
        }
        else
        {
            main.ally.InstantiateTextOnMe("You died!", Color.red);
            yield return new WaitForSeconds(1.0f);
        }
        main.ally.ResetStatus();
        main.DeathPanel.isPanel = false;
        main.dungeonAry[(int)main.GameController.currentDungeon].gameObject.GetComponent<Button>().onClick.Invoke();
    }


    public void doChangeSkillTree()
    {
        StartCoroutine(changeSkillTree());
        if (!main.S.isSkillTreeOpen)
        {
            main.TutorialController.TutorialCanvasAry[1].gameObject.GetComponent<RectTransform>().anchoredPosition += new Vector2(-10000, 0);
            main.S.isSkillTreeOpen = true;
        }
    }
    public void doChangeUpgrade()
    {
        StartCoroutine(changeUpgrade());
    }
    public void doChangeVillage()
    {
        StartCoroutine(changeVillage());
        if (!main.S.isDungeonOpen)
        {
            main.S.isDungeonOpen = true;
        }
    }
    public void doChangeInventory()
    {
        StartCoroutine(changeInventory());
    }
    public void doChangeChallange()
    {
        StartCoroutine(changeChallange());
    }
    public void doChangeJobchange()
    {
        StartCoroutine(changeJobchange());
    }
    public void doChangeAchievement()
    {
        if (!main.S.isOpenedQuest)
            main.S.isOpenedQuest = true;
        StartCoroutine(changeAchievement());
    }
    public void doChangeArtifact()
    {
        StartCoroutine(changeArtifact());
    }
    public IEnumerator changeUpgrade()
    {
        if (UpgradeMode != upgrade)
        {
            disableButtons();
            //FalseObject(currentCanvas);
            //yield return new WaitForSeconds(0.4f);
            SetAllImageAndText(currentCanvas, false);
            yield return null;
            currentCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(-400, 0);
            IdleCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(400, 0);
            //ActiveObject(IdleCanvas);
            SetAllImageAndText(IdleCanvas, true);
            ableButtons();
            UpgradeMode = upgrade;
          // if (main.idleBackGround.isDarkRitual)
          // {
          //     main.DRctrl.UpgradeToDarkRitual.onClick.Invoke();
          // }
          // if (main.idleBackGround.isBank)
          // {
          //     main.bankCtrl.Open();
          // }
            currentCanvas = IdleCanvas;

        }
        else
        {

        }
    }
    public IEnumerator changeSkillTree()
    {
        if(UpgradeMode!= skillTree)
        {
            //現在の職業のボタンを押しておく．
            switch (main.ally1.GetComponent<ALLY>().job)
            {
                case ALLY.Job.Warrior:
                    if (main.SR.isReinClassSprite)
                        main.skillTreeButtons[3].onClick.Invoke();
                    else
                        main.skillTreeButtons[0].onClick.Invoke();
                    break;
                case ALLY.Job.Wizard:
                    if (main.SR.isReinClassSprite)
                        main.skillTreeButtons[4].onClick.Invoke();
                    else
                        main.skillTreeButtons[1].onClick.Invoke();
                    break;
                case ALLY.Job.Angel:
                    if (main.SR.isReinClassSprite)
                        main.skillTreeButtons[5].onClick.Invoke();
                    else
                        main.skillTreeButtons[2].onClick.Invoke();
                    break;
                default:
                    break;
            }
            disableButtons();
            SetAllImageAndText(currentCanvas, false);
            //FalseObject(currentCanvas);
            //yield return new WaitForSeconds(0.4f);
            yield return null;
            currentCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(-400, 0);
            SkillTreeCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(400, 0);
            //ActiveObject(SkillTreeCanvas);
            SetAllImageAndText(SkillTreeCanvas, true);
            //yield return new WaitForSeconds(0.2f);
            ableButtons();
            UpgradeMode = skillTree;
            currentCanvas = SkillTreeCanvas;

        }
    }

    public IEnumerator changeVillage()
    {
        if(UpgradeMode!= village)
        {
            disableButtons();
            //FalseObject(currentCanvas);
            SetAllImageAndText(currentCanvas, false);
            //yield return new WaitForSeconds(0.4f);
            yield return null;
            currentCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(-400, 0);
            VillageCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(400, 0);
            //ActiveObject(VillageCanvas);
            SetAllImageAndText(VillageCanvas, true);
            //yield return new WaitForSeconds(0.2f);
            ableButtons();
            UpgradeMode = village;
            currentCanvas = VillageCanvas;
        }
    }
    public IEnumerator changeInventory()
    {
        if(UpgradeMode!= inventory)
        {
            disableButtons();
            //FalseObject(currentCanvas);
            //yield return new WaitForSeconds(0.4f);
            SetAllImageAndText(currentCanvas, false);
            yield return null;
            currentCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(-400, 0);
            InventoryCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(400, 0);
            //ActiveObject(InventoryCanvas);
            SetAllImageAndText(InventoryCanvas, true);
            //yield return new WaitForSeconds(0.2f);
            ableButtons();
            UpgradeMode = inventory;
            currentCanvas = InventoryCanvas;
            //トグルの更新
            for (int i = 0; i < main.toggles.Length; i++)
            {
                //main.toggles[i].isOn = false;
                main.toggles[i].isOn = main.S.toggleSave[i];
            }
        }
    }

    public IEnumerator changeChallange()
    {
        if (UpgradeMode != challange)
        {
            disableButtons();
            //FalseObject(currentCanvas);
            //yield return new WaitForSeconds(0.4f);
            SetAllImageAndText(currentCanvas, false);
            yield return null;
            currentCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(-400, 0);
            ChallangeCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(400, 0);
            //ActiveObject(ChallangeCanvas);
            SetAllImageAndText(ChallangeCanvas, true);
            //yield return new WaitForSeconds(0.2f);
            foreach(QUEST quest in main.QuestCtrl.Quests)
            {
                quest.gameObject.GetComponent<Button>().enabled = false;
                quest.gameObject.GetComponent<Button>().enabled = true;
            }
            ableButtons();
            UpgradeMode = challange;
            currentCanvas = ChallangeCanvas;
        }
    }
    public IEnumerator changeJobchange()
    {
        if (UpgradeMode != jobchange)
        {
            disableButtons();
            //FalseObject(currentCanvas);
            //yield return new WaitForSeconds(0.4f);
            SetAllImageAndText(currentCanvas, false);
            yield return null;
            currentCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(-400, 0);
            JobchangeCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(400, 0);
            //ActiveObject(JobchangeCanvas);
            SetAllImageAndText(JobchangeCanvas, true);
            //yield return new WaitForSeconds(0.2f);
            foreach (A_UPGRADE up in main.Ascends)
            {
                up.gameObject.GetComponent<Button>().enabled = false;
                up.gameObject.GetComponent<Button>().enabled = true;
            }
            ableButtons();
            UpgradeMode = jobchange;
            RPmanager.UpdateMaterialPoint();//MaterialによるSEポイントを計算
            main.rein.ResetAssignment();
            currentCanvas = JobchangeCanvas;
        }
    }

    public IEnumerator changeAchievement()
    {
        if (UpgradeMode != achievement)
        {
            disableButtons();
            //FalseObject(currentCanvas);
            SetAllImageAndText(currentCanvas, false);
            //yield return new WaitForSeconds(0.4f);
            yield return null;
            currentCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(-400, 0);
            AchievementCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(400, 0);
            //ActiveObject(AchievementCanvas);
            SetAllImageAndText(AchievementCanvas, true);
            //yield return new WaitForSeconds(0.2f);
            foreach(ACHIEVEMENT quest in main.quests)
            {
                if (quest == null)
                    continue;
                quest.GetComponentInChildren<Button>().enabled = false;
                quest.GetComponentInChildren<Button>().enabled = true;
            }

            foreach (Q_UPGRADE up in main.questUpgrades)
            {
                up.GetComponent<Button>().enabled = false;
                up.GetComponent<Button>().enabled = true;
            }
            ableButtons();
            UpgradeMode = achievement;
            currentCanvas = AchievementCanvas;
            main.expeditionCtrl.UpdateUnleashExpedition();
        }
    }

    public IEnumerator changeArtifact()
    {
        if (UpgradeMode != artifact)
        {
            disableButtons();
            //FalseObject(currentCanvas);
            //yield return new WaitForSeconds(0.4f);
            SetAllImageAndText(currentCanvas, false);
            yield return null;
            currentCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(-400, 0);
            ArtifactCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(400, 0);
            //ActiveObject(ArtifactCanvas);
            SetAllImageAndText(ArtifactCanvas, true);
            //yield return new WaitForSeconds(0.2f);
            foreach(ARTIFACT arti in main.NewArtifacts)
            {
                arti.GetComponentInChildren<Button>().enabled = false;
                arti.GetComponentInChildren<Button>().enabled = true;
            }
            ableButtons();
            UpgradeMode = artifact;
            RPmanager.UpdateMaterialPoint();//MaterialによるSEポイントを計算
            currentCanvas = ArtifactCanvas;
        }
    }
    public void disableButtons()
    {
        main.buttons[0].interactable = false;
        main.buttons[1].interactable = false;
        main.buttons[3].interactable = false;
        main.buttons[4].interactable = false;
        main.buttons[6].interactable = false;
        main.buttons[7].interactable = false;
        main.buttons[8].interactable = false;
        main.buttons[9].interactable = false;
    }
    public void ableButtons()
    {
        main.buttons[0].interactable = true;
        main.buttons[1].interactable = true;
        main.buttons[3].interactable = true;
        main.buttons[4].interactable = true;
        main.buttons[6].interactable = true;
        main.buttons[7].interactable = true;
        main.buttons[8].interactable = true;
        main.buttons[9].interactable = true;
    }

}
