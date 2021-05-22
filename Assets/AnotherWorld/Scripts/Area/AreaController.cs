using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Cysharp.Threading.Tasks;
using static Another.Main;
using Another;
using static UsefulMethod;
using static Another.LocalizedText;
using System.Linq;
using System.Threading.Tasks;

public partial class Save
{
    public bool[] AIsMaxHp;
    public bool[] AIsOnlyBase;
    public bool[] AIsNoEq;
    public bool[] AIsNoDmg;
    public float[] AMinClearTime;
    public float[] AMaxClearTime;
    public double[] AMaxGoldGained;
    public long[] AAreaClearedNum;
    public float[] ASpendTime;
    public bool[] AIsMissionAll;
}
namespace Another
{
    public class AreaController : MonoBehaviour
    {
        //AreaIdは11:1-1, 23:2-3を意味する
        public AREA[] areas;
        public Sprite[] backgroundSpritesArea1;
        public Sprite[] backgroundSpritesArea2;
        public Sprite[] backgroundSpritesArea3;
        public Sprite[] backgroundSpritesArea4;
        public Sprite[] backgroundSpritesArea5;
        public Sprite[] backgroundSpritesArea6;
        public Sprite[] backgroundSpritesArea7;
        public Sprite[] backgroundSpritesArea8;

        [SerializeField] CanvasGroup resultCanvasGroup;
        [SerializeField] TextMeshProUGUI resultText;
        [SerializeField] Image clockImage;
        [NonSerialized] public int currentAreaId, currentWave;
        [NonSerialized] public double resultGold, resultExp;
        [NonSerialized] public double[] resultMaterials = new double[Enum.GetNames(typeof(Material)).Length];
        private float clearTime;
        [NonSerialized] public Sprite[] backgroundSprites;//areaIdを元に並んでいる
        public int MaxWave(int areaId)
        {
            return 5 * Math.Max(1, (areaId / 10 + areaId % 10 - 1));
        }
        public int CurrentWave()
        {
            return currentWave;
        }
        public void StartArea(int areaId)
        {
            Initialize(areaId);
            InitializeMission();
            main.battleCtrl.Initialize(true, backgroundSprites[areaId]);
            main.skillCtrl.Initialize();
        }
        public void Initialize(int areaId)
        {
            resultCanvasGroup.alpha = 0;
            currentWave = 0;
            resultGold = 0;
            resultExp = 0;
            for (int i = 0; i < resultMaterials.Length; i++)
            {
                resultMaterials[i] = 0;
            }
            clearTime = 0;
            currentAreaId = areaId;
        }
        public async void ProceedStage()
        {
            while (true)
            {
                if (main.battleCtrl.isVanishedAll)
                {
                    if (CurrentWave() >= MaxWave(currentAreaId))
                    {
                        ClearArea();
                        await Result(true);
                        StartArea(currentAreaId);
                    }
                    else
                    {
                        currentWave++;
                        main.battleCtrl.Initialize();
                        SpawnEnemy(currentAreaId, CurrentWave());
                    }
                }
                else if (!main.battleCtrl.ally.IsLive())
                {
                    main.battleCtrl.ally.position = BattleController.behindPosition;
                    await Result(false);
                    StartArea(currentAreaId);
                }
                await UniTask.DelayFrame(1);
            }
        }
        //AreaMastery
        long[] masteryNums = new long[] { 10, 20, 30, 50, 100, 200, 300, 500, 1000, 2000, 3000, 5000, 10000, 20000, 30000, 50000, 100000, 200000, 300000, 500000, 1000000, 2000000, 3000000, 5000000, (long)1e18 };
        public long NextMasteryNum(int areaId)
        {
            long clearedNum = ClearedNum(areaId);
            for (int i = 0; i < masteryNums.Length; i++)
            {
                if (clearedNum < masteryNums[i])
                    return masteryNums[i];
            }
            return 0;
        }
        public double MasteryBonus(int areaId)
        {
            int tempValue = 0;
            long clearedNum = ClearedNum(areaId);
            for (int i = 0; i < masteryNums.Length; i++)
            {
                if (clearedNum < masteryNums[i])
                {
                    tempValue = i;
                    break;
                }
            }
            return 0.10d * tempValue;
        }
        //Mission
        bool isOnlyBase, isNoEq, isNoDmg;
        public void InitializeMission()
        {
            isOnlyBase = true;
            CheckIsOnlyBase();
            //isNoEq = true;
            //UpdateIsNoEq();
            isNoDmg = true;
        }
        public void ClearArea()
        {
            //Mission
            IncreaseCleaedNum(currentAreaId);
            if (main.battleCtrl.ally.HpPercent() >= 0.75d) main.S.AIsMaxHp[currentAreaId] = true;
            if (isOnlyBase) main.S.AIsOnlyBase[currentAreaId] = true;
            if (isNoEq) main.S.AIsNoEq[currentAreaId] = true;
            if (isNoDmg) main.S.AIsNoDmg[currentAreaId] = true;
            main.S.AMinClearTime[currentAreaId] = Mathf.Min(main.S.AMinClearTime[currentAreaId], clearTime);
            main.S.AMaxClearTime[currentAreaId] = Mathf.Max(main.S.AMaxClearTime[currentAreaId], clearTime);
            main.S.AMaxGoldGained[currentAreaId] = Math.Max(main.S.AMaxGoldGained[currentAreaId], resultGold);
        }
        public long ClearedNum(int areaId)
        {
            return main.S.AAreaClearedNum[areaId];
        }
        public void IncreaseCleaedNum(int areaId)
        {
            main.S.AAreaClearedNum[areaId] += 1;
        }
        public void CheckIsOnlyBase()
        {
            for (int i = 0; i < main.skillCtrl.skills.Length; i++)
            {
                if (i % 10 != 0 && main.skillCtrl.skills[i].isEquipped)
                {
                    isOnlyBase = false;
                    return;
                }
            }
        }
        public void CheckIsNoDmg()
        {
            isNoDmg = false;
        }


        static int resultSmoothness = 30;
        public async Task Result(bool isClear)
        {
            clockImage.fillAmount = 0;
            resultText.text = optStr + "<size=26>";
            resultText.text += isClear ? optStr + "<color=green>" + localized.Basic(BasicWord.Areacleared) : optStr + "<color=red>" + localized.Basic(BasicWord.Areafailed);
            resultText.text += "<size=20></color>";
            resultCanvasGroup.alpha = 0;
            for (int i = 0; i < resultSmoothness; i++)
            {
                resultCanvasGroup.alpha += 1f / resultSmoothness;
                await UniTask.DelayFrame(1);
            }
            resultCanvasGroup.alpha = 1;
            await UniTask.DelayFrame(30);
            resultText.text += optStr + "\n\n" + localized.Basic(BasicWord.CompltedTime) + " : " + tDigit(clearTime) + " " + localized.Basic(BasicWord.Sec);
            await UniTask.DelayFrame(30);
            resultText.text += optStr + "\n\n" + localized.Basic(BasicWord.TotalGoldGained) + " : " + tDigit(resultGold);
            await UniTask.DelayFrame(30);
            resultText.text += optStr + "\n\n" + localized.Basic(BasicWord.TotalExpGained) + " : " + tDigit(resultExp);
            await UniTask.DelayFrame(30);
            resultText.text += optStr + "\n\n" + localized.Basic(BasicWord.TotalMaterialsGained) + " : <size=16>\n\n";
            for (int i = 0; i < resultMaterials.Length; i++)
            {
                if (resultMaterials[i] > 0)
                    resultText.text += optStr + localized.Material((Material)i) + " * " + tDigit(resultMaterials[i]) + "\n";
            }
            for (int i = 0; i < 180; i++)
            {
                clockImage.fillAmount += 1f / 180f;
                await UniTask.DelayFrame(1);
            }
        }
        public EnemyColor SelectedColor(EnemyRarity rarity)
        {
            EnemyColor tempEnemyColor = EnemyColor.Normal;
            int random = UnityEngine.Random.Range(0, 10000);
            switch (rarity)
            {
                case EnemyRarity.Normal:
                    tempEnemyColor = EnemyColor.Normal;
                    break;
                case EnemyRarity.Common:
                    if (random < 2000)
                        tempEnemyColor = EnemyColor.Yellow;//20.00%
                    else if (random < 5000)
                        tempEnemyColor = EnemyColor.Blue;//30.00%
                    else if (random < 9999)
                        tempEnemyColor = EnemyColor.Normal;//49.99%
                    else
                        tempEnemyColor = EnemyColor.Metal;//0.01%
                    break;
                case EnemyRarity.Uncommon:
                    if (random < 1000)
                        tempEnemyColor = EnemyColor.Green;//10.00%
                    else if (random < 3000)
                        tempEnemyColor = EnemyColor.Red;//20.00%
                    else if (random < 6000)
                        tempEnemyColor = EnemyColor.Yellow;//30.00%
                    else if (random < 9997)
                        tempEnemyColor = EnemyColor.Blue;//39.98%
                    else
                        tempEnemyColor = EnemyColor.Metal;//0.03%
                    break;
                case EnemyRarity.Rare:
                    if (random < 3500)
                        tempEnemyColor = EnemyColor.Purple;//35.00%
                    else if (random < 8000)
                        tempEnemyColor = EnemyColor.Green;//35.00%
                    else if (random < 9995)
                        tempEnemyColor = EnemyColor.Red;//19.95%
                    else
                        tempEnemyColor = EnemyColor.Metal;//0.05%
                    break;
                case EnemyRarity.Boss:
                    tempEnemyColor = EnemyColor.Boss;
                    break;
            }
            return tempEnemyColor;
        }


        private void Awake()
        {
            backgroundSprites = new Sprite[100];
            for (int i = 0; i < backgroundSpritesArea1.Length; i++)
            {
                if (backgroundSpritesArea1[i] != null)
                    backgroundSprites[11 + i] = backgroundSpritesArea1[i];
                if (backgroundSpritesArea2[i] != null)
                    backgroundSprites[21 + i] = backgroundSpritesArea2[i];
                if (backgroundSpritesArea3[i] != null)
                    backgroundSprites[31 + i] = backgroundSpritesArea3[i];
                if (backgroundSpritesArea4[i] != null)
                    backgroundSprites[41 + i] = backgroundSpritesArea4[i];
                if (backgroundSpritesArea5[i] != null)
                    backgroundSprites[51 + i] = backgroundSpritesArea5[i];
                if (backgroundSpritesArea6[i] != null)
                    backgroundSprites[61 + i] = backgroundSpritesArea6[i];
                if (backgroundSpritesArea7[i] != null)
                    backgroundSprites[71 + i] = backgroundSpritesArea7[i];
                if (backgroundSpritesArea8[i] != null)
                    backgroundSprites[81 + i] = backgroundSpritesArea8[i];
            }
            for (int i = 0; i < areas.Length; i++)
            {
                areas[i].id = 11 + i;
                areas[i].SetMission();
            }
        }
        // Start is called before the first frame update
        void Start()
        {
            //Debug
            StartArea(11);

            UpdateTime();
            ProceedStage();
        }
        async void UpdateTime()
        {
            while (true)
            {
                await UniTask.Delay(1000);
                clearTime++;
                main.S.ASpendTime[currentAreaId]++;
            }
        }
        // Update is called once per frame
        void Update()
        {

        }
        public string InfoString(int areaId)
        {
            return optStr + "<size=20>" + AreaString(areaId) + "<Star></size>"
                + "<size=12>\n\n</size>"
                + "<size=16>" + localized.Basic(BasicWord.MasteryBonus) + " <color=green> + " + percent(MasteryBonus(areaId)) + "</color>"
                + " <size=16>( " + localized.Basic(BasicWord.CompletedNum) + " " + ClearedNum(areaId).ToString() + " / " + "Next : " + NextMasteryNum(areaId).ToString() + " )";
        }
        public string AreaString(int areaId)
        {
            string tempString = optStr + localized.Basic(BasicWord.Area) + " " + areaId / 10 + "-" + areaId % 10 + " : ";
            tempString += localized.Area(areaId);
            return tempString;
        }
        public string AreaString()
        {
            return AreaString(currentAreaId);
        }
        public string WaveString()
        {
            string tempString = optStr + localized.Basic(BasicWord.Wave) + " " + CurrentWave().ToString() + " / " + MaxWave(currentAreaId).ToString();
            return tempString;
        }
        public string MasteryString(int areaId)
        {
            string tempString = optStr + "<size=16><u>" + localized.Basic(BasicWord.MasteryBonus) + "</u><size=8>\n"
            + "\n</size><size=16>- " + localized.Stat(Stats.ExpGain) + ", " + localized.Stat(Stats.MoveSpeed) + ", " + localized.Stat(Stats.NormalDropChance)
            + " <color=green> + " + percent(MasteryBonus(areaId));
            return tempString;
        }

        //敵の出現パターン
        public void SpawnEnemy(int areaId, int wave)//500,700
        {
            switch (areaId)
            {
                case 11:
                    SpawnEnemySymmetric(EnemySpecies.Slime, EnemyRarity.Normal, 0, wave, wave);
                    break;
                case 12:
                    SpawnEnemySymmetric(EnemySpecies.Slime, EnemyRarity.Common, 1, wave, wave);
                    break;
                case 13:
                    SpawnEnemySymmetric(EnemySpecies.Slime, EnemyRarity.Common, 2, wave, wave);
                    break;
                case 14:
                    SpawnEnemySymmetric(EnemySpecies.Slime, EnemyRarity.Uncommon, 3, wave, wave);
                    break;
                case 15:
                    SpawnEnemySymmetric(EnemySpecies.Slime, EnemyRarity.Uncommon, 4, wave, wave);
                    break;
                case 16:
                    SpawnEnemySymmetric(EnemySpecies.Slime, EnemyRarity.Uncommon, 5, wave, wave);
                    break;
                case 17:
                    SpawnEnemySymmetric(EnemySpecies.Slime, EnemyRarity.Rare, 6, wave, wave);
                    break;
                case 18:
                    SpawnEnemySymmetric(EnemySpecies.Slime, EnemyRarity.Rare, 7, wave, wave);
                    break;
                default:
                    SpawnEnemySymmetric(EnemySpecies.Slime, EnemyRarity.Normal, 0, 0, 1 + wave * 2);
                    break;
            }
        }
        //左右対称
        public void SpawnEnemySymmetric(EnemySpecies species, EnemyRarity rarity, long level, long difficulty, int spawnNum)
        {
            var positions = new List<Vector2>();
            switch (spawnNum)
            {
                case 1:
                    positions.Add(Vector2.up * 500);
                    break;
                case 2:
                    positions.Add(Vector2.up * 300 + Vector2.right * 300);
                    positions.Add(Vector2.up * 300 + Vector2.left * 300);
                    break;
                case 3:
                    positions.Add(Vector2.up * 300);
                    positions.Add(Vector2.up * 100 + Vector2.right * 300);
                    positions.Add(Vector2.up * 100 + Vector2.left * 300);
                    break;
                case 4:
                    positions.Add(Vector2.up * 400 + Vector2.right * 100);
                    positions.Add(Vector2.up * 400 + Vector2.left * 100);
                    positions.Add(Vector2.up * 300 + Vector2.right * 300);
                    positions.Add(Vector2.up * 300 + Vector2.left * 300);
                    break;
                case 5:
                    positions.Add(Vector2.up * 200);
                    positions.Add(Vector2.up * 400 + Vector2.right * 200);
                    positions.Add(Vector2.up * 400 + Vector2.left * 200);
                    positions.Add(Vector2.up * 300 + Vector2.right * 400);
                    positions.Add(Vector2.up * 300 + Vector2.left * 400);
                    break;
                case 6:
                    positions.Add(Vector2.up * 200 + Vector2.right * 150);
                    positions.Add(Vector2.up * 200 + Vector2.left * 150);
                    positions.Add(Vector2.up * 400 + Vector2.right * 200);
                    positions.Add(Vector2.up * 400 + Vector2.left * 200);
                    positions.Add(Vector2.up * 300 + Vector2.right * 400);
                    positions.Add(Vector2.up * 300 + Vector2.left * 400);
                    break;
                case 7:
                    positions.Add(Vector2.zero);
                    positions.Add(Vector2.up * 250);
                    positions.Add(Vector2.up * 500);
                    positions.Add(Vector2.up * 200 + Vector2.right * 200);
                    positions.Add(Vector2.up * 200 + Vector2.left * 200);
                    positions.Add(Vector2.up * 400 + Vector2.right * 400);
                    positions.Add(Vector2.up * 400 + Vector2.left * 400);
                    break;
                case 8:
                    positions.Add(Vector2.right * 100);
                    positions.Add(Vector2.left * 100);
                    positions.Add(Vector2.up * 150 + Vector2.right * 200);
                    positions.Add(Vector2.up * 150 + Vector2.left * 200);
                    positions.Add(Vector2.up * 300 + Vector2.right * 300);
                    positions.Add(Vector2.up * 300 + Vector2.left * 300);
                    positions.Add(Vector2.up * 450 + Vector2.right * 400);
                    positions.Add(Vector2.up * 450 + Vector2.left * 400);
                    break;
                case 9:
                    positions.Add(Vector2.up * 150);
                    positions.Add(Vector2.up * 300 + Vector2.right * 200);
                    positions.Add(Vector2.up * 300 + Vector2.left * 200);
                    positions.Add(Vector2.up * 450 + Vector2.right * 400);
                    positions.Add(Vector2.up * 450 + Vector2.left * 400);
                    positions.Add(Vector2.right * 200);
                    positions.Add(Vector2.left * 200);
                    positions.Add(Vector2.down * 150 + Vector2.right * 400);
                    positions.Add(Vector2.down * 150 + Vector2.left * 400);
                    break;
                case 10:
                    positions.Add(Vector2.zero);
                    positions.Add(Vector2.up * 100 + Vector2.right * 200);
                    positions.Add(Vector2.up * 100 + Vector2.left * 200);
                    positions.Add(Vector2.up * 200 + Vector2.right * 400);
                    positions.Add(Vector2.up * 200 + Vector2.left * 400);
                    positions.Add(Vector2.up * 300);
                    positions.Add(Vector2.up * 400 + Vector2.right * 200);
                    positions.Add(Vector2.up * 400 + Vector2.left * 200);
                    positions.Add(Vector2.up * 500 + Vector2.right * 400);
                    positions.Add(Vector2.up * 500 + Vector2.left * 400);
                    break;
                case 11:
                    positions.Add(Vector2.zero);
                    positions.Add(Vector2.up * 250);
                    positions.Add(Vector2.up * 500);
                    positions.Add(Vector2.up * 450 + Vector2.right * 150);
                    positions.Add(Vector2.up * 450 + Vector2.left * 150);
                    positions.Add(Vector2.up * 200 + Vector2.right * 200);
                    positions.Add(Vector2.up * 200 + Vector2.left * 200);
                    positions.Add(Vector2.up * 100 + Vector2.right * 350);
                    positions.Add(Vector2.up * 100 + Vector2.left * 350);
                    positions.Add(Vector2.up * 400 + Vector2.right * 400);
                    positions.Add(Vector2.up * 400 + Vector2.left * 400);
                    break;
                case 12:
                    positions.Add(Vector2.zero);
                    positions.Add(Vector2.up * 100 + Vector2.right * 200);
                    positions.Add(Vector2.up * 100 + Vector2.left * 200);
                    positions.Add(Vector2.up * 200 + Vector2.right * 400);
                    positions.Add(Vector2.up * 200 + Vector2.left * 400);
                    positions.Add(Vector2.up * 300);
                    positions.Add(Vector2.up * 300 + Vector2.right * 300);
                    positions.Add(Vector2.up * 300 + Vector2.left * 300);
                    positions.Add(Vector2.up * 400 + Vector2.right * 200);
                    positions.Add(Vector2.up * 400 + Vector2.left * 200);
                    positions.Add(Vector2.up * 500 + Vector2.right * 400);
                    positions.Add(Vector2.up * 500 + Vector2.left * 400);
                    break;
                case 13:
                    positions.Add(Vector2.right * 100);
                    positions.Add(Vector2.left * 100);
                    positions.Add(Vector2.up * 150 + Vector2.right * 200);
                    positions.Add(Vector2.up * 150 + Vector2.left * 200);
                    positions.Add(Vector2.up * 300 + Vector2.right * 300);
                    positions.Add(Vector2.up * 300 + Vector2.left * 300);
                    positions.Add(Vector2.up * 450 + Vector2.right * 400);
                    positions.Add(Vector2.up * 450 + Vector2.left * 400);
                    positions.Add(Vector2.down * 200);
                    positions.Add(Vector2.down * 400 + Vector2.right * 200);
                    positions.Add(Vector2.down * 400 + Vector2.left * 200);
                    positions.Add(Vector2.down * 300 + Vector2.right * 400);
                    positions.Add(Vector2.down * 300 + Vector2.left * 400);
                    break;
                case 14:
                    positions.Add(Vector2.left * 500);
                    positions.Add(Vector2.up * 250);
                    positions.Add(Vector2.up * 500);
                    positions.Add(Vector2.up * 200 + Vector2.right * 200);
                    positions.Add(Vector2.up * 200 + Vector2.left * 200);
                    positions.Add(Vector2.up * 400 + Vector2.right * 400);
                    positions.Add(Vector2.up * 400 + Vector2.left * 400);
                    positions.Add(Vector2.right * 500);
                    positions.Add(Vector2.down * 250);
                    positions.Add(Vector2.down * 500);
                    positions.Add(Vector2.down * 200 + Vector2.right * 200);
                    positions.Add(Vector2.down * 200 + Vector2.left * 200);
                    positions.Add(Vector2.down * 400 + Vector2.right * 400);
                    positions.Add(Vector2.down * 400 + Vector2.left * 400);
                    break;
                case 15:
                    positions.Add(Vector2.up * 150);
                    positions.Add(Vector2.up * 300 + Vector2.right * 200);
                    positions.Add(Vector2.up * 300 + Vector2.left * 200);
                    positions.Add(Vector2.up * 450 + Vector2.right * 400);
                    positions.Add(Vector2.up * 450 + Vector2.left * 400);
                    positions.Add(Vector2.right * 200);
                    positions.Add(Vector2.left * 200);
                    positions.Add(Vector2.down * 150 + Vector2.right * 400);
                    positions.Add(Vector2.down * 150 + Vector2.left * 400);
                    positions.Add(Vector2.down * 200 + Vector2.right * 150);
                    positions.Add(Vector2.down * 200 + Vector2.left * 150);
                    positions.Add(Vector2.down * 400 + Vector2.right * 200);
                    positions.Add(Vector2.down * 400 + Vector2.left * 200);
                    positions.Add(Vector2.down * 300 + Vector2.right * 400);
                    positions.Add(Vector2.down * 300 + Vector2.left * 400);
                    break;
                case 16:
                    positions.Add(Vector2.zero);
                    positions.Add(Vector2.up * 250);
                    positions.Add(Vector2.up * 500);
                    positions.Add(Vector2.up * 450 + Vector2.right * 150);
                    positions.Add(Vector2.up * 450 + Vector2.left * 150);
                    positions.Add(Vector2.up * 200 + Vector2.right * 200);
                    positions.Add(Vector2.up * 200 + Vector2.left * 200);
                    positions.Add(Vector2.up * 100 + Vector2.right * 350);
                    positions.Add(Vector2.up * 100 + Vector2.left * 350);
                    positions.Add(Vector2.up * 400 + Vector2.right * 400);
                    positions.Add(Vector2.up * 400 + Vector2.left * 400);
                    positions.Add(Vector2.down * 200);
                    positions.Add(Vector2.down * 400 + Vector2.right * 200);
                    positions.Add(Vector2.down * 400 + Vector2.left * 200);
                    positions.Add(Vector2.down * 300 + Vector2.right * 400);
                    positions.Add(Vector2.down * 300 + Vector2.left * 400);
                    break;
                case 17:
                    positions.Add(Vector2.zero);
                    positions.Add(Vector2.up * 250);
                    positions.Add(Vector2.up * 500);
                    positions.Add(Vector2.up * 450 + Vector2.right * 150);
                    positions.Add(Vector2.up * 450 + Vector2.left * 150);
                    positions.Add(Vector2.up * 200 + Vector2.right * 200);
                    positions.Add(Vector2.up * 200 + Vector2.left * 200);
                    positions.Add(Vector2.up * 100 + Vector2.right * 350);
                    positions.Add(Vector2.up * 100 + Vector2.left * 350);
                    positions.Add(Vector2.up * 400 + Vector2.right * 400);
                    positions.Add(Vector2.up * 400 + Vector2.left * 400);
                    positions.Add(Vector2.down * 200 + Vector2.right * 150);
                    positions.Add(Vector2.down * 200 + Vector2.left * 150);
                    positions.Add(Vector2.down * 400 + Vector2.right * 200);
                    positions.Add(Vector2.down * 400 + Vector2.left * 200);
                    positions.Add(Vector2.down * 300 + Vector2.right * 400);
                    positions.Add(Vector2.down * 300 + Vector2.left * 400);
                    break;
                case 18:
                    positions.Add(Vector2.left * 300);
                    positions.Add(Vector2.up * 250);
                    positions.Add(Vector2.up * 500);
                    positions.Add(Vector2.up * 450 + Vector2.right * 150);
                    positions.Add(Vector2.up * 450 + Vector2.left * 150);
                    positions.Add(Vector2.up * 200 + Vector2.right * 200);
                    positions.Add(Vector2.up * 200 + Vector2.left * 200);
                    positions.Add(Vector2.up * 100 + Vector2.right * 350);
                    positions.Add(Vector2.up * 100 + Vector2.left * 350);
                    positions.Add(Vector2.up * 400 + Vector2.right * 400);
                    positions.Add(Vector2.up * 400 + Vector2.left * 400);
                    positions.Add(Vector2.right * 300);
                    positions.Add(Vector2.down * 250);
                    positions.Add(Vector2.down * 500);
                    positions.Add(Vector2.down * 200 + Vector2.right * 200);
                    positions.Add(Vector2.down * 200 + Vector2.left * 200);
                    positions.Add(Vector2.down * 400 + Vector2.right * 400);
                    positions.Add(Vector2.down * 400 + Vector2.left * 400);
                    break;
                case 19:
                    positions.Add(Vector2.right * 100);
                    positions.Add(Vector2.left * 100);
                    positions.Add(Vector2.up * 150 + Vector2.right * 200);
                    positions.Add(Vector2.up * 150 + Vector2.left * 200);
                    positions.Add(Vector2.up * 300 + Vector2.right * 300);
                    positions.Add(Vector2.up * 300 + Vector2.left * 300);
                    positions.Add(Vector2.up * 450 + Vector2.right * 400);
                    positions.Add(Vector2.up * 450 + Vector2.left * 400);
                    positions.Add(Vector2.down * 500 + Vector2.right * 100);
                    positions.Add(Vector2.down * 500 + Vector2.left * 100);
                    positions.Add(Vector2.down * 500 + Vector2.up * 150 + Vector2.right * 200);
                    positions.Add(Vector2.down * 500 + Vector2.up * 150 + Vector2.left * 200);
                    positions.Add(Vector2.down * 500 + Vector2.up * 300 + Vector2.right * 300);
                    positions.Add(Vector2.down * 500 + Vector2.up * 300 + Vector2.left * 300);
                    positions.Add(Vector2.down * 500 + Vector2.up * 450 + Vector2.right * 400);
                    positions.Add(Vector2.down * 500 + Vector2.up * 450 + Vector2.left * 400);
                    positions.Add(Vector2.up * 500);
                    positions.Add(Vector2.up * 200);
                    positions.Add(Vector2.down * 300);
                    break;
                case 20:
                    positions.Add(Vector2.zero);
                    positions.Add(Vector2.up * 100 + Vector2.right * 200);
                    positions.Add(Vector2.up * 100 + Vector2.left * 200);
                    positions.Add(Vector2.up * 200 + Vector2.right * 400);
                    positions.Add(Vector2.up * 200 + Vector2.left * 400);
                    positions.Add(Vector2.up * 300);
                    positions.Add(Vector2.up * 400 + Vector2.right * 200);
                    positions.Add(Vector2.up * 400 + Vector2.left * 200);
                    positions.Add(Vector2.up * 500 + Vector2.right * 400);
                    positions.Add(Vector2.up * 500 + Vector2.left * 400);
                    positions.Add(Vector2.down * 500 + Vector2.zero);
                    positions.Add(Vector2.down * 500 + Vector2.up * 100 + Vector2.right * 200);
                    positions.Add(Vector2.down * 500 + Vector2.up * 100 + Vector2.left * 200);
                    positions.Add(Vector2.down * 500 + Vector2.up * 200 + Vector2.right * 400);
                    positions.Add(Vector2.down * 500 + Vector2.up * 200 + Vector2.left * 400);
                    positions.Add(Vector2.down * 500 + Vector2.up * 300);
                    positions.Add(Vector2.down * 500 + Vector2.up * 400 + Vector2.right * 200);
                    positions.Add(Vector2.down * 500 + Vector2.up * 400 + Vector2.left * 200);
                    positions.Add(Vector2.down * 500 + Vector2.up * 500 + Vector2.right * 400);
                    positions.Add(Vector2.down * 500 + Vector2.up * 500 + Vector2.left * 400);
                    break;
                default:
                    positions.Add(Vector2.zero);
                    positions.Add(Vector2.up * 100 + Vector2.right * 200);
                    positions.Add(Vector2.up * 100 + Vector2.left * 200);
                    positions.Add(Vector2.up * 200 + Vector2.right * 400);
                    positions.Add(Vector2.up * 200 + Vector2.left * 400);
                    positions.Add(Vector2.up * 300);
                    positions.Add(Vector2.up * 400 + Vector2.right * 200);
                    positions.Add(Vector2.up * 400 + Vector2.left * 200);
                    positions.Add(Vector2.up * 500 + Vector2.right * 400);
                    positions.Add(Vector2.up * 500 + Vector2.left * 400);
                    positions.Add(Vector2.down * 500 + Vector2.zero);
                    positions.Add(Vector2.down * 500 + Vector2.up * 100 + Vector2.right * 200);
                    positions.Add(Vector2.down * 500 + Vector2.up * 100 + Vector2.left * 200);
                    positions.Add(Vector2.down * 500 + Vector2.up * 200 + Vector2.right * 400);
                    positions.Add(Vector2.down * 500 + Vector2.up * 200 + Vector2.left * 400);
                    positions.Add(Vector2.down * 500 + Vector2.up * 300);
                    positions.Add(Vector2.down * 500 + Vector2.up * 400 + Vector2.right * 200);
                    positions.Add(Vector2.down * 500 + Vector2.up * 400 + Vector2.left * 200);
                    positions.Add(Vector2.down * 500 + Vector2.up * 500 + Vector2.right * 400);
                    positions.Add(Vector2.down * 500 + Vector2.up * 500 + Vector2.left * 400);
                    break;
            }
            for (int i = 0; i < positions.Count(); i++)
            {
                main.battleCtrl.SpawnEnemy(species, SelectedColor(rarity), positions[i], level, difficulty);
            }

        }
        public void SpawnEnemySquare()
        {

        }

    }

}