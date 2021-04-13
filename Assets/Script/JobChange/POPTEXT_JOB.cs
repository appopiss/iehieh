using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;

public class POPTEXT_JOB : BASE
{
    public GameObject window;
    [TextAreaAttribute(10, 100)]//height:10,width:100
    public string Explain;
    public string Name;
    protected string Level;
    public string kind;
    protected string currentEffect;
    protected string nextEffect;
    protected string cost;
    public Image Icon;

    private void Awake()
    {
        StartBASE();
    }

    private void Start()
    {
        startText();
    }

    private void Update()
    {
        updateText();
    }

    public void startText()
    {
        window = Instantiate(main.P_texts[12], main.WindowShowCanvas);
        gameObject.AddComponent<EventTrigger>().triggers = new List<EventTrigger.Entry>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry2.eventID = EventTriggerType.PointerExit;
        entry.callback.AddListener((x) => UsefulMethod.setActive(window));
        entry2.callback.AddListener((x) => UsefulMethod.setFalse(window)); //ラムダ式の右側は追加するメソッドです。
        gameObject.AddComponent<EventTrigger>().triggers.Add(entry);
        gameObject.AddComponent<EventTrigger>().triggers.Add(entry2);

        Icon = window.transform.GetChild(0).GetComponentInChildren<Image>();
        Icon.sprite = gameObject.GetComponent<Image>().sprite;
    }

    public void updateText()
    {
        window.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "                 " + Name + " < <color=green>Lv " + Level+ " </color>>";
        window.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "                      - " + kind + "\n  \n  ";
        window.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "- " + Explain + "\n-- Current : " + currentEffect + "\n-- Next : " + nextEffect ;
        window.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text = cost;

        //if (window != null)
        //{
        //    if (Input.mousePosition.y >= 300 && Input.mousePosition.x >= 400)
        //    {
        //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(-300.0f, 0.0f);
        //    }
        //    else if (Input.mousePosition.y >= 300 && Input.mousePosition.x < 400)
        //    {
        //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(50.0f, 0.0f);
        //    }
        //    else if (Input.mousePosition.y < 300 && Input.mousePosition.x > 400)
        //    {
        //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(-300.0f, 100.0f);
        //    }
        //    else if (Input.mousePosition.y < 300 && Input.mousePosition.x < 400)
        //    {
        //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(50.0f, 100.0f);
        //    }
        //}
    }


}
