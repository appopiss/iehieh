using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UsefulMethod;
using System;

public class IEBBonusController : BASE
{
    public TextMeshProUGUI haveText;
    public Button playIEBButton;
    public IEBBONUS[] bonuses;

    [System.NonSerialized]
    public OpenClose thisOpenClose;
    private void Awake()
    {
        for (int i = 0; i < bonuses.Length; i++)
        {
            bonuses[i].id = i;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        thisOpenClose = gameObject.GetComponent<OpenClose>();
        playIEBButton.onClick.AddListener(onClick);
        UpdateText();
        CalculateBonus();
    }
    void onClick()
    {
        if (main.platform == Platform.steam)
            Application.OpenURL("https://store.steampowered.com/app/1535060/Incremental_Epic_Breakers/");//""の中には開きたいWebページのURLを入力します
        else
            Application.ExternalEval(string.Format("window.open('{0}','_blank')", "https://store.steampowered.com/app/1535060/Incremental_Epic_Breakers/"));
    }
    public int CurrentBonusPoint()
    {
        return main.S.isIEBSteamAchievementNum - ConsumedBonusPointNum();
    }
    int ConsumedBonusPointNum()
    {
        int tempNum = 0;
        for (int i = 0; i < main.S.isPurchasedIEBBonus.Length; i++)
        {
            if (main.S.isPurchasedIEBBonus[i])
                tempNum++;
        }
        return tempNum;
    }
    void UpdateText()
    {
        haveText.text = optStr + "You currently have <color=green>" + CurrentBonusPoint().ToString() + "</color> bonus points.";
    }

    // Update is called once per frame
    void Update()
    {
        if (thisOpenClose.isOpen)
            UpdateText();
    }
    public double[] iebBonuses = new double[Enum.GetNames(typeof(IEBBONUS.BonusKind)).Length];
    double[] tempBonuses = new double[Enum.GetNames(typeof(IEBBONUS.BonusKind)).Length];
    public void CalculateBonus()
    {
        for (int i = 0; i < iebBonuses.Length; i++)
        {
            tempBonuses[i] = 0;
        }
        for (int i = 0; i < bonuses.Length; i++)
        {
            if (bonuses[i].IsPurchased())
            {
                switch (bonuses[i].kind)
                {
                    case IEBBONUS.BonusKind.ec:
                        tempBonuses[(int)bonuses[i].kind]++;
                        break;
                    case IEBBONUS.BonusKind.goldgain:
                        tempBonuses[(int)bonuses[i].kind] += 0.2d;
                        break;
                    case IEBBONUS.BonusKind.goldcap:
                        tempBonuses[(int)bonuses[i].kind] += 0.1d;
                        break;
                    case IEBBONUS.BonusKind.expgain:
                        tempBonuses[(int)bonuses[i].kind] += 0.1d;
                        break;
                    case IEBBONUS.BonusKind.monstergoldcap:
                        tempBonuses[(int)bonuses[i].kind] += 250;
                        break;
                    case IEBBONUS.BonusKind.prof:
                        tempBonuses[(int)bonuses[i].kind] += 1;
                        break;
                    case IEBBONUS.BonusKind.eq:
                        tempBonuses[(int)bonuses[i].kind] += 1;
                        break;
                    default:
                        break;
                }
            }
        }
        for (int i = 0; i < iebBonuses.Length; i++)
        {
            iebBonuses[i] = tempBonuses[i];
        }
    }
}
