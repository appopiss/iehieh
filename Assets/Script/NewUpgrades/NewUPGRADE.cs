using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;

public class NewUPGRADE : POPTEXT_UG
{
    ////LevelはSaveするよ
    //gold: 0 , stone:1, cristal:2 ,leaf:
    public virtual int level { get; set; }
    public virtual int S_level { get; set; }
    protected int[][] upgradeId;
    public double initValue;
    public double[] initCost = new double[4];
    public double[] bottom = new double[4];
    public bool[] isUsed = new bool[4];
    double[] costArray = new double[4];
    public double plusValue;
    public double factor;
    Button thisButton;
    Slider thisSlider;
    [NonSerialized]
    public TextMeshProUGUI thisText;


    public void awake()
    {
        // startText();
    }
    virtual public void upgrade() { }

    // Start is called before the first frame update
    public void UpdateUpgrade()
    {
        updateText();
    }

    public void StartUpgrade()
    {
        startText();
        thisButton = gameObject.transform.GetChild(0).GetComponent<Button>();
        thisSlider = gameObject.transform.GetChild(1).GetComponent<Slider>();
        thisButton.onClick.AddListener(calculate);
        thisText = gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        StartCoroutine(Effect());
        StartCoroutine(StartSlider());
    }

    public virtual IEnumerator Effect() { yield return null; }
    public virtual void SliderAction() { }
    public virtual double SliderFactor() { return 1.0; }
    public virtual double PlusValue() { return 0; }

    //CalculateCurrentValueが1だったら，1秒間に1増える処理をする．フレームは0.05fで．つまりは，value * 0.05fをやる．
    public IEnumerator StartSlider()
    {
        while (true)
        {
            yield return new WaitUntil(() => calculateCurrentValue() > 0);
            while(thisSlider.value <1)  
            {
                thisSlider.value += (float)(calculateCurrentValue() * 0.05f);
                yield return new WaitForSeconds(0.05f);
                if(thisSlider.value >= 1)
                {
                    SliderAction();
                    S_level++;
                    thisSlider.value = 0;
                }
            }
        }
    }

    public double[] calcurateCurrentCost()
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
                tempLevel = 10 + level;
                return calculateSumCost(level, 10);
            case UPGRADE.buyMode.mode25:
                tempLevel = 25 + level;
                return calculateSumCost(level, 25);
            case UPGRADE.buyMode.modeMax:
                for (int i = 0; i < 4; i++)
                {
                    if (isUsed[i])
                    {
                        costArray[i] = initCost[i] * Math.Pow(bottom[i], level);
                    }
                }
                tempLevel = calculateMaxSumCost(level).z + level;
                //return calculateMaxSumCost(level).x[0] == 0 || calculateMaxSumCost(level).x[1] == 0 ?
                //   costArray : calculateMaxSumCost(level).x;
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
        double[] sumCost = new double[4] { 0, 0, 0, 0 };

        while (true)
        {
            if (main.SR.gold < sumCost[0] || main.SR.stone < sumCost[1] || main.SR.cristal < sumCost[2] || main.SR.leaf < sumCost[3])
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
                level += 10;
                break;
            case UPGRADE.buyMode.mode25:
                main.SR.gold -= isUsed[0] ? calcurateCurrentCost()[0] : 0;
                main.SR.stone -= isUsed[1] ? calcurateCurrentCost()[1] : 0;
                main.SR.cristal -= isUsed[2] ? calcurateCurrentCost()[2] : 0;
                main.SR.leaf -= isUsed[3] ? calcurateCurrentCost()[3] : 0;
                level += 25;
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
    }

    public virtual double DPS() { return 0; }

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
            if (MaxLimit() || calculateMaxSumCost(level).z == 0)
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

            if (calcurateCurrentCost()[0] > main.SR.gold || calcurateCurrentCost()[1] > main.SR.stone || calcurateCurrentCost()[2] > main.SR.cristal
                || calcurateCurrentCost()[3] > main.SR.leaf)
            {
                thisButton.interactable = false;
            }
            else
            {
                thisButton.interactable = true;
            }
        }

        C_gold = "<sprite=0>     " + tDigit(calcurateCurrentCost()[0]);
        C_stone = "<sprite=1>     " + tDigit(calcurateCurrentCost()[1]);
        C_cristal = "<sprite=2>     " + tDigit(calcurateCurrentCost()[2]);
        C_leaf = "<sprite=3>     " + tDigit(calcurateCurrentCost()[3]);
        thisButton.gameObject.GetComponent<Image>().sprite = upgradeIcon.sprite;
        //currentValue = tDigit(calculateCurrentValue());
        //nextValue = tDigit(calculateNextValue());
    }

    public string percent(double d)
    {
        return tDigit((d - 1) * 100, 2) + " % ";
    }
}
