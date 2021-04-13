using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;

public class SkillList : BASE {

	// Use this for initialization
	void Awake () {
		StartBASE();
	}

    public SKILL[] WarriorSkills;
    public SKILL[] WizardSkills;
    public SKILL[] AngelSkills;
    public TextMeshProUGUI DpsText; 

    public enum WarriorSkill
    {
        sword = 0,
        slash = 1,
        DoubleSlash = 2,
        sonic = 3,
        swingDown = 4,
        swingAround = 5,
        chargeSwing = 6,
        fanSwing = 7,
        shieldAttack = 8,
        block = 9,
        warriorSpirit = 10,
        earthquake = 11,
        fortitudeCourage=12,
        criticalEye=13,
    }

    public enum WizardSkill
    {
        staff = 0,
        fireBall = 1,
        fireStorm = 2,
        meteo = 3,
        iceBall = 4,
        chillingToudch = 5,
        blizzard = 6,
        thunderBall = 7,
        doubleThunderBall = 8,
        lightningThunder=9,
        wizardSpirit=10,
        comboAttack=11,
        magicalGuard=12,
        criticalBolt=13,
    }

    public enum AngelSkill
    {
        wingAttack = 0,
        wingShoot = 1,
        heal = 2,
        godBless = 3,
        muscle = 4,
        magicImpact = 5,
        protectWall = 6,
        haste = 7,
        angelDistraction = 8,
        holdWings = 9,
        angelSpirit=10,
        balancedWing=11,
        holyArch=12,
        purification=13,
    }
}
