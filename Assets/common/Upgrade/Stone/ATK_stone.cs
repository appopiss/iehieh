using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class ATK_stone : M_UPGRADE
{
    public override int level { get => main.SR.AtkStone; set => main.SR.AtkStone = value; }
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
        upgradeIcon.sprite = main.UpStatusSpriteAry[0];
        currentValue = "HP + " + tDigit(calculateCurrentValue()*5) + " ,  ATK + " + tDigit(calculateCurrentValue());
        nextValue = "HP + " + tDigit(calculateNextValue()*5) + " ,  ATK + " + tDigit(calculateNextValue());
        L_Upgrades.atk(ref Name, ref effectExplain, ref explain);
    }

}
