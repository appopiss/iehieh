using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class EquipmentSlotUpgrade : M_UPGRADE
{
    public override int level { get => main.SR.EquipSlotUp; set => main.SR.EquipSlotUp = value; }
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
        upgradeIcon.sprite = main.UpStatusSpriteAry[3];
        currentValue = "+ " + tDigit(calculateCurrentValue());
        nextValue = "+ " + tDigit(calculateNextValue());
        L_Upgrades.equip(ref Name, ref effectExplain, ref explain);
    }

}