using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static System.Math;
using static UsefulMethod;

public class A_UPGRADE : POPTEXT_JOB
{
    //LevelはSaveするよ
    //public int level { get => main.S.A_level[upgradeId]; set => main.S.A_level[upgradeId] = value; }
    //[NonSerialized]
    public int upgradeId;
    [NonSerialized]
    public int tempLevel;
    public double initValue;
    public double initCost;
    public double plusValue;
    public double bottom;
    public bool isLinear;
    public calWay cal;
    public ALLY.Job job;
    public enum calWay
    {
        exp,
        fib,
    }

    private void Awake()
    {
        StartBASE(); 
    }

    Button thisButton;

    public void Start()
    {
        thisButton = gameObject.GetComponent<Button>();
        thisButton.onClick.AddListener(calculate);
        startText();
        tempLevel = main.S.A_level[upgradeId];
    }

    public long calculateCurrentCost()
    {
        if (cal == calWay.exp)
        {
            if (initCost == 0)
            {
                return (long)(Math.Min(1, tempLevel) * Math.Pow(bottom, tempLevel) * main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.PrestigeBargain].GetCurrentValue());
            }
            else
            {
                return (long)(initCost * Math.Pow(bottom, tempLevel) * main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.PrestigeBargain].GetCurrentValue());
            }
        }
        else
        {
            return (long)(fibonacci(tempLevel + 2) * main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.PrestigeBargain].GetCurrentValue());
        }
    }
    public void calculate()
    {
       switch (job)
       {
           case ALLY.Job.Warrior:
               main.tempWarP -= calculateCurrentCost();
               break;
           case ALLY.Job.Wizard:
               main.tempWizP -= calculateCurrentCost();
               break;
           case ALLY.Job.Angel:
               main.tempAngP -= calculateCurrentCost();
               break;
            case ALLY.Job.all:
                main.tempWarP -= calculateCurrentCost();
                main.tempWizP -= calculateCurrentCost();
                main.tempAngP -= calculateCurrentCost();
                break;
            default:
               break;
       }
        //resources -= calculateCurrentCost();
        tempLevel++;
    }

    public double calculateCurrentValueTemp()
    {
        if (isLinear)
        {
            if (upgradeId==1 || upgradeId==6 || upgradeId == 11)
            {
                if(initValue + tempLevel * (plusValue) == 0)
                {
                    return 1;
                }
                else
                {
                    return (initValue + tempLevel * (plusValue));
                }
            }
            else
            {
                return (initValue + tempLevel * (plusValue));
            }
        }
        else
        {
            //プロフィシェんしーx10の効果を入れる。
            if (upgradeId == 14 && main.cc.Curses[(int)CurseId.curse_of_proficiency - 1].ClearNum >= 1)
                return ((initValue * Pow(plusValue, tempLevel)) - 1) * 10;
            return (initValue * Pow(plusValue, tempLevel))-1;
        }
    }

    //実際に値を使うときはTempじゃないほうを　使う．
    public double calculateCurrentValue()   
    {
        if (isLinear)
        {
            if (upgradeId == 1 || upgradeId == 6 || upgradeId == 11)
            {

                if (initValue + main.S.A_level[upgradeId] * (plusValue) == 0)
                {
                    return 1;
                }
                else
                {
                    return (initValue + main.S.A_level[upgradeId] * (plusValue));
                }
            }
            else
            {
                return initValue + main.S.A_level[upgradeId] * plusValue;
            }
        }
        else
        {
            //プロフィシェんしーx10の効果を入れる。
            if (upgradeId == 14 && main.cc.Curses[(int)CurseId.curse_of_proficiency-1].ClearNum >= 1)
                return ((initValue * Pow(plusValue, main.S.A_level[upgradeId])) - 1) * 10;
            return (initValue * Pow(plusValue, main.S.A_level[upgradeId]))-1;
        }
    }
    public double calculateNextValueTemp()
    {
        tempLevel++;
        double ans = calculateCurrentValueTemp();
        tempLevel--;
        return ans;
    }
    public double calculateNextSub()
    {
        return calculateNextValueTemp() - calculateCurrentValueTemp();
    }

    public void Update()
    {
        if (main.GameController.currentCanvas == main.GameController.JobchangeCanvas)
        {
            switch (job)
            {
                case ALLY.Job.Warrior:
                    if (calculateCurrentCost() > main.tempWarP)
                    {
                        thisButton.interactable = false;
                    }
                    else
                    {
                        thisButton.interactable = true;
                    }
                    break;
                case ALLY.Job.Wizard:
                    if (calculateCurrentCost() > main.tempWizP)
                    {
                        thisButton.interactable = false;
                    }
                    else
                    {
                        thisButton.interactable = true;
                    }
                    break;
                case ALLY.Job.Angel:
                    if (calculateCurrentCost() > main.tempAngP)
                    {
                        thisButton.interactable = false;
                    }
                    else
                    {
                        thisButton.interactable = true;
                    }
                    break;
                case ALLY.Job.all:
                    if (calculateCurrentCost() > main.tempWarP || calculateCurrentCost() > main.tempWizP || calculateCurrentCost() > main.tempAngP)
                    {
                        thisButton.interactable = false;
                    }
                    else
                    {
                        thisButton.interactable = true;
                    }
                    break;
                default:
                    break;
            }

            //if (upgradeId == 15)
            //{
            //    if(tempLevel >= 3)
            //        thisButton.interactable = false;
            //    else
            //        thisButton.interactable = true;
            //}


            if (window.activeSelf)
            {
                updateText();
                //テキストの更新
                Level = tDigit(tempLevel);
                if (isLinear)
                {
                    if (upgradeId == 15)
                    {
                        //if(tempLevel >= 3)
                        //{
                        //    currentEffect = " " + tDigit(calculateCurrentValueTemp());
                        //    nextEffect = " No more upgrade";
                        //    setFalse(window.transform.GetChild(4).gameObject);
                        //    setFalse(window.transform.GetChild(5).gameObject);
                        //}
                        //else
                        //{
                            currentEffect = " " + tDigit(calculateCurrentValueTemp());
                            nextEffect = " " + tDigit(calculateNextValueTemp());
                        //}
                    }
                    else if (upgradeId == 16)
                    {
                        currentEffect = " " + tDigit(calculateCurrentValueTemp());
                        nextEffect = " " + tDigit(calculateNextValueTemp());
                    }
                    else
                    {
                        currentEffect = " * " + tDigit(calculateCurrentValueTemp());
                        nextEffect = " * " + tDigit(calculateNextValueTemp());
                    }
                }
                else
                {
                    currentEffect = " + " + percent(calculateCurrentValueTemp());
                    nextEffect = " + " + percent(calculateNextValueTemp());
                }

                switch (job)
                {
                    case ALLY.Job.Warrior:
                        if (main.tempWarP >= calculateCurrentCost())
                        {
                            cost = "- Warrior Point : <color=green>" + tDigit(calculateCurrentCost());
                        }
                        else
                        {
                            cost = "- Warrior Point : <color=red>" + tDigit(calculateCurrentCost());
                        }
                        break;
                    case ALLY.Job.Wizard:
                        if (main.tempWizP >= calculateCurrentCost())
                        {
                            cost = "- Wizard Point : <color=green>" + tDigit(calculateCurrentCost());
                        }
                        else
                        {
                            cost = "- Wizard Point : <color=red>" + tDigit(calculateCurrentCost());
                        }
                        break;
                    case ALLY.Job.Angel:
                        if (main.tempAngP >= calculateCurrentCost())
                        {
                            cost = "- Angel Point : <color=green>" + tDigit(calculateCurrentCost());
                        }
                        else
                        {
                            cost = "- Angel Point : <color=red>" + tDigit(calculateCurrentCost());
                        }
                        break;
                    case ALLY.Job.all:
                        cost = "";
                        if (main.tempWarP >= calculateCurrentCost())
                        {
                            cost += "- Warrior Point : <color=green>" + tDigit(calculateCurrentCost());
                        }
                        else
                        {
                            cost += "- Warrior Point : <color=red>" + tDigit(calculateCurrentCost());
                        }

                        if (main.tempWizP >= calculateCurrentCost())
                        {
                            cost += "\n</color>- Wizard Point : <color=green>" + tDigit(calculateCurrentCost());
                        }
                        else
                        {
                            cost += "\n</color>- Wizard Point : <color=red>" + tDigit(calculateCurrentCost());
                        }
                        if (main.tempAngP >= calculateCurrentCost())
                        {
                            cost += "\n</color>- Angel Point : <color=green>" + tDigit(calculateCurrentCost());
                        }
                        else
                        {
                            cost += "\n</color>- Angel Point : <color=red>" + tDigit(calculateCurrentCost());
                        }

                        break;
                }

            }

        }
    }

    public double fibonacci(int n)
    {
        double factor = 1 / Sqrt(5);
        double phi = (1 + Sqrt(5)) / 2;
        double phi2 = (1 - Sqrt(5)) / 2;

        return factor * (Pow(phi, n) - Pow(phi2, n));
    }

    public string percent(double d)
    {
        return tDigit((d) * 100,2) + "%";
    }
}
