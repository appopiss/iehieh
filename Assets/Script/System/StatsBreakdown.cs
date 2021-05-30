using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;

public class StatsBreakdown : BASE {

    public Button ToSystem;
    public Button ToStatsBreakDown;
    public GameObject SystemCanvas;
    public GameObject StatsBreakDownCanvas;
    public TextMeshProUGUI showValueText;
    public TextMeshProUGUI totalValueText;
    public TextMeshProUGUI nameText;
    public Button[] statsModeButtons;
    public enum StatusKind {
        hp,
        mp,
        atk,
        matk,
        def,
        mdef,
        spd,
        gold,
        exp,
        drop,
        prof,
        goldcap,
    }
    public StatusKind kind;

    public void GoToSystem()
    {
        StatsBreakDownCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, -1000);
        main.GameController.SetAllImageAndText(StatsBreakDownCanvas, false);
        SystemCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 1000);
    }

    public void GoToStatsBreakDown()
    {
        SystemCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, -1000);
        main.GameController.SetAllImageAndText(StatsBreakDownCanvas, true);
        StatsBreakDownCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 1000);
        statsModeButtons[0].onClick.Invoke();
    }

    // Use this for initialization
    void Awake () {
		StartBASE();
        ToSystem.onClick.AddListener(GoToSystem);
        ToStatsBreakDown.onClick.AddListener(GoToStatsBreakDown);
        statsModeButtons[0].onClick.AddListener(() => { kind = StatusKind.hp; changeStats(); });
        statsModeButtons[1].onClick.AddListener(() => {kind = StatusKind.mp; changeStats(); });
        statsModeButtons[2].onClick.AddListener(() => {kind = StatusKind.atk; changeStats(); });
        statsModeButtons[3].onClick.AddListener(() => {kind = StatusKind.matk; changeStats(); });
        statsModeButtons[4].onClick.AddListener(() => {kind = StatusKind.def; changeStats(); });
        statsModeButtons[5].onClick.AddListener(() => {kind = StatusKind.mdef; changeStats(); });
        statsModeButtons[6].onClick.AddListener(() => {kind = StatusKind.spd; changeStats(); });
        statsModeButtons[7].onClick.AddListener(() => {kind = StatusKind.gold; changeStats(); });
        statsModeButtons[8].onClick.AddListener(() => {kind = StatusKind.exp; changeStats(); });
        statsModeButtons[9].onClick.AddListener(() => {kind = StatusKind.drop; changeStats(); });
        statsModeButtons[10].onClick.AddListener(() =>{ kind = StatusKind.prof; changeStats(); });
        statsModeButtons[11].onClick.AddListener(() => { kind = StatusKind.goldcap; changeStats(); });
        statsModeButtons[0].onClick.Invoke();
    }

	// Use this for initialization
	void Start () {
        // main.GameController.SetAllImageAndText(StatsBreakDownCanvas, false);
      
    }
	
    void changeStats()
    {
        if (main.GameController.currentCanvas == main.GameController.InventoryCanvas)
        {
            switch (kind)
            {
                case StatusKind.hp:
                    nameText.text = showHP()[0];
                    showValueText.text = showHP()[1];
                    totalValueText.text = tDigit(main.ally.HP()) + "    <size=12>( Regen : " + tDigit(main.ally.HpRegen()) + " / s )";
                    break;
                case StatusKind.mp:
                    nameText.text = showMP()[0];
                    showValueText.text = showMP()[1];
                    totalValueText.text = tDigit(main.ally.MP()) + "    <size=12>( Regen : " + tDigit(main.ally.MpRegen()+main.skillSetController.GainMPDPS()) + " / s )";
                    break;
                case StatusKind.atk:
                    nameText.text = showATK()[0];
                    showValueText.text = showATK()[1];
                    totalValueText.text = tDigit(main.ally.Atk());
                    break;
                case StatusKind.matk:
                    nameText.text = showMATK()[0];
                    showValueText.text = showMATK()[1];
                    totalValueText.text = tDigit(main.ally.MAtk());
                    break;
                case StatusKind.def:
                    nameText.text = showDEF()[0];
                    showValueText.text = showDEF()[1];
                    totalValueText.text = tDigit(main.ally.Def());
                    break;
                case StatusKind.mdef:
                    nameText.text = showMDEF()[0];
                    showValueText.text = showMDEF()[1];
                    totalValueText.text = tDigit(main.ally.MDef());
                    break;
                case StatusKind.spd:
                    nameText.text = showSPD()[0];
                    showValueText.text = showSPD()[1];
                    totalValueText.text = tDigit(main.ally.Speed());
                    break;
                case StatusKind.gold:
                    nameText.text = showGOLD()[0];
                    showValueText.text = showGOLD()[1];
                    totalValueText.text = TotalGold();
                    break;
                case StatusKind.exp:
                    nameText.text = showEXP()[0];
                    showValueText.text = showEXP()[1];
                    totalValueText.text = TotalExp();
                    break;
                case StatusKind.drop:
                    nameText.text = showDrop()[0];
                    showValueText.text = showDrop()[1];
                    totalValueText.text = TotalDrop();
                    break;
                case StatusKind.prof:
                    nameText.text = showProf()[0];
                    showValueText.text = showProf()[1];
                    totalValueText.text = percent(profFactor());
                    break;
                case StatusKind.goldcap:
                    nameText.text = showGOLDCap()[0];
                    showValueText.text = showGOLDCap()[1];
                    totalValueText.text = TotalGoldCap();
                    break;

            }

        }
    }

    public string[] showHP()
    {
        string nameText = "";
        string valueText = "";
        nameText += "<size=14>Additive HP<size=10>";

        nameText += "\n - " + main.S.job + " Base ";
        nameText += "\n - Level Up";
        nameText += "\n - Upgrade";
        nameText += "\n - Equipment";
        nameText += "\n - Alchemy";
        nameText += "\n - Artifact";

        nameText += "\n\n<size=14>Multiplicative HP<size=10>";

        nameText += "\n - Skill Passive Effect";
        nameText += "\n - Equipment";
        nameText += "\n - Rebirth ";
        nameText += "\n - Reincarnation";
        nameText += "\n - Challenge Boss";
        nameText += "\n - Bestiary ";
        nameText += "\n - Quests";
        nameText += "\n - Potion";
        nameText += "\n - Buff";
        nameText += "\n - Mission Milestone";
        nameText += "\n - Artifact";

        valueText += "<size=14>" + tDigit(main.ally.addHP()) + "<size=10>";

        valueText += "\n   " + tDigit(main.ally.initialHp);
        valueText += "\n+ " + tDigit(main.ally.L_HP());
        valueText += "\n+ " + tDigit(main.SR.R_HP + main.ally.HP_ritualUpgrade());
        valueText += "\n+ " + tDigit(main.ArtifactFactor.ADD_HP());
        valueText += "\n+ " + tDigit(main.S.vitalityLevel);
        valueText += "\n+ " + tDigit(ArtifactBonus.HP_ADD);

        valueText += "\n\n<size=14>" + percent(main.ally.mulHP()) + "<size=10>";

        valueText += "\n   " + percent(main.ally.HP_passiveSkill());
        valueText += "\n* " + percent((1+main.ArtifactFactor.MUL_HP()) * LegendaryEffect.StatsBonus());
        valueText += "\n* " + percent(1+main.Ascends[2].calculateCurrentValue());
        valueText += "\n* " + percent(1 + main.rein.R_factor.StatusIncrease());
        valueText += "\n* " + percent(1+main.QuestCtrl.R_slime());
        valueText += "\n* " + percent(1+main.ally.Mile_hp);
        valueText += "\n* " + percent(1 + main.quests[(int)ACHIEVEMENT.QuestList.journey].clearNum * 0.1 + main.quests[(int)ACHIEVEMENT.QuestList.P_leather].clearNum * 0.01);
        valueText += "\n* " + percent(1+main.S.hpPortion);
        valueText += "\n* " + percent(1+main.ally.buffHpFactor);
        valueText += "\n* " + percent(main.MissionMileStoneHidden.StatsFactor());
        valueText += "\n* " + percent(1 + ArtifactBonus.HP_MUL);
        return new string[] { nameText,valueText};
    }


    public string[] showMP()
    {
        string nameText = "";
        string valueText = "";

        nameText += "<size=14>Additive MP<size=10>";

        nameText += "\n - " + main.S.job + " Base ";
        nameText += "\n - Level Up";
        nameText += "\n - Upgrade";
        nameText += "\n - Equipment ";
        nameText += "\n - Alchemy ";
        nameText += "\n - Artifact";

        nameText += "\n\n<size=14>Multiplicative MP<size=10>";

        nameText += "\n - Skill Passive Effect";
        nameText += "\n - Equipment";
        nameText += "\n - Rebirth ";
        nameText += "\n - Reincarnation";
        nameText += "\n - Challenge Boss";
        //nameText += "\n - MileStone ";
        //nameText += "\n - Quests";
        nameText += "\n - Potion";
        //nameText += "\n - Buff";
        nameText += "\n - Mission Milestone";
        nameText += "\n - Artifact";

        valueText += "<size=14>" + tDigit(main.ally.addMP()) + "<size=10>";

        valueText += "\n   " + tDigit(main.ally.initialMp);
        valueText += "\n+ " + tDigit(main.ally.L_MP());
        valueText += "\n+ " + tDigit(main.SR.R_MP + main.ally.MP_ritualUpgrade());
        valueText += "\n+ " + tDigit(main.ArtifactFactor.ADD_MP());
        valueText += "\n+ " + tDigit(main.S.vitalityLevel);
        valueText += "\n+ " + tDigit(ArtifactBonus.MP_ADD);

        valueText += "\n\n<size=14>" + percent(main.ally.mulMP()) + "<size=10>";

        valueText += "\n   " + percent(main.ally.MP_passiveSkill());
        valueText += "\n* " + percent((1 + main.ArtifactFactor.MUL_MP()) * LegendaryEffect.StatsBonus());
        valueText += "\n* " + percent(1 + main.Ascends[7].calculateCurrentValue());
        valueText += "\n* " + percent(1 + main.rein.R_factor.StatusIncrease());
        valueText += "\n* " + percent(1 + main.QuestCtrl.R_octobaddie());
        //valueText += "\n* " + percent(1 + main.ally.Mile_mp);
        //valueText += "\n* " + percent(1 + main.quests[(int)ACHIEVEMENT.QuestList.journey].clearNum * 0.1);
        valueText += "\n* " + percent(1 + main.S.mpPortion);
        //valueText += "\n* " + percent(1 + main.ally.buffHpFactor);
        valueText += "\n* " + percent(main.MissionMileStoneHidden.StatsFactor());
        valueText += "\n* " + percent(1 + ArtifactBonus.MP_MUL);

        return new string[] { nameText, valueText };
    }

    public string[] showATK()
    {
        string nameText = "";
        string valueText = "";
        nameText += "<size=14>Additive ATK<size=10>";

        nameText += "\n - " + main.S.job + " Base ";
        nameText += "\n - Level Up";
        nameText += "\n - Upgrade";
        nameText += "\n - Equipment ";
        nameText += "\n - Alchemy ";
        nameText += "\n - Slime Bank";
        nameText += "\n - Buff";
        nameText += "\n - Artifact";

        nameText += "\n\n<size=14>Multiplicative ATK<size=10>";

        nameText += "\n - Skill Passive Effect";
        nameText += "\n - Equipment";
        nameText += "\n - Rebirth ";
        nameText += "\n - Reincarnation";
        nameText += "\n - Challenge Boss";
        //nameText += "\n - MileStone ";
        nameText += "\n - Stance";
        nameText += "\n - Debuff";
        nameText += "\n - Mission Milestone";
        nameText += "\n - Artifact";

        valueText += "<size=14>" + tDigit(main.ally.addATK()) + "<size=10>";

        valueText += "\n   " + tDigit(main.ally.initialAtk);
        valueText += "\n+ " + tDigit(main.ally.L_ATK());
        valueText += "\n+ " + tDigit(main.SR.R_ATK + main.ally.ATK_ritualUpgrade());
        valueText += "\n+ " + tDigit(main.ArtifactFactor.ADD_ATK());
        valueText += "\n+ " + tDigit(main.S.muscleLevel);
        valueText += "\n+ " + tDigit(main.ally.ATK_bank());
        valueText += "\n+ " + tDigit(main.ally.buffAtkFactor);
        valueText += "\n+ " + tDigit(ArtifactBonus.ATK_ADD);

        valueText += "\n\n<size=14>" + percent(main.ally.mulATK()) + "<size=10>";

        valueText += "\n   " + percent(main.ally.ATK_passiveSkill());
        valueText += "\n* " + percent((1 + main.ArtifactFactor.MUL_ATK()) * LegendaryEffect.StatsBonus());
        valueText += "\n* " + percent(1 + main.Ascends[3].calculateCurrentValue());
        valueText += "\n* " + percent(1 + main.rein.R_factor.StatusIncrease());
        valueText += "\n* " + percent(1 + main.QuestCtrl.R_spider());
        //valueText += "\n* " + percent(1 + main.ally.Mile_atk);
        valueText += "\n* " + percent(1 + main.ally.warriorPassiveSwordFactor);
        valueText += "\n* " + percent(main.ally.tempAtkFactor);
        valueText += "\n* " + percent(main.MissionMileStoneHidden.StatsFactor());
        valueText += "\n* " + percent(1 + ArtifactBonus.ATK_MUL);

        return new string[] { nameText, valueText };
    }

    public string[] showMATK()
    {
        string nameText = "";
        string valueText = "";
        nameText += "<size=14>Additive MATK<size=10>";

        nameText += "\n - " + main.S.job + " Base ";
        nameText += "\n - Level Up";
        nameText += "\n - Upgrade";
        nameText += "\n - Equipment ";
        nameText += "\n - Alchemy ";
        nameText += "\n - Slime Bank";
        nameText += "\n - Buff";
        nameText += "\n - Artifact";

        nameText += "\n\n<size=14>Multiplicative MATK<size=10>";

        nameText += "\n - Skill Passive Effect";
        nameText += "\n - Equipment";
        nameText += "\n - Rebirth ";
        nameText += "\n - Reincarnation";
        nameText += "\n - Challenge Boss";
        //nameText += "\n - MileStone ";
        nameText += "\n - Stance";
        nameText += "\n - Debuff";
        nameText += "\n - Mission Milestone";
        nameText += "\n - Artifact";

        valueText += "<size=14>" + tDigit(main.ally.addMATK()) + "<size=10>";

        valueText += "\n   " + tDigit(main.ally.initialMAtk);
        valueText += "\n+ " + tDigit(main.ally.L_MATK());
        valueText += "\n+ " + tDigit(main.SR.R_MATK + main.ally.MATK_ritualUpgrade());
        valueText += "\n+ " + tDigit(main.ArtifactFactor.ADD_MATK());
        valueText += "\n+ " + tDigit(main.S.wisdomLevel);
        valueText += "\n+ " + tDigit(main.ally.MATK_bank());
        valueText += "\n+ " + tDigit(main.ally.buffMAtkFactor);
        valueText += "\n+ " + tDigit(ArtifactBonus.MATK_ADD);

        valueText += "\n\n<size=14>" + percent(main.ally.mulMATK()) + "<size=10>";

        valueText += "\n   " + percent(main.ally.MATK_passiveSkill());
        valueText += "\n* " + percent((1 + main.ArtifactFactor.MUL_MATK()) * LegendaryEffect.StatsBonus());
        valueText += "\n* " + percent(1 + main.Ascends[8].calculateCurrentValue());
        valueText += "\n* " + percent(1 + main.rein.R_factor.StatusIncrease());
        valueText += "\n* " + percent(1 + main.QuestCtrl.R_fairy());
        //valueText += "\n* " + percent(1 + main.ally.Mile_matk);
        valueText += "\n* " + percent(1 + main.ally.wizardPassiveStaffFactor);
        valueText += "\n* " + percent(main.ally.tempMatkFactor);
        valueText += "\n* " + percent(main.MissionMileStoneHidden.StatsFactor());
        valueText += "\n* " + percent(1 + ArtifactBonus.MATK_MUL);

        return new string[] { nameText, valueText };
    }

    public string[] showDEF()
    {
        string nameText = "";
        string valueText = "";
        nameText += "<size=14>Additive DEF<size=10>";

        nameText += "\n - " + main.S.job + " Base ";
        nameText += "\n - Level Up";
        nameText += "\n - Upgrade";
        nameText += "\n - Equipment ";
        nameText += "\n - Alchemy ";
        nameText += "\n - Buff";
        nameText += "\n - Artifact";

        nameText += "\n\n<size=14>Multiplicative DEF<size=10>";

        nameText += "\n - Skill Passive Effect";
        nameText += "\n - Equipment";
        nameText += "\n - Rebirth ";
        nameText += "\n - Reincarnation";
        nameText += "\n - Challenge Boss";
        //nameText += "\n - MileStone ";
        nameText += "\n - Stance";
        nameText += "\n - Debuff";
        nameText += "\n - Mission Milestone";
        nameText += "\n - Artifact";

        valueText += "<size=14>" + tDigit(main.ally.addDEF()) + "<size=10>";

        valueText += "\n   " + tDigit(main.ally.initialDef);
        valueText += "\n+ " + tDigit(main.ally.L_DEF());
        valueText += "\n+ " + tDigit(main.SR.R_DEF + main.ally.DEF_ritualUpgrade());
        valueText += "\n+ " + tDigit(main.ArtifactFactor.ADD_DEF());
        valueText += "\n+ " + tDigit(main.S.muscleLevel);
        valueText += "\n+ " + tDigit(main.ally.buffDefFactor);
        valueText += "\n+ " + tDigit(ArtifactBonus.DEF_ADD);

        valueText += "\n\n<size=14>" + percent(main.ally.mulDEF()) + "<size=10>";

        valueText += "\n   " + percent(main.ally.DEF_passiveSkill());
        valueText += "\n* " + percent((1 + main.ArtifactFactor.MUL_DEF()) * LegendaryEffect.StatsBonus());
        valueText += "\n* " + percent(1 + main.Ascends[4].calculateCurrentValue());
        valueText += "\n* " + percent(1 + main.rein.R_factor.StatusIncrease());
        valueText += "\n* " + percent(1 + main.QuestCtrl.R_golem());
        //valueText += "\n* " + percent(1 + main.ally.Mile_def);
        valueText += "\n* " + percent(1 + main.ally.warriorPassiveSwordFactor - main.ally.warriorPassiveShieldFactor);
        valueText += "\n* " + percent(main.ally.tempDefFactor);
        valueText += "\n* " + percent(main.MissionMileStoneHidden.StatsFactor());
        valueText += "\n* " + percent(1 + ArtifactBonus.DEF_MUL);

        return new string[] { nameText, valueText };
    }

    public string[] showMDEF()
    {
        string nameText = "";
        string valueText = "";
        nameText += "<size=14>Additive MDEF<size=10>";

        nameText += "\n - " + main.S.job + " Base ";
        nameText += "\n - Level Up";
        nameText += "\n - Upgrade";
        nameText += "\n - Equipment ";
        nameText += "\n - Alchemy ";
        nameText += "\n - Buff";
        nameText += "\n - Artifact";

        nameText += "\n\n<size=14>Multiplicative MDEF<size=10>";

        nameText += "\n - Skill Passive Effect";
        nameText += "\n - Equipment";
        nameText += "\n - Rebirth ";
        nameText += "\n - Reincarnation";
        nameText += "\n - Challenge Boss";
        //nameText += "\n - MileStone ";
        nameText += "\n - Stance";
        nameText += "\n - Debuff";
        nameText += "\n - Mission Milestone";
        nameText += "\n - Artifact";

        valueText += "<size=14>" + tDigit(main.ally.addMDEF()) + "<size=10>";

        valueText += "\n   " + tDigit(main.ally.initialMDef);
        valueText += "\n+ " + tDigit(main.ally.L_MDEF());
        valueText += "\n+ " + tDigit(main.SR.R_MDEF + main.ally.MDEF_ritualUpgrade());
        valueText += "\n+ " + tDigit(main.ArtifactFactor.ADD_MDEF());
        valueText += "\n+ " + tDigit(main.S.wisdomLevel);
        valueText += "\n+ " + tDigit(main.ally.buffMDefFactor);
        valueText += "\n+ " + tDigit(ArtifactBonus.MDEF_ADD);


        valueText += "\n\n<size=14>" + percent(main.ally.mulMDEF()) + "<size=10>";

        valueText += "\n   " + percent(main.ally.MDEF_passiveSkill());
        valueText += "\n* " + percent((1 + main.ArtifactFactor.MUL_MDEF()) * LegendaryEffect.StatsBonus());
        valueText += "\n* " + percent(1 + main.Ascends[9].calculateCurrentValue());
        valueText += "\n* " + percent(1 + main.rein.R_factor.StatusIncrease());
        valueText += "\n* " + percent(1 + main.QuestCtrl.R_golem());
        //valueText += "\n* " + percent(1 + main.ally.Mile_mdef);
        valueText += "\n* " + percent(1 - main.ally.wizardPassiveStaffFactor + main.ally.warriorPassiveShieldFactor);
        valueText += "\n* " + percent(main.ally.tempMdefFactor);
        valueText += "\n* " + percent(main.MissionMileStoneHidden.StatsFactor());
        valueText += "\n* " + percent(1 + ArtifactBonus.MDEF_MUL);

        return new string[] { nameText, valueText };
    }

    public string[] showSPD()
    {
        string nameText = "";
        string valueText = "";
        nameText += "<size=14>Additive SPD<size=10>";

        nameText += "\n - " + main.S.job + " Base ";
        nameText += "\n - Level Up";
        nameText += "\n - Upgrade";
        nameText += "\n - Equipment ";
        nameText += "\n - Alchemy ";

        nameText += "\n\n<size=14>Multiplicative SPD<size=10>";

        nameText += "\n - Skill Passive Effect";
        nameText += "\n - Equipment";
        nameText += "\n - Rebirth ";
        nameText += "\n - Reincarnation";
        nameText += "\n - Challenge Boss";
        //nameText += "\n - MileStone ";
        nameText += "\n - Buff";
        nameText += "\n - Mission Milestone";

        nameText += "\n\n<size=14>Bonus SPD<size=10>";

        nameText += "\n - Spicy Potion";

        valueText += "<size=14>" + tDigit(main.ally.addSPD()) + "<size=10>";

        valueText += "\n   " + tDigit(main.ally.initialSpeed);
        valueText += "\n+ " + tDigit(main.ally.L_SPD());
        valueText += "\n+ " + tDigit(main.SR.R_SPD + main.ally.SPD_ritualUpgrade());
        valueText += "\n+ " + tDigit(main.ArtifactFactor.ADD_SPD());
        valueText += "\n+ " + tDigit(main.S.agilityLevel);


        valueText += "\n\n<size=14>" + percent(main.ally.mulSPD()) + "<size=10>";

        valueText += "\n   " + percent(main.ally.SPD_passiveSkill());
        valueText += "\n* " + percent((1 + main.ArtifactFactor.MUL_SPD()) * LegendaryEffect.StatsBonus());
        valueText += "\n* " + percent(1 + main.Ascends[10].calculateCurrentValue());
        valueText += "\n* " + percent(1 + main.rein.R_factor.StatusIncrease());
        valueText += "\n* " + percent(1 + main.QuestCtrl.R_bananoon());
        //valueText += "\n* " + percent(1 + main.ally.Mile_spd);
        valueText += "\n* " + percent(1 + main.ally.buffSpdFactor);
        valueText += "\n* " + percent(main.MissionMileStoneHidden.StatsFactor());

        valueText += "\n\n<size=14>+ " + tDigit(main.ally.buffSpdFactor2) + "<size=10>";

        valueText += "\n+ " + tDigit(main.ally.buffSpdFactor2);

        return new string[] { nameText, valueText };
    }

    public string[] showGOLD()
    {
        string nameText = "";
        string valueText = "";

        nameText += "<size=14>Multiplicative Gold<size=10>";

        nameText += "\n - Skill Passive Effect";
        nameText += "\n - Equipment";
        nameText += "\n - Rebirth ";
        nameText += "\n - Dark Ritual ";
        //nameText += "\n - MileStone ";
        nameText += "\n - Buff";
        nameText += "\n - IEB Bonus";
        nameText += "\n - DLC";
        nameText += "\n - Artifact";

        nameText += "\n\n<size=14>Bonus Gold<size=10>";

        nameText += "\n - Upgrade";
        nameText += "\n - Equipment";
        nameText += "\n - Reincarnation";
        nameText += "\n - DLC";

        valueText += "<size=14>" + percent(mulGold()) + "<size=10>";

        valueText += "\n   " + percent(1+GOLD_passiveSkill());
        valueText += "\n* " + percent(1 + main.ArtifactFactor.GOLD());
        valueText += "\n* " + percent(1 + main.Ascends[13].calculateCurrentValue());
        valueText += "\n* " + percent(1 + main.jems[(int)JEM.ID.GoldGem].Effect());
        //valueText += "\n* " + percent(1 + main.ally.Mile_gold);
        if (main.ally.isBuff[(int)Main.Buff.gold]) 
            valueText += "\n* " + percent(1 + main.angelSkillAry[8].Damage() / 100);
        else
            valueText += "\n* 100.00%";
        valueText += "\n* " + percent(1d + main.iebCtrl.iebBonuses[(int)IEBBONUS.BonusKind.goldgain]);
        valueText += "\n* " + percent(main.GoldGainDLCFactor());
        valueText += "\n* " + percent(1 + ArtifactBonus.GOLD_GAIN);

        valueText += "\n\n<size=14>" + tDigit(bonusGold()) + "<size=10>";

        valueText += "\n+ " + tDigit(main.StatusUpgrade[4].calculateCurrentValue() + main.SR.R_GOLD);
        valueText += "\n+ " + tDigit(main.ArtifactFactor.ADD_GOLD());
        valueText += "\n+ " + tDigit(main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.Golden].GetCurrentValue());
        valueText += "\n* " + percent(main.GoldGainDLCFactor());

        return new string[] { nameText, valueText };
    }

    double bonusGold()
    {
        return (main.StatusUpgrade[4].calculateCurrentValue() + main.ArtifactFactor.ADD_GOLD() + main.SR.R_GOLD + main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.Golden].GetCurrentValue())
            * main.GoldGainDLCFactor();
    }
    double mulGold()
    {
        if (main.ally.isBuff[(int)Main.Buff.gold])
        {
            return (1 + GOLD_passiveSkill()) * (1 + main.angelSkillAry[8].Damage() / 100)
     * (1 + main.ArtifactFactor.GOLD()) * (1 + main.Ascends[13].calculateCurrentValue())
     * (1 + main.jems[(int)JEM.ID.GoldGem].Effect()) * (1 + main.ally.Mile_gold)
                  * (1d + main.iebCtrl.iebBonuses[(int)IEBBONUS.BonusKind.goldgain])
     * main.GoldGainDLCFactor();
            ;
        }
        else
        {
            return (1 + GOLD_passiveSkill()) * (1)
* (1 + main.ArtifactFactor.GOLD()) * (1 + main.Ascends[13].calculateCurrentValue())
* (1 + main.jems[(int)JEM.ID.GoldGem].Effect()) * (1 + main.ally.Mile_gold)
* main.GoldGainDLCFactor();
        }
    }
    public double GOLD_passiveSkill()
    {
        if (main.ally.job == ALLY.Job.Angel || main.MissionMileStone.IsSkillPassiveEffect())
            return main.angelSkillAry[8].pas1 + main.angelSkillAry[8].pas2 + main.angelSkillAry[8].pas3;
        else
            return 0;
    }

    public string TotalGold()
    {
        return percent(mulGold()) + "  +  " + tDigit(bonusGold());
    }

    //GoldCap
    public string[] showGOLDCap()
    {
        string nameText = "";
        string valueText = "";
        nameText += "<size=14>Additive Gold Cap<size=10>";

        nameText += "\n - Base";
        nameText += "\n - Stone Gold Cap";
        nameText += "\n - Crystal Gold Cap";
        nameText += "\n - Leaf Gold Cap";
        nameText += "\n - Quest";
        nameText += "\n - Mission Milestone";
        nameText += "\n - Epic Store";
        nameText += "\n - Reincarnation";

        nameText += "\n\n<size=14>Multiplicative<size=10>";

        nameText += "\n - Dark Ritual";
        nameText += "\n - Spirit Upgrade";
        nameText += "\n - Mission Milestone";
        nameText += "\n - IEB Bonus";


        valueText += "<size=14>" + tDigit(main.GoldCapADD()) + "<size=10>";

        valueText += "\n   1000";
        valueText += "\n+ " + tDigit(main.SR.stoneGoldLevel * main.Ascends[0].calculateCurrentValue());
        valueText += "\n+ " + tDigit(main.SR.crystalGoldLevel * main.Ascends[5].calculateCurrentValue());
        valueText += "\n+ " + tDigit(main.SR.leafGoldLevel * main.Ascends[10].calculateCurrentValue());
        valueText += "\n+ " + tDigit(main.GoldCapFromQuest());
        valueText += "\n+ " + tDigit(main.MissionMileStone.GoldCapBonus());
        valueText += "\n+ " + tDigit(main.S.GoldCapByKreds);
        valueText += "\n+ " + tDigit(main.rein.R_factor.GoldCap());

        valueText += "\n\n<size=14>" + percent(main.GoldCapMUL()) + "<size=10>";

        valueText += "\n   " + percent(1 + main.jems[(int)JEM.ID.GoldCapGem].Effect());
        valueText += "\n* " + percent(1 + main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.Deeper].GetCurrentValue());
        valueText += "\n* " + percent(1 + main.MissionMileStoneHidden.GoldCapFactor());
        valueText += "\n* " + percent(1d + main.iebCtrl.iebBonuses[(int)IEBBONUS.BonusKind.goldcap]);

        return new string[] { nameText, valueText };
    }
    public string TotalGoldCap()
    {
        return tDigit(main.MaxGold());
    }





    public string[] showEXP()
    {
        string nameText = "";
        string valueText = "";

        nameText += "<size=14>Multiplicative EXP<size=10>";

        nameText += "\n - Equipment";
        // += "\n - MileStone ";
        nameText += "\n - Dungeon";
        nameText += "\n - IEB Bonus";
        nameText += "\n - DLC & Epic Store";

        nameText += "\n\n<size=14>Bonus EXP<size=10>";

        nameText += "\n - Upgrade";
        nameText += "\n - Reincarnation";

        valueText += "<size=14>" + percent(mulEXP()) + "<size=10>";

        valueText += "\n   " + percent(1 + main.ArtifactFactor.MUL_EXP());
        //valueText += "\n* " + percent(1 + main.ally.Mile_exp);
        valueText += "\n* " + percent(1 + main.zoneExpBonus() / 100);
        valueText += "\n* " + percent(1d + main.iebCtrl.iebBonuses[(int)IEBBONUS.BonusKind.expgain]);
        valueText += "\n* " + percent(main.ExpGainDLCFactor());

        valueText += "\n\n<size=14>" + tDigit(bonusEXP()) + "<size=10>";

        valueText += "\n+ " + tDigit(main.StatusUpgrade[5].calculateCurrentValue() + main.SR.R_EXP);
        valueText += "\n+ " + tDigit(main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.Golden].GetCurrentValue()*5);

        return new string[] { nameText, valueText };
    }

    public double mulEXP()
    {
        return (1 + main.zoneExpBonus() / 100) * (1 + main.ArtifactFactor.MUL_EXP())  * (1 + main.ally.Mile_exp) * main.ExpGainDLCFactor() * (1d + main.iebCtrl.iebBonuses[(int)IEBBONUS.BonusKind.expgain]);
    }
    public double bonusEXP()
    {
        return main.StatusUpgrade[5].calculateCurrentValue() + main.SR.R_EXP + main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.Golden].GetCurrentValue()*5;

    }

    public string TotalExp()
    {
        return percent(mulEXP())
            + "  +  " + tDigit(main.StatusUpgrade[5].calculateCurrentValue() + main.SR.R_EXP);
    }


    public string[] showDrop()
    {
        string nameText = "";
        string valueText = "";

        nameText += "<size=14>Multiplicative Drop<size=10>";

        nameText += "\n - Equipment";
        //nameText += "\n - MileStone ";
        nameText += "\n - Mission MileStone ";
        nameText += "\n - Upgrade";
        nameText += "\n - Area Mastery";
        valueText += "<size=14>" + TotalDrop() + "<size=10>";

        valueText += "\n   " + percent(1 + main.ArtifactFactor.DROP());
        //valueText += "\n* " + percent(1 + main.ally.Mile_drop);
        valueText += "\n* " + percent(1 + main.MissionMileStone.DropBonus());
        valueText += "\n* " + percent(1 + main.SR.R_drop);
        valueText += "\n* " + percent(1 + main.dungeonAry[(int)main.GameController.currentDungeon].CurrentDropChanceBonus());
        return new string[] { nameText, valueText };
    }
    public string TotalDrop()
    {
        return percent((1 + main.ArtifactFactor.DROP()) * (1+main.ally.Mile_drop) * (1 + main.SR.R_drop) * (1d + main.MissionMileStone.DropBonus()));
    } 
    public double DropFactor()
    {
        return (1 + main.ArtifactFactor.DROP())
            * (1 + main.ally.Mile_drop)
            * (1 + main.dungeonAry[(int)main.GameController.currentDungeon].CurrentDropChanceBonus())
            * ( 1 + main.SR.R_drop)
            * (1d + main.MissionMileStone.DropBonus())
            +(1 + main.keyf.M_drop);//Lottery
    }

    public string[] showProf()
    {
        string nameText = "";
        string valueText = "";

        nameText += "<size=14>Skill Proficiency<size=10>";

        nameText += "\n - Skill Passive Effect";
        nameText += "\n - Equipment";
        nameText += "\n - Rebirth ";
        nameText += "\n - Dark Ritual ";
        nameText += "\n - IEB Bonus";
        nameText += "\n - Buff";
        nameText += "\n - Artifact";

        valueText += "<size=14>" + percent(profFactor()) + "<size=10>";

        if (main.MissionMileStone.IsSkillPassiveEffect()) 
            valueText += "\n   " + percent(1 + main.skillList.WarriorSkills[(int)SkillList.WarriorSkill.sword].warriorFactor +
    main.skillList.WizardSkills[(int)SkillList.WizardSkill.staff].wizardFactor +
    main.skillList.AngelSkills[(int)SkillList.AngelSkill.wingAttack].angelFactor +
    main.angelSkillAry[9].pas1 + main.angelSkillAry[9].pas2 + main.angelSkillAry[9].pas3 + main.angelSkillAry[13].pas2);
        else if (main.ally.job == ALLY.Job.Warrior)
            valueText += "\n   " + percent(1 + main.skillList.WarriorSkills[(int)SkillList.WarriorSkill.sword].warriorFactor);
        else if (main.ally.job == ALLY.Job.Wizard)
            valueText += "\n   " +
                percent(1+main.skillList.WizardSkills[(int)SkillList.WizardSkill.staff].wizardFactor);
        else if (main.ally.job == ALLY.Job.Angel)
            valueText += "\n   " + percent(1 + 
                main.skillList.AngelSkills[(int)SkillList.AngelSkill.wingAttack].angelFactor +
                main.angelSkillAry[9].pas1 + main.angelSkillAry[9].pas2 + main.angelSkillAry[9].pas3);
        else
            valueText += "\n   " + percent(1 + main.skillList.WarriorSkills[(int)SkillList.WarriorSkill.sword].warriorFactor +
                main.skillList.WizardSkills[(int)SkillList.WizardSkill.staff].wizardFactor +
                main.skillList.AngelSkills[(int)SkillList.AngelSkill.wingAttack].angelFactor +
                main.angelSkillAry[9].pas1 + main.angelSkillAry[9].pas2 + main.angelSkillAry[9].pas3 + main.angelSkillAry[13].pas2);


        valueText += "\n* " + percent((1 + main.ArtifactFactor.PROF())*LegendaryEffect.SkillEfficiencyBonus());
        valueText += "\n* " + percent(1 + main.Ascends[14].calculateCurrentValue());
        valueText += "\n* " + percent(1 + main.jems[(int)JEM.ID.Prof].Effect());
        valueText += "\n* " + percent(1d + main.iebCtrl.iebBonuses[(int)IEBBONUS.BonusKind.prof]);
        if (main.ally.isBuff[(int)Main.Buff.prof])
            valueText += "\n* " + percent(1 + main.angelSkillAry[9].Damage() / 100);
        else
            valueText += "\n* 100%";
        valueText += "\n* " + percent(1 + ArtifactBonus.PROFICIENCY);
        return new string[] { nameText, valueText };
    }


    public double profFactor()
    {
        if (main.MissionMileStone.IsSkillPassiveEffect())
        {
            if (main.ally.isBuff[(int)Main.Buff.prof])
            {
                return (1 + main.skillList.WarriorSkills[(int)SkillList.WarriorSkill.sword].warriorFactor +
        main.skillList.WizardSkills[(int)SkillList.WizardSkill.staff].wizardFactor +
        main.skillList.AngelSkills[(int)SkillList.AngelSkill.wingAttack].angelFactor +
        main.angelSkillAry[9].pas1 + main.angelSkillAry[9].pas2 + main.angelSkillAry[9].pas3) * (1 + main.jems[(int)JEM.ID.Prof].Effect())
        * (1 + main.ArtifactFactor.PROF()) * (1 + main.Ascends[14].calculateCurrentValue()) * (1 + main.angelSkillAry[9].Damage() / 100)
        * (1d + main.iebCtrl.iebBonuses[(int)IEBBONUS.BonusKind.prof])
                * (1 + ArtifactBonus.PROFICIENCY);
            }
            else
            {
                return (1 + main.skillList.WarriorSkills[(int)SkillList.WarriorSkill.sword].warriorFactor +
        main.skillList.WizardSkills[(int)SkillList.WizardSkill.staff].wizardFactor +
        main.skillList.AngelSkills[(int)SkillList.AngelSkill.wingAttack].angelFactor +
        main.angelSkillAry[9].pas1 + main.angelSkillAry[9].pas2 + main.angelSkillAry[9].pas3) * (1 + main.jems[(int)JEM.ID.Prof].Effect())
        * (1 + main.ArtifactFactor.PROF()) * (1 + main.Ascends[14].calculateCurrentValue())
        * (1d + main.iebCtrl.iebBonuses[(int)IEBBONUS.BonusKind.prof]) * (1 + ArtifactBonus.PROFICIENCY);

            }
        }
        else if (main.ally.job == ALLY.Job.Angel)
        {
            if (main.ally.isBuff[(int)Main.Buff.prof])
            {
                return (1) *
        (1 +
        main.skillList.AngelSkills[(int)SkillList.AngelSkill.wingAttack].angelFactor +
        main.angelSkillAry[9].pas1 + main.angelSkillAry[9].pas2 + main.angelSkillAry[9].pas3) * (1 + main.jems[(int)JEM.ID.Prof].Effect())
        * (1 + main.ArtifactFactor.PROF()) * (1 + main.Ascends[14].calculateCurrentValue()) * (1 + main.angelSkillAry[9].Damage() / 100)
                * (1d + main.iebCtrl.iebBonuses[(int)IEBBONUS.BonusKind.prof]) * (1 + ArtifactBonus.PROFICIENCY);

                ;
            }
            else
            {
                return (1 ) *
        (1 +
        main.skillList.AngelSkills[(int)SkillList.AngelSkill.wingAttack].angelFactor +
        main.angelSkillAry[9].pas1 + main.angelSkillAry[9].pas2 + main.angelSkillAry[9].pas3) * (1 + main.jems[(int)JEM.ID.Prof].Effect())
        * (1 + main.ArtifactFactor.PROF()) * (1 + main.Ascends[14].calculateCurrentValue())
                * (1d + main.iebCtrl.iebBonuses[(int)IEBBONUS.BonusKind.prof]) * (1 + ArtifactBonus.PROFICIENCY);

                ;

            }

        }
        else if (main.ally.job == ALLY.Job.Warrior)
        {
            if (main.ally.isBuff[(int)Main.Buff.prof])
            {
                return (1) *
        (1 + main.skillList.WarriorSkills[(int)SkillList.WarriorSkill.sword].warriorFactor) * (1 + main.jems[(int)JEM.ID.Prof].Effect())
        * (1 + main.ArtifactFactor.PROF()) * (1 + main.Ascends[14].calculateCurrentValue()) * (1 + main.angelSkillAry[9].Damage() / 100)
                * (1d + main.iebCtrl.iebBonuses[(int)IEBBONUS.BonusKind.prof]) * (1 + ArtifactBonus.PROFICIENCY);

                ;
            }
            else
            {
                return (1 ) *
        (1 + main.skillList.WarriorSkills[(int)SkillList.WarriorSkill.sword].warriorFactor) * (1 + main.jems[(int)JEM.ID.Prof].Effect())
        * (1 + main.ArtifactFactor.PROF()) * (1 + main.Ascends[14].calculateCurrentValue())
                * (1d + main.iebCtrl.iebBonuses[(int)IEBBONUS.BonusKind.prof]) * (1 + ArtifactBonus.PROFICIENCY);

                ;

            }

        }
        else
        {
            if (main.ally.isBuff[(int)Main.Buff.prof])
            {
                return (1) *
        (1 + main.skillList.WizardSkills[(int)SkillList.WizardSkill.staff].wizardFactor) * (1 + main.jems[(int)JEM.ID.Prof].Effect())
        * (1 + main.ArtifactFactor.PROF()) * (1 + main.Ascends[14].calculateCurrentValue()) * (1 + main.angelSkillAry[9].Damage() / 100)
                * (1d + main.iebCtrl.iebBonuses[(int)IEBBONUS.BonusKind.prof]) * (1 + ArtifactBonus.PROFICIENCY);

                ;
            }
            else
            {
                return (1 ) *
        (1 + main.skillList.WizardSkills[(int)SkillList.WizardSkill.staff].wizardFactor) * (1 + main.jems[(int)JEM.ID.Prof].Effect())
        * (1 + main.ArtifactFactor.PROF()) * (1 + main.Ascends[14].calculateCurrentValue())
                * (1d + main.iebCtrl.iebBonuses[(int)IEBBONUS.BonusKind.prof]) * (1 + ArtifactBonus.PROFICIENCY);

                ;

            }

        }
    }
}
