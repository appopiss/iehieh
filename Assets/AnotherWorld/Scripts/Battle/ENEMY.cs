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

public partial class Save
{
    public double[] AKillCount;
}
namespace Another
{
    public class ENEMY : MonoBehaviour
    {
        public Slider hpSlider, mpSlider;
        public DamageText[] damageTexts;
        Image thisImage;
        EnemyController enemyCtrl;
        Ally ally;

        [NonSerialized] public bool isSpawn;//バトルスクリーン上に存在する
        [NonSerialized] public EnemySpecies species;
        [NonSerialized] public EnemyColor color;
        [NonSerialized] public Element element;
        [NonSerialized] public long level;
        [NonSerialized] public long difficulty;
        [NonSerialized] public double currentHp;
        [NonSerialized] public RectTransform thisRect;
        [NonSerialized] public Vector2 position;
        [NonSerialized] public double hp, mp, atk, matk, def, mdef, spd, fire, ice, thunder, light, dark;
        public double Level()
        {
            return 1 + level;
        }
        public double DifficultyFactor()
        {
            return Math.Pow(2, difficulty / 10d);
        }
        public double ColorFactor()
        {
            return 1 + (int)color;
        }
        public double Gold()
        {
            return (Level() + DifficultyFactor()) * ColorFactor();
        }
        public double Exp()
        {
            return Level() + DifficultyFactor() * ColorFactor();
        }
        public double Hp()
        {
            return hp * Level() * DifficultyFactor();
        }
        public double Mp()
        {
            return mp * Level() * DifficultyFactor();
        }
        public double Atk()
        {
            return atk * Level() * DifficultyFactor();
        }
        public double MAtk()
        {
            return matk * Level() * DifficultyFactor();
        }
        public double Def()
        {
            return def * Level() * DifficultyFactor();
        }
        public double MDef()
        {
            return mdef * Level() * DifficultyFactor();
        }
        public double Spd()
        {
            return spd;// * Level() * DifficultyFactor();
        }
        public float Interval()
        {
            return 2.0f / (1.0f + (float)spd / 10f);
        }
        public double FireResistance()
        {
            return fire;
        }
        public double IceResistance()
        {
            return ice;
        }
        public double ThunderResistance()
        {
            return thunder;
        }
        public double LightResistance()
        {
            return light;
        }
        public double DarkResistance()
        {
            return dark;
        }
        public float Range()
        {
            float tempValue = element == Element.Nothing ? 100f : 300f;
            return tempValue;
        }
        public double HpPercent()
        {
            return currentHp / Hp();
        }

        //Attack
        [NonSerialized] public bool isFilledCooltime;
        float chargetime;

        public float ChargetimePercent()
        {
            return chargetime / Interval();
        }
        static int intervalFrame = 2;
        async void UpdateChargetime()
        {
            while (true)
            {
                if (isSpawn && !isFilledCooltime && IsWithinRange())
                {
                    setActive(mpSlider.gameObject);
                    if (ChargetimePercent() >= 1)
                        isFilledCooltime = true;
                    else
                    {
                        chargetime += intervalFrame / 60f;
                        mpSlider.value = ChargetimePercent();
                    }
                }
                await UniTask.DelayFrame(intervalFrame);
            }
        }
        public bool IsWithinRange()
        {
            return main.battleCtrl.TargetDistanceToAlly(position) < Range();
        }
        async void Attack()
        {
            double dmg = 0;
            while (true)
            {
                if (isFilledCooltime && IsWithinRange() && ally.IsLive())
                {
                    dmg = element == Element.Nothing ? Atk() : MAtk();
                    main.battleCtrl.AttackToAlly(element, Debuff.Nothing, dmg);
                    chargetime = 0;
                    mpSlider.value = ChargetimePercent();
                    isFilledCooltime = false;
                }

                await UniTask.DelayFrame(intervalFrame);
            }
        }

        //Damage
        public void Attacked(Element element, Debuff debuff, double dmg)
        {
            switch (debuff)
            {
                case Debuff.Nothing:
                    break;
                case Debuff.AtkDown:
                    break;
                case Debuff.MatkDown:
                    break;
                case Debuff.DefDown:
                    break;
                case Debuff.MdefDown:
                    break;
                case Debuff.SpdDown:
                    break;
                case Debuff.Stop:
                    break;
                case Debuff.Electric:
                    break;
                case Debuff.Posion:
                    break;
                case Debuff.Death:
                    break;
                case Debuff.Knockback:
                    AutoMove(-60f);
                    break;
            }

            //Criticalの抽選
            double tempChance = element == Element.Nothing ? main.battleCtrl.ally.TotalStats(Stats.PhysCritChance) : main.battleCtrl.ally.TotalStats(Stats.MagCritChance);
            bool isCrit = UnityEngine.Random.Range(0, 10000) < 10000 * tempChance;
            //Damage計算
            Damaged(element, CalculatedDamage(element, dmg, isCrit), isCrit);
        }
        double CalculatedDamage(Element element, double dmg, bool isCrit)
        {
            double tempDmg = dmg;
            tempDmg *= DamageReduction(element, dmg);
            if (isCrit) tempDmg *= 2;
            return tempDmg;
        }
        double DamageReduction(Element element, double dmg)
        {
            double tempReduction = element == Element.Nothing ? 1 - Def() / (dmg + Def()) : 1 - MDef() / (dmg + MDef());
            switch (element)
            {
                case Element.Nothing:
                    break;
                case Element.Fire:
                    tempReduction *= 1 - FireResistance();
                    break;
                case Element.Ice:
                    tempReduction *= 1 - IceResistance();
                    break;
                case Element.Thunder:
                    tempReduction *= 1 - ThunderResistance();
                    break;
                case Element.Light:
                    tempReduction *= 1 - LightResistance();
                    break;
                case Element.Dark:
                    tempReduction *= 1 - DarkResistance();
                    break;
            }
            return tempReduction;
        }
        void Damaged(Element element, double dmg, bool isCrit)
        {
            setActive(hpSlider.gameObject);
            currentHp -= dmg;
            hpSlider.value = (float)HpPercent();
            ShowDmg(element, dmg, isCrit);
        }
        int dmgtextId;
        void ShowDmg(Element element, double dmg, bool isCrit)
        {
            string tempColor = "";
            if (element == Element.Nothing)
            {
                tempColor = isCrit ? "<size=36><color=red>" : "<size=26><color=white>";
            }
            else
            {
                tempColor = isCrit ? "<size=36><color=yellow>" : "<size=26<color=orange>";
            }
            string tempString = optStr + tempColor + "-" + tDigit(dmg, 1) + "</color>";
            setActive(damageTexts[dmgtextId].gameObject);
            damageTexts[dmgtextId].ShowText(tempString);
            if (dmgtextId >= damageTexts.Length - 1)
                dmgtextId = 0;
            else
                dmgtextId++;
        }

        //Move
        public void AutoMove(float factor = 1)
        {
            if (CanAutoMove())
                position += main.battleCtrl.MoveDirectionToAlly(position) * MoveSpeed() * factor;
        }
        public bool CanAutoMove()
        {
            return isSpawn && ally.IsLive() && main.battleCtrl.TargetDistanceToAlly(position) >= CloseDistance();
        }
        public float MoveSpeed()
        {
            return (float)Spd() / 10f;
        }
        public float CloseDistance()
        {
            float tempValue = element == Element.Nothing ? 100f : 300f;
            return tempValue;
        }

        public void Spawn(EnemySpecies species, EnemyColor color, Vector2 position, long level, long difficulty)
        {
            this.species = species;
            this.color = color;
            SetSprite(true);
            this.position = position;
            this.level = level;
            this.difficulty = difficulty;
            element = enemyCtrl.InitStats(species, color).element;
            hp = enemyCtrl.InitStats(species, color).stats[0];
            mp = enemyCtrl.InitStats(species, color).stats[1];
            atk = enemyCtrl.InitStats(species, color).stats[2];
            matk = enemyCtrl.InitStats(species, color).stats[3];
            def = enemyCtrl.InitStats(species, color).stats[4];
            mdef = enemyCtrl.InitStats(species, color).stats[5];
            spd = enemyCtrl.InitStats(species, color).stats[6];
            fire = enemyCtrl.InitStats(species, color).stats[7];
            ice = enemyCtrl.InitStats(species, color).stats[8];
            thunder = enemyCtrl.InitStats(species, color).stats[9];
            light = enemyCtrl.InitStats(species, color).stats[10];
            dark = enemyCtrl.InitStats(species, color).stats[11];
            currentHp = Hp();
            isSpawn = true;
        }
        public void Vanish(bool isDied = false)
        {
            if (isDied)//戦闘で倒されたときの処理
            {
                IncreaseKillCount();
                enemyCtrl.GainGold(Gold());
                enemyCtrl.GainExp(Exp());
                enemyCtrl.GainMaterial(species, color);
            }
            position = BattleController.behindPosition;
            species = EnemySpecies.Slime;
            color = EnemyColor.Normal;
            element = Element.Nothing;
            level = 0;
            difficulty = 0;
            currentHp = 0;
            chargetime = 0;
            setFalse(hpSlider.gameObject);
            setFalse(mpSlider.gameObject);
            for (int i = 0; i < damageTexts.Length; i++)
            {
                setFalse(damageTexts[i].gameObject);
            }
            isSpawn = false;
        }
        void IncreaseKillCount()
        {
            main.S.AKillCount[10 * (int)species + (int)color]++;
        }

        private void Awake()
        {
            thisRect = gameObject.GetComponent<RectTransform>();
            thisImage = gameObject.GetComponent<Image>();
            enemyCtrl = main.battleCtrl.enemyCtrl;
            ally = main.battleCtrl.ally;
            for (int i = 0; i < damageTexts.Length; i++)
            {
                damageTexts[i].id = i;
            }
            Vanish();
        }
        // Start is called before the first frame update
        void Start()
        {
            ChangeSprite();
            Attack();
            UpdateChargetime();
        }

        // Update is called once per frame
        void Update()
        {
            if (isSpawn)
            {
                if (currentHp <= 0)
                    Vanish(true);
            }
            AutoMove();
            thisRect.anchoredPosition = position;
        }
        async void ChangeSprite()
        {
            bool isZero = false;
            while (true)
            {
                if (isSpawn)
                {
                    SetSprite(isZero);
                    isZero = !isZero;
                }
                await UniTask.Delay(500);
            }
        }
        void SetSprite(bool isZero)
        {
            thisImage.sprite = enemyCtrl.Sprites(species, color, isZero);
        }
    }
}
