using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;

public class MISSION : BASE {

    //ミッションの種類
    //時間内に倒す done
    //HPX%以上でクリア done
    //物理or魔法縛り done
    //Baseスキルのみ
    //No Move
    //No Equipment
    //素材を集める．

    public int MissionId;
    public int NewMissionId => MissionId + 384 * Convert.ToInt32(main.ZoneCtrl.isHidden);
    public long EpicCoinNum;
    public long SeNum;
    public bool isCleared { get => main.S.M_isCleared[NewMissionId]; set => main.S.M_isCleared[NewMissionId] = value; }
    public bool isClearedAfterReincarnation { get => main.S.M_isClearedAfterReincarnation[NewMissionId];
        set => main.S.M_isClearedAfterReincarnation[NewMissionId] = value; }
    public long materialNum { get => main.S.M_materialNum[NewMissionId];
        set => main.S.M_materialNum[NewMissionId] = value; }
    public long capturedNum { get => main.S.M_capturedNum[NewMissionId];
        set => main.S.M_capturedNum[NewMissionId] = value; }
    public int MissionClearNumAfterReincarnation { get => main.S.MissionClearNumAfterReincarnation[NewMissionId]; set =>
            main.S.MissionClearNumAfterReincarnation[NewMissionId] = value;
    }
    Transform P_transform;
    public virtual void Initialize() { }
    public void Judge(float time) {
        if (ClearTrigger())
        {
            GetEpicCoin();
        }
    }
    //エリアクリアが終わった後に判定するかどうか？
    public bool isUpdate;
    //常に判定するときの成功条件
    public Func<bool> ClearCondition = () => false;
    //クリアした後に判定するときの成功条件
    public Func<bool> ClearTrigger = () => false;
    [NonSerialized]
    public TextMeshProUGUI MissionExplainText;
    TextMeshProUGUI EpicCoinNumText;
    public Coroutine updateJudge;
    DUNGEON thisDungeon;
    GameObject thisWindow;
    // Use this for initialization
	public void AwakeMission () {
		StartBASE();
        thisDungeon = gameObject.GetComponent<DUNGEON>();
        thisWindow = thisDungeon.window;
    }
	// Use this for initialization
	public void StartMission () { 
        MissionExplainText = Instantiate(main.Texts[29], gameObject.GetComponent<DUNGEON>().window.transform.GetChild(5));
        EpicCoinNumText = MissionExplainText.gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        updateJudge = StartCoroutine(UpdateJudge());
        if (MissionId % 5 == 0 || MissionId % 5 == 1)
        {
            EpicCoinNum = 10;
            SeNum = 10;
        }
        if (MissionId % 5 == 2 || MissionId % 5 == 3)
        {
            EpicCoinNum = 25;
            SeNum = 20;
        }
        if (MissionId % 5 == 4)
        {
            EpicCoinNum = 55;
            SeNum = 30;
        }
    }
    public bool IsReinAndCleared()
    {
        return main.S.ReincarnationNum > 0 && isCleared && !isClearedAfterReincarnation;
    }
    public long GetEpicCoin()
    {
        if (IsReinAndCleared())
        {
            main.S.SRPfromMission += SeNum;
            isClearedAfterReincarnation = true;
            main.S.totalMissionCleared++;
            MissionClearNumAfterReincarnation++;
        }
        else if(!isCleared)
        {
            isCleared = true;
            main.S.totalMissionCleared++;
        }
        return 0;
    }	
	// Update is called once per frame
	public void UpdateMission () {
        if (!thisWindow.activeSelf)
        {
            return;
        }
        LocalizeInitialize.SetFont(MissionExplainText);
        //レインカーネーション後で、かつミッションクリアしている。
        if (main.S.ReincarnationNum > 0)
        {
            //クリアした
            if (isClearedAfterReincarnation)
            {
                MissionExplainText.color = Color.green;
                EpicCoinNumText.text = "  <sprite=\"se2\" index=0>  <color=green>" + tDigit(SeNum);
            }
            //クリアしてない
            else if (!isClearedAfterReincarnation)
            {
                //一回はクリアしてる 
                if (isCleared)
                {
                    MissionExplainText.color = orange;
                    EpicCoinNumText.text = "  <sprite=\"se2\" index=0>  <color=orange>" + tDigit(SeNum);
                }
                //そもそもクリアしてない
                else
                {
                    MissionExplainText.color = Color.white;
                    EpicCoinNumText.text = "<sprite=0> <color=white>" + tDigit(EpicCoinNum);
                }
            }
        }
        else
        {
            if (isCleared)
            {
                MissionExplainText.color = Color.green;
                EpicCoinNumText.text = "<sprite=0> <color=green>" + tDigit(EpicCoinNum);
            }
            else
            {
                MissionExplainText.color = Color.white;
                EpicCoinNumText.text = "<sprite=0> <color=white>" + tDigit(EpicCoinNum);
            }
        }
	}
    protected virtual void ResetVariable()
    {

    }
    public IEnumerator UpdateJudge()
    {
       if (!isUpdate)
       {
           yield break;
       }

        while (true)
        {
            //
            yield return new WaitUntil(() => ClearCondition());
            GetEpicCoin();
            if(main.S.ReincarnationNum > 0 && !isClearedAfterReincarnation)
                ResetVariable();
            yield return new WaitForSeconds(1.0f);
        }
        /*
        while (!ClearCondition() || isCleared)
        {
            yield return new WaitForSeconds(0.1f);
        }
        main.S.ECbyMission += GetEpicCoin();
        isCleared = true;
        */
    }
}
