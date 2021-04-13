using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using System;
using static UsefulMethod;
public class POPTEXT_Passive : BASE
{
    [NonSerialized]
    public GameObject window;
    [NonSerialized]
    public Image windowSkillIcon;
    [NonSerialized]
    public TextMeshProUGUI windowText0;
    [NonSerialized]
    public TextMeshProUGUI windowText1;
    [NonSerialized]
    public TextMeshProUGUI windowText3;
    [NonSerialized]
    public TextMeshProUGUI windowText5;
    [NonSerialized]
    public TextMeshProUGUI windowText6;
    [NonSerialized]
    public TextMeshProUGUI windowText7;


    [NonSerialized]
    public Transform windowParent;
    [NonSerialized]
    public string skillNameString;
    [NonSerialized]
    public string linageString;
    [NonSerialized]
    public string effectString;
    [NonSerialized]
    public string explainString;
    [NonSerialized]
    public string requiredAndPassiveString;
    [NonSerialized]
    public string requiredSkillString;
    [NonSerialized]
    public string proficiencyString;
    [NonSerialized]
    public string costString;
    [NonSerialized]
    public bool isOver;
    [NonSerialized]
    public bool isOver2;


    public bool onlyDisplay;

    public void awakeText()
    {
        StartBASE();
    }

    public void startText()
    {
        window = Instantiate(main.P_texts[21], main.WindowShowCanvas); 
        gameObject.AddComponent<EventTrigger>().triggers = new List<EventTrigger.Entry>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry2.eventID = EventTriggerType.PointerExit;
        entry.callback.AddListener((x) => { isOver = true; });
        entry2.callback.AddListener((x) => isOver = false); //ラムダ式の右側は追加するメソッドです。
        gameObject.GetComponent<EventTrigger>().triggers.Add(entry);
        gameObject.GetComponent<EventTrigger>().triggers.Add(entry2);

        windowSkillIcon = window.transform.GetChild(0).GetComponentInChildren<Image>();
        windowText0 = window.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        windowText1 = window.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        windowText3 = window.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        windowText5 = window.transform.GetChild(5).GetComponent<TextMeshProUGUI>();
        //windowText6 = window.transform.GetChild(6).GetComponent<TextMeshProUGUI>();
        //windowText7 = window.transform.GetChild(7).GetComponent<TextMeshProUGUI>();
    }

    public void updateText()
    {
        if (main.skillSetController.mouseObject != null)
        {
            setFalse(window);
            return;
        }

        if (!isOver)
        {
            setFalse(window);
        }
        else if (isOver)
        {
            setActive(window);
            //window1
            windowText0.text = "             " + skillNameString;
            windowText1.text = "                  Status : " + linageString + "\n   ";
            windowText3.text = effectString;
            windowText5.text = explainString;
            //windowText6.text = requiredAndPassiveString;
            //windowText7.text = requiredSkillString;


            //if (window != null)
            //{
            //    if (Input.mousePosition.y >= 300 && Input.mousePosition.x >= 400)
            //    {
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(-250.0f, -50.0f);
            //    }
            //    else if (Input.mousePosition.y >= 300 && Input.mousePosition.x < 400)
            //    {
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(50.0f, -50.0f);
            //    }
            //    else if (Input.mousePosition.y < 300 && Input.mousePosition.x > 400)
            //    {
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(-380.0f, 50.0f);
            //    }
            //    else if (Input.mousePosition.y < 300 && Input.mousePosition.x < 400)
            //    {
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(50.0f, 50f);
            //    }
            //}

        }
    }


}
