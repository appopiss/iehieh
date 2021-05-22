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

//partial class Save
//{
//    public long[] AUpgradeLevelsResourceStone;
//    public long[] AUpgradeLevelsResourceCrystal;
//    public long[] AUpgradeLevelsResourceLeaf;
//}
//namespace Another
//{
//    public class UPGRADE_RESOURCE : UPGRADE
//    {
//        [NonSerialized] public Resource resourceKind;
//        public override long level
//        {
//            get
//            {
//                switch (resourceKind)
//                {
//                    case Resource.Stone:
//                        return main.S.AUpgradeLevelsResourceStone[tier];
//                    case Resource.Crystal:
//                        return main.S.AUpgradeLevelsResourceCrystal[tier];
//                    case Resource.Leaf:
//                        return main.S.AUpgradeLevelsResourceLeaf[tier];
//                    default:
//                        return 0;
//                }
//            }
//            set
//            {
//                switch (resourceKind)
//                {
//                    case Resource.Stone:
//                        main.S.AUpgradeLevelsResourceStone[tier] = value;
//                        break;
//                    case Resource.Crystal:
//                        main.S.AUpgradeLevelsResourceCrystal[tier] = value;
//                        break;
//                    case Resource.Leaf:
//                        main.S.AUpgradeLevelsResourceLeaf[tier] = value;
//                        break;
//                }
//            }
//        }

//        public override string InfoString()
//        {
//            return optStr + "<size=30>" + localized.UpgradeName(kind, resourceKind) + " " + (1 + tier).ToString()
//                + "   < <color=green>Lv " + Level().ToString() + "</color> ></size><size=26>\n\n"
//                + localized.Basic(BasicWord.Current) + " : + " + tDigit(main.upgradeCtrl.ProductResourcePerSec(resourceKind)) + " / sec"
//                + "\n" + localized.Basic(BasicWord.Next) + " : + " + tDigit(main.upgradeCtrl.ProductResourcePerSec(resourceKind, true, tier)) + " / sec ( <color=green>Lv " + TempLevel().ToString() + "</color> )";
//        }
//        public override string CostString()
//        {
//            return optStr + "<sprite=\"resource\" index=0> " + tDigit(CurrentCost(Resource.Gold))
//                + "\n" + localized.Basic(BasicWord.LevelUp) + " + " + tDigit(main.BuyModeNum());
//        }
//        public override double Cost(Resource resource, long level)
//        {
//            double tempValue = 0;
//            switch (resource)
//            {
//                case Resource.Gold:
//                    tempValue = 10 * Math.Pow(5, tier) * Math.Pow(1.1d + 0.1d * tier, level);
//                    break;
//                case Resource.SlimeCoin:
//                    break;
//                case Resource.Stone:
//                    break;
//                case Resource.Crystal:
//                    break;
//                case Resource.Leaf:
//                    break;
//            }
//            return tempValue;
//        }
//        public override void SetIcon()
//        {
//            switch (resourceKind)
//            {
//                case Resource.Stone:
//                    iconImage.sprite = main.upgradeCtrl.stoneUpgradeSprites[tier];
//                    break;
//                case Resource.Crystal:
//                    iconImage.sprite = main.upgradeCtrl.crystalUpgradeSprites[tier];
//                    break;
//                case Resource.Leaf:
//                    iconImage.sprite = main.upgradeCtrl.leafUpgradeSprites[tier];
//                    break;
//            }
//        }
//        protected override void Awake()
//        {
//            base.Awake();
//        }
//        // Start is called before the first frame update
//        protected override void Start()
//        {
//            base.Start();
//        }
//        public override void CheckIsShow()
//        {
//            base.CheckIsShow();
//            switch (resourceKind)
//            {
//                case Resource.Stone:
//                    isShow = main.upgradeCtrl.switchTab.currentTabId == 0;
//                    break;
//                case Resource.Crystal:
//                    isShow = main.upgradeCtrl.switchTab.currentTabId == 1;
//                    break;
//                case Resource.Leaf:
//                    isShow = main.upgradeCtrl.switchTab.currentTabId == 2;
//                    break;
//            }
//        }
//        // Update is called once per frame
//        protected override void Update()
//        {
//            base.Update();
//        }
//    }
//}
