using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WIZARD_SKILL : SKILL
{
    public SkillList.WizardSkill SkillKind;
    public sealed override int P_level
    {
        get => main.saveWiz.SkillLevel[(int)SkillKind];
        set => main.saveWiz.SkillLevel[(int)SkillKind] = value;
    }
    public sealed override bool canGetExp
    {
        get => main.saveWiz.canGetExp[(int)SkillKind];
        set => main.saveWiz.canGetExp[(int)SkillKind] = value;
    }
    public sealed override double P_exp
    {
        get => main.saveWiz.exp[(int)SkillKind];
        set => main.saveWiz.exp[(int)SkillKind] = value;
    }
}
