using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;

public class POPTEXT_UG : BASE  
{
    [System.NonSerialized]
    public GameObject window;
    [System.NonSerialized]
    public Transform windowParent;
    [System.NonSerialized]
    public string Name;
    [System.NonSerialized]
    public string explain;
    [System.NonSerialized]
    public string levelString;
    [System.NonSerialized]
    public string currentValue;
    [System.NonSerialized]
    public string nextValue;
    [System.NonSerialized]
    public string C_gold;
    [System.NonSerialized]
    public string C_stone;
    [System.NonSerialized]
    public string C_cristal;
    [System.NonSerialized]
    public string C_leaf;
    [System.NonSerialized]
    public Image upgradeIcon;
    [System.NonSerialized]
    public string effectExplain;
    [System.NonSerialized]
    public double tempLevel;
    [System.NonSerialized]
    public string queueText;

    public void awakeText()
    {
        StartBASE();
    }

    public void startText()
    {
        window = Instantiate(main.P_texts[4], main.WindowShowCanvas);
        upgradeIcon = window.transform.GetChild(0).GetComponentInChildren<Image>();
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

    public bool isLottery = false;
    public void updateText()
    {
        if (window.activeSelf)
        {
            window.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = L_Upgrades.BaseFormatForName(Name, levelString);
            if (!isLottery)
                window.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = L_Upgrades.BaseFormatForCurrentAndNext(effectExplain, currentValue, nextValue, tempLevel);
            else
                window.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = effectExplain;

            levelString = gameObject.GetComponent<M_UPGRADE>().level.ToString();
            window.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = "- " + explain;
            window.transform.GetChild(6).GetComponent<TextMeshProUGUI>().text = C_gold;
            window.transform.GetChild(7).GetComponent<TextMeshProUGUI>().text = C_stone;
            window.transform.GetChild(8).GetComponent<TextMeshProUGUI>().text = C_cristal;
            window.transform.GetChild(9).GetComponent<TextMeshProUGUI>().text = C_leaf;
            window.transform.GetChild(10).GetComponent<TextMeshProUGUI>().text = queueText;

            //fontを切り替えます。
            LocalizeInitialize.SetFont(window.transform.GetChild(0).GetComponent<TextMeshProUGUI>()
                , window.transform.GetChild(2).GetComponent<TextMeshProUGUI>()
                , window.transform.GetChild(4).GetComponent<TextMeshProUGUI>());
            L_Upgrades.UpdateBaseFormatForHeader(window.transform.GetChild(1).GetComponent<TextMeshProUGUI>(),
                window.transform.GetChild(3).GetComponent<TextMeshProUGUI>(),
                window.transform.GetChild(5).GetComponent<TextMeshProUGUI>());


            //if (window != null)
            //{
            //    if (Input.mousePosition.y >= 150 && Input.mousePosition.x >= 400)
            //    {
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(-250.0f, -100.0f);
            //    }
            //    else if (Input.mousePosition.y >= 150 && Input.mousePosition.x < 400)
            //    {
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(50.0f, 120.0f);
            //    }
            //    else if (Input.mousePosition.y < 150 && Input.mousePosition.x > 400)
            //    {
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(-250.0f, 0.0f);
            //    }
            //    else if (Input.mousePosition.y < 150 && Input.mousePosition.x < 400)
            //    {
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(50.0f, 170.0f);
            //    }
            //}
        }
    }


}
