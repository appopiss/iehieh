//using System.Collections;
//using System.Collections.Generic;
//using System;
//using UnityEngine;
//using UnityEngine.UI;
//using static Another.Main;
//using static UsefulMethod;
//using Cysharp.Threading.Tasks;
//using TMPro;
//using static Another.LocalizedText;
//using System.Linq;
//using static Another.Stats;
//using static Calculation;
//using static Another.Material;

//public partial class Save
//{
//    public bool[] AIsEquippedEq;
//    public long[] AEquipmentLevels;
//    public long[] AEquipmentRanks;
//}
//namespace Another
//{
//    public class EQUIPMENT : DOWNINFO
//    {
//        void SetValue()
//        {
//            switch (equipment)
//            {
//                case Equipment.DullHeroSword:
//                    maxLevel = () => 10 * (1 + Rank());
//                    effects.Add(new Effect(Mp, Add, () => (1 + 0.05 * Rank()) * Level(), () => 5 * Rank()));
//                    effects.Add(new Effect(Atk, Add, () => (2 + 0.1 * Rank()) * Level(), () => 10 * Rank()));
//                    levelReqMats.Add(MonsterFluid, () => 10 + 5 * Rank());
//                    levelReqMats.Add(OozeStainedCloth, () => 5 + Rank());
//                    rankReqMats.Add(RelicStone, () => 2 + Rank());
//                    rankReqMats.Add(OozeStainedCloth, () => 10 + 10 * Rank());
//                    break;
//                case Equipment.BrittleHeroStaff:
//                    maxLevel = () => 10 * (1 + Rank());
//                    effects.Add(new Effect(Mp, Add, () => (1 + 0.05 * Rank()) * Level(), () => 5 * Rank()));
//                    effects.Add(new Effect(MAtk, Add, () => (2 + 0.1 * Rank()) * Level(), () => 10 * Rank()));
//                    levelReqMats.Add(MonsterFluid, () => 10 + 5 * Rank());
//                    levelReqMats.Add(OozeStainedCloth, () => 5 + Rank());
//                    rankReqMats.Add(RelicStone, () => 2 + Rank());
//                    rankReqMats.Add(OozeStainedCloth, () => 10 + 10 * Rank());
//                    break;
//                case Equipment.FlimsyHeroWing:
//                    maxLevel = () => 10 * (1 + Rank());
//                    effects.Add(new Effect(Mp, Add, () => (1 + 0.05 * Rank()) * Level(), () => 5 * Rank()));
//                    effects.Add(new Effect(Atk, Add, () => (1 + 0.05 * Rank()) * Level(), () => 5 * Rank()));
//                    effects.Add(new Effect(MAtk, Add, () => (1 + 0.05 * Rank()) * Level(), () => 5 * Rank()));
//                    levelReqMats.Add(MonsterFluid, () => 10 + 5 * Rank());
//                    levelReqMats.Add(OozeStainedCloth, () => 5 + Rank());
//                    rankReqMats.Add(RelicStone, () => 2 + Rank());
//                    rankReqMats.Add(OozeStainedCloth, () => 10 + 10 * Rank());
//                    break;
//                case Equipment.OldHeroCloak:
//                    maxLevel = () => 10 * (1 + Rank());
//                    effects.Add(new Effect(Hp, Mul, () => (0.002 + 0.0001 * Rank()) * Level(), () => 0.02 * Rank()));
//                    effects.Add(new Effect(Def, Add, () => (1 + 0.05 * Rank()) * Level(), () => 5 * Rank()));
//                    levelReqMats.Add(MonsterFluid, () => 5 + 5 * Rank());
//                    rankReqMats.Add(RelicStone, () => 5 + 5 * Rank());
//                    break;
//                case Equipment.SlimeSword:
//                    maxLevel = () => 10 * (1 + Rank());
//                    effects.Add(new Effect(Hp, Add, () => (10 + 1 * Rank()) * Level(), () => 20 * Rank()));
//                    effects.Add(new Effect(Atk, Mul, () => (0.001 + 0.0005 * Rank()) * Level(), () => 0.01 * Rank()));
//                    levelReqMats.Add(OozeStainedCloth, () => 10 + 5 * Rank());
//                    levelReqMats.Add(OilOfSlime, () => 2 + 2 * Rank());
//                    rankReqMats.Add(RelicStone, () => 10 + 10 * Rank());
//                    rankReqMats.Add(OilOfSlime, () => 5 + 5 * Rank());
//                    break;
//                case Equipment.SlimeRing:
//                    maxLevel = () => 10 * (1 + Rank());
//                    effects.Add(new Effect(StoneGain, Mul, () => (0.20 + 0.1 * Rank()) * Level(), () => 1 * Rank()));
//                    effects.Add(new Effect(CrystalGain, Mul, () => (0.20 + 0.1 * Rank()) * Level(), () => 1 * Rank()));
//                    effects.Add(new Effect(LeafGain, Mul, () => (0.20 + 0.1 * Rank()) * Level(), () => 1 * Rank()));
//                    levelReqMats.Add(MonsterFluid, () => 20 + 5 * Rank());
//                    levelReqMats.Add(OilOfSlime, () => 10 + 2 * Rank());
//                    rankReqMats.Add(RelicStone, () => 20 + 20 * Rank());
//                    rankReqMats.Add(OilOfSlime, () => 20 + 20 * Rank());
//                    break;
//                case Equipment.SlimeHat:
//                    maxLevel = () => 10 * (1 + Rank());
//                    effects.Add(new Effect(MDef, Add, () => (1 + 0.25 * Rank()) * Level(), () => 10 * Rank()));
//                    effects.Add(new Effect(ExpGain, Mul, () => (0.005 + 0.001 * Rank()) * Level(), () => 0.05 * Rank()));
//                    levelReqMats.Add(RelicStone, () => 10 + 5 * Rank());
//                    levelReqMats.Add(OilOfSlime, () => 4 + 2 * Rank());
//                    rankReqMats.Add(RelicStone, () => 20 + 10 * Rank());
//                    rankReqMats.Add(OilOfSlime, () => 8 + 4 * Rank());
//                    break;
//                case Equipment.BatCloak:
//                    break;
//                case Equipment.BatShoes:
//                    break;
//                case Equipment.HerbloreGuide:
//                    break;
//                case Equipment.StoneHeroSword:
//                    break;
//                case Equipment.CrystalHeroStaff:
//                    break;
//                case Equipment.LeafHeroWing:
//                    break;
//                case Equipment.StoneHeroCloak:
//                    break;
//                case Equipment.SlimeStick:
//                    break;
//                case Equipment.AmberRing:
//                    break;
//                case Equipment.AzurePendant:
//                    break;
//                case Equipment.BindingSilk:
//                    break;
//                case Equipment.FairyBoots:
//                    break;
//                case Equipment.VenomSword:
//                    break;
//                case Equipment.CrystalHeroSword:
//                    break;
//                case Equipment.LeafHeroStaff:
//                    break;
//                case Equipment.StoneHeroWing:
//                    break;
//                case Equipment.CrystalHeroCloak:
//                    break;
//                case Equipment.MagicalFairyWing:
//                    break;
//                case Equipment.FoxHat:
//                    break;
//                case Equipment.FoxCoat:
//                    break;
//                case Equipment.FoxBoots:
//                    break;
//                case Equipment.GolemShield:
//                    break;
//                case Equipment.HealingStaff:
//                    break;
//                case Equipment.LeafHeroSword:
//                    break;
//                case Equipment.StoneHeroStaff:
//                    break;
//                case Equipment.CrystalHeroWing:
//                    break;
//                case Equipment.LeafHeroCloak:
//                    break;
//                case Equipment.GolemCrest:
//                    break;
//                case Equipment.ScaleArmor:
//                    break;
//                case Equipment.ArtificialGill:
//                    break;
//                case Equipment.ScaleRing:
//                    break;
//                case Equipment.GoldenAmulet:
//                    break;
//                case Equipment.BananaCutter:
//                    break;
//                case Equipment.LegendWarrior:
//                    break;
//                case Equipment.LegendWizard:
//                    break;
//                case Equipment.LegendAngel:
//                    break;
//                case Equipment.LegendWarriorRein:
//                    break;
//                case Equipment.LegendWizardRein:
//                    break;
//                case Equipment.LegendAngelRein:
//                    break;
//            }
//        }

//        public Equipment equipment;
//        [NonSerialized] public Grade grade;
//        private Func<long> maxLevel = () => 0;
//        private List<Effect> effects = new List<Effect>();
//        private Dictionary<Material, Func<double>> levelReqMats = new Dictionary<Material, Func<double>>();
//        private Dictionary<Material, Func<double>> rankReqMats = new Dictionary<Material, Func<double>>();
//        [SerializeField] TextMeshProUGUI infoText, effectText, passiveEffectText, levelReqMatText, levelReqMatNumText, rankReqMatText, rankReqMatNumText, levelCostText, rankCostText;
//        [SerializeField] Button levelupButton, rankupButton;
//        long level { get => main.S.AEquipmentLevels[(int)equipment]; set => main.S.AEquipmentLevels[(int)equipment] = value; }
//        long rank { get => main.S.AEquipmentRanks[(int)equipment]; set => main.S.AEquipmentRanks[(int)equipment] = value; }

//        public void RankUp()
//        {
//            if (CanRankup())
//            {
//                foreach (var item in rankReqMats)
//                {
//                    main.battleCtrl.dropCtrl.ChangeCurrentMaterial(item.Key, -CurrentCostMaterialNum(item.Value()));
//                }
//                RankUp(main.BuyModeNum());
//            }
//            UpdateEffect();
//        }
//        public void LevelUp()
//        {
//            if (CanLevelup())
//            {
//                foreach (var item in levelReqMats)
//                {
//                    main.battleCtrl.dropCtrl.ChangeCurrentMaterial(item.Key, -CurrentCostMaterialNum(item.Value()));
//                }
//                LevelUp(main.BuyModeNum());
//            }
//            UpdateEffect();
//        }
//        public void RankUp(long value)
//        {
//            rank += value;
//        }
//        public void LevelUp(long value)
//        {
//            level += value;
//        }
//        bool CanLevelup()
//        {
//            return !IsMaxedLevel() && IsEnoughCostLevel();
//        }
//        bool CanRankup()
//        {
//            return IsMaxedLevel() && IsEnoughCostRank();
//        }
//        bool IsMaxedLevel()
//        {
//            return Level() >= maxLevel();
//        }
//        bool IsEnoughCostLevel()
//        {
//            foreach (var item in levelReqMats)
//            {
//                if (!main.craftCtrl.IsEnoughCost(item.Key, CurrentCostMaterialNum(item.Value())))
//                    return false;
//            }
//            return true;
//        }
//        bool IsEnoughCostRank()
//        {
//            foreach (var item in rankReqMats)
//            {
//                if (!main.craftCtrl.IsEnoughCost(item.Key, CurrentCostMaterialNum(item.Value())))
//                    return false;
//            }
//            return true;
//        }
//        public long Level()
//        {
//            return Math.Min(level, maxLevel());
//        }
//        public long Rank()
//        {
//            return rank;
//        }
//        public long ShowRank()
//        {
//            return 1 + Rank();
//        }
//        public bool isEquipped { get => main.S.AIsEquippedEq[(int)equipment]; set => main.S.AIsEquippedEq[(int)equipment] = value; }
//        [NonSerialized] public double[] statsAddFactors = new double[Enum.GetNames(typeof(Stats)).Length];
//        [NonSerialized] public double[] statsMulFactors = new double[Enum.GetNames(typeof(Stats)).Length];
//        [SerializeField] private GameObject equippedFrameObject;
//        private double[] tempStatsAddFactors = new double[Enum.GetNames(typeof(Stats)).Length];
//        private double[] tempStatsMulFactors = new double[Enum.GetNames(typeof(Stats)).Length];
//        public void UpdateEffect()
//        {
//            for (int i = 0; i < tempStatsAddFactors.Length; i++)
//            {
//                tempStatsAddFactors[i] = 0;
//            }
//            for (int i = 0; i < tempStatsMulFactors.Length; i++)
//            {
//                tempStatsMulFactors[i] = 0;
//            }
//            for (int i = 0; i < effects.Count(); i++)
//            {
//                switch (effects[i].cul)
//                {
//                    case Add:
//                        tempStatsAddFactors[(int)effects[i].stats] += effects[i].passiveValue();
//                        if (isEquipped) tempStatsAddFactors[(int)effects[i].stats] += effects[i].value();
//                        break;
//                    case Mul:
//                        tempStatsMulFactors[(int)effects[i].stats] += effects[i].passiveValue();
//                        if (isEquipped) tempStatsMulFactors[(int)effects[i].stats] += effects[i].value();
//                        break;
//                }
//            }
//            for (int i = 0; i < statsAddFactors.Length; i++)
//            {
//                statsAddFactors[i] = tempStatsAddFactors[i];
//            }
//            for (int i = 0; i < statsMulFactors.Length; i++)
//            {
//                statsMulFactors[i] = tempStatsMulFactors[i];
//            }
//        }
//        bool CanEquip()
//        {
//            return Level() > 0 && main.craftCtrl.CanEquipEq();
//        }
//        public void Equip()
//        {
//            if (isEquipped)
//                isEquipped = false;
//            else if (CanEquip())
//                isEquipped = true;
//            UpdateEffect();
//        }
//        double CurrentCostMaterialNum(double value, bool isOneBuy = false)
//        {
//            if (isOneBuy) return value;
//            return value * main.BuyModeNum();
//        }
//        protected override void Awake()
//        {
//            base.Awake();
//            infoSize = new Vector2(1000f, 530f);
//            SetValue();
//        }
//        // Start is called before the first frame update
//        void Start()
//        {
//            iconImage.sprite = main.craftCtrl.equipmentSprites[(int)equipment];
//            iconButton.onClick.AddListener(Equip);
//            levelupButton.onClick.AddListener(LevelUp);
//            rankupButton.onClick.AddListener(RankUp);
//            UpdateEffect();
//        }
//        // Update is called once per frame
//        void Update()
//        {
//            UpdateUI();
//        }
//        void UpdateUI()
//        {
//            infoText.text = InfoString();
//            levelCostText.text = localized.Basic(BasicWord.LevelUp);
//            rankCostText.text = localized.Basic(BasicWord.RankUp);
//            levelReqMatText.text = LevelReqMatString();
//            levelReqMatNumText.text = LevelReqMatNumString();
//            rankReqMatText.text = RankReqMatString();
//            rankReqMatNumText.text = RankReqMatNumString();
//            effectText.text = EffectString();
//            passiveEffectText.text = PassiveEffectString();
//            levelupButton.interactable = CanLevelup();
//            rankupButton.interactable = CanRankup();
//            iconButton.interactable = CanEquip();
//            if (isEquipped) setActive(equippedFrameObject);
//            else setFalse(equippedFrameObject);
//        }
//        public string InfoString()
//        {
//            string tempString = optStr + "<size=30>" + localized.Equipment(equipment) + "  < <color=green>Rank " + tDigit(ShowRank()) + "</color> >\n"
//                + "<color=green>Lv " + tDigit(Level()) + "</color> / " + tDigit(maxLevel()) + "\n<size=24>";
//            for (int i = 0; i < effects.Count(); i++)
//            {
//                if (effects[i].isStatEffect) tempString += optStr + effects[i].EffectString(true) + "  ";
//            }
//            return tempString;
//        }
//        public string EffectString()
//        {
//            string tempString = optStr + "<size=26><u>" + localized.Basic(BasicWord.Effect) + "</u><size=8>\n";
//            for (int i = 0; i < effects.Count(); i++)
//            {
//                tempString += optStr + "\n</size><size=26>- " + effects[i].EffectString();
//            }
//            return tempString;
//        }
//        public string PassiveEffectString()
//        {
//            string tempString = optStr + "<size=26><u>" + localized.Basic(BasicWord.PassiveEffect) + "</u><size=8>\n";
//            for (int i = 0; i < effects.Count(); i++)
//            {
//                tempString += optStr + "\n</size><size=26>- " + effects[i].PassiveEffectString();
//            }
//            return tempString;
//        }
//        public string LevelReqMatString()
//        {
//            string tempString = optStr + "<size=26><u>" + localized.Basic(BasicWord.MaterialsToLevelUp) + "</u><size=8>\n";
//            foreach (var item in levelReqMats)
//            {
//                tempString += optStr + "\n</size><size=26>- " + localized.Material(item.Key);
//            }
//            return tempString;
//        }
//        public string LevelReqMatNumString()
//        {
//            string tempString = optStr + "<size=26>     <size=8>\n";
//            foreach (var item in levelReqMats)
//            {
//                tempString += optStr + "\n</size><size=26>";
//                if (main.S.AMaterials[(int)item.Key] >= CurrentCostMaterialNum(item.Value())) tempString += "<color=green>";
//                else tempString += "<color=red>";
//                tempString += tDigit(main.S.AMaterials[(int)item.Key]) + "</color> / " + tDigit(CurrentCostMaterialNum(item.Value()));
//            }
//            return tempString;
//        }
//        public string RankReqMatString()
//        {
//            string tempString = optStr + "<size=26><u>" + localized.Basic(BasicWord.MaterialsToRankUp) + "</u><size=8>\n";
//            foreach (var item in rankReqMats)
//            {
//                tempString += optStr + "\n</size><size=26>- " + localized.Material(item.Key);
//            }
//            return tempString;
//        }
//        public string RankReqMatNumString()
//        {
//            string tempString = optStr + "<size=26>     <size=8>\n";
//            foreach (var item in rankReqMats)
//            {
//                tempString += optStr + "\n</size><size=26>";
//                if (main.S.AMaterials[(int)item.Key] >= CurrentCostMaterialNum(item.Value())) tempString += "<color=green>";
//                else tempString += "<color=red>";
//                tempString += tDigit(main.S.AMaterials[(int)item.Key]) + "</color> / " + tDigit(CurrentCostMaterialNum(item.Value()));
//            }
//            return tempString;
//        }
//    }
//    public class Effect
//    {
//        public bool isStatEffect;
//        public Stats stats;
//        public Calculation cul;
//        public Func<double> value;
//        public Func<double> passiveValue;
//        public string effectString, passiveEffectString;

//        public Effect(Stats stats, Calculation cul, Func<double> value, Func<double> passiveValue = null)
//        {
//            this.stats = stats;
//            this.cul = cul;
//            this.value = value;
//            this.passiveValue = passiveValue;
//            isStatEffect = true;
//        }
//        public Effect(string effectString, string passiveEffectString = null)
//        {
//            this.effectString = effectString;
//            this.passiveEffectString = passiveEffectString;
//        }
//        public string EffectString(bool isShort = false)
//        {
//            string tempString = optStr;
//            if (isStatEffect)
//            {
//                switch (cul)
//                {
//                    case Add:
//                        tempString += optStr + localized.Stat(stats, isShort) + " + " + tDigit(value(), 2);
//                        break;
//                    case Mul:
//                        tempString += optStr + localized.Stat(stats, isShort) + " + " + percent(value());
//                        break;
//                }
//            }
//            else
//                tempString += effectString;
//            return tempString;
//        }
//        public string PassiveEffectString()
//        {
//            string tempString = optStr;
//            if (isStatEffect)
//            {
//                switch (cul)
//                {
//                    case Add:
//                        tempString += optStr + localized.Stat(stats) + " + " + tDigit(passiveValue(), 2);
//                        break;
//                    case Mul:
//                        tempString += optStr + localized.Stat(stats) + " + " + percent(passiveValue());
//                        break;
//                }
//            }
//            else
//                tempString += passiveEffectString;
//            return tempString;
//        }

//        //線形Effect
//        private double initValue, incrementValue;
//        private Func<double> level = () => 0;
//        public Effect(Stats stats, Calculation cul, double initValue, double incrementValue, Func<double> level)
//        {
//            this.stats = stats;
//            this.cul = cul;
//            this.initValue = initValue;
//            this.incrementValue = incrementValue;
//            this.level = level;
//        }
//        public double Value(long level)
//        {
//            return initValue + level * incrementValue;
//        }
//        public double Value()
//        {
//            return initValue + level() * incrementValue;
//        }
//        public string EffectString(long level, bool isShort = false)
//        {
//            string tempString = optStr;
//            switch (cul)
//            {
//                case Add:
//                    tempString += optStr + localized.Stat(stats, isShort) + " + " + tDigit(Value(level), 2);
//                    break;
//                case Mul:
//                    tempString += optStr + localized.Stat(stats, isShort) + " + " + percent(Value(level));
//                    break;
//            }
//            return tempString;
//        }

//    }

//}
