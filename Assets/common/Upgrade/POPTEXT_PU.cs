using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;

public class POPTEXT_PU : BASE
{
    public GameObject window;
    public string Name;
    public string explain;
    public string levelString;
    public string currentValue;
    public string nextValue;
    public string cost;

    public void awakeText()
    {
        StartBASE();
    }

    public void startText()
    {
        window = Instantiate(main.P_texts[0],main.WindowShowCanvas);
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
        if (window.activeSelf)
        {
            window.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Name + "    LV." + levelString;
            window.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = explain;
            window.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "<Current Value>\n" + currentValue + "\n <Next Value>\n" + nextValue;
            levelString = "Level : " + gameObject.GetComponent<UPGRADE>().level.ToString();
            window.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text = cost;


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
    }


}
