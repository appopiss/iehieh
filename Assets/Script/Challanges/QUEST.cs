using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UsefulMethod;
using static QuestCtrl.QuestId;

public class QUEST : BASE {

    /*
     timeLimitは，院スペックたー上から設定する．
    */
    
    [System.NonSerialized]
    public bool isWin;
    public bool isQuit;
    public IEnumerator QuestCor;
    public virtual int clearedNum { get; set; }
    public virtual bool isCleared { get; set; }
    public virtual int maxClaredNum { get; set; }
    public ENEMY BossMonster;
    public TextMeshProUGUI defeatText;

    public Button button;

    public void AwakeQuest()
    {
        StartBASE();
        QuestCor = challangeCor();
    }

    public void StartQuest()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(()=> { changeQuestId(); main.QuestCtrl.ChangeText(); });
        main.buttons[5].onClick.AddListener(QuitChallange);
        button = gameObject.GetComponent<Button>();
    }

    public void UpdateQuest()
    {
        //if (QuestCondition())
        //{
        //    gameObject.GetComponent<Button>().interactable = true;
        //}
        //else
        //{
        //    gameObject.GetComponent<Button>().interactable = false;
        //}

        if (main.GameController.battleMode != GameController.BattleMode.challange||main.DeathPanel.isPanel)
        {
            main.buttons[5].interactable = false;
        }
        else
        {
            main.buttons[5].interactable = true;
        }
        if (main.GameController.battleMode != GameController.BattleMode.challange && QuestCondition())
        {
            //quit以外のボタンはtrue
            button.interactable = true;
        }
        else
        {
            //quit以外のボタンはfalse
            button.interactable = false;
        }
    }

    public virtual void InstantiateEnemy() { }

    public virtual bool QuestCondition()
    {
        return true;
    }

    public virtual bool ClearCondition() {

        return GameObject.FindGameObjectsWithTag("enemy").Length == 0;
    }   

    public virtual void changeQuestId()
    {

    }

    public virtual void GetReward() { }




    public IEnumerator challangeCor() { 
    
        yield return new WaitUntil(() =>
        {
            return ClearCondition() || main.ally1.GetComponent<ALLY>().currentHp <= 0 || isQuit;
        });
        if (main.ally1.GetComponent<ALLY>().currentHp <= 0 ||isQuit)
        {
            isWin = false;
            StartCoroutine(ShowDeathPanel(false));
        }
        else
        {
            isWin = true;
            GetReward();
            isCleared = true;
            //if ClearedNum == 0 ... Core確定ドロップ

            clearedNum++;
            maxClaredNum = Mathf.Max(clearedNum, maxClaredNum);
            StartCoroutine(ShowDeathPanel(true));
        }
    }

    public void QuitChallange()
    {
        isQuit = true;
    }


    //これはクエストに成功しても失敗しても呼ぶようにする．
    public IEnumerator ShowDeathPanel(bool isWin)
    {
        main.DeathPanel.isPanel = true;
        if (!main.toggles[1].isOn)
        {
            if (isWin)
            {
                main.DeathPanel.titleText.text = "Challenge Cleared!!!";
            }
            else
            {
                main.DeathPanel.titleText.text = "Challenge Failed...";
            }
            yield return main.DeathPanel.ActiveCor(main.deathPanel.gameObject);
            yield return main.DeathPanel.ActiveCor(main.DeathPanel.titleText.gameObject);
            main.DeathPanel.expText.text = "Total Exp Gained " + tDigit(main.DeathPanel.C_exp);
            yield return main.DeathPanel.ActiveCor(main.DeathPanel.expText.gameObject);
            main.DeathPanel.goldText.text = "Total Gold Gained " + tDigit(main.DeathPanel.C_gold);
            yield return main.DeathPanel.ActiveCor(main.DeathPanel.goldText.gameObject);
            main.DeathPanel.timeText.text = "Survival time " + DoubleTimeToDate(main.DeathPanel.C_time);
            yield return main.DeathPanel.ActiveCor(main.DeathPanel.timeText.gameObject);
            main.DeathPanel.AddMaterialText();//Cをとってみた
            for (int i = 0; i < main.DeathPanel.materialTexts.Length; i++)
            {
                StartCoroutine(main.DeathPanel.ActiveCor(main.DeathPanel.materialTexts[i].gameObject));
            }
            yield return new WaitForSeconds(2.0f);
            main.DeathPanel.FadeAwayPanel();
        }
        else
        {
            if(isWin)
               main.ally.InstantiateTextOnMe("CLEAR!", Color.red);
            else
                main.ally.InstantiateTextOnMe("Failed", Color.red);
            yield return new WaitForSeconds(1.0f);
        }
        main.ally.ResetStatus();
        if (main.toggles[2].isOn)
            main.toggles[3].isOn = false;
        main.DeathPanel.isPanel = false;
        EndChallenge();
        yield return new WaitForSeconds(0.2f);
        if (main.toggles[5].isOn&&isWin)
        {
            StartChallange();
            yield break;
        }
        main.dungeonAry[(int)main.GameController.currentDungeon].gameObject.GetComponent<Button>().onClick.Invoke();
    }

    public virtual void EndChallenge() { }
        
    public void StartChallange()
    {
        main.GameController.Initialize();
        InitChallange();
        InstantiateEnemy();
        StartCoroutine(challangeCor());
    }

    public void InitChallange()
    {
        main.DeathPanel.FadeAwayPanel();
        main.DeathPanel.C_initResult();
        //MissionReset
        DUNGEON.InitializeMission();
        main.ally.currentHp = main.ally.HP();
        isWin = false;
        isQuit = false;
        main.GameController.battleMode = GameController.BattleMode.challange;
        main.GameController.ChangeFieldSprite();
        main.ally.condition = ALLY.Condition.MoveMode;
        main.ally.combo = 0;
        main.ally.stayTime = 0;
    }

    public void InstantiateBoss(ENEMY enemy, Vector3 position,double[] Status = null)
    {
        ENEMY game;
        ENEMY _enemy = enemy;
        if (main.cc.CurrentCurseId == CurseId.curse_of_metal)
            _enemy = main.QuestCtrl.BigMetalSlime;

        game = Instantiate(_enemy, position + new Vector3(575, 325), new Quaternion(0, 0, 0, 0), main.Transforms[0]);
        if (Status != null)
        {
            game.InputStatus = Status;
        }
        game.gameObject.GetComponent<RectTransform>().anchoredPosition = position;
    }

}
