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
//    public class UPGRADE : DOWNINFO
//    {
//        [NonSerialized] public UpgradeKind kind;
//        [NonSerialized] public int tier;
//        [NonSerialized] public bool isShow;
//        public virtual long level { get; set; }
//        long tempLevel;
//        [SerializeField] TextMeshProUGUI infoText, costText;
//        [SerializeField] Button levelupButton;
//        public virtual string InfoString()
//        {
//            return "";
//        }
//        public virtual string CostString()
//        {
//            return "";
//        }
//        public virtual double Cost(Resource resource, long level)
//        {
//            double tempValue = 0;
//            switch (resource)
//            {
//                case Resource.Gold:
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
//        public double CurrentCost(Resource resource, bool isOneBuy = false)
//        {
//            if (isOneBuy) return Cost(resource, level);
//            double tempCost = 0;
//            for (int i = 0; i < main.BuyModeNum(); i++)
//            {
//                tempCost += Cost(resource, level + i);
//            }
//            return tempCost;
//        }
//        public bool CanBuy()
//        {
//            return main.statusCtrl.IsEnoughCost(Resource.Gold, CurrentCost(Resource.Gold))
//                && main.statusCtrl.IsEnoughCost(Resource.SlimeCoin, CurrentCost(Resource.SlimeCoin))
//                && main.statusCtrl.IsEnoughCost(Resource.Stone, CurrentCost(Resource.Stone))
//                && main.statusCtrl.IsEnoughCost(Resource.Crystal, CurrentCost(Resource.Crystal))
//                && main.statusCtrl.IsEnoughCost(Resource.Leaf, CurrentCost(Resource.Leaf));
//        }
//        public void Buy()
//        {
//            if (CanBuy())
//            {
//                main.statusCtrl.ChangeCurrentResource(Resource.Gold, -CurrentCost(Resource.Gold));
//                main.statusCtrl.ChangeCurrentResource(Resource.SlimeCoin, -CurrentCost(Resource.SlimeCoin));
//                main.statusCtrl.ChangeCurrentResource(Resource.Stone, -CurrentCost(Resource.Stone));
//                main.statusCtrl.ChangeCurrentResource(Resource.Crystal, -CurrentCost(Resource.Crystal));
//                main.statusCtrl.ChangeCurrentResource(Resource.Leaf, -CurrentCost(Resource.Leaf));
//                LevelUp(main.BuyModeNum());
//            }
//        }
//        public long Level()
//        {
//            return level;
//        }
//        public long TempLevel()
//        {
//            return level + main.BuyModeNum();
//        }
//        void LevelUp(long value)
//        {
//            level += value;
//        }

//        public virtual void SetIcon()
//        {
//            iconImage.sprite = null;
//        }
//        protected override void Awake()
//        {
//            base.Awake();
//            infoSize = new Vector2(1000f, 400f);
//            UpdateUI();
//        }
//        // Start is called before the first frame update
//        protected virtual void Start()
//        {
//            levelupButton.onClick.AddListener(Buy);
//            SetIcon();
//        }
//        public virtual void CheckIsShow()
//        {
//            isShow = main.menuCtrl.currentMenu == Menu.Upgrade;
//        }
//        // Update is called once per frame
//        protected virtual void Update()
//        {
//            if (isShow) UpdateUI();
//        }
//        void UpdateUI()
//        {
//            infoText.text = InfoString();
//            costText.text = CostString();
//            levelupButton.interactable = CanBuy();
//        }
//    }
//}
