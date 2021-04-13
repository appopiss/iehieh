using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using static UsefulMethod;

public class PU_stone4 : M_UPGRADE
{
    public override int level { get => main.SR.L_stone4; set => main.SR.L_stone4 = value; }
    public override double calculateCurrentValue()
    {
        //return main.StoneUpgrade[3].level * 1000 * ((main.StoneUpgrade[4].level * main.StoneUpgrade[5].level * level ) + Math.Pow( Math.Min(( 1.40 + main.StoneUpgrade[4].level * main.StoneUpgrade[5].level / 30000d ) , 1.75), (initValue + level * plusValue))) * Math.Min(level, 1);
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
        thisAttribute = Attribute.stone;
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
        if (!window.activeSelf)
            return;
        upgradeIcon.sprite = main.UpStoneSpriteAry[6];
       // if (window.activeSelf)
       // {
            currentValue = tDigit(main.idleBackGround.IdleDPS(thisAttribute), 1) + " / s";
            nextValue = tDigit(main.idleBackGround.IdleNextDPS(this), 1) + " / s";
        L_Upgrades.PU_stone4(ref Name, ref effectExplain, ref explain);
                //"<size=12>\n\n- Rough formula : A * ( [Enchant] + B ^ [Enchant] )" +
                //"\n-- A = 1M ~ 1T defined by [Mining amount / click]" +
                //"\n-- B = 3.00 ~ 4.00 defined by [Train], [Train II], [Train III] & [Enchant]";
       // }
    }

    public override IEnumerator Effect()
    {
        while (true)
        {
            main.SR.stone += calculateCurrentValue() * 0.1;
            main.S.totalGetStone += calculateCurrentValue() * 0.1;
            main.SR.stoneExp += calculateCurrentValue() * 0.1;

            yield return new WaitForSeconds(0.1f);
        }
    }
}
