using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using static UsefulMethod;
using TMPro;
using static ArtiCtrl;

public class AlchemyPointBar : BASE
{
    public Button UpButton;
    public TextMeshProUGUI valueText;
    public TextMeshProUGUI StatsText;
    public Slider StatusSlider;
    bool isClick;
    public int Index;
    // Use this for initialization
    void Awake()
    {
        StartBASE();
    }
    // Use this for initialization
    void Start()
    {
        UpButton.gameObject.AddComponent<EventTrigger>().triggers = new List<EventTrigger.Entry>();
        EventTrigger.Entry click = new EventTrigger.Entry();
        EventTrigger.Entry click2 = new EventTrigger.Entry();
        EventTrigger.Entry click3 = new EventTrigger.Entry();
        click.eventID = EventTriggerType.PointerDown;
        click2.eventID = EventTriggerType.PointerClick;
        click3.eventID = EventTriggerType.PointerExit;
        click.callback.AddListener((x) => StartCoroutine(getValueFirst()));
        click2.callback.AddListener((x) => { isClickFirst = false; isClick = false; });
        click3.callback.AddListener((x) => { isClickFirst = false; isClick = false; });//ラムダ式の右側は追加するメソッドです。
        UpButton.gameObject.GetComponent<EventTrigger>().triggers.Add(click);
        UpButton.gameObject.GetComponent<EventTrigger>().triggers.Add(click2);
        UpButton.gameObject.GetComponent<EventTrigger>().triggers.Add(click3);
        ShowStats();
        StartCoroutine(RaiseStatus());
    }

    bool isClickFirst;

    IEnumerator getValueFirst()
    {
        if (main.alchemyController.alchemyPoint() <= 0)
            yield break;

        isClickFirst = true;
        valueUp(1);
        for (int i = 0; i < 5; i++)
        {
            if (!isClickFirst)
                break;
            yield return new WaitForSeconds(0.02f);
        }
        if (!isClickFirst)
            yield break;
        if (main.alchemyController.alchemyPoint() <= 0)
            yield break;
        valueUp(1);

        for (int i = 0; i < 3; i++)
        {
            if (!isClickFirst)
                break;
            yield return new WaitForSeconds(0.02f);
        }
        if (!isClickFirst)
            yield break;
        if (main.alchemyController.alchemyPoint() <= 0)
            yield break;
        valueUp(1);

        for (int i = 0; i < 2; i++)
        {
            if (!isClickFirst)
                break;
            yield return new WaitForSeconds(0.02f);
        }
        if (!isClickFirst)
            yield break;
        if (main.alchemyController.alchemyPoint() <= 0)
            yield break;
        valueUp(1);

        for (int i = 0; i < 1; i++)
        {
            if (!isClickFirst)
                break;
            yield return new WaitForSeconds(0.02f);
        }
        if (!isClickFirst)
            yield break;
        if (main.alchemyController.alchemyPoint() <= 0)
            yield break;
        valueUp(1);

        yield return new WaitForSeconds(0.02f);
        if (!isClickFirst)
            yield break;
        if (main.alchemyController.alchemyPoint() <= 0)
            yield break;
        isClick = true;        
    }

    double cost()
    {
        switch (Index)
        {
            case 0:
                return 2 + main.S.vitalityLevel * 3 + Math.Floor(Math.Pow(main.S.vitalityLevel / 50d, 2));
            case 1:
                return 5 + main.S.muscleLevel * 5 + Math.Floor(Math.Pow(main.S.muscleLevel / 10d, 2));
            case 2:
                return 5 + main.S.wisdomLevel * 5 + Math.Floor(Math.Pow(main.S.wisdomLevel / 10d, 2));
            case 3:
                return 2 + main.S.agilityLevel * 3 + Math.Floor(Math.Pow(main.S.agilityLevel / 25d, 2));
            default:
                return 99999999;
        }
    }
    double value()
    {
        switch (Index)
        {
            case 0:
                return main.S.vitalityValue;
            case 1:
                return main.S.muscleValue;
            case 2:
                return main.S.wisdomValue;
            case 3:
                return main.S.agilityValue;
            default:
                return 99999999;
        }
    }
    void ValueReset()
    {
        switch (Index)
        {
            case 0:
                main.S.vitalityValue=0;
                break;
            case 1:
                main.S.muscleValue=0;
                break;
            case 2:
                main.S.wisdomValue=0;
                break;
            case 3:
                main.S.agilityValue=0;
                break;
            default:
                break;
        }
    }
    void LevelUp()
    {
        switch (Index)
        {
            case 0:
                main.S.vitalityLevel+=1;
                break;
            case 1:
                main.S.muscleLevel+=1;
                break;
            case 2:
                main.S.wisdomLevel+=1;
                break;
            case 3:
                main.S.agilityLevel+=1;
                break;
            default:
                break;
        }
    }
    void ShowStats()
    {
        switch (Index)
        {
            case 0:
                StatsText.text = "HP,MP + " + tDigit(main.S.vitalityLevel);
                break;
            case 1:
                StatsText.text = "ATK,DEF + " + tDigit(main.S.muscleLevel);
                break;
            case 2:
                StatsText.text = "MATK,MDEF + " + tDigit(main.S.wisdomLevel);
                break;
            case 3:
                StatsText.text = "SPD + " + tDigit(main.S.agilityLevel);
                break;
            default:
                break;
        }
    }
    void valueUp(double factor)
    {
        switch (Index)
        {
            case 0:
                main.S.vitalityValue += 1 * factor;
                break;
            case 1:
                main.S.muscleValue += 1 * factor;
                break;
            case 2:
                main.S.wisdomValue += 1 * factor;
                break;
            case 3:
                main.S.agilityValue += 1 * factor;
                break;
            default:
                break;
        }
        main.S.consumedAlchemyPoint += 1 * factor;
    }

    public IEnumerator RaiseStatus()
    {
        while (true)
        {
            if (main.alchemyController.alchemyPoint() > 0)
            {
                UpButton.interactable = true;
                if (ZC(main.alchemyController.alchemyPoint() / cost()) >50)
                {
                    if (isClick)
                    {
                        valueUp(Math.Max(cost(), 1));
                    }
                }
                else if (ZC(main.alchemyController.alchemyPoint() / cost()) > 20)
                {
                    if (isClick)
                    {
                        valueUp(Math.Max(cost() / 2,1));
                    }
                }
                else if (ZC(main.alchemyController.alchemyPoint() / cost()) > 10)
                {
                    if (isClick)
                    {
                        valueUp(Math.Max(cost() / 4,1));
                    }
                }
                else if (ZC(main.alchemyController.alchemyPoint() / cost()) > 5)
                {
                    if (isClick)
                    {
                        valueUp(Math.Max(cost() / 8,1));
                    }
                }
                else if (ZC(main.alchemyController.alchemyPoint() / cost()) > 2)
                {
                    if (isClick)
                    {
                        valueUp(Math.Max(cost() / 10,1));
                    }
                }
                else if (ZC(main.alchemyController.alchemyPoint() / cost()) > 1)
                {
                    if (isClick)
                    {
                        valueUp(Math.Max(cost() / 20,1));
                    }
                }
                else if (ZC(main.alchemyController.alchemyPoint() / cost()) > 0.5)
                {
                    if (isClick)
                    {
                        valueUp(Math.Max(cost() / 40,1));
                    }
                }
                else if (ZC(main.alchemyController.alchemyPoint() / cost()) > 0.1)
                {
                    if (isClick)
                    {
                        valueUp(Math.Max(cost() / 100,1));
                    }
                }
                else if (ZC(main.alchemyController.alchemyPoint() / cost()) > 0.01)
                {
                    if (isClick)
                    {
                        valueUp(Math.Max(cost() / 1000,1));
                    }
                }
                else
                {
                    if (isClick)
                    {
                        valueUp(1);
                    }
                }
            }
            else
            {
                UpButton.interactable = false;
            }
            StatusSlider.value = (float)(value() / cost());
            valueText.text = tDigit(value()) + " / " + tDigit(cost());
            if (value() >= cost())
            {
                ValueReset();
                LevelUp();
                ShowStats();
            }
            yield return new WaitForSeconds(0.01666f);
        }
    }


    private void Update()
    {
        
    }


}
