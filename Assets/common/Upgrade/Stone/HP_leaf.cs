using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class HP_leaf : M_UPGRADE
{
    public override int level { get => main.SR.HpLeaf; set => main.SR.HpLeaf = value; }
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
        upgradeIcon.sprite = main.UpStatusSpriteAry[2];
        currentValue = "DEF + " + tDigit(calculateCurrentValue()/4) + " ,  MDEF + " + tDigit(calculateCurrentValue()/4) + " ,  SPD + " + tDigit(calculateCurrentValue()*5);
        nextValue = "DEF + " + tDigit(calculateNextValue()/4) + " ,  MDEF + " + tDigit(calculateNextValue()/4) + " ,  SPD + " + tDigit(calculateNextValue() * 5);
        L_Upgrades.defspd(ref Name, ref effectExplain, ref explain);
    }

}
