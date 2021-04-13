using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UsefulMethod;

public class B_Upgrade : POPTEXT_BA
{
    ////LevelはSaveするよ
    //gold: 0 , stone:1, cristal:2 ,leaf:3 
    public int level { get { return main.S.BankUpgradeLevel[(int)thisId]; } set => main.S.BankUpgradeLevel[(int)thisId] = value; }
    public int ReputationPerUpgrade { get {
            if (IncrementReputation >= 0)
                return  (int)(IncrementReputation * (1 + main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.Sincere].GetCurrentValue()));
            else
                return IncrementReputation;
        }
    }
    public int iconOrder;
    public double initValue;
    public double initCost;
    public double bottom;
    public double plusValue;
    public Button thisButton;
    public int GetReputation;
    public int RequiredReputation;
    public enum UpgradeId
    {
        Donate,
        BankEfficiency,
        BankRate,
        BankCap,
        BankInterest, //up to here in the old version
        sEnhance,
        cEnhance,
        lEnhance,
        S_technical,
        M_technical,
        counter,
        coin,
        capture,
        nitro,
        graduate, //11 new upgrades including donation to orphans
        healthyCapture,
        potion,
        taming,
        capacity,
        powder,
        drug
    }
    public UpgradeId thisId;
    public int IncrementReputation;
    virtual public void upgrade() { }
    TextMeshProUGUI QueueText;

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
                if (assignedSuperQueue)
                    queueText = "<size=12>\n- <color=green>Super Queue </color>/ Available Queues : " + tDigit(main.queueController.SBqueue) + "\n- Ctrl-Q to remove";
                else if (main.queueController.SBqueueCap() > 0)
                    queueText = "<size=12>\n- Queued : " + tDigit(assignedQueue) + " / Available Queues : " + tDigit(main.queueController.SBqueue) + "\n- Right-Click to assign / Ctrl-Right-Click to remove";
                else
                    queueText = "";
                if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))//remove
                {
                    if (main.S.SuperQueueSB && assignedSuperQueue)
                    {
                        if (Input.GetKey(KeyCode.Q))
                        {
                            main.queueController.SBqueue += 5;
                            assignedSuperQueue = false;
                            main.queueController.SuperQueueSBSave();
                        }
                    }
                    if (!assignedSuperQueue && assignedQueue > 0)
                    {
                        if (Input.GetMouseButtonDown(1))
                        {
                            main.queueController.SBqueue += 1;
                            assignedQueue -= 1;
                        }
                    }
                }
                else
                {
                    if (!assignedSuperQueue && main.queueController.SBqueue > 0)//assign
                    {
                        if (main.S.SuperQueueSB && main.queueController.SBqueue >= 5)
                        {
                            if (Input.GetKey(KeyCode.Q))
                            {
                                AssignSuperQueue();
                                main.queueController.SuperQueueSBSave();

                            }
                        }
                        if (main.queueController.SBqueue > 0)//assign
                        {
                            if (Input.GetMouseButtonDown(1))
                            {
                                main.queueController.SBqueue -= 1;
                                assignedQueue += 1;
                            }
                        }
                    }
                }


            }

        }
    }
    public void AssignSuperQueue()
    {
        if (main.S.SuperQueueSB && main.queueController.SBqueue >= 5)
        {
            main.queueController.SBqueue -= 5;
            assignedSuperQueue = true;
            main.queueController.SBqueue += assignedQueue;
            assignedQueue = 0;
        }
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
                if (main.toggles[12].isOn)//この辺は訳あって複雑にしているので、変えないで！
                {
                    if(main.S.SlimeCoin >= main.bankCtrl.BankCap())
                    {
                        if (canBuy() && !Input.GetMouseButton(0))
                        {
                            UPGRADE.buyMode tempBuyMode = main.SR.B_buyMode;
                            assignedQueue -= 1;
                            main.SR.B_buyMode = UPGRADE.buyMode.mode1;
                            gameObject.GetComponent<Button>().onClick.Invoke();
                            main.queueController.SBqueue += 1;
                            main.SR.B_buyMode = tempBuyMode;
                        }
                    }
                }
                else
                {
                    if (canBuy() && !Input.GetMouseButton(0))
                    {
                        UPGRADE.buyMode tempBuyMode = main.SR.B_buyMode;
                        assignedQueue -= 1;
                        main.SR.B_buyMode = UPGRADE.buyMode.mode1;
                        gameObject.GetComponent<Button>().onClick.Invoke();
                        main.queueController.SBqueue += 1;
                        main.SR.B_buyMode = tempBuyMode;
                    }
                }
            }
            else if (assignedSuperQueue)
            {
                if (main.toggles[12].isOn)//この辺は訳あって複雑にしているので、変えないで！
                {
                    if (main.S.SlimeCoin >= main.bankCtrl.BankCap())
                    {
                        if (canBuy() && !Input.GetMouseButton(0))
                        {
                            UPGRADE.buyMode tempBuyMode = main.SR.B_buyMode;
                            main.SR.B_buyMode = UPGRADE.buyMode.mode1;
                            gameObject.GetComponent<Button>().onClick.Invoke();
                            main.SR.B_buyMode = tempBuyMode;
                        }
                    }
                }
                else
                {
                    if (canBuy() && !Input.GetMouseButton(0))
                    {
                        UPGRADE.buyMode tempBuyMode = main.SR.B_buyMode;
                        main.SR.B_buyMode = UPGRADE.buyMode.mode1;
                        gameObject.GetComponent<Button>().onClick.Invoke();
                        main.SR.B_buyMode = tempBuyMode;
                    }
                }
            }
            yield return new WaitForSecondsRealtime(1.0f);
        }
    }
    public int reputationCap()
    {
        return 10000;
    }
    public virtual bool canBuy()
    {
        if (main.SR.B_buyMode == UPGRADE.buyMode.modeMax)
        {
            return !(calculateMaxSumCost(level).x == 0 || calculateMaxSumCost(level).z == 0 || main.S.slimeReputation < RequiredReputation);
        }
        else
        {
            return calcurateCurrentCost() <= main.S.SlimeCoin && main.S.slimeReputation >= RequiredReputation;
        }
    }
    public double costFactor;
    public void StartUpgrade()
    {
        startText();
        costFactor = 1d-main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.SlimeKingBlessing].GetCurrentValue();//初期値０
        thisButton = gameObject.GetComponent<Button>();
        thisButton.onClick.AddListener(upgrade);
        QueueText = gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        StartCoroutine(BuyByQueue());

    }

    public double calcurateCurrentCost()
    {
        if (thisId == UpgradeId.BankCap)
        {
            tempLevel = 1 + level;
            return main.bankCtrl.BankCap() * 0.75 * (1 - costFactor) * Curse_1000gold.CostReduction();
        }

        double costArray;
        switch (main.SR.B_buyMode)
        {
            case UPGRADE.buyMode.mode1:

                tempLevel = 1 + level;
                return calculateCurrentCost(level);
            case UPGRADE.buyMode.mode10:
                tempLevel = 10 + level;
                return calculateSumCost(level, 10);
            case UPGRADE.buyMode.mode25:
                tempLevel = 25 + level;
                return calculateSumCost(level, 25);
            case UPGRADE.buyMode.modeMax:
                if (calculateMaxSumCost(level).x == 0)
                {
                    if(bottom==0)
                        costArray = calculateCurrentCost(level);
                    else
                        costArray = initCost * Math.Pow(bottom, level);
                    tempLevel = 1 + level;
                    return costArray;
                }
                tempLevel = calculateMaxSumCost(level).z + level;
                return calculateMaxSumCost(level).x;
            default:
                return 0;
        }
    }
    
    public double calculateSumCost(int currentLevel, int plusLevel)
    {
        int tempLevel = currentLevel;
        double sumCost = 0; 

        for (int i = 0; i < plusLevel; i++)
        {
            sumCost += calculateCurrentCost(tempLevel);
            tempLevel++;
        }

        return sumCost;
    }

    public virtual double calculateCurrentCost(int level)
    {
        return initCost * Math.Pow(bottom, level) * (1 - costFactor);
    }

    public (double x, int z) calculateMaxSumCost(int currentLevel)
    {
        int tempLevel = currentLevel;
        double sumCost = 0;

        while (true)
        {
            if (main.S.SlimeCoin < sumCost||(thisId == UpgradeId.Donate && main.S.slimeReputation + (tempLevel-currentLevel) * IncrementReputation > reputationCap()+IncrementReputation))
            {
                sumCost -= calculateCurrentCost(tempLevel - 1);
                return (sumCost, tempLevel - currentLevel - 1);
            }
            else
            {
                sumCost += calculateCurrentCost(tempLevel);
            }

            tempLevel++;
        }
    }

    public void calculate()
    {

        double tempX = 0;
        int tempY = 0;
        int reputationIncrement;
        if (IncrementReputation >= 0)
            reputationIncrement = (int)(IncrementReputation * (1 + main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.Sincere].GetCurrentValue()));
        else
            reputationIncrement = IncrementReputation;

        if (thisId == UpgradeId.BankCap)
        {
            main.S.SlimeCoin -= calcurateCurrentCost();
            level++;
            main.S.slimeReputation += reputationIncrement;
            return;
        }

        switch (main.SR.B_buyMode)
        {

            case UPGRADE.buyMode.mode1:
                main.S.SlimeCoin -= calcurateCurrentCost();
                level++;
                main.S.slimeReputation += reputationIncrement;
                //main.S.slimeReputation += GetReputation;
                break;
            case UPGRADE.buyMode.mode10:
                main.S.SlimeCoin -= calcurateCurrentCost();
                level += 10;
                main.S.slimeReputation += reputationIncrement * 10;
                //main.S.slimeReputation += GetReputation * 10;
                break;
            case UPGRADE.buyMode.mode25:
                main.S.SlimeCoin -= calcurateCurrentCost();
                level += 25;
                main.S.slimeReputation += reputationIncrement * 25;
               // main.S.slimeReputation += GetReputation * 25;
                break;
            case UPGRADE.buyMode.modeMax:
                (tempX, tempY) = calculateMaxSumCost(level);
                main.S.SlimeCoin -= tempX;
                level += tempY;
                main.S.slimeReputation += reputationIncrement * tempY;
               // main.S.slimeReputation += GetReputation * tempY;
                break;
            default:
                break;
        }

    }

    public virtual void AdditionalEffect()
    {

    }

    public virtual double DPS() { return 0; }
    public virtual double calculateCurrentValue()
    {

        return initValue + level * plusValue;
    }

    public virtual double calculateCurrentValue(int level)
    {

        return (initValue + level * plusValue);
    }

    public double calculateNextValue()
    {
        int tempLevel = level;

        switch (main.SR.B_buyMode)
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

    public virtual void checkButton()
    {
        if (main.SR.B_buyMode == UPGRADE.buyMode.modeMax)
        {
            if (calculateMaxSumCost(level).x == 0|| calculateMaxSumCost(level).z == 0|| main.S.slimeReputation < RequiredReputation)
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

            if (canBuy())
            {
                thisButton.interactable = true;
            }
            else
            {
                thisButton.interactable = false;
            }
        }
        //
        C_slimeCoin = "Slime Coin : " + tDigit(calcurateCurrentCost());
        //C_gold = "<sprite=\"Gold\" index=0>     " + tDigit(calcurateCurrentCost()[0]);
        //C_stone = "<sprite=1>     " + tDigit(calcurateCurrentCost()[1]);
        //C_cristal = "<sprite=2>     " + tDigit(calcurateCurrentCost()[2]);
        //C_leaf = "<sprite=3>     " + tDigit(calcurateCurrentCost()[3]);
        //currentValue = tDigit(calculateCurrentValue());
        //nextValue = tDigit(calculateNextValue());
    }

    //加算の時にはこっちを使う．
    public double TotalEffect()
    {
        if (level == 0)
            return 0;

        double effect = 0;

        for(int i = 1; i < level + 1; i++)
        {
            effect += calculateCurrentValue(i);
        }

        return effect;
    }

    public double TotalEffect(int level)
    {
        if (level == 0)
            return 0;

        double effect = 0;

        for (int i = 1; i < level + 1; i++)
        {
            effect += calculateCurrentValue(i);
        }

        return effect;
    }


    public double calculateNextValueTotal()
    {
        int tempLevel = level;

        switch (main.SR.B_buyMode)
        {

            case UPGRADE.buyMode.mode1:
                tempLevel++;
                double ans = TotalEffect(tempLevel);
                return ans;
            case UPGRADE.buyMode.mode10:
                tempLevel += 10;
                double ans10 = TotalEffect(tempLevel);
                return ans10;
            case UPGRADE.buyMode.mode25:
                tempLevel += 25;
                double ans25 = TotalEffect(tempLevel);
                return ans25;
            case UPGRADE.buyMode.modeMax:
                tempLevel += calculateMaxSumCost(level).z;
                double ansMax = TotalEffect(tempLevel);
                return ansMax;
            default:
                return 0;
        }

    }

    public string percent(double d)
    {
        return tDigit((d) * 100, 2) + "%";
    }
}
