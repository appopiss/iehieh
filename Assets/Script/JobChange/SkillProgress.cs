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

public class SkillProgress : BASE {

    public Slider[] ReincarnationSliderAry;
    public TextMeshProUGUI[] ReinProgressTextAry;
    bool isWindow;
    public float intervalFactor;
    public double mpFactor;
    public bool isNoMpChance;
    public bool isWizDebuffFactor;//coldとpalaryseの加算ファクタ
    public bool isWizNoMp;//Interval半分
    public float movespeedFactor;
    public bool isHealInterval;
    public bool isBuffDuration;
    public float regeneratePointPercent;
    public double buffFactor;
    public float isSordAttackInterval;
    public int dodgeChancePercent;
    public int criticalChance;

    public void InstantiateWindow()
    {
        window = Instantiate(main.P_texts[32], main.WindowShowCanvas);
        EventTrigger.Entry entry = new EventTrigger.Entry();
        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry2.eventID = EventTriggerType.PointerExit;
        entry.callback.AddListener((x) => UsefulMethod.setActive(window));
        entry2.callback.AddListener((x) => UsefulMethod.setFalse(window)); //ラムダ式の右側は追加するメソッドです。
        switch (main.ally.job)
        {
            case ALLY.Job.Warrior:
                ReincarnationSliderAry[0].gameObject.AddComponent<EventTrigger>().triggers = new List<EventTrigger.Entry>();
                ReincarnationSliderAry[0].gameObject.GetComponent<EventTrigger>().triggers.Add(entry);
                ReincarnationSliderAry[0].gameObject.GetComponent<EventTrigger>().triggers.Add(entry2);
                break;
            case ALLY.Job.Wizard:
                ReincarnationSliderAry[1].gameObject.AddComponent<EventTrigger>().triggers = new List<EventTrigger.Entry>();
                ReincarnationSliderAry[1].gameObject.GetComponent<EventTrigger>().triggers.Add(entry);
                ReincarnationSliderAry[1].gameObject.GetComponent<EventTrigger>().triggers.Add(entry2);
                break;
            case ALLY.Job.Angel:
                ReincarnationSliderAry[2].gameObject.AddComponent<EventTrigger>().triggers = new List<EventTrigger.Entry>();
                ReincarnationSliderAry[2].gameObject.GetComponent<EventTrigger>().triggers.Add(entry);
                ReincarnationSliderAry[2].gameObject.GetComponent<EventTrigger>().triggers.Add(entry2);
                break;
            default:
                break;
        }
        isWindow = true;
        updateText();
    }

    void updateText()
    {
        StringBuilder text = new StringBuilder();
        text.Append("Class Passives  <color=green>");
        switch (main.ally.job)
        {
            case ALLY.Job.Warrior:
                text.Append(tDigit(Progress(ALLY.Job.Warrior) * 100 / 2000f, 1) + "%</color>\n<size=4><size=12>");
                intervalFactor = 0;
                mpFactor = 0;
                isNoMpChance = false;
                isWizDebuffFactor = false;
                movespeedFactor = 0;
                isHealInterval = false;
                isBuffDuration = false;
                regeneratePointPercent = 0;
                buffFactor = 0;
                if (Progress(ALLY.Job.Warrior) < 400)
                {
                    isSordAttackInterval = 0;
                    text.Append("<color=white>");
                }
                else
                {
                    isSordAttackInterval = 0.5f;
                    text.Append("<color=green>");
                }
                text.Append("\n-   20% : Reduce Sword Attack Interval by 50%</color>");

                if (Progress(ALLY.Job.Warrior) < 800)
                {
                    dodgeChancePercent = 0;
                    text.Append("<color=white>");
                }
                else
                {
                    dodgeChancePercent = 2;
                    text.Append("<color=green>");
                }
                text.Append("\n-   40% : Increase Dodge Chance by 2%</color>");

                if (Progress(ALLY.Job.Warrior) < 1200)
                {
                    text.Append("<color=white>");
                }
                else
                {
                    dodgeChancePercent = 5;
                    text.Append("<color=green>");
                }
                text.Append("\n-   60% : Increase Dodge Chance by 3%</color>");

                if (Progress(ALLY.Job.Warrior) < 1600)
                {
                    criticalChance = 0;
                    text.Append("<color=white>");
                }
                else
                {
                    criticalChance = 1;
                    text.Append("<color=green>");
                }
                text.Append("\n-   80% : Increase Critical Chance by 1%</color>");

                if (Progress(ALLY.Job.Warrior) < 2000)
                {
                    text.Append("<color=white>");
                }
                else
                {
                    criticalChance = 3;
                    text.Append("<color=green>");
                }
                text.Append("\n- 100% : Increase Critical Chance by 2%</color>");

                break;
            case ALLY.Job.Wizard:
                text.Append(tDigit(Progress(ALLY.Job.Wizard) * 100 / 2000f, 1) + "%</color>\n<size=4><size=12>");
                movespeedFactor = 0;
                isHealInterval = false;
                isBuffDuration = false;
                regeneratePointPercent = 0;
                buffFactor = 0;
                isSordAttackInterval = 0;
                dodgeChancePercent = 0;
                criticalChance = 0;

                if (Progress(ALLY.Job.Wizard) < 400)
                {
                    intervalFactor = 0;
                    text.Append("<color=white>");
                }
                else
                {
                    intervalFactor = 0.25f;
                    text.Append("<color=green>");
                }
                text.Append("\n-   20% : Reduce Skill Intervals by 25%</color>");

                if (Progress(ALLY.Job.Wizard) < 800)
                {
                    mpFactor = 0;
                    text.Append("<color=white>");
                }
                else
                {
                    mpFactor = 0.5d;
                    text.Append("<color=green>");
                }
                text.Append("\n-   40% : Reduce MP Costs by 50%</color>");

                if (Progress(ALLY.Job.Wizard) < 1200)
                {
                    isNoMpChance = false;
                    text.Append("<color=white>");
                }
                else
                {
                    isNoMpChance = true;
                    text.Append("<color=green>");
                }
                text.Append("\n-   60% : 20% on cast that skill will use no MP</color>");

                if (Progress(ALLY.Job.Wizard) < 1600)
                {
                    isWizDebuffFactor = false;
                    text.Append("<color=white>");
                }
                else
                {
                    isWizDebuffFactor = true;
                    text.Append("<color=green>");
                }
                text.Append("\n-   80% : Damage done to monsters with cold or paralyze increased by 200%</color>");

                if (Progress(ALLY.Job.Wizard) < 2000)
                {
                    isWizNoMp = false;
                    text.Append("<color=white>");
                }
                else
                {
                    isWizNoMp = true;
                    text.Append("<color=green>");
                }
                text.Append("\n- 100% : Reduce skill Intervals for Blizzard, Meteor Strike and Lightning Thunder by 50%</color>");

                break;

            case ALLY.Job.Angel:
                text.Append(tDigit(Progress(ALLY.Job.Angel) * 100 / 2000f, 1) + "%</color>\n<size=4><size=12>");
                mpFactor = 0;
                intervalFactor = 0;
                isNoMpChance = false;
                isWizDebuffFactor = false;
                isSordAttackInterval = 0;
                dodgeChancePercent = 0;
                criticalChance = 0;

                if (Progress(ALLY.Job.Angel) < 400)
                {
                    movespeedFactor = 0;
                    text.Append("<color=white>");
                }
                else
                {
                    movespeedFactor = 0.25f;
                    text.Append("<color=green>");
                }
                text.Append("\n-   20% : Increase move speed by 25%</color>");

                if (Progress(ALLY.Job.Angel) < 800)
                {
                    isHealInterval=false;
                    text.Append("<color=white>");
                }
                else
                {
                    isHealInterval = true;
                    text.Append("<color=green>");
                }
                text.Append("\n-   40% : Reduce Heal MP cost by 25%</color>");

                if (Progress(ALLY.Job.Angel) < 1200)
                {
                    isBuffDuration = false;
                    text.Append("<color=white>");
                }
                else
                {
                    isBuffDuration = true;
                    text.Append("<color=green>");
                }
                text.Append("\n-   60% : Improve all skill buff durations by 100%</color>");

                if (Progress(ALLY.Job.Angel) < 1600)
                {
                    regeneratePointPercent = 0;
                    text.Append("<color=white>");
                }
                else
                {
                    regeneratePointPercent = 0.05f;
                    text.Append("<color=green>");
                }
                text.Append("\n-   80% : Regenerate HP by 0.05% / s</color>");

                if (Progress(ALLY.Job.Angel) < 2000)
                {
                    buffFactor = 0;
                    text.Append("<color=white>");
                }
                else
                {
                    buffFactor = 0.5;
                    text.Append("<color=green>");
                }
                text.Append("\n- 100% : Improve all skill buff potency by 50%</color>");
                break;

            default:
                break;
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


    // Use this for initialization
    void Awake () {
		StartBASE();
    }

    // Use this for initialization
    void Start () {
        StartCoroutine(InstantiateWindowCor());
    }

    IEnumerator InstantiateWindowCor()
    {
        yield return new WaitUntil(() => main.ally.job != ALLY.Job.Novice);
        InstantiateWindow();
    }

    float progress;

    public float Progress(ALLY.Job job)
    {
        progress = 0;
        switch (job)
        {
            case ALLY.Job.Warrior:
                for (int i = 0; i < 10; i++)
                {
                    if (main.saveWar.SkillLevel[i] >= 200)
                    {
                        progress += 200;
                    }
                    else
                    {
                        progress += main.saveWar.SkillLevel[i];
                    }
                }
                return progress;
            case ALLY.Job.Wizard:
                for (int i = 0; i < 10; i++)
                {
                    if (main.saveWiz.SkillLevel[i] >= 200)
                    {
                        progress += 200;
                    }
                    else
                    {
                        progress += main.saveWiz.SkillLevel[i];
                    }
                }
                return progress;
            case ALLY.Job.Angel:
                for (int i = 0; i < 10; i++)
                {
                    if (main.saveAng.SkillLevel[i] >= 200)
                    {
                        progress += 200;
                    }
                    else
                    {
                        progress += main.saveAng.SkillLevel[i];
                    }
                }
                return progress;
            default:
                return 0;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (main.GameController.currentCanvas == main.GameController.SkillTreeCanvas)
        {
            ReincarnationSliderAry[0].value = Progress(ALLY.Job.Warrior) / 2000f;
            ReincarnationSliderAry[1].value = Progress(ALLY.Job.Wizard) / 2000f;
            ReincarnationSliderAry[2].value = Progress(ALLY.Job.Angel) / 2000f;
            ReinProgressTextAry[0].text = tDigit(Progress(ALLY.Job.Warrior) * 100 / 2000f, 1) + "%";
            ReinProgressTextAry[1].text = tDigit(Progress(ALLY.Job.Wizard) * 100 / 2000f, 1) + "%";
            ReinProgressTextAry[2].text = tDigit(Progress(ALLY.Job.Angel) * 100 / 2000f, 1) + "%";

        }
        if (isWindow && window.activeSelf)//これは絶対消さないで
            updateText();

    }
}
