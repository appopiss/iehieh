using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static BASE;

public class Title : MonoBehaviour, ILocalizedText
{
    public TextMeshProUGUI ClickToStart, tutorialText, chooseClassText;
    string str1, str2, str3;
    int fontSize;
    void Awake()
    {
        str1 = ClickToStart.text;
        str2 = tutorialText.text;
        str3 = chooseClassText.text;
    }

    public static void Proceed(TextMeshProUGUI text, int index)
    {
        LocalizeInitialize.SetFont(text);
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                text.text = "You've chosen ";
                if (index == 0)
                    text.text += "<color=green>Warrior</color>.\n\nWould you like to proceed?";
                else if (index == 1)
                    text.text += "<color=green>Wizard</color>.\n\nWould you like to proceed?";
                else if (index == 2)
                    text.text += "<color=green>Angel</color>.\n\nWould you like to proceed?";
                break;
            case Language.jp:
                text.text = "あなたが選んだのは ";
                if (index == 0)
                    text.text += "<color=green>戦士</color>.\n\nこれでよろしいですか？";
                else if (index == 1)
                    text.text += "<color=green>魔法使い</color>.\n\nこれでよろしいですか？";
                else if (index == 2)
                    text.text += "<color=green>天使</color>.\n\nこれでよろしいですか？";
                break;
            case Language.chi:
                text.text = "您选择了 ";
                if (index == 0)
                    text.text += "<color=green>战士</color>.\n\n您想继续吗?";
                else if (index == 1)
                    text.text += "<color=green>巫师</color>.\n\n您想继续吗?";
                else if (index == 2)
                    text.text += "<color=green>天使</color>.\n\n您想继续吗?";
                break;
        }
    }

    public static void ClassExplanation(TextMeshProUGUI classText, TextMeshProUGUI featureText)
    {
        LocalizeInitialize.SetFont(classText);
        LocalizeInitialize.SetFont(featureText);
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                switch (main.S.job)
                {
                    case ALLY.Job.Warrior:
                        classText.text = "Warrior";
                        break;
                    case ALLY.Job.Wizard:
                        classText.text = "Wizard";
                        break;
                    case ALLY.Job.Angel:
                        classText.text = "Angel";
                            break;
                }
                featureText.fontSize = 16;
                featureText.text = "Health\nPhysical Attack\nMagical Attack\nDefence\nSpeed\nAttack Range\nIdle Play\nActive Play";
                break;
            case Language.jp:
                switch (main.S.job)
                {
                    case ALLY.Job.Warrior:
                        classText.text = "戦士";
                        break;
                    case ALLY.Job.Wizard:
                        classText.text = "魔法使い";
                        break;
                    case ALLY.Job.Angel:
                        classText.text = "天使";
                        break;
                }
                featureText.fontSize = 12;
                featureText.margin = new Vector4(0, 2, 0, 0);
                featureText.text = "体力\n物理攻撃\n魔法攻撃\n耐久力\n速度\n攻撃範囲\n放置プレイ\nアクティブプレイ";
                break;
            case Language.chi:
                switch (main.S.job)
                {
                    case ALLY.Job.Warrior:
                        classText.text = "战士";
                        break;
                    case ALLY.Job.Wizard: 
                        classText.text = "巫师";
                        break;            
                    case ALLY.Job.Angel:
                        classText.text = "天使";
                        break;
                }
                featureText.fontSize = 12;
                featureText.margin = new Vector4(0, 2, 0, 0);
                featureText.text = "健康方面\n物理攻击\n魔法攻击\n防御\n速度\n攻击范围\n闲置游戏\n主动播放";
                break;

        }
    }

    public static void Proceed2(TextMeshProUGUI text)
    {
        LocalizeInitialize.SetFont(text);
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                text.text = "Your adventure has now begun!";
                break;
            case Language.jp:
                text.text = "冒険の始まりだ！";
                break;
            case Language.chi:
                text.text = "你的冒险现在已经开始了!";
                break;
        }
    }
    void Update()
    {
        if (!main.S.isSlimeHideoutClear)
            UpdateText(LocalizeInitialize.language);
    }
    public void UpdateText(Language lang)
    {
        LocalizeInitialize.SetFont(ClickToStart);
        LocalizeInitialize.SetFont(tutorialText);
        LocalizeInitialize.SetFont(chooseClassText);

        switch (lang)
        {
            case Language.eng:
                ClickToStart.text = str1;
                tutorialText.text = str2;
                chooseClassText.text = str3;
                break;
            case Language.jp:
                ClickToStart.text = "クリックしてスタート";
                tutorialText.text =   "インクリメンタル・エピックヒーローの世界にようこそ！" +
                    "冒険を始める前に、次の3つのうちから１つ職業を選んでください. 【戦士 : 魔法使い : 天使】\n\n" +
                    "冒険の最初は選んだ職業で始まりますが、最終的には3つの職業に「再誕」を繰り返してより強くなることができます. より詳しいことは、冒険を進めるうちに分かっていくことでしょう. ";
                chooseClassText.text = "最初の職業を選んでください";
                break;
            case Language.chi:
                ClickToStart.text = "点击开始游戏";
                tutorialText.text = "欢迎来到 Incremental Epic Hero!" +
                    "在你开始冒险之前, 请从以下三个职业中选择一个.  [战士 : 巫师 : 天使]\n\n" +
                    "你的第一次冒险将从你刚刚选择的职业开始, 但你最终可以 Rebirth 成三个职业反复变强. " +
                    "更多细节将随着你的冒险进程而揭晓.";
                chooseClassText.text = "选择你的第一个职业.";
                break;
        }
    }
}
