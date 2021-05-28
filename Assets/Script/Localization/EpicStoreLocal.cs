using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static BASE;
using static UsefulMethod;

public class EpicStoreLocal : MonoBehaviour
{
    public GameObject[] units;
    TextMeshProUGUI[] explain;
    string[] tempExplain;
    float[] tempFontsize;

    public void UpdateText(Language lang)
    {
        LocalizeInitialize.SetFont(explain);
        switch (lang)
        {
            case Language.eng:
                for (int i = 0; i < units.Length; i++)
                {
                    explain[i].text = tempExplain[i];
                    explain[i].fontSize = tempFontsize[i];
                }
                break;
            case Language.jp:
                explain[0].text = "錬金術(Alchemy)で、所持している全ての容器に同時に水をためることができるようになります. ";
                explain[1].text = "錬金術で、容器の所持数を自動で拡張できる機能を追加します. 再誕後、これまで到達した最も大きい容器まで自動的に「+」ボタンを押します. ";
                explain[1].fontSize = 7;
                explain[2].text = "モンスター図鑑(Bestiary)で、lootを自動で行うようになります. ";
                explain[3].text = "デイリークエストを1つ追加します. ";
                explain[4].text = "デイリークエストを1つ追加します. ";
                explain[5].text = "デイリークエストを1つ追加します. ";
                explain[6].text = "デイリークエストで、コモン(Common)がでなくなります";
                explain[7].text = "デイリークエストで、アンコモン(Uncommon)がでなくなります";

                explain[8].text = "キューの最大値を+5します. ";
                explain[9].text = "キューの最大値を+5します. ";
                explain[10].text = "キューの最大値を+5します. ";
                explain[11].text = "キューの最大値を+10します. ";
                explain[12].text = "スライムバンクのキューの最大値を+3します. ";
                explain[13].text = "スライムバンクのキューの最大値を+3します. ";
                explain[14].text = "スライムバンクのキューの最大値を+3します. ";
                explain[15].text = "スライムバンクのキューの最大値を+6します. ";

                explain[16].text = "装備をすべて外すボタンを有効化します. ";
                explain[17].text = "オートムーブ時に、どれくらい敵に近づくか設定できるようになります(Systemタブ). ";
                explain[18].text = "ムーブスピードが1%～100%の範囲で設定できるようになります(Systemタブ). ";
                explain[19].text = "エリアボタンの上で\"F\"キーをおすことでお気に入りのエリアを設定します. ロードしたとき、そのエリアから始まるようになります. ";
                explain[19].fontSize = 7;
                explain[20].text = "\"L\"キーをおすことで錬金術(Alchemy)のアイテムをロックできます";
                explain[21].text = "アクティブスキルを移動で発動できるようなオプションを追加します(Systemタブ)";
                explain[22].text = "\"Q\"キーをおすことで5キューと引き換えに、スーパーキューを割り当てられます. スーパーキューは永久にそれを買い続けます. ";
                explain[22].fontSize = 7;
                explain[23].text = "スライムバンクでも\"Q\"キーをおすことでスーパーキューが割り当てられるようになります";

                explain[24].text = "再誕(Rebirth)後にロードされるスキルスロットをセーブすることができます. ";
                explain[25].text = "\"N\"キーをおすことで有効化します. ニトロがMaxになったときに、自動的にブーストを始めます. ";
                explain[26].text = "\"M\"キーをおすことで有効化します. 同時に複数のスキルをレベルアップすることができます. ";
                explain[27].text = "スーパーキュー(Super Queue)の設定が、再誕(Rebirth)後も引き継ぐようになります. ";
                explain[28].text = "装備の上で\"F\"キーをおすことで、お気に入りの装備を設定します. その装備は、再誕(Rebirth)後も自動的に装備されます. ";
                explain[28].fontSize = 7;

                explain[29].text = "スライムキングのレベルを1に戻します";
                explain[30].text = "ゴーレムのレベルを1に戻します";
                explain[31].text = "デスパイダーのレベルを1に戻します";
                explain[32].text = "フェアリークイーンのレベルを1に戻します";
                explain[33].text = "バナヌーンのレベルを1に戻します";
                explain[34].text = "オクトバディのレベルを1に戻します";
                explain[35].text = "ディストーションスライムのレベルを1に戻します";

                explain[36].text = "すべてのチャレンジボスのレベルを1に戻します";
                explain[37].text = "ミステリーアップグレードのレベルを1に戻します";
                explain[38].text = "<color=green>500</color> モンスターの体液を獲得します.  <color=orange>(買うたびに得られる量が増えます)";
                explain[39].text = "ニトロをMaxまでチャージします";

                explain[40].text = "再誕(Rebirth)することなく、再誕アップグレードを購入できます. ";
                explain[41].text = "ゲームをはじめからやり直すことなく再誕(Rebirth)できます. ";
                explain[42].text = "再誕(Rebirth)アップグレードをリセットして、再誕ポイント(Prestige Point)を払い戻します. ";
                explain[43].text = "転生(Reincarnation)することなく、転生アップグレードを購入できます. ";
                explain[44].text = "転生(Rebirth)アップグレードをリセットして、Sprit Essenceを払い戻します. ";

                explain[45].text = "装備スロットを追加で1つ獲得します";
                explain[46].text = "装備スロットを追加で1つ獲得します";
                explain[47].text = "装備スロットを追加で1つ獲得します";
                explain[48].text = "スキルスロットを追加で1つ獲得します";
                explain[49].text = "グローバルスキルスロットを追加で1つ獲得します";
                explain[50].text = "グローバルスキルスロットを追加で1つ獲得します";

                explain[51].text = "スキルセットを新しく追加します. \"Shift + Tab + 5\"で切り替えれます. ";
                explain[52].text = "スキルセットを新しく追加します. \"Shift + Tab + 4\"で切り替えれます. ";
                explain[53].text = "スキルセットを新しく追加します. \"Shift + Tab + 3\"で切り替えれます. ";
                explain[54].text = "スキルセットを新しく追加します. \"Shift + Tab + 2\"で切り替えれます. ";
                explain[55].text = "錬金術(Alchemy)のインベントリを+4します";
                explain[56].text = "錬金術(Alchemy)のインベントリを+4します";
                explain[57].text = "錬金術(Alchemy)のインベントリを+4します";
                explain[58].text = "錬金術(Alchemy)のインベントリを+4します";

                explain[59].text = "虹色魚がどこでも手に入るようになり、さらに獲得確率が10倍になります. ";
                explain[60].text = "暗黒の儀式(Dark Ritual)での作業員の効率が2倍になり、ジェムの効果も2倍になります. ";
                explain[61].text = "獲得する経験値が1.5倍になります(メタルスライムも含みます)";
                explain[62].text = "獲得する経験値が1.5倍になります(メタルスライムも含みます)";
                explain[63].text = "モンスターゴールドキャップを+1000します";
                explain[64].text = "モンスターゴールドキャップを+1000します";
                explain[65].text = "モンスターゴールドキャップを+1000します";
                explain[66].text = "モンスターゴールドキャップを+1000します";
                explain[67].text = "錬金術(Alchemy)で\"Q\"キーを押すことでスーパーキューを割り当てられます. スーパーキューは永久にそれを買い続けます. ";
                explain[68].text = "スーパーキュー(Super Queue)の設定が、転生(Reincarnation)後も引き継ぐようになります. ";
                explain[69].text = "Favorite Craftが、進化回数は半分、レベルは１になって、転生(Reincarnation)を通しても引き継ぐようになります. ";
                explain[70].text = "2時間分のオフラインボーナスを即座に獲得します. (1日1回まで購入可能)";
                explain[71].text = "4時間分のオフラインボーナスを即座に獲得します. (1日1回まで購入可能)";
                explain[72].text = "8時間分のオフラインボーナスを即座に獲得します. (1日1回まで購入可能)";
                explain[73].text = "16時間分のオフラインボーナスを即座に獲得します. (1日1回まで購入可能)";
                break;
            case Language.chi:
                explain[0].text = "在Alchemy中, 您可以同时将水储存在所有容器中. ";
                explain[1].text = "我们将添加一个功能, 该功能可以自动扩展您拥有的炼金术容器的数量. 重生后, 自动将[+]按钮按到您所到达的最大容器中. ";
                explain[1].fontSize = 7;
                explain[2].text = "在Bestiary中, 战利品会自动执行. ";
                explain[3].text = "添加一个每日任务(Daily Quest). ";
                explain[4].text = "添加一个每日任务(Daily Quest). ";
                explain[5].text = "添加一个每日任务(Daily Quest). ";
                explain[6].text = "在Daily Quest中, Common不再可用. ";
                explain[7].text = "在Daily Quest中, Unommon不再可用. ";

                explain[8].text = "将Queue的最大值增加+5. ";
                explain[9].text = "将Queue的最大值增加+5. ";
                explain[10].text = "将Queue的最大值增加+5. ";
                explain[11].text = "将Queue的最大值增加+10. ";
                explain[12].text = "将Slime Bank Queue的最大值增加+3. ";
                explain[13].text = "将Slime Bank Queue的最大值增加+3. ";
                explain[14].text = "将Slime Bank Queue的最大值增加+3. ";
                explain[15].text = "将Slime Bank Queue的最大值增加+6. ";

                explain[16].text = "启用按钮以删除所有设备. ";
                explain[17].text = "您将能够设置自动移动过程中与敌人的距离（System选项卡）. ";
                explain[18].text = "可以在1％至100％的范围内设置移动速度（System选项卡）. ";
                explain[19].text = "通过按区域按钮上的\"F\"键设置您喜欢的区域. 加载后, 它将从该区域开始. ";
                explain[19].fontSize = 7;
                explain[20].text = "按\"L\"键可以锁定炼金物品. ";
                explain[21].text = "增加一个选项, 允许通过移动激活主动技能（System选项卡）. ";
                explain[22].text = "通过按\"Q\"键, 你可以分配一个超级提示, 以换取5个提示. 超级引子(Super Queue)会一直买下去, 直到永远. ";
                explain[22].fontSize = 7;
                explain[23].text = "你也可以通过按\"Q\"键在 Slime Bank 中分配 Super Queue. ";

                explain[24].text = "你可以保存Rebirth后加载的技能槽. ";
                explain[25].text = "按\"N\"键激活. 当Nitro达到Max时, 它将自动开始提升. ";
                explain[26].text = "按\"M\"键激活. 你可以同时提升多个技能的等级. ";
                explain[27].text = "在Rebirth之后, Super Queue的设置将被继承. ";
                explain[28].text = "按设备上的\"F\"键, 可以设置自己喜欢的设备. 重生后会自动装备. ";
                explain[28].fontSize = 7;

                explain[29].text = "将Slime King的等级重置为1. ";
                explain[30].text = "将Golem的等级重置为1. ";
                explain[31].text = "将Deathpider的等级重置为1. ";
                explain[32].text = "将Fairy Queen的等级重置为1. ";
                explain[33].text = "将Bananoon的等级重置为1. ";
                explain[34].text = "将Octobaddie的等级重置为1. ";
                explain[35].text = "将Distortion Slime的等级重置为1. ";

                explain[36].text = "将所有挑战(Challenge Boss)的等级返回1. ";
                explain[37].text = "恢复神秘升级等级至1. ";
                explain[38].text = "获得<color=green>500</color> Monster Fluid.  <color=orange>(每次购买, 您都会得到更多)";
                explain[39].text = "将硝基充至最大. ";

                explain[40].text = "您可以购买没有Rebirth的Rebirth Upgrades. ";
                explain[41].text = "您可以Rebirth游戏而无需重新开始. ";
                explain[42].text = "重置Rebirth Upgrades并获得Prestige Points退款. ";
                explain[43].text = "您可以购买Reincarnation Upgrades而无需Reincarnation. ";
                explain[44].text = "重置Reincarnation Upgrades可获得Sprit Essence的退款. ";

                explain[45].text = "你获得一个额外的装备(Equipment)槽. ";
                explain[46].text = "你获得一个额外的装备(Equipment)槽. ";
                explain[47].text = "你获得一个额外的装备(Equipment)槽. ";
                explain[48].text = "获得一个额外的技能槽(Skill Slot). ";
                explain[49].text = "获得一个额外的Global Skill Slot. ";
                explain[50].text = "获得一个额外的Global Skill Slot. ";

                explain[51].text = "增加一套新的技能. 你可以按\"Shift + Tab + 5\"来切换. ";
                explain[52].text = "增加一套新的技能. 你可以按\"Shift + Tab + 4\"来切换. ";
                explain[53].text = "增加一套新的技能. 你可以按\"Shift + Tab + 3\"来切换. ";
                explain[54].text = "增加一套新的技能. 你可以按\"Shift + Tab + 2\"来切换. ";
                explain[55].text = "Alchemy存量(Inventory)增加+4. ";
                explain[56].text = "Alchemy存量(Inventory)增加+4. ";
                explain[57].text = "Alchemy存量(Inventory)增加+4. ";
                explain[58].text = "Alchemy存量(Inventory)增加+4. ";

                explain[59].text = "现在你在任何地方都可以得到Rainbow Fish, 你得到Rainbow Fish的几率提高了10倍. ";
                explain[60].text = "它能使Dark Ritual中工人的效率翻倍, 宝石(Gem)的效果也翻倍. ";
                explain[61].text = "你获得的经验将增加1.5倍（包括Metal Slime）. ";
                explain[62].text = "你获得的经验将增加1.5倍（包括Metal Slime）. ";
                explain[63].text = "Monster Gold Cap + 1000. ";
                explain[64].text = "Monster Gold Cap + 1000. ";
                explain[65].text = "Monster Gold Cap + 1000. ";
                explain[66].text = "Monster Gold Cap + 1000. ";
                explain[67].text = "你也可以通过按\"Q\"键在Alchemy中分配SuperQueue. SuperQueue会一直买下去, 直到永远. ";
                explain[68].text = "在Reincarnation之后, Super Queue的设置将被继承. ";
                explain[69].text = "在Reincarnation之后, Favorite Craft的设置将被继承. 进化编号将减半, 等级将为1.";
                explain[70].text = "立即获得价值2小时的离线奖金! (每天最多可以购买一次)";
                explain[71].text = "立即获得价值4小时的离线奖金! (每天最多可以购买一次)";
                explain[72].text = "立即获得价值8小时的离线奖金! (每天最多可以购买一次)";
                explain[73].text = "立即获得价值24小时的离线奖金! (每天最多可以购买一次)";
                break;
            default:
                for (int i = 0; i < units.Length; i++)
                {
                    explain[i].text = tempExplain[i];
                    explain[i].fontSize = tempFontsize[i];
                }
                break;
        }
    }

    void Update()
    {
        UpdateText(LocalizeInitialize.language);
    }

    void Awake()
    {
        explain = new TextMeshProUGUI[units.Length];
        tempExplain = new string[units.Length];
        tempFontsize = new float    [units.Length];
        for (int i = 0; i < units.Length; i++)
        {
            explain[i] = units[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>();
            //もともと入っていたものをキャッシュします
            tempExplain[i] = explain[i].text;
            tempFontsize[i] = explain[i].fontSize;
        }
    }
}
