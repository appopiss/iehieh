using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;

public class Help : BASE
{

    public Button ToSystem;
    public Button ToHelp;
    public GameObject SystemCanvas;
    public GameObject HelpCanvas;
    public TextMeshProUGUI Text;
    public Button[] statsModeButtons;
    public Scrollbar textScroll;
    public enum HelpKind
    {
        classes,
        stats,
        resource,
        utility,
        skill,
        explore,
        craft,
        quest,
        prestige,
        challenge,
        bestiary,
        bank,
        nitro,
        epicstore,
        capture
    }
    public HelpKind kind;

    public void GoToSystem()
    {
        HelpCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, -1000);
        main.GameController.SetAllImageAndText(HelpCanvas, false);
        SystemCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 1000);
    }

    public void GoToHelp()
    {
        SystemCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, -1000);
        main.GameController.SetAllImageAndText(HelpCanvas, true);
        HelpCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 1000);
    }


    // Use this for initialization
    void Awake()
    {
        StartBASE();
        ToSystem.onClick.AddListener(GoToSystem);
        ToHelp.onClick.AddListener(GoToHelp);
        statsModeButtons[0].onClick.AddListener(() => { kind = HelpKind.classes; ChangeText(); textScroll.value = 1; });
        statsModeButtons[1].onClick.AddListener(() => { kind = HelpKind.stats; ChangeText(); textScroll.value = 1; });
        statsModeButtons[2].onClick.AddListener(() => { kind = HelpKind.resource; ChangeText(); textScroll.value = 1; });
        statsModeButtons[3].onClick.AddListener(() => { kind = HelpKind.utility; ChangeText(); textScroll.value = 1; });
        statsModeButtons[4].onClick.AddListener(() => { kind = HelpKind.skill; ChangeText(); textScroll.value = 1; });
        statsModeButtons[5].onClick.AddListener(() => { kind = HelpKind.explore; ChangeText(); textScroll.value = 1; });
        statsModeButtons[6].onClick.AddListener(() => { kind = HelpKind.craft; ChangeText(); textScroll.value = 1; });
        statsModeButtons[7].onClick.AddListener(() => { kind = HelpKind.quest; ChangeText(); textScroll.value = 1; });
        statsModeButtons[8].onClick.AddListener(() => { kind = HelpKind.prestige; ChangeText(); textScroll.value = 1; });
        statsModeButtons[9].onClick.AddListener(() => { kind = HelpKind.challenge; ChangeText(); textScroll.value = 1; });
        statsModeButtons[10].onClick.AddListener(() => { kind = HelpKind.bestiary; ChangeText(); textScroll.value = 1; });
        statsModeButtons[11].onClick.AddListener(() => { kind = HelpKind.bank; ChangeText(); textScroll.value = 1; });
        statsModeButtons[12].onClick.AddListener(() => { kind = HelpKind.nitro; ChangeText(); textScroll.value = 1; });
        statsModeButtons[13].onClick.AddListener(() => { kind = HelpKind.epicstore; ChangeText(); textScroll.value = 1; });
        statsModeButtons[14].onClick.AddListener(() => { kind = HelpKind.capture; ChangeText(); textScroll.value = 1; });
        statsModeButtons[0].onClick.Invoke();
    }

    // Use this for initialization
    void Start()
    {
        //main.GameController.SetAllImageAndText(HelpCanvas, false);
    }

    void ChangeText()
    {
        if (main.GameController.currentCanvas == main.GameController.InventoryCanvas)
        {
            LocalizeInitialize.SetFont(Text);
            switch (kind)
            {
                case HelpKind.classes:
                    switch (LocalizeInitialize.language)
                    {
                        case Language.eng:
                            Text.text = "There are three available classes in Incremental Epic Hero: Warrior, Wizard, and Angel. Throughout the game, you are able to switch between each of these classes through the first prestige called Rebirth (SEE: Rebirth), which awards a number of prestige points to spend on special upgrades and enables you to start over as the same or a new class.";
                            Text.text += "\n\nEach class has various available skills, which can begin to be utilized by other classes after your first Rebirth prestige.";
                            Text.text += "\n\nEach class has a unique advantage regarding stat growth (SEE: Stats), and special passives that are only available while playing as that class. In general the focus of each class is as follows:";
                            Text.text += "\n\n-  Warrior  :  Tank (Health and Def)";
                            Text.text += "\n-  Wizard  :  Damage (Magic Damage and Magic Defense)";
                            Text.text += "\n-  Angel  :  Buffs (Speed)";
                            break;
                        case Language.jp:
                            Text.text = "インクリメンタル・エピックヒーローには, 戦士 (Warrior), 魔法使い (Wizard), 天使 (Angel)の3つの職業 (Class)があります. ゲーム全体を通して, 再誕 (Rebirth)を通してこれら各職業を切り替えることができます. これにより, 再誕専用のアップグレードに使用できる再誕ポイントが付与され, 同じ職業または別の職業としてゲームを再スタートできます. ";
                            Text.text += "\n\n各職業には専用のスキルがあり, 専用スキルスロット (左側の6つのスロット)にセットすることで使用できます. 初めての再誕時にグローバルスキルスロット (Global Skill Slot)を解禁することで, 別の職業のスキルを使用できるようになります. ";
                            Text.text += "\n\n各職業の特徴は次の通りです. ";
                            Text.text += "\n\n-  戦士 (Warrior)  :  耐久力と物理攻撃 (体力と防御力が高い)";
                            Text.text += "\n-  魔法使い (Wizard)  :  強力な魔法攻撃 (魔法攻撃力と魔法防御力が高い)";
                            Text.text += "\n-  天使 (Angel)  :  エンハンス・バフ (スピードが高い)";
                            break;
                        case Language.chi:
                            Text.text = "在Incremental Epic Hero中, 有三个可用的类别 : 战士(Warrior), 巫师(Wizard), 天使(Angel). 在整个游戏过程中, 你能够通过第一个名为重生(SEE : Rebirth)的声望在这三个阶级之间进行切换, 该声望奖励若干声望点用于特殊升级, 并使你能够以相同或新的阶级重新开始. ";
                            Text.text += "\n\n每个班级都有各种可用的技能, 在你第一次重生声望后, 可以开始被其他班级利用. ";
                            Text.text += "\n\n每个类都有独特的优势, 关于数据成长(SEE : Stats), 以及特殊的被动, 这些被动只有在作为该类游戏时才能使用. 一般来说, 每个类的重点如下. ";
                            Text.text += "\n\n-  Warrior  :  Tank (Health and Def)";
                            Text.text += "\n-  Wizard  :  Damage (Magic Damage and Magic Defense)";
                            Text.text += "\n-  Angel  :  Buffs (Speed)";
                            break;
                        default:
                            Text.text = "There are three available classes in Incremental Epic Hero: Warrior, Wizard, and Angel. Throughout the game, you are able to switch between each of these classes through the first prestige called Rebirth (SEE: Rebirth), which awards a number of prestige points to spend on special upgrades and enables you to start over as the same or a new class.";
                            Text.text += "\n\nEach class has various available skills, which can begin to be utilized by other classes after your first Rebirth prestige.";
                            Text.text += "\n\nEach class has a unique advantage regarding stat growth (SEE: Stats), and special passives that are only available while playing as that class. In general the focus of each class is as follows:";
                            Text.text += "\n\n-  Warrior  :  Tank (Health and Def)";
                            Text.text += "\n-  Wizard  :  Damage (Magic Damage and Magic Defense)";
                            Text.text += "\n-  Angel  :  Buffs (Speed)";
                            break;
                    }
                    break;
                case HelpKind.stats:
                    switch (LocalizeInitialize.language)
                    {
                        case Language.eng:
                            Text.text = "Stats give you an indication of just how powerful you are, and there are many different ways throughout the game to boost them:";
                            Text.text += "\n-  HP shows your current available health points.";
                            Text.text += "\n-  MP shows your current available mana points.";
                            Text.text += "\n-  ATK / DEF affect the dealing / receiving of Physical Damage.";
                            Text.text += "\n-  MATK / MDEF affect the dealing / receiving of Magical Damage.";
                            Text.text += "\n-  SPD makes everything you do happen faster, affecting both skill speed and movement speed.";
                            Text.text += "\n\n<size=12>There are additional stats that you will acquire through playing the game:";
                            Text.text += "\n-  SKILL PROFICIENCY increases the rate at which you automatically raise skill levels.";
                            Text.text += "\n-  DROP increases the chance that a monster will drop something from its available loot.";
                            Text.text += "\n-  GOLD indicate both the way gold drops are multiplied and what fixed number is being added to each drop.";
                            Text.text += "\n-  EXP work the same way as Gold, showing both multiplied exp gains and the fixed number being added on top after each monster kill.";
                            Text.text += "\n\n<size=12>There are other special stats that become available later in the game that we will let you discover for yourself to not spoil the mystery!";
                            break;
                        case Language.jp:
                            Text.text = "統計 (Stats)では, 現在のステータスの詳細情報を見ることができます. ";
                            Text.text += "\n-  HPは現在のあなたの最大HPを表示します. ";
                            Text.text += "\n-  MPは現在のあなたの最大MPを表示します. ";
                            Text.text += "\n-  ATK / DEFは物理ダメージに対する攻撃力/防御力を表示します. ";
                            Text.text += "\n-  MATK / MDEFは魔法ダメージに対する攻撃力/防御力を表示します. ";
                            Text.text += "\n-  SPDは移動速度やスキルの攻撃速度に影響するスピードを表示します. ";
                            Text.text += "\n-  SKILL PROFICIENCY (スキル熟練度)はスキル使用時に得られる熟練度の量に影響する値を示します. ";
                            Text.text += "\n-  DROP CHANCE (ドロップ率)は敵を倒した時に得られる戦利品のドロップ率に影響する値を示します. ";
                            Text.text += "\n-  GOLDは敵を倒した時に得られるゴールド量を示します. ";
                            Text.text += "\n-  EXPは敵を倒した時に得られる経験値を示します. ";
                            break;
                        case Language.chi:
                            Text.text = "统计数据让你知道自己有多强大, 在整个游戏中, 有许多不同的方法来提升它们. ";
                            Text.text += "\n-  HP显示你当前可用的健康点数. ";
                            Text.text += "\n-  MP显示你当前可用的法力点. ";
                            Text.text += "\n-  ATK / DEF会影响物理伤害的施放/接收. ";
                            Text.text += "\n-  MATK / MDEF会影响魔法伤害的施放/接收. ";
                            Text.text += "\n-  SPD让你做的每件事都发生得更快, 影响技能速度和移动速度. ";
                            Text.text += "\n\n<size=12>通过玩游戏还能获得额外的数据. ";
                            Text.text += "\n-  SKILL PROFICIENCY增加你自动提升技能等级的速度. ";
                            Text.text += "\n-  DROP增加怪物从其可用战利品中掉落东西的几率. ";
                            Text.text += "\n-  GOLD表示既是金币的倍数方式, 也是每个金币的固定数字. ";
                            Text.text += "\n-  EXP的工作方式和金币一样, 既显示出成倍的exp收益, 也显示出每次杀怪后固定的数字被加在上面. ";
                            Text.text += "\n\n<size=12>还有其他一些特殊的统计, 在游戏后期会变成, 为了不破坏神秘感, 我们会让你自己去发现!";
                            break;
                        default:
                            Text.text = "Stats give you an indication of just how powerful you are, and there are many different ways throughout the game to boost them:";
                            Text.text += "\n-  HP shows your current available health points.";
                            Text.text += "\n-  MP shows your current available mana points.";
                            Text.text += "\n-  ATK / DEF affect the dealing / receiving of Physical Damage.";
                            Text.text += "\n-  MATK / MDEF affect the dealing / receiving of Magical Damage.";
                            Text.text += "\n-  SPD makes everything you do happen faster, affecting both skill speed and movement speed.";
                            Text.text += "\n\n<size=12>There are additional stats that you will acquire through playing the game:";
                            Text.text += "\n-  SKILL PROFICIENCY increases the rate at which you automatically raise skill levels.";
                            Text.text += "\n-  DROP increases the chance that a monster will drop something from its available loot.";
                            Text.text += "\n-  GOLD indicate both the way gold drops are multiplied and what fixed number is being added to each drop.";
                            Text.text += "\n-  EXP work the same way as Gold, showing both multiplied exp gains and the fixed number being added on top after each monster kill.";
                            Text.text += "\n\n<size=12>There are other special stats that become available later in the game that we will let you discover for yourself to not spoil the mystery!";
                            break;
                    }
                    break;
                case HelpKind.resource:
                    switch (LocalizeInitialize.language)
                    {
                        case Language.eng:
                            Text.text = "There are three primary resources in the game: Stone, Crystal, and Leaf. Resources are used for upgrading class skills, expanding the gold cap, and are sometimes even used as materials when upgrading/evolving equipment (SEE: Crafting).";
                            Text.text += "\n\nThere are multiple upgrades available for each type, offering both clicking upgrades and idle gain upgrades. Additional upgrades unlock as you progress through the game, and many of the upgrades work synergistically to boost one another. You can find hints about this in the tool-tips for the upgrades.";
                            break;
                        case Language.jp:
                            Text.text = "インクリメンタル・エピックヒーローには, ストーン (Stone), クリスタル (Crystal), リーフ (Leaf)の3つの主要なリソースがあります. リソースは, 各職業スキルのレベルアップやゴールドキャップの拡張に使用され, クラフト (Craft)のレベルアップ/進化の際の材料としても使用されます. ";
                            Text.text += "\n\nそれぞれのリソースに対応した複数のアップグレード (Upgrade)があります. ゲームを進めると, 追加のアップグレードが解放され, アップグレードの多くは相乗的に機能します. これらに関するヒントは, アップグレード (Upgrade)内のポップアップウィンドウを確認してください. ";
                            break;
                        case Language.chi:
                            Text.text = "游戏中主要有三种资源. 石头, 水晶和树叶. 资源用于升级类技能, 扩大金币上限, 有时甚至可以作为升级/进化装备时的材料 (SEE : Crafting). ";
                            Text.text += "\n\n每种类型都有多种升级方式, 提供点击升级和闲置增益升级. 额外的升级会随着你在游戏中的进展而解锁, 很多升级都能协同工作, 相互促进. 你可以在升级的工具提示中找到相关提示. ";
                            break;
                        default:
                            Text.text = "There are three primary resources in the game: Stone, Crystal, and Leaf. Resources are used for upgrading class skills, expanding the gold cap, and are sometimes even used as materials when upgrading/evolving equipment (SEE: Crafting).";
                            Text.text += "\n\nThere are multiple upgrades available for each type, offering both clicking upgrades and idle gain upgrades. Additional upgrades unlock as you progress through the game, and many of the upgrades work synergistically to boost one another. You can find hints about this in the tool-tips for the upgrades.";
                            break;
                    }
                    break;
                case HelpKind.utility:
                    switch (LocalizeInitialize.language)
                    {
                        case Language.eng:
                            Text.text = "In addition to the resource upgrades, various Utility upgrades will become available as you progress through the game. The game will start with a Gold and EXP upgrade, which add a fixed amount (after all other multipliers) to the amount of gold / exp that monsters will award when defeated. Additionally, you will be able to upgrade the number of equipment slots available, as well as a series of \"Ritual\" upgrades that boost your stats, and finally a Mystery upgrade that randomly chooses a boost and applies it.";
                            Text.text += "\n\nAll upgrades are reset upon Rebirth (SEE: Rebirth).";
                            break;
                        case Language.jp:
                            Text.text = "リソースのアップグレード (Upgrade)だけでなく, ゲームを進めるにつれて, さまざまなアップグレードが解放されます. 例えばゴールド (Gold)と経験値 (EXP)のアップグレードは, モンスターが倒されたときに獲得できるゴールド/EXPの量に (他のすべての乗数の後に)ボーナス量を追加で獲得できます. さらに, 装備できるクラフト (Craft)の数を増加させたり, 儀式 (Ritual)アップグレードによってステータスを増加させたりできます. ";
                            Text.text += "\n\nアップグレードは, 再誕 (Rebirth)時に全てリセットされます. ";
                            break;
                        case Language.chi:
                            Text.text = "除了资源升级外, 随着游戏进程的推进, 各种实用性升级也会出现. 游戏开始时将会有金币和EXP的升级, 这些升级会增加固定的数量 (在所有其他倍数之后), 当击败怪物时, 怪物会奖励一定数量的金币/EXP. 此外, 你将能够升级可用的装备槽数量, 以及一系列的\"Ritual\"升级, 以提升你的统计数据, 最后是一个神秘的升级, 随机选择一个提升并应用它. ";
                            Text.text += "\n\n重生时所有升级都会被重置 (参见 : Rebirth). ";
                            break;
                        default:
                            Text.text = "In addition to the resource upgrades, various Utility upgrades will become available as you progress through the game. The game will start with a Gold and EXP upgrade, which add a fixed amount (after all other multipliers) to the amount of gold / exp that monsters will award when defeated. Additionally, you will be able to upgrade the number of equipment slots available, as well as a series of \"Ritual\" upgrades that boost your stats, and finally a Mystery upgrade that randomly chooses a boost and applies it.";
                            Text.text += "\n\nAll upgrades are reset upon Rebirth (SEE: Rebirth).";
                            break;
                    }
                    break;
                case HelpKind.skill:
                    switch (LocalizeInitialize.language)
                    {
                        case Language.eng:
                            Text.text = "- Skill Level\nEach class has powerful skills that can be equipped to the available skill slots, which are shown below the battle field. These skills can be upgrades using resources to increase their power and to also unleash passive boosts when certain levels are reached. Please review the tool-tips when mousing over each class skill to see at what levels a new passive effect will unleash.";
                            Text.text += "\nMore skill slots unlock as you progress through the game, allowing more strategy to be employed to overcome obstacles you will encounter during exploration (SEE: Explore).";
                            Text.text += "\n\n- Passive Effect\nPassive Bonuses earned from Class Skills are ONLY applicable when playing as that class. These include a variety of stat boosts as well as sometimes enhancing the effect of the skill itself.";
                            Text.text += "\n\n- Passive Abilities\nPassive Abilities are special skills that can greatly change the way a class is played, and they are unlocked currently through the Passive Bonuses system. We will leave a little mystery to what they all are, but each one is designed to augment the purpose of each class.";
                            Text.text += "\n\n- Hotkeys can be used for quick assignment to available skill slots. \n\nClick on the skill you would like to equip and press the corresponding slot number on your keyboard (1 through 6) to quick assign it. \n\nThe same can be done for global skill slots by holding Shift when pressing the corresponding number.";
                            Text.text += "\n\n- The first skill slot determines the default range that the player's character will use for skills.\n\nSetting this to a buff skill will result in the primary attack skill's range being utilized. Additionally, there is an Epic Store upgrade that enables you to override the range in the System Settings.";
                            break;
                        case Language.jp:
                            Text.text = "- スキルレベル\n各職業には専用スキルがあり, 戦闘スクリーンの下部に表示されているスキルスロットに装備することでスキルを使用できます. これらのスキルはリソース (Stone/Crystal/Leaf)を使用してレベルアップし, 特定のレベルに達するとパッシブ効果を解放します. パッシブ効果などの詳細情報はスキルアイコンをホバーした際に表示されるポップアップウィンドウを確認してください. ";
                            Text.text += "\nゲームを進めるにつれて, より多くのスキルスロットが解放され, 探索 (Explore)をより効率的に進めるための戦略を練ることができます. ";
                            Text.text += "\n\n- パッシブ効果\n一定のスキルレベルに到達するとパッシブボーナスを得られます. パッシブ効果は, その職業でプレイする場合にのみ適用されます. ";
                            Text.text += "\n\n- ホットキー\n使用したいスキルをクリックし, キーボードの対応するスロット番号 (1から6)を押すことで, 即時にセットできます.  Shiftキーを押しながら対応する番号 (1から6)を押すと, グローバルスキルスロットでも同じことができます. ";
                            break;
                        case Language.chi:
                            Text.text = "- Skill Level\n每个阶级都有强大的技能, 可以装备到可用的技能槽中, 这些技能槽在战场下方显示. 这些技能可以使用资源进行升级, 以增加其威力, 当达到一定等级时, 还可以释放被动加成. 请在鼠标移动到每个类目技能时查看工具提示, 看看在什么等级会释放新的被动效果. ";
                            Text.text += "\n随着游戏的进展, 更多的技能槽会解锁, 可以采用更多的策略来克服探索过程中会遇到的障碍 (SEE : 探索). ";
                            Text.text += "\n\n- 被动效果/班级技能所获得的被动奖励只有在扮演该班级时才适用. 这些奖励包括各种状态的提升, 有时也会增强技能本身的效果. ";
                            Text.text += "\n\n- Passive Abilities\n被动能力是一种特殊的技能, 可以极大地改变一个类的玩法, 它们目前是通过被动奖励系统解锁的. 它们都是什么我们就不多说了, 但每一个都是为了增强每个类的目的. ";
                            Text.text += "\n\n- 热键可以用来快速分配到可用的技能槽.  \n\n点击你要装备的技能, 按键盘上对应的槽位号 (1到6)即可快速分配.  \n\n同样可以在按下相应数字时按住Shift键进行全局技能槽的操作. ";
                            Text.text += "\n\n- 第一个技能槽决定了玩家角色使用技能的默认范围, 将其设置为buff技能会导致主攻技能的范围被利用. 此外, 有一个史诗商店升级版, 可以让你在系统设置中覆盖范围. ";
                            break;
                        default:
                            Text.text = "- Skill Level\nEach class has powerful skills that can be equipped to the available skill slots, which are shown below the battle field. These skills can be upgrades using resources to increase their power and to also unleash passive boosts when certain levels are reached. Please review the tool-tips when mousing over each class skill to see at what levels a new passive effect will unleash.";
                            Text.text += "\nMore skill slots unlock as you progress through the game, allowing more strategy to be employed to overcome obstacles you will encounter during exploration (SEE: Explore).";
                            Text.text += "\n\n- Passive Effect\nPassive Bonuses earned from Class Skills are ONLY applicable when playing as that class. These include a variety of stat boosts as well as sometimes enhancing the effect of the skill itself.";
                            Text.text += "\n\n- Passive Abilities\nPassive Abilities are special skills that can greatly change the way a class is played, and they are unlocked currently through the Passive Bonuses system. We will leave a little mystery to what they all are, but each one is designed to augment the purpose of each class.";
                            Text.text += "\n\n- Hotkeys can be used for quick assignment to available skill slots. \n\nClick on the skill you would like to equip and press the corresponding slot number on your keyboard (1 through 6) to quick assign it. \n\nThe same can be done for global skill slots by holding Shift when pressing the corresponding number.";
                            Text.text += "\n\n- The first skill slot determines the default range that the player's character will use for skills.\n\nSetting this to a buff skill will result in the primary attack skill's range being utilized. Additionally, there is an Epic Store upgrade that enables you to override the range in the System Settings.";
                            break;
                    }
                    break;
                case HelpKind.explore:
                    switch (LocalizeInitialize.language)
                    {
                        case Language.eng:
                            Text.text = optStr + "Exploration is perhaps the most important element in the game, as it is here that the core mechanics happen. Journey through the world and encounter all kinds of terrible monsters that will do all that they can to end you quickly. Overcome the obstacles and you will unlock new areas to explore.\n\n" +
                                "Exploration Area Maps are the story maps of IEH and where you are introduced to the monsters found in that area. Defeating monsters earns you gold, experience, and loot drops that can be used to unlock, upgrade, and evolve equipment that will aid you in becoming stronger and stronger.\n\n" +
                                "Each area also has Missions available that provide a set of tasks for you as the player to accomplish that will be rewarded with Epic Coin (SEE: Epic Shop).The total number of Epic Coins available per area from Mission rewards is over 1000, so it is a great way to collect premium currency.\n\n" +
                                "When you manage to overcome the challenge of an Area Boss Level, you will gain access to that Area's Infinite Dungeon. Infinite Dungeons, as their name implies, enable you to fight hoards of the monsters of a certain Area in much great number. Additionally, each wave completed adds a small bonus to your overall experience modifier as well. Dungeons are a great place to farm and grind when you don't have a specific material in mind.";
                            break;
                        case Language.jp:
                            Text.text = optStr + "探索 (Explore)は, このゲームを進める上で最も重要な要素です. インクリメンタル・エピックヒーローの世界を旅し, 様々なモンスターと出会い, ゲーム内のあらゆる要素を解禁します. \n\n" +
                                "ゴールド, 経験値, 戦利品のドロップを獲得できます. これらを使用して, クラフト (Craft)の解放, レベルアップ, 進化させることができ, ますます強くなるのに役立ちます. \n\n" +
                                "各エリアにはミッション (Mission)があり, 報酬として, 本ゲームのプレミアム通貨であるエピックコイン (Epic Coin)を得られます. \n\n" +
                                "ダンジョン (Dungeon)は, エリア種族のモンスターと数多く戦うことができます. ";
                            break;
                        case Language.chi:
                            Text.text = optStr + "探索也许是游戏中最重要的元素, 因为核心机制就是在这里发生的. 在这个世界上旅行, 遇到各种可怕的怪物, 它们会尽其所能迅速结束你. 克服障碍, 你将解锁新的区域进行探索. \n\n" +
                                "探索区域地图是IEH的故事地图, 也是向你介绍该区域内的怪物的地方. 击败怪物可以获得金币, 经验和战利品掉落, 这些都可以用来解锁, 升级和进化装备, 帮助你变得越来越强. \n\n" +
                                "每个区域也有任务可做, 提供一组任务供你作为玩家完成, 将获得史诗币的奖励(SEE : 史诗商店).每个区域从任务奖励中获得的史诗币总数超过1000个, 所以这是收集高级货币的好方法. \n\n" +
                                "当你成功挑战一个区域的Boss关卡后, 你将获得进入该区域的无限地下城. 无限地下城, 顾名思义, 就是让你可以大量地与某个区域的怪物群殴. 此外, 每完成一波, 你的整体经验修改器也会增加一点奖励. 当你没有特定材料的时候, 地下城是一个很好的养殖和磨练的地方. ";
                            break;
                        default:
                            Text.text = optStr + "Exploration is perhaps the most important element in the game, as it is here that the core mechanics happen. Journey through the world and encounter all kinds of terrible monsters that will do all that they can to end you quickly. Overcome the obstacles and you will unlock new areas to explore.\n\n" +
                                "Exploration Area Maps are the story maps of IEH and where you are introduced to the monsters found in that area. Defeating monsters earns you gold, experience, and loot drops that can be used to unlock, upgrade, and evolve equipment that will aid you in becoming stronger and stronger.\n\n" +
                                "Each area also has Missions available that provide a set of tasks for you as the player to accomplish that will be rewarded with Epic Coin (SEE: Epic Shop).The total number of Epic Coins available per area from Mission rewards is over 1000, so it is a great way to collect premium currency.\n\n" +
                                "When you manage to overcome the challenge of an Area Boss Level, you will gain access to that Area's Infinite Dungeon. Infinite Dungeons, as their name implies, enable you to fight hoards of the monsters of a certain Area in much great number. Additionally, each wave completed adds a small bonus to your overall experience modifier as well. Dungeons are a great place to farm and grind when you don't have a specific material in mind.";
                            break;
                    }
                    break;
                case HelpKind.craft:
                    switch (LocalizeInitialize.language)
                    {
                        case Language.eng:
                            Text.text = "Equipment is one of the most powerful ways that you will be able to upgrade your stats in order to overcome obstacles. All Equipment items require materials that are dropped from monsters. Materials are necessary to unleash, upgrade, and evolve equipment.\n\n" +
                                "Each piece of Equipment has a number of levels before they reach their max level, at which point they become available to Evolve. Evolution may require new and much rarer materials, and will result in a higher max level of the Equipment. However, Evolution will reset the levels back to 0, so you should always be sure you have enough materials on hand before evolving in order to get the most benefit from the evolution.\n\n" +
                                "Equipment is also broken up by Grades: D, C, B, A, and S. Grade D materials can be found in Areas 1 and 2, Grade C materials can be found in Areas 2 and 3, and so on.However, S materials are very, very rare and you will have to discover how to find these very rare and special materials for yourself.\n\n" +
                                "Lastly, Equipment has a certain number of available slots, limiting how many pieces of Equipment you can have equipped at once. This can be upgraded through the Upgrade panel, through Rebirth(SEE: Rebirth), and a few other ways that you will have to discover on your own.\n\n- Left Click to equip\n- Right Click to remove\n- Press \"M\" to max level up";
                            break;
                        case Language.jp:
                            Text.text = optStr + "クラフト/装備 (Craft/Equipment)は, ステータスを強化する最も強力な方法の1つです. すべての装備アイテムには, モンスターからドロップされた材料が必要です. 装備の解放, レベルアップ, 進化 (Evolution)に材料が使われます. \n\n" +
                                "装備には最大レベルが設定されており, 最大レベルに到達すると進化ができます.  進化には, より希少な材料が必要になる場合があり, 進化の結果, クラフトの最大レベルや能力が向上します.  ただし, 進化した直後はクラフトのレベルを0にリセットするため, 進化から最大の利益を得るには, 進化する前に十分な材料が手元にあることを常に確認する必要があります. \n\n" +
                                "装備にはランクがあり, D/C/B/A/Sに分類されます. \n\n" +
                                "装備には一定数の装備可能スロットがあり, 一度に装備できる装備の数が制限されます. これは, アップグレード (Upgrade), 再誕 (Rebirth), およびその他のいくつかの方法でアップグレードできます. \n\n- 左クリックで装備\n- 右クリックで取り除く\n-「Mキー」を押して最大レベルアップ";
                            break;
                        case Language.chi:
                            Text.text = "装备是你提升自己的状态以克服障碍的最有力途径之一. 所有装备物品都需要从怪物身上掉落的材料. 材料是发动, 升级, 进化装备的必要条件. \n\n" +
                                "每件装备在达到最大等级之前都有一定的等级, 这时它们就可以进行进化. 进化可能需要新的和更稀有的材料, 并且会导致装备的最高等级提高. 然而, 进化会将等级重置为0, 所以在进化之前, 你应该始终确保手头有足够的材料, 以便从进化中获得最大的好处. \n\n" +
                                "装备也是按Rank来划分的. D级材料可以在1区和2区找到, C级材料可以在2区和3区找到, 以此类推, 但是S级材料是非常非常稀有的, 如何找到这些非常稀有和特殊的材料, 需要你自己去发现. \n\n" +
                                "最后, 装备有一定的可用槽位, 限制了你一次可以装备多少件装备. 这可以通过升级面板, 通过重生(SEE: Rebirth), 以及其他一些方式进行升级, 这就需要你自己去发现了. \n\n- Left Click to equip\n- Right Click to remove\n- Press \"M\" to max level up";
                            break;
                        default:
                            Text.text = "Equipment is one of the most powerful ways that you will be able to upgrade your stats in order to overcome obstacles. All Equipment items require materials that are dropped from monsters. Materials are necessary to unleash, upgrade, and evolve equipment.\n\n" +
                                "Each piece of Equipment has a number of levels before they reach their max level, at which point they become available to Evolve. Evolution may require new and much rarer materials, and will result in a higher max level of the Equipment. However, Evolution will reset the levels back to 0, so you should always be sure you have enough materials on hand before evolving in order to get the most benefit from the evolution.\n\n" +
                                "Equipment is also broken up by Grades: D, C, B, A, and S. Grade D materials can be found in Areas 1 and 2, Grade C materials can be found in Areas 2 and 3, and so on.However, S materials are very, very rare and you will have to discover how to find these very rare and special materials for yourself.\n\n" +
                                "Lastly, Equipment has a certain number of available slots, limiting how many pieces of Equipment you can have equipped at once. This can be upgraded through the Upgrade panel, through Rebirth(SEE: Rebirth), and a few other ways that you will have to discover on your own.\n\n- Left Click to equip\n- Right Click to remove\n- Press \"M\" to max level up";
                            break;
                    }
                    break;
                case HelpKind.quest:
                    switch (LocalizeInitialize.language)
                    {
                        case Language.eng:
                            Text.text = "- Basic Quest\nWhen you unlock Quests, you will be automatically assigned a number of Basic Quests. These are Quest series that contain several different tasks that may culminate in some useful and sometimes powerful rewards. Each quest is different and you will have to review what each quest requires by mousing over the listing in the Quest tab. It is there that you will also be able to click \"CLAIM\" when the quest is complete to receive the reward you have earned!";
                            Text.text += "\n\n- Daily Quest\nDaily Quests enable you to earn premium currency, Epic Coins, every single day! These quests range in difficulty from Common to Legendary, with a reward based on that difficulty. You may find Epic Shop upgrades available that improve the rewards each day by removing Common difficulty and another to remove Uncommon difficulty, resulting in higher difficulty Daily Quests and more Epic Coins!\n\n" +
                                "As you progress through the game, you will gain opportunities to do more than one Daily Quest per day, increasing the chances of getting a higher difficulty quest and more opportunities to earn premium currency!";
                            break;
                        case Language.jp:
                            Text.text = "- 通常クエスト\nクエストタブが解禁されると, チュートリアルクエストが始まります. その後通常クエストと反復クエストが解禁されます. 必要なタスクはポップアップウィンドウを確認してください. クエストが完了したら「CLAIM」をクリックして, 報酬を受け取ることができます. ";
                            Text.text += "\n\n- デイリークエスト\nデイリークエストでは, 毎日プレミアム通貨のエピックコイン (Epic Coin)を獲得できます. これらのクエストの難易度はコモン (Common)からレジェンダリー (Legendary)まであり, その難易度に基づいて報酬が与えられます. 報酬の低いデイリークエストを排除するアップグレードがエピックストア (Epic Store)で購入できます. \n\n" +
                                "ゲームを進めていくと, 1日に複数のデイリークエストを行う機会が得られ, 難易度の高いクエストを取得する機会が増え, プレミアム通貨を獲得する機会が増えます. ";
                            break;
                        case Language.chi:
                            Text.text = "- Basic Quest\n当你解锁任务时, 你会被自动分配一些基本任务. 这些是任务系列, 包含几个不同的任务, 最终可能会获得一些有用的, 有时是强大的奖励. 每一个任务都是不同的, 你必须通过鼠标移动到任务选项卡中的列表来查看每个任务所需的内容. 在那里, 当任务完成时, 你还可以点击\"CLAIM\"来获得你所获得的奖励!";
                            Text.text += "\n\n- Daily Quest\n每日任务可以让你每天都能获得高级货币--史诗币! 这些任务的难度从普通到传奇不等, 奖励基于该难度. 你可能会发现有史诗商店升级, 通过消除普通难度来提高每天的奖励, 而另一个则是消除不普通难度, 从而获得更高难度的每日任务和更多的Epic Coins!\n\n" +
                                "随着游戏进程的推进, 你将获得每天做多个每日任务的机会, 增加获得更高难度任务的机会, 也有更多机会获得高级货币!";
                            break;

                        default:
                            Text.text = "- Basic Quest\nWhen you unlock Quests, you will be automatically assigned a number of Basic Quests. These are Quest series that contain several different tasks that may culminate in some useful and sometimes powerful rewards. Each quest is different and you will have to review what each quest requires by mousing over the listing in the Quest tab. It is there that you will also be able to click \"CLAIM\" when the quest is complete to receive the reward you have earned!";
                            Text.text += "\n\n- Daily Quest\nDaily Quests enable you to earn premium currency, Epic Coins, every single day! These quests range in difficulty from Common to Legendary, with a reward based on that difficulty. You may find Epic Shop upgrades available that improve the rewards each day by removing Common difficulty and another to remove Uncommon difficulty, resulting in higher difficulty Daily Quests and more Epic Coins!\n\n" +
                                "As you progress through the game, you will gain opportunities to do more than one Daily Quest per day, increasing the chances of getting a higher difficulty quest and more opportunities to earn premium currency!";
                            break;
                    }
                    break;
                case HelpKind.prestige:
                    switch (LocalizeInitialize.language)
                    {
                        case Language.eng:
                            Text.text = "Upon completing Area 1-5, you will now be able to Rebirth. Rebirth is a prestige mechanic that provides you access to powerful upgrades that will increase your overall power and how quickly you are able to progress through the game. Each class has its own set of Rebirth points, meaning that to acquire all of the necessary points to purchase some upgrades will require playing as all three classes and saving up those points!\n\n" +
                                "It is recommended that you export your save before completing a Rebirth in case you decide to change your mind.";
                            break;
                        case Language.jp:
                            Text.text = "エリア1-5を完了すると, 再誕 (Rebirth)ができるようになります.  再誕によって強力なアップグレードを得られ, ステータスやゲーム全体の進行を向上させます. 各職業にはそれぞれの再誕ポイントがあり, 全ての再誕アップグレードを購入するためには, 3つの職業をすべてプレイする必要があります. \n\n" +
                                "再誕後に気が変わってしまう場合に備えて, 再誕をする前にローカルセーブ (Local Save)をすることをお勧めします. ";
                            break;
                        case Language.chi:
                            Text.text = "完成1-5区后, 你现在就可以重生了. 重生是一种声望机制, 它为你提供了获得强大升级的机会, 这些升级将增加你的整体实力和你在游戏中的进展速度. 每个等级都有自己的一套重生点数, 这意味着要想获得所有必要的点数来购买一些升级, 就需要扮演所有三个等级, 并将这些点数存起来!\n\n" +
                                "建议你在完成重生之前, 先导出你的保存, 以防你决定改变主意. ";
                            break;
                        default:
                            Text.text = "Upon completing Area 1-5, you will now be able to Rebirth. Rebirth is a prestige mechanic that provides you access to powerful upgrades that will increase your overall power and how quickly you are able to progress through the game. Each class has its own set of Rebirth points, meaning that to acquire all of the necessary points to purchase some upgrades will require playing as all three classes and saving up those points!\n\n" +
                                "It is recommended that you export your save before completing a Rebirth in case you decide to change your mind.";
                            break;
                    }
                    break;
                case HelpKind.challenge:
                    switch (LocalizeInitialize.language)
                    {
                        case Language.eng:
                            Text.text = "Challenge Bosses are unleashed upon defeating the Eighth map of an Area. These bosses grow in difficulty with every defeat, learning from their mistakes. However, they provide permanent bonuses to your stats and drop some very rare materials that you will need for upgrading/evolving some Equipment.\n\n" +
                                "Be warned, as they grow in strength, they also grow in strategy. Do not be surprised if one fight to the next suddenly jumps in difficulty as a Challenge Boss begins doing things you had not anticipate, nor prepared at all to face!";
                            break;
                        case Language.jp:
                            Text.text = "チャレンジ (Challenge)は, 各エリアの8番目のマップを倒すと解放されます. これらのボスは, 彼らの過ちから学び, 倒すたびにより強力になります. 倒したレベルに応じて永続的なステータスボーナスを獲得でき, また, いくつかの装備をレベルアップ/進化させるために必要となる非常にまれな材料を落とします. \n\n";
                            break;
                        case Language.chi:
                            Text.text = "Challenge Boss是在击败一个区域的第八张地图后发动的. 这些boss的难度会随着每次失败而增加, 从他们的错误中学习. 不过, 他们会给你的数据提供永久的加成, 并且会掉落一些非常稀有的材料, 你需要这些材料来升级/进化一些装备. \n\n" +
                                "请注意, 随着他们实力的增长, 他们的策略也在增长. 当挑战BOSS开始做一些你没有预料到, 也没有准备好面对的事情时, 如果一场战斗到下一场战斗的难度突然跳升, 请不要惊讶!";
                            break;
                        default:
                            Text.text = "Challenge Bosses are unleashed upon defeating the Eighth map of an Area. These bosses grow in difficulty with every defeat, learning from their mistakes. However, they provide permanent bonuses to your stats and drop some very rare materials that you will need for upgrading/evolving some Equipment.\n\n" +
                                "Be warned, as they grow in strength, they also grow in strategy. Do not be surprised if one fight to the next suddenly jumps in difficulty as a Challenge Boss begins doing things you had not anticipate, nor prepared at all to face!";
                            break;
                    }
                    break;
                case HelpKind.bestiary:
                    switch (LocalizeInitialize.language)
                    {
                        case Language.eng:
                            Text.text = "The Bestiary will keep track of how many monsters you have defeated, conveniently listing off all of the loot that they are capable of dropping along with the drop chances. It will also show how many you have captured as well, enabling you to begin harvesting those possible loot drops every 2-3 hours. \n\n" +
                                "This harvesting is manual, but there is a Loot All button provided in the top left of the Bestiary Window to make this process simpler. Additionally, and Epic Shop upgrade has also been made available that will auto-collect Bestiary harvests as soon as they are ready, providing a permanent passive income of potentially rare items!";
                            break;
                        case Language.jp:
                            Text.text = "モンスター図鑑 (Bestiary)は, あなたが倒したモンスターの数を記録し, 各モンスターからドロップできる戦利品を表示します. また, 捕獲 (Capture)した数も表示され, 一定時間ごとに戦利品のボーナスドロップができるようになります. \n\n" +
                                "この戦利品ボーナスの収穫は手動ですが, このプロセスを簡単にするために, モンスター図鑑ウィンドウの左上に「一括収穫 (Loot All)」ボタンがあります.  さらに, エピックストア (Epic Store)のアップグレードでは, 収穫ゲージがたまると自動収集できる機能もあります. ";
                            break;
                        case Language.chi:
                            Text.text = "兽栏会记录你打败了多少怪物, 方便地列出它们能够掉落的所有战利品以及掉落几率. 它还会显示你抓了多少只, 让你每隔2-3小时就能开始收获那些可能掉落的战利品. \n\n" +
                                "这个收获是手动的, 但在兽栏窗口的左上方提供了一个全部掠夺按钮, 让这个过程变得更简单. 此外, 还提供了史诗商店升级功能, 一旦兽栏收获准备好, 就会自动收集, 提供潜在稀有物品的永久被动收入!";
                            break;
                        default:
                            Text.text = "The Bestiary will keep track of how many monsters you have defeated, conveniently listing off all of the loot that they are capable of dropping along with the drop chances. It will also show how many you have captured as well, enabling you to begin harvesting those possible loot drops every 2-3 hours. \n\n" +
                                "This harvesting is manual, but there is a Loot All button provided in the top left of the Bestiary Window to make this process simpler. Additionally, and Epic Shop upgrade has also been made available that will auto-collect Bestiary harvests as soon as they are ready, providing a permanent passive income of potentially rare items!";
                            break;
                    }
                    break;
                case HelpKind.bank:
                    switch (LocalizeInitialize.language)
                    {
                        case Language.eng:
                            Text.text = "The Slime Bank is built around a special currency that is generated when your current gold reaches the gold cap. All excess gold is then collected by the Slime Bank and converted into Slime Coin. Slime Coin can be used to purchase very powerful upgrades that greatly boost several aspects of the game. However, not all upgrades are immediately available. The Slime Bank won't start out trusting you, so you won't have full access to the bank. Continue to purchase upgrades or you can donate your Slime Coin to the Slime Orphan Fund for a large boost in reputation.";
                            break;
                        case Language.jp:
                            Text.text = "スライムバンク (Slime Bank)では, スライムコイン (Slime Coin)を通貨とするアップグレードを購入できます. スライムコインは, 現在所持しているゴールド (Gold)がゴールドキャップに達したときに生成されます. ゴールドキャップに達している状態で獲得した余分なゴールドはすべてスライムコインに変換されます. スライムコインは, ゲームの様々な側面を大幅に後押しする非常に強力なアップグレードを購入するために使用できます. ただし, すべてのアップグレードがすぐに利用できるわけではありません. 最初のうちは, スライムバンクはあなたをそれほど信頼していないので, あなたは銀行への完全なアクセス権を持っていません. バンクのアップグレードを購入するか, スライムコインをスライムオーファンファンドに寄付して評判を大幅に高めることができます. ";
                            break;
                        case Language.chi:
                            Text.text = "史莱姆银行是围绕着一种特殊的货币建立的, 当你当前的黄金达到黄金上限时, 就会产生这种货币. 然后, 所有多余的黄金都会被史莱姆银行收集, 并转换成史莱姆币. 史莱姆币可以用来购买非常强大的升级, 大大提升游戏的几个方面. 不过, 并不是所有的升级都可以立即使用. 史莱姆银行一开始不会信任你, 所以你不会完全使用银行. 继续购买升级, 或者你可以将你的史莱姆币捐给史莱姆孤儿基金, 以获得声望的大幅提升. ";
                            break;
                        default:
                            Text.text = "The Slime Bank is built around a special currency that is generated when your current gold reaches the gold cap. All excess gold is then collected by the Slime Bank and converted into Slime Coin. Slime Coin can be used to purchase very powerful upgrades that greatly boost several aspects of the game. However, not all upgrades are immediately available. The Slime Bank won't start out trusting you, so you won't have full access to the bank. Continue to purchase upgrades or you can donate your Slime Coin to the Slime Orphan Fund for a large boost in reputation.";
                            break;
                    }
                    break;
                case HelpKind.nitro:
                    switch (LocalizeInitialize.language)
                    {
                        case Language.eng:
                            Text.text = "Nitro is a substance that increases the speed of the game when consumed. It starts off as something you can only earn offline, but you will eventually discover another method for earning it while you are online! Additional upgrades will also be available much later in the game that improve the speed and the max capacity.";
                            break;
                        case Language.jp:
                            Text.text = "ニトロ (Nitro)は, ニトロブースター (Nitro Booster)に使用されます. ブースター使用時にはゲーム全体の進行速度が２倍になります. 最初のうちは, ニトロはオフライン中でのみ獲得できます. ゲームを進めていくにつれて, オンラインでも獲得できるような方法を発見できるでしょう. 速度と最大容量を改善する追加のアップグレードも, ゲームのかなり後の方で利用できるようになります. ";
                            break;
                        case Language.chi:
                            Text.text = "硝化甘油是一种消耗后可以提高游戏速度的物质. 一开始它是你只能在线下赚取的东西, 但你最终会发现另一种方法, 在你在线时赚取它! 额外的升级也会在游戏后期很多时候出现, 可以提高速度和最大容量. ";
                            break;
                        default:
                            Text.text = "Nitro is a substance that increases the speed of the game when consumed. It starts off as something you can only earn offline, but you will eventually discover another method for earning it while you are online! Additional upgrades will also be available much later in the game that improve the speed and the max capacity.";
                            break;
                    }
                    break;
                case HelpKind.epicstore:
                    switch (LocalizeInitialize.language)
                    {
                        case Language.eng:
                            Text.text = "The Epic Store is where you can spend your premium currency, Epic Coins, in exchange for some of the most powerful upgrades in the game!\n\n" +
                                "The Epic Store is dynamic, though, and so not all of its upgrades are available from the start. As you unlock new features, any Epic Upgrades that may exist for that feature will then become available for you.\n\n" +
                                "Nearly all upgrades found here work to improve the game's Quality of Life, and have been designed to enhance your game experience. It has been carefully designed to not change the overall experience nor to overpower your character and ruin the fun.\n\n" +
                                "Everything in the Epic Store can be acquired entirely free by playing the game, but if you would like to support the game, we have also provided a tab for you to purchase Epic Coins directly.";
                            break;
                        case Language.jp:
                            Text.text = "エピックストア (Epic Store)では, プレミアム通貨であるエピックコイン (Epic Coin)を使用して, 本ゲームで最も強力なアップグレードを購入できます. \n\n" +
                                "エピックストア内のアップグレードは, ゲームプレイのQOL・ゲーム体験を向上させるように設計されています. \n\n" +
                                "エピックストア内のアップグレードは, ゲームを長くプレイすることで全てを無料で入手できますが, 本ゲームをサポートしたい場合, エピックコインを直接購入するためのタブも用意されています. ";
                            break;
                        case Language.chi:
                            Text.text = "在史诗商店中, 你可以花费你的高级货币--史诗币, 换取游戏中最强大的升级!\n\n" +
                                "不过, 史诗商店是动态的, 所以并不是所有的升级都可以从一开始就获得. 当你解锁新功能时, 任何可能存在于该功能的史诗升级都会在那时为你提供. \n\n" +
                                "在这里找到的几乎所有升级都是为了提高游戏的生活质量, 并且是为了提升你的游戏体验而设计的. 它经过精心设计, 既不会改变整体体验, 也不会让你的角色过于强大而破坏游戏乐趣. \n\n" +
                                "史诗商店中的所有东西都可以通过玩游戏完全免费获得, 但如果你想支持游戏, 我们也提供了一个标签让你直接购买史诗币. ";
                            break;
                        default:
                            Text.text = "The Epic Store is where you can spend your premium currency, Epic Coins, in exchange for some of the most powerful upgrades in the game!\n\n" +
                                "The Epic Shop is dynamic, though, and so not all of its upgrades are available from the start. As you unlock new features, any Epic Upgrades that may exist for that feature will then become available for you.\n\n" +
                                "Nearly all upgrades found here work to improve the game's Quality of Life, and have been designed to enhance your game experience. It has been carefully designed to not change the overall experience nor to overpower your character and ruin the fun.\n\n" +
                                "Everything in the Epic Store can be acquired entirely free by playing the game, but if you would like to support the game, we have also provided a tab for you to purchase Epic Coins directly.";
                            break;
                    }
                    break;
                case HelpKind.capture:
                    switch (LocalizeInitialize.language)
                    {
                        case Language.eng:
                            Text.text = "In order to begin capturing, you must reach Area 3 to acquire the ingredients to build Traps. Traps are unlocked through the Alchemy system once you progress to 100mL. Unlocking the recipe for Traps is expensive, though, so be sure you've saved up your Alchemy Points.";
                            Text.text += "\n\n Once you have spider silk and the Trap recipe, craft a trap and then you will be able to right-click on a monster in order to attempt capture.";
                            Text.text += "\n\n The base rate of capture for regular monsters (non-boss) is 10% and that has a scaling improvement after the monster drops below 75% HP.";
                            Text.text += "\n\n The base rate of capture for boss monsters is 0% and that switches to 5% when the Boss HP falls below 5%.";
                            Text.text += "\n\n Slime Bank Updates: \nEnhanced Capture Traps: Increase the base % chance to catch for regular monsters by 1 % starting at 100% monster HP and for boss monsters by 0.5 % starting at < 5 % HP.";
                            Text.text += "\nHealthy Capture Traps: Increase the base % chance to catch for regular monsters by 2% & boss monsters by 1% only while Monster HP = 100%.";
                            Text.text += "\n\n The 100 Mission Bonus for +20% capture chance is multiplicative and affects both regular and boss monsters, but bosses only when they are below 5% HP.";
                            Text.text += "\n\n Challenge Bosses are not capturable.";
                            break;
                        case Language.jp:
                            Text.text = "捕獲 (Capture)を開始するには, エリア3に到達して, 捕獲用トラップ (Trap)を錬金するための材料を入手する必要があります. 錬金術 (Alchemy)システムの100 mLタブ内で, 捕獲用トラップを解禁できます. ";
                            Text.text += "\n\n 捕獲用トラップを作成すると, モンスターを右クリックして捕獲を試みることができます. ";
                            Text.text += "\n\n 通常のモンスター (ボス以外)の基本捕獲率は10％で, モンスターのHPが75％を下回ると捕獲率が向上します. ";
                            Text.text += "\n\n ボスモンスターの基本捕獲率は0％で, ボスのHPが5％を下回ると捕獲率は5％に切り替わります. ";
                            Text.text += "\n\n スライムバンク (Slime Bank)内アップグレード : \nEnhanced Capture Traps : 通常のモンスターの基本捕獲率を1%増加させ, 5％以下HP時のボスモンスターの基本捕獲率を0.5％増加させます. ";
                            Text.text += "\nHealthy Capture Traps: モンスターのHPが100％の場合のにみ, 通常のモンスターを捕まえる基本％チャンスを2％増やし, ボスモンスターに対しては1％増やします. ";
                            Text.text += "\n\n チャレンジボスは捕獲できません. ";
                            break;
                        case Language.chi:
                            Text.text = "为了开始抓捕, 你必须到达3号区域获得建造陷阱的原料. 当你进阶到100mL后, 就可以通过炼金系统解锁陷阱. 不过解锁陷阱的配方是很昂贵的, 所以一定要把炼金点数存起来. ";
                            Text.text += "\n\n 一旦你有了蜘蛛丝和陷阱配方, 制作一个陷阱, 然后你就可以右键点击一个怪物, 以便尝试捕捉. ";
                            Text.text += "\n\n 普通怪物(非boss)的基础捕获率为10%, 在怪物HP降到75%以下后, 这个比率有一个缩放的提升. ";
                            Text.text += "\n\n Boss怪物的基础捕获率是0%, 当boss的hp低于5%时, 就会切换到5%. ";
                            Text.text += "\n\n Slime Bank Updates: \n增强捕捉陷阱. 从100%怪物HP开始, 普通怪物的基本捕捉几率增加1%；从<5%HP开始, 老板怪物的捕捉几率增加0.5%. ";
                            Text.text += "\nHealthy Capture Traps: 在怪物HP=100%的情况下, 普通怪物的基础抓取几率提高2%, boss怪物提高1%. ";
                            Text.text += "\n\n 捕获几率+20%的100任务奖励是多倍的, 对普通怪和Boss怪都有影响, 但Boss只有在HP低于5%时才会影响. ";
                            Text.text += "\n\n 挑战BOSS是无法捕捉的. ";
                            break;
                        default:
                            Text.text = "In order to begin capturing, you must reach Area 3 to acquire the ingredients to build Traps. Traps are unlocked through the Alchemy system once you progress to 100mL. Unlocking the recipe for Traps is expensive, though, so be sure you've saved up your Alchemy Points.";
                            Text.text += "\n\n Once you have spider silk and the Trap recipe, craft a trap and then you will be able to right-click on a monster in order to attempt capture.";
                            Text.text += "\n\n The base rate of capture for regular monsters (non-boss) is 10% and that has a scaling improvement after the monster drops below 75% HP.";
                            Text.text += "\n\n The base rate of capture for boss monsters is 0% and that switches to 5% when the Boss HP falls below 5%.";
                            Text.text += "\n\n Slime Bank Updates: \nEnhanced Capture Traps: Increase the base % chance to catch for regular monsters by 1 % starting at 100% monster HP and for boss monsters by 0.5 % starting at < 5 % HP.";
                            Text.text += "\nHealthy Capture Traps: Increase the base % chance to catch for regular monsters by 2% & boss monsters by 1% only while Monster HP = 100%.";
                            Text.text += "\n\n The 100 Mission Bonus for +20% capture chance is multiplicative and affects both regular and boss monsters, but bosses only when they are below 5% HP.";
                            Text.text += "\n\n Challenge Bosses are not capturable.";
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

    }


}
