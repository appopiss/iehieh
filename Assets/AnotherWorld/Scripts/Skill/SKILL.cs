using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using static Another.Main;
using static UsefulMethod;
using static Another.Skill;
using static Another.Class;
using static Another.SkillType;
using Cysharp.Threading.Tasks;
using static Another.LocalizedText;
using Another;
using System.Linq;

public partial class Save
{
    public bool[] AIsEquippedSkills;
    public long[] ASkillLevel;
    public long[] ASkillRank;
    public double[] ASkillProf;
}

namespace Another
{
    public class SKILL : DOWNINFO
    {
        [NonSerialized] public Skill skill;
        void SetValue()
        {
            switch (skill)
            {
                case SwordAttack:
                    skillClass = Warrior;
                    skillType = Physical;
                    initDmg = 1;
                    incrementDmg = 0.02;
                    initMpGain = 1;
                    incrementMpGain = 1;
                    initInterval = 1;
                    profDifficulty = 0;
                    passiveEffects.Add(new PassiveEffect(10, Stats.Atk, 0.1));
                    passiveEffects.Add(new PassiveEffect(20, Stats.Atk, 0.2));
                    passiveEffects.Add(new PassiveEffect(30, Stats.Atk, 0.3));
                    passiveEffects.Add(new PassiveEffect(40, Stats.Atk, 0.4));
                    passiveEffects.Add(new PassiveEffect(50, Stats.Atk, 0.5));
                    break;
                case Skill.Slash:
                    skillClass = Warrior;
                    skillType = Physical;
                    initDmg = 2;
                    incrementDmg = 0.05;
                    initMpGain = 1;
                    incrementMpGain = 1;
                    initInterval = 1;
                    profDifficulty = 0;
                    passiveEffects.Add(new PassiveEffect(10, Stats.Hp, 0.1));
                    passiveEffects.Add(new PassiveEffect(20, Stats.Hp, 0.2));
                    passiveEffects.Add(new PassiveEffect(30, Stats.Hp, 0.3));
                    passiveEffects.Add(new PassiveEffect(40, Stats.Hp, 0.4));
                    passiveEffects.Add(new PassiveEffect(50, Stats.Hp, 0.5));
                    break;
                case Skill.DoubleSlash:
                    skillClass = Warrior;
                    skillType = Physical;
                    initDmg = 2;
                    incrementDmg = 0.05;
                    initMpGain = 0;
                    incrementMpGain = 2;
                    initMpConsume = 20;
                    incrementMpConsume = 1.5;
                    initInterval = 1;
                    profDifficulty = 1;
                    initHitCount = 2;
                    maxHitCount = 2;
                    passiveEffects.Add(new PassiveEffect(10, Stats.Atk, 0.1));
                    passiveEffects.Add(new PassiveEffect(20, Stats.Atk, 0.2));
                    passiveEffects.Add(new PassiveEffect(30, Stats.Atk, 0.3));
                    passiveEffects.Add(new PassiveEffect(40, Stats.Atk, 0.4));
                    passiveEffects.Add(new PassiveEffect(50, Stats.Atk, 0.5));
                    break;
                case Skill.SonicSlash:
                    skillClass = Warrior;
                    skillType = Physical;
                    initDmg = 2;
                    incrementDmg = 0.05;
                    initMpConsume = 50;
                    incrementMpConsume = 2.5;
                    initInterval = 1;
                    profDifficulty = 2;
                    initHitCount = 3;
                    incrementHitCount = 1 / 25d;
                    maxHitCount = 7;
                    passiveEffects.Add(new PassiveEffect(10, Stats.Atk, 0.1));
                    passiveEffects.Add(new PassiveEffect(20, Stats.Atk, 0.2));
                    passiveEffects.Add(new PassiveEffect(30, Stats.Atk, 0.3));
                    passiveEffects.Add(new PassiveEffect(40, Stats.Atk, 0.4));
                    passiveEffects.Add(new PassiveEffect(50, Stats.Atk, 0.5));
                    break;
                case Skill.SwingDown:
                    skillClass = Warrior;
                    skillType = Physical;
                    initDmg = 10;
                    incrementDmg = 0.1;
                    initMpGain = 10;
                    incrementMpGain = 1;
                    initMpConsume = 50;
                    incrementMpConsume = 5;
                    initInterval = 2;
                    profDifficulty = 2;
                    initDebuffChance = 0.5d;
                    maxDebuffChance = 0.5d;
                    debuff = Debuff.DefDown;
                    passiveEffects.Add(new PassiveEffect(10, Stats.Atk, 0.1));
                    passiveEffects.Add(new PassiveEffect(20, Stats.Atk, 0.2));
                    passiveEffects.Add(new PassiveEffect(30, Stats.Atk, 0.3));
                    passiveEffects.Add(new PassiveEffect(40, Stats.Atk, 0.4));
                    passiveEffects.Add(new PassiveEffect(50, Stats.Atk, 0.5));
                    break;
                case Skill.SwingAround:
                    skillClass = Warrior;
                    skillType = Physical;
                    initDmg = 20;
                    incrementDmg = 0.5;
                    initMpConsume = 80;
                    incrementMpConsume = 5;
                    initInterval = 2;
                    profDifficulty = 3;
                    passiveEffects.Add(new PassiveEffect(10, Stats.Atk, 0.1));
                    passiveEffects.Add(new PassiveEffect(20, Stats.Atk, 0.2));
                    passiveEffects.Add(new PassiveEffect(30, Stats.Atk, 0.3));
                    passiveEffects.Add(new PassiveEffect(40, Stats.Atk, 0.4));
                    passiveEffects.Add(new PassiveEffect(50, Stats.Atk, 0.5));
                    break;
                case Skill.ChargeSwing:
                    skillClass = Warrior;
                    skillType = Physical;
                    initDmg = 50;
                    incrementDmg = 0.75;
                    initMpConsume = 50;
                    incrementMpConsume = 5;
                    initInterval = 3;
                    profDifficulty = 3;
                    initDebuffChance = 0.5d;
                    maxDebuffChance = 0.5d;
                    debuff = Debuff.MatkDown;
                    passiveEffects.Add(new PassiveEffect(10, Stats.Atk, 0.1));
                    passiveEffects.Add(new PassiveEffect(20, Stats.Atk, 0.2));
                    passiveEffects.Add(new PassiveEffect(30, Stats.Atk, 0.3));
                    passiveEffects.Add(new PassiveEffect(40, Stats.Atk, 0.4));
                    passiveEffects.Add(new PassiveEffect(50, Stats.Atk, 0.5));
                    break;
                case Skill.FanSwing:
                    skillClass = Warrior;
                    skillType = Physical;
                    initDmg = 20;
                    incrementDmg = 0.25;
                    initMpConsume = 120;
                    incrementMpConsume = 5;
                    initInterval = 2;
                    profDifficulty = 4;
                    initHitCount = 2;
                    incrementHitCount = 1 / 50d;
                    maxHitCount = 4;
                    passiveEffects.Add(new PassiveEffect(10, Stats.Atk, 0.1));
                    passiveEffects.Add(new PassiveEffect(20, Stats.Atk, 0.2));
                    passiveEffects.Add(new PassiveEffect(30, Stats.Atk, 0.3));
                    passiveEffects.Add(new PassiveEffect(40, Stats.Atk, 0.4));
                    passiveEffects.Add(new PassiveEffect(50, Stats.Atk, 0.5));
                    break;
                case Skill.ShieldAttack:
                    skillClass = Warrior;
                    skillType = Physical;
                    initDmg = 1;
                    incrementDmg = 0.05;
                    initMpGain = 10;
                    incrementMpGain = 5;
                    initInterval = 1;
                    profDifficulty = 0;
                    passiveEffects.Add(new PassiveEffect(10, Stats.Atk, 0.1));
                    passiveEffects.Add(new PassiveEffect(20, Stats.Atk, 0.2));
                    passiveEffects.Add(new PassiveEffect(30, Stats.Atk, 0.3));
                    passiveEffects.Add(new PassiveEffect(40, Stats.Atk, 0.4));
                    passiveEffects.Add(new PassiveEffect(50, Stats.Atk, 0.5));
                    break;
                case KnockingShot:
                    skillClass = Warrior;
                    skillType = Physical;
                    initDmg = 1;
                    incrementDmg = 0.05;
                    initMpGain = 10;
                    incrementMpGain = 5;
                    initInterval = 1;
                    profDifficulty = 1;
                    initDebuffChance = 0.10;
                    maxDebuffChance = 0.10;
                    debuff = Debuff.Knockback;
                    passiveEffects.Add(new PassiveEffect(10, Stats.Atk, 0.1));
                    passiveEffects.Add(new PassiveEffect(20, Stats.Atk, 0.2));
                    passiveEffects.Add(new PassiveEffect(30, Stats.Atk, 0.3));
                    passiveEffects.Add(new PassiveEffect(40, Stats.Atk, 0.4));
                    passiveEffects.Add(new PassiveEffect(50, Stats.Atk, 0.5));
                    break;
                case StaffAttack:
                    skillClass = Wizard;
                    skillType = Physical;

                    initDmg = 1;
                    incrementDmg = 0.05;
                    initMpGain = 10;
                    incrementMpGain = 5;
                    initInterval = 1;
                    profDifficulty = 1;
                    initDebuffChance = 0.10;
                    maxDebuffChance = 0.10;
                    passiveEffects.Add(new PassiveEffect(10, Stats.MAtk, 0.1));
                    passiveEffects.Add(new PassiveEffect(20, Stats.MAtk, 0.2));
                    passiveEffects.Add(new PassiveEffect(30, Stats.MAtk, 0.3));
                    passiveEffects.Add(new PassiveEffect(40, Stats.MAtk, 0.4));
                    passiveEffects.Add(new PassiveEffect(50, Stats.MAtk, 0.5));

                    break;
                case FireBolt:
                    break;
                case Nothing:
                    break;
                default:
                    break;
            }
        }

        [NonSerialized] public Class skillClass;
        private SkillType skillType;
        private Element element;
        private Debuff debuff;
        private List<PassiveEffect> passiveEffects = new List<PassiveEffect>();
        [NonSerialized] public double[] statsPassiveFactors = new double[Enum.GetNames(typeof(Stats)).Length];
        private double initDmg, incrementDmg;
        private double initMpGain, incrementMpGain;
        private double initMpConsume, incrementMpConsume;
        private float initInterval;
        private int profDifficulty;
        private float range = 100;
        private float initEffectRange = 50, incrementEffectRange, maxEffectRange = 50;
        private double initDebuffChance, incrementDebuffChance, maxDebuffChance;
        private long initHitCount = 1, maxHitCount = 1;
        private double incrementHitCount;
        [NonSerialized] public float chargetime;
        [NonSerialized] public bool isShow;
        [SerializeField] TextMeshProUGUI infoText, effectText, passiveText, costText;
        [SerializeField] Slider proficiencyBar;
        [SerializeField] private GameObject equippedFrameObject;
        public bool isEquipped { get => main.S.AIsEquippedSkills[(int)skill]; set => main.S.AIsEquippedSkills[(int)skill] = value; }
        public long rank { get => main.S.ASkillRank[(int)skill]; set => main.S.ASkillRank[(int)skill] = value; }
        public long level { get => main.S.ASkillLevel[(int)skill]; set => main.S.ASkillLevel[(int)skill] = value; }
        public double currentProf { get => main.S.ASkillProf[(int)skill]; set => main.S.ASkillProf[(int)skill] = value; }
        [SerializeField] Button rankupButton;

        private double[] tempStatsPassiveFactors = new double[Enum.GetNames(typeof(Stats)).Length];
        public void UpdatePassiveEffect()
        {
            for (int i = 0; i < tempStatsPassiveFactors.Length; i++)
            {
                tempStatsPassiveFactors[i] = 0;
            }
            for (int i = 0; i < passiveEffects.Count(); i++)
            {
                if (level >= passiveEffects[i].level)
                    tempStatsPassiveFactors[(int)passiveEffects[i].stats] += passiveEffects[i].percentValue;
            }
            for (int i = 0; i < statsPassiveFactors.Length; i++)
            {
                statsPassiveFactors[i] = tempStatsPassiveFactors[i];
            }
        }
        public double Cost(long rank)
        {
            return Math.Pow(100, 1 + profDifficulty) * (rank + Math.Pow(1.6d + 0.1d * profDifficulty, rank));
        }
        public double CurrentCost(bool isOneBuy = false)
        {
            if (isOneBuy) return Cost(level);
            double tempCost = 0;
            for (int i = 0; i < main.BuyModeNum(); i++)
            {
                tempCost += Cost(level + i);
            }
            return tempCost;
        }
        bool CanBuy()
        {
            return !IsMaxedRank() && main.statusCtrl.IsEnoughCost(CostResource(), CurrentCost());
        }
        public void Buy()
        {
            if (CanBuy())
            {
                main.statusCtrl.ChangeCurrentResource(CostResource(), -CurrentCost());
                RankUp(main.BuyModeNum());
            }
        }
        Resource CostResource()
        {
            switch (skillClass)
            {
                case Warrior:
                    return Resource.Stone;
                case Wizard:
                    return Resource.Crystal;
                case Angel:
                    return Resource.Leaf;
                default:
                    return Resource.Stone;
            }
        }
        bool CanEquip()
        {
            return Rank() > 0 && main.skillCtrl.CanEquipSkill(skillClass);
        }
        public void Equip()
        {
            if (isEquipped)
                isEquipped = false;
            else if (CanEquip())
                isEquipped = true;
            main.skillCtrl.UpdateEquipSKill();
        }
        public void RankUp(long value)
        {
            rank += value;
        }
        public void LevelUp(long value)
        {
            level += value;
            UpdatePassiveEffect();
        }
        bool IsMaxedLevel()
        {
            return Level() >= MaxLevel();
        }
        public long Level()
        {
            return Math.Min(MaxLevel(), 1 + level);
        }
        public long MaxLevel()
        {
            return Rank() * 5;
        }
        bool IsMaxedRank()
        {
            return Rank() >= MaxRank();
        }
        public long Rank()
        {
            return rank;
        }
        public long MaxRank()
        {
            return (long)Math.Min(100, 500);//コスト的に、最大でもRank500が限界
        }
        public double Damage()
        {
            double tempValue = initDmg + incrementDmg * (Level() + Rank());
            switch (skillType)
            {
                case Physical:
                    tempValue *= main.battleCtrl.ally.TotalStats(Stats.Atk);
                    break;
                case Magical:
                    tempValue *= main.battleCtrl.ally.TotalStats(Stats.MAtk);
                    break;
                case Devine:
                    break;
                case Buff:
                    break;
                case SkillType.Heal:
                    break;
                default:
                    break;
            }
            return tempValue;
        }
        public float Interval()
        {
            float tempValue = initInterval;
            return tempValue;
        }
        public double Dps()
        {
            return Damage() / Interval();
        }
        public double Proficiency()
        {
            double tempValue = Math.Floor(10 * ((1 + profDifficulty * 0.5) * Level() + Math.Pow(2, level / 100d)));
            return tempValue;
        }
        float ProficiencyPercent()
        {
            return Mathf.Clamp((float)(currentProf / Proficiency()), 0, 1);
        }
        void IncreaseProficiency()
        {
            if (IsMaxedLevel()) return;
            currentProf += initInterval * main.battleCtrl.ally.TotalStats(Stats.ProficiencyGain);
            UpdateLevel();
        }
        void UpdateProfBar()
        {
            proficiencyBar.value = ProficiencyPercent();
        }
        void UpdateLevel()
        {
            long plusLevel = 0;
            while (true)
            {
                if (currentProf >= Proficiency())
                {
                    currentProf -= Proficiency();
                    plusLevel++;
                }
                else
                {
                    LevelUp(plusLevel);
                    break;
                }
            }
        }
        public double GainMp()
        {
            double tempValue = initMpGain + incrementMpGain * Level();
            return tempValue;
        }
        public double ConsumeMp()
        {
            double tempValue = initMpConsume + incrementMpConsume * Level();
            return tempValue;
        }
        public long HitCount()
        {
            long tempValue = Math.Min(maxHitCount, initHitCount + (long)(incrementHitCount * Level()));
            return tempValue;
        }
        public float Range()
        {
            float tempValue = range;
            return tempValue;
        }
        public float EffectRange()
        {
            float tempValue = Math.Min(maxEffectRange, initEffectRange + incrementEffectRange * Level());
            return tempValue;
        }

        public bool IsWithinRange()
        {
            return main.battleCtrl.TargetDistanceToEnemy() < Range();
        }
        public bool IsChargedInterval()
        {
            return chargetime >= Interval();
        }
        public bool IsEnoughMp()
        {
            return main.battleCtrl.ally.currentMp >= ConsumeMp();
        }
        public bool CanAttack()
        {
            return isEquipped && IsChargedInterval() && main.battleCtrl.ally.IsLive() && IsWithinRange() && IsEnoughMp();
        }
        async void Attack()
        {
            while (true)
            {
                if (CanAttack())
                {
                    chargetime = 0;
                    IncreaseProficiency();
                    main.battleCtrl.ally.ChangeCurrentStats(Stats.Mp, -ConsumeMp());
                    main.battleCtrl.AttackToEnemy(skill, skillType, element, debuff, Damage(), HitCount(), main.battleCtrl.TargetEnemyFromAlly().position, EffectRange());
                }
                await UniTask.Delay(500);
            }
        }
        int intervalFrame = 2;
        async void UpdateChargetime()
        {
            while (true)
            {
                if (isEquipped && !IsChargedInterval() && main.battleCtrl.ally.IsLive())
                {
                    chargetime += intervalFrame / 60f;
                }
                await UniTask.DelayFrame(intervalFrame);
            }
        }

        protected override void Awake()
        {
            base.Awake();
            SetValue();
        }
        // Start is called before the first frame update
        void Start()
        {
            iconImage.sprite = main.skillCtrl.skillSprites[(int)skill] != null ? main.skillCtrl.skillSprites[(int)skill] : null;
            iconButton.onClick.AddListener(Equip);
            rankupButton.onClick.AddListener(Buy);
            Attack();
            UpdateChargetime();
            UpdatePassiveEffect();
        }
        public virtual void CheckIsShow()
        {
            //isShow = main.menuCtrl.currentMenu == Menu.Skill;
        }
        // Update is called once per frame
        void Update()
        {
            if (isShow) UpdateUI();
        }
        void UpdateUI()
        {
            infoText.text = InfoString();
            effectText.text = EffectString();
            passiveText.text = PassiveEffectString();
            costText.text = CostString();
            UpdateProfBar();
            rankupButton.interactable = CanBuy();
            iconButton.interactable = Rank() > 0;
            if (isEquipped) setActive(equippedFrameObject);
            else setFalse(equippedFrameObject);
        }
        string InfoString()
        {
            return optStr + "<size=30>" + localized.SkillName(skill) + "    < <color=green>Rank " + Rank().ToString() + "</color> ></size>"
                + "<size=26>\nDPS : " + tDigit(Dps(), 2) + "<size=12>\n\n</size><size=30><color=green>Lv " + Level().ToString() + "</color> / " + MaxLevel().ToString() + "</size></color>    "
                + "<size=26>" + localized.Basic(BasicWord.Proficiency) + " : " + tDigit(currentProf, 2) + " / " + tDigit(Proficiency(), 2) + " ( " + percent(ProficiencyPercent()) + " )";
        }
        string CostString()
        {
            return optStr + "<sprite=\"resource\" index=" + (int)CostResource() + "> " + tDigit(CurrentCost())
                + "\n" + localized.Basic(BasicWord.RankUp) + " + " + tDigit(main.BuyModeNum());
        }
        string EffectString()
        {
            string tempString = optStr + "<size=26><u>" + localized.Basic(BasicWord.Effect) + "</u>\n<size=8>\n</size>";
            switch (skillType)
            {
                case Physical:
                    tempString += optStr + localized.SkillEffect(EffectKind.PhysicalDamage) + " : " + tDigit(Damage(), 2);
                    break;
                case Magical:
                    switch (element)
                    {
                        case Element.Nothing:
                            tempString += optStr + localized.SkillEffect(EffectKind.PhysicalDamage) + " : " + tDigit(Damage(), 2);
                            break;
                        case Element.Fire:
                            tempString += optStr + localized.SkillEffect(EffectKind.FireDamage) + " : " + tDigit(Damage(), 2);
                            break;
                        case Element.Ice:
                            tempString += optStr + localized.SkillEffect(EffectKind.IceDamage) + " : " + tDigit(Damage(), 2);
                            break;
                        case Element.Thunder:
                            tempString += optStr + localized.SkillEffect(EffectKind.ThunderDamage) + " : " + tDigit(Damage(), 2);
                            break;
                        case Element.Light:
                            tempString += optStr + localized.SkillEffect(EffectKind.LightDamage) + " : " + tDigit(Damage(), 2);
                            break;
                        case Element.Dark:
                            tempString += optStr + localized.SkillEffect(EffectKind.DarkDamage) + " : " + tDigit(Damage(), 2);
                            break;
                    }
                    break;
                case Devine:
                    break;
                case Buff:
                    break;
                case SkillType.Heal:
                    break;
            }
            tempString += optStr + "\n" + localized.SkillEffect(EffectKind.MPGain) + " : " + tDigit(GainMp(), 2);
            tempString += optStr + "\n" + localized.SkillEffect(EffectKind.MPConsumption) + " : " + tDigit(ConsumeMp(), 2);
            tempString += optStr + "\n" + localized.SkillEffect(EffectKind.Cooltime) + " : " + tDigit(Interval(), 2) + " " + localized.Basic(BasicWord.Sec);
            tempString += optStr + "\n" + localized.SkillEffect(EffectKind.Range) + " : " + Range().ToString();
            return tempString;
        }
        public string PassiveEffectString()
        {
            string tempString = optStr + "<size=26><u>" + localized.Basic(BasicWord.PassiveEffect) + "</u><size=8>\n";
            for (int i = 0; i < passiveEffects.Count(); i++)
            {
                tempString += optStr + "\n</size><size=26>" + PassiveEffectLineString(i);
            }
            return tempString;
        }
        public string PassiveEffectLineString(int id)
        {
            string tempString = optStr;
            if (level >= passiveEffects[id].level)
                tempString += "<color=green>";
            tempString += passiveEffects[id].EffectString();
            tempString += "</color>";
            return tempString;
        }
    }

    public class PassiveEffect
    {
        bool isStatEffect;
        public long level;
        public Stats stats;
        public double percentValue;
        public string effectString;
        public PassiveEffect(long level, Stats stats, double percentValue)
        {
            this.level = level;
            this.stats = stats;
            this.percentValue = percentValue;
            isStatEffect = true;
        }
        public PassiveEffect(long level, string effectString)
        {
            this.level = level;
            this.effectString = effectString;
        }
        public string EffectString()
        {
            string tempString = optStr + "Lv " + tDigit(level) + " : ";
            if (isStatEffect)
                tempString += optStr + localized.Stat(stats) + " + " + percent(percentValue);
            else
                tempString += effectString;
            return tempString;
        }
    }
}
