using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class UPGRADE : POPTEXT_PU
{
    //LevelはSaveするよ
    public virtual int level { get; set; }
    public int[][] upgradeId;
    public double initValue;
    public double initCost;
    public double plusValue;
    public double bottom;
    public enum buyMode
    {
        //nothing,
        mode1,
        mode10,
        mode25,
        modeMax
    }
    Button thisButton;

    public void startUpgrade()
    {
       // this.initValue = initValue;
       // this.initCost = initCost;
       // this.bottom = bottom;
       // plusValue = plus;
        thisButton = gameObject.GetComponent<Button>();
        gameObject.GetComponent<Button>().onClick.AddListener(upgrade);
        StartCoroutine(Effect());
    }
    virtual public void upgrade() { }
    public virtual double DPS() { return 0; }
    public double calculateCurrentCost()
    {
        switch (main.SR.buyMode) {

            case buyMode.mode1:
            return initCost * Math.Pow(bottom, level);
            case buyMode.mode10:
                return calculateSumCost(level, 10);
            case buyMode.mode25:
                return calculateSumCost(level, 25);
            case buyMode.modeMax:
                return calculateMaxSumCost(level).x ==0? initCost * Math.Pow(bottom, main.idleBackGround.TotalUpgradeLevel())
                    : calculateMaxSumCost(level).x;
            default:
                return 0;
        }
    }
    public double calculateCurrentCost(int level)
    {
        return initCost * Math.Pow(bottom, level);
    }
    public double calculateSumCost(int currentLevel, int plusLevel)
    {
        int tempLevel = currentLevel;
        double sumCost=0;

        for(int i=0; i<plusLevel; i++)
        {
            sumCost += calculateCurrentCost(tempLevel);
            tempLevel++;
        }

        return sumCost;
    }
    public virtual (double x, int y) calculateMaxSumCost(int currentLevel)
    {
        int tempLevel = currentLevel;
        double sumCost = 0;

        while (true)
        {
            if (main.SR.gold < sumCost)
            {
                sumCost -= calculateCurrentCost(tempLevel-1);
                return (sumCost, tempLevel-1 - currentLevel);
            }
            else
            {
                sumCost += calculateCurrentCost(tempLevel);
            }

            tempLevel++;
        }
    }
    public void calculate(ref double resources)
    {
        // resources -= calcurateCurrentCost();
        // level++;
        double tempX=0;
        int tempY=0;

        switch (main.SR.buyMode)
        {

            case buyMode.mode1:
                resources -= calculateCurrentCost();
                level++;
                break;
            case buyMode.mode10:
                resources -= calculateCurrentCost();
                level+=10;
                break;
            case buyMode.mode25:
                resources -= calculateCurrentCost();
                level += 25;
                break;
            case buyMode.modeMax:
                (tempX, tempY) = calculateMaxSumCost(level);
                resources -= tempX;
                level += tempY;
                break;
            default:
                break;
        }
    }
    public virtual double calculateCurrentValue()
    {
        return initValue + level * plusValue;
    }
    public virtual double calculateCurrentValue(int level)
    {
        return initValue + level * plusValue;
    }
    public double calculateNextValue()
    {
      int tempLevel = level;
      switch (main.SR.buyMode)
        {

            case buyMode.mode1:
                tempLevel++;
                double ans = calculateCurrentValue(tempLevel);
                //level--;
                return ans;
            case buyMode.mode10:
                tempLevel+=10;
                double ans10 = calculateCurrentValue(tempLevel);
                //level-=10;
                return ans10;
            case buyMode.mode25:
                tempLevel+=25;
                double ans25 = calculateCurrentValue(tempLevel);
                //level-=25;
                return ans25;
            case buyMode.modeMax:
                tempLevel+=calculateMaxSumCost(level).y;
                double ansMax = calculateCurrentValue(tempLevel);
                //tempLevel-= calculateMaxSumCost(level).y;
                return ansMax;
            default:
                return 0;
        }

    }
    public double calculateNextSub()
    {
        return calculateNextValue() - calculateCurrentValue();
    }
    //updateで呼ぶ
    public void updateUpgrade(double Resources)
    {
        if (main.SR.buyMode == buyMode.modeMax)
        {
            if (calculateMaxSumCost(level).x == 0)
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
            if (calculateCurrentCost() > Resources)
            {
               thisButton.interactable = false;
            }
            else
            {
               thisButton.interactable = true;
            }
        }
       // currentValue = tDigit(calculateCurrentValue());
       // nextValue = tDigit(calculateNextValue());

    }
    public virtual IEnumerator Effect() { yield return null; }
}
