using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UsefulMethod;
using static ENEMY.EnemyKind;
using static QuestCtrl.QuestId;

public abstract class DUNGEON : POPTEXT_DG
{

    /*
     timeLimitは，院スペックたー上から設定する．
    */
    
    [System.NonSerialized]
    public bool isTimeOver;
    [System.NonSerialized]
    public bool isWin;

    public float timeLimit;
    //public virtual int clearedNum { get; set; }
    public virtual int maxDungeonFloorNum
    {
        get => main.S.maxDungeonFloorNum[idDungeon];
        set => main.S.maxDungeonFloorNum[idDungeon] = value;
    }
    //
    public Main.Dungeon dungeon;
    [System.NonSerialized]
    public string dungeonName;
    public int dungeonFloorNum;
    public int dungeonMaxFloorNum;

    [System.NonSerialized]
    public bool isCoolTime;
    //public DateTime dungeonPlayTime { get => main.SR.dungeonPlayTime[idDungeon]; set => main.SR.dungeonPlayTime[idDungeon] = value; }
    public virtual double dungeonPlayTime
    {
        get { return main.SR.dungeonPlayTime[idDungeon]; }
        set { main.SR.dungeonPlayTime[idDungeon] = value; }
    }

    [System.NonSerialized]
    public Button button;
    public int idDungeon;
    public bool isDungeon { get => main.SR.isDungeon[idDungeon]; set => main.SR.isDungeon[idDungeon] = value; }
    public int dungeonClearNum { get => main.S.dungeonClearNum[idDungeon + 100 * Convert.ToInt32(main.ZoneCtrl.isHidden)]; set => main.S.dungeonClearNum[idDungeon + 100 * Convert.ToInt32(main.ZoneCtrl.isHidden)] = value; }
    public int dungeonClearNumForMission { get => main.S.dungeonClearNumForMission[idDungeon + 100 * Convert.ToInt32(main.ZoneCtrl.isHidden)]; set => main.S.dungeonClearNumForMission[idDungeon + 100 * Convert.ToInt32(main.ZoneCtrl.isHidden)] = value; }
    public bool isMissionCompleted { get => main.S.isMissionCompleted[idDungeon + 100 * Convert.ToInt32(main.ZoneCtrl.isHidden)]; set => main.S.isMissionCompleted[idDungeon + 100 * Convert.ToInt32(main.ZoneCtrl.isHidden)] = value; }
    public bool isMissionCompletedAfterReincarnation { get => main.S.isMissionCompletedAfterReincarnation[idDungeon + 100 * Convert.ToInt32(main.ZoneCtrl.isHidden)];
        set => main.S.isMissionCompletedAfterReincarnation[idDungeon + 100 * Convert.ToInt32(main.ZoneCtrl.isHidden)] = value; }
    public double spendTime { get => main.S.D_spendTime[idDungeon + 100 * Convert.ToInt32(main.ZoneCtrl.isHidden)]; set => main.S.D_spendTime[idDungeon + 100 * Convert.ToInt32(main.ZoneCtrl.isHidden)] = value; }
    float clearTime;
    Coroutine StageCoroutine;
    Coroutine DungeonCoroutine;
    public Coroutine calculateSpendTimeCor;
    //タイム表示用とタイムミッション用
    public double startTime;
    //ミッションで使う変数だよ
    public static bool isAttacked;
    public static bool isAttackedByMag;
    public static bool isAttackedByPhy;
    public static bool isOnlyBase;
    public static int hitCount;
    public static bool isNoEQ;
    //マテリアル
    public static ArtiCtrl.MaterialList targetMaterial;
    public static long targetMaterialNum;
    public static M_material materialTempMission;
    //キャプチャ
    public static ENEMY.EnemyKind targetEnemy;
    public static long targetCapturedNum;
    public static M_capture captureTempMission;
    public static float thisClearTime;
    IPoint DPGetter;
    //チャレンジでも呼ぼうね
    public static void InitializeMission()
    {
        isAttacked = false;
        isAttackedByMag = false;
        isAttackedByPhy = false;
        targetMaterial = ArtiCtrl.MaterialList.nothing;
        targetMaterialNum = 0;
        materialTempMission = null;
        targetEnemy = ENEMY.EnemyKind.Deathpider;
        targetCapturedNum = 0;
        captureTempMission = null;
        isOnlyBase = true;
        isNoEQ = true;
        hitCount = 0;
        thisClearTime = 999999;
    }
    public float CurrentExpBonus()
    {
        if (main.GameController.battleMode == GameController.BattleMode.challange)
            return 0;

        if (dungeonClearNum >= 10000000)
        {
            return 0;
        }
        else if (dungeonClearNum >= GetMasteryNum(10))
        {
            return GetMasteryExp(11);
        }
        else if (dungeonClearNum >= GetMasteryNum(9))
        {
            return GetMasteryExp(10);
        }
        else if (dungeonClearNum >= GetMasteryNum(8))
        {
            return GetMasteryExp(9);
        }
        else if (dungeonClearNum >= GetMasteryNum(7))
        {
            return GetMasteryExp(8);
        }
        else if (dungeonClearNum >= GetMasteryNum(6))
        {
            return GetMasteryExp(7);
        }
        else if (dungeonClearNum >= GetMasteryNum(5))
        {
            return GetMasteryExp(6);
        }
        else if (dungeonClearNum >= GetMasteryNum(4))
        {
            return GetMasteryExp(5);
        }
        else if (dungeonClearNum >= GetMasteryNum(3))
        {
            return GetMasteryExp(4);
        }
        else if (dungeonClearNum >= GetMasteryNum(2))
        {
            return GetMasteryExp(3);
        }
        else if (dungeonClearNum >= GetMasteryNum(1))
        {
            return GetMasteryExp(2);
        }
        else if (dungeonClearNum >= GetMasteryNum(0))
        {
            return GetMasteryExp(1);
        }
        else
        {
            return GetMasteryExp(0);
        }
    }
    public float CurrentDropChanceBonus()
    {
        if (main.GameController.battleMode == GameController.BattleMode.challange)
            return 0;

        if (coolTime == 0)
            return CurrentExpBonus()/10;
        else
            return CurrentExpBonus();
    }
    public float CurrentMoveSpeedBonus()
    {
        if (main.GameController.battleMode == GameController.BattleMode.challange)
            return 0;

        if (dungeonClearNum >= GetMasteryNum(8))
        {
            return GetMasterySpeed(9);
        }
        else if (dungeonClearNum >= GetMasteryNum(7))
        {
            return GetMasterySpeed(8);
        }
        else if (dungeonClearNum >= GetMasteryNum(6))
        {
            return GetMasterySpeed(7);
        }
        else if (dungeonClearNum >= GetMasteryNum(5))
        {
            return GetMasterySpeed(6);
        }
        else if (dungeonClearNum >= GetMasteryNum(4))
        {
            return GetMasterySpeed(5);
        }
        else if (dungeonClearNum >= GetMasteryNum(3))
        {
            return GetMasterySpeed(4);
        }
        else if (dungeonClearNum >= GetMasteryNum(2))
        {
            return GetMasterySpeed(3);
        }
        else if (dungeonClearNum >= GetMasteryNum(1))
        {
            return GetMasterySpeed(2);
        }
        else if (dungeonClearNum >= GetMasteryNum(0))
        {
            return GetMasterySpeed(1);
        }
        else
        {
            return GetMasterySpeed(0);
        }
    }
    public int NextBonusNum()
    {
        if (dungeonClearNum >= 10000000)
        {
            return 0;
        }
        else if (dungeonClearNum >= GetMasteryNum(10))
        {
            return GetMasteryNum(11);
        }
        else if (dungeonClearNum >= GetMasteryNum(9))
        {
            return GetMasteryNum(10);
        }
        else if (dungeonClearNum >= GetMasteryNum(8))
        {
            return GetMasteryNum(9);
        }
        else if (dungeonClearNum >= GetMasteryNum(7))
        {
            return GetMasteryNum(8);
        }
        else if (dungeonClearNum >= GetMasteryNum(6))
        {
            return GetMasteryNum(7);
        }
        else if (dungeonClearNum >= GetMasteryNum(5))
        {
            return GetMasteryNum(6);
        }
        else if (dungeonClearNum >= GetMasteryNum(4))
        {
            return GetMasteryNum(5);
        }
        else if (dungeonClearNum >= GetMasteryNum(3))
        {
            return GetMasteryNum(4);
        }
        else if (dungeonClearNum >= GetMasteryNum(2))
        {
            return GetMasteryNum(3);
        }
        else if (dungeonClearNum >= GetMasteryNum(1))
        {
            return GetMasteryNum(2);
        }
        else if (dungeonClearNum >= GetMasteryNum(0))
        {
            return GetMasteryNum(1);
        }
        else
        {
            return GetMasteryNum(0);
        }
    }
    int[] masteryNum = new int[] { 20, 50, 100, 200, 500, 1000, 2000, 5000, 10000, 100000, 1000000,10000000 };
    float[] masterySpeed = new float[] { 0, 0.03f, 0.05f, 0.075f, 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 1.0f, 1.0f, 1.0f, 1.0f };
    float[] masteryExp = new float[] { 0f, 0.1f, 0.15f, 0.2f, 0.25f, 0.3f, 0.4f, 0.5f, 1.0f, 2.0f, 3.0f, 4.0f, 5.0f };

    int GetMasteryNum(int index) => (int)(SumMulDelegate(main.cc.cf.MasteryNumDecay) * masteryNum[index]);
    float GetMasterySpeed(int index) => (float)(SumMulDelegate(main.cc.cf.MasteryEffectMultiplier) * masterySpeed[index]);
    float GetMasteryExp(int index) => (float)(SumMulDelegate(main.cc.cf.MasteryEffectMultiplier) * masteryExp[index]);
    
    public bool isZone;
    public string showIndex;
    public float coolTime;
    string tempNameString;
    public void AwakeDungeon(Main.Dungeon dungeon, string dungeonName, int dungeonMaxFloorNum, int idDungeon, float coolTime = 0, bool isZone = true, string showIndex = "1-1")
    {
        this.dungeon = dungeon;
        this.dungeonName = dungeonName;
        this.dungeonMaxFloorNum = dungeonMaxFloorNum;
        this.idDungeon = idDungeon;
        this.isZone = isZone;
        this.showIndex = showIndex;
        this.coolTime = coolTime;
        DPGetter = new DungeonPoint(this);
        awakeText();
    }
    public TextMeshProUGUI MissionExplainText;
    TextMeshProUGUI areaNumText;
    TextMeshProUGUI EpicCoinNumText;
    Coroutine cor;
    string tempAreaNumString;
    public void StartDungeon()
    {
        startText();
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(PrepareDungeon);
        StartCoroutine(ResetTry(coolTime));
        calculateSpendTimeCor = StartCoroutine(CalculateSpendTime());
        //mission系
        StartCoroutine(UpdateJudge());
        areaNumText = gameObject.GetComponentsInChildren<TextMeshProUGUI>()[1];
        StartCoroutine(indicatorAllClearMission());
        tempAreaNumString = areaNumText.text;
        tempNameString = dungeonName;
        if (main.S.autoRebirthArea == Main.Dungeon.slimeHideout)
            main.S.autoRebirthArea = Main.Dungeon.batCave;
    }
    bool isMissionAllCleared()
    {
        if (gameObject.GetComponentsInChildren<MISSION>().Length == 0)
            return false;

        foreach(MISSION mission in gameObject.GetComponentsInChildren<MISSION>())
        {
            if (!mission.isCleared)
            {
                return false;
            }
        }

        return true;
    }
    bool isRMissionAllCleared()
    {
        if (gameObject.GetComponentsInChildren<MISSION>().Length == 0)
            return false;

        foreach (MISSION mission in gameObject.GetComponentsInChildren<MISSION>())
        {
            if (!mission.isClearedAfterReincarnation)
            {
                return false;
            }
        }

        return true;
    }
    public IEnumerator UpdateJudge()
    {
        int GetSE = 60;
        if (gameObject.GetComponent<MISSION>() == null)
        {
            MissionExplainText = Instantiate(main.Texts[29], gameObject.GetComponent<DUNGEON>().window.transform.GetChild(5));
            EpicCoinNumText = MissionExplainText.gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
            MissionExplainText.text = "- Coming Soon!";
            yield break;
        }

        yield return new WaitForSeconds(0.1f);
        MissionExplainText = Instantiate(main.Texts[29], gameObject.GetComponent<DUNGEON>().window.transform.GetChild(5));
        EpicCoinNumText = MissionExplainText.gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>();

        //転生回数が０回のとき
        if (main.S.ReincarnationNum == 0)
        {
            if (isMissionCompleted)
            {
                MissionExplainText.color = Color.green;
                EpicCoinNumText.text = "<sprite=0> <color=green>" + tDigit(200);
            }
            else
            {
                MissionExplainText.color = Color.white;
                EpicCoinNumText.text = "<sprite=0> <color=white>" + tDigit(200);
                while (!isMissionAllCleared() || isMissionCompleted)
                {
                    yield return new WaitForSeconds(0.25f);
                }
                MissionExplainText.color = Color.green;
                EpicCoinNumText.text = "<sprite=0> <color=green>" + tDigit(200);
                //main.S.ECbyMission += 200 / 5;
                isMissionCompleted = true;
            }
        }
        else
        {
            if (!isMissionCompleted)
            {
                //まだ一回もAll Clearをしていないか？
                MissionExplainText.color = Color.white;
                EpicCoinNumText.text = "<sprite=0> <color=white>" + tDigit(200);
                yield return new WaitUntil(() => isMissionAllCleared() && !isMissionCompleted);
                //main.S.ECbyMission += 200 / 5;
                isMissionCompleted = true;
                MissionExplainText.color = Color.green;
                EpicCoinNumText.text = "<sprite=0> <color=green>" + tDigit(200);
            }

            if (isMissionCompletedAfterReincarnation)
            {
                MissionExplainText.color = Color.green;
                EpicCoinNumText.text = "  <sprite=\"se2\" index=0>  <color=green>" + tDigit(GetSE);
            }
            else
            {
                MissionExplainText.color = orange;
                EpicCoinNumText.text = "  <sprite=\"se2\" index=0>  <color=orange>" + tDigit(GetSE);
                //その後全てクリアしたら。。。
                while (true)
                {
                    if (isRMissionAllCleared() && !isMissionCompletedAfterReincarnation)
                        break;
                    if (!isMissionCompleted)
                    {
                        MissionExplainText.color = Color.white;
                        EpicCoinNumText.text = "<sprite=0> <color=white>" + tDigit(200);
                    }
                    else 
                    {
                        MissionExplainText.color = orange;
                        EpicCoinNumText.text = "  <sprite=\"se2\" index=0>  <color=orange>" + tDigit(GetSE);
                    }
                    yield return new WaitForSeconds(1.0f);
                }
                //yield return new WaitUntil(() => isRMissionAllCleared() && !isMissionCompletedAfterReincarnation);
                MissionExplainText.color = Color.green;
                EpicCoinNumText.text = "  <sprite=\"se2\" index=0>  <color=green>" + tDigit(GetSE);
                main.S.SRPfromMission += GetSE;
                isMissionCompletedAfterReincarnation = true;
            }
        }
    }

    public void ChangeTextColor()
    {
        if (!isMissionCompleted)
        {
            MissionExplainText.color = Color.white;
            EpicCoinNumText.text = "<sprite=0> <color=white>" + tDigit(200);
        }
        else if (main.S.ReincarnationNum > 0 && !isMissionCompletedAfterReincarnation)
        {
            MissionExplainText.color = orange;
            EpicCoinNumText.text = "  <sprite=\"se2\" index=0>  <color=orange>" + tDigit(60);
        }
        else
        {
            MissionExplainText.color = Color.green;
            EpicCoinNumText.text = "  <sprite=\"se2\" index=0>  <color=green>" + tDigit(60);
        }
    }

    //AllMissionクリアの勲章表示
    string tempString;
    public IEnumerator indicatorAllClearMission()
    {
        if (main.S.ReincarnationNum == 0)
            yield return new WaitUntil(isMissionAllCleared);
        else
        {
            tempString = areaNumText.text;
            if (isMissionAllCleared())
                areaNumText.text = tempString + "<size=8><sprite=\"StarSlice\" index=0>";
            yield return new WaitUntil(isRMissionAllCleared);
            areaNumText.text = tempString + "<size=8><sprite=\"StarSlice\" index=1>";
        }
    }

    //ダンジョンボタンを押したときの処理（ボタンを押せばHP回復してスタート）
    public void PrepareDungeon()
    {
        main.ally.currentHp = main.ally.HP();
        if (!main.S.isSlimeHideoutTryAgainFirst)//最初の達成率を0%にするため
        {
            main.S.isSlimeHideoutTryAgainFirst = true;
        }
        TryDungeon();
    }
    public void TryDungeon()
    {
        main.GameController.Initialize();
        dungeonPlayTime = main.rebirthTime;

        //if (!main.toggles[1].isOn)//死んだときは強制でデスパネル呼ばれてしまうため、コメントアウトした
        //{
        main.DeathPanel.FadeAwayPanel();
        //}
        main.DeathPanel.isPanel = false;
        dungeonFloorNum = 0;
        isWin = false;
        main.GameController.battleMode = GameController.BattleMode.dungeon;
        main.GameController.currentDungeon = dungeon;
        main.GameController.ChangeFieldSprite();
        //for (int i = 0; i < main.StageChangeButtonAry.Length; i++)
        //{
        //    int count = i;
        //    main.StageChangeButtonAry[count].SetActive(false);
        //}
        main.DeathPanel.initResult();
        //main.ally1.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -150);
        InstantiateEnemies(dungeonFloorNum);
        //コルーチンを止める処理を入れる
        if (DungeonCoroutine != null)
            StopCoroutine(DungeonCoroutine);
        if (StageCoroutine != null)
            StopCoroutine(StageCoroutine);
        DungeonCoroutine = StartCoroutine(DungeonCor());
        StageCoroutine = StartCoroutine(StageController());
        //setActive(main.DungeonBar.gameObject);
        //StartCoroutine(Retire());

        //タイムはここからやりましょう
        startTime = spendTime;

        //Mission系統
        InitializeMission();
        foreach (MISSION mission in gameObject.GetComponents<MISSION>())
        {
            mission.Initialize();
            if (mission.gameObject.HasComponent<M_material>())
            {
                targetMaterial = mission.gameObject.GetComponent<M_material>().TargetMaterial;
                targetMaterialNum = main.ArtiCtrl.CurrentMaterial[targetMaterial];
                materialTempMission = mission.gameObject.GetComponent<M_material>();
            }
            if (mission.gameObject.HasComponent<M_capture>())
            {
                targetEnemy = mission.gameObject.GetComponent<M_capture>().TargetEnemy;
                targetCapturedNum = main.S.totalEnemiesCaptured[(int)targetEnemy];
                captureTempMission = mission.gameObject.GetComponent<M_capture>();
            }
        }
        //ここまで
    }
    public IEnumerator StageController()
    {
        while (true)
        {
            yield return new WaitUntil(() =>
            main.GameController.battleMode == GameController.BattleMode.dungeon
            && GameObject.FindGameObjectsWithTag("enemy").Length == 0
            && !main.DeathPanel.isPanel);
            if (!ClearCondition() && main.GameController.currentDungeon == dungeon)
            {
                dungeonFloorNum++;
                main.GameController.Initialize();
                InstantiateEnemies(dungeonFloorNum);
            }
            //else
            //{
            //    yield break;
            //}
            yield return new WaitForSeconds(0.05f);
        }
    }
    public IEnumerator DungeonCor()
    {
        yield return new WaitUntil(() =>
        {
            return ClearCondition() || main.ally1.GetComponent<ALLY>().currentHp <= 0 &&
            main.GameController.battleMode == GameController.BattleMode.dungeon && !main.DeathPanel.isPanel;
        });
        if (main.ally1.GetComponent<ALLY>().currentHp <= 0)
        {
            yield return StartCoroutine(ShowDeathPanel(false));

        }
        else
        {
            GetReward();
            //clearedNum++;
            yield return StartCoroutine(ShowDeathPanel(true));
        }
    }
    public IEnumerator CalculateSpendTime()
    {
        while (true)
        {
            yield return new WaitUntil(() => main.GameController.currentDungeon == dungeon);
            if (materialTempMission != null)
            {
                materialTempMission.materialNum += Math.Max((main.ArtiCtrl.CurrentMaterial[targetMaterial] - targetMaterialNum), 0);
                targetMaterialNum = main.ArtiCtrl.CurrentMaterial[targetMaterial];
            }
            if (captureTempMission != null)
            {
                captureTempMission.capturedNum += Math.Max((main.S.totalEnemiesCaptured[(int)targetEnemy] - targetCapturedNum), 0);
                targetCapturedNum = main.S.totalEnemiesCaptured[(int)targetEnemy];
            }
            spendTime += 1.0;
            yield return new WaitForSecondsRealtime(1.0f/Time.timeScale);
        }
    }
    public double areaDifficultyFactor = 0;
    public double dungeonDifficultyFactor = 0;
    public int dungeonLevelFactor = 0;
    public double AreaDifficultyFactor()
    {
        return areaDifficultyFactor + Convert.ToInt32(main.ZoneCtrl.isHidden) * (1000d + (int)dungeon * 50d);
    }
    public double DungeonDifficultyFactor()
    {
        return dungeonDifficultyFactor;
    }
    public double DungeonLevelFactor()
    {
        return dungeonLevelFactor;
    }
    public virtual void InstantiateEnemy(int enemyIndex, Vector3 position, double[] Status = null)//20200211新EnemyAryに変えました
    {
        int _enemyIndex = enemyIndex;
        //メタルスライムw
        if (main.cc.CurrentCurseId == CurseId.curse_of_metal)
            _enemyIndex = (int)ENEMY.EnemyKind.MetalSlime;
        ENEMY game;
        //game = Instantiate(main.enemies[enemyIndex], position + new Vector3(575, 325), new Quaternion(0, 0, 0, 0), main.Transforms[0]);
        game = Instantiate(main.ZoneCtrl.EnemyAry[_enemyIndex], position + new Vector3(575, 325), new Quaternion(0, 0, 0, 0), main.Transforms[0]);
        game.gameObject.GetComponent<RectTransform>().anchoredPosition = position;//+ new Vector3(575, 325);
                                                                                  //game.gameObject.GetComponent<RectTransform>().localPosition += new Vector3(0, 0, 6000);
        game.dungeonLevelFactor = DungeonLevelFactor();
        game.areaDifficultyFactor = AreaDifficultyFactor();
        game.dungeonDifficultyFactor = DungeonDifficultyFactor();
        if (Status != null)
        {
            game.InputStatus = Status;
        }
    }
    public void InstantiateEnemy(ENEMY.EnemyKind enemyIndex, Vector3 position, double[] Status = null)//20200211新EnemyAryに変えました
    {
        ENEMY.EnemyKind _enemyIndex = enemyIndex;
        //メタルスライムw
        if (main.cc.CurrentCurseId == CurseId.curse_of_metal)
            _enemyIndex = ENEMY.EnemyKind.MetalSlime;
        ENEMY game;
        //game = Instantiate(main.enemies[enemyIndex], position + new Vector3(575, 325), new Quaternion(0, 0, 0, 0), main.Transforms[0]);
        game = Instantiate(main.ZoneCtrl.EnemyAry[(int)_enemyIndex], position + new Vector3(575, 325), new Quaternion(0, 0, 0, 0), main.Transforms[0]);
        game.gameObject.GetComponent<RectTransform>().anchoredPosition = position;//+ new Vector3(575, 325);
                                                                                  //game.gameObject.GetComponent<RectTransform>().localPosition += new Vector3(0, 0, 6000);
        game.dungeonLevelFactor = DungeonLevelFactor();
        game.areaDifficultyFactor = AreaDifficultyFactor();
        game.dungeonDifficultyFactor = DungeonDifficultyFactor();
        if (Status != null)
        {
            game.InputStatus = Status;
        }

    }
    public double achievementPercent()
    {
        if (isZone)
            return 0;
        return maxDungeonFloorNum;
        //return (double)((maxDungeonFloorNum) * 100) / (double)(dungeonMaxFloorNum + 1);
    }
    void UpdateMission()
    {
        /*
        if (MissionExplainText == null || EpicCoinNumText == null)
        {
            return;
        }
        if (isMissionCompleted)
        {
            MissionExplainText.color = Color.green;
            EpicCoinNumText.text = "<sprite=0> <color=green>" + tDigit(200);
        }
        else
        {
            MissionExplainText.color = Color.white;
            EpicCoinNumText.text = "<sprite=0> <color=white>" + tDigit(200);
        }
        */
    }



    public void UpdateDungeon()
    {
        updateText();
        if (window.activeSelf)
        {
            LocalizeInitialize.SetFont(MissionExplainText);
            MissionExplainText.text = MissionLocal.clearall();
        }
        if (main.S.isSkillSet && main.S.isSlimeHideoutTryAgainFirst)
        {
            maxDungeonFloorNum = Math.Max(maxDungeonFloorNum, dungeonFloorNum);
            if (maxDungeonFloorNum == dungeonMaxFloorNum && isDungeon)
            {
                maxDungeonFloorNum = dungeonMaxFloorNum + 1;
            }
        }
        if (main.toggles[9].isOn)//LightMode
        {
            if (main.GameController.battleMode == GameController.BattleMode.dungeon && main.GameController.currentDungeon == dungeon)
            {
                if (isZone)
                    main.systemController.texts[1].text = main.TextEdit(new string[] { "Area ", showIndex, " : WAVE ", (dungeonFloorNum + 1).ToString(), " / ", (dungeonMaxFloorNum + 1).ToString() });
                else
                    main.systemController.texts[1].text = main.TextEdit(new string[] { "Dungeon ", showIndex, " : WAVE ", (dungeonFloorNum + 1).ToString() });

            }
        }
        else
        {
            if (!isZone)
                gameObject.GetComponentsInChildren<TextMeshProUGUI>()[2].text = "Wave " + tDigit(achievementPercent());

            LocalizeInitialize.SetFont(main.Texts[0]);
            if (main.GameController.battleMode == GameController.BattleMode.dungeon && main.GameController.currentDungeon == dungeon)
            {
                if (isZone)
                    main.Texts[0].text = "Area " + showIndex + " : " + AreaLocal.GetAreaName(dungeon,this) + "\n<size=50%>WAVE  " + (dungeonFloorNum + 1) + " / " + (dungeonMaxFloorNum + 1);
                else
                    main.Texts[0].text = "Dungeon " + showIndex + " : " + AreaLocal.GetAreaName(dungeon, this) + "\n<size=50%>WAVE  " + (dungeonFloorNum + 1);
            }
        }

        if (window.activeSelf)
        {
            UpdateMission();

            if (isZone)
            {
                Name = "Area " + (showIndex) + "\n<size=18>" + AreaLocal.GetAreaName(dungeon, this);
                rewardText = "Reward";
            }
            else
            {
                Name = "Dungeon " + showIndex + "\n<size=18>" + AreaLocal.GetAreaName(dungeon, this);
                rewardText = "Status";
                setFalse(window.transform.GetChild(4).gameObject);
                setFalse(window.transform.GetChild(5).gameObject);
                setFalse(window.transform.GetChild(7).gameObject);
                setFalse(window.transform.GetChild(8).gameObject);
            }

            if (main.S.canAutoRebirth && isZone)
            {
                if ((int)dungeon >= 12 && Input.GetKeyDown(KeyCode.R))
                {
                    if (main.S.autoRebirthArea == dungeon)
                    {
                        main.S.autoRebirthArea = Main.Dungeon.batCave;
                    }
                    else
                    {
                        main.S.autoRebirthArea = dungeon;
                        
                    }
                }
            }

            if (main.S.FavoriteArea && isZone && coolTime==0)
            {
                if (Input.GetKeyDown(KeyCode.F) || Input.GetMouseButtonDown(1))
                {
                    main.SR.favoriteDungeon = dungeon;
                }
            }
        }
        if (main.S.FavoriteArea && main.SR.favoriteDungeon == dungeon)
            areaNumText.color = Color.yellow;
        else
            areaNumText.color = Color.white;
        if (main.S.canAutoRebirth && main.S.autoRebirthArea == dungeon)
        {
            areaNumText.text = tempAreaNumString + "<size=12><color=green><R></color></size>";
            //dungeonName = tempNameString + "  <color=green>Rebirth Area</color>";
        }
        else
        {
            areaNumText.text = tempAreaNumString;
        }

        if (main.DeathPanel.isPanel || main.GameController.battleMode == GameController.BattleMode.challange || isCoolTime)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
        }

        //AreaMastery
        if (window.activeSelf)
        {
            if (isZone)
            {
                ClearNumText = "- Cleared Count : " + tDigit(dungeonClearNum);
                ClearNumText += "\n</color>- Drop Bonus : <color=green>+ " + percent(CurrentDropChanceBonus()) + "</color>";
                ClearNumText +=  "\n- EXP Bonus : <color=green>+ " + percent(CurrentExpBonus()) + "</color>\n- Move Speed Bonus : <color=green>+ " + percent(CurrentMoveSpeedBonus());
                ClearNumText += "</color>\n- Next Bonus at cleared " + tDigit(NextBonusNum()) + " times";
            }
            else
                ClearNumText = "";
            //ExpBonusText = "Exp Bonus in this Area " + percent(CurrentExpBonus());
            //MoveSpeedText = "Move Speed Bonus in this Area " + percent(CurrentMoveSpeedBonus());
            //NextBonusText = "Next Bonus at " + tDigit(NextBonusNum());
        }
    }
    public virtual void InstantiateEnemies(int dungeonFloorNum) { }
    public bool ClearCondition()
    {
        if (main.GameController.currentDungeon == dungeon && dungeonFloorNum == dungeonMaxFloorNum && GameObject.FindGameObjectsWithTag("enemy").Length == 0)
        {
            dungeonFloorNum = dungeonMaxFloorNum;
            return true;
        }
        else
        {
            return false;
        }
    }
    public virtual void GetReward() { }
    //これはクエストに成功しても失敗しても呼ぶようにする．
    public IEnumerator ShowDeathPanel(bool isWin)
    {
        //clearTime = main.DeathPanel.time;これはspendTimeでやることにした
        clearTime = (float)(spendTime - startTime);
        thisClearTime = clearTime;
        LocalizeInitialize.SetFont(main.DeathPanel.titleText);
        if (isWin)
        {
            if (isZone)
            {
                main.DeathPanel.titleText.text = AreaLocal.clearArea(true);
                if (!main.ally.isDead)
                    main.ally.isDead = true;
            }
            else
                main.DeathPanel.titleText.text = AreaLocal.clearZone(true);
            UpdateClearTime(clearTime);
            //ミッションの判定
            foreach (MISSION mission in gameObject.GetComponents<MISSION>())
            {
                mission.Judge(clearTime);
            }
            /*
            if (materialTempMission != null)
            {
                materialTempMission.materialNum += Math.Max((main.ArtiCtrl.CurrentMaterial[targetMaterial] - targetMaterialNum),0);
            }
            if(captureTempMission != null)
            {
                captureTempMission.capturedNum += Math.Max((main.S.totalEnemiesCaptured[(int)targetEnemy] - targetCapturedNum),0);
            }
            */
            //
            int temp = 1 + (int)main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.Catographer].GetCurrentValue();
            dungeonClearNum += temp;
            dungeonClearNumForMission += temp;
            //Application.ExternalCall("kongregate.stats.submit", "MissionMilestone", main.MissionCount);

            //AutoRebirth
            if (main.S.canAutoRebirth && main.S.autoRebirthArea == dungeon && main.cc.CurrentCurseId == CurseId.normal)
            {
                switch (main.S.job)
                {
                    case ALLY.Job.Warrior:
                        if (main.S.canAutoRebirthWarrior)
                        {
                            main.Log("Rebirth to Warrior", 10);
                            main.buttons[4].onClick.Invoke();
                            yield return new WaitForSeconds(0.5f);
                            main.jobChangeButtons[0].onClick.Invoke();
                            main.S.didAutoRebirth = true;
                            StartCoroutine(main.jobChange.doAscension());
                        }
                        break;
                    case ALLY.Job.Wizard:
                        if (main.S.canAutoRebirthWiz)
                        {
                            main.Log("Rebirth to Wizard", 10);
                            main.buttons[4].onClick.Invoke();
                            yield return new WaitForSeconds(0.5f);
                            main.jobChangeButtons[1].onClick.Invoke();
                            main.S.didAutoRebirth = true;
                            StartCoroutine(main.jobChange.doAscension());
                        }
                        break;
                    case ALLY.Job.Angel:
                        if (main.S.canAutoRebirthAng)
                        {
                            main.Log("Rebirth to Angel", 10);
                            main.buttons[4].onClick.Invoke();
                            yield return new WaitForSeconds(0.5f);
                            main.jobChangeButtons[2].onClick.Invoke();
                            main.S.didAutoRebirth = true;
                            StartCoroutine(main.jobChange.doAscension());
                        }
                        break;
                    default:
                        break;
                }
            }
            //AutoRein
            if (dungeon==Main.Dungeon.Z_fox4 && main.S.canAutoRein && main.cc.CurrentCurseId == CurseId.normal)
            {
                if (main.skillSetController.currentDPS >= 1e20d)
                {
                    switch (main.S.job)
                    {
                        case ALLY.Job.Warrior:
                            if (main.S.canAutoReinWarrior)
                            {
                                main.Log("Reincarnate to Warrior", 10);
                                main.QuestCtrl.Quests[(int)montblango].GetReward();
                                main.S.didAutoRein = true;
                                main.S.autoReinJob = ALLY.Job.Warrior;
                                yield return new WaitForSeconds(0.1f);
                                main.buttons[4].onClick.Invoke();
                                yield return new WaitForSeconds(1f);
                                StartCoroutine(main.rein.Reincarnate());
                            }
                            break;
                        case ALLY.Job.Wizard:
                            if (main.S.canAutoReinWiz)
                            {
                                main.Log("Reincarnate to Wizard", 10);
                                main.QuestCtrl.Quests[(int)montblango].GetReward();
                                main.S.didAutoRein = true;
                                main.S.autoReinJob = ALLY.Job.Wizard;
                                yield return new WaitForSeconds(0.1f);
                                main.buttons[4].onClick.Invoke();
                                yield return new WaitForSeconds(1f);
                                StartCoroutine(main.rein.Reincarnate());
                            }
                            break;
                        case ALLY.Job.Angel:
                            if (main.S.canAutoReinAng)
                            {
                                main.Log("Reincarnate to Angel", 10);
                                main.QuestCtrl.Quests[(int)montblango].GetReward();
                                main.S.didAutoRein = true;
                                main.S.autoReinJob = ALLY.Job.Angel;
                                yield return new WaitForSeconds(0.1f);
                                main.buttons[4].onClick.Invoke();
                                yield return new WaitForSeconds(1f);
                                StartCoroutine(main.rein.Reincarnate());
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        else
        {
            if (isZone)
                main.DeathPanel.titleText.text = AreaLocal.clearArea(false);
            else
                main.DeathPanel.titleText.text = AreaLocal.clearZone(false);
        }

        main.DeathPanel.isPanel = true;

        //デスパネルがオフにされていれば，この処理を飛ばす．
        if (!main.toggles[1].isOn)
        {
            if (!main.TutorialController.isSlimeHideoutClear)
            {
                yield return main.DeathPanel.ActiveCor(main.deathPanel.gameObject);
                yield return main.DeathPanel.ActiveCor(main.DeathPanel.titleText.gameObject);
                L_tutorial.Proceed(main.DeathPanel.expText);
                yield return main.DeathPanel.ActiveCor(main.DeathPanel.expText.gameObject);
                yield return new WaitForSeconds(2.0f);
                //Upgradeメニューの開放
                if (main.ally1.GetComponent<ALLY>().isDead && !main.TutorialController.isUpgrade)
                {
                    main.buttons[0].gameObject.GetComponent<Transform>().SetParent(main.TutorialController.MenuCanvas);
                    main.GameController.ActiveObject(main.GameController.HideIdleCanvas);
                    main.GameController.DoRayCast();
                    if (main.S.job == ALLY.Job.Warrior)
                    {
                        main.TutorialController.Texts[0].gameObject.SetActive(true);
                        main.S.isUpgradeIcon1 = true;
                        main.TutorialController.ShowUpgradeIcon();
                    }
                    else if (main.S.job == ALLY.Job.Wizard)
                    {
                        main.TutorialController.Texts[1].gameObject.SetActive(true);
                        main.S.isUpgradeIcon2 = true;
                        main.TutorialController.ShowUpgradeIcon();
                    }
                    else if (main.S.job == ALLY.Job.Angel)
                    {
                        main.TutorialController.Texts[2].gameObject.SetActive(true);
                        main.S.isUpgradeIcon3 = true;
                        main.TutorialController.ShowUpgradeIcon();
                    }
                    main.TutorialController.isUpgrade = true;
                }
                yield return new WaitUntil(() => main.S.isSkillTreeOpen);
                L_tutorial.Proceed2(main.DeathPanel.goldText);
                yield return main.DeathPanel.ActiveCor(main.DeathPanel.goldText.gameObject);

                yield return new WaitUntil(() => main.saveWar.SkillLevel[1] >= 1 || main.saveWiz.SkillLevel[1] >= 1 || main.saveAng.SkillLevel[1] >= 1);
                L_tutorial.Proceed3(main.DeathPanel.timeText);
           
                yield return main.DeathPanel.ActiveCor(main.DeathPanel.timeText.gameObject);


            }
            else
            {
                yield return main.DeathPanel.ActiveCor(main.deathPanel.gameObject);
                yield return main.DeathPanel.ActiveCor(main.DeathPanel.titleText.gameObject);
                DeathpanelLocal.exp(main.DeathPanel.expText);
                //main.DeathPanel.expText.text = "Total Exp Gained " + tDigit(main.DeathPanel.exp);
                yield return main.DeathPanel.ActiveCor(main.DeathPanel.expText.gameObject);
                DeathpanelLocal.gold(main.DeathPanel.goldText);
               // main.DeathPanel.goldText.text = "Total Gold Gained " + tDigit(main.DeathPanel.gold);
                yield return main.DeathPanel.ActiveCor(main.DeathPanel.goldText.gameObject);
                DeathpanelLocal.time(main.DeathPanel.timeText,clearTime);
                //main.DeathPanel.timeText.text = "Time " + DoubleTimeToDate(clearTime);
                yield return main.DeathPanel.ActiveCor(main.DeathPanel.timeText.gameObject);
                main.DeathPanel.AddMaterialText();
                for (int i = 0; i < main.DeathPanel.materialTexts.Length; i++)
                {
                    StartCoroutine(main.DeathPanel.ActiveCor(main.DeathPanel.materialTexts[i].gameObject));
                }
            }
            //main.DeathPanel.timeText.text = "Survival time " + DoubleTimeToDate(DeltaTimeFloat(main.DeathPanel.C_time));
            //yield return main.DeathPanel.ActiveCor(main.DeathPanel.timeText.gameObject);
            if (!main.S.isSlimeHideoutClear)
            {
                dungeonFloorNum = 0;
                main.DeathPanel.isPanel = false;
                yield break;
            }

        }
        else
        {

           StartCoroutine(main.DeathPanel.ActiveCor(main.deathPanel.gameObject));
           StartCoroutine(main.DeathPanel.ActiveCor(main.DeathPanel.titleText.gameObject));
            DeathpanelLocal.exp(main.DeathPanel.expText);
            StartCoroutine(main.DeathPanel.ActiveCor(main.DeathPanel.expText.gameObject));
            DeathpanelLocal.gold(main.DeathPanel.goldText);
            StartCoroutine(main.DeathPanel.ActiveCor(main.DeathPanel.goldText.gameObject));
            DeathpanelLocal.time(main.DeathPanel.timeText, clearTime);
            yield return main.DeathPanel.ActiveCor(main.DeathPanel.timeText.gameObject);
            main.DeathPanel.AddMaterialText();
           for (int i = 0; i < main.DeathPanel.materialTexts.Length; i++)
           {
               StartCoroutine(main.DeathPanel.ActiveCor(main.DeathPanel.materialTexts[i].gameObject));
           }
            yield return new WaitForSeconds(1.0f);
        }
        //トグルOnかどうかで処理を分けてしまうよ→分かれないよ→草
        dungeonFloorNum = 0;
        main.ally1.GetComponent<ALLY>().condition = ALLY.Condition.MoveMode;

        if (!isCoolTime)
        {
            if (!main.toggles[1].isOn)
            {
                yield return new WaitForSeconds(1.0f);
                main.Texts[28].text = "Restart this Area in 3";
                yield return main.DeathPanel.ActiveCor(main.Texts[28].gameObject);
                yield return new WaitForSeconds(1.0f);
                main.Texts[28].text = "Restart this Area in 2";
                yield return new WaitForSeconds(1.0f);
                main.Texts[28].text = "Restart this Area in 1";
                yield return new WaitForSeconds(1.0f);
            }
            main.DeathPanel.isPanel = false;
        }
        else
        {
            yield return new WaitForSeconds(1.0f);
            main.Texts[28].text = "Select to try another Area";
            yield return main.DeathPanel.ActiveCor(main.Texts[28].gameObject);
            main.DeathPanel.isPanel = false;
        }
        //チェックしてなかったら
        if (!main.toggles[6].isOn || !isWin)
        {
            if (!isCoolTime)
                main.dungeonAry[(int)main.GameController.currentDungeon].gameObject.GetComponent<Button>().onClick.Invoke();
            else if (main.S.FavoriteArea)
                main.dungeonAry[(int)main.SR.favoriteDungeon].gameObject.GetComponent<Button>().onClick.Invoke();
            else
                main.dungeonAry[0].gameObject.GetComponent<Button>().onClick.Invoke();
        }
        else
        {
            if (main.GameController.currentDungeon == Main.Dungeon.slimeHideout)
            {
                main.dungeonAry[9].gameObject.GetComponent<Button>().onClick.Invoke();
            }
            else if (main.GameController.currentDungeon == Main.Dungeon.Z_spider8)
            {
                main.dungeonAry[35].gameObject.GetComponent<Button>().onClick.Invoke();
            }
            else if (main.GameController.currentDungeon == Main.Dungeon.Z_fairy8)
            {
                main.dungeonAry[44].gameObject.GetComponent<Button>().onClick.Invoke();
            }
            else if (main.GameController.currentDungeon == Main.Dungeon.Z_fox8)
            {
                main.dungeonAry[53].gameObject.GetComponent<Button>().onClick.Invoke();
            }
            else if (main.GameController.currentDungeon == Main.Dungeon.Z_MS8)
            {
                main.dungeonAry[62].gameObject.GetComponent<Button>().onClick.Invoke();
            }
            else if (main.GameController.currentDungeon == Main.Dungeon.Z_DF8)
            {
                main.dungeonAry[71].gameObject.GetComponent<Button>().onClick.Invoke();
            }
            //↓ここに一番最後のダンジョンを入れる．
            else if (main.GameController.currentDungeon == Main.Dungeon.Z_BB8)
            {
                if (!main.dungeonAry[(int)main.GameController.currentDungeon].isCoolTime)//クールタイムじゃなければ周回
                    main.dungeonAry[(int)main.GameController.currentDungeon].gameObject.GetComponent<Button>().onClick.Invoke();
                else if (main.S.FavoriteArea)
                    main.dungeonAry[(int)main.SR.favoriteDungeon].gameObject.GetComponent<Button>().onClick.Invoke();
                else
                    main.dungeonAry[0].gameObject.GetComponent<Button>().onClick.Invoke();
            }
            else
            {
                if(!main.dungeonAry[(int)main.GameController.currentDungeon + 1].isCoolTime)//次がクールタイムじゃなければ次へ進む
                    main.dungeonAry[(int)main.GameController.currentDungeon + 1].gameObject.GetComponent<Button>().onClick.Invoke();
                else if (main.S.FavoriteArea)
                    main.dungeonAry[(int)main.SR.favoriteDungeon].gameObject.GetComponent<Button>().onClick.Invoke();
                else
                    main.dungeonAry[(int)main.GameController.currentDungeon].gameObject.GetComponent<Button>().onClick.Invoke();
            }
        }
    }



    public void UpdateClearTime(float time)
    {
        switch (dungeon)
        {
            case Main.Dungeon.slimeHideout:
                main.S.MT_slime = Math.Min(main.S.MT_slime, time);
                break;
            case Main.Dungeon.batCave:
                main.S.MT_bat = Math.Min(main.S.MT_bat, time);
                break;
            case Main.Dungeon.sacredFairyCave:
                main.S.MT_fairy = Math.Min(main.S.MT_fairy, time);
                break;
            case Main.Dungeon.spiderRuin:
                main.S.MT_spider = Math.Min(main.S.MT_spider, time);
                break;
        }
    }

    public ENEMY.EnemyKind CalculateProb(Dictionary<ENEMY.EnemyKind, int> pairs)
    {
        int random = UnityEngine.Random.Range(0, 10000);
        int tempProb = 0;
        foreach (KeyValuePair<ENEMY.EnemyKind, int> pair in pairs)
        {
            tempProb += pair.Value;
            if (random <= tempProb)
            {
                return pair.Key;
            }
        }
        return ENEMY.EnemyKind.NormalSlime;
    }

    public ENEMY.EnemyKind ChooseEnemyByTable(ENEMY.MonsterTable table)
    {
        int random = UnityEngine.Random.Range(0, 10000);
        Dictionary<ENEMY.EnemyKind, int> enemyTable = new Dictionary<ENEMY.EnemyKind, int>();
        switch (table)
        {
            case ENEMY.MonsterTable.NormalSlimes:
                return ENEMY.EnemyKind.NormalSlime;
            case ENEMY.MonsterTable.BigSlime:
                return ENEMY.EnemyKind.BigSlime;
            case ENEMY.MonsterTable.CommonSlimes:
               enemyTable.Add(ENEMY.EnemyKind.NormalSlime, 4998);
               enemyTable.Add(ENEMY.EnemyKind.BlueSlime, 4000);
               enemyTable.Add(ENEMY.EnemyKind.YellowSlime, 1000);
               enemyTable.Add(ENEMY.EnemyKind.MetalSlime, 2);
                break;
            case ENEMY.MonsterTable.UncommonSlimes:
                enemyTable.Add(ENEMY.EnemyKind.YellowSlime, 3297);
                enemyTable.Add(ENEMY.EnemyKind.GreenSlime, 3300);
                enemyTable.Add(ENEMY.EnemyKind.OrangeSlime, 3200);
                enemyTable.Add(ENEMY.EnemyKind.RedSlime, 200);
                enemyTable.Add(ENEMY.EnemyKind.MetalSlime, 3);
                break;
            case ENEMY.MonsterTable.RareSlimes:
                enemyTable.Add(ENEMY.EnemyKind.RedSlime, 5995);
                enemyTable.Add(ENEMY.EnemyKind.PurpleSlime, 3999);
                enemyTable.Add(ENEMY.EnemyKind.SlimeBoss, 1);
                enemyTable.Add(ENEMY.EnemyKind.MetalSlime, 5);
                break;
            case ENEMY.MonsterTable.BossSlimes:
                return ENEMY.EnemyKind.SlimeBoss;
            case ENEMY.MonsterTable.NormalSpider:
                return ENEMY.EnemyKind.NormalSpider;
            case ENEMY.MonsterTable.CommonSpiders:
                enemyTable.Add(ENEMY.EnemyKind.NormalSpider, 4998);
                enemyTable.Add(ENEMY.EnemyKind.BlueSpider, 4000);
                enemyTable.Add(ENEMY.EnemyKind.YellowSpider, 1000);
                enemyTable.Add(ENEMY.EnemyKind.MetalSlime, 2);
                break;
            case ENEMY.MonsterTable.UncommonSpiders:
                enemyTable.Add(ENEMY.EnemyKind.YellowSpider, 4997);
                enemyTable.Add(ENEMY.EnemyKind.GreenSpider, 4800);
                enemyTable.Add(ENEMY.EnemyKind.RedSpider, 200);
                enemyTable.Add(ENEMY.EnemyKind.MetalSlime, 3);
                break;
            case ENEMY.MonsterTable.RareSpiders:
                enemyTable.Add(ENEMY.EnemyKind.RedSpider, 5995);
                enemyTable.Add(ENEMY.EnemyKind.PurpleSpider, 3999);
                enemyTable.Add(ENEMY.EnemyKind.SpiderQueen, 1);
                enemyTable.Add(ENEMY.EnemyKind.MetalSlime, 5);
                break;
            case ENEMY.MonsterTable.BossSpiders:
                return ENEMY.EnemyKind.SpiderQueen;
            case ENEMY.MonsterTable.NormalBats:
                return ENEMY.EnemyKind.NormalBat;
            case ENEMY.MonsterTable.CommonBats:
                enemyTable.Add(ENEMY.EnemyKind.NormalBat, 4998);
                enemyTable.Add(ENEMY.EnemyKind.BlueBat, 4000);
                enemyTable.Add(ENEMY.EnemyKind.YellowBat, 1000);
                enemyTable.Add(ENEMY.EnemyKind.MetalSlime, 2);
                break;
            case ENEMY.MonsterTable.UncommonBats:
                enemyTable.Add(ENEMY.EnemyKind.YellowBat, 3297);
                enemyTable.Add(ENEMY.EnemyKind.GreenBat, 3300);
                enemyTable.Add(ENEMY.EnemyKind.OrangeBat, 3200);
                enemyTable.Add(ENEMY.EnemyKind.RedBat, 200);
                enemyTable.Add(ENEMY.EnemyKind.MetalSlime, 3);
                break;
            case ENEMY.MonsterTable.RareBats:
                enemyTable.Add(ENEMY.EnemyKind.RedBat, 5995);
                enemyTable.Add(ENEMY.EnemyKind.PurpleBat, 3999);
                enemyTable.Add(ENEMY.EnemyKind.BlackBat, 1);
                enemyTable.Add(ENEMY.EnemyKind.MetalSlime, 5);
                break;
            case ENEMY.MonsterTable.BossBats:
                return ENEMY.EnemyKind.BlackBat;
            
                //Fairy
            case ENEMY.MonsterTable.NormalFairy:
                return ENEMY.EnemyKind.NormalFairy;
            case ENEMY.MonsterTable.CommonFairy:
                enemyTable.Add(ENEMY.EnemyKind.NormalFairy, 4998);
                enemyTable.Add(ENEMY.EnemyKind.BlueFairy, 4000);
                enemyTable.Add(ENEMY.EnemyKind.YellowFairy, 1000);
                enemyTable.Add(ENEMY.EnemyKind.MetalSlime, 2);
                break;
            case ENEMY.MonsterTable.UncommonFairy:
                enemyTable.Add(ENEMY.EnemyKind.YellowFairy, 3297);
                enemyTable.Add(ENEMY.EnemyKind.GreenFairy, 3300);
                enemyTable.Add(ENEMY.EnemyKind.OrangeFairy, 3200);
                enemyTable.Add(ENEMY.EnemyKind.RedFairy, 200);
                enemyTable.Add(ENEMY.EnemyKind.MetalSlime, 3);
                break;
            case ENEMY.MonsterTable.RareFairy:
                enemyTable.Add(ENEMY.EnemyKind.RedFairy, 5995);
                enemyTable.Add(ENEMY.EnemyKind.PurpleFairy, 3999);
                enemyTable.Add(ENEMY.EnemyKind.BlackFairy, 1);
                enemyTable.Add(ENEMY.EnemyKind.MetalSlime, 5);
                break;
            case ENEMY.MonsterTable.BossFairy:
                return ENEMY.EnemyKind.BlackFairy;

                //Fox
            case ENEMY.MonsterTable.NormalFoxes:
                return ENEMY.EnemyKind.OrangeFox;
            case ENEMY.MonsterTable.CommonFoxes:
                enemyTable.Add(ENEMY.EnemyKind.OrangeFox, 4998);
                enemyTable.Add(ENEMY.EnemyKind.YellowFox, 4000);
                enemyTable.Add(ENEMY.EnemyKind.GreenFox, 1000);
                enemyTable.Add(ENEMY.EnemyKind.MetalSlime, 2);
                break;
            case ENEMY.MonsterTable.UncommonFoxes:
                enemyTable.Add(ENEMY.EnemyKind.GreenFox, 4997);
                enemyTable.Add(ENEMY.EnemyKind.RedFox, 4800);
                enemyTable.Add(ENEMY.EnemyKind.BlueFox, 200);
                enemyTable.Add(ENEMY.EnemyKind.MetalSlime, 3);
                break;
            case ENEMY.MonsterTable.RareFoxes:
                enemyTable.Add(ENEMY.EnemyKind.BlueFox, 3395);
                enemyTable.Add(ENEMY.EnemyKind.PurpleFox, 3000);
                enemyTable.Add(ENEMY.EnemyKind.WhiteFox, 1200);
                enemyTable.Add(ENEMY.EnemyKind.SkyFox, 1200);
                enemyTable.Add(ENEMY.EnemyKind.BlackFox, 1200);
                enemyTable.Add(ENEMY.EnemyKind.MetalSlime, 5);
                break;
            case ENEMY.MonsterTable.BossFoxes:
                return ENEMY.EnemyKind.WhiteNineTailedFox;
                //MS
            case ENEMY.MonsterTable.NormalMSlimes:
                return ENEMY.EnemyKind.MNormalslime;
            case ENEMY.MonsterTable.CommonMSlimes:
                enemyTable.Add(ENEMY.EnemyKind.MNormalslime, 4998);
                enemyTable.Add(ENEMY.EnemyKind.MBlueslime, 4000);
                enemyTable.Add(ENEMY.EnemyKind.MYelllowSlime, 1000);
                enemyTable.Add(ENEMY.EnemyKind.MetalSlime, 2);
                break;
            case ENEMY.MonsterTable.UncommonMSlimes:
                enemyTable.Add(ENEMY.EnemyKind.MYelllowSlime, 3297);
                enemyTable.Add(ENEMY.EnemyKind.MGreenSlime, 3300);
                enemyTable.Add(ENEMY.EnemyKind.MOrangeSlime, 2500);
                enemyTable.Add(ENEMY.EnemyKind.MRedSlime, 900);
                enemyTable.Add(ENEMY.EnemyKind.MetalSlime, 3);
                break;
            case ENEMY.MonsterTable.RareMSlimes:
                enemyTable.Add(ENEMY.EnemyKind.MOrangeSlime, 2999);
                enemyTable.Add(ENEMY.EnemyKind.MRedSlime, 4000);
                enemyTable.Add(ENEMY.EnemyKind.MPurpleSlime, 2995);
                enemyTable.Add(ENEMY.EnemyKind.WizardSlime, 1);
                enemyTable.Add(ENEMY.EnemyKind.MetalSlime, 5);
                break;
            case ENEMY.MonsterTable.BossMSlimes:
                return ENEMY.EnemyKind.WizardSlime;

            //DevilFish
            case ENEMY.MonsterTable.NormalDevilFish:
                enemyTable.Add(ENEMY.EnemyKind.BlueDevilFish, 4997);
                enemyTable.Add(ENEMY.EnemyKind.GreenDevilFish, 4997);
                enemyTable.Add(ENEMY.EnemyKind.PurpleDevilFish, 4);
                enemyTable.Add(ENEMY.EnemyKind.MetalSlime, 2);
                break;
            case ENEMY.MonsterTable.CommonDevilFish:
                enemyTable.Add(ENEMY.EnemyKind.BlueDevilFish, 2998);
                enemyTable.Add(ENEMY.EnemyKind.GreenDevilFish, 2998);
                enemyTable.Add(ENEMY.EnemyKind.OrangeDevilFish, 1999);
                enemyTable.Add(ENEMY.EnemyKind.RedDevilFish, 1998);
                enemyTable.Add(ENEMY.EnemyKind.PurpleDevilFish, 5);
                enemyTable.Add(ENEMY.EnemyKind.MetalSlime, 2);
                break;
            case ENEMY.MonsterTable.UncommonDevilFish:
                enemyTable.Add(ENEMY.EnemyKind.BlueDevilFish, 999);
                enemyTable.Add(ENEMY.EnemyKind.GreenDevilFish, 999);
                enemyTable.Add(ENEMY.EnemyKind.OrangeDevilFish, 2999);
                enemyTable.Add(ENEMY.EnemyKind.RedDevilFish, 2999);
                enemyTable.Add(ENEMY.EnemyKind.SkyDevilFish, 999);
                enemyTable.Add(ENEMY.EnemyKind.YellowDevilFish, 998);
                enemyTable.Add(ENEMY.EnemyKind.PurpleDevilFish, 5);
                enemyTable.Add(ENEMY.EnemyKind.MetalSlime, 2);
                break;
            case ENEMY.MonsterTable.RareDevilFish:
                enemyTable.Add(ENEMY.EnemyKind.OrangeDevilFish, 997);
                enemyTable.Add(ENEMY.EnemyKind.RedDevilFish, 997);
                enemyTable.Add(ENEMY.EnemyKind.SkyDevilFish, 3998);
                enemyTable.Add(ENEMY.EnemyKind.YellowDevilFish, 3998);
                enemyTable.Add(ENEMY.EnemyKind.PurpleDevilFish, 5);
                enemyTable.Add(ENEMY.EnemyKind.MetalSlime, 5);
                break;
            case ENEMY.MonsterTable.BossDevilFish:
                return ENEMY.EnemyKind.PurpleDevilFish;

            //Blob
            case ENEMY.MonsterTable.CommonBall:
                enemyTable.Add(ENEMY.EnemyKind.BlueBlob, 4999);
                enemyTable.Add(ENEMY.EnemyKind.RedBlob, 4999);
                enemyTable.Add(ENEMY.EnemyKind.MetalSlime, 2);
                break;
            case ENEMY.MonsterTable.RareBall:
                enemyTable.Add(ENEMY.EnemyKind.BlueCatBlob, 3000);
                enemyTable.Add(ENEMY.EnemyKind.RedCatBlob, 3000);
                enemyTable.Add(ENEMY.EnemyKind.BlueRabbitBlob, 1999);
                enemyTable.Add(ENEMY.EnemyKind.RedRabbitBlob, 1999);
                enemyTable.Add(ENEMY.EnemyKind.MetalSlime, 2);
                break;

            default:
                break;
        }
        return CalculateProb(enemyTable);
    }

    //以降フォーメイション
    public void InstantiateSquare(ENEMY.MonsterTable table, Vector3 CenterPosition, int Width, int Spacing = 40)//(ENEMY.MonsterTable table, Vector3 CenterPosition, double[] status,int Width, int Spacing=40)
    {
        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                InstantiateEnemy(ChooseEnemyByTable(table), CenterPosition + new Vector3(Spacing / 2 * (1 - Width) + Spacing * i, Spacing / 2 * (Width - 1) - Spacing * j));//(ChooseEnemyByTable(table), CenterPosition + new Vector3(Spacing/2 * (1 - Width) + Spacing * i, Spacing / 2 * ( Width - 1 ) - Spacing * j), status);
            }
        }
    }
    public void InstantiateHolLine(ENEMY.MonsterTable table, Vector3 CenterPosition, int Width, int Spacing = 40, double[] status = null)
    {
        for (int i = 0; i < Width; i++)
        {
            InstantiateEnemy(ChooseEnemyByTable(table), CenterPosition + new Vector3(Spacing / 2 * (1 - Width) + Spacing * i, 0));
        }
    }
    public void InstantiateVerLine(ENEMY.MonsterTable table, Vector3 CenterPosition, int Width, int Spacing = 40)
    {
        for (int i = 0; i < Width; i++)
        {
            InstantiateEnemy(ChooseEnemyByTable(table), CenterPosition + new Vector3(0, Spacing / 2 * (1 - Width) + Spacing * i));
        }
    }
    public void InstantiateFiveDia(ENEMY.MonsterTable table, Vector3 InitialPosition, double[] status = null)
    {
        InstantiateEnemy(ChooseEnemyByTable(table), InitialPosition, status);
        InstantiateEnemy(ChooseEnemyByTable(table), InitialPosition + new Vector3(-80, 120), status);
        InstantiateEnemy(ChooseEnemyByTable(table), InitialPosition + new Vector3(80, 120), status);
        InstantiateEnemy(ChooseEnemyByTable(table), InitialPosition + new Vector3(-140, 60), status);
        InstantiateEnemy(ChooseEnemyByTable(table), InitialPosition + new Vector3(140, 60), status);
    }
    public void InstantiateFiveUnder(ENEMY.MonsterTable table, Vector3 InitialPosition, double[] status = null)
    {
        InstantiateEnemy(ChooseEnemyByTable(table), InitialPosition, status);
        InstantiateEnemy(ChooseEnemyByTable(table), InitialPosition + new Vector3(-60, 30), status);
        InstantiateEnemy(ChooseEnemyByTable(table), InitialPosition + new Vector3(60, 30), status);
        InstantiateEnemy(ChooseEnemyByTable(table), InitialPosition + new Vector3(-120, 60), status);
        InstantiateEnemy(ChooseEnemyByTable(table), InitialPosition + new Vector3(120, 60), status);
    }
    public void InstantiateSevenUnder(ENEMY.MonsterTable table, Vector3 InitialPosition, double[] status = null)
    {
        InstantiateEnemy(ChooseEnemyByTable(table), InitialPosition, status);
        InstantiateEnemy(ChooseEnemyByTable(table), InitialPosition + new Vector3(-60, 30), status);
        InstantiateEnemy(ChooseEnemyByTable(table), InitialPosition + new Vector3(60, 30), status);
        InstantiateEnemy(ChooseEnemyByTable(table), InitialPosition + new Vector3(-120, 60), status);
        InstantiateEnemy(ChooseEnemyByTable(table), InitialPosition + new Vector3(120, 60), status);
        InstantiateEnemy(ChooseEnemyByTable(table), InitialPosition + new Vector3(-180, 90), status);
        InstantiateEnemy(ChooseEnemyByTable(table), InitialPosition + new Vector3(180, 90), status);
    }
    public void InstantiateSeven(ENEMY.MonsterTable table, Vector3 InitialPosition, double[] status = null)
    {
        InstantiateHolLine(table, InitialPosition + new Vector3(0, 100), 4, 100, status);
        InstantiateHolLine(table, InitialPosition + new Vector3(0, 20), 3, 100, status);
    }
    public void InstantiateNine(ENEMY.MonsterTable table, Vector3 InitialPosition, double[] status = null)
    {
        InstantiateHolLine(table, InitialPosition + new Vector3(0, 100), 4, 100, status);
        InstantiateHolLine(table, InitialPosition + new Vector3(0, 20), 3, 100, status);
        InstantiateHolLine(table, InitialPosition + new Vector3(0, -60), 2, 100, status);
    }
    public void Instantiate13(ENEMY.MonsterTable table, Vector3 InitialPosition, double[] status = null)
    {
        InstantiateHolLine(table, InitialPosition + new Vector3(0, -20), 4, 100);
        InstantiateHolLine(table, InitialPosition + new Vector3(0, 60), 3, 100);
        InstantiateHolLine(table, InitialPosition + new Vector3(0, 140), 3, 60);
        InstantiateHolLine(table, InitialPosition + new Vector3(0, -100), 3, 60);
    }
    public void InstantiateAround3(ENEMY.MonsterTable table, Vector3 InitialPosition, double[] status = null)
    {
        InstantiateEnemy(ChooseEnemyByTable(table), InitialPosition + new Vector3(0, 0), status);
        InstantiateHolLine(table, InitialPosition + new Vector3(0, -80), 2, 320);
    }
    public void InstantiateAround4(ENEMY.MonsterTable table, Vector3 InitialPosition, double[] status = null)
    {
        InstantiateHolLine(table, InitialPosition + new Vector3(0, 0), 2, 80);
        InstantiateHolLine(table, InitialPosition + new Vector3(0, -80), 2, 240);
    }
    public void InstantiateAround5(ENEMY.MonsterTable table, Vector3 InitialPosition, double[] status = null)
    {
        InstantiateEnemy(ChooseEnemyByTable(table), InitialPosition + new Vector3(0, 0), status);
        InstantiateHolLine(table, InitialPosition + new Vector3(0, -40), 2, 160);
        InstantiateHolLine(table, InitialPosition + new Vector3(0, -80), 2, 320);
    }
    public void InstantiateAround6(ENEMY.MonsterTable table, Vector3 InitialPosition, double[] status = null)
    {
        InstantiateHolLine(table, InitialPosition + new Vector3(0, 0), 2, 80);
        InstantiateHolLine(table, InitialPosition + new Vector3(0, -40), 2, 160);
        InstantiateHolLine(table, InitialPosition + new Vector3(0, -80), 2, 240);
    }
    public void InstantiateAround7(ENEMY.MonsterTable table, Vector3 InitialPosition, double[] status = null)
    {
        InstantiateEnemy(ChooseEnemyByTable(table), InitialPosition + new Vector3(0, 0), status);
        InstantiateHolLine(table, InitialPosition + new Vector3(0, -40), 2, 100);
        InstantiateHolLine(table, InitialPosition + new Vector3(0, -80), 2, 200);
        InstantiateHolLine(table, InitialPosition + new Vector3(0, -120), 2, 300);
    }

    public void getMaterial(ArtiCtrl.MaterialList material, int num = 1)
    {
        main.ArtiCtrl.CurrentMaterial[material] += num;
        //Debug.Log(main.ArtiCtrl.CurrentMaterial[material]);
        if (main.GameController.battleMode != GameController.BattleMode.challange)
        {
            main.DeathPanel.materials[material] += num;
        }
        else
        {
            main.DeathPanel.C_materials[material] += num;
        }
    }

    //Status
    //Slime
    // public double[] NormalSlime = new double[] { 20, 5, 0, 5, 0, 4, 8 };
    // double[] BlueSlime = new double[] { 120, 30, 0, 30, 0, 10, 15 };
    // double[] YellowlSlime = new double[] { 120, 30, 0, 30, 0, 10, 15 };
    // double[] GreenSlime = new double[] { 180, 45, 0, 45, 0, 16, 23 };
    // double[] OrangeSlime = new double[] { 20, 5, 0, 5, 0, 4, 8 };

    public IEnumerator ResetTry(float time)
    {
        while (true)
        {
            if (isDungeon && isCoolTime)
            {
                gameObject.GetComponentsInChildren<TextMeshProUGUI>()[0].text = "" + DoubleTimeToDate(Math.Max(time - (main.rebirthTime - dungeonPlayTime), 0));//.ToString(@"hh\:mm\:ss");
                setActive(window.transform.GetChild(6).GetComponent<TextMeshProUGUI>().gameObject);
                timeLeft = "You can try again in " + DoubleTimeToDate(Math.Max(time - ( main.rebirthTime - dungeonPlayTime), 0));
            }
            else
            {
                gameObject.GetComponentsInChildren<TextMeshProUGUI>()[0].text = "";
                setFalse(window.transform.GetChild(6).GetComponent<TextMeshProUGUI>().gameObject);
            }
            yield return new WaitForSecondsRealtime(1.0f);
            if (!isDungeon)
                continue;

            if ((main.rebirthTime - dungeonPlayTime) >= time)
            {
                isCoolTime = false;
            }
            else if (isDungeon)
            {
                isCoolTime = true;
            }
        }
    }


}
