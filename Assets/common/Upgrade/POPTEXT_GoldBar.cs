using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using static UsefulMethod;
public class POPTEXT_GoldBar : BASE
{
    public GameObject window;
    public TextMeshProUGUI windowText0;
    public TextMeshProUGUI windowText1;

    public GameObject window2;
    public TextMeshProUGUI window2Text0;
    public TextMeshProUGUI window2Text1;

    public GameObject window3;
    public TextMeshProUGUI window3Text0;
    public TextMeshProUGUI window3Text1;

    public Slider StoneSlider;
    public Slider CristalSlider;
    public Slider LeafSlider;
    public Transform windowParent;
    public string[] levelString;
    public string[] ExpString;
    public bool isOver;
    public bool isOver2;
    public bool isOver3;
    

    public void awakeText()
    {
        StartBASE();
    }

    public void startText()
    {
        window = Instantiate(main.P_texts[16], main.WindowShowCanvas);
        StoneSlider.gameObject.AddComponent<EventTrigger>().triggers = new List<EventTrigger.Entry>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry2.eventID = EventTriggerType.PointerExit;
        entry.callback.AddListener((x) => { isOver = true; });
        entry2.callback.AddListener((x) => isOver = false); //ラムダ式の右側は追加するメソッドです。
        StoneSlider.gameObject.GetComponent<EventTrigger>().triggers.Add(entry);
        StoneSlider.gameObject.GetComponent<EventTrigger>().triggers.Add(entry2);

        windowText0 = window.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        windowText1 = window.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

        window2 = Instantiate(main.P_texts[16], main.WindowShowCanvas);
        CristalSlider.gameObject.AddComponent<EventTrigger>().triggers = new List<EventTrigger.Entry>();
        EventTrigger.Entry entry3 = new EventTrigger.Entry();
        EventTrigger.Entry entry4 = new EventTrigger.Entry();
        entry3.eventID = EventTriggerType.PointerEnter;
        entry4.eventID = EventTriggerType.PointerExit;
        entry3.callback.AddListener((x) => { isOver2 = true; });
        entry4.callback.AddListener((x) => isOver2 = false); //ラムダ式の右側は追加するメソッドです。
        CristalSlider.gameObject.GetComponent<EventTrigger>().triggers.Add(entry3);
        CristalSlider.gameObject.GetComponent<EventTrigger>().triggers.Add(entry4);

        window2Text0 = window2.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        window2Text1 = window2.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

        window3 = Instantiate(main.P_texts[16], main.WindowShowCanvas);
        LeafSlider.gameObject.AddComponent<EventTrigger>().triggers = new List<EventTrigger.Entry>();
        EventTrigger.Entry entry5 = new EventTrigger.Entry();
        EventTrigger.Entry entry6 = new EventTrigger.Entry();
        entry5.eventID = EventTriggerType.PointerEnter;
        entry6.eventID = EventTriggerType.PointerExit;
        entry5.callback.AddListener((x) => { isOver3 = true; });
        entry6.callback.AddListener((x) => isOver3 = false); //ラムダ式の右側は追加するメソッドです。
        LeafSlider.gameObject.GetComponent<EventTrigger>().triggers.Add(entry5);
        LeafSlider.gameObject.GetComponent<EventTrigger>().triggers.Add(entry6);

        window3Text0 = window3.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        window3Text1 = window3.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

    }

    public void updateText()
    {
        if (main.skillSetController.mouseObject != null)
        {
            setFalse(window);
            setFalse(window2);
            setFalse(window3);
            return;
        }

        if (!isOver)
        {
            setFalse(window);
        }
        if (!isOver2)
        {
            setFalse(window2);
        }
        if (!isOver3)
        {
            setFalse(window3);
        }
        if (isOver)
        {
            setActive(window);
            //window1
            windowText0.text = levelString[0];
            windowText1.text = ExpString[0];

            if (window != null)
            {
                window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition / (Screen.height / 600f) - new Vector3(400, 300) + new Vector3(120f, -50.0f);
                //if (Input.mousePosition.y >= 300 && Input.mousePosition.x >= 400)
                //{
                //    window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(120f, -50.0f);
                //}
                //else if (Input.mousePosition.y >= 300 && Input.mousePosition.x < 400)
                //{
                //    window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(120f, -50.0f);
                //}
                //else if (Input.mousePosition.y < 300 && Input.mousePosition.x > 400)
                //{
                //    window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(120f, -50.0f);
                //}
                //else if (Input.mousePosition.y < 300 && Input.mousePosition.x < 400)
                //{
                //    window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(120f, -50.0f);
                //}
            }
        }
        if (isOver2)
        {
            setActive(window2);
            //window2
            window2Text0.text = levelString[1];
            window2Text1.text = ExpString[1];

            if (window2 != null)
            {
                window2.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition / (Screen.height / 600f) - new Vector3(400, 300) + new Vector3(120f, -50.0f);

                //if (Input.mousePosition.y >= 300 && Input.mousePosition.x >= 400)
                //{
                //    window2.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(120f, -50.0f);
                //}
                //else if (Input.mousePosition.y >= 300 && Input.mousePosition.x < 400)
                //{
                //    window2.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(120f, -50.0f);
                //}
                //else if (Input.mousePosition.y < 300 && Input.mousePosition.x > 400)
                //{
                //    window2.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(120f, -50.0f);
                //}
                //else if (Input.mousePosition.y < 300 && Input.mousePosition.x < 400)
                //{
                //    window2.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(120f, -50.0f);
                //}
            }
        }
        if (isOver3)
        {
            setActive(window3);
            //window3
            window3Text0.text = levelString[2];
            window3Text1.text = ExpString[2];

            if (window3 != null)
            {
                window3.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition / (Screen.height / 600f) - new Vector3(400, 300) + new Vector3(120f, -50.0f);

                //if (Input.mousePosition.y >= 300 && Input.mousePosition.x >= 400)
                //{
                //    window3.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(120f, -50.0f);
                //}
                //else if (Input.mousePosition.y >= 300 && Input.mousePosition.x < 400)
                //{
                //    window3.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(120f, -50.0f);
                //}
                //else if (Input.mousePosition.y < 300 && Input.mousePosition.x > 400)
                //{
                //    window3.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(120f, -50.0f);
                //}
                //else if (Input.mousePosition.y < 300 && Input.mousePosition.x < 400)
                //{
                //    window3.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(120f, -50.0f);
                //}
            }
        }
    }


}
