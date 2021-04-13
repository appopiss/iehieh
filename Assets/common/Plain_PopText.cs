﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;

public class Plain_PopText : BASE
{
    public GameObject window;
    public Vector3 AdjustVector1, AdjustVector2, AdjustVector3, AdjustVector4;
    public Func<bool> ActiveCondition = () => true;
    [TextAreaAttribute(10,100)]//height:10,width:100
    public string text;

    private void Awake()
    {
        StartBASE();
    }

    private void Start()
    {
        startText();
    }

    private void Update()
    {
        updateText();
    }

    public void startText()
    {
        if(window == null)
            window = Instantiate(main.plainPopText, main.WindowShowCanvas);
        else
            window = Instantiate(window, main.WindowShowCanvas);
        gameObject.AddComponent<EventTrigger>().triggers = new List<EventTrigger.Entry>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry2.eventID = EventTriggerType.PointerExit;
        entry.callback.AddListener((x) => UsefulMethod.setActive(window, ActiveCondition()));
        entry2.callback.AddListener((x) => UsefulMethod.setFalse(window)); //ラムダ式の右側は追加するメソッドです。
        gameObject.AddComponent<EventTrigger>().triggers.Add(entry);
        gameObject.AddComponent<EventTrigger>().triggers.Add(entry2);
    }
    public void updateText()
    {
        if (window.activeSelf)
        {
            window.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = text;

            //if (window != null)
            //{
            //    if (Input.mousePosition.y >= 300 && Input.mousePosition.x >= 400)
            //    {
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(80f, -40.0f) + AdjustVector1;
            //    }
            //    else if (Input.mousePosition.y >= 300 && Input.mousePosition.x < 400)
            //    {
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(80f, -40.0f) + AdjustVector2;
            //    }
            //    else if (Input.mousePosition.y < 300 && Input.mousePosition.x > 400)
            //    {
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(-120f, 40.0f) + AdjustVector4;
            //    }
            //    else if (Input.mousePosition.y < 300 && Input.mousePosition.x < 400)
            //    {
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(80f, 40.0f) + AdjustVector3;
            //    }
            //}

        }

    }


}
