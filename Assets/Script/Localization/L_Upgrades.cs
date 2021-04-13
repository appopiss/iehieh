using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static BASE;
using static UsefulMethod;

public class L_Upgrades : MonoBehaviour, ILocalizedText
{
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
                return "                        " + Name + " <<color=\"green\">レベル " + levelString + "</color> >\n \n ";
            case Language.chi:
                return "                 " + Name + " <<color=\"green\">Lv " + levelString + "</color> >\n \n ";
        }
        return "                 " + Name + " <<color=\"green\">Lv " + levelString + "</color> >\n \n \n ";
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
    public static void C_Leaf1(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                name = "Gathering";
                effectExplain = "Upgrade your Click Power for Gathering by 1 / level";
                explain = "Gather leaves to upgrade your Angel skills.";
                break;
            case Language.jp:
                name = "集める";
                effectExplain = "森をクリックしたときの緑の葉の獲得量を1増やします. ";
                explain = "天使のスキルを強くするために葉っぱを集める.";
                break;
            case Language.chi:
                name = "采集";
                effectExplain = "提升手动采集1*科技等级. ";
                explain = "点击森林获得绿叶. 绿叶主要用于提升天使技能.";
                break;

            default:
                name = "Gathering";
                effectExplain = "Upgrade your Click Power for Gathering by 1 / level";
                explain = "Gather leaves to upgrade your Angel skills.";
                break;
        }
    }
    public static void C_Leaf2(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                name = "Gathering II";
                effectExplain = "Increase the amount of \"Click Trees\" by ";
                explain = "Get leaves more efficiently by clicking the forest.\n  Gathering level is also important to increase the amount.";
                break;
            case Language.jp:
                name = "集める 2";
                effectExplain = "森をクリックしたときの緑の葉の獲得量を以下の数値だけ増やします. ";
                explain = "もっと効率よく緑の葉を集めるために森をクリックするんだ. \n下位アップグレード「集めろ」のレベルを上げることも重要だ. ";
                break;
            case Language.chi:
                name = "采集 2";
                effectExplain = "提升采集科技效率 0.5*科技等级";
                explain = "提升采集科技效率 0.5*科技等级. ";
                break;
            default:
                name = "Gathering II";
                effectExplain = "Increase the amount of \"Click Trees\" by ";
                explain = "Get leaves more efficiently by clicking the forest.\n  Gathering level is also important to increase the amount.";
                break;
        }
    }
    public static void C_Leaf3(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                name = "Gathering III";
                effectExplain = "Increase the amount of \"Click Tree\"";
                explain = "Your clickings encourage the tree to perform well.\n  Gathering level is also important to increase the amount.";
                break;
            case Language.jp:
                name = "集める 3";
                effectExplain = "森をクリックしたときの緑の葉の獲得量を以下の数値だけ増やします. ";
                explain = "君のクリックは森のパフォーマンスを上げるのに役立っている. \n下位アップグレード「集めろ」のレベルを上げることも重要だ. ";
                break;
            case Language.chi:
                name = "采集 3";
                effectExplain = "提升采集科技效率 100%*科技等级.";
                explain = "绿叶也可以用在绿叶仪式提升物理防御, 魔法防御和速度.";
                break;
            default:
                name = "Gathering III";
                effectExplain = "Increase the amount of \"Click Tree\"";
                explain = "Your clickings encourage the tree to perform well.\n  Gathering level is also important to increase the amount.";
                break;
        }
    }

    public static void PU_leaf1(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                name = "Train Gatherer";
                effectExplain = "Improve your ability to gain Leaf automatically by 1.0 / level.";
                explain = "Hire a bored kid to gather leaves for you.";
                break;
            case Language.jp:
                name = "労働者を訓練する";
                effectExplain = "1レベルあげるごとに、葉っぱを自動的に1増やします. ";
                explain = "葉っぱを集めてくれる退屈そうな子供を雇った. ";
                break;
            case Language.chi:
                name = "雇用农民";
                effectExplain = "提升自动采集 1*科技等级.";
                explain = "雇用农民自动采集叶子, 从此解救鼠标.";
                break;
            default:
                name = "Train Gatherer";
                effectExplain = "Improve your ability to gain Leaf automatically by 1.0 / level.";
                explain = "Hire a bored kid to gather leaves for you.";
                break;
        }
    }

    public static void PU_leaf2(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                name = "Train Gatherer II";
                effectExplain = "A more efficient method for gaining Leaf based\n  on the current level of Train Gatherer";
                explain = "Hire a bear to gather leaves for you. What? It could happen.";
                break;
            case Language.jp:
                name = "労働者を訓練する 2";
                effectExplain = "「労働者を訓練する」のレベルに応じて、\n   より効率的に葉っぱを自動獲得します. ";
                explain = "葉っぱを拾ってくれるクマを雇った. え？そういうこともあるもんだよ. ";
                break;
            case Language.chi:
                name = "培训农民";
                effectExplain = "提升农民效率 以增加自动采集速度.";
                explain = "培农民获得采集知识.";
                break;
            default:
                name = "Train Gatherer II";
                effectExplain = "A more efficient method for gaining Leaf based\n  on the current level of Train Gatherer";
                explain = "Hire a bear to gather leaves for you. What? It could happen.";
                break;
        }
    }

    public static void PU_leaf3(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                name = "Train Gatherer III";
                effectExplain = "A further improved method for gaining Leaf based on \n  the current levels of both Train Gatherer and Train Gatherer II";
                explain = "Hire a small town to gather leaves for you.";
                break;
            case Language.jp:
                name = "労働者を訓練する 3";
                effectExplain = "「労働者を訓練する2」のレベルに応じて、さらに\n  効率的に葉っぱを自動獲得します. ";
                explain = "葉っぱを集めるために、小さな町の人々を丸ごと動員した. ";
                break;
            case Language.chi:
                name = "高级农民";
                effectExplain = "提升农民效率和培训农民效率以增加自动采集效率. ";
                explain = "提升农民为高级农民. ";
                break;
            default:
                name = "Train Gatherer III";
                effectExplain = "A further improved method for gaining Leaf based on \n  the current levels of both Train Gatherer and Train Gatherer II";
                explain = "Hire a small town to gather leaves for you.";
                break;

        }
    }

    public static void PU_leaf4(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                name = "Enchanted Rake";
                effectExplain = "The most effective method for gaining Leaf based on \n  current levels of the other upgrades";
                explain = "When you want something done right, do it yourself...\n  or enchant a magical rake to do what you could have done yourself.";
                break;
            case Language.jp:
                name = "魔法のくま手";
                effectExplain = "「労働者を訓練する1～3」のレベルに応じて、\n  最も効率的に葉っぱを自動獲得します";
                explain = "物事を正しく行うには、結局は自分でやることだ. \n ...あるいはこの魔法のくま手を使おう. ";
                break;
            case Language.chi:
                name = "强化耙子";
                effectExplain = "增加农民和高级农民效率, \n  也提升他们的培训效率以增加自动采集效率. ";
                explain = "提升农民的装备和采集效率 ";
                break;
            default:
                name = "Enchanted Rake";
                effectExplain = "The most effective method for gaining Leaf based on \n  current levels of the other upgrades";
                explain = "When you want something done right, do it yourself...\n  or enchant a magical rake to do what you could have done yourself.";
                break;
        }
    }

    public static void C_crystal1(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                name = "Synthesizing";
                effectExplain = "Upgrade your Click Power for Synthesizing by 1 / level";
                explain = "Synthesize crystals to upgrade your Wizard skills.";
                break;
            case Language.jp:
                name = "共鳴";
                effectExplain = "研究所をクリックしたときのクリスタルの獲得量を1増やします. ";
                explain = "魔法使いのスキルを強くするために、クリスタルを共鳴させろ";
                break;
            case Language.chi:
                name = "合成";
                effectExplain = "提升手动合成1*科技等级. ";
                explain = "点击学院获得水晶. 水晶主要用于提升魔法师技能. ";
                break;
            default:
                name = "Synthesizing";
                effectExplain = "Upgrade your Click Power for Synthesizing by 1 / level";
                explain = "Synthesize crystals to upgrade your Wizard skills.";
                break;
        }
    }

    public static void C_crystal2(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                name = "Synthesizing II";
                effectExplain = "Increase the amount of \"Click Laboratory\" by ";
                explain = "Get crystals more efficiently by clicking the laboratory.\n  Synthesizing level is also important to increase the amount.";
                break;
            case Language.jp:
                name = "共鳴 2";
                effectExplain = "研究所をクリックしたときのクリスタルの獲得量を以下の量増やします. ";
                explain = "研究所をクリックしたときにより効率的にクリスタルを得られます. \n 下位アップグレード「共鳴」のレベルが重要です. ";
                break;
            case Language.chi:
                name = "合成II ";
                effectExplain = "提升合成科技效率 0.5*科技等级. ";
                explain = "水晶也可以用于提升金币加成和经验加成科技. ";
                break;
            default:
                name = "Synthesizing II";
                effectExplain = "Increase the amount of \"Click Laboratory\" by ";
                explain = "Get crystals more efficiently by clicking the laboratory.\n  Synthesizing level is also important to increase the amount.";
                break;
        }
    }

    public static void C_crystal3(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                name = "Synthesizing III";
                effectExplain = "Increase the amount of \"Click Laboratory\"";
                explain = "Your clickings encourage the laboratory to parform well.\n  Synthesizing level is also important to increase the amount.";
                break;
            case Language.jp:
                name = "共鳴 3";
                effectExplain = "研究所をクリックしたときのクリスタルの\n獲得量を以下の量増やします. ";
                explain = "あなたのクリックが研究所のパフォーマンスを良くします. \n 下位アップグレード「共鳴」のレベルが重要です. ";
                break;
            case Language.chi:
                name = "合成III ";
                effectExplain = "提升合成科技效率 100%*科技等级. ";
                explain = "水晶也可以用在水晶仪式提升蓝量和魔法攻击. ";
                break;
            default:
                name = "Synthesizing III";
                effectExplain = "Increase the amount of \"Click Laboratory\"";
                explain = "Your clickings encourage the laboratory to perform well.\n  Synthesizing level is also important to increase the amount.";
                break;
        }
    }

    public static void PU_crystal1(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                name = "Train Apprentice";
                effectExplain = "Improve your ability to gain Crystal automatically by 1.0 / level.";
                explain = "Hire a lazy kid to help run the lab.";
                break;
            case Language.jp:
                name = "研究員を訓練する";
                effectExplain = "1レベルあげるごとに、クリスタルを自動的に1増やします. ";
                explain = "研究所の経営ヘルプに、怠惰な子供を雇った. ";
                break;
            case Language.chi:
                name = "雇用研究员";
                effectExplain = "提升自动合成水晶 1*科技等级. ";
                explain = "雇用矿工自动合成水晶, 从此解救鼠标. ";
                break;
            default:
                name = "Train Apprentice";
                effectExplain = "Improve your ability to gain Crystal automatically by 1.0 / level.";
                explain = "Hire an lazy kid to help run the lab.";
                break;
        }
    }

    public static void PU_crystal2(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                name = "Train Apprentice II";
                effectExplain = "A more efficient method for gaining Crystal based\n  on the current level of Train Apprentice";
                explain = "Hire an eager apprentice to help run the lab.";
                break;
            case Language.jp:
                name = "研究員を訓練する 2";
                effectExplain = "「研究員を訓練する」のレベルに応じて、\n  より効率的にクリスタルを自動獲得します. ";
                explain = "研究所の経営ヘルプに、熱心な研究員を頼んだ. ";
                break;
            case Language.chi:
                name = "培训研究员";
                effectExplain = "提升研究员效率 以增加自动合成速度. ";
                explain = "培训研究员获得合成知识. ";
                break;
            default:
                name = "Train Apprentice II";
                effectExplain = "A more efficient method for gaining Crystal based\n  on the current level of Train Apprentice";
                explain = "Hire an eager apprentice to help run the lab.";
                break;
        }
    }

    public static void PU_crystal3(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                name = "Train Apprentice III";
                effectExplain = "A further improved method for gaining Crystal based on \n  the current levels of both Train Apprentice and Train Apprentice II";
                explain = "Hire a wizard to help run the lab.";
                break;
            case Language.jp:
                name = "研究員を訓練する 3";
                effectExplain = "「研究員を訓練する2」のレベルに応じて、\nより効率的にクリスタルを自動獲得します. ";
                explain = "研究所の経営ヘルプに、魔法使いを雇った. ";
                break;
            case Language.chi:
                name = "培训研究人员";
                effectExplain = "提升研究员效率和培训研究员效率 以增加自动研究员效率. ";
                explain = "提升研究员为高级研究员. ";
                break;
            default:
                name = "Train Apprentice III";
                effectExplain = "A further improved method for gaining Crystal based on \n  the current levels of both Train Apprentice and Train Apprentice II";
                explain = "Hire a wizard to help run the lab.";
                break;
        }
    }

    public static void PU_crystal4(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                name = "Enchanted Lab";
                effectExplain = "The most effective method for gaining Crystal based on \n  current levels of the other upgrades";
                explain = "When you want something done right, do it yourself...\n  or enchant an entire lab to do what you could have done yourself.";
                break;
            case Language.jp:
                name = "魔法の研究所";
                effectExplain = "「研究員を訓練する1～3」のレベルに応じて、\n最も効率的にクリスタルを自動獲得します";
                explain = "物事を正しく行うには、結局は自分でやることだ. \n ...あるいはこの魔法の研究所を使おう. ";
                break;
            case Language.chi:
                name = "强化实验室";
                effectExplain = "增加研究员和高级研究员效率, 也提升他们的培训效率 \n  以增加自动合成效率";
                explain = "提升研究员的环境和效率. ";
                break;
            default:
                name = "Enchanted Lab";
                effectExplain = "The most effective method for gaining Crystal based on \n  current levels of the other upgrades";
                explain = "When you want something done right, do it yourself...\n  or enchant an entire lab to do what you could have done yourself.";
                break;
        }
    }

    public static void C_stone1(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                name = "Mining";
                effectExplain = "Upgrade your Click Power for Mining by 1 / level";
                explain = "Mine for stone to upgrade your Warrior skills.";
                break;
            case Language.jp:
                name = "採掘";
                effectExplain = "鉱山をクリックしたときのクリスタルの獲得量を1増やします. ";
                explain = "戦士のスキルを強くするために、石を採掘せよ";
                break;
            case Language.chi:
                name = "采矿";
                effectExplain = "提升手动采矿 1*科技等级. ";
                explain = "点击矿山获得石头 \n  石头主要用于提升战士技能. ";
                break;
            default:
                name = "Mining";
                effectExplain = "Upgrade your Click Power for Mining by 1 / level";
                explain = "Mine for stone to upgrade your Warrior skills.";
                break;
        }
    }

    public static void C_stone2(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                name = "Mining II";
                effectExplain = "Increase effectiveness of Click Power by\n  additional 0.5 / level";
                explain = "Cleave off larger chunks of stone with each click.";
                break;
            case Language.jp:
                name = "採掘 2";
                effectExplain = "鉱山をクリックしたときのクリスタルの\n  獲得量を追加で0.5増やします. ";
                explain = "クリックで岩石を切り落とせ";
                break;
            case Language.chi:
                name = "采矿II ";
                effectExplain = "提升采矿科技效率 0.5*科技等级";
                explain = "石头也可以用于提升金币加成和经验加成科技. ";
                break;
            default:
                name = "Mining II";
                effectExplain = "Increase effectiveness of Click Power by\n  additional 0.5 / level";
                explain = "Cleave off larger chunks of stone with each click.";
                break;
        }
    }

    public static void C_stone3(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                name = "Mining III";
                effectExplain = "Increase effectiveness of Click Power";
                explain = "Knowing the weak points in the stone\n  means a larger quarry per click.";
                break;
            case Language.jp:
                name = "採掘 3";
                effectExplain = "クリックパワーをさらに効率的にします. ";
                explain = "石の弱点を知れば、一クリックで巨大な採石場を石に変えられる. ";
                break;
            case Language.chi:
                name = "采矿III ";
                effectExplain = "提升采矿科技效率 100%*科技等级";
                explain = "石头也可以用在祭石仪式提升血量和物理攻击. ";
                break;
            default:
                name = "Mining III";
                effectExplain = "Increase effectiveness of Click Power";
                explain = "Knowing the weak points in the stone\n  means a larger quarry per click.";
                break;
        }
    }

    public static void PU_stone1(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                name = "Train Miner";
                effectExplain = "Improve your ability to gain Stone automatically by 1.0 / level.";
                explain = "Hire a wimpy kid to break stone for you.";
                break;
            case Language.jp:
                name = "採掘員を訓練する";
                effectExplain = "1レベルあげるごとに、青い石を自動的に1増やします. ";
                explain = "採掘員として、弱虫な子供を雇った. ";
                break;
            case Language.chi:
                name = "雇用矿工";
                effectExplain = "提升自动采矿. ";
                explain = "雇用矿工自动采矿, 从此解救鼠标. ";
                break;
            default:
                name = "Train Miner";
                effectExplain = "Improve your ability to gain Stone automatically by 1.0 / level.";
                explain = "Hire a wimpy kid to break stone for you.";
                break;
        }
    }

    public static void PU_stone2(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                name = "Train Miner II";
                effectExplain = "A more efficient method for gaining Stone based\n  on the current level of Train Miner";
                explain = "Hire a strong man to break stone for you.";
                break;
            case Language.jp:
                name = "採掘員を訓練する 2";
                effectExplain = "下位アップグレード「採掘員を訓練する」のレベルに\n  応じてより効率的に青い石を自動獲得します. ";
                explain = "採掘員として、強靭な男を雇った. ";
                break;
            case Language.chi:
                name = "培训矿工";
                effectExplain = "提升矿工效率 以增加自动采矿速度. ";
                explain = "培训矿工获得采矿知识. ";
                break;
            default:
                name = "Train Miner II";
                effectExplain = "A more efficient method for gaining Stone based\n  on the current level of Train Miner";
                explain = "Hire a strong man to break stone for you.";
                break;

        }
    }

    public static void PU_stone3(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                name = "Train Miner III";
                effectExplain = "A further improved method for gaining Stone based on \n  the current levels of both Train Miner and Train Miner II";
                explain = "Hire a golem to break stone for you.";
                break;
            case Language.jp:
                name = "採掘員を訓練する 3";
                effectExplain = "下位アップグレード「採掘員を訓練する2」のレベルに\n応じてさらに効率的に青い石を自動獲得します. ";
                explain = "採掘員として、ゴーレムを雇った. ";
                break;
            case Language.chi:
                name = "高级矿工";
                effectExplain = "提升矿工效率和培训矿工效率 以增加自动采矿效率. ";
                explain = "提升矿工为高级矿工. ";
                break;
            default:
                name = "Enchanted Pickaxe";
                effectExplain = "A further improved method for gaining Stone based on \n  the current levels of both Train Miner and Train Miner II";
                explain = "Hire a golem to break stone for you.";
                break;
        }


    }

    public static void PU_stone4(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                name = "Enchanted Pickaxe";
                effectExplain = "The most effective method for gaining Stone based on \n  current levels of the other upgrades";
                explain = "When you want something done right, do it yourself... \n  or enchant a magical pickaxe to do what you could\n  have done yourself.";
                break;
            case Language.jp:
                name = "魔法のピッケル";
                effectExplain = "「採掘員を訓練する1～3」のレベルに応じて、\n  最も効率的に青い石を自動獲得します";
                explain = "物事を正しく行うには、結局は自分でやることだ. \n ...あるいはこの魔法のピッケルを使おう. ";
                break;
            case Language.chi:
                name = "强化十字镐";
                effectExplain = "增加矿工和高级矿工效率, 也提升他们的培训效率以增加自动采矿效率. ";
                explain = "提升矿工的装备和效率. ";
                break;
            default:
                name = "Enchanted Pickaxe";
                effectExplain = "The most effective method for gaining Stone based on \n  current levels of the other upgrades";
                explain = "When you want something done right, do it yourself... \n  or enchant a magical pickaxe to do what you could\n  have done yourself.";
                break;
        }
    }

    public static void atk(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                name = "Stone Ritual";
                effectExplain = "Increase your stats";
                explain = "You can brush up your body through a special ritual.\n  Lots of stones are required.";
                break;
            case Language.jp:
                name = "石の儀式";
                effectExplain = "攻撃力と体力を上昇させます. ";
                explain = "特別な儀式を通してあなたの体を磨きます. \n たくさんの石が必要だ. ";
                break;
            case Language.chi:
                name = "祭石仪式";
                effectExplain = "增加血量和物理攻击";
                explain = "透过仪式增强身体获得力量. \n  需要大量的石头. ";
                break;
            default:
                name = "Stone Ritual";
                effectExplain = "Increase your stats";
                explain = "You can brush up your body through a special ritual.\n  Lots of stones are required.";
                break;
        }
    }
    public static void defspd(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                name = "Leaf Ritual";
                effectExplain = "Increase your stats";
                explain = "You can brush up your body through a special ritual.\n  Lots of leaves are required.";
                break;
            case Language.jp:
                name = "葉の儀式";
                effectExplain = "物理防御、魔法防御、スピードを上昇させます. ";
                explain = "特別な儀式を通してあなたの体を磨きます. \n たくさんの葉が必要だ. ";
                break;
            case Language.chi:
                name = "祭叶仪式";
                effectExplain = "增加物理防御, 魔法防御和速度";
                explain = "透过仪式增强身体获得速度与防御. \n  需要大量的叶子. ";
                break;
            default:
                name = "Leaf Ritual";
                effectExplain = "Increase your stats";
                explain = "You can brush up your body through a special ritual.\n  Lots of leaves are required.";
                break;
        }
    }

    public static void matk(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                name = "Crystal Ritual";
                effectExplain = "Increase your stats";
                explain = "You can brush up your body through a special ritual.\n  Lots of crystals are required.";
                break;
            case Language.jp:
                name = "クリスタルの儀式";
                effectExplain = "MP,魔法防御を上昇させます. ";
                explain = "特別な儀式を通してあなたの体を磨きます. \n たくさんのクリスタルが必要だ. ";
                break;
            case Language.chi:
                name = "水晶仪式";
                effectExplain = "增加蓝量和魔法攻击";
                explain = "透过仪式增强身体获得智慧. \n  需要大量的水晶. ";
                break;
            default:
                name = "Crystal Ritual";
                effectExplain = "Increase your stats";
                explain = "You can brush up your body through a special ritual.\n  Lots of crystals are required.";
                break;
        }
    }
    public static void equip(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                name = "Expand Equipment";
                effectExplain = "Increase Equipment slot";
                explain = "You can expand your Equipment slot.";
                break;
            case Language.jp:
                name = "装備拡張";
                effectExplain = "装備スロットを１つ解放します. ";
                explain = "装備スロットを拡張できる. ";
                break;
            case Language.chi:
                name = "全面武装";
                effectExplain = "增加装备栏";
                explain = "允许玩家装备更多装备. ";
                break;
            default:
                name = "Expand Equipment";
                effectExplain = "Increase Equipment slot";
                explain = "You can expand your Equipment slot.";
                break;
        }
    }

    public static void exp(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                name = "EXP Bonus";
                effectExplain = "Increase EXP Gain";
                explain = "You can gain extra EXP Bonus when you kill a monster.";
                break;
            case Language.jp:
                name = "経験値ボーナス";
                effectExplain = "得られる経験値を上昇させます. ";
                explain = "モンスターを倒した時に追加でEXPが得られます";
                break;
            case Language.chi:
                name = "经验值奖励";
                effectExplain = "增加经验值";
                explain = "击杀怪物时可以获得额外的经验奖励. ";
                break;
            default:
                name = "EXP Bonus";
                effectExplain = "Increase EXP Gain";
                explain = "You can gain extra EXP Bonus when you kill a monster.";
                break;

        }
    }

    public static void gold(ref string name, ref string effectExplain, ref string explain)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                name = "Gold Bonus";
                effectExplain = "Increase Gold Gain";
                explain = "You can gain extra Gold Bonus when you kill a monster.";
                break;
            case Language.jp:
                name = "ゴールドボーナス";
                effectExplain = "得られるゴールドを上昇させます. ";
                explain = "モンスターを倒した時に追加でゴールドが得られます";
                break;
            case Language.chi:
                name = "金币奖励";
                effectExplain = "增加金币";
                explain = "击杀怪物时可以获得额外的金币奖励. ";
                break;
            default:
                name = "Gold Bonus";
                effectExplain = "Increase Gold Gain";
                explain = "You can gain extra Gold Bonus when you kill a monster.";
                break;
        }
    }

    public static string lottaryDescription()
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                return "Stats Upgrade : 50%\n- Resource Production Upgrade : 15%\n- EXP Bonus : 15%\n- Gold Bonus : 15%\n- Drop Chance : 5%";
            case Language.jp:
                return "ステータス : 50%\n- リソース生産 : 15%\n- 経験値ボーナス : 15%\n- ゴールドボーナス : 15%\n- ドロップ確率ボーナス : 5%";
            case Language.chi:
                return "Stats Upgrade : 50%\n- Resource Production Upgrade : 15%\n- EXP Bonus : 15%\n- Gold Bonus : 15%\n- Drop Chance : 5%";
            default:
                return "属性强化几率 : 50%\n- 资源产量加成几率 : 15%\n- 经验奖励几率 : 15%\n- 金币奖励几率 : 15%\n- 掉落率几率 : 5%";
        }
    }

    public static string lottaryName()
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                return "Mystery Upgrade";
            case Language.jp:
                return "ミステリーアップグレード";
            case Language.chi:
                return "神秘升级";
            default:
                return "Mystery Upgrade";
        }
    }

    public static string lottaryEffect()
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                string tempText = "";
                if (main.SR.R_HP > 0)
                    tempText += "- HP + " + tDigit(main.SR.R_HP) + "\n";
                if (main.SR.R_MP > 0)
                    tempText += "- MP + " + tDigit(main.SR.R_MP) + "\n";
                if (main.SR.R_ATK > 0)
                    tempText += "- ATK + " + tDigit(main.SR.R_ATK) + "\n";
                if (main.SR.R_MATK > 0)
                    tempText += "- MATK + " + tDigit(main.SR.R_MATK) + "\n";
                if (main.SR.R_DEF > 0)
                    tempText += "- DEF + " + tDigit(main.SR.R_DEF) + "\n";
                if (main.SR.R_MDEF > 0)
                    tempText += "- MDEF + " + tDigit(main.SR.R_MDEF) + "\n";
                if (main.SR.R_SPD > 0)
                    tempText += "- SPD + " + tDigit(main.SR.R_SPD) + "\n";
                if (main.SR.R_EXP > 0)
                    tempText += "- EXP Gain + " + tDigit(main.SR.R_EXP) + "\n";
                if (main.SR.R_GOLD > 0)
                    tempText += "- Gold Gain + " + tDigit(main.SR.R_GOLD) + "\n";
                if (main.SR.R_stone > 0)
                    tempText += "- Stone Production + " + UsefulMethod.percent(main.SR.R_stone, 1) + "\n";
                if (main.SR.R_crystal > 0)
                    tempText += "- Crystal Production + " + UsefulMethod.percent(main.SR.R_crystal, 1) + "\n";
                if (main.SR.R_leaf > 0)
                    tempText += "- Leaf Production  + " + UsefulMethod.percent(main.SR.R_leaf, 1) + "\n";
                if (main.SR.R_drop > 0)
                    tempText += "- Drop Chance  + " + UsefulMethod.percent(main.SR.R_drop, 2) + "\n";
                return tempText;
            case Language.jp:
                string tempText2 = "";
                if (main.SR.R_HP > 0)
                    tempText2 += "- HP + " + tDigit(main.SR.R_HP) + "\n";
                if (main.SR.R_MP > 0)
                    tempText2 += "- MP + " + tDigit(main.SR.R_MP) + "\n";
                if (main.SR.R_ATK > 0)
                    tempText2 += "- ATK + " + tDigit(main.SR.R_ATK) + "\n";
                if (main.SR.R_MATK > 0)
                    tempText2 += "- MATK + " + tDigit(main.SR.R_MATK) + "\n";
                if (main.SR.R_DEF > 0)
                    tempText2 += "- DEF + " + tDigit(main.SR.R_DEF) + "\n";
                if (main.SR.R_MDEF > 0)
                    tempText2 += "- MDEF + " + tDigit(main.SR.R_MDEF) + "\n";
                if (main.SR.R_SPD > 0)
                    tempText2 += "- SPD + " + tDigit(main.SR.R_SPD) + "\n";
                if (main.SR.R_EXP > 0)
                    tempText2 += "- 経験値 + " + tDigit(main.SR.R_EXP) + "\n";
                if (main.SR.R_GOLD > 0)
                    tempText2 += "- ゴールド + " + tDigit(main.SR.R_GOLD) + "\n";
                if (main.SR.R_stone > 0)
                    tempText2 += "- ストーンの生産量 + " + UsefulMethod.percent(main.SR.R_stone, 1) + "\n";
                if (main.SR.R_crystal > 0)
                    tempText2 += "- クリスタルの生産量 + " + UsefulMethod.percent(main.SR.R_crystal, 1) + "\n";
                if (main.SR.R_leaf > 0)
                    tempText2 += "- リーフの生産量  + " + UsefulMethod.percent(main.SR.R_leaf, 1) + "\n";
                if (main.SR.R_drop > 0)
                    tempText2 += "- ドロップ率  + " + UsefulMethod.percent(main.SR.R_drop, 2) + "\n";
                return tempText2;
            default:
                string tempText3 = "";
                if (main.SR.R_HP > 0)
                    tempText3 += "- HP + " + tDigit(main.SR.R_HP) + "\n";
                if (main.SR.R_MP > 0)
                    tempText3 += "- MP + " + tDigit(main.SR.R_MP) + "\n";
                if (main.SR.R_ATK > 0)
                    tempText3 += "- ATK + " + tDigit(main.SR.R_ATK) + "\n";
                if (main.SR.R_MATK > 0)
                    tempText3 += "- MATK + " + tDigit(main.SR.R_MATK) + "\n";
                if (main.SR.R_DEF > 0)
                    tempText3 += "- DEF + " + tDigit(main.SR.R_DEF) + "\n";
                if (main.SR.R_MDEF > 0)
                    tempText3 += "- MDEF + " + tDigit(main.SR.R_MDEF) + "\n";
                if (main.SR.R_SPD > 0)
                    tempText3 += "- SPD + " + tDigit(main.SR.R_SPD) + "\n";
                if (main.SR.R_EXP > 0)
                    tempText3 += "- EXP Gain + " + tDigit(main.SR.R_EXP) + "\n";
                if (main.SR.R_GOLD > 0)
                    tempText3 += "- Gold Gain + " + tDigit(main.SR.R_GOLD) + "\n";
                if (main.SR.R_stone > 0)
                    tempText3 += "- Stone Production + " + UsefulMethod.percent(main.SR.R_stone, 1) + "\n";
                if (main.SR.R_crystal > 0)
                    tempText3 += "- Crystal Production + " + UsefulMethod.percent(main.SR.R_crystal, 1) + "\n";
                if (main.SR.R_leaf > 0)
                    tempText3 += "- Leaf Production  + " + UsefulMethod.percent(main.SR.R_leaf, 1) + "\n";
                if (main.SR.R_drop > 0)
                    tempText3 += "- Drop Chance  + " + UsefulMethod.percent(main.SR.R_drop, 2) + "\n";
                return tempText3;
        }
    }

    public void UpdateText(Language lang)
    {

    }
}
