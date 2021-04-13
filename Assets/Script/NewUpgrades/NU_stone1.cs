using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class NU_stone1 : NewUPGRADE
{
    //public override int level { get => main.SR.N_stone1; set => main.SR.N_stone1 = value; }
    //public override int S_level { get => main.SR.NS_stone1; set => main.SR.NS_stone1 = value; }
    ////public override double calculateCurrentValue()
    ////{
    ////    return (initValue + main.Ascends[1].calculateCurrentValue() + level * plusValue) * main.Ascends[2].calculateCurrentValue();
    ////}
    ////public override double calculateCurrentValue(int level)
    ////{
    ////    return (initValue + main.Ascends[1].calculateCurrentValue() + level * plusValue) * main.Ascends[2].calculateCurrentValue();
    ////}

    //private void Awake()
    //{
    //    awakeText();
    //}
    //// Start is called before the first frame update
    //void Start()
    //{
    //    startText();
    //    StartUpgrade();
    //    //gameObject.GetComponent<Button>().onClick.AddListener(calculate);
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    updateText();
    //    checkButton();
    //    upgradeIcon.sprite = main.UpStoneSpriteAry[3];
    //    Name = "Shovel";
    //    effectExplain = "Gain stones";
    //    currentValue = tDigit(calculateCurrentValue(), 1) + " / s";
    //    nextValue = tDigit(calculateNextValue(), 1) + " / s";
    //    explain = "Get stones automatically.\n  Stones are mainly used for warrior's skills.";
    //    if (calculateCurrentValue() != 0)
    //        thisText.text = tDigit(SliderFactor(),1) + " Stone / " + (1.0f / calculateCurrentValue()).ToString("F1") + " s";
    //    else
    //        thisText.text = "";
    //}

    //public override void SliderAction()
    //{
    //    main.SR.stone += SliderFactor();
    //}

    //public override double SliderFactor()
    //{
    //    return (1.0 + main.Nstones[1].SliderFactor()) *main.idleBackGround.StoneCombo();
    //}
}
