﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;

public class POP_material : BASE
{
    public GameObject window;
    [TextAreaAttribute(10, 100)]//height:10,width:100
    public string Name;
    public string MaterialNum;
    public TextMeshProUGUI materialNumText;

    private void Awake()
    {
        StartBASE();
    }
    private void Start()
    {
        startText();
        materialNumText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        updateText();
    }

    public void startText()
    {
        window = Instantiate(main.P_texts[6], main.WindowShowCanvas);
        gameObject.AddComponent<EventTrigger>().triggers = new List<EventTrigger.Entry>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry2.eventID = EventTriggerType.PointerExit;
        entry.callback.AddListener((x) => UsefulMethod.setActive(window));
        entry2.callback.AddListener((x) => UsefulMethod.setFalse(window)); //ラムダ式の右側は追加するメソッドです。
        gameObject.AddComponent<EventTrigger>().triggers.Add(entry);
        gameObject.AddComponent<EventTrigger>().triggers.Add(entry2);
    }
    public void updateText()
    {
        window.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Name;

        //if (window != null)
        //{
        //    if (Input.mousePosition.y >= 300 && Input.mousePosition.x >= 400)
        //    {
        //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(-300.0f, -50.0f);
        //    }
        //    else if (Input.mousePosition.y >= 300 && Input.mousePosition.x < 400)
        //    {
        //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(50.0f, -50.0f);
        //    }
        //    else if (Input.mousePosition.y < 300 && Input.mousePosition.x > 400)
        //    {
        //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(-300.0f, 50.0f);
        //    }
        //    else if (Input.mousePosition.y < 300 && Input.mousePosition.x < 400)
        //    {
        //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(50.0f, 50.0f);
        //    }
        //}
    }


}
