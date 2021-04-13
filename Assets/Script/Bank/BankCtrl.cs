using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;
using static B_Upgrade.UpgradeId;
using System.Linq;
using UnityEngine.EventSystems;
using System.Text;
using static BASE;

public class BankCtrl : BASE {

    public TextMeshProUGUI explainText;
    public TextMeshProUGUI EffeciencyText;
    public TextMeshProUGUI ExchangeRateText;
    public TextMeshProUGUI CurrentSlimeCoinText;
    public TextMeshProUGUI ReputationText;
    public TextMeshProUGUI UnlockText;
    public Slider BankSlider;
    public Button GoBank;
    public Button GoUpgrade;
    public Button WithDrawalButton;
    public GameObject BankCanvas;
    public Button[] bairituButtons;
    public B_Upgrade[] BankUpgrades;
    public Transform StoneUpgradeCanvas;
    public Transform CrystalUpgradeCanvas;
    public Transform LeafUpgradeCanvas;
    public Transform ParentCanvas;
    public GameObject ReputationTargetObject;

    public int RequiredReputation;
    public GameObject window;

    public void InstantiateWindow()
    {
        window = Instantiate(main.P_texts[33], main.WindowShowCanvas);
        ReputationTargetObject.AddComponent<EventTrigger>().triggers = new List<EventTrigger.Entry>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry2.eventID = EventTriggerType.PointerExit;
        entry.callback.AddListener((x) => UsefulMethod.setActive(window));
        entry2.callback.AddListener((x) => UsefulMethod.setFalse(window)); //ラムダ式の右側は追加するメソッドです。
        ReputationTargetObject.GetComponent<EventTrigger>().triggers.Add(entry);
        ReputationTargetObject.GetComponent<EventTrigger>().triggers.Add(entry2);
    }

    public void Open()
    {
        main.DRctrl.UpgradePanel.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, -500f);
        BankCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 500f);
        ShowDescription();
        main.idleBackGround.isBank = true;
    }
    public void Close()
    {
        main.DRctrl.UpgradePanel.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 500f);
        BankCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, -500f);
        main.idleBackGround.isBank = false;
    }

    string rep = "Reputation";
    string sc = "Slime Coin";
    string gold = "Gold";
    public void ShowDescription()
    {
        LocalizeInitialize.SetFont(explainText);
        LocalizeInitialize.SetFont(ReputationText);
        LocalizeInitialize.SetFont(ExchangeRateText);
        LocalizeInitialize.SetFont(EffeciencyText);

        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                explainText.text = "The Slime Bank converts your wasted Gold into Slime Coin you can spend on powerful upgrades that persist through Rebirth. Earn reputation by spending Slime Coin and more upgrade opportunities will become available!";
                rep = "Reputation";
                sc = "Slime Coin";
                gold = "Gold";
                break;
            case Language.jp:
                explainText.text = "スライムバンクでは、ゴールドキャップを超過したゴールドをスライムコインに変換し、より強力なアップグレードを購入できます。バンクは再誕(Rebirth)をしても引き継がれます。";
                rep = "評判";
                sc = "スライムコイン";
                gold = "ゴールド";
                break;
            case Language.chi:
                explainText.text = "<size=11>当玩家的金币溢出金币上限的时候, 一定量的金币就会自动兑换成史莱姆币. 转生不会重置史莱姆银行科技. 转世将会重置史莱姆科技银行威望越高可研发的科技越多. 备注: 转生和转世是不一样的东西.";
                rep = "威望";
                sc = "史莱姆币";
                gold = "金币";
                break;
            default:
                break;
        }
    }

    GameObject confirmWindow;
    void confirmWithDrawal()
    {
        if (main.S.SlimeCoin == 0)
            return;
        double sabun = main.MaxGold() - main.SR.gold;

        confirmWindow = Instantiate(main.P_texts[26], main.DeathShowCanvas);
        if (main.S.SlimeCoin * ExchangeRate() >= sabun)
            confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Withdraw <color=green>" + tDigit(sabun) + " Gold\n\n</color>Slime Coin : " + tDigit(main.S.SlimeCoin) + " -> <color=red>" + tDigit(main.S.SlimeCoin - (sabun / ExchangeRate()));
        else
            confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Withdraw <color=green>" + tDigit(main.S.SlimeCoin * ExchangeRate()) + " Gold\n\n</color>Slime Coin : " + tDigit(main.S.SlimeCoin) + " -> <color=red>0";

        confirmWindow.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() => Destroy(confirmWindow));
        confirmWindow.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(() =>
        {
            if (main.S.SlimeCoin * ExchangeRate() >= sabun)
            {
                main.SR.gold += sabun;
                main.S.SlimeCoin -= sabun / ExchangeRate();
            }
            else
            {
                main.SR.gold += main.S.SlimeCoin * ExchangeRate();
                main.S.SlimeCoin -= main.S.SlimeCoin;
            }
            Destroy(confirmWindow);
        });

    }
    //public void WithDrawal()
    //{
    //    if (main.S.SlimeCoin == 0)
    //        return;

    //    double sabun = main.MaxGold() - main.SR.gold;
    //    if(main.S.SlimeCoin * ExchangeRate() >= sabun)
    //    {
    //        main.SR.gold += sabun;
    //        main.S.SlimeCoin -= sabun/ExchangeRate();
    //    }
    //    else
    //    {
    //        main.SR.gold += main.S.SlimeCoin * ExchangeRate();
    //        main.S.SlimeCoin -= main.S.SlimeCoin;
    //    }
    //}
    public double BankCap()
    {
        if (main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.BankCap].calculateCurrentValue() == 0)
            return 1000;

        return main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.BankCap].calculateCurrentValue();
    }
    public double ExchangeRate()
    {
        return main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.BankRate].calculateCurrentValue();
    }
    public double Effeciency()  
    {
        if (BankUpgrades[(int)B_Upgrade.UpgradeId.BankEfficiency].calculateCurrentValue() == 0)
            return 500 / ((1+main.alchemyController.bankEfficiencyFactor)*(1+main.MissionMileStone.BankEfficiencyBonus()));

        return 1.0f / (BankUpgrades[(int)B_Upgrade.UpgradeId.BankEfficiency].calculateCurrentValue() * (1 + main.alchemyController.bankEfficiencyFactor) * (1 + main.MissionMileStone.BankEfficiencyBonus()));
    }
    public string ShowReputation()
    {
        string tempText = "Reputation : <color=green>" + tDigit(main.S.slimeReputation) + "</color><size=12>\n\n";

        IEnumerable<B_Upgrade> newUpgrade = BankUpgrades.OrderBy(a => a.RequiredReputation);
        foreach (B_Upgrade upgrade in newUpgrade)
        {
            if (upgrade.RequiredReputation == 0)
                continue;

            if (main.S.slimeReputation < upgrade.RequiredReputation)
            {
                if(upgrade.RequiredReputation < 1000)
                    tempText += "- " + tDigit(upgrade.RequiredReputation) + "   :  " + "<color=red>???</color>\n";
                else
                    tempText += "- " + tDigit(upgrade.RequiredReputation) + " :  " + "<color=red>???</color>\n";
            }
            else
            {
                if (upgrade.RequiredReputation < 1000)
                    tempText += "- " + tDigit(upgrade.RequiredReputation) + "   :  " + upgrade.gameObject.name + "\n";
                else
                    tempText += "- " + tDigit(upgrade.RequiredReputation) + " :  " + upgrade.gameObject.name + "\n";
                    
            }
        }

        return tempText;
    }
    public IEnumerator ShowReputationText()
    {
        while (true)
        {
            //UnlockText.text = ShowReputation();
            //reputationText.text = ShowReputation();
            window.GetComponentInChildren<TextMeshProUGUI>().text = ShowReputation().ToString();
            yield return new WaitForSeconds(1.0f);
        }
    }
	// Use this for initialization
	void Awake () {
		StartBASE();
        InstantiateWindow();
        GoBank.onClick.AddListener(Open);
        GoUpgrade.onClick.AddListener(Close);
        WithDrawalButton.onClick.AddListener(confirmWithDrawal);
        bairituButtons[0].onClick.AddListener(() => main.SR.B_buyMode = UPGRADE.buyMode.mode1);
        bairituButtons[1].onClick.AddListener(() => main.SR.B_buyMode = UPGRADE.buyMode.mode10);
        bairituButtons[2].onClick.AddListener(() => main.SR.B_buyMode = UPGRADE.buyMode.mode25);
        bairituButtons[3].onClick.AddListener(() => main.SR.B_buyMode = UPGRADE.buyMode.modeMax);
    }

	// Use this for initialization
	void Start () {
        foreach(B_Upgrade upgrade in BankUpgrades)
        {
            upgrade.gameObject.AddComponent<UnlockBank>().UnlockCondition = () => main.S.slimeReputation >= upgrade.RequiredReputation;
        }
        //BankUpgrades[(int)Donate].gameObject.AddComponent<UnlockBank>().UnlockCondition = () => true;
        //BankUpgrades[(int)sEnhance].gameObject.AddComponent<UnlockBank>().UnlockCondition = () => true;
        //BankUpgrades[(int)cEnhance].gameObject.AddComponent<UnlockBank>().UnlockCondition = () => true;
        //BankUpgrades[(int)lEnhance].gameObject.AddComponent<UnlockBank>().UnlockCondition = () => true;
        //BankUpgrades[(int)BankEfficiency].gameObject.AddComponent<UnlockBank>().UnlockCondition = () => true;
        //BankUpgrades[(int)BankRate].gameObject.AddComponent<UnlockBank>().UnlockCondition = () => true;
        //BankUpgrades[(int)B_Upgrade.UpgradeId.BankCap].gameObject.AddComponent<UnlockBank>().UnlockCondition = () => true;
        //BankUpgrades[(int)BankInterest].gameObject.AddComponent<UnlockBank>().UnlockCondition = () => true;
        //BankUpgrades[(int)counter].gameObject.AddComponent<UnlockBank>().UnlockCondition = () => true;
        //BankUpgrades[(int)S_technical].gameObject.AddComponent<UnlockBank>().UnlockCondition = () => true;

        StartCoroutine(ShowReputationText());
        StartCoroutine(LiquidateSlimeCoin());
    }
	
	// Update is called once per frame
	void Update () {

        updateText();
        if (main.S.SlimeCoin > BankCap())
            main.S.SlimeCoin = BankCap();
        if (main.S.SlimeCoin < 0)
            main.S.SlimeCoin = 0;
        if (main.S.slimeReputation < 0)
            main.S.slimeReputation = 0;
        
        //Debug.Log(this[BankRate].calculateCurrentValue());
        
        if (main.GameController.currentCanvas == main.GameController.IdleCanvas)
        {
            BankSlider.value = (float)(main.S.SlimeCoin / BankCap());
            CurrentSlimeCoinText.text = tDigit(Math.Min(main.S.SlimeCoin, BankCap())) + " / " + tDigit(BankCap());

            if (main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.coin].level < 1)
                EffeciencyText.text = "1 " + sc +" / " + tDigit(Effeciency()) + " " + gold;
            else
                EffeciencyText.text = tDigit((1+ main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.coin].level)) + " " + sc +" / " + tDigit(Effeciency()) + " " + gold;
            ReputationText.text = rep + " : <color=green>" + tDigit(main.S.slimeReputation);
            ExchangeRateText.text = tDigit(ExchangeRate(), 2) + " " + gold + " / 1 " + sc;
        }
    }

    void updateText()
    {
        if (!window.activeSelf)
            return;

        //if (window != null)
        //{
        //    if (Input.mousePosition.y >= 300 && Input.mousePosition.x >= 400)
        //    {
        //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(-250.0f, -50.0f);
        //    }
        //    else if (Input.mousePosition.y >= 300 && Input.mousePosition.x < 400)
        //    {
        //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(50.0f, -50.0f);
        //    }
        //    else if (Input.mousePosition.y < 300 && Input.mousePosition.x > 400)
        //    {
        //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(-250.0f, 50.0f);
        //    }
        //    else if (Input.mousePosition.y < 300 && Input.mousePosition.x < 400)
        //    {
        //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(50.0f, 100.0f);
        //    }
        //}
    }

    public IEnumerator LiquidateSlimeCoin()
    {
        while (true)
        {
            yield return new WaitUntil(() => main.S.TempStoreSlimeCoin > 0);
            double getCoin = main.S.TempStoreSlimeCoin / Effeciency();
            main.S.TempStoreSlimeCoin = 0;
            main.S.SlimeCoin += (getCoin * (1+main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.coin].level));
            yield return new WaitForSeconds(0.1f);
        }
    }

    public B_Upgrade this[B_Upgrade.UpgradeId id]
    {
        get => main.bankCtrl.BankUpgrades[(int)id];
    }
}
