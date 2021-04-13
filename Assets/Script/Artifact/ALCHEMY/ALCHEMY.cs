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

public class ALCHEMY : BASE,IPointerDownHandler
{
    public int alchemyQuantityId;
    public GameObject SuperQueueImage;
    GameObject window;
    public string Name;
    [TextAreaAttribute(10, 100)]
    public string explain;
    public SampleTable RequiredMaterial;
    public GameObject hideImage;
    public enum MaterialName
    {
        DPSWater=0,
        StoneWater=1,//Stoneの生産を挙げる
        CrystalWater=2,//同様に
        LeafWater=3,//
        HpPortion=4,
        MpPortion=5,
        SpicyPortion=6,
        CurePortion=7,
        GoldPotion=8,
        EXPPotion=9,
        ATKUp=10,
        MATKUp=11,
        DEFMDEFUp=12,
        DropPotion=13,
        PoisonBanana=14,
        Traps=15,
        HpPotion2=16,
        MpPotion2=17,
        SpicyMonsterEnergy=18,
        TinctureOfBoss1=19,
        TinctureOfBoss2=20,
        TinctureOfBoss3=21,
        TinctureOfBoss4=22,
        TinctureOfBoss5=23,
        TinctureOfBoss6=24,
        TinctureOfBoss7=25,
        TinctureOfBoss8=26,
        AlchemyPoint=27,
        ResourseElixir=28,
        HpPotion3=29,
        MpPotion3=30,
        BankEfficiency=31,
        NitroPotion=32,
        ReasonableMonsterEnergy=33,
        ATKUp2=34,
        MATKUp2=35,
    }
    public MaterialName materialName;

    //public int MaxTrapNum()
    //{
    //    return 5 + main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.capture].level * 2;
    //}

    Button hatenaButton;
    TextMeshProUGUI requiredAPText;
    double requiredUnlockAP;
    bool isUnlocked { get => main.S.isUnlockedAlchemy[(int)materialName]; set => main.S.isUnlockedAlchemy[(int)materialName] = value; }

    // Use this for initialization
    void Awake()
    {
        StartBASE();
        hatenaButton = gameObject.GetComponentInChildren<Button>();
        requiredAPText = hatenaButton.gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Use this for initialization
    void Start()
    {
        InstantiateWindow();
        if (isUnlocked)
            setFalse(hatenaButton.gameObject);
        hatenaButton.onClick.AddListener(() => { main.S.consumedAlchemyPoint += requiredUnlockAP; isUnlocked = true; });


        switch (materialName)
        {
            case MaterialName.DPSWater:
                isUnlocked = true;
                requiredUnlockAP = 0;
                break;
            case MaterialName.ReasonableMonsterEnergy:
                requiredUnlockAP = 10000;
                break;
            case MaterialName.SpicyMonsterEnergy:
                requiredUnlockAP = 50000;
                break;
            case MaterialName.StoneWater:
                requiredUnlockAP = 5;
                break;
            case MaterialName.CrystalWater:
                requiredUnlockAP = 5;
                break;
            case MaterialName.LeafWater:
                requiredUnlockAP = 5;
                break;
            case MaterialName.NitroPotion:
                requiredUnlockAP = 5;
                break;
            case MaterialName.HpPortion:
                requiredUnlockAP = 3000;
                break;
            case MaterialName.MpPortion:
                requiredUnlockAP = 5000;
                break;
            case MaterialName.HpPotion2:
                requiredUnlockAP = 30000;
                break;
            case MaterialName.MpPotion2:
                requiredUnlockAP = 30000;
                break;
            case MaterialName.HpPotion3:
                requiredUnlockAP = 100000;
                break;
            case MaterialName.MpPotion3:
                requiredUnlockAP = 100000;
                break;
            case MaterialName.CurePortion:
                requiredUnlockAP = 7500;
                break;
            case MaterialName.SpicyPortion:
                requiredUnlockAP = 5000;
                break;
            case MaterialName.GoldPotion:
                requiredUnlockAP = 1000;
                break;
            case MaterialName.EXPPotion:
                requiredUnlockAP = 2000;
                break;
            case MaterialName.ATKUp:
                requiredUnlockAP = 500;
                break;
            case MaterialName.MATKUp:
                requiredUnlockAP = 500;
                break;
            case MaterialName.DEFMDEFUp:
                requiredUnlockAP = 500;
                break;
            case MaterialName.DropPotion:
                requiredUnlockAP = 100000;
                break;
            case MaterialName.BankEfficiency:
                requiredUnlockAP = 150000;
                break;
            case MaterialName.PoisonBanana:
                break;
            case MaterialName.Traps:
                requiredUnlockAP = 10000;
                break;
            case MaterialName.TinctureOfBoss1:
                requiredUnlockAP = 10000;
                break;
            case MaterialName.TinctureOfBoss2:
                requiredUnlockAP = 50000;
                break;
            case MaterialName.TinctureOfBoss3:
                requiredUnlockAP = 100000;
                break;
            case MaterialName.TinctureOfBoss4:
                requiredUnlockAP = 250000;
                break;
            case MaterialName.TinctureOfBoss5:
                requiredUnlockAP = 500000;
                break;
            case MaterialName.TinctureOfBoss6:
                requiredUnlockAP = 1000000;
                break;
            case MaterialName.TinctureOfBoss7:
                requiredUnlockAP = 3000000;
                break;
            //case MaterialName.TinctureOfBoss8:
            //    requiredUnlockAP = 300000;
            //    break;

            case MaterialName.AlchemyPoint:
                requiredUnlockAP = 777;
                break;
            case MaterialName.ResourseElixir:
                requiredUnlockAP = 1000000;
                break;
            case MaterialName.ATKUp2:
                requiredUnlockAP = 1000000;
                break;
            case MaterialName.MATKUp2:
                requiredUnlockAP = 1000000;
                break;

            default:
                break;
        }

        requiredAPText.text = tDigit(requiredUnlockAP);

        switch (materialName)
        {
            case MaterialName.DPSWater:
                break;
            case MaterialName.StoneWater:
                requiredAPText.text = "Cost 5 AP";
                break;
            case MaterialName.CrystalWater:
                requiredAPText.text = "Cost 5 AP";
                break;
            case MaterialName.LeafWater:
                requiredAPText.text = "Cost 5 AP";
                break;
            case MaterialName.NitroPotion:
                requiredAPText.text = "Cost 5 AP";
                break;
        }

        StartCoroutine(MakeByQueue());
    }

    public void InstantiateWindow()
    {
        window = Instantiate(main.P_texts[9], main.WindowShowCanvas);
        gameObject.AddComponent<EventTrigger>().triggers = new List<EventTrigger.Entry>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry2.eventID = EventTriggerType.PointerExit;
        entry.callback.AddListener((x) => {
            if (isUnlocked)
                UsefulMethod.setActive(window); });
        entry2.callback.AddListener((x) =>
        {
            if (isUnlocked)
                UsefulMethod.setFalse(window);
        } ); //ラムダ式の右側は追加するメソッドです。
        gameObject.GetComponent<EventTrigger>().triggers.Add(entry);
        gameObject.GetComponent<EventTrigger>().triggers.Add(entry2);
    }

    // Update is called once per frame
    void Update()
    {
        updateText();
        if (CanUnlock())
            setFalse(hideImage);
        else
            setActive(hideImage);

        if (main.alchemyController.alchemyPoint() >= requiredUnlockAP)
            hatenaButton.interactable = true;
        else
            hatenaButton.interactable = false;
        if (isUnlocked)
            setFalse(hatenaButton.gameObject);
        else
            setActive(hatenaButton.gameObject);

        if (window.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.M) || Input.GetMouseButtonDown(1))
            {
                for (int i = 0; i < main.alchemyController.waterCap(main.SR.alchemyQuantity); i++)
                {
                    if (CanUnlock())
                    {
                        Make();
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                AssignSuperQueue();
            }
        }

    }

    public void updateText()
    {
        LockWindow();
    }
    public bool CanUnlock(bool isSuperQueue = false)
    {
        if (!isUnlocked)
            return false;
        foreach (KeyValuePair<MaterialList, int> material in RequiredMaterial.GetTable())
        {
            switch (material.Key)
            {
                case MaterialList.Stone:
                    if (main.SR.stone < material.Value)
                    {
                        return false;
                    }
                    break;
                case MaterialList.Crystal:
                    if (main.SR.cristal < material.Value)
                    {
                        return false;
                    }
                    break;
                case MaterialList.Leaf:
                    if (main.SR.leaf < material.Value)
                    {
                        return false;
                    }
                    break;
                case MaterialList.gold:
                    if (main.SR.gold < material.Value)
                    {
                        return false;
                    }
                    break;
                default:
                    if (main.ArtiCtrl.CurrentMaterial[material.Key] < material.Value)
                    {
                        return false;
                    }
                    break;
            }
        }
        if (isSuperQueue)
        {
            if (main.alchemyController.canAlchemy(alchemyQuantityId))
                return true;
            else
                return false;
        }
        else
        {
            if (main.alchemyController.canAlchemy())
                return true;
            else
                return false;
        }
    }
    public void Make(bool isSuperQueue = false)
    {
        foreach (KeyValuePair<MaterialList, int> material in RequiredMaterial.GetTable())
        {
            switch (material.Key)
            {
                case MaterialList.Stone:
                    main.SR.stone -= material.Value;
                    break;
                case MaterialList.Crystal:
                    main.SR.cristal -= material.Value;
                    break;
                case MaterialList.Leaf:
                    main.SR.leaf -= material.Value;
                    break;
                case MaterialList.gold:
                    main.SR.gold -= material.Value;
                    break;
                default:
                    main.ArtiCtrl.CurrentMaterial[material.Key] -= material.Value;
                    break;
            }
        }
        if(isSuperQueue)
            main.SR.currentWater[alchemyQuantityId] -= 1;
        else
            main.SR.currentWater[main.SR.alchemyQuantity] -= 1;
        CreateAlchemy();
    }
    public void CreateAlchemy()
    {
        if(main.alchemyController.AlchemyInventory.childCount < main.alchemyController.AlchemyInventoryCap())
        {
            GameObject icon;
            icon = Instantiate(main.alchemyController.AlchemyIcons[(int)materialName], main.alchemyController.AlchemyInventory);
            icon.GetComponent<CONSUMEITEM>().definedQuality = quality();
        }
    }

    public int cost(SamplePair material)
    {
        return material.Value;
    }
    public string showMaterial()
    {
        string text = "";
        foreach (SamplePair material in RequiredMaterial.GetList())
        {
            switch (material.Key)
            {
                case MaterialList.Stone:
                    text += "- " + material.Key;
                    text += "\n";
                    break;
                case MaterialList.Crystal:
                    text += "- " + material.Key;
                    text += "\n";
                    break;
                case MaterialList.Leaf:
                    text += "- " + material.Key;
                    text += "\n";
                    break;
                case MaterialList.gold:
                    text += "- Gold";
                    text += "\n";
                    break;
                default:
                    text += "- " + material.Key;
                    text += "\n";
                    break;
            }
        }
        return text;
    }
    public string showMaterialNum()
    {
        string text = "";
        foreach (SamplePair material in RequiredMaterial.GetList())
        {
            switch (material.Key)
            {
                case MaterialList.Stone:
                    if (main.SR.stone < cost(material))
                    {
                        text += "<color=\"red\">" + tDigit(main.SR.stone) + "</color> / " + tDigit(cost(material));
                    }
                    else
                    {
                        text += "<color=\"green\">" + tDigit(main.SR.stone) + "</color> / " + tDigit(cost(material));
                    }
                    text += "\n";
                    break;
                case MaterialList.Crystal:
                    if (main.SR.cristal < cost(material))
                    {
                        text += "<color=\"red\">" + tDigit(main.SR.cristal) + "</color> / " + tDigit(cost(material));

                    }
                    else
                    {
                        text += "<color=\"green\">" + tDigit(main.SR.cristal) + "</color> / " + tDigit(cost(material));
                    }
                    text += "\n";
                    break;
                case MaterialList.Leaf:
                    if (main.SR.leaf < cost(material))
                    {
                        text += "<color=\"red\">" + tDigit(main.SR.leaf) + "</color> / " + tDigit(cost(material));
                    }
                    else
                    {
                        text += "<color=\"green\">" + tDigit(main.SR.leaf) + "</color> / " + tDigit(cost(material));
                    }
                    text += "\n";
                    break;
                case MaterialList.gold:
                    if (main.SR.gold < cost(material))
                    {
                        text += "<color=\"red\">" + tDigit(main.SR.gold) + "</color> / " + tDigit(cost(material));
                    }
                    else
                    {
                        text += "<color=\"green\">" + tDigit(main.SR.gold) + "</color> / " + tDigit(cost(material));
                    }
                    text += "\n";
                    break;
                default:
                    if (main.ArtiCtrl.CurrentMaterial[material.Key] < cost(material))
                    {
                        text += "<color=\"red\">" + tDigit(main.ArtiCtrl.CurrentMaterial[material.Key]) + "</color> / " + tDigit(cost(material));
                    }
                    else
                    {
                        text += "<color=\"green\">" + tDigit(main.ArtiCtrl.CurrentMaterial[material.Key]) + "</color> / " + tDigit(cost(material));
                    }
                    text += "\n";
                    break;
            }
        }
        return text;
    }
    public int minQuality;
    public int maxQuality;

    public int quality()
    {
        return UnityEngine.Random.Range(minQuality, maxQuality+1);
        //switch (main.SR.alchemyQuantity)
        //{
        //    case 0:
        //        return UnityEngine.Random.Range(1, 5);
        //    case 1:
        //        return UnityEngine.Random.Range(6, 20);
        //    case 2:
        //        return UnityEngine.Random.Range(21, 35);
        //    case 3:
        //        return UnityEngine.Random.Range(36, 50);
        //    case 4:
        //        return UnityEngine.Random.Range(51, 65);
        //    case 5:
        //        return UnityEngine.Random.Range(66, 80);
        //    case 6:
        //        return UnityEngine.Random.Range(81, 100);
        //    default:
        //        return 0;
        //}
    }
    public string qualityString()
    {
        return minQuality + " ~ " + maxQuality;
        //switch (main.SR.alchemyQuantity)
        //{
        //    case 0:
        //        return "1 ~ 5";
        //    case 1:
        //        return "6 ~ 20";
        //    case 2:
        //        return "21 ~ 35";
        //    case 3:
        //        return "36 ~ 50";
        //    case 4:
        //        return "51 ~ 65";
        //    case 5:
        //        return "66 ~ 80";
        //    case 6:
        //        return "81 ~ 100";
        //    default:
        //        return "0";
        //}
    }


    public void LockWindow()
    {
        if (window.activeSelf)
        {
            window.transform.GetChild(0).GetComponentInChildren<Image>().sprite = gameObject.GetComponentsInChildren<Image>()[0].sprite;
            window.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "                 " + Name;
            window.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "                       Quality : " + qualityString() + "\n\n ";
            window.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "- " + explain;
            window.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text = showMaterial();
            window.transform.GetChild(5).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = showMaterialNum();

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
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(-250.0f, 50.0f);
            //    }
            //    else if (Input.mousePosition.y < 300 && Input.mousePosition.x < 400)
            //    {
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(50.0f, 100.0f);
            //    }
            //}
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
            if (eventData.pointerId == -1)
            {
                if (CanUnlock())
                {
                    Make();
                }
            }
    }

    public bool isSuperQueued { get => main.S.isSuperQueuedAlchemy[50 * alchemyQuantityId + (int)materialName]; set => main.S.isSuperQueuedAlchemy[50 * alchemyQuantityId + (int)materialName] = value; }
    public void AssignSuperQueue()
    {
        if (!main.S.isPurchasedSuperQueueAlchemy)
            return;
        if (isSuperQueued)
            isSuperQueued = false;
        else
        {
            for (int i = 0; i < main.S.isSuperQueuedAlchemy.Length; i++)
            {
                main.S.isSuperQueuedAlchemy[i] = false;
            }
            isSuperQueued = true;
        }
    }
    IEnumerator MakeByQueue()
    {
        while (true)
        {            
            if (isSuperQueued)
            {
                setActive(SuperQueueImage);
                if (CanUnlock(true))
                {
                    Make(true);
                }
            }
            else
            {
                setFalse(SuperQueueImage);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
