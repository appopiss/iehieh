using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class MATK_crystal : M_UPGRADE
{
    public override int level { get => main.SR.MatkCristal; set => main.SR.MatkCristal = value; }
    public override double calculateCurrentValue()
    {
        return initValue + level * (level + 1) * 0.5 * plusValue;
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
        upgradeIcon.sprite = main.UpStatusSpriteAry[1];
        currentValue = "MP + " + tDigit(calculateCurrentValue()*5) + " ,  MATK + " + tDigit(calculateCurrentValue());
        nextValue = "MP + " + tDigit(calculateNextValue()*5) + " ,  MATK + " + tDigit(calculateNextValue());
        L_Upgrades.matk(ref Name, ref effectExplain, ref explain);
    }

}
