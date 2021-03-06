using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Storage3 : M_UPGRADE
{
    public override int level { get => main.SR.Storage3; set => main.SR.Storage3 = value; }

    private void Awake()
    {
        awakeText();
    }
    // Start is called before the first frame update
    void Start()
    {
        startText();
        StartUpgrade();
        gameObject.GetComponent<Button>().onClick.AddListener(calculate);
    }

    // Update is called once per frame
    void Update()
    {
        updateText();
        checkButton();
        upgradeIcon.sprite = main.UpStoneSpriteAry[3];
        Name = "Storage3";
        effectExplain = "Increase the CAP of gold + 2000";
        currentValue = "Gold Cap + " + tDigit(calculateCurrentValue());
        nextValue = "Gold Cap + " + tDigit(calculateNextValue());
        explain = "Get stones automatically.\n  Stones are mainly used for warrior's skills.";
    }

}
