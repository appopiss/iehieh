using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using static UsefulMethod;
using static AchievementController;
using TMPro;

public class NitroCharger : BASE {

    public Button BoostButton;
    public Button BoostButtonInField;
    public Slider NitroSlider;
    public Slider NitroSliderInField;
    public TextMeshProUGUI Text;
    GameObject window;
    float Duration { get => main.S.CurrentNitro; set => main.S.CurrentNitro = value; }
    bool isNitro { get => main.S.isNitro; set => main.S.isNitro = value; }

    public string NitroText()
    {
        string tempText = "";
        tempText += "<size=16>Nitro Charger";
        if (isNitro)
            tempText += "   ( <color=green>Active</color> )";
        else
            tempText += "   ( Inactive )";
        tempText += "</size>\n\n";
        tempText += "You can do Nitro Boost by using dangerous Nitro you stored.\nNote that can be stored only when you are OFFLINE!\n\n";
        if (main.S.dlcNitro)
            tempText += "- Effect : " + "Boost the game speed x3\n";
        else
            tempText += "- Effect : " + "Boost the game speed x2\n";
        tempText += "- Current Nitro : " + tDigit(Duration) + " / " + tDigit(NitroCap()) + "\n";
        tempText += "- Nitro Produce : 4 seconds offline for 1 Nitro";
        if (main.S.AutoNitro)
        {
            if (main.S.isAutoNitro)
                tempText += "\n- <color=green>Auto-ON</color>  ( \"N\" to OFF )";
            else
                tempText += "\n- <color=green>Auto-OFF</color>  ( \"N\" to ON )";
        }
        return tempText;
    }

    public float CalculateQuestNitro()
    {
        float tempNum = 0f;
        foreach(ACHIEVEMENT quest in main.quests)
        {
            tempNum += quest.NitroBonus;
        }
        return tempNum;
    }

    public float NitroCap()
    {
        return 1000 + main.S.NitroCapUpNum * 500 + CalculateQuestNitro() + (float)main.jems[(int)JEM.ID.Nitro].Effect()
            + (float)main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.powder].calculateCurrentValue();
    }

	// Use this for initialization
	void Awake () {
		StartBASE();
        BoostButton.onClick.AddListener(Boost);
        BoostButtonInField.onClick.AddListener(Boost);
    }

    void Boost()
    {
        if (Duration < 1)
        {
            isNitro = false;
            return;
        }

        if (!isNitro)
            isNitro = true;
        else
            isNitro = false;
    }

    public float AddTimeScale()
    {
        float temp = 0;
        //ニトロがかかっていたら
        if (isNitro && Duration > 0)
        {
            temp += 1.0f;
            if (main.S.dlcNitro)
                temp += 1.0f;
        }

        //あっどボーナスがあったら
        if(main.S.nitroExplosionTimeLeft > 0)
        {
            temp += 1.0f;
        }
        return temp;
    }

    public IEnumerator NitroBoostCor()
    {
        while (true)
        {
            if (!isNitro || Duration == 0)
            {
                 //Time.timeScale = main.S.nitroExplosionTimeLeft <= 0 ? 1.0f : 2.0f;
                isNitro = false;
            }
            yield return new WaitUntil(() => isNitro);
            yield return new WaitUntil(() => Duration > 0);
            //Time.timeScale = main.S.nitroExplosionTimeLeft <= 0 ? 2.0f : 3.0f;
            Duration -= 1.0f;
            if (Duration < 0)
                Duration = 0;
            yield return new WaitForSeconds(2.0f);
        }
    }

    IEnumerator NitroExplosionCor()
    {
        WaitUntil wait = new WaitUntil(() => main.S.nitroExplosionTimeLeft > 0);
        while (true)
        {
            yield return wait;
            main.S.nitroExplosionTimeLeft -= 1.0f;
            yield return new WaitForSecondsRealtime(1.0f);
        }
    }

    IEnumerator WaitUntilNitroIsMax()
    {
        //ここにQoLを購入したかどうかのboolを書く
        yield return new WaitUntil(() => main.S.AutoNitro);
        while (true)
        {
            yield return new WaitUntil(() => main.S.isAutoNitro);
            yield return new WaitUntil(() => Duration >= NitroCap());
            if(!isNitro)
                BoostButton.onClick.Invoke();
        }
    }

	// Use this for initialization
	void Start () {
        StartCoroutine(NitroBoostCor());
        StartCoroutine(NitroExplosionCor());
        StartCoroutine(WaitUntilNitroIsMax());
        InstantiateWindow();
	}
	
	// Update is called once per frame
	void Update () {
        Time.timeScale = 1.0f + AddTimeScale();
        NitroSlider.value = Duration / NitroCap();
        NitroSliderInField.value = Duration / NitroCap();
        if (window.activeSelf)
        {
            window.GetComponentInChildren<TextMeshProUGUI>().text = NitroText();

            if (main.S.AutoNitro&&Input.GetKeyDown(KeyCode.N))
            {
                if (main.S.isAutoNitro)
                    main.S.isAutoNitro = false;
                else
                    main.S.isAutoNitro = true;
            }
        }
        if (isNitro)
        {
            BoostButton.GetComponentInChildren<TextMeshProUGUI>().text = "Nitro Boost!!";
        }
        else
        {
            BoostButton.GetComponentInChildren<TextMeshProUGUI>().text = "Nitro Off";
        }

        if (Duration >= NitroCap())
            Duration = NitroCap();

        if(main.GameController.currentCanvas==main.GameController.IdleCanvas)
            Text.text = tDigit(Duration) + " / " + tDigit(NitroCap());


        //if (window != null)
        //{
        //    if (Input.mousePosition.y >= 300 && Input.mousePosition.x >= 400)
        //    {
        //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(-300.0f, -100.0f);
        //    }
        //    else if (Input.mousePosition.y >= 300 && Input.mousePosition.x < 400)
        //    {
        //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(50.0f, -50.0f);
        //    }
        //    else if (Input.mousePosition.y < 300 && Input.mousePosition.x > 400)
        //    {
        //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(-420.0f, 0.0f);
        //    }
        //    else if (Input.mousePosition.y < 300 && Input.mousePosition.x < 400)
        //    {
        //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(50.0f, 100.0f);
        //    }
        //}

    }

    public void InstantiateWindow()
    {
        window = Instantiate(main.P_texts[19], main.WindowShowCanvas);
        gameObject.AddComponent<EventTrigger>().triggers = new List<EventTrigger.Entry>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry2.eventID = EventTriggerType.PointerExit;
        entry.callback.AddListener((x) => UsefulMethod.setActive(window));
        entry2.callback.AddListener((x) => UsefulMethod.setFalse(window)); //ラムダ式の右側は追加するメソッドです。
        gameObject.GetComponent<EventTrigger>().triggers.Add(entry);
        gameObject.GetComponent<EventTrigger>().triggers.Add(entry2);

        BoostButtonInField.gameObject.AddComponent<EventTrigger>().triggers = new List<EventTrigger.Entry>();
        EventTrigger.Entry entry3 = new EventTrigger.Entry();
        EventTrigger.Entry entry4 = new EventTrigger.Entry();
        entry3.eventID = EventTriggerType.PointerEnter;
        entry4.eventID = EventTriggerType.PointerExit;
        entry3.callback.AddListener((x) => UsefulMethod.setActive(window));
        entry4.callback.AddListener((x) => UsefulMethod.setFalse(window)); //ラムダ式の右側は追加するメソッドです。
        BoostButtonInField.GetComponent<EventTrigger>().triggers.Add(entry3);
        BoostButtonInField.GetComponent<EventTrigger>().triggers.Add(entry4);

    }

}
