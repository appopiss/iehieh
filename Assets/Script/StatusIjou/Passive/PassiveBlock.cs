using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class PassiveBlock : POPTEXT_Passive {

	// Use this for initialization
	void Awake () {
        awakeText();
	}

    // Use this for initialization
    void Start () {
        startText();
        if (!onlyDisplay)
        {
            main.SR.P_Block = true;
            StartCoroutine(Activate());
        }
    }

    // Update is called once per frame
    void Update () {
        updateText();
        if (window.activeSelf)
        {
            windowSkillIcon.sprite = main.Sprites[9];
            skillNameString = "Protection Stance < <color=\"green\">Lv " + main.warriorSkillAry[9].BuffedLevel() + " </color>>";
            linageString = "";
            if (main.SR.P_Block)
                linageString += "Active";
            else
                linageString += "Inactive";
            effectString = "<color=green>- Summon shield with " + tDigit(protectHp()) + " HP</color>\n- Activate Chance : " + percent(chance() / 10000);
            explainString = "- Activate Protection Stance when you recieve damage.";
        }
        if (main.ally.isPassiveBlockActivated)
           main.ally.gameObject.transform.GetChild(0).gameObject.GetComponent<Slider>().value = (float)(main.ally.currentBlockHp / main.ally.MaxBlockHp);
    }

    IEnumerator Activate()
    { 
        while (true)
        {
            ResetEffect();
            yield return new WaitUntil(() => main.warriorSkillAry[9].attackNum >= 10000-chance());
            setActive(main.ally.transform.GetChild(0).gameObject);//HPSlider
            main.ally.isPassiveBlockActivated = true;
            main.ally.MaxBlockHp = protectHp();
            main.ally.currentBlockHp = main.ally.MaxBlockHp;
            setActive(gameObject.transform.GetChild(1).gameObject);
            setActive(main.ally.gameObject.transform.GetChild(4).gameObject);
            //main.ally.warriorPassiveSwordFactor = effect();
            yield return new WaitUntil(()=>main.ally.currentBlockHp <= 0);
        }
    }
    public void ResetEffect()
    {
        main.warriorSkillAry[9].attackNum = 0;
        main.ally.currentBlockHp = 0;
        main.ally.isPassiveBlockActivated = false;

        if (gameObject.transform.GetChild(1).gameObject!=null)
            setFalse(gameObject.transform.GetChild(1).gameObject);
        if (main.ally.gameObject.transform.GetChild(4).gameObject!=null)
            setFalse(main.ally.gameObject.transform.GetChild(4).gameObject);
        if (main.ally.gameObject.transform.GetChild(0).gameObject!=null)
            setFalse(main.ally.gameObject.transform.GetChild(0).gameObject);//HPSlider

    }


    double chance()
    {
        return 100 + main.warriorSkillAry[9].BuffedLevel()/2;
    }
    double protectHp()
    {
        return main.ally.HP() * ( 0.05 + (double)main.warriorSkillAry[9].BuffedLevel()/2000);
    }

    private void OnDestroy()
    {
        if (!onlyDisplay)
        {
            ResetEffect();
            main.ally.warriorPassiveSwordFactor = 0;
        }
            //main.SR.P_Block = false;
    }
}
