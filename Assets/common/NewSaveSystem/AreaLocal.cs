using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BASE;
using static UsefulMethod;

public class AreaLocal : MonoBehaviour
{
    public static string GetAreaName(Main.Dungeon name, DUNGEON dungeon)
    {
        if (LocalizeInitialize.language == Language.jp)
        {
            switch (name)
            {
                case Main.Dungeon.slimeHideout:
                    return "スライムの隠れ家";
                case Main.Dungeon.Z_slimeSlums:
                    return "スライムのスラム街";
                case Main.Dungeon.Z_slimeVillage:
                    return "スライムの村";
                case Main.Dungeon.Z_slimePlains:
                    return "スライム平原";
                case Main.Dungeon.Z_slimePits:
                    return "スライムの隠れ穴";
                case Main.Dungeon.Z_slimePools:
                    return "スライムたまり";
                case Main.Dungeon.Z_slimeForest:
                    return "スライム森";
                case Main.Dungeon.Z_slimeCastle:
                    return "スライム城";
                case Main.Dungeon.Z_slimeThroneRoom:
                    return "スライム城の玉座の間";

                //bat
                case Main.Dungeon.Z_batDarkForest:
                    return "暗い森";
                case Main.Dungeon.Z_batCaveInTheWoods:
                    return "木に隠れた洞窟";
                case Main.Dungeon.Z_batRuinedTemple:
                    return "寂れた寺";
                case Main.Dungeon.Z_batTempleAntechamber:
                    return "寺の控室";
                case Main.Dungeon.Z_batCollapsedSanctuary:
                    return "崩壊した聖堂";
                case Main.Dungeon.Z_batUnderTemple:
                    return "寺の地下";
                case Main.Dungeon.Z_batBreedingGrounds:
                    return "血に染まった地";
                case Main.Dungeon.Z_batBlackCorridor:
                    return "黒い廊下";

                //spider
                case Main.Dungeon.Z_spider1:
                    return "不気味な田舎道";
                case Main.Dungeon.Z_spider2:
                    return "招かれざる客";
                case Main.Dungeon.Z_spider3:
                    return "糸で張り巡らされた部屋";
                case Main.Dungeon.Z_spider4:
                    return "じめじめした台所";
                case Main.Dungeon.Z_spider5:
                    return "破壊された台所";
                case Main.Dungeon.Z_spider6:
                    return "うごめくプールサイド";
                case Main.Dungeon.Z_spider7:
                    return "垣根で覆われた迷宮の入り口";
                case Main.Dungeon.Z_spider8:
                    return "蜘蛛王殿";

                //fairy
                case Main.Dungeon.Z_fairy1:
                    return "明るい森";
                case Main.Dungeon.Z_fairy2:
                    return "捨てられた小屋";
                case Main.Dungeon.Z_fairy3:
                    return "隠し道";
                case Main.Dungeon.Z_fairy4:
                    return "異常増殖";
                case Main.Dungeon.Z_fairy5:
                    return "奇妙な切り開き";
                case Main.Dungeon.Z_fairy6:
                    return "キノコの空地";
                case Main.Dungeon.Z_fairy7:
                    return "妖精の街";
                case Main.Dungeon.Z_fairy8:
                    return "妖精の庄園";

                //fox
                case Main.Dungeon.Z_fox1:
                    return "隠された小道";
                case Main.Dungeon.Z_fox2:
                    return "曲がりくねったトンネル";
                case Main.Dungeon.Z_fox3:
                    return "めまいのするトンネル";
                case Main.Dungeon.Z_fox4:
                    return "ガードルーム";
                case Main.Dungeon.Z_fox5:
                    return "秘密の道";
                case Main.Dungeon.Z_fox6:
                    return "行き止まり";
                case Main.Dungeon.Z_fox7:
                    return "右の道";
                case Main.Dungeon.Z_fox8:
                    return "女王の間";

                //magic slime
                case Main.Dungeon.Z_MS1:
                    return "スライム川";
                case Main.Dungeon.Z_MS2:
                    return "スライム洞穴";
                case Main.Dungeon.Z_MS3:
                    return "スライム市街";
                case Main.Dungeon.Z_MS4:
                    return "スライム番所";
                case Main.Dungeon.Z_MS5:
                    return "スライムの学校";
                case Main.Dungeon.Z_MS6:
                    return "スライムの大学";
                case Main.Dungeon.Z_MS7:
                    return "スライムメイジの塔";
                case Main.Dungeon.Z_MS8:
                    return "塔の頂";

                //sakana
                case Main.Dungeon.Z_DF1:
                    return "浅瀬";
                case Main.Dungeon.Z_DF2:
                    return "サンゴの洞窟";
                case Main.Dungeon.Z_DF3:
                    return "古代の難破船";
                case Main.Dungeon.Z_DF4:
                    return "海底都市";
                case Main.Dungeon.Z_DF5:
                    return "果てしなく広がる暗黒";
                case Main.Dungeon.Z_DF6:
                    return "溝";
                case Main.Dungeon.Z_DF7:
                    return "さらに深く";
                case Main.Dungeon.Z_DF8:
                    return "最も深く、暗い所";

                //ball
                case Main.Dungeon.Z_BB1:
                    return "時空のゆがんだ駅";
                case Main.Dungeon.Z_BB2:
                    return "ワープトレイン";
                case Main.Dungeon.Z_BB3:
                    return "ワープトンネル";
                case Main.Dungeon.Z_BB4:
                    return "混沌";
                case Main.Dungeon.Z_BB5:
                    return "???の目";
                case Main.Dungeon.Z_BB6:
                    return "???の脳";
                case Main.Dungeon.Z_BB7:
                    return "???の心臓";
                case Main.Dungeon.Z_BB8:
                    return "???のコア";

                //dungeon
                case Main.Dungeon.Z_slimeD:
                    return "スライムの湧き出るプール";
                case Main.Dungeon.Z_batD:
                    return "終わりのない夜";
                case Main.Dungeon.Z_spiderD:
                    return "糸の広がる世界";
                case Main.Dungeon.Z_fairyD:
                    return "妖精国";
                case Main.Dungeon.Z_foxD:
                    return "狐の穴";
                case Main.Dungeon.Z_MSD:
                    return "頂上のない塔";
                case Main.Dungeon.Z_DFD:
                    return "無限深";
                case Main.Dungeon.Z_BBD:
                    return "超空間";
            }
        }
        else
        {
            return dungeon.dungeonName;
        }
        return "";
    }
    public static string clearArea(bool isWin)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                if (!isWin)
                {
                    return "Area \"" + main.dungeonAry[(int)main.GameController.currentDungeon].dungeonName + "\" is failed...";
                }else
                return main.DeathPanel.titleText.text = "Area \"" + 
                    AreaLocal.GetAreaName(main.GameController.currentDungeon, main.dungeonAry[(int)main.GameController.currentDungeon]) + "\" is cleared!!!";
            case Language.jp:
                if (!isWin)
                {
                    return AreaLocal.GetAreaName(main.GameController.currentDungeon, main.dungeonAry[(int)main.GameController.currentDungeon]) + " に失敗した...";
                }
                return 
                    AreaLocal.GetAreaName(main.GameController.currentDungeon, main.dungeonAry[(int)main.GameController.currentDungeon]) + " をクリアした!!!";
            default:
                if (!isWin)
                {
                    return "Area \"" + main.dungeonAry[(int)main.GameController.currentDungeon].dungeonName + "\" is failed...";
                }
                else
                    return main.DeathPanel.titleText.text = "Area \"" +
                        AreaLocal.GetAreaName(main.GameController.currentDungeon, main.dungeonAry[(int)main.GameController.currentDungeon]) + "\" is cleared!!!";
        }
    }
    public static string clearZone(bool isWin)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                if (!isWin)
                {
                    return "Dungeon \"" + main.dungeonAry[(int)main.GameController.currentDungeon].dungeonName + "\" is failed...";
                }
                else
                    return main.DeathPanel.titleText.text = "Dungeon \"" +
                        AreaLocal.GetAreaName(main.GameController.currentDungeon, main.dungeonAry[(int)main.GameController.currentDungeon]) + "\" is cleared!!!";
            case Language.jp:
                if (!isWin)
                {
                    return AreaLocal.GetAreaName(main.GameController.currentDungeon, main.dungeonAry[(int)main.GameController.currentDungeon]) + " に失敗した...";
                }
                return
                    AreaLocal.GetAreaName(main.GameController.currentDungeon, main.dungeonAry[(int)main.GameController.currentDungeon]) + " をクリアした!!!";
            default:
                if (!isWin)
                {
                    return "Dungeon \"" + main.dungeonAry[(int)main.GameController.currentDungeon].dungeonName + "\" is failed...";
                }
                else
                    return main.DeathPanel.titleText.text = "Dungeon \"" +
                        AreaLocal.GetAreaName(main.GameController.currentDungeon, main.dungeonAry[(int)main.GameController.currentDungeon]) + "\" is cleared!!!";

        }
    }
}
