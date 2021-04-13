using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using UnityEngine.EventSystems;
using TMPro;
using System.Linq;

public class DailyQuest : BASE {

    //ミッションの種類は今のところ2種類
    public bool canClear { get => main.S.isClearedToday[dailyQuestId]; set => main.S.isClearedToday[dailyQuestId] = value; }
    DateTime todayDate;
    int SavedDate { get => main.S.DailyQuestSavedDate[dailyQuestId]; set => main.S.DailyQuestSavedDate[dailyQuestId] = value; }
    bool isQuestInstantiated { get => main.S.isQuestInstantiated[dailyQuestId]; set => main.S.isQuestInstantiated[dailyQuestId] = value; }
    int todayInt;
    bool isAvailable;
    public int dailyQuestId;
    GameObject window;
    Button clearButton;
    public enum Rarity
    {
        common,
        uncommon,
        rare,
        legendary,
        epic
    }
    public enum QuestKind
    {
        enemy,
        material
    }
    public Rarity rarity { get; set; }
    public QuestKind questKind { get; set; }
    public ENEMY.EnemyKind targetEnemy { get; set; }
    public ArtiCtrl.MaterialList targetMaterial { get; set; }

    // Use this for initialization
    void Awake () {
		StartBASE();
        clearButton = gameObject.GetComponentInChildren<Button>();
        clearButton.onClick.AddListener(ClearQuest);
	}
	// Use this for initialization
	void Start () {
        StartCoroutine(OneSecCor());
    }
    void InstantiateQuest()
    {
        if (isQuestInstantiated)
            return;

        //rarityを決める
        questKind = chooseQuestKind();
        rarity = chooseRarity();
        targetEnemy = chooseEnemy();
        targetMaterial = chooseMaterial();

    }

    int rand;
    Rarity chooseRarity()
    {
        rand = UnityEngine.Random.Range(0, 10000);
        if ( rand<= 8000)
        {
            return Rarity.common;
        }else if (rand<=9000){
            return Rarity.uncommon;
        }
        else if (rand <= 9600)
        {
            return Rarity.rare;
        }
        else if (rand <= 9900)
        {
            return Rarity.epic;
        }
        else if (rand <= 10000)
        {
            return Rarity.legendary;
        }

        return Rarity.common;

    }
    QuestKind chooseQuestKind()
    {
        rand = UnityEngine.Random.Range(0, 10000);

        if (rand <= 5000)
        {
            return QuestKind.enemy;
        }
        else
        {
            return QuestKind.material;
        }
    }
    ENEMY.EnemyKind chooseEnemy()
    {
        return RandomElementAt(Enum.GetValues(typeof(ENEMY.EnemyKind)).Cast<ENEMY.EnemyKind>());
    }
    ArtiCtrl.MaterialList chooseMaterial()
    {
        return RandomElementAt(Enum.GetValues(typeof(ArtiCtrl.MaterialList)).Cast<ArtiCtrl.MaterialList>());
    }
    // Update is called once per frame
    void Update () {
		
	}
    IEnumerator OneSecCor()
    {
        while (true)
        {
            todayDate = DateTime.Now;
            todayInt = todayDate.Year * 10000 + todayDate.Month * 100 + todayDate.Day;

            if (todayInt > SavedDate)
            {
                canClear = true;
                ////広告のやつ
                //main.S.isDailyAP = true;
                //main.S.dailyECnum = 0;
            }
            if (isAvailable)
            {
            }
            else
            {
            }
            yield return new WaitForSeconds(1.0f);
        }
    }
    void ClearQuest()
    {
        if (!isAvailable)
            return;
        else
        {
            canClear = false;
            todayDate = DateTime.Now;
            SavedDate = todayDate.Year * 10000 + todayDate.Month * 100 + todayDate.Day;
        }

    }
    class QuestInfo
    {
        Rarity rarity;
        QuestKind questKind;
        ENEMY.EnemyKind targetEnemy;
        ArtiCtrl.MaterialList targetMaterial;
    }

    public void InstantiateWindow()
    {
        window = Instantiate(main.P_texts[29], main.WindowShowCanvas);
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
    public void ShowWindow()
    {
        if (window.activeSelf)
        {
          //  window.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "- " + UnlockCondition[clearNum];
          //  window.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = "- " + CurrentProgress[clearNum]();
          //  //  window.transform.GetChild(6).GetComponent<TextMeshProUGUI>().text = "- " + tDigit(QuestPoints[clearNum]) + " Quest Point";
          //  window.transform.GetChild(7).GetComponent<TextMeshProUGUI>().text = rewardText[clearNum];
          //  window.transform.GetChild(9).GetComponent<TextMeshProUGUI>().text = "- " + CliantName;
          //  window.transform.GetChild(10).GetComponent<TextMeshProUGUI>().text = discription[clearNum];
                    

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
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(50.0f, 200.0f);
            //    }
            //}
        }
    }

    static T RandomElementAt<T>(IEnumerable<T> ie)
    {
        return ie.ElementAt(new System.Random().Next(ie.Count()));
    }
}
