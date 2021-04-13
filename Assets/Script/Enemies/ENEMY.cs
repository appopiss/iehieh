using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using static UsefulMethod;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using MathNet.Numerics.Distributions;
using static ALLY.Condition;
using static BASE;
//using UnityEditor.Animations;

[System.Serializable]
public class DropMaterial : Serialize.TableBase<ArtiCtrl.MaterialList, int, DropMaterialPair>
{


}
[System.Serializable]
public class DropMaterialPair : Serialize.KeyAndValue<ArtiCtrl.MaterialList, int>
{

    public DropMaterialPair(ArtiCtrl.MaterialList Material, int Probability,double tei=0) : base(Material, Probability,tei)
    {

    }
}

public abstract class ENEMY : BASE//,IPointerDownHandler
{
    public int EnemyIndex;
    public double buffer;
    float enemySize;
    public float hpRate()
    {
        return (float)(currentHp / HP());
    }
    
    public enum EnemyKind
    {
        BigSlime, //0
        NormalSlime,
        BlueSlime,
        YellowSlime,  
        GreenSlime,
        OrangeSlime,
        NormalBat,
        RedSlime,
        BlueBat,
        YellowBat,
        PurpleSlime,//10
        GreenBat,
        RedBat,
        OrangeBat,
        PurpleBat,
        BlackBat,
        NormalSpider,
        BlueSpider,
        YellowSpider,
        GreenSpider,
        RedSpider,//20
        PurpleSpider,
        SpiderQueen,
        OrangeFox,
        YellowFox,
        GreenFox,
        BlueFox,
        RedFox,
        PurpleFox,
        WhiteFox,
        MNormalslime,//30
        SkyFox,
        BlackFox,
        MBlueslime,
        MYelllowSlime,
        WhiteNineTailedFox,
        MGreenSlime,
        MOrangeSlime,
        MRedSlime,
        BlueDevilFish,
        MPurpleSlime,//40
        BlueBlob,
        RedBlob,
        GreenDevilFish,
        UnknownSlime,
        OrangeDevilFish,
        BlueCatBlob,
        RedCatBlob,
        BlueRabbitBlob,
        RedRabbitBlob,
        BlueBlobSilent,//50
        RedBlobSilent,
        MutantSlime,
        RedDevilFish,
        PurpleDevilFish,
        SkyDevilFish,
        YellowDevilFish,
        BlueKnightBlob,
        RedKnightBlob,
        BlueKnightBlobSilent,
        RedKnightBlobSilent,//60
        BlueArcherBlob,
        RedArcherBlob,
        BlueKingBlob,
        RedKingBlob,
        SlimeBoss,//65
        SlimeKing,
        FairyQueen,
        Golem,
        Bananoon,
        Spyder,//70
        Montblango,
        DistortionSlime,
        MetalSlime,
        NormalFairy,
        BlueFairy,
        YellowFairy,
        GreenFairy,
        OrangeFairy,
        RedFairy,
        PurpleFairy,//80
        BlackFairy,
        Deathpider,
        WizardSlime,
        Octobaddie,//84
    }
    public enum MonsterTable
    {
        NormalSlimes,
        BigSlime,//Tuotiral専用
        CommonSlimes,
        UncommonSlimes,
        RareSlimes,
        BossSlimes,
        NormalSpider,
        CommonSpiders       ,
        UncommonSpiders     ,
        RareSpiders         ,
        BossSpiders         ,
        NormalBats          ,
        CommonBats          ,
        UncommonBats        ,
        RareBats            ,
        BossBats            ,
        NormalFoxes         ,
        CommonFoxes         ,
        UncommonFoxes       ,
        RareFoxes           ,
        BossFoxes           ,
        NormalMSlimes       ,
        CommonMSlimes       ,
        UncommonMSlimes     ,
        RareMSlimes         ,
        BossMSlimes          ,
        NormalDevilFish     ,
        CommonDevilFish     ,
        UncommonDevilFish   ,
        RareDevilFish       ,
        BossDevilFish       ,
        NormalFairy         ,
        CommonFairy         ,
        UncommonFairy       ,
        RareFairy           ,
        BossFairy           ,
        MetalSlime,
        CommonBall,
        RareBall,
    }
    //
    [TextAreaAttribute(10, 100)]//height:10,width:100
    [System.NonSerialized]
    public GameObject window;
    public string text;
    public string EnemyName;
    [System.NonSerialized]
    public string hpText;
    [System.NonSerialized]
    public string atkText;
    [System.NonSerialized]
    public string defText;
    [System.NonSerialized]
    public string mAtkText;
    [System.NonSerialized]
    public string mDefText;
    [System.NonSerialized]
    public string spdText;
    [System.NonSerialized]
    public bool isDead;
    public bool isTempEnemy;
    [System.NonSerialized]
    public int moveFactor;
    [System.NonSerialized]
    public GameObject mahouzin;
    [System.NonSerialized]
    public Image enemyImage;
    [Header("spritesとintervalsのサイズは同じにしてください")]
    /// <summary>
    /// ここに切り替える画像を入れてください．
    /// </summary>
    public Sprite[] sprites;
    /// <summary>
    /// コマとコマの感覚をそれぞれ入力してください．デフォルトは[0.5,0.5]で．
    /// </summary>
    public float[] intervals = { 0.5f, 0.5f };
    public bool isOver;
    public double[] InputStatus;
    [NonSerialized]
    public bool isTargetted;
    GameObject TargetImage;
    public enum EnemyColor
    {
        normal=0,
        blue = 1,
        red = 2,
        green = 3,
        yellow = 4,
        purple = 5,
        sky = 6,
        white = 7,
        black = 8,
        orange = 9,
        pink = 10
    }
    public EnemyColor thisColor;
    public enum AttackType
    {
        pyshical,
        magic
    }
    [System.NonSerialized]
    public AttackType attackType;
    [System.NonSerialized]
    public GameObject mpSlider;
    [System.NonSerialized]
    public GameObject AttackObject;
    [System.NonSerialized]
    public float  MoveSpeed = 0.5f;
    [System.NonSerialized]
    public float AttackRange = 100f;
    public EnemyKind enemyKind;
    public enum MileStoneKind
    {
        hp,
        mp,
        atk,
        def,
        matk,
        mdef,
        gold,
        exp,
        drop,
        spd
    }
    public MileStoneKind mileStoneKind;
    public long TotalEachEnemyKilled { get => main.S.totalEnemiesKilled[(int)enemyKind]; set => main.S.totalEnemiesKilled[(int)enemyKind] = value; }
    public long TotalEachEnemyKilledForDailyQuest { get => main.S.defeatedEnemyNum[(int)enemyKind]; set => main.S.defeatedEnemyNum[(int)enemyKind] = value; }
    public long TotalEnemiesCaptured { get => main.S.totalEnemiesCaptured[(int)enemyKind]; set => main.S.totalEnemiesCaptured[(int)enemyKind] = value; }

    public double MileStoneFactor()
    {
        if(TotalEachEnemyKilled >= 10000000)
        {
            return 0.05;
        }else if(TotalEachEnemyKilled >= 1000000)
        {
            return 0.04;
        }else if(TotalEachEnemyKilled >= 100000)
        {
            return 0.03;
        }else if(TotalEachEnemyKilled >= 10000)
        {
            return 0.02;
        }else if(TotalEachEnemyKilled >= 1000)
        {
            return 0.01;
        }
        else
        {
            return 0;
        }
    }
    public virtual bool isDefeatedByOnce { get; set; }
    public virtual void SetMileStoneKind()
    {

    }

    public void OnMouse()
    {
        if (isRange(enemySize/2, (Vector2)Input.mousePosition/(Screen.height/600f) + main.mouseEvent.factor, gameObject))
        {
            if (!main.mouseEvent.isOver)
            {
                main.mouseEvent.isOver = true;
                main.mouseEvent.targetEnemy = this;
                isOver = true;
            }
            
        }
        else
        {
            if (main.mouseEvent.isOver&&isOver)
            {
                main.mouseEvent.isOver = false;
                isOver = false;
            }
        }
    }
    //一回でも攻撃されたか
    public bool isAttackedOnce;
    public int dodgeRate = 0;
    public int phyDodgeRate = 0;
 

    //デストラクタ
    private void OnDestroy()
    {
        Destroy(window);
        if (isOver)
        {
            main.mouseEvent.targetEnemy = null;
            main.mouseEvent.isOver = false;
        }
        if (mahouzin != null)
            Destroy(mahouzin);
    }
    public void updateText()
    {
        OnMouse();
        if (isTargetted)
            setActive(TargetImage);
        else
            setFalse(TargetImage);
        //バフ
        if (main.ally1.gameObject.GetComponent<ALLY>().isBuff[(int)Main.Buff.gold])
        {
            buffGoldFactor = main.angelSkillAry[8].Damage()/100;
        }
        else
        {
            buffGoldFactor = 0;
        }

        if (condition == BattleMode)
        {
            if (!CanAttack())
            {
                condition = MoveMode;
            }
        }

        if (attackType == AttackType.magic && mahouzin!=null)
        {
            if (!main.toggles[9].isOn && !main.systemController.disableEffect)
            {
                if (isChanting)
                {
                    setActive(mahouzin);
                    mahouzin.GetComponent<RectTransform>().anchoredPosition = thisRect.anchoredPosition;
                }
                else
                {
                    setFalse(mahouzin);
                }
            }
        }

        //デバフ
        if (isDebuff[(int)Main.Debuff.cold] || isDebuff[(int)Main.Debuff.freeze])
        {
            enemyImage.color = Blue;
        }
        if (!isDebuff[(int)Main.Debuff.cold] && !isDebuff[(int)Main.Debuff.freeze])
        {
            if (isDebuff[(int)Main.Debuff.electricalShock])
            {
                enemyImage.color = Yellow;
            }
            //else
            //{
            //    enemyImage.color = White;
            //}
        }
        if(isAttackedOnce)
            gameObject.GetComponentsInChildren<Slider>()[0].value = (float)(currentHp / HP());

    }
    Color Blue = new Color(0, 0, 120);
    Color Yellow = new Color(120, 120, 0);
    Color White = new Color(255, 255, 255);

    //チャレンジは個別にステータスを設定する．
    public virtual void SetStatus(double hp, double atk, double matk, double def, double mdef,double gold)
    {
        this.initialHp = hp;
        currentHp = this.initialHp;
        this.initialAtk = atk;
        this.initialDef = def;
        initialMAtk = matk;
        initialMDef = mdef;
        this.initialGold = gold;
    }

    public virtual int BaseColorDrop()
    {
        return 15;
    }

    double isBossFactor(bool isBoss)
    {
        if (isBoss)
            return 1.5;
        else
            return 1;
    }
    double isBossFactorHp(bool isBoss)
    {
        if (isBoss)
            return 5;
        else
            return 1;
    }

    public enum atkKind
    {
        phys,
        mag,
        both
    }
    public double difficulty = 1;
    public double areaDifficultyFactor;
    public double dungeonDifficultyFactor;
    public double level = 1;
    public double dungeonLevelFactor;
    public bool isBoss;

    public void AwakeEnemy(int level = 1, int difficulty = 1, float initialAttackSpeed = 1.0f, atkKind atkKind = atkKind.phys, bool isBoss = false)
        //double initialHp =0,double initialAtk=0, double initialMAtk=0, double initialDef=0, double initialMDef=0,
        //double initialGold =0,float initialAttackSpeed = 1.0f ,bool isChallange = false)
    {
        StartBASE();
        this.initialHp = 20  * isBossFactorHp(isBoss);
        currentHp = this.initialHp;
        if (atkKind == atkKind.mag)
            this.initialAtk = 0;
        else
            this.initialAtk = 5  * isBossFactor(isBoss);
        if (atkKind == atkKind.phys)
            this.initialMAtk = 0;
        else
            this.initialMAtk = 5  * isBossFactor(isBoss);
        if (atkKind == atkKind.mag)
            this.initialDef = 0;
        else
            this.initialDef = 5  * isBossFactor(isBoss);
        if (atkKind == atkKind.phys)
            this.initialMDef = 0;
        else
            this.initialMDef = 5  * isBossFactor(isBoss);

        if (!isBoss)
            this.initialGold = 6  * 0.5 ;
        else
            this.initialGold = 6  * 1;

        if (!isBoss)
            this.exp = 10  * 0.75;
        else
            this.exp = 10  * 0.75 * 2.5;

        this.initialAttackSpeed = initialAttackSpeed;
        this.difficulty = difficulty;
        this.level = level;
        this.isBoss = isBoss;
        targetEnemy = main.ally1;
        targetEnemyPosition = targetEnemy.GetComponent<RectTransform>();
        thisRect = gameObject.GetComponent<RectTransform>();
        enemySize = thisRect.sizeDelta.x;
        //gameObject.AddComponent<CAPTURE>();
        SetMileStoneKind();
    }

    //ドロップ率の調整を行う．
    public virtual void ModifiedDrop() { }
    public void AddDrop(DropMaterialPair pair)
    {
        DropMaterial.list.Add(pair);
    }

    public virtual void AddDrop(ArtiCtrl.MaterialList material, int probability)
    {

    }

    //Trueならスクリプトを参照する．
    public bool DropByScript = true;
        
    public void StartEnemy()
    {
        EnemyName = main.ArtiCtrl.ConvertEnum(enemyKind);
        if (!isTempEnemy)
        {
            gameObject.AddComponent<DropInfo>().DropInfoDic = main.dropInfo.ReturnDropInfo(enemyKind);
        }
        //もしステータスがインプットされていたら．
        if (InputStatus.Length == 6)
        {
            this.initialHp = InputStatus[0];
            this.initialAtk = InputStatus[1];
            this.initialMAtk = InputStatus[2];
            this.initialDef = InputStatus[3];
            this.initialMDef = InputStatus[4];  
            this.initialGold = InputStatus[5];
        }else if(InputStatus.Length == 7)
        {
            this.initialHp = InputStatus[0];
            this.initialAtk = InputStatus[1];
            this.initialMAtk = InputStatus[2];
            this.initialDef = InputStatus[3];
            this.initialMDef = InputStatus[4];
            this.initialGold = InputStatus[5];
            this.exp = InputStatus[6];
        }
        currentHp = HP();

        isDebuff = new bool[System.Enum.GetValues(typeof(Main.Debuff)).Length];
        goldFactor = 1;
        StartCoroutine(Move());
        StartCoroutine(NormilizeStatus());
        StartCoroutine(SearchDecoy());

        enemyImage = gameObject.GetComponent<Image>();
        StartCoroutine(UpdateText());
        StartCoroutine(ChangeSprite());
        if (DropByScript)
        {
            DropMaterial = new DropMaterial();
            DropMaterial.list = new List<DropMaterialPair>();
        }
        //ModifiedDrop();
        TargetImage = Instantiate(main.targetImage, gameObject.transform);
        setFalse(TargetImage);
        TargetImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        if (attackType == AttackType.magic && gameObject.transform.childCount > 1)
            mpSlider = gameObject.transform.GetChild(1).gameObject;
        else
            mpSlider = InstantiateSlider();

        mpSlider.GetComponent<Slider>().value = 0;

        if (attackType == AttackType.pyshical)
            AttackObject = main.animationObject[8];
        else
            AttackObject = main.animationObject[19];

        if (attackType == AttackType.magic)
        {
            AttackRange = 150f;
            if (!main.toggles[9].isOn && !main.systemController.disableEffect)
            {
                mahouzin = Instantiate(main.animationObject[23], main.Transforms[3]);
                mahouzin.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
                setFalse(mahouzin);
            }
        }
    }

    public GameObject InstantiateSlider()
    {
        GameObject slider;
        slider = Instantiate(main.mpSlider.gameObject, gameObject.transform);
        slider.transform.GetChild(1).GetChild(0).GetComponent<Image>().color = Color.blue;
        slider.GetComponent<RectTransform>().anchoredPosition
            = gameObject.transform.GetChild(0).gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(0, 6);
        return slider;
    }

    public bool isPurchasedCostumeDLC { get => main.GameController.isDlcIEH2; }
    public bool isSpecialSprite;
    public IEnumerator ChangeSprite()
    {
        if (isSpecialSprite)
            yield break;
        if (isPurchasedCostumeDLC && main.bestiary.enemySprite0[(int)enemyKind] != null && main.bestiary.enemySprite1[(int)enemyKind] != null)
        {
            //IEH2
            if (gameObject.HasComponent<Animator>())
                gameObject.GetComponent<Animator>().enabled = false;
            if (gameObject.HasComponent<SLIME>())
                gameObject.GetComponent<RectTransform>().localScale *= 0.8f;
        }
        while (true)
        {
            if (isPurchasedCostumeDLC && main.bestiary.enemySprite0[(int)enemyKind] != null && main.bestiary.enemySprite1[(int)enemyKind] != null)
            {
                gameObject.GetComponent<Image>().sprite = null;
                gameObject.GetComponent<Image>().sprite = main.bestiary.enemySprite0[(int)enemyKind];
                if (isDebuff[(int)Main.Debuff.freeze])
                {
                    yield return new WaitForSeconds(300);
                }
                else if (isDebuff[(int)Main.Debuff.cold])
                    yield return new WaitForSeconds(0.5f * 2);
                else
                    yield return new WaitForSeconds(0.5f);
                gameObject.GetComponent<Image>().sprite = null;
                gameObject.GetComponent<Image>().sprite = main.bestiary.enemySprite1[(int)enemyKind];
                if (isDebuff[(int)Main.Debuff.freeze])
                {
                    yield return new WaitForSeconds(300);
                }
                else if (isDebuff[(int)Main.Debuff.cold])
                    yield return new WaitForSeconds(0.5f * 2);
                else
                    yield return new WaitForSeconds(0.5f);
            }
            else
            {
                if (sprites.Length == 0 || intervals.Length == 0)
                {
                    break;
                }
                if (sprites.Length != intervals.Length)
                {
                    break;
                }
                for (int i = 0; i < sprites.Length; i++)
                {
                    gameObject.GetComponent<Image>().sprite = null;
                    gameObject.GetComponent<Image>().sprite = sprites[i];
                    if (isDebuff[(int)Main.Debuff.freeze])
                    {
                        yield return new WaitForSeconds(300);
                    }
                    else if (isDebuff[(int)Main.Debuff.cold])
                        yield return new WaitForSeconds(intervals[i] * 2);
                    else
                        yield return new WaitForSeconds(intervals[i]);
                }

            }
        }

        //while (true)
        //{
        //    if(sprites.Length ==0 || intervals.Length == 0)
        //    {
        //        break;
        //    }

        //    if(sprites.Length != intervals.Length)
        //    {
        //        break;
        //    }
        //    for(int i = 0; i < sprites.Length; i++)
        //    {
        //        gameObject.GetComponent<Image>().sprite = null;
        //        gameObject.GetComponent<Image>().sprite = sprites[i];
        //        if (isDebuff[(int)Main.Debuff.freeze])
        //        {
        //            yield return new WaitForSeconds(300);
        //        }
        //        else if (isDebuff[(int)Main.Debuff.cold])
        //            yield return new WaitForSeconds(intervals[i]*2);
        //        else
        //            yield return new WaitForSeconds(intervals[i]);
        //    }
        //}
    }
    
    public void ChangeImage(Sprite sprite)
    {   
        gameObject.GetComponent<Image>().sprite = sprite;
    }

    public double Factor(double tei)
    {
        switch (main.GameController.currentVillage)
        {
            case Main.Village.slime:
                return Math.Max(Math.Pow(tei, main.GameController.floorNum - 100), 1);
            case Main.Village.bat:
                return Math.Max(Math.Pow(tei, main.GameController.floorNum1), 1);
            case Main.Village.ball:
                return Math.Max(Math.Pow(tei, main.GameController.floorNum2), 1);
            case Main.Village.fish:
                return Math.Max(Math.Pow(tei, main.GameController.floorNum3), 1);
            case Main.Village.fox:
                return Math.Max(Math.Pow(tei, main.GameController.floorNum4), 1);
            default:
                return 1;
        }
    }

    [System.NonSerialized]
    public double initialHp;
    [System.NonSerialized]
    public double currentHp;
    [System.NonSerialized]
    public double initialAtk;
    [System.NonSerialized]
    public double initialMAtk;
    [System.NonSerialized]
    public double initialDef;
    [System.NonSerialized]
    public double initialMDef;
    [System.NonSerialized]
    public double initialGold;
    [System.NonSerialized]
    public double exp;
    public DropMaterial DropMaterial;
    [System.NonSerialized]
    public double goldFactor;
    public virtual double HP()
    {
        if(isBoss)
            return initialHp * Math.Pow((difficulty + areaDifficultyFactor + dungeonDifficultyFactor),2)
                * Math.Pow(1.05, (areaDifficultyFactor + dungeonDifficultyFactor)) * (level+dungeonLevelFactor) * Math.Pow(1.05, (dungeonLevelFactor));
        else
            return initialHp * Math.Pow((difficulty + areaDifficultyFactor + dungeonDifficultyFactor), 2)
                * Math.Pow(1.045, (areaDifficultyFactor + dungeonDifficultyFactor)) * (level + dungeonLevelFactor) * Math.Pow(1.045, (dungeonLevelFactor));
    }
    public double ATK()
    {
        double tempValue;
        if (isBoss)
            tempValue = initialAtk * (difficulty + areaDifficultyFactor + dungeonDifficultyFactor) * Math.Pow(1.00625, (areaDifficultyFactor + dungeonDifficultyFactor)) * (level + dungeonLevelFactor) * Math.Pow(1.0525, (dungeonLevelFactor))*(1 - Convert.ToInt32(isDebuff[(int)Main.Debuff.atkDown]) * 0.25f);// 
        else
            tempValue = initialAtk * (difficulty + areaDifficultyFactor + dungeonDifficultyFactor) * Math.Pow(1.005, (areaDifficultyFactor + dungeonDifficultyFactor)) * (level + dungeonLevelFactor) * Math.Pow(1.035, (dungeonLevelFactor)) * (1 - Convert.ToInt32(isDebuff[(int)Main.Debuff.atkDown]) * 0.5f);//
        if (main.ZoneCtrl.isHidden)
            tempValue *= 1e8d;
        return tempValue;
    }
    public double MATK()
    {
        double tempValue;
        if (isBoss)
            tempValue = initialMAtk * (difficulty + areaDifficultyFactor + dungeonDifficultyFactor) * Math.Pow(1.00625, (areaDifficultyFactor + dungeonDifficultyFactor)) * (level + dungeonLevelFactor) * Math.Pow(1.0525, (dungeonLevelFactor)) * (1 - Convert.ToInt32(isDebuff[(int)Main.Debuff.mAtkDown]) * 0.25f);//
        else
            tempValue = initialMAtk * (difficulty + areaDifficultyFactor + dungeonDifficultyFactor) * Math.Pow(1.005, (areaDifficultyFactor + dungeonDifficultyFactor)) * (level + dungeonLevelFactor) * Math.Pow(1.035, (dungeonLevelFactor)) * (1 - Convert.ToInt32(isDebuff[(int)Main.Debuff.mAtkDown]) * 0.5f);//
        if (main.ZoneCtrl.isHidden)
            tempValue *= 1e8d;
        return tempValue;
    }
    public double DEF() { return initialDef * (difficulty + areaDifficultyFactor + dungeonDifficultyFactor) * (level + dungeonLevelFactor) * (1 - Convert.ToInt32(isDebuff[(int)Main.Debuff.defDown]) * 0.5f); }
    public double MDEF() { return initialMDef * (difficulty + areaDifficultyFactor + dungeonDifficultyFactor) * (level + dungeonLevelFactor) * (1 - Convert.ToInt32(isDebuff[(int)Main.Debuff.defDown]) * 0.5f); }
    public virtual double EXP() {
        double exp = this.exp
            * (1 + main.zoneExpBonus() / 100)
            * (1 + main.ArtifactFactor.MUL_EXP()) * (1 + main.QuestCtrl.R_distortion())
            * (difficulty + areaDifficultyFactor / 2 + dungeonDifficultyFactor / 2) * (level + dungeonLevelFactor) * (1 + main.ally.Mile_exp)
            * (1 + main.dungeonAry[(int)main.GameController.currentDungeon].CurrentExpBonus())
            * (1 + main.keyf.M_exp)
            * (1d + main.iebCtrl.iebBonuses[(int)IEBBONUS.BonusKind.expgain])
            + main.StatusUpgrade[5].calculateCurrentValue()//UpgradeのExpBonus
            + main.SR.R_EXP//Lottery
            + main.alchemyController.expFactor
            + main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.Golden].GetCurrentValue() * 5            ;

        if (main.ally.Level() <= 1000)
            exp = Math.Min(exp, main.ally.RequiredExp() * 1000);
        else if (main.ally.Level() <= 2000)
            exp = Math.Min(exp, main.ally.RequiredExp() * 100);
        else if (main.ally.Level() <= 3000)
            exp = Math.Min(exp, main.ally.RequiredExp() * 50);
        else if (main.ally.Level() <= 3500)
            exp = Math.Min(exp, main.ally.RequiredExp());
        else if (main.ally.Level() <= 4000)
            exp = Math.Min(exp, main.ally.RequiredExp() * 0.1d);
        else if (main.ally.Level() <= 5000)
            exp = Math.Min(exp, main.ally.RequiredExp() * 0.01d);
        else if (main.ally.Level() <= 10000)
            exp = Math.Min(exp, main.ally.RequiredExp() * 0.001d);
        else if (main.ally.Level() <= 100000)
            exp = Math.Min(exp, main.ally.RequiredExp() * 0.0001d);
        else
            exp = Math.Min(exp, main.ally.RequiredExp() * 0.00001d);
        //DLCとEpicStore
        exp *= main.ExpGainDLCFactor();
        /*ここにMetalSlimeCurseの報酬をかく
        exp = Math.Max(exp, main.ally.RequiredExp() * 0.00001d * cureseClearNum(最大10));
        */
        exp += SumAddDelegate(main.cc.cf.ExpBonus_Add);

        exp = Math.Min(exp, 1e306);

        main.skillSetController.exp += exp;
        if (main.GameController.battleMode==GameController.BattleMode.dungeon)
        {
            main.DeathPanel.exp += exp;
        }
        else if (main.GameController.battleMode == GameController.BattleMode.challange)
        {
            main.DeathPanel.C_exp += exp;
        }
        return exp;
    }
    [System.NonSerialized]
    public double buffGoldFactor;

    public double GOLD_passiveSkill()
    {
        if (main.ally.job == ALLY.Job.Angel || main.MissionMileStone.IsSkillPassiveEffect())
            return main.angelSkillAry[8].pas1 + main.angelSkillAry[8].pas2 + main.angelSkillAry[8].pas3;
        else
            return 0;
    }

    double mulGold()
    {
        return (1 + GOLD_passiveSkill()) * (1 + buffGoldFactor)
             * (1 + main.ArtifactFactor.GOLD()) * (1 + main.Ascends[13].calculateCurrentValue())
             * (1 + main.jems[(int)JEM.ID.GoldGem].Effect())
             * (1 + main.ally.Mile_gold)
             * (1d + main.iebCtrl.iebBonuses[(int)IEBBONUS.BonusKind.goldgain])
             ;
    }


    public double GOLD() {


        double gold = initialGold * goldFactor
            * ((difficulty + areaDifficultyFactor / 5 + Math.Log10(1 + dungeonDifficultyFactor)) / 20 + 1) * (1 + (level - 1) / 2 + dungeonLevelFactor / 10)
             * mulGold()
             + main.StatusUpgrade[4].calculateCurrentValue() + main.ArtifactFactor.ADD_GOLD() + main.keyf.A_gold
            + main.SR.R_GOLD
            + main.alchemyController.goldFactor
            + main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.Golden].GetCurrentValue();

        //DLC
        gold *= main.GoldGainDLCFactor();

        double GoldCap = isBoss ? 10000 : 1000;
        GoldCap += SumAddDelegate(main.cc.cf.MonsterGoldCap);
        GoldCap += main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.capacity].calculateCurrentValue();
        GoldCap += main.MissionMileStone.GoldCap();
        GoldCap += main.MonsterGoldCapEpicStoreFactor();
        GoldCap += main.iebCtrl.iebBonuses[(int)IEBBONUS.BonusKind.monstergoldcap];
        GoldCap *= main.MonsterGoldCapDLCFactor();
        GoldCap *= main.MissionMileStoneHidden.MonsterGoldCap();
        if (main.cc.CurrentCurseId == CurseId.curse_of_poverty)
        {
            GoldCap /= 100;
        }
        gold = Math.Min(gold, GoldCap);

        if (main.GameController.battleMode == GameController.BattleMode.dungeon)
        {
            //gold *= UnityEngine.Random.Range(5,15);
            main.DeathPanel.gold += gold;
        }
        else if(main.GameController.battleMode == GameController.BattleMode.challange)
        {
            main.DeathPanel.C_gold += gold;
        }
        else
        {
            //gold = (1 + buffGoldFactor + main.angelSkillAry[8].pas1 + main.angelSkillAry[8].pas2 + main.angelSkillAry[8].pas3)
            //* main.ArtifactFactor.GOLD() * main.Ascends[15].calculateCurrentValue() * (1 + main.jems[(int)JEM.ID.GoldProduce].Effect());
            //main.DeathPanel.gold += gold;
        }
        main.skillSetController.gold += gold;
        if(!main.toggles[4].isOn&&!main.toggles[9].isOn)
            main.Log("Gold + " + tDigit(gold));
        double sabun = main.MaxGold() - main.SR.gold;
        if(main.SR.gold + gold >= main.MaxGold())
        {
            main.SR.gold += sabun;
            main.S.TempStoreSlimeCoin += gold - sabun;
        }
        else
        {
            main.SR.gold += gold;
        }
        return gold;
    }
    [System.NonSerialized]
    public float initialAttackSpeed;
    public float AttackSpeed() { return initialAttackSpeed * (1 + Convert.ToInt32(isDebuff[(int)Main.Debuff.cold])); }
    [System.NonSerialized]
    public ALLY.Condition condition;
    [System.NonSerialized]
    public GameObject targetEnemy;
    [System.NonSerialized]
    public RectTransform targetEnemyPosition;
    [System.NonSerialized]
    public RectTransform thisRect;
    [System.NonSerialized]
    public bool[] isDebuff;

    public virtual void Attacking() {
        if (AttackObject == null)
            return;

        if (CanAttack())
        {
            if(attackType == AttackType.pyshical)
                StartCoroutine(I_AttackObject(AttackObject, targetEnemyPosition, ATK(), 0, SKILL.DamageKind.physical));
            else
                StartCoroutine(I_AttackObject(AttackObject, targetEnemyPosition, MATK(), 0, SKILL.DamageKind.magical));
        }
    }
    public bool CanAttack() {
        return !isDebuff[(int)Main.Debuff.freeze] && vectorAbs(thisRect.anchoredPosition - targetEnemyPosition.anchoredPosition) <= AttackRange;
    }
    //ダメージの計算を行う．
    public double calculatedDamage(double damage = 0, double mDamage = 0, double critDamage = 0)
    { return (damage * dmgReduction(damage) + mDamage * mDmgReduction(mDamage) + critDamage)* Math.Max(Normal.Sample(1, 0.05), 0.8); }//Math.Max(((damage * (1-(DEF()/(DEF()+damage))) * Math.Max(Normal.Sample(1, 0.05), 0.8)) + (mDamage * (1 - MDEF() / (MDEF() + mDamage)) * Math.Max(Normal.Sample(1, 0.05), 0.8)) + critDamage),0.1) ; }
    public double dmgReduction(double damage)
    {
        if (main.skillList.WarriorSkills[(int)SkillList.WarriorSkill.criticalEye].P_level > 0)
            return 1;
        if (DEF() <= 0)
        {
            return 1;
        }
        else
        {
            return 1 - DEF() / (DEF() + damage);
        }
    }
    public double mDmgReduction(double mDamage)
    {
        if (main.skillList.WizardSkills[(int)SkillList.WizardSkill.criticalBolt].P_level > 0)
            return 1;

        if (MDEF() <= 0)
        {
            return 1;
        }
        else
        {
            return 1 - MDEF() / (MDEF() + mDamage);
        }
    }
    //攻撃されたときに1回だけ呼ばれる．
    public virtual void Attacked() { }
    public void InstantiateText(string text, Color color)
    {

        GameObject Text;
        Text = Instantiate(main.prefabAry_H[0], gameObject.transform);
        Text.GetComponent<RectTransform>().anchoredPosition = new Vector2(UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-10, 10));
        Text.GetComponentInChildren<TextMeshProUGUI>().text = text;
        Text.GetComponentInChildren<TextMeshProUGUI>().color = color;
    }
    //衝突したときに一回だけ呼ばれる
    protected Collider2D colliderInfo;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        SKILL.DamageKind damageKind;
        if (collision.gameObject.HasComponent<Attack>())
        {
            if (collision.GetComponent<Attack>().isEnemyAttack)
                return;
            damageKind = collision.GetComponent<Attack>().damageKind;
            if (!isBoss)
            {
                if (collision.GetComponent<Attack>().thisDebuff == Main.Debuff.knockback)
                    KnockBack();
                else
                    isDebuff[(int)collision.GetComponent<Attack>().thisDebuff] = true;
            }
            else if (collision.GetComponent<Attack>().thisDebuff != Main.Debuff.freeze && collision.GetComponent<Attack>().thisDebuff != Main.Debuff.cold && collision.GetComponent<Attack>().thisDebuff != Main.Debuff.knockback)
                isDebuff[(int)collision.GetComponent<Attack>().thisDebuff] = true;
            else if (collision.GetComponent<Attack>().thisDebuff == Main.Debuff.freeze)//ボスはcoldは無効、freezeの場合のみcoldになる
                isDebuff[(int)Main.Debuff.cold] = true;
        }
        else
        {
            damageKind = SKILL.DamageKind.nothing;
            return;
        }
        //回避処理
        if (UnityEngine.Random.Range(0, 10000) <= dodgeRate)
        {
            if (!main.systemController.noMoreDamageTxt)
                InstantiateText("Dodge!!", Color.blue);
            Destroy(collision.gameObject);
            return;
        }

        if (damageKind == SKILL.DamageKind.physical)
        {
            DUNGEON.isAttackedByPhy = true;
            //物理回避処理
            if (UnityEngine.Random.Range(0, 10000) <= phyDodgeRate)
            {
                if (!main.systemController.noMoreDamageTxt)
                    InstantiateText("Dodge!!", Color.blue);
                Destroy(collision.gameObject);
                return;
            }
            main.sound.PlaySound(main.sound.attackClip);
        }
        else if (damageKind == SKILL.DamageKind.magical)
        {
            DUNGEON.isAttackedByMag = true;
            main.sound.PlaySound(main.sound.magicalAtkClip);
        }
        if (main.S.job == ALLY.Job.Wizard && main.S.ReincarnationNum>0)//コンボ
        {
            if (main.wizardSkillAry[11].P_level>0 && main.wizardSkillAry[11].IsEquipped())
                main.ally.combo++;
        }

        //ミッションのhit count
        if (enemyKind==EnemyKind.SpiderQueen)
            DUNGEON.hitCount++;
        //コライダーに情報入力
        colliderInfo = collision;

        double damage;
        double mDamage;
        double critDamage;
        if (collision.gameObject.tag != "enemyEffect" && collision.GetComponent<Attack>() != null)
        {
            damage = collision.GetComponent<Attack>().damage;
            mDamage = collision.GetComponent<Attack>().mDamage;
            critDamage = collision.GetComponent<Attack>().critDamage;
        }
        else
        {
            return;
        }
        //ヴェノムソードの処理
        if(main.NewArtifacts[(int)ARTIFACT.ArtifactName.VenomSword].isEquipped
            && UnityEngine.Random.Range(0, 10000) < main.NewArtifacts[(int)ARTIFACT.ArtifactName.VenomSword].level*0.00025*10000)
        {
            StartCoroutine(VenomPoison());
        }
        //クリティカルの判定
        if (main.NewArtifacts[(int)ARTIFACT.ArtifactName.AmberRing].isEquipped)
        {
            if (UnityEngine.Random.Range(0, 10000) <= 10000 *
    main.NewArtifacts[(int)ARTIFACT.ArtifactName.AmberRing].level* 0.0005 + main.skillprogress.criticalChance*100)
            {
                if (!main.systemController.noMoreDamageTxt)
                    main.ally1.GetComponent<IDamagable>().InstantiateText("Critical!", Color.magenta);
                damage *= 2.5;
                mDamage *= 2.5;
            }
        }
        //吸血処理
        // if(UnityEngine.Random.Range(0,10000) <= 10000)
        // {
        //     main.ally1.GetComponent<IDamagable>().currentHp += damage * main.ArtifactFactor.value10;
        // }
        if (collision.GetComponent<Attack>().isDestroyAfterCollide)
            Destroy(collision.gameObject);
        //装備によるダメージボーナス
        damage *= 1+ main.ArtifactFactor.PhysicalDamage();
        mDamage *= 1 + main.ArtifactFactor.MagicalAtk();
        //FortitudeCourageによるダメージボーナス
        damage *= 1 + main.warriorSkillAry[12].Damage();
        //ComboAttackによるダメージボーナス
        mDamage *= 1 + main.wizardSkillAry[11].Damage();
        //BalancedWingsによるダメージボーナス
        if (main.angelSkillAry[11].IsEquipped())
        {
            damage *= 1 + main.angelSkillAry[11].Damage();
            mDamage *= 1 + main.angelSkillAry[11].Damage();
        }
        else if (main.S.job == ALLY.Job.Angel || main.MissionMileStone.IsSkillPassiveEffect())
        {
            damage *= 1 + main.angelSkillAry[11].Damage() * main.angelSkillAry[11].pas1;
            mDamage *= 1 + main.angelSkillAry[11].Damage() * main.angelSkillAry[11].pas1;
        }
        //総ダメージをここで計算する．(ここでダメージを確定させる．)
        double totalDamage = calculatedDamage(damage, mDamage, critDamage);
        //Jemによるダメージボーナス
        totalDamage *= 1+main.jems[(int)JEM.ID.FuryGem].Effect();
        //Wizのclasspassive
        if (main.skillprogress.isWizDebuffFactor)
        {
            if (isDebuff[(int)Main.Debuff.cold])
                totalDamage *= 2;
            if (isDebuff[(int)Main.Debuff.electricalShock])
                totalDamage *= 2;
        }
        //Divineのときは最低でも1%のダメージに
        if (damageKind == SKILL.DamageKind.divine && totalDamage < currentHp * 0.01d)
        {
            if (currentHp >= HP() * 0.25)
                totalDamage = UnityEngine.Random.Range(0.0001f, 0.01f) * currentHp;
            else
                totalDamage = UnityEngine.Random.Range(0.00001f, 0.01f) * currentHp;
        }
        //バナナのダメージ
        if (damageKind == SKILL.DamageKind.banana && main.skillSetController.currentDPS >= currentHp * 0.01d)
        {
            if (!isBoss && !gameObject.HasComponent<C_ENEMY>())
                totalDamage = UnityEngine.Random.Range(0.05f, 0.75f) * currentHp;
            else
                totalDamage = UnityEngine.Random.Range(0.000000001f, 0.1f) * currentHp;
        }
        totalDamage = Math.Min(1e305d, totalDamage);
        currentHp -= Math.Max(totalDamage, 1);
        //感電処理(総ダメージに依存した追加攻撃を書く)．
        ElectricDamage(totalDamage);
        setActive(gameObject.transform.GetChild(0).gameObject);
        if (!isAttackedOnce && totalDamage >= HP())
        {
            isDefeatedByOnce = true;
        }
        isAttackedOnce = true;
        //個別に攻撃されたときの処理を行う．
        Attacked();
        //死んだときの処理
        if (currentHp <= 0)
        {
            currentHp = 0;
            if (!isDead)
            {
                isDead = true;
                //Reincarnationによる自動キャプチャ
                if (UnityEngine.Random.Range(0,10000 ) < main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.HappyCapture].GetCurrentValue() * 10000)
                {
                    if (!gameObject.HasComponent<C_ENEMY>())
                    {
                        StartCoroutine(main.capture.ActualCapture(this, true));
                        return;
                    }
                }
                if (isBoss)
                {
                    gameObject.GetComponent<DropInfo>().Drop();
                }
                else
                {
                    LimitedDrop();
                }

                main.S.totalEnemyKilled++;
                if (collision.name == "SlimeBall")
                    main.S.DefeatBySlimeBall++;

                long count = 1 + (long)main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.counter].TotalEffect();
                TotalEachEnemyKilled += count;
                if (main.S.ReincarnationNum > 0)
                    main.S.totalEnemiesKilledAfterReincarnation[(int)enemyKind] += count;
                TotalEachEnemyKilledForDailyQuest += count;
                if (main.S.totalEnemyKilled % 500 == 0) { GetAscendPoint((long)(Math.Log10(1+(level+dungeonLevelFactor)))); }
                setFalse(window);
                main.ally1.GetComponent<IDamagable>().condition = ALLY.Condition.MoveMode;
                GOLD();
                main.ally1.GetComponent<IDamagable>().currentExp += EXP();
                Drop();
                if (!main.toggles[4].isOn && !main.toggles[9].isOn)
                {
                    main.Log("EXP + " + tDigit(EXP()));
                    GameObject destroy;
                    destroy = Instantiate(main.DestroyEnemy, main.Transforms[1]);
                    destroy.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
                }
                foreach (GameObject game in GameObject.FindGameObjectsWithTag("enemyEffect"))
                {
                    Destroy(game);
                }
                if (mahouzin != null)
                    Destroy(mahouzin);
                //もし一撃で倒されたら・・・
                //個別の死んだ処理
                Dead();
                Destroy(gameObject);
            }
        }
        main.skillSetController.dps += calculatedDamage(damage, mDamage,critDamage);
        InstantiateDamage(Math.Max(totalDamage, 1), damageKind);
    }

    public void KnockBack()
    {
        if (thisRect.anchoredPosition.y <= 200 && thisRect.anchoredPosition.y >= -200 && thisRect.anchoredPosition.x <= 200 && thisRect.anchoredPosition.x >= -200) 
        gameObject.GetComponent<RectTransform>().anchoredPosition += 30*normalize(thisRect.anchoredPosition - main.ally.GetComponent<RectTransform>().anchoredPosition);
    }


    public void GetAscendPoint(long bonus)
    {
        long value = 1 + bonus;
        value = (long)(value * main.RebirthPointFactor());

        switch (main.ally.job)
        {
            case ALLY.Job.Warrior:
                main.WarP += value;
                main.tempWarP += value;
                break;
            case ALLY.Job.Wizard:
                main.WizP += value;
                main.tempWizP += value;
                break;
            case ALLY.Job.Angel:
                main.AngP += value;
                main.tempAngP += value;
                break;
            default:
                break;
        }

        main.SR.JP_enemy += value;
    }

    void LimitedDrop()
    {
        if (!main.isDropped[0])
        {
            gameObject.GetComponent<DropInfo>().Drop();
            if (main.SR.P_AngelDistruction)
                gameObject.GetComponent<DropInfo>().Drop();
        }
        else if (!main.isDropped[1])
        {
            gameObject.GetComponent<DropInfo>().Drop();
            if (main.SR.P_AngelDistruction)
                gameObject.GetComponent<DropInfo>().Drop();
        }
        else if (main.SR.P_AngelDistruction && !main.isDropped[2])
        {
            gameObject.GetComponent<DropInfo>().Drop();
            if (main.SR.P_AngelDistruction)
                gameObject.GetComponent<DropInfo>().Drop();
        }
        else if (main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.Greedy].GetCurrentValue() > 0 && !main.isDropped[3])
        {
            gameObject.GetComponent<DropInfo>().Drop();
        }
        else if (main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.Greedy].GetCurrentValue() > 1 && !main.isDropped[4])
        {
            gameObject.GetComponent<DropInfo>().Drop();
        }
        else if (main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.Greedy].GetCurrentValue() > 2 && !main.isDropped[5])
        {
            gameObject.GetComponent<DropInfo>().Drop();
        }
        else if (main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.Greedy].GetCurrentValue() > 3 && !main.isDropped[6])
        {
            gameObject.GetComponent<DropInfo>().Drop();
        }
        else if (main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.Greedy].GetCurrentValue() > 4 && !main.isDropped[7])
        {
            gameObject.GetComponent<DropInfo>().Drop();
        }
        else if (main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.Greedy].GetCurrentValue() > 5 && !main.isDropped[8])
        {
            gameObject.GetComponent<DropInfo>().Drop();
        }
        else if (main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.Greedy].GetCurrentValue() > 6 && !main.isDropped[9])
        {
            gameObject.GetComponent<DropInfo>().Drop();
        }
        else if (main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.Greedy].GetCurrentValue() > 7 && !main.isDropped[10])
        {
            gameObject.GetComponent<DropInfo>().Drop();
        }
        else if (main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.Greedy].GetCurrentValue() > 8 && !main.isDropped[11])
        {
            gameObject.GetComponent<DropInfo>().Drop();
        }
        else if (main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.Greedy].GetCurrentValue() > 9 && !main.isDropped[12])
        {
            gameObject.GetComponent<DropInfo>().Drop();
        }
        else if (main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.Greedy].GetCurrentValue() > 10 && !main.isDropped[13])
        {
            gameObject.GetComponent<DropInfo>().Drop();
        }
        else if (main.NewArtifacts[(int)ARTIFACT.ArtifactName.GoldenAmulet].isEquipped)
        {
            if (main.NewArtifacts[(int)ARTIFACT.ArtifactName.GoldenAmulet].EvolutionNum >= 0 && !main.isDropped[14])
            {
                gameObject.GetComponent<DropInfo>().Drop();
            }
            else if (main.NewArtifacts[(int)ARTIFACT.ArtifactName.GoldenAmulet].EvolutionNum >= 1 && !main.isDropped[15])
            {
                gameObject.GetComponent<DropInfo>().Drop();
            }
            else if (main.NewArtifacts[(int)ARTIFACT.ArtifactName.GoldenAmulet].EvolutionNum >= 2 && !main.isDropped[16])
            {
                gameObject.GetComponent<DropInfo>().Drop();
            }
            else if (main.NewArtifacts[(int)ARTIFACT.ArtifactName.GoldenAmulet].EvolutionNum >= 3 && !main.isDropped[17])
            {
                gameObject.GetComponent<DropInfo>().Drop();
            }
            else if (main.NewArtifacts[(int)ARTIFACT.ArtifactName.GoldenAmulet].EvolutionNum >= 4 && !main.isDropped[18])
            {
                gameObject.GetComponent<DropInfo>().Drop();
            }
        }
    }

    //チャレンジでのみオーバーライドしてね．他でオーバーライドしないでね．
    public virtual void Drop()
    {
      //  double dropFactor = 1 + main.ArtifactFactor.DROP();
      //  foreach(KeyValuePair<ArtiCtrl.MaterialList,int> material in DropMaterial.GetTable())
      //  {
      //      int randomNum = UnityEngine.Random.Range(0, 10000);
      //      if (randomNum< material.Value * dropFactor)
      //      {
      //         main.ArtiCtrl.CurrentMaterial[material.Key] += 1;
      //          if (!main.toggles[4].isOn)
      //              main.Log("Gained <color=green>" + main.ArtiCtrl.ConvertEnum(material.Key));
      //         if (main.GameController.battleMode != GameController.BattleMode.challange)
      //         {
      //             main.DeathPanel.materials[material.Key] += 1;
      //         }
      //         else
      //         {
      //             main.DeathPanel.C_materials[material.Key] += 1;
      //         }
      //      }
      //  }
    }
    public IEnumerator VenomPoison()
    {
        if (isDebuff[(int)Main.Debuff.poison])
            yield break;
        else
            isDebuff[(int)Main.Debuff.poison] = true;

        GameObject poison;
        poison = Instantiate(main.animationObject[56], gameObject.transform);

        //20×30 = 600ループ
        for(int i = 0; i < 600; i++)
        {
            currentHp -= 0.05 * currentHp * 0.0001;
            yield return new WaitForSeconds(0.05f);
        }
        isDebuff[(int)Main.Debuff.poison] = false;
    }
    public virtual void Dead() {
    }
    public virtual void InstantiateDamage(double damage, SKILL.DamageKind damageKind)
    {
        if (!main.systemController.noMoreDamageTxt)
        {
            switch (damageKind)
            {
                case SKILL.DamageKind.physical:
                    GameObject damageText;
                    damageText = Instantiate(main.prefabAry_H[0], main.Transforms[1]);
                    damageText.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
                    damageText.GetComponent<RectTransform>().anchoredPosition += new Vector2(UnityEngine.Random.Range(-30, 30), UnityEngine.Random.Range(-30, 30));
                    damageText.GetComponentInChildren<TextMeshProUGUI>().text = "- " + tDigit(damage, 1);
                    break;

                case SKILL.DamageKind.magical:
                    GameObject damageTextMag;
                    damageTextMag = Instantiate(main.prefabAry_H[0], main.Transforms[1]);
                    damageTextMag.GetComponentInChildren<TextMeshProUGUI>().color = Color.magenta;
                    damageTextMag.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
                    damageTextMag.GetComponent<RectTransform>().anchoredPosition += new Vector2(UnityEngine.Random.Range(-30, 30), UnityEngine.Random.Range(-30, 30));
                    damageTextMag.GetComponentInChildren<TextMeshProUGUI>().text = "- " + tDigit(damage, 1);
                    break;

                case SKILL.DamageKind.electrical:
                    GameObject damageTextElect;
                    damageTextElect = Instantiate(main.prefabAry_H[0], main.Transforms[1]);
                    damageTextElect.GetComponentInChildren<TextMeshProUGUI>().color = Color.yellow;
                    damageTextElect.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
                    damageTextElect.GetComponent<RectTransform>().anchoredPosition += new Vector2(UnityEngine.Random.Range(-30, 30), UnityEngine.Random.Range(-30, 30));
                    damageTextElect.GetComponentInChildren<TextMeshProUGUI>().text = "- " + tDigit(damage, 1);
                    break;

                case SKILL.DamageKind.divine:
                    GameObject damageTextDivine;
                    damageTextDivine = Instantiate(main.prefabAry_H[0], main.Transforms[1]);
                    damageTextDivine.GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
                    damageTextDivine.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
                    damageTextDivine.GetComponent<RectTransform>().anchoredPosition += new Vector2(UnityEngine.Random.Range(-30, 30), UnityEngine.Random.Range(-30, 30));
                    damageTextDivine.GetComponentInChildren<TextMeshProUGUI>().text = "- " + tDigit(damage, 1);
                    break;

                default:
                    break;
            }
        }
    }
    public void ElectricDamage(double calDam)
    {
        if (isDebuff[(int)Main.Debuff.electricalShock])
        {

            double damage = calDam * (0.2 + Math.Max(Normal.Sample(0.2, 0.1), -0.19));
            currentHp -= damage;
            InstantiateDamage(damage, SKILL.DamageKind.electrical);
        }
        else
        {
            return;
        }
    }
    public IEnumerator UpdateText()
    {
        while (true)
        {
            updateText();
            yield return new WaitForSeconds(0.1f);
        }
    }

    //魔法系のみisChantingを使う
    [NonSerialized]
    public bool isChanting;

    public virtual IEnumerator Move()
    {
        //isChanting = true;

        while (true)
        {

            switch (condition)
            {
                case MoveMode:
                    Vector2 moveDistance = targetEnemyPosition.anchoredPosition - thisRect.anchoredPosition;
                    ActualMove(MoveSpeed);
                    if (vectorAbs(moveDistance) <= AttackRange)
                    {
                        condition = BattleMode;
                    }
                    yield return new WaitForSeconds(0.05f);
                    break;
                case BattleMode:
                        yield return new WaitUntil(() => !isChanting);
                    Attacking();
                    break;
            }

        }
    }




    public virtual void ActualMove(float factor = 1.0f)
    {
            thisRect.anchoredPosition += normalize(targetEnemyPosition.anchoredPosition - thisRect.anchoredPosition) * factor
                * Convert.ToInt32(!isDebuff[(int)Main.Debuff.freeze]) * (1 - Convert.ToInt32(isDebuff[(int)Main.Debuff.cold]) * 0.5f) * canMove();
    }
    public int canMove()
    {
        if (main.ally.currentHp <= 0)
            return 0;
        else
            return 1;
    }
    public IEnumerator NormilizeStatus()
    {
        int[] timeStep = new int[isDebuff.Length];

        while (true)
        {   
            for(int i = 0; i < isDebuff.Length; i++)
            {
                if (isDebuff[i])
                {
                    timeStep[i]++;
                    if (timeStep[i] >= 30)
                    {
                        isDebuff[i] = false;
                        timeStep[i] = 0;
                    }
                }
                else
                {
                    timeStep[i] = 0;
                }
            }
            yield return new WaitForSeconds(1.0f);
        }
    }

    public IEnumerator SearchDecoy()
    {
        while (true)
        {
           yield return new WaitUntil(() => { return main.activeSkills[2].GetComponent<Avater>().avater1 !=null
               || main.activeSkills[2].GetComponent<Avater>().avater2 != null;});
            //2体いる時
            if(main.activeSkills[2].GetComponent<Avater>().avater1 != null&& main.activeSkills[2].GetComponent<Avater>().avater2 != null)
            {
                targetEnemy = UnityEngine.Random.Range(0, 2) == 0 ? main.activeSkills[2].GetComponent<Avater>().avater1.gameObject :
                    main.activeSkills[2].GetComponent<Avater>().avater2.gameObject;
            }else if(main.activeSkills[2].GetComponent<Avater>().avater1 != null)
            {
                targetEnemy = main.activeSkills[2].GetComponent<Avater>().avater1.gameObject;
            }
            else if(main.activeSkills[2].GetComponent<Avater>().avater2 != null)
            {
                targetEnemy = main.activeSkills[2].GetComponent<Avater>().avater2.gameObject;
            }
            targetEnemyPosition = targetEnemy.GetComponent<RectTransform>();
            yield return new WaitUntil(() => targetEnemy == null);
            targetEnemy = main.ally1;
            targetEnemyPosition = targetEnemy.GetComponent<RectTransform>();
            condition = ALLY.Condition.MoveMode;
        }
    }

    public void InstantiateLine(string text, Color color)
    {

        GameObject Text;
        Text = Instantiate(main.animationObject[55], main.WindowShowCanvas);
        Text.GetComponent<RectTransform>().anchoredPosition = new Vector2(175f, 150f);
        Text.GetComponentInChildren<TextMeshProUGUI>().text = text;
        Text.GetComponentInChildren<TextMeshProUGUI>().color = color;
        Text.GetComponentInChildren<TextMeshProUGUI>().color -= new Color(0, 0, 0, 1.0f);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(eventData.pointerId == -1)
        {
            main.ally.targetEnemy = null;
            main.ally.condition = ALLY.Condition.MoveMode;
            GameObject[] taggedEnemy = GameObject.FindGameObjectsWithTag("enemy");

            foreach (GameObject game in taggedEnemy)
            {
                game.GetComponent<ENEMY>().isTargetted = false;  
            }

            isTargetted = true;
        }
    }

    public IEnumerator I_AttackObject(GameObject animatedObj, RectTransform transform, double damage = 0, double consumeMp = 0,
    SKILL.DamageKind damageKind = SKILL.DamageKind.physical, Main.Debuff debuff = Main.Debuff.nothing)
    {
        setActive(mpSlider);
        isChanting = true;
     //   for (int i = 0; i < 50; i++)
     //   {
     //       mpSlider.GetComponent<Slider>().value = (float)i * 0.02f;
     //       if (mahouzin != null)
     //       {
     //           mahouzin.transform.Rotate(new Vector3(0, 0, 90) * 0.1f);
     //       }
     //       yield return new WaitForSeconds(AttackSpeed() / 50);
     //   }

        while(mpSlider.GetComponent<Slider>().value < 1)
        {
            if (AttackSpeed() >= 1)
            {
                mpSlider.GetComponent<Slider>().value += 0.02f;
                if (mahouzin != null)
                {
                    mahouzin.transform.Rotate(new Vector3(0, 0, 90) * 0.1f);
                }
                yield return new WaitForSeconds(AttackSpeed() / 50);
            }
            else if (AttackSpeed() >= 0.5)
            {
                mpSlider.GetComponent<Slider>().value += 0.04f;
                if (mahouzin != null)
                {
                    mahouzin.transform.Rotate(new Vector3(0, 0, 90) * 0.15f);
                }
                yield return new WaitForSeconds(AttackSpeed() / 25);
            }
            else if (AttackSpeed() >= 0.2)
            {
                mpSlider.GetComponent<Slider>().value += 0.1f;
                if (mahouzin != null)
                {
                    mahouzin.transform.Rotate(new Vector3(0, 0, 90) * 0.2f);
                }
                yield return new WaitForSeconds(AttackSpeed() / 10);
            }
            else
            {
                mpSlider.GetComponent<Slider>().value += 0.2f;
                if (mahouzin != null)
                {
                    mahouzin.transform.Rotate(new Vector3(0, 0, 90) * 0.25f);
                }
                yield return new WaitForSeconds(AttackSpeed() / 5);
            }

        }

            //距離を計算して，だめだったら待つ
            if (!CanAttack())
        {
            isChanting = false;
            yield break;
        }

        Attack game;
        game = Instantiate(animatedObj, main.Transforms[1]).GetComponent<Attack>();
        SetAbnormal(game);
        switch (damageKind)
        {
            case SKILL.DamageKind.physical:
                game.GetComponent<Attack>().damage = damage;
                game.GetComponent<Attack>().damageKind = SKILL.DamageKind.physical;
                main.SoundEffectSource.PlayOneShot(main.sound.enemyAtkClip);
                break;
            case SKILL.DamageKind.magical:
                game.GetComponent<Attack>().mDamage = damage;
                game.GetComponent<Attack>().damageKind = SKILL.DamageKind.magical;
                main.SoundEffectSource.PlayOneShot(main.sound.magicalAtkClip);
                break;
            case SKILL.DamageKind.divine:
                game.GetComponent<Attack>().critDamage = damage;
                game.GetComponent<Attack>().damageKind = SKILL.DamageKind.divine;
                //main.SoundEffectSource.PlayOneShot(main.sound.magicalAtkClip);
                break;
            case SKILL.DamageKind.banana:
                game.GetComponent<Attack>().critDamage = damage;
                game.GetComponent<Attack>().damageKind = SKILL.DamageKind.banana;
                //main.SoundEffectSource.PlayOneShot(main.sound.magicalAtkClip);
                break;
            default:
                break;
        }
        game.GetComponent<Attack>().thisDebuff = debuff;
        if(game != null)
            game.GetComponent<RectTransform>().anchoredPosition = transform.anchoredPosition;
        isChanting = false;

        if (consumeMp > 0)
        {
            main.ally.currentMp -= consumeMp;
        }

        if (game != null)
        {
            game.gameObject.AddComponent<DestroyAnimation>();
        }

        mpSlider.GetComponent<Slider>().value = 0;
    }

    public IEnumerator InstantiateAnimation(GameObject animatedObj, RectTransform transform, double damage = 0, double consumeMp = 0,
SKILL.DamageKind damageKind = SKILL.DamageKind.physical)
    {
        setActive(mpSlider);
        isChanting = true;
        for (int i = 0; i < 50; i++)
        {
            mpSlider.GetComponent<Slider>().value = (float)i * 0.02f;
            if (mahouzin != null)
            {
                mahouzin.transform.Rotate(new Vector3(0, 0, 90) * 0.1f);
            }
            yield return new WaitForSeconds(AttackSpeed() / 50);
        }
        GameObject game;
        game = Instantiate(animatedObj, main.Transforms[1]);
        switch (damageKind)
        {
            case SKILL.DamageKind.physical:
                game.GetComponent<Attack>().damage = damage;
                game.GetComponent<Attack>().damageKind = SKILL.DamageKind.physical;
                break;
            case SKILL.DamageKind.magical:
                game.GetComponent<Attack>().mDamage = damage;
                game.GetComponent<Attack>().damageKind = SKILL.DamageKind.magical;
                break;
            case SKILL.DamageKind.divine:
                game.GetComponent<Attack>().critDamage = damage;
                game.GetComponent<Attack>().damageKind = SKILL.DamageKind.divine;
                break;
            default:
                break;
        }
        game.GetComponent<RectTransform>().anchoredPosition = transform.anchoredPosition;
        isChanting = false;
        Destroy(game);
    }

    public IEnumerator FillSlider(Slider slider, float interval)
    {
        setActive(slider.gameObject);
        slider.value = 0;
        for (int i = 0; i < 50; i++)
        {
            slider.value += 1.0f / 50f;
            yield return new WaitForSeconds(interval / 50);
        }
        setFalse(slider.gameObject);
    }

    public IEnumerator FillSlider()
    {
        isChanting = true;
        setActive(mpSlider.gameObject);
        mpSlider.GetComponent<Slider>().value = 0;
        for (int i = 0; i < 50; i++)
        {
            mpSlider.GetComponent<Slider>().value += 1.0f / 50f;
            yield return new WaitForSeconds(AttackSpeed() / 50);
        }
        setFalse(mpSlider.GetComponent<Slider>().gameObject);
        isChanting = false;
    }

    public virtual void SetAbnormal(Attack attack) { }
}