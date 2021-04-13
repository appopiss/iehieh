using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;
using TMPro;

public class SkillLocal : BASE, ILocalizedText
{
    //public TextMeshProUGUI[] jobTexts;
    public void UpdateText(Language lang)
    {
        //LocalizeInitialize.SetFont(jobTexts);
        //switch (lang)
        //{
        //    case Language.eng:
        //        jobTexts[0].text = "                                      Warrior";
        //        jobTexts[1].text = "                                      Wizard";
        //        jobTexts[2].text = "                                      Angel";
        //        jobTexts[3].text = "                                      Warrior";
        //        jobTexts[4].text = "                                      Wizard";
        //        jobTexts[5].text = "                                      Angel";
        //        break;
        //    case Language.jp:
        //        jobTexts[0].text = "                                      戦士";
        //        jobTexts[1].text = "                                      魔法使い";
        //        jobTexts[2].text = "                                      天使";
        //        jobTexts[3].text = "あああああああ";
        //        jobTexts[4].text = "                             魔法使い\n               (転生)";
        //        jobTexts[5].text = "                             天使 (転生)";
        //        break;
        //}
    }

    public static string BaseForName(string skillNameString)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                return "                 " + skillNameString;
            case Language.jp:
                return "                   " + skillNameString;
            case Language.chi:
                return "                 " + skillNameString;
        }
        return "                 " + skillNameString;
    }
    public static string BaseForLinage(string linageString)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                return "                     Lineage : " + linageString + "\n   \n   ";
            case Language.jp:
                return "                         血統 : " + linageString + "\n   ";
            case Language.chi:
                return "                     血统 : " + linageString + "\n   ";
        }
        return "                     Lineage : " + linageString + "\n   \n   ";
    }
    public static string EffectString()
    {
        switch (LocalizeInitialize.language)
        {
            case Language.jp:
                return "効果";
            case Language.chi:
                return "被动技能";
            default:
                return "Effect";
        }
    }
    public static string DescriptionString()
    {
        switch (LocalizeInitialize.language)
        {
            case Language.jp:
                return "説明";
            case Language.chi:
                return "技能介绍";
            default:
                return "Description";
        }
    }
    public static string PassiveEffect()
    {
        switch (LocalizeInitialize.language)
        {
            case Language.jp:
                return "パッシブ効果";
            case Language.chi:
                return "被动效果";
            default:
                return "Passive Effect";
        }
    }
    public static string RequiredSkill()
    {
        switch (LocalizeInitialize.language)
        {
            case Language.jp:
                return "必要スキル";
            case Language.chi:
                return "技能要求";
            default:
                return "Required Skill";
        }
    }
    static string effectTemplate(SKILL skill,int multiple = 0, SKILL.DamageKind kind = SKILL.DamageKind.physical)
    {
        string mult = "";
        string damageKind = "";
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                damageKind = kind == SKILL.DamageKind.physical ? "- Physical damage : " : "- Magical damage : ";
                if (multiple != 0) mult = optStr + " * " + multiple.ToString();
               return optStr + damageKind + tDigit(skill.Damage(), 2) + mult + "\n- Interval : "
                    + tDigit(skill.AttackInterval(), 2) + "\n- Range : " + tDigit(skill.attackRange, 2);
            case Language.jp:
                damageKind = kind == SKILL.DamageKind.physical ? "- 物理ダメージ : " : "- 魔法ダメージ : ";
                if (multiple != 0) mult = optStr + " x " + multiple.ToString();
                return optStr + damageKind + tDigit(skill.Damage(), 2) + mult + "\n- 攻撃間隔 : "
                    + tDigit(skill.AttackInterval(), 2) + "\n- 攻撃範囲 : " + tDigit(skill.attackRange, 2);
            case Language.chi:
                damageKind = kind == SKILL.DamageKind.physical ? "- 物理伤害 : " : "- 魔法伤害 : ";
                if (multiple != 0) mult = optStr + " * " + multiple.ToString();
                return optStr + damageKind + tDigit(skill.Damage(), 2) + mult + "\n- 技能冷却 : "
                     + tDigit(skill.AttackInterval(), 2) + "\n- 攻击距离 : " + tDigit(skill.attackRange, 2);
            default:
                damageKind = kind == SKILL.DamageKind.physical ? "- Physical damage : " : "- Magical damage : ";
                if (multiple != 0) mult = optStr + " * " + multiple.ToString();
                return optStr + damageKind + tDigit(skill.Damage(), 2) + mult + "\n- Interval : "
                     + tDigit(skill.AttackInterval(), 2) + "\n- Range : " + tDigit(skill.attackRange, 2);
        }
    }
    static string descriptionTemplate(SKILL skill, string description, bool isGain = true)
    {
        string gainorlost = "";
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                gainorlost = skill.ConsumeMp() < 0 ? "Gain " : "Lost ";
                if (skill.ConsumeMp() > 0)
                {
                    return optStr + "- " + gainorlost + tDigit(skill.ConsumeMp(), 2) +
                        " MP / trigger\n- " + description;
                }
                else
                {
                    return optStr + "- " + gainorlost + tDigit(Math.Abs(skill.ConsumeMp()) / skill.AttackInterval(), 2) +
                        " MP / s\n- " + description;
                }
            case Language.jp:
                gainorlost = skill.ConsumeMp() < 0 ? "<color=green>得られる</color=green>MP" : "<color=red>失う</color=red>MP";
                if (skill.ConsumeMp() > 0)//失う
                {
                    return optStr + "- 1回発動あたり" + gainorlost + " : " + tDigit(Math.Abs(skill.ConsumeMp()), 2) +
                        "\n- " + description;
                }
                else
                {
                    return optStr + "- 1秒間に" + gainorlost + " : " + tDigit((Math.Abs(skill.ConsumeMp())) / skill.AttackInterval(), 2) +
                        "\n- " + description;
                }
            case Language.chi:
                gainorlost = skill.ConsumeMp() < 0 ? "收益 " : "丢失 ";
                if (skill.ConsumeMp() > 0)
                {
                    return optStr + "- " + gainorlost + tDigit(skill.ConsumeMp(), 2) +
                        " MP / trigger\n- " + description;
                }
                else
                {
                    return optStr + "- " + gainorlost + tDigit(Math.Abs(skill.ConsumeMp()) / skill.AttackInterval(), 2) +
                        " MP / s\n- " + description;
                }
            default:
                gainorlost = skill.ConsumeMp() < 0 ? "收益 " : "丢失 ";
                if (skill.ConsumeMp() < 0)
                {
                    return optStr + "- " + gainorlost + tDigit(skill.ConsumeMp(), 2) +
                        " MP / trigger\n- " + description;
                }
                else
                {
                    return optStr + "- " + gainorlost + tDigit((skill.ConsumeMp()) / skill.AttackInterval(), 2) +
                        " MP / s\n- " + description;
                }
        }
    }
    static string costTemplate(SKILL skill,ALLY.Job job)
    {
        string resource = "";
        double cost = 0;
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                switch (job) 
                {
                    case ALLY.Job.Warrior:
                        resource = "stones";
                        cost = skill.CostStone();
                        break;
                    case ALLY.Job.Wizard:
                        resource = "crystals";
                        cost = skill.CostCristal();
                        break;
                    case ALLY.Job.Angel:
                        resource = "leaves";
                        cost = skill.CostLeaf();
                        break;
                    default:
                        resource = "";
                        break;
                }
                return "- Gain 1.0% / " + tDigit(skill.P_requiredExp() / (skill.culGetExp() * 100), 2)
                    + " attacks\n- Gain 1.0% / " + tDigit(cost, 2) +  " " +resource;
            case Language.jp:
                switch (job)
                {
                    case ALLY.Job.Warrior:
                        resource = "ストーン";
                        cost = skill.CostStone();
                        break;
                    case ALLY.Job.Wizard:
                        resource = "クリスタル";
                        cost = skill.CostCristal();
                        break;
                    case ALLY.Job.Angel:
                        resource = "リーフ";
                        cost = skill.CostLeaf();
                        break;
                    default:
                        resource = "";
                        break;
                }
                return "- 1%に必要な攻撃回数 : " + tDigit(skill.P_requiredExp() / (skill.culGetExp() * 100), 2)
                    + " \n- 1%に必要な" + resource + " : " + tDigit(cost, 2);
            case Language.chi:
                switch (job)
                {
                    case ALLY.Job.Warrior:
                        resource = "石头";
                        cost = skill.CostStone();
                        break;
                    case ALLY.Job.Wizard:
                        resource = "水晶";
                        cost = skill.CostCristal();
                        break;
                    case ALLY.Job.Angel:
                        resource = "叶子";
                        cost = skill.CostLeaf();
                        break;
                    default:
                        resource = "";
                        break;
                }
                return "- 收益 1.0% / " + tDigit(skill.P_requiredExp() / (skill.culGetExp() * 100), 2)
                    + " 攻击\n- 收益 1.0% / " + tDigit(cost, 2) + " " + resource;
            default:
                switch (job)
                {
                    case ALLY.Job.Warrior:
                        resource = "stones";
                        cost = skill.CostStone();
                        break;
                    case ALLY.Job.Wizard:
                        resource = "crystals";
                        cost = skill.CostCristal();
                        break;
                    case ALLY.Job.Angel:
                        resource = "leafs";
                        cost = skill.CostLeaf();
                        break;
                    default:
                        resource = "";
                        break;
                }
                return "- Gain 1.0% / " + tDigit(skill.P_requiredExp() / (skill.culGetExp() * 100), 2)
                    + " attacks\n- Gain 1.0% / " + tDigit(cost, 2) + " " + resource;
        }
    }
    static string nameTemplate(SKILL skill, string Name)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                return Name + " < <color=\"green\">Lv " + skill.BuffedLevelString() + " </color>>";
            case Language.jp:
                return Name + " < <color=\"green\">Lv " + skill.BuffedLevelString() + " </color>>";
            case Language.chi:
                return Name + " < <color=\"green\">Lv " + skill.BuffedLevelString() + " </color>>";
            default:
                return Name + " < <color=\"green\">Lv " + skill.BuffedLevelString() + " </color>>";
        }
    }
    static string LinageTemplate(string linage)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                return linage;
            case Language.jp:
                return linage;
            case Language.chi:
                return linage;
            default:
                return linage;
        }
    }

    public static void S_warrior(SKILL skill, ref string skillNameString, ref string linageString, ref string effectString, ref string explainString, ref string costString)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                skillNameString = nameTemplate(skill, "Sword Attack");
                linageString = LinageTemplate("Warrior Base");
                effectString = effectTemplate(skill);
                explainString = descriptionTemplate(skill, "Classical attack as warrior, simply physical damage.");
                costString = costTemplate(skill, ALLY.Job.Warrior);
                break;
            case Language.jp:
                skillNameString = nameTemplate(skill, "ソードアタック");
                linageString = LinageTemplate("戦士");
                effectString = effectTemplate(skill);
                explainString = descriptionTemplate(skill, "戦士の基本的な攻撃で、相手にダメージを与える. ");
                costString = costTemplate(skill, ALLY.Job.Warrior);
                break;
            case Language.chi:
                skillNameString = nameTemplate(skill, "剑击");
                linageString = LinageTemplate("战士");
                effectString = effectTemplate(skill);
                explainString = descriptionTemplate(skill, "战士的普通攻击.");
                costString = costTemplate(skill, ALLY.Job.Warrior);
                break;
            default:
                skillNameString = nameTemplate(skill, "Sword Attack");
                linageString = LinageTemplate("Warrior Base");
                effectString = effectTemplate(skill);
                explainString = descriptionTemplate(skill, "Classical attack as warrior, simply physical damage.");
                costString = costTemplate(skill, ALLY.Job.Warrior);
                break;
        }
    }

    public static void slash(SKILL skill, ref string skillNameString, ref string linageString, ref string effectString, ref string explainString, ref string costString)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                skillNameString = nameTemplate(skill, "Slash");
                linageString = "Warrior <color=#00C8FF>Sword</color>";
                effectString = effectTemplate(skill);
                explainString = descriptionTemplate(skill, "Slash an enemy simply by the sword.");
                costString = costTemplate(skill, ALLY.Job.Warrior);
                break;
            case Language.jp:
                skillNameString = nameTemplate(skill, "スラッシュ");
                linageString = LinageTemplate("戦士 : <color=#00C8FF>剣</color>");
                effectString = effectTemplate(skill);
                explainString = descriptionTemplate(skill, "敵一体を切りきざみます. ");
                costString = costTemplate(skill, ALLY.Job.Warrior);
                break;
            case Language.chi:
                skillNameString = nameTemplate(skill, "砍击");
                linageString = LinageTemplate("战士 : <color=#00C8FF>剑</color>");
                effectString = effectTemplate(skill);
                explainString = descriptionTemplate(skill, "使用重剑砍击敌人.");
                costString = costTemplate(skill, ALLY.Job.Warrior);
                break;


            default:
                skillNameString = nameTemplate(skill, "Slash");
                linageString = "Warrior <color=#00C8FF>Sword</color>";
                effectString = effectTemplate(skill);
                explainString = descriptionTemplate(skill, "Slash an enemy simply by the sword.");
                costString = costTemplate(skill, ALLY.Job.Warrior);
                break;
        }
    }

    public static void doubleslash(SKILL skill, ref string skillNameString, ref string linageString, ref string effectString, ref string explainString, ref string costString)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                skillNameString = nameTemplate(skill, "Double Slash");
                linageString = "Warrior <color=#00C8FF>Sword</color>";
                effectString = effectTemplate(skill);
                explainString = descriptionTemplate(skill, "Make double attacks against an enemy by the sword.", false);
                costString = costTemplate(skill, ALLY.Job.Warrior);
                break;
            case Language.jp:
                skillNameString = nameTemplate(skill, "ダブルスラッシュ");
                linageString = LinageTemplate("戦士 : <color=#00C8FF>剣</color>");
                effectString = effectTemplate(skill);
                explainString = descriptionTemplate(skill, "敵一体を２回攻撃で切りきざみます. ", false);
                costString = costTemplate(skill, ALLY.Job.Warrior);
                break;
            case Language.chi:
                skillNameString = nameTemplate(skill, "二连击");
                linageString = LinageTemplate("战士 : <color=#00C8FF>剑</color>");
                effectString = effectTemplate(skill);
                explainString = descriptionTemplate(skill, "快速的对敌人造成2次攻击.", false);
                costString = costTemplate(skill, ALLY.Job.Warrior);
                break;


            default:
                skillNameString = nameTemplate(skill, "Double Slash");
                linageString = "Warrior <color=#00C8FF>Sword</color>";
                effectString = effectTemplate(skill);
                explainString = descriptionTemplate(skill, "Make double attacks against an enemy by the sword.", false);
                costString = costTemplate(skill, ALLY.Job.Warrior);
                break;
        }
    }

    public static void swingaround(SKILL skill, ref string skillNameString, ref string linageString, ref string effectString, ref string explainString, ref string costString)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                skillNameString = nameTemplate(skill, "Swing Around");
                linageString = "Warrior <color=#00C8FF>Sword</color>";
                effectString = effectTemplate(skill);
                explainString = descriptionTemplate(skill, "Swing the large sword around monsters.", false);
                costString = costTemplate(skill, ALLY.Job.Warrior);
                break;
            case Language.jp:
                skillNameString = nameTemplate(skill, "なぎはらい");
                linageString = LinageTemplate("戦士 : <color=#00C8FF>剣</color>");
                effectString = effectTemplate(skill);
                explainString = descriptionTemplate(skill, "大きな剣で敵をなぎはらいます. ", false);
                costString = costTemplate(skill, ALLY.Job.Warrior);
                break;
            case Language.chi:
                skillNameString = nameTemplate(skill, "横扫");
                linageString = LinageTemplate("战士 : <color=#00C8FF>剑</color>");
                effectString = effectTemplate(skill);
                explainString = descriptionTemplate(skill, "砍出一道剑气, 对正面大量敌人造成伤害.", false);
                costString = costTemplate(skill, ALLY.Job.Warrior);
                break;

            default:
                skillNameString = nameTemplate(skill, "Swing Around");
                linageString = "Warrior <color=#00C8FF>Sword</color>";
                effectString = effectTemplate(skill);
                explainString = descriptionTemplate(skill, "Swing the large sword around monsters.", false);
                costString = costTemplate(skill, ALLY.Job.Warrior);
                break;
        }
    }

    public static void swingdown(SKILL skill, ref string skillNameString, ref string linageString, ref string effectString, ref string explainString, ref string costString)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                skillNameString = nameTemplate(skill, "Swing Down");
                linageString = "Warrior <color=#00C8FF>Sword</color>";
                effectString = effectTemplate(skill);
                explainString = descriptionTemplate(skill, "Swing down the certain large sword strongly.", false);
                costString = costTemplate(skill, ALLY.Job.Warrior);
                break;
            case Language.jp:
                skillNameString = nameTemplate(skill, "振り下ろし");
                linageString = LinageTemplate("戦士 : <color=#00C8FF>剣</color>");
                effectString = effectTemplate(skill);
                explainString = descriptionTemplate(skill, "大きな剣を力強く振り下ろします. ", false);
                costString = costTemplate(skill, ALLY.Job.Warrior);
                break;
            case Language.chi:
                skillNameString = nameTemplate(skill, "重击");
                linageString = LinageTemplate("战士 : <color=#00C8FF>剑</color>");
                effectString = effectTemplate(skill);
                explainString = descriptionTemplate(skill, "猛烈的挥出大剑砍倒敌人.", false);
                costString = costTemplate(skill, ALLY.Job.Warrior);
                break;

            default:
                skillNameString = nameTemplate(skill, "Swing Down");
                linageString = "Warrior <color=#00C8FF>Sword</color>";
                effectString = effectTemplate(skill);
                explainString = descriptionTemplate(skill, "Swing down the certain large sword strongly.", false);
                costString = costTemplate(skill, ALLY.Job.Warrior);
                break;
        }
    }
    public static void sonicslash(SKILL skill, ref string skillNameString, ref string linageString, ref string effectString, ref string explainString, ref string costString)
    {
        SonicSlash sonicSlash = skill as SonicSlash;
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                skillNameString = nameTemplate(skill, "Sonic Slash");
                linageString = "Warrior <color=#00C8FF>Sword</color>";
                effectString = effectTemplate(skill, sonicSlash.temp());
                explainString = descriptionTemplate(skill, "Make quick slashes against a monster.\n  Target monster can't see what has happend.", false);
                costString = costTemplate(skill, ALLY.Job.Warrior);
                break;
            case Language.jp:
                skillNameString = nameTemplate(skill, "ソニックスラッシュ");
                linageString = LinageTemplate("戦士 : <color=#00C8FF>剣</color>");
                effectString = effectTemplate(skill, sonicSlash.temp());
                explainString = descriptionTemplate(skill, "敵に対して素早く斬撃をあたえます. \n敵は何が起こったのか分かりません. ", false);
                costString = costTemplate(skill, ALLY.Job.Warrior);
                break;
            case Language.chi:
                skillNameString = nameTemplate(skill, "音速斩击");
                linageString = LinageTemplate("战士 : <color=#00C8FF>剑</color>");
                effectString = effectTemplate(skill, sonicSlash.temp());
                explainString = descriptionTemplate(skill, "神不知鬼不觉的对敌人造成多次攻击.", false);
                costString = costTemplate(skill, ALLY.Job.Warrior);
                break;

            default:
                skillNameString = nameTemplate(skill, "Sonic Slash");
                linageString = "Warrior <color=#00C8FF>Sword</color>";
                effectString = effectTemplate(skill, sonicSlash.temp());
                explainString = descriptionTemplate(skill, "Make quick slashes against a monster.\n  Target monster can't see what has happend.", false);
                costString = costTemplate(skill, ALLY.Job.Warrior);
                break;
        }
    }
    public static void chargeswings(SKILL skill, ref string skillNameString, ref string linageString, ref string effectString, ref string explainString, ref string costString)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                skillNameString = nameTemplate(skill, "Charge Swing");
                linageString = "Warrior <color=#00C8FF>Sword</color>";
                effectString = effectTemplate(skill);
                explainString = descriptionTemplate(skill, "Powerful attack with the large sword to destroy an enemy.", false);
                costString = costTemplate(skill, ALLY.Job.Warrior);
                break;
            case Language.jp:
                skillNameString = nameTemplate(skill, "チャージスイング");
                linageString = LinageTemplate("戦士 : <color=#00C8FF>剣</color>");
                effectString = effectTemplate(skill);
                explainString = descriptionTemplate(skill, "巨大な剣を振り下ろして敵を破壊する. ", false);
                costString = costTemplate(skill, ALLY.Job.Warrior);
                break;
            case Language.chi:
                skillNameString = nameTemplate(skill, "会心重击");
                linageString = LinageTemplate("战士: <color=#00C8FF>剑</color>");
                effectString = effectTemplate(skill);
                explainString = descriptionTemplate(skill, "猛烈的挥出巨剑撕裂敌人.", false);
                costString = costTemplate(skill, ALLY.Job.Warrior);
                break;

            default:
                skillNameString = nameTemplate(skill, "Charge Swing");
                linageString = "Warrior <color=#00C8FF>Sword</color>";
                effectString = effectTemplate(skill);
                explainString = descriptionTemplate(skill, "Powerful attack with the large sword to destroy an enemy.", false);
                costString = costTemplate(skill, ALLY.Job.Warrior);
                break;
        }
    }
    public static void fanswing(SKILL skill, ref string skillNameString, ref string linageString, ref string effectString, ref string explainString, ref string costString)
    {
        FanSwing fan = skill as FanSwing;
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                skillNameString = nameTemplate(skill, "Fan Swing");
                linageString = "Warrior <color=#00C8FF>Sword</color>";
                effectString = effectTemplate(skill, fan.temp());
                explainString = descriptionTemplate(skill, "Swing the sword quickly to make sword doppelgangers,\n  additional attack with shock waves aginst around monsters.", false);
                costString = costTemplate(skill, ALLY.Job.Warrior);
                break;
            case Language.jp:
                skillNameString = nameTemplate(skill, "ファンスイング");
                linageString = LinageTemplate("戦士 : <color=#00C8FF>剣</color>");
                effectString = effectTemplate(skill, fan.temp());
                explainString = descriptionTemplate(skill, "剣の生霊を呼び起こし、剣波で周囲の敵に連続攻撃を行う. ", false);
                costString = costTemplate(skill, ALLY.Job.Warrior);
                break;
            case Language.chi:
                skillNameString = nameTemplate(skill, "剑刃风暴");
                linageString = LinageTemplate("战士 : <color=#00C8FF>剑</color>");
                effectString = effectTemplate(skill, fan.temp());
                explainString = descriptionTemplate(skill, "唤起剑灵对周围产生剑气并撕裂周围的敌人.", false);
                costString = costTemplate(skill, ALLY.Job.Warrior);
                break;

            default:
                skillNameString = nameTemplate(skill, "Fan Swing");
                linageString = "Warrior <color=#00C8FF>Sword</color>";
                effectString = effectTemplate(skill, fan.temp());
                explainString = descriptionTemplate(skill, "Swing the sword quickly to make sword doppelgangers,\n  additional attack with shock waves aginst around monsters.", false);
                costString = costTemplate(skill, ALLY.Job.Warrior);
                break;
        }
    }

    public static void block(SKILL skill, ref string skillNameString, ref string linageString, ref string effectString, ref string explainString, ref string costString)
    {
        Block block = skill as Block;
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                skillNameString = nameTemplate(skill, "Block");
                linageString = "Warrior <color=#00C8FF>Shield</color>";
                effectString = effectTemplate(skill);
                explainString = descriptionTemplate(skill, "Protect yourself from attacks by enemies.\n  You don't get damaged during the time the skill is active.\n  " +
                                    "There is a certain probability of grave accidents\n  happening despite every cautionary measure taken.", false)
                                    + "\n- Block Chance : " + tDigit(block.Prob() / 100d, 2) + "%";
                costString = costTemplate(skill, ALLY.Job.Warrior);
                break;
            case Language.jp:
                skillNameString = nameTemplate(skill, "ブロック");
                linageString = LinageTemplate("戦士 : <color=#00C8FF>盾</color>");
                effectString = effectTemplate(skill);
                explainString = descriptionTemplate(skill, "敵の攻撃から身を守ります. \nこのスキルが発動している間、あなたは攻撃を受けません. ", false)
                                                        + "\n- ブロック成功確率 : " + tDigit(block.Prob() / 100d, 2) + "%";
                costString = costTemplate(skill, ALLY.Job.Warrior);
                break;
            case Language.chi:
                skillNameString = nameTemplate(skill, "格挡");
                linageString = LinageTemplate("战士 : <color=#00C8FF>盾</color>");
                effectString = effectTemplate(skill);
                explainString = descriptionTemplate(skill, "保护自己免受伤害.\n  成功格挡时不会受到伤害.", false)
                                                        + "\n- 格挡概率: " + tDigit(block.Prob() / 100d, 2) + "%";
                costString = costTemplate(skill, ALLY.Job.Warrior);
                break;

            default:
                skillNameString = nameTemplate(skill, "Block");
                linageString = "Warrior <color=#00C8FF>Shield</color>";
                effectString = effectTemplate(skill);
                explainString = descriptionTemplate(skill, "Protect yourself from attacks by enemies.\n  You don't get damaged during the time the skill is active.\n  " +
                                    "There is a certain probability of grave accidents\n  happening despite every cautionary measure taken.", false)
                                                        + "\n- Protect Chance : " + tDigit(block.Prob() / 100d, 2) + "%";
                costString = costTemplate(skill, ALLY.Job.Warrior);
                break;
        }
    }

    public static void sheildAttack(SKILL skill, ref string skillNameString, ref string linageString, ref string effectString, ref string explainString, ref string costString)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                skillNameString = nameTemplate(skill, "Shield Attack");
                linageString = "Warrior <color=#00C8FF>Shield</color>";
                effectString = effectTemplate(skill);
                explainString = descriptionTemplate(skill, "Make an simple attack against an enemy by shield,\n  preparing to active high skills by gaining MP.");
                costString = costTemplate(skill, ALLY.Job.Warrior);
                break;
            case Language.jp:
                skillNameString = nameTemplate(skill, "シールドアタック");
                linageString = LinageTemplate("戦士 : <color=#00C8FF>盾</color>");
                effectString = effectTemplate(skill);
                explainString = descriptionTemplate(skill, "盾で敵を攻撃します. \n  強力な攻撃の準備のため、多くのMPが得られます. ");
                costString = costTemplate(skill, ALLY.Job.Warrior);
                break;
            case Language.chi:
                skillNameString = nameTemplate(skill, "盾击");
                linageString = LinageTemplate("战士 : <color=#00C8FF>盾</color>");
                effectString = effectTemplate(skill);
                explainString = descriptionTemplate(skill, "用盾牌对敌人造成伤害并获得MP.");
                costString = costTemplate(skill, ALLY.Job.Warrior);
                break;

            default:
                skillNameString = nameTemplate(skill, "Shield Attack");
                linageString = "Warrior <color=#00C8FF>Shield</color>";
                effectString = effectTemplate(skill);
                explainString = descriptionTemplate(skill, "Make an simple attack against an enemy by shield,\n  preparing to active high skills by gaining MP.");
                costString = costTemplate(skill, ALLY.Job.Warrior);
                break;
        }
    }
    public static void swizard(SKILL skill, ref string skillNameString, ref string linageString, ref string effectString, ref string explainString, ref string costString)
    {

        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                skillNameString = nameTemplate(skill, "Staff Attack");
                linageString = "Wizard Base";
                explainString = descriptionTemplate(skill, "A simple magical attack with your staff.");
                break;
            case Language.jp:
                skillNameString = nameTemplate(skill, "スタッフアタック");
                linageString = LinageTemplate("魔法使い");
                explainString = descriptionTemplate(skill, "杖による基本的な魔法攻撃. ");
                break;
            case Language.chi:
                skillNameString = nameTemplate(skill, "法杖攻击");
                linageString = LinageTemplate("魔法师");
                explainString = descriptionTemplate(skill, "法杖的基本魔法.");
                break;

            default:
                skillNameString = nameTemplate(skill, "Staff Attack");
                linageString = "Wizard Base";
                explainString = descriptionTemplate(skill, "A simple magical attack with your staff.");
                break;
        }
        effectString = effectTemplate(skill, 0, SKILL.DamageKind.magical);
        costString = costTemplate(skill, ALLY.Job.Wizard);
    }
    public static void fireball(SKILL skill, ref string skillNameString, ref string linageString, ref string effectString, ref string explainString, ref string costString)
    {

        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                skillNameString = nameTemplate(skill, "Fire Ball");
                linageString = "Wizard <color=#ffe400>Fire</color>";
                explainString = descriptionTemplate(skill, "Attack with a large fireball that also hits nearby foes.");
                break;
            case Language.jp:
                skillNameString = nameTemplate(skill, "ファイアボール");
                linageString = LinageTemplate("魔法使い <color=#ffe400>炎</color>");
                explainString = descriptionTemplate(skill, "炎の玉で攻撃する. ターゲットに近い敵もダメージを受ける. ");
                break;
            case Language.chi:
                skillNameString = nameTemplate(skill, "火球术");
                linageString = LinageTemplate("魔法师 <color=#ffe400>火</color>");
                explainString = descriptionTemplate(skill, "咏唱火球术攻击敌人, 接近目标也会受到伤害.");
                break;

            default:
                skillNameString = nameTemplate(skill, "Fire Ball");
                linageString = "Wizard <color=#ffe400>Fire</color>";
                explainString = descriptionTemplate(skill, "Attack with a large fireball that also hits nearby foes.");
                break;
        }
        effectString = effectTemplate(skill, 0, SKILL.DamageKind.magical);
        costString = costTemplate(skill, ALLY.Job.Wizard);
    }
    public static void firestorm(SKILL skill, ref string skillNameString, ref string linageString, ref string effectString, ref string explainString, ref string costString)
    {
        FireStorm firestorm = skill as FireStorm;
        int temp = firestorm.P_level < 30 ? 4 : 6;
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                skillNameString = nameTemplate(skill, "Fire Storm");
                linageString = "Wizard <color=#ffe400>Fire</color>";
                explainString = descriptionTemplate(skill, "Conjure a fire storm that surrounds you and \n  damages all nearby targets.", false);
                break;
            case Language.jp:
                skillNameString = nameTemplate(skill, "ファイアストーム");
                linageString = LinageTemplate("魔法使い <color=#ffe400>炎</color>");
                explainString = descriptionTemplate(skill, "ファイアストームを発動し、周辺の敵すべてにダメージを与える. ", false);
                break;
            case Language.chi:
                skillNameString = nameTemplate(skill, "火焰风暴");
                linageString = LinageTemplate("魔法师 <color=#ffe400>火</color>");
                explainString = descriptionTemplate(skill, "对周围制作火焰风暴并烧毁敌人. ", false);
                break;

            default:
                skillNameString = nameTemplate(skill, "Fire Storm");
                linageString = "Wizard <color=#ffe400>Fire</color>";
                explainString = descriptionTemplate(skill, "Conjure a fire storm that surrounds you and \n  damages all nearby targets.", false);
                break;
        }
        effectString = effectTemplate(skill, temp, SKILL.DamageKind.magical);
        costString = costTemplate(skill, ALLY.Job.Wizard);
    }
    public static void meteo(SKILL skill, ref string skillNameString, ref string linageString, ref string effectString, ref string explainString, ref string costString)
    {
        MeteoStrike meteo = skill as MeteoStrike;
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                skillNameString = nameTemplate(skill, "Meteor Strike");
                linageString = "Wizard <color=#ffe400>Fire</color>";
                explainString = descriptionTemplate(skill, "Call a Meteor from the heavens to crush your enemies\n  in a blazing inferno.", false);
                break;
            case Language.jp:
                skillNameString = nameTemplate(skill, "メテオストライク");
                linageString = LinageTemplate("魔法使い <color=#ffe400>炎</color>");
                explainString = descriptionTemplate(skill, "天空からメテオを呼び起こし、敵を業火で包む", false);
                break;
            case Language.chi:
                skillNameString = nameTemplate(skill, "陨石术");
                linageString = LinageTemplate("魔法师 <color=#ffe400>火</color>");
                explainString = descriptionTemplate(skill, "从天空降下陨石对敌人降下业火的制裁.", false);
                break;

            default:
                skillNameString = nameTemplate(skill, "Meteor Strike");
                linageString = "Wizard <color=#ffe400>Fire</color>";
                explainString = descriptionTemplate(skill, "Call a Meteor from the heavens to crush your enemies\n  in a blazing inferno.", false);
                break;
        }
        effectString = effectTemplate(skill, meteo.temp(), SKILL.DamageKind.magical);
        costString = costTemplate(skill, ALLY.Job.Wizard);
    }

    public static void iceball(SKILL skill, ref string skillNameString, ref string linageString, ref string effectString, ref string explainString, ref string costString)
    {
        IceBall iceball = skill as IceBall;
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                skillNameString = nameTemplate(skill, "Ice Ball");
                linageString = "Wizard <color=#00C8FF>Ice</color>";
                explainString = descriptionTemplate(skill, "Shoot of a bolt of frost that damages and \n  may also slow your target.", false);
                effectString = effectTemplate(skill, 0, SKILL.DamageKind.magical) + "\n- Cold Chance : " + tDigit(iceball.probability() / 100, 2) + "%";
                break;
            case Language.jp:
                skillNameString = nameTemplate(skill, "アイスボール");
                linageString = LinageTemplate("魔法使い <color=#00C8FF>氷</color>");
                explainString = descriptionTemplate(skill, "アイスボールを発射し、確率で敵の動きを鈍らせる. ", false);
                effectString = effectTemplate(skill, 0, SKILL.DamageKind.magical) + "\n- コールド確率 : " + tDigit(iceball.probability() / 100, 2) + "%";
                break;
            case Language.chi:
                skillNameString = nameTemplate(skill, "冰球术");
                linageString = LinageTemplate("魔法师 <color=#00C8FF>冰</color>");
                explainString = descriptionTemplate(skill, "使用冰球攻击敌人, 并有概率减速敌人. ", false);
                effectString = effectTemplate(skill, 0, SKILL.DamageKind.magical) + "\n- 减速概率: " + tDigit(iceball.probability() / 100, 2) + "%";
                break;

            default:
                skillNameString = nameTemplate(skill, "Ice Ball");
                linageString = "Wizard <color=#00C8FF>Ice</color>";
                explainString = descriptionTemplate(skill, "Shoot of a bolt of frost that damages and \n  may also slow your target.", false);
                effectString = effectTemplate(skill, 0, SKILL.DamageKind.magical) + "\n- Cold Chance : " + tDigit(iceball.probability() / 100, 2) + "%";
                break;
        }
        costString = costTemplate(skill, ALLY.Job.Wizard);
    }
    public static void chillingtouch(SKILL skill, ref string skillNameString, ref string linageString, ref string effectString, ref string explainString, ref string costString)
    {
        ChillingTouch chill = skill as ChillingTouch;
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                skillNameString = nameTemplate(skill, "Chilling Touch");
                linageString = "Wizard <color=#00C8FF>Ice</color>";
                explainString = descriptionTemplate(skill, "A touch attack that damages your target and \n  may also freeze them solid." +
                                    "\n- Freeze is only way to delay Boss's attack.", false);
                effectString = "- Physical damage : " + tDigit(chill.Damage(), 2) + "\n" +
                effectTemplate(skill, 0, SKILL.DamageKind.magical) +
                                    "\n- Freeze Chance : " + chill.probability() / 100 + "%";
                break;
            case Language.jp:
                skillNameString = nameTemplate(skill, "チリングタッチ");
                linageString = LinageTemplate("魔法使い <color=#00C8FF>氷</color>");
                explainString = descriptionTemplate(skill, "敵を凍らせる攻撃を行い、確率で敵の移動を無効にする. ", false);
                effectString = effectString = "- 物理攻撃 : " + tDigit(chill.Damage(), 2) + "\n" +
                effectTemplate(skill, 0, SKILL.DamageKind.magical) +
                                    "\n- フリーズ確率: " + chill.probability() / 100 + "%";
                break;
            case Language.chi:
                skillNameString = nameTemplate(skill, "极寒之触");
                linageString = LinageTemplate("魔法师 <color=#00C8FF>冰</color>");
                explainString = descriptionTemplate(skill, "对敌人释放极寒之触, 接触者概率冻结并动弹不得. ", false);
                effectString = effectString = "- 物理伤害 : " + tDigit(chill.Damage(), 2) + "\n" +
                effectTemplate(skill, 0, SKILL.DamageKind.magical) +
                                    "\n- 冰冻概率 : " + chill.probability() / 100 + "%";

                break;
            default:
                skillNameString = nameTemplate(skill, "Chilling Touch");
                linageString = "Wizard <color=#00C8FF>Ice</color>";
                explainString = descriptionTemplate(skill, "A touch attack that damages your target and \n  may also freeze them solid." +
                                    "\n- Freeze is only way to delay Boss's attack.", false);
                effectString = "- Physical damage : " + tDigit(chill.Damage(), 2) + "\n" +
                effectTemplate(skill, 0, SKILL.DamageKind.magical) +
                                    "\n- Freeze Chance : " + chill.probability() / 100 + "%";
                break;
        }
        costString = costTemplate(skill, ALLY.Job.Wizard);
    }
    public static void blizzard(SKILL skill, ref string skillNameString, ref string linageString, ref string effectString, ref string explainString, ref string costString)
    {
        Blizzard iceball = skill as Blizzard;
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                skillNameString = nameTemplate(skill, "Blizard");
                linageString = "Wizard <color=#00C8FF>Ice</color>";
                explainString = descriptionTemplate(skill, "Summon forth a blizard, over the center\n  of the map, that damages and slows enemies.", false);
                effectString = effectTemplate(skill, 0, SKILL.DamageKind.magical) + "\n- Freeze Chance : " + tDigit(iceball.probability() / 100, 2) + "%";
                break;
            case Language.jp:
                skillNameString = nameTemplate(skill, "ブリザード");
                linageString = LinageTemplate("魔法使い <color=#00C8FF>氷</color>");
                explainString = descriptionTemplate(skill, "画面中央にブリザードを召喚し、当たった敵の速度を下げる. ", false);
                effectString = effectTemplate(skill, 0, SKILL.DamageKind.magical) + "\n- フリーズ確率 : " + tDigit(iceball.probability() / 100, 2) + "%";
                break;
            case Language.chi:
                skillNameString = nameTemplate(skill, "暴风雪");
                linageString = LinageTemplate("魔法师 <color=#00C8FF>氷</color>");
                explainString = descriptionTemplate(skill, "在屏幕中间释放暴风雪攻击敌人并有概率冰冻. ", false);
                effectString = effectTemplate(skill, 0, SKILL.DamageKind.magical) + "\n- 冰冻概率 : " + tDigit(iceball.probability() / 100, 2) + "%";
                break;

            default:
                skillNameString = nameTemplate(skill, "Blizard");
                linageString = "Wizard <color=#00C8FF>Ice</color>";
                explainString = descriptionTemplate(skill, "Summon forth a blizard, over the center\n  of the map, that damages and slows enemies.", false);
                effectString = effectTemplate(skill, 0, SKILL.DamageKind.magical) + "\n- Freeze Chance : " + tDigit(iceball.probability() / 100, 2) + "%";
                break;
        }
        costString = costTemplate(skill, ALLY.Job.Wizard);
    }
    public static void thunderball(SKILL skill, ref string skillNameString, ref string linageString, ref string effectString, ref string explainString, ref string costString)
    {
        ThunderBall thunder = skill as ThunderBall;
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                skillNameString = nameTemplate(skill, "Thunder Ball");
                linageString = "Wizard <color=#ffe400>Thunder</color>";
                explainString = descriptionTemplate(skill, "MP / s\n- Fire a lightning bolt at your target that may also cause paralysis." +
                                    "\n  Enemies with paralysis will suffer greater damage when attacked.", false);
                effectString = effectTemplate(skill, 0, SKILL.DamageKind.magical) + "\n- Paralyzing Chance : " + tDigit(thunder.probability() / 100, 2) + " %";
                break;
            case Language.jp:
                skillNameString = nameTemplate(skill, "サンダーボール");
                linageString = LinageTemplate("魔法使い  <color=#ffe400>雷</color>");
                explainString = descriptionTemplate(skill, "サンダーボールを発射し、確率で感電させます. ", false);
                effectString = effectTemplate(skill, 0, SKILL.DamageKind.magical) + "\n- 感電確率 : " + tDigit(thunder.probability() / 100, 2) + "%";
                break;
            case Language.chi:
                skillNameString = nameTemplate(skill, "雷球术");
                linageString = LinageTemplate("魔法师  <color=#ffe400>电</color>");
                explainString = descriptionTemplate(skill, "对敌人发射雷球, 并有概率触发麻痹. " +
                                    "\n  敌人麻痹的时候会增加受到的伤害.", false);
                effectString = effectTemplate(skill, 0, SKILL.DamageKind.magical) + "\n- 麻痹概率 : " + tDigit(thunder.probability() / 100, 2) + "%";
                break;

            default:
                skillNameString = nameTemplate(skill, "Thunder Ball");
                linageString = "Wizard <color=#ffe400>Thunder</color>";
                explainString = descriptionTemplate(skill, "MP / s\n- Fire a lightning bolt at your target that may also cause paralysis." +
                                    "\n  Enemies with paralysis will suffer greater damage when attacked.", false);
                effectString = effectTemplate(skill, 0, SKILL.DamageKind.magical) + "\n- Paralyzing Chance : " + tDigit(thunder.probability() / 100, 2) + " %";
                break;
        }
        costString = costTemplate(skill, ALLY.Job.Wizard);
    }
    public static void doublethunder(SKILL skill, ref string skillNameString, ref string linageString, ref string effectString, ref string explainString, ref string costString)
    {
        DoubleThunderBall thunder = skill as DoubleThunderBall;
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                skillNameString = nameTemplate(skill, "Double Thunder Ball");
                linageString = "Wizard <color=#ffe400>Thunder</color>";
                explainString = descriptionTemplate(skill, "Fires a pair of lightning bolts at your target that may also cause paralysis.", false);
                effectString = effectTemplate(skill, 0, SKILL.DamageKind.magical) + "\n- Paralyzing Chance : " + tDigit(thunder.probability() / 100, 2) + " %";
                break;
            case Language.jp:
                skillNameString = nameTemplate(skill, "ダブルサンダーボール");
                linageString = LinageTemplate("魔法使い  <color=#ffe400>雷</color>");
                explainString = descriptionTemplate(skill, "２つのサンダーボールを発射し、確率で感電させます. ", false);
                effectString = effectTemplate(skill, 0, SKILL.DamageKind.magical) + "\n- 感電確率 : " + tDigit(thunder.probability() / 100, 2) + "%";
                break;
            case Language.chi:
                skillNameString = nameTemplate(skill, "双雷球术");
                linageString = LinageTemplate("魔法师  <color=#ffe400>点</color>");
                explainString = descriptionTemplate(skill, "对敌人连续发射雷球, 并有概率触发麻痹. ", false);
                effectString = effectTemplate(skill, 0, SKILL.DamageKind.magical) + "\n- 麻痹概率 : " + tDigit(thunder.probability() / 100, 2) + "%";
                break;

            default:
                skillNameString = nameTemplate(skill, "Double Thunder Ball");
                linageString = "Wizard <color=#ffe400>Thunder</color>";
                explainString = descriptionTemplate(skill, "Fires a pair of lightning bolts at your target that may also cause paralysis.", false);
                effectString = effectTemplate(skill, 0, SKILL.DamageKind.magical) + "\n- Paralyzing Chance : " + tDigit(thunder.probability() / 100, 2) + " %";
                break;
        }
        costString = costTemplate(skill, ALLY.Job.Wizard);
    }

    public static void LightningTHunder(SKILL skill, ref string skillNameString, ref string linageString, ref string effectString, ref string explainString, ref string costString)
    {
        LightningThunder thunder = skill as LightningThunder;
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                skillNameString = nameTemplate(skill, "Lightning Thunder");
                linageString = "Wizard <color=#ffe400>Thunder</color>";
                explainString = descriptionTemplate(skill, "Summon forth a storm that randomly attacks enemies with lightning.", false);
                effectString = effectTemplate(skill, thunder.attackNum(), SKILL.DamageKind.magical) + "\n- Paralyzing Chance : " + tDigit(thunder.probability() / 100, 2) + " %";
                break;
            case Language.jp:
                skillNameString = nameTemplate(skill, "ライトニングサンダー");
                linageString = LinageTemplate("魔法使い  <color=#ffe400>雷</color>");
                explainString = descriptionTemplate(skill, "雷の嵐を起こし、ランダムに敵に複数攻撃します. ", false);
                effectString = effectTemplate(skill, thunder.attackNum(), SKILL.DamageKind.magical) + "\n- 感電確率 : " + tDigit(thunder.probability() / 100, 2) + "%";
                break;
            case Language.chi:
                skillNameString = nameTemplate(skill, "天雷");
                linageString = LinageTemplate("魔法师  <color=#ffe400>电</color>");
                explainString = descriptionTemplate(skill, "召唤天雷, 随机攻击周围的敌人. ", false);
                effectString = effectTemplate(skill, thunder.attackNum(), SKILL.DamageKind.magical) + "\n- 麻痹概率 : " + tDigit(thunder.probability() / 100, 2) + "%";
                break;

            default:
                skillNameString = nameTemplate(skill, "Lightning Thunder");
                linageString = "Wizard <color=#ffe400>Thunder</color>";
                explainString = descriptionTemplate(skill, "Summon forth a storm that randomly attacks enemies with lightning.", false);
                effectString = effectTemplate(skill, thunder.attackNum(), SKILL.DamageKind.magical) + "\n- Paralyzing Chance : " + tDigit(thunder.probability() / 100, 2) + " %";
                break;
        }
        costString = costTemplate(skill, ALLY.Job.Wizard);
    }

    public static void sangel(SKILL skill, ref string skillNameString, ref string linageString, ref string effectString, ref string explainString, ref string costString)
    {
        S_Angel angel = skill as S_Angel;
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                skillNameString = nameTemplate(skill, "Wing Attack");
                linageString = "Angel Base";
                explainString = descriptionTemplate(skill, "A simple attack with your wings.");
                effectString = effectTemplate(skill, angel.temp(), SKILL.DamageKind.physical);
                break;
            case Language.jp:
                skillNameString = nameTemplate(skill, "ウィングアタック");
                linageString = LinageTemplate("天使");
                explainString = descriptionTemplate(skill, "羽を使った基本攻撃です. ");
                effectString = effectTemplate(skill, angel.temp(), SKILL.DamageKind.physical);
                break;
            case Language.chi:
                skillNameString = nameTemplate(skill, "翅膀攻击");
                linageString = LinageTemplate("天使");
                explainString = descriptionTemplate(skill, "天使的普通攻击. ");
                effectString = effectTemplate(skill, angel.temp(), SKILL.DamageKind.physical);
                break;

            default:
                skillNameString = nameTemplate(skill, "Wing Attack");
                linageString = "Angel Base";
                explainString = descriptionTemplate(skill, "A simple attack with your wings.");
                effectString = effectTemplate(skill, angel.temp(), SKILL.DamageKind.physical);
                break;
        }
        costString = costTemplate(skill, ALLY.Job.Angel);
    }
    public static void wingshots(SKILL skill, ref string skillNameString, ref string linageString, ref string effectString, ref string explainString, ref string costString)
    {
        WingShoot angel = skill as WingShoot;
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                skillNameString = nameTemplate(skill, "Wing Shoot");
                linageString = "Angel <color=#32ff32>Wing</color>";
                explainString = descriptionTemplate(skill, "Flap your wings to generate a powerful wind attack.");
                effectString = effectTemplate(skill, angel.temp(), SKILL.DamageKind.magical);
                break;
            case Language.jp:
                skillNameString = nameTemplate(skill, "ウィングシュート");
                linageString = LinageTemplate("天使  <color=#32ff32>羽</color>");
                explainString = descriptionTemplate(skill, "羽を羽ばたかせて行う魔法攻撃です. ");
                effectString = effectTemplate(skill, angel.temp(), SKILL.DamageKind.magical);
                break;
            case Language.chi:
                skillNameString = nameTemplate(skill, "风刃");
                linageString = LinageTemplate("天使  <color=#32ff32>羽</color>");
                explainString = descriptionTemplate(skill, "拍打翅膀产生风刃, 造成魔法伤害. ");
                effectString = effectTemplate(skill, angel.temp(), SKILL.DamageKind.magical);
                break;

            default:
                skillNameString = nameTemplate(skill, "Wing Shoot");
                linageString = "Angel <color=#32ff32>Wing</color>";
                explainString = descriptionTemplate(skill, "Flap your wings to generate a powerful wind attack.");
                effectString = effectTemplate(skill, angel.temp(), SKILL.DamageKind.magical);
                break;
        }
        costString = costTemplate(skill, ALLY.Job.Angel);
    }
    public static void heal(SKILL skill, ref string skillNameString, ref string linageString, ref string effectString, ref string explainString, ref string costString)
    {
        Heal angel = skill as Heal;
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                skillNameString = nameTemplate(skill, "Heal");
                linageString = "Angel <color=#32ff32>Wing</color>";
                explainString = descriptionTemplate(skill, "Heal your wounds..");
                effectString = angel.P_level < 50 ?
                optStr + "- Heal Point : " + tDigit(angel.damageMin()) + " ~ " + tDigit(angel.damageMax()) + "\n- Interval : " + tDigit(angel.AttackInterval(), 2) :
                optStr + "- Heal Point : " + tDigit(angel.damageMin()) + " ~ " + tDigit(angel.damageMax()) + "\n- Cure Chance : " + tDigit(angel.cureChance() / 100, 2)
                                    + "%\n- Interval : " + tDigit(angel.AttackInterval(), 2);
                break;
            case Language.jp:
                skillNameString = nameTemplate(skill, "ヒール");
                linageString = LinageTemplate("天使  <color=#32ff32>羽</color>");
                explainString = descriptionTemplate(skill, "傷を癒します. ");
                effectString = effectString = angel.P_level < 50 ?
                optStr + "- 回復量 : " + tDigit(angel.damageMin()) + " ~ " + tDigit(angel.damageMax()) + "\n- 発動間隔 : １秒間に" + tDigit(angel.AttackInterval(), 2) :
                optStr + "- 回復量 : " + tDigit(angel.damageMin()) + " ~ " + tDigit(angel.damageMax()) + "\n- 状態異常回復確率 : " + tDigit(angel.cureChance() / 100, 2)
                                    + "%\n- 発動間隔 : " + tDigit(angel.AttackInterval(), 2);
                break;
            case Language.chi:
                skillNameString = nameTemplate(skill, "治疗术");
                linageString = LinageTemplate("天使  <color=#32ff32>羽</color>");
                explainString = descriptionTemplate(skill, "回复血量. ");
                effectString = effectString = angel.P_level < 50 ?
                optStr + "- 回血量 : " + tDigit(angel.damageMin()) + " ~ " + tDigit(angel.damageMax()) + "\n- 技能冷却 : 1秒内" + tDigit(angel.AttackInterval(), 2) :
                optStr + "- 回血量 : " + tDigit(angel.damageMin()) + " ~ " + tDigit(angel.damageMax()) + "\n- 解除减益概率: " + tDigit(angel.cureChance() / 100, 2)
                                    + "%\n- 技能冷却 : " + tDigit(angel.AttackInterval(), 2);
                break;

            default:
                skillNameString = nameTemplate(skill, "Heal");
                linageString = "Angel <color=#32ff32>Wing</color>";
                explainString = descriptionTemplate(skill, "Heal your wounds..");
                effectString = angel.P_level < 50 ?
                optStr + "- Heal Point : " + tDigit(angel.damageMin()) + " ~ " + tDigit(angel.damageMax()) + "\n- Interval : " + tDigit(angel.AttackInterval(), 2) :
                optStr + "- Heal Point : " + tDigit(angel.damageMin()) + " ~ " + tDigit(angel.damageMax()) + "\n- Cure Chance : " + tDigit(angel.cureChance() / 100, 2)
                                    + "%\n- Interval : " + tDigit(angel.AttackInterval(), 2);
                break;
        }
        costString = costTemplate(skill, ALLY.Job.Angel);
    }
    public static void godbless(SKILL skill, ref string skillNameString, ref string linageString, ref string effectString, ref string explainString, ref string costString)
    {
        GodBless angel = skill as GodBless;
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                skillNameString = nameTemplate(skill, "God Bless");
                linageString = "Angel <color=#32ff32>Enhance</color>";
                explainString = descriptionTemplate(skill, "A simple prayer that boosts your HP.");
                effectString = angel.P_level < 30 ?
                effectString = "- Max HP : + " + tDigit(angel.Damage(), 2) + "%\n- Debuff Resistance : " +
                                 "+ " + tDigit(angel.DebuffResistance() / 100, 2) + "%\n- Interval : " + tDigit(angel.AttackInterval(), 2) :
                effectString = "- Max HP : + " + tDigit(angel.Damage(), 2) + "%\n- Debuff Resistance : " +
                                    "+ " + tDigit(angel.DebuffResistance() / 100, 2) + "%\n- Regenerate HP : " + tDigit(angel.RegenePoint(), 3) + "" +
                                    "% / s\n- Interval : " + tDigit(angel.AttackInterval(), 2);
                break;
            case Language.jp:
                skillNameString = nameTemplate(skill, "ゴッドブレス");
                linageString = LinageTemplate("天使  <color=#32ff32>強化</color>");
                explainString = descriptionTemplate(skill, "HPの最大値を上げる、神の祈り. ");
                effectString = angel.P_level < 30 ?
                effectString = "- 最大HP : + " + tDigit(angel.Damage(), 2) + "%\n- 状態異常耐性 : " +
                                 "+ " + tDigit(angel.DebuffResistance() / 100, 2) + "%\n- 発動間隔 : " + tDigit(angel.AttackInterval(), 2) :
                effectString = "- 最大HP : + " + tDigit(angel.Damage(), 2) + "%\n- 状態異常耐性 : " +
                                    "+ " + tDigit(angel.DebuffResistance() / 100, 2) + "%\n- HP自動回復量 : " + tDigit(angel.RegenePoint(), 3) + "" +
                                    "% / s\n- 発動間隔 : " + tDigit(angel.AttackInterval(), 2);
                break;
            case Language.chi:
                skillNameString = nameTemplate(skill, "上帝的保佑");
                linageString = LinageTemplate("天使 <color=#32ff32>强化</color>");
                explainString = descriptionTemplate(skill, "增加血量最大值. ");
                effectString = angel.P_level < 30 ?
                effectString = "- 最大HP : + " + tDigit(angel.Damage(), 2) + "%\n- 减益抗性 : " +
                                 "+ " + tDigit(angel.DebuffResistance() / 100, 2) + "%\n- 技能冷却 : " + tDigit(angel.AttackInterval(), 2) :
                effectString = "- 最大HP : + " + tDigit(angel.Damage(), 2) + "%\n-减益抗性: " +
                                    "+ " + tDigit(angel.DebuffResistance() / 100, 2) + "%\n- HP自动回复: " + tDigit(angel.RegenePoint(), 3) + "" +
                                    "% / s\n- 技能冷却 : " + tDigit(angel.AttackInterval(), 2);
                break;

            default:
                skillNameString = nameTemplate(skill, "God Bless");
                linageString = "Angel <color=#32ff32>Enhance</color>";
                explainString = descriptionTemplate(skill, "A simple prayer that boosts your HP.");
                effectString = angel.P_level < 30 ?
                effectString = "- Max HP : + " + tDigit(angel.Damage(), 2) + "%\n- Debuff Resistance : " +
                                 "+ " + tDigit(angel.DebuffResistance() / 100, 2) + "%\n- Interval : " + tDigit(angel.AttackInterval(), 2) :
                effectString = "- Max HP : + " + tDigit(angel.Damage(), 2) + "%\n- Debuff Resistance : " +
                                    "+ " + tDigit(angel.DebuffResistance() / 100, 2) + "%\n- Regenerate HP : " + tDigit(angel.RegenePoint(), 3) + "" +
                                    "% / s\n- Interval : " + tDigit(angel.AttackInterval(), 2);
                break;
        }
        costString = costTemplate(skill, ALLY.Job.Angel);
    }
    public static void muscle(SKILL skill, ref string skillNameString, ref string linageString, ref string effectString, ref string explainString, ref string costString)
    {
        MuscleInflation angel = skill as MuscleInflation;
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                skillNameString = nameTemplate(skill, "Muscle Inflation");
                linageString = "Angel <color=#32ff32>Enhance</color>";
                explainString = descriptionTemplate(skill, "Bulk up the body to boost the ATK.");
                effectString = angel.P_level >= 30 ?
                                    "- ATK : + " + tDigit(angel.Damage(), 2) + "\n- Physical damage : " + tDigit(angel.Damage() * angel.BuffedLevel(), 2) + " * 5\n- Interval : "
                                    + tDigit(angel.AttackInterval(), 2) :
                                    "- ATK : + " + tDigit(angel.Damage(), 2) + "\n- Interval : " + tDigit(angel.AttackInterval(), 2);
                break;
            case Language.jp:
                skillNameString = nameTemplate(skill, "マッスルインフレーション");
                linageString = LinageTemplate("天使  <color=#32ff32>強化</color>");
                explainString = descriptionTemplate(skill, "筋肉を増やし、一定時間攻撃力を上げます. ");
                effectString = angel.P_level >= 30 ?
                                    "- ATK : + " + tDigit(angel.Damage(), 2) + "\n- 物理攻撃力 : " + tDigit(angel.Damage() * angel.BuffedLevel(), 2) + " * 5\n- 発動間隔 : "
                                    + tDigit(angel.AttackInterval(), 2) :
                                    "- ATK : + " + tDigit(angel.Damage(), 2) + "\n- 発動間隔 : " + tDigit(angel.AttackInterval(), 2);
                break;
            case Language.chi:
                skillNameString = nameTemplate(skill, "肌肉强化");
                linageString = LinageTemplate("天使  <color=#32ff32>强化</color>");
                explainString = descriptionTemplate(skill, "肌肉强化, 在一定时间内增加物理伤害. ");
                effectString = angel.P_level >= 30 ?
                                    "- ATK : + " + tDigit(angel.Damage(), 2) + "\n- 物理伤害 : " + tDigit(angel.Damage() * angel.BuffedLevel(), 2) + " * 5\n- 技能冷却 : "
                                    + tDigit(angel.AttackInterval(), 2) :
                                    "- ATK : + " + tDigit(angel.Damage(), 2) + "\n- 技能冷却 : " + tDigit(angel.AttackInterval(), 2);
                break;

            default:
                skillNameString = nameTemplate(skill, "Muscle Inflation");
                linageString = "Angel <color=#32ff32>Enhance</color>";
                explainString = descriptionTemplate(skill, "Bulk up the body to boost the ATK.");
                effectString = angel.P_level >= 30 ?
                                    "- ATK : + " + tDigit(angel.Damage(), 2) + "\n- Physical damage : " + tDigit(angel.Damage() * angel.BuffedLevel(), 2) + " * 5\n- Interval : "
                                    + tDigit(angel.AttackInterval(), 2) :
                                    "- ATK : + " + tDigit(angel.Damage(), 2) + "\n- Interval : " + tDigit(angel.AttackInterval(), 2);
                break;
        }
        costString = costTemplate(skill, ALLY.Job.Angel);
    }
    public static void mipact(SKILL skill, ref string skillNameString, ref string linageString, ref string effectString, ref string explainString, ref string costString)
    {
        MagicImpact angel = skill as MagicImpact;
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                skillNameString = nameTemplate(skill, "Magic Impact");
                linageString = "Angel <color=#32ff32>Enhance</color>";
                explainString = descriptionTemplate(skill, "Your halo glows brightly and increases your MATK.");
                effectString = angel.P_level >= 30 ?
                                    "- MATK : + " + tDigit(angel.Damage(), 2) + "\n- Magical damage : " + tDigit(angel.Damage() * angel.BuffedLevel(), 2) + " * 5\n- Interval : "
                                    + tDigit(angel.AttackInterval(), 2) :
                                    "- MATK : + " + tDigit(angel.Damage(), 2) + "\n- Interval : " + tDigit(angel.AttackInterval(), 2);
                break;
            case Language.jp:
                skillNameString = nameTemplate(skill, "マジックインパクト");
                linageString = LinageTemplate("天使  <color=#32ff32>強化</color>");
                explainString = descriptionTemplate(skill, "あなたは光り輝き、魔法攻撃力が上がります. ");
                effectString = angel.P_level >= 30 ?
                                    "- MATK : + " + tDigit(angel.Damage(), 2) + "\n- 魔法攻撃力 : " + tDigit(angel.Damage() * angel.BuffedLevel(), 2) + " * 5\n- 発動間隔 : "
                                    + tDigit(angel.AttackInterval(), 2) :
                                    "- MATK : + " + tDigit(angel.Damage(), 2) + "\n- 発動間隔 : " + tDigit(angel.AttackInterval(), 2);
                break;
            case Language.chi:
                skillNameString = nameTemplate(skill, "魔法强化");
                linageString = LinageTemplate("天使  <color=#32ff32>强化</color>");
                explainString = descriptionTemplate(skill, "魔法强化, 在一定时间内增加魔法伤害. ");
                effectString = angel.P_level >= 30 ?
                                    "- MATK : + " + tDigit(angel.Damage(), 2) + "\n- 魔法伤害 : " + tDigit(angel.Damage() * angel.BuffedLevel(), 2) + " * 5\n- 技能冷却 : "
                                    + tDigit(angel.AttackInterval(), 2) :
                                    "- MATK : + " + tDigit(angel.Damage(), 2) + "\n- 技能冷却 : " + tDigit(angel.AttackInterval(), 2);
                break;

            default:
                skillNameString = nameTemplate(skill, "Magic Impact");
                linageString = "Angel <color=#32ff32>Enhance</color>";
                explainString = descriptionTemplate(skill, "Your halo glows brightly and increases your MATK.");
                effectString = angel.P_level >= 30 ?
                                    "- MATK : + " + tDigit(angel.Damage(), 2) + "\n- Magical damage : " + tDigit(angel.Damage() * angel.BuffedLevel(), 2) + " * 5\n- Interval : "
                                    + tDigit(angel.AttackInterval(), 2) :
                                    "- MATK : + " + tDigit(angel.Damage(), 2) + "\n- Interval : " + tDigit(angel.AttackInterval(), 2);
                break;
        }
        costString = costTemplate(skill, ALLY.Job.Angel);
    }
    public static void protect(SKILL skill, ref string skillNameString, ref string linageString, ref string effectString, ref string explainString, ref string costString)
    {
        ProtectWall angel = skill as ProtectWall;
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                skillNameString = nameTemplate(skill, "Protect Wall");
                linageString = "Angel <color=#32ff32>Enhance</color>";
                explainString = descriptionTemplate(skill, "A shield of celestial energy surrounds you,\n  boosting your DEF and MDEF.");
                effectString = "- DEF : + " + tDigit(angel.Damage(), 2) + "\n- MDEF : + " + tDigit(angel.Damage(), 2) + "\n- Interval : " + tDigit(angel.AttackInterval(), 2);
                break;
            case Language.jp:
                skillNameString = nameTemplate(skill, "プロテクトウォール");
                linageString = LinageTemplate("天使  <color=#32ff32>強化</color>");
                explainString = descriptionTemplate(skill, "天の力を借りた盾があなたを包みます. \n物理防御と魔法防御が上がります. ");
                effectString = effectString = "- DEF : + " + tDigit(angel.Damage(), 2) + "\n- MDEF : + " + tDigit(angel.Damage(), 2) + "\n- 発動間隔 : " + tDigit(angel.AttackInterval(), 2);
                break;
            case Language.chi:
                skillNameString = nameTemplate(skill, "防御墙");
                linageString = LinageTemplate("天使  <color=#32ff32>強化</color>");
                explainString = descriptionTemplate(skill, "一定时间内增加物理防御和魔法防御. ");
                effectString = effectString = "- DEF : + " + tDigit(angel.Damage(), 2) + "\n- MDEF : + " + tDigit(angel.Damage(), 2) + "\n- 技能冷却 : " + tDigit(angel.AttackInterval(), 2);
                break;

            default:
                skillNameString = nameTemplate(skill, "Protect Wall");
                linageString = "Angel <color=#32ff32>Enhance</color>";
                explainString = descriptionTemplate(skill, "A shield of celestial energy surrounds you,\n  boosting your DEF and MDEF.");
                effectString = "- DEF : + " + tDigit(angel.Damage(), 2) + "\n- MDEF : + " + tDigit(angel.Damage(), 2) + "\n- Interval : " + tDigit(angel.AttackInterval(), 2);
                break;
        }
        costString = costTemplate(skill, ALLY.Job.Angel);
    }

    public static void haste(SKILL skill, ref string skillNameString, ref string linageString, ref string effectString, ref string explainString, ref string costString)
    {
        Haste angel = skill as Haste;
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                skillNameString = nameTemplate(skill, "Haste");
                linageString = "Angel <color=#32ff32>Enhance</color>";
                explainString = descriptionTemplate(skill, "trigger\n - A special technique that greatly enhances\n  your SPD.");
                effectString = "- SPD : + " + tDigit(skill.Damage(), 2) + "%\n- Interval : " + tDigit(skill.AttackInterval(), 2);
                break;
            case Language.jp:
                skillNameString = nameTemplate(skill, "ヘイスト");
                linageString = LinageTemplate("天使  <color=#32ff32>強化</color>");
                explainString = descriptionTemplate(skill, "特別な技術があなたのスピードを大幅に上げます. ");
                effectString = "- SPD : + " + tDigit(skill.Damage(), 2) + "%\n- 発動間隔 : " + tDigit(skill.AttackInterval(), 2);
                break;
            case Language.chi:
                skillNameString = nameTemplate(skill, "极速");
                linageString = LinageTemplate("天使  <color=#32ff32>强化</color>");
                explainString = descriptionTemplate(skill, "一定时间内增加速度. ");
                effectString = "- SPD : + " + tDigit(skill.Damage(), 2) + "%\n- 技能冷却 : " + tDigit(skill.AttackInterval(), 2);
                break;

            default:
                skillNameString = nameTemplate(skill, "Haste");
                linageString = "Angel <color=#32ff32>Enhance</color>";
                explainString = descriptionTemplate(skill, "trigger\n - A special technique that greatly enhances\n  your SPD.");
                effectString = "- SPD : + " + tDigit(skill.Damage(), 2) + "%\n- Interval : " + tDigit(skill.AttackInterval(), 2);
                break;
        }
        costString = costTemplate(skill, ALLY.Job.Angel);
    }

    public static void distact(SKILL skill, ref string skillNameString, ref string linageString, ref string effectString, ref string explainString, ref string costString)
    {
        AngelDistraction angel = skill as AngelDistraction;
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                skillNameString = nameTemplate(skill, "Angel Distraction");
                linageString = "Angel <color=#32ff32>Enhance</color>";
                explainString = descriptionTemplate(skill, "A powerful hymn that magnifies the amount of Gold\n  you receive.");
                effectString = "- Gain Gold : + " + tDigit(angel.Damage(), 2) + "%\n- Interval : " + tDigit(angel.AttackInterval(), 2);
                break;
            case Language.jp:
                skillNameString = nameTemplate(skill, "エンジェルディストラクション");
                linageString = LinageTemplate("天使  <color=#32ff32>強化</color>");
                explainString = descriptionTemplate(skill, "得られるゴールドを大幅に増やす. ");
                effectString = "- 獲得ゴールド : + " + tDigit(angel.Damage(), 2) + "%\n- 発動間隔 : " + tDigit(angel.AttackInterval(), 2);
                break;
            case Language.chi:
                skillNameString = nameTemplate(skill, "天使的祝福");
                linageString = LinageTemplate("天使  <color=#32ff32>强化</color>");
                explainString = descriptionTemplate(skill, "一定时间内增加金币获取. ");
                effectString = "- 金币获取 : + " + tDigit(angel.Damage(), 2) + "%\n- 技能冷却 : " + tDigit(angel.AttackInterval(), 2);
                break;

            default:
                skillNameString = nameTemplate(skill, "Angel Distraction");
                linageString = "Angel <color=#32ff32>Enhance</color>";
                explainString = descriptionTemplate(skill, "A powerful hymn that magnifies the amount of Gold\n  you receive.");
                effectString = "- Gain Gold : + " + tDigit(angel.Damage(), 2) + "%\n- Interval : " + tDigit(angel.AttackInterval(), 2);
                break;
        }
        costString = costTemplate(skill, ALLY.Job.Angel);
    }
    public static void holdwing(SKILL skill, ref string skillNameString, ref string linageString, ref string effectString, ref string explainString, ref string costString)
    {
        HoldWings angel = skill as HoldWings;
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                skillNameString = nameTemplate(skill, "Hold Wings");
                linageString = "Angel <color=#32ff32>Enhance</color>";
                explainString = descriptionTemplate(skill, "A vast archive of knowledge expands in your mind \n  and boosts Skill Proficiency.");
                effectString = "- Skill Proficiency : + " + tDigit(angel.Damage(), 2) + "%\n- Interval : " + tDigit(angel.AttackInterval(), 2);
                break;
            case Language.jp:
                skillNameString = nameTemplate(skill, "ホールドウィングス");
                linageString = LinageTemplate("天使  <color=#32ff32>強化</color>");
                explainString = descriptionTemplate(skill, "壮大な知識の書庫があなたの頭脳に宿ります. \n得られるスキルの熟練度が大幅に上昇します. ");
                effectString = "- スキル熟練度 : + " + tDigit(angel.Damage(), 2) + "%\n- 発動間隔 : " + tDigit(angel.AttackInterval(), 2);
                break;
            case Language.chi:
                skillNameString = nameTemplate(skill, "神圣祝福");
                linageString = LinageTemplate("天使  <color=#32ff32>强化</color>");
                explainString = descriptionTemplate(skill, "一定时间内增加技能熟练度获取. ");
                effectString = "- 技能熟练度获取: + " + tDigit(angel.Damage(), 2) + "%\n- 技能冷却 : " + tDigit(angel.AttackInterval(), 2);
                break;

            default:
                skillNameString = nameTemplate(skill, "Hold Wings");
                linageString = "Angel <color=#32ff32>Enhance</color>";
                explainString = descriptionTemplate(skill, "A vast archive of knowledge expands in your mind \n  and boosts Skill Proficiency.");
                effectString = "- Skill Proficiency : + " + tDigit(angel.Damage(), 2) + "%\n- Interval : " + tDigit(angel.AttackInterval(), 2);
                break;
        }
        costString = costTemplate(skill, ALLY.Job.Angel);
    }
}
