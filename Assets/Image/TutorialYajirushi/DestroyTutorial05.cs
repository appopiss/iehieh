using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class DestroyTutorial05 : BASE {

	// Use this for initialization
	void Awake () {
		StartBASE();
        gameObject.GetComponent<RectTransform>().anchoredPosition += new Vector2(10000, 0);
        
    }
    

	// Use this for initialization
	void Start () {
        if (main.S.isGlobalSlotEquipped)
        {
            Destroy(gameObject);
        }
        StartCoroutine(StartWait());
    }
    IEnumerator StartWait()
    {
        yield return new WaitForSeconds(0.1f);
        if (!main.S.isGlobalSlotEquipped && main.skillSlotCanvasAry[7].canEquipped && isChosenAnotherJob())
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition += new Vector2(-10000, 0);
        }
        yield break;
    }
    public bool isChosenAnotherJob()
    {
        if ((main.warriorSkillAry[0].P_level > 0 && main.wizardSkillAry[0].P_level > 0) || (main.warriorSkillAry[0].P_level > 0 && main.angelSkillAry[0].P_level > 0) || (main.wizardSkillAry[0].P_level > 0 && main.angelSkillAry[0].P_level > 0))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Update is called once per frame
    void Update () {
        if (main.S.isGlobalSlotEquipped)
        {
            Destroy(gameObject);
        }
    }
}
