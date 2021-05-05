using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UsefulMethod;

public class BonusCode : BASE {

	// Use this for initialization
	void Awake () {
		StartBASE();
	}

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Button>().onClick.AddListener(BonusCodeWindow);
	}

    GameObject confirmWindow;
    void BonusCodeWindow()
    {
        //if (main.toggles[9].isOn)
        //    return;
        main.ally.isInputText = true;
        confirmWindow = Instantiate(main.P_texts[34], main.DeathShowCanvas);
        confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Input a bonus code";
        confirmWindow.transform.GetChild(4).GetComponentInChildren<TextMeshProUGUI>().text = "OK";
        confirmWindow.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(() => { main.ally.isInputText = false; Destroy(confirmWindow); });
        confirmWindow.transform.GetChild(4).GetComponent<Button>().onClick.AddListener(() =>
        {
            setFalse(confirmWindow.transform.GetChild(2).gameObject);
            CheckBonusCode(confirmWindow.transform.GetChild(2).GetComponent<TMP_InputField>().text);
            confirmWindow.transform.GetChild(4).GetComponent<Button>().onClick.AddListener(() => { main.ally.isInputText = false; Destroy(confirmWindow); });
        });
    }

    void CheckBonusCode(string inputText)
    {
        confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Congraturations! \nYou've received the following:\n<color=green>";
        switch (inputText)
        {
            case "IEHhapiwaku":
                if(main.S.BC1IEHhapiwaku)
                    confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "You had already received.";
                else
                {
                    confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text += "200 Epic Coin\n1 Super Rebirth Ticket";
                    main.S.SuperRebirthNum += 1;
                    if (!main.S.boughtSuperRebirth)
                        main.S.boughtSuperRebirth = true;
                    main.S.BC1IEHhapiwaku = true;
                }
                break;
            case "IEHmonthlycontest":
                if (main.S.BC2IEHmonthlycontest)
                    confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "You had already received.";
                else
                {
                    confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text += "250 Epic Coin\n500 Monster Fluid";
                    main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.MonsterFluid] += 500;
                    main.Log("Gained <color=green>Monster Fluid * 500", 5f);
                    main.S.BC2IEHmonthlycontest = true;
                }
                break;
            case "IEHhapiwakuMay":
                if (main.S.BC3IEHhapiwakuMay)
                    confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "You had already received.";
                else
                {
                    confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text += "300 Epic Coin\n1 Instant Rebirth Upgrade Ticket";
                    main.S.InstantRebirthNum += 1;
                    if (!main.S.boughtInstantRebirth)
                        main.S.boughtInstantRebirth = true;
                    main.S.BC3IEHhapiwakuMay = true;
                }
                break;
            case "IEHoctobaddie30"://期間限定6/26まで->Permanentに！
                if (main.S.octoMaxReachedLevel < 29)
                    confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Failure.";
                else if (main.S.BC4IEHoctobaddie30)
                    confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "You had already received.";
                else
                {
                    confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text += "10K Epic Coin, 3 Super Rebirth Ticket\n2 Instant, 1 Reset Rebirth Upgrade Ticket\n100K Monster Fluid";
                    main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.MonsterFluid] += 100000;
                    main.Log("Gained <color=green>Monster Fluid * 100K", 5f);
                    main.S.SuperRebirthNum += 3;
                    if (!main.S.boughtSuperRebirth)
                        main.S.boughtSuperRebirth = true;
                    main.S.InstantRebirthNum += 2;
                    if (!main.S.boughtInstantRebirth)
                        main.S.boughtInstantRebirth = true;
                    main.S.ResetRebirthUpgradeNum += 1;
                    if (!main.S.boughtResetRebirth)
                        main.S.boughtResetRebirth = true;
                    main.S.BC4IEHoctobaddie30 = true;
                }
                break;
            //case "IEHoctobaddie3"://期間限定6/26まで
            //    if (main.S.octoMaxReachedLevel < 2)
            //        confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Failure.";
            //    else if (main.S.BC5IEHoctobaddie3)
            //        confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "You had already received.";
            //    else
            //    {
            //        confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text += "2500 Epic Coin, 1 Super Rebirth Ticket\n1 Instant, 1 Reset Rebirth Upgrade Ticket\n50K Monster Fluid";
            //        main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.MonsterFluid] += 50000;
            //        main.Log("Gained <color=green>Monster Fluid * 50K", 5f);
            //        main.S.SuperRebirthNum += 1;
            //        if (!main.S.boughtSuperRebirth)
            //            main.S.boughtSuperRebirth = true;
            //        main.S.InstantRebirthNum += 1;
            //        if (!main.S.boughtInstantRebirth)
            //            main.S.boughtInstantRebirth = true;
            //        main.S.ResetRebirthUpgradeNum += 1;
            //        if (!main.S.boughtResetRebirth)
            //            main.S.boughtResetRebirth = true;
            //        main.S.BC5IEHoctobaddie3 = true;
            //    }
            //    break;
            //case "IEHoctobaddie1"://期間限定6/26まで
            //    if (main.S.octoMaxReachedLevel < 1)
            //        confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Failure.";
            //    else if (main.S.BC6IEHoctobaddie1)
            //        confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "You had already received.";
            //    else
            //    {
            //        confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text += "500 Epic Coin\n1 Reset Rebirth Upgrade Ticket\n5000 Monster Fluid";
            //        main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.MonsterFluid] += 50000;
            //        main.Log("Gained <color=green>Monster Fluid * 5000", 5f);
            //        main.S.ResetRebirthUpgradeNum += 1;
            //        if (!main.S.boughtResetRebirth)
            //            main.S.boughtResetRebirth = true;
            //        main.S.BC6IEHoctobaddie1 = true;
            //    }
            //    break;
            case "IEHhapiwakuJune":
                if (main.S.BC7IEHhapiwakuJune)
                    confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "You had already received.";
                else
                {
                    confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text += "500 Epic Coin\n500 Monster Fluid\n50 Red Chili";
                    main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.MonsterFluid] += 500;
                    main.Log("Gained <color=green>Monster Fluid * 500", 10f);
                    main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.RedChili] += 50;
                    main.Log("Gained <color=green>Red Chili * 50", 10f);
                    main.S.BC7IEHhapiwakuJune = true;
                }
                break;
            case "IEHhapiwakuJuly":
                if (main.S.BC8IEHhapiwakuJuly)
                    confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "You had already received.";
                else
                {
                    confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text += "700 Epic Coin\n700 Monster Fluid\n70 Red Chili";
                    main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.MonsterFluid] += 700;
                    main.Log("Gained <color=green>Monster Fluid * 700", 10f);
                    main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.RedChili] += 70;
                    main.Log("Gained <color=green>Red Chili * 70", 10f);
                    main.S.BC8IEHhapiwakuJuly = true;
                }
                break;
            case "IEHhapiwakuAugust":
                switch (main.platform)
                {
                    case Platform.kong:
                        if (main.S.BC9IEHhapiwakuAugustKong)
                            confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "You had already received.";
                        else
                        {
                            confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text += "1000 Epic Coin\n1000 Monster Fluid\n100 Red Chili";
                            main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.MonsterFluid] += 1000;
                            main.Log("Gained <color=green>Monster Fluid * 1000", 10f);
                            main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.RedChili] += 100;
                            main.Log("Gained <color=green>Red Chili * 100", 10f);
                            main.S.BC9IEHhapiwakuAugustKong = true;
                        }
                        break;
                    default:
                        if (main.S.BC9IEHhapiwakuAugustArmorGames)
                            confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "You had already received.";
                        else
                        {
                            confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text += "1000 Epic Coin\n1000 Monster Fluid\n100 Red Chili";
                            main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.MonsterFluid] += 1000;
                            main.Log("Gained <color=green>Monster Fluid * 1000", 10f);
                            main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.RedChili] += 100;
                            main.Log("Gained <color=green>Red Chili * 100", 10f);
                            main.S.BC9IEHhapiwakuAugustArmorGames = true;
                        }
                        break;
                }
                break;
            case "IEHhapiwakuSeptember":
                switch (main.platform)
                {
                    case Platform.kong:
                        if (main.S.BC10IEHhapiwakuSeptemberKong)
                            confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "You had already received.";
                        else
                        {
                            confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text += "1000 Epic Coin\n1000 Monster Fluid\n100 Red Chili";
                            main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.MonsterFluid] += 1000;
                            main.Log("Gained <color=green>Monster Fluid * 1000", 10f);
                            main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.RedChili] += 100;
                            main.Log("Gained <color=green>Red Chili * 100", 10f);
                            main.S.BC10IEHhapiwakuSeptemberKong = true;
                        }
                        break;
                    default:
                        if (main.S.BC10IEHhapiwakuSeptemberArmorGames)
                            confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "You had already received.";
                        else
                        {
                            confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text += "1000 Epic Coin\n1000 Monster Fluid\n100 Red Chili";
                            main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.MonsterFluid] += 1000;
                            main.Log("Gained <color=green>Monster Fluid * 1000", 10f);
                            main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.RedChili] += 100;
                            main.Log("Gained <color=green>Red Chili * 100", 10f);
                            main.S.BC10IEHhapiwakuSeptemberArmorGames = true;
                        }
                        break;
                }
                break;
            case "IEHhapiwakuOctober":
                switch (main.platform)
                {
                    case Platform.kong:
                        if (main.S.BC11IEHhapiwakuOctoberKong)
                            confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "You had already received.";
                        else
                        {
                            confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text += "1000 Epic Coin\n1 Super Rebirth Ticket\n1 Reset Spirit Upgrade Ticket";
                            main.S.SuperRebirthNum += 1;
                            if (!main.S.boughtSuperRebirth)
                                main.S.boughtSuperRebirth = true;
                            main.S.ResetReincarnationUpgradeNum += 1;
                            main.S.BC11IEHhapiwakuOctoberKong = true;
                        }
                        break;
                    default:
                        if (main.S.BC11IEHhapiwakuOctoberArmorGames)
                            confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "You had already received.";
                        else
                        {
                            confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text += "1000 Epic Coin\n1 Super Rebirth Ticket\n1 Reset Spirit Upgrade Ticket";
                            main.S.SuperRebirthNum += 1;
                            if (!main.S.boughtSuperRebirth)
                                main.S.boughtSuperRebirth = true;
                            main.S.ResetReincarnationUpgradeNum += 1;
                            main.S.BC11IEHhapiwakuOctoberKong = true;
                        }
                        break;
                }
                break;

            case "IEHsteam":
                if (main.S.BCSteam)
                    confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "You had already received.";
                else
                {
                    confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text += "1000 Epic Coin";
                    main.S.BCSteam = true;
                }
                break;
            case "IEHhapiwakuYC":
                if (main.S.BCYC)
                    confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "You had already received.";
                else if (main.S.isInstalledYC)
                {
                    confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text += "500 Epic Coin\n1 Super Rebirth Ticket";
                    main.S.SuperRebirthNum += 1;
                    if (!main.S.boughtSuperRebirth)
                        main.S.boughtSuperRebirth = true;
                    main.S.BCYC = true;
                }
                else
                {
                    confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "\n\nPlay \"Your Chronicle\" once and try again!";
                }
                break;
            case "IEHanniversary":
                if(main.S.BCanniversary)
                    confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "You had already received.";
                else
                {
                    confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text += "1000 Epic Coin\n3 Super Rebirth Ticket";
                    main.S.SuperRebirthNum += 3;
                    if (!main.S.boughtSuperRebirth)
                        main.S.boughtSuperRebirth = true;
                    main.S.BCanniversary = true;
                }
                break;
            
      //    case "IEHdebug1624test":
      //    confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text += "70000 EC\n1E100 Resources\n1E7 materials";
      //    foreach (ArtiCtrl.MaterialList material in Enum.GetValues(typeof(ArtiCtrl.MaterialList)))
      //    {
      //        main.ArtiCtrl.CurrentMaterial[material] += (int)1E07;
      //    }
      //    main.SR.stone += 1E300;
      //    main.SR.cristal += 1E300;
      //    main.SR.leaf += 1E300;
      //    main.S.ECforDebug += 1;
      //          for (int i = 0; i < main.skillsForCoolTime.Length; i++)
      //          {
      //              main.skillsForCoolTime[i].P_level += 300;
      //          }
      //        foreach (DUNGEON dungeon in main.dungeonAry)
      //        {
      //            dungeon.isDungeon = true;
      //        }
      //        for (int i = 0; i < main.SR.isDungeon.Length; i++)
      //        {
      //            main.SR.isDungeon[i] = true;
      //        }
      //        foreach (QUEST quest in main.QuestCtrl.Quests)
      //        {
      //            quest.isCleared = true;
      //        }
      //        main.S.isDistortionBeated = true;
      //        main.S.isMontblangoBeated = true;
      //        main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.montblango].clearedNum += 1;
      //        main.S.unleashBank = true;
      //        main.rein.ResetButton.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
      //        break;
      //case "IEHdebughs":
      //    confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text += "5 Heart Stone";
      //    main.S.RP += 15;
      //    if (!main.S.isMontblangoBeated)
      //    {
      //        main.TutorialController.ReincarnationButton.GetComponent<RectTransform>().anchoredPosition += new Vector2(400, 0);
      //        main.S.isMontblangoBeated = true;
      //    }
      //    main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.montblango].isCleared = true;
      //    break;
                        



            default:
                confirmWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Failure.";
                break;
        }
    }

        // Update is called once per frame
        void Update () {
		
	}
}
