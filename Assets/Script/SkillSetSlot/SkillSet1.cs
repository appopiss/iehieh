using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using static UsefulMethod;
using static SkillSetController;

public class SkillSet1 : SKILLSET,IPointerEnterHandler,IPointerExitHandler{

    public override SKILL currentSkill { get => main.SR.currentSkill[slotId]; set => main.SR.currentSkill[slotId] = value; }
    public override bool canEquipped { get => main.S.Slot_canEquipped[slotId]; set => main.S.Slot_canEquipped[slotId] = value; }
    public override int saveSkillId { get => main.SR.saveSkillId[slotId]; set => main.SR.saveSkillId[slotId] = value; }
    //public override bool canEquipped { get => main.S.canEquipped[slotId]; set => main.S.canEquipped[slotId] = value; }
    // Use this for initialization
    void Awake () {
		StartBASE();
        SkillSetAwake();
    }

	// Use this for initialization
	void Start () {
        SkillSetStart();
        gameObject.GetComponent<Plain_PopText>().ActiveCondition = () => currentSkill == null;
    }

	// Update is called once per frame
	void Update () {
        SkillSetUpdate();
        if(canEquipped&&currentSkill == null)
        {
            gameObject.GetComponent<Plain_PopText>().text = "Put a skill here";
        }
        else
        {
            setFalse(gameObject.GetComponent<Plain_PopText>().window);
        }
        if (slotId == 0)
        {
            currentSkill = main.skillsForCoolTime[main.jobNum];
        }
    }
}
