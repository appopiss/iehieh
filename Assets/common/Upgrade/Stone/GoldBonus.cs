using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class GoldBonus : M_UPGRADE
{
    public override int level { get => main.SR.GoldBonusUp; set => main.SR.GoldBonusUp = value; }
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
        upgradeIcon.sprite = main.UpStatusSpriteAry[4];
        currentValue = "+ " + tDigit(calculateCurrentValue());
        nextValue = "+ " + tDigit(calculateNextValue());
        L_Upgrades.gold(ref Name, ref effectExplain, ref explain);
    }

}
