using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using static UsefulMethod;

public class ABNORMAL : BASE {

    [NonSerialized]
    public bool isOver;
    [NonSerialized]
    public GameObject window;
    [NonSerialized]
    public Image windowSkillIcon;
    [NonSerialized]
    public TextMeshProUGUI windowText0;
    [NonSerialized]
    public TextMeshProUGUI windowText1;
    [NonSerialized]
    public TextMeshProUGUI windowText3;
    [NonSerialized]
    public Transform windowParent;
    [NonSerialized]
    public string skillNameString;
    [NonSerialized]
    public string effectString;


    public double factor;
    public float duration;
    public float currentDuration;
    public Main.Debuff debuff;
    public Main.Buff buff;
    Image coolTimeImage;
    //Image backGround;
    public double abnormalDamage;

	// Use this for initialization
	public void AwakeCor () {
        StartBASE();
        coolTimeImage = gameObject.GetComponent<Image>();
        //backGround = gameObject.transform.GetChild(0).GetComponent<Image>();
	}

	// Use this for initialization
	public void StartCor () {
        StartCoroutine(CalculateDuration());
        StartCoroutine(Effect());

        window = Instantiate(main.P_texts[25], main.WindowShowCanvas);
        gameObject.AddComponent<EventTrigger>().triggers = new List<EventTrigger.Entry>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry2.eventID = EventTriggerType.PointerExit;
        entry.callback.AddListener((x) => { isOver = true; });
        entry2.callback.AddListener((x) => isOver = false); //ラムダ式の右側は追加するメソッドです。
        gameObject.GetComponent<EventTrigger>().triggers.Add(entry);
        gameObject.GetComponent<EventTrigger>().triggers.Add(entry2);

        windowSkillIcon = window.transform.GetChild(0).GetComponentInChildren<Image>();
        windowText0 = window.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        windowText1 = window.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        windowText3 = window.transform.GetChild(3).GetComponent<TextMeshProUGUI>();

        StartCoroutine(WaitForDurationDouble());
    }
    IEnumerator WaitForDurationDouble()
    {
        yield return new WaitUntil(() => buff != Main.Buff.nothing && main.skillprogress.isBuffDuration);
        duration *= 2;
    }

    // Update is called once per frame
    public void UpdateCor () {
        coolTimeImage.fillAmount = 1-currentDuration / duration;

        if (!isOver)
        {
            setFalse(window);
        }
        else if (isOver)
        {
            setActive(window);
            //window1
            windowSkillIcon.sprite = gameObject.GetComponent<Image>().sprite;
            windowText0.text = "             " + skillNameString;
            windowText1.text = "                  Duration : " + tDigit(duration-currentDuration) + "\n   ";
            windowText3.text = effectString;


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
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(-180.0f, 80.0f);
            //    }
            //    else if (Input.mousePosition.y < 300 && Input.mousePosition.x < 400)
            //    {
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(50.0f, 50f);
            //    }
            //}

        }

    }

    public virtual IEnumerator Effect() { yield return null; }
    public IEnumerator CalculateDuration()
    {
        while (true)
        {
            //yield return new WaitUntil(() => duration > 0);
            currentDuration += 1.0f;
            if(currentDuration >= duration) { Destroy(gameObject); }
            yield return new WaitForSeconds(1.0f);
        }
    }
}
