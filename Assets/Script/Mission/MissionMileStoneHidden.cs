using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using static UsefulMethod;

public class MissionMileStoneHidden : BASE {

    public GameObject window;

    public void InstantiateWindow()
    {
        window = Instantiate(main.P_texts[39], main.WindowShowCanvas);
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

    private void Awake()
    {
        StartBASE();
        InstantiateWindow();
        gameObject.AddComponent<MS>().awakeMS(5, 0, "Gold Cap + 10%");
        gameObject.AddComponent<MS>().awakeMS(10, 1, "Multiply Stats (HP,MP,ATK,MATK,DEF,MDEF,SPD) by 2");
        gameObject.AddComponent<MS>().awakeMS(15, 2, "Gold Cap + 20%");
        gameObject.AddComponent<MS>().awakeMS(20, 3, "Multiply Stats (HP,MP,ATK,MATK,DEF,MDEF,SPD) by 2");
        gameObject.AddComponent<MS>().awakeMS(25, 4, "Gold Cap + 30%");
        gameObject.AddComponent<MS>().awakeMS(30, 5, "Multiply Stats (HP,MP,ATK,MATK,DEF,MDEF,SPD) by 2");
        gameObject.AddComponent<MS>().awakeMS(35, 6, "Gold Cap + 40%");
        gameObject.AddComponent<MS>().awakeMS(40, 7, "Multiply Stats (HP,MP,ATK,MATK,DEF,MDEF,SPD) by 2");
        gameObject.AddComponent<MS>().awakeMS(45, 8, "Gold Cap + 50%");
        gameObject.AddComponent<MS>().awakeMS(50, 9, "Multiply Stats (HP,MP,ATK,MATK,DEF,MDEF,SPD) by 2");
        gameObject.AddComponent<MS>().awakeMS(60, 10, "Gold Cap + 60%");
        gameObject.AddComponent<MS>().awakeMS(70, 11, "Multiply Stats (HP,MP,ATK,MATK,DEF,MDEF,SPD) by 3");
        gameObject.AddComponent<MS>().awakeMS(80, 12, "Gold Cap + 70%");
        gameObject.AddComponent<MS>().awakeMS(90, 13, "Multiply Stats (HP,MP,ATK,MATK,DEF,MDEF,SPD) by 3");
        gameObject.AddComponent<MS>().awakeMS(100, 14, "Gold Cap + 80%");
        gameObject.AddComponent<MS>().awakeMS(110, 15, "Multiply Stats (HP,MP,ATK,MATK,DEF,MDEF,SPD) by 3");
        gameObject.AddComponent<MS>().awakeMS(120, 16, "Gold Cap + 90%");
        gameObject.AddComponent<MS>().awakeMS(130, 17, "Multiply Stats (HP,MP,ATK,MATK,DEF,MDEF,SPD) by 4");
        gameObject.AddComponent<MS>().awakeMS(140, 18, "Gold Cap + 100%");
        gameObject.AddComponent<MS>().awakeMS(150, 19, "Multiply Stats (HP,MP,ATK,MATK,DEF,MDEF,SPD) by 5");
        gameObject.AddComponent<MS>().awakeMS(160, 20, "Gold Cap + 120%");
        gameObject.AddComponent<MS>().awakeMS(170, 21, "Multiply Stats (HP,MP,ATK,MATK,DEF,MDEF,SPD) by 6");
        gameObject.AddComponent<MS>().awakeMS(180, 22, "Gold Cap + 140%");
        gameObject.AddComponent<MS>().awakeMS(190, 23, "Multiply Stats (HP,MP,ATK,MATK,DEF,MDEF,SPD) by 7");
        gameObject.AddComponent<MS>().awakeMS(200, 24, "Gold Cap + 160%");
        gameObject.AddComponent<MS>().awakeMS(210, 25, "Multiply Stats (HP,MP,ATK,MATK,DEF,MDEF,SPD) by 8");
        gameObject.AddComponent<MS>().awakeMS(220, 26, "Gold Cap + 180%");
        gameObject.AddComponent<MS>().awakeMS(230, 27, "Multiply Stats (HP,MP,ATK,MATK,DEF,MDEF,SPD) by 9");
        gameObject.AddComponent<MS>().awakeMS(240, 28, "Gold Cap + 200%");
        gameObject.AddComponent<MS>().awakeMS(250, 29, "Multiply Stats (HP,MP,ATK,MATK,DEF,MDEF,SPD) by 10");
        gameObject.AddComponent<MS>().awakeMS(275, 30, "Gold Cap + 250%");
        gameObject.AddComponent<MS>().awakeMS(300, 31, "Multiply Stats (HP,MP,ATK,MATK,DEF,MDEF,SPD) by 15");
        gameObject.AddComponent<MS>().awakeMS(325, 32, "Multiply Monster Gold Cap by 2");
        gameObject.AddComponent<MS>().awakeMS(350, 33, "Multiply Stats (HP,MP,ATK,MATK,DEF,MDEF,SPD) by 20");
        //gameObject.AddComponent<MS>().awakeMS(375, 34, "Multiply Monster Gold Cap by 2");
        //gameObject.AddComponent<MS>().awakeMS(384, 35, "");
    }
    public double MonsterGoldCap()
    {
        if (main.MissionCountHidden >= 325)
            return 2;
        return 1;
    }
    public double GoldCapFactor()
    {
        double tempValue = 0;
        if (main.MissionCountHidden >= 15)
            tempValue += 0.1;
        if (main.MissionCountHidden >= 15)
            tempValue += 0.2;
        if (main.MissionCountHidden >= 25)
            tempValue += 0.3;
        if (main.MissionCountHidden >= 35)
            tempValue += 0.4;
        if (main.MissionCountHidden >= 45)
            tempValue += 0.5;
        if (main.MissionCountHidden >= 60)
            tempValue += 0.6;
        if (main.MissionCountHidden >= 80)
            tempValue += 0.7;
        if (main.MissionCountHidden >= 100)
            tempValue += 0.8;
        if (main.MissionCountHidden >= 120)
            tempValue += 0.9;
        if (main.MissionCountHidden >= 140)
            tempValue += 1.0;
        if (main.MissionCountHidden >= 160)
            tempValue += 1.2;
        if (main.MissionCountHidden >= 180)
            tempValue += 1.4;
        if (main.MissionCountHidden >= 200)
            tempValue += 1.6;
        if (main.MissionCountHidden >= 220)
            tempValue += 1.8;
        if (main.MissionCountHidden >= 240)
            tempValue += 2.0;
        if (main.MissionCountHidden >= 275)
            tempValue += 2.5;
        return tempValue;
    }
    public double StatsFactor()
    {
        double tempValue = 1;
        if (main.MissionCountHidden >= 10)
            tempValue *= 2;
        if (main.MissionCountHidden >= 20)
            tempValue *= 2;
        if (main.MissionCountHidden >= 30)
            tempValue *= 2;
        if (main.MissionCountHidden >= 40)
            tempValue *= 2;
        if (main.MissionCountHidden >= 50)
            tempValue *= 2;
        if (main.MissionCountHidden >= 70)
            tempValue *= 3;
        if (main.MissionCountHidden >= 90)
            tempValue *= 3;
        if (main.MissionCountHidden >= 110)
            tempValue *= 3;
        if (main.MissionCountHidden >= 130)
            tempValue *= 4;
        if (main.MissionCountHidden >= 150)
            tempValue *= 5;
        if (main.MissionCountHidden >= 170)
            tempValue *= 6;
        if (main.MissionCountHidden >= 190)
            tempValue *= 7;
        if (main.MissionCountHidden >= 210)
            tempValue *= 8;
        if (main.MissionCountHidden >= 230)
            tempValue *= 9;
        if (main.MissionCountHidden >= 250)
            tempValue *= 10;
        if (main.MissionCountHidden >= 300)
            tempValue *= 15;
        if (main.MissionCountHidden >= 350)
            tempValue *= 20;
        return tempValue;
    }
    void updateText()
    {
        if (!window.activeSelf)
            return;

        StringBuilder text = new StringBuilder();
        text.Append("Hidden Mission Milestone ( Cleared <color=green>");
        text.Append(main.MissionCountHidden);
        text.Append("</color> Mission )\n<size=11>");
        foreach(MS ms in gameObject.GetComponentsInChildren<MS>())
        {
            if (ms.isCleared)
            {
                text.Append("<color=green>");
                text.Append(ms.explainText());
                text.Append("</color>");
            }
            else
            {
                text.Append(ms.explainText());
                text.Append("</color>");
            }
        }
        window.GetComponentInChildren<TextMeshProUGUI>().text = text.ToString();
    }

    private void Update()
    {
        updateText();
    }

    public class MS : BASE
    {
        int clearNum;
        public bool isCleared { get => main.S.isMissionMileStoneHidden[thisId]; set => main.S.isMissionMileStoneHidden[thisId] = value; }
        int thisId;
        Action ClearAction = () => { };
        public string text;
        public string explainText()
        {
            if (clearNum < 10)
                return "\n-     " + clearNum + "  :  " + text;
            else if(clearNum <100)
                return "\n-   " + clearNum + "  :  " + text;
            else
                return "\n- " + clearNum + "  :  " + text;
        }

        public void awakeMS(int clearNum, int thisId,string text, Action action = null)
        {
            StartBASE();
            this.clearNum = clearNum;
            this.thisId = thisId;
            this.text = text;
            if(action!=null)
            ClearAction = action;
        }

        private void Start()
        {
            StartCoroutine(WaitUntilClear());
        }

        IEnumerator WaitUntilClear()
        {
            if (isCleared)
            {
                yield break;
            }

            yield return new WaitUntil(() => main.MissionCountHidden >= clearNum);
            isCleared = true;
            ClearAction();
        }
    }
}
