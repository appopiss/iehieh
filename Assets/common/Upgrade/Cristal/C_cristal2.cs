using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class C_cristal2 : M_UPGRADE
{
    public override int level { get => main.SR.LC_cristal2; set => main.SR.LC_cristal2 = value; }
    public override double calculateCurrentValue()
    {
        return initValue + level * plusValue;
    }
    public override double calculateCurrentValue(int level)
    {
        return initValue + level * plusValue;
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
        upgradeIcon.sprite = main.UpCrystalSpriteAry[1];
        currentValue = tDigit(main.CristalUpgrade[0].plusValue + calculateCurrentValue(), 1) + " / Click Laboratory level";
        nextValue = tDigit(main.CristalUpgrade[0].plusValue + calculateNextValue(), 1) + " / Click Laboratory level";
        L_Upgrades.C_crystal2(ref Name, ref effectExplain, ref explain);
    }
}
