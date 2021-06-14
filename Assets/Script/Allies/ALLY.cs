using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static ALLY.Job;
using TMPro;
using MathNet.Numerics.Distributions;


public abstract class ALLY : BASE, IDamagable
{
    public GameObject thisSlider;
    public GameObject thisSlider2;
    public bool isChosen;
    public bool isDead { get => main.S.isDead; set => main.S.isDead = value; }
    public virtual int saveLevel { get; set; }
    public virtual int Level() {
        if (main.cc.CurrentCurseId == CurseId.curse_of_metal && saveLevel > 1000) return 1000;
        return saveLevel + 1;
    }
    public virtual double currentExp { get; set; }
    [Header("spritesとintervalsのサイズは同じにしてください")]
    /// <summary>
    /// ここに切り替える画像を入れてください．
    /// </summary>
    public Sprite[] sprites;
    public Sprite[] ieh2sprites;
    /// <summary>
    /// コマとコマの感覚をそれぞれ入力してください．デフォルトは[0.5,0.5]で．
    /// </summary>
    public float[] intervals;
    public Slider chantingSlider;
    public bool[] isDebuff;
    public GameObject SetEffectObject;
    public long combo;
    public double stayTime;

    //バトルレンジ
    public float BattleRange()
    {
        if (main.toggles[10].isOn)
        {
            return main.S.customRange;
        }
        else
        {
            if (main.skillSlotCanvasAry[1].currentSkill != null)
            {
                float range = main.skillSlotCanvasAry[1].currentSkill.attackRange;
                //for (int i = 1; i < main.skillSlotCanvasAry.Length; i++)
                //{
                //    if (main.skillSlotCanvasAry[i].currentSkill != null && main.skillSlotCanvasAry[i].currentSkill.attackRange != 0)
                //    {
                //        if (main.skillSlotCanvasAry[i].currentSkill.attackRange < 1000)
                //        {
                //            if (range == 0f)
                //            {
                //                range = main.skillSlotCanvasAry[i].currentSkill.attackRange;
                //            }
                //            else
                //            {
                //                range = Math.Max(range, main.skillSlotCanvasAry[i].currentSkill.attackRange);
                //            }

                //        }
                //    }
                //}
                if (range == 0 || range >= 1000)
                {
                    return main.skillSlotCanvasAry[0].currentSkill.attackRange;
                }
                else
                {
                    return range;
                }
            }
            else if (main.skillSlotCanvasAry[0].currentSkill != null)
            {
                return main.skillSlotCanvasAry[0].currentSkill.attackRange;
            }
            else
            {
                return 50f;
            }
        }
    }
    //経験値テーブル (100,140,196,...)
    public double RequiredExp() {
        if (Level() >= 3801)
            return 50 + 50 * Math.Pow((3801 - 1), 2.55) + 50 * Math.Pow(1.2, (3801 - 1));
        else
            return 50 + 50 * Math.Pow((Level() - 1), 2.55) + 50 * Math.Pow(1.2, (Level() - 1));
    }
    //LevelUpの処理
    public void LevelUp()
    {
        if (main.cc.CurrentCurseId == CurseId.curse_of_metal && saveLevel >= 1000)
            return;

        saveLevel++;
        main.S.maxLevelReached = Math.Max(main.S.maxLevelReached, saveLevel);
        main.S.maxLevelReachedWhileReincarnation = Math.Max(main.S.maxLevelReachedWhileReincarnation, saveLevel);
        main.SoundEffectSource.PlayOneShot(main.sound.levelUpClip);
        main.Log("<color=green>Level Up !");
        // if (Level() <= 15)
        // {
        //     main.JobPoint += 3 * Math.Pow(Level(), 1.15);
        //     main.SR.JP_level += 3 * Math.Pow(Level(), 1.15);
        // }
        // else
        // {
        //     main.JobPoint += 3 * Math.Pow(Level(), 1.35);
        //     main.SR.JP_level += 3 * Math.Pow(Level(), 1.35);
        // }
        GetAscendPoint();
        main.sound.PlaySound(main.sound.positiveClip);

        if (isWarSpirit())
        {
            main.SR.spiritWar += main.warriorSkillAry[10].Damage();
        }
        else if (job == Job.Warrior || main.MissionMileStone.IsSkillPassiveEffect())
        {
            main.SR.spiritWar += main.warriorSkillAry[10].Damage() * main.warriorSkillAry[10].pas1;
        }

        if (isWizSpirit())
        {
            main.SR.spiritWiz += main.wizardSkillAry[10].Damage();
        }
        else if (job == Job.Wizard || main.MissionMileStone.IsSkillPassiveEffect())
        {
            main.SR.spiritWiz += main.wizardSkillAry[10].Damage() * main.wizardSkillAry[10].pas1;
        }

        if (isAngSpirit())
        {
            main.SR.spiritAng += main.angelSkillAry[10].Damage();
        }
        else if (job == Job.Angel || main.MissionMileStone.IsSkillPassiveEffect())
        {
            main.SR.spiritAng += main.angelSkillAry[10].Damage() * main.angelSkillAry[10].pas1;
        }


    }

    public void GetAscendPoint()
    {
        long value;
        if (Level() <= 100)
        {
            value = (long)(2 * Math.Pow(1.05, Level()));
        }
        else
        {
            value = (long)(2 * Math.Pow(1.05, 100) + 1 * (Level() - 100));
        }
        //倍率をかける
        value = (long)(value * main.RebirthPointFactor());

        switch (main.ally.job)
        {
            case ALLY.Job.Warrior:
                main.WarP += value;
                main.tempWarP += value;
                break;
            case ALLY.Job.Wizard:
                main.WizP += value;
                main.tempWizP += value;
                break;
            case ALLY.Job.Angel:
                main.AngP += value;
                main.tempAngP += value;
                break;
            default:
                break;
        }

        main.SR.JP_level += value;
    }

    //public void GetAscendPointForSuperRebirth(int level)
    //{
    //    long value;
    //    if (level <= 100)
    //    {
    //        value = (long)(2 * Math.Pow(1.05, level));
    //    }
    //    else
    //    {
    //        value = (long)(2 * Math.Pow(1.05, 100) + 1 * (level - 100));
    //    }


    //    switch (main.ally.job)
    //    {
    //        case ALLY.Job.Warrior:
    //            main.WarP += value;
    //            main.tempWarP += value;
    //            break;
    //        case ALLY.Job.Wizard:
    //            main.WizP += value;
    //            main.tempWizP += value;
    //            break;
    //        case ALLY.Job.Angel:
    //            main.AngP += value;
    //            main.tempAngP += value;
    //            break;
    //        default:
    //            break;
    //    }

    //    main.SR.JP_level += value;
    //}

    bool isWarSpirit()
    {
        return main.skillsForCoolTime[30].IsEquipped();
    }
    bool isWizSpirit()
    {
        return main.skillsForCoolTime[40].IsEquipped();
    }
    bool isAngSpirit()
    {
        return main.skillsForCoolTime[50].IsEquipped();
    }


    public double L_HP()
    {
        switch (job)
        {
            case Warrior:
                return Math.Pow(Level() - 1, 1.45) * 50 + main.SR.spiritWar * 10;
            case Wizard:
                return Math.Pow(Level() - 1, 1.15) * 25 + main.SR.spiritWar * 10;
            case Angel:
                return Math.Pow(Level() - 1, 1.35) * 25 + main.SR.spiritWar * 10;
            default:
                return 0 * Level();
        }
    }
    public double L_MP()
    {
        switch (job)
        {
            case Warrior:
                return Math.Pow(Level() - 1, 1.05) * 3 + main.SR.spiritWiz * 2;
            case Wizard:
                return Math.Pow(Level() - 1, 1.15) * 3 + main.SR.spiritWiz * 2;
            case Angel:
                return Math.Pow(Level() - 1, 1.15) * 5 + main.SR.spiritWiz * 2;
            default:
                return 0 * Level();
        }
    }

    public double L_ATK()
    {
        switch (job)
        {
            case Warrior:
                return Math.Pow(Level() - 1, 1.45) * 3 + main.SR.spiritWar;
            case Wizard:
                return Math.Pow(Level() - 1, 1.05) * 0.1 + main.SR.spiritWar;
            case Angel:
                return Math.Pow(Level() - 1, 1.15) * 1 + main.SR.spiritWar;
            default:
                return 0 * Level();
        }
    }

    public double L_MATK()
    {
        switch (job)
        {
            case Warrior:
                return Math.Pow(Level() - 1, 1.05) * 0.1 + main.SR.spiritWiz;
            case Wizard:
                return Math.Pow(Level() - 1, 1.35) * 3 + main.SR.spiritWiz;
            case Angel:
                return Math.Pow(Level() - 1, 1.15) * 1 + main.SR.spiritWiz;
            default:
                return 0 * Level();
        }
    }

    public double L_DEF()
    {
        switch (job)
        {
            case Warrior:
                return Math.Pow(Level() - 1, 1.45) * 3 + main.SR.spiritAng;
            case Wizard:
                return Math.Pow(Level() - 1, 1.15) * 0.5 + main.SR.spiritAng;
            case Angel:
                return Math.Pow(Level() - 1, 1.175) * 1 + main.SR.spiritAng;
            default:
                return 0 * Level();
        }
    }

    public double L_MDEF()
    {
        switch (job)
        {
            case Warrior:
                return Math.Pow(Level() - 1, 1.15) * 0.5 + main.SR.spiritAng;
            case Wizard:
                return Math.Pow(Level() - 1, 1.15) * 1 + main.SR.spiritAng;
            case Angel:
                return Math.Pow(Level() - 1, 1.175) * 1 + main.SR.spiritAng;
            default:
                return 0 * Level();
        }
    }

    public double L_SPD()
    {
        switch (job)
        {
            case Warrior:
                return Math.Pow(Level() - 1, 1.15) * 2.5 + main.SR.spiritAng * 3;
            case Wizard:
                return Math.Pow(Level() - 1, 1.05) * 2.5 + main.SR.spiritAng * 3;
            case Angel:
                return Math.Pow(Level() - 1, 1.55) * 5 + main.SR.spiritAng * 3;
            default:
                return 0 * Level();
        }
    }

    //バフ
    public bool[] isBuff;// = new bool[System.Enum.GetValues(typeof(Main.Buff)).Length];
    public double buffHpFactor;
    public double buffAtkFactor;
    public double buffMAtkFactor;
    public double buffDefFactor;
    public double buffMDefFactor;
    //Haste
    public double buffSpdFactor;
    //spicy
    public float buffSpdFactor2;
    public double Mile_hp;
    public double Mile_mp;
    public double Mile_atk;
    public double Mile_matk;
    public double Mile_def;
    public double Mile_mdef;
    public double Mile_spd;
    public double Mile_exp;
    public double Mile_gold;
    public double Mile_drop;
    public IEnumerator CalculateMile()
    {
        while (true)
        {
            Mile_hp = main.bestiary.CalculateMileStoneBonus(ENEMY.MileStoneKind.hp);
            Mile_mp = main.bestiary.CalculateMileStoneBonus(ENEMY.MileStoneKind.mp);
            Mile_atk = main.bestiary.CalculateMileStoneBonus(ENEMY.MileStoneKind.atk);
            Mile_matk = main.bestiary.CalculateMileStoneBonus(ENEMY.MileStoneKind.matk);
            Mile_def = main.bestiary.CalculateMileStoneBonus(ENEMY.MileStoneKind.def);
            Mile_mdef = main.bestiary.CalculateMileStoneBonus(ENEMY.MileStoneKind.mdef);
            Mile_spd = main.bestiary.CalculateMileStoneBonus(ENEMY.MileStoneKind.spd);
            Mile_exp = main.bestiary.CalculateMileStoneBonus(ENEMY.MileStoneKind.exp);
            Mile_gold = main.bestiary.CalculateMileStoneBonus(ENEMY.MileStoneKind.gold);
            Mile_drop = main.bestiary.CalculateMileStoneBonus(ENEMY.MileStoneKind.drop);
            yield return new WaitForSeconds(10.0f);
        }
    }

    public void AwakeAlly(double initialHp, double initialMp, double initialAtk, double initialMAtk, double initialDef, double initialMDef, float initialSpeed)
    {
        StartBASE();
        isBuff = new bool[System.Enum.GetValues(typeof(Main.Buff)).Length];
        this.initialHp = initialHp;
        this.initialMp = initialMp;
        currentMp = 0;
        this.initialAtk = initialAtk;
        this.initialMAtk = initialMAtk;
        this.initialDef = initialDef;
        this.initialMDef = initialMDef;
        this.initialSpeed = initialSpeed;
        thisRect = gameObject.GetComponent<RectTransform>();
        chantingSlider = gameObject.GetComponentInChildren<Slider>();
        setFalse(chantingSlider.gameObject);
        main.S.maxLevelReached = Math.Max(main.S.maxLevelReached, saveLevel);
        main.S.maxLevelReachedWhileReincarnation = Math.Max(main.S.maxLevelReachedWhileReincarnation, saveLevel);
    }

    public void updateJobStatus()
    {
        switch (job)
        {
            case Warrior:
                initialHp = 120;
                initialMp = 10;
                main.SR.currentHp = HP();
                currentMp = 0;
                initialMpRegen = 1.0;
                initialAtk = 5;
                initialMAtk = 3;
                initialDef = 1;
                initialMDef = 0;
                initialSpeed = 3;
                break;
            case Wizard:
                initialHp = 100;
                initialMp = 20;
                main.SR.currentHp = HP();
                initialMpRegen = 3.0;
                currentMp = 0;
                initialAtk = 3;
                initialMAtk = 5;
                initialDef = 0;
                initialMDef = 1;
                initialSpeed = 1;
                break;
            case Angel:
                initialHp = 130;
                initialMp = 15;
                main.SR.currentHp = HP();
                currentMp = 0;
                initialMpRegen = 2.0;
                initialAtk = 3;
                initialMAtk = 3;
                initialDef = 1;
                initialMDef = 1;
                initialSpeed = 8;
                break;
        }
    }

    public void ResetStatus()
    {
        tempAtkFactor = 1.0f;
        tempMatkFactor = 1.0f;
        tempDefFactor = 1.0f;
        tempMdefFactor = 1.0f;
        main.MyStatusTexts[3].color = Color.white;
        main.MyStatusTexts[4].color = Color.white;
        main.MyStatusTexts[5].color = Color.white;
        main.MyStatusTexts[6].color = Color.white;
    }

    //R4スキルによるStats上昇
    public double StatsMultiFromR4Skill()
    {
        return main.skillList.WarriorSkills[(int)SkillList.WarriorSkill.criticalEye].Chance()
            * main.skillList.WizardSkills[(int)SkillList.WizardSkill.criticalBolt].Chance()
            * main.skillList.AngelSkills[(int)SkillList.AngelSkill.purification].Chance();
    }

    //HPのブレイクダウン
    public virtual double HP()
    {
        return addHP() * mulHP();
    }
    public double addHP()
    {
        return initialHp
            + L_HP()
            + main.ArtifactFactor.ADD_HP()
            + main.keyf.A_hp
            + HP_ritualUpgrade()
            + main.SR.R_HP
            + main.S.vitalityLevel
            + ArtifactBonus.HP_ADD
            ;
    }
    public double mulHP()
    {
        return HP_passiveSkill()
            * (1 + buffHpFactor) * (1 + main.ArtifactFactor.MUL_HP()) *
            (1 + main.QuestCtrl.R_slime()) * (1 + main.S.hpPortion) *
            (1 + main.Ascends[2].calculateCurrentValue()) * (1 + main.quests[(int)ACHIEVEMENT.QuestList.journey].clearNum * 0.1 + main.quests[(int)ACHIEVEMENT.QuestList.P_leather].clearNum * 0.01)
            * (1 + Mile_hp) * (1 + main.keyf.M_hp) * (1 + main.rein.R_factor.StatusIncrease()) * SumMulDelegate(main.cc.cf.AllStatusMul)
            * LegendaryEffect.StatsBonus()
            * main.MissionMileStoneHidden.StatsFactor()
            * (1 + ArtifactBonus.HP_MUL)
            ;
    }

    //クラフトは直接参照する．
    public double HP_ritualUpgrade()
    {
        return main.StatusUpgrade[0].calculateCurrentValue() * 5;
    }

    public double HP_passiveSkill()
    {
        if (main.MissionMileStone.IsSkillPassiveEffect())
            return (1 + main.warriorSkillAry[8].pas1 + main.warriorSkillAry[8].pas4 + main.warriorSkillAry[8].pas7
             + main.warriorSkillAry[9].pas1 + main.warriorSkillAry[9].pas5
              + main.wizardSkillAry[5].pas7
              + main.angelSkillAry[2].pas4 + main.angelSkillAry[2].pas5 + main.angelSkillAry[2].pas6
            + main.angelSkillAry[3].pas1 + main.angelSkillAry[3].pas2 + main.angelSkillAry[3].pas4
            )
                        * StatsMultiFromR4Skill()
;

        if (main.ally.job == Job.Warrior)
            return (1 + main.warriorSkillAry[8].pas1 + main.warriorSkillAry[8].pas4 + main.warriorSkillAry[8].pas7
             + main.warriorSkillAry[9].pas1 + main.warriorSkillAry[9].pas5
            )
                        * StatsMultiFromR4Skill()
;
        else if (main.ally.job == Job.Wizard)
            return (1 + main.wizardSkillAry[5].pas7
            )
                        * StatsMultiFromR4Skill()
;
        else if (main.ally.job == Job.Angel)
            return (1 + main.angelSkillAry[2].pas4 + main.angelSkillAry[2].pas5 + main.angelSkillAry[2].pas6
            + main.angelSkillAry[3].pas1 + main.angelSkillAry[3].pas2 + main.angelSkillAry[3].pas4
            )
                        * StatsMultiFromR4Skill()
;
        else
            return 1;
    }

    public virtual double MP()
    {
        if (CURSE_RAIN.IsRoad2())
            return 0;
        return addMP() * mulMP();
        ;
    }
    public double addMP()
    {
        return initialMp
            + L_MP()
            + main.ArtifactFactor.ADD_MP()
            + MP_ritualUpgrade()
            + main.SR.R_MP
            + main.keyf.A_mp
            + main.S.vitalityLevel
            + ArtifactBonus.MP_ADD
            ;
    }
    public double mulMP()
    {
        return MP_passiveSkill()
                    * (1 + main.Ascends[7].calculateCurrentValue()) * (1 + main.QuestCtrl.R_octobaddie()) * (1 + main.S.mpPortion)
                    * (1 + main.ArtifactFactor.MUL_MP())
                    * (1 + Mile_mp) * (1 + +main.keyf.M_mp) * (1 + main.rein.R_factor.StatusIncrease()) * SumMulDelegate(main.cc.cf.AllStatusMul)
                    * LegendaryEffect.StatsBonus()
                    * main.MissionMileStoneHidden.StatsFactor()
                    * (1 + ArtifactBonus.MP_MUL)
                    ;
    }

    public double MP_ritualUpgrade()
    {
        return (main.StatusUpgrade[1].calculateCurrentValue() * 5);
    }
    public double MP_passiveSkill()
    {
        if (main.MissionMileStone.IsSkillPassiveEffect())
            return (1 + main.warriorSkillAry[2].pas1
                        + main.warriorSkillAry[6].pas1
                        + main.warriorSkillAry[8].pas2
                        + main.warriorSkillAry[9].pas2
                        + main.wizardSkillAry[0].pas5
                        + main.wizardSkillAry[1].pas2
                        + main.wizardSkillAry[4].pas1 + main.wizardSkillAry[4].pas4 + main.wizardSkillAry[4].pas7
                        + main.wizardSkillAry[7].pas1 + main.wizardSkillAry[7].pas4
                        + main.angelSkillAry[3].pas3
                        )
                                    * StatsMultiFromR4Skill()
;

        if (main.ally.job == Job.Warrior)
            return (1 + main.warriorSkillAry[2].pas1
                        + main.warriorSkillAry[6].pas1
                        + main.warriorSkillAry[8].pas2
                        + main.warriorSkillAry[9].pas2
                        )
                                    * StatsMultiFromR4Skill()
;
        else if (main.ally.job == Job.Wizard)
            return (1   + main.wizardSkillAry[0].pas5
                        + main.wizardSkillAry[1].pas2
                        + main.wizardSkillAry[4].pas1 + main.wizardSkillAry[4].pas4 + main.wizardSkillAry[4].pas7
                        + main.wizardSkillAry[7].pas1 + main.wizardSkillAry[7].pas4
                        )
                                    * StatsMultiFromR4Skill()
;
        else if (main.ally.job == Job.Angel)
            return (1 + main.angelSkillAry[3].pas3
                        )
                                    * StatsMultiFromR4Skill()
;
        else
            return 1;

    }

    public double tempAtkFactor;
    public double warriorPassiveSwordFactor;
    public double alchemyAtkFactor;

    public virtual double Atk()
    {
        return addATK() * mulATK() * (1+alchemyAtkFactor);
        ;
    }
    public double addATK()
    {
        return initialAtk
            + L_ATK()
            + (buffAtkFactor)
            + main.ArtifactFactor.ADD_ATK()
            + main.StatusUpgrade[0].calculateCurrentValue()
            + ATK_bank()
            + main.SR.R_ATK
            + main.keyf.A_atk
            + main.S.muscleLevel
            + ArtifactBonus.ATK_ADD
            ;
    }
    public double mulATK()
    {
        return ATK_passiveSkill()
           * (1 + main.QuestCtrl.R_spider()) * (1 + main.Ascends[3].calculateCurrentValue())
           * (1 + main.ArtifactFactor.MUL_ATK())
             * tempAtkFactor * (1 + Mile_atk)
             * (1 + warriorPassiveSwordFactor) * (1 + main.keyf.M_atk) * (1 - angelPassiveFactor) * (1 + main.rein.R_factor.StatusIncrease())
             * SumMulDelegate(main.cc.cf.AllStatusMul)
             * LegendaryEffect.StatsBonus()
            * main.MissionMileStoneHidden.StatsFactor()
            * (1 + ArtifactBonus.ATK_MUL)
             ;
    }

    public double ATK_ritualUpgrade()
    {
        return main.StatusUpgrade[0].calculateCurrentValue();
    }
    public double ATK_passiveSkill()
    {
        if (main.MissionMileStone.IsSkillPassiveEffect())
            return (1 + main.warriorSkillAry[0].pas4 + main.warriorSkillAry[0].pas5
+ main.warriorSkillAry[1].pas7 + main.warriorSkillAry[1].pas8
+ main.warriorSkillAry[2].pas3
+ main.warriorSkillAry[4].pas9 + main.warriorSkillAry[4].pas10
+ main.warriorSkillAry[5].pas1
+ main.warriorSkillAry[6].pas2
+ main.warriorSkillAry[6].pas3
+ main.warriorSkillAry[7].pas1
+ main.angelSkillAry[0].pas4 + main.angelSkillAry[0].pas5
            + main.angelSkillAry[4].pas1 + main.angelSkillAry[4].pas2 + main.angelSkillAry[4].pas4           
)
            * StatsMultiFromR4Skill()
;

        if (main.ally.job == Job.Warrior)
            return (1 + main.warriorSkillAry[0].pas4 + main.warriorSkillAry[0].pas5
            + main.warriorSkillAry[1].pas7 + main.warriorSkillAry[1].pas8
            + main.warriorSkillAry[2].pas3
            + main.warriorSkillAry[4].pas9 + main.warriorSkillAry[4].pas10
            + main.warriorSkillAry[5].pas1
            + main.warriorSkillAry[6].pas2
            + main.warriorSkillAry[6].pas3
            + main.warriorSkillAry[7].pas1
            )
                        * StatsMultiFromR4Skill()
;
        else if (main.ally.job == Job.Wizard)
            return (1)
                            * StatsMultiFromR4Skill()
;
        else if (main.ally.job == Job.Angel)
            return (1 + main.angelSkillAry[0].pas4 + main.angelSkillAry[0].pas5
            + main.angelSkillAry[4].pas1 + main.angelSkillAry[4].pas2 + main.angelSkillAry[4].pas4
            )
                        * StatsMultiFromR4Skill()
;
        else
            return 1;
    }
    public double ATK_bank()
    {
        return main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.S_technical].TotalEffect();
    }

    public double tempMatkFactor;


    public double wizardPassiveStaffFactor;
    public double alchemyMAtkFactor;

    public virtual double MAtk()
    {
        return addMATK() * mulMATK() * (1 + alchemyMAtkFactor);
        ;
    }

    public double angelPassiveFactor;

    public double addMATK()
    {
        return initialMAtk
            + L_MATK()
            + buffMAtkFactor
            + main.StatusUpgrade[1].calculateCurrentValue()
            + main.ArtifactFactor.ADD_MATK()
            + MATK_bank()
            + main.SR.R_MATK
            + main.keyf.A_matk
            + main.S.wisdomLevel
            + ArtifactBonus.MATK_ADD
            ;
    }
    public double mulMATK()
    {
        return MATK_passiveSkill() * (1 + main.QuestCtrl.R_fairy()) * (1 + main.Ascends[8].calculateCurrentValue())
                       * (1 + main.ArtifactFactor.MUL_MATK())
              * tempMatkFactor * (1 + Mile_matk)
                           * (1 + wizardPassiveStaffFactor) * (1 + main.keyf.M_atk) * (1 - angelPassiveFactor) * (1 + main.rein.R_factor.StatusIncrease())
                           * SumMulDelegate(main.cc.cf.AllStatusMul)
                           * LegendaryEffect.StatsBonus()
            * main.MissionMileStoneHidden.StatsFactor()
            * (1 + ArtifactBonus.MATK_MUL)
                           ;
    }
    public double MATK_bank()
    {
        return main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.M_technical].TotalEffect();
    }
    public double MATK_ritualUpgrade()
    {
        return main.StatusUpgrade[1].calculateCurrentValue();
    }
    public double MATK_passiveSkill()
    {
        if (main.MissionMileStone.IsSkillPassiveEffect())
            return (1 + main.wizardSkillAry[0].pas4
    + main.wizardSkillAry[1].pas1 + main.wizardSkillAry[1].pas2 + main.wizardSkillAry[1].pas3
    + main.wizardSkillAry[3].pas1
    + main.wizardSkillAry[4].pas2 + main.wizardSkillAry[4].pas3 + main.wizardSkillAry[4].pas5 + main.wizardSkillAry[4].pas6
    + main.wizardSkillAry[5].pas8
    + main.wizardSkillAry[7].pas7
    + main.wizardSkillAry[9].pas3
                    + main.angelSkillAry[1].pas4 + main.angelSkillAry[1].pas5
                + main.angelSkillAry[5].pas1 + main.angelSkillAry[5].pas2 + main.angelSkillAry[5].pas4
    )
                * StatsMultiFromR4Skill()
;

        if (main.ally.job == Job.Warrior)
            return (1)
                            * StatsMultiFromR4Skill()
;
        else if (main.ally.job == Job.Wizard)
            return (1 + main.wizardSkillAry[0].pas4
                + main.wizardSkillAry[1].pas1 + main.wizardSkillAry[1].pas2 + main.wizardSkillAry[1].pas3
                + main.wizardSkillAry[3].pas1
                + main.wizardSkillAry[4].pas2 + main.wizardSkillAry[4].pas3 + main.wizardSkillAry[4].pas5 + main.wizardSkillAry[4].pas6
                + main.wizardSkillAry[5].pas8
                + main.wizardSkillAry[7].pas7
                + main.wizardSkillAry[9].pas3
                )
                            * StatsMultiFromR4Skill()
;
        else if (main.ally.job == Job.Angel)
            return (1 
                + main.angelSkillAry[1].pas4 + main.angelSkillAry[1].pas5
                + main.angelSkillAry[5].pas1 + main.angelSkillAry[5].pas2 + main.angelSkillAry[5].pas4
                )
                            * StatsMultiFromR4Skill()
;
        else
            return 1;

    }

    public double tempDefFactor;
    public double warriorPassiveShieldFactor;
    public double alchemyDefFactor;

    public virtual double Def()
    {
        if (main.cc.CurrentCurseId == CurseId.curse_of_blood)
            return 0;
        return addDEF() * mulDEF() * (1+alchemyDefFactor);
    }
    public double addDEF()
    {
        return initialDef
            + L_DEF()
            + (buffDefFactor)
            + main.ArtifactFactor.ADD_DEF()
            + DEF_ritualUpgrade()
            + main.SR.R_DEF
            + main.keyf.A_def
            + main.S.muscleLevel
            + ArtifactBonus.DEF_ADD
            ;
    }
    public double mulDEF()
    {
        return DEF_passiveSkill()
        * (1 + main.Ascends[4].calculateCurrentValue())
        * (1 + main.ArtifactFactor.MUL_DEF())
            * (1 + main.QuestCtrl.R_golem())
            * tempDefFactor * (1 + Mile_def)
            * (1 - warriorPassiveSwordFactor)
            * (1 + warriorPassiveShieldFactor)
            * (1 + main.keyf.M_def) * (1 + main.rein.R_factor.StatusIncrease()) * SumMulDelegate(main.cc.cf.AllStatusMul)
            * LegendaryEffect.StatsBonus()
            * main.MissionMileStoneHidden.StatsFactor()
            * (1 + ArtifactBonus.DEF_MUL)
            ;
    }

    public double DEF_ritualUpgrade()
    {
        return (main.StatusUpgrade[2].calculateCurrentValue() / 4);
    }
    public double DEF_passiveSkill()
    {
        if (main.MissionMileStone.IsSkillPassiveEffect())
            return (1 + main.warriorSkillAry[8].pas3 + main.warriorSkillAry[8].pas5 + main.warriorSkillAry[8].pas8
            + main.warriorSkillAry[9].pas3 + main.warriorSkillAry[9].pas6
                        + main.wizardSkillAry[5].pas1 + main.wizardSkillAry[5].pas4
                                    + main.angelSkillAry[6].pas1 + main.angelSkillAry[6].pas3 + main.angelSkillAry[6].pas5
            )
                        * StatsMultiFromR4Skill()
;

        if (main.ally.job == Job.Warrior)
            return (1 + main.warriorSkillAry[8].pas3 + main.warriorSkillAry[8].pas5 + main.warriorSkillAry[8].pas8
            + main.warriorSkillAry[9].pas3 + main.warriorSkillAry[9].pas6
            )
                        * StatsMultiFromR4Skill()
;
        else if (main.ally.job == Job.Wizard)
            return (1 
            + main.wizardSkillAry[5].pas1 + main.wizardSkillAry[5].pas4
            )
                        * StatsMultiFromR4Skill()
;
        else if (main.ally.job == Job.Angel)
            return (1 
            + main.angelSkillAry[6].pas1 + main.angelSkillAry[6].pas3 + main.angelSkillAry[6].pas5
            )
                        * StatsMultiFromR4Skill()
;
        else
            return 1;

    }

    public double tempMdefFactor;
    public double alchemyMDefFactor;

    public virtual double MDef()
    {
        if (main.cc.CurrentCurseId == CurseId.curse_of_blood)
            return 0;
        return addMDEF() * mulMDEF() * (1+alchemyMDefFactor);        
    }
    public double addMDEF()
    {
        return initialMDef
            + L_MDEF()
            + (buffMDefFactor)
            + main.ArtifactFactor.ADD_MDEF()
            + MDEF_ritualUpgrade()
            + main.SR.R_MDEF
            + main.keyf.A_mdef
            + main.S.wisdomLevel
            + ArtifactBonus.MDEF_ADD
            ;
    }
    public double mulMDEF()
    {
        return MDEF_passiveSkill()
        * (1 + main.Ascends[9].calculateCurrentValue()) * (1 + main.ArtifactFactor.MUL_MDEF())
        * (1 + main.QuestCtrl.R_golem())
        * tempMdefFactor * (1 + Mile_mdef)
        * (1 - wizardPassiveStaffFactor)
         * (1 + warriorPassiveShieldFactor)
         * (1 + main.keyf.M_mdef) * (1 + main.rein.R_factor.StatusIncrease()) * SumMulDelegate(main.cc.cf.AllStatusMul)
         * LegendaryEffect.StatsBonus()
         * main.MissionMileStoneHidden.StatsFactor()
         * (1 + ArtifactBonus.MDEF_MUL)
         ;
    }
    public double MDEF_ritualUpgrade()
    {
        return (main.StatusUpgrade[2].calculateCurrentValue() / 4);
    }
    public double MDEF_passiveSkill()
    {
        if (main.MissionMileStone.IsSkillPassiveEffect())
            return (1 + main.warriorSkillAry[8].pas6 + main.warriorSkillAry[8].pas9
            + main.warriorSkillAry[9].pas4 + main.warriorSkillAry[9].pas7
                        + main.wizardSkillAry[5].pas2 + main.wizardSkillAry[5].pas5
            + main.angelSkillAry[6].pas2 + main.angelSkillAry[6].pas4 + main.angelSkillAry[6].pas6
            )
                        * StatsMultiFromR4Skill()
;

        if (main.ally.job == Job.Warrior)
            return (1 + main.warriorSkillAry[8].pas6 + main.warriorSkillAry[8].pas9
            + main.warriorSkillAry[9].pas4 + main.warriorSkillAry[9].pas7)
                        * StatsMultiFromR4Skill()
;
        else if (main.ally.job == Job.Wizard)
            return (1 
            + main.wizardSkillAry[5].pas2 + main.wizardSkillAry[5].pas5
            )
                        * StatsMultiFromR4Skill()
;
        else if (main.ally.job == Job.Angel)
            return (1 
            + main.angelSkillAry[6].pas2 + main.angelSkillAry[6].pas4 + main.angelSkillAry[6].pas6)
                        * StatsMultiFromR4Skill()
;
        else
            return 1;


    }

    public virtual float Speed()
    {
        return addSPD() * mulSPD() + bonusSPD();
        ;
    }
    public float addSPD()
    {
        return (float)(initialSpeed + L_SPD() + main.ArtifactFactor.ADD_SPD()
            + SPD_ritualUpgrade() + main.SR.R_SPD + main.keyf.A_spd
            + main.S.agilityLevel
            );
    }
    public float mulSPD()
    {
        return (float)(SPD_passiveSkill()
             * (1 + buffSpdFactor) * (1 + main.QuestCtrl.R_bananoon()) * (1 + main.Ascends[12].calculateCurrentValue())
            * (1 + main.ArtifactFactor.MUL_SPD()) * (1+ Mile_spd) * (1 + main.keyf.M_spd) * (1 + main.rein.R_factor.StatusIncrease())
            * SumMulDelegate(main.cc.cf.AllStatusMul)
            * LegendaryEffect.StatsBonus()
            * main.MissionMileStoneHidden.StatsFactor())
            ;
    }
    public float bonusSPD()
    {
        return buffSpdFactor2;
    }


    public double SPD_ritualUpgrade()
    {
        return main.StatusUpgrade[2].calculateCurrentValue() * 5;
    }
    public double SPD_passiveSkill()
    {
        if (main.MissionMileStone.IsSkillPassiveEffect())
            return (1 + main.warriorSkillAry[2].pas2 + main.warriorSkillAry[2].pas4
                   + main.warriorSkillAry[1].pas9
                                      + main.wizardSkillAry[7].pas2 + main.wizardSkillAry[7].pas5 + main.wizardSkillAry[7].pas8
                   + main.wizardSkillAry[9].pas1 + main.wizardSkillAry[9].pas4
                                      + main.angelSkillAry[1].pas6
                   + main.angelSkillAry[3].pas5
                   + main.angelSkillAry[7].pas1 + main.angelSkillAry[7].pas2 + main.angelSkillAry[7].pas4
                )
                            * StatsMultiFromR4Skill()
;

        if (main.ally.job == Job.Warrior)
            return (1 + main.warriorSkillAry[2].pas2 + main.warriorSkillAry[2].pas4
                   + main.warriorSkillAry[1].pas9
                )
                            * StatsMultiFromR4Skill()
;
        else if (main.ally.job == Job.Wizard)
            return (1
                   + main.wizardSkillAry[7].pas2 + main.wizardSkillAry[7].pas5 + main.wizardSkillAry[7].pas8
                   + main.wizardSkillAry[9].pas1 + main.wizardSkillAry[9].pas4
                )
                            * StatsMultiFromR4Skill()
;
        else if (main.ally.job == Job.Angel)
            return (1 
                   + main.angelSkillAry[1].pas6
                   + main.angelSkillAry[3].pas5
                   + main.angelSkillAry[7].pas1 + main.angelSkillAry[7].pas2 + main.angelSkillAry[7].pas4
                )
                            * StatsMultiFromR4Skill()
;
        else
            return 1;

    }

    //public virtual float Range()
    //{
    //    return initialRange;
    //}

    public void UpdateAlly()
    {
        main.HPSlider.value = (float)(currentHp / HP());
        main.MPSlider.value = MP() == 0 ? 0 : (float)(currentMp / MP());

        if (currentHp >= HP())
        {
            currentHp = HP();
        }
        if (currentMp >= MP())
        {
            currentMp = MP();
        }
        if (currentMp < 0)
        {
            currentMp = 0;
        }

        main.ExpSlider.value = (float)(currentExp / RequiredExp());
        main.Texts[9].text = "<color=yellow>*</color>Range : " + tDigit(BattleRange());
        main.Texts[11].text = "EXP : " + tDigit((currentExp / RequiredExp()) * 100, 3) + "%";
        main.Texts[12].text = "EXP  :  " + tDigit(currentExp) + " / " + tDigit(RequiredExp());
        //経験値の処理を行う．
        if (currentExp >= RequiredExp())
        {
            currentExp -= RequiredExp();
            LevelUp();
        }

        if (condition == Condition.BattleMode)
        {
            if (!canAttak())
            {
                condition = Condition.MoveMode;
            }
        }

        //職業のテキストを変更する．
        switch (job)
        {
            case Job.Novice:
                main.JobImage.sprite = null;
                main.JobImage.color = new Color(0, 0, 0, 0);
                main.MyStatusTexts[0].text = main.TextEdit(new string[] { "Novice   <color=\"green\">Lv ", Level().ToString(), "</color>" });
                break;
            case Job.Warrior:
                if (main.SR.isReinClassSprite)
                    main.JobImage.sprite = main.JobSprites[3];
                else
                    main.JobImage.sprite = main.JobSprites[0];
                main.JobImage.color = new Color(255, 255, 255, 255);
                main.MyStatusTexts[0].text = main.TextEdit(new string[] { "Warrior   <color=\"green\">Lv ", Level().ToString(), "</color>" });
                break;
            case Job.Wizard:
                if (main.SR.isReinClassSprite)
                    main.JobImage.sprite = main.JobSprites[4];
                else
                    main.JobImage.sprite = main.JobSprites[1];
                main.JobImage.color = new Color(255, 255, 255, 255);
                main.MyStatusTexts[0].text = main.TextEdit(new string[] { "Wizard   <color=\"green\">Lv ", Level().ToString(), "</color>" });
                break;
            case Job.Angel:
                if (main.SR.isReinClassSprite)
                    main.JobImage.sprite = main.JobSprites[5];
                else
                    main.JobImage.sprite = main.JobSprites[2];
                main.JobImage.color = new Color(255, 255, 255, 255);
                main.MyStatusTexts[0].text = main.TextEdit(new string[] { "Angel  <color=\"green\">Lv ", Level().ToString(), "</color>" });
                break;
        }


        // ステータスのテキストを更新する．
        if (isBuff[(int)Main.Buff.maxHp])
        {
            main.MyStatusTexts[1].text = "        " + tDigit(currentHp) + " / <color=\"green\">" + tDigit(HP());
        }
        else
        {
            buffHpFactor = 0;
            main.MyStatusTexts[1].text = "        " + tDigit(currentHp) + " / " + tDigit(HP());
        }

        main.MyStatusTexts[2].text = "        " + tDigit(currentMp) + " / " + tDigit(MP());

        if (isDebuff[(int)Main.Debuff.atkDown])
        {
            main.MyStatusTexts[3].text = "<color=\"red\">" + tDigit(Atk()); ;
        }
        else if (isBuff[(int)Main.Buff.muscleInflation])
        {
            main.MyStatusTexts[3].text = "<color=\"green\">" + tDigit(Atk()); ;
        }
        else
        {
            main.ally.buffAtkFactor = 0;
            main.MyStatusTexts[3].text = tDigit(Atk());
        }

        if (isDebuff[(int)Main.Debuff.mAtkDown])
        {
            main.MyStatusTexts[4].text = "<color=\"red\">" + tDigit(MAtk()); ;
        }
        else if (isBuff[(int)Main.Buff.magicImpact])
        {
            main.MyStatusTexts[4].text = "<color=\"green\">" + tDigit(MAtk()); ;
        }
        else
        {
            buffMAtkFactor = 0;
            main.MyStatusTexts[4].text = tDigit(MAtk());
        }

        if (isDebuff[(int)Main.Debuff.defDown])
        {
            main.MyStatusTexts[5].text = "<color=\"red\">" + tDigit(Def()); ;
        }
        else if (isBuff[(int)Main.Buff.def])
        {
            main.MyStatusTexts[5].text = "<color=\"green\">" + tDigit(Def()); ;
        }
        else
        {
            buffDefFactor = 0;
            main.MyStatusTexts[5].text = tDigit(Def());
        }

        if (isDebuff[(int)Main.Debuff.mDefDown])
        {
            main.MyStatusTexts[6].text = "<color=\"red\">" + tDigit(MDef()); ;
        }
        else if (isBuff[(int)Main.Buff.mDef])
        {
            main.MyStatusTexts[6].text = "<color=\"green\">" + tDigit(MDef()); ;
        }
        else
        {
            buffMDefFactor = 0;
            main.MyStatusTexts[6].text = tDigit(MDef());
        }

        if (isBuff[(int)Main.Buff.spd])
        {
            main.MyStatusTexts[7].text = "<color=\"green\">" + tDigit(Speed()); ;
        }
        else
        {
            buffSpdFactor = 0;
            main.MyStatusTexts[7].text = tDigit(Speed());
        }

        if (main.S.ReincarnationNum >= 2)
        {
            if (main.S.ReincarnationNum >= 3 && main.S.job == Job.Warrior && main.warriorSkillAry[12].P_level > 0 && main.warriorSkillAry[12].IsEquipped() && main.warriorSkillAry[12].Damage() > 0)
            {
                main.Texts[4].text = main.TextEdit(new string[] { "<i><color=orange><size=10>Standing-still for </size> ", DoubleTimeToDate(stayTime), "</color></i>\n<size=10><color=yellow>Physical Damage + ", percent(main.warriorSkillAry[12].Damage(), 1) });
            }
            else if (main.S.job==Job.Wizard && main.wizardSkillAry[11].P_level > 0 && main.wizardSkillAry[11].IsEquipped() && combo >= 1)
            {
                main.Texts[4].text = main.TextEdit(new string[] { "<i><color=orange>", combo.ToString(), " <size=10>COMBO!!</color></i>\n<color=yellow>Magical Damage + ", percent(main.wizardSkillAry[11].Damage(), 1) });
            }
            else
                main.Texts[4].text = "";
        }
        
    }

    public int[] timeStep;
    public IEnumerator NormilizeStatus()
    {
        timeStep = new int[isBuff.Length];
        while (true)
        {
            for (int i = 0; i < isBuff.Length; i++)
            {
                if (isBuff[i])
                {
                    timeStep[i]++;
                    if (timeStep[i] >= 30)
                    {
                        isBuff[i] = false;
                        timeStep[i] = 0;
                    }
                }
                else
                {
                    timeStep[i] = 0;
                }
            }
            yield return new WaitForSeconds(1.0f);
        }
    }



    public void StartAlly()
    {
        updateJobStatus();
        isDebuff = new bool[System.Enum.GetValues(typeof(Main.Debuff)).Length];
        // isBuff = new bool[System.Enum.GetValues(typeof(Main.Buff)).Length
        main.SR.currentHp = HP();
        tempAtkFactor = 1.0f;
        tempMatkFactor = 1.0f;
        tempDefFactor = 1.0f;
        tempMdefFactor = 1.0f;
        StartCoroutine(Move());
        //StartCoroutine(NormilizeStatus());
        StartCoroutine(Regen());
        StartCoroutine(ChangeSprite());
        StartCoroutine(ManualMove());
        StartCoroutine(InstantiateBanana());
        StartCoroutine(CalculateMile());
        StartCoroutine(BackToAutoWhenIdling());
        //ここで職業を選択する
        foreach (Button buttons in main.jobButton)
        {
            buttons.onClick.AddListener(() => confirmFirstClass(Array.IndexOf(main.jobButton, buttons)));
        }

        main.SR.currentHp = HP();
        if (main.SR.currentExp >= RequiredExp())
            main.SR.currentExp = RequiredExp() - 1;

        StartCoroutine(ResurrectionReset());

        //職業のテキストを変更する．
        switch (job)
        {
            case Job.Novice:
                main.JobImage.sprite = null;
                main.JobImage.color = new Color(0, 0, 0, 0);
                main.MyStatusTexts[0].text = main.TextEdit(new string[] { "Novice   <color=\"green\">Lv ", Level().ToString(), "</color>" });
                break;
            case Job.Warrior:
                if(main.SR.isReinClassSprite)
                    main.JobImage.sprite = main.JobSprites[3];
                else
                    main.JobImage.sprite = main.JobSprites[0];
                main.JobImage.color = new Color(255, 255, 255, 255);
                main.MyStatusTexts[0].text = main.TextEdit(new string[] { "Warrior   <color=\"green\">Lv ", Level().ToString(), "</color>" });
                break;
            case Job.Wizard:
                if (main.SR.isReinClassSprite)
                    main.JobImage.sprite = main.JobSprites[4];
                else
                    main.JobImage.sprite = main.JobSprites[1];
                main.JobImage.color = new Color(255, 255, 255, 255);
                main.MyStatusTexts[0].text = main.TextEdit(new string[] { "Wizard   <color=\"green\">Lv ", Level().ToString(), "</color>" });
                break;
            case Job.Angel:
                if (main.SR.isReinClassSprite)
                    main.JobImage.sprite = main.JobSprites[5];
                else
                    main.JobImage.sprite = main.JobSprites[2];
                main.JobImage.color = new Color(255, 255, 255, 255);
                main.MyStatusTexts[0].text = main.TextEdit(new string[] { "Angel  <color=\"green\">Lv ", Level().ToString(), "</color>" });
                break;
        }

        //AutoRein後
        if (main.S.didAutoRein)
        {
            StartCoroutine(AutoRein());
            main.S.didAutoRein = false;
        }
        //AutoRebirth後
        if (main.S.didAutoRebirth)
        {
            StartCoroutine(AutoRebirth());
            main.S.didAutoRebirth = false;
        }

    }
    IEnumerator AutoRebirth()
    {
        yield return new WaitForSeconds(1.0f);
        main.titleCtrl.StartGame();
    }
    IEnumerator AutoRein()
    {
        yield return new WaitForSeconds(1.0f);
        main.titleCtrl.StartGame();
        yield return new WaitForSeconds(3.0f);
        switch (main.S.autoReinJob)
        {
            case Warrior:
                confirmFirstClass(0);
                yield return new WaitForSeconds(1.0f);
                confirmWindow.transform.GetChild(3).GetComponent<Button>().onClick.Invoke();
                break;
            case Wizard:
                confirmFirstClass(1);
                yield return new WaitForSeconds(1.0f);
                confirmWindow.transform.GetChild(3).GetComponent<Button>().onClick.Invoke();
                break;
            case Angel:
                confirmFirstClass(2);
                yield return new WaitForSeconds(1.0f);
                confirmWindow.transform.GetChild(3).GetComponent<Button>().onClick.Invoke();
                break;
            default:
                break;
        }
    }

    bool canResurrection;

    IEnumerator ResurrectionReset()
    {
        while (true)
        {
            isResurrection = false;
            canResurrection = false;
            if (main.SR.P_GodBless && UnityEngine.Random.Range(0, 10000) < resurrectionChance * 10000)
                canResurrection = true;
            yield return new WaitForSeconds(0.5f);
        }
    }

    public double initialHp;
    public double initialMp;
    public virtual double currentMp { get; set; }
    public virtual double currentHp { get; set; }
    public double initialAtk;
    public double initialMAtk;
    public double initialDef;
    public double initialMDef;
    public double initialMpRegen;
    //public float initialRange;
    public float initialSpeed;


    public virtual void Attacked() { }

    public RectTransform thisRect;
    public Condition condition;
    public enum Condition
    {
        MoveMode,
        BattleMode
    }
    public Job job { get => main.S.job; set => main.S.job = value; }
    Condition IDamagable.condition { get => condition; set => condition = value; }

    public enum Job
    {
        Novice,
        Warrior,
        Wizard,
        Angel,
        all
    }

    //索敵の関数
    public ENEMY targetEnemy;
    public virtual ENEMY SearchEnemy()
    {
        GameObject[] taggedEnemy = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject game in taggedEnemy)
        {
            if (game.GetComponent<ENEMY>().isTargetted)
                return game.GetComponent<ENEMY>();
        }

        if (taggedEnemy == null || taggedEnemy.Length == 0) { return null; }
        float minDistance = 9999999;
        float tempDistance = 0;
        int tempIndex = 0; 
        for (int i = 0; i < taggedEnemy.Length; i++)
        {
            tempDistance = vectorAbs(gameObject.GetComponent<RectTransform>().anchoredPosition - taggedEnemy[i].GetComponent<RectTransform>().anchoredPosition);
            if (tempDistance < minDistance) { minDistance = tempDistance; tempIndex = i; }
        }
        return taggedEnemy[tempIndex].GetComponent<ENEMY>();
    }

    public bool canAttak()
    {
        GameObject[] currentEnemies;
        currentEnemies = GameObject.FindGameObjectsWithTag("enemy");
        List<GameObject> attackableEnemes = new List<GameObject>();
        foreach (GameObject game in currentEnemies)
        {
            if (vectorAbs(main.ally1.GetComponent<RectTransform>().anchoredPosition - game.GetComponent<RectTransform>().anchoredPosition)
                - game.GetComponent<ENEMY>().buffer <= BattleRange())
            {
                attackableEnemes.Add(game);
            }
        }
        if (attackableEnemes.Count == 0) { return false; }
        else { return true; }
    }

    public float BindingFactor=0f;
    public float moveSpeedFactor() {
        if(main.toggles[14].isOn)
            return main.S.customSpeed/100f * Mathf.Min(Mathf.Log10((1000f + main.ally.Speed()) / 100f), 10f) * (1 / (1 + BindingFactor)) * (1 + main.skillprogress.movespeedFactor);
        return Mathf.Min(Mathf.Log10((1000f + main.ally.Speed()) / 100f), 10f) * ( 1 / (1+BindingFactor)) * (1+main.skillprogress.movespeedFactor);
    }

    //衣装を変えるときはここから
    public Sprite[] SlimeSetSprites;
    public SlimeSet SlimeSet;
    public Sprite[] FairySetSprites;
    public FairySet FairySet;
    public Sprite[] FoxSetSprites;
    public FoxSet FoxSet;


    public IEnumerator ChangeSprite()
    {
        while (true)
        {
            if (sprites.Length == 0 || intervals.Length == 0)
            {
                break;
            }

            if (sprites.Length != intervals.Length)
            {
                break;
            }

            if (main.GameController.isDlcIEH2)
            {
                if (job == Warrior)
                {
                    gameObject.GetComponent<Image>().sprite = null;
                    gameObject.GetComponent<Image>().sprite = ieh2sprites[0];
                    yield return new WaitForSeconds(intervals[0]);
                    gameObject.GetComponent<Image>().sprite = null;
                    gameObject.GetComponent<Image>().sprite = ieh2sprites[1];
                    yield return new WaitForSeconds(intervals[1]);
                }
                else if (job == Wizard)
                {
                    gameObject.GetComponent<Image>().sprite = null;
                    gameObject.GetComponent<Image>().sprite = ieh2sprites[2];
                    yield return new WaitForSeconds(intervals[0]);
                    gameObject.GetComponent<Image>().sprite = null;
                    gameObject.GetComponent<Image>().sprite = ieh2sprites[3];
                    yield return new WaitForSeconds(intervals[1]);
                }
                else if (job == Angel)
                {
                    gameObject.GetComponent<Image>().sprite = null;
                    gameObject.GetComponent<Image>().sprite = ieh2sprites[4];
                    yield return new WaitForSeconds(intervals[0]);
                    gameObject.GetComponent<Image>().sprite = null;
                    gameObject.GetComponent<Image>().sprite = ieh2sprites[5];
                    yield return new WaitForSeconds(intervals[1]);
                }
                else
                {
                    gameObject.GetComponent<Image>().sprite = null;
                    gameObject.GetComponent<Image>().sprite = ieh2sprites[4];
                    yield return new WaitForSeconds(intervals[0]);
                    gameObject.GetComponent<Image>().sprite = null;
                    gameObject.GetComponent<Image>().sprite = ieh2sprites[5];
                    yield return new WaitForSeconds(intervals[1]);
                }
            }
            else
            {
                if (job == Warrior)
                {
                    if (FoxSet.isFoxSet())
                    {
                        gameObject.GetComponent<Image>().sprite = null;
                        gameObject.GetComponent<Image>().sprite = FoxSetSprites[0];
                        yield return new WaitForSeconds(intervals[0]);
                        gameObject.GetComponent<Image>().sprite = null;
                        gameObject.GetComponent<Image>().sprite = FoxSetSprites[1];
                        yield return new WaitForSeconds(intervals[1]);
                    }
                    else
                    {
                        if (SlimeSet.SetSlime)
                        {
                            if (FairySet.isFairySet())
                            {
                                gameObject.GetComponent<Image>().sprite = null;
                                gameObject.GetComponent<Image>().sprite = FairySetSprites[0];
                                yield return new WaitForSeconds(intervals[0]);
                                gameObject.GetComponent<Image>().sprite = null;
                                gameObject.GetComponent<Image>().sprite = FairySetSprites[1];
                                yield return new WaitForSeconds(intervals[1]);
                            }
                            else
                            {
                                gameObject.GetComponent<Image>().sprite = null;
                                gameObject.GetComponent<Image>().sprite = SlimeSetSprites[0];
                                yield return new WaitForSeconds(intervals[0]);
                                gameObject.GetComponent<Image>().sprite = null;
                                gameObject.GetComponent<Image>().sprite = SlimeSetSprites[1];
                                yield return new WaitForSeconds(intervals[1]);
                            }
                        }
                        else
                        {
                            if (FairySet.isFairySet())
                            {
                                gameObject.GetComponent<Image>().sprite = null;
                                gameObject.GetComponent<Image>().sprite = FairySetSprites[0];
                                yield return new WaitForSeconds(intervals[0]);
                                gameObject.GetComponent<Image>().sprite = null;
                                gameObject.GetComponent<Image>().sprite = FairySetSprites[1];
                                yield return new WaitForSeconds(intervals[1]);
                            }
                            else
                            {
                                gameObject.GetComponent<Image>().sprite = null;
                                gameObject.GetComponent<Image>().sprite = sprites[0];
                                yield return new WaitForSeconds(intervals[0]);
                                gameObject.GetComponent<Image>().sprite = null;
                                gameObject.GetComponent<Image>().sprite = sprites[1];
                                yield return new WaitForSeconds(intervals[1]);
                            }
                        }

                    }
                }
                else if (job == Wizard)
                {
                    if (FoxSet.isFoxSet())
                    {
                        gameObject.GetComponent<Image>().sprite = null;
                        gameObject.GetComponent<Image>().sprite = FoxSetSprites[2];
                        yield return new WaitForSeconds(intervals[0]);
                        gameObject.GetComponent<Image>().sprite = null;
                        gameObject.GetComponent<Image>().sprite = FoxSetSprites[3];
                        yield return new WaitForSeconds(intervals[1]);
                    }
                    else
                    {
                        if (SlimeSet.SetSlime)
                        {
                            if (FairySet.isFairySet())
                            {
                                gameObject.GetComponent<Image>().sprite = null;
                                gameObject.GetComponent<Image>().sprite = FairySetSprites[2];
                                yield return new WaitForSeconds(intervals[0]);
                                gameObject.GetComponent<Image>().sprite = null;
                                gameObject.GetComponent<Image>().sprite = FairySetSprites[3];
                                yield return new WaitForSeconds(intervals[1]);

                            }
                            else
                            {
                                gameObject.GetComponent<Image>().sprite = null;
                                gameObject.GetComponent<Image>().sprite = SlimeSetSprites[2];
                                yield return new WaitForSeconds(intervals[0]);
                                gameObject.GetComponent<Image>().sprite = null;
                                gameObject.GetComponent<Image>().sprite = SlimeSetSprites[3];
                                yield return new WaitForSeconds(intervals[1]);

                            }
                        }
                        else
                        {
                            if (FairySet.isFairySet())
                            {
                                gameObject.GetComponent<Image>().sprite = null;
                                gameObject.GetComponent<Image>().sprite = FairySetSprites[2];
                                yield return new WaitForSeconds(intervals[0]);
                                gameObject.GetComponent<Image>().sprite = null;
                                gameObject.GetComponent<Image>().sprite = FairySetSprites[3];
                                yield return new WaitForSeconds(intervals[1]);

                            }
                            else
                            {
                                gameObject.GetComponent<Image>().sprite = null;
                                gameObject.GetComponent<Image>().sprite = sprites[2];
                                yield return new WaitForSeconds(intervals[2]);
                                gameObject.GetComponent<Image>().sprite = null;
                                gameObject.GetComponent<Image>().sprite = sprites[3];
                                yield return new WaitForSeconds(intervals[3]);
                            }
                        }

                    }
                }
                else if (job == Angel)
                {
                    if (FoxSet.isFoxSet())
                    {
                        gameObject.GetComponent<Image>().sprite = null;
                        gameObject.GetComponent<Image>().sprite = FoxSetSprites[4];
                        yield return new WaitForSeconds(intervals[0]);
                        gameObject.GetComponent<Image>().sprite = null;
                        gameObject.GetComponent<Image>().sprite = FoxSetSprites[5];
                        yield return new WaitForSeconds(intervals[1]);
                    }
                    else
                    {
                        if (SlimeSet.SetSlime)
                        {
                            if (FairySet.isFairySet())
                            {
                                gameObject.GetComponent<Image>().sprite = null;
                                gameObject.GetComponent<Image>().sprite = FairySetSprites[4];
                                yield return new WaitForSeconds(intervals[0]);
                                gameObject.GetComponent<Image>().sprite = null;
                                gameObject.GetComponent<Image>().sprite = FairySetSprites[5];
                                yield return new WaitForSeconds(intervals[1]);
                            }
                            else
                            {
                                gameObject.GetComponent<Image>().sprite = null;
                                gameObject.GetComponent<Image>().sprite = SlimeSetSprites[4];
                                yield return new WaitForSeconds(intervals[0]);
                                gameObject.GetComponent<Image>().sprite = null;
                                gameObject.GetComponent<Image>().sprite = SlimeSetSprites[5];
                                yield return new WaitForSeconds(intervals[1]);
                            }
                        }
                        else
                        {
                            gameObject.GetComponent<Image>().sprite = null;
                            gameObject.GetComponent<Image>().sprite = sprites[4];
                            yield return new WaitForSeconds(intervals[4]);
                            gameObject.GetComponent<Image>().sprite = null;
                            gameObject.GetComponent<Image>().sprite = sprites[5];
                            yield return new WaitForSeconds(intervals[5]);
                        }

                    }
                }
                else
                {
                    if (FairySet.isFairySet())
                    {
                        gameObject.GetComponent<Image>().sprite = null;
                        gameObject.GetComponent<Image>().sprite = FairySetSprites[4];
                        yield return new WaitForSeconds(intervals[0]);
                        gameObject.GetComponent<Image>().sprite = null;
                        gameObject.GetComponent<Image>().sprite = FairySetSprites[5];
                        yield return new WaitForSeconds(intervals[1]);
                    }
                    else
                    {
                        gameObject.GetComponent<Image>().sprite = null;
                        gameObject.GetComponent<Image>().sprite = sprites[0];
                        yield return new WaitForSeconds(intervals[0]);
                        gameObject.GetComponent<Image>().sprite = null;
                        gameObject.GetComponent<Image>().sprite = sprites[1];
                        yield return new WaitForSeconds(intervals[1]);
                    }
                }
            }
        }
    }
    public bool isMoving;
    double buffer;
    Vector2 moveDistance;
    public IEnumerator Move()
    {
        main.ally1.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -150);
        yield return new WaitUntil(() => job != Novice);
        yield return new WaitUntil(() => TitleCtrl.isLoaded);
        while (true)
        {
            isMoving = false;
            yield return new WaitUntil(() => !Another.SwitchWorld.isAnotherWorld && main.GameController.isAuto);//another
            if (targetEnemy == null)
            {
                targetEnemy = SearchEnemy();    
                yield return new WaitForSeconds(0.05f);
            }
            else
            {
                switch (condition)
                {
                    case Condition.MoveMode:
                        isMoving = true;
                        buffer = targetEnemy.buffer;
                        moveDistance = targetEnemy.GetComponent<RectTransform>().anchoredPosition - thisRect.anchoredPosition;
                        if (vectorAbs(moveDistance) - buffer <= BattleRange())
                        {
                            condition = Condition.BattleMode;
                        }

                        //倍速・三倍速等遣る場合にはifで分岐させましょう!!!
                        thisRect.anchoredPosition +=
                            normalize(moveDistance) * 4f * (1 - Convert.ToInt32(main.GameController.isFieldEffect) / 2)
                            * moveSpeedFactor() * ((float)main.ArtifactFactor.SpeedRate + 1) * Time.timeScale
                            * (1 + main.dungeonAry[(int)main.GameController.currentDungeon].CurrentMoveSpeedBonus());
                        main.S.WalkDistance += vectorAbs(normalize(moveDistance) * 4f * (1 - Convert.ToInt32(main.GameController.isFieldEffect) / 2)
                            * moveSpeedFactor() * ((float)main.ArtifactFactor.SpeedRate + 1) * Time.timeScale)
                            * (1 + main.dungeonAry[(int)main.GameController.currentDungeon].CurrentMoveSpeedBonus());
                        yield return new WaitForSeconds(0.017f);
                        break;
                    case Condition.BattleMode:
                        isMoving = false;
                        yield return new WaitForSeconds(0.017f);
                        break;
                }
            }
        }
    }
    public bool isInputText;
    public IEnumerator ManualMove()
    {
        while (true)
        {
            isMoving = false;
            Vector2 moveDistance = new Vector2(0, 0);
            //yield return new WaitUntil(() => !main.GameController.isAuto);
            yield return new WaitUntil(() => !Another.SwitchWorld.isAnotherWorld && !isInputText && ( Direction(direction.down) || Direction(direction.up) || Direction(direction.right) || Direction(direction.left)));
            main.toggles[3].isOn = true;
            isMoving = true;
            //↑
            if (Direction(direction.up) && thisRect.anchoredPosition.y <= 240)
            {
                moveDistance = new Vector2(0, 1);
            }
            //↓
            if (Direction(direction.down) && thisRect.anchoredPosition.y >= -240)
            {
                moveDistance = new Vector2(0, -1);
            }
            //→矢印を推しているとき
            if (Direction(direction.right) && thisRect.anchoredPosition.x <= 225)
            {
                moveDistance = new Vector2(1, 0);
                if (Direction(direction.up) && thisRect.anchoredPosition.y <= 240)
                {
                    moveDistance = new Vector2(1, 1);
                }
                else if (Direction(direction.down) && thisRect.anchoredPosition.y >= -240)
                {
                    moveDistance = new Vector2(1, -1);
                }

            }
            //←矢印を推しているとき
            if (Direction(direction.left) && thisRect.anchoredPosition.x >= -225)
            {
                moveDistance = new Vector2(-1, 0);
                if ((Direction(direction.up) && thisRect.anchoredPosition.y <= 240))
                {
                    moveDistance = new Vector2(-1, 1);
                }
                else if (Direction(direction.down) && thisRect.anchoredPosition.y >= -240)
                {
                    moveDistance = new Vector2(-1, -1);
                }
            }
            
            thisRect.anchoredPosition += normalize(moveDistance) * 4f * (1 - Convert.ToInt32(main.GameController.isFieldEffect) / 2) * moveSpeedFactor()
                * (1 + main.dungeonAry[(int)main.GameController.currentDungeon].CurrentMoveSpeedBonus()) * Time.timeScale;
            main.S.WalkDistance += vectorAbs(normalize(moveDistance) * 4f * (1 - Convert.ToInt32(main.GameController.isFieldEffect) / 2) * moveSpeedFactor())
                * (1 + main.dungeonAry[(int)main.GameController.currentDungeon].CurrentMoveSpeedBonus()) * Time.timeScale;
            yield return new WaitForSeconds(0.017f);
        }
    }
    public enum direction
    {
        down,
        up,
        right,
        left
    }
    public bool Direction(direction direction)
    {
        switch (direction)
        {
            case direction.down:
                return Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
            case direction.up:
                return Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
            case direction.right:
                return Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
            case direction.left:
                return Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
            default:
                return false;
        }
    }

    IEnumerator BackToAutoWhenIdling()
    {
        //float temp = 0;
        while (true)
        {
            yield return new WaitUntil(() => main.toggles[13].isOn);
            yield return new WaitUntil(() => main.toggles[3].isOn);
            yield return new WaitForSeconds(0.05f);
            yield return new WaitUntil(() => !Input.anyKey);
            main.toggles[3].isOn = false;
            main.GameController.isAuto = true;
            //if(Input.anyKey)
            //{
            //    //temp = 0;
            //    //Debug.Log("何かキー押してるよ");
            //}
            //else
            //{
            //    temp += 1.0f;
            //}
            //yield return new WaitForSeconds(1.0f);
            //if(temp >= 3.0f)
            //{
            //    temp = 0;
            //    main.toggles[3].isOn = false;
            //    main.GameController.isAuto = true;
            //}
        }
    }

    double tempMPFactor;
    public double MpRegen()
    {
        if (CURSE_RAIN.IsRoad2())
            return 0;
        tempMPFactor = 0;
        tempMPFactor += MP() * main.jems[(int)JEM.ID.MpRegenGem].Effect();
        if (main.NewArtifacts[(int)ARTIFACT.ArtifactName.SlimeStick].isEquipped)
            tempMPFactor += MP() * main.NewArtifacts[(int)ARTIFACT.ArtifactName.SlimeStick].level * 0.0001;
        tempMPFactor += MP() * main.alchemyController.MpRegenFactor;
        return tempMPFactor;
    }
    public double MpLost()
    {
        if (main.NewArtifacts[(int)ARTIFACT.ArtifactName.HealingStaff].isEquipped && currentMp > (1000 + main.NewArtifacts[(int)ARTIFACT.ArtifactName.HealingStaff].level * 50))
            return (1000 + main.NewArtifacts[(int)ARTIFACT.ArtifactName.HealingStaff].level * 50);
        else
            return 0;
    }

    double tempFactor;
    public double HpRegen()
    {
        tempFactor = 0;
        if (isBuff[(int)Main.Buff.maxHp] && main.angelSkillAry[3].P_level >= 30)
        {
            tempFactor += HP() * main.angelSkillAry[3].RegenePoint() * 0.01;
        }
        tempFactor += HP() * main.jems[(int)JEM.ID.HpRegenGem].Effect();
        if (main.NewArtifacts[(int)ARTIFACT.ArtifactName.HealingStaff].isEquipped && currentMp > (1000 + main.NewArtifacts[(int)ARTIFACT.ArtifactName.HealingStaff].level * 50))
        {
            tempFactor += HP() * main.NewArtifacts[(int)ARTIFACT.ArtifactName.HealingStaff].GetComponent<ARTIFACT.Status>().GetValue();
        }
        tempFactor += HP() * main.alchemyController.HpRegenFactor;
        tempFactor += HP() * main.skillprogress.regeneratePointPercent * 0.01;
        return tempFactor;
    }

    public IEnumerator Regen()
    {
        yield return new WaitForSeconds(1.0f);
        while (true)
        {
            //bloodの固定regen
            currentHp += SumAddDelegate(main.cc.cf.Add_HPregen);
            currentHp += HpRegen() * 0.05;
            currentMp += MpRegen() * 0.05 + main.skillSetController.GainMPDPS() * 0.05;
            currentMp -= MpLost() * 0.05;
            yield return new WaitForSeconds(0.05f);
        }
    }
    public IEnumerator InstantiateBanana()
    {
        while (true)
        {
            yield return new WaitUntil(() => main.NewArtifacts[(int)ARTIFACT.ArtifactName.BananaCutter].isEquipped);
            GameObject game;
            for (int i = 0; i < 1+main.NewArtifacts[(int)ARTIFACT.ArtifactName.BananaCutter].level; i++)
            {
                game = Instantiate(main.animationObject[53], main.Transforms[1]);
                game.GetComponent<RectTransform>().anchoredPosition = main.ally1.GetComponent<RectTransform>().anchoredPosition;
                game.GetComponent<Attack>().damage = BananaCutterATK();
                game.GetComponent<Attack>().damageKind = SKILL.DamageKind.banana;
                game.GetComponent<Attack>().isDestroyAfterCollide = true;
                StartCoroutine(MoveBanana(game));
                yield return new WaitForSeconds(0.05f);
            }
            yield return new WaitForSeconds(2.0f);
        }
    }
    public double BananaCutterATK()
    {
        return 1;
    }
    public IEnumerator MoveBanana(GameObject game)
    {
        Vector2 random = randomVec();
        for (int i = 0; i < 50 / Math.Max(Time.timeScale, 1f); i++)
        {
            if (game != null)
                game.GetComponent<RectTransform>().anchoredPosition += random * 15f * Math.Max(Time.timeScale, 1f);
            
            yield return new WaitForSeconds(0.017f);
        }
        if (game != null)
            Destroy(game);
    }
    ////スキルの状態変化
    //public bool isBlock;
    //ダメージの計算を行う．
    public virtual double calculatedDamage(double damage = 0, double mDamage = 0, double critDamage = 0)
    { return (damage * dmgReduction(damage) + mDamage * mDmgReduction(mDamage) + critDamage) * Math.Max(Normal.Sample(1, 0.05), 0.8); }
    public double dmgReduction(double damage)
    {
        if (Def() <= 0)
        {
            return 1;
        }
        else
        {
            return 1 - Def() / (Def() + damage);
        }
    }
    public double mDmgReduction(double mDamage)
    {
        if (MDef() <= 0)
        {
            return 1;
        }
        else
        {
            return 1 - MDef() / (MDef() + mDamage);
        }
    }
    public void InstantiateStatusAbnormal(Main.Debuff debuff, double abnormalDamage)
    {
        if (debuff == Main.Debuff.nothing)
            return;

        switch (debuff)
        {
            case Main.Debuff.poison:
                //すでにポイソンがあればreturn
                if (!updateDuration(Main.Debuff.poison))
                {
                    ABNORMAL game;
                    game = Instantiate(main.StatusIcons[0], main.StatusIconCanvas);
                    game.GetComponent<ABNORMAL>().abnormalDamage = abnormalDamage;
                    if (main.NewArtifacts[(int)ARTIFACT.ArtifactName.ScaleRing].isEquipped)
                        game.GetComponent<ABNORMAL>().abnormalDamage *= Math.Max(1 - (0.25 + main.NewArtifacts[(int)ARTIFACT.ArtifactName.ScaleRing].level * 0.001d),0.25);
                }
                break;
            case Main.Debuff.atkDown:
                //すでにatkDownがあればreturn
                if (!updateDuration(Main.Debuff.atkDown))
                {
                    ABNORMAL game;
                    game = Instantiate(main.StatusIcons[9], main.StatusIconCanvas);
                    game.GetComponent<ABNORMAL>().abnormalDamage = abnormalDamage;
                    if (main.NewArtifacts[(int)ARTIFACT.ArtifactName.ScaleRing].isEquipped)
                        game.GetComponent<ABNORMAL>().abnormalDamage *= Math.Max(1 + (0.25 + main.NewArtifacts[(int)ARTIFACT.ArtifactName.ScaleRing].level * 0.001d), 0.25);
                }
                break;
            case Main.Debuff.mAtkDown:
                //すでにmAtkDownがあればreturn
                if (!updateDuration(Main.Debuff.mAtkDown))
                {
                    ABNORMAL game;
                    game = Instantiate(main.StatusIcons[10], main.StatusIconCanvas);
                    game.GetComponent<ABNORMAL>().abnormalDamage = abnormalDamage;
                    if (main.NewArtifacts[(int)ARTIFACT.ArtifactName.ScaleRing].isEquipped)
                        game.GetComponent<ABNORMAL>().abnormalDamage *= Math.Max(1 + (0.25 + main.NewArtifacts[(int)ARTIFACT.ArtifactName.ScaleRing].level * 0.001d), 0.25);
                }
                break;
            case Main.Debuff.defDown:
                if (!updateDuration(Main.Debuff.defDown))
                {
                    ABNORMAL game;
                    game = Instantiate(main.StatusIcons[12], main.StatusIconCanvas);
                    game.GetComponent<ABNORMAL>().abnormalDamage = abnormalDamage;
                    if (main.NewArtifacts[(int)ARTIFACT.ArtifactName.ScaleRing].isEquipped)
                        game.GetComponent<ABNORMAL>().abnormalDamage *= Math.Max(1 + (0.25 + main.NewArtifacts[(int)ARTIFACT.ArtifactName.ScaleRing].level * 0.001d), 0.25);
                }
                break;
            case Main.Debuff.binding:
                if (!updateDuration(Main.Debuff.binding))
                {
                    ABNORMAL game;
                    game = Instantiate(main.StatusIcons[8], main.StatusIconCanvas);
                    //game.GetComponent<ABNORMAL>().abnormalDamage = abnormalDamage;
                }
                break;

            default:
                break;
        }
    }
    public bool updateDuration(Main.Debuff debuff)
    {
        foreach (Transform child in main.StatusIconCanvas.transform)
        {
            if (child.GetComponent<ABNORMAL>().debuff == debuff)
            {
                child.GetComponent<ABNORMAL>().currentDuration = 0;
                return true;
            }
        }
        return false;
    }
    public bool updateDuration(Main.Buff buff)
    {
        foreach (Transform child in main.StatusIconCanvas.transform)
        {
            if (child.GetComponent<ABNORMAL>().buff == buff)
            {
                child.GetComponent<ABNORMAL>().currentDuration = 0;
                return true;
            }
        }
        return false;
    }
    public int alchemyDebuffResistanceFactor;
    public bool isMagicalGuard;
    //敵からの攻撃を受けた時．
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.HasComponent<Attack>() || collision.gameObject.tag == "effect")
            return;

        if (isResurrection)
            return;

        if (isMagicalGuard)
            return;

        SKILL.DamageKind damageKind;
        Main.Debuff thisDebuff = Main.Debuff.nothing;
        damageKind = collision.GetComponent<Attack>().damageKind;
        thisDebuff = collision.GetComponent<Attack>().thisDebuff;
        //衝突したときの独自の判定を行う．
        collision.GetComponent<Attack>().CollisionEvent();

        double damage;
        double mDamage;
        double critDamage;
        //回避処理
        if (UnityEngine.Random.Range(0, 10000) <= Math.Min(10000 * main.ArtifactFactor.DodgeRate + main.skillprogress.dodgeChancePercent * 100 + main.warriorSkillAry[12].pas3*10000, 7000))//Max70%
        {
            if (!main.systemController.noMoreDamageTxt)
                InstantiateText("Dodge!!", Color.blue);
            Destroy(collision.gameObject);
            return;
        }
        //Blockの処理
        if (main.isBlock)
        {
            if (!main.systemController.noMoreDamageTxt)
                InstantiateText("Block!!", damageKind);
            foreach (SKILL skill in main.warriorSkillAry)
            {
                if (skill.canGetExp)
                {
                    if (skill.skillLineage == "Shield")
                    {
                        skill.GetProExp(1);
                    }
                    else
                    {
                        skill.GetProExp(0.1);

                    }
                }
            }
            return;
        }

        damage = collision.GetComponent<Attack>().damage;
        mDamage = collision.GetComponent<Attack>().mDamage;
        critDamage = collision.GetComponent<Attack>().critDamage;

        //ダメージをカットする．
        damage -= damage * Math.Min((main.ArtifactFactor.PhysicalDef()),0.8);
        mDamage -= mDamage * Math.Min((main.ArtifactFactor.MagicalDef()),0.8);

        //BloodCurseの追加カット
        damage *= main.cc.cf.Blood_DamageReduction();
        mDamage *= main.cc.cf.Blood_DamageReduction();

        if (collision.GetComponent<Attack>().isDestroyAfterCollide) { Destroy(collision.gameObject); }

        double totalDamage;
        totalDamage = calculatedDamage(damage, mDamage, critDamage);

        if (main.S.job == Job.Wizard && main.wizardSkillAry[12].IsEquipped())//Magical Guard
        {
            if (isMagicalGuard)
                return;

            if (main.wizardSkillAry[12].P_level >= 200 && currentMp >= MP() * 0.99999)//Lv200のパッシブ
            {
                isMagicalGuard = true;
                return;
            }

            if (UnityEngine.Random.Range(0, 10000) < main.wizardSkillAry[12].Chance() * 10000)
            {
                isMagicalGuard = true;
                return;
            }

            if (currentMp >= totalDamage / Math.Max(main.wizardSkillAry[12].Damage(), 1))
            {
                currentMp -= totalDamage / Math.Max(main.wizardSkillAry[12].Damage(), 1);
                if (!main.systemController.noMoreDamageTxt)
                    InstantiateText("Guard!!", Color.blue);
                return;
            }
            else
            {
                totalDamage -= currentMp * main.warriorSkillAry[12].Damage();
                currentMp = 0;//ここも
            }
        }

        //Combo
        if (main.wizardSkillAry[11].P_level >= 100)
            combo = (long)(combo / 2d);
        else
            combo = 0;


        //状態異常の処理
        if (isBuff[(int)Main.Buff.maxHp])
        {
            if (UnityEngine.Random.Range(0, 10000) >= main.angelSkillAry[3].DebuffResistance() + main.ArtifactFactor.DebuffResistance + alchemyDebuffResistanceFactor)
            {
                InstantiateStatusAbnormal(thisDebuff, collision.GetComponent<Attack>().abnormalDamage);
            }
        }
        else
        {
            if (UnityEngine.Random.Range(0, 10000) >= main.ArtifactFactor.DebuffResistance + alchemyDebuffResistanceFactor)
            {
                InstantiateStatusAbnormal(thisDebuff, collision.GetComponent<Attack>().abnormalDamage);
            }
        }


        //BlockStance
        if (!isPassiveBlockActivated)
        {



            if (totalDamage >= currentHp)
            {
                if (canResurrection)
                {
                    isResurrection = true;
                    return;
                }
                else
                {
                    currentHp -= totalDamage;
                }
            }
            else
            {
                currentHp -= totalDamage;
            }
        }
        else
            currentBlockHp -= totalDamage;



        if (main.SR.P_Block)
            main.warriorSkillAry[9].attackNum = UnityEngine.Random.Range(0, 10000);

        if (totalDamage > 0)
        {
            DUNGEON.isAttacked = true;
        }
        InstantiateDamage(totalDamage, damageKind);

        if (isResurrection)
        {
            return;
        }
        //死んだときの処理
        if (currentHp <= 0)
        {
            //Nightmare Exploreだった場合、curse idを通常に戻します。
            if (main.cc.CurrentCurseId == CurseId.curse_of_explore)
                main.cc.CurrentCurseId = CurseId.normal;

                foreach (Transform child in main.StatusIconCanvas.transform)
                {
                    Destroy(child.GetComponent<ABNORMAL>().gameObject);
                }
                currentHp = 0;
                if (!isDead)
                {
                    isDead = true;
                }
                main.DeathPanel.isDead = true;
                Vector2 position = gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(175, 45);
                GameObject Text1;
                Text1 = Instantiate(main.prefabAry_H[1], main.DeathShowCanvas);
                Text1.GetComponent<RectTransform>().anchoredPosition = position;
                main.ally1.GetComponent<RectTransform>().anchoredPosition = new Vector2(350, -100000);
                StartCoroutine(DeathWhenNormalMode());
        }
        //InstantiateDamage(calculatedDamage(damage, mDamage, critDamage), damageKind);
    }
    public double MaxBlockHp;
    public double currentBlockHp;
    public bool isPassiveBlockActivated;
    public double resurrectionChance;
    public bool isResurrection;
    IEnumerator DeathWhenNormalMode()
    {
        yield return new WaitForSeconds(1.0f);
        main.SR.currentHp = HP();
    }
    public void InstantiateText(string text, Color color)
    {

        GameObject Text;
        Text = Instantiate(main.prefabAry_H[0], gameObject.transform);
        Text.GetComponent<RectTransform>().anchoredPosition = new Vector2(UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-10, 10));
        Text.GetComponentInChildren<TextMeshProUGUI>().text = text;
        Text.GetComponentInChildren<TextMeshProUGUI>().color = color;
    }
    public void InstantiateTextOnMe(string text, Color color)
    {

        GameObject Text;
        Text = Instantiate(main.prefabAry_H[0], gameObject.transform);
        Text.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
        Text.GetComponentInChildren<TextMeshProUGUI>().text = text;
        Text.GetComponentInChildren<TextMeshProUGUI>().color = color;
    }

    public virtual void InstantiateText(string text, SKILL.DamageKind damageKind)
    {
        switch (damageKind)
        {
            case SKILL.DamageKind.physical:
                GameObject Text;
                Text = Instantiate(main.prefabAry_H[0], gameObject.transform);
                Text.GetComponent<RectTransform>().anchoredPosition = new Vector2(UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-10, 10));
                Text.GetComponentInChildren<TextMeshProUGUI>().text = text;
                //StartCoroutine(destroyObject(Text));
                GameObject Animation;
                Animation = Instantiate(main.animationObject[3], gameObject.transform);
                Animation.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
                //StartCoroutine(main.InstantiateAnimation(main.animationObject[3], main.ally1.GetComponent<RectTransform>(), 0, 0, SKILL.DamageKind.physical));
                break;

            case SKILL.DamageKind.magical:
                GameObject TextMag;
                TextMag = Instantiate(main.prefabAry_H[0], gameObject.transform);
                TextMag.GetComponentInChildren<TextMeshProUGUI>().color = Color.magenta;
                TextMag.GetComponent<RectTransform>().anchoredPosition = new Vector2(UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-10, 10));
                TextMag.GetComponentInChildren<TextMeshProUGUI>().text = text;
                //StartCoroutine(destroyObject(TextMag));
                GameObject AnimationMag;
                AnimationMag = Instantiate(main.animationObject[3], gameObject.transform);
                AnimationMag.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
                break;
        }
    }
    public virtual void InstantiateDamage(double damage, SKILL.DamageKind damageKind)
    {
        if (!main.systemController.noMoreDamageTxt)
        {

            switch (damageKind)
            {
                case SKILL.DamageKind.physical:
                    GameObject damageText;
                    damageText = Instantiate(main.prefabAry_H[0], gameObject.transform);
                    damageText.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    damageText.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition/6;
                    damageText.GetComponent<RectTransform>().anchoredPosition += new Vector2(UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-10, 0));
                    damageText.GetComponentInChildren<TextMeshProUGUI>().text = "- " + tDigit(damage, 1);
                    break;

                case SKILL.DamageKind.magical:
                    GameObject damageTextMag;
                    damageTextMag = Instantiate(main.prefabAry_H[0], gameObject.transform);
                    damageTextMag.GetComponentInChildren<TextMeshProUGUI>().color = magical;
                    damageTextMag.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition/6;
                    damageTextMag.GetComponent<RectTransform>().anchoredPosition += new Vector2(UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-10, 0));
                    damageTextMag.GetComponentInChildren<TextMeshProUGUI>().text = "- " + tDigit(damage, 1);
                    break;

                case SKILL.DamageKind.electrical:
                    GameObject damageTextElect;
                    damageTextElect = Instantiate(main.prefabAry_H[0], gameObject.transform);
                    damageTextElect.GetComponentInChildren<TextMeshProUGUI>().color = Color.yellow;
                    damageTextElect.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition/6;
                    damageTextElect.GetComponent<RectTransform>().anchoredPosition += new Vector2(UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-10, 0));
                    damageTextElect.GetComponentInChildren<TextMeshProUGUI>().text = "- " + tDigit(damage, 1);
                    break;

                default:
                    GameObject damageTextN;
                    damageTextN = Instantiate(main.prefabAry_H[0], gameObject.transform);
                    damageTextN.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                    damageTextN.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition/6;
                    damageTextN.GetComponent<RectTransform>().anchoredPosition += new Vector2(UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-10, 0));
                    damageTextN.GetComponentInChildren<TextMeshProUGUI>().text = "- " + tDigit(damage, 1);
                    break;
            }
        }
    }

    Color magical = new Color(255f / 255f, 150f / 255f, 0f);

    GameObject confirmWindow;
    void confirmFirstClass(int index)
    {
        confirmWindow = Instantiate(main.P_texts[26], main.FirstConfirmCanvas);
        Title.Proceed(confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>(), index);
        confirmWindow.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() => Destroy(confirmWindow));
        confirmWindow.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(() =>
        {
            confirmWindow.transform.GetChild(3).GetComponent<Button>().interactable = false;
            foreach (Button buttons in main.jobButton)
            {
                buttons.GetComponent<Button>().interactable = false;
            }
            StartCoroutine(GameStart(index));
        });
    }
    IEnumerator GameStart(int index)
    {
        Title.Proceed2(confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>());
        yield return new WaitForSeconds(2f);
        Destroy(confirmWindow);
        Destroy(main.GameController.ChooseFirstWeapon, 1.0f);
        ChooseJob(index);
    }

    //最初の職業を選ぶ．
    public void ChooseJob(int index)
    {
        switch (index)
        {
            case 0:
                job = Job.Warrior;
                main.warriorSkillAry[0].P_level = 1;
                main.warriorSkillAry[0].canGetExp = true;
                main.skillSlotCanvasAry[0].currentSkill = main.warriorSkillAry[0];
                main.skillSlotCanvasAry[0].saveSkillId = 1;
                break;
            case 1:
                job = Job.Wizard;
                main.wizardSkillAry[0].P_level = 1;
                main.wizardSkillAry[0].canGetExp = true;
                main.skillSlotCanvasAry[0].currentSkill = main.wizardSkillAry[0];
                main.skillSlotCanvasAry[0].saveSkillId = 11;
                break;
            case 2:
                job = Job.Angel;
                main.angelSkillAry[0].P_level = 1;
                main.angelSkillAry[0].canGetExp = true;
                main.skillSlotCanvasAry[0].currentSkill = main.angelSkillAry[0];
                main.skillSlotCanvasAry[0].saveSkillId = 21;
                break;
        }
        main.dungeonAry[0].TryDungeon();
        updateJobStatus();
        //deleteChooseButton();
        main.GameController.isJobbed = true;
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
                yield return new WaitForSeconds(0.05f);
            }
            else
            {
                game.GetComponent<TextMeshProUGUI>().color -= new Color(0, 0, 0, 0.05f);
                yield return new WaitForSeconds(0.05f);
            }

        }
        Destroy(main.GameController.ChooseFirstWeapon);
    }

    public void InstantiateText()
    {
        throw new NotImplementedException();
    }
}
