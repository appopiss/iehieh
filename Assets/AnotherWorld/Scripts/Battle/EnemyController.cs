using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Cysharp.Threading.Tasks;
using Another;
using static Another.Main;
using static UsefulMethod;
using static Another.LocalizedText;

namespace Another
{
    public enum EnemySpecies
    {
        Slime,
        Bat,
        Spider,
        Fairy,
        Fox,
        MagicSlime,
        DevifFish,

        //SlimeKing,
        //Golem,
        //Deathpider,
        //FairyQueen,
        //Bananoon,
        //Octobaddie,
        //DistortionSlime,
    }
    public enum EnemyColor
    {
        Normal,
        Blue,
        Yellow,
        Red,
        Green,
        Purple,
        Boss,
        ChallengeBoss,
        Metal,
    }
    public enum EnemyRarity
    {
        Normal,
        Common,
        Uncommon,
        Rare,
        Boss,
    }
    public class EnemyController : MonoBehaviour
    {
        //HP,  MP, ATK, MATK, DEF, MDEF, SPD, FIRE, 
        double[] slimeNormal = new double[] { 10, 0, 5, 0, 0, 0, 10, -50, -50, -50, -100, -100 };
        double[] slimeBlue = new double[] { 20, 0, 10, 0, 0, 0, 10, -50, -50, -50, -100, -100 };
        double[] slimeYellow = new double[] { 10, 0, 5, 0, 0, 0, 15, -50, -50, -50, -100, -100 };
        double[] slimeRed = new double[] { 20, 0, 20, 0, 0, 0, 5, -50, -50, -50, -100, -100 };
        double[] slimeGreen = new double[] { 30, 0, 10, 0, 10, 0, 20, -50, -50, -50, -100, -100 };
        double[] slimePurple = new double[] { 30, 0, 40, 0, 50, 0, 5, -50, -50, -50, -100, -100 };
        double[] slimeBoss = new double[] { 50, 0, 50, 0, 50, 0, 10, -50, -50, -50, -100, -100 };

        public (double[] stats, Element element) InitStats(EnemySpecies species, EnemyColor color)
        {
            switch (species)
            {
                case EnemySpecies.Slime:
                    switch (color)
                    {
                        case EnemyColor.Normal:
                            return (slimeNormal, Element.Nothing);
                        case EnemyColor.Blue:
                            return (slimeBlue, Element.Nothing);
                        case EnemyColor.Yellow:
                            return (slimeYellow, Element.Nothing);
                        case EnemyColor.Red:
                            return (slimeRed, Element.Nothing);
                        case EnemyColor.Green:
                            return (slimeGreen, Element.Nothing);
                        case EnemyColor.Purple:
                            return (slimePurple, Element.Nothing);
                        case EnemyColor.Boss:
                            return (slimeBoss, Element.Nothing);
                        default:
                            return (slimeNormal, Element.Nothing);
                    }
                default:
                    switch (color)
                    {
                        case EnemyColor.Normal:
                            return (slimeNormal, Element.Nothing);
                        case EnemyColor.Blue:
                            return (slimeBlue, Element.Nothing);
                        case EnemyColor.Yellow:
                            return (slimeYellow, Element.Nothing);
                        case EnemyColor.Red:
                            return (slimeRed, Element.Nothing);
                        case EnemyColor.Green:
                            return (slimeGreen, Element.Nothing);
                        case EnemyColor.Purple:
                            return (slimePurple, Element.Nothing);
                        case EnemyColor.Boss:
                            return (slimeBoss, Element.Nothing);
                        default:
                            return (slimeNormal, Element.Nothing);
                    }
            }
        }
        public ENEMY[] enemies;
        public Sprite[] slimeSprite, batSprite, spiderSprite, fairySprite, foxSprite, mslimeSprite, fishSprite;

        private RectTransform thisRect;
        //Gold獲得
        public void GainGold(double value)
        {
            double tempValue = value;
            tempValue += main.battleCtrl.ally.AddStats(Stats.GoldGain);
            tempValue *= main.battleCtrl.ally.MulStats(Stats.GoldGain);
            main.statusCtrl.ChangeCurrentResource(Resource.Gold, tempValue);
            main.areaCtrl.resultGold += tempValue;
        }
        public void GainExp(double value)
        {
            double tempValue = value;
            tempValue += main.battleCtrl.ally.AddStats(Stats.ExpGain);
            tempValue *= main.battleCtrl.ally.MulStats(Stats.ExpGain);
            main.battleCtrl.ally.ChangeCurrentStats(Stats.ExpGain, tempValue);
            main.areaCtrl.resultExp += tempValue;
        }
        public void GainMaterial(EnemySpecies species, EnemyColor color)
        {
            main.battleCtrl.dropCtrl.DropLottery(species, color);
        }
        public Sprite Sprites(EnemySpecies species, EnemyColor color, bool isZero)
        {
            int id = Convert.ToInt32(isZero);
            switch (species)
            {
                case EnemySpecies.Slime:
                    return slimeSprite[id + 2 * (int)color];
                case EnemySpecies.Bat:
                    return batSprite[id + 2 * (int)color];
                case EnemySpecies.Spider:
                    return spiderSprite[id + 2 * (int)color];
                case EnemySpecies.Fairy:
                    return fairySprite[id + 2 * (int)color];
                case EnemySpecies.Fox:
                    return foxSprite[id + 2 * (int)color];
                case EnemySpecies.MagicSlime:
                    return mslimeSprite[id + 2 * (int)color];
                case EnemySpecies.DevifFish:
                    return fishSprite[id + 2 * (int)color];
                default:
                    return slimeSprite[id + 2 * (int)color];
            }
        }
        private void Awake()
        {
            thisRect = gameObject.GetComponent<RectTransform>();
        }
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }
    }

}
