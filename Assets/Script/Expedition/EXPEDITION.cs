using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using TMPro;
using System;
using IdleLibrary;
using static IdleLibrary.UsefulMethod;
using static UsefulMethod;
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
public partial class SaveO
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
        return (long)Math.Log10(Math.Max(1, tempCaptureNum));
    }
    public long level { get => Level.level * LevelCaptureNumFactor(kind); set => throw new NotImplementedException(); }
}
public class EXPEDITION : BASE
{
    public ExpeditionKind kind;
    float[] requiredHours = new float[] { 0.001f, 1.0f, 2.0f, 4.0f, 8.0f, 24.0f };
    [NonSerialized] public Canvas thisCanvas;
    public Button startClaimButton, rightButton, leftButton;
    public TextMeshProUGUI nameText, startClaimText, requiredHourText, progressPercentText, bonusText, rewardText;
    public Slider progressBar;
    public Expedition expedition;
    public ExpeditionLevel level;
    public Image monsterImage;
    private void Awake()
    {
        expedition = new Expedition((int)kind, main.SO.expedition, null, new ArtifactReward(), requiredHours);
        level = new ExpeditionLevel(expedition, kind);
        //var cost = new LinearCost(10, 10, level);
        //var transaction = new Transaction(new MaterialNumber(ArtiCtrl.MaterialList.BlackPearl), cost);
        expedition.SetReward(()=>ChestLotteryNum(expedition.hourId), new float[3] { Tier1chestChance(level, expedition.hourId), Tier2chestChance(level, expedition.hourId), Tier3chestChance(level, expedition.hourId)});
        expedition.SetTransaction(new NullTransaction());
        expedition.SetTimeSpeedFactor(TimeSpeedFactor);
        thisCanvas = gameObject.GetComponent<Canvas>();
    }
    public void LinkExpedition(Expedition expedition)
    {
        this.expedition = expedition;
    }
    public float TimeSpeedFactor()
    {
        if (level == null) return 1;
        return Math.Min(5, 1f + 0.01f * level.level);
    }
    public void UpdateUI()
    {
        UpdateStartClaimButton();
        UpdateProgress();
        UpdateRequiredHour();
        UpdateRightLeftButton();
        nameText.text = optStr + NameString() + "  < <color=green>Lv " + UsefulMethod.tDigit(level.level) + "</color> >";
        bonusText.text = optStr + "Speed Bonus : <color=green>x " + UsefulMethod.tDigit(TimeSpeedFactor(), 2) + "</color>";
        rewardText.text = RewardString(level, expedition.hourId);
    }
    public float Tier1chestChance(ILevel level, int hourId)
    {
        return 1 - (Tier2chestChance(level, hourId) + Tier3chestChance(level, hourId));
    }
    public float Tier2chestChance(ILevel level, int hourId)
    {
        return 0.09f + Mathf.Clamp(0.0002f * level.level * (1 + hourId), 0, 0.5f);
    }
    public float Tier3chestChance(ILevel level, int hourId)
    {
        return 0.01f + Tier2chestChance(level, hourId) / 2f;
    }
    public int ChestLotteryNum(int hourId)
    {
        int tempNum = 0;
        switch (hourId)
        {
            case 0: tempNum = 3; break;
            case 1: tempNum = 5; break;
            case 2: tempNum = 8; break;
            case 3: tempNum = 15; break;
            case 4: tempNum = 28; break;
            case 5: tempNum = 50; break;
        }
        return tempNum;
    }
    public string RewardString(ILevel level, int hourId)
    {
        return UsefulMethod.optStr + "Chest x " + UsefulMethod.tDigit(ChestLotteryNum(hourId))
        + "   ( <sprite=\"chests\" index=0> " + UsefulMethod.percent(Tier1chestChance(level, hourId), 1)
            + "   " + "<sprite=\"chests\" index=1> " + UsefulMethod.percent(Tier2chestChance(level, hourId), 1)
            + "   " + "<sprite=\"chests\" index=2> " + UsefulMethod.percent(Tier3chestChance(level, hourId), 1)
            + " )";
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
        progressPercentText.text = optStr + expedition.LeftTimesecString() + " (" + UsefulMethod.percent(expedition.ProgressPercent()) + ")";
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
    string NameString()
    {
        switch (kind)
        {
            case ExpeditionKind.slime:
                return "Slime";
            case ExpeditionKind.bat:
                return "Bat";
            case ExpeditionKind.spider:
                return "Spider";
            case ExpeditionKind.fairy:
                return "Fairy";
            case ExpeditionKind.fox:
                return "Fox";
            case ExpeditionKind.magicslime:
                return "Magic Slime";
            case ExpeditionKind.devilfish:
                return "Devil Fish";
            case ExpeditionKind.blob:
                return "Blob";
            default:
                return "Slime";
        }
    }
    async void ChangeSprite()
    {
        monsterImage.sprite = main.expeditionCtrl.monsterSprites1[(int)kind];
        while (true)
        {
            if (expedition.IsStarted())
            {
                monsterImage.sprite = main.expeditionCtrl.monsterSprites1[(int)kind];
                await UniTask.Delay(1000);
                monsterImage.sprite = main.expeditionCtrl.monsterSprites2[(int)kind];
            }
            await UniTask.Delay(1000);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        startClaimButton.onClick.AddListener(() => { expedition.StartOrClaim(); });
        rightButton.onClick.AddListener(() => SwitchRequiredHour(true));
        leftButton.onClick.AddListener(() => SwitchRequiredHour(false));
        ChangeSprite();
    }
}

