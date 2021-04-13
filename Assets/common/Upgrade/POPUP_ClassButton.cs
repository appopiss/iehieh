using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using static UsefulMethod;
public class POPUP_ClassButton : BASE
{
    public GameObject window;
    public bool isOver;
    public TextMeshProUGUI text1, text2;

    public void Awake()
    {
        StartBASE();
    }

    public void Start()
    {
        gameObject.AddComponent<EventTrigger>().triggers = new List<EventTrigger.Entry>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry2.eventID = EventTriggerType.PointerExit;
        entry.callback.AddListener((x) => { isOver = true; });
        entry2.callback.AddListener((x) => isOver = false); //ラムダ式の右側は追加するメソッドです。
        gameObject.GetComponent<EventTrigger>().triggers.Add(entry);
        gameObject.GetComponent<EventTrigger>().triggers.Add(entry2);
        text1 = window.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        text2 = window.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    public void Update()
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
        if (isOver)
        {
            setActive(window);
            Title.ClassExplanation(text1, text2);
        }
    }


}
