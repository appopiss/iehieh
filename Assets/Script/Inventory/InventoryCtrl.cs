using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;
using static ArtiCtrl.MaterialList;
using System.Linq;
using static BASE;

public class InventoryCtrl : BASE
{
    int rscNum;
    int itemNum;
    public MaterialPre_I inventoryPre;
    List<MaterialPre_I> resources = new List<MaterialPre_I>();
    List<MaterialPre_I> consumes = new List<MaterialPre_I>();
    public Transform resourceParent, consumeParent;
    //ResourceInfo resouceInfo = new ResourceInfo();
    public TextMeshProUGUI explainText;
    ITEM_CONSUME[] itemEffects;
    public ConfirmDefault confirm;
    bool isLoaded;
    public Toggle inventoryToggle;
    public GameObject InventoryCanvas;

    void ApplyExplainText(string explain)
    {
        explainText.text = explain;
        main.sound.PlaySound(main.sound.levelUpClip);
    }

    // Use this for initialization
    void Awake()
    {
        StartBASE();
        rscNum = Enum.GetNames(typeof(ArtiCtrl.MaterialList)).Length;
        itemNum = Enum.GetNames(typeof(ArtiCtrl.ConsumeItemList)).Length;
    }

    // Use this for initialization
    void Start()
    {
        //エフェクトを配列に格納
        itemEffects = GetComponents<ITEM_CONSUME>();
        StartCoroutine(LoadMaterial());
        //setFalse(InventoryCanvas);
    }

    IEnumerator LoadMaterial()
    {
        int tempIndex = 0;
        yield return new WaitUntil(() => TitleCtrl.isLoaded);
        foreach (ArtiCtrl.MaterialList material in Enum.GetValues(typeof(ArtiCtrl.MaterialList)).Cast<ArtiCtrl.MaterialList>().ToList().OrderBy(s => s.ToString()))
        {
            if (main.cc.CurrentCurseId == CurseId.curse_of_poverty)
            {
                resources.Add(inventoryPre.StartMaterialInventory(resourceParent, material, 1, MaterialInfo(material).text));
            }
            else
            {
                resources.Add(inventoryPre.StartMaterialInventory(resourceParent, material, MaterialInfo(material).sellPrice, MaterialInfo(material).text));
            }
            resources[tempIndex].ID = tempIndex;
            yield return new WaitForSeconds(0.01f);
        }
        resources.OrderBy(s => s.rscKind);
        isLoaded = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLoaded)
            return;

        if (!inventoryToggle.isOn)//||!main.GameController.currentCanvas != main.GameController.ArtifactCanvas)
        {
            setFalse(InventoryCanvas);
        }
        else
        {
            setActive(InventoryCanvas);
        }
        if (main.GameController.currentCanvas == main.GameController.ArtifactCanvas)
        {
            foreach (var r in resources) { r.UpdateMaterial(); }
            foreach (var c in consumes) { c.UpdateMaterial(); }

        }
    }

    public static (double sellPrice, string text) MaterialInfo(ArtiCtrl.MaterialList material)
    {
        double price = 0;
        string text = "";
        switch (material)
        {
            case MonsterFluid:
                return (1, "Remains of a slain monster.");
            case RelicStone:
                return (50, "A valuable trading good.");
            case BlackPearl:
                return (2500, "A remarkable, precious stone.");
            case OozeStainedCloth:
                return (10, "A disgusting scrap of cloth, stained by slime ooze.");
            case OilOfSlime:
                return (10, "An oily substance extracted from slime remains.");
            case AcidicGoop:
                return (15, "An acidic sample of slime goop.");
            case BatPelt:
                return (20, "The skin of a slain bat.");
            case BatTooth:
                return (35, "The tooth of a slain bat. It's pointy!");
            case BatFeet:
                return (50, "If rabbit's feet are lucky, are bat's feet unlucky?");
            case FairyDust:
                return (20, "A spinkling of Fairy Dust! It glows slightly.");
            case FairyWing:
                return (30, "A shimmering wing taken from a dead Fairy.");
            case BloodOfFairy:
                return (45, "A bright bluish-green sample of Fairy blood.");
            case SpiderBlood:
                return (20, "A sticky, green ichor sample of Spider blood.");
            case SpiderFang:
                return (22, "The fangs of a dead spider. It can't still bite, right?");
            case VenomSoakedCloth:
                return (25, "The cloth remains of a spider's victim.");
            case SlimeEyeBall:
                return (35, "I think it's looking at me…");
            case FishScales:
                return (25, "The scales of a slain devil fish.");
            case SharpFin:
                return (35, "The barbed fine of a dead devil fish.");
            case FishTail:
                return (50, "This thing makes my whole bag smell fishy.");
            case RubberyBlob:
                return (30, "It's like a bouncy ball, made from flesh… gross.");
            case MiniatureSword:
                return (30, "A miniature sword with miniature blood stains.");
            case RubberCrown:
                return (60, "It's a stretchy crown! Almost like a headband.");
            case FoxPelt:
                return (25, "The skin of a slain fox.");
            case FoxTail:
                return (30, "The poofy fox tail.");
            case IntactNineTail:
                return (60, "A brilliant, white set of tails from a White Nine-Tailed Fox.");
            case FrostShard:
                return (30, "A shard of condensed frost. Chilly!");
            case FlameShard:
                return (30, "A shard of condensed flame. It's still warm!");
            case LightningShard:
                return (30, "A shard of condensed lightning. Shocking!");
            case NatureShard:
                return (30, "A shard of condensed nature energy. Calming!");
            case PoisonShard:
                return (30, "A shard of condensed poison. It's emitting light vapors.");
            case GoldenShard:
                return (30, "A shard of condensed light. Use it as a night light!");
            case LifeShard:
                return (30, "A shard of condensed life. I feel healthier just holding it.");
            case ManaShard:
                return (30, "A shard of condensed mana. So magical!");
            case CarvedIdol:
                return (50, "A small idol carved out of wood.");
            case AncientCoin:
                return (150, "An ancient gold coin. It's probably worth quite a bit!");
            case GooeySludge:
                return (10, "A gooey bit of sludge. It stains whatever it touches.");
            case BatWing:
                return (15, "The wing of a bat. It won't help you fly, though.");
            case IntactBatHead:
                return (50, "The whole head of a bat.");
            case EnchantedCloth:
                return (45, "A bolt of glowing cloth. It's clearly magical.");
            case FairyCoin:
                return (50, "A currency used by Fairy's maybe? Might be worth something.");
            case FairyHeart:
                return (75, "The heart of a dead fairy. It still sometimes beats.");
            case SpiderSilk:
                return (20, "Strong spider silk thread that's useful in tailoring.");
            case SpiderLeg:
                return (15, "A hairy, spindly leg of a dead spider.");
            case SpiderHeart:
                return (20, "The heart of a dead spider. It's much smaller than I imagined.");
            case RuinedSpellBook:
                return (45, "An old spell tome that's been partially dissolved. Illegible now.");
            case FishTeeth:
                return (30, "A few teeth extracted from a devil fish.");
            case SmallTreasureChest:
                return (150, "Wow! A small treasure chest! This should sell well!");
            case DeflatedBallCorpse:
                return (60, "The deflated, rubbery corpse of a ball being.");
            case FoxEar:
                return (30, "They say having one of these let's you hear spirits. Doesn't work.");
            case WhiteFoxPelt:
                return (100, "The rare white pelt of a White Nine-Tailed Fox.");
            case FrostCrystal:
                return (100, "A large crystal of condensed frost. Great for making ice cubes.");
            case FlameCrystal:
                return (100, "A large crystal of condensed flame. Cooks meat in two minutes.");
            case LightningCrystal:
                return (100, "A large crystal of condensed lightning. It keeps zapping me!");
            case NatureCrystal:
                return (100, "A large crystal of condensed nature energy. It's totally groovy.");
            case PoisonCrystal:
                return (100, "A large crystal of condensed poison. Touching it makes me feel ill.");
            case GoldenCrystal:
                return (100, "A large crystal of condensed light. Don't look directly at it.");
            case LifeCrystal:
                return (100, "A large crystal of condensed life. But whose life was it?");
            case ManaCrystal:
                return (100, "A large crystal of condensed mana. It's quite beautiful.");
            case SlimeCrown:
                return (80, "A shiny, golden crown dripping with disgusting slime.");
            case BatHeart:
                return (55, "The heart of a dead bat.");
            case MysticGemStone:
                return (75, "This shiny gemstone pulses with magical power.");
            case WebbedCore:
                return (250, "The Soul Core of a Spider. Who knows what it's used for?");
            case GlowingSludge:
                return (60, "A glob of dimly glowing sludge. It's fun to paint on things.");
            case OddMagicalHat:
                return (100, "A slime covered mage's hat.");
            case DevilFishCore:
                return (250, "The Soul Core of a Devil Fish. Who knows what it's used for?");
            case BallHeart:
                return (150, "It's kind of sad, but it's still pretty fun to bounce.");
            case FoxEye:
                return (75, "The eye of a fox. It's not as cool as an eye of the tiger.");
            case FoxHeart:
                return (140, "The heart of a dead fox.");
            case SlimeCore:
                return (250, "The Soul Core of a Slime. Who knows what it's used for?");
            case BatCore:
                return (250, "The Soul Core of a Bat. Who knows what it's used for?");
            case FairyCore:
                return (250, "The Soul Core of a Fairy. Who knows what it's used for?");
            case MagicSlimeCore:
                return (250, "The Soul Core of a Magical Slime. Who knows what it's used for?");
            case BallCore:
                return (250, "The Soul Core of a Ball Being. Who knows what it's used for?");
            case FoxCore:
                return (250, "The Soul Core of a Fox. Who knows what it's used for?");
            case ShinySlimeCrown:
                return (5000, "A pristine jeweled crown with only small amounts of slime.");
            case FairyQueenDust:
                return (5000, "A pouch of dust reserved for the Fairy Queen.");
            case RobustBone:
                return (5000, "It's a bone, but it's also stone. Petrified Bone!");
            case RottenBanana:
                return (5000, "It's barely holding it's shape and it's black as night.");
            case PotentVenomSample:
                return (5000, "Even a whiff of this stuff and you're dead.");
            case SlimeSceptre:
                return (10000, "A sceptre made of hardened slime and gemstones.");
            case EnchantedSapling:
                return (10000, "The sapling of a magical money tree. Wait, did you say money tree?");
            case GolemShard:
                return (10000, "A shard recovered from a defeated Golem.");
            case RipeBanana:
                return (10000, "A delicious looking banana, but considering it's source… no.");
            case SpiderIronSilk:
                return (10000, "A thread of ironsilk, the strongest thread in the world.");
            case SlimeKingGoop:
                return (10000, "Something about this glob of Slime King emanates power.");
            case FairyQueenWand:
                return (10000, "The Fairy Queen's Wand is a powerful relic, but it only works for her.");
            case StoneHeart:
                return (10000, "The heart of a Golem, though it just looks like a big rock.");
            case BananaDagger:
                return (10000, "A sleek dagger, sharp as a banana.");
            case SpiderEggSac:
                return (10000, "Could this contain the deadly offspring of the Deathspider?");
            case SlimeKingCore:
                return (50000, "The glimmering soul of the Slime King. But what is it for?");
            case FairyQueenCore:
                return (50000, "The glimmering soul of the Fairy Queen. But what is it for?");
            case GolemCore:
                return (50000, "The glimmering soul of the Golem. But what is it for?");
            case BananoonCore:
                return (50000, "The glimmering soul of the Bananoon. But what is it for?");
            case DeathpiderCore:
                return (50000, "The glimmering soul of the Deathspider. But what is it for?");
            case SeveredTentacle:
                return (5000, "A severed octopus tentacle. Is it normal for it to keep moving?");
            case OctopusEye:
                return (10000, "A giant octopus eye. It's the biggest eye you've ever seen seeing you.");
            case InkGland:
                return (10000, "The ink gland of an octopus. Anyone need to refill their pen?");
            case OctobaddieCore:
                return (50000, "The glimmering soul of the Octobaddie. But what is it for?");
            case RedChili:
                return (1000, "Yeah. This is Red Chili.");
            case Herb:
                return (10, "Yeah. This is so-called Herb.");
            case Berry:
                return (10, "Yeah. This is so-called Berry.");
            case MagicSeed:
                return (10, "Yeah. This is so-called Magic Seed.");




            //素材
            default:
                price = 0;
                text = "";
                break;
        }
        return (price, text);
    }

}
