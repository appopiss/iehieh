using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class C_leaf2 : M_UPGRADE
{
    public override int level { get => main.SR.LC_leaf2; set => main.SR.LC_leaf2 = value; }
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
        upgradeIcon.sprite = main.UpLeafSpriteAry[1];
        currentValue = tDigit(main.LeafUpgrade[0].plusValue + calculateCurrentValue(), 1) + " / Click Tree level";
        nextValue = tDigit(main.LeafUpgrade[0].plusValue + calculateNextValue(), 1) + " / Click Tree level";
        L_Upgrades.C_Leaf2(ref Name, ref effectExplain, ref explain);
    }
}
