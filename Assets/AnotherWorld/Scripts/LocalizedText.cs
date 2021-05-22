using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Another;
using static UsefulMethod;

namespace Another
{
    public enum Language
    {
        English,
        Japanese,
        Chinese,
    }
    public enum BasicWord
    {
        Gain,
        Proficiency,
        Area,
        Wave,
        Areacleared,
        Areafailed,
        CompltedTime,
        TotalGoldGained,
        TotalExpGained,
        TotalMaterialsGained,
        Mission,
        AreaMastery,
        MasteryBonus,
        CompletedNum,
        Current,
        Next,
        LevelUp,
        RankUp,
        Sec,
        Effect,
        PassiveEffect,
        MaterialsToLevelUp,
        MaterialsToRankUp,
        Levelup,
        Rankup,
        Bonus,
        GoldCap,
    }
    public enum EffectKind
    {
        PhysicalDamage,
        FireDamage,
        IceDamage,
        ThunderDamage,
        LightDamage,
        DarkDamage,
        Heal,
        MPGain,
        MPConsumption,
        Cooltime,
        Range,
    }
    public class LocalizedText : MonoBehaviour
    {
        public Language language;
        public static LocalizedText localized;

        public string Basic(BasicWord basicWord)
        {
            string tempString = "";
            switch (language)
            {
                case Language.Japanese:
                    switch (basicWord)
                    {
                        case BasicWord.Gain:
                            tempString = "獲得量";
                            break;
                        case BasicWord.Area:
                            tempString = "エリア";
                            break;
                        case BasicWord.Wave:
                            tempString = "ステージ";
                            break;
                        case BasicWord.Proficiency:
                            tempString = "熟練度";
                            break;
                        case BasicWord.Areacleared:
                            tempString = "エリアコンプリート!";
                            break;
                        case BasicWord.Areafailed:
                            tempString = "探索失敗...";
                            break;
                        case BasicWord.CompltedTime:
                            tempString = "探索時間";
                            break;
                        case BasicWord.TotalGoldGained:
                            tempString = "合計獲得ゴールド";
                            break;
                        case BasicWord.TotalExpGained:
                            tempString = "合計獲得EXP";
                            break;
                        case BasicWord.TotalMaterialsGained:
                            tempString = "獲得した素材";
                            break;
                        case BasicWord.Mission:
                            tempString = "ミッション";
                            break;
                        case BasicWord.AreaMastery:
                            tempString = "探索ボーナス";
                            break;
                        case BasicWord.MasteryBonus:
                            tempString = "探索ボーナス";
                            break;
                        case BasicWord.CompletedNum:
                            tempString = "クリア回数";
                            break;
                        case BasicWord.Current:
                            tempString = "現在";
                            break;
                        case BasicWord.Next:
                            tempString = "次回";
                            break;
                        case BasicWord.LevelUp:
                            tempString = "レベルアップ";
                            break;
                        case BasicWord.RankUp:
                            tempString = "ランクアップ";
                            break;
                        case BasicWord.Sec:
                            tempString = "秒";
                            break;
                        case BasicWord.Effect:
                            tempString = "効果";
                            break;
                        case BasicWord.PassiveEffect:
                            tempString = "パッシブ効果";
                            break;
                        case BasicWord.MaterialsToLevelUp:
                            tempString = "レベルアップに必要な素材";
                            break;
                        case BasicWord.MaterialsToRankUp:
                            tempString = "ランクアップに必要な素材";
                            break;
                        case BasicWord.Levelup:
                            tempString = "レベルアップ";
                            break;
                        case BasicWord.Rankup:
                            tempString = "ランクアップ";
                            break;
                        case BasicWord.Bonus:
                            tempString = "ボーナス";
                            break;
                    }
                    break;
                default://English
                    switch (basicWord)
                    {
                        case BasicWord.Gain:
                            tempString = "Gain";
                            break;
                        case BasicWord.Area:
                            tempString = "Area";
                            break;
                        case BasicWord.Wave:
                            tempString = "Wave";
                            break;
                        case BasicWord.Proficiency:
                            tempString = "Proficiency";
                            break;
                        case BasicWord.Areacleared:
                            tempString = "Area Completed!";
                            break;
                        case BasicWord.Areafailed:
                            tempString = "Area Failed...";
                            break;
                        case BasicWord.CompltedTime:
                            tempString = "Time";
                            break;
                        case BasicWord.TotalGoldGained:
                            tempString = "Total Gold Gained";
                            break;
                        case BasicWord.TotalExpGained:
                            tempString = "Total EXP Gained";
                            break;
                        case BasicWord.TotalMaterialsGained:
                            tempString = "Total Materials Gained";
                            break;
                        case BasicWord.Mission:
                            tempString = "Mission";
                            break;
                        case BasicWord.AreaMastery:
                            tempString = "Area Mastery";
                            break;
                        case BasicWord.MasteryBonus:
                            tempString = "Mastery Bonus";
                            break;
                        case BasicWord.CompletedNum:
                            tempString = "Completed #";
                            break;
                        case BasicWord.Current:
                            tempString = "Current";
                            break;
                        case BasicWord.Next:
                            tempString = "Next";
                            break;
                        case BasicWord.LevelUp:
                            tempString = "Level Up";
                            break;
                        case BasicWord.RankUp:
                            tempString = "Rank Up";
                            break;
                        case BasicWord.Sec:
                            tempString = "sec";
                            break;
                        case BasicWord.Effect:
                            tempString = "Effect";
                            break;
                        case BasicWord.PassiveEffect:
                            tempString = "Passive Effect";
                            break;
                        case BasicWord.MaterialsToLevelUp:
                            tempString = "Materials to Level Up";
                            break;
                        case BasicWord.MaterialsToRankUp:
                            tempString = "Materials to Rank Up";
                            break;
                        case BasicWord.Levelup:
                            tempString = "Level Up";
                            break;
                        case BasicWord.Rankup:
                            tempString = "Rank Up";
                            break;
                        case BasicWord.Bonus:
                            tempString = "Bonus";
                            break;
                    }
                    break;
            }
            return tempString;
        }
        //Menu
        public string Menu(Menu menu)
        {
            string tempString = "";
            switch (language)
            {
                case Language.Japanese:
                    switch (menu)
                    {
                        case Another.Menu.Upgrade:
                            tempString = "アップグレード";
                            break;
                        case Another.Menu.Skill:
                            tempString = "スキル";
                            break;
                        case Another.Menu.Explore:
                            tempString = "探索";
                            break;
                        case Another.Menu.Craft:
                            tempString = "クラフト";
                            break;
                    }
                    break;
                default:
                    switch (menu)
                    {
                        case Another.Menu.Upgrade:
                            tempString = "Upgrade";
                            break;
                        case Another.Menu.Skill:
                            tempString = "Skill";
                            break;
                        case Another.Menu.Explore:
                            tempString = "Explore";
                            break;
                        case Another.Menu.Craft:
                            tempString = "Craft";
                            break;
                    }
                    break;
            }
            return tempString;
        }
        //Stats
        public string Stat(Stats stats, bool isShort = false)
        {
            string tempString = "";
            switch (language)
            {
                case Language.Japanese:
                    switch (stats)
                    {
                        case Stats.Hp:
                            tempString = optStr + "<sprite=\"stats\" index=0>";
                            if (!isShort) tempString += " HP";
                            break;
                        case Stats.Mp:
                            tempString = optStr + "<sprite=\"stats\" index=1>";
                            if (!isShort) tempString += " MP";
                            break;
                        case Stats.Atk:
                            tempString = optStr + "<sprite=\"stats\" index=2>";
                            if (!isShort) tempString += " ATK";
                            break;
                        case Stats.MAtk:
                            tempString = optStr + "<sprite=\"stats\" index=3>";
                            if (!isShort) tempString += " MATK";
                            break;
                        case Stats.Def:
                            tempString = optStr + "<sprite=\"stats\" index=4>";
                            if (!isShort) tempString += " DEF";
                            break;
                        case Stats.MDef:
                            tempString = optStr + "<sprite=\"stats\" index=5>";
                            if (!isShort) tempString += " MDEF";
                            break;
                        case Stats.Spd:
                            tempString = optStr + "<sprite=\"stats\" index=6>";
                            if (!isShort) tempString += " SPD";
                            break;
                        case Stats.FireRes:
                            tempString = optStr + "<sprite=\"stats\" index=7>";
                            if (!isShort) tempString += " Fire Resistance";
                            break;
                        case Stats.IceRes:
                            tempString = optStr + "<sprite=\"stats\" index=8>";
                            if (!isShort) tempString += " Ice Resistance";
                            break;
                        case Stats.ThunderRes:
                            tempString = optStr + "<sprite=\"stats\" index=9>";
                            if (!isShort) tempString += " Thunder Resistance";
                            break;
                        case Stats.LightRes:
                            tempString = optStr + "<sprite=\"stats\" index=10>";
                            if (!isShort) tempString += " Light Resistance";
                            break;
                        case Stats.DarkRes:
                            tempString = optStr + "<sprite=\"stats\" index=11>";
                            if (!isShort) tempString += " Dark Resistance";
                            break;
                        case Stats.DodgeChance:
                            tempString = "回避率";
                            break;
                        case Stats.PhysCritChance:
                            tempString = "物理クリティカル率";
                            break;
                        case Stats.MagCritChance:
                            tempString = "魔法クリティカル率";
                            break;
                        case Stats.GoldGain:
                            tempString = "ゴールド獲得量";
                            break;
                        case Stats.ExpGain:
                            tempString = "EXP獲得量";
                            break;
                        case Stats.ProficiencyGain:
                            tempString = "熟練度獲得量";
                            break;
                        case Stats.NormalDropChance:
                            tempString = "ノーマルドロップ率";
                            break;
                        case Stats.ColorDropChance:
                            tempString = "カラードロップ率";
                            break;
                        case Stats.UniqueDropChance:
                            tempString = "ユニークドロップ率";
                            break;
                        case Stats.MoveSpeed:
                            tempString = "移動速度";
                            break;
                        case Stats.StoneGain:
                            tempString = "ストーン生産量";
                            break;
                        case Stats.CrystalGain:
                            tempString = "クリスタル生産量";
                            break;
                        case Stats.LeafGain:
                            tempString = "リーフ生産量";
                            break;
                        case Stats.GoldCap:
                            tempString = "ゴールドキャップ";
                            break;
                        case Stats.SlimeCoinCap:
                            tempString = "スライムコインキャップ";
                            break;
                    }
                    break;
                default://English
                    switch (stats)
                    {
                        case Stats.Hp:
                            tempString = optStr + "<sprite=\"stats\" index=0>";
                            if (!isShort) tempString += " HP";
                            break;
                        case Stats.Mp:
                            tempString = optStr + "<sprite=\"stats\" index=1>";
                            if (!isShort) tempString += " MP";
                            break;
                        case Stats.Atk:
                            tempString = optStr + "<sprite=\"stats\" index=2>";
                            if (!isShort) tempString += " ATK";
                            break;
                        case Stats.MAtk:
                            tempString = optStr + "<sprite=\"stats\" index=3>";
                            if (!isShort) tempString += " MATK";
                            break;
                        case Stats.Def:
                            tempString = optStr + "<sprite=\"stats\" index=4>";
                            if (!isShort) tempString += " DEF";
                            break;
                        case Stats.MDef:
                            tempString = optStr + "<sprite=\"stats\" index=5>";
                            if (!isShort) tempString += " MDEF";
                            break;
                        case Stats.Spd:
                            tempString = optStr + "<sprite=\"stats\" index=6>";
                            if (!isShort) tempString += " SPD";
                            break;
                        case Stats.FireRes:
                            tempString = optStr + "<sprite=\"stats\" index=7>";
                            if (!isShort) tempString += " Fire Resistance";
                            break;
                        case Stats.IceRes:
                            tempString = optStr + "<sprite=\"stats\" index=8>";
                            if (!isShort) tempString += " Ice Resistance";
                            break;
                        case Stats.ThunderRes:
                            tempString = optStr + "<sprite=\"stats\" index=9>";
                            if (!isShort) tempString += " Thunder Resistance";
                            break;
                        case Stats.LightRes:
                            tempString = optStr + "<sprite=\"stats\" index=10>";
                            if (!isShort) tempString += " Light Resistance";
                            break;
                        case Stats.DarkRes:
                            tempString = optStr + "<sprite=\"stats\" index=11>";
                            if (!isShort) tempString += " Dark Resistance";
                            break;
                        case Stats.DodgeChance:
                            tempString = "Dodge Chance";
                            break;
                        case Stats.PhysCritChance:
                            tempString = "Physical Critical Chance";
                            break;
                        case Stats.MagCritChance:
                            tempString = "Magical Critical Chance";
                            break;
                        case Stats.GoldGain:
                            tempString = "Gold Gain";
                            break;
                        case Stats.ExpGain:
                            tempString = "EXP Gain";
                            break;
                        case Stats.ProficiencyGain:
                            tempString = "Proficiency Gain";
                            break;
                        case Stats.NormalDropChance:
                            tempString = "Normal Drop Chance";
                            break;
                        case Stats.ColorDropChance:
                            tempString = "Color Drop Chance";
                            break;
                        case Stats.UniqueDropChance:
                            tempString = "Unique Drop Chance";
                            break;
                        case Stats.MoveSpeed:
                            tempString = "Move Speed";
                            break;
                        case Stats.StoneGain:
                            tempString = "Stone Production";
                            break;
                        case Stats.CrystalGain:
                            tempString = "Crystal Production";
                            break;
                        case Stats.LeafGain:
                            tempString = "Leaf Production";
                            break;
                        case Stats.GoldCap:
                            tempString = "Gold Cap";
                            break;
                        case Stats.SlimeCoinCap:
                            tempString = "Slime Coin Cap";
                            break;
                    }
                    break;
            }
            return tempString;
        }
        //Resource
        public string Resource(Resource resource)
        {
            string tempString = "";
            switch (language)
            {
                case Language.Japanese:
                    switch (resource)
                    {
                        case Another.Resource.Gold:
                            tempString = "ゴールド";
                            break;
                        case Another.Resource.SlimeCoin:
                            tempString = "スライムコイン";
                            break;
                        case Another.Resource.Stone:
                            tempString = "ストーン";
                            break;
                        case Another.Resource.Crystal:
                            tempString = "クリスタル";
                            break;
                        case Another.Resource.Leaf:
                            tempString = "リーフ";
                            break;
                    }
                    break;
                default://English
                    switch (resource)
                    {
                        case Another.Resource.Gold:
                            tempString = "Gold";
                            break;
                        case Another.Resource.SlimeCoin:
                            tempString = "Slime Coin";
                            break;
                        case Another.Resource.Stone:
                            tempString = "Stone";
                            break;
                        case Another.Resource.Crystal:
                            tempString = "Crystal";
                            break;
                        case Another.Resource.Leaf:
                            tempString = "Leaf";
                            break;
                    }
                    break;
            }
            return tempString;
        }
        //Class, Job
        public string Class(Class job)
        {
            string tempString = "";
            switch (language)
            {
                case Language.Japanese:
                    switch (job)
                    {
                        case Another.Class.Warrior:
                            tempString = "戦士";
                            break;
                        case Another.Class.Wizard:
                            tempString = "魔法使い";
                            break;
                        case Another.Class.Angel:
                            tempString = "天使";
                            break;
                    }
                    break;
                default:
                    switch (job)
                    {
                        case Another.Class.Warrior:
                            tempString = "Warrior";
                            break;
                        case Another.Class.Wizard:
                            tempString = "Wizard";
                            break;
                        case Another.Class.Angel:
                            tempString = "Angel";
                            break;
                    }
                    break;
            }
            return tempString;
        }
        //Upgrade
        //public string UpgradeName(UpgradeKind kind, Resource resource)
        //{
        //    string tempString = "";
        //    switch (language)
        //    {
        //        case Language.Japanese:
        //            switch (kind)
        //            {
        //                case UpgradeKind.Resource:
        //                    switch (resource)
        //                    {
        //                        case Another.Resource.Stone:
        //                            tempString = "ストーン生産";
        //                            break;
        //                        case Another.Resource.Crystal:
        //                            tempString = "クリスタル生産";
        //                            break;
        //                        case Another.Resource.Leaf:
        //                            tempString = "リーフ生産";
        //                            break;
        //                    }
        //                    break;
        //                case UpgradeKind.GoldCap:
        //                    switch (resource)
        //                    {
        //                        case Another.Resource.Stone:
        //                            tempString = "ストーンゴールドキャップ";
        //                            break;
        //                        case Another.Resource.Crystal:
        //                            tempString = "クリスタルゴールドキャップ";
        //                            break;
        //                        case Another.Resource.Leaf:
        //                            tempString = "リーフゴールドキャップ";
        //                            break;
        //                    }
        //                    break;
        //            }
        //            break;
        //        default:
        //            switch (kind)
        //            {
        //                case UpgradeKind.Resource:
        //                    switch (resource)
        //                    {
        //                        case Another.Resource.Stone:
        //                            tempString = "Stone Production";
        //                            break;
        //                        case Another.Resource.Crystal:
        //                            tempString = "Crystal Production";
        //                            break;
        //                        case Another.Resource.Leaf:
        //                            tempString = "Leaf Production";
        //                            break;
        //                    }
        //                    break;
        //                case UpgradeKind.GoldCap:
        //                    switch (resource)
        //                    {
        //                        case Another.Resource.Stone:
        //                            tempString = "Stone Gold Cap";
        //                            break;
        //                        case Another.Resource.Crystal:
        //                            tempString = "Crystal Gold Cap";
        //                            break;
        //                        case Another.Resource.Leaf:
        //                            tempString = "Leaf Gold Cap";
        //                            break;
        //                    }
        //                    break;
        //            }
        //            break;
        //    }
        //    return tempString;
        //}
        //Explorable Area
        public string Area(int id)
        {
            string tempString = "The Slime Slums";
            switch (language)
            {
                case Language.Japanese:
                    switch (id)
                    {
                        case 11:
                            tempString = "スライムスラム街";
                            break;
                        case 12:
                            tempString = "スライムの集落";
                            break;
                        case 13:
                            tempString = "The Slime Plains";
                            break;
                        case 14:
                            tempString = "The Slime Pits";
                            break;
                        case 15:
                            tempString = "The Slime Pools";
                            break;
                        case 16:
                            tempString = "The Slime Forest";
                            break;
                        case 17:
                            tempString = "Slime Castle";
                            break;
                        case 18:
                            tempString = "Slime Throne Room";
                            break;
                        case 21:
                            tempString = "The Dark Forest";
                            break;
                        case 22:
                            tempString = "Cave in the Woods";
                            break;
                    }
                    break;
                default:
                    switch (id)
                    {
                        case 11:
                            tempString = "The Slime Slums";
                            break;
                        case 12:
                            tempString = "The Slime Village";
                            break;
                        case 13:
                            tempString = "The Slime Plains";
                            break;
                        case 14:
                            tempString = "The Slime Pits";
                            break;
                        case 15:
                            tempString = "The Slime Pools";
                            break;
                        case 16:
                            tempString = "The Slime Forest";
                            break;
                        case 17:
                            tempString = "Slime Castle";
                            break;
                        case 18:
                            tempString = "Slime Throne Room";
                            break;
                        case 21:
                            tempString = "The Dark Forest";
                            break;
                        case 22:
                            tempString = "Cave in the Woods";
                            break;
                    }
                    break;
            }
            return tempString;
        }
        //Mission
        public string Mission(int areaId, MissionKind kind, double value)
        {
            string tempString = "";
            switch (language)
            {
                case Language.Japanese:
                    switch (kind)
                    {
                        case MissionKind.Clear:
                            tempString = "このエリアをクリアする";
                            break;
                        case MissionKind.ClearNum:
                            tempString = optStr + tDigit(value) + "回クリアする";
                            break;
                        case MissionKind.Hp:
                            tempString = optStr + "75%以上のHPでクリアする";
                            break;
                        case MissionKind.OnlyBase:
                            tempString = optStr + "基礎攻撃のみでクリアする";
                            break;
                        case MissionKind.NoEq:
                            tempString = optStr + "装備を使用せずにクリアする";
                            break;
                        case MissionKind.Time:
                            tempString = optStr + tDigit(value) + "秒以内にクリアする";
                            break;
                        case MissionKind.TimeOver:
                            tempString = optStr + tDigit(value) + "秒以上かけてクリアする";
                            break;
                        case MissionKind.SpendTime:
                            tempString = optStr + "合計" + DoubleTimeToDate(value) + "の時間を過ごす ( " + DoubleTimeToDate(Main.main.S.ASpendTime[areaId]) + " )";
                            break;
                        case MissionKind.Capture:
                            break;
                        case MissionKind.Gather:
                            break;
                        case MissionKind.Defeat:
                            break;
                        case MissionKind.Gold:
                            tempString = optStr + "１周で" + tDigit(value) + "ゴールドを獲得する";
                            break;
                        case MissionKind.NoDmg:
                            tempString = optStr + "ダメージを受けずにクリアする";
                            break;
                        case MissionKind.All:
                            tempString = optStr + "全てのミッションをクリアする";
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    switch (kind)
                    {
                        case MissionKind.Clear:
                            tempString = "Complete this area";
                            break;
                        case MissionKind.ClearNum:
                            tempString = optStr + "Complete " + tDigit(value) + " times";
                            break;
                        case MissionKind.Hp:
                            tempString = optStr + "Complete when HP is more than 75%";
                            break;
                        case MissionKind.OnlyBase:
                            tempString = optStr + "Complete with only Base Attack";
                            break;
                        case MissionKind.NoEq:
                            tempString = optStr + "Complete with no Equipment";
                            break;
                        case MissionKind.Time:
                            tempString = optStr + "Complete within " + tDigit(value) + " sec";
                            break;
                        case MissionKind.TimeOver:
                            tempString = optStr + "Complete over " + tDigit(value) + " sec";
                            break;
                        case MissionKind.SpendTime:
                            tempString = optStr + "Spend " + DoubleTimeToDate(value) + " here ( " + DoubleTimeToDate(Main.main.S.ASpendTime[areaId]) + " )";
                            break;
                        case MissionKind.Capture:
                            break;
                        case MissionKind.Gather:
                            break;
                        case MissionKind.Defeat:
                            break;
                        case MissionKind.Gold:
                            tempString = optStr + "Gain " + tDigit(value) + " Gold in one complete";
                            break;
                        case MissionKind.NoDmg:
                            tempString = optStr + "Complete with receiving no damage";
                            break;
                        case MissionKind.All:
                            tempString = optStr + "Complete all missions";
                            break;
                        default:
                            break;
                    }
                    break;
            }
            return tempString;
        }
        //SkillName
        public string SkillName(Skill skill)
        {
            string tempString = "";
            switch (language)
            {
                case Language.Japanese:
                    switch (skill)
                    {
                        case Skill.SwordAttack:
                            tempString = "ソードアタック";
                            break;
                        case Skill.Slash:
                            tempString = "スラッシュ";
                            break;
                        case Skill.DoubleSlash:
                            tempString = "ダブルスラッシュ";
                            break;
                        case Skill.SonicSlash:
                            tempString = "ソニックスラッシュ";
                            break;
                        case Skill.SwingDown:
                            tempString = "振り下ろし";
                            break;
                        case Skill.SwingAround:
                            tempString = "振り回し";
                            break;
                        case Skill.ChargeSwing:
                            tempString = "チャージスイング";
                            break;
                        case Skill.FanSwing:
                            tempString = "ファンスイング";
                            break;
                        case Skill.ShieldAttack:
                            tempString = "シールドアタック";
                            break;
                        case Skill.KnockingShot:
                            tempString = "ノッキングショット";
                            break;
                        case Skill.StaffAttack:
                            break;
                        case Skill.FireBolt:
                            break;
                        case Skill.FireStorm:
                            break;
                        case Skill.MeteorStrike:
                            break;
                        case Skill.IceBolt:
                            break;
                        case Skill.ChillingTouch:
                            break;
                        case Skill.Blizzard:
                            break;
                        case Skill.ThunderBolt:
                            break;
                        case Skill.DoubleThunderBolt:
                            break;
                        case Skill.LightningThunder:
                            break;
                        case Skill.WingAttack:
                            break;
                        case Skill.WingShoot:
                            break;
                        case Skill.Heal:
                            break;
                        case Skill.GodBless:
                            break;
                        case Skill.MuscleInflation:
                            break;
                        case Skill.MagicImpact:
                            break;
                        case Skill.ProtectWall:
                            break;
                        case Skill.Haste:
                            break;
                        case Skill.AngelDistraction:
                            break;
                        case Skill.HoldWings:
                            break;
                        case Skill.Nothing:
                            break;
                    }
                    break;
                default:
                    switch (skill)
                    {
                        case Skill.SwordAttack:
                            tempString = "Sword Attack";
                            break;
                        case Skill.Slash:
                            tempString = "Slash";
                            break;
                        case Skill.DoubleSlash:
                            tempString = "Double Slash";
                            break;
                        case Skill.SonicSlash:
                            tempString = "Sonic Slash";
                            break;
                        case Skill.SwingDown:
                            tempString = "Swing Down";
                            break;
                        case Skill.SwingAround:
                            tempString = "Swing Around";
                            break;
                        case Skill.ChargeSwing:
                            tempString = "Charge Swing";
                            break;
                        case Skill.FanSwing:
                            tempString = "Fan Swing";
                            break;
                        case Skill.ShieldAttack:
                            tempString = "Shield Attack";
                            break;
                        case Skill.KnockingShot:
                            tempString = "Knocking Shot";
                            break;
                        case Skill.StaffAttack:
                            break;
                        case Skill.FireBolt:
                            break;
                        case Skill.FireStorm:
                            break;
                        case Skill.MeteorStrike:
                            break;
                        case Skill.IceBolt:
                            break;
                        case Skill.ChillingTouch:
                            break;
                        case Skill.Blizzard:
                            break;
                        case Skill.ThunderBolt:
                            break;
                        case Skill.DoubleThunderBolt:
                            break;
                        case Skill.LightningThunder:
                            break;
                        case Skill.WingAttack:
                            break;
                        case Skill.WingShoot:
                            break;
                        case Skill.Heal:
                            break;
                        case Skill.GodBless:
                            break;
                        case Skill.MuscleInflation:
                            break;
                        case Skill.MagicImpact:
                            break;
                        case Skill.ProtectWall:
                            break;
                        case Skill.Haste:
                            break;
                        case Skill.AngelDistraction:
                            break;
                        case Skill.HoldWings:
                            break;
                        case Skill.Nothing:
                            break;
                    }
                    break;
            }
            return tempString;
        }
        public string SkillEffect(EffectKind effect)
        {
            string tempString = "";
            switch (language)
            {
                case Language.Japanese:
                    switch (effect)
                    {
                        case EffectKind.PhysicalDamage:
                            tempString = "物理ダメージ";
                            break;
                        case EffectKind.FireDamage:
                            tempString = "炎ダメージ";
                            break;
                        case EffectKind.IceDamage:
                            tempString = "氷ダメージ";
                            break;
                        case EffectKind.ThunderDamage:
                            tempString = "雷ダメージ";
                            break;
                        case EffectKind.LightDamage:
                            tempString = "光ダメージ";
                            break;
                        case EffectKind.DarkDamage:
                            tempString = "闇ダメージ";
                            break;
                        case EffectKind.Heal:
                            tempString = "ヒール";
                            break;
                        case EffectKind.MPGain:
                            tempString = "獲得MP";
                            break;
                        case EffectKind.MPConsumption:
                            tempString = "消費MP";
                            break;
                        case EffectKind.Cooltime:
                            tempString = "クールタイム";
                            break;
                        case EffectKind.Range:
                            tempString = "射程距離";
                            break;
                    }
                    break;
                default:
                    switch (effect)
                    {
                        case EffectKind.PhysicalDamage:
                            tempString = "Physical Damage";
                            break;
                        case EffectKind.FireDamage:
                            tempString = "Fire Damage";
                            break;
                        case EffectKind.IceDamage:
                            tempString = "Ice Damage";
                            break;
                        case EffectKind.ThunderDamage:
                            tempString = "Thunder Damage";
                            break;
                        case EffectKind.LightDamage:
                            tempString = "Light Damage";
                            break;
                        case EffectKind.DarkDamage:
                            tempString = "Dark Damage";
                            break;
                        case EffectKind.Heal:
                            tempString = "Heal";
                            break;
                        case EffectKind.MPGain:
                            tempString = "MP Gain";
                            break;
                        case EffectKind.MPConsumption:
                            tempString = "MP Consumption";
                            break;
                        case EffectKind.Cooltime:
                            tempString = "Cooltime";
                            break;
                        case EffectKind.Range:
                            tempString = "Range";
                            break;
                    }
                    break;
            }
            return tempString;
        }
        //public string Equipment(Equipment equipment)
        //{
        //    string tempString = "";
        //    switch (language)
        //    {
        //        case Language.Japanese:
        //            break;
        //        default:
        //            break;
        //    }
        //    //仮
        //    tempString = equipment.ToString();
        //    return tempString;
        //}
        public string Material(Material material)
        {
            string tempString = "";
            switch (language)
            {
                case Language.Japanese:
                    break;
                default:
                    break;
            }
            //仮
            tempString = material.ToString();
            return tempString;
        }

        private void Awake()
        {
            localized = this;
        }
    }


}
