using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using IdleLibrary;
using static IdleLibrary.UsefulMethod;
using static BASE;

public enum ExpeditionKind
{
    slime,
    bat,
    spider,
    fairy,
    fox,
    magicslime,
    devilfish,
    blob,
}
public partial class Save
{
    public ExpeditionForSave[] expedition;
}
public class ExpeditionLevel : ILevel
{
    public ILevel Level;
    public ExpeditionKind kind;
    public ExpeditionLevel(ILevel level, ExpeditionKind kind)
    {
        this.Level = level;
        this.kind = kind;
    }
    public long LevelCaptureNumFactor(ExpeditionKind kind)
    {
        long tempCaptureNum = 0;
        switch (kind)
        {
            case ExpeditionKind.slime:
                for (int i = 0; i < 7; i++)
                {
                    tempCaptureNum += main.ZoneCtrl.Slime[i].TotalEnemiesCaptured;
                }
                break;
            case ExpeditionKind.bat:
                for (int i = 0; i < main.ZoneCtrl.Bat.Length; i++)
                {
                    tempCaptureNum += main.ZoneCtrl.Bat[i].TotalEnemiesCaptured;
                }
                break;
            case ExpeditionKind.spider:
                for (int i = 0; i < main.ZoneCtrl.Spider.Length; i++)
                {
                    tempCaptureNum += main.ZoneCtrl.Spider[i].TotalEnemiesCaptured;
                }
                break;
            case ExpeditionKind.fairy:
                for (int i = 0; i < main.ZoneCtrl.Fairy.Length; i++)
                {
                    tempCaptureNum += main.ZoneCtrl.Fairy[i].TotalEnemiesCaptured;
                }
                break;
            case ExpeditionKind.fox:
                for (int i = 0; i < main.ZoneCtrl.Fox.Length; i++)
                {
                    tempCaptureNum += main.ZoneCtrl.Fox[i].TotalEnemiesCaptured;
                }
                break;
            case ExpeditionKind.magicslime:
                for (int i = 7; i < main.ZoneCtrl.Slime.Length; i++)
                {
                    tempCaptureNum += main.ZoneCtrl.Slime[i].TotalEnemiesCaptured;
                }
                break;
            case ExpeditionKind.devilfish:
                for (int i = 0; i < main.ZoneCtrl.DevilFish.Length; i++)
                {
                    tempCaptureNum += main.ZoneCtrl.DevilFish[i].TotalEnemiesCaptured;
                }
                break;
            case ExpeditionKind.blob:
                for (int i = 0; i < main.ZoneCtrl.Blob.Length; i++)
                {
                    tempCaptureNum += main.ZoneCtrl.Blob[i].TotalEnemiesCaptured;
                }
                break;
            default:
                break;
        }
        return (long)Math.Log10(1 + tempCaptureNum);
    }
    public long level { get => Level.level * LevelCaptureNumFactor(kind); set => throw new NotImplementedException(); }
}
public class EXPEDITION : BASE
{

    float[] initRequiredHours = new float[] { 0.5f, 1.0f, 2.0f, 4.0f, 8.0f, 24.0f };
    public float[] RequiredHours()
    {
        if (level == null)
            return initRequiredHours;
        float[] tempHours = initRequiredHours;
        for (int i = 0; i < tempHours.Length; i++)
        {
            tempHours[i] = Mathf.Floor(initRequiredHours[i] * Mathf.Max(0.5f, Mathf.Pow(0.99f, level.level)) * 10) / 10f;
        }
        return tempHours;
    }
    public ExpeditionKind kind;
    public Button startClaimButton, rightButton, leftButton;
    public TextMeshProUGUI levelText, startClaimText, requiredHourText, progressPercentText, rewardText;
    public Slider progressBar;
    public Expedition expedition;
    public ExpeditionLevel level;
    private void Awake()
    {
        expedition = new Expedition((int)kind, main.S.expedition, () => RequiredHours(), null, null);
        level = new ExpeditionLevel(expedition, kind);
        var cost = new LinearCost(10, 10, level);
        var transaction = new Transaction(new MaterialNumber(ArtiCtrl.MaterialList.SlimeKingCore), cost);
        expedition.SetTransaction(transaction);
    }
    public void LinkExpedition(Expedition expedition)
    {
        this.expedition = expedition;
    }

    public void UpdateUI()
    {
        UpdateStartClaimButton();
        UpdateProgress();
        UpdateRequiredHour();
        UpdateRightLeftButton();
        levelText.text = "<color=green>Lv " + tDigit(level.level) + "</color>";
    }
    void UpdateStartClaimButton()
    {
        if (expedition.IsStarted())
        {
            startClaimText.text = "Claim";
            startClaimButton.interactable = expedition.CanClaim();
        }
        else
        {
            startClaimText.text = "Start";
            startClaimButton.interactable = expedition.CanStart();
        }
    }
    void UpdateRightLeftButton()
    {
        rightButton.interactable = !expedition.IsStarted();
        leftButton.interactable = !expedition.IsStarted();
    }
    void UpdateProgress()
    {
        progressPercentText.text = DoubleTimeToDate(expedition.CurrentTimesec()) + " ( " + percent(expedition.ProgressPercent()) + " )";
        progressBar.value = expedition.ProgressPercent();
    }
    void UpdateRequiredHour()
    {
        requiredHourText.text = expedition.RequiredTime(false).ToString("F1") + " h";
    }
    void SwitchRequiredHour(bool isRight)
    {
        expedition.SwitchRequiredHour(isRight);
    }

    // Start is called before the first frame update
    void Start()
    {
        startClaimButton.onClick.AddListener(() => { expedition.StartOrClaim(); });
        rightButton.onClick.AddListener(() => SwitchRequiredHour(true));
        leftButton.onClick.AddListener(() => SwitchRequiredHour(false));
    }
}

