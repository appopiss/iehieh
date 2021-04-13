using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BankLocal : BASE, ILocalizedText
{
    public void UpdateText(Language lang)
    {
    }
    public static string BaseFormatForCurrentAndNext(string effectExplain, string currentValue, string nextValue, double tempLevel)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                return "- " + effectExplain + "\n-- Current : " + currentValue +
                    "\n-- Next : " + nextValue + " ( <color=\"green\">Lv " + tempLevel + "</color> ) ";
            case Language.jp:
                return "- " + effectExplain + "\n-- 現在のレベル : " + currentValue +
                    "\n-- 次のレベル : " + nextValue + " ( <color=\"green\">Lv " + tempLevel + "</color> ) ";
            case Language.chi:
                return "- " + effectExplain + "\n-- 当前 : " + currentValue +
                    "\n-- 下个 : " + nextValue + " ( <color=\"green\">Lv " + tempLevel + "</color> ) ";
        }
        return "- " + effectExplain + "\n-- Current : " + currentValue +
            "\n-- Next : " + nextValue + " ( <color=\"green\">Lv " + tempLevel + "</color> ) ";
    }
    public static string BaseFormatForName(string Name, string levelString)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.jp:
                return Name + " <<color=\"green\">レベル " + levelString + "</color> >";
            case Language.chi:
                return Name + " <<color=\"green\">Lv " + levelString + "</color> >";
        }
        return Name + " <<color=\"green\">Lv " + levelString + "</color> >";
    }
    public static void UpdateBaseFormatForHeader(TextMeshProUGUI effect, TextMeshProUGUI explain, TextMeshProUGUI cost)
    {
        LocalizeInitialize.SetFont(effect, explain, cost);
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                effect.text = "Effect";
                explain.text = "Description";
                cost.text = "Cost";
                break;
            case Language.jp:
                effect.text = "効果";
                explain.text = "説明";
                cost.text = "コスト";
                break;
            case Language.chi:
                effect.text = "科技效果";
                explain.text = "介绍";
                cost.text = "费用";
                break;
            default:
                effect.text = "Effect";
                explain.text = "Description";
                cost.text = "Cost";
                break;
        }
    }
    public static void B_cap(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.jp:
                name = "銀行キャップ";
                effectExplain = "スライムコインのキャップ上限を増加します.";
                explain = "A non-slime appears to be manning this counter, though you've never seen the miniscule likes of it anywhere else. She greets you in a slightly high pitched, energetic tone, \"Hi there! I\'m Shelba Higginsbottomsworthamillion. Oh I can see already that you\'re confused. I\'m a gnome! We don\'t come out much, but Papa Higginsbottomsworthamillion said I should see the world! So I set out, but then I got lost and ended up here. Short story short, now I work and live here! Anyways, enough about me. I can help you increase the amount of slime coins you can store in your bank account. Would you like me to do that for you today?\" She looks up earnestly at you, awaiting your reply as cute as friggin possible.";
                break;
            case Language.chi:
                name = "银行上限";
                effectExplain = "增加史莱姆币的上限.";
                explain = "扩建银行仓库, 增加史莱姆币的库存. 史莱姆币越多能研发的科技越多, 有钱就能使鬼推磨. 能存的史莱姆币变多了.";
                break;
            default:
                name = "Bank Cap";
                effectExplain = "Increase the cap of Slime Coin.";
                explain = "A non-slime appears to be manning this counter, though you've never seen the miniscule likes of it anywhere else. She greets you in a slightly high pitched, energetic tone, \"Hi there! I\'m Shelba Higginsbottomsworthamillion. Oh I can see already that you\'re confused. I\'m a gnome! We don\'t come out much, but Papa Higginsbottomsworthamillion said I should see the world! So I set out, but then I got lost and ended up here. Short story short, now I work and live here! Anyways, enough about me. I can help you increase the amount of slime coins you can store in your bank account. Would you like me to do that for you today?\" She looks up earnestly at you, awaiting your reply as cute as friggin possible.";
                break;
        }
    }
    public static void B_capture(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.jp:
                name = "捕獲用ネット強化";
                effectExplain = "捕獲ネットを強化し、モンスター捕獲率を向上させます.";
                explain = "An odd, mechanical orb floats around the bank, aimlessly, stopping occasionally to shoot an odd beam of light at random passers-by." +
                    " After it scans you a very strange voice emits from the spheroid. \"GREETINGS. zz-rtt SCANS REVEAL THIS LIFEFORM TO BE APPREHENDER OF HOSTILE " +
                    "ORGANISMS zz-rtt. DETECTED, ANALYZING STRUCTURE. ANALYSIS COMPLETE. SYNTHETIC LIFE SPHERE AE733-4 IS EQUIPPED TO ENHANCE zz-rtt PRIMITIVE" +
                    " ENSNAREMENTS AND AUTOMATE PROCESSES. REMUNERATION IS REQUIRED FOR ALL EXCHANGES OF SERVICE. zz-rtt DOES LIFEFORM ASSENT TO EXCHANGE?\" " +
                    "You aren't sure you even understood half of what sounds it just made. ";
                break;
            case Language.chi:
                name = "陷阱强化";
                effectExplain = "增加怪物捕捉率 , +1%*技能等级.";
                explain = "尝试各种材料制作陷阱, 终有个陷阱更容易捕捉怪物. 更容易捕捉怪物了.";
                break;
            default:
                name = "Enhanced Capture Traps";
                effectExplain = "Pay to improve your traps, increasing your capture chance with each upgrade.";// +
                explain = "An odd, mechanical orb floats around the bank, aimlessly, stopping occasionally to shoot an odd beam of light at random passers-by." +
                    " After it scans you a very strange voice emits from the spheroid. \"GREETINGS. zz-rtt SCANS REVEAL THIS LIFEFORM TO BE APPREHENDER OF HOSTILE " +
                    "ORGANISMS zz-rtt. DETECTED, ANALYZING STRUCTURE. ANALYSIS COMPLETE. SYNTHETIC LIFE SPHERE AE733-4 IS EQUIPPED TO ENHANCE zz-rtt PRIMITIVE" +
                    " ENSNAREMENTS AND AUTOMATE PROCESSES. REMUNERATION IS REQUIRED FOR ALL EXCHANGES OF SERVICE. zz-rtt DOES LIFEFORM ASSENT TO EXCHANGE?\" " +
                    "You aren't sure you even understood half of what sounds it just made. ";
                break;
        }
    }
    public static void B_enhanceS(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.jp:
                name = "ストーン強化訓練";
                effectExplain = "訓練3のアップグレードを強化し、ストーン生成の効率を向上させます.";
                explain = "An old man sits off to the side of the circular room. Approaching him, he quickly swaps his hat, which has an emblem for stone on it. Before you can speak to question the legitimacy of his operation," +
                    " he starts talking to you. Hey there sonny! I'm head of the stone labor union! I've got an exciting time share.. wait, wrong spiel... " +
                    "I've got an exciting opportunity for you! For a fee, I'll come out and personally train your workers to be more efficient at their work! Well... " +
                    "I'll lecture them until they start working faster anyways, because I won't stop until they do! It always works, I guarantee it!";
                break;
            case Language.chi:
                name = "采矿大师";
                effectExplain = "增加高级矿工的采矿效率.";
                explain = "在采矿大师的领导下, 更容易分辨矿石的种类. 增加蓝石的生产效率.";
                break;
            default:
                name = "Enhanced Training [Stone]";
                effectExplain = "Improves Train III to be more efficient than before.";
                explain = "An old man sits off to the side of the circular room. Approaching him, he quickly swaps his hat, which has an emblem for stone on it. Before you can speak to question the legitimacy of his operation," +
                    " he starts talking to you. Hey there sonny! I'm head of the stone labor union! I've got an exciting time share.. wait, wrong spiel... " +
                    "I've got an exciting opportunity for you! For a fee, I'll come out and personally train your workers to be more efficient at their work! Well... " +
                    "I'll lecture them until they start working faster anyways, because I won't stop until they do! It always works, I guarantee it!";
                break;
        }
    }

    public static void B_enhanceC(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.jp:
                name = "クリスタル強化訓練";
                effectExplain = "訓練3のアップグレードを強化し、クリスタル生成の効率を向上させます.";
                explain = "An old man sits off to the side of the circular room. Approaching him, he quickly swaps his hat, which has an emblem for crystal on it. Before you can speak to question the legitimacy of his operation," +
                    " he starts talking to you. Hey there sonny! I'm head of the crystal labor union! I've got an exciting time share.. wait, wrong spiel... " +
                    "I've got an exciting opportunity for you! For a fee, I'll come out and personally train your workers to be more efficient at their work! Well... " +
                    "I'll lecture them until they start working faster anyways, because I won't stop until they do! It always works, I guarantee it!";
                break;
            case Language.chi:
                name = "合成大师";
                effectExplain = "增加高级研究员的合成效率.";
                explain = "合成大师带领的队伍, 闭着眼睛随便合水晶. 增加水晶的生产效率.";
                break;
            default:
                name = "Enhanced Training [Crystal]";
                effectExplain = "Improves Train III to be more efficient than before.";
                explain = "An old man sits off to the side of the circular room. Approaching him, he quickly swaps his hat, which has an emblem for crystal on it. Before you can speak to question the legitimacy of his operation," +
                    " he starts talking to you. Hey there sonny! I'm head of the crystal labor union! I've got an exciting time share.. wait, wrong spiel... " +
                    "I've got an exciting opportunity for you! For a fee, I'll come out and personally train your workers to be more efficient at their work! Well... " +
                    "I'll lecture them until they start working faster anyways, because I won't stop until they do! It always works, I guarantee it!";
                break;
        }
    }
    public static void B_enhanceL(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.jp:
                name = "リーフ強化訓練";
                effectExplain = "訓練3のアップグレードを強化し、リーフ生成の効率を向上させます.";
                explain = "An old man sits off to the side of the circular room. Approaching him, he quickly swaps his hat, which has an emblem for leaf on it. Before you can speak to question the legitimacy of his operation," +
                    " he starts talking to you. Hey there sonny! I'm head of the leaf labor union! I've got an exciting time share.. wait, wrong spiel... " +
                    "I've got an exciting opportunity for you! For a fee, I'll come out and personally train your workers to be more efficient at their work! Well... " +
                    "I'll lecture them until they start working faster anyways, because I won't stop until they do! It always works, I guarantee it!";
                break;
            case Language.chi:
                name = "采集大师";
                effectExplain = "增加高级农民的采集绿叶效率.";
                explain = "在采集大师的指挥下, 采集绿叶不在话下. 增加绿叶的生产效率.";
                break;
            default:
                name = "Enhanced Training [Leaf]";
                effectExplain = "Improves Train III to be more efficient than before.";
                explain = "An old man sits off to the side of the circular room. Approaching him, he quickly swaps his hat, which has an emblem for leaf on it. Before you can speak to question the legitimacy of his operation," +
                    " he starts talking to you. Hey there sonny! I'm head of the leaf labor union! I've got an exciting time share.. wait, wrong spiel... " +
                    "I've got an exciting opportunity for you! For a fee, I'll come out and personally train your workers to be more efficient at their work! Well... " +
                    "I'll lecture them until they start working faster anyways, because I won't stop until they do! It always works, I guarantee it!";
                break;
        }
    }
    public static void B_slimecoin(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.jp:
                name = "スライムコインの帳簿";
                effectExplain = "怪しげなスライムに賄賂を払ってスライムバンクに忍び込み, スライムコインへの変換効率を書き換えます. ";
                explain = "“Psst, yeahs you, gets over here” you hear from a ventilation grate in the floor. You move closer and hear " +
                    "“Close enough yeah! Don’ts want da others to get any fishy ideas. So I’lls let yous in on a secret, k? Theys keep a book here abouts" +
                    " that tracks the deposits you make. I’s could gets in there and fix da numbers for ya, k? It’s risky, so I needs my fee upfront, but you’" +
                    "ll gets more slime coins for the golds you deposit. Sounds pretty keen, yeah?” There is some shady business going on here, and you’re very" +
                    " certain you’ve heard that accent somewhere before.";
                break;
            case Language.chi:
                name = "史莱姆币账本";
                effectExplain = "增加自动兑换史莱姆币兑换率, +1史莱姆币*技能等级.";
                explain = "“在账本的帮助下, 更容易记下金币兑换的记录, 不用再被邪恶的黑商的欺诈导致史莱姆兑换量减少. 获得史莱姆币变多了.";
                break;
            default:
                name = "Slime Coin Ledger";
                effectExplain = "Pay a shady slime to sneak into the Slime Bank and rig the books to improve your payoffs when converting Gold to SC.";
                explain = "“Psst, yeahs you, gets over here” you hear from a ventilation grate in the floor. You move closer and hear " +
                    "“Close enough yeah! Don’ts want da others to get any fishy ideas. So I’lls let yous in on a secret, k? Theys keep a book here abouts" +
                    " that tracks the deposits you make. I’s could gets in there and fix da numbers for ya, k? It’s risky, so I needs my fee upfront, but you’" +
                    "ll gets more slime coins for the golds you deposit. Sounds pretty keen, yeah?” There is some shady business going on here, and you’re very" +
                    " certain you’ve heard that accent somewhere before.";
                break;
        }
    }
    public static void B_donate(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.jp:
                name = "スライム孤児院に募金する";
                effectExplain = "直接的なメリットはありませんが, スライムバンクでの評判がかなり上がります.";
                explain = "A elderly-looking, grey slime with a poofy, white wig quakes slightly near the entrance to the bank. Is this like a slime grandma or something? " +
                    "\"Exgooze me young one. My name is Gooladys Wrinkledgoop. We are <blurpsnarfleplop> goollecting donations for the Orphan's Fund. <hisssssssssssnurfle>" +
                    " We would be goorateful if you'd <flurflecrack> ohh my aghing globs, sorry, if you'd donate today.\" She just stares intently at you, offering nothing " +
                    "in exchange for your slime coins. You wonder with a name like 'Wrinkledgoop' if she was born old.";
                break;
            case Language.chi:
                name = "史莱姆孤儿基金";
                effectExplain = "每级增加50点银行威望.";
                explain = "好人有好报, 谢谢你拯救水深火热的孤儿. 你的威望逐渐被传播出去";
                break;
            default:
                name = "Donate to the Slime Orphan Fund";
                effectExplain = "There is no direct benefit, but it increases \"Reputation\" with the Slimes a lot more than anything else.";
                explain = "A elderly-looking, grey slime with a poofy, white wig quakes slightly near the entrance to the bank. Is this like a slime grandma or something? " +
                    "\"Exgooze me young one. My name is Gooladys Wrinkledgoop. We are <blurpsnarfleplop> goollecting donations for the Orphan's Fund. <hisssssssssssnurfle>" +
                    " We would be goorateful if you'd <flurflecrack> ohh my aghing globs, sorry, if you'd donate today.\" She just stares intently at you, offering nothing " +
                    "in exchange for your slime coins. You wonder with a name like 'Wrinkledgoop' if she was born old.";
                break;
        }
    }
    public static void B_efficiency(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.jp:
                name = "スライムコイン変換効率";
                effectExplain = "ゴールドとスライムコインの変換効率を向上させます.";
                explain = "The slime at this counter says, \"Helloo, I am <murpslurp>Mr.Moslopoly\" as an oozing tendril emerges from his form and adjusts the monocle floating directly on his eyeball. \"I gan help you improove the effigiengy of goold to Slime Goin. Everygoo loves <draffleblug> earning moore of our esteemed gurrengy!\" You can't stop staring at its monocle, so you don't even listen to the rest of what it says.";
                break;
            case Language.chi:
                name = "银行效率";
                effectExplain = "增加金币自动兑换史莱姆币的兑换率.";
                explain = "让银行了解金币的益处而获得更多史莱姆币, 最大益处就是那闪闪发亮";
                break;
            default:
                name = "Bank Efficiency";
                effectExplain = "Increase the conversion efficiency between wasted Gold and Slime Coin.";
                explain = "The slime at this counter says, \"Helloo, I am <murpslurp>Mr.Moslopoly\" as an oozing tendril emerges from his form and adjusts the monocle floating directly on his eyeball. \"I gan help you improove the effigiengy of goold to Slime Goin. Everygoo loves <draffleblug> earning moore of our esteemed gurrengy!\" You can't stop staring at its monocle, so you don't even listen to the rest of what it says.";
                break;
        }
    }
    public static void B_explore(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.jp:
                name = "探検家の精神";
                effectExplain = "モンスター討伐時に得られるゴールドの上限（モンスターゴールドキャップ）を増加する.";
                explain = "A shady looking fox wearing a blue bandana and blue gloves is leaning up against the wall near the entrance to the bank. He perks up as soon as " +
                    "he realizes you've noticed him \"Oh man! You have the looks of an explorer and those are some impressive boots!Look, I don't mean to swipe too much of your" +
                    " time, but I can help you out. \"He gives a shifty look around the room before resuming, \"Your, uhh, backpack or whatever you use to hold all of your gold could" +
                    " be fixed up to hold more.\" He snickers suspiciously to himself. \"My, uhh, methods aren't exactly looked upon favorably here, but it's totally worth it or my" +
                    " name isn't...isn't... important actually. \"You are interested but you're sure that the Slime Bank doesn't exactly like this guy.";
                break;
            case Language.chi:
                name = "探险大师";
                effectExplain = "增加怪物金币掉落上限值, +100金币上限*技能等级";
                explain = "怪物的皮可以卖皮匠, 怪物的魔石可以卖铁匠, 怪物的血可以卖炼金术师. \n 丰富的探险经验让你更懂得利用怪物的尸体获得更多的金币.";
                break;
            default:
                name = "Explorer's Capacity";
                effectExplain = "Increase the Monsters Gold Cap + 100 for each level";
                explain = "A shady looking fox wearing a blue bandana and blue gloves is leaning up against the wall near the entrance to the bank. He perks up as soon as " +
                    "he realizes you've noticed him \"Oh man! You have the looks of an explorer and those are some impressive boots!Look, I don't mean to swipe too much of your" +
                    " time, but I can help you out. \"He gives a shifty look around the room before resuming, \"Your, uhh, backpack or whatever you use to hold all of your gold could" +
                    " be fixed up to hold more.\" He snickers suspiciously to himself. \"My, uhh, methods aren't exactly looked upon favorably here, but it's totally worth it or my" +
                    " name isn't...isn't... important actually. \"You are interested but you're sure that the Slime Bank doesn't exactly like this guy.";
                break;
        }
    }
    public static void B_graduate(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.jp:
                name = "スライム大学卒業生";
                effectExplain = "訓練1を強化して, リソース生成量を向上させる." +
                    " Further upgrades here enhance their efficiency.";
                explain = "You notice a dog looking creature manning an unmarked stall in the bank and feel curious enough to inspect further. " +
                    "\"Hai! am prof doggo-doesntchasesquirrelz.  R u lookin'2 expand u workforce with freshly trained, straight outa college, broke from student" +
                    " loanz, slime kids? i can set u up 2 b an internship opportunity 4 these kiddoz if u jus pay teh application fee. Talk 2 me latr about our " +
                    "expandd progrramz 2!\" You aren't strongly convinced that this thing would make a very good professor. Now it's licking itself, so better " +
                    "to hurry up and decide on its offer.";
                break;
            case Language.chi:
                name = "史莱姆大学毕业生";
                effectExplain = "增加雇用矿工, 研究员和农民的效率.";
                explain = "善用大学的知识, 和矿工, 研究员, 农民探讨各种先进技术 \n增加采矿, 合成和采集生产加成";
                break;
            default:
                name = "Slime College Graduate";
                effectExplain = "Enhance the Train I for Resources," +
                    " Further upgrades here enhance their efficiency.";
                explain = "You notice a dog looking creature manning an unmarked stall in the bank and feel curious enough to inspect further. " +
                    "\"Hai! am prof doggo-doesntchasesquirrelz.  R u lookin'2 expand u workforce with freshly trained, straight outa college, broke from student" +
                    " loanz, slime kids? i can set u up 2 b an internship opportunity 4 these kiddoz if u jus pay teh application fee. Talk 2 me latr about our " +
                    "expandd progrramz 2!\" You aren't strongly convinced that this thing would make a very good professor. Now it's licking itself, so better " +
                    "to hurry up and decide on its offer.";
                break;
        }
    }
    public static void B_healthy(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.jp:
                name = "ヘルシーキャプチャー";
                effectExplain = "モンスターの残りHPが100%の時でも, 2％の確率で捕獲可能になります.";
                explain = "A fine looking gentleman stands by a table with several different trap models you've never seen before. As you approach he greets you, \"Ahh yes, good day my fine friend! Allow me to introduce myself. J.Worthington Snaresmith at your service! I've come up with a rather ingenius technique, you see, for capturing monsters that are completely healthy. Normally, traps break when attempting this, but I have devised a brilliant solution, if I do say so myself.\" He rambles on about science and magicky stuff before concluding, \"So you see, if you would invest in my offer, you'll have a whole new way to capture monsters! Keep in mind, it only works when they are undamaged, otherwise you'll have to do it the regular way, I suppose. So have I garnered your support?\" His accent is familiar, and his eagerness a bit over the top, but his proposition does sound interesting.";
                break;
            case Language.chi:
                name = "捕捉大师";
                effectExplain = "增加对满血怪物的捕捉率, +2%*技能等级.";
                explain = "满血不代表状态无敌, 不一定把怪物打得虚弱才能捕捉. 或许熟悉怪物的弱点捕捉它们也不是问题";
                break;
            default:
                name = "Healthy Capturing";
                effectExplain = "This upgrade adds 2% success chance to capture any monster at full health.";
                explain = "A fine looking gentleman stands by a table with several different trap models you've never seen before. As you approach he greets you, \"Ahh yes, good day my fine friend! Allow me to introduce myself. J.Worthington Snaresmith at your service! I've come up with a rather ingenius technique, you see, for capturing monsters that are completely healthy. Normally, traps break when attempting this, but I have devised a brilliant solution, if I do say so myself.\" He rambles on about science and magicky stuff before concluding, \"So you see, if you would invest in my offer, you'll have a whole new way to capture monsters! Keep in mind, it only works when they are undamaged, otherwise you'll have to do it the regular way, I suppose. So have I garnered your support?\" His accent is familiar, and his eagerness a bit over the top, but his proposition does sound interesting.";
                break;
        }
    }
    public static void B_interest(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.jp:
                name = "銀行の利子";
                effectExplain = "60秒ごとに, 現在の預金に応じて一定の利子を得ることができます.";
                explain = "The largest counter in the bank, occupied by the largest slime in the building. This could be the bank manager, but before you can ponder further it speaks, \"Heeeeeeeeeeeeeeey man! Nice duds. <gurginflarf> So I\'m the bank manager...\'s offspawn. He like, sent me off to college <Plurpbarf> to like learn accounting and how to speak better. I think he\'s off challenging loser wanna-be heroes or something, so I\'ll totally help you out in his place, cool? So <blapfample> you want to, like, raise your interest rate at the Bank? That\'s rad, man. Good for you. <Hurfflepurff> So you down with doing that, man?\" He\'s the chillest slime you\'ve ever seen. Wait, did he say his dad challenges wanna-be heroes?!";
                break;
            case Language.chi:
                name = "银行利息";
                effectExplain = "增加史莱姆币每分钟的利息.";
                explain = "既然你是银行, 银行不给利息说得过去吗? 我把史莱姆币都存进去了, 我要更多的史莱姆币";
                break;
            default:
                name = "Bank Interest";
                effectExplain = "You can gain certain amount of interest\n  according to your deposit every 60 seconds.";
                explain = "The largest counter in the bank, occupied by the largest slime in the building. This could be the bank manager, but before you can ponder further it speaks, \"Heeeeeeeeeeeeeeey man! Nice duds. <gurginflarf> So I\'m the bank manager...\'s offspawn. He like, sent me off to college <Plurpbarf> to like learn accounting and how to speak better. I think he\'s off challenging loser wanna-be heroes or something, so I\'ll totally help you out in his place, cool? So <blapfample> you want to, like, raise your interest rate at the Bank? That\'s rad, man. Good for you. <Hurfflepurff> So you down with doing that, man?\" He\'s the chillest slime you\'ve ever seen. Wait, did he say his dad challenges wanna-be heroes?!";
                break;
        }
    }
    public static void B_counter(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.jp:
                name = "魔法のモンスターカウンター";
                effectExplain = "倒したモンスターを魔法のように集計する機械. 怪しげなスライムは, スライムコインと引き換えにその機械を利用することを提案します. これにより, モンスター討伐数を通常よりも多くカウントするようになります. ";
                explain = "“Psst, over here” you hear coming from behind a large, marbled column. Inspecting further, you discover a slime draped in what " +
                    "appears to be a trench coat and a black fedora on top. “Hey looks here, I’m gonna shoot it to ya straight, k? You kill monsters," +
                    " I seen ya do it. They gots this machine here that tracks it too. I hears you get something when that number go ups enough, so hows about it?" +
                    " Yous help me, I helps you. I’ll rig it if the price is right to give yous more credit, sound keen?” You can’t help but wonder where you’" +
                    "ve heard that voice before.";
                break;
            case Language.chi:
                name = "开挂的计数器";
                effectExplain = "增加怪物的击杀数, +1击杀*技能等级 ";
                explain = "不是吧? 击杀怪物都能开挂? 官方你不管管? 增加怪物击杀数";
                break;
            default:
                name = "Broken Monster Counter";
                effectExplain = "A relic of a machine that magically tallies the monsters you’ve killed. A Shady Slime offers to rig it in your favor in exchange " +
                    "for Slime Coins so that it counts twice when you’ve killed a monster instead of once. He may be able to rig it further for more Slime Coins. ";
                explain = "“Psst, over here” you hear coming from behind a large, marbled column. Inspecting further, you discover a slime draped in what " +
                    "appears to be a trench coat and a black fedora on top. “Hey looks here, I’m gonna shoot it to ya straight, k? You kill monsters," +
                    " I seen ya do it. They gots this machine here that tracks it too. I hears you get something when that number go ups enough, so hows about it?" +
                    " Yous help me, I helps you. I’ll rig it if the price is right to give yous more credit, sound keen?” You can’t help but wonder where you’" +
                    "ve heard that voice before.";
                break;
        }
    }
    public static void B_tech(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.jp:
                name = "筋力向上トレーニング";
                effectExplain = "基礎ATKを恒久的に改善するための特別トレーニングセミナー.";
                explain = "A large, burly looking man is off standing with one of his feet occupying a slime teller's stall. He doesn't stop flexing his abnormally enormous muscles," +
                    " even after you approach him. He says, \"Ahh, it is such good fortune for you to be standing here with me, yes!? You like be brawny, like me? Of course you do! " +
                    "Who not want that? Okay, you convinced me. I train you, but I need slime coin. Fair exchange, this is way world works, no?\" You better decide soon because he'" +
                    "s now flexing his pecs while staring at you intensely and it's getting very awkward.";
                break;
            case Language.chi:
                name = "力量训练";
                effectExplain = "增加物理攻击";
                explain = "举重, 俯卧撑, 拼命训练的我越来越强了";
                break;
            default:
                name = "Strength Technique Training";
                effectExplain = "Special training seminars to permanently improve base ATK";
                explain = "A large, burly looking man is off standing with one of his feet occupying a slime teller's stall. He doesn't stop flexing his abnormally enormous muscles," +
                    " even after you approach him. He says, \"Ahh, it is such good fortune for you to be standing here with me, yes!? You like be brawny, like me? Of course you do! " +
                    "Who not want that? Okay, you convinced me. I train you, but I need slime coin. Fair exchange, this is way world works, no?\" You better decide soon because he'" +
                    "s now flexing his pecs while staring at you intensely and it's getting very awkward.";
                break;
        }

    }
    public static void B_mtech(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.jp:
                name = "メンタル向上トレーニング";
                effectExplain = "基礎MATKを恒久的に改善するための特別トレーニングセミナー.";
                explain = "A beautiful sorceress is chatting with some other bank patrons as you approach. She looks you up and down and says " +
                    "“Ahh, yes, I could work with this. You appear to have at least some semblance of intelligence. Would you care to join my seminar " +
                    "and learn my secrets of the trade?” You’re quite entranced by her rare and foreign beauty when suddenly she’s an old, decrepit man. " +
                    "“See!” he says “I have much I can teach you. My name is The Great Wizard, but you can call me Ryun for short. So do you want to learn " +
                    "the secrets to powerful magic?” You’re really not sure how Ryun could be short for “The Great Wizard.”";
                break;
            case Language.chi:
                name = "思维训练";
                effectExplain = "增加魔法攻击";
                explain = "知识, 书本, 图书馆, 我要更多知识, 我要变得聪明更有智慧";
                break;
            default:
                name = "Mind Technique Training";
                effectExplain = "Special training seminars to permanently improve base MATK";
                explain = "A beautiful sorceress is chatting with some other bank patrons as you approach. She looks you up and down and says " +
                    "“Ahh, yes, I could work with this. You appear to have at least some semblance of intelligence. Would you care to join my seminar " +
                    "and learn my secrets of the trade?” You’re quite entranced by her rare and foreign beauty when suddenly she’s an old, decrepit man. " +
                    "“See!” he says “I have much I can teach you. My name is The Great Wizard, but you can call me Ryun for short. So do you want to learn " +
                    "the secrets to powerful magic?” You’re really not sure how Ryun could be short for “The Great Wizard.”";
                break;
        }

    }
    public static void B_nitro(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.jp:
                name = "ニトロエナジー...?";
                effectExplain = "自動販売機でニトロエナジーを手に入れましょう. このアップグレードにより, オンライン中にもニトロを獲得できるようになります.";
                explain = "An oddly shaped vending machine hums gently next to a water dispensing machine." +
                    " This Bank is a very strange place. As you walk up to the Vending Machine, you can make out the words " +
                    "\"Nuka Col..\" but a sign has been slapped on top, cutting off the last letter of it, that reads " +
                    "\"Nitro - put some speed in your step!\" and in smaller print it says \"Also, no copyright infringement committed in the Slime Bank!" +
                    " - signed Management\" How very confusing, but you evidently need to insert a large sum of Slime Coins to get a bottle. " +
                    "You aren't sure whether or not you are supposed to drink this or what you do with it. The bottlecap looks valuable, though..";
                break;
            case Language.chi:
                name = "化学大师";
                effectExplain = "增加每小时自动产生硝基,  +2*技能等级";
                explain = ". 硝酸混合硫酸就可获得硝基? 应该是这样吧, 反正熟能生巧, 错了就改进 \n增加在线硝基产量";
                break;
            default:
                name = "Nitro Col...?";
                effectExplain = "Pay a vending machine to get a bottle of Nitro Col..? This upgrade unlocks the ability to gain Nitro while online, and each upgrade " +
                    "improves the rate at which the player gains online Nitro.";
                explain = "An oddly shaped vending machine hums gently next to a water dispensing machine." +
                    " This Bank is a very strange place. As you walk up to the Vending Machine, you can make out the words " +
                    "\"Nuka Col..\" but a sign has been slapped on top, cutting off the last letter of it, that reads " +
                    "\"Nitro - put some speed in your step!\" and in smaller print it says \"Also, no copyright infringement committed in the Slime Bank!" +
                    " - signed Management\" How very confusing, but you evidently need to insert a large sum of Slime Coins to get a bottle. " +
                    "You aren't sure whether or not you are supposed to drink this or what you do with it. The bottlecap looks valuable, though..";
                break;
        }
    }
    public static void B_powder(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.jp:
                name = "隠されたパウダーショップ";
                effectExplain = "レベルアップごとにニトロのキャップを250増やします.";
                explain = "Nearby the Nitro Cola machine, you see an old tortoise wearing what seems to be a military uniform nearly covered in medals. As he notices you, " +
                    "he sets his foot on a small crate labeled DANGER - EXPLOSIVE and slowly speaks" +
                    " to you, \"Why hello there.... Are you looking.... to speed things.... up in your life?.... I have just.... the answer.... Why in my day.... " +
                    "I used this substance....to beat a hasty hare.... who thought they were.... the fastest in the world.... but I won, I did.... now you can too.... " +
                    "are you interested?....\" It took him ten minutes to tell you that, but you're still intrigued by the offer.";
                break;
            case Language.chi:
                name = "化学仓库";
                effectExplain = "增加硝基加速器的容量上限, +250*技能等级";
                explain = "扩充硝基加速的容器, 让其可储存更多的硝基";
            break;
            default:
                name = "Hidden Powder Store";
                effectExplain = "Increase the Cap of Nitro + 250 for each level";
                explain = "Nearby the Nitro Cola machine, you see an old tortoise wearing what seems to be a military uniform nearly covered in medals. As he notices you, " +
                    "he sets his foot on a small crate labeled DANGER - EXPLOSIVE and slowly speaks" +
                    " to you, \"Why hello there.... Are you looking.... to speed things.... up in your life?.... I have just.... the answer.... Why in my day.... " +
                    "I used this substance....to beat a hasty hare.... who thought they were.... the fastest in the world.... but I won, I did.... now you can too.... " +
                    "are you interested?....\" It took him ten minutes to tell you that, but you're still intrigued by the offer.";
                break;
        }
    }
    public static void B_rate(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.jp:
                name = "ゴールド変換レート";
                effectExplain = "スライムコインからゴールドへの変換レートを向上させます.";
                explain = "A rare she-slime sits behind this counter. \"Ahh, I'm Pagilda Puddlesmear. I like your, uhh, face. How can I helps ya today? Oh don\'t even tell me ya don\'t want our coins no more?\" she annunciates clearly, albeit strangely, and much to your surprise without belching once. \"Oh come on, don\'t look so shocked, ya hear me? Yah, we don\'t keep much actual gold, it gets melted ya know? But if ya is willing to pay our fee, we\'ll start setting more to the side for you so ya get more back, sound keen?\" She\'s like the slime mom you never knew you didn\'t want, but still want to call on holidays.";
                break;
            case Language.chi:
                name = "银行汇率";
                effectExplain = "增加史莱姆币兑换金币的汇率.";
                explain = "穷啊！银行能不能低价收购我手上的史莱姆币啊, 我没金币了";
                break;
            default:
                name = "Bank Exchange Rate";
                effectExplain = "Increase the exchange rate from Slime Coin to Gold.";
                explain = "A rare she-slime sits behind this counter. \"Ahh, I'm Pagilda Puddlesmear. I like your, uhh, face. How can I helps ya today? Oh don\'t even tell me ya don\'t want our coins no more?\" she annunciates clearly, albeit strangely, and much to your surprise without belching once. \"Oh come on, don\'t look so shocked, ya hear me? Yah, we don\'t keep much actual gold, it gets melted ya know? But if ya is willing to pay our fee, we\'ll start setting more to the side for you so ya get more back, sound keen?\" She\'s like the slime mom you never knew you didn\'t want, but still want to call on holidays.";
                break;
        }
    }
    public static void B_potion(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.jp:
                name = "精製マスター";
                effectExplain = "錬金術(Alchemy)での容器のキャップを上昇させるたびに、水精製速度が向上するようになる。";
                explain = "Be a mad scientist!";
                break;
            case Language.chi:
                name = "净化大师";
                effectExplain = "增加净化神秘水的速度， +1%*技能等级.";
                explain = "净化神秘水的速度增加了, 炼金就没那么麻烦了.";
                break;
            default:
                name = "Purification Master";
                effectExplain = "The production speed of purifying Mysterious Water increases each and every time you expand its cap.";
                explain = "Be a mad scientist!";
                break;
        }
    }

}
