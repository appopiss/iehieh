using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using static UsefulMethod;
using TMPro;
using static ArtiCtrl;

public class AlchemyCtrl : BASE
{

    public Button[] QuantityButtons;
    public Button capExpandButton;
    public Button autoExpandButton;
    public Button autoUseButton;
    public Button useAllButton;
    public Button[] inventoryChangeButtons;
    public TextMeshProUGUI autoExpandText;
    public TextMeshProUGUI autoUseText;
    public RectTransform[] QuantityCanvas;
    public TextMeshProUGUI quantityText;
    public TextMeshProUGUI capText;
    public TextMeshProUGUI DPSText;
    public Slider waterSlider;
    public Transform AlchemyInventory;
    public GameObject[] AlchemyIcons;
    public GameObject[] AlchemyEffectTextAry;

    [NonSerialized]
    public float DPSmulFactor;

    public int AlchemyInventoryCap()
    {
        return 16 + Math.Min(4 * (main.S.ExpandAlchemyInventory1 + main.S.ExpandAlchemyInventory2 + main.S.ExpandAlchemyInventory3 + main.S.ExpandAlchemyInventory4),16);
    }

    public float waterDPS()//mL単位
    {
        float tempDPS;
        tempDPS = (0.1f + (float) main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.Alkahest].GetCurrentValue()+ main.SR.waterAddDPSByPotion) * (1 + DPSmulFactor) * (1 + main.MissionMileStone.WaterBonus()) * (1 + main.SR.DPSBankFactor) * (float)(1 + main.jems[(int)JEM.ID.Potion].Effect()) * (float)(1 + main.Ascends[17].calculateCurrentValue()) * (float)(1 + main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.Alkahest].GetCurrentValue());
        if(main.NewArtifacts[(int)ARTIFACT.ArtifactName.ArtificialGill].isEquipped)
            tempDPS *= (float)(1+main.NewArtifacts[(int)ARTIFACT.ArtifactName.ArtificialGill].level * 0.01f * (1+main.NewArtifacts[(int)ARTIFACT.ArtifactName.ArtificialGill].EvolutionNum));
        return tempDPS;
    }
    public float waterValue()
    {
        return main.SR.waterValue[main.SR.alchemyQuantity];
    }
    public float waterMaxValue()
    {
        return Mathf.Pow(10, main.SR.alchemyQuantity);
    }
    public void showCapText(int index)
    {
        capText.text = main.TextEdit(new string[] { currentWater(index).ToString(), " / ", waterCap(index).ToString() });
    }
    public int currentWater(int index)
    {
        return main.SR.currentWater[index];
    }
    public int waterCap(int index)
    {
        return (1 + main.SR.waterCap[index]);
    }
    public bool canAlchemy(int alchemyQuantity = -1)
    {
        if (alchemyQuantity == -1)
        {
            if (currentWater(main.SR.alchemyQuantity) > 0 && AlchemyInventory.childCount < main.alchemyController.AlchemyInventoryCap())
                return true;
            else
                return false;
        }
        else
        {
            if (currentWater(alchemyQuantity) > 0 && AlchemyInventory.childCount < main.alchemyController.AlchemyInventoryCap())
                return true;
            else
                return false;
        }
    }
    // Use this for initialization
    void Awake()
    {
        StartBASE();
    }
    // Use this for initialization
    void Start()
    {
        QuantityButtons[0].onClick.AddListener(()=>ChangeQuantity(0));//1mL
        QuantityButtons[1].onClick.AddListener(()=>ChangeQuantity(1));//10mL
        QuantityButtons[2].onClick.AddListener(()=>ChangeQuantity(2));//100mL
        QuantityButtons[3].onClick.AddListener(()=>ChangeQuantity(3));//1L
        QuantityButtons[4].onClick.AddListener(()=>ChangeQuantity(4));//10L
        QuantityButtons[5].onClick.AddListener(()=>ChangeQuantity(5));//100L
        QuantityButtons[6].onClick.AddListener(()=>ChangeQuantity(6));//1KL
        QuantityButtons[7].onClick.AddListener(()=>ChangeQuantity(7));//10KL
        QuantityButtons[8].onClick.AddListener(()=>ChangeQuantity(8));//100KL
        QuantityButtons[9].onClick.AddListener(()=>ChangeQuantity(9));//1ML
        QuantityButtons[10].onClick.AddListener(()=>ChangeQuantity(10));//10ML
        QuantityButtons[11].onClick.AddListener(()=>ChangeQuantity(11));//100ML
        QuantityButtons[12].onClick.AddListener(()=>ChangeQuantity(12));//1BL
        QuantityButtons[13].onClick.AddListener(()=>ChangeQuantity(13));//10BL

        capExpandButton.onClick.AddListener(()=>CapExpand(main.SR.alchemyQuantity));
        autoExpandButton.onClick.AddListener(ChangeAuto);
        autoUseButton.onClick.AddListener(ChangeAutoUse);
        useAllButton.onClick.AddListener(UseAll);

        StartCoroutine(PurifyWater());
        StartCoroutine(ShowWaterValue());
        FirstInstantiateItems();
        for (int i = 0; i < 13; i++)
        {
            if (main.SR.waterCap[i] >= 9)
            {
                QuantityButtons[i + 1].interactable = true;
                QuantityButtons[i + 1].gameObject.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
            }
            else
            {
                QuantityButtons[i + 1].interactable = false;
                QuantityButtons[i + 1].gameObject.GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
            }
        }

        StartCoroutine(SaveItems());
        QuantityCanvas[main.SR.alchemyQuantity].anchoredPosition += Y;
        QuantityButtons[main.SR.alchemyQuantity].onClick.Invoke();

        if(main.S.isAuto)
            autoExpandText.color = Color.green;
        else
            autoExpandText.color = Color.white;
        if (main.S.isAutoUse)
            autoUseText.color = Color.green;
        else
            autoUseText.color = Color.white;
        inventoryChangeButtons[0].onClick.AddListener(() => AlchemyInventory.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0));
        inventoryChangeButtons[1].onClick.AddListener(() => AlchemyInventory.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 76));

    }

    void UseAll()
    {
        for (int i = 0; i < AlchemyInventory.childCount; i++)
        {
            AlchemyInventory.GetChild(i).GetComponent<CONSUMEITEM>().isClicked = true;
            AlchemyInventory.GetChild(i).GetComponent<CONSUMEITEM>().DefinedEffect();
        }
    }

    public void ChangeAuto()
    {
        if (main.S.isAuto)
        {
            main.S.isAuto = false;
            autoExpandText.color = Color.white;
        }
        else
        {
            main.S.isAuto = true;
            autoExpandText.color = Color.green;
        }
    }
    public void ChangeAutoUse()
    {
        if (main.S.isAutoUse)
        {
            main.S.isAutoUse = false;
            autoUseText.color = Color.white;
        }
        else
        {
            main.S.isAutoUse = true;
            autoUseText.color = Color.green;
        }
    }

    void CapExpand(int index)
    {
        main.SR.DPSBankFactor += (float)main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.potion].calculateCurrentValue();
        main.SR.currentWater[index] = 0;
        main.SR.waterCap[index] += 1;
        main.SR.reachedCap += 1;
        main.S.maxReachedCap = Math.Max(main.S.maxReachedCap, main.SR.reachedCap);
        showCapText(main.SR.alchemyQuantity);
        for (int i = 0; i < 13; i++)
        {
            if (main.SR.waterCap[i] >= 9)
            {
                QuantityButtons[i + 1].interactable = true;
                QuantityButtons[i + 1].gameObject.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                //if (main.S.isAuto)
                //    QuantityButtons[i + 1].onClick.Invoke();
            }
            else
            {
                QuantityButtons[i + 1].interactable = false;
                QuantityButtons[i + 1].gameObject.GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
            }
        }

    }

    Vector2 Y = new Vector2(0, 400);
    void ChangeQuantity(int num)
    {
        switch (num)
        {
            case 0:
                quantityText.text = "1 mL vial";
                break;
            case 1:
                quantityText.text = "10 mL vial";
                break;
            case 2:
                quantityText.text = "100 mL cup";
                break;
            case 3:
                quantityText.text = "1 L bottle";
                break;
            case 4:
                quantityText.text = "10 L bottle";
                break;
            case 5:
                quantityText.text = "100 L barrel";
                break;
            case 6:
                quantityText.text = "1K L barrel";
                break;
            case 7:
                quantityText.text = "10K L barrel";
                break;
            case 8:
                quantityText.text = "100K L pool";
                break;
            case 9:
                quantityText.text = "1M L pool";
                break;
            case 10:
                quantityText.text = "10M L tank";
                break;
            case 11:
                quantityText.text = "100M L tank";
                break;
            case 12:
                quantityText.text = "1B L dam";
                break;
            case 13:
                quantityText.text = "10B L dam";
                break;
            default:
                break;
        }
        showCapText(main.SR.alchemyQuantity);
        if (main.SR.alchemyQuantity == num)
            return;
        QuantityCanvas[main.SR.alchemyQuantity].anchoredPosition -= Y;
        QuantityCanvas[num].anchoredPosition += Y;
        main.SR.alchemyQuantity = num;
    }

    IEnumerator ShowWaterValue()
    {
        while (true)
        {
            if (main.GameController.currentCanvas == main.GameController.ArtifactCanvas)
            {
                showCapText(main.SR.alchemyQuantity);
                alchemyPointText.text = main.TextEdit(new string[] { "Alchemy Point : ", tDigit(alchemyPoint()) });
                if (waterDPS() < 1000f)
                    DPSText.text = main.TextEdit(new string[] { "( + ", tDigit(waterDPS(), 3), " mL / s )" });
                else if (waterDPS() < 1000000f)
                    DPSText.text = main.TextEdit(new string[] { "( + ", tDigit(waterDPS() / 1000f, 3), " L / s )" });
                else if (waterDPS() < 1000000000f)
                    DPSText.text = main.TextEdit(new string[] { "( + ", tDigit(waterDPS() / 1000000f, 3), "K L / s )" });
                else
                    DPSText.text = main.TextEdit(new string[] { "( + ", tDigit(waterDPS() / 1000000f, 3), "M L / s )" });
                waterSlider.value = waterValue() / waterMaxValue();
            }
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator PurifyWater()
    {
        while (true)
        {

            if (main.S.WaterALL)//全て同時にたまる
            {
                for (int i = 0; i < main.SR.waterValue.Length; i++)
                {
                    if (main.SR.currentWater[i] < main.SR.waterCap[i] + 1)
                        main.SR.waterValue[i] += waterDPS() * 0.05f;
                    if (main.SR.waterValue[i] >= Mathf.Pow(10, i))
                    {
                        main.SR.waterValue[i] = Mathf.Pow(10, i);
                        if (main.SR.currentWater[i] < main.SR.waterCap[i] + 1)
                        {
                            main.SR.currentWater[i] += 1;
                            main.SR.waterValue[i] = 0;
                            showCapText(main.SR.alchemyQuantity);
                        }
                    }
                }
            }
            else//個別にたまる
            {
                if (currentWater(main.SR.alchemyQuantity) < waterCap(main.SR.alchemyQuantity))
                    main.SR.waterValue[main.SR.alchemyQuantity] += waterDPS() * 0.05f;
                if (waterValue() >= waterMaxValue())
                {
                    main.SR.waterValue[main.SR.alchemyQuantity] = waterMaxValue();
                    if (currentWater(main.SR.alchemyQuantity) < waterCap(main.SR.alchemyQuantity))
                    {
                        main.SR.currentWater[main.SR.alchemyQuantity] += 1;
                        main.SR.waterValue[main.SR.alchemyQuantity] = 0;
                        showCapText(main.SR.alchemyQuantity);
                    }
                }
            }
            yield return new WaitForSecondsRealtime(0.05f/ Math.Max(Time.timeScale,1));
        }
    }    

    //public GameObject HideImage;
    void Update()
    {
        if (main.S.isAuto && currentWater((int)(Math.Min(main.SR.reachedCap / 9d, 13))) >= waterCap((int)(Math.Min(main.SR.reachedCap / 9d,13))))
        {
            if (main.SR.reachedCap < main.S.maxReachedCap)
                CapExpand((int)Math.Min(main.SR.reachedCap / 9d, 13));
            else
                ChangeAuto();
        }

        if (currentWater(main.SR.alchemyQuantity) >= waterCap(main.SR.alchemyQuantity))
        {
            if (main.SR.alchemyQuantity == 13)
            {
                capExpandButton.interactable = true;
            }
            else if (waterCap(main.SR.alchemyQuantity) < 10)
            {
                capExpandButton.interactable = true;
            }
            else
                capExpandButton.interactable = false;
        }
        else
            capExpandButton.interactable = false;

        if (main.S.AutoExpandAlchemy && (main.SR.alchemyQuantity == 13 || waterCap(main.SR.alchemyQuantity) < 10) && main.SR.reachedCap < main.S.maxReachedCap)
        {
            autoExpandButton.interactable = true;
        }
        else
        {
            autoExpandButton.interactable = false;
        }

        if (DPSmulFactor > 0)
            setActive(AlchemyEffectTextAry[0]);
        else
            setFalse(AlchemyEffectTextAry[0]);
        if (main.idleBackGround.stoneAlchemyFactor > 0)
            setActive(AlchemyEffectTextAry[1]);
        else
            setFalse(AlchemyEffectTextAry[1]);
        if (main.idleBackGround.crystalAlchemyFactor > 0)
            setActive(AlchemyEffectTextAry[2]);
        else
            setFalse(AlchemyEffectTextAry[2]);
        if (main.idleBackGround.leafAlchemyFactor > 0)
            setActive(AlchemyEffectTextAry[3]);
        else
            setFalse(AlchemyEffectTextAry[3]);
        if (HpRegenFactor > 0)
            setActive(AlchemyEffectTextAry[4]);
        else
            setFalse(AlchemyEffectTextAry[4]);
        if (MpRegenFactor > 0)
            setActive(AlchemyEffectTextAry[5]);
        else
            setFalse(AlchemyEffectTextAry[5]);
        if (main.ally.alchemyAtkFactor > 0)
            setActive(AlchemyEffectTextAry[6]);
        else
            setFalse(AlchemyEffectTextAry[6]);
        if (main.ally.alchemyMAtkFactor > 0)
            setActive(AlchemyEffectTextAry[7]);
        else
            setFalse(AlchemyEffectTextAry[7]);
        if (main.ally.alchemyDefFactor > 0)
            setActive(AlchemyEffectTextAry[8]);
        else
            setFalse(AlchemyEffectTextAry[8]);
        if (main.ally.alchemyMDefFactor > 0)
            setActive(AlchemyEffectTextAry[9]);
        else
            setFalse(AlchemyEffectTextAry[9]);
        if (goldFactor > 0)
            setActive(AlchemyEffectTextAry[10]);
        else
            setFalse(AlchemyEffectTextAry[10]);
        if (expFactor > 0)
            setActive(AlchemyEffectTextAry[11]);
        else
            setFalse(AlchemyEffectTextAry[11]);
        if (dropFactor > 0)
            setActive(AlchemyEffectTextAry[12]);
        else
            setFalse(AlchemyEffectTextAry[12]);
        if (main.ally.alchemyDebuffResistanceFactor > 0)
            setActive(AlchemyEffectTextAry[13]);
        else
            setFalse(AlchemyEffectTextAry[13]);
        if (bankEfficiencyFactor > 0)
            setActive(AlchemyEffectTextAry[14]);
        else
            setFalse(AlchemyEffectTextAry[14]);

        if (main.GameController.currentCanvas==main.GameController.ArtifactCanvas)
        {
            if (main.S.AutoExpandAlchemy)
                setActive(autoExpandButton.gameObject);
            else
                setFalse(autoExpandButton.gameObject);

            if (Input.GetKeyDown(KeyCode.U) && gameObject.GetComponent<RectTransform>().anchoredPosition.x >= 0)
                UseAll();

            if (AlchemyInventoryCap() > 16)
            {
                setActive(inventoryChangeButtons[0].gameObject);
                setActive(inventoryChangeButtons[1].gameObject);
            }
            else
            {
                setFalse(inventoryChangeButtons[0].gameObject);
                setFalse(inventoryChangeButtons[1].gameObject);
            }
        }


    }

    public void StartResourseBoost(int resourseIndex, int multiNum, float duration)
    {
        StartCoroutine(ResourseBoost(resourseIndex, multiNum, duration));
    }

    public IEnumerator ResourseBoost(int resourseIndex, int multiNum, float duration)
    {
        switch (resourseIndex)
        {
            case 0:
                main.idleBackGround.stoneAlchemyFactor += Math.Max(multiNum, 0);
                AlchemyEffectTextAry[1].GetComponent<TextMeshProUGUI>().text = main.TextEdit(new string[] { "Stone Production + " + percent(main.idleBackGround.stoneAlchemyFactor, 0) });
                break;
            case 1:
                main.idleBackGround.crystalAlchemyFactor += Math.Max(multiNum, 0);
                AlchemyEffectTextAry[2].GetComponent<TextMeshProUGUI>().text = main.TextEdit(new string[] { "Crystal Production + " + percent(main.idleBackGround.crystalAlchemyFactor, 0) });
                break;
            case 2:
                main.idleBackGround.leafAlchemyFactor += Math.Max(multiNum, 0);
                AlchemyEffectTextAry[3].GetComponent<TextMeshProUGUI>().text = main.TextEdit(new string[] { "Leaf Production + " + percent(main.idleBackGround.leafAlchemyFactor, 0) });
                break;
            default:
                break;
        }
        yield return new WaitForSecondsRealtime(duration / Math.Max(Time.timeScale, 1));
        switch (resourseIndex)
        {
            case 0:
                main.idleBackGround.stoneAlchemyFactor -= Math.Max(multiNum, 0);
                AlchemyEffectTextAry[1].GetComponent<TextMeshProUGUI>().text = main.TextEdit(new string[] { "Stone Production + " + percent(main.idleBackGround.stoneAlchemyFactor, 0) });
                break;
            case 1:
                main.idleBackGround.crystalAlchemyFactor -= Math.Max(multiNum, 0);
                AlchemyEffectTextAry[2].GetComponent<TextMeshProUGUI>().text = main.TextEdit(new string[] { "Crystal Production + " + percent(main.idleBackGround.crystalAlchemyFactor, 0) });
                break;
            case 2:
                main.idleBackGround.leafAlchemyFactor -= Math.Max(multiNum, 0);
                AlchemyEffectTextAry[3].GetComponent<TextMeshProUGUI>().text = main.TextEdit(new string[] { "Leaf Production + " + percent(main.idleBackGround.leafAlchemyFactor, 0) });
                break;
            default:
                break;
        }
    }

    public double goldFactor;
    public void StartGoldBoost(int addNum, float duration)
    {
        StartCoroutine(GoldBoost(addNum, duration));
    }

    public IEnumerator GoldBoost(int addNum, float duration)
    {
        goldFactor += addNum;
        AlchemyEffectTextAry[10].GetComponent<TextMeshProUGUI>().text = main.TextEdit(new string[] { "Gold + " + tDigit(goldFactor) });
        yield return new WaitForSecondsRealtime(duration / Math.Max(Time.timeScale, 1));
        goldFactor -= addNum;
        AlchemyEffectTextAry[10].GetComponent<TextMeshProUGUI>().text = main.TextEdit(new string[] { "Gold + " + tDigit(goldFactor) });
    }

    public double expFactor;
    public void StartExpBoost(int addNum, float duration)
    {
        StartCoroutine(ExpBoost(addNum, duration));
    }

    public IEnumerator ExpBoost(int addNum, float duration)
    {
        expFactor += addNum;
        AlchemyEffectTextAry[11].GetComponent<TextMeshProUGUI>().text = main.TextEdit(new string[] { "EXP + " + tDigit(expFactor) });
        yield return new WaitForSecondsRealtime (duration / Math.Max(Time.timeScale, 1));
        expFactor -= addNum;
        AlchemyEffectTextAry[11].GetComponent<TextMeshProUGUI>().text = main.TextEdit(new string[] { "EXP + " + tDigit(expFactor) });
    }

    public void StartAtkBoost(double mulNum, float duration)
    {
        StartCoroutine(AtkBoost(mulNum, duration));
    }
    public IEnumerator AtkBoost(double mulNum, float duration)
    {
        main.ally.alchemyAtkFactor += mulNum/100d;
        AlchemyEffectTextAry[6].GetComponent<TextMeshProUGUI>().text = main.TextEdit(new string[] { "ATK + " + percent(main.ally.alchemyAtkFactor) });
        yield return new WaitForSecondsRealtime(duration / Math.Max(Time.timeScale, 1));
        main.ally.alchemyAtkFactor -= mulNum / 100d;
        AlchemyEffectTextAry[6].GetComponent<TextMeshProUGUI>().text = main.TextEdit(new string[] { "ATK + " + percent(main.ally.alchemyAtkFactor) });
    }
    public void StartMAtkBoost(double mulNum, float duration)
    {
        StartCoroutine(MAtkBoost(mulNum, duration));
    }
    public IEnumerator MAtkBoost(double mulNum, float duration)
    {
        main.ally.alchemyMAtkFactor += mulNum/100d;
        AlchemyEffectTextAry[7].GetComponent<TextMeshProUGUI>().text = main.TextEdit(new string[] { "MATK + " + percent(main.ally.alchemyMAtkFactor) });
        yield return new WaitForSecondsRealtime(duration / Math.Max(Time.timeScale, 1));
        main.ally.alchemyMAtkFactor -= mulNum / 100d;
        AlchemyEffectTextAry[7].GetComponent<TextMeshProUGUI>().text = main.TextEdit(new string[] { "MATK + " + percent(main.ally.alchemyMAtkFactor) });
    }
    public void StartDefBoost(double mulNum, float duration)
    {
        StartCoroutine(DefBoost(mulNum, duration));
    }
    public IEnumerator DefBoost(double mulNum, float duration)
    {
        main.ally.alchemyDefFactor += mulNum/100d;
        AlchemyEffectTextAry[8].GetComponent<TextMeshProUGUI>().text = main.TextEdit(new string[] { "DEF + " + percent(main.ally.alchemyDefFactor) });
        yield return new WaitForSecondsRealtime(duration / Math.Max(Time.timeScale, 1));
        main.ally.alchemyDefFactor -= mulNum / 100d;
        AlchemyEffectTextAry[8].GetComponent<TextMeshProUGUI>().text = main.TextEdit(new string[] { "DEF + " + percent(main.ally.alchemyDefFactor) });
    }
    public void StartMDefBoost(double mulNum, float duration)
    {
        StartCoroutine(MDefBoost(mulNum, duration));
    }
    public IEnumerator MDefBoost(double mulNum, float duration)
    {
        main.ally.alchemyMDefFactor += mulNum/100d;
        AlchemyEffectTextAry[9].GetComponent<TextMeshProUGUI>().text = main.TextEdit(new string[] { "MDEF + " + percent(main.ally.alchemyMDefFactor) });
        yield return new WaitForSecondsRealtime(duration / Math.Max(Time.timeScale, 1));
        main.ally.alchemyMDefFactor -= mulNum / 100d;
        AlchemyEffectTextAry[9].GetComponent<TextMeshProUGUI>().text = main.TextEdit(new string[] { "MDEF + " + percent(main.ally.alchemyMDefFactor) });
    }
    public void StartCureCor(int resistancePercent, float duration)
    {
        StartCoroutine(CureCor(resistancePercent, duration));
    }
    public IEnumerator CureCor(int resitancePercent, float duration)
    {
        foreach (Transform child in main.StatusIconCanvas.transform)
        {
            if (child.GetComponent<ABNORMAL>().debuff != Main.Debuff.nothing)
            {
                Destroy(child.gameObject);
            }
        }
        main.ally.alchemyDebuffResistanceFactor += resitancePercent*100;
        AlchemyEffectTextAry[13].GetComponent<TextMeshProUGUI>().text = main.TextEdit(new string[] { "Debuff resistance + " + tDigit(main.ally.alchemyDebuffResistanceFactor/100) + "%" });
        yield return new WaitForSecondsRealtime(duration / Math.Max(Time.timeScale, 1));
        main.ally.alchemyDebuffResistanceFactor -= resitancePercent*100;
        AlchemyEffectTextAry[13].GetComponent<TextMeshProUGUI>().text = main.TextEdit(new string[] { "Debuff resistance + " + tDigit(main.ally.alchemyDebuffResistanceFactor / 100) + "%" });
    }

    public void StartPureBoost(float mulNum, float duration)
    {
        StartCoroutine(PureBoost(mulNum, duration));
    }
    public IEnumerator PureBoost(float mulNum, float duration)
    {
        DPSmulFactor += mulNum;
        AlchemyEffectTextAry[0].GetComponent<TextMeshProUGUI>().text = main.TextEdit(new string[] { "Mysterious Water + " + percent(DPSmulFactor, 0) });
        yield return new WaitForSecondsRealtime(duration / Math.Max(Time.timeScale, 1));
        DPSmulFactor -= mulNum;
        AlchemyEffectTextAry[0].GetComponent<TextMeshProUGUI>().text = main.TextEdit(new string[] { "Mysterious Water + " + percent(DPSmulFactor, 0) });
    }

    public double HpRegenFactor;
    public double MpRegenFactor;
    public void StartHpRegen(double percentNum, float duration)
    {
        StartCoroutine(HpRegen(percentNum, duration));
    }
    public IEnumerator HpRegen(double percentNum, float duration)
    {
        HpRegenFactor += percentNum/100;
        AlchemyEffectTextAry[4].GetComponent<TextMeshProUGUI>().text = main.TextEdit(new string[] { "Regenerate HP + " + percent(HpRegenFactor, 2) + " / s" });
        yield return new WaitForSecondsRealtime(duration / Math.Max(Time.timeScale, 1));
        HpRegenFactor -= percentNum / 100;
        AlchemyEffectTextAry[4].GetComponent<TextMeshProUGUI>().text = main.TextEdit(new string[] { "Regenerate HP + " + percent(HpRegenFactor, 2) + " / s" });
    }
    public void StartMpRegen(double percentNum, float duration)
    {
        StartCoroutine(MpRegen(percentNum, duration));
    }
    public IEnumerator MpRegen(double percentNum, float duration)
    {
        MpRegenFactor += percentNum/100;
        AlchemyEffectTextAry[5].GetComponent<TextMeshProUGUI>().text = main.TextEdit(new string[] { "Regenerate MP + " + percent(MpRegenFactor, 2) + " / s" });
        yield return new WaitForSecondsRealtime(duration / Math.Max(Time.timeScale, 1));
        MpRegenFactor -= percentNum / 100;
        AlchemyEffectTextAry[5].GetComponent<TextMeshProUGUI>().text = main.TextEdit(new string[] { "Regenerate MP + " + percent(MpRegenFactor, 2) + " / s" });
    }

    [NonSerialized]
    public double bankEfficiencyFactor;
    float bankDuration;
    bool isAlreadyStartBank;
    public void StartBankBoost(float mulNum, float duration)
    {
        StartCoroutine(BankBoost(mulNum, duration));
    }
    public IEnumerator BankBoost(float mulNum, float duration)
    {
        bankDuration += duration;
        if (isAlreadyStartBank)
        {
            yield break;
        }
        else
        {
            isAlreadyStartBank = true;
        }
        bankEfficiencyFactor = Math.Max(bankEfficiencyFactor, mulNum);
        AlchemyEffectTextAry[14].GetComponent<TextMeshProUGUI>().text = main.TextEdit(new string[] { "Slime Coin Efficiency + " + percent(bankEfficiencyFactor) });
        while (true)
        {
            yield return new WaitForSecondsRealtime(1f / Math.Max(Time.timeScale, 1));
            bankDuration -= 1;
            if (bankDuration <= 0)
            {
                isAlreadyStartBank = false;
                bankEfficiencyFactor = 0;
                AlchemyEffectTextAry[14].GetComponent<TextMeshProUGUI>().text = main.TextEdit(new string[] { "Slime Coin Efficiency + " + percent(bankEfficiencyFactor) });
                yield break;
            }
        }
    }


    [NonSerialized]
    public double dropFactor;
    float dropDuration;
    bool isAlreadyStart;
    public void StartDropBoost(float mulNum, float duration)
    {
        StartCoroutine(DropBoost(mulNum, duration));
    }
    public IEnumerator DropBoost(float mulNum, float duration)
    {
        dropDuration += duration;
        if (isAlreadyStart)
        {
            yield break;
        }
        else
        {
            isAlreadyStart = true;
        }
        dropFactor = Math.Max(dropFactor,mulNum);
        AlchemyEffectTextAry[12].GetComponent<TextMeshProUGUI>().text = main.TextEdit(new string[] { "Drop Chance + " + percent(dropFactor) });
        while (true)
        {
            yield return new WaitForSecondsRealtime(1f / Math.Max(Time.timeScale, 1));
            dropDuration -= 1;
            if (dropDuration <= 0)
            {
                isAlreadyStart = false;
                dropFactor = 0;
                AlchemyEffectTextAry[12].GetComponent<TextMeshProUGUI>().text = main.TextEdit(new string[] { "Drop Chance + " + percent(dropFactor) });
                yield break;
            }
        }

    }



    IEnumerator SaveItems()
    {
        int tempTrapNum = 0;
        while (true)
        {
            yield return new WaitForSeconds(0.5123f);
            //AutoUse
            if (main.S.isAutoUse)
                UseAll();

            tempTrapNum = 0;
            for (int i = 0; i < AlchemyInventory.childCount; i++)
            {
                main.S.leftItems[i] = (int)AlchemyInventory.GetChild(i).GetComponent<CONSUMEITEM>().materialName + 1;
                main.S.leftItemsQuality[i] = AlchemyInventory.GetChild(i).GetComponent<CONSUMEITEM>().definedQuality;
                main.S.leftItemsIsLock[i] = AlchemyInventory.GetChild(i).GetComponent<CONSUMEITEM>().isLock;
                if (AlchemyInventory.GetChild(i).GetComponent<CONSUMEITEM>().materialName == ALCHEMY.MaterialName.Traps)
                    tempTrapNum++;
            }
            trapNum = Math.Max(trapNum, tempTrapNum);
            for (int i = AlchemyInventory.childCount; i < main.S.leftItems.Length; i++)
            {
                main.S.leftItems[i] = 0;
                main.S.leftItemsQuality[i] = 0;
                main.S.leftItemsIsLock[i] = false;
            }
        }
    }

    private void OnApplicationQuit()//直前のセーブ
    {
        for (int i = 0; i < AlchemyInventory.childCount; i++)
        {
            main.S.leftItems[i] = (int)AlchemyInventory.GetChild(i).GetComponent<CONSUMEITEM>().materialName + 1;
            main.S.leftItemsQuality[i] = AlchemyInventory.GetChild(i).GetComponent<CONSUMEITEM>().definedQuality;
            main.S.leftItemsIsLock[i] = AlchemyInventory.GetChild(i).GetComponent<CONSUMEITEM>().isLock;
        }
        main.saveCtrl.setSaveKey();
    }

    void FirstInstantiateItems()
    {
        for (int i = 0; i < main.S.leftItems.Length; i++)
        {
            if (main.S.leftItems[i] != 0)
            {
                GameObject icon;
                icon = Instantiate(AlchemyIcons[main.S.leftItems[i] - 1], AlchemyInventory);
                icon.GetComponent<CONSUMEITEM>().definedQuality = main.S.leftItemsQuality[i];
                icon.GetComponent<CONSUMEITEM>().isLock = main.S.leftItemsIsLock[i];
            }
        }
    }
    public int trapNum;

    public TextMeshProUGUI alchemyPointText;

    public double alchemyPoint()
    {
        return Math.Max(main.S.gainedAlchemyPoint - main.S.consumedAlchemyPoint, 0); 
    }

}
