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

public class ACHIEVEMENT : BASE {

    GameObject window;
    GameObject hatena;
    public Image actualImage;
    Button claimButton;
    public string Name;
    public string CliantName;
    public string[] discription;
    public string[] rewardText;
    public string P_rewardText;
    public string P_discription;
    public string EffectExplain;
    public bool isUnlocked { get => main.S.isUnlocked[(int)quest]; set => main.S.isUnlocked[(int)quest] = value; }
    public Mode mode { get => main.S.mode[(int)quest]; set => main.S.mode[(int)quest] = value; }
    public int clearNum { get => main.S.clearNum[(int)quest]; set => main.S.clearNum[(int)quest] = value; }
    public virtual bool[] isSeen { get; set; }
    public long[] GoldCap;
    public float NitroBonus;
    public int MaxClearNum;
    public QuestList quest;
    public Coroutine QuestCor;
    public int EquipmentBonus;
    public long GoldCapBonus;
    public long SEbonus;
    public enum Mode
    {
        locked,
        claim,
        unlocked
    }
    public Type questType;
    public enum Type
    {
        Permanent,
        Limited
    }
    //この3つのデリゲートをlist化して，clearNumでアクセスするようにする．
    //クエストの解禁条件
    public string[] UnlockCondition;
    public string P_unlockCondition;
    public string[] QuestNames;
    public string P_questName;
    public Func<bool>[] Condition;
    public Func<bool> P_condition;
    //現在の進み具合
    public Func<string>[] CurrentProgress;
    public Func<string> P_currentProgress;
    public UL_quest unlock;
    public bool isParmanentMode()
    {
        return clearNum >= MaxClearNum;
    }
   // public long[] QuestPoints;
   // public long P_questPoint;
    public virtual void GetQuestPoint()
    {
    }
    // Use this for initialization
    public void AwakeQuest (int MaxClearNum, Type questType) {
		StartBASE();
        this.MaxClearNum = MaxClearNum;
        this.questType = questType;
        hatena = gameObject.transform.GetChild(1).gameObject;
        claimButton = gameObject.transform.GetChild(2).gameObject.GetComponent<Button>();
        actualImage = gameObject.transform.GetChild(0).gameObject.GetComponent<Image>();
        claimButton.onClick.AddListener(ClaimReward);
        //QuestPoints = new long[MaxClearNum+1];
        QuestNames = new string[MaxClearNum+1];
        Condition = new Func<bool>[MaxClearNum+1];
        CurrentProgress = new Func<string>[MaxClearNum+1];
        UnlockCondition = new string[MaxClearNum + 1];
        discription = new string[MaxClearNum + 1];
        rewardText = new string[MaxClearNum + 1];
        GoldCap = new long[MaxClearNum + 1];
        if (isSeen == null)
            isSeen = new bool[MaxClearNum + 1];
        unlock = gameObject.AddComponent<UL_quest>();
        unlock.type = questType;
        unlock.UnlockCondition = () => main.quests[(int)ACHIEVEMENT.QuestList.tutorial].clearNum >= 4;
        unlock.ClearCondition = () => questType == Type.Limited && clearNum == MaxClearNum;
        unlock.TargetCanvas = main.QuestCanvas;
        unlock.RepeatableCanvas = main.RepeatableCanvas;
        unlock.ClearedCanvas = main.ClearedCanvas;
        unlock.orderId = (int)quest;
        ExtraUnlockCondition();
        UpdateNitro();
    }
    public virtual void ExtraUnlockCondition() { }
    public enum QuestList
    {
        tutorial,
        SlimeBust,
        StrangeErrand,
        P_errand,
        PetheticMan,
        MysteriousMan,
        journey,
        husband,
        P_tailor,
        P_fairyRelics,
        P_leather,
        metal,
        P_octoSE,
        explore,
        expedition
    }

    // Use this for initialization
    public void StartQuest () {
        InstantiateWindow();
        Initialize();
        StartCoroutine(NennnotameButton());
	}

    public bool RecoverBool()
    {
        if (mode == Mode.unlocked || clearNum == 4)
            return true;

       return !Condition[clearNum]() || mode != Mode.claim;
    }

    public void GetEC(long ec)
    {
        if (main.S.ReincarnationNum == 0)
            main.S.ECbyQuest += ec;
    }

    public static long TotalSE()
    {
        long temp = 0;
        foreach(ACHIEVEMENT quest in main.quests)
        {
            temp += quest.SEbonus;
        }
        temp *= 10;
        return temp;
    }

    public string LetterImage()
    {
        if (main.S.ReincarnationNum == 0)
            return "\n- <sprite=0>";
        else
            return "\n-   <sprite=\"se2\" index=0>";
    }
    //現在のインデックスのConditionが開放されるまで待つ．
    public IEnumerator QuestControll()
    {
        yield return new WaitUntil(() => TitleCtrl.isLoaded);
        switch (questType)
        {
            　　//限定クエストの制御
            case Type.Limited:
                while (true)
                {
                    if (mode == Mode.unlocked || clearNum == 4)
                        yield break;


                     while (RecoverBool())
                        {
                            yield return null;
                        }

                    //yield return new WaitUntil(() => !Load.isLoading&&Condition[clearNum]() || mode == Mode.claim);
                    //条件が満たされたら，Claimモードにする．
                    if (mode != Mode.claim)
                        ShowLog();
                    mode = Mode.claim;
                    //claim状態になったら，再びlocked状態になるまで待つ．
                    yield return new WaitUntil(() => mode == Mode.locked);
                    //lockedに変わったということは，clearNumが+1されていることになる
                    if (clearNum == MaxClearNum)
                        yield break;
                }
                //パーマネントクエストの制御
            case Type.Permanent:
                while (true)
                {
                    bool tempBool = (!isParmanentMode() && Condition[clearNum]()) || (isParmanentMode()&& P_condition());
                    //条件が満たされるのを待つ．
                    yield return new WaitUntil(() => tempBool|| mode == Mode.claim);
                    //条件が満たされたら，Claimモードにする．
                    if (mode != Mode.claim)
                        ShowLog();
                    mode = Mode.claim;
                    //claim状態になったら，再びlocked状態になるまで待つ．
                    yield return new WaitUntil(() => mode == Mode.locked);
                }
            default:
                break;
        }

    }

    public void ClaimReward()
    {
       
        switch (questType)
        {
            case Type.Limited:
                if (clearNum == MaxClearNum || !Condition[clearNum]())
                    return;
                break;
            case Type.Permanent:
                if(isParmanentMode())
                {
                    if (!P_condition())
                        return;
                }else
                {
                    if (!Condition[clearNum]())
                        return;
                }
                break;
            default:
                break;           
        }

        GetQuestPoint();
        if (!isUnlocked && hatena != null)
            Destroy(hatena);
        isUnlocked = true;
        clearNum++;
        if(clearNum == MaxClearNum)
        {
            mode = Mode.unlocked;
        }
        else
        {
            mode = Mode.locked;
        }
    }

    public void Initialize()
    {
        if (isUnlocked && hatena != null)
            Destroy(hatena);

        QuestCor = StartCoroutine(QuestControll());
    }

    public void ShowLog()
    {
        if (!main.SR.isDungeon[9])
        {
            return;
        }

        switch (questType)
        {
            case Type.Limited:
                StartCoroutine(main.InstantiateLogText("Quest Completed! Claim the reward!", actualImage.sprite));
                break;
            case Type.Permanent:
                if(clearNum < MaxClearNum)
                {
                    StartCoroutine(main.InstantiateLogText("Quest Completed! Claim the reward!", actualImage.sprite));
                }
                else
                {
                    StartCoroutine(main.InstantiateLogText("Quest Completed! Claim the reward!", actualImage.sprite));
                }
                break;
        }
    } 
    public virtual void UpdateNitro() { }
    public virtual void updateTrophy()
    {
        if (clearNum <= 1)
        {
            actualImage.sprite = null;
            actualImage.sprite = main.A_ctrl.bronze;
        }
        else if (clearNum == 2)
        {
            actualImage.sprite = null;
            actualImage.sprite = main.A_ctrl.silver;
        }
        else if (clearNum == 3)
        {
            actualImage.sprite = null;
            actualImage.sprite = main.A_ctrl.gold;
        }
        else if (clearNum >= 4)
        {
            actualImage.sprite = null;
            actualImage.sprite = main.A_ctrl.platina;
        }
    }
    // Update is called once per frame
    public void UpdateQuest () {
        ShowWindow();
        updateTrophy();
        UpdateNitro();
        switch (questType)
        {
            case Type.Limited:
                if (clearNum == MaxClearNum || !Condition[clearNum]())
                    claimButton.interactable = false;
                else
                    claimButton.interactable = true;
                break;
            case Type.Permanent:
                bool tempBool = (clearNum < MaxClearNum && Condition[clearNum]()) || (clearNum >= MaxClearNum && P_condition());
                if (!tempBool)
                    claimButton.interactable = false;
                else
                    claimButton.interactable = true;
                break;
        }
	}

    public IEnumerator NennnotameButton()
    {
        while (true)
        {
            yield return new WaitUntil(() => claimButton.enabled == true);
            switch (questType)
            {
                case Type.Limited:
                    if (clearNum == MaxClearNum || !Condition[clearNum]())
                        claimButton.interactable = false;
                    else
                        claimButton.interactable = true;
                    break;
                case Type.Permanent:
                    bool tempBool = (clearNum < MaxClearNum && Condition[clearNum]()) || (clearNum >= MaxClearNum && P_condition());
                    if (!tempBool)
                        claimButton.interactable = false;
                    else
                        claimButton.interactable = true;
                    break;
            }

            yield return new WaitForSeconds(1.0f);
        }
    }


    public void InstantiateWindow()
    {
        window = Instantiate(main.P_texts[11], main.WindowShowCanvas);
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

    Vector2 completedWindowVector = new Vector2(150f, 100f);

    public void ShowWindow()
    {
        if (window.activeSelf)
        {
            //初めて依頼文を見たらboolをtrueに変える．
            if(isSeen.Length != 0&&clearNum<=4&&questType == Type.Limited)
                isSeen[clearNum] = true;

            QuestLocal.unlock(window.transform.GetChild(1).GetComponent<TextMeshProUGUI>());
            QuestLocal.progress(window.transform.GetChild(3).GetComponent<TextMeshProUGUI>());
            QuestLocal.reward(window.transform.GetChild(5).GetComponent<TextMeshProUGUI>());
            QuestLocal.client(window.transform.GetChild(7).GetComponent<TextMeshProUGUI>());
            LocalizeInitialize.SetFont(window.transform.GetChild(0).GetComponent<TextMeshProUGUI>(),
                window.transform.GetChild(2).GetComponent<TextMeshProUGUI>(),
                window.transform.GetChild(4).GetComponent<TextMeshProUGUI>(),
                window.transform.GetChild(6).GetComponent<TextMeshProUGUI>(),
                window.transform.GetChild(8).GetComponent<TextMeshProUGUI>(),
                window.transform.GetChild(9).GetComponent<TextMeshProUGUI>()
                );
            
            switch (questType)
            {
                case Type.Limited:
                    if (mode == Mode.locked || mode == Mode.claim)
                    {
                        window.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QuestNames[clearNum];
                        window.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "- "+UnlockCondition[clearNum];
                        window.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = "- "+CurrentProgress[clearNum]();
                     //  window.transform.GetChild(6).GetComponent<TextMeshProUGUI>().text = "- " + tDigit(QuestPoints[clearNum]) + " Quest Point";
                        window.transform.GetChild(6).GetComponent<TextMeshProUGUI>().text = rewardText[clearNum];
                        window.transform.GetChild(8).GetComponent<TextMeshProUGUI>().text = "- " + CliantName;
                        window.transform.GetChild(9).GetComponent<TextMeshProUGUI>().text = discription[clearNum];
                    }
                    else
                    {
                        window.GetComponent<RectTransform>().sizeDelta = completedWindowVector;
                        window.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "<size=16>Completed!";
                        for (int i = 1; i < 10; i++)
                        {
                            setFalse(window.transform.GetChild(i).gameObject);
                        }
                        //window.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "";
                        //window.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = "";
                        //window.transform.GetChild(6).GetComponent<TextMeshProUGUI>().text = "";
                        //window.transform.GetChild(6).GetComponent<TextMeshProUGUI>().text = "";
                        //window.transform.GetChild(8).GetComponent<TextMeshProUGUI>().text = "";
                        //window.transform.GetChild(9).GetComponent<TextMeshProUGUI>().text = "";
                    }
                    break;
                case Type.Permanent:
                    if (!isParmanentMode())
                    {
                        window.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QuestNames[clearNum];
                        window.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "- "+UnlockCondition[clearNum];
                        window.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = "- "+CurrentProgress[clearNum]();
                       // window.transform.GetChild(6).GetComponent<TextMeshProUGUI>().text = "- " + tDigit(QuestPoints[clearNum]) + " Quest Point";
                        window.transform.GetChild(6).GetComponent<TextMeshProUGUI>().text = rewardText[clearNum];
                        window.transform.GetChild(8).GetComponent<TextMeshProUGUI>().text = "- " + CliantName;
                        window.transform.GetChild(9).GetComponent<TextMeshProUGUI>().text = discription[clearNum];
                    }
                    else
                    {
                        window.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = P_questName;
                        window.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "- "+P_unlockCondition;
                        window.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = "- "+P_currentProgress();
                       // window.transform.GetChild(6).GetComponent<TextMeshProUGUI>().text = "- " + tDigit(P_questPoint)+ " Quest Point";
                        window.transform.GetChild(6).GetComponent<TextMeshProUGUI>().text = P_rewardText;
                        window.transform.GetChild(8).GetComponent<TextMeshProUGUI>().text = "- " + CliantName;
                        window.transform.GetChild(9).GetComponent<TextMeshProUGUI>().text = P_discription;
                    }
                    break;
            }

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
}
