using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class C_stone2 : M_UPGRADE
{
    public override int level { get => main.SR.LC_stone2; set => main.SR.LC_stone2 = value; }
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
        upgradeIcon.sprite = main.UpStoneSpriteAry[1];
        currentValue = tDigit(main.StoneUpgrade[0].plusValue + calculateCurrentValue(), 1) + " / Mining level";
        nextValue = tDigit(main.StoneUpgrade[0].plusValue + calculateNextValue(), 1) + " / Mining level";
        L_Upgrades.C_stone2(ref Name, ref effectExplain, ref explain);
    }
}
