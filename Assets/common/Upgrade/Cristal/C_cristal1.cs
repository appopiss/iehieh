using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class C_cristal1 : M_UPGRADE
{
    public override int level { get => main.SR.LC_cristal; set => main.SR.LC_cristal = value; }
    public override double calculateCurrentValue()
    {
        return (initValue + level * (plusValue + main.CristalUpgrade[1].calculateCurrentValue())) * (main.CristalUpgrade[2].calculateCurrentValue() / 100);
    }
    public override double calculateCurrentValue(int level)
    {
        return (initValue + level * (plusValue + main.CristalUpgrade[1].calculateCurrentValue())) * (main.CristalUpgrade[2].calculateCurrentValue() / 100);
    }
    private void Awake()
    {
        awakeText();
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
        upgradeIcon.sprite = main.UpCrystalSpriteAry[0];
        currentValue = tDigit(calculateCurrentValue(), 1) + " / click";
        nextValue = tDigit(calculateNextValue(), 1) + " / click";
        L_Upgrades.C_crystal1(ref Name, ref effectExplain, ref explain);
    }
}
