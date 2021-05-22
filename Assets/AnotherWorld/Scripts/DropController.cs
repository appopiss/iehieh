using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static Another.Main;
using static UsefulMethod;
using Cysharp.Threading.Tasks;
using TMPro;
using static Another.LocalizedText;
using System.Linq;
using Another;
using static Another.Material;
public partial class Save
{
    public double[] AMaterials;
}
namespace Another
{
    public class DropController : MonoBehaviour
    {
        //Materialの所持数を変えるときは必ずこれを参照する
        public void ChangeCurrentMaterial(Another.Material material, double value)
        {
            double tempValue = main.S.AMaterials[(int)material];
            tempValue += value;
            if (tempValue < 0) tempValue = 0;
            if (tempValue == Mathf.Infinity) tempValue = 1e300d;
            main.S.AMaterials[(int)material] = tempValue;
            //Log
            if (value > 0 && material != Another.Material.Nothing) main.Log(optStr + "<color=green>" + localized.Material(material) + " * " + tDigit(value) + "</color>");
        }
        public double NormalDropChance()
        {
            return main.battleCtrl.ally.TotalStats(Stats.NormalDropChance);
        }
        public double ColorDropChance()
        {
            return main.battleCtrl.ally.TotalStats(Stats.ColorDropChance);
        }
        public double UniqueDropChance()
        {
            return main.battleCtrl.ally.TotalStats(Stats.UniqueDropChance);
        }
        public void DropLottery(EnemySpecies species, EnemyColor color)
        {
            int value = 1;
            int rand = UnityEngine.Random.Range(0, 10000);
            Material material = Nothing;
            if (rand < NormalDropChance() * 10000)
            {
                material = NormalDropMaterial(color);
                if (material != Nothing) GainMaterial(material, value);
            }
            rand = UnityEngine.Random.Range(0, 10000);
            if (rand < ColorDropChance() * 10000)
            {
                material = ColorDropMaterial(color);
                if (material != Nothing) GainMaterial(material, value);
            }
            rand = UnityEngine.Random.Range(0, 10000);
            if (rand < UniqueDropChance() * 10000)
            {
                material = UniqueDropMaterial(species, color);
                if (material != Nothing) GainMaterial(material, value);
            }
        }
        void GainMaterial(Material material, double value)
        {
            ChangeCurrentMaterial(material, value);
            //Area Result
            main.areaCtrl.resultMaterials[(int)material] += value;
        }
        //以下は基本いじらない
        Material NormalDropMaterial(EnemyColor color)
        {
            int rand = UnityEngine.Random.Range(0, 10000);
            double tempChance = 0;
            for (int i = 0; i < NormalDropRate(color).Length; i++)
            {
                tempChance += NormalDropRate(color)[i];
                if (rand < tempChance * 10000)
                    return NormalDropTable()[i];
            }
            return Nothing;
        }
        Material ColorDropMaterial(EnemyColor color)
        {
            int rand = UnityEngine.Random.Range(0, 10000);
            double tempChance = 0;
            for (int i = 0; i < ColorDropRate(color).Length; i++)
            {
                tempChance += ColorDropRate(color)[i];
                if (rand < tempChance * 10000)
                    return ColorDropTable(color)[i];
            }
            return Nothing;
        }
        Material UniqueDropMaterial(EnemySpecies species, EnemyColor color)
        {
            int rand = UnityEngine.Random.Range(0, 10000);
            double tempChance = 0;
            for (int i = 0; i < UniqueDropRate(color).Length; i++)
            {
                tempChance += UniqueDropRate(color)[i];
                if (rand < tempChance * 10000)
                    return UniqueDropTable(species)[i];
            }
            return Nothing;
        }

        Material[] NormalDropTable()
        {
            return nTable;
        }
        double[] NormalDropRate(EnemyColor color)
        {
            switch (color)
            {
                case EnemyColor.Normal:
                    return nRateNormal;
                case EnemyColor.Blue:
                    return nRateCommon;
                case EnemyColor.Yellow:
                    return nRateCommon;
                case EnemyColor.Red:
                    return nRateUncommon;
                case EnemyColor.Green:
                    return nRateUncommon;
                case EnemyColor.Purple:
                    return nRateRare;
                case EnemyColor.Boss:
                    return nRateBoss;
                case EnemyColor.ChallengeBoss:
                    return nRateChallenge;
                case EnemyColor.Metal:
                    return nRateChallenge;
                default:
                    return nRateNormal;
            }
        }
        Material[] nTable = new Material[] { MonsterFluid, RelicStone, AncientCoin, BlackPearl };
        double[] nRateNormal = new double[] { 1.00, 0, 0, 0 };
        double[] nRateCommon = new double[] { 0.70, 0.30, 0, 0 };
        double[] nRateUncommon = new double[] { 0.35, 0.60, 0.05, 0 };
        double[] nRateRare = new double[] { 0.10, 0.70, 0.20, 0 };
        double[] nRateBoss = new double[] { 0, 0, 0.90, 0.10 };
        double[] nRateChallenge = new double[] { 0, 0, 0.10, 0.90 };

        Material[] ColorDropTable(EnemyColor color)
        {
            switch (color)
            {
                case EnemyColor.Blue:
                    return cTableBlue;
                case EnemyColor.Yellow:
                    return cTableYellow;
                case EnemyColor.Red:
                    return cTableRed;
                case EnemyColor.Green:
                    return cTableGreen;
                case EnemyColor.Purple:
                    return cTablePurple;
                case EnemyColor.Boss:
                    return cTableBoss;
                case EnemyColor.ChallengeBoss:
                    return cTableBoss;
                case EnemyColor.Metal:
                    return cTableBoss;
                default:
                    return cTableNothing;
            }
        }
        double[] ColorDropRate(EnemyColor color)
        {
            switch (color)
            {
                case EnemyColor.Normal:
                    return cRateNormal;
                default:
                    return cRateCommon;
            }
        }
        Material[] cTableNothing = new Material[] { Nothing, Nothing };
        Material[] cTableBlue = new Material[] { FrostShard, FrostCrystal };
        Material[] cTableYellow = new Material[] { LightningShard, LightningCrystal };
        Material[] cTableRed = new Material[] { FlameShard, FlameCrystal };
        Material[] cTableGreen = new Material[] { NatureShard, NatureCrystal };
        Material[] cTablePurple = new Material[] { PoisonShard, PoisonCrystal };
        Material[] cTableBoss = new Material[] { ManaShard, ManaCrystal };
        double[] cRateNormal = new double[] { 0, 0 };
        double[] cRateCommon = new double[] { 0.90, 0.10 };

        Material[] UniqueDropTable(EnemySpecies species)
        {
            switch (species)
            {
                case EnemySpecies.Slime:
                    return uTableSlime;
                case EnemySpecies.Bat:
                    return uTableBat;
                case EnemySpecies.Spider:
                    return uTableSpider;
                case EnemySpecies.Fairy:
                    return uTableFairy;
                case EnemySpecies.Fox:
                    return uTableFox;
                case EnemySpecies.MagicSlime:
                    return uTableMagicSlime;
                case EnemySpecies.DevifFish:
                    return uTableDevilFish;
                default:
                    return uTableNothing;
            }
        }
        double[] UniqueDropRate(EnemyColor color)
        {
            switch (color)
            {
                case EnemyColor.Normal:
                    return uRateNormal;
                case EnemyColor.Blue:
                    return uRateCommon;
                case EnemyColor.Yellow:
                    return uRateCommon;
                case EnemyColor.Red:
                    return uRateUncommon;
                case EnemyColor.Green:
                    return uRateUncommon;
                case EnemyColor.Purple:
                    return uRateRare;
                case EnemyColor.Boss:
                    return uRateBoss;
                default:
                    return uRateNothing;
            }
        }
        Material[] uTableNothing = new Material[] { Nothing, Nothing, Nothing };
        Material[] uTableSlime = new Material[] { OozeStainedCloth, OilOfSlime, SlimeCore };
        Material[] uTableBat = new Material[] { BatPelt, BatWing, BatCore };
        Material[] uTableSpider = new Material[] { SpiderBlood, SpiderSilk, SpiderCore };
        Material[] uTableFairy = new Material[] { FairyDust, FairyWing, FairyCore };
        Material[] uTableFox = new Material[] { FoxPelt, FoxEye, FoxCore };
        Material[] uTableMagicSlime = new Material[] { EnchantedCloth, GlowingSludge, MagicSlimeCore };
        Material[] uTableDevilFish = new Material[] { FishScales, FishTeeth, DevilFishCore };
        double[] uRateNothing = new double[] { 0, 0, 0 };
        double[] uRateNormal = new double[] { 1.00, 0, 0 };
        double[] uRateCommon = new double[] { 0.70, 0.30, 0 };
        double[] uRateUncommon = new double[] { 0.50, 0.50, 0 };
        double[] uRateRare = new double[] { 0.30, 0.70, 0, 0 };
        double[] uRateBoss = new double[] { 0, 0.90, 0.10 };
    }

    public enum Material
    {
        //汎用素材
        MonsterFluid,//Common
        RelicStone,//Uncommon
        AncientCoin,//Rare
        BlackPearl,//SuperRare
                   //カラー
        FrostShard,//Blue
        FrostCrystal,
        LightningShard,//Yellow
        LightningCrystal,
        FlameShard,//Red
        FlameCrystal,
        NatureShard,//Green
        NatureCrystal,
        PoisonShard,//Purple
        PoisonCrystal,
        ManaShard,//Black(Boss)
        ManaCrystal,
        //Slime
        OozeStainedCloth,
        OilOfSlime,
        SlimeCore,
        //Bat
        BatPelt,
        BatWing,
        BatCore,
        //Spider
        SpiderBlood,
        SpiderSilk,
        SpiderCore,
        //Fairy
        FairyDust,
        FairyWing,
        FairyCore,
        //Fox
        FoxPelt,
        FoxEye,
        FoxCore,
        //MagicSlime
        EnchantedCloth,
        GlowingSludge,
        MagicSlimeCore,
        //DevilFish
        FishScales,
        FishTeeth,
        DevilFishCore,
        //Challenge
        //SlimeKing
        ShinySlimeCrown,
        SlimeKingCore,
        //Golem
        RobustBorn,
        GolemCore,
        //Fairy
        FairyQueenDust,
        FairyQueenCore,
        //Deathpider
        PotentVenomSample,
        DeathpiderCore,
        //Bananoon
        RottenBanana,
        BananoonCore,
        //Octobaddie
        OctopusEye,
        OctobaddieCore,
        //DistortionSlime
        DarkMatter,
        DistortionSlimeCore,
        //フィールド系
        Herb,
        Berry,
        MagicSeed,
        RedChili,
        Stone,
        Crystal,
        Leaf,
        //クエストアイテム
        RainbowFish,
        ShabbyPurse,
        PoppyWinstonNeckless,
        Gold,
        Nothing,
    }

}

