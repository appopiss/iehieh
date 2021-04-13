using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static System.Math;
using static UsefulMethod;

public class R_UPGRADE : POPTEXT_JOB
{
    //LevelはSaveするよ
    //public int level
    //{
    //    get
    //    {
    //        if (isMainUpgrade)
    //            return main.S.R_level[(int)R_thisId];
    //        else
    //            return main.S.SR_level[(int)SR_thisId];
    //    }

    //}
    //[NonSerialized]
    [NonSerialized]
    public int tempLevel;
    public int maxLevel = 99999;
    public bool isMainUpgrade;
    public double GetCurrentValue()
    {
        if (isMainUpgrade)
            return CurrentValue(main.S.R_level[(int)R_thisId]);
        else
            return CurrentValue(main.S.SR_level[(int)SR_thisId]);
    }
    Func<int, double> CurrentValue = (x) => 0;//(level) => 0;
    Func<int, long> CurrentCost = (x) => 0; // (level) => 0;
    Func<int,string> CurrentText = (x) => "";
    Func<string> NextText = () => "";
    UNLOCK unlock;
    private void Awake()
    {
        StartBASE();
        SetUpgrade();
    }

    void SetUpgrade()
    {
        if (isMainUpgrade)
        {
            switch (R_thisId)
            {
                case R_upgradeId.NewWarrior:
                    Name = "New Warrior Skill";//"<color=red>Under Construction</color>";
                    Explain = "Unleash one new Warrior Skill.";//"<color=red>Under Construction</color>";//"Unlash a new Warrior skill.";
                    CurrentCost = (x) => 1+x;
                    CurrentValue = (x) => x;
                    CurrentText = (x) => "Unleash the " + ToOrdinal((int)CurrentValue(x)) + " New Warrior Skill";
                    NextText = () =>
                    {
                        if (tempLevel >= 4)
                            return "Coming Soon!";
                        else
                            return CurrentText(tempLevel + 1);
                    };
                    maxLevel = 4;
                    break;
                case R_upgradeId.NewWizard:
                    Name = "New Wizard Skill";//"<color=red>Under Construction</color>";
                    Explain = "Unleash one new Wizard Skill.";//"<color=red>Under Construction</color>";//"Unlash a new Warrior skill.";
                    CurrentCost = (x) => 1+x;
                    CurrentValue = (x) => x;
                    CurrentText = (x) => "Unleash the " + ToOrdinal((int)CurrentValue(x)) + " New Wizard Skill";
                    NextText = () =>
                    {
                        if (tempLevel >= 4)
                            return "Coming Soon!";
                        else
                            return CurrentText(tempLevel + 1);
                    };
                    maxLevel = 4;
                    break;
                case R_upgradeId.NewAngel:
                    Name = "New Angel Skill";//"<color=red>Under Construction</color>";
                    Explain = "Unleash one new Angel Skill.";//"<color=red>Under Construction</color>";//"Unlash a new Warrior skill.";
                    CurrentCost = (x) => 1+x;
                    CurrentValue = (x) => x;
                    CurrentText = (x) => "Unleash the " + ToOrdinal((int)CurrentValue(x)) + " New Angel Skill";
                    NextText = () =>
                    {
                        if (tempLevel >= 4)
                            return "Coming Soon!";
                        else
                            return CurrentText(tempLevel + 1);
                    };
                    maxLevel = 4;
                    break;
                case R_upgradeId.SpiritEssenceMore:
                    Name = "Essential Knowledge";
                    Explain = "Increase Spirit Essence Gain";
                    CurrentCost = (x) => 1;
                    CurrentValue = (x) => 0.1d * x;
                    CurrentText = (x) => "+ " + percent(CurrentValue(x));
                    NextText = () => CurrentText(tempLevel + 1);
                    maxLevel = 100;
                    break;
                case R_upgradeId.Unleash:
                    Name = "Unleash New Spirit Upgrades";
                    Explain = "Unleash 3 New Spirit Upgrades";
                    CurrentCost = (x) => 1;
                    CurrentValue = (x) => 3*x;
                    CurrentText = (x) => "Unleash " + tDigit(CurrentValue(x)) + " New Spirit Upgrades";
                    NextText = () => CurrentText(tempLevel + 1);
                    maxLevel = 3;
                    break;

                    //case R_upgradeId.Unleash:
                    //    Name = "Extra Spirit Upgrades";
                    //    Explain = "Unleash";
                    //    CurrentCost = (x) => 1;
                    //    CurrentValue = (x) => 0.025d * x;
                    //    CurrentText = (x) => "+ " + percent(CurrentValue(x));
                    //    NextText = () => CurrentText(tempLevel + 1);
                    //    maxLevel = 40;
                    //    break;

            }
        }
        else
        {
            unlock = gameObject.AddComponent<UNLOCK>();
            unlock.UnlockCondition = () => true;
            unlock.TargetCanvas = main.rein.R_upgradeCanvas;
            double maxLevelBonus = 0;
            double temp = 0;
            for (int i = 0; i < main.S.CurseReinClearNum.Length; i++)
            {
                temp += main.S.CurseReinClearNum[i] * 0.1;
            }
            maxLevelBonus = temp;
            switch (SR_thisId)
            {
                case SR_upgradeID.Loot:
                    Name = "Power of Replication";
                    Explain = "Increase quantity of loot gained when you defeat enemies.";
                    CurrentCost = (x) => (long)(5000 * Math.Pow(2, x));
                    CurrentValue = (x) => x;
                    CurrentText = (x) => "Additional loot drop  + " + tDigit(CurrentValue(x));
                    NextText = () => CurrentText(tempLevel + 1);
                    maxLevel = 5;
                    break;
                case SR_upgradeID.Greedy:
                    Name = "Greedy Looting";
                    Explain = "Increase Drop Slot by one for each upgrade.";
                    CurrentCost = (x) => (long)(3000 * Math.Pow(1.8, x));
                    CurrentValue = (x) => x;
                    CurrentText = (x) => "Drop Slot  + " + tDigit(CurrentValue(x));
                    NextText = () => CurrentText(tempLevel + 1);
                    maxLevel = 10;
                    break;
                case SR_upgradeID.Golden:
                    Name = "Golden Touch";
                    Explain = "Increase starting Gold Gain and EXP Gain.";
                    CurrentCost = (x) => (long)(600 * Math.Pow(1.5, x));
                    CurrentValue = (x) => x;
                    CurrentText = (x) => "Gold Gain  + " + tDigit(CurrentValue(x)) + ", EXP Gain  + " + tDigit(CurrentValue(x) * 5);
                    NextText = () => CurrentText(tempLevel + 1);
                    maxLevel = 20;
                    break;
                case SR_upgradeID.DarkRitualGem:
                    Name = "Enchanted Gem Clock";
                    Explain = "Reduces the time it takes to level up Gems.";
                    CurrentCost = (x) => (long)(450 + 50 * Math.Pow(1.15, x));
                    CurrentValue = (x) => 1d / Math.Pow(1.1, x);
                    CurrentText = (x) => "Gem Time  " + percent(CurrentValue(x),3);
                    NextText = () => CurrentText(tempLevel + 1);
                    maxLevel = 50 ;
                    break;
                case SR_upgradeID.AlchemyPoint://これまで獲得したアルケミーポイントの一部を引き継ぐ
                    Name = "Alchemy Point";
                    Explain = "Keep X% of Alchemy Points you've gained during this reincarnation.";
                    CurrentCost = (x) => (long)(2000 * Math.Pow(1.5, x));
                    CurrentValue = (x) => x * 0.1d;
                    CurrentText = (x) => "Persist  " + percent(CurrentValue(x));
                    NextText = () => CurrentText(tempLevel + 1);
                    maxLevel = 10;
                    break;
                case SR_upgradeID.Trainer:
                    Name = "Powerful Trainers";
                    Explain = "Increase the overall Resource Production by a factor of 2 for each upgrade.";
                    CurrentCost = (x) => (long)(500 * Math.Pow(x + 1, 2));
                    CurrentValue = (x) => (double)Math.Pow(2, x);
                    CurrentText = (x) => "Resource Production  * " + tDigit(CurrentValue(x));
                    NextText = () => CurrentText(tempLevel + 1);
                    maxLevel = 20;
                    break;
                case SR_upgradeID.Alkahest:
                    Name = "Alkahest'ish";
                    Explain = "Increase starting Purification Speed in alchemy.";
                    CurrentCost = (x) => (long)(500 + 20 * x);
                    CurrentValue = (x) => 0.25d * x;
                    CurrentText = (x) => "Purification Speed  + " + tDigit(CurrentValue(x), 3) + " mL / s";
                    NextText = () => CurrentText(tempLevel + 1);
                    maxLevel = 200;
                    break;
                case SR_upgradeID.Deeper:
                    Name = "Deeper Pockets";
                    Explain = "Increase the Gold Cap by 1% per upgrade.";
                    CurrentCost = (x) => (long)(500 * Math.Pow(1.15, x));
                    CurrentValue = (x) => x * 0.01d;
                    CurrentText = (x) => "Gold Cap  + " + percent(CurrentValue(x));
                    NextText = () => CurrentText(tempLevel + 1);
                    maxLevel = 50;
                    break;
                case SR_upgradeID.HappyCapture:
                    Name = "Happy Captures";
                    Explain = "Enable to automatically capture a monster when you defeat it.";
                    CurrentCost = (x) => (long)(2500 * (x + 1) + 500 * Math.Pow(2, x));
                    CurrentValue = (x) => x * 0.0002d;
                    CurrentText = (x) => "Auto Capture Chance  " + percent(CurrentValue(x));
                    NextText = () => CurrentText(tempLevel + 1);
                    maxLevel = 10;
                    break;
                case SR_upgradeID.LoyalBargain:
                    Name = "Loyal Bargain";
                    Explain = "Reduces the cost of Resource Upgrades by 0.25% per level. \n(Lv 1-200 additive; Lv 200+ multiplicative)";
                    CurrentCost = (x) => (long)Math.Min(200 + 50 * x, 1000 * (x + 1));
                    CurrentValue = (x) => 
                    {
                        if (x <= 200)
                        {
                            return 1d - 0.0025d * x;
                        }
                        else
                        {
                            return 0.5d * Pow(0.99975, x - 200);
                        }
                    };
                    CurrentText = (x) => "Resource Upgrades Cost  " + percent(CurrentValue(x));
                    NextText = () => CurrentText(tempLevel + 1);
                    maxLevel = 200;
                    unlock.UnlockCondition = () => main.rein.R_upgrades[(int)R_UPGRADE.R_upgradeId.Unleash].GetCurrentValue() >= 3;
                    break;
                case SR_upgradeID.EQSlot:
                    Name = "Wardrobe of Aranathi";
                    Explain = "Gain extra Equipment Slots.";
                    CurrentCost = (x) => (long)(1000 * Math.Pow(2, x));
                    CurrentValue = (x) => x;
                    CurrentText = (x) => "Equipment Slot  + " + tDigit(CurrentValue(x));
                    NextText = () => CurrentText(tempLevel + 1);
                    maxLevel = 5 ;
                    unlock.UnlockCondition = () => main.rein.R_upgrades[(int)R_UPGRADE.R_upgradeId.Unleash].GetCurrentValue() >= 3;
                    break;
                case SR_upgradeID.Catographer:
                    Name = "Cartographer";
                    Explain = "Increase the number of clears counted when you clear an area.";
                    CurrentCost = (x) => (long)(800 * Math.Pow(x + 1, 1.5));
                    CurrentValue = (x) => x;
                    CurrentText = (x) => "Area Clear Count  + " + tDigit(CurrentValue(x));
                    NextText = () => CurrentText(tempLevel + 1);
                    maxLevel = 10;
                    unlock.UnlockCondition = () => main.rein.R_upgrades[(int)R_UPGRADE.R_upgradeId.Unleash].GetCurrentValue() >= 3;
                    break;
                case SR_upgradeID.Sincere:
                    Name = "Sincere Buisiness";
                    Explain = "Increase the Reputation Gain when you buy Slime Bank upgrades.";
                    CurrentCost = (x) => (long)(1000 + 100 * x);
                    CurrentValue = (x) => x * 0.2d;
                    CurrentText = (x) => "Reputation Gain  + " + percent(CurrentValue(x));
                    NextText = () => CurrentText(tempLevel + 1);
                    maxLevel = 50;
                    unlock.UnlockCondition = () => main.rein.R_upgrades[(int)R_UPGRADE.R_upgradeId.Unleash].GetCurrentValue() >= 6;
                    break;
                case SR_upgradeID.SlimeKingBlessing:
                    Name = "Slime King Bargain";
                    Explain = "Reduces the cost of Slime Bank by 0.25% per level. \n(Lv 1-200 additive; Lv 200+ multiplicative)";
                    CurrentCost = (x) => (long)Math.Min(200 + 50 * x, 1000 * (x + 1));
                    CurrentValue = (x) =>
                    {
                        if (x <= 200)
                        {
                            return 1d - 0.0025d * x;
                        }
                        else
                        {
                            return 0.5d * Pow(0.99975, x - 200);
                        }
                    };
                    CurrentText = (x) => "Slime Bank upgrades Cost  " + percent(CurrentValue(x));
                    NextText = () => CurrentText(tempLevel + 1);
                    maxLevel = 200;
                    unlock.UnlockCondition = () => main.rein.R_upgrades[(int)R_UPGRADE.R_upgradeId.Unleash].GetCurrentValue() >= 6;
                    break;
                case SR_upgradeID.Queue:
                    Name = "Queue Done It?";
                    Explain = "Gain an additional 5 queues for Resource Upgrades.";
                    CurrentCost = (x) => (long)(10000 * Math.Pow(2, x));
                    CurrentValue = (x) => 5*x;
                    CurrentText = (x) => "Resource Upgrade Queue  + " + tDigit(CurrentValue(x));
                    NextText = () => CurrentText(tempLevel + 1);
                    maxLevel = 5;
                    unlock.UnlockCondition = () => main.rein.R_upgrades[(int)R_UPGRADE.R_upgradeId.Unleash].GetCurrentValue() >= 6;
                    break;

                case SR_upgradeID.Clock:
                    Name = "Enchanted Beast Clock";
                    Explain = "Reduces the time it takes to loot captured monsters.";
                    CurrentCost = (x) => (long)(3000 * Math.Pow(1.5, x));
                    CurrentValue = (x) => 1d / Math.Pow(2,x);
                    CurrentText = (x) => "Loot Time  " + percent(CurrentValue(x),3);
                    NextText = () => CurrentText(tempLevel + 1);
                    maxLevel = 8;
                    unlock.UnlockCondition = () => main.rein.R_upgrades[(int)R_UPGRADE.R_upgradeId.Unleash].GetCurrentValue() >= 9;
                    break;

                case SR_upgradeID.PrestigeBargain:
                    Name = "Prestige Bargain";
                    Explain = "Reduces the cost of Rebirth Upgrades by 0.45% per level. \n(Lv 1-200 additive; Lv 200+ multiplicative)";
                    CurrentCost = (x) => (long)Math.Min(200 + 50 * x, 1000 * (x + 1));
                    CurrentValue = (x) =>
                    {
                        if (x <= 200)
                        {
                            return 1d - 0.0045d * x;
                        }
                        else
                        {
                            return 0.1d * Pow(0.99945, x-200);
                        }
                    };
                    //CurrentValue = (x) => 1d - 0.0045d * x;
                    CurrentText = (x) => "Rebirth Upgrades Cost  " + percent(CurrentValue(x));
                    NextText = () => CurrentText(tempLevel + 1);
                    maxLevel = 200;
                    unlock.UnlockCondition = () => main.rein.R_upgrades[(int)R_UPGRADE.R_upgradeId.Unleash].GetCurrentValue() >= 9;
                    break;

                case SR_upgradeID.BankQueue:
                    Name = "Bank Queue";
                    Explain = "Gain an additional 5 queues for Slime Bank Upgrades.";
                    CurrentCost = (x) => (long)(25000 * Math.Pow(2, x));
                    CurrentValue = (x) => 5*x;
                    CurrentText = (x) => "Slime Bank Upgrade Queue  + " + tDigit(CurrentValue(x));
                    NextText = () => CurrentText(tempLevel + 1);
                    maxLevel = 5;
                    unlock.UnlockCondition = () => main.rein.R_upgrades[(int)R_UPGRADE.R_upgradeId.Unleash].GetCurrentValue() >= 9;
                    break;

            }
            maxLevel = (int)(maxLevel * (1 + maxLevelBonus));
            unlock.orderId = (int)SR_thisId;
        }

    }
    public void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(calculate);
        startText();
        if (isMainUpgrade)
        {
            tempLevel = main.S.R_level[(int)R_thisId];
        }
        else
        {
            tempLevel = main.S.SR_level[(int)SR_thisId];
        }
    }
    public void calculate()
    {
        if(isMainUpgrade)
            main.tempRP -= CurrentCost(tempLevel);
        else
            main.tempSRP -= CurrentCost(tempLevel);
        tempLevel++;
    }
    public enum R_upgradeId
    {
        NewWarrior,
        NewWizard,
        NewAngel,
        SpiritEssenceMore,
        Unleash,
        MaxExpand,
    }
    public R_upgradeId R_thisId;
    public enum SR_upgradeID
    {
        Loot,
        Trainer,
        Greedy,
        Alkahest,
        Golden,
        Sincere,
        Catographer,
        Bonus,
        Deeper,
        DarkRitualGem,
        AlchemyPoint,
        Clock,
        EQSlot,
        HappyCapture,
        LoyalBargain,
        SlimeKingBlessing,
        PrestigeBargain,
        Queue,
        BankQueue,
    }
    public SR_upgradeID SR_thisId;
    //実際に値を使うときはTempじゃないほうを　使う．
    public double calculateNextValueTemp()
    {
        tempLevel++;
        double ans = CurrentValue(tempLevel);
        tempLevel--;
        return ans;
    }
    public double calculateNextSub()
    {
        return calculateNextValueTemp() - CurrentValue(tempLevel);
    }

    bool ButtonCondition()
    {
        if (isMainUpgrade)
        {
            return tempLevel < maxLevel && CurrentCost(tempLevel) <= main.tempRP;
        }
        else
        {
            return tempLevel < maxLevel && CurrentCost(tempLevel) <= main.tempSRP;
        }
    }

    public void Update()
    {
        if (main.GameController.currentCanvas != main.GameController.JobchangeCanvas)
        {
            return;
        }

        if (!ButtonCondition())
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
        }

        updateText();
        //テキストの更新
        Level = tempLevel.ToString();
        kind = "Max Level : " + maxLevel;
        //if (isMainUpgrade)
        //{
        //    Level = tDigit(main.S.R_level[(int)R_thisId]);
        //}
        //else
        //{
        //    Level = tDigit(main.S.SR_level[(int)SR_thisId]);
        //}
        currentEffect = CurrentText(tempLevel);
        if (tempLevel < maxLevel)
            nextEffect = NextText();
        else
        {
            if (isMainUpgrade && (R_thisId == R_upgradeId.NewWarrior || isMainUpgrade && R_thisId == R_upgradeId.NewWizard || isMainUpgrade && R_thisId == R_upgradeId.NewAngel))
                nextEffect = NextText();
            else
                nextEffect = "";

        }
        if(isMainUpgrade)
            cost = "Heart Stone  " + tDigit(CurrentCost(tempLevel));
        else
            cost = "Spirit Essence  " + tDigit(CurrentCost(tempLevel));
    }

    public double fibonacci(int n)
    {
        double factor = 1 / Sqrt(5);
        double phi = (1 + Sqrt(5)) / 2;
        double phi2 = (1 - Sqrt(5)) / 2;

        return factor * (Pow(phi, n) - Pow(phi2, n));
    }

    //public string percent(double d)
    //{
    //    return tDigit((d - 1) * 100, 2) + " % ";
    //}
}
