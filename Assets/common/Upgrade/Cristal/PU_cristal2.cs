using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using static UsefulMethod;

public class PU_cristal2 : M_UPGRADE
{
    public override int level { get => main.SR.L_cristal2; set => main.SR.L_cristal2 = value; }
    public override double calculateCurrentValue()
    {
        return Math.Min(main.CristalUpgrade[3].calculateCurrentValue()*5, 10000) * ((level) + Math.Pow(Math.Min(1.15 + main.CristalUpgrade[3].calculateCurrentValue() * level / 10000d, 1.45), (initValue + level * plusValue))) * Math.Min(level, 1);
    }
    public override double calculateCurrentValue(int level)
    {
        return Math.Min(main.CristalUpgrade[3].calculateCurrentValue()*5, 10000) * ((level) + Math.Pow(Math.Min(1.15 + main.CristalUpgrade[3].calculateCurrentValue() * level / 10000d, 1.45), (initValue + level * plusValue))) * Math.Min(level, 1);
    }
    public override double DPS()
    {
        return calculateCurrentValue();
    }
    private void Awake()
    {
        awakeText();
        thisAttribute = Attribute.crystal;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartUpgrade();
        gameObject.GetComponent<Button>().onClick.AddListener(calculate);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUpgrade();
        checkButton();
        if (window.activeSelf)
        {
            upgradeIcon.sprite = main.UpCrystalSpriteAry[4];
            currentValue = tDigit(main.idleBackGround.IdleDPS(thisAttribute), 1) + " / s";
            nextValue = tDigit(main.idleBackGround.IdleNextDPS(this), 1) + " / s";
            L_Upgrades.PU_crystal2(ref Name, ref effectExplain, ref explain);// +
                //            "<size=12>\n\n- Rough formula : A * ( [Train II] + B ^ [Train II] )" +
                //"\n-- A = 0 ~ 10K defined by [Train]" +
                //"\n-- B = 1.15 ~ 1.45 defined by [Train] & [Train II]";
        }
    }

    public override IEnumerator Effect()
    {
        while (true)
        {
            main.SR.cristal += calculateCurrentValue() * 0.1;
            main.S.totalGetCrystal += calculateCurrentValue() * 0.1;
            main.SR.crystalExp += calculateCurrentValue() * 0.1;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
