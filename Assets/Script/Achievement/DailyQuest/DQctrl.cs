using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using UnityEngine.EventSystems;
using TMPro;
using System.Linq;

public class DQctrl : BASE
{

    //ミッションの種類は今のところ2種類
    //canClearは時間がたってないか，すでにクリアしている．
    public bool canClear { get => main.S.isClearedToday[dailyQuestId]; set => main.S.isClearedToday[dailyQuestId] = value; }
    DateTime todayDate;
    int SavedDate { get => main.S.DailyQuestSavedDate[dailyQuestId]; set => main.S.DailyQuestSavedDate[dailyQuestId] = value; }
    bool isQuestInstantiated { get => main.S.isQuestInstantiated[dailyQuestId]; set => main.S.isQuestInstantiated[dailyQuestId] = value; }
    int questInfoId { get => main.S.dailyQuestInfoId[dailyQuestId]; set => main.S.dailyQuestInfoId[dailyQuestId] = value; }
    //倒した敵の数とマテリアルを保存
    long defeatedEnemyNum { get => main.S.defeatedEnemyNum[(int)targetEnemy]; set => main.S.defeatedEnemyNum[(int)targetEnemy] = value; }
    //long getheredMaterialNum { get => main.S.getheredMaterialNum[(int)targetMaterial]; set => main.S.getheredMaterialNum[(int)targetMaterial] = value; }
    long requiredEnemyNum;
    long requiredMaterial;
    int todayInt;
    bool isAvailable;
    string clientName = "Arua";
    string townName = "Tokyo";
    string landName = "America";
    public int dailyQuestId;
    GameObject window;
    Button clearButton;
    Func<bool> clearCondition = () => false;
    public enum Rarity
    {
        common,
        uncommon,
        rare,
        legendary,
        epic
    }
    public enum QuestKind
    {
        enemy,
        material
    }
    public Rarity rarity { get => main.S.rarity[dailyQuestId]; set => main.S.rarity[dailyQuestId] = value; }
    public QuestKind questKind { get => main.S.questKind[dailyQuestId]; set => main.S.questKind[dailyQuestId] = value; }
    public ENEMY.EnemyKind targetEnemy { get => main.S.targetEnemy[dailyQuestId]; set => main.S.targetEnemy[dailyQuestId] = value; }
    public ArtiCtrl.MaterialList targetMaterial { get => main.S.targetMaterial[dailyQuestId]; set => main.S.targetMaterial[dailyQuestId] = value; }
    //↓スタートだけではなく切り替わった瞬間にも呼ぶ．
    void InstantiateQuest()
    {
        //すでにクエストがあればリターンする．
        if (isQuestInstantiated)
            return;

        //倒した敵の数をリセットする．
        for (int i = 0; i < main.S.defeatedEnemyNum.Length; i++)
        {
            main.S.defeatedEnemyNum[i] = 0;
        }
        isQuestInstantiated = true;
        //レアリティを選択する．
        rarity = chooseRarity();
        //ターゲットの敵を選択する．
        chooseEnemy();
        //ターゲットのマテリアルを選択する．
        targetMaterial = chooseMaterial();
        //クエストの種類を選択する．(現状0しかできてない)
        questInfoId = UnityEngine.Random.Range(0, 10);
        //questInfoId = 8;


    }
    void UpdateInfo()
    {
        //クエストの条件を代入する．
        if (questInfoId == 4 || questInfoId == 6)
        {
            clearCondition = () => main.ArtiCtrl.CurrentMaterial[targetMaterial] >= requiredMaterial;
            questKind = QuestKind.material;
        }
        else
        {
            clearCondition = () => defeatedEnemyNum >= requiredEnemyNum;
            questKind = QuestKind.enemy;
        }
        //クエストの難易度によって要求数を代入する．
        determineNum();
        //infoId8の時は・・・
        if (questInfoId == 8)
        {
            targetEnemy = ENEMY.EnemyKind.SlimeBoss;
            switch (rarity)
            {
                case Rarity.common:
                    requiredEnemyNum = 10;
                    break;
                case Rarity.uncommon:
                    requiredEnemyNum = 20;
                    break;
                case Rarity.rare:
                    requiredEnemyNum = 40;
                    break;
                case Rarity.epic:
                    requiredEnemyNum = 80;
                    break;
                case Rarity.legendary:
                    requiredEnemyNum = 100;
                    break;
            }
        }
        string[] landKouho = new string[] { "America", "Japan", "France", "Russia", "Canada", "Mexico", "Italy", "Australia", "Brazil", "China", "Korea", "Germany", "Singapore", "Libya", "India" };
        string[] townKouho = new string[] { "Tochigi", "Gifu", "Tokyo", "Osaka", "Nagoya","Dragonbottom","Quickdoom","Bondrill","Sicklever","Bowe Gulf","Barleydal","Forestcliffe","Cornestream","Wansea","Spleendale","Fairyfrith","Lessingwyke","Blastedroad","Sparthville","Mucksea","Flittermousemouthe","Cogtowne","Stourtor","Arvaleroad","Stanfelde","Hawkingcombe","Emeraldcorrie","Bowenock","Mightystrait","Barrenglen","Farwater","Lyngehampton","Wilderstream","Roaryngpass","Maddermere","Towercourse","Castlecoppice","Wildersea","Vinecorrie" };
        string[] clientNameKouho = new string[] { "Kei", "Hitan", "Loren", "Arua", "Nohn", "Wakana", "Rio", "Minato", "Akko", "Misa",
"Belladonna Magusreaper",
"Flame Honorwarden",
"Flora Saber",
"King Blackedge",
"Leo Wisesinner",
"Magus Demonsong",
"Magus Floraicon",
"Mourner Dark",
"River Squall",
"Shadow Jester",
"Shadow Mourner",
"Sin Fellanger",
"Sinner Silversin",
"Sunrise Quake",
"Tome Floradoom",
"Totem Violetchanter",
"Typhoon Warlockgrief",
"Victory Gunner",
"Warden Darkguard",
"Angel Gust",
"Arcana Song",
"Battler Shroudkiller",
"Blood Dawn",
"Claw Sunset",
"Curse Talondemon",
"Dirk Cursekiller",
"Fauna Lionmourner",
"Grave Queen",
"Grief Gravebrand",
"Jester Aeon",
"Jester Roamer",
"Mourner Arcana",
"Rain Riversinner",
"Rose Knightwarlock",
"Star Magezealot",
"Sunset Mourner",
"Totem Beastreaper",
"Totem Mist",
"Warden Guardlight",
"Aeon Honormage",
"Claw Doom",
"Claw Zealmourner",
"Dagger Sunset",
"Dirk Gravereaper",
"Fate Solitaire",
"Grave Wanderer",
"Griffon Silverhunter",
"Gust Blackchanter",
"Honor Rascal",
"Jasmine Magicchanter",
"Midnight Honor",
"Midnight Lionclaw",
"Mist Pandemonium",
"Opera Rubyanger",
"Rage Icebeast",
"Saber Lightning",
"Shadow Katanacaster",
"Tiger Violetcurse",
"Victor Axehunter",
"Blade Hunter",
"Blade Knightrune",
"Brand Midnightcaster",
"Grim Rose",
"Jasmine Iceking",
"Katana Windwarlock",
"Leo Lightslayer",
"Leo Wanderlust",
"Rose Nazareth",
"Seraphim Dawn",
"Seraphim Grave",
"Seraphim Maverick",
"Sheol Griffon",
"Sinner Gale",
"Star Totemcaster",
"Sunset Furor",
"Totem Guardsoul",
"Victory Blood",
"Wolf Grim",
"Zeal Ghostcaster",
"Claymore Griffonsong",
"Dawn Rune",
"Drake Katanabrand",
"Flame Spiritbane",
"Harmony Baneclaw",
"Ice Ruby",
"Knight Lawghost",
"Maxim Raven",
"Rouge Beastwolf",
"Ruby Heartlance",
"Ruby Violet",
"Saber Nemesis",
"Seraphim Raven",
"Sheol Magereaper",
"Storm Honorsinner",
"Storm Katanairon",
"Tarot Silvergold",
"Valentine Ghostslayer",
"Victory Roamer",
"Acarn",
"Asoneust",
"Biuseusala",
"Bonerit",
"Brganthil",
"Cilylys",
"Dialoch",
"Eumpe",
"Fabith",
"Gastene",
"Isani",
"Iteustr",
"Lananero",
"Lasonyndiul",
"Nerilalysi",
"Nusiau",
"Peam",
"Pymuli",
"Rncuse",
"Viusthol",
"Beussth",
"Dilymusa",
"Dusop",
"Imolentar",
"Krant",
"Krousy",
"Musici",
"Phiniliax",
"Phopi",
"Rodesus",
"Tisor",
"Useneuss",
"Usurenesteo",
"Xeon",
"Xetonen",
"Xeusmiop",
"Zelealilip",
"Zethius",
"Zeusel",
"Zeusthisius"};
        clientName = randomChoose(clientNameKouho);
        landName = randomChoose(landKouho);
        townName = randomChoose(townKouho);
    }
    void Start()
    {
        StartCoroutine(DelayStart());
    }

    IEnumerator DelayStart()
    {
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(OneSecCor());
        //debug用
        //isQuestInstantiated = false;
        InstantiateQuest();
        UpdateInfo();
        InstantiateWindow();
    }

    //スタートした後に，要求素材量と要求倒す数を代入する．
    void determineNum()
    {
        switch (rarity)
        {
            case Rarity.common:
                requiredEnemyNum = 100;
                requiredMaterial = 10;
                break;
            case Rarity.uncommon:
                requiredEnemyNum = 250;
                requiredMaterial = 25;
                break;
            case Rarity.rare:
                requiredEnemyNum = 1000;
                requiredMaterial = 50;
                break;
            case Rarity.epic:
                requiredEnemyNum = 2500;
                requiredMaterial = 100;
                break;
            case Rarity.legendary:
                requiredEnemyNum = 7500;
                requiredMaterial = 200;
                break;
        }
    }
    int rand;

    DQctrl.Rarity chooseRarity()
    {
        rand = UnityEngine.Random.Range(0, 10000);

        if (!main.S.RareDQ1 && !main.S.RareDQ2)
        {
            if (rand <= 8000)
            {
                return Rarity.common;
            }
            else if (rand <= 9000)
            {
                return Rarity.uncommon;
            }
            else if (rand <= 9600)
            {
                return Rarity.rare;
            }
            else if (rand <= 9900)
            {
                return Rarity.epic;
            }
            else if (rand <= 10000)
            {
                return Rarity.legendary;
            }
        }
        else if (main.S.RareDQ1 && !main.S.RareDQ2)
        {
            if (rand < 0) // 選ばれない
            {
                return Rarity.common;
            }
            else if (rand <= 8100)
            {
                return Rarity.uncommon;
            }
            else if (rand <= 9100)
            {
                return Rarity.rare;
            }
            else if (rand <= 9700)
            {
                return Rarity.epic;
            }
            else if (rand <= 10000)
            {
                return Rarity.legendary;
            }
        }
        else if (!main.S.RareDQ1 && main.S.RareDQ2)
        {
            if (rand <= 8000) 
            {
                return Rarity.common;
            }
            else if (rand <= 8000)// 選ばれない
            {
                return Rarity.uncommon;
            }
            else if (rand <= 9100)
            {
                return Rarity.rare;
            }
            else if (rand <= 9700)
            {
                return Rarity.epic;
            }
            else if (rand <= 10000)
            {
                return Rarity.legendary;
            }
        }
        else
        {
            if (rand < 0) // 選ばれない
            {
                return Rarity.common;
            }
            else if (rand < 0)// 選ばれない
            {
                return Rarity.uncommon;
            }
            else if (rand <= 8400)
            {
                return Rarity.rare;
            }
            else if (rand <= 9400)
            {
                return Rarity.epic;
            }
            else if (rand <= 10000)
            {
                return Rarity.legendary;
            }
            
        }
        return Rarity.common;

    }

    void  chooseEnemy()
    {
        int tempCount = 0;
         while (tempCount <= 100)
         {
             int num = Enum.GetValues(typeof(ENEMY.EnemyKind)).Length;
             int randomNum = UnityEngine.Random.Range(0, num);
            if (main.S.ReincarnationNum > 0)
            {
                if (main.ZoneCtrl.EnemyAry[randomNum] != null && main.S.totalEnemiesKilled[randomNum] > 0)
                {
                    targetEnemy = (ENEMY.EnemyKind)randomNum;
                    break;
                }
            }
            else
            {
                if (main.ZoneCtrl.EnemyAry[randomNum] != null && main.S.totalEnemiesKilledAfterReincarnation[randomNum] > 0)
                {
                    targetEnemy = (ENEMY.EnemyKind)randomNum;
                    break;
                }
            }
            tempCount++;
         }
        targetEnemy =  ENEMY.EnemyKind.NormalSlime;
    }
    ArtiCtrl.MaterialList chooseMaterial()
    {
        return main.bestiary.ChooseRandomMaterial();
    }
    string randomChoose(string[] vs)
    {
        int randomNum = UnityEngine.Random.Range(0, vs.Length);
        return vs[randomNum];
    }
    //クエストinfoの種類によってディスクリプションを変える．
    string[] ExplainAndObjectiveText()
    {
        string tempText1 = "";
        string tempText2 = "";

        switch (questInfoId)
        {
            case 0:
                tempText1 =
                    string.Format("A fancy carriage stops next to you while traveling the roads. The occupant of the carriage peeks out of the window and speaks to you," +
                    " \"Good day there traveler! I am {0}! I am a merchant from the city of {1}. I hope you know that the" +
                    " direction you are traveling in is currently infested with {2} at the moment. Terrible creatures...\" as " +
                    "they glance down at the stains of blood on the sides of the Carriage. \"Killed several of my guards before we were able to flee to safety. " +
                    "I would normally implore you to seek safer passage elsewhere, but you look like you can handle yourself. If you can get vengeance for me by " +
                    "slaying at least {3} of those disgusting things I will reward you! Seek me out in {1} if you manage " +
                    "it!\" and then the Carriage continues on down the path.", clientName, townName, main.ArtiCtrl.ConvertEnum(targetEnemy), requiredEnemyNum);
                tempText2 =
                    string.Format("Kill {0} {1} and report your success " + 
                    "to {2} in {3}.", requiredEnemyNum, main.ArtiCtrl.ConvertEnum(targetEnemy), clientName, townName);
                break;
            case 1://0 clientName, 1: townName, 2: monster 3: count
                tempText1 =
                    string.Format("A fancy carriage stops next to you while traveling the roads. The occupant of the carriage peeks out of the window " +
                    "and speaks to you, \"Good day there traveler! I am {0}! I am a merchant from the city of {1}." +
                    " I hope you know that the direction you are traveling in is currently infested with {2} at the moment." +
                    " Terrible creatures...\" as they glance down at the stains of blood on the sides of the Carriage. \"Killed several of my guards " +
                    "before we were able to flee to safety. I would normally implore you to seek safer passage elsewhere, but you look like you can handle" +
                    " yourself. If you can get vengeance for me by slaying at least {3} of those disgusting things, I will " +
                    "reward you! Seek me out in {3} if you manage it!\" and then the Carriage continues on down the path.", clientName, townName, main.ArtiCtrl.ConvertEnum(targetEnemy), requiredEnemyNum);
                tempText2 =
                    string.Format("Kill {0} {1} and report your success " +
                    "to {2} in {3}.",requiredEnemyNum, main.ArtiCtrl.ConvertEnum(targetEnemy), clientName,townName);
                break;
            case 2:
                tempText1 =
                    string.Format("While perusing a list of bounties while throwing back a pint in a rustic tavern you stumbled upon, " +
                    "one listing catches your eye. It reads \"WANTED: For the destruction of {0} and the murder of countless people," +
                    " the village of {1} seeks the destruction of {2}. We want proof of kill of at least {3} " +
                    "of them brought to {1}.\" There reward listed below it is {4} epic coin. Seems like a worthy challenge."
                    ,landName, townName, main.ArtiCtrl.ConvertEnum(targetEnemy), requiredEnemyNum, showGetEpicCoin());
                tempText2 =
                    string.Format("Kill {0} {1} and report your success to {2}."
                    , requiredEnemyNum, main.ArtiCtrl.ConvertEnum(targetEnemy), townName);
                break;
            case 3:
                tempText1 =
                    string.Format("An elderly man traveling alone spots you in the distance, and hastily hobbles in your direction. " +
                    "\"They came in the night and took the life of some of the villagers. Friends, family, husbands and wives, gone in a flash. " +
                    "We lack the power to avenge our fallen. Please, hero, be our vengeance and unleash our fury upon those vicious {0}" +
                    " and kill at least {1} of them for us! Were I younger, I'd join you, but at my age I would just " +
                    "get in your way.\" Pretty presumptuous to assume you'll help, but he's offering a reward, so maybe he'll make it worth your " +
                    "time. You blink for a moment and he's gone, or maybe you zoned out and he left. You didn't get his name, or where he lives," +
                    " but with that hobbly tread you're sure you'll be able to track him down once the task is done."
                    , main.ArtiCtrl.ConvertEnum(targetEnemy), requiredEnemyNum);
                tempText2 =
                    string.Format("Kill {0} {1} and report your success to the elderly man whose name you forgot to ask."
                    , requiredEnemyNum, main.ArtiCtrl.ConvertEnum(targetEnemy));
                break;
            case 4:
                tempText1 =
                    string.Format("A young gentleman strolls up to you while you're resting in a tavern. \"Good day! My name is {0} and you look just " +
                    "like the kind of person who might be able to help me!\" You roll your eyes, wondering why this kind of thing keeps happening to you. He continues, \"You " +
                    "see, there's this girl I like and I mean really like. I want to impress her, but I don't know how.Do you have any ideas ? I know she has a fondness for " +
                    "{1}, but it's rare and I haven't managed to find a single one yet.I'm beginning to think they're just a myth.Could you see if "+
                    "you could find {2} for me? It would mean the world to me, and of course I will reward you!"
                    ,clientName,targetMaterial,requiredMaterial);
                tempText2 =
                    string.Format("Collect {0} {1}s and deliver them to the young gentleman."
                    , requiredMaterial, targetMaterial);
                break;
            case 5:
                tempText1 =
                     string.Format("A young girl marches up to you and tugs gently on your shirt. You look at her and see her eyes swelled up with tears. She says \"My brother " +
                     "is such an meany! He keeps pulling my hair and he scares me every single day!\" and then her face shifts to anger, \"So that's why I'm asking for your help! I " +
                     "know my brother is deathly afraid of {0}, so I've got a plan to scare him by filling his stupid room with the corpses of those things. Can you fetch me" +
                     " {1} {0} and then maybe he will finally leave me alone?\" " +
                     "You are both mortified and ready to champion for this disturbed little girl!", main.ArtiCtrl.ConvertEnum(targetEnemy), requiredEnemyNum);
                tempText2 =
                    string.Format("Kill {0} {1} and help the little girl traumatize her brother for the rest of his life."
                    , requiredEnemyNum, main.ArtiCtrl.ConvertEnum(targetEnemy));
                break;
            case 6:
                tempText1 =
                    string.Format("You find a message in a bottle, halfway buried in the dirt, alongside a poorly traveled path in the woods. The message " +
                    "reads, \"To whoever finds this, I'm probably already dead. My last wish was to bring {0} {1} " +
                    "to my daughter in {2} as the peace offering. We fought and she left home and I only just learned where she lived, but my old bones are too" +
                    " weak to make this trip I fear. If you could bring those to her and let her know that I loved her dearly, it will hopefully allow me to move on in peace. " +
                    "I've already left the reward for doing this quest in the bottle, but I hope that whoever finds this is honorable enough to fulfill a dead man's last " +
                    "request.\" Alright, you relent, but only because that story tugged your heart strings a little bit."
                    , requiredMaterial, targetMaterial, townName);
                tempText2 =
                    string.Format("Collect {0} {1} and deliver them to the daughter " +
                    "who lives in {2}.", requiredMaterial, targetMaterial, townName);
                break;
            case 7:
                tempText1 =
                    string.Format("You walk up to the sight of a burned building. A nearby man wearing a fine set of spectacles waves at you and " +
                    "rushes to greet you. \"Oh hello there!If you're looking for the Museum of Ancient Treasures and Magical Artifacts then you're too late. It " +
                    "was destroyed last night by a thief who then set fire to the whole place! What a fool, he clearly has no idea the level of historical significance " +
                    "that building had and held within it.He died, though, shortly thereafter.Ravaged by {0} as he attempted to carry off his " +
                    "ill - gotten goods.Before I could recover any of them, all of the artifacts he carried with him had been destroyed by those monsters.I don't care" +
                    " one bit about that thief, but I would ask that you kill those monsters for the damage they did to our history! There were around " +
                    "{1} of them, if I recall correctly. I'll reward you for doing this small right about this terrible wrong."
                    , main.ArtiCtrl.ConvertEnum(targetEnemy), requiredEnemyNum);
                tempText2 =
                    string.Format("Kill {0} {1} for the man who begrudges any who would dishonor" +
                    " history and it's treasures.", requiredEnemyNum, main.ArtiCtrl.ConvertEnum(targetEnemy));
                break;
            case 8:
                tempText1 =
                    string.Format("While out walking through nature, you are suddenly seized upon by the largest slime you've ever seen, a shiny crown jiggling atop" +
                    " it's mass. You draw your weapon ready to fight when it begins speaking to you, \"Hey now < flurzleblurp > I mean you no harm at the mom.." +
                    " < berferbelch > moment. I gome for your help < snazzwhurbarf >. You see, awful Slime Bosses have moved in on my Globdom, and I < hurrphurphurrr > " +
                    "need your help removing them. Just this once, gan you help me < goragburp > and my goople?\" As tempted as you are to fight this monster " +
                    "here and now, even you cannot turn down a plea for help so earnestly made.");
                tempText2 =
                    string.Format("Kill {0} Slime Boss and get your reward from the Slime King.",requiredEnemyNum);
                break;
            case 9:
                tempText1 =
                    string.Format("A snarky, little boy taunts you as you pass through town, \"Oh look, it's an ADVEEEEEEENTURER. Real fancy. Bet you haven't done anything " +
                    "your whole life but walk around and pretend you're some hero. Lame. I pick boogers out of my nose that are more intimidating than you are. Oh and you" +
                    " stink like... troll bung. How did you even make it this far into town without people throwing you out with a stink like that. I bet you were born stinky. " +
                    "I bet you're mother ev...\" The boy is suddenly snatched by the ear by his mother and thrown inside their house. The mother returns to you and " +
                    "says \"I am so sorry about that.He's been like that ever since his adventurous father was eaten by a {0}. Say, you look like you could handle" +
                    " one of those awful creatures! Could you kill {1} of them and let my son see that there are true adventurers in this world? " +
                    "Maybe then he will wake up and realize his dreams are possible again. I'll pay you of course!\" You're very unsure how to feel about all of this, especially " +
                    "with how he spoke to you, but the mother's words have moved you to grant her request.", main.ArtiCtrl.ConvertEnum(targetEnemy), requiredEnemyNum);
                tempText2 =
                    string.Format("Kill {0} {1} and return to the Mother and the rotten boy for your reward."
                    , requiredEnemyNum, main.ArtiCtrl.ConvertEnum(targetEnemy));
                break;
            default:
                return new string[] { "NULL", "NULL" };
        }
        return new string[] { tempText1, tempText2 };
    }
    IEnumerator OneSecCor()
    {
        //Debug.Log("aa");
        while (true)
        {
            //todayDate = DateTime.Now;
            if (UsefulMethod.DeltaTimeFloatNotSub(DateTime.Now - todayDate) >= 60f)
            {
                todayDate = todayDate + new TimeSpan(0, 0, 1);
            }
            else
            {
                todayDate = DateTime.Now;
            }
            todayInt = todayDate.Year * 10000 + todayDate.Month * 100 + todayDate.Day;

            if (todayInt > SavedDate)
            {   
                //savedDateを今にすれば必ず1回だけ呼ばれる！！   
                isQuestInstantiated = false;
                InstantiateQuest();
                UpdateInfo();
                canClear = true;
                //Ads用
                main.S.isDailyAP = false;
                main.S.dailyECnum = 0;

                SavedDate = DateTime.Now.Year * 10000 + DateTime.Now.Month * 100 + DateTime.Now.Day;
            }
            if (canClear)
            {
               // Debug.Log("Quest進行中だよ．");
            }
            else
            {
               // Debug.Log("Quest終わったよ．次にできるのは．．．" + DoubleTimeToDate(86400 - (todayDate.Hour * 3600 + todayDate.Minute * 60 + todayDate.Second)));
            }
            yield return new WaitForSecondsRealtime(1.0f);
        }
    }
    void ClearQuest()
    {
        if (!canClear)
            return;
        else
        {
            main.S.ECbyDailyQuest += showGetEpicCoin() / 5;   
            if (questKind == QuestKind.material)
            {
                main.ArtiCtrl.CurrentMaterial[targetMaterial] -= (int)requiredMaterial;
            }
            canClear = false;
            todayDate = DateTime.Now;
            SavedDate = todayDate.Year * 10000 + todayDate.Month * 100 + todayDate.Day;
        }

    }

    TextMeshProUGUI nameText;
    TextMeshProUGUI explainText;
    TextMeshProUGUI objectiveText;
    TextMeshProUGUI rewardText;
    public void InstantiateWindow()
    {
        window = Instantiate(main.P_texts[29], main.WindowShowCanvas);
        gameObject.AddComponent<EventTrigger>().triggers = new List<EventTrigger.Entry>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry2.eventID = EventTriggerType.PointerExit;
        entry.callback.AddListener((x) => UsefulMethod.setActive(window));
        entry2.callback.AddListener((x) => UsefulMethod.setFalse(window)); //ラムダ式の右側は追加するメソッドです。
        gameObject.GetComponent<EventTrigger>().triggers.Add(entry);
        gameObject.GetComponent<EventTrigger>().triggers.Add(entry2);
        nameText = window.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        explainText = window.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        objectiveText = window.transform.GetChild(4).GetComponent<TextMeshProUGUI>();
        rewardText = window.transform.GetChild(6).GetComponent<TextMeshProUGUI>();

    }
    long showGetEpicCoin()
    {
        switch (rarity)
        {
            case Rarity.common:
                return 50;
            case Rarity.uncommon:
                return 125;
            case Rarity.rare:
                return 250;
            case Rarity.epic:
                return 375;
            case Rarity.legendary:
                return 500;
        }

        return 0;
    }
    string showQuestProgress()
    {
        string tempText = "";
        if (questKind == QuestKind.enemy)
        {
            tempText = "\n\n- Current : " + tDigit(defeatedEnemyNum) + " / " + tDigit(requiredEnemyNum);
        }
        else
        {
            tempText = "\n\n- Current : " + main.ArtiCtrl.CurrentMaterial[targetMaterial] + " / " + tDigit(requiredMaterial);
        }

        return tempText;
    }
    public void ShowWindow()
    {
        if(window == null)
        {
            return;
        }
        if (window.activeSelf)
        {
            if (canClear)
            {
                nameText.text = "Daily Quest ( " + rarity + " ) ";
            }
            else
            {
                nameText.text = "Daily Quest ( " + rarity + " ) <color=green> Cleared!";
            }
            explainText.text = ExplainAndObjectiveText()[0];
            objectiveText.text = ExplainAndObjectiveText()[1] + showQuestProgress();
            rewardText.text = "Epic Coin " + showGetEpicCoin();

            //if (window != null)
            //{
            //    if (Input.mousePosition.y >= 300 && Input.mousePosition.x >= 400)
            //    {
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(-250.0f, -50.0f);
            //    }
            //    else if (Input.mousePosition.y >= 300 && Input.mousePosition.x < 400)
            //    {
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(50.0f, -50.0f);
            //    }
            //    else if (Input.mousePosition.y < 300 && Input.mousePosition.x > 400)
            //    {
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(-250.0f, 50.0f);
            //    }
            //    else if (Input.mousePosition.y < 300 && Input.mousePosition.x < 400)
            //    {
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(50.0f, 150.0f);
            //    }
            //}
        }
    }

    // Use this for initialization
    void Awake()
    {
        StartBASE();
        clearButton = gameObject.transform.GetChild(2).GetComponent<Button>();
        clearButton.onClick.AddListener(ClearQuest);
    }
    // Use this for initialization


    // Update is called once per frame
    void Update()
    {
        ShowWindow();

        if (!clearCondition()||!canClear)
        {
            clearButton.interactable = false;
        }
        else
        {
            clearButton.interactable = true;
        }

    }

    static T RandomElementAt<T>(IEnumerable<T> ie)
    {
        return ie.ElementAt(new System.Random().Next(ie.Count()));
    }
}
