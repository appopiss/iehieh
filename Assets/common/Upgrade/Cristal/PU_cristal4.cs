using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using static UsefulMethod;

public class PU_cristal4 : M_UPGRADE
{
    public override int level { get => main.SR.L_cristal4; set => main.SR.L_cristal4 = value; }
    public override double calculateCurrentValue()
    {
        return initValue + level * plusValue;
    }
    public override double calculateCurrentValue(int level)
    {
        return initValue + level * plusValue;
    }
    //public override double DPS()
    //{
    //    return calculateCurrentValue();
    //}
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
            upgradeIcon.sprite = main.UpCrystalSpriteAry[6];
            currentValue = tDigit(main.idleBackGround.IdleDPS(thisAttribute), 1) + " / s";
            nextValue = tDigit(main.idleBackGround.IdleNextDPS(this), 1) + " / s";
            L_Upgrades.PU_crystal4(ref Name, ref effectExplain, ref explain);// +
                //"<size=12>\n\n- Rough formula : A * ( [Enchant] + B ^ [Enchant] )" +
                //"\n-- A = 1M ~ 1T defined by [Synthesizing amount / click]" +
                //"\n-- B = 1.65 ~ 4.00 defined by [Train], [Train II], [Train III] & [Enchant]";
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
