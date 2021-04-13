using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;
using static UsefulMethod;

public class M_UPGRADE : POPTEXT_UG
{
    ////LevelはSaveするよ
    //gold: 0 , stone:1, cristal:2 ,leaf:3 
    public virtual int level { get; set; }
    protected int[][] upgradeId;
    public double initValue;
    public double[] initCost = new double[4];
    public double[] bottom = new double[4];
    public bool[] isUsed = new bool[4];
    double[] costArray = new double[4];
    public double plusValue;
    public long MaxLevel = 100000;
    Button thisButton;
    public Attribute thisAttribute;
    public enum Attribute
    {
        stone,
        crystal,
        leaf,
        status
    }
    TextMeshProUGUI QueueText;


    public void awake()
    {
        // startText();
    }
    virtual public void upgrade() { }

    //public long BuffedLevel()
    //{
    //    if (main.angelSkillAry[12].IsEquipped())
    //        return level + (long)main.angelSkillAry[12].Damage();
    //    else
    //        return level;
    //}
    //public long BuffedLevelStatus()
    //{
    //    if (main.angelSkillAry[12].IsEquipped())
    //        return level + (long)main.angelSkillAry[12].Damage();
    //    else
    //        return level;
    //}

    // Start is called before the first frame update
    public void UpdateUpgrade()
    {
        updateText();
        if (main.GameController.currentCanvas == main.GameController.IdleCanvas)
        {
            if (assignedQueue > 0 || assignedSuperQueue)
            {
                setActive(QueueText.gameObject);
                if (assignedSuperQueue)
                    QueueText.text = "<color=green>Q";
                else
                    QueueText.text = "<color=green>" + assignedQueue;
            }
            else
                setFalse(QueueText.gameObject);


            if (window.activeSelf)
            {
                if (!isUsed[0])
                {
                    window.transform.GetChild(6).gameObject.SetActive(false);
                }
                if (!isUsed[1])
                {
                    window.transform.GetChild(7).gameObject.SetActive(false);
                }
                if (!isUsed[2])
                {
                    window.transform.GetChild(8).gameObject.SetActive(false);
                }
                if (!isUsed[3])
                {
                    window.transform.GetChild(9).gameObject.SetActive(false);
                }
            }

            if (window.activeSelf && !isLottery)//Queueに関する処理
            {
                if (assignedSuperQueue)
                    queueText = "<size=12>\n- <color=green>Super Queue </color>/ Available Queues : " + tDigit(main.queueController.queue) + "\n- Ctrl-Q to remove";
                else if (main.queueController.queueCap() > 0)
                    queueText = "<size=12>\n- Queued : " + tDigit(assignedQueue) + " / Available Queues : " + tDigit(main.queueController.queue) + "\n- Right-Click to assign / Ctrl-Right-Click to remove";
                else
                    queueText = "";
                if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))//remove
                {
                    if (main.S.SuperQueue && assignedSuperQueue)
                    {
                        if (Input.GetKey(KeyCode.Q))
                        {
                            main.queueController.queue += 5;
                            assignedSuperQueue = false;
                            main.queueController.SuperQueueSave();
                        }
                    }
                    if (!assignedSuperQueue && assignedQueue > 0)
                    {
                        if (Input.GetMouseButtonDown(1))
                        {
                            main.queueController.queue += 1;
                            assignedQueue -= 1;
                        }
                    }
                }
                else
                {
                    if (!assignedSuperQueue && main.queueController.queue > 0)//assign
                    {
                        if (main.S.SuperQueue && main.queueController.queue >= 5)
                        {
                            if (Input.GetKey(KeyCode.Q))
                            {
                                AssignSuperQueue();
                                main.queueController.SuperQueueSave();
                            }
                        }
                        if (Input.GetMouseButtonDown(1))
                        {
                            main.queueController.queue -= 1;
                            assignedQueue += 1;
                        }
                    }
                }

            }
        }

    }
    public void AssignSuperQueue()
    {
        if (main.S.SuperQueue && main.queueController.queue >= 5)
        {
            main.queueController.queue -= 5;
            assignedSuperQueue = true;
            main.queueController.queue += assignedQueue;
            assignedQueue = 0;
        }
    }


    public void StartUpgrade()
    {
        startText();
        for (int i = 0; i < 4; i++)
        {
            initCost[i] *= main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.LoyalBargain].GetCurrentValue();
        }
        thisButton = gameObject.GetComponent<Button>();
        thisButton.onClick.AddListener(upgrade);
        StartCoroutine(BuyByQueue());
        QueueText = gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
       // StartCoroutine(Effect());
    }

    public int assignedQueue;
    public bool assignedSuperQueue;

    public virtual IEnumerator BuyByQueue()
    {
        while (true)
        {
            yield return new WaitUntil(() => assignedQueue > 0 || assignedSuperQueue);
            if (assignedQueue > 0)
            {
                if (canBuy()&&!Input.GetMouseButton(0))
                {
                    UPGRADE.buyMode tempBuyMode = main.SR.buyMode;
                    assignedQueue -= 1;
                    main.SR.buyMode = UPGRADE.buyMode.mode1;
                    gameObject.GetComponent<Button>().onClick.Invoke();
                    main.queueController.queue += 1;
                    main.SR.buyMode = tempBuyMode;
                }
            }
            else if(assignedSuperQueue)
            {
                if (canBuy() && !Input.GetMouseButton(0))
                {
                    UPGRADE.buyMode tempBuyMode = main.SR.buyMode;
                    main.SR.buyMode = UPGRADE.buyMode.mode1;
                    gameObject.GetComponent<Button>().onClick.Invoke();
                    main.SR.buyMode = tempBuyMode;
                }
            }
            yield return new WaitForSecondsRealtime(1.0f);
        }
    }

    public virtual IEnumerator Effect() { yield return null; }

   public virtual double[] calcurateCurrentCost()
   {
       switch (main.SR.buyMode)
       {
           case UPGRADE.buyMode.mode1:
                for (int i = 0; i < 4; i++)
                {
                    if (isUsed[i])
                    {
                        costArray[i] = initCost[i] * Math.Pow(bottom[i], level);
                    }
                }
                tempLevel = 1 + level;
                return costArray;
           case UPGRADE.buyMode.mode10:
                if (10 + level > MaxLevel)
                {
                    tempLevel = MaxLevel;
                }
                else
                {
                    tempLevel = 10 + level;
                }
                return calculateSumCost(level, 10);
           case UPGRADE.buyMode.mode25:
                if (25 + level > MaxLevel)
                {
                    tempLevel = MaxLevel;
                }
                else
                {
                    tempLevel = 25 + level;
                }
                return calculateSumCost(level, 25);
           case UPGRADE.buyMode.modeMax:
                for (int i = 0; i < 4; i++)
                {
                    if (isUsed[i])
                    {
                        costArray[i] = initCost[i] * Math.Pow(bottom[i], level);
                    }
                }
                if(isUsed[0]&&calculateMaxSumCost(level).x[0] ==0 ||
                   isUsed[1] && calculateMaxSumCost(level).x[1] == 0||
                   isUsed[2] && calculateMaxSumCost(level).x[2] == 0||
                   isUsed[3] && calculateMaxSumCost(level).x[3] == 0)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (isUsed[i])
                        {
                            costArray[i] = initCost[i] * Math.Pow(bottom[i], level);
                        }
                    }
                    tempLevel = 1 + level;
                    return costArray;
                }
                    tempLevel = calculateMaxSumCost(level).z + level;
                return calculateMaxSumCost(level).x;
            default:
               return null;
       }
   }

    public double[] calculateSumCost(int currentLevel, int plusLevel)
    {
        int tempLevel = currentLevel;
        double[] sumCost = new double[4];

        for (int i = 0; i < plusLevel; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                sumCost[j] += calculateCurrentCost(tempLevel)[j];
            }
            tempLevel++;
        }

        return sumCost;
    }

    public double[] calculateCurrentCost(int level)
    {
        for (int i = 0; i < 4; i++)
        {
            costArray[i] = initCost[i] * Math.Pow(bottom[i], level);
        }
        return costArray;
    }

    public (double[] x, int z) calculateMaxSumCost(int currentLevel)
    {
        int tempLevel = currentLevel;
        double[] sumCost = new double[4] { 0, 0,0,0 };

        while (true)
        {
            if (main.SR.gold < sumCost[0] || main.SR.stone < sumCost[1] || main.SR.cristal < sumCost[2] || main.SR.leaf < sumCost[3]||tempLevel>MaxLevel)
            {
                if (main.SR.gold < sumCost[0])
                {
                    sumCost[0] -= calculateCurrentCost(tempLevel - 1)[0];
                }

                if (main.SR.stone < sumCost[1])
                {
                    sumCost[1] -= calculateCurrentCost(tempLevel - 1)[1];
                }

                if (main.SR.cristal < sumCost[2])
                {
                    sumCost[2] -= calculateCurrentCost(tempLevel - 1)[2];
                }

                if (main.SR.leaf < sumCost[3])
                {
                    sumCost[3] -= calculateCurrentCost(tempLevel - 1)[3];
                }

                return (sumCost, tempLevel - currentLevel - 1);
            }
            else
            {
                for (int i = 0; i < 4; i++) 
                {
                    sumCost[i] += calculateCurrentCost(tempLevel)[i];
                }
            }

            tempLevel++;
        }
    }

    public virtual void AdditionalEffect() { }

    public void calculate()
    {

        double[] tempX = new double[4];
        int tempY = 0;

        switch (main.SR.buyMode)
        {

            case UPGRADE.buyMode.mode1:
                main.SR.gold -= isUsed[0] ? calcurateCurrentCost()[0] : 0;
                main.SR.stone -= isUsed[1] ? calcurateCurrentCost()[1] : 0;
                main.SR.cristal -= isUsed[2] ? calcurateCurrentCost()[2] : 0;
                main.SR.leaf -= isUsed[3] ? calcurateCurrentCost()[3] : 0;
                level++;
                break;
            case UPGRADE.buyMode.mode10:
                main.SR.gold -= isUsed[0] ? calcurateCurrentCost()[0] : 0;
                main.SR.stone -= isUsed[1] ? calcurateCurrentCost()[1] : 0;
                main.SR.cristal -= isUsed[2] ? calcurateCurrentCost()[2] : 0;
                main.SR.leaf -= isUsed[3] ? calcurateCurrentCost()[3] : 0;
                level+=10;
                break;
            case UPGRADE.buyMode.mode25:
                main.SR.gold -= isUsed[0] ? calcurateCurrentCost()[0] : 0;
                main.SR.stone -= isUsed[1] ? calcurateCurrentCost()[1] : 0;
                main.SR.cristal -= isUsed[2] ? calcurateCurrentCost()[2] : 0;
                main.SR.leaf -= isUsed[3] ? calcurateCurrentCost()[3] : 0;
                level+=25;
                break;
            case UPGRADE.buyMode.modeMax:
                (tempX, tempY) = calculateMaxSumCost(level);
                main.SR.gold -= isUsed[0] ? tempX[0] : 0;
                main.SR.stone -= isUsed[1] ? tempX[1] : 0;
                main.SR.cristal -= isUsed[2] ? tempX[2] : 0;
                main.SR.leaf -= isUsed[3] ? tempX[3] : 0;
                level += tempY;
                break;
            default:
                break;
        }

        AdditionalEffect();
    }

    public virtual double DPS() { return 0; }
    public double CalculateTotalNextDPS(M_UPGRADE[] upgrades)
    {
        int tempLevel = level;
        double ans = 0;
        double dps = 0;
        switch (main.SR.buyMode)
        {

            case UPGRADE.buyMode.mode1:
                tempLevel++;
                ans = calculateCurrentValue(tempLevel);
                break;
            case UPGRADE.buyMode.mode10:
                tempLevel += 10;
                ans = calculateCurrentValue(tempLevel);
                break;
            case UPGRADE.buyMode.mode25:
                tempLevel += 25;
                ans = calculateCurrentValue(tempLevel);
                break;
            case UPGRADE.buyMode.modeMax:
                tempLevel += calculateMaxSumCost(level).z;
                ans = calculateCurrentValue(tempLevel);
                break;
            default:
                break;
        }

        foreach(M_UPGRADE upgrade in upgrades)
        {
            if(upgrade == this)
            {
                dps += ans;
            }   
            else
            {
                dps += upgrade.DPS();
            }
        }

        return dps;
    }

    public virtual double calculateCurrentValue()
    {

        return initValue + level * plusValue;
    }

    public virtual double calculateCurrentValue(int level)
    {

        return initValue + level * plusValue;
    }

    public virtual double  calculateNextValue()
    {
        int tempLevel = level;

        switch (main.SR.buyMode)
        {

            case UPGRADE.buyMode.mode1:
                tempLevel++;
                double ans = calculateCurrentValue(tempLevel);
                return ans;
            case UPGRADE.buyMode.mode10:
                tempLevel += 10;
                double ans10 = calculateCurrentValue(tempLevel);
                return ans10;
            case UPGRADE.buyMode.mode25:
                tempLevel += 25;
                double ans25 = calculateCurrentValue(tempLevel);
                return ans25;
            case UPGRADE.buyMode.modeMax:
                tempLevel += calculateMaxSumCost(level).z;
                double ansMax = calculateCurrentValue(tempLevel);
                return ansMax;
            default:
                return 0;
        }

    }

    public double calculateNextSub()
    {
        return calculateNextValue() - calculateCurrentValue();
    }

    public bool MaxLimit()
    {
        return isUsed[0] && calculateMaxSumCost(level).x[0] == 0
            || isUsed[1] && calculateMaxSumCost(level).x[1] == 0
            || isUsed[2] && calculateMaxSumCost(level).x[2] == 0
            || isUsed[3] && calculateMaxSumCost(level).x[3] == 0;
    }

    public void checkButton()
    {
        if (main.SR.buyMode == UPGRADE.buyMode.modeMax)
        {
            if (MaxLimit() || calculateMaxSumCost(level).z == 0)//||level >= MaxLevel)
            {
                thisButton.interactable = false;
            }
            else
            {
                thisButton.interactable = true;
            }
        }
        else
        {

            if (calcurateCurrentCost()[0] > main.SR.gold || calcurateCurrentCost()[1] > main.SR.stone || calcurateCurrentCost()[2]>main.SR.cristal
                ||calcurateCurrentCost()[3]>main.SR.leaf)//||level>=MaxLevel)
            {
                thisButton.interactable = false;
            }
            else
            {
                thisButton.interactable = true;
            }   
        }

        if (window.activeSelf)
        {
            C_gold = "<sprite=0>     " + tDigit(calcurateCurrentCost()[0]);
            C_stone = "<sprite=1>     " + tDigit(calcurateCurrentCost()[1]);
            C_cristal = "<sprite=2>     " + tDigit(calcurateCurrentCost()[2]);
            C_leaf = "<sprite=3>     " + tDigit(calcurateCurrentCost()[3]);
        }
        //currentValue = tDigit(calculateCurrentValue());
        //nextValue = tDigit(calculateNextValue());
    }

    public bool canBuy()
    {
        if (calculateNextValue() > 1e305)
            return false;
        if (main.SR.buyMode == UPGRADE.buyMode.modeMax)
        {
            return !(MaxLimit() || calculateMaxSumCost(level).z == 0);
        }
        else
        {
            return !(calcurateCurrentCost()[0] > main.SR.gold || calcurateCurrentCost()[1] > main.SR.stone || calcurateCurrentCost()[2] > main.SR.cristal
                    || calcurateCurrentCost()[3] > main.SR.leaf || level >= MaxLevel);
        }
    }

    public string percent(double d)
    {
        return tDigit((d - 1) * 100, 2) + " % ";
    }
}
