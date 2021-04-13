using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WARRIOR_SKILL : SKILL
{
    public SkillList.WarriorSkill SkillKind;
    public sealed override int P_level
    {
        get => main.saveWar.SkillLevel[(int)SkillKind];
        set => main.saveWar.SkillLevel[(int)SkillKind] = value;
    }
    public sealed override bool canGetExp
    {
        get => main.saveWar.canGetExp[(int)SkillKind];
        set => main.saveWar.canGetExp[(int)SkillKind] = value;
    }
    public sealed override double P_exp 
    {
        get => main.saveWar.exp[(int)SkillKind];
        set => main.saveWar.exp[(int)SkillKind] = value;
    }

}
