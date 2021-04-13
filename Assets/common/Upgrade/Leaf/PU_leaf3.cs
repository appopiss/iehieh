using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using static UsefulMethod;

public class PU_leaf3 : M_UPGRADE
{
    public override int level { get => main.SR.L_leaf3; set => main.SR.L_leaf3 = value; }
    public override double calculateCurrentValue()
    {
        return Math.Min(main.LeafUpgrade[3].calculateCurrentValue() * main.LeafUpgrade[4].level * 50 * (1+main.LeafUpgrade[6].calculateCurrentValue()), 1000000000)
            * ((level * 10000) + Math.Pow(Math.Min(1.45 + main.LeafUpgrade[4].level * (level + main.LeafUpgrade[6].calculateCurrentValue()) / 30000d, 3), (20 + initValue + level * plusValue + main.LeafUpgrade[6].calculateCurrentValue() * 2)))
            * Math.Min(level, 1) * (1 + main.LeafUpgrade[3].calculateCurrentValue() / 1000)
            * (1 + main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.lEnhance].TotalEffect());
    }
    public override double calculateCurrentValue(int level)
    {
        return Math.Min(main.LeafUpgrade[3].calculateCurrentValue() * main.LeafUpgrade[4].level * 50 * (1 + main.LeafUpgrade[6].calculateCurrentValue()), 1000000000)
            * ((level * 10000) + Math.Pow(Math.Min(1.45 + main.LeafUpgrade[4].level * (level + main.LeafUpgrade[6].calculateCurrentValue()) / 30000d, 3), (20 + initValue + level * plusValue + main.LeafUpgrade[6].calculateCurrentValue() * 2)))
            * Math.Min(level, 1) * (1 + main.LeafUpgrade[3].calculateCurrentValue() / 1000)
            * (1 + main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.lEnhance].TotalEffect());
    }
    public override double DPS()
    {
        return calculateCurrentValue();
    }
    private void Awake()
    {
        awakeText();
        thisAttribute = Attribute.leaf;
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
            upgradeIcon.sprite = main.UpLeafSpriteAry[5];
            currentValue = tDigit(main.idleBackGround.IdleDPS(thisAttribute), 1) + " / s";
            nextValue = tDigit(main.idleBackGround.IdleNextDPS(this), 1) + " / s";
            L_Upgrades.PU_leaf3(ref Name, ref effectExplain, ref explain);// +
                //            "<size=12>\n\n- Rough formula : A * ( [Train III] + B ^ [Train III] )" +
                //"\n-- A = 0 ~ 1B defined by [Train I] & [Train II]" +
                //"\n-- B = 1.45 ~ 3.00 defined by [Train II] & [Train III]";
        }
    }

    public override IEnumerator Effect()
    {
        while (true)
        {
            main.SR.leaf += calculateCurrentValue() * 0.1;
            main.S.totalGetLeaf += calculateCurrentValue() * 0.1;
            main.SR.leafExp += calculateCurrentValue() * 0.1;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
