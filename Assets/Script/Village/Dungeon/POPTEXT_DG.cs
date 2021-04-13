using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;

public class POPTEXT_DG : BASE
{
    public GameObject window;
    public Transform MissionTransform;
    public string Name;
    public string explain;
    public string rewardText;
    public string rewardExplain;
    public string timeLeft;
    public string ClearNumText;
    //public string ExpBonusText;
    //public string MoveSpeedText;
    //public string NextBonusText;

    public void awakeText()
    {
        StartBASE();
        window = Instantiate(main.P_texts[13], main.WindowShowCanvas);
        MissionTransform = window.transform.GetChild(5);
        for(int i = 0; i < gameObject.GetComponents<MISSION>().Length; i++)
        {
            Instantiate(main.Texts[29], MissionTransform);
        }
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

    public void startText()
    {

    }
    public void updateText()
    {
        if (window.activeSelf)
        {
            LocalizeInitialize.SetFont(window.transform.GetChild(0).GetComponent<TextMeshProUGUI>());
            window.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Name;
            window.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = explain;
            window.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = rewardText;
            window.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = rewardExplain;
            window.transform.GetChild(6).GetComponent<TextMeshProUGUI>().text = timeLeft;
            window.transform.GetChild(8).GetComponent<TextMeshProUGUI>().text = ClearNumText;
            //window.transform.GetChild(9).GetComponent<TextMeshProUGUI>().text = ExpBonusText;
            //window.transform.GetChild(10).GetComponent<TextMeshProUGUI>().text = MoveSpeedText;
            //window.transform.GetChild(11).GetComponent<TextMeshProUGUI>().text = NextBonusText;


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
            //    else if (Input.mousePosition.y < 300 && Input.mousePosition.x > 250)
            //    {
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(-50.0f, 180.0f);
            //    }
            //    else if (Input.mousePosition.y < 300 && Input.mousePosition.x < 250)
            //    {
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(50.0f, 80.0f);
            //    }
            //}
        }
    }


}
