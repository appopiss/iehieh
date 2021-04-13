using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using static UsefulMethod;


public class LevelUnlock : BASE {

    public GameObject window;
    public int UnlockNum = 0;
    public int thisLevel = 0;
    Vector2 initialPos = new Vector2(0, 0);
    Vector2 HidePos = new Vector2(-1000, 0);
    Button button;
    //public List<MS> MSlist;

    public void InstantiateWindow()
    {
        window = Instantiate(main.plainPopText, gameObject.transform.parent);
        gameObject.AddComponent<EventTrigger>().triggers = new List<EventTrigger.Entry>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry2.eventID = EventTriggerType.PointerExit;
        entry.callback.AddListener((x) => UsefulMethod.setActive(window, () => TotalClearNum() < UnlockNum));
        entry2.callback.AddListener((x) => UsefulMethod.setFalse(window)); //ラムダ式の右側は追加するメソッドです。
        gameObject.GetComponent<EventTrigger>().triggers.Add(entry);
        gameObject.GetComponent<EventTrigger>().triggers.Add(entry2);
    }

    public void OnButton()
    {
        for (int i = 0; i < main.cc.LevelCanvas.Length; i++)
        {
            main.cc.LevelCanvas[i].anchoredPosition = HidePos;
        }
        main.cc.LevelCanvas[thisLevel].anchoredPosition = initialPos;
    }

    private void Awake()
    {
        StartBASE();
        InstantiateWindow();
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(() => OnButton());
    }

    long TotalClearNum()
    {
        long unko = 0;
        for (int i = 0; i < main.S.CurseReinClearNum.Length; i++)
        {
            unko += main.S.CurseReinClearNum[i];
        }
        return unko;
    }

    void updateText()
    {
        if (!window.activeSelf)
            return;

        StringBuilder text = new StringBuilder();
        text.Append("Unlock with total curse cleared " + UnlockNum + " times");

        window.GetComponentInChildren<TextMeshProUGUI>().text = text.ToString();
        //if (window != null)
        //{
        //    if (Input.mousePosition.y >= 300 && Input.mousePosition.x >= 400)
        //    {
        //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300);
        //    }
        //    else if (Input.mousePosition.y >= 300 && Input.mousePosition.x < 400)
        //    {
        //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300);
        //    }
        //    else if (Input.mousePosition.y < 300 && Input.mousePosition.x > 400)
        //    {
        //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300);
        //    }
        //    else if (Input.mousePosition.y < 300 && Input.mousePosition.x < 400)
        //    {
        //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300);
        //    }
        //}

    }

    private void Update()
    {
        updateText();
        if(TotalClearNum() < UnlockNum)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }
}
