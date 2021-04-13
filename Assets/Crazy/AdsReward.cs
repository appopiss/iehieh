using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;
using TMPro;

public abstract class AdsReward{

    public Button button;
    TextMeshProUGUI titleText;
    TextMeshProUGUI explainText;
    public virtual void GetReward()
    {
        if (main.epicShop.TotalBonusPoint() == 0)
        {
            return;
        }
        main.S.APconsumed++;
    }
    protected virtual bool canBuy => main.epicShop.TotalBonusPoint() > 0;
    public abstract string RewardName();
    public abstract string RewardExplain();
    public void SetUI(Button button, TextMeshProUGUI title, TextMeshProUGUI explain)
    {
        this.button = button;
        titleText = title;
        explainText = explain;
        button.onClick.AddListener(() => GetReward());
        title.text = RewardName();
        explain.text = RewardExplain();
    }
    public void UpdateUI()
    {
        if (!canBuy)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
        explainText.text = "Required : <sprite=\"starslice\" index=1> 1\n" + RewardExplain();
    }
    protected virtual int cost => 1;
}

public class InstantResource : AdsReward
{
    public override void GetReward()
    {
        base.GetReward();
        CoroutineHandler.StartStaticCoroutine(main.idleBackGround.GetOfflineBonus(1800));
    }

    public override string RewardExplain()
    {
        return "You can instantly gain Offline Bonus for 30 min.";
    }

    public override string RewardName()
    {
        return "Time Warp 30 min";
    }
}

public class GameSpeed : AdsReward
{
    float timeLeft { get => main.S.nitroExplosionTimeLeft; set => main.S.nitroExplosionTimeLeft = value; }
    public override void GetReward()
    {
        base.GetReward();
        timeLeft += 600;
    }

    public override string RewardExplain()
    {
        string tempString = "Game Speed + 100% for 10 min. Activation time is stuck. Total Game Speed x3 while Nitro activated.";
        if (timeLeft > 0)
            tempString += "\n<color=green>Activated  " + DoubleTimeToDate(timeLeft) + " left</color>";
        return tempString;
    }

    public override string RewardName()
    {
        return "Game Speed + 100%";
    }
}

public class EpicCoin : AdsReward
{
    protected override bool canBuy
    {
        get => main.epicShop.TotalBonusPoint() > 0 && main.S.dailyECnum < 3;
    }
    public override void GetReward()
    {
        base.GetReward();
        main.S.ECC1 += 20;
        main.S.dailyECnum++;
    }
        
    public override string RewardExplain()
    {
        return "You can instantly gain 100 Epic Coin! \n(Limit per day : " + main.S.dailyECnum + " / 3 )" ;
    }

    public override string RewardName()
    {
        return "100 Epic Coin";
    }
}
