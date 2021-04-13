using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using System;
using static UsefulMethod;
public class POPTEXT_SL : BASE
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
    public TextMeshProUGUI windowText2;
    [NonSerialized]
    public TextMeshProUGUI windowText3;
    [NonSerialized]
    public TextMeshProUGUI windowText4;
    [NonSerialized]
    public TextMeshProUGUI windowText5;
    [NonSerialized]
    public TextMeshProUGUI windowText6;
    [NonSerialized]
    public Image whiteLine;
    [NonSerialized]
    public TextMeshProUGUI windowText7;

    [NonSerialized]
    public GameObject window2;
    [NonSerialized]
    public TextMeshProUGUI window2Text0;
    [NonSerialized]
    public TextMeshProUGUI window2Text1;
    [NonSerialized]
    public TextMeshProUGUI window2Text2;
    [NonSerialized]
    public TextMeshProUGUI window2Text4;
    [NonSerialized]
    public TextMeshProUGUI window2Text5;
    [NonSerialized]
    public TextMeshProUGUI window2Text6;
    //[NonSerialized]
    //public TextMeshProUGUI window2CostText;

    //熟練度バー
    [NonSerialized]
    public Slider P_slider;
    //熟練度ボタン
    [NonSerialized]
    public Button P_button;
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


    public void awakeText()
    {
        StartBASE();
    }

    public void startText()
    {
        P_slider = transform.parent.GetComponentInChildren<Slider>();
        P_button = transform.parent.gameObject.GetComponentsInChildren<Button>()[0];

        window = Instantiate(main.P_texts[1], main.WindowShowCanvas);
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
        windowText2 = window.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        windowText3 = window.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        windowText4 = window.transform.GetChild(4).GetComponent<TextMeshProUGUI>();
        windowText5 = window.transform.GetChild(5).GetComponent<TextMeshProUGUI>();
        windowText6 = window.transform.GetChild(6).GetComponent<TextMeshProUGUI>();
        whiteLine = window.transform.GetChild(6).GetComponentInChildren<Image>();
        windowText7 = window.transform.GetChild(7).GetComponent<TextMeshProUGUI>();

        window2 = Instantiate(main.P_texts[2], main.WindowShowCanvas);
        P_button.gameObject.AddComponent<EventTrigger>().triggers = new List<EventTrigger.Entry>();
        EventTrigger.Entry entry3 = new EventTrigger.Entry();
        EventTrigger.Entry entry4 = new EventTrigger.Entry();
        entry3.eventID = EventTriggerType.PointerEnter;
        entry4.eventID = EventTriggerType.PointerExit;
        entry3.callback.AddListener((x) => { isOver2 = true; });
        entry4.callback.AddListener((x) => isOver2 = false); //ラムダ式の右側は追加するメソッドです。
        P_button.gameObject.GetComponent<EventTrigger>().triggers.Add(entry3);
        P_button.gameObject.GetComponent<EventTrigger>().triggers.Add(entry4);

        window2Text0 = window2.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        window2Text1 = window2.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        window2Text2 = window2.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        window2Text4 = window2.transform.GetChild(4).GetComponent<TextMeshProUGUI>();
        //window2CostText = window2.transform.GetChild(5).GetComponent<TextMeshProUGUI>();
        window2Text5 = window2.transform.GetChild(6).GetComponent<TextMeshProUGUI>();
        window2Text6 = window2.transform.GetChild(7).GetComponent<TextMeshProUGUI>();

        //SetTooltip();
    }



    public void updateText()
    {
        if (main.skillSetController.mouseObject != null)
        {
            setFalse(window);
            setFalse(window2);
            return;
        }

        if (!isOver)
        {
            setFalse(window);
        }
        if (!isOver2)
        {
            setFalse(window2);
        }
        if (isOver)
        {
            setActive(window);
            //window1
            windowText0.text = SkillLocal.BaseForName(skillNameString);
            windowText1.text = SkillLocal.BaseForLinage(linageString);
            windowText2.text = SkillLocal.EffectString();
            windowText3.text = effectString;
            windowText4.text = SkillLocal.DescriptionString();
            windowText5.text = explainString;
            windowText6.text = requiredAndPassiveString;
            windowText7.text = requiredSkillString;
            LocalizeInitialize.SetFont(windowText0, windowText1, windowText2, windowText3, windowText4, windowText5, windowText6, windowText7);


            //if (window != null)
            //{
            //if (Input.mousePosition.y >= 300 && Input.mousePosition.x >= 400)
            //{
            //    window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(-250.0f, -50.0f);
            //}
            //else if (Input.mousePosition.y >= 300 && Input.mousePosition.x < 400)
            //{
            //    window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(50.0f, -50.0f);
            //}
            //else if (Input.mousePosition.y < 300 && Input.mousePosition.x > 400)
            //{
            //    window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(-250.0f, 50.0f);
            //}
            //else if (Input.mousePosition.y < 300 && Input.mousePosition.x < 400)
            //{
            //    window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(50.0f, 50f);
            //}

            //}

        }
        else if (isOver2)
        {
            setActive(window2);
            //window2
            window2Text0.text = skillNameString;
            window2Text1.text = "- Lineage : " + linageString;
            window2Text2.text = "- Proficiency : " + proficiencyString;
            window2Text4.text = costString;
            window2Text6.text = requiredSkillString;
            LocalizeInitialize.SetFont(window2Text0, window2Text1, window2Text2, window2Text4, window2Text6);


            //if (window2 != null)
            //{
            //if (Input.mousePosition.y >= 300 && Input.mousePosition.x >= 400)
            //{
            //    window2.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(-250.0f, -50.0f);
            //}
            //else if (Input.mousePosition.y >= 300 && Input.mousePosition.x < 400)
            //{
            //    window2.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(50.0f, -50.0f);
            //}
            //else if (Input.mousePosition.y < 300 && Input.mousePosition.x > 400)
            //{
            //    window2.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(-250.0f, 50.0f);
            //}
            ////第3象限
            //else if (Input.mousePosition.y < 300 && Input.mousePosition.x < 400)
            //{
            //    window2.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(50.0f, 50f);
            //}
            //}
        }
    }



}
