using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using static UsefulMethod;
using static ACHIEVEMENT.QuestList;
using static ArtiCtrl.MaterialList;

public class IdleBackGround : POPTEXT_GoldBar,IPointerDownHandler {

    public Transform[] SliderCanvas;
    public GameObject[] textPrefab;
    long tempStoneClickNum;
    long tempCristalClickNum;
    long tempLeafClickNum;
    int StoneSliderLevel { get => main.SR.StoneSliderLevel; set => main.SR.StoneSliderLevel = value; }
    int CristalSliderLevel { get => main.SR.CristalSliderLevel; set => main.SR.CristalSliderLevel = value; }
    int LeafSliderLevel { get => main.SR.LeafSliderLevel; set => main.SR.LeafSliderLevel = value; }
    double ReqExp(int level)
    {
        //こっちが本リリース版！！！ 
        return 100 * (level) + 100 * Math.Pow(1.025, level);
        //return 100 + (level) + 100 * Math.Pow(1.5, level);
    }

    // Use this for initialization
    void Awake()
    {
        awakeText();
    }

    // Use this for initialization
    void Start()
    {
        startText();
        //StoneSlider = gameObject.GetComponentsInChildren<Slider>()[0];
        //CristalSlider = gameObject.GetComponentsInChildren<Slider>()[1];
        //LeafSlider = gameObject.GetComponentsInChildren<Slider>()[2];
        //Instantiate(main.Particles[0], main.Transforms[4]);
        // StartCoroutine(InstantiateParticleStone());
        // StartCoroutine(InstantiateParticleCristal());
        //StartCoroutine(InstantiateParticleLeaf());
        StartCoroutine(GetOfflineBonus());
        StartCoroutine(CalculateStone());
        StartCoroutine(CalculateCrystal());
        StartCoroutine(CalculateLeaf());
        StartCoroutine(GetResourceByIdle());
        StartCoroutine(GetResourceByIdleAnimation());
    }
    public IEnumerator GetOfflineBonus(float time = 0)
    {
        float showTime = 10.0f;
        string tempDateTime = main.S.lastTime;
        yield return new WaitUntil(() => TitleCtrl.isLoaded && TitleCtrl.isOpenedGame);
        float factor = time == 0 ? DeltaTimeFloat(DateTime.FromBinary(Convert.ToInt64(tempDateTime))) : time;
        if (factor < 60f)//オフライン時間が60秒以内だったらなし
            OfflineBonus(factor, showTime);
    }
    public void OfflineBonus(float factor = 0, float showTime = 10.0f)
    {
        string tempStr = optStr + "<size=16><color=orange>OFFLINE BONUS</color>";
        tempStr += "\n<size=14>You left for <color=green>" + DoubleTimeToDate(factor) + "</color>";
        tempStr += "\n\n<size=12>" + "<color=green>Stone + " + tDigit(factor * IdleDPS(M_UPGRADE.Attribute.stone));
        tempStr += "\n" + "<color=green>Crystal + " + tDigit(factor * IdleDPS(M_UPGRADE.Attribute.crystal));
        tempStr += "\n" + "<color=green>Leaf + " + tDigit(factor * IdleDPS(M_UPGRADE.Attribute.leaf));
        tempStr += "\n<color=green>Nitro + " + tDigit(factor * 0.25f);
        tempStr += "\n<color=green>Gem Progress + " + DoubleTimeToDate(factor);
        main.Log("<color=orange>OFFLINE BONUS", showTime);
        main.Log("You left for <color=red>" + DoubleTimeToDate(factor) + "</color>", showTime);
        main.SR.stone += factor * IdleDPS(M_UPGRADE.Attribute.stone);
        main.Log("<color=green>Stone + " + tDigit(factor * IdleDPS(M_UPGRADE.Attribute.stone)), showTime);
        main.SR.cristal += factor * IdleDPS(M_UPGRADE.Attribute.crystal);
        main.Log("<color=green>Crystal + " + tDigit(factor * IdleDPS(M_UPGRADE.Attribute.crystal)), showTime);
        main.SR.leaf += factor * IdleDPS(M_UPGRADE.Attribute.leaf);
        main.Log("<color=green>Leaf + " + tDigit(factor * IdleDPS(M_UPGRADE.Attribute.leaf)), showTime);
        main.S.CurrentNitro += factor * 0.25f;
        main.Log("<color=red>Nitro + " + tDigit(factor * 0.25f), showTime);
        main.expeditionCtrl.OfflineBonus(factor);
        foreach (JEM jem in main.jems)
        {
            if (jem.CurrentWorkerNum == 0)
                continue;
            jem.CurrentExp += main.DRctrl.WorkerPower() * jem.CurrentWorkerNum * factor;
            main.Log("<color=green>" + jem.gameObject.name + "EXP + " + tDigit(main.DRctrl.WorkerPower() * jem.CurrentWorkerNum * factor), showTime);
        }
        main.Confirm(tempStr);
    }

    public double StoneCombo()
    {
        return Math.Min(1 + 0.01 * tempStoneClickNum,6);
    }
    public double CristalCombo()
    {
        return Math.Min(1 + 0.01 * tempCristalClickNum,6);
    }
    public double LeafCombo()
    {
        return Math.Min(1 + 0.01 * tempLeafClickNum,6);
    }

    //float mousePosX;
    // Update is called once per frame
    void Update()
    {
        updateText();

        if (main.SR.stone > 1e306)
            main.SR.stone = 1e306d;
        if (main.SR.cristal > 1e306)
            main.SR.cristal = 1e306d;
        if (main.SR.leaf > 1e306)
            main.SR.leaf = 1e306d;

        if (main.GameController.currentCanvas == main.GameController.IdleCanvas)
        {
            //mousePosX = Input.mousePosition.x - (main.screenCanvas.GetComponent<RectTransform>().sizeDelta.x - main.mainCanvas.GetComponent<RectTransform>().sizeDelta.x) / 2;
            if (Input.mousePosition.x / (Screen.height / 600f) <= (float)350 / 3)
            {
                clickMode = ClickMode.stone;
            }
            else if (Input.mousePosition.x / (Screen.height / 600f) <= (float)350 / 3 * 2)
            {
                clickMode = ClickMode.cristal;
            }
            else
            {
                clickMode = ClickMode.leaf;
            }

            main.Texts[6].text = tDigit(S_ClickDPS(), 1) + " / click" + "\n" + tDigit(IdleDPS(M_UPGRADE.Attribute.stone), 1) + " / s";
            main.Texts[7].text = tDigit(C_ClickDPS(), 1) + " / click" + "\n" + tDigit(IdleDPS(M_UPGRADE.Attribute.crystal), 1) + " / s";
            main.Texts[8].text = tDigit(L_ClickDPS(), 1) + " / click" + "\n" + tDigit(IdleDPS(M_UPGRADE.Attribute.leaf), 1) + " / s";

            StoneSlider.value = (float)(main.SR.stoneExp / ReqExp(main.SR.stoneGoldLevel));
            CristalSlider.value = (float)(main.SR.crystalExp / ReqExp(main.SR.crystalGoldLevel));
            LeafSlider.value = (float)(main.SR.leafExp / ReqExp(main.SR.leafGoldLevel));

            if (window.activeSelf||window2.activeSelf||window3.activeSelf)
            {
                levelString[0] = "Stone Gold Cap < <color=green>Lv " + main.SR.stoneGoldLevel + "</color> >";
                levelString[1] = "Crystal Gold Cap < <color=green>Lv " + main.SR.crystalGoldLevel + "</color> >";
                levelString[2] = "Leaf Gold Cap < <color=green>Lv " + main.SR.leafGoldLevel + "</color> >";

                if (main.SR.stoneExp >= ReqExp(main.SR.stoneGoldLevel))
                    ExpString[0] = "EXP : " + tDigit(ReqExp(main.SR.stoneGoldLevel)) + " / " + tDigit(ReqExp(main.SR.stoneGoldLevel));
                else
                    ExpString[0] = "EXP : " + tDigit(main.SR.stoneExp) + " / " + tDigit(ReqExp(main.SR.stoneGoldLevel));
                if (main.SR.crystalExp >= ReqExp(main.SR.crystalGoldLevel))
                    ExpString[1] = "EXP : " + tDigit(ReqExp(main.SR.crystalGoldLevel)) + " / " + tDigit(ReqExp(main.SR.crystalGoldLevel));
                else
                    ExpString[1] = "EXP : " + tDigit(main.SR.crystalExp) + " / " + tDigit(ReqExp(main.SR.crystalGoldLevel));
                if (main.SR.leafExp >= ReqExp(main.SR.leafGoldLevel))
                    ExpString[2] = "EXP : " + tDigit(ReqExp(main.SR.leafGoldLevel)) + " / " + tDigit(ReqExp(main.SR.leafGoldLevel));
                else
                    ExpString[2] = "EXP : " + tDigit(main.SR.leafExp) + " / " + tDigit(ReqExp(main.SR.leafGoldLevel));

            }

        }
    }
    bool IsShow()
    {
        return main.GameController.currentCanvas == main.GameController.IdleCanvas;
    }

    public IEnumerator CalculateStone()
    {
        while (true)
        {
            yield return new WaitUntil(() => main.SR.stoneExp >= ReqExp(main.SR.stoneGoldLevel));
            main.SR.stoneExp -= ReqExp(main.SR.stoneGoldLevel);
            main.SR.stoneGoldLevel++;
            main.SR.gold += 1 * main.Ascends[0].calculateCurrentValue();
            if (IsShow())
                StartCoroutine(InstantiateGoldCapText(1, 1));
            yield return new WaitForSeconds(0.1f);
        }
    }
    public IEnumerator CalculateCrystal()
    {
        while (true)
        {
            yield return new WaitUntil(() => main.SR.crystalExp >= ReqExp(main.SR.crystalGoldLevel));
            main.SR.crystalExp -= ReqExp(main.SR.crystalGoldLevel);
            main.SR.crystalGoldLevel++;
            main.SR.gold += 1 * main.Ascends[5].calculateCurrentValue();
            if (IsShow())
                StartCoroutine(InstantiateGoldCapText(2, 1));
            yield return new WaitForSeconds(0.1f);
        }
    }

    public IEnumerator CalculateLeaf()
    {
        while (true)
        {
            yield return new WaitUntil(() => main.SR.leafExp >= ReqExp(main.SR.leafGoldLevel));
            main.SR.leafExp -= ReqExp(main.SR.leafGoldLevel);
            main.SR.leafGoldLevel++;
            main.SR.gold += 1 * main.Ascends[10].calculateCurrentValue();
            if (IsShow())
                StartCoroutine(InstantiateGoldCapText(3, 1));
            yield return new WaitForSeconds(0.1f);
        }
    }
    public IEnumerator InstantiateGoldCapText(int num, double capUp=1)
    {
        switch (num)
        {
            case 1:
                GameObject StoneGoldText;
                StoneGoldText = Instantiate(textPrefab[0], SliderCanvas[0]);
                StoneGoldText.GetComponent<TextMeshProUGUI>().color += new Color(0, 0, 0, 1f);
                StoneGoldText.GetComponent<TextMeshProUGUI>().text = "Gold Cap + " + capUp * main.Ascends[0].calculateCurrentValue();
                for (int i = 0; i < 25; i++)
                {
                    StoneGoldText.GetComponent<TextMeshProUGUI>().color += new Color(0, 0, 0, -0.04f);
                    StoneGoldText.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 1f);
                    yield return new WaitForSeconds(0.020f);
                }
                Destroy(StoneGoldText);
                break;
            case 2:
                GameObject CrystalGoldText;
                CrystalGoldText = Instantiate(textPrefab[1], SliderCanvas[1]);
                CrystalGoldText.GetComponent<TextMeshProUGUI>().color += new Color(0, 0, 0, 1f);
                CrystalGoldText.GetComponent<TextMeshProUGUI>().text = "Gold Cap + " + capUp * main.Ascends[5].calculateCurrentValue();
                for (int i = 0; i < 25; i++)
                {
                    CrystalGoldText.GetComponent<TextMeshProUGUI>().color += new Color(0, 0, 0, -0.04f);
                    CrystalGoldText.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 1f);
                    yield return new WaitForSeconds(0.020f);
                }
                Destroy(CrystalGoldText);
                break;
            case 3:
                GameObject LeafGoldText;
                LeafGoldText = Instantiate(textPrefab[2], SliderCanvas[2]);
                LeafGoldText.GetComponent<TextMeshProUGUI>().color += new Color(0, 0, 0, 1f);
                LeafGoldText.GetComponent<TextMeshProUGUI>().text = "Gold Cap + " + capUp * main.Ascends[10].calculateCurrentValue();
                for (int i = 0; i < 25; i++)
                {
                    LeafGoldText.GetComponent<TextMeshProUGUI>().color += new Color(0, 0, 0, -0.04f);
                    LeafGoldText.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 1f);
                    yield return new WaitForSeconds(0.020f);
                }
                Destroy(LeafGoldText);
                break;
            default:
                break;
        }
    }

    //このクラスで，リソースをクリックしたときの処理を行います．
    public enum ClickMode
    {
        stone,
        cristal,
        leaf
    }
    public ClickMode clickMode;
    public void OnPointerDown(PointerEventData eventData)
    {
        switch (clickMode)
        {
            case ClickMode.stone:
                GetStone();
                break;
            case ClickMode.cristal:
                GetCristal();
                break;
            case ClickMode.leaf:
                GetLeaf();
                break;
            default:
                break;
                
        }
    }
    public bool isDarkRitual;
    public bool isBank;
    public void InstantiateResource(int i)
    {
        GameObject particle = Instantiate(main.Particles[i], main.Transforms[4]);
        particle.GetComponent<RectTransform>().anchoredPosition += Vector2.right * 117f * i;
        //particle.GetComponent<RectTransform>().anchoredPosition += new Vector2(58.5f + 117f * i, 300f);
        //particle.GetComponent<RectTransform>().anchoredPosition = (Input.mousePosition / (Screen.height / 600));
    }
    public void InstantiateResourceIdle(int i)
    {
        GameObject particle = Instantiate(main.Particles[i], main.Transforms[4]);
        particle.GetComponent<RectTransform>().anchoredPosition += Vector2.right * 117f * i;
    }


    public void GetStone()
    {
        tempLeafClickNum = Math.Max(tempLeafClickNum - 1, 0);
        tempCristalClickNum = Math.Max(tempCristalClickNum - 1, 0);
        main.SR.stone += S_ClickDPS();
        main.SR.stoneExp += S_ClickDPS();
        main.S.totalGetStone += S_ClickDPS();
        InstantiateResource(0);
        main.S.totalClickNum++;
        tempStoneClickNum = Math.Min(tempStoneClickNum + 1, 600);
    }
    public void GetCristal()
    {
        tempLeafClickNum = Math.Max(tempLeafClickNum - 1, 0);
        tempStoneClickNum = Math.Max(tempStoneClickNum - 1, 0);
        main.SR.cristal += C_ClickDPS();
        main.SR.crystalExp += C_ClickDPS() ;
        main.S.totalGetCrystal += C_ClickDPS();
        InstantiateResource(1);
        main.S.totalClickNum++;
        tempCristalClickNum = Math.Min(tempCristalClickNum + 1, 600);
        //CristalExp++;
        //CristalSlider.value = (float)(cristalExp / ReqExp(CristalSliderLevel));
        //if (CristalSlider.value >= 1)
        //{
        //    CristalSliderLevel++;
        //    cristalExp = 0;
        //}
    }
    public void GetLeaf()
    {
        tempStoneClickNum = Math.Max(tempStoneClickNum - 1, 0);
        tempCristalClickNum = Math.Max(tempCristalClickNum - 1, 0);
        main.SR.leaf += L_ClickDPS();
        main.SR.leafExp += L_ClickDPS();
        main.S.totalGetLeaf += L_ClickDPS();
        InstantiateResource(2);
        main.S.totalClickNum++;
        tempLeafClickNum = Math.Min(tempLeafClickNum + 1, 600);
        //Purse
        if (main.quests[(int)PetheticMan].isSeen[0] && !main.S.isPurse && UnityEngine.Random.Range(0,10000) < 2000)
        {
            main.ArtiCtrl.CurrentMaterial[ShabbyPurse] += 1;
            StartCoroutine(InstantiateText("Shabby Purse + 1"));
            main.sound.MustPlaySound(main.sound.levelUpClip);
            main.S.isPurse = true;
        }
    }

    public IEnumerator InstantiateText(string text)
    {
        GameObject StoneGoldText;
        StoneGoldText = Instantiate(textPrefab[0], SliderCanvas[2]);
        StoneGoldText.GetComponent<TextMeshProUGUI>().color += new Color(0, 0, 0, 1f);
        StoneGoldText.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 30);
        StoneGoldText.GetComponent<TextMeshProUGUI>().text = text;
        for (int i = 0; i < 25; i++)
        {
            StoneGoldText.GetComponent<TextMeshProUGUI>().color += new Color(0, 0, 0, -0.04f);
            StoneGoldText.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 1f);
            yield return new WaitForSeconds(0.020f);
        }
        Destroy(StoneGoldText);
    }

    public int TotalUpgradeLevel()
    {
        int totalLevel = 0;
        foreach(M_UPGRADE upgrade in main.StoneUpgrade)
        {
            totalLevel += upgrade.level;
        }
        foreach (M_UPGRADE upgrade in main.CristalUpgrade)
        {
            totalLevel += upgrade.level;
        }
        foreach (M_UPGRADE upgrade in main.LeafUpgrade)
        {
            totalLevel += upgrade.level;
        }
        return totalLevel;
    }

    public int TotalStoneLevel()
    {
        int totalLevel = 0;
        foreach (M_UPGRADE upgrade in main.StoneUpgrade)
        {
            totalLevel += upgrade.level;
        }
        return totalLevel;
    }

    public int TotalCristalLevel()
    {
        int totalLevel = 0;
        foreach (M_UPGRADE upgrade in main.CristalUpgrade)
        {
            totalLevel += upgrade.level;
        }
        return totalLevel;
    }

    public int TotalLeafLevel()
    {
        int totalLevel = 0;
        foreach (M_UPGRADE upgrade in main.LeafUpgrade)
        {
            totalLevel += upgrade.level;
        }
        return totalLevel;
    }

    public double stoneAlchemyFactor;
    public double crystalAlchemyFactor;
    public double leafAlchemyFactor;
    double CommonFactor()
    {
        return (1 + main.MissionMileStone.ResourceBonus())
            * Math.Max(main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.Trainer].GetCurrentValue(), 1)
            * (1 + ArtifactBonus.RESOURCE)
            ;
    }
    double S_factor()
    {
        return (1 + main.ArtifactFactor.Stone())
            * (1 + main.SR.R_stone) *
            (main.Ascends[1].calculateCurrentValue() *
            (1 + main.keyf.M_stone))
            * (1 + stoneAlchemyFactor)
            * SumMulDelegate(main.cc.cf.Stone1000)
            * CommonFactor();
    }
    double C_factor()
    {
        return (1 + main.ArtifactFactor.Crystal())
            * (1 + main.SR.R_crystal) 
            * (main.Ascends[6].calculateCurrentValue()
            * (1 + main.keyf.M_crystal))
            * (1 + crystalAlchemyFactor)
            * SumMulDelegate(main.cc.cf.Crystal1000)
            * CommonFactor();
    }
    double L_factor()
    {
        return (1 + main.ArtifactFactor.Leaf()) 
            * (1 + main.SR.R_leaf) 
            * (main.Ascends[11].calculateCurrentValue() 
            * (1 + main.keyf.M_leaf)) 
            * (1 + leafAlchemyFactor)
            * SumMulDelegate(main.cc.cf.Leaf1000)
            * CommonFactor();
    }
    public double IdleDPS(M_UPGRADE.Attribute attribute)
    {
        double DPS = 0;
        switch (attribute)
        {
            case M_UPGRADE.Attribute.stone:
                foreach (M_UPGRADE upgrade in main.StoneUpgrade)
                {
                    DPS += upgrade.DPS();
                }
                //CurseProficiency
                DPS = Curse_proficiency.LOG(DPS * S_factor());
                break;
            case M_UPGRADE.Attribute.crystal:
                foreach (M_UPGRADE upgrade in main.CristalUpgrade)
                {
                    DPS += upgrade.DPS();
                }
                DPS = Curse_proficiency.LOG(DPS * C_factor());
                break;
            case M_UPGRADE.Attribute.leaf:
                foreach (M_UPGRADE upgrade in main.LeafUpgrade)
                {
                    DPS += upgrade.DPS();
                }
                DPS = Curse_proficiency.LOG(DPS * L_factor());
                break;
            default:
                break;
        }
        DPS = Math.Min(DPS, 1e305);
        return DPS;
    }
  //  public double S_IdleDPS()
  //  {
  //      double DPS = 0;
  //      foreach(M_UPGRADE upgrade in main.StoneUpgrade)
  //      {
  //          DPS += upgrade.DPS() * (main.Ascends[1].calculateCurrentValue());
  //      }
  //      return DPS * (1 + main.ArtifactFactor.Stone()) * (1 + main.SR.R_stone);
  //  }
    public double IdleNextDPS(M_UPGRADE targetUpgrade)
    {
        //int tempLevel = targetUpgrade.level;
        double ans = 0;
        double dps = 0;
        int levelIncrement = 0;
        bool whenMaxAndLevelZero = false;

        switch (main.SR.buyMode)
        {

            case UPGRADE.buyMode.mode1:
                targetUpgrade.level++;
                levelIncrement = 1;
                ans = targetUpgrade.calculateCurrentValue(targetUpgrade.level);
                break;
            case UPGRADE.buyMode.mode10:
                targetUpgrade.level+=10;
                levelIncrement = 10;
                ans = targetUpgrade.calculateCurrentValue(targetUpgrade.level);
                break;
            case UPGRADE.buyMode.mode25:
                targetUpgrade.level+=25;
                levelIncrement = 25;
                ans = targetUpgrade.calculateCurrentValue(targetUpgrade.level);
                break;
            case UPGRADE.buyMode.modeMax:
                if (targetUpgrade.canBuy())
                {
                    levelIncrement = targetUpgrade.calculateMaxSumCost(targetUpgrade.level).z;
                    targetUpgrade.level += levelIncrement;
                }
                else
                {
                    targetUpgrade.level += 1;
                    levelIncrement = 1;
                }
                // if (levelIncrement == 0)
                // {
                //     whenMaxAndLevelZero = true;
                //     levelIncrement = 1;
                // }
                ans = targetUpgrade.calculateCurrentValue(targetUpgrade.level);
                break;
            default:
                break;
        }

        M_UPGRADE[] tempUpgrades;
        switch (targetUpgrade.thisAttribute)
        {
            case M_UPGRADE.Attribute.stone:
                tempUpgrades = main.StoneUpgrade;
                break;
            case M_UPGRADE.Attribute.crystal:
                tempUpgrades = main.CristalUpgrade;
                break;
            case M_UPGRADE.Attribute.leaf:
                tempUpgrades = main.LeafUpgrade;
                break;
            default:
                return 0;
        }

        foreach (M_UPGRADE upgrade in tempUpgrades)
        {
            dps += upgrade.DPS();
        }
       // if (!whenMaxAndLevelZero)
       // {
            targetUpgrade.level -= levelIncrement;
        // }
        switch (targetUpgrade.thisAttribute)
        {
            case M_UPGRADE.Attribute.stone:
                return Curse_proficiency.LOG(dps * S_factor());
            case M_UPGRADE.Attribute.crystal:
                return Curse_proficiency.LOG(dps * C_factor());
            case M_UPGRADE.Attribute.leaf:
                return Curse_proficiency.LOG(dps * L_factor());
        }
        //return IdleDPS(targetUpgrade.thisAttribute);
        return 0;
    }
    public double C_ClickDPS()
    {
        return Curse_proficiency.LOG(main.CristalUpgrade[0].calculateCurrentValue() * C_factor());
    }

    public double L_ClickDPS()
    {
        return Curse_proficiency.LOG(main.LeafUpgrade[0].calculateCurrentValue() * L_factor());
    }

    public double S_ClickDPS()
    {
        return Curse_proficiency.LOG(main.StoneUpgrade[0].calculateCurrentValue() * S_factor());
    }

    public IEnumerator GetResourceByIdle()
    {
        while (true)
        {
            if (main.rein.isStartedRein || main.jobChange.isStartedRebirth)
            {
                break;
            }
            double getStone = Math.Min(IdleDPS(M_UPGRADE.Attribute.stone) * 0.05d, 1e305);
            main.SR.stone += getStone;
            main.S.totalGetStone += getStone;
            main.SR.stoneExp += getStone;

            double getCristal = Math.Min(IdleDPS( M_UPGRADE.Attribute.crystal) * 0.05, 1e305);
            main.SR.cristal += getCristal;
            main.S.totalGetCrystal += getCristal;
            main.SR.crystalExp += getCristal;

            double getLeaf = Math.Min(IdleDPS(M_UPGRADE.Attribute.leaf) * 0.05, 1e305);
            main.SR.leaf += getLeaf;
            main.S.totalGetLeaf += getLeaf;
            main.SR.leafExp += getLeaf;
            yield return new WaitForSeconds(0.05f);
        }
    }
    public IEnumerator GetResourceByIdleAnimation()
    {
        while (true)
        {
            yield return new WaitUntil(() => main.GameController.currentCanvas == main.GameController.IdleCanvas);
            if (IdleDPS( M_UPGRADE.Attribute.stone) != 0)
            {
                for (int i = 0; i < Math.Min(Math.Log10(1+IdleDPS( M_UPGRADE.Attribute.stone)),3); i++)
                {
                    InstantiateResourceIdle(0);
                }
            }
            if (IdleDPS( M_UPGRADE.Attribute.crystal) != 0)
            {
                for (int i = 0; i < Math.Min(Math.Log10(1 + IdleDPS( M_UPGRADE.Attribute.crystal)), 3); i++)
                {
                    InstantiateResourceIdle(1);
                }
            }
            if (IdleDPS( M_UPGRADE.Attribute.leaf) != 0)
            {
                for (int i = 0; i < Math.Min(Math.Log10(1 + IdleDPS( M_UPGRADE.Attribute.leaf)), 3); i++)
                {
                    InstantiateResourceIdle(2);
                }
            }
            yield return new WaitForSeconds(1f);
        }
    }

}
