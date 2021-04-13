using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class C_stone3 : M_UPGRADE
{
    public override int level { get => main.SR.LC_stone3; set => main.SR.LC_stone3 = value; }
    public override double calculateCurrentValue()
    {
        return initValue + level * (level+1) * 0.5 * plusValue;
    }
    public override double calculateCurrentValue(int level)
    {
        return initValue + level * (level + 1) * 0.5 * plusValue;
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
        upgradeIcon.sprite = main.UpStoneSpriteAry[2];
        currentValue = tDigit(calculateCurrentValue(), 1) + "%";
        nextValue = tDigit(calculateNextValue(), 1) + "%";
        L_Upgrades.C_stone3(ref Name, ref effectExplain, ref explain);
    }
}
