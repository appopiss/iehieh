using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;
using TMPro;

public class L_tutorial : BASE, ILocalizedText {

    public static void Proceed(TextMeshProUGUI text)
    {
        LocalizeInitialize.SetFont(main.DeathPanel.expText);
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                if (main.S.job == ALLY.Job.Warrior)
                {
                    main.DeathPanel.expText.text = "<size=14>To defeat Big Slime, gain 100 Blue Stones " +
                        "by clicking mine or buying upgrades with Gold.";
                }
                else if (main.S.job == ALLY.Job.Wizard)
                {
                    main.DeathPanel.expText.text = "<size=14>To defeat Big Slime, gain 100 Yellow Crystals " +
                        "by clicking laboratory or buying upgrades with Gold.";
                }
                else if (main.S.job == ALLY.Job.Angel)
                {
                    main.DeathPanel.expText.text = "<size=14>To defeat Big Slime, gain 100 Green Leaves " +
                        "by clicking forest or buying upgrades with Gold.";
                }
                break;
            case Language.jp:
                if (main.S.job == ALLY.Job.Warrior)
                {
                    main.DeathPanel.expText.text = "<size=13>ビッグスライムを倒すために、鉱山をクリックするか、" +
                        "アップグレードを購入して青いストーンを100個貯めよう. ";
                }
                else if (main.S.job == ALLY.Job.Wizard)
                {
                    main.DeathPanel.expText.text = "<size=13>ビッグスライムを倒すために、研究所をクリックするか、" +
                        "アップグレードを購入して黄色クリスタルを100貯めよう. ";
                }
                else if (main.S.job == ALLY.Job.Angel)
                {
                    main.DeathPanel.expText.text = "<size=13>ビッグスライムを倒すために、森をクリックするか、" +
                        "アップグレードを購入して緑のリーフを100個貯めよう. ";
                }
                break;
            case Language.chi:
                if (main.S.job == ALLY.Job.Warrior)
                {
                    main.DeathPanel.expText.text = "<size=14>要击败 Big Slime, 请点击我的或购买金币来获得100枚蓝 Stone. ";
                }
                else if (main.S.job == ALLY.Job.Wizard)
                {
                    main.DeathPanel.expText.text = "<size=14>要击败 Big Slime, 请通过单击实验室或购买金币来获得100个黄色 Crystal. ";
                }
                else if (main.S.job == ALLY.Job.Angel)
                {
                    main.DeathPanel.expText.text = "<size=14>打败 Big Slime, 通过点击森林或用金币购买升级获得100枚緑 Leaf. ";
                }
                break;
        }
    }

    public static void Proceed2(TextMeshProUGUI text)
    {
        LocalizeInitialize.SetFont(text);
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                if (main.S.job == ALLY.Job.Warrior)
                {
                    text.text 
                        = "<size=14>Unleash a new Skill by holding down the Blue Stone to raise Proficiency.";
                }
                else if (main.S.job == ALLY.Job.Wizard)
                {
                    text.text 
                        = "<size=14>Unleash a new Skill by holding down the Yellow Crystal to raise Proficiency.";
                }
                else if (main.S.job == ALLY.Job.Angel)
                {
                    text.text 
                        = "<size=14>Unleash a new Skill by holding down the Green Leaf to raise Proficiency.";
                }
                break;
            case Language.jp:
                if (main.S.job == ALLY.Job.Warrior)
                {
                    text.text = "<size=13>青いストーンが描かれたボタンを長押しして熟練度を上げ、新しいスキルを習得しよう. ";
                }
                else if (main.S.job == ALLY.Job.Wizard)
                {
                    text.text = "<size=13>黄色いクリスタルが描かれたボタンを長押しして熟練度を上げ、新しいスキルを習得しよう. ";
                }
                else if (main.S.job == ALLY.Job.Angel)
                {
                    text.text = "<size=13>緑のリーフが描かれたボタンを長押しして熟練度を上げ、新しいスキルを習得しよう. ";
                }
                break;
            case Language.chi:
                if (main.S.job == ALLY.Job.Warrior)
                {
                    text.text = "<size=14>按住蓝石释放新技能, 提升熟练度. ";
                }
                else if (main.S.job == ALLY.Job.Wizard)
                {
                    text.text = "<size=14>按住黄水晶释放新技能, 提升熟练度. ";
                }
                else if (main.S.job == ALLY.Job.Angel)
                {
                    text.text = "<size=14>按住绿叶释放新技能, 提升熟练度. ";
                }
                break;
        }
    }

    public static void Proceed3(TextMeshProUGUI text)
    {
        LocalizeInitialize.SetFont(text);
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                text.text = "<size=14>Click a new Skill and set it on the slot. \nThen try again Area 1-1 The Slime Slums.";
                break;
            case Language.jp:
                text.text = "<size=13>習得した新しいスキルをクリックして、右下のスキルスロットに入れよう. \n" +
                    "その後、ビッグスライムに再挑戦しよう. ";
                break;
            case Language.chi:
                text.text = "<size=14>点击一个新的技能并将其设置在插槽上. 再尝试 Big Slime. ";
                break;
        }
    }

    public void UpdateText(Language lang)
    {

    }
}
