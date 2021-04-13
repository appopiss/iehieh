using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using static UsefulMethod;

public class POPTEXT_BankDescription : BASE
{
    [System.NonSerialized]
    public GameObject window;
    [System.NonSerialized]
    public Transform windowParent;
    public string Name;
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

    public void Awake()
    {
        StartBASE();
    }

    public void Start()
    {
        window = Instantiate(main.P_texts[22], main.WindowShowCanvas);
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

    //public string NitroText()
    //{
    //    string tempText = "";
    //    tempText += "<size=16>Slime Bank</size>\n\n";
    //    tempText += "A large, domical structure cast from white marble that bears intricate designs carved into the pillars that surround it on all sides. Within the structure the walls are lined with cute little boxes, big enough for... \"Welgoome.. < glogblurtle >..Hooman to<flurglesnap> the Slurm Ba.. errg the Slime Bank<barflesnurf>. We've been goollegting all of <gurgblat> the goold you left lurgin.. ugg lying aroound when <burpflurgin> your poggets were full. We melted it all into Slurm go... <flurgha> Slime Goins for your gonvenienge. If you want to <praglefurrrt> upgoorade your aggount with us, let me gnow.\" said a voice from within one of the boxes. Within is a strange little slime wearing a fancy suit, a mustache made from what looks to be an old mop, and a monocle that makes you suddenly really trust this guy!";
    //    return tempText;
    //}


    public void Update()
    {
        if (window.activeSelf)
        {
            //window.GetComponentInChildren<TextMeshProUGUI>().text = NitroText();

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
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(50.0f, 150.0f);
            //    }
            //}
        }

    }


}
