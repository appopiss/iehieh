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

public class CurseReinMileStone : BASE
{

    public GameObject window;
    //public List<MS> MSlist;

    public void InstantiateWindow()
    {
        window = Instantiate(main.P_texts[31], gameObject.transform.parent);
        gameObject.AddComponent<EventTrigger>().triggers = new List<EventTrigger.Entry>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry2.eventID = EventTriggerType.PointerExit;
        entry.callback.AddListener((x) => UsefulMethod.setActive(window));
        entry2.callback.AddListener((x) => UsefulMethod.setFalse(window)); //ラムダ式の右側は追加するメソッドです。
        gameObject.GetComponent<EventTrigger>().triggers.Add(entry);
        gameObject.GetComponent<EventTrigger>().triggers.Add(entry2);
    }

    private void Awake()
    {
        StartBASE();
        InstantiateWindow();
        main.cc.cf.SeMul.Add(() => 1 + TotalClearNum() * 0.05);
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
        text.Append("Curse of Reincarnation Milestone (<color=green>");
        text.Append(TotalClearNum().ToString());
        text.Append("</color> Times Clear )\n<size=12>");
        text.Append("\nYou will recieve <color=yellow> 5% </color=yellow>Sprit Essence bonus and <color=yellow>10%</color=yellow> " +
            "Max Level bonus for Sprit Essence Upgrade per each clear.(i.e. Clearing 1 Curse of Reincarnation will raise the upper limit of Alkahest by 20" +
            "but nothing will happen for Loot upgrade because decimal point is truncated.So Clearing 2 Curse of Reincarnation will raise 2 for Loot upgrade.)");
        text.Append("\n\n<size=16>CURRENT BONUS</size=12>");
        text.Append("\nSprit Essence Bonus : <color=green>" + TotalClearNum() * 5 + "%</color=green>");
        text.Append("\nMax Level bonus for SE upgrades : <color=green>" + TotalClearNum() * 10 + "%</color=green>");
        text.Append("\n\n<size=16>Curse Point</size=12>");
        text.Append("\n(Unlocked in later update)");

        window.GetComponentInChildren<TextMeshProUGUI>().text = text.ToString();
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
        //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(-250.0f, 50.0f);
        //    }
        //    else if (Input.mousePosition.y < 300 && Input.mousePosition.x < 400)
        //    {
        //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(50.0f, 100.0f);
        //    }
        //}

    }

    private void Update()
    {
        updateText();
    }

}
