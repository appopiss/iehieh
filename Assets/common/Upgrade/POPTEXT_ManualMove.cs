using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using static UsefulMethod;
public class POPTEXT_ManualMove : BASE
{
    public GameObject window;
    public Transform windowParent;
    public bool isOver;
    

    public void awakeText()
    {
        StartBASE();
    }

    public void startText()
    {
        window = Instantiate(main.P_texts[17], main.WindowShowCanvas);
        gameObject.AddComponent<EventTrigger>().triggers = new List<EventTrigger.Entry>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry2.eventID = EventTriggerType.PointerExit;
        entry.callback.AddListener((x) => { isOver = true; });
        entry2.callback.AddListener((x) => isOver = false); //ラムダ式の右側は追加するメソッドです。
        gameObject.GetComponent<EventTrigger>().triggers.Add(entry);
        gameObject.GetComponent<EventTrigger>().triggers.Add(entry2);

    }

    public void updateText()
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
            if (window != null)
            {
                window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition / (Screen.height / 600f) - new Vector3(400, 300) + new Vector3(0, 50.0f);
                //if (Input.mousePosition.y >= 300 && Input.mousePosition.x >= 400)
                //{
                //    window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(0, 50.0f);
                //}
                //else if (Input.mousePosition.y >= 300 && Input.mousePosition.x < 400)
                //{
                //    window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(0f, 50.0f);
                //}
                //else if (Input.mousePosition.y < 300 && Input.mousePosition.x > 400)
                //{
                //    window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(0f, 50.0f);
                //}
                //else if (Input.mousePosition.y < 300 && Input.mousePosition.x < 400)
                //{
                //    window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(0f, 50.0f);
                //}
            }
        }
    }


}
