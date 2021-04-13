using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class poision : ABNORMAL {

    public Sprite[] hpbarSp;
    //public Image hpbar;
    //public Image hpbar;
	// Use this for initialization
	void Awake () {
        AwakeCor();
	}

	// Use this for initialization
	void Start () {
        StartCor();
        main.ally.isDebuff[(int)Main.Debuff.poison] = true;
        skillNameString = "Poison";
        effectString = "<color=red>- Poison Damage : " + tDigit(abnormalDamage / Math.Log10((1000 + main.ally.Def() + main.ally.MDef()) / 100)) + " / s";
    }

    // Update is called once per frame
    void Update () {
        UpdateCor();
	}

    public override IEnumerator Effect()
    {
        main.HPSlider.transform.GetChild(1).gameObject.GetComponentInChildren<Image>().sprite = null;
        main.HPSlider.transform.GetChild(1).gameObject.GetComponentInChildren<Image>().sprite = hpbarSp[0];
        while (true)
        {
            effectString = "<color=red>- Poison Damage : " + tDigit(abnormalDamage / Math.Log10((1000 + main.ally.Def() + main.ally.MDef()) / 100)) + " / s";
            if (main.ally.currentHp >= 0)
            {
                main.ally.currentHp -= abnormalDamage / Math.Log10((1000 + main.ally.Def()+main.ally.MDef())/100);//ここは変えないで！！
            }
            yield return new WaitForSeconds(1f);
        }
    }
    private void OnDestroy()
    {
        Destroy(window);
        main.HPSlider.transform.GetChild(1).gameObject.GetComponentInChildren<Image>().sprite = null;
        main.HPSlider.transform.GetChild(1).gameObject.GetComponentInChildren<Image>().sprite = hpbarSp[1];
        main.ally.isDebuff[(int)Main.Debuff.poison] = false;
    }
}
