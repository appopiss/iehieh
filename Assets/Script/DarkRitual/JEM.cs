using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using UnityEngine.EventSystems; 
using UnityEngine.Events;
using TMPro;

public class JEM : BASE, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler {

    // Use this for initialization
    void Awake() {
        StartBASE();
        workerNumText = gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        jemLevelText = gameObject.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
    }
    // Use this for initialization
    void Start() {
        InstantiateText();
        StartCoroutine(FillSlider());
        StartCoroutine(TextUpdate());
        if (isUnlocked)
            Destroy(Hatena);
    }
    TextMeshProUGUI workerNumText;
    TextMeshProUGUI jemLevelText;
    // Update is called once per frame
    void Update() {
        UpdateText();
    }
    IEnumerator TextUpdate()
    {
        yield return new WaitUntil(() => main.S.unleashDarkRitual);
        while (true)
        {
            workerNumText.text = tDigit(CurrentWorkerNum);
            jemLevelText.text = "Lv " + tDigit(JemLevel);
            yield return new WaitForSeconds(0.5f);
        }
    }
    public long CurrentWorkerNum
    {
        get
        {
            return main.SR.currentWorkerNum[(int)id];
        }
        set
        {
                main.SR.currentWorkerNum[(int)id] = value;
        }
    }
    public double JemLevel { get => main.S.JemLevel[(int)id]; set => main.S.JemLevel[(int)id] = value; }
    public enum ID
    {
        GoldGem = 0,
        GoldCapGem = 1,
        FuryGem = 2,
        HpRegenGem = 3,
        WorkerPowerGem = 4,
        MpRegenGem =5,
        Potion = 6,
        Nitro =7,
        BankCap = 8,
        Prof =9
    }
    public ID id;
    public enum CostKind
    {
        gold,
        stone,
        crystal,
        leaf,
        material
    }
    public CostKind costKind;
    public ArtiCtrl.MaterialList RequiredMaterial;
    public double cost;
    public double InitialReqCost = 100;
    public double BaseOfReqCost = 1.5;
    public double CurrentExp { get => main.S.CurrentExp[(int)id]; set => main.S.CurrentExp[(int)id] = value; }
    public bool isUnlocked { get => main.S.isJemUnlocked[(int)id]; set => main.S.isJemUnlocked[(int)id] = value; }
    double ReqExp()
    {
        return InitialReqCost * Math.Pow(BaseOfReqCost, JemLevel)
            * main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.DarkRitualGem].GetCurrentValue()
            * main.MissionMileStone.GemHalfTime();
    }
    bool isOver;
    public IEnumerator FillSlider()
    {
        while (true)
        {
            yield return new WaitUntil(() => CurrentWorkerNum > 0 || CurrentExp > 0);
            CurrentExp += main.DRctrl.WorkerPower() * CurrentWorkerNum * 0.5f;
            gameObject.transform.GetChild(1).GetComponent<Image>().fillAmount = (float)(CurrentExp / ReqExp());
            if(CurrentExp >= ReqExp())
            {
                CurrentExp -= ReqExp();
                JemLevel++;
            }
            yield return new WaitForSecondsRealtime(0.5f/Math.Max(Time.timeScale,1));
        }
    }
    public void DistributeWorker()
    {
        if (main.SR.WorkerNum == 0||!isUnlocked)
            return;

        long tempNum = 0;
        switch (main.DRctrl.J_buyMode)
        {
            case DRctrl.JemBuyMode.mode1:
                if (main.SR.WorkerNum == 0)
                    return;
                else
                    tempNum = 1;
                break;
            case DRctrl.JemBuyMode.mode10:
                if (main.SR.WorkerNum < 10)
                    tempNum = main.SR.WorkerNum;
                else
                    tempNum = 10;
                break;
            case DRctrl.JemBuyMode.mode100:
                if (main.SR.WorkerNum < 100)
                    tempNum = main.SR.WorkerNum;
                else
                    tempNum = 100;
                break;
            case DRctrl.JemBuyMode.mode1000:
                if (main.SR.WorkerNum < 1000)
                    tempNum = main.SR.WorkerNum;
                else
                    tempNum = 1000;
                break;
            case DRctrl.JemBuyMode.mode25p:
                tempNum = (long)(main.SR.WorkerNum * 0.25);
                break;
            case DRctrl.JemBuyMode.mode50p:
                tempNum = (long)(main.SR.WorkerNum * 0.50);
                break;
            case DRctrl.JemBuyMode.mode75p:
                tempNum = (long)(main.SR.WorkerNum * 0.75);
                break;
            case DRctrl.JemBuyMode.modeMax:
                tempNum = main.SR.WorkerNum;
                break;
        }

        CurrentWorkerNum += tempNum;
        main.SR.WorkerNum -= tempNum;
    }
    public void RetrieveWorker()
    {
        if (CurrentWorkerNum == 0||!isUnlocked)
            return;

        long tempNum = 0;
        switch (main.DRctrl.J_buyMode)
        {
            case DRctrl.JemBuyMode.mode1:
                if (CurrentWorkerNum == 0)
                    return;
                else
                    tempNum = 1;
                break;
            case DRctrl.JemBuyMode.mode10:
                if (CurrentWorkerNum < 10)
                    tempNum = CurrentWorkerNum;
                else
                    tempNum = 10;
                break;
            case DRctrl.JemBuyMode.mode100:
                if (CurrentWorkerNum < 100)
                    tempNum = CurrentWorkerNum;
                else
                    tempNum = 100;
                break;
            case DRctrl.JemBuyMode.mode1000:
                if (CurrentWorkerNum < 1000)
                    tempNum = CurrentWorkerNum;
                else
                    tempNum = 1000;
                break;
            case DRctrl.JemBuyMode.mode25p:
                tempNum = (long)(CurrentWorkerNum * 0.25);
                break;
            case DRctrl.JemBuyMode.mode50p:
                tempNum = (long)(CurrentWorkerNum * 0.50);
                break;
            case DRctrl.JemBuyMode.mode75p:
                tempNum = (long)(CurrentWorkerNum * 0.75);
                break;
            case DRctrl.JemBuyMode.modeMax:
                tempNum = CurrentWorkerNum;
                break;
        }

        CurrentWorkerNum -= tempNum;
        main.DRctrl.workerNum += tempNum;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isUnlocked)
        {
            switch (costKind)
            {
                case CostKind.gold:
                    if(main.SR.gold >= cost)
                    {
                        main.SR.gold -= cost;
                        Destroy(Hatena);
                        isUnlocked = true;
                        return;
                    }
                    break;
                case CostKind.stone:
                    if (main.SR.stone >= cost)
                    {
                        main.SR.stone -= cost;
                        Destroy(Hatena);
                        isUnlocked = true;
                        return;
                    };
                    break;
                case CostKind.crystal:
                    if (main.SR.cristal >= cost)
                    {
                        main.SR.cristal -= cost;
                        Destroy(Hatena);
                        isUnlocked = true;
                        return;
                    }
                    break;
                case CostKind.leaf:
                    if (main.SR.leaf >= cost)
                    {
                        main.SR.leaf -= cost;
                        Destroy(Hatena);
                        isUnlocked = true;
                        return;
                    }
                    break;
                case CostKind.material:
                    if (main.ArtiCtrl.CurrentMaterial[RequiredMaterial] >= 1)
                    {
                        main.ArtiCtrl.CurrentMaterial[RequiredMaterial] -= 1;
                        Destroy(Hatena);
                        isUnlocked = true;
                        return;
                    }
                    break;
            }
        }

        if (eventData.pointerId == -1)
            DistributeWorker();
        else if(eventData.pointerId == -2)
            RetrieveWorker();
    }

    public double EffectBonus()
    {
        return (1 + main.MissionMileStone.JemBonus()) * (1 + Convert.ToInt32(main.S.isDarkRitualPurchase));
    }
    public double Effect()
    {
        if (!isUnlocked)
            return 0;
        switch (id)
        {
            case ID.GoldGem:
                return JemLevel * 0.01 * 0.1 * EffectBonus() ;
            case ID.GoldCapGem:
                return JemLevel * 0.01 * 0.05 * EffectBonus();
            case ID.FuryGem:
                return JemLevel * 0.01 * 0.05 * EffectBonus();
            case ID.HpRegenGem:
                return (0.00001 * Math.Min(JemLevel, 1) + JemLevel * 0.01 * 0.001) * EffectBonus();//初期値0.001%/s、+0.001%/level  
            case ID.WorkerPowerGem:
                return JemLevel * 0.01 * 0.05 * EffectBonus();
            case ID.MpRegenGem:
                return JemLevel * 0.01 * 0.05 * EffectBonus();
            case ID.Potion:
                return JemLevel * 0.01 * 0.05 * EffectBonus();
            case ID.Nitro:
                return JemLevel * 10 * EffectBonus();
            case ID.BankCap:
                return JemLevel * 0.01 * 0.05 * EffectBonus();
            case ID.Prof:
                return JemLevel * 0.01 * 0.25 * EffectBonus();
            default:
                return 0;
        }
    }
    GameObject window;
    GameObject unlockWindow;
    Image Icon;
    Image OrigIcon;
    //Image FillIcon;
    //Image OrigFillIcon;
    TextMeshProUGUI PercentText;
    TextMeshProUGUI CurrentDistributedWorkersText;
    TextMeshProUGUI TimesToNextLevelUpText;
    TextMeshProUGUI EffectText;
    TextMeshProUGUI CostText;
    TextMeshProUGUI PopupName;
    GameObject Hatena;
    string Name;
    public void InstantiateText()
    {
        window = Instantiate(main.P_texts[14], main.WindowShowCanvas);
        unlockWindow = Instantiate(main.P_texts[15], main.WindowShowCanvas);
        PercentText = window.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        Icon = window.transform.GetChild(0).GetComponentInChildren<Image>().gameObject.transform.GetChild(0).GetComponentInChildren<Image>();
        OrigIcon = gameObject.transform.GetChild(0).GetComponent<Image>();
        //FillIcon = window.transform.GetChild(0).GetComponentsInChildren<Image>()[2];
        //OrigFillIcon = gameObject.transform.GetChild(1).GetComponent<Image>();

        TimesToNextLevelUpText = window.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        EffectText = window.transform.GetChild(5).GetComponent<TextMeshProUGUI>();
        CostText = unlockWindow.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        Name = gameObject.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text;
        PopupName = window.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        Hatena = gameObject.transform.GetChild(5).gameObject;
    }
    public void UpdateText()
    {
        if (isOver)
        {
            if (!isUnlocked)
            {
                setActive(unlockWindow);
                setFalse(window);
            }
            else
            {
                setFalse(unlockWindow);
                setActive(window);
            }
        }
        else
        {
            setFalse(window);
            setFalse(unlockWindow);
        }

        if (window.activeSelf)
        {
            if (isOver)
            {
                Icon.sprite = OrigIcon.sprite;
                //FillIcon.sprite = OrigFillIcon.sprite;
                PopupName.text = "                 " + Name + " Gem < <color=green>Lv " + tDigit(JemLevel) + "</color> >";
                PercentText.text = "                         - Progress : " + tDigit(CurrentExp*100 / ReqExp())+ "%\n                         - Worker : " + tDigit(CurrentWorkerNum) + "\n ";
                if (CurrentWorkerNum > 0)
                {
                    TimesToNextLevelUpText.text = "- " +DoubleTimeToDate((ReqExp() - CurrentExp) / (main.DRctrl.WorkerPower() * CurrentWorkerNum));
                }
                else
                {
                    TimesToNextLevelUpText.text = "- " + DoubleTimeToDate((ReqExp() - CurrentExp) / (main.DRctrl.WorkerPower() * 1))
                        +" when you distribute 1 Worker on this.";
                }
                switch (id)
                {
                    case ID.GoldGem:
                        EffectText.text = "- Increase Gained Gold by " + percent(Effect());
                        break;
                    case ID.GoldCapGem:
                        EffectText.text = "- Increase Gold Cap by " + percent(Effect());
                        break;
                    case ID.FuryGem:
                        EffectText.text = "- Increase Overall Damage by " + percent(Effect());
                        break;
                    case ID.HpRegenGem:
                        EffectText.text = "- Regenerate HP : " + percent(Effect(),3) + " / s";
                        break;
                    case ID.WorkerPowerGem:
                        EffectText.text = "- Increase Worker Power by " + percent(Effect());
                        break;
                    case ID.MpRegenGem:
                        EffectText.text = "- Regenerate MP : " + percent(Effect()) + " / s";
                        break;
                    case ID.Potion:
                        EffectText.text = "- Increase the purification speed of water by  " + percent(Effect());
                        break;
                    case ID.Nitro:
                        EffectText.text = "- Increase the cap of Nitro charger by " + tDigit(Effect());
                        break;
                    case ID.BankCap:
                        EffectText.text = "- Increase Slime Coin Cap by " + percent(Effect());
                        break;
                    case ID.Prof:
                        EffectText.text = "- Increase Gained Skill Proficiency for all skills by " + percent(Effect());
                        break;
                }
            }


            //if (window != null)
            //{
            //    if (Input.mousePosition.y >= 300 && Input.mousePosition.x >= 400)
            //    {
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(0f, -50.0f);
            //    }
            //    else if (Input.mousePosition.y >= 300 && Input.mousePosition.x < 400)
            //    {
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(0f, -50.0f);
            //    }
            //    else if (Input.mousePosition.y < 300 && Input.mousePosition.x > 400)
            //    {
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(0f, -50.0f);
            //    }
            //    else if (Input.mousePosition.y < 300 && Input.mousePosition.x < 400)
            //    {
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(0f, -50.0f);
            //    }
            //}
        }

        if (unlockWindow.activeSelf)
        {
            if (isOver)
            {
                unlockWindow.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Name;
                switch (costKind)
                {
                    case CostKind.gold:
                        CostText.text = "Gold " + tDigit(cost);
                        break;
                    case CostKind.stone:
                        CostText.text = "<sprite=1>       " + tDigit(cost);
                        break;
                    case CostKind.crystal:
                        CostText.text = "<sprite=2>       " + tDigit(cost);
                        break;
                    case CostKind.leaf:
                        CostText.text = "<sprite=3>       " + tDigit(cost);
                        break;
                    case CostKind.material:
                        CostText.text = main.ArtiCtrl.ConvertEnum(RequiredMaterial) +" " +main.ArtiCtrl.CurrentMaterial[RequiredMaterial] +  " / 1";
                        break;
                }
            }


            //if (unlockWindow != null)
            //{
            //    if (Input.mousePosition.y >= 300 && Input.mousePosition.x >= 400)
            //    {
            //        unlockWindow.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) +  new Vector3(100f, 50.0f);
            //    }
            //    else if (Input.mousePosition.y >= 300 && Input.mousePosition.x < 400)
            //    {
            //        unlockWindow.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) +  new Vector3(100f, 50.0f);
            //    }
            //    else if (Input.mousePosition.y < 300 && Input.mousePosition.x > 400)
            //    {
            //        unlockWindow.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) +  new Vector3(100f, 50.0f);
            //    }
            //    else if (Input.mousePosition.y < 300 && Input.mousePosition.x < 400)
            //    {
            //        unlockWindow.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(100f, 50.0f);
            //    }
            //}
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOver = false;
    }
}
