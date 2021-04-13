using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UsefulMethod;

public class SystemController : BASE {

    public Button[] buttons;
    public TextMeshProUGUI[] texts;
    public Toggle[] toggles;
    public bool dmgTxtLimitOff { get => main.S.dmgTxtLimitOff; set => main.S.dmgTxtLimitOff = value; }
    public bool isDeathPanel { get => main.S.isDeathPanel; set => main.S.isDeathPanel = value; }
    public Slider[] sliders;
    public float dmgTxtLimit { get => main.S.dmgTxtLimit; set => main.S.dmgTxtLimit = value; }
    public bool noMoreDamageTxt;
    public static bool isScientificNotification;
    public Canvas[] darkCanvas;
    public GameObject[] ClassImage;
    public GameObject screenSizeCanvas;
    public Button[] screenSizeButtons;
    public Button[] fullScreenSizeButtons;
    public Button openScreenSizeButton;
    public Button openScreenSizeButton2;
    public Button quitScreenSizeButton;

    bool isPerformanceMode;
    public bool disableTooltip { get => main.S.isDisableTooltip; set => main.S.isDisableTooltip = value; }
    public bool disableLootLog { get => main.S.isDisableLootLog; set => main.S.isDisableLootLog = value; }
    public bool disableEffect { get => main.S.isDisableEffect; set => main.S.isDisableEffect = value; }

    // Use this for initialization
    void Awake () {
		StartBASE();
        dmgTxtLimit = 1;

        if (main.platform == Platform.steam)
        {
            setActive(openScreenSizeButton.gameObject);
            setActive(openScreenSizeButton2.gameObject);
            screenSizeButtons[0].onClick.AddListener(() => Screen.SetResolution(800, 600, false));
            screenSizeButtons[1].onClick.AddListener(() => Screen.SetResolution(1024, 768, false));
            screenSizeButtons[2].onClick.AddListener(() => Screen.SetResolution(1200, 900, false));
            screenSizeButtons[3].onClick.AddListener(() => Screen.SetResolution(1400, 1050, false));
            screenSizeButtons[4].onClick.AddListener(() => Screen.SetResolution(1600, 1200, false));
            screenSizeButtons[5].onClick.AddListener(() => Screen.SetResolution(2048, 1536, false));
            screenSizeButtons[6].onClick.AddListener(() => Screen.SetResolution(3072, 2304, false));
            fullScreenSizeButtons[0].onClick.AddListener(() => Screen.SetResolution(800, 600, true));
            fullScreenSizeButtons[1].onClick.AddListener(() => Screen.SetResolution(1024, 768, true));
            fullScreenSizeButtons[2].onClick.AddListener(() => Screen.SetResolution(1200, 900, true));
            fullScreenSizeButtons[3].onClick.AddListener(() => Screen.SetResolution(1400, 1050, true));
            fullScreenSizeButtons[4].onClick.AddListener(() => Screen.SetResolution(1600, 1200, true));
            fullScreenSizeButtons[5].onClick.AddListener(() => Screen.SetResolution(2048, 1536, true));
            fullScreenSizeButtons[6].onClick.AddListener(() => Screen.SetResolution(3072, 2304, true));
            openScreenSizeButton.onClick.AddListener(() => { setActive(screenSizeCanvas); screenSizeCanvas.GetComponent<RectTransform>().anchoredPosition = new Vector2(-620, 300); });
            openScreenSizeButton2.onClick.AddListener(() => setActive(screenSizeCanvas));
            quitScreenSizeButton.onClick.AddListener(() => setFalse(screenSizeCanvas));
        }
        else
        {
            setFalse(openScreenSizeButton.gameObject);
            setFalse(openScreenSizeButton2.gameObject);
            setFalse(screenSizeCanvas);
        }
    }

    public void SaveToggle(bool bo, Toggle to)
    {
        if (bo)
        {
            if (!to.isOn)
            {
                to.isOn = true;
            }
        }
        else
        {
            if (to.isOn)
            {
                to.isOn = false;
            }
        }

    }

	// Use this for initialization
	void Start () {
        if (dmgTxtLimitOff)
        {
            if (!toggles[0].isOn)
            {
                toggles[0].isOn = true;
            }
        }
        else
        {
            if (toggles[0].isOn)
            {
                toggles[0].isOn = false;
            }
        }
        SaveToggle(isDeathPanel, main.toggles[1]);
        sliders[0].value = dmgTxtLimit;

        Load();             //Added

        switch (main.ally.job)
        {
            case ALLY.Job.Novice:
                break;
            case ALLY.Job.Warrior:
                setActive(ClassImage[0]);
                setFalse(ClassImage[1]);
                setFalse(ClassImage[2]);
                break;
            case ALLY.Job.Wizard:
                setFalse(ClassImage[0]);
                setActive(ClassImage[1]);
                setFalse(ClassImage[2]);
                break;
            case ALLY.Job.Angel:
                setFalse(ClassImage[0]);
                setFalse(ClassImage[1]);
                setActive(ClassImage[2]);
                break;
            case ALLY.Job.all:
                break;
            default:
                break;
        }

        if (!main.S.CustomRange)
        {
            main.toggles[10].gameObject.GetComponent<RectTransform>().anchoredPosition += new Vector2(-400, 0);
        }
        if (!main.S.CustomSpeed)
        {
            main.toggles[14].gameObject.GetComponent<RectTransform>().anchoredPosition += new Vector2(-400, 0);
        }
        if (!main.S.AutoActiveSkill)
        {
            main.toggles[11].gameObject.GetComponent<RectTransform>().anchoredPosition += new Vector2(-400, 0);
        }

        //Performance Mode
        if (main.toggles[9].isOn)
        {
                for (int i = 0; i < darkCanvas.Length; i++)
                {
                    darkCanvas[i].enabled = false;
                }
                isPerformanceMode = true;
        }
        else
        {
                for (int i = 0; i < darkCanvas.Length; i++)
                {
                    darkCanvas[i].enabled = true;
                }
                isPerformanceMode = false;
        }
        StartCoroutine(Hotkey());
        StartCoroutine(HotKeyP());
        StartCoroutine(HotKeyT());
        StartCoroutine(HotKeyB());
        StartCoroutine(HotKeyL());


        if (disableTooltip)
            main.WindowShowCanvas.GetComponent<Canvas>().enabled = false;
        else
            main.WindowShowCanvas.GetComponent<Canvas>().enabled = true;
        if (disableEffect)
            main.Transforms[1].GetComponent<Canvas>().enabled = false;
        else
            main.Transforms[1].GetComponent<Canvas>().enabled = true;
    }

    IEnumerator HotKeyP()//Performance mode
    {
        while (true)
        {
            yield return new WaitUntil(() => (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Input.GetKeyDown(KeyCode.P));
            if (!main.toggles[9].isOn)
                main.toggles[9].isOn = true;
            else
                main.toggles[9].isOn = false;
            yield return new WaitForSeconds(0.05f);
        }
    }
    IEnumerator HotKeyT()//ToolTip隠す
    {
        while (true)
        {
            yield return new WaitUntil(() => (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Input.GetKeyDown(KeyCode.T));
            if (!disableTooltip)
            {
                main.WindowShowCanvas.GetComponent<Canvas>().enabled = false;
                disableTooltip = true;
            }
            else
            {
                main.WindowShowCanvas.GetComponent<Canvas>().enabled = true;
                disableTooltip = false;
            }
            yield return new WaitForSeconds(0.05f);
        }
    }
    IEnumerator HotKeyB()//Animation隠す
    {
        while (true)
        {
            yield return new WaitUntil(() => (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Input.GetKeyDown(KeyCode.B));
            if (!disableEffect)
            {
                main.Transforms[1].GetComponent<Canvas>().enabled = false;
                disableEffect = true;
            }
            else
            {
                main.Transforms[1].GetComponent<Canvas>().enabled = true;
                disableEffect = false;
            }
            yield return new WaitForSeconds(0.05f);
        }
    }
    IEnumerator HotKeyL()//LootLog消す
    {
        while (true)
        {
            yield return new WaitUntil(() => (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Input.GetKeyDown(KeyCode.L));
            if (!disableLootLog)
                disableLootLog = true;
            else
                disableLootLog = false;
            yield return new WaitForSeconds(0.05f);
        }
    }


    IEnumerator Hotkey()//SkillSlotSet
    {
        while (true)
        {
            yield return new WaitUntil(() => Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl));
            //if (Input.GetKeyDown(KeyCode.P))//Performance Mode
            //{
            //    if (!main.toggles[9].isOn)
            //        main.toggles[9].isOn = true;
            //    else
            //        main.toggles[9].isOn = false;
            //}
            //if (Input.GetKeyDown(KeyCode.T))//ToolTipを隠す
            //{
            //    if (!disableTooltip)
            //    {
            //        main.WindowShowCanvas.GetComponent<Canvas>().enabled = false;
            //        disableTooltip = true;
            //    }
            //    else
            //    {
            //        main.WindowShowCanvas.GetComponent<Canvas>().enabled = true;
            //        disableTooltip = false;
            //    }
            //}
            //if (Input.GetKeyDown(KeyCode.B))//Animation消す
            //{
            //    if (!disableEffect)
            //    {
            //        main.Transforms[1].GetComponent<Canvas>().enabled = false;
            //        disableEffect = true;
            //    }
            //    else
            //    {
            //        main.Transforms[1].GetComponent<Canvas>().enabled = true;
            //        disableEffect = false;
            //    }
            //}
            //if (Input.GetKeyDown(KeyCode.L)) //LootLogも消す
            //{
            //    if (!disableLootLog)
            //        disableLootLog = true;
            //    else
            //        disableLootLog = false;
            //}
            if (main.S.SkillSetSaveBuyNum >= 2)
            {
                if (Input.GetKey(KeyCode.Tab))
                {
                    if (main.S.SkillSetSaveBuyNum >= 1 && Input.GetKey(KeyCode.Alpha1))
                        main.skillSetController.SkillSetSaveButtons[0].onClick.Invoke();
                    else if (main.S.SkillSetSaveBuyNum >= 2 && Input.GetKey(KeyCode.Alpha2))
                        main.skillSetController.SkillSetSaveButtons[1].onClick.Invoke();
                    else if (main.S.SkillSetSaveBuyNum >= 3 && Input.GetKey(KeyCode.Alpha3))
                        main.skillSetController.SkillSetSaveButtons[2].onClick.Invoke();
                    else if (main.S.SkillSetSaveBuyNum >= 4 && Input.GetKey(KeyCode.Alpha3))
                        main.skillSetController.SkillSetSaveButtons[3].onClick.Invoke();
                    else if (main.S.SkillSetSaveBuyNum >= 5 && Input.GetKey(KeyCode.Alpha3))
                        main.skillSetController.SkillSetSaveButtons[4].onClick.Invoke();
                }
            }
            yield return new WaitForSeconds(0.05f);
        }
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            if(Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
            {
                if (Input.GetKeyDown(KeyCode.S))
                    Screen.SetResolution(800, 600, false);
            }
        }

        if (main.toggles[10].isOn)
            sliders[3].interactable = true;
        else
            sliders[3].interactable = false;
        if (main.toggles[14].isOn)
            sliders[4].interactable = true;
        else
            sliders[4].interactable = false;

        if (toggles[0].isOn)//OFF
        {
            if (!dmgTxtLimitOff)
            {
                dmgTxtLimitOff = true;
            }
            noMoreDamageTxt = true;
            sliders[0].interactable = false;
        }
        else
        {
            if (dmgTxtLimitOff)
            {
                dmgTxtLimitOff = false;
            }
            sliders[0].interactable = true;
            if (GameObject.FindGameObjectsWithTag("damageText").Length >= sliders[0].value*100)
            {
                noMoreDamageTxt = true;
            }
            else
            {
                noMoreDamageTxt = false;
            }
        }
        dmgTxtLimit = sliders[0].value;
        if(main.GameController.currentCanvas == main.GameController.InventoryCanvas)
        {
            texts[0].text = tDigit(dmgTxtLimit * 100);
            texts[3].text = tDigit(main.S.customRange);
            texts[4].text = tDigit(main.S.customSpeed) + "%";
        }


        if (main.toggles[1].isOn)
            isDeathPanel = true;
        else
            isDeathPanel = false;

        if (main.toggles[7].isOn)
            isScientificNotification = true;
        else
            isScientificNotification = false;

        if (main.toggles[9].isOn)
        {
            if (!isPerformanceMode)
            {
                for (int i = 0; i < darkCanvas.Length; i++)
                {
                    darkCanvas[i].enabled = false;
                }
                isPerformanceMode = true;
            }
        }
        else
        {
            if (isPerformanceMode)
            {
                for (int i = 0; i < darkCanvas.Length; i++)
                {
                    darkCanvas[i].enabled = true;
                }
                isPerformanceMode = false;
            }
        }


        Save();             //Added
    }

    void Load()
    {
        sliders[1].value = main.S.bgmSliderValue;
        sliders[2].value = main.S.seSliderValue;
        sliders[3].value = main.S.customRange;
        sliders[4].value = main.S.customSpeed;
    }

    void Save()
    {
        main.sound.ChangeBGMVolume(sliders[1].value);
        main.sound.ChangeSEVolume(sliders[2].value);

        main.S.bgmSliderValue = sliders[1].value;
        main.S.seSliderValue = sliders[2].value;
        main.S.customRange = sliders[3].value;
        main.S.customSpeed = sliders[4].value;
    }
}
