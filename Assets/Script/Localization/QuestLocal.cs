using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static BASE;
using static UsefulMethod;

public class QuestLocal : MonoBehaviour
{
    public static void unlock(TextMeshProUGUI text)
    {
        LocalizeInitialize.SetFont(text);
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                text.text = "Unlock condition";
                return;
            case Language.jp:
                text.text = "クエスト達成条件";
                return;
            case Language.chi:
                text.text = "任务成就条件";
                return;
            default:
                text.text = "Unlock condition";
                return;
        }
    }
    public static void progress(TextMeshProUGUI text)
    {
        LocalizeInitialize.SetFont(text);
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                text.text = "Current Progress";
                return;
            case Language.jp:
                text.text = "現在の進行状況";
                return;
            case Language.chi:
                text.text = "目前的进展";
                return;
            default:
                text.text = "Current Progress";
                return;
        }
    }
    public static void reward(TextMeshProUGUI text)
    {
        LocalizeInitialize.SetFont(text);
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                text.text = "Reward";
                return;
            case Language.jp:
                text.text = "報酬";
                return;
            case Language.chi:
                text.text = "奖励";
                return;
            default:
                text.text = "Reward";
                return;
        }
    }
    public static void client(TextMeshProUGUI text)
    {
        LocalizeInitialize.SetFont(text);
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                text.text = "Client";
                return;
            case Language.jp:
                text.text = "依頼人";
                return;
            case Language.chi:
                text.text = "客户";
                return;
            default:
                text.text = "Client";
                return;
        }
    }

    public static void tutorial(ref string client, string[] discription, string[] QuestNames, string[] rewardText, string[] UnlockCondition)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                client = "Stranger";
                discription[0] = "Welcome to Incremental Epic Hero! Since this is your first quest, let's start easy. Why not get out there a defeat around 300 normal slimes.";
                discription[1] = "Excellent work! Now while you were slaying those slimes you may have collected some Monster Fluid. I need five for something I am preparing for you. If you have already used what you previously collected, it shouldn't take long for you to collect more. It can be acquired from almost all common monsters. If you need further help knowing what monsters you can collect it from, consult your Bestiary!";
                discription[2] = "Terrific job! I've heard that Area 1-3 is overrun with slimes. You may have already cleared it by this point, but if not would you mind? Keeping the monster population low helps you as well! The more you slay, the more likely you will be able to acquire something from that specific type of monster! It also helps when you stay in an Area, as the more times you clear it, the more familiar the surroundings become, resulting in improved performance and more loot!";
                discription[3] = "You're doing a great job! Now I want to let you know that area 2-1 is now available for you to explore. The bats in that area have gotten out of hand, so before we conclude this training quest line, I'd ask that you clear Area 2-1 at least once. I will reward you with a very powerful second skill slot, which will make it much easier for you to progress! Good luck!";
                QuestNames[0] = "Tutorial Quest 1";
                QuestNames[1] = "Tutorial Quest 2";
                QuestNames[2] = "Tutorial Quest 3";
                QuestNames[3] = "Tutorial Quest 4";
                rewardText[0] = "- 1000 Gold";
                rewardText[1] = "- Gold Cap + 100";
                rewardText[2] = "- 50 Monster Fluids";
                rewardText[3] = "- Extra Skill Slot";
                UnlockCondition[0] = "Defeat 300 Normal Slimes";
                UnlockCondition[1] = "Bring 5 Monster Fluid";
                UnlockCondition[2] = "Clear Area 1-3";
                UnlockCondition[3] = "Clear Area 2-1";
                break;
            case Language.jp:
                client = "見知らぬ男";
                discription[0] = "インクリメンタルエピックヒーローの世界にようこそ！ これが君の初めてのクエストだから、簡単なところから始めよう. まずは、300体のスライムを倒しに出かけるのはどうだ？";
                discription[1] = "よくやった！さて、君がスライムを倒している間にいくつかモンスターの退役を手に入れたはずだ. これを5つ集めてきたらあるものをあげよう. もし、モンスターの体液を別のことに使ってしまっていたとしても、すぐにまた集められるだろう. これはほとんどどんなモンスターからも手に入れられるからね. もしモンスターが何を落とすのか知りたくなったら、ExploreタブからBestiaryを覗いてみよう！";
                discription[2] = "素晴らしい！ところで、スライム平原でスライムがはびこっているのを聞いたんだ. もしまだそのステージをクリアしていなければ、行ってきてくれないか？君にとってもいい話なはずだ. モンスターを狩れば狩るほど、そこから何かを得ることができるからね. また、同じステージを何度もクリアするのもいいことだ. その地を知れば知るほどより早くクリアできるようになり、そしてより報酬もよくなるだろう. ";
                discription[3] = "君はなんて仕事が早いんだ！さぁ、君は今暗黒の森を探検できるようになった. 森のこうもりたちは手を付けられない. このクエストの締めとして、暗黒の森をクリアしてきてくれ. クリアしたら報酬として、とても強力な2つ目のスキルスロットをあげよう. それで一気に攻略が楽になるはずだ！";
                QuestNames[0] = "チュートリアルクエスト1";
                QuestNames[1] = "チュートリアルクエスト2";
                QuestNames[2] = "チュートリアルクエスト3";
                QuestNames[3] = "チュートリアルクエスト4";
                rewardText[0] = "- 1000 ゴールド";
                rewardText[1] = "- +100 ゴールドキャップ";
                rewardText[2] = "- 50 モンスターの体液";
                rewardText[3] = "- 追加のスキルスロット";
                UnlockCondition[0] = "ノーマルスライムを300体倒そう";
                UnlockCondition[1] = "モンスターの体液を5つ集めよう";
                UnlockCondition[2] = "スライム平原をクリアしよう";
                UnlockCondition[3] = "暗黒の森をクリアしよう";
                break;
            case Language.chi:
                client = "陌生人";
                discription[0] = "陌陌欢迎来到 Incremental Epic Hero! 因为这是你的第一个任务, 让我们从简单的开始. 为什么不出去打败300个普通史莱姆呢？";
                discription[1] = "干得好！当你杀死那些史莱姆的时候... 你可能收集到了一些怪物液 我需要五瓶来给你准备一些东西. 如果你已经用完了你之前收集的东西, 你应该不需要花很长时间去收集更多的东西. 它可以从几乎所有常见的怪物身上获得. 如果你需要进一步的帮助, 知道你可以从哪些怪物身上收集到它, 请查阅你的兽皮书!";
                discription[2] = "干得好！我听说1 -3区有很多粘液. 你可能已经清理过了, 但如果没有, 你介意吗？保持怪物数量少对你也有帮助! 你击杀的怪物越多, 你就越有可能从那种特定类型的怪物身上获得一些东西! 当你停留在一个区域时, 这也是有帮助的, 因为你清理的次数越多, 对周围的环境就越熟悉, 从而提高业绩, 获得更多的战利品!";
                discription[3] = "你做得很好！现在我想告诉你们, 2-1区域现在可以供你们探索了. 那个区域的蝙蝠已经失控了, 所以在我们结束这个训练任务线之前, 我想请你至少清理一次2-1区域. 我将奖励你一个非常强大的第二个技能槽, 这将使你更容易进步! 祝大家好运!";
                QuestNames[0] = "教程任务 1";
                QuestNames[1] = "教程任务 2";
                QuestNames[2] = "教程任务 3";
                QuestNames[3] = "教程任务 4";
                rewardText[0] = "- 1000 Gold";
                rewardText[1] = "- Gold Cap + 100";
                rewardText[2] = "- 50 Monster Fluids";
                rewardText[3] = "- Extra Skill Slot";
                UnlockCondition[0] = "打败 300 Normal Slimes";
                UnlockCondition[1] = "带上 5 Monster Fluid";
                UnlockCondition[2] = "完成 Area 1-3";
                UnlockCondition[3] = "完成 Area 2-1";
                break;
            default:
                client = "Stranger";
                discription[0] = "Welcome to Incremental Epic Hero! Since this is your first quest, let's start easy. Why not get out there a defeat around 300 normal slimes.";
                discription[1] = "Excellent work! Now while you were slaying those slimes you may have collected some Monster Fluid. I need five for something I am preparing for you. If you have already used what you previously collected, it shouldn't take long for you to collect more. It can be acquired from almost all common monsters. If you need further help knowing what monsters you can collect it from, consult your Bestiary!";
                discription[2] = "Terrific job! I've heard that Area 1-3 is overrun with slimes. You may have already cleared it by this point, but if not would you mind? Keeping the monster population low helps you as well! The more you slay, the more likely you will be able to acquire something from that specific type of monster! It also helps when you stay in an Area, as the more times you clear it, the more familiar the surroundings become, resulting in improved performance and more loot!";
                discription[3] = "You're doing a great job! Now I want to let you know that area 2-1 is now available for you to explore. The bats in that area have gotten out of hand, so before we conclude this training quest line, I'd ask that you clear Area 2-1 at least once. I will reward you with a very powerful second skill slot, which will make it much easier for you to progress! Good luck!";
                QuestNames[0] = "Tutorial Quest 1";
                QuestNames[1] = "Tutorial Quest 2";
                QuestNames[2] = "Tutorial Quest 3";
                QuestNames[3] = "Tutorial Quest 4";
                rewardText[0] = "- 1000 Gold";
                rewardText[1] = "- Gold Cap + 100";
                rewardText[2] = "- 50 Monster Fluids";
                rewardText[3] = "- Extra Skill Slot";
                UnlockCondition[0] = "Defeat 300 Normal Slimes";
                UnlockCondition[1] = "Bring 5 Monster Fluid";
                UnlockCondition[2] = "Clear Area 1-3";
                UnlockCondition[3] = "Clear Area 2-1";
                break;
        }
    }
    public static void treasure(ref string client, string[] discription, string[] QuestNames, string[] rewardText, string[] UnlockCondition)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                client = "The pathetic old man";
                discription[0] = "Oh dear, could you please help me? A bird took off with my wallet and flew into the forest! My wife is expecting me to bring her a gift for her birthday! Please help me! I cannot go in there!";
                discription[1] = "Oh gracious gods, you found my wallet! Thank you so much! But wait, my money is all gone! Oh dear me, what will I do?!" +
                    " I can't go home empty-handed... I know I've already asked a lot of you already, but could you lend me some money? I promise I'll repay the favor somehow!";
                discription[2] = "Oh thank you again so very much! I've already got the gift in mind. A necklace by famed jeweller, Poppy Winston. She is going to love it!"
                    + " Oh thank the merciful gods that you are still here. I had just purchased the necklace that I told you about when I was attacked by a slime!"
                    + " In my shock, I threw the necklace at the slime and ran! I'm sure that it's floating in that slime still if you could go and find it for me? I'd surely die if I tried.";
                discription[3] = "Oh you found it! You're my hero! Wait, it's corroded from acidic sludge. Hmm, I may be able to fix and polish it back up though!"
                    + " I used to be a trainer, before I took an arrow to the knee. If you help me gather the supplies I need, I'll teach you a technique for expanding your equipment slot.";
                QuestNames[0] = "Pathetic man 1";
                QuestNames[1] = "Pathetic man 2";
                QuestNames[2] = "Pathetic man 3";
                QuestNames[3] = "Pathetic man 4";
                rewardText[0] = "- Gold Cap + 300";
                rewardText[1] = "- Nothing :x";
                rewardText[2] = "- 1000 Gold";
                rewardText[3] = "- Extra Equipment Slot!";
                UnlockCondition[0] = "Find a man's wallet!";
                UnlockCondition[1] = "Give him 1000 Gold!";
                UnlockCondition[2] = "Find Poppy Winston Necklace!";
                UnlockCondition[3] = "Give the resources to repair the necklace!";
                break;
            case Language.jp:
                client = "哀れな老人";
                discription[0] = "これ、ちょっと助けてくれんか？鳥がワシの財布を奪って森に落としてしまったんじゃ！今日は妻の誕生日で、プレゼントを待っておるのじゃ...頼む！私を助けてくれ！";
                discription[1] = "ああよかった、見つけてくれてありがとう. しかし待て、ワシの金が全部なくなっとるじゃないか！どうすればいいんじゃ...手ぶらでは帰れぬし.... おおそうだ、頼み事を聞いてくれたのに申し訳ないが、いくらかお金を貸してくれんか？もちろん金はあとで必ず返す！";
                discription[2] = "本当に助かるよ、何度もありがとう. 実は妻のプレゼントに何を買うかもう決めとるんじゃ. 高級ブランドのポピーウィンストンのネックレスじゃ！きっと気に入るはずじゃ. それじゃあ買ってくるよ、本当にありがとうよ. (...数分後) おお、よかったまだそこにおったか. 実はさっき言ってたネックレスを買ってすぐに" +
                    "スライムに襲われてしまっての...ネックレスをスライムに投げつけて逃げてきたんじゃ. まだ奴が持っているはずじゃから取り返してきてくれんか？";
                discription[3] = "なに、見つけてきてくれたのか！君は本当に私の恩人だよ. まて、よく見たらスライムの酸で錆びてしまっているな...まぁ磨けば大丈夫じゃろう！すまんが、これを磨くための材料を持ってきてくれんか？そしたらワシが秘伝のスキルスロット拡張を伝授しよう. ";
                QuestNames[0] = "哀れな男1";
                QuestNames[1] = "哀れな男2";
                QuestNames[2] = "哀れな男3";
                QuestNames[3] = "哀れな男4";
                rewardText[0] = "- +300 ゴールドキャップ";
                rewardText[1] = "- 何も得られない";
                rewardText[2] = "- 1000 ゴールド";
                rewardText[3] = "- 追加のスキルスロット";
                UnlockCondition[0] = "老人の財布を探そう！";
                UnlockCondition[1] = "老人に1000ゴールド貸そう. ";
                UnlockCondition[2] = "ポピーウィンストンのネックレスを探そう. ";
                UnlockCondition[3] = "ストーン10M個と、クリスタル10M個を用意しよう. ";
                break;
            case Language.chi:
                client = "那个可怜的老人";
                discription[0] = "哦, 亲爱的, 你能帮帮我吗？一只鸟带着我的钱包飞进了森林! 我的妻子正期待着我给她带来一份生日礼物! 请帮帮我吧！我不能进去！";
                discription[1] = "哦, 天哪, 你找到了我的钱包! 太感谢你了！但是, 等等, 我的钱都不见了！哦, 亲爱的, 我该怎么办？" +
                    " 我不能空手而归... ... 我知道我已经问过你们很多人了 但你们能不能借我点钱？我保证一定会报答你们的！";
                discription[2] = "哦, 再次非常感谢你！我已经想好了礼物. 著名珠宝商Poppy Winston的项链. 她一定会喜欢的！"
                    + " 哦, 感谢仁慈的上帝, 你还在这里. 我刚刚买了我跟你说的项链, 就被一只粘液袭击了!"
                    + " 惊魂未定之下, 我把项链扔到泥浆里就跑了! 我敢肯定, 它还在那泥浆里漂着, 如果你能去帮我找到它？我要是去找的话, 肯定会死的. ";
                discription[3] = "哦, 你找到了！你是我的英雄！等等, 它被酸性污泥腐蚀了. 嗯, 我也许可以把它修好, 然后再抛光！"
                    + " 我以前是个教练, 在我膝盖中箭之前. 如果你帮我收集我需要的物资, 我就教你一个扩大装备槽的技巧. ";
                QuestNames[0] = "Pathetic man 1";
                QuestNames[1] = "Pathetic man 2";
                QuestNames[2] = "Pathetic man 3";
                QuestNames[3] = "Pathetic man 4";
                rewardText[0] = "- Gold Cap + 300";
                rewardText[1] = "- Nothing :x";
                rewardText[2] = "- 1000 Gold";
                rewardText[3] = "- Extra Equipment Slot!";
                UnlockCondition[0] = "找到一个男人的钱包！";
                UnlockCondition[1] = "给他1000金！";
                UnlockCondition[2] = "寻找Poppy Winston项链!";
                UnlockCondition[3] = "给资源修项链!";
                break;
            default:
                client = "The pathetic old man";
                discription[0] = "Oh dear, could you please help me? A bird took off with my wallet and flew into the forest! My wife is expecting me to bring her a gift for her birthday! Please help me! I cannot go in there!";
                discription[1] = "Oh gracious gods, you found my wallet! Thank you so much! But wait, my money is all gone! Oh dear me, what will I do?!" +
                    " I can't go home empty-handed... I know I've already asked a lot of you already, but could you lend me some money? I promise I'll repay the favor somehow!";
                discription[2] = "Oh thank you again so very much! I've already got the gift in mind. A necklace by famed jeweller, Poppy Winston. She is going to love it!"
                    + " Oh thank the merciful gods that you are still here. I had just purchased the necklace that I told you about when I was attacked by a slime!"
                    + " In my shock, I threw the necklace at the slime and ran! I'm sure that it's floating in that slime still if you could go and find it for me? I'd surely die if I tried.";
                discription[3] = "Oh you found it! You're my hero! Wait, it's corroded from acidic sludge. Hmm, I may be able to fix and polish it back up though!"
                    + " I used to be a trainer, before I took an arrow to the knee. If you help me gather the supplies I need, I'll teach you a technique for expanding your equipment slot.";
                QuestNames[0] = "Pathetic man 1";
                QuestNames[1] = "Pathetic man 2";
                QuestNames[2] = "Pathetic man 3";
                QuestNames[3] = "Pathetic man 4";
                rewardText[0] = "- Gold Cap + 300";
                rewardText[1] = "- Nothing :x";
                rewardText[2] = "- 1000 Gold";
                rewardText[3] = "- Extra Equipment Slot!";
                UnlockCondition[0] = "Find a man's wallet!";
                UnlockCondition[1] = "Give him 1000 Gold!";
                UnlockCondition[2] = "Find Poppy Winston Necklace!";
                UnlockCondition[3] = "Give the resources to repair the necklace!";
                break;
        }
    }
    public static void slimelover(ref string CliantName, string[] discription, string[] QuestNames, string[] rewardText, string[] UnlockCondition, ACHIEVEMENT quest = null)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                CliantName = "Slime otaku";//"Slime Hat man";
                discription[0] = "Hey! You look like you've been out there killing slimes! I collect their parts!  My momma told me that I needed to collect something, so this is what I picked. My only problem is that I'm not actually strong enough to fight them. They'll gobble me up and spit out my bones. So will you help me gather 1000 ooze stained cloth?! I'm going to make some slime clothes for myself, so maybe they'll let me hang out with them without eating me.";
                discription[1] = "It kind of worked! I was able to blend in with the normal slimes no problem! I had to steer clear of the others, though, because they seemed to know something was off. What do you mean slimes don't think?! Look they picked up on vibes or something, so I'm going to need more help from you, if you're willing. This time I need 5 Gooey Sludge and 2000 Ooze Stained Cloth. I don't care where you get them, but this will surely help me go undetected by the other slimes!";
                discription[2] = "Oh man, you won't believe it but my upgraded disguise works on all of the slimes except the really big ones that wear those cool sunglasses. It's like with those glasses on they just see right through my disguise! I had to run away to keep from getting digested by that guy, or thing, you know what I mean. This time I've raided my mom's cabinet and I'm ready to give you a good reward if you'll get me some Acidic Goo and a Slime Eye Ball. Yeah, if he looks me in that slimy eye, he'll for sure fall for my getup and accept me as a slime!";
                discription[3] = "Haha I am like one of them now. They don't even know I'm not a slime like them. I just make gurgling sounds and shuffle around and it's like I'm one of the family. I'm a little sad you keep killing so many of them, but if you hadn't, then I wouldn't be able to fulfill of dreams of living like a slime! I just have one problem, though. So I kind of lost something important to me and it was gobbled up by a red slime. It's probably completely dissolved by now, but if there's one kind of slime I don't like, then it's the red ones. I think I'd feel a lot better if you killed 3000 of them for me. Then they wouldn't be around as much and I'd get to enjoy hanging out with the rest of the slimes in peace.";
                discription[4] = "You really did it! I gurgled to the other slimes that a slayer was coming for the red slimes and now they think I'm some sort of prophet slime! Oh yeah, I'm starting to understand their language a little bit. It's pretty simple once you spend enough time living with them. My mom quit letting me come in the house because of all of the slimy goop I track in, so I've also been sleeping out there too. It's fine though, I feel more at home with the slimes than I do at home. My skin is even kind of turning tranluscent! I wonder if that's from the acidic goo from my disguise. Oh well, I have one last favor to ask of you. I need 3 Slime Core because I've heard of a potion that will make it so that I don't have to blend in... I'll actually become a slime! I've got everything else but that, so will you please get it for me? Oh and once I'm a slime, please don't kill me.";

                QuestNames[0] = "Slime lover 1";
                QuestNames[1] = "Slime lover 2";
                QuestNames[2] = "Slime lover 3";
                QuestNames[3] = "Slime lover 4";
                QuestNames[4] = "Slime lover 5";
                rewardText[0] = "- 1000 Gold\n- Gold Cap + 200";
                rewardText[1] = "- 500 Monster Fluid\n- 5 Carved Idol";
                rewardText[2] = "- 5 Nature Shards\n- Gold Cap + 1000";
                rewardText[3] = "- Equipment Slot " + quest.LetterImage() + " 30";
                rewardText[4] = "- 5000 Monster Fluid " + quest.LetterImage() + " 100";
                UnlockCondition[0] = "1000 Ooze Stained Cloth";
                UnlockCondition[1] = "5 Gooey Sludge\n- 2000 Ooze Stained Cloth";
                UnlockCondition[2] = "1 Acidic Goop\n- 1 Slime Eye Ball";
                UnlockCondition[3] = "Kill 3000 Red Slimes";
                UnlockCondition[4] = "3 Slime Core";
                break;
            case Language.jp:
                CliantName = "スライムオタク";
                discription[0] = "よう！景気よくスライムを狩り回っているみたいだな. 俺はやつらの素材を集めるのが趣味なんだ！ところで、ママからおつかいを頼まれてるんだが、俺じゃやつらに勝てないんだ. 代わりに<color=green>薄汚れた布</color=green>を1000個集めてきてくれないか？それでスライムの皮を作って、変装してから行くことにするよ. そうしたら奴ら俺を食べないだろ";
                discription[1] = "うまくいったぜ！スライムの中に紛れ込むことができたよ. けど、上手く動き回ることができなかったんだ、やつらなんかおかしいなって顔してたよ. え？スライムがそんなこと考えてるわけないってどういう意味だよ！...ともかく、もう少し君の力が必要だ. " +
                    "5個の<color=green>" + main.ArtiCtrl.ConvertEnum(ArtiCtrl.MaterialList.GooeySludge) + "</color=green>と、2000個の" + main.ArtiCtrl.ConvertEnum(ArtiCtrl.MaterialList.OozeStainedCloth) + "</color=green>を唯してくれ. どこで手に入れてきてもいい. きっとこれで他のスライムにバレないはずだ！";
                discription[2] = "聞いてくれ！信じないだろうけど、サングラスをかけたどでかいスライムを除けば他のスライムには全く気付かれなかったぜ！でかいやつは、サングラスを通して俺の正体を見破ってたみたいだ...消化されたくないから逃げてきたけどよ. 今度は報酬にママの戸棚からいいものを持ってきたから、" +
                    "<color=green>" + main.ArtiCtrl.ConvertEnum(ArtiCtrl.MaterialList.AcidicGoop) + "</color=green>と<color=green>" + main.ArtiCtrl.ConvertEnum(ArtiCtrl.MaterialList.SlimeEyeBall) + "</color=green>をいくつか持ってきてくれないか. そういうことさ、目玉がスライムのものならやつだって俺をスライムだって受け入れるしかないさ. ";
                discription[3] = "ははは、これで俺もスライムの一員だ. 俺が実は人間ってことをやつら分かってないだろう. 君がスライムをたくさんやっつけたことはちょっと悲しいが、けどそのおかげでスライムのように生きるという夢がかなったよ！ところで問題が一つあるんだ. 途中でちょっと大切なものを落としてしまって、レッドスライムに奪われてしまったんだ. 多分、完全には溶けていないと思うんだけど...もし嫌いなスライムがいるとしたらそれは赤いやつさ. " +
                    "もしレッドスライムを3000体ほど倒してきてくれたらきっといい気分になるだろう. 多分赤いやつらは周りにはいなくなって、俺は平和に他のスライムたちとエンジョイできるだろうぜ";
                discription[4] = "よくやった！実は他のスライムたちに、もうすぐレッドスライムを倒しに来てくれる人が現れるよって言っておいたんだ. 彼らは俺のことを予言スライムだと思ってるよ. おっとそうだ、実は彼らと暮らしていくなかでスライム語をちょっと覚えたんだ. 少し彼らと時間を過ごせばとても単純な言語だって分かるよ. " +
                    "体中スライムの粘液でべとべとだからママは家に入れてくれないんだ、だから寝るときも彼らと一緒だよ. それでもいいんだけどね. 彼らといるほうが家にいる時より落ち着くんだ. なんだか肌も半透明になってきたよ！おっと、君に最後の頼みがあるんだ" +
                    ". <color=green>" + main.ArtiCtrl.ConvertEnum(ArtiCtrl.MaterialList.SlimeCore) + "</color=green>を3つ持ってきてくれないか. なんでも、それで本当にスライムになれる薬が作れるらしいんだ...頼むよ. おっと、もし俺がスライムになっても絶対殺さないでくれよ！";
                QuestNames[0] = "スライムを愛する男1";
                QuestNames[1] = "スライムを愛する男2";
                QuestNames[2] = "スライムを愛する男3";
                QuestNames[3] = "スライムを愛する男4";
                rewardText[0] = "- 1000ゴールド\n- +200ゴールドキャップ";
                rewardText[1] = "- 500　モンスターの体液\n- 5 "　+ main.ArtiCtrl.ConvertEnum(ArtiCtrl.MaterialList.CarvedIdol);
                rewardText[2] = "- 5 自然のかけら\n- +1000ゴールドキャップ";
                rewardText[3] = "- 追加のスキルスロット\n - 30エピックコイン";
                rewardText[4] = "- 5000 モンスターの体液\n - 100エピックコイン";
                UnlockCondition[0] = "1000個の薄汚れた布を用意しよう. ";
                UnlockCondition[1] = "5つの"　+main.ArtiCtrl.ConvertEnum(ArtiCtrl.MaterialList.GooeySludge) + "と\n2000個の"+ main.ArtiCtrl.ConvertEnum(ArtiCtrl.MaterialList.OozeStainedCloth) + "を集めよう";
                UnlockCondition[2] = "1つの" + main.ArtiCtrl.ConvertEnum(ArtiCtrl.MaterialList.AcidicGoop) + "と\n1つの" + main.ArtiCtrl.ConvertEnum(ArtiCtrl.MaterialList.SlimeEyeBall) + "を集めよう";
                UnlockCondition[3] = "レッドスライムを3000匹倒そう";
                UnlockCondition[4] = "スライムの核を3個集めよう";
                break;
            default:
                CliantName = "Slime otaku";//"Slime Hat man";
                discription[0] = "Hey! You look like you've been out there killing slimes! I collect their parts!  My momma told me that I needed to collect something, so this is what I picked. My only problem is that I'm not actually strong enough to fight them. They'll gobble me up and spit out my bones. So will you help me gather 1000 ooze stained cloth?! I'm going to make some slime clothes for myself, so maybe they'll let me hang out with them without eating me.";
                discription[1] = "It kind of worked! I was able to blend in with the normal slimes no problem! I had to steer clear of the others, though, because they seemed to know something was off. What do you mean slimes don't think?! Look they picked up on vibes or something, so I'm going to need more help from you, if you're willing. This time I need 5 Gooey Sludge and 2000 Ooze Stained Cloth. I don't care where you get them, but this will surely help me go undetected by the other slimes!";
                discription[2] = "Oh man, you won't believe it but my upgraded disguise works on all of the slimes except the really big ones that wear those cool sunglasses. It's like with those glasses on they just see right through my disguise! I had to run away to keep from getting digested by that guy, or thing, you know what I mean. This time I've raided my mom's cabinet and I'm ready to give you a good reward if you'll get me some Acidic Goo and a Slime Eye Ball. Yeah, if he looks me in that slimy eye, he'll for sure fall for my getup and accept me as a slime!";
                discription[3] = "Haha I am like one of them now. They don't even know I'm not a slime like them. I just make gurgling sounds and shuffle around and it's like I'm one of the family. I'm a little sad you keep killing so many of them, but if you hadn't, then I wouldn't be able to fulfill of dreams of living like a slime! I just have one problem, though. So I kind of lost something important to me and it was gobbled up by a red slime. It's probably completely dissolved by now, but if there's one kind of slime I don't like, then it's the red ones. I think I'd feel a lot better if you killed 3000 of them for me. Then they wouldn't be around as much and I'd get to enjoy hanging out with the rest of the slimes in peace.";
                discription[4] = "You really did it! I gurgled to the other slimes that a slayer was coming for the red slimes and now they think I'm some sort of prophet slime! Oh yeah, I'm starting to understand their language a little bit. It's pretty simple once you spend enough time living with them. My mom quit letting me come in the house because of all of the slimy goop I track in, so I've also been sleeping out there too. It's fine though, I feel more at home with the slimes than I do at home. My skin is even kind of turning tranluscent! I wonder if that's from the acidic goo from my disguise. Oh well, I have one last favor to ask of you. I need 3 Slime Core because I've heard of a potion that will make it so that I don't have to blend in... I'll actually become a slime! I've got everything else but that, so will you please get it for me? Oh and once I'm a slime, please don't kill me.";

                QuestNames[0] = "Slime lover 1";
                QuestNames[1] = "Slime lover 2";
                QuestNames[2] = "Slime lover 3";
                QuestNames[3] = "Slime lover 4";
                QuestNames[4] = "Slime lover 5";
                rewardText[0] = "- 1000 Gold\n- Gold Cap + 200";
                rewardText[1] = "- 500 Monster Fluid\n- 5 Carved Idol";
                rewardText[2] = "- 5 Nature Shards\n- Gold Cap + 1000";
                rewardText[3] = "- Equipment Slot " + quest.LetterImage() + " 30";
                rewardText[4] = "- 5000 Monster Fluid " + quest.LetterImage() + " 100";
                UnlockCondition[0] = "1000 Ooze Stained Cloth";
                UnlockCondition[1] = "5 Gooey Sludge\n- 2000 Ooze Stained Cloth";
                UnlockCondition[2] = "1 Acidic Goop\n- 1 Slime Eye Ball";
                UnlockCondition[3] = "Kill 3000 Red Slimes";
                UnlockCondition[4] = "3 Slime Core";
                break;
        }
    }
}
