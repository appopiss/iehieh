using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using UnityEngine.EventSystems;
using TMPro;
using System.Text;

public class KEYITEM : BASE, IPointerDownHandler
{

    public ArtifactId thisId;
    public Rarity thisRarity;
    int keyItemNum { get => main.S.keyItemNum[(int)thisId]; set => main.S.keyItemNum[(int)thisId] = value; }
    bool isUnlocked { get => main.S.key_isUnlocked[(int)thisId]; set => main.S.key_isUnlocked[(int)thisId] = value; }
    GameObject hatena;
    public GameObject window;
    public enum ArtifactId
    {
        UsedCoinPouch,
        MeteoriteShard,
        CrackedDivinity,
        AncientScroll,
        LuckyCoin,
        WiseOwlFeather,
        DiscardedSweatband,
        StrangeRock,
        WarpedCrystal,
        SmallShrubby,
    }
    public enum Rarity
    {
        common,
        uncommon,
        rare
    }
    public Dictionary<ArtiCtrl.MaterialList, int> MaterialList;
    public KEYITEM[] key_tier1;
    public KEYITEM[] key_tier2;
    public KEYITEM[] key_tier3;
	// Use this for initialization
	void Awake () {
		StartBASE();
        InstantiateWindow();
        hatena = gameObject.transform.GetChild(0).gameObject;
        MaterialList = new Dictionary<ArtiCtrl.MaterialList, int>();
        if (isUnlocked)
        {
            Destroy(hatena);
        }

        switch (thisId)
        {
            case ArtifactId.UsedCoinPouch:
                gameObject.AddComponent<Effect>().AwakeEffect(thisId, Effect.StatusKind.goldCap, Effect.CalWay.add, () => keyItemNum * 25);
                thisRarity = Rarity.uncommon;
                MaterialList.Add(ArtiCtrl.MaterialList.MonsterFluid, 5);
                MaterialList.Add(ArtiCtrl.MaterialList.AncientCoin, 1);
                break;
        }
	}

	// Use this for initialization
	void Start () {
        StartCoroutine(Unlock());
        //Debug用
        keyItemNum += 1;
	}
	
	// Update is called once per frame
	void Update () {
        UpdateWindow();
	}

    IEnumerator Unlock()
    {
        if (isUnlocked)
        {
            yield break;
        }
        yield return new WaitUntil( () => keyItemNum >= 1);
        isUnlocked = true;
        if (hatena != null)
            Destroy(hatena);
    }
    string ShowMaterial()
    {
        StringBuilder tempText = new StringBuilder();
        if (MaterialList.Count == 0)
            return "Nothing";

        int tempCount = 0;
        foreach(KeyValuePair<ArtiCtrl.MaterialList,int> material in MaterialList)
        {
            if(tempCount == 0)
            {
                tempText.Append("- ");
                tempText.Append(main.ArtiCtrl.ConvertEnum(material.Key));
                tempText.Append(" ×");
                tempText.Append(material.Value);
                tempText.Append(" ( ");
                tempText.Append(main.ArtiCtrl.CurrentMaterial[material.Key]);
                tempText.Append(" )");
            }
            else
            {
                tempText.Append("\n- ");
                tempText.Append(main.ArtiCtrl.ConvertEnum(material.Key));
                tempText.Append(" ×");
                tempText.Append(material.Value);
                tempText.Append(" ( ");
                tempText.Append(main.ArtiCtrl.CurrentMaterial[material.Key]);
                tempText.Append(" )");
            }
            tempCount++;
        }
        return tempText.ToString();
    }
    void Break()
    {
        if (keyItemNum == 0)
            return;

        keyItemNum -= 1;
        foreach(KeyValuePair<ArtiCtrl.MaterialList,int> material in MaterialList)
        {
            main.ArtiCtrl.CurrentMaterial[material.Key] += material.Value;
        }
    }
    public void UpdateWindow()
    {
        if (window.activeSelf)
        {
            window.transform.GetChild(0).GetComponentInChildren<Image>().sprite = gameObject.GetComponent<Image>().sprite;
            window.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "                 " + main.ArtiCtrl.ConvertEnum(thisId);
            window.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "                        - Rarity : " + main.ArtiCtrl.ConvertEnum(thisRarity) + "\n                        - Current Num : " + keyItemNum + "\n                        ";
            window.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text = ShowMaterial();
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
    public void InstantiateWindow()
    {
        window = Instantiate(main.P_texts[30], main.WindowShowCanvas);
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

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerId == -2)
        {
            Break();
        }
    }

    public class Effect : BASE
    {
        public enum StatusKind
        {
            goldCap,
            ATK,
            MATK,
            DEF,
            MDEF,
            prof,
            gold,
            exp,
            spd,
            stone,
            crystal,
            leaf,
            MP,
            HP,
            drop,
            other
        }
        public enum CalWay
        {
            add,
            mul
        }
        public StatusKind statusKind;
        public CalWay calWay;
        public ArtifactId targetArtifact;
        public Func<double> growthValue;
        public Func<string> FreeText;
        TextMeshProUGUI statusExplainText;
        string tempText;
        private void Awake()
        {
            StartBASE();
        }
        public void AwakeEffect(KEYITEM.ArtifactId thisId, StatusKind statusKind, CalWay calWay,Func<double> value)
        {
            targetArtifact = thisId;
            this.statusKind = statusKind;
            this.calWay = calWay;
            this.growthValue = value;
            statusExplainText = Instantiate(main.EffectText, main.keyItemCtrl.keyItems[(int)targetArtifact].window.transform.GetChild(3));
        }
        void UpdateText()
        {
            if (!main.keyItemCtrl.keyItems[(int)targetArtifact].window.activeSelf)
            {
                return;
            }

            switch (calWay)
            {
                case CalWay.add:
                    tempText = tDigit(growthValue());
                    break;
                case CalWay.mul:
                    tempText = percent(growthValue());
                    break;
            }

            switch (statusKind)
            {
                case StatusKind.HP:
                    statusExplainText.text = "- HP : + " + tempText;
                    break;
                case StatusKind.MP:
                    statusExplainText.text = "- MP : + " + tempText;
                    break;
                case StatusKind.gold:
                    statusExplainText.text = "- Gold Gain : + " + tempText;
                    break;
                case StatusKind.stone:
                    statusExplainText.text = "- Stone Produce : + " + tempText;
                    break;
                case StatusKind.crystal:
                    statusExplainText.text = "- Crystal Produce : + " + tempText;
                    break;
                case StatusKind.leaf:
                    statusExplainText.text = "- Leaf Produce : + " + tempText;
                    break;
                case StatusKind.drop:
                    statusExplainText.text = "- Drop Chance : + " + tempText;
                    break;
                case StatusKind.prof:
                    statusExplainText.text = "- Skill Profiency : + " + tempText;
                    break;
                case StatusKind.exp:
                    statusExplainText.text = "- Gained EXP : + " + tempText;
                    break;
                case StatusKind.spd:
                    statusExplainText.text = "- SPD : + " + tempText;
                    break;
                case StatusKind.ATK:
                    statusExplainText.text = "- ATK : + " + tempText;
                    break;
                case StatusKind.MATK:
                    statusExplainText.text = "- MATK : + " + tempText;
                    break;
                case StatusKind.DEF:
                    statusExplainText.text = "- DEF : + " + tempText;
                    break;
                case StatusKind.MDEF:
                    statusExplainText.text = "- MDEF : + " + tempText;
                    break;
                case StatusKind.goldCap:
                    statusExplainText.text = "- GOLD CAP : + " + tempText;
                    break;
                case StatusKind.other:
                    statusExplainText.text = "- " + FreeText();
                    break;
            }

        }
        private void Update()
        {
            UpdateText();
        }
    }
}
