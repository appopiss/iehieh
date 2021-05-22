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
//using static Another.Stats;

//partial class Save
//{
//    public long[] AUpgradeLevelsStats;
//}
//namespace Another
//{
//    public class UPGRADE_STATS : UPGRADE
//    {
//        void SetInfo()
//        {
//            switch (tier)
//            {
//                case 0:
//                    stats = GoldGain;
//                    break;
//                case 1:
//                    stats = ExpGain;
//                    break;
//                case 2:
//                    stats = Hp;
//                    break;
//                case 3:
//                    stats = Mp;
//                    break;
//                case 4:
//                    stats = Atk;
//                    break;
//                case 5:
//                    stats = MAtk;
//                    break;
//                case 6:
//                    stats = Def;
//                    break;
//                case 7:
//                    stats = MDef;
//                    break;
//            }
//        }
//        private Stats stats;
//        public override long level { get => main.S.AUpgradeLevelsStats[(int)stats]; set => main.S.AUpgradeLevelsStats[(int)stats] = value; }

//        public override string InfoString()
//        {
//            return optStr + "<size=30>" + localized.Stat(stats) + " " + localized.Basic(BasicWord.Bonus)
//                + "   < <color=green>Lv " + Level().ToString() + "</color> ></size><size=26>\n\n"
//                + localized.Basic(BasicWord.Current) + " : " + localized.Stat(stats) + " + " + main.upgradeCtrl.TotalStatsAddFactors(stats)
//                + "\n" + localized.Basic(BasicWord.Next) + " : " + localized.Stat(stats) + " + " + main.upgradeCtrl.TotalStatsAddFactors(stats, true) + " ( <color=green>Lv " + TempLevel().ToString() + "</color> )";
//        }
//        public override string CostString()
//        {
//            return optStr + "<sprite=\"resource\" index=0> " + tDigit(CurrentCost(Resource.Gold))
//                + "\n" + "<sprite=\"resource\" index=2><sprite=\"resource\" index=3><sprite=\"resource\" index=4> " + tDigit(CurrentCost(Resource.Stone));
//        }
//        public override double Cost(Resource resource, long level)
//        {
//            double tempValue = 0;
//            switch (resource)
//            {
//                case Resource.Gold:
//                    tempValue = 1000d;
//                    break;
//                case Resource.SlimeCoin:
//                    break;
//                case Resource.Stone:
//                    tempValue = Math.Pow(10, level);
//                    break;
//                case Resource.Crystal:
//                    tempValue = Math.Pow(10, level);
//                    break;
//                case Resource.Leaf:
//                    tempValue = Math.Pow(10, level);
//                    break;
//            }
//            return tempValue;
//        }
//        public override void SetIcon()
//        {
//            iconImage.sprite = main.upgradeCtrl.statsUpgradeSprites[tier];
//        }
//        protected override void Awake()
//        {
//            base.Awake();
//        }
//        // Start is called before the first frame update
//        protected override void Start()
//        {
//            base.Start();
//            SetInfo();
//        }
//        public override void CheckIsShow()
//        {
//            base.CheckIsShow();
//            isShow = main.upgradeCtrl.switchTab.currentTabId == 3;
//        }
//        // Update is called once per frame
//        protected override void Update()
//        {
//            base.Update();
//        }
//    }
//}
