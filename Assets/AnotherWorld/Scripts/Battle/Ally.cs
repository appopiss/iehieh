using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using static Another.Main;
using static UsefulMethod;
using static Another.LocalizedText;
using Another;
using Cysharp.Threading.Tasks;


public partial class Save
{
    public long ACurrentLevel;
    public double ACurrentExp;
    public Class ACurrentClass;
}
namespace Another
{
    public enum Class
    {
        Warrior,
        Wizard,
        Angel,
    }
    public enum Stats
    {
        Hp,
        Mp,
        Atk,
        MAtk,
        Def,
        MDef,
        Spd,
        FireRes,
        IceRes,
        ThunderRes,
        LightRes,
        DarkRes,
        DodgeChance,
        PhysCritChance,
        MagCritChance,
        GoldGain,
        ExpGain,
        ProficiencyGain,
        NormalDropChance,
        ColorDropChance,
        UniqueDropChance,
        MoveSpeed,
        StoneGain,
        CrystalGain,
        LeafGain,
        GoldCap,
        SlimeCoinCap,
    }

    public class Ally : MonoBehaviour
    {
        public DamageText[] damageTexts;
        public Sprite[] warriorSprites;
        public Sprite[] wizardSprites;
        public Sprite[] angelSprites;

        Image thisImage;
        [NonSerialized] public Class currentClass;
        public bool isAutoMove { get => main.statusCtrl.isAutoMove; set => main.statusCtrl.isAutoMove = value; }
        public long level { get => main.S.ACurrentLevel; set => main.S.ACurrentLevel = value; }
        public double exp { get => main.S.ACurrentExp; set => main.S.ACurrentExp = value; }
        [NonSerialized] public RectTransform thisRect;
        [NonSerialized] public Vector2 position;
        static Vector2 initPosition = Vector2.down * 400;
        [NonSerialized] public double currentHp, currentMp;


        public long Level()
        {
            return level;
        }
        public long ShowLevel()
        {
            return 1 + Level();
        }
        public double TotalStats(Stats stats)
        {
            double tempValue = AddStats(stats) * MulStats(stats);
            switch (stats)//Maxの値がある場合はここで設定
            {
                case Stats.Spd:
                    tempValue = Math.Min(100, tempValue);
                    break;
                case Stats.NormalDropChance:
                    tempValue = Math.Min(0.50, tempValue);
                    break;
                case Stats.ColorDropChance:
                    tempValue = Math.Min(0.50, tempValue);
                    break;
                case Stats.UniqueDropChance:
                    tempValue = Math.Min(0.50, tempValue);
                    break;
            }
            return tempValue;
        }
        public double AddStats(Stats stats)
        {
            double tempValue = BaseStats(stats);
            //tempValue += main.craftCtrl.TotalStatsAddFactors(stats);
            //tempValue += main.upgradeCtrl.TotalStatsAddFactors(stats);
            return tempValue;
        }
        public double MulStats(Stats stats)
        {
            double tempValue = 1;
            //tempValue *= 1 + main.skillCtrl.TotalStatsPassiveFactor(stats);
            //tempValue *= 1 + main.craftCtrl.TotalStatsMulFactors(stats);
            return tempValue;
        }
        public double BaseStats(Stats stats)
        {
            double tempValue = 0;
            switch (stats)
            {
                case Stats.Hp:
                    switch (currentClass)
                    {
                        case Class.Warrior:
                            tempValue = 20 + Level() * 5;
                            break;
                        case Class.Wizard:
                            tempValue = 10 + Level() * 2;
                            break;
                        case Class.Angel:
                            tempValue = 15 + Level() * 3;
                            break;
                    }
                    break;
                case Stats.Mp:
                    switch (currentClass)
                    {
                        case Class.Warrior:
                            tempValue = 5 + Level() * 1;
                            break;
                        case Class.Wizard:
                            tempValue = 10 + Level() * 2;
                            break;
                        case Class.Angel:
                            tempValue = 10 + Level() * 2;
                            break;
                    }
                    break;
                case Stats.Atk:
                    switch (currentClass)
                    {
                        case Class.Warrior:
                            tempValue = 5 + Level() * 2;
                            break;
                        case Class.Wizard:
                            tempValue = 1 + Level() * 0;
                            break;
                        case Class.Angel:
                            tempValue = 3 + Level() * 1;
                            break;
                    }
                    break;
                case Stats.MAtk:
                    switch (currentClass)
                    {
                        case Class.Warrior:
                            tempValue = 1 + Level() * 0;
                            break;
                        case Class.Wizard:
                            tempValue = 5 + Level() * 2;
                            break;
                        case Class.Angel:
                            tempValue = 3 + Level() * 1;
                            break;
                    }
                    break;
                case Stats.Def:
                    switch (currentClass)
                    {
                        case Class.Warrior:
                            tempValue = 2 + Level() * 1;
                            break;
                        case Class.Wizard:
                            tempValue = 1 + Level() * 0;
                            break;
                        case Class.Angel:
                            tempValue = 2 + Level() * 1;
                            break;
                    }
                    break;
                case Stats.MDef:
                    switch (currentClass)
                    {
                        case Class.Warrior:
                            tempValue = 1 + Level() * 0;
                            break;
                        case Class.Wizard:
                            tempValue = 2 + Level() * 1;
                            break;
                        case Class.Angel:
                            tempValue = 2 + Level() * 1;
                            break;
                    }
                    break;
                case Stats.Spd:
                    switch (currentClass)
                    {
                        case Class.Warrior:
                            tempValue = 5 + Level() * 0;
                            break;
                        case Class.Wizard:
                            tempValue = 5 + Level() * 0;
                            break;
                        case Class.Angel:
                            tempValue = 5 + Level() * 0;
                            break;
                    }
                    break;
                case Stats.FireRes:
                    tempValue = 0;
                    break;
                case Stats.IceRes:
                    tempValue = 0;
                    break;
                case Stats.ThunderRes:
                    tempValue = 0;
                    break;
                case Stats.LightRes:
                    tempValue = 0;
                    break;
                case Stats.DarkRes:
                    tempValue = 0;
                    break;
                case Stats.DodgeChance:
                    tempValue = 0;
                    break;
                case Stats.PhysCritChance:
                    tempValue = 0.01d;
                    break;
                case Stats.MagCritChance:
                    tempValue = 0.01d;
                    break;
                case Stats.GoldGain:
                    tempValue = 0;
                    break;
                case Stats.ExpGain:
                    tempValue = 0;
                    break;
                case Stats.ProficiencyGain:
                    tempValue = 1;
                    break;
                case Stats.NormalDropChance:
                    tempValue = 0.10d;
                    break;
                case Stats.ColorDropChance:
                    tempValue = 0.01d;
                    break;
                case Stats.UniqueDropChance:
                    tempValue = 0.01d;
                    break;
                case Stats.MoveSpeed:
                    tempValue = TotalStats(Stats.Spd);
                    break;
                case Stats.StoneGain:
                    tempValue = 1;
                    break;
                case Stats.CrystalGain:
                    tempValue = 1;
                    break;
                case Stats.LeafGain:
                    tempValue = 1;
                    break;
                case Stats.GoldCap:
                    tempValue = 1000;
                    break;
                case Stats.SlimeCoinCap:
                    tempValue = 1000;
                    break;
            }
            return tempValue;
        }
        public double TotalElementResistance(Element element)
        {
            switch (element)
            {
                case Element.Fire:
                    return Math.Min(0.9, TotalStats(Stats.FireRes));
                case Element.Ice:
                    return Math.Min(0.9, TotalStats(Stats.IceRes));
                case Element.Thunder:
                    return Math.Min(0.9, TotalStats(Stats.ThunderRes));
                case Element.Light:
                    return Math.Min(0.9, TotalStats(Stats.LightRes));
                case Element.Dark:
                    return Math.Min(0.9, TotalStats(Stats.DarkRes));
                default:
                    return 0;
            }
        }
        public double HpPercent()
        {
            return currentHp / TotalStats(Stats.Hp);
        }
        public double MpPercent()
        {
            return currentMp / TotalStats(Stats.Mp);
        }
        public bool IsLive()
        {
            return currentHp > 0;
        }

        public float CloseDistance()
        {
            return main.statusCtrl.currentRange;
        }
        public void AutoMove()
        {
            if (CanAutoMove())
                position += main.battleCtrl.MoveDirectionToEnemy() * Math.Min(main.battleCtrl.TargetDistanceToEnemy(), (float)TotalStats(Stats.MoveSpeed));
        }
        public bool CanAutoMove()
        {
            return isAutoMove && IsLive() && main.battleCtrl.TargetDistanceToEnemy() > CloseDistance() && !main.battleCtrl.isVanishedAll;
        }
        public bool IsWithinMoveRange()
        {
            return IsRangeRight() && IsRangeLeft() && IsRangeUp() && IsRangeDown();
        }
        bool IsRangeRight()
        {
            return position.x < main.battleCtrl.thisRect.sizeDelta.x / 2f;
        }
        bool IsRangeLeft()
        {
            return position.x > -main.battleCtrl.thisRect.sizeDelta.x / 2f;
        }
        bool IsRangeUp()
        {
            return position.y < main.battleCtrl.thisRect.sizeDelta.y / 2f;
        }
        bool IsRangeDown()
        {
            return position.y > -main.battleCtrl.thisRect.sizeDelta.y / 2f;
        }


        //Damage
        public void Attacked(Element element, Debuff debuff, double dmg)
        {
            main.areaCtrl.CheckIsNoDmg();
            Damaged(element, CalculatedDamage(element, dmg));
        }
        double CalculatedDamage(Element element, double dmg)
        {
            double tempDmg = dmg;
            tempDmg *= DamageReduction(element, dmg);
            return tempDmg;
        }
        double DamageReduction(Element element, double dmg)
        {
            double tempReduction = element == Element.Nothing ? 1 - TotalStats(Stats.Def) / (dmg + TotalStats(Stats.Def)) : 1 - TotalStats(Stats.MDef) / (dmg + TotalStats(Stats.MDef));
            tempReduction *= 1 - TotalElementResistance(element);
            return tempReduction;
        }
        void Damaged(Element element, double dmg)
        {
            ChangeCurrentStats(Stats.Hp, -dmg);
            ShowDmg(element, dmg);
        }
        int dmgtextId;
        void ShowDmg(Element element, double dmg)
        {
            string tempColor = "<color=white>";
            if (element != Element.Nothing)
                tempColor = "<color=orange>";
            string tempString = optStr + tempColor + "-" + tDigit(dmg, 1) + "</color>";
            setActive(damageTexts[dmgtextId].gameObject);
            damageTexts[dmgtextId].ShowText(tempString);
            if (dmgtextId >= damageTexts.Length - 1)
                dmgtextId = 0;
            else
                dmgtextId++;
        }


        public void MoveHorizontal(float value)
        {
            if (!IsLive())
                return;
            if (value > 0 && IsRangeRight())
                position += Vector2.right * value * (float)TotalStats(Stats.MoveSpeed);
            if (value < 0 && IsRangeLeft())
                position += Vector2.right * value * (float)TotalStats(Stats.MoveSpeed);
        }
        public void MoveVertical(float value)
        {
            if (!IsLive())
                return;
            if (value > 0 && IsRangeUp())
                position += Vector2.up * value * (float)TotalStats(Stats.MoveSpeed);
            if (value < 0 && IsRangeDown())
                position += Vector2.up * value * (float)TotalStats(Stats.MoveSpeed);
        }

        public void SetInitPosition()
        {
            position = initPosition;
        }
        private void Awake()
        {
            thisRect = gameObject.GetComponent<RectTransform>();
            thisImage = gameObject.GetComponent<Image>();
            for (int i = 0; i < damageTexts.Length; i++)
            {
                damageTexts[i].id = i;
            }
            currentHp = TotalStats(Stats.Hp);
        }
        // Start is called before the first frame update
        void Start()
        {
            ChangeSprite();
            UpdateLevel();
        }

        // Update is called once per frame
        void Update()
        {
            AutoMove();
            thisRect.anchoredPosition = position;
            if (currentHp < 0)
                currentHp = 0;
        }
        async void UpdateLevel()
        {
            while (true)
            {
                long plusLevel = 0;
                while (true)
                {
                    if (exp >= CurrentRequiredExp())
                    {
                        exp -= CurrentRequiredExp();
                        level++;
                        plusLevel++;
                    }
                    else
                    {
                        if (plusLevel > 0)
                            main.Log(optStr + "<color=green>Level Up! (+" + tDigit(plusLevel) + ")");
                        break;
                    }
                }
                await UniTask.DelayFrame(5);
            }
        }
        async void ChangeSprite()
        {
            bool isZero = false;
            while (true)
            {
                switch (currentClass)
                {
                    case Class.Warrior:
                        thisImage.sprite = warriorSprites[Convert.ToInt32(isZero)];
                        break;
                    case Class.Wizard:
                        thisImage.sprite = wizardSprites[Convert.ToInt32(isZero)];
                        break;
                    case Class.Angel:
                        thisImage.sprite = angelSprites[Convert.ToInt32(isZero)];
                        break;
                    default:
                        thisImage.sprite = warriorSprites[Convert.ToInt32(isZero)];
                        break;
                }
                isZero = !isZero;
                await UniTask.Delay(500);
            }
        }

        public double CurrentRequiredExp()
        {
            return RequiredExp(level);
        }
        double RequiredExp(long level)
        {
            return 10 * (1 + level);
        }
        public float CurrentExpPercent()
        {
            return Mathf.Clamp((float)(exp / CurrentRequiredExp()), 0, 1);
        }
        public void FullHeal()
        {
            currentHp = TotalStats(Stats.Hp);
        }
        public void ChangeCurrentStats(Stats stats, double value)
        {
            if (!IsLive())
                return;
            double tempValue = 0;
            switch (stats)
            {
                case Stats.Hp:
                    tempValue = currentHp;
                    tempValue += value;
                    if (tempValue < 0) tempValue = 0;
                    if (tempValue == Mathf.Infinity) tempValue = 1e300d;
                    if (tempValue > TotalStats(Stats.Hp)) tempValue = TotalStats(Stats.Hp);
                    currentHp = tempValue;
                    break;
                case Stats.Mp:
                    tempValue = currentMp;
                    tempValue += value;
                    if (tempValue < 0) tempValue = 0;
                    if (tempValue == Mathf.Infinity) tempValue = 1e300d;
                    if (tempValue > TotalStats(Stats.Mp)) tempValue = TotalStats(Stats.Mp);
                    currentMp = tempValue;
                    break;
                case Stats.ExpGain:
                    tempValue = exp;
                    tempValue += value;
                    if (tempValue < 0) tempValue = 0;
                    if (tempValue == Mathf.Infinity) tempValue = 1e300d;
                    exp = tempValue;
                    //Log
                    if (value > 0) main.Log(optStr + "EXP + " + tDigit(value));
                    break;
            }
        }


    }

}
