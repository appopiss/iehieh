using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using static UsefulMethod;

public class POPTEXT_BA : BASE
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
    public string C_slimeCoin;
    [System.NonSerialized]
    public Image upgradeIcon;
    [System.NonSerialized]
    public string effectExplain;
    [System.NonSerialized]
    public double tempLevel;
    [System.NonSerialized]
    public string queueText;
    [System.NonSerialized]
    TextMeshProUGUI text0, text1, text2, text3, text4, text5, text6,text7;

    public void awakeText()
    {
        StartBASE();
    }

    public void startText()
    {
        window = Instantiate(main.P_texts[20], main.WindowShowCanvas);
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

        text0 = window.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        text1 = window.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        text2 = window.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        text3 = window.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        text4 = window.transform.GetChild(4).GetComponent<TextMeshProUGUI>();
        text5 = window.transform.GetChild(5).GetComponent<TextMeshProUGUI>();
        text6 = window.transform.GetChild(6).GetComponent<TextMeshProUGUI>();
        text7 = window.transform.GetChild(7).GetComponent<TextMeshProUGUI>();
    }
    public void updateText()
    {
        if (window.activeSelf)
        {
            LocalizeInitialize.SetFont(text0,text1,text2,text3,text4,text5,text6);
            levelString = gameObject.GetComponent<B_Upgrade>().level.ToString();
            text0.text = BankLocal.BaseFormatForName(Name, levelString);
            BankLocal.UpdateBaseFormatForHeader(text1, text3, text5);
            text2.text = BankLocal.BaseFormatForCurrentAndNext(effectExplain, currentValue, nextValue, tempLevel);
            switch (LocalizeInitialize.language)
            {
                case Language.jp:
                    text4.text = "<size=10>" + explain + "\n\n- レベルアップによる評判 " + gameObject.GetComponent<B_Upgrade>().ReputationPerUpgrade.ToString("F0");
                    break;
                case Language.chi:
                    text4.text = explain + "\n\n- 每升级一次 + " + gameObject.GetComponent<B_Upgrade>().ReputationPerUpgrade.ToString("F0") + " 威望";
                    break;
                default:
                    text4.text = explain + "\n\n- Reputation per Upgrade " + gameObject.GetComponent<B_Upgrade>().ReputationPerUpgrade.ToString("F0");
                    break;
            }
            text6.text = "- " + C_slimeCoin;
            text7.text = queueText;


            //if (window != null)
            //{
            //    if (Input.mousePosition.y >= 300 && Input.mousePosition.x >= 400)
            //    {
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(-250.0f, -100.0f);
            //    }
            //    else if (Input.mousePosition.y >= 300 && Input.mousePosition.x < 400)
            //    {
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(50.0f, -100.0f);
            //    }
            //    else if (Input.mousePosition.y < 300 && Input.mousePosition.x > 400)
            //    {
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(-250.0f, 0.0f);
            //    }
            //    else if (Input.mousePosition.y < 300 && Input.mousePosition.x < 400)
            //    {
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(25.0f, 150.0f);
            //    }
            //}
        }

    }


}
