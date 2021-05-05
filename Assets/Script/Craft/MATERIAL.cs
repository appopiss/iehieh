//using System.Collections;
//using System.Collections.Generic;
//using System;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.Events;
//using UnityEngine.EventSystems;
//using static UsefulMethod;
//using TMPro;
//using static ArtiCtrl;

//public class MATERIAL : BASE,IPointerDownHandler
//{

//    GameObject window;
//    GameObject hatena;
//    Button hatenaButton;
//    GameObject making;
//    public string Name;
//    [TextAreaAttribute(10, 100)]
//    public string explain;
//    float duration { get => main.S.duration[(int)materialName]; set => main.S.duration[(int)materialName] = value; }
//    bool isDurated;
//    //public string Effect;
//    public enum Condition
//    {
//        locked,
//        making,
//    }
//    public Condition condition { get => main.S.condition2[(int)materialName]; set => main.S.condition2[(int)materialName] = value; }
//    //public ArtiCtrl.MaterialList TargetMaterial;
//    public float leftTime { get => main.S.leftTime2[(int)materialName]; set => main.S.leftTime2[(int)materialName] = value; }
//    public float I_leftTime;
//    public SampleTable RequiredMaterial;
//    //public int StoredNum { get => main.S.storedNum[(int)materialName]; set => main.S.storedNum[(int)materialName] = value; }
//    public enum MaterialName
//    {
//        HpPortion= 0,
//        MpPortion =1,
//        CurePortion=2,
//        SpicyPortion =3,
//        ExpPotion = 4,
//        GoldPotion = 5,
//        DropPotion = 6,
//        PoisonBanana = 7,
//        Traps = 8,
//    }
//    public MaterialName materialName;
//    public long CurrentNum
//    {
//        get
//        {
//            switch (materialName)
//            {
//                case MaterialName.HpPortion:
//                    return main.S.HpPotion;
//                case MaterialName.MpPortion:
//                    return main.S.MpPotion;
//                case MaterialName.CurePortion:
//                    return main.S.CurePotion;
//                case MaterialName.SpicyPortion:
//                    return main.S.SpicyPotion;
//                case MaterialName.ExpPotion:
//                    return main.S.ExpPotion;
//                case MaterialName.GoldPotion:
//                    return main.S.GoldPotion;
//                case MaterialName.DropPotion:
//                    return main.S.DropPotion;
//                case MaterialName.Traps:
//                    return main.S.Trap;
//                default:
//                    return 0;
//            }
//        }
//        set
//        {
//            switch (materialName)
//            {
//                case MaterialName.HpPortion:
//                    main.S.HpPotion = value;
//                    break;
//                case MaterialName.MpPortion:
//                    main.S.MpPotion = value;
//                    break;
//                case MaterialName.CurePortion:
//                    main.S.CurePotion = value;
//                    break;
//                case MaterialName.SpicyPortion:
//                    main.S.SpicyPotion = value;
//                    break;
//                case MaterialName.ExpPotion:
//                    main.S.ExpPotion = value;
//                    break;
//                case MaterialName.GoldPotion:
//                    main.S.GoldPotion = value;
//                    break;
//                case MaterialName.DropPotion:
//                    main.S.DropPotion = value;
//                    break;
//                case MaterialName.Traps:
//                    main.S.Trap = value;
//                    break;
//                default:
//                    break;
//            }
//        }
//    }
//    public int MaxTrapNum()
//    {
//        return 5 + main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.capture].level * 2;
//    }

//    // Use this for initialization
//    void Awake()
//    {
//        StartBASE();
//        hatena = gameObject.transform.GetChild(0).gameObject;
//        making = gameObject.transform.GetChild(1).gameObject;
//    }

//    // Use this for initialization
//    void Start()
//    {
//        InstantiateWindow();
//        //hatenaButton.onClick.AddListener(Make);

//        // foreach(KeyValuePair<MaterialList,int> material in RequiredMaterial.GetTable())
//        // {
//        //     Debug.Log(material.Key + " : " +material.Value);
//        // }

//        if (condition == Condition.locked)
//        {
//            if (materialName == MaterialName.Traps)
//            {
//                leftTime = (float)(10 * 60 * (100 - (main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.capture].level) * 2) * 0.01);
//            }
//            else
//            {
//                leftTime = I_leftTime;
//            }
//        }

//        //StartCoroutine(Making());
//        StartCoroutine(Duration());
//        //main.ArtiCtrl.CurrentMaterial[TargetMaterial] += 10;
//        //numText = gameObject.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
//        //StartCoroutine(AutoTrapMaker()); これは強すぎるのでナシにした
//    }

//    public TextMeshProUGUI numText;

//    public void InstantiateWindow()
//    {
//        window = Instantiate(main.P_texts[9], main.WindowShowCanvas);
//        gameObject.AddComponent<EventTrigger>().triggers = new List<EventTrigger.Entry>();
//        EventTrigger.Entry entry = new EventTrigger.Entry();
//        EventTrigger.Entry entry2 = new EventTrigger.Entry();
//        entry.eventID = EventTriggerType.PointerEnter;
//        entry2.eventID = EventTriggerType.PointerExit;
//        entry.callback.AddListener((x) => UsefulMethod.setActive(window));
//        entry2.callback.AddListener((x) => UsefulMethod.setFalse(window)); //ラムダ式の右側は追加するメソッドです。
//        gameObject.GetComponent<EventTrigger>().triggers.Add(entry);
//        gameObject.GetComponent<EventTrigger>().triggers.Add(entry2);
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        updateText();
//        //if(main.GameController.currentCanvas == main.GameController.ArtifactCanvas)
//        //{
//        //    numText.text = "x " + tDigit(CurrentNum);
//        //}
//        updateDuration();
//    }

//    public void updateText()
//    {
//        LockWindow();
//        //if(StoredNum == 0)
//        //{
//        //    setFalse(making);
//        //}
//        //else
//        //{
//        //    setActive(making);
//        //}
//    }
//    public bool CanUnlock()
//    {
//        if(materialName == MaterialName.Traps)
//        {
//            if (CurrentNum >= MaxTrapNum())
//            {
//                return false;
//            }
//        }
//        foreach (KeyValuePair<MaterialList, int> material in RequiredMaterial.GetTable())
//        {
//            switch (material.Key)
//            {
//                case MaterialList.Stone:
//                    if (main.SR.stone < material.Value)
//                    {
//                        return false;
//                    }
//                    break;
//                case MaterialList.Crystal:
//                    if (main.SR.cristal < material.Value)
//                    {
//                        return false;
//                    }
//                    break;
//                case MaterialList.Leaf:
//                    if (main.SR.leaf < material.Value)
//                    {
//                        return false;
//                    }
//                    break;
//                case MaterialList.gold:
//                    if (main.SR.gold < material.Value)
//                    {
//                        return false;
//                    }
//                    break;
//                default:
//                    if (main.ArtiCtrl.CurrentMaterial[material.Key] < material.Value)
//                    {
//                        return false;
//                    }
//                    break;
//            }
//        }
//        return true;
//    }
//    public void Unlock()
//    {
//        Make();
//    }
//    public void Make()
//    {
//        foreach (KeyValuePair<MaterialList, int> material in RequiredMaterial.GetTable())
//        {
//            switch (material.Key)
//            {
//                case MaterialList.Stone:
//                    main.SR.stone -= material.Value;
//                    break;
//                case MaterialList.Crystal:
//                    main.SR.cristal -= material.Value;
//                    break;
//                case MaterialList.Leaf:
//                    main.SR.leaf -= material.Value;
//                    break;
//                case MaterialList.gold:
//                    main.SR.gold -= material.Value;
//                    break;
//                default:
//                    main.ArtiCtrl.CurrentMaterial[material.Key] -= material.Value;
//                    break;
//            }
//        }
//        //StoredNum++;
//    }
//    public void MakeMax()
//    {
//        while (true)
//        {
//            foreach (KeyValuePair<MaterialList, int> material in RequiredMaterial.GetTable())
//            {
//                switch (material.Key)
//                {
//                    case MaterialList.Stone:
//                        if (main.SR.stone >= material.Value)
//                            main.SR.stone -= material.Value;
//                        else return;
//                        break;
//                    case MaterialList.Crystal:
//                        if (main.SR.cristal >= material.Value)
//                            main.SR.cristal -= material.Value;
//                        else return;
//                        break;
//                    case MaterialList.Leaf:
//                        if (main.SR.leaf >= material.Value)
//                            main.SR.leaf -= material.Value;
//                        else return;
//                        break;
//                    case MaterialList.gold:
//                        if (main.SR.gold >= material.Value)
//                            main.SR.gold -= material.Value;
//                        else return;
//                        break;
//                    default:
//                        if (main.ArtiCtrl.CurrentMaterial[material.Key] >= material.Value)
//                            main.ArtiCtrl.CurrentMaterial[material.Key] -= material.Value;
//                        else return;
//                        break;
//                }
//            }
//            //StoredNum++;
//        }
//    }
//    //public IEnumerator Making()
//    //{
//    //    while (true)
//    //    {
//    //        //if (StoredNum == 0)
//    //        //{
//    //        //    condition = Condition.locked;
//    //        //}
//    //        yield return new WaitUntil(() => StoredNum > 0);
//    //        condition = Condition.making;
//    //        if(materialName== MaterialName.Traps)
//    //        {
//    //            yield return new WaitUntil(() => CurrentNum < MaxTrapNum());
//    //        }
//    //        leftTime -= 1.0f;
//    //        if (leftTime <= 0)
//    //        {
//    //            CurrentNum += 1;
//    //            StoredNum--;
//    //            if(materialName == MaterialName.Traps)
//    //            {
//    //                leftTime = (float)(10 * 60 * (5000 / (50 + main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.capture].level)) * 0.01);
//    //            }
//    //            else
//    //            {
//    //                leftTime = I_leftTime;
//    //            }
//    //        }
//    //        yield return new WaitForSecondsRealtime(1.0f);
//    //    }
//    //}
//    public int cost(SamplePair material)
//    {
//        return material.Value;
//    }
//    public string showMaterial()
//    {
//        string text = "";
//        foreach (SamplePair material in RequiredMaterial.GetList())
//        {
//            switch (material.Key)
//            {
//                case MaterialList.Stone:
//                    text += "- " + material.Key;
//                    text += "\n";
//                    break;
//                case MaterialList.Crystal:
//                    text += "- " + material.Key;
//                    text += "\n";
//                    break;
//                case MaterialList.Leaf:
//                    text += "- " + material.Key;
//                    text += "\n";
//                    break;
//                default:
//                    text += "- " + material.Key;
//                    text += "\n";
//                    break;
//            }
//        }
//        return text;
//    }
//    public string showMaterialNum()
//    {
//        string text = "";
//        foreach (SamplePair material in RequiredMaterial.GetList())
//        {
//            switch (material.Key)
//            {
//                case MaterialList.Stone:
//                    if (main.SR.stone < cost(material))
//                    {
//                        text += "<color=\"red\">" + tDigit(main.SR.stone) + "</color> / " + tDigit(cost(material));
//                    }
//                    else
//                    {
//                        text += "<color=\"green\">" + tDigit(main.SR.stone) + "</color> / " + tDigit(cost(material));
//                    }
//                    text += "\n";
//                    break;
//                case MaterialList.Crystal:
//                    if (main.SR.cristal < cost(material))
//                    {
//                        text += "<color=\"red\">" + tDigit(main.SR.cristal) + "</color> / " + tDigit(cost(material));

//                    }
//                    else
//                    {
//                        text += "<color=\"green\">" + tDigit(main.SR.cristal) + "</color> / " + tDigit(cost(material));
//                    }
//                    text += "\n";
//                    break;
//                case MaterialList.Leaf:
//                    if (main.SR.leaf < cost(material))
//                    {
//                        text += "<color=\"red\">" + tDigit(main.SR.leaf) + "</color> / " + tDigit(cost(material));
//                    }
//                    else
//                    {
//                        text += "<color=\"green\">" + tDigit(main.SR.leaf) + "</color> / " + tDigit(cost(material));
//                    }
//                    text += "\n";
//                    break;
//                case MaterialList.gold:
//                    if (main.SR.gold < cost(material))
//                    {
//                        text += "<color=\"red\">" + tDigit(main.SR.gold) + "</color> / " + tDigit(cost(material));
//                    }
//                    else
//                    {
//                        text += "<color=\"green\">" + tDigit(main.SR.gold) + "</color> / " + tDigit(cost(material));
//                    }
//                    text += "\n";
//                    break;
//                default:
//                    if (main.ArtiCtrl.CurrentMaterial[material.Key] < cost(material))
//                    {
//                        text += "<color=\"red\">" + tDigit(main.ArtiCtrl.CurrentMaterial[material.Key]) + "</color> / " + tDigit(cost(material));
//                    }
//                    else
//                    {
//                        text += "<color=\"green\">" + tDigit(main.ArtiCtrl.CurrentMaterial[material.Key]) + "</color> / " + tDigit(cost(material));
//                    }
//                    text += "\n";
//                    break;
//            }
//        }
//        return text;
//    }
//    public void LockWindow()
//    {
//        if (window.activeSelf)
//        {
//            window.transform.GetChild(0).GetComponentInChildren<Image>().sprite = gameObject.GetComponentsInChildren<Image>()[0].sprite;
//            window.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "                 " + Name;
//            //if (materialName == MaterialName.Traps)
//            //{
//            //    window.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text
//            //            = "                        - You have : " + tDigit(CurrentNum)
//            //            //+ "\n                        - Making left : " + StoredNum
//            //            + "\n                        - Time left : " + DoubleTimeToDate(leftTime)
//            //            + "\n                        - Max Num : " + MaxTrapNum();
//            //    window.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "- " + explain;
//            //}
//            //else
//            //{
//            //    //window.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text
//            //    //        = "                        - You have : " + tDigit(CurrentNum)
//            //    //        + "\n                        - Making left : " + StoredNum
//            //    //        + "\n                        - Time left : " + DoubleTimeToDate(leftTime);
//            //    window.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "- " + explain;
//            //}
//            window.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "- " + explain;



//            //if (materialName== MaterialName.HpPortion)
//            //{
//            //    window.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text += "\n- Permanent max HP : + " + percent(main.S.hpPortion);
//            //}
//            //else if(materialName== MaterialName.MpPortion)
//            //{
//            //    window.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text += "\n- Permanent max MP : + " + percent(main.S.mpPortion);

//            //}

//            window.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text = showMaterial();
//            window.transform.GetChild(5).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = showMaterialNum();
//            //if (duration > 0)
//            //    window.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Duration\n\n " + DoubleTimeToDate(duration);
//            //else
//            //    window.transform.GetChild(7).GetComponent<TextMeshProUGUI>().text = "";


//            if (window != null)
//            {
//                if (Input.mousePosition.y >= 300 && Input.mousePosition.x >= 400)
//                {
//                    window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(-250.0f, -50.0f);
//                }
//                else if (Input.mousePosition.y >= 300 && Input.mousePosition.x < 400)
//                {
//                    window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(50.0f, -50.0f);
//                }
//                else if (Input.mousePosition.y < 300 && Input.mousePosition.x > 400)
//                {
//                    window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(-250.0f, 50.0f);
//                }
//                else if (Input.mousePosition.y < 300 && Input.mousePosition.x < 400)
//                {
//                    window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(50.0f, 100.0f);
//                }
//            }
//        }
//    }
//    public void OnPointerDown(PointerEventData eventData)
//    {
//        if (eventData.pointerId == -1)
//        {
//            if (CanUnlock())
//            {
//                if (!main.toggles[0].isOn)
//                    Make();
//                else
//                    MakeMax();
//            }
//        }
//        //else if (eventData.pointerId == -2)
//        //{
//        //    Effect();
//        //}
//    }
//    public void Effect()
//    {
//        if (CurrentNum == 0)
//            return;
//        switch (materialName)
//        {
//            case MaterialName.HpPortion:
//                if (main.ally.currentHp >= main.ally.HP())
//                    main.S.hpPortion += 0.0001;
//                else
//                    main.ally1.GetComponent<ALLY>().currentHp += main.ally.HP() * 0.5;
//                break;
//            case MaterialName.MpPortion:
//                if (main.ally.currentMp >= main.ally.MP())
//                    main.S.mpPortion += 0.0001;
//                else
//                    main.ally1.GetComponent<ALLY>().currentMp += main.ally.MP() * 1;
//                break;
//            case MaterialName.CurePortion:
//                duration += 0;
//                foreach (Transform child in main.StatusIconCanvas.transform)
//                {
//                    if (child.GetComponent<ABNORMAL>().debuff != Main.Debuff.nothing)
//                    {
//                        Destroy(child.gameObject);
//                    }
//                }
//                break;
//            case MaterialName.SpicyPortion:
//                if (!main.ally.updateDuration(Main.Buff.spicy))
//                {
//                    ABNORMAL game;
//                    game = Instantiate(main.StatusIcons[11], main.StatusIconCanvas);
//                    game.duration = 10;
//                }
//                break;
//            default:
//                break;
//        }
//        CurrentNum -= 1;
//    }
//    public IEnumerator Duration()
//    {
//        while (true)
//        {
//            yield return new WaitUntil(() => duration > 0);
//            isDurated = true;
//            duration--;
//            if (duration <= 0)
//            {
//                duration = 0;
//                isDurated = false;
//            }
//            yield return new WaitForSeconds(1.0f);
//        }
//    }
//    public void updateDuration()
//    {
//        //消費アイテムの効果を書いていく
//    }
//    //public IEnumerator AutoTrapMaker()
//    //{
//    //    if (materialName != MaterialName.Traps)
//    //        yield break;

//    //    while (true)
//    //    {
//    //        yield return new WaitUntil(() => main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.capture].level > 0);
//    //        yield return new WaitUntil(() => StoredNum == 0);
//    //        StoredNum += 1;
//    //        yield return new WaitForSeconds(1.0f);
//    //    }
//    //}
//}
