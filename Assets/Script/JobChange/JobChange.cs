using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;
using UnityEngine.SceneManagement;

public class JobChange : BASE {

    public DateTime startTime
    {
        get { return DateTime.FromBinary(Convert.ToInt64(main.SR.ascendTime)); }
        set { main.SR.ascendTime = value.ToBinary().ToString(); }
    }
    public bool isAscend { get => main.S.isAscend; set => main.S.isAscend = value; }
    public ConfirmDefault confirm;
    public ALLY.Job selectedJob;
    public GameObject currentCanvas;
    public Button SuperRebirth;
    public Button InstantRebirth;
    public Button ResetRebirth;
    public Button[] JobChangeButton;

    // Use this for initialization
    void Awake () {
		StartBASE();
        //ミッション回数だけ先に入れる
        AfterRebirth();
        AfterSuperRebirth();
        gameObject.GetComponent<Button>().onClick.AddListener(confirmAscend);
        if (!isAscend)
        {
            startTime = DateTime.Now;
        }

        
    }

    // Use this for initialization
    void Start () {
        main.jobChangeButtons[0].onClick.AddListener(() => SetSibling(ALLY.Job.Warrior));
        main.jobChangeButtons[1].onClick.AddListener(() => SetSibling(ALLY.Job.Wizard));
        main.jobChangeButtons[2].onClick.AddListener(() => SetSibling(ALLY.Job.Angel));
        SuperRebirth.onClick.AddListener(confirmSuperRebirth);
        InstantRebirth.onClick.AddListener(confirmInstantRebirth);
        ResetRebirth.onClick.AddListener(confirmResetRebirth);
        currentCanvas = main.JobchangeCanvas[0].gameObject;
        selectedJob = ALLY.Job.Warrior;
        //tempPointを実際のPointと一致させる．
        main.tempAngP = main.AngP;
        main.tempWizP = main.WizP;
        main.tempWarP = main.WarP;
        //多分リセットボタン
        main.buttons[10].onClick.AddListener(() =>
        {
            foreach (A_UPGRADE upgrade in main.Ascends)
            {
                upgrade.tempLevel = main.S.A_level[upgrade.upgradeId];
            }
            main.tempWarP = main.WarP;
            main.tempWizP = main.WizP;
            main.tempAngP = main.AngP;
        });
        switch (main.ally1.GetComponent<ALLY>().job)
        {
            case ALLY.Job.Warrior:
                //currentCanvas = main.JobchangeCanvas[0].gameObject;
                break;
            case ALLY.Job.Wizard:
                main.jobChangeButtons[1].onClick.Invoke();
                break;
            case ALLY.Job.Angel:
                main.jobChangeButtons[2].onClick.Invoke();
                break;
        }
        if (!isAscend)
        {
            isAscend = true;
        }
        switch (main.cc.CurrentCurseId)
        {
            case CurseId.road_of_warrior:
                JobChangeButton[0].onClick.Invoke();
                break;
            case CurseId.curse_of_warrior2:
                JobChangeButton[0].onClick.Invoke();
                break;
            case CurseId.road_of_wizard:
                JobChangeButton[1].onClick.Invoke();
                break;
            case CurseId.curse_of_wizard2:
                JobChangeButton[1].onClick.Invoke();
                break;
            case CurseId.road_of_angel:
                JobChangeButton[2].onClick.Invoke();
                break;
            case CurseId.curse_of_angel2:
                JobChangeButton[2].onClick.Invoke();
                break;
        }
    }

    public void SetSibling(ALLY.Job job)
    {
        selectedJob = job;
        switch (job)
        {
            case ALLY.Job.Warrior:
                if (currentCanvas == main.JobchangeCanvas[0])
                {
                    return;
                }
                else
                {
                    currentCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, -500);
                    main.JobchangeCanvas[0].GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 500);
                    currentCanvas = main.JobchangeCanvas[0].gameObject;
                }
                break;
            case ALLY.Job.Wizard:
                if (currentCanvas == main.JobchangeCanvas[1])
                {
                    return;
                }
                else
                {
                    currentCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, -500);
                    main.JobchangeCanvas[1].GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 500);
                    currentCanvas = main.JobchangeCanvas[1].gameObject;
                }
                break;
            case ALLY.Job.Angel:
                if (currentCanvas == main.JobchangeCanvas[2])
                {
                    return;
                }
                else
                {
                    currentCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, -500);
                    main.JobchangeCanvas[2].GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 500);
                    currentCanvas = main.JobchangeCanvas[2].gameObject;
                }
                break;
        }


    }
    string currentJob;

    public string CurrentJobString()
    {
        if (main.S.job == ALLY.Job.Warrior)
        {
            currentJob = tDigit(main.WarP) + " Warrior ";
        }
        else if (main.S.job == ALLY.Job.Wizard)
        {
            currentJob = tDigit(main.WizP) + " Wizard ";
        }
        else if (main.S.job == ALLY.Job.Angel)
        {
            currentJob = tDigit(main.AngP) + " Angel ";
        }
        return currentJob;
    }

    // Update is called once per frame
    void Update () {

        if(main.GameController.currentCanvas != main.GameController.JobchangeCanvas)
        {
            return;
        }
		if(selectedJob == ALLY.Job.Novice)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
        }

        //時間があるときにappendに変えよう
        if (main.GameController.currentCanvas == main.GameController.JobchangeCanvas)
        {
            main.Texts[16].text = "  You can rebirth as a warrior with the skills you have raised, your inventory, crafts, achievements and the prestige points. Now you can gain <color=\"green\">"
    + CurrentJobString() + "prestige points</color> when you rebirth. (" + tDigit(main.SR.JP_level) + " from level, " + tDigit(main.SR.JP_enemy) + " from kills, " + tDigit(main.SR.JP_craft) + " from crafting and " + tDigit(previousPoint()) + " unspent)";
            main.Texts[17].text = "  You can rebirth as a wizard with the skills you have raised, your inventory, crafts, achievements and the prestige points. Now you can gain <color=\"green\">"
                + CurrentJobString() + "prestige points</color> when you rebirth. (" + tDigit(main.SR.JP_level) + " from level, " + tDigit(main.SR.JP_enemy) + " from kills, " + tDigit(main.SR.JP_craft) + " from crafting and " + tDigit(previousPoint()) + " unspent)";
            main.Texts[18].text = "  You can rebirth as an angel with the skills you have raised, your inventory, crafts, achievements and the prestige points. Now you can gain <color=\"green\">"
                + CurrentJobString() + "prestige points</color> when you rebirth. (" + tDigit(main.SR.JP_level) + " from level, " + tDigit(main.SR.JP_enemy) + " from kills, " + tDigit(main.SR.JP_craft) + " from crafting and " + tDigit(previousPoint()) + " unspent)";
            main.Texts[15].text = "Warrior Point\n<color=green>" + tDigit(main.tempWarP) + "</color> / " + tDigit(main.WarP);
            main.Texts[19].text = "Wizard Point\n<color=green>" + tDigit(main.tempWizP) + "</color> / " + tDigit(main.WizP);
            main.Texts[20].text = "Angel Point\n<color=green>" + tDigit(main.tempAngP) + "</color> / " + tDigit(main.AngP);

            if (main.S.SuperRebirthNum > 0)
                SuperRebirth.interactable = true;
            else
                SuperRebirth.interactable = false;
            if (main.S.InstantRebirthNum > 0)
                InstantRebirth.interactable = true;
            else
                InstantRebirth.interactable = false;
            if (main.S.ResetRebirthUpgradeNum > 0)
                ResetRebirth.interactable = true;
            else
                ResetRebirth.interactable = false;

            if (main.S.boughtSuperRebirth)
                SuperRebirth.GetComponentInChildren<TextMeshProUGUI>().text = "Super Rebirth";
            else
                SuperRebirth.GetComponentInChildren<TextMeshProUGUI>().text = "???";
            if (main.S.boughtInstantRebirth)
                InstantRebirth.GetComponentInChildren<TextMeshProUGUI>().text = "Instant";
            else
                InstantRebirth.GetComponentInChildren<TextMeshProUGUI>().text = "???";
            if (main.S.boughtResetRebirth)
                ResetRebirth.GetComponentInChildren<TextMeshProUGUI>().text = "Reset";
            else
                ResetRebirth.GetComponentInChildren<TextMeshProUGUI>().text = "???";
        }

    }

    double point;
    double previousPoint()
    {
        if (main.ally.job == ALLY.Job.Warrior)
        {
            point = main.WarP - (main.SR.JP_level + main.SR.JP_craft + main.SR.JP_enemy);
        }
        else if (main.ally.job == ALLY.Job.Wizard)
        {
            point = main.WizP - (main.SR.JP_level + main.SR.JP_craft + main.SR.JP_enemy);
        }
        else if (main.ally.job == ALLY.Job.Angel)
        {
            point = main.AngP - (main.SR.JP_level + main.SR.JP_craft + main.SR.JP_enemy);
        }

        return point;
    }
    void confirmAscend()
    {
        Instantiate(main.P_texts[18], main.DeathShowCanvas);
    }
    void confirmSuperRebirth()
    {
        Instantiate(main.P_texts[23], main.DeathShowCanvas);
    }
    void confirmInstantRebirth()
    {
        Instantiate(main.P_texts[24], main.DeathShowCanvas);
    }
    void confirmResetRebirth()
    {
        Instantiate(main.P_texts[27], main.DeathShowCanvas);
    }

    public int unleashNum()
    {
        return main.Ascends[15].tempLevel - main.S.A_level[15];
    }

    public　void AfterRebirth()
    {
        if (!main.SR.afterRebirth)//Rebirth/Rein後一回だけ呼ばれる
        {
            //呪い転生からの体液
            Curse_MC.GetMonsterFluid();
            //最初にぼたんが押された状態にする。
            switch (main.cc.CurrentCurseId)
            {
                case CurseId.road_of_warrior:
                    JobChangeButton[0].onClick.Invoke();
                    break;
                case CurseId.road_of_wizard:
                    JobChangeButton[1].onClick.Invoke();
                    break;
                case CurseId.road_of_angel:
                    JobChangeButton[2].onClick.Invoke();
                    break;
            }
            //DRの引継ぎ
            //リバース直後のみ呼ばなければいけない？
            if (main.S.isMission325Completed)
            {
                main.SR.WorkerNum = main.S.WorkerNum;
                main.SR.BuyLevel = main.S.BuyLevel;
                main.SR.CapLevel = main.S.CapLevel;
                for (int i = 0; i < main.SR.currentWorkerNum.Length; i++)
                {
                    main.SR.currentWorkerNum[i] = main.S.currentWorkerNum[i];
                }
            }
            if (!main.S.SkillSetSaveLoad)//SkillSaveを買ってなかったら
            {
                //SkillSlotSaveのリセット
                main.S.SkillSetSaveID = 0;
                for (int i = 0; i < main.S.WarSaveSkillId1.Length; i++)
                {
                    main.S.WarSaveSkillId1[i] = 0;
                    main.S.WarSaveSkillId2[i] = 0;
                    main.S.WarSaveSkillId3[i] = 0;
                    main.S.WarSaveSkillId4[i] = 0;
                    main.S.WarSaveSkillId5[i] = 0;
                    main.S.WizSaveSkillId1[i] = 0;
                    main.S.WizSaveSkillId2[i] = 0;
                    main.S.WizSaveSkillId3[i] = 0;
                    main.S.WizSaveSkillId4[i] = 0;
                    main.S.WizSaveSkillId5[i] = 0;
                    main.S.AngSaveSkillId1[i] = 0;
                    main.S.AngSaveSkillId2[i] = 0;
                    main.S.AngSaveSkillId3[i] = 0;
                    main.S.AngSaveSkillId4[i] = 0;
                    main.S.AngSaveSkillId5[i] = 0;
                }
            }
            else//買っていたら
            {
                switch (main.S.job)
                {
                    case ALLY.Job.Warrior:
                        main.SR.P_SwordAttack = main.S.P_SwordAttack;
                        main.SR.P_ShieldAttack = main.S.P_ShieldAttack;
                        main.SR.P_Block = main.S.P_Block;
                        break;
                    case ALLY.Job.Wizard:
                        main.SR.P_StaffAttack = main.S.P_StaffAttack;
                        main.SR.P_fire = main.S.P_fire;
                        main.SR.P_ice = main.S.P_ice;
                        main.SR.P_thunder = main.S.P_thunder;
                        break;
                    case ALLY.Job.Angel:
                        main.SR.P_GodBless = main.S.P_GodBless;
                        main.SR.P_AngelDistruction = main.S.P_AngelDistruction;
                        main.SR.P_HoldWing = main.S.P_HoldWing;
                        break;
                }

            }

            if (main.S.AutoExpandAlchemy)
            {
                if (!main.S.isAuto)
                    main.alchemyController.ChangeAuto();
            }
            main.SR.afterRebirth = true;
        }
    }
    public IEnumerator BeforeRebirth()
    {
        main.S.toggleSave[6] = true;//AutoProgressは常にON
        main.toggles[6].isOn = true;
        if (main.S.SkillSetSaveLoad)//SkillSaveを買っていたらStanceを引き継ぐ
        {
            switch (main.S.job)
            {
                case ALLY.Job.Warrior:
                    main.S.P_SwordAttack = main.SR.P_SwordAttack;
                    main.S.P_ShieldAttack = main.SR.P_ShieldAttack;
                    main.S.P_Block = main.SR.P_Block;
                    break;
                case ALLY.Job.Wizard:
                    main.S.P_StaffAttack = main.SR.P_StaffAttack;
                    main.S.P_fire = main.SR.P_fire;
                    main.S.P_ice = main.SR.P_ice;
                    main.S.P_thunder = main.SR.P_thunder;
                    break;
                case ALLY.Job.Angel:
                    main.S.P_GodBless = main.SR.P_GodBless;
                    main.S.P_AngelDistruction = main.SR.P_AngelDistruction;
                    main.S.P_HoldWing = main.SR.P_HoldWing;
                    break;
            }
        }

        if (!main.S.SuperQueueMemory)//SuperQueueMemoryを買っていなかったら消す
        {
            for (int i = 0; i < main.StoneUpgrade.Length; i++)
            {
                main.S.isSuperQueueAssignedforStoneUpgrade[i] = false;
            }
            for (int i = 0; i < main.CristalUpgrade.Length; i++)
            {
                main.S.isSuperQueueAssignedforCrystalUpgrade[i] = false;
            }
            for (int i = 0; i < main.LeafUpgrade.Length; i++)
            {
                main.S.isSuperQueueAssignedforLeafUpgrade[i] = false;
            }
            for (int i = 0; i < main.StatusUpgrade.Length; i++)
            {
                main.S.isSuperQueueAssignedforStatusUpgrade[i] = false;
            }
            for (int i = 0; i < main.bankCtrl.BankUpgrades.Length; i++)
            {
                main.S.isSuperQueueSBAssigned[i] = false;
            }
        }
        if (main.S.isMission325Completed)
        {
            main.S.WorkerNum = main.SR.WorkerNum;
            main.S.BuyLevel = main.SR.BuyLevel;
            main.S.CapLevel = main.SR.CapLevel;
            for (int i = 0; i < main.SR.currentWorkerNum.Length; i++)
            {
                main.S.currentWorkerNum[i] = main.SR.currentWorkerNum[i];
            }
        }
        yield return null;
    }

    public bool isStartedRebirth;
    public IEnumerator doAscension()
    {
        isStartedRebirth = true;
        StopCoroutine(main.saveCtrl.save);
        isAscend = false;
        main.S.AscendNum++;
        main.S.AscendNumWhileReincarnation++;
        for (int i = 0; i < unleashNum(); i++)
        {
            main.skillSetController.UnleashGrobalSkillSlot();
        }
       foreach(A_UPGRADE upgrades in main.Ascends)
        {
            main.S.A_level[upgrades.upgradeId] = upgrades.tempLevel;
            //upgrades.tempLevel = 0;
        }
        main.S.consumedWarP += (main.WarP - main.tempWarP);
        main.WarP = main.tempWarP;
        main.S.consumedWizP += (main.WizP - main.tempWizP);
        main.WizP = main.tempWizP;
        main.S.consumedAngP += (main.AngP - main.tempAngP);
        main.AngP = main.tempAngP;
        //foreach (ARTIFACT equipment in main.NewArtifacts)
        //{
        //    equipment.isEquipped = false;
        //}
        yield return BeforeRebirth();
        main.S.job = selectedJob;
        //必ず直前に1回セーブする．
        main.saveCtrl.setSaveKey();
        yield return new WaitForSeconds(0.3f);
        //消す処理
        PlayerPrefs.DeleteKey(keyList.resetSaveKey);
        SceneManager.LoadScene("main");
    }
    
    //ここにSuperRebirthの処理を書く
    public IEnumerator doSuperRebirth()
    {
        main.S.SuperRebirthNum -= 1;
        StopCoroutine(main.saveCtrl.save);
        isAscend = false;
        main.S.AscendNum++;
        main.S.AscendNumWhileReincarnation++;
        //main.S.SRP += 1;
        main.S.SRPfromRebirth += 1;
        for (int i = 0; i < unleashNum(); i++)
        {
            main.skillSetController.UnleashGrobalSkillSlot();
        }
        foreach (A_UPGRADE upgrades in main.Ascends)
        {
            main.S.A_level[upgrades.upgradeId] = upgrades.tempLevel;
            //upgrades.tempLevel = 0;
        }
        main.S.consumedWarP += (main.WarP - main.tempWarP);
        main.WarP = main.tempWarP;
        main.S.consumedWizP += (main.WizP - main.tempWizP);
        main.WizP = main.tempWizP;
        main.S.consumedAngP += (main.AngP - main.tempAngP);
        main.AngP = main.tempAngP;
        //foreach (ARTIFACT equipment in main.NewArtifacts)
        //{
        //    equipment.isEquipped = false;
        //}
        yield return BeforeRebirth();
        main.S.job = selectedJob;
        yield return BeforeSuperRebirth();
        //必ず直前に1回セーブする．
        main.saveCtrl.setSaveKey();
        yield return new WaitForSeconds(0.3f);
        PlayerPrefs.DeleteKey(keyList.resetSaveKey);
        SceneManager.LoadScene("main");
    }

    public IEnumerator BeforeSuperRebirth()
    {
        main.S.isSuperRebirth = true;
        main.S.tempLevel = main.ally.saveLevel;
        for (int i = 0; i < main.StoneUpgrade.Length; i++)
        {
            main.S.stoneUpgradeLevel[i] = main.StoneUpgrade[i].level;
        }
        for (int i = 0; i < main.CristalUpgrade.Length; i++)
        {
            main.S.crystalUpgradeLevel[i] = main.CristalUpgrade[i].level;
        }
        for (int i = 0; i < main.LeafUpgrade.Length; i++)
        {
            main.S.leafUpgradeLevel[i] = main.LeafUpgrade[i].level;
        }
        for (int i = 0; i < main.StatusUpgrade.Length; i++)
        {
            main.S.statusUpgradeLevel[i] = main.StatusUpgrade[i].level;
        }
        main.S.stone = main.SR.stone;
        main.S.cristal = main.SR.cristal;
        main.S.leaf = main.SR.leaf;
        main.S.stoneGoldLevel = main.SR.stoneGoldLevel;
        main.S.crystalGoldLevel = main.SR.crystalGoldLevel;
        main.S.leafGoldLevel = main.SR.leafGoldLevel;
        main.S.stoneExp = main.SR.stoneExp;
        main.S.crystalExp = main.SR.crystalExp;
        main.S.leafExp = main.SR.leafExp;
        main.S.WorkerNum = main.SR.WorkerNum;
        main.S.BuyLevel = main.SR.BuyLevel;
        main.S.CapLevel = main.SR.CapLevel;
        for (int i = 0; i < main.SR.currentWorkerNum.Length; i++)
        {
            main.S.currentWorkerNum[i] = main.SR.currentWorkerNum[i];
        }
        main.S.R_HP     = main.SR.R_HP;
        main.S.R_MP     = main.SR.R_MP;
        main.S.R_ATK    = main.SR.R_ATK;
        main.S.R_DEF    = main.SR.R_DEF;
        main.S.R_MATK   = main.SR.R_MATK;
        main.S.R_MDEF   = main.SR.R_MDEF;
        main.S.R_SPD    = main.SR.R_SPD;
        main.S.R_GOLD   = main.SR.R_GOLD;
        main.S.R_EXP    = main.SR.R_EXP;
        main.S.R_stone  = main.SR.R_stone;
        main.S.R_crystal= main.SR.R_crystal;
        main.S.R_leaf   = main.SR.R_leaf;
        main.S.R_drop   = main.SR.R_drop;
        main.S.spiritWar = main.SR.spiritWar;
        main.S.spiritWiz = main.SR.spiritWiz;
        main.S.spiritAng = main.SR.spiritAng;
        //Alchemy
        main.S.SalchemyQuantity = main.SR.alchemyQuantity;
        for (int i = 0; i < main.S.SwaterCap.Length; i++)
        {
            main.S.SwaterCap[i] = main.SR.waterCap[i];
        }
        for (int i = 0; i < main.S.ScurrentWater.Length; i++)
        {
            main.S.ScurrentWater[i] = main.SR.currentWater[i];
        }
        for (int i = 0; i < main.S.SwaterValue.Length; i++)
        {
            main.S.SwaterValue[i] = main.SR.waterValue[i];
        }
        main.S.SwaterAddDPSByPotion = main.SR.waterAddDPSByPotion;
        main.S.SreachedCap = main.SR.reachedCap;
        main.S.DPSbankFactor = main.SR.DPSBankFactor;
    yield return null;
    }

    public void AfterSuperRebirth()
    {

        if (main.S.isSuperRebirth)
        {
            main.ally.saveLevel = main.S.tempLevel;
            for (int i = 0; i < main.StoneUpgrade.Length; i++)
            {
                main.StoneUpgrade[i].level = main.S.stoneUpgradeLevel[i];
            }
            for (int i = 0; i < main.CristalUpgrade.Length; i++)
            {
                main.CristalUpgrade[i].level = main.S.crystalUpgradeLevel[i];
            }
            for (int i = 0; i < main.LeafUpgrade.Length; i++)
            {
                main.LeafUpgrade[i].level = main.S.leafUpgradeLevel[i];
            }
            for (int i = 0; i < main.StatusUpgrade.Length; i++)
            {
                main.StatusUpgrade[i].level = main.S.statusUpgradeLevel[i];
            }
            main.SR.stone = main.S.stone;
            main.SR.cristal = main.S.cristal;
            main.SR.leaf = main.S.leaf;
            main.SR.stoneGoldLevel = main.S.stoneGoldLevel;
            main.SR.crystalGoldLevel = main.S.crystalGoldLevel;
            main.SR.leafGoldLevel = main.S.leafGoldLevel;
            main.SR.stoneExp = main.S.stoneExp;
            main.SR.crystalExp = main.S.crystalExp;
            main.SR.leafExp = main.S.leafExp;
            main.SR.WorkerNum = main.S.WorkerNum;
            main.SR.BuyLevel = main.S.BuyLevel;
            main.SR.CapLevel = main.S.CapLevel;
            for (int i = 0; i < main.SR.currentWorkerNum.Length; i++)
            {
                main.SR.currentWorkerNum[i] = main.S.currentWorkerNum[i];
            }
            main.SR.R_HP = main.S.R_HP;
            main.SR.R_MP = main.S.R_MP;
            main.SR.R_ATK = main.S.R_ATK;
            main.SR.R_DEF = main.S.R_DEF;
            main.SR.R_MATK = main.S.R_MATK;
            main.SR.R_MDEF = main.S.R_MDEF;
            main.SR.R_SPD = main.S.R_SPD;
            main.SR.R_GOLD = main.S.R_GOLD;
            main.SR.R_EXP = main.S.R_EXP;
            main.SR.R_stone = main.S.R_stone;
            main.SR.R_crystal = main.S.R_crystal;
            main.SR.R_leaf = main.S.R_leaf;
            main.SR.R_drop = main.S.R_drop;
            main.SR.spiritWar = main.S.spiritWar;
            main.SR.spiritWiz = main.S.spiritWiz;
            main.SR.spiritAng = main.S.spiritAng;

            main.SR.alchemyQuantity = main.S.SalchemyQuantity;
            for (int i = 0; i < main.S.SwaterCap.Length; i++)
            {
                main.SR.waterCap[i] = main.S.SwaterCap[i];
            }
            for (int i = 0; i < main.S.ScurrentWater.Length; i++)
            {
                main.SR.currentWater[i] = main.S.ScurrentWater[i];
            }
            for (int i = 0; i < main.S.SwaterValue.Length; i++)
            {
                main.SR.waterValue[i] = main.S.SwaterValue[i];
            }

            main.SR.waterAddDPSByPotion = main.S.SwaterAddDPSByPotion;
            main.SR.reachedCap = main.S.SreachedCap;
            main.SR.DPSBankFactor = main.S.DPSbankFactor;

            //for (int i = 0; i < main.ally.Level(); i++)
            //{
            //    main.ally.GetAscendPointForSuperRebirth(i+1);
            //}
            //for (int i = 0; i < main.ally.Level(); i++)
            //{
            //    main.ally.GetAscendPointForSuperRebirth(i+1);
            //}

            main.S.isSuperRebirth = false;
        }
    }

}
