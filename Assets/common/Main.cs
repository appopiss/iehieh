using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UsefulMethod;
using Sirenix.Serialization;
using Sirenix.OdinInspector;

public enum Platform
{
    kong,
    armor,
    kartridge,
    steam,
    crazygames,
}
public class Main : SerializedMonoBehaviour
{
    public double allTime { get => S.allTime; set => S.allTime = value; }
    public double realAllTime { get => S.realAllTime; set => S.realAllTime = value; }
    public double rebirthTime { get => SR.rebirthTime; set => SR.rebirthTime = value; }
    public double realRebirthTime { get => SR.realRebirthTime; set => SR.realRebirthTime = value; }
    public Platform platform;
    public DateTime birthTime
    {
        get { return DateTime.FromBinary(Convert.ToInt64(S.birthDate)); }
        set { S.birthDate = value.ToBinary().ToString(); }
    }
    [NonSerialized]
    public DateTime ReleaseTime = DateTime.Parse("4/11/2020 8:00:00 PM");
    public DateTime lastTime//最後にプレイした時間。
    {
        get { return DateTime.FromBinary(Convert.ToInt64(S.lastTime)); }
        set { S.lastTime = value.ToBinary().ToString(); }
    }
    [Range(0.05f, 10.0f)]
    public float tick = 1.0f;
    public IdleActionCtrl idleActionCtrl;

    [SerializeField]
    public SaveR SR;
    [SerializeField]
    public Save S;
    [OdinSerialize, NonSerialized] public SaveO SO;
    [SerializeField]
    public saveRein ST;

    public Canvas screenCanvas;
    public Canvas mainCanvas;
    public GameObject LinkCanvas;
    public GameObject openAdsButton;
    public Canvas BonusCanvas;
    //EpicShop
    public EpicShop epicShop;

    public saveWar saveWar;
    public saveWiz saveWiz;
    public saveAng saveAng;

    public SaveDeclare SD;
    public saveCtrl saveCtrl;
    public Transform WindowShowCanvas;
    public Transform FirstConfirmCanvas;
    public Transform LogShowCanvas;
    public Transform DeathShowCanvas;

    public Image Field;
    public ABNORMAL[] StatusIcons;
    public POPTEXT_Passive[] StanceIcons;
    public Sprite[] StatusSprite;
    public Transform StatusIconCanvas;
    public Transform StanceIconCanvas;
    public AudioSource SoundEffectSource;
    public Sound sound;
    public TutorialController TutorialController;
    public GameController GameController;
    public SystemController systemController;
    public AlchemyCtrl alchemyController;
    public GameObject plainPopText;
    public GameObject QplainPopText;
    public GameObject CurrentSkillTree;
    public GameObject[] animationObject;
    public GameObject DestroyEnemy;
    public Transform[] Transforms;
    public Button[] buttons;
    public Button[] jobChangeButtons;
    public QueueController queueController;
    public SkillProgress skillprogress;
    public CraftCtrl craftCtrl;

    public TextMeshProUGUI[] MyStatusTexts;
    public TextMeshProUGUI[] ResourseTexts;
    public TextMeshProUGUI[] Texts;
    public Button[] jobButton;
    public GameObject[] objects;
    public GameObject[] P_texts;
    public Toggle[] toggles;
    public A_UPGRADE[] Ascends;
    public R_UPGRADE[] R_upgrades;
    public R_UPGRADE[] SR_upgrades;
    public Transform[] JobchangeCanvas;
    public Ally_avater avaterPre;
    public GameObject allyCanvas;
    public A_SKILL[] activeSkills;

    //public TimeManager timeManager;
    /* Libraryここまで */

    public GameObject ally1;
    public ALLY ally;
    public ENEMY[] enemies;
    public ENEMY[] C_enemies;

    //Zone
    public Sprite[] ZoneSpritesAry;
    public Button[] zoneAry;
    public SlimeVillage slimeVillage;
    public BatVillage batVillage;
    public BallVillage ballVillage;
    public DevilFishVillage devilfishVillage;
    public FoxVillage foxVillage;

    //Dungeon
    public DUNGEON[] dungeonAry;

    //SKILL
    public SKILL[] warriorSkillAry;
    public Image[] warriorSkillBranchAry;
    public SKILL[] wizardSkillAry;
    public SKILL[] angelSkillAry;
    //public Sprite canEquipSprite;
    public Sprite canNotEquipSprite;


    //ステージ背景切り替え
    public Sprite[] StageSpriteAry;
    public GameObject[] StageChangeButtonAry;
    public Sprite[] ChallengeSpriteAry;

    //Block
    public bool isBlock;

    public SkillSetController skillSetController;
    public SKILLSET[] skillSlotCanvasAry;
    public Sprite SkillSlotEmptyImage;
    public GameObject[] TreeSprites;

    public Sprite[] Sprites;
    public Sprite[] BuffSpriteAry;


    //FixedStatus
    public Image JobImage;
    public Sprite[] JobSprites;

    //UPGRADE
    public Sprite[] UpStoneSpriteAry;
    public Sprite[] UpCrystalSpriteAry;
    public Sprite[] UpLeafSpriteAry;
    public Sprite[] UpStatusSpriteAry;
    public M_UPGRADE[] StoneUpgrade;
    public M_UPGRADE[] CristalUpgrade;
    public M_UPGRADE[] LeafUpgrade;
    public M_UPGRADE[] StatusUpgrade;
    //public UPGRADE[] OtherUpgrades;
    public QuestCtrl.QuestId QuestId;
    public QuestCtrl QuestCtrl;
    public ENEMY.EnemyKind EnemyKind;
    //public QUEST[] quests;

    public GameObject[] prefabAry_H;
    public GameObject[] SkillTreeCanvas;
    public SKILL[] skillsForCoolTime;
    public GameObject logText;

    public GameObject DungeonBar;
    public Slider GoldSlider;
    public Slider HPSlider;
    public Slider BossHpSlider;
    public Slider MPSlider;
    public Slider ExpSlider;

    public GameObject[] Particles;
    public IdleBackGround idleBackGround;

    public Image deathPanel;
    public ArtiCtrl ArtiCtrl;
    public POP_material[] pOP_Materials;
    public ARTIFACT[] artifacts;
    public ACHIEVEMENT[] achievements;
    public ArtifactFactor ArtifactFactor;
    public DeathPanel DeathPanel;
    public AnimationClip MoveClip;
    public Button[] skillTreeButtons;
    public JobChange jobChange;
    public GameObject mouseObject;
    public Button[] A_rankButton;
    public GameObject[] ArtifactCanvas;
    //public MATERIAL[] materials;
    public MouseEvent mouseEvent;
    public RectTransform AS_warrior, AS_wizard, AS_angel;
    public NewUPGRADE[] Nstones;
    public NewUPGRADE[] Ncristals;
    public NewUPGRADE[] Nleafs;
    public DRctrl DRctrl;
    public JEM[] jems;
    public GameObject targetImage;
    public GameObject EmptyObject;
    public Slider mpSlider;
    public SkillList skillList;
    public ARTIFACT[] NewArtifacts;
    public TextMeshProUGUI EffectText;
    public AchievementController A_ctrl;
    public Q_UPGRADE[] questUpgrades;
    public ACHIEVEMENT[] quests;
    public SlimeSet slimeSet;
    public ZoneCtrl ZoneCtrl;
    public BESTIARY bestiary;
    public DropInfo dropInfo;
    public BankCtrl bankCtrl;
    public StatsBreakdown stats;
    public GameObject Capture;
    public MissionCondition missionCondition;
    public TitleCtrl titleCtrl;
    public Transform QuestCanvas;
    public Transform RepeatableCanvas;
    public Transform ClearedCanvas;
    public KeyItemCtrl keyItemCtrl;
    public KeyItemFactor keyf;
    public MissionMileStone MissionMileStone;
    public MissionMileStoneHidden MissionMileStoneHidden;
    public long WarP { get => S.WarP; set => S.WarP = value; }
    public long WizP { get => S.WizP; set => S.WizP = value; }
    public long AngP { get => S.AngP; set => S.AngP = value; }
    public long tempWarP;
    public long tempWizP;
    public long tempAngP;
    public long tempRP;
    public long tempSRP;
    public NitroCharger NitroCharger;
    public REIN rein;
    public RPmanager RPmanager;
    [NonSerialized]
    public bool montblangoIsBig;
    public CAPTURE capture;
    public CurseCtrl cc;
    public INFO_bank INFO_bank = new INFO_bank();
    public LocalizeInitialize local;
    public IEBBonusController iebCtrl;
    public ExpeditionController expeditionCtrl;
    public MaterialNumber[] materials;
    public Inventory inventory_mono;

    public bool[] isDropped = new bool[25];//単位時間あたり何個もドロップさせないためのブール

    public IEnumerator LimitDrop()
    {
        while (true)
        {
            for (int i = 0; i < isDropped.Length; i++)
            {
                isDropped[i] = false;
            }
            yield return new WaitForSeconds(2f/Math.Max(Time.timeScale,1));
        }
    }

    private void Awake()
    {
        BASE.main = this;
        S.isNewReleasedIEH = true;
        //初めてのプレイだったら現在の値を代入
        if (!S.isContinuePlay)
        {
            birthTime = DateTime.Now;
            lastTime = DateTime.Now;
            S.isContinuePlay = true;
            S.lastAdsWatchTime = -30 * 60;
        }
        //不正な時間が入っていたら現在の値を代入
        if (lastTime < ReleaseTime || lastTime > DateTime.Now)
        {
            lastTime = DateTime.Now;
        }
        //Instantiate(cc.ConfirmWindow, WindowShowCanvas);
        //Debug用
        /*
        ally.saveLevel = 1000;
        foreach(DUNGEON dungeon in dungeonAry)
        {
            dungeon.isDungeon = true;
        }
        for (int i = 0; i < SR.isDungeon.Length; i++)
        {
            SR.isDungeon[i] = true;
        }
        foreach(QUEST quest in QuestCtrl.Quests)
        {
            quest.isCleared = true;
        }
        S.isDistortionBeated = true;
        S.unleashBank = true;
        */
        materials = new MaterialNumber[Enum.GetNames(typeof(ArtiCtrl.MaterialList)).Length];
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i] = new MaterialNumber((ArtiCtrl.MaterialList)i);
        }
    }
    /*
     enum
     */
    public enum Village
    {
        slime,
        bat,
        ball,
        fish,
        fox,
    }
    public enum Dungeon
    {
        slimeHideout = 0,
        batCave = 1,
        sacredFairyCave = 2,
        spiderRuin = 3,
        foxHome = 4,
        slimeSecretBase = 5,
        deepSeaCave = 6,
        lavaCave = 7,
        Z_slimeSlums = 8,
        Z_slimeVillage = 9,
        Z_slimePlains = 10,
        Z_slimePits = 11,
        Z_slimePools = 12,
        Z_slimeForest = 13,
        Z_slimeCastle = 14,
        Z_slimeThroneRoom = 15,

        Z_slimeD = 32,
        //Bat
        Z_batDarkForest = 16,
        Z_batCaveInTheWoods = 17,
        Z_batRuinedTemple = 18,
        Z_batTempleAntechamber = 19,
        Z_batCollapsedSanctuary = 20,
        Z_batUnderTemple = 21,
        Z_batBreedingGrounds = 22,
        Z_batBlackCorridor = 23,

        Z_batD = 33,
        //Spider
        Z_spider1 = 24,
        Z_spider2 = 25,
        Z_spider3 = 26,
        Z_spider4 = 27,
        Z_spider5 = 28,
        Z_spider6 = 29,
        Z_spider7 = 30,
        Z_spider8 = 31,

        Z_spiderD = 34,
        //Fairy
        Z_fairy1 = 35,
        Z_fairy2 = 36,
        Z_fairy3 = 37,
        Z_fairy4 = 38,
        Z_fairy5 = 39,
        Z_fairy6 = 40,
        Z_fairy7 = 41,
        Z_fairy8 = 42,
        Z_fairyD = 43,

        //Fox5
        Z_fox1 = 44,
        Z_fox2 = 45,
        Z_fox3 = 46,
        Z_fox4 = 47,
        Z_fox5 = 48,
        Z_fox6 = 49,
        Z_fox7 = 50,
        Z_fox8 = 51,
        Z_foxD = 52,
        //MagicSlime6
        Z_MS1 = 53,
        Z_MS2 = 54,
        Z_MS3 = 55,
        Z_MS4 = 56,
        Z_MS5 = 57,
        Z_MS6 = 58,
        Z_MS7 = 59,
        Z_MS8 = 60,
        Z_MSD = 61,

        //DevilFish7
        Z_DF1 = 62,
        Z_DF2 = 63,
        Z_DF3 = 64,
        Z_DF4 = 65,
        Z_DF5 = 66,
        Z_DF6 = 67,
        Z_DF7 = 68,
        Z_DF8 = 69,
        Z_DFD = 70,

        //Blob8
        Z_BB1 = 71,
        Z_BB2 = 72,
        Z_BB3 = 73,
        Z_BB4 = 74,
        Z_BB5 = 75,
        Z_BB6 = 76,
        Z_BB7 = 77,
        Z_BB8 = 78,
        Z_BBD = 79,
    }
    public enum Debuff
    {
        nothing,
        electricalShock,
        cold,
        freeze,
        atkDown,
        mAtkDown,
        defDown,
        mDefDown,
        poison,
        binding,
        acid,
        knockback

    }
    public enum Buff
    {
        nothing,
        maxHp,
        muscleInflation,
        magicImpact,
        def,
        mDef,
        spd,
        gold,
        prof,
        spicy

    }

    public enum Passive
    {

    }

    public enum CurrentStage
    {
        stage1,
        stage2,
        stage3,
        stage4,
        stage5,
        stage6,
        stage7,
        stage8
    }

    // Start is called before the first frame update
    void Start()
    {
        //ミッションカウントこれはStartに。Awakeはダメ
        StartCoroutine(MissionCountCor());

        StartCoroutine(plusTime());
        StartCoroutine(plusRealTime());
        //アップグレードの方法，初期値
        SR.buyMode = UPGRADE.buyMode.mode1;
        //ドロップ制限
        StartCoroutine(LimitDrop());

        /*
        //統計
        StartCoroutine(StatsTotalEnemyKill());


        //補填・配布等
        if (!S.isDistributedResetRebirth)
        {
            S.ResetRebirthUpgradeNum += 1;
            S.boughtResetRebirth = true;
            S.isDistributedResetRebirth = true;
        }
        if (!S.isAfterVer1100)
            RestoreMissionEC();
        */
    }
    /*
    IEnumerator StatsTotalEnemyKill()
    {
        while (true)
        {
            Application.ExternalCall("kongregate.stats.submit", "TotalEnemyKilled", S.totalEnemyKilled);
            yield return new WaitForSecondsRealtime(300f);
        }
    }
    */

    public double ExpGainDLCFactor()
    {
        //return Math.Pow(1.5d, Convert.ToInt32(S.isEXPMulti1) + Convert.ToInt32(S.isEXPMulti2));
        if (!TutorialController.isSlimeHideoutClear)
            return 1;
        if (S.dlcStarter || S.dlcGlobal || S.dlcNitro || S.dlcGold || S.isEXPMulti1 || S.isEXPMulti2)
            return Math.Pow(1.5d, Convert.ToInt32(S.dlcStarter) + Convert.ToInt32(S.dlcGlobal) + Convert.ToInt32(S.dlcNitro) + Convert.ToInt32(S.dlcGold) + Convert.ToInt32(S.isEXPMulti1) + Convert.ToInt32(S.isEXPMulti2));
        else
            return 1;
    }
    public double GoldGainDLCFactor()
    {
        //return 1;
        if (S.dlcStarter || S.dlcGold)
            return Math.Pow(2d, Convert.ToInt32(S.dlcGold));
        else
            return 1;
    }
    public double MonsterGoldCapDLCFactor()
    {
        //return 1;
        if (S.dlcGold)
            return Math.Pow(2d, Convert.ToInt32(S.dlcGold));
        else
            return 1;
    }
    public double MonsterGoldCapEpicStoreFactor()
    {
        return S.monsterGoldCapFactor * 1000;
    }


    public int jobNum;

    private void Update()
    {
        switch (ally.job)
        {
            case ALLY.Job.Novice:
                break;
            case ALLY.Job.Warrior:
                jobNum = 0;
                break;
            case ALLY.Job.Wizard:
                jobNum = 10;
                break;
            case ALLY.Job.Angel:
                jobNum = 20;
                break;
            default:
                break;
        }

        if (SR.gold > MaxGold())
        {
            SR.gold = MaxGold();
        }
        if(SR.gold < 0)
        {
            SR.gold = 0;
        }


        if (!toggles[9].isOn)//LIGHT MODEじゃなければ表示
        {
            GoldSlider.value = (float)(SR.gold / MaxGold());

            if (toggles[8].isOn)
            {
                setActive(ResourseTexts[4].transform.GetChild(1).gameObject);
                setFalse(ResourseTexts[4].transform.GetChild(0).gameObject);
                ResourseTexts[4].text = TextEdit(new string[] { tDigit(Math.Min(S.SlimeCoin, bankCtrl.BankCap())), " / ", tDigit(bankCtrl.BankCap()) });
            }
            else
            {
                setActive(ResourseTexts[4].transform.GetChild(0).gameObject);
                setFalse(ResourseTexts[4].transform.GetChild(1).gameObject);
                ResourseTexts[4].text = TextEdit(new string[] { tDigit(Math.Min(SR.gold, MaxGold())), " / ", tDigit(MaxGold()) });
            }
            ResourseTexts[1].text = tDigit(SR.stone);
            ResourseTexts[2].text = tDigit(SR.cristal);
            ResourseTexts[3].text = tDigit(SR.leaf);
            ResourseTexts[0].text = TextEdit(new string[] { tDigit(Math.Min(SR.gold, MaxGold())), " / ", tDigit(MaxGold()) });

        }
        else//LIGHT MODEでの表示
        {
            systemController.texts[2].text 
                = TextEdit(new string[] { "Gold : ", tDigit(Math.Min(SR.gold, MaxGold())), " / ", tDigit(MaxGold()),
                    "\nSlime Coin : ", tDigit(Math.Min(S.SlimeCoin, bankCtrl.BankCap())), " / ", tDigit(bankCtrl.BankCap()),
                    "\nStone : ",tDigit(SR.stone),
                    "\nCrystal : ",tDigit(SR.cristal),
                    "\nLeaf : ",tDigit(SR.leaf)});
        }
        if (GameController.currentCanvas == GameController.VillageCanvas)
            Texts[26].text = TextEdit(new string[] { "EXP Bonus : <color=green>+ ", tDigit(zoneExpBonus(), 1), "%" });

    }

    System.Text.StringBuilder TempText = new System.Text.StringBuilder(100);
    public string TextEdit(string[] texts)
    {
        TempText.Clear();
        for (int i = 0; i < texts.Length; i++)
        {
            TempText.Append(texts[i]);
        }
        return TempText.ToString();
    }

    public double RebirthPointFactor()
    {
        return (1 + rein.R_factor.RebirthPoint());
    }


    //public double dungeonGoldBonus()
    //{
    //    double bonus = 0;
    //    foreach (DUNGEON dungeon in dungeonAry)
    //    {
    //        bonus += dungeon.achievementPercent()/10;
    //    }
    //    return bonus;
    //}
    public double zoneExpBonus()
    {
        double bonus = 0;
        foreach (DUNGEON dungeon in dungeonAry)
        {          
            bonus += dungeon.achievementPercent() / 10;
        }
        return bonus;
    }
    public double MaxGold()
    {
        if (cc.CurrentCurseId == CurseId.curse_of_1000gold)
        {
            return 1000.001;
        }
        return (1000 + GoldCapADD()) * GoldCapMUL();
    }
    public double GoldCapADD()
    {
        return
            SR.stoneGoldLevel * Ascends[0].calculateCurrentValue()
            + SR.crystalGoldLevel * Ascends[5].calculateCurrentValue()
            + SR.leafGoldLevel * Ascends[10].calculateCurrentValue()
            + GoldCapFromQuest() + MissionMileStone.GoldCapBonus()
            + S.GoldCapByKreds
            + rein.R_factor.GoldCap()
            + SumAddDelegate(cc.cf.GoldBonus);
    }
    public double GoldCapFromQuest()
    {
        long QuestFactor = 0;
        foreach (ACHIEVEMENT quest in quests)
        {
            if (quest == null)
                continue;
            QuestFactor += quest.GoldCapBonus;
        }
        return QuestFactor;
    }
    public double GoldCapMUL()
    {

        return (1 + jems[(int)JEM.ID.GoldCapGem].Effect())
            * (1 + rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.Deeper].GetCurrentValue())
            * (1 + MissionMileStoneHidden.GoldCapFactor())
            * (1d + iebCtrl.iebBonuses[(int)IEBBONUS.BonusKind.goldcap]);
    }

    IEnumerator plusTime()
    {
        while (true)
        {
            allTime++;
            rebirthTime++;
            yield return new WaitForSeconds(1.0f);
        }
    }

    IEnumerator plusRealTime()
    {
        while (true)
        {
            realAllTime++;
            realRebirthTime++;
            S.reincarnationTime++;
            yield return new WaitForSecondsRealtime(1.0f);
        }
    }
    public Transform LogCanvas;
    public void Log(string text, float DestroyTime = 1.0f)
    {
        GameObject logText;
        logText = Instantiate(prefabAry_H[3], LogCanvas);
        logText.AddComponent<DestroyLog>().DestroyTime = DestroyTime;
        LocalizeInitialize.SetFont(logText.GetComponent<TextMeshProUGUI>());
        logText.GetComponent<TextMeshProUGUI>().text = text;
    }

    public bool isLogging;
    public IEnumerator InstantiateLogText(string text, Sprite sprite = null)
    {
        GameObject Text;
        yield return new WaitUntil(() => !isLogging);
        isLogging = true;
        Text = Instantiate(prefabAry_H[2], LogShowCanvas);
        LogShowCanvas.gameObject.GetComponentsInChildren<InstantiateAchievementLog>()[0].canLog = true;
        Text.GetComponent<RectTransform>().anchoredPosition = new Vector2(110, 00);
        if (sprite != null)
        {
            Text.transform.GetChild(1).GetComponent<Image>().sprite = sprite;
        }
        Text.GetComponentInChildren<TextMeshProUGUI>().text = text;
        yield break;
    }



    public IEnumerator InstantiateAnimation(GameObject animatedObj, RectTransform transform, double damage=0, double consumeMp = 0, 
        SKILL.DamageKind damageKind = SKILL.DamageKind.physical,Main.Debuff debuff = Debuff.nothing,SKILL skill = null)
    {
        GameObject game;
        game = Instantiate(animatedObj, Transforms[1]);

        switch (damageKind) 
        {
            case SKILL.DamageKind.physical:
                game.GetComponent<Attack>().damage = damage;
                game.GetComponent<Attack>().damageKind = SKILL.DamageKind.physical;
                break;
            case SKILL.DamageKind.magical:
                game.GetComponent<Attack>().mDamage = damage;
                game.GetComponent<Attack>().damageKind = SKILL.DamageKind.magical;
                break;
            case SKILL.DamageKind.divine:
                game.GetComponent<Attack>().critDamage = damage;
                game.GetComponent<Attack>().damageKind = SKILL.DamageKind.divine;
                break;
            default:
                break;
        }
        game.GetComponent<Attack>().thisDebuff = debuff;
        game.GetComponent<RectTransform>().anchoredPosition = transform.anchoredPosition;
        if (consumeMp > 0)
        {
            if (skillprogress.isNoMpChance && UnityEngine.Random.Range(0, 10000) < 2000)
                ally.currentMp -= 0;
            else
                ally.currentMp -= consumeMp;
        }
        yield return new WaitForSeconds(game.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        Destroy(game);
    }


    public IEnumerator InstantiateSubAnimation(GameObject animatedObj, RectTransform transform, double consumeMp = 0)
    {
        GameObject game;
        game = Instantiate(animatedObj, transform);
        game.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        if (consumeMp > 0)
        {
            if (skillprogress.isNoMpChance && UnityEngine.Random.Range(0, 10000) < 2000)
                ally.currentMp -= 0;
            else
                ally.currentMp -= consumeMp;
        }
        yield return new WaitForSeconds(game.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        Destroy(game);

    }

    public IEnumerator FillSlider(Slider slider, float interval)
    {
        setActive(slider.gameObject);
        slider.value = 0;
        for (int i = 0; i < 50; i++)
        {
            slider.value += 1.0f / 50f;
            yield return new WaitForSeconds(interval / 50);
        }
        setFalse(slider.gameObject);
    }

    public int MissionCount;
    public int MissionCountHidden;
    public long[] CurrentMissionCountNum()
    {
        int tempNum = 0;
        long tempEpicCoin = 0;
        foreach (DUNGEON dungeon in dungeonAry)
        {
            if (!dungeon.gameObject.HasComponent<MISSION>())
            {
                continue;
            }

            if (dungeon.isMissionCompleted)
            {
                tempNum++;
                tempEpicCoin += 200;
            }

            foreach (MISSION mission in dungeon.gameObject.GetComponentsInChildren<MISSION>())
            {
                if (mission.isCleared)
                {
                    tempNum++;
                    if (mission.MissionId % 5 == 0 || mission.MissionId % 5 == 1)
                    {
                        tempEpicCoin += 10;
                    }
                    else if (mission.MissionId % 5 == 2 || mission.MissionId % 5 == 3)
                    {
                        tempEpicCoin += 25;
                    }
                    else
                    {
                        tempEpicCoin += 55;
                    }
                }
            }
        }
        return new long[] { tempNum, tempEpicCoin };
    }

    public IEnumerator MissionCountCor()
    {
        while (true)
        {
            if (ZoneCtrl.isHidden)
            {
                S.MissionCountHidden = (int)CurrentMissionCountNum()[0];
                S.ECbyMissionHidden = CurrentMissionCountNum()[1] / 5;
            }
            else
            {
                S.MissionCount = (int)CurrentMissionCountNum()[0];
                S.ECbyMission = CurrentMissionCountNum()[1] / 5;
            }
            MissionCountHidden = S.MissionCountHidden;
            MissionCount = S.MissionCount;

            yield return new WaitForSeconds(1.0f);
        }
    }

    void RestoreMissionEC()
    {
        int tempNum = 0;
        long tempEpicCoin = 0;
        foreach (DUNGEON dungeon in dungeonAry)
        {
            if (!dungeon.gameObject.HasComponent<MISSION>())
            {
                continue;
            }

            if (dungeon.isMissionCompleted)
            {
                tempNum++;
                tempEpicCoin += 200;
            }

            foreach (MISSION mission in dungeon.gameObject.GetComponentsInChildren<MISSION>())
            {
                if (mission.isCleared)
                {
                    tempNum++;
                    if (mission.MissionId % 5 == 0 || mission.MissionId % 5 == 1)
                    {
                        tempEpicCoin += 10;
                    }
                    else if (mission.MissionId % 5 == 2 || mission.MissionId % 5 == 3)
                    {
                        tempEpicCoin += 25;
                    }
                    else
                    {
                        tempEpicCoin += 55;
                    }
                }
            }
        }
        MissionCount = tempNum;
        if (S.ECbyMission > tempEpicCoin / 5)
            S.ECbyRestoredMission = S.ECbyMission - tempEpicCoin / 5;
        S.ECbyMission = tempEpicCoin / 5;
    }

    public long TotalSEfromMission()
    {
        long temp = 0;
        foreach (DUNGEON dungeon in dungeonAry)
        {
            if (!dungeon.gameObject.HasComponent<MISSION>())
            {
                continue;
            }

            if (dungeon.isMissionCompletedAfterReincarnation) 
            {
                temp += 60;
            }

            foreach (MISSION mission in dungeon.gameObject.GetComponentsInChildren<MISSION>())
            {
                int tempNum = 0;
                if (mission.isClearedAfterReincarnation)
                    tempNum = 1;
                else
                    tempNum = 0;

                if (mission.MissionId % 5 == 0 || mission.MissionId % 5 == 1)
                {
                    temp += 10 * tempNum;
                }
                else if (mission.MissionId % 5 == 2 || mission.MissionId % 5 == 3)
                {
                    temp += 20 * tempNum;
                }
                else
                {
                    temp += 30 * tempNum;
                }
            }
        }
        return temp;
    }

    public B_Upgrade this[B_Upgrade.UpgradeId id]
    {
        get => bankCtrl.BankUpgrades[(int)id];
    }

    public R_UPGRADE this[R_UPGRADE.R_upgradeId id]
    {
        get => rein.R_upgrades[(int)id];
    }

    public R_UPGRADE this[R_UPGRADE.SR_upgradeID id]
    {
        get => rein.SR_upgrades[(int)id];
    }

    public ACHIEVEMENT this[ACHIEVEMENT.QuestList id]
    {
        get => quests[(int)id];
    }

    public bool isDevine;
}