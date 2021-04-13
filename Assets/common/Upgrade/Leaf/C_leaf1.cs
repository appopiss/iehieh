using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class C_leaf1 : M_UPGRADE
{
    public override int level { get => main.SR.LC_leaf; set => main.SR.LC_leaf = value; }
    public override double calculateCurrentValue()
    {
        return (initValue + level * (plusValue + main.LeafUpgrade[1].calculateCurrentValue())) * (main.LeafUpgrade[2].calculateCurrentValue() / 100);
    }
    public override double calculateCurrentValue(int level)
    {
        return (initValue + level * (plusValue + main.LeafUpgrade[1].calculateCurrentValue())) * (main.LeafUpgrade[2].calculateCurrentValue() / 100);
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
        upgradeIcon.sprite = main.UpLeafSpriteAry[0];
        L_Upgrades.C_Leaf1(ref Name, ref effectExplain, ref explain);
        currentValue = tDigit(calculateCurrentValue(), 1) + " / click";
        nextValue = tDigit(calculateNextValue(), 1) + " / click";
    }
}
