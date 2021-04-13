using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;
using System.Text;

public class BESTIARY : BASE {

    public GameObject Monsters;
    public GameObject BestiaryCanvas;
    public Transform SlimeCanvas;
    public Sprite hatena;
    public TextMeshProUGUI enemyName;
    public Image enemyImage;
    public TextMeshProUGUI TotallKilledNum;
    public TextMeshProUGUI TotalCapturedText;
    public TextMeshProUGUI DropRateBonusText;
    public TextMeshProUGUI DropRateText2;
    public TextMeshProUGUI DropRateText;
    public Button closeButton;
    public Button openButton;
    public GameObject[] enemies;
    public TextMeshProUGUI[] MileStoneText;
    public TextMeshProUGUI[] KilledNumText;
    public Slider LootSlider;
    public Button LootButton;
    public Button AllLootButton;
    public TextMeshProUGUI timeToLoot;
    public TextMeshProUGUI HistoryText;
    public Info currentInfo;

    public ENEMY[] Slimes;
    public ENEMY[] Bats;
    public ENEMY[] Spiders;
    public ENEMY[] Fairies;
    public ENEMY[] Foxes;
    public ENEMY[] DevilFish;
    public ENEMY[] Blob;
    public Action Loot;
    public List<Info> InfoList;

    public Sprite[] enemySprite0;
    public Sprite[] enemySprite1;

    public ArtiCtrl.MaterialList ChooseRandomMaterial()
    {
        List<ArtiCtrl.MaterialList> availableList = new List<ArtiCtrl.MaterialList>();
        foreach(Info info in InfoList)
        {
            if (main.S.ReincarnationNum > 0)
            {
                if (main.S.totalEnemiesKilled[(int)info.thisEnemyKind] > 0)
                {
                    availableList.Add(main.dropInfo.RandomChooseMaterial(info.thisEnemyKind));
                }
            }
            else
            {
                if (main.S.totalEnemiesKilledAfterReincarnation[(int)info.thisEnemyKind] > 0)
                {
                    availableList.Add(main.dropInfo.RandomChooseMaterial(info.thisEnemyKind));
                }

            }
        }

        if (availableList.Count == 0)
            return ArtiCtrl.MaterialList.MonsterFluid;

        int randomNum = UnityEngine.Random.Range(0, availableList.Count);
        return availableList[randomNum];
  
    }

    public void Open()
    {
        BestiaryCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(-1000,0);
        main.GameController.SetAllImageAndText(BestiaryCanvas, true);
        currentInfo.SetInfo();
    }
    public void Close()
    {
        BestiaryCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(1000,0);
        main.GameController.SetAllImageAndText(BestiaryCanvas, false);
    }
	// Use this for initialization
	void Awake () {
		StartBASE();
        closeButton.onClick.AddListener(Close);
        openButton.onClick.AddListener(Open);
        Slimes = InstantiateTempEnemy(main.ZoneCtrl.Slime);
        Bats = InstantiateTempEnemy(main.ZoneCtrl.Bat);
        Spiders = InstantiateTempEnemy(main.ZoneCtrl.Spider);
        Fairies = InstantiateTempEnemy(main.ZoneCtrl.Fairy);
        Foxes = InstantiateTempEnemy(main.ZoneCtrl.Fox);
        DevilFish = InstantiateTempEnemy(main.ZoneCtrl.DevilFish);
        Blob = InstantiateTempEnemy(main.ZoneCtrl.Blob);
        enemies = InstantiateSlime();
        LootButton = LootSlider.transform.GetChild(2).gameObject.GetComponent<Button>();
        timeToLoot = LootSlider.transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>();
        LootButton.onClick.AddListener(() => Loot());
        AllLootButton.onClick.AddListener(() =>
        {
            foreach (Info info in InfoList)
            {
                if(info == null)
                {
                    continue;
                }
                else
                {
                    if (info.isFilled)
                    {
                        info.DoLoot();
                    }
                }
            }
        });
        StartCoroutine(OneSecondUpdate());
    }
    
    public bool canAllLoot()
    {
        bool isFilled = false;
        foreach (Info info in InfoList)
        {
            if (info == null)
            {
                continue;
            }
            else
            {
                if (info.isFilled)
                {
                    isFilled = true ;
                }
            }
        }
        return isFilled;
    }
    IEnumerator OneSecondUpdate()
    {
        while (true)
        {
            if (canAllLoot())
            {
                if (main.S.AutoLoot)
                    AllLootButton.onClick.Invoke();
                else
                    AllLootButton.interactable = true;
            }
            else
                AllLootButton.interactable = false;

            yield return new WaitForSeconds(1.0f);
        }
    }

	// Use this for initialization
	void Start () {
	}

    private void Update()
    {
        if (currentInfo.isFilled)
        {
            LootButton.interactable = true;
        }
        else
        {
            LootButton.interactable = false;
        }

        timeToLoot.text = currentInfo.NextFillString();
        LootSlider.value = currentInfo.currentValueRate();
    }

    public GameObject[] InstantiateSlime()
    {
        GameObject[] enemies = new GameObject[150];
        for (int i = 0; i < main.ZoneCtrl.Slime.Length; i++)
        {
            enemies[i] = Instantiate(Monsters, SlimeCanvas);
            enemies[i].AddComponent<Info>().thisEnemy = main.ZoneCtrl.Slime[i];
            enemies[i].GetComponent<Info>().thisSprite = main.ZoneCtrl.Slime[i].GetComponent<Image>().sprite;
            enemies[i].GetComponent<Info>().thisEnemyKind = Slimes[i].enemyKind;
            main.ZoneCtrl.EnemyAry[(int)Slimes[i].enemyKind] = main.ZoneCtrl.Slime[i];
            enemies[i].GetComponent<Info>().mileStoneKind = ENEMY.MileStoneKind.hp;
            InfoList.Add(enemies[i].GetComponent<Info>());
        }
        enemies[0].GetComponent<Button>().onClick.Invoke();
        currentInfo = enemies[0].GetComponent<Info>();

        for (int i = 0; i < main.ZoneCtrl.Bat.Length; i++)
        {
            enemies[i] = Instantiate(Monsters, SlimeCanvas);
            enemies[i].AddComponent<Info>().thisEnemy = main.ZoneCtrl.Bat[i];
            enemies[i].GetComponent<Info>().thisSprite = main.ZoneCtrl.Bat[i].GetComponent<Image>().sprite;
            enemies[i].GetComponent<Info>().thisEnemyKind = Bats[i].enemyKind;
            main.ZoneCtrl.EnemyAry[(int)Bats[i].enemyKind] = main.ZoneCtrl.Bat[i];
            enemies[i].GetComponent<Info>().mileStoneKind = ENEMY.MileStoneKind.mp;
            InfoList.Add(enemies[i].GetComponent<Info>());
        }
        for (int i = 0; i < main.ZoneCtrl.Spider.Length; i++)
        {
            enemies[i] = Instantiate(Monsters, SlimeCanvas);
            enemies[i].AddComponent<Info>().thisEnemy = main.ZoneCtrl.Spider[i];
            enemies[i].GetComponent<Info>().thisSprite = main.ZoneCtrl.Spider[i].GetComponent<Image>().sprite;
            enemies[i].GetComponent<Info>().thisEnemyKind = Spiders[i].enemyKind;
            main.ZoneCtrl.EnemyAry[(int)Spiders[i].enemyKind] = main.ZoneCtrl.Spider[i];
            enemies[i].GetComponent<Info>().mileStoneKind = ENEMY.MileStoneKind.atk;
            InfoList.Add(enemies[i].GetComponent<Info>());
        }
        for (int i = 0; i < main.ZoneCtrl.Fairy.Length; i++)
        {
            enemies[i] = Instantiate(Monsters, SlimeCanvas);
            enemies[i].AddComponent<Info>().thisEnemy = main.ZoneCtrl.Fairy[i];
            enemies[i].GetComponent<Info>().thisSprite = main.ZoneCtrl.Fairy[i].GetComponent<Image>().sprite;
            enemies[i].GetComponent<Info>().thisEnemyKind = Fairies[i].enemyKind;
            main.ZoneCtrl.EnemyAry[(int)Fairies[i].enemyKind] = main.ZoneCtrl.Fairy[i];
            enemies[i].GetComponent<Info>().mileStoneKind = ENEMY.MileStoneKind.matk;
            InfoList.Add(enemies[i].GetComponent<Info>());
        }
        for (int i = 0; i < main.ZoneCtrl.Fox.Length; i++)
        {
            enemies[i] = Instantiate(Monsters, SlimeCanvas);
            enemies[i].AddComponent<Info>().thisEnemy = main.ZoneCtrl.Fox[i];
            enemies[i].GetComponent<Info>().thisSprite = main.ZoneCtrl.Fox[i].GetComponent<Image>().sprite;
            enemies[i].GetComponent<Info>().thisEnemyKind = Foxes[i].enemyKind;
            main.ZoneCtrl.EnemyAry[(int)Foxes[i].enemyKind] = main.ZoneCtrl.Fox[i];
            enemies[i].GetComponent<Info>().mileStoneKind = ENEMY.MileStoneKind.def;
            InfoList.Add(enemies[i].GetComponent<Info>());
        }
        for (int i = 0; i < main.ZoneCtrl.DevilFish.Length; i++)
        {
            enemies[i] = Instantiate(Monsters, SlimeCanvas);
            enemies[i].AddComponent<Info>().thisEnemy = main.ZoneCtrl.DevilFish[i];
            enemies[i].GetComponent<Info>().thisSprite = main.ZoneCtrl.DevilFish[i].GetComponent<Image>().sprite;
            enemies[i].GetComponent<Info>().thisEnemyKind = DevilFish[i].enemyKind;
            main.ZoneCtrl.EnemyAry[(int)DevilFish[i].enemyKind] = main.ZoneCtrl.DevilFish[i];
            enemies[i].GetComponent<Info>().mileStoneKind = ENEMY.MileStoneKind.def;
            InfoList.Add(enemies[i].GetComponent<Info>());
        }
        for (int i = 0; i < main.ZoneCtrl.Blob.Length; i++)
        {
            enemies[i] = Instantiate(Monsters, SlimeCanvas);
            enemies[i].AddComponent<Info>().thisEnemy = main.ZoneCtrl.Blob[i];
            enemies[i].GetComponent<Info>().thisSprite = main.ZoneCtrl.Blob[i].GetComponent<Image>().sprite;
            enemies[i].GetComponent<Info>().thisEnemyKind = Blob[i].enemyKind;
            main.ZoneCtrl.EnemyAry[(int)Blob[i].enemyKind] = main.ZoneCtrl.Blob[i];
            enemies[i].GetComponent<Info>().mileStoneKind = ENEMY.MileStoneKind.def;
            InfoList.Add(enemies[i].GetComponent<Info>());
        }

        foreach (ENEMY enemy in Slimes)
        {
            Destroy(enemy.gameObject);
        }
        foreach (ENEMY enemy in Bats)
        {
            Destroy(enemy.gameObject);
        }
        foreach (ENEMY enemy in Spiders)
        {
            Destroy(enemy.gameObject);
        }
        foreach (ENEMY enemy in Fairies)
        {
            Destroy(enemy.gameObject);
        }
        foreach (ENEMY enemy in Foxes)
        {
            Destroy(enemy.gameObject);
        }
        foreach (ENEMY enemy in DevilFish)
        {
            Destroy(enemy.gameObject);
        }
        foreach (ENEMY enemy in Blob)
        {
            Destroy(enemy.gameObject);
        }
        return enemies;
    }

    public ENEMY[] InstantiateTempEnemy(ENEMY[] enemies)
    {
        ENEMY[] tempEnemies = new ENEMY[enemies.Length];
        for(int i=0; i < enemies.Length; i++)
        {
            tempEnemies[i] = Instantiate(enemies[i]);
            tempEnemies[i].isTempEnemy = true;
            tempEnemies[i].GetComponent<RectTransform>().anchoredPosition += new Vector2(100000, 0);
        }
        return tempEnemies;
    }
    
    public class Info : BASE
    {
        public ENEMY thisEnemy;
        public Sprite thisSprite;
        //public int thisIndex;
        public ENEMY.EnemyKind thisEnemyKind;
        public ENEMY.MileStoneKind mileStoneKind;
        public float timeToLoot { get => main.S.timeToLoot[(int)thisEnemyKind]; set => main.S.timeToLoot[(int)thisEnemyKind] = value; }
        public bool isFilled;
        public int bestiaryIndex;
        public List<ArtiCtrl.MaterialList> dropHistoryList = new List<ArtiCtrl.MaterialList>();
        static int maxHistoryNum = 7;
        public string dropHistoryString()
        {
            if (dropHistoryList.Count == 0)
                return "";

            string tempText = "";
            foreach(ArtiCtrl.MaterialList material in dropHistoryList)
            {
                tempText = optStr + "- " + main.ArtiCtrl.ConvertEnum(material) + "\n";
            }

            return tempText.ToString();
        }
        public void AddToHistory(ArtiCtrl.MaterialList material)
        {
            if(dropHistoryList.Count == maxHistoryNum)
            {
                for(int i = 1; i < dropHistoryList.Count; i++)
                {
                    dropHistoryList[i - 1] = dropHistoryList[i];
                }
                dropHistoryList[maxHistoryNum-1] = material;
            }
            else
            {
                dropHistoryList.Add(material);
            }
        }



        private void Awake()
        {
            StartBASE();
            gameObject.GetComponent<Button>().onClick.AddListener(SetInfo);
        }

        private void Update()
        {

            if (main.S.totalEnemiesKilled[(int)thisEnemyKind] > 0)
            {
                gameObject.GetComponent<Transform>().GetChild(0).GetComponent<Image>().sprite = thisSprite;
                gameObject.GetComponent<Button>().interactable = true;
            }
            else
            {
                gameObject.GetComponent<Transform>().GetChild(0).GetComponent<Image>().sprite = main.bestiary.hatena;
                gameObject.GetComponent<Button>().interactable = false;
            }
        }

        private void Start()
        {
            StartCoroutine(FillSlider());
        }

        public void SetInfo()
        {
            LocalizeInitialize.SetFont(main.bestiary.enemyName, main.bestiary.DropRateText, main.bestiary.DropRateText2, main.bestiary.HistoryText);
            main.bestiary.currentInfo = gameObject.GetComponent<Info>();
            main.bestiary.Loot = () => StartCoroutine(Loot());
            main.bestiary.enemyName.text = main.ZoneCtrl.EnemyAry[(int)thisEnemyKind].EnemyName;
            main.bestiary.enemyImage.sprite = thisSprite;
            main.bestiary.TotallKilledNum.text = tDigit(main.S.totalEnemiesKilled[(int)thisEnemyKind]);
            main.bestiary.TotalCapturedText.text = tDigit(main.S.totalEnemiesCaptured[(int)thisEnemyKind]);
            main.bestiary.DropRateBonusText.text = percent(main.dropInfo.calculateCaptureDropRate(main.S.totalEnemiesCaptured[(int)thisEnemyKind]));
            main.bestiary.DropRateText.text = main.dropInfo.showDropInfo(main.ZoneCtrl.EnemyAry[(int)thisEnemyKind].enemyKind)[0];
            main.bestiary.DropRateText2.text = main.dropInfo.showDropInfo(main.ZoneCtrl.EnemyAry[(int)thisEnemyKind].enemyKind)[1];
            main.bestiary.HistoryText.text = dropHistoryString();
            SetMileStoneText();
        }

        public IEnumerator FillSlider()
        {
            while (true)
            {
                yield return new WaitUntil(() => !isFilled);
                yield return new WaitUntil(() => main.S.totalEnemiesCaptured[(int)thisEnemyKind] > 0);
                main.S.timeToLoot[(int)thisEnemyKind] += 1.0f;
                if (main.S.timeToLoot[(int)thisEnemyKind] >= MaxFillTime())
                {
                    isFilled = true;
                }
                yield return new WaitForSecondsRealtime(1.0f/Math.Max(Time.timeScale,1));
            }
        }

        public double MaxFillTime()
        {
            //return 10800f / Math.Log10(10 * main.S.totalEnemiesCaptured[(int)thisEnemyKind]);
            return (10800 / (1 + Math.Log10(1 + main.S.totalEnemiesCaptured[(int)thisEnemyKind])))
                * (main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.Clock].GetCurrentValue())
                ;
        }

        public double NextFillTime()
        {
            return MaxFillTime() - main.S.timeToLoot[(int)thisEnemyKind];
        }

        public string NextFillString()
        {
            if (main.S.timeToLoot[(int)thisEnemyKind] == 0)
            {
                return "No Service";
            }
            else
            {
                return DoubleTimeToDate(NextFillTime());
            }
        }

        public float currentValueRate()
        {
            return (float)(main.S.timeToLoot[(int)thisEnemyKind] / MaxFillTime());
        }

        public IEnumerator Loot()
        {
            ENEMY tempEnemy;
            ArtiCtrl.MaterialList tempMaterial;
            tempEnemy = Instantiate(main.ZoneCtrl.EnemyAry[(int)thisEnemyKind]);
            setActive(tempEnemy.gameObject);
            tempEnemy.GetComponent<RectTransform>().anchoredPosition += new Vector2(100000, 0);
            yield return tempEnemy.GetComponent<DropInfo>();
            tempMaterial = tempEnemy.GetComponent<DropInfo>().AbsoluteDrop();
            AddToHistory(tempMaterial);
            main.S.timeToLoot[(int)thisEnemyKind] = 0;
            isFilled = false;
            main.bestiary.currentInfo.SetInfo();
            Destroy(tempEnemy.gameObject);
        }

        public void DoLoot()
        {
            StartCoroutine(Loot());
        }

       void SetMileStoneText()
       {
            string TempText = "";
            switch (mileStoneKind)
            {
                case ENEMY.MileStoneKind.hp:
                    TempText += "HP ";
                    break;
                case ENEMY.MileStoneKind.mp:
                    TempText += "MP ";
                    break;
                case ENEMY.MileStoneKind.atk:
                    TempText += "ATK ";
                    break;
                case ENEMY.MileStoneKind.def:
                    TempText += "DEF ";
                    break;
                case ENEMY.MileStoneKind.matk:
                    TempText += "MATK ";
                    break;
                case ENEMY.MileStoneKind.mdef:
                    TempText += "MDEF ";
                    break;
                case ENEMY.MileStoneKind.exp:
                    TempText += "EXP ";
                    break;
                case ENEMY.MileStoneKind.gold:
                    TempText += "Gold ";
                    break;
                case ENEMY.MileStoneKind.drop:
                    TempText += "Drop ";
                    break;
            }

            //直すまでは一旦これで。。。
            TempText = "HP ";

            for(int i = 0; i < 5; i++)
            {
                main.bestiary.MileStoneText[i].text = TempText + " + " + (i+1).ToString() + " %";
            }

            if (main.S.totalEnemiesKilled[(int)thisEnemyKind] >= 10000000)
            {
                main.bestiary.MileStoneText[4].color = Color.green;
                main.bestiary.KilledNumText[4].color = Color.green;
            }
            else
            {
                main.bestiary.MileStoneText[4].color = Color.white;
                main.bestiary.KilledNumText[4].color = Color.white;
            }
            if (main.S.totalEnemiesKilled[(int)thisEnemyKind] >= 1000000)
            {
                main.bestiary.MileStoneText[3].color = Color.green;
                main.bestiary.KilledNumText[3].color = Color.green;
            }
            else
            {
                main.bestiary.MileStoneText[3].color = Color.white;
                main.bestiary.KilledNumText[3].color = Color.white;
            }
            if (main.S.totalEnemiesKilled[(int)thisEnemyKind] >= 100000)
            {
                main.bestiary.MileStoneText[2].color = Color.green;
                main.bestiary.KilledNumText[2].color = Color.green;
            }
            else
            {
                main.bestiary.MileStoneText[2].color = Color.white;
                main.bestiary.KilledNumText[2].color = Color.white;
            }
            if (main.S.totalEnemiesKilled[(int)thisEnemyKind] >= 10000)
            {
                main.bestiary.MileStoneText[1].color = Color.green;
                main.bestiary.KilledNumText[1].color = Color.green;
            }
            else
            {
                main.bestiary.MileStoneText[1].color = Color.white;
                main.bestiary.KilledNumText[1].color = Color.white;
            }
            if (main.S.totalEnemiesKilled[(int)thisEnemyKind] >= 1000)
            {
                main.bestiary.MileStoneText[0].color = Color.green;
                main.bestiary.KilledNumText[0].color = Color.green;
            }
            else
            {
                main.bestiary.MileStoneText[0].color = Color.white;
                main.bestiary.KilledNumText[0].color = Color.white;
            }

       }
    }

    public double CalculateMileStoneBonus(ENEMY.MileStoneKind mileStoneKind)
    {
       double tempFactor = 0;
       for(int i = 0; i < main.ZoneCtrl.EnemyAry.Length; i++)
       {
            if (main.ZoneCtrl.EnemyAry[i] == null)
                continue;
           if(main.ZoneCtrl.EnemyAry[i].mileStoneKind == mileStoneKind)
           {
               if (main.S.totalEnemiesKilled[i] >= 10000000)
               {
                   tempFactor += 0.01;
               }
               if (main.S.totalEnemiesKilled[i] >= 1000000)
               {
                   tempFactor += 0.01;
               }
               if (main.S.totalEnemiesKilled[i] >= 100000)
               {
                   tempFactor += 0.01;
               }
               if (main.S.totalEnemiesKilled[i] >= 10000)
               {
                   tempFactor += 0.01;
               }
               if (main.S.totalEnemiesKilled[i] >= 1000)
               {
                   tempFactor += 0.01;
               }
           }
       }
       return tempFactor;
    }

}

