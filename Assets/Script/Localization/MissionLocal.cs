using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static BASE;
using static UsefulMethod;

public class MissionLocal : MonoBehaviour
{
    public static string capture(MISSION mission)
    {
        var mis = mission as M_capture;
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                return optStr + "- Capture " + tDigit(mis.requiredCaptureNum) + " " + main.ArtiCtrl.ConvertEnum(mis.TargetEnemy)
                    + " ( " + tDigit(Math.Min(mis.capturedNum, mis.requiredCaptureNum)) +  " / " +  tDigit(mis.requiredCaptureNum) +  " )";
            case Language.jp:
                return optStr + "- " + tDigit(mis.requiredCaptureNum) + "体の" + main.ArtiCtrl.ConvertEnum(mis.TargetEnemy)
                    + "をキャプチャーする ( " + tDigit(Math.Min(mis.capturedNum, mis.requiredCaptureNum)) + " / " + tDigit(mis.requiredCaptureNum) + " )";
            case Language.chi:
                return optStr + "- 捕捉 " + tDigit(mis.requiredCaptureNum) + " " + main.ArtiCtrl.ConvertEnum(mis.TargetEnemy)
                    + " ( " + tDigit(Math.Min(mis.capturedNum, mis.requiredCaptureNum)) + " / " + tDigit(mis.requiredCaptureNum) + " )";
            default:
                return optStr + "- Capture " + tDigit(mis.requiredCaptureNum) + " " + main.ArtiCtrl.ConvertEnum(mis.TargetEnemy)
                    + " ( " + tDigit(Math.Min(mis.capturedNum, mis.requiredCaptureNum)) + " / " + tDigit(mis.requiredCaptureNum) + " )";
        }
    }
    public static string clear()
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                return "- Clear this area";
            case Language.jp:
                return "- このエリアをクリアする";
            case Language.chi:
                return "- 完成这个区域";
            default:
                return "- Clear this area";
        }
    }
    public static string clearall()
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                return "- Clear All Missions";
            case Language.jp:
                return "- ミッションをすべてクリアする";
            case Language.chi:
                return "- 完成所有任务";
            default:
                return "- Clear All Missions";
        }
    }
    public static string clearNum(MISSION mission)
    {
        var mis = mission as M_clearNum;
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                return optStr + "- Clear this area " + mis.clearNum + " times";
            case Language.jp:
                return optStr + "- このエリアを" + mis.clearNum + "回クリアする";
            case Language.chi:
                return optStr + "- 完成这个区域 " + mis.clearNum + " 次";
            default:
                return optStr + "- Clear this area " + mis.clearNum + " times";
        }
    }
    public static string gold(MISSION mission)
    {
        var mis = mission as M_gold;
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                return optStr + "- Gain " + tDigit(mis.goldNum) + " Gold from this area in one clear";
            case Language.jp:
                return optStr + "- このエリア内でクリアするまでに" + tDigit(mis.goldNum) + "ゴールドを獲得する";
            case Language.chi:
                return optStr + "- 从这个区域获得 " + tDigit(mis.goldNum) + " 金";
            default:
                return optStr + "- Gain " + tDigit(mis.goldNum) + " Gold from this area in one clear";
        }
    }
    public static string hp(MISSION mission)
    {
        var mis = mission as M_hp;
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                return optStr + "- Clear when your HP is more than " + percent(mis.HP);
            case Language.jp:
                return optStr + "- このエリアをクリアしたときにHPが" + percent(mis.HP) + "以上残っている";
            case Language.chi:
                return optStr + "- 当你的HP超过" + percent(mis.HP) + "的时候, 就可以清除. ";
            default:
                return optStr + "- Clear when your HP is more than " + percent(mis.HP);
        }
    }
    public static string material(MISSION mission)
    {
        var mis = mission as M_material;
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                return optStr + "- Gather " + tDigit(mis.requiredMaterialNum) + " " +
                main.ArtiCtrl.ConvertEnum(mis.TargetMaterial) + " ( " + tDigit(Math.Min(mis.materialNum, mis.requiredMaterialNum)) + " / " + tDigit(mis.requiredMaterialNum) + " )";
            case Language.jp:
                return optStr + "- " + tDigit(mis.requiredMaterialNum) + "個の" +
                main.ArtiCtrl.ConvertEnum(mis.TargetMaterial) + "を集める.  ( " + tDigit(Math.Min(mis.materialNum, mis.requiredMaterialNum)) + " / " + tDigit(mis.requiredMaterialNum) + " )";
            case Language.chi:
                return optStr + "- 采集 " + tDigit(mis.requiredMaterialNum) + " " +
                main.ArtiCtrl.ConvertEnum(mis.TargetMaterial) + " ( " + tDigit(Math.Min(mis.materialNum, mis.requiredMaterialNum)) + " / " + tDigit(mis.requiredMaterialNum) + " )";
            default:
                return optStr + "- Gather " + tDigit(mis.requiredMaterialNum) + " " +
                main.ArtiCtrl.ConvertEnum(mis.TargetMaterial) + " ( " + tDigit(Math.Min(mis.materialNum, mis.requiredMaterialNum)) + " / " + tDigit(mis.requiredMaterialNum) + " )";
        }
    }
    public static string nodamage()
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                return "- Clear with receiving no damage";
            case Language.jp:
                return "- ダメージを一度も受けずにクリアする";
            case Language.chi:
                return "- 在没有受到伤害的情况下完成这个区域";
            default:
                return "- Clear with receiving no damage";
        }
    }
    public static string noeq()
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                return "- Clear this area with no Equipment";
            case Language.jp:
                return "- 装備を一個もつけずにクリアする";
            case Language.chi:
                return "- 在没有装备的情况下完成这个区域";
            default:
                return "- Clear this area with no Equipment";
        }
    }
    public static string oneshot()
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                return "- Defeat the monster with ONE SHOT";
            case Language.jp:
                return "- 一撃で敵を倒す";
            case Language.chi:
                return "- 一枪打倒怪物";
            default:
                return "- Defeat the monster with ONE SHOT";
        }
    }
    public static string onlyBase()
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                return "- Clear with only Base Attack";
            case Language.jp:
                return "- 各職業の基本スキルのみでクリアする";
            case Language.chi:
                return "- 只带基础攻击(Base Attack)";
            default:
                return "- Clear with only Base Attack";
        }
    }
    public static string onlymag()
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                return "- Clear this area using only Magical Damage";
            case Language.jp:
                return "- 魔法攻撃のみでクリアする";
            case Language.chi:
                return "- 只使用魔法伤害完成此区域";
            default:
                return "- Clear this area using only Magical Damage";
        }
    }

    public static string onlyphy()
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                return "- Clear this area using only Physical Damage";
            case Language.jp:
                return "- 物理攻撃のみでクリアする";
            case Language.chi:
                return "- 只使用物理伤害清除这个区域";
            default:
                return "- Clear this area using only Physical Damage";
        }
    }

    public static string spendtime(MISSION mission,DUNGEON dungeon)
    {
        var mis = mission as M_spendTime;
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                if (dungeon.spendTime == 0)
                    return optStr + "- Spend " + DoubleTimeToDate(mis.requiredSpendTime) + " here";
                else
                    return optStr + "- Spend " + DoubleTimeToDate(mis.requiredSpendTime) + " here ( " +
                        DoubleTimeToDate(Math.Min(dungeon.spendTime, mis.requiredSpendTime)) + " )";
            case Language.jp:
                if (dungeon.spendTime == 0)
                    return optStr + "- ここで" + DoubleTimeToDate(mis.requiredSpendTime) + " だけ過ごす";
                else
                    return optStr + "- ここで " + DoubleTimeToDate(mis.requiredSpendTime) + " だけ過ごす ( " +
                        DoubleTimeToDate(Math.Min(dungeon.spendTime, mis.requiredSpendTime)) + " )";
            case Language.chi:
                if (dungeon.spendTime == 0)
                    return optStr + "- 在这个区域花费 " + DoubleTimeToDate(mis.requiredSpendTime) + " ";
                else
                    return optStr + "- 在这个区域花费 " + DoubleTimeToDate(mis.requiredSpendTime) + " ( " +
                        DoubleTimeToDate(Math.Min(dungeon.spendTime, mis.requiredSpendTime)) + " )";
            default:
                if (dungeon.spendTime == 0)
                    return optStr + "- Spend " + DoubleTimeToDate(mis.requiredSpendTime) + " here";
                else
                    return optStr + "- Spend " + DoubleTimeToDate(mis.requiredSpendTime) + " here ( " +
                        DoubleTimeToDate(Math.Min(dungeon.spendTime, mis.requiredSpendTime)) + " )";
        }
    }

    public static string cleartime(MISSION mission)
    {
        var mis = mission as M_time;
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                    return optStr + "- Clear within " + mis.time.ToString("F0") + " seconds";
            case Language.jp:
                return optStr + "- " + mis.time.ToString("F0") + " 秒以内にクリアする";
            case Language.chi:
                return optStr + "- 在 " + mis.time.ToString("F0") + " 秒内完成这个区域. ";
            default:
                return optStr + "- Clear within " + mis.time.ToString("F0") + " seconds";
        }
    }
    public static string cleartimeover(MISSION mission)
    {
        var mis = mission as M_timeOver;
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                return optStr + "- Clear in OVER " + mis.time.ToString("F0") + " seconds";
            case Language.jp:
                return optStr + "- " + mis.time.ToString("F0") + " 秒以上経過してからクリアする";
            case Language.chi:
                return optStr + "- " + mis.time.ToString("F0") + " 秒钟或更长时间内完成此区域";
            default:
                return optStr + "- Clear in OVER " + mis.time.ToString("F0") + " seconds";
        }
    }
    public static string bat1(long target)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                return optStr + "- Defeat 2000 Normal Bats ( " + tDigit(Math.Min(target, 2000)) + " / 2000 )";
            case Language.jp:
                return optStr + "- ノーマルバットを2000体倒す ( " + tDigit(Math.Min(target, 2000)) + " / 2000 )";
            case Language.chi:
                return optStr + "- 打败 2000 Normal Bats ( " + tDigit(Math.Min(target, 2000)) + " / 2000 )";
            default:
                return optStr + "- Defeat 2000 Normal Bats ( " + tDigit(Math.Min(target, 2000)) + " / 2000 )";
        }
    }
    public static string bat5(long target)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                return optStr + "- Defeat 2000 Yellow Bats ( " + tDigit(Math.Min(target, 2000)) + " / 2000 )";
            case Language.jp:
                return optStr + "- イエローバットを2000体倒す ( " + tDigit(Math.Min(target, 2000)) + " / 2000 )";
            case Language.chi:
                return optStr + "- 打败 2000 Yellow Bats ( " + tDigit(Math.Min(target, 2000)) + " / 2000 )";
            default:
                return optStr + "- Defeat 2000 Yellow Bats ( " + tDigit(Math.Min(target, 2000)) + " / 2000 )";
        }
    }
    public static string bat7(long target)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                return optStr + "- Defeat 100 Metal Slimes ( " + tDigit(Math.Min(target, 100)) + " / 100 )";
            case Language.jp:
                return optStr + "- メタルスライムを100体倒す ( " + tDigit(Math.Min(target, 100)) + " / 100 )";
            case Language.chi:
                return optStr + "- 打败 100 Metal Slimes ( " + tDigit(Math.Min(target, 100)) + " / 100 )";
            default:
                return optStr + "- Defeat 100 Metal Slimes ( " + tDigit(Math.Min(target, 100)) + " / 100 )";
        }
    }
    public static string bat8(long target, long required)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                return optStr + "- Defeat " + required + " Black Bat ( " + tDigit(Math.Min(target, required)) + " / "+ required + " )";
            case Language.jp:
                return optStr + "- ブラックバットを" + required + "体倒す ( " + tDigit(Math.Min(target, required)) + " / " + required + " )";
            case Language.chi:
                return optStr + "- 打败 " + required + " Black Bat ( " + tDigit(Math.Min(target, required)) + " / " + required + " )";
            default:
                return optStr + "- Defeat " + required + " Black Bat ( " + tDigit(Math.Min(target, required)) + " / " + required + " )";
        }
    }
    public static string slime5(long target, long required)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                return optStr + "- Activate " + required + " active skills here ( " + tDigit(Math.Min(target, required)) + " / " + required + " )";
            case Language.jp:
                return optStr + "- アクティブスキルを" + required + "回発動する ( " + tDigit(Math.Min(target, required)) + " / " + required + " )";
            case Language.chi:
                return optStr + "- 在这里激活 " + required + " 个 Active Skills ( " + tDigit(Math.Min(target, required)) + " / " + required + " )";
            default:
                return optStr + "- Activate " + required + " active skills here ( " + tDigit(Math.Min(target, required)) + " / " + required + " )";
        }
    }
    public static string slime72(long target, long required)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                return optStr + "- Defeat " + required + " Metal Slimes ( " + tDigit(Math.Min(target, required)) + " / " + required + " )";
            case Language.jp:
                return optStr + "- メタルスライムを" + required + "体倒す ( " + tDigit(Math.Min(target, required)) + " / " + required + " )";
            case Language.chi:
                return optStr + "- 打败 " + required + " Metal Slimes ( " + tDigit(Math.Min(target, required)) + " / " + required + " )";
            default:
                return optStr + "- Defeat " + required + " Metal Slimes ( " + tDigit(Math.Min(target, required)) + " / " + required + " )";
        }
    }
    public static string slime7(long target, long required)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                return optStr + "- Defeat " + required + " Purple Slimes ( " + tDigit(Math.Min(target, required)) + " / " + required + " )";
            case Language.jp:
                return optStr + "- Purple Slime" + required + "体倒す ( " + tDigit(Math.Min(target, required)) + " / " + required + " )";
            case Language.chi:
                return optStr + "- 打败 " + required + " Purple Slimes ( " + tDigit(Math.Min(target, required)) + " / " + required + " )";
            default:
                return optStr + "- Defeat " + required + " Purple Slimes ( " + tDigit(Math.Min(target, required)) + " / " + required + " )";
        }
    }
    public static string slime8(long target, long required)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                return optStr + "- Defeat " + required + " Slime Boss ( " + tDigit(Math.Min(target, required)) + " / " + required + " )";
            case Language.jp:
                return optStr + "- スライムボスを" + required + "体倒す ( " + tDigit(Math.Min(target, required)) + " / " + required + " )";
            case Language.chi:
                return optStr + "- 打败 " + required + " Slime Boss ( " + tDigit(Math.Min(target, required)) + " / " + required + " )";
            default:
                return optStr + "- Defeat " + required + " Slime Boss ( " + tDigit(Math.Min(target, required)) + " / " + required + " )";
        }
    }
    public static string slime1(long target, long required)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                return optStr + "- Defeat 1000 Big Slime without any skills equipped ( " + tDigit(Math.Min(target, 1000)) + " / 1000 )";
            case Language.jp:
                return optStr + "- スキルを装備せずにスライムボスを" + required + "体倒す ( " + tDigit(Math.Min(target, required)) + " / " + required + " )";
            case Language.chi:
                return optStr + "- 打败 1000 Big Slime 在没有装备任何技能的情况下 ( " + tDigit(Math.Min(target, 1000)) + " / 1000 )";
            default:
                return optStr + "- Defeat 1000 Big Slime without any skills equipped ( " + tDigit(Math.Min(target, 1000)) + " / 1000 )";
        }
    }
    public static string slime6()
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                return "- Eat a sandwich while playing IEH";
            case Language.jp:
                return "- サンドイッチを食べながらIEHをプレイする";
            case Language.chi:
                return "- 一边吃三明治一边玩IEH";
            default:
                return "- Eat a sandwich while playing IEH";
        }
    }
}
