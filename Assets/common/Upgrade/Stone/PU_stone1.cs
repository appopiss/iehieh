using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class PU_stone1 : M_UPGRADE
{
    public override int level { get => main.SR.L_stone; set => main.SR.L_stone = value; }
    public override double calculateCurrentValue()
    {
        return (initValue + level * plusValue) * main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.graduate].calculateCurrentValue();
        //return (initValue + main.Ascends[1].calculateCurrentValue() + level * plusValue)*main.Ascends[2].calculateCurrentValue();
    }
    public override double calculateCurrentValue(int level)
    {
        return (initValue + level * plusValue) * main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.graduate].calculateCurrentValue();
        //return (initValue + main.Ascends[1].calculateCurrentValue() + level * plusValue) * main.Ascends[2].calculateCurrentValue();
    }
    public override double DPS()
    {
        return calculateCurrentValue();
    }

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
        upgradeIcon.sprite = main.UpStoneSpriteAry[3];
        if (window.activeSelf)
        {
            L_Upgrades.PU_stone1(ref Name, ref effectExplain, ref explain);
        }
        currentValue = tDigit(main.idleBackGround.IdleDPS(thisAttribute), 1) + " / s";
        nextValue = tDigit(main.idleBackGround.IdleNextDPS(this), 1) + " / s";
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
