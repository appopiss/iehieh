using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UsefulMethod;

public class EpicShop : BASE {

    public GameObject EpicShopCanvas;
    public Button closeButton;
    public Button openButton;
    public TextMeshProUGUI EpicCoinText;
    public Button[] tabButtons;
    public Transform[] goodsCanvas;
    public GameObject currentCanvas;
    public GameObject crazygamesCanvas;

    bool isShowing;

    public void Open()
    {
        EpicShopCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(-1000, 0);
        isShowing = true;
    }
    public void Close()
    {
        //Debug.Log("yonderuyo");
        EpicShopCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(1000, 0);
        isShowing = false;
    }

    // Use this for initialization
    void Awake () {
		StartBASE();
        closeButton.onClick.AddListener(Close);
        openButton.onClick.AddListener(Open);

        currentCanvas = goodsCanvas[0].gameObject;
        for (int i = 0; i < goodsCanvas.Length; i++)
        {
            int count = i;
            tabButtons[count].onClick.AddListener(() => setSibling(count));
        }
    }

    public void setSibling(int count)
    {
        if (currentCanvas == goodsCanvas[count])
        {
            return;
        }
        else
        {
            currentCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, -500);
            goodsCanvas[count].GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 500);
            currentCanvas = goodsCanvas[count].gameObject;
        }
    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!isShowing)
            return;

        EpicCoinText.text = "<sprite=0> " + tDigit(totalEpicCoin());
        if (main.platform == Platform.crazygames)
        {
            if (currentCanvas == goodsCanvas[4].gameObject || currentCanvas == goodsCanvas[8].gameObject)
                setActive(crazygamesCanvas);
            else
                setFalse(crazygamesCanvas);
        }
        else
            setFalse(crazygamesCanvas);
    }

    public int TotalBonusPoint()
    {
        return main.S.AP1 - main.S.APconsumed;
    }

    public long totalEpicCoin()
    {
        return main.S.ECbyKreds * 50
            + main.S.ECbyMission * 5
            + main.S.ECbyMissionHidden * 5
            + main.S.ECbyQuest * 10
            + main.S.ECbyDailyQuest * 5
            + ECbyDLC()
            + ECbyKreds()
            + ECbyAds
            + ECbyKredsOnePurchase()
            + ECbyBonus()
            + ECbyContest()
            + ECbyRestore()
            + ECbyLocalSave()
            + ECbyIEB()
            - main.S.ECconsumed;
    }
    public long ECbyDLC()
    {
        //return 0;
        return 2000 * Convert.ToInt32(main.S.dlcStarter||main.S.dlcStarterECGot)
            + 5500 * Convert.ToInt32(main.S.dlcNitro||main.S.dlcNitroECGot)
            + 5500 * Convert.ToInt32(main.S.dlcGlobal||main.S.dlcGlobalECGot)
            + 5500 * Convert.ToInt32(main.S.dlcGold||main.S.dlcGoldECGot)
            + 5500 * Convert.ToInt32(main.GameController.isDlcIEH2 || main.S.dlcIeh2ECGot)
            ;
    }
    public long ECbyKreds()
    {
        return (main.S.EC1 * 500 + main.S.EC2 * 1050 + main.S.EC3 * 2650 + main.S.EC4 * 5500 + main.S.EC5 * 12000 + main.S.EC6 * 18500 + main.S.EC7 * 31000 + main.S.EC8 * 70000);
    }
    public long ECbyKredsOnePurchase()
    {
        return (main.S.ECF1 * 1000 + main.S.ECF2 * 2100 + main.S.ECF3 * 5300 + main.S.ECF4 * 11000 + main.S.ECF5 * 24000 + main.S.ECF6 * 37000 + main.S.ECS1 * 500 + main.S.ECS4 * 5500);// + main.S.ECS2 * 1050 + main.S.ECS3 * 2650 );
    }
    public long ECbyBonus()
    {
        return main.S.ECforDebug * 70000 + Convert.ToInt32(main.S.BC1IEHhapiwaku) * 200 + Convert.ToInt32(main.S.BC2IEHmonthlycontest) * 250 + Convert.ToInt32(main.S.BC3IEHhapiwakuMay) * 300 + Convert.ToInt32(main.S.BC7IEHhapiwakuJune) * 500 + Convert.ToInt32(main.S.BC8IEHhapiwakuJuly) * 700 + Convert.ToInt32(main.S.BC9IEHhapiwakuAugustKong) * 1000 + Convert.ToInt32(main.S.BC9IEHhapiwakuAugustArmorGames) * 1000
            + Convert.ToInt32(main.S.BC10IEHhapiwakuSeptemberKong) * 1000 + Convert.ToInt32(main.S.BC10IEHhapiwakuSeptemberArmorGames) * 1000
            + Convert.ToInt32(main.S.BC11IEHhapiwakuOctoberKong) * 1000 + Convert.ToInt32(main.S.BC11IEHhapiwakuOctoberArmorGames) * 1000
            + Convert.ToInt32(main.S.BCSteam) * 1000
            + Convert.ToInt32(main.S.BCYC) * 500
            + Convert.ToInt32(main.S.BCanniversary) * 1000;
    }
    public long ECbyContest()
    {
        return Convert.ToInt32(main.S.BC4IEHoctobaddie30) * 10000 + Convert.ToInt32(main.S.BC5IEHoctobaddie3) * 2500 + Convert.ToInt32(main.S.BC6IEHoctobaddie1) * 500;
    }
    public long ECbyRestore()
    {
        return main.S.ECbyRestoredMission;
    }
    public long ECbyLocalSave()
    {
        return main.S.ECbyLocalSave * 30;
    }
    public long ECbyIEB()
    {
        return 1000 * (long)main.iebCtrl.iebBonuses[(int)(IEBBONUS.BonusKind.ec)];
    }

    public long ECbyAds => main.S.ECC1 * 5;
}
