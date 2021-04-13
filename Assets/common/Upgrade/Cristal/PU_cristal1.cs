using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class PU_cristal1 : M_UPGRADE
{
    public override int level { get => main.SR.L_cristal; set => main.SR.L_cristal = value; }
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
        if (!window.activeSelf)
            return;
        upgradeIcon.sprite = main.UpCrystalSpriteAry[3];
        if (window.activeSelf)
        {
            currentValue = tDigit(main.idleBackGround.IdleDPS(thisAttribute), 1) + " / s";
            nextValue = tDigit(main.idleBackGround.IdleNextDPS(this), 1) + " / s";
            L_Upgrades.PU_crystal1(ref Name, ref effectExplain, ref explain);
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
