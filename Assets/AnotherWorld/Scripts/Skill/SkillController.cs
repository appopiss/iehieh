using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Another;
using static Another.Main;
using static UsefulMethod;
using Cysharp.Threading.Tasks;

namespace Another
{
    public enum Skill
    {
        SwordAttack,
        Slash,
        DoubleSlash,
        SonicSlash,
        SwingDown,
        SwingAround,
        ChargeSwing,
        FanSwing,
        ShieldAttack,
        KnockingShot,

        StaffAttack,
        FireBolt,
        FireStorm,
        MeteorStrike,
        IceBolt,
        ChillingTouch,
        Blizzard,
        ThunderBolt,
        DoubleThunderBolt,
        LightningThunder,

        WingAttack,
        WingShoot,
        Heal,
        GodBless,
        MuscleInflation,
        MagicImpact,
        ProtectWall,
        Haste,
        AngelDistraction,
        HoldWings,

        Nothing,
    }
    public enum SkillType
    {
        Physical,
        Magical,
        Devine,
        Buff,
        Heal,
    }
    public enum Debuff
    {
        Nothing,
        AtkDown,
        MatkDown,
        DefDown,
        MdefDown,
        SpdDown,
        Stop,
        Electric,
        Posion,
        Death,
        Knockback
    }

    public class SkillController : MonoBehaviour
    {
        public SKILL[] warriorSkills;
        public SKILL[] wizardSkills;
        public SKILL[] angelSkills;
        [NonSerialized] public SKILL[] skills;
        public Sprite[] warriorSkillSprites;
        public Sprite[] wizardSkillSprites;
        public Sprite[] angelSkillSprites;
        public Sprite[] skillEffectSprites;

        [NonSerialized] public Sprite[] skillSprites;
        public Sprite slotSprite, lockSlotSprite;
        public SKILLSLOT[] normalSkillSlots;
        public SKILLSLOT[] globalSkillSlots;

        public void Initialize()
        {
            for (int i = 0; i < skills.Length; i++)
            {
                skills[i].chargetime = 0;
            }
        }
        public int NormalSkillSlotNum()
        {
            return 3;
        }
        public int GlobalSkillSlotNum()
        {
            return 1;
        }
        public int CurrentNormalSkillEquippedNum()
        {
            int tempNum = 0;
            switch (main.S.ACurrentClass)
            {
                case Class.Warrior:
                    for (int i = 0; i < warriorSkills.Length; i++)
                    {
                        if (warriorSkills[i].isEquipped) tempNum++;
                    }
                    break;
                case Class.Wizard:
                    for (int i = 0; i < wizardSkills.Length; i++)
                    {
                        if (wizardSkills[i].isEquipped) tempNum++;
                    }
                    break;
                case Class.Angel:
                    for (int i = 0; i < angelSkills.Length; i++)
                    {
                        if (angelSkills[i].isEquipped) tempNum++;
                    }
                    break;
                default:
                    break;
            }
            return tempNum;
        }
        public int CurrentGlobalSkillEquippedNum()
        {
            int tempNum = 0;
            switch (main.S.ACurrentClass)
            {
                case Class.Warrior:
                    for (int i = 0; i < wizardSkills.Length; i++)
                    {
                        if (wizardSkills[i].isEquipped)
                            tempNum++;
                    }
                    for (int i = 0; i < angelSkills.Length; i++)
                    {
                        if (angelSkills[i].isEquipped)
                            tempNum++;
                    }
                    break;
                case Class.Wizard:
                    for (int i = 0; i < warriorSkills.Length; i++)
                    {
                        if (warriorSkills[i].isEquipped)
                            tempNum++;
                    }
                    for (int i = 0; i < angelSkills.Length; i++)
                    {
                        if (angelSkills[i].isEquipped)
                            tempNum++;
                    }
                    break;
                case Class.Angel:
                    for (int i = 0; i < warriorSkills.Length; i++)
                    {
                        if (warriorSkills[i].isEquipped)
                            tempNum++;
                    }
                    for (int i = 0; i < wizardSkills.Length; i++)
                    {
                        if (wizardSkills[i].isEquipped)
                            tempNum++;
                    }
                    break;
                default:
                    break;
            }
            return tempNum;
        }
        public bool CanEquipSkill(Class skillClass)
        {
            if (skillClass == main.S.ACurrentClass)
                return CurrentNormalSkillEquippedNum() < NormalSkillSlotNum();
            else
                return CurrentGlobalSkillEquippedNum() < GlobalSkillSlotNum();
        }
        public void UpdateEquipSKill()
        {
            int tempNormalSlotId = 0;
            int tempGlobalSlotId = 0;
            for (int i = 0; i < skills.Length; i++)
            {
                if (skills[i].isEquipped)
                {
                    if (skills[i].skillClass == main.S.ACurrentClass)
                    {
                        normalSkillSlots[tempNormalSlotId].SetSkill(skills[i].skill);
                        tempNormalSlotId++;
                    }
                    else
                    {
                        globalSkillSlots[tempNormalSlotId].SetSkill(skills[i].skill);
                        tempGlobalSlotId++;
                    }
                }
            }
            for (int i = tempNormalSlotId; i < normalSkillSlots.Length; i++)
            {
                normalSkillSlots[i].RemoveSkill();
            }
            for (int i = tempGlobalSlotId; i < globalSkillSlots.Length; i++)
            {
                globalSkillSlots[i].RemoveSkill();
            }
            main.areaCtrl.CheckIsOnlyBase();//Mission
        }

        public double TotalGainMp()
        {
            double tempValue = 0;
            for (int i = 0; i < skills.Length; i++)
            {
                tempValue += skills[i].GainMp();
            }
            return tempValue;
        }
        public async void GainMp()
        {
            while (true)
            {
                await UniTask.Delay(1000 / 20);
                main.battleCtrl.ally.ChangeCurrentStats(Stats.Mp, TotalGainMp() / 20);
            }
        }

        public double TotalStatsPassiveFactor(Stats stats)
        {
            double tempValue = 0;
            for (int i = 0; i < skills.Length; i++)
            {
                tempValue += skills[i].statsPassiveFactors[(int)stats];
            }
            return tempValue;
        }

        private void Awake()
        {
            for (int i = 0; i < normalSkillSlots.Length; i++)
            {
                normalSkillSlots[i].id = i;
            }
            for (int i = 0; i < globalSkillSlots.Length; i++)
            {
                globalSkillSlots[i].isGlobal = true;
                globalSkillSlots[i].id = i;
            }
            for (int i = 0; i < warriorSkills.Length; i++)
            {
                warriorSkills[i].skill = (Skill)i;
            }
            for (int i = 0; i < wizardSkills.Length; i++)
            {
                wizardSkills[i].skill = (Skill)i + 10;
            }
            for (int i = 0; i < angelSkills.Length; i++)
            {
                angelSkills[i].skill = (Skill)i + 20;
            }

            List<SKILL> tempSkillList = new List<SKILL>(warriorSkills.Length + wizardSkills.Length + angelSkills.Length);
            tempSkillList.AddRange(warriorSkills);
            tempSkillList.AddRange(wizardSkills);
            tempSkillList.AddRange(angelSkills);
            skills = tempSkillList.ToArray();
            List<Sprite> tempSpriteList = new List<Sprite>(warriorSkillSprites.Length + wizardSkillSprites.Length + angelSkillSprites.Length);
            tempSpriteList.AddRange(warriorSkillSprites);
            tempSpriteList.AddRange(wizardSkillSprites);
            tempSpriteList.AddRange(angelSkillSprites);
            skillSprites = tempSpriteList.ToArray();

            //main.menuCtrl.action += () => CheckIsShowAll();
        }
        // Start is called before the first frame update
        void Start()
        {
            UpdateEquipSKill();
            GainMp();

            //Debug
            skills[0].rank = Math.Max(1, skills[0].rank);
            if (!skills[0].isEquipped) skills[0].Equip();
        }
        public void CheckIsShowAll()
        {
            for (int i = 0; i < skills.Length; i++)
            {
                skills[i].CheckIsShow();
            }
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}
