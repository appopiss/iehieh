using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class ANGEL_SKILL : SKILL {

    public SkillList.AngelSkill SkillKind;
    public sealed override int P_level
    {
        get => main.saveAng.SkillLevel[(int)SkillKind];
        set => main.saveAng.SkillLevel[(int)SkillKind] = value;
    }
    public sealed override bool canGetExp
    {
        get => main.saveAng.canGetExp[(int)SkillKind];
        set => main.saveAng.canGetExp[(int)SkillKind] = value;
    }
    public sealed override double P_exp
    {
        get => main.saveAng.exp[(int)SkillKind];
        set => main.saveAng.exp[(int)SkillKind] = value;
    }

}
