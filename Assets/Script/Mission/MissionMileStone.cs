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

public class MissionMileStone : BASE {

    public GameObject window;
    //public List<MS> MSlist;

    public void InstantiateWindow()
    {
        window = Instantiate(main.P_texts[31], main.WindowShowCanvas);
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
        gameObject.AddComponent<MS>().awakeMS(5, 0, "100 Monster Fluid", () => main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.MonsterFluid] += 100);
        gameObject.AddComponent<MS>().awakeMS(10, 1, "1 Extra Equipment Slot");
        gameObject.AddComponent<MS>().awakeMS(20, 2, "Gold Cap + 1000");
        gameObject.AddComponent<MS>().awakeMS(30, 3, "Reduce cooldown of active skills by 60 s");
        gameObject.AddComponent<MS>().awakeMS(40, 4, "Resource production + 100%");
        gameObject.AddComponent<MS>().awakeMS(50, 5, "10 Black Pearl", () => main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.BlackPearl] += 10);
        gameObject.AddComponent<MS>().awakeMS(60, 6, "Mysterious Water Purifying speed + 100%");
        gameObject.AddComponent<MS>().awakeMS(70, 7, "10000 Monster Fluid", () => main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.MonsterFluid] += 10000);
        gameObject.AddComponent<MS>().awakeMS(80, 8, "1 Extra Equipment Slot");
        gameObject.AddComponent<MS>().awakeMS(90, 9, "Gold Cap + 10000");
        gameObject.AddComponent<MS>().awakeMS(100, 10, "Trap Chance + 20%");
        gameObject.AddComponent<MS>().awakeMS(120, 11, "100 Black Pearl", () => main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.BlackPearl] += 100);
        gameObject.AddComponent<MS>().awakeMS(140, 12, "1 Extra Equipment Slot");
        gameObject.AddComponent<MS>().awakeMS(160, 13, "Resource Production + 1000%");
        gameObject.AddComponent<MS>().awakeMS(180, 14, "Drop Chance + 20%");
        gameObject.AddComponent<MS>().awakeMS(200, 15, "Worker Power & Gem Effect + 50% in Dark Ritual");
        gameObject.AddComponent<MS>().awakeMS(225, 20, "Slime Bank Efficiency + 20%");
        gameObject.AddComponent<MS>().awakeMS(250, 16, "1 Extra Global Skill Slot",() =>
        {
            if (!main.S.isGlobalSlotbyMissionMilestone)
            {
                main.skillSetController.UnleashGrobalSkillSlot();
                main.S.isGlobalSlotbyMissionMilestone = true;
            }
        });
        gameObject.AddComponent<MS>().awakeMS(275, 21, "Enable normal skills to be set in Global Slot");
        gameObject.AddComponent<MS>().awakeMS(300, 17, "All Passive Effects of skill apply to every class");
        gameObject.AddComponent<MS>().awakeMS(325, 22, "Workers persist through Rebirth & Reincarnation");
        gameObject.AddComponent<MS>().awakeMS(350, 23, "Monster Gold Cap + 50 per Reincarnation");
        gameObject.AddComponent<MS>().awakeMS(375, 24, "Worker&Gem Effect + 100% & half complete time");
        gameObject.AddComponent<MS>().awakeMS(384, 25, "Gain Core when you defeat Lv 1 Challenge Boss");
    }
    public long GoldCap()
    {
        if(main.MissionCount >= 350)
        {
            return main.S.ReincarnationNum * 50;
        }
        else
        {
            return 0;
        }
    }


    public double GemHalfTime()
    {
        if(main.MissionCount >= 375)
        {
            return 0.5;
        }
        else
        {
            return 1.0;
        }
    }

    public int EquipmentBonus()
    {
        int tempInt = 0;
        if (main.MissionCount >= 10)
            tempInt++;
        if (main.MissionCount >= 80)
            tempInt++;
        if (main.MissionCount >= 140)
            tempInt++;

        return tempInt;
    }
    //gold cap bonus
    public double GoldCapBonus()
    {
        double temp = 0;
        if (main.MissionCount >= 20)
            temp += 1000;
        if (main.MissionCount >= 90)
            temp += 10000;

        return temp;
    }
    //resource bonus
    public double ResourceBonus()
    {
        double temp = 0;
        if (main.MissionCount >= 40)
            temp += 1.0;
        if (main.MissionCount >= 160)
            temp += 10.0;

        return temp;
    }
    //water bonus
    public float WaterBonus()
    {
        if (main.MissionCount >= 60)
            return 1.0f;
        else
            return 0;
    }
    public double TrapBonus()
    {
        if (main.MissionCount >= 100)
            return 0.2;
        else
            return 0;
    }
    public double DropBonus()
    {
        if (main.MissionCount >= 180)
            return 0.2;
        else
            return 0;
    }
    public double JemBonus()
    {
        double temp = 0;
        if(main.MissionCount >= 200)
        {
            temp += 0.5;
        }
        if(main.MissionCount >= 375)
        {
            temp += 1.0;
        }

        return temp;
    }
    public float CoolTimeBonus()
    {
        if (main.MissionCount >= 30)
            return -60f;
        else
            return 0;
    }
    public double BankEfficiencyBonus()
    {
        if (main.MissionCount >= 225)
            return 0.2d;
        else
            return 0;
    }
    public bool IsSkillPassiveEffect()
    {
        if (main.MissionCount >= 300)
            return true;
        else
            return false;
    }
    public bool IsGlobalSkill()
    {
        if (main.MissionCount >= 275)
            return true;
        else
            return false;
    }
    void updateText()
    {
        if (!window.activeSelf)
            return;

        StringBuilder text = new StringBuilder();
        text.Append("Mission Milestone ( Cleared <color=green>");
        text.Append(main.MissionCount);
        text.Append("</color> Mission )\n<size=12>");
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

    private void Update()
    {
        updateText();
        if(main.MissionCount >= 325 && !main.S.isMission325Completed)
        {
            main.S.isMission325Completed = true;
        }
        if (main.MissionCount >= 384 && !main.S.isMission384Completed)
        {
            main.S.isMission384Completed = true;
        }
    }

    public class MS : BASE
    {
        int clearNum;
        public bool isCleared { get => main.S.isMissionMileStone[thisId]; set => main.S.isMissionMileStone[thisId] = value; }
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

            yield return new WaitUntil(() => main.MissionCount >= clearNum);
            isCleared = true;
            ClearAction();
        }
    }
}
