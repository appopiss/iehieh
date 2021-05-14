using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static ArtiCtrl.MaterialList;
using IdleLibrary;
using static BASE;

public class ArtiCtrl : BASE {

    public GameObject currentCanvas;
    public Coroutine UpdateMaterial;

	// Use this for initialization
	void Awake () {
		StartBASE();
        currentCanvas = main.ArtifactCanvas[0];
        for (int i = 0; i < main.ArtifactCanvas.Length; i++)
        {
            int count = i;
            main.A_rankButton[count].onClick.AddListener(() => setSibling(count));
        }
        foreach (MaterialList material in Enum.GetValues(typeof(MaterialList)))
        {
            CurrentMaterial.Add(material, materialNum[(int)material]);
        }
        //素材大量デバッグ
        /*
        foreach (MaterialList material in Enum.GetValues(typeof(MaterialList)))
        {
            CurrentMaterial[material] += 10000000;
        }
        */  
    }

	// Use this for initialization
	void Start () {
        UpdateMaterial = StartCoroutine(updateMaterial());
        StartCoroutine(CheckDropItem());
    }

    public void setSibling(int count)
    {
        if(currentCanvas == main.ArtifactCanvas[count])
        {
            return;
        }
        else
        {
            currentCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(-500,0);
            main.ArtifactCanvas[count].GetComponent<RectTransform>().anchoredPosition += new Vector2(500,0);
            currentCanvas = main.ArtifactCanvas[count].gameObject;
        }
    }

    //public void GetEC(int ec)
    //{
    //    if (main.S.ReincarnationNum == 0)
    //        main.S.ECbyMission += ec;
    //}
	
	// Update is called once per frame
	void Update () {
        updateMaterial();
	}

    public Dictionary<MaterialList, int> CurrentMaterial = new Dictionary<MaterialList, int>();
    //各色汎用素材
    //Red heart
    //Blue tear
    //Golden liquid
    //Green Crystal
    //Purple skin
    public enum MaterialList
    {
        //色
        FrostShard,
        FrostCrystal,
        FlameShard,
        FlameCrystal,
        LightningShard,
        LightningCrystal,
        NatureShard,
        NatureCrystal,
        PoisonShard,
        PoisonCrystal,
        GoldenShard,
        GoldenCrystal,
        LifeShard,
        LifeCrystal,
        ManaShard,
        ManaCrystal,
        //New Update
        MonsterFluid,
        RelicStone ,
        CarvedIdol,
        BlackPearl,
        AncientCoin ,
        OozeStainedCloth ,
        GooeySludge ,
        OilOfSlime ,
        AcidicGoop,
        SlimeEyeBall,
        SlimeCrown ,
        SlimeCore,
        //bat
        BatPelt,
        BatWing,
        BatTooth,
        BatFeet,
        IntactBatHead,
        BatHeart,
        BatCore,
        //fairy
        FairyDust,
        FairyWing,
        BloodOfFairy,
        SpiderBlood,
        SpiderFang,
        VenomSoakedCloth,
        FishScales,
        SharpFin,
        FishTail,
        RubberyBlob,
        MiniatureSword,
        RubberCrown,
        FoxPelt,
        FoxTail,
        IntactNineTail,
        EnchantedCloth,
        FairyCoin,
        FairyHeart,
        SpiderSilk,
        SpiderLeg,
        SpiderHeart,
        RuinedSpellBook,
        FishTeeth,
        SmallTreasureChest,
        MinuatureSheild,
        DeflatedBallCorpse,
        FoxEar,
        WhiteFoxPelt,
        MysticGemStone,
        WebbedCore,
        GlowingSludge,
        OddMagicalHat,
        DevilFishCore,
        BallHeart,
        FoxEye,
        FoxHeart,
        FairyCore,
        MagicSlimeCore,
        BallCore,
        FoxCore,
        ShinySlimeCrown,
        FairyQueenDust,
        RobustBone,
        RottenBanana,
        PotentVenomSample,
        SlimeSceptre,
        EnchantedSapling,
        GolemShard,
        RipeBanana,
        SpiderIronSilk,
        SlimeKingGoop,
        FairyQueenWand,
        StoneHeart,
        BananaDagger,
        SpiderEggSac,
        SlimeKingCore,
        FairyQueenCore,
        GolemCore,
        BananoonCore,
        DeathpiderCore,
        SeveredTentacle,
        OctopusEye,
        InkGland,
        OctobaddieCore,


        

        //消費アイテム素材
       // RedPortion ,
       // BluePortion,
       // CurePortion,
       // SpicyPortion,
       // PoisonBanana,
        //素材たち
        Herb,
        Mashroom ,
        LuckySeed ,
        Berry ,
        MagicSeed,
        RedChili,
        Stone ,
        Crystal,
        Leaf,
        SlimeTongue ,
        //ゴーレム
        GolemFragment ,    
        HeartStone ,
        FairyBlood ,
        //bananoon
        BigEye ,
        //Spider
        PoisonEssence ,
        AdamantSilk ,
        //DistortionSlime
        DarkMatter ,
        GrotesqueEye ,
        //特殊素材
        WarriorSoul ,
        WizardSoul,
        AngelSoul,
        ProofOfWarrior,
        ProofOfWizard,
        ProofOfAngel,

        //クエストアイテム
        RainbowFish ,
        ShabbyPurse ,
        PoppyWinstonNeckless,
        gold,
        nothing,

    }
    public enum ConsumeItemList
    {
        itemA,
        itemB,
        itemC,
        itemAA,
        itemBB,
        itemCC,
        itemAAA,
        itemBBB,
        itemCCC,
        itemAAAA,
        itemBBBB,
        itemCCCC,
        itemAAAAA,
        itemBBBBB,
        itemCCCCC,
    }
    //素材の所持数のみをセーブする．
    public int[] materialNum { get => main.S.materialNum; set => main.S.materialNum = value; }
    public int[] consumeItemNum { get => main.S.consumeItemNum; set => main.S.consumeItemNum = value; }

   // void updateMaterial()
   // {
   //
   // }
    IEnumerator updateMaterial()
    {
        while (true)
        {
            if (main.rein.isStartedRein)
                break;
            foreach (KeyValuePair<MaterialList, int> material in CurrentMaterial)
            {
                materialNum[(int)material.Key] = material.Value;
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    public string ConvertEnum(Enum material)
    {
        if(material is ArtiCtrl.MaterialList)
        {
            if (LocalizeInitialize.language == Language.jp)
            {
                switch (material)
                {
                    case Stone:
                        return "ストーン";
                    case Crystal:
                        return "クリスタル";
                    case Leaf:
                        return "リーフ";
                    case MonsterFluid:
                        return "モンスターの体液";
                    case RelicStone:
                        return "古びた石";
                    case BlackPearl:
                        return "黒い真珠";
                    case OozeStainedCloth:
                        return "薄汚れた布";
                    case OilOfSlime:
                        return "スライムの油";
                    case AcidicGoop:
                        return "べとべとの酸";
                    case BatPelt:
                        return "こうもりの毛皮";
                    case BatTooth:
                        return "こうもりの歯";
                    case BatFeet:
                        return "こうもりの足";
                    case FairyDust:
                        return "妖精の粉塵";
                    case FairyWing:
                        return "妖精の羽";
                    case BloodOfFairy:
                        return "妖精の血";
                    case SpiderBlood:
                        return "クモの血";
                    case SpiderFang:
                        return "クモの牙";
                    case VenomSoakedCloth:
                        return "血に染まった布";
                    case SlimeEyeBall:
                        return "スライムの目玉";
                    case FishScales:
                        return "魚の鱗";
                    case SharpFin:
                        return "とがったヒレ";
                    case FishTail:
                        return "魚の尾";
                    case RubberyBlob:
                        return "ぶよぶよしたゴム";
                    case MiniatureSword:
                        return "ミニチュアの剣";
                    case RubberCrown:
                        return "ゴムでできた王冠";
                    case FoxPelt:
                        return "狐の毛皮";
                    case FoxTail:
                        return "狐の尾";
                    case IntactNineTail:
                        return "傷一つない九尾の尾";
                    case FrostShard:
                        return "氷の破片";
                    case FlameShard:
                        return "炎の破片";
                    case LightningShard:
                        return "雷の破片";
                    case NatureShard:
                        return "自然の破片";
                    case PoisonShard:
                        return "毒の破片";
                    case GoldenShard:
                        return "金の破片";
                    case LifeShard:
                        return "生命の破片";
                    case ManaShard:
                        return "マナの破片";
                    case CarvedIdol:
                        return "刻まれた偶像";
                    case AncientCoin:
                        return "古代の通貨";
                    case GooeySludge:
                        return "ねばねばしたヘドロ";
                    case BatWing:
                        return "こうもりの羽";
                    case IntactBatHead:
                        return "傷一つないこうもりの頭";
                    case EnchantedCloth:
                        return "魔法の布";
                    case FairyCoin:
                        return "妖精の通貨";
                    case FairyHeart:
                        return "妖精の心臓";
                    case SpiderSilk:
                        return "クモの糸";
                    case SpiderLeg:
                        return "クモの足";
                    case SpiderHeart:
                        return "クモの心臓";
                    case RuinedSpellBook:
                        return "古びた魔法書";
                    case FishTeeth:
                        return "魚の歯";
                    case SmallTreasureChest:
                        return "小さな宝箱";
                    case DeflatedBallCorpse:
                        return "収縮して腐敗した目玉";
                    case FoxEar:
                        return "狐の耳";
                    case WhiteFoxPelt:
                        return "白狐の毛皮";
                    case FrostCrystal:
                        return "氷のクリスタル";
                    case FlameCrystal:
                        return "炎のクリスタル";
                    case LightningCrystal:
                        return "雷のクリスタル";
                    case NatureCrystal:
                        return "自然のクリスタル";
                    case PoisonCrystal:
                        return "毒のクリスタル";
                    case GoldenCrystal:
                        return "金のクリスタル";
                    case LifeCrystal:
                        return "生命のクリスタル";
                    case ManaCrystal:
                        return "マナのクリスタル";
                    case SlimeCrown:
                        return "スライムの王冠";
                    case BatHeart:
                        return "こうもりの心臓";
                    case MysticGemStone:
                        return "神秘的な宝石";
                    case WebbedCore:
                        return "クモの核";
                    case GlowingSludge:
                        return "光るべとべと";
                    case OddMagicalHat:
                        return "変な魔法の帽子";
                    case DevilFishCore:
                        return "悪魔魚の核";
                    case BallHeart:
                        return "目玉の核";
                    case FoxEye:
                        return "狐の目";
                    case FoxHeart:
                        return "狐の心臓";
                    case SlimeCore:
                        return "スライムの核";
                    case BatCore:
                        return "こうもりの核";
                    case FairyCore:
                        return "妖精の核";
                    case MagicSlimeCore:
                        return "魔法スライムの核";
                    case BallCore:
                        return "目玉の核";
                    case FoxCore:
                        return "狐の核";
                    case ShinySlimeCrown:
                        return "輝くスライムの王冠";
                    case FairyQueenDust:
                        return "妖精の女王の粉塵";
                    case RobustBone:
                        return "しっかりした骨";
                    case RottenBanana:
                        return "腐ったバナナ";
                    case PotentVenomSample:
                        return "劇烈な毒の試料";
                    case SlimeSceptre:
                        return "スライムのセプター";
                    case EnchantedSapling:
                        return "魔法の苗木";
                    case GolemShard:
                        return "ゴーレムの破片";
                    case RipeBanana:
                        return "熟れたバナナ";
                    case SpiderIronSilk:
                        return "クモの鉄糸";
                    case SlimeKingGoop:
                        return "スライム王のべとべと";
                    case FairyQueenWand:
                        return "妖精の女王の杖";
                    case StoneHeart:
                        return "鉄の心臓";
                    case BananaDagger:
                        return "バナナの剣";
                    case SpiderEggSac:
                        return "クモの卵嚢";
                    case SlimeKingCore:
                        return "スライムキングの核";
                    case FairyQueenCore:
                        return "妖精の女王の核";
                    case GolemCore:
                        return "ゴーレムの核";
                    case BananoonCore:
                        return "ババヌーンの核";
                    case DeathpiderCore:
                        return "デスパイダーの核";
                    case SeveredTentacle:
                        return "切断された触手";
                    case OctopusEye:
                        return "タコの目";
                    case InkGland:
                        return "インク腺";
                    case OctobaddieCore:
                        return "オクトバディの核";
                    case RedChili:
                        return "レッドチリ";
                    case Herb:
                        return "ハーブ";
                    case Berry:
                        return "ベリー";
                    case MagicSeed:
                        return "魔法の種";
                }
            }
            else if (LocalizeInitialize.language == Language.chi)
            {
                switch (material)
                {
                    case Stone:
                        return "石头";
                    case Crystal:
                        return "水晶";
                    case Leaf:
                        return "叶子";
                    case MonsterFluid:
                        return "怪物魔液";
                    case RelicStone:
                        return "遗迹之石";
                    case BlackPearl:
                        return "黑珍珠";
                    case OozeStainedCloth:
                        return "软泥染色布";
                    case OilOfSlime:
                        return "史莱姆油";
                    case AcidicGoop:
                        return "质酸黏物";
                    case BatPelt:
                        return "魔蝠毛皮";
                    case BatTooth:
                        return "魔蝠尖牙";
                    case BatFeet:
                        return "魔蝠魔爪";
                    case FairyDust:
                        return "精灵之尘";
                    case FairyWing:
                        return "精灵之翼";
                    case BloodOfFairy:
                        return "精灵魔血";
                    case SpiderBlood:
                        return "魔蛛之血";
                    case SpiderFang:
                        return "魔蛛之牙";
                    case VenomSoakedCloth:
                        return "毒液浸泡布";
                    case SlimeEyeBall:
                        return "史莱姆眼珠";
                    case FishScales:
                        return "魔鱼之鳞";
                    case SharpFin:
                        return "魔鱼之鳍";
                    case FishTail:
                        return "魔鱼之尾";
                    case RubberyBlob:
                        return "弹力滴液";
                    case MiniatureSword:
                        return "微型之剑";
                    case RubberCrown:
                        return "橡胶皇冠";
                    case FoxPelt:
                        return "魔狐之皮";
                    case FoxTail:
                        return "魔狐之尾l";
                    case IntactNineTail:
                        return "无损九指l";
                    case FrostShard:
                        return "冰霜碎片";
                    case FlameShard:
                        return "火焰碎片";
                    case LightningShard:
                        return "闪电碎片";
                    case NatureShard:
                        return "自然碎片";
                    case PoisonShard:
                        return "恶毒碎片";
                    case GoldenShard:
                        return "黄金碎片";
                    case LifeShard:
                        return "生命碎片";
                    case ManaShard:
                        return "魔力碎片";
                    case CarvedIdol:
                        return "偶像雕塑";
                    case AncientCoin:
                        return "远古钱币";
                    case GooeySludge:
                        return "黏黏的泥";
                    case BatWing:
                        return "魔蝠之翼";
                    case IntactBatHead:
                        return "完整的魔蝠头";
                    case EnchantedCloth:
                        return "魔法织布";
                    case FairyCoin:
                        return "精灵硬币";
                    case FairyHeart:
                        return "精灵之心";
                    case SpiderSilk:
                        return "魔蛛网";
                    case SpiderLeg:
                        return "魔蛛之腿";
                    case SpiderHeart:
                        return "魔蛛之心";
                    case RuinedSpellBook:
                        return "被摧毁的魔法书";
                    case FishTeeth:
                        return "魔鱼之齿";
                    case SmallTreasureChest:
                        return "小小宝箱";
                    case DeflatedBallCorpse:
                        return "泄气的魔球尸体";
                    case FoxEar:
                        return "魔狐之耳";
                    case WhiteFoxPelt:
                        return "白狐之皮";
                    case FrostCrystal:
                        return "冰霜水晶";
                    case FlameCrystal:
                        return "火焰水晶";
                    case LightningCrystal:
                        return "闪电水晶";
                    case NatureCrystal:
                        return "自然水晶";
                    case PoisonCrystal:
                        return "恶毒水晶";
                    case GoldenCrystal:
                        return "黄金水晶";
                    case LifeCrystal:
                        return "生命水晶";
                    case ManaCrystal:
                        return "魔力水晶";
                    case SlimeCrown:
                        return "史莱姆皇冠";
                    case BatHeart:
                        return "魔蝠之心";
                    case MysticGemStone:
                        return "神秘的宝石";
                    case WebbedCore:
                        return "魔网之核";
                    case GlowingSludge:
                        return "灼热的淤泥";
                    case OddMagicalHat:
                        return "古怪的魔法帽";
                    case DevilFishCore:
                        return "魔鬼鱼之核";
                    case BallHeart:
                        return "魔球之心";
                    case FoxEye:
                        return "魔狐之眼";
                    case FoxHeart:
                        return "魔狐之心";
                    case SlimeCore:
                        return "史莱姆之核";
                    case BatCore:
                        return "魔蝠之核";
                    case FairyCore:
                        return "精灵之核";
                    case MagicSlimeCore:
                        return "魔法史莱姆之核";
                    case BallCore:
                        return "魔球之核";
                    case FoxCore:
                        return "魔狐之核";
                    case ShinySlimeCrown:
                        return "亮晶晶的史莱姆之冠";
                    case FairyQueenDust:
                        return "精灵女皇之尘";
                    case RobustBone:
                        return "强健的骨骼";
                    case RottenBanana:
                        return "腐烂的香蕉";
                    case PotentVenomSample:
                        return "强力毒液样品";
                    case SlimeSceptre:
                        return "史莱姆权杖";
                    case EnchantedSapling:
                        return "魔力树苗";
                    case GolemShard:
                        return "魔像碎片";
                    case RipeBanana:
                        return "熟透的香蕉";
                    case SpiderIronSilk:
                        return "魔蛛铁丝网";
                    case SlimeKingGoop:
                        return "史莱姆之王的黏物";
                    case FairyQueenWand:
                        return "精灵女皇的魔杖";
                    case StoneHeart:
                        return "石之心";
                    case BananaDagger:
                        return "香蕉匕首";
                    case SpiderEggSac:
                        return "蜘蛛软囊";
                    case SlimeKingCore:
                        return "史莱姆之王核心";
                    case FairyQueenCore:
                        return "精灵女皇之核";
                    case GolemCore:
                        return "魔像之核";
                    case BananoonCore:
                        return "巴纳农之核";
                    case DeathpiderCore:
                        return "死亡蜘蛛之核";
                    case SeveredTentacle:
                        return "切断的触手";
                    case OctopusEye:
                        return "章鱼之眼";
                    case InkGland:
                        return "墨汁腺体";
                    case OctobaddieCore:
                        return "恶物之核";
                    case RedChili:
                        return "红辣椒";
                    case Herb:
                        return "草药";
                    case Berry:
                        return "浆果";
                    case MagicSeed:
                        return "魔法种子";
                }
            }
            else
            {
                switch (material)
                {
                    case Stone:
                        return "stone";
                    case Crystal:
                        return "crystal";
                    case Leaf:
                        return "leaf";
                    case MonsterFluid:
                        return "Monster Fluid";
                    case RelicStone:
                        return "Relic Stone";
                    case BlackPearl:
                        return "Black Pearl";
                    case OozeStainedCloth:
                        return "Ooze Stained Cloth";
                    case OilOfSlime:
                        return "Oil of Slime";
                    case AcidicGoop:
                        return "Acidic Goop";
                    case BatPelt:
                        return "Bat Pelt";
                    case BatTooth:
                        return "Bat Tooth";
                    case BatFeet:
                        return "Bat Feet";
                    case FairyDust:
                        return "Fairy Dust";
                    case FairyWing:
                        return "Fairy Wing";
                    case BloodOfFairy:
                        return "Blood of Fairy";
                    case SpiderBlood:
                        return "Spider Blood";
                    case SpiderFang:
                        return "Spider Fang";
                    case VenomSoakedCloth:
                        return "Venom Soaked Cloth";
                    case SlimeEyeBall:
                        return "Slime Eye Ball";
                    case FishScales:
                        return "Fish Scale";
                    case SharpFin:
                        return "Sharp Fin";
                    case FishTail:
                        return "Fish Tail";
                    case RubberyBlob:
                        return "Rubbery Blob";
                    case MiniatureSword:
                        return "Miniature Sword";
                    case RubberCrown:
                        return "Rubber Crown";
                    case FoxPelt:
                        return "Fox Pelt";
                    case FoxTail:
                        return "Fox Tail";
                    case IntactNineTail:
                        return "Intact Nine Tail";
                    case FrostShard:
                        return "Frost Shard";
                    case FlameShard:
                        return "Flame Shard";
                    case LightningShard:
                        return "Lightning Shard";
                    case NatureShard:
                        return "Nature Shard";
                    case PoisonShard:
                        return "Poison Shard";
                    case GoldenShard:
                        return "Golden Shard";
                    case LifeShard:
                        return "Life Shard";
                    case ManaShard:
                        return "Mana Shard";
                    case CarvedIdol:
                        return "Carved Idol";
                    case AncientCoin:
                        return "Ancient Coin";
                    case GooeySludge:
                        return "Gooey Sludge";
                    case BatWing:
                        return "Bat Wing";
                    case IntactBatHead:
                        return "Intact Bat Head";
                    case EnchantedCloth:
                        return "Enchanted Cloth";
                    case FairyCoin:
                        return "Fairy Coin";
                    case FairyHeart:
                        return "Fairy Heart";
                    case SpiderSilk:
                        return "Spider Silk";
                    case SpiderLeg:
                        return "Spider Leg";
                    case SpiderHeart:
                        return "Spider Heart";
                    case RuinedSpellBook:
                        return "Ruined Spell Book";
                    case FishTeeth:
                        return "Fish Teeth";
                    case SmallTreasureChest:
                        return "Small Treasure Chest";
                    case DeflatedBallCorpse:
                        return "Deflated Ball Corpse";
                    case FoxEar:
                        return "Fox Ear";
                    case WhiteFoxPelt:
                        return "White Fox Pelt";
                    case FrostCrystal:
                        return "Frost Crystal";
                    case FlameCrystal:
                        return "Flame Crystal";
                    case LightningCrystal:
                        return "Lightning Crystal";
                    case NatureCrystal:
                        return "Nature Crystal";
                    case PoisonCrystal:
                        return "Poison Crystal";
                    case GoldenCrystal:
                        return "Golden Crystal";
                    case LifeCrystal:
                        return "Life Crystal";
                    case ManaCrystal:
                        return "Mana Crystal";
                    case SlimeCrown:
                        return "Slime Crown";
                    case BatHeart:
                        return "Bat Heart";
                    case MysticGemStone:
                        return "Mystic Gem Stone";
                    case WebbedCore:
                        return "Webbed Core";
                    case GlowingSludge:
                        return "Glowing Sludge";
                    case OddMagicalHat:
                        return "Odd Magical Hat";
                    case DevilFishCore:
                        return "Devil Fish Core";
                    case BallHeart:
                        return "Ball Heart";
                    case FoxEye:
                        return "Fox Eye";
                    case FoxHeart:
                        return "Fox Heart";
                    case SlimeCore:
                        return "Slime Core";
                    case BatCore:
                        return "Bat Core";
                    case FairyCore:
                        return "Fairy Core";
                    case MagicSlimeCore:
                        return "Magic Slime Core";
                    case BallCore:
                        return "Ball Core";
                    case FoxCore:
                        return "Fox Core";
                    case ShinySlimeCrown:
                        return "Shiny Slime Crown";
                    case FairyQueenDust:
                        return "Fairy Queen Dust";
                    case RobustBone:
                        return "Robust Bone";
                    case RottenBanana:
                        return "Rotten Banana";
                    case PotentVenomSample:
                        return "Potent Venom Sample";
                    case SlimeSceptre:
                        return "Slime Sceptre";
                    case EnchantedSapling:
                        return "Enchanted Sapling";
                    case GolemShard:
                        return "Golem Shard";
                    case RipeBanana:
                        return "Ripe Banana";
                    case SpiderIronSilk:
                        return "Spider Iron Silk";
                    case SlimeKingGoop:
                        return "Slime King Goop";
                    case FairyQueenWand:
                        return "Fairy Queen Wand";
                    case StoneHeart:
                        return "Stone Heart";
                    case BananaDagger:
                        return "Banana Dagger";
                    case SpiderEggSac:
                        return "Spider Egg Sac";
                    case SlimeKingCore:
                        return "Slime King Core";
                    case FairyQueenCore:
                        return "Fairy Queen Core";
                    case GolemCore:
                        return "Golem Core";
                    case BananoonCore:
                        return "Bananoon Core";
                    case DeathpiderCore:
                        return "Deathpider Core";
                    case SeveredTentacle:
                        return "Severed Tentacle";
                    case OctopusEye:
                        return "Octopus Eye";
                    case InkGland:
                        return "Ink Gland";
                    case OctobaddieCore:
                        return "Octobaddie Core";
                    case RedChili:
                        return "Red Chili";
                    case Herb:
                        return "Herb";
                    case Berry:
                        return "Berry";
                    case MagicSeed:
                        return "Magic Seed";
                }
            }

        }
        if(material is ENEMY.EnemyKind)
        {
            //if (LocalizeInitialize.language == Language.jp)
            //{
            //    switch (material)
            //    {
            //        case ENEMY.EnemyKind.BigSlime:
            //            return "ビッグスライム";
            //        case ENEMY.EnemyKind.NormalSlime:
            //            return "スライム";
            //        case ENEMY.EnemyKind.BlueSlime:
            //            return "ブルースライム";
            //        case ENEMY.EnemyKind.YellowSlime:
            //            return "イエロースライム";
            //        case ENEMY.EnemyKind.GreenSlime:
            //            return "グリーンスライム";
            //        case ENEMY.EnemyKind.OrangeSlime:
            //            return "オレンジスライム";
            //        case ENEMY.EnemyKind.NormalBat:
            //            return "バット";
            //        case ENEMY.EnemyKind.RedSlime:
            //            return "レッドスライム";
            //        case ENEMY.EnemyKind.BlueBat:
            //            return "ブルーバット";
            //        case ENEMY.EnemyKind.YellowBat:
            //            return "イエローバット";
            //        case ENEMY.EnemyKind.PurpleSlime:
            //            return "パープルスライム";
            //        case ENEMY.EnemyKind.GreenBat:
            //            return "グリーンバット";
            //        case ENEMY.EnemyKind.RedBat:
            //            return "レッドバット";
            //        case ENEMY.EnemyKind.OrangeBat:
            //            return "オレンジバット";
            //        case ENEMY.EnemyKind.PurpleBat:
            //            return "パープルバット";
            //        case ENEMY.EnemyKind.BlackBat:
            //            return "ブラックバット";
            //        case ENEMY.EnemyKind.NormalSpider:
            //            return "スパイダー";
            //        case ENEMY.EnemyKind.BlueSpider:
            //            return "ブルースパイダー";
            //        case ENEMY.EnemyKind.YellowSpider:
            //            return "イエロースパイダー";
            //        case ENEMY.EnemyKind.GreenSpider:
            //            return "グリーンスパイダー";
            //        case ENEMY.EnemyKind.RedSpider:
            //            return "レッドスパイダー";
            //        case ENEMY.EnemyKind.PurpleSpider:
            //            return "パープルスパイダー";
            //        case ENEMY.EnemyKind.SpiderQueen:
            //            return "スパイダークイーン";
            //        case ENEMY.EnemyKind.OrangeFox:
            //            return "オレンジフォックス";
            //        case ENEMY.EnemyKind.YellowFox:
            //            return "イエローフォックス";
            //        case ENEMY.EnemyKind.GreenFox:
            //            return "グリーンフォックス";
            //        case ENEMY.EnemyKind.BlueFox:
            //            return "ブルーフォックス";
            //        case ENEMY.EnemyKind.RedFox:
            //            return "レッドフォックス";
            //        case ENEMY.EnemyKind.PurpleFox:
            //            return "パープルフォックス";
            //        case ENEMY.EnemyKind.WhiteFox:
            //            return "ホワイトフォックス";
            //        case ENEMY.EnemyKind.MNormalslime:
            //            return "マジックスライム";
            //        case ENEMY.EnemyKind.SkyFox:
            //            return "スカイフォックス";
            //        case ENEMY.EnemyKind.BlackFox:
            //            return "ブラックフォックス";
            //        case ENEMY.EnemyKind.MBlueslime:
            //            return "ブルーマジックスライム";
            //        case ENEMY.EnemyKind.MYelllowSlime:
            //            return "イエローマジックスライム";
            //        case ENEMY.EnemyKind.WhiteNineTailedFox:
            //            return "ホワイトナインテール";
            //        case ENEMY.EnemyKind.MGreenSlime:
            //            return "グリーンマジックスライム";
            //        case ENEMY.EnemyKind.MOrangeSlime:
            //            return "オレンジマジックスライム";
            //        case ENEMY.EnemyKind.MRedSlime:
            //            return "レッドマジックスライム";
            //        case ENEMY.EnemyKind.BlueDevilFish:
            //            return "ブルーデビルフィッシュ";
            //        case ENEMY.EnemyKind.MPurpleSlime:
            //            return "パープルマジックスライム";
            //        case ENEMY.EnemyKind.BlueBlob:
            //            return "ブルーブロッブ";
            //        case ENEMY.EnemyKind.RedBlob:
            //            return "レッドブロッブ";
            //        case ENEMY.EnemyKind.GreenDevilFish:
            //            return "グリーンデビルフィッシュ";
            //        case ENEMY.EnemyKind.UnknownSlime:
            //            return "アンノーンスライム";
            //        case ENEMY.EnemyKind.OrangeDevilFish:
            //            return "オレンジデビルフィッシュ";
            //        case ENEMY.EnemyKind.BlueCatBlob:
            //            return "ブルーキャットブロッブ";
            //        case ENEMY.EnemyKind.RedCatBlob:
            //            return "レッドキャットブロッブ";
            //        case ENEMY.EnemyKind.BlueRabbitBlob:
            //            return "ブルーラビットブロッブ";
            //        case ENEMY.EnemyKind.RedRabbitBlob:
            //            return "レッドラビットブロッブ";
            //        case ENEMY.EnemyKind.BlueBlobSilent:
            //            return "ブルーサイレントブロッブ";
            //        case ENEMY.EnemyKind.RedBlobSilent:
            //            return "レッドサイレントブロッブ";
            //        case ENEMY.EnemyKind.MutantSlime:
            //            return "ミュータントスライム";
            //        case ENEMY.EnemyKind.RedDevilFish:
            //            return "レッドデビルフィッシュ";
            //        case ENEMY.EnemyKind.PurpleDevilFish:
            //            return "パープルデビルフィッシュ";
            //        case ENEMY.EnemyKind.SkyDevilFish:
            //            return "デビルフィッシュ";
            //        case ENEMY.EnemyKind.YellowDevilFish:
            //            return "イエローデビルフィッシュ";
            //        case ENEMY.EnemyKind.BlueKnightBlob:
            //            return "ブルーナイトブロッブ";
            //        case ENEMY.EnemyKind.RedKnightBlob:
            //            return "レッドナイトブロッブ";
            //        case ENEMY.EnemyKind.BlueKnightBlobSilent:
            //            return "ブルーナイトサイレントブロッブ";
            //        case ENEMY.EnemyKind.RedKnightBlobSilent:
            //            return "レッドナイトサイレントブロッブ";
            //        case ENEMY.EnemyKind.BlueArcherBlob:
            //            return "ブルーアーチャーブロッブ";
            //        case ENEMY.EnemyKind.RedArcherBlob:
            //            return "レッドアーチャーブロッブ";
            //        case ENEMY.EnemyKind.BlueKingBlob:
            //            return "ブルーキングブロッブ";
            //        case ENEMY.EnemyKind.RedKingBlob:
            //            return "レッドキングブロッブ";
            //        case ENEMY.EnemyKind.SlimeBoss:
            //            return "スライムボス";
            //        case ENEMY.EnemyKind.SlimeKing:
            //            return "スライムキング";
            //        case ENEMY.EnemyKind.FairyQueen:
            //            return "フェアリークイーン";
            //        case ENEMY.EnemyKind.Golem:
            //            return "ゴーレム";
            //        case ENEMY.EnemyKind.Bananoon:
            //            return "バナヌーン";
            //        case ENEMY.EnemyKind.Spyder:
            //            return "デスパイダー";
            //        case ENEMY.EnemyKind.Montblango:
            //            return "モンブランゴ";
            //        case ENEMY.EnemyKind.DistortionSlime:
            //            return "ディストーションスライム";
            //        case ENEMY.EnemyKind.MetalSlime:
            //            return "メタルスライム";
            //        case ENEMY.EnemyKind.NormalFairy:
            //            return "フェアリー";
            //        case ENEMY.EnemyKind.BlueFairy:
            //            return "ブルーフェアリー";
            //        case ENEMY.EnemyKind.YellowFairy:
            //            return "イエローフェアリー";
            //        case ENEMY.EnemyKind.GreenFairy:
            //            return "グリーンフェアリー";
            //        case ENEMY.EnemyKind.OrangeFairy:
            //            return "オレンジフェアリー";
            //        case ENEMY.EnemyKind.RedFairy:
            //            return "レッドフェアリー";
            //        case ENEMY.EnemyKind.PurpleFairy:
            //            return "パープルフェアリー";
            //        case ENEMY.EnemyKind.BlackFairy:
            //            return "ブラックフェアリー";
            //        case ENEMY.EnemyKind.Deathpider:
            //            return "デスパイダー";
            //        case ENEMY.EnemyKind.WizardSlime:
            //            return "ウィザードスライム";
            //        case ENEMY.EnemyKind.Octobaddie:
            //            return "オクトバディ";
            //        default:
            //            break;
            //    }
            //}
            //else 
            //{
                switch (material)
                {
                    case ENEMY.EnemyKind.BigSlime:
                        return "Big Slime";
                    case ENEMY.EnemyKind.NormalSlime:
                        return "Normal Slime";
                    case ENEMY.EnemyKind.BlueSlime:
                        return "Blue Slime";
                    case ENEMY.EnemyKind.YellowSlime:
                        return "Yellow Slime";
                    case ENEMY.EnemyKind.GreenSlime:
                        return "Green Slime";
                    case ENEMY.EnemyKind.OrangeSlime:
                        return "Orange Slime";
                    case ENEMY.EnemyKind.NormalBat:
                        return "Normal Bat";
                    case ENEMY.EnemyKind.RedSlime:
                        return "Red Slime";
                    case ENEMY.EnemyKind.BlueBat:
                        return "Blue Bat";
                    case ENEMY.EnemyKind.YellowBat:
                        return "Yellow Bat";
                    case ENEMY.EnemyKind.PurpleSlime:
                        return "Purple Slime";
                    case ENEMY.EnemyKind.GreenBat:
                        return "Green Bat";
                    case ENEMY.EnemyKind.RedBat:
                        return "Red Bat";
                    case ENEMY.EnemyKind.OrangeBat:
                        return "Orange Bat";
                    case ENEMY.EnemyKind.PurpleBat:
                        return "Purple Bat";
                    case ENEMY.EnemyKind.BlackBat:
                        return "Black Bat";
                    case ENEMY.EnemyKind.NormalSpider:
                        return "Normal Spider";
                    case ENEMY.EnemyKind.BlueSpider:
                        return "Blue Spider";
                    case ENEMY.EnemyKind.YellowSpider:
                        return "Yellow Spider";
                    case ENEMY.EnemyKind.GreenSpider:
                        return "Green Spider";
                    case ENEMY.EnemyKind.RedSpider:
                        return "Red Spider";
                    case ENEMY.EnemyKind.PurpleSpider:
                        return "Purple Spider";
                    case ENEMY.EnemyKind.SpiderQueen:
                        return "Spider Queen";
                    case ENEMY.EnemyKind.OrangeFox:
                        return "Orange Fox";
                    case ENEMY.EnemyKind.YellowFox:
                        return "Yellow Fox";
                    case ENEMY.EnemyKind.GreenFox:
                        return "Green Fox";
                    case ENEMY.EnemyKind.BlueFox:
                        return "Blue Fox";
                    case ENEMY.EnemyKind.RedFox:
                        return "Red Fox";
                    case ENEMY.EnemyKind.PurpleFox:
                        return "Purple Fox";
                    case ENEMY.EnemyKind.WhiteFox:
                        return "White Fox";
                    case ENEMY.EnemyKind.MNormalslime:
                        return "Normal Magic Slime";
                    case ENEMY.EnemyKind.SkyFox:
                        return "Sky Fox";
                    case ENEMY.EnemyKind.BlackFox:
                        return "Black Fox";
                    case ENEMY.EnemyKind.MBlueslime:
                        return "Blue Magic Slime";
                    case ENEMY.EnemyKind.MYelllowSlime:
                        return "Yellow Magic Slime";
                    case ENEMY.EnemyKind.WhiteNineTailedFox:
                        return "White Nine Tail";
                    case ENEMY.EnemyKind.MGreenSlime:
                        return "Green Magic Slime";
                    case ENEMY.EnemyKind.MOrangeSlime:
                        return "Orange Magic Slime";
                    case ENEMY.EnemyKind.MRedSlime:
                        return "Red Magic Slime";
                    case ENEMY.EnemyKind.BlueDevilFish:
                        return "Blue Devil Fish";
                    case ENEMY.EnemyKind.MPurpleSlime:
                        return "Purple Magic Slime";
                    case ENEMY.EnemyKind.BlueBlob:
                        return "Blue Blob";
                    case ENEMY.EnemyKind.RedBlob:
                        return "Red Blob";
                    case ENEMY.EnemyKind.GreenDevilFish:
                        return "Green Devil Fish";
                    case ENEMY.EnemyKind.UnknownSlime:
                        return "Unknown Slime";
                    case ENEMY.EnemyKind.OrangeDevilFish:
                        return "Orange Devil Fish";
                    case ENEMY.EnemyKind.BlueCatBlob:
                        return "Blue Cat Blob";
                    case ENEMY.EnemyKind.RedCatBlob:
                        return "Red Cat Blob";
                    case ENEMY.EnemyKind.BlueRabbitBlob:
                        return "Blue Rabbit Blob";
                    case ENEMY.EnemyKind.RedRabbitBlob:
                        return "Red Rabbit Blob";
                    case ENEMY.EnemyKind.BlueBlobSilent:
                        return "Blue Silent Blob";
                    case ENEMY.EnemyKind.RedBlobSilent:
                        return "Red Silent Blob";
                    case ENEMY.EnemyKind.MutantSlime:
                        return "Mutant Slime";
                    case ENEMY.EnemyKind.RedDevilFish:
                        return "Red Debil Fish";
                    case ENEMY.EnemyKind.PurpleDevilFish:
                        return "Purple Devil Fish";
                    case ENEMY.EnemyKind.SkyDevilFish:
                        return "Sky Devil Fish";
                    case ENEMY.EnemyKind.YellowDevilFish:
                        return "Yellow Devil Fish";
                    case ENEMY.EnemyKind.BlueKnightBlob:
                        return "Blue Knight Blob";
                    case ENEMY.EnemyKind.RedKnightBlob:
                        return "Red Knight Blob";
                    case ENEMY.EnemyKind.BlueKnightBlobSilent:
                        return "Blue Knight Silent Blob";
                    case ENEMY.EnemyKind.RedKnightBlobSilent:
                        return "Red Knight Silent Blob";
                    case ENEMY.EnemyKind.BlueArcherBlob:
                        return "Blue Archer Blob";
                    case ENEMY.EnemyKind.RedArcherBlob:
                        return "Red Archer Blob";
                    case ENEMY.EnemyKind.BlueKingBlob:
                        return "Blue King Blob";
                    case ENEMY.EnemyKind.RedKingBlob:
                        return "Red King Blob";
                    case ENEMY.EnemyKind.SlimeBoss:
                        return "Slime Boss";
                    case ENEMY.EnemyKind.SlimeKing:
                        return "Slime King";
                    case ENEMY.EnemyKind.FairyQueen:
                        return "Fairy Queen";
                    case ENEMY.EnemyKind.Golem:
                        return "Golem";
                    case ENEMY.EnemyKind.Bananoon:
                        return "Bananoon";
                    case ENEMY.EnemyKind.Spyder:
                        return "Spider";
                    case ENEMY.EnemyKind.Montblango:
                        return "Montblango";
                    case ENEMY.EnemyKind.DistortionSlime:
                        return "Distortion Slime";
                    case ENEMY.EnemyKind.MetalSlime:
                        return "Metal Slime";
                    case ENEMY.EnemyKind.NormalFairy:
                        return "Normal Fairy";
                    case ENEMY.EnemyKind.BlueFairy:
                        return "Blue Fairy";
                    case ENEMY.EnemyKind.YellowFairy:
                        return "Yellow Fairy";
                    case ENEMY.EnemyKind.GreenFairy:
                        return "Green Fairy";
                    case ENEMY.EnemyKind.OrangeFairy:
                        return "Orange Fairy";
                    case ENEMY.EnemyKind.RedFairy:
                        return "Red Fairy";
                    case ENEMY.EnemyKind.PurpleFairy:
                        return "Purple Fairy";
                    case ENEMY.EnemyKind.BlackFairy:
                        return "Black Fairy";
                    case ENEMY.EnemyKind.Deathpider:
                        return "Deathpider";
                    case ENEMY.EnemyKind.WizardSlime:
                        return "Wizard Slime";
                    case ENEMY.EnemyKind.Octobaddie:
                        return "Octobaddie";
                    default:
                        break;
                //}
            }
        }
        if(material is ARTIFACT.ArtifactName)
        {
            if(LocalizeInitialize.language == Language.jp||LocalizeInitialize.language == Language.eng)
            {
                return CraftLocal.GetEquipmentName((ARTIFACT.ArtifactName)material);
            }
        }
        string str = material.ToString();
        int tempIndex = 0;
        string trueText = "";
        foreach(char moji in str)
        {
            if (tempIndex == 0)
            {
                tempIndex++;
                trueText += moji;
                continue;
            }

            if (char.IsUpper(moji))
            {
                trueText += " ";
                trueText += moji;
            }
            else
            {
                trueText += moji;
            }
        }
        return trueText;
    }

    public IEnumerator CheckDropItem()
    {
        //負だったら０に戻す
        foreach (MaterialList material in Enum.GetValues(typeof(MaterialList)))
        {
            if (CurrentMaterial[material] < 0)
            {
                CurrentMaterial[material] = 0;
            }
        }
        while (true)
        {
            foreach (MaterialList material in Enum.GetValues(typeof(MaterialList)))
            {
                if (CurrentMaterial[material] > 0)
                {
                    main.S.isDropped[(int)material] = true;
                }
            }

            yield return new WaitForSeconds(1.0f);
        }
    }
}

public class MaterialNumber : NUMBER
{
    ArtiCtrl.MaterialList material;
    public override double Number { get => BASE.main.S.materialNum[(int)material]; set => BASE.main.S.materialNum[(int)material] = (int)value; }

    public MaterialNumber(ArtiCtrl.MaterialList material)
    {
        this.material = material;
    }

    public void EnemyDrop()
    {
        IncrementNumber(1 + main.S.SR_level[(int)R_UPGRADE.SR_upgradeID.Loot]);
        int dropNum = 1 + main.S.SR_level[(int)R_UPGRADE.SR_upgradeID.Loot];
        //main.ArtiCtrl.CurrentMaterial[material] += dropNum;
        if (main.GameController.battleMode != GameController.BattleMode.challange)
        {
            main.DeathPanel.materials[material] += dropNum;
        }
        else
        {
            main.DeathPanel.C_materials[material] += dropNum;
        }
        if (!main.systemController.disableLootLog)
        {
            if (dropNum == 1)
                main.Log("Gained <color=green>" + main.ArtiCtrl.ConvertEnum(material));
            else
                main.Log("Gained <color=green>" + main.ArtiCtrl.ConvertEnum(material) + " * " + dropNum);
        }

    }
}