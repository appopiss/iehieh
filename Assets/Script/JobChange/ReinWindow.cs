using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using UnityEngine.EventSystems;
using TMPro;
using System.Text;

public class ReinWindow : BASE {

    public GameObject window;
    public GameObject TargetObject;

    public void InstantiateWindow()
    {
        window = Instantiate(main.P_texts[22], main.WindowShowCanvas);
        TargetObject.AddComponent<EventTrigger>().triggers = new List<EventTrigger.Entry>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry2.eventID = EventTriggerType.PointerExit;
        entry.callback.AddListener((x) => UsefulMethod.setActive(window));
        entry2.callback.AddListener((x) => UsefulMethod.setFalse(window)); //ラムダ式の右側は追加するメソッドです。
        TargetObject.GetComponent<EventTrigger>().triggers.Add(entry);
        TargetObject.GetComponent<EventTrigger>().triggers.Add(entry2);
    }
    IEnumerator GotHeartStone()
    {
        while (true)
        {
            yield return new WaitUntil(() => main.S.totalMissionCleared >= 1000 * (1 + main.S.totalHeartStoneGot));
            main.S.RP++;
            main.S.totalHeartStoneGot++;
            yield return new WaitForSeconds(1.0f);
        }
    }

    string ShowBonusText()
    {
        StringBuilder tempText = new StringBuilder();
        tempText.Append("<size=20>Reincarnation Number : ");
        tempText.Append(main.S.ReincarnationNum);
        tempText.Append("</size>\n\n");
        tempText.Append("<size=16>Passive Bonus</size>\n");
        tempText.Append("- Starting Gold Cap  <color=green>+ ");
        tempText.Append(tDigit(main.rein.R_factor.GoldCap()));
        tempText.Append("</color>\n- Prestige Point Gain   <color=green>");
        tempText.Append(percent(1 + main.rein.R_factor.RebirthPoint()));
        tempText.Append("</color>\n- Stats (HP,MP,ATK,MATK,DEF,MDEF,SPD)   <color=green>");
        tempText.Append(percent(1 + main.rein.R_factor.StatusIncrease()));
        tempText.Append("</color>");
        tempText.Append("\n\n<size=16>Spirit Essence Breakdown</size>\n");
        tempText.Append("- Playtime : <color=green> " + main.S.SRPfromTime + "</color>   ( Reincarnation Time : " + DoubleTimeToDate(main.S.reincarnationTime) + " )\n");
        tempText.Append("- Max Hero Level Reached : <color=green> " + main.S.SRPfromLevel + "</color>\n");
        tempText.Append("- Rebirth : <color=green> " + main.S.SRPfromRebirth + "</color>\n");
        tempText.Append("- Equipment Evolution : <color=green> " + main.S.SRPfromEquipment + "</color>\n");
        tempText.Append("- Slime Bank Cap : <color=green> " + main.S.SRPfromBankCap + "</color>\n");
        tempText.Append("- Gathered Materials : <color=green> " + main.S.SRPfromMaterial + "</color>\n");
        tempText.Append("- Montblango : <color=green> " + main.S.SRPfromMontblango + "</color>\n");
        if (main.S.SRPfromMission == 0)
            tempText.Append("- Mission : <color=green>0</color>   ( enabled after the first Reincarnation )\n");
        else
            tempText.Append("- Mission : <color=green> " + main.S.SRPfromMission + "</color>\n");
        if (main.S.SRPfromQuest == 0)
            tempText.Append("- Quest : <color=green>0</color>   ( enabled after the first Reincarnation )\n");
        else
            tempText.Append("- Quest : <color=green> " + main.S.SRPfromQuest + "</color>\n");
        if (main.S.SRPfromPrevious - main.S.SRPconsumed==0)
            tempText.Append("- Previous : <color=green>0</color> \n");
        else
            tempText.Append("- Previous : <color=green> " + (main.S.SRPfromPrevious - main.S.SRPconsumed) + "</color>\n");
        if (main.S.SRPinstantConsumed > 0)
            tempText.Append("- Instant Paid : <color=red> - " + main.S.SRPinstantConsumed + "</color>\n");
        tempText.Append("<size=13>Total Spirit Essence : <color=green> " + main.RPmanager.SpiritEssence() + "</color></size>");
        tempText.Append("\n\n<size=16>Heart Stone Bonus from Missions</size>");
        tempText.Append("\nGain 1 Heart Stone per 1000 Total Mission Cleared.");
        tempText.Append("\n- Total Mission Cleared : <color=green>" + tDigit(main.S.totalMissionCleared) + "</color>");
        tempText.Append("\n- You have got <color=green>" + tDigit(main.S.totalHeartStoneGot) + "</color> Heart Stone");
        //text.Append("\n\n Total Missions Cleared Through Reincarnation - <color=green> " + main.S.totalMissionCleared + "</color>");
        //text.Append("\n\n You can get 1 extra Heart Stone once every 1000 total missions cleared");
        //text.Append("You got " + main.S.totalHeartStoneGot + " Heart Stone");


        return tempText.ToString();

    }
    // Use this for initialization
    void Awake () {
		StartBASE();
        InstantiateWindow();
	}

	// Use this for initialization
	void Start () {
        StartCoroutine(GotHeartStone());
	}
	
	// Update is called once per frame
	void Update () {
        updateText();
	}

    void updateText()
    {
        if (!window.activeSelf)
            return;

        window.GetComponentInChildren<TextMeshProUGUI>().text = ShowBonusText();

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
