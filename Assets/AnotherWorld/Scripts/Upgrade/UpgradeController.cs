//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using TMPro;
//using System;
//using static Another.Main;
//using static UsefulMethod;
//using Cysharp.Threading.Tasks;
//using static Another.LocalizedText;
//using Another;

//namespace Another
//{
//    public enum UpgradeKind
//    {
//        Resource,
//        Stats,
//        GoldCap,
//    }
//    public class UpgradeController : MonoBehaviour
//    {
//        [NonSerialized] public static readonly int resourceUpgradeTierNum = 10;
//        public UPGRADE_RESOURCE[] stoneUpgrades, crystalUpgrades, leafUpgrades;
//        public UPGRADE_STATS[] statsUpgrades;
//        public UPGRADE_GOLDCAP[] goldcapUpgrades;
//        [NonSerialized] public UPGRADE[] upgrades;
//        public Sprite[] stoneUpgradeSprites, crystalUpgradeSprites, leafUpgradeSprites;
//        public Sprite[] statsUpgradeSprites, goldcapUpgradeSprites;
//        public SwitchTab switchTab;

//        //Resource
//        public double ProductResourcePerSec(Resource resourceKind, bool isTemp = false, int tempTier = 0)
//        {
//            long[] levels = new long[resourceUpgradeTierNum];
//            double tempValue = 0;
//            for (int i = 0; i < levels.Length; i++)
//            {
//                switch (resourceKind)
//                {
//                    case Resource.Stone:
//                        levels[i] = main.S.AUpgradeLevelsResourceStone[i];
//                        break;
//                    case Resource.Crystal:
//                        levels[i] = main.S.AUpgradeLevelsResourceCrystal[i];
//                        break;
//                    case Resource.Leaf:
//                        levels[i] = main.S.AUpgradeLevelsResourceLeaf[i];
//                        break;
//                }
//                if (isTemp && i == tempTier)
//                    levels[i] += main.BuyModeNum();
//                tempValue += levels[i];
//            }
//            for (int i = 1; i < levels.Length; i++)
//            {
//                double tempTempSumValue = 0;
//                for (int j = i; j < levels.Length; j++)
//                {
//                    tempTempSumValue += levels[j];
//                }
//                tempValue *= 1 + tempTempSumValue;
//            }
//            switch (resourceKind)
//            {
//                case Resource.Stone:
//                    tempValue *= main.battleCtrl.ally.TotalStats(Stats.StoneGain);
//                    break;
//                case Resource.Crystal:
//                    tempValue *= main.battleCtrl.ally.TotalStats(Stats.CrystalGain);
//                    break;
//                case Resource.Leaf:
//                    tempValue *= main.battleCtrl.ally.TotalStats(Stats.LeafGain);
//                    break;
//            }
//            return tempValue;//([0]+[1]+...+[9])*(1+[1]+...+[9])*(1+[2]+...+[9])*...*(1+[9])
//        }
//        static int smoothnessPerSec = 10;
//        async void GainProductResource()
//        {
//            while (true)
//            {
//                await UniTask.Delay(1000 / smoothnessPerSec);
//                main.statusCtrl.ChangeCurrentResource(Resource.Stone, ProductResourcePerSec(Resource.Stone) / smoothnessPerSec);
//                main.statusCtrl.ChangeCurrentResource(Resource.Crystal, ProductResourcePerSec(Resource.Crystal) / smoothnessPerSec);
//                main.statusCtrl.ChangeCurrentResource(Resource.Leaf, ProductResourcePerSec(Resource.Leaf) / smoothnessPerSec);
//            }
//        }
//        //GoldCap
//        public double ResourceGoldCapFactors(Resource resource, bool isTemp = false)
//        {
//            double tempValue = 0;
//            long tempLevel = main.S.AUpgradeLevelsGoldCap[(int)resource];
//            if (isTemp) tempLevel += main.BuyModeNum();
//            tempValue = tempLevel;
//            return tempValue;
//        }
//        //Stats
//        public double TotalStatsAddFactors(Stats stats, bool isTemp = false)
//        {
//            double tempValue = 0;
//            long tempLevel = main.S.AUpgradeLevelsStats[(int)stats];
//            if (isTemp) tempLevel += main.BuyModeNum();
//            switch (stats)
//            {
//                case Stats.Hp:
//                    tempValue += 50 * tempLevel;
//                    break;
//                case Stats.Mp:
//                    tempValue += 10 * tempLevel;
//                    break;
//                case Stats.Atk:
//                    tempValue += 1 * tempLevel;
//                    break;
//                case Stats.MAtk:
//                    tempValue += 1 * tempLevel;
//                    break;
//                case Stats.Def:
//                    tempValue += 1 * tempLevel;
//                    break;
//                case Stats.MDef:
//                    tempValue += 1 * tempLevel;
//                    break;
//                case Stats.GoldGain:
//                    tempValue += 1 * tempLevel;
//                    break;
//                case Stats.ExpGain:
//                    tempValue += 5 * tempLevel;
//                    break;
//                case Stats.GoldCap:
//                    tempValue += ResourceGoldCapFactors(Resource.Stone);
//                    tempValue += ResourceGoldCapFactors(Resource.Crystal);
//                    tempValue += ResourceGoldCapFactors(Resource.Leaf);
//                    break;
//                case Stats.SlimeCoinCap:
//                    break;
//                default:
//                    break;
//            }
//            return tempValue;
//        }
//        private void Awake()
//        {
//            for (int i = 0; i < stoneUpgrades.Length; i++)
//            {
//                stoneUpgrades[i].kind = UpgradeKind.Resource;
//                stoneUpgrades[i].resourceKind = Resource.Stone;
//                stoneUpgrades[i].tier = i;
//            }
//            for (int i = 0; i < crystalUpgrades.Length; i++)
//            {
//                crystalUpgrades[i].kind = UpgradeKind.Resource;
//                crystalUpgrades[i].resourceKind = Resource.Crystal;
//                crystalUpgrades[i].tier = i;
//            }
//            for (int i = 0; i < leafUpgrades.Length; i++)
//            {
//                leafUpgrades[i].kind = UpgradeKind.Resource;
//                leafUpgrades[i].resourceKind = Resource.Leaf;
//                leafUpgrades[i].tier = i;
//            }
//            for (int i = 0; i < statsUpgrades.Length; i++)
//            {
//                statsUpgrades[i].kind = UpgradeKind.Stats;
//                statsUpgrades[i].tier = i;
//            }
//            for (int i = 0; i < goldcapUpgrades.Length; i++)
//            {
//                goldcapUpgrades[i].kind = UpgradeKind.GoldCap;
//                goldcapUpgrades[i].tier = i;
//            }

//            List<UPGRADE> tempUpgrades = new List<UPGRADE>(stoneUpgrades.Length + crystalUpgrades.Length + leafUpgrades.Length + statsUpgrades.Length);
//            tempUpgrades.AddRange(stoneUpgrades);
//            tempUpgrades.AddRange(crystalUpgrades);
//            tempUpgrades.AddRange(leafUpgrades);
//            tempUpgrades.AddRange(statsUpgrades);
//            tempUpgrades.AddRange(goldcapUpgrades);
//            upgrades = tempUpgrades.ToArray();

//            main.menuCtrl.action += () => CheckIsShowAll();
//            switchTab.action += () => CheckIsShowAll();
//        }
//        // Start is called before the first frame update
//        void Start()
//        {
//            GainProductResource();
//        }
//        public void CheckIsShowAll()
//        {
//            for (int i = 0; i < upgrades.Length; i++)
//            {
//                upgrades[i].CheckIsShow();
//            }
//        }
//        // Update is called once per frame
//        void Update()
//        {

//        }
//    }
//}
