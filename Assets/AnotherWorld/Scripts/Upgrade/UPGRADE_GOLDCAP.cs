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
//using static Another.Resource;
//using Another;

//partial class Save
//{
//    public long[] AUpgradeLevelsGoldCap;
//}
//namespace Another
//{
//    public class UPGRADE_GOLDCAP : UPGRADE
//    {
//        void SetInfo()
//        {
//            switch (tier)
//            {
//                case 0:
//                    resource = Stone;
//                    break;
//                case 1:
//                    resource = Crystal;
//                    break;
//                case 2:
//                    resource = Leaf;
//                    break;
//            }
//        }
//        private Resource resource;
//        public override long level { get => main.S.AUpgradeLevelsGoldCap[(int)resource]; set => main.S.AUpgradeLevelsGoldCap[(int)resource] = value; }

//        public override string InfoString()
//        {
//            return optStr + "<size=30>" + localized.UpgradeName(UpgradeKind.GoldCap, resource)
//                + "   < <color=green>Lv " + Level().ToString() + "</color> ></size><size=26>\n\n"
//                + localized.Basic(BasicWord.Current) + " : " + localized.Stat(Stats.GoldCap) + " + " + main.upgradeCtrl.ResourceGoldCapFactors(resource)
//                + "\n" + localized.Basic(BasicWord.Next) + " : " + localized.Stat(Stats.GoldCap) + " + " + main.upgradeCtrl.ResourceGoldCapFactors(resource, true) + " ( <color=green>Lv " + TempLevel().ToString() + "</color> )";
//        }
//        public override string CostString()
//        {
//            return optStr + "<sprite=\"resource\" index=" + (int)resource + "> " + tDigit(CurrentCost(resource))
//                + "\n" + localized.Basic(BasicWord.LevelUp) + " + " + tDigit(main.BuyModeNum());
//        }
//        public override double Cost(Resource resource, long level)
//        {
//            double tempValue = 0;
//            if (resource == this.resource) tempValue = 100 * Math.Pow(2, level);
//            return tempValue;
//        }
//        public override void SetIcon()
//        {
//            iconImage.sprite = main.upgradeCtrl.goldcapUpgradeSprites[tier];
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

