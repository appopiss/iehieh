using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class D_SacredFairyCave : DUNGEON
{
     //public override int maxDungeonFloorNum
     //{
     //    get => main.SR.maxDungeonFloorNum[idDungeon];
     //    set => main.SR.maxDungeonFloorNum[idDungeon] = value;
     //}
  
     //public override DateTime dungeonPlayTime
     //{
     //    get { return DateTime.FromBinary(Convert.ToInt64(main.S.dungeonPlayTime[idDungeon])); }
     //    set { main.S.dungeonPlayTime[idDungeon] = value.ToBinary().ToString(); }
     //}
  
     // Use this for initialization
     void Awake () {
         AwakeDungeon(Main.Dungeon.sacredFairyCave,"Sacred Fairy Cave", 14,2);
     }
  
  //// Use this for initialization
     void Start () {
         StartDungeon();
     }
  
     // Update is called once per frame
     void Update () {
         UpdateDungeon();
         if (!isDungeon)
         {
             explain = "- Max Wave " + (dungeonMaxFloorNum + 1) + "\n- Recommended Lv ???";
             rewardExplain = "- EXP : 2000\n- GOLD : 1000\n- <color=green>New Contents";
         }
         else
         {
             explain = "- Max Wave " + (dungeonMaxFloorNum + 1) + "\n- Recommended Lv 16 ~ 25";
             rewardExplain = "- EXP : 2000\n- GOLD : 1000";
         }
     }
  
     public override void GetReward()
     {
         main.SR.gold += 1000;
         main.DeathPanel.gold += 1000;
         main.ally1.GetComponent<IDamagable>().currentExp += 2000;
         main.DeathPanel.exp += 2000;
         main.Log("<color=orange>Dungeon Clear !");
         main.Log("<color=green>EXP + 2000");
         main.Log("<color=green>Gold + 1000");
  
         if (!isDungeon)
         {
             isDungeon = true;
             main.TutorialController.ResetMenu();
             main.TutorialController.ShowMenu();
             StartCoroutine(main.InstantiateLogText("New Content\n<size=12>\"REBIRTH\"<size=10> is Unleashed!", main.TutorialController.iconSpriteAry[0]));
             main.TutorialController.ResetDungeon();
             main.TutorialController.ShowDungeon();
             StartCoroutine(main.InstantiateLogText("New Dungeon\n<size=12>\"Spider Ruin\"<size=10> is Unleashed!",main.ChallengeSpriteAry[2]));
             main.TutorialController.ResetZone();
             main.TutorialController.ShowZone();
             StartCoroutine(main.InstantiateLogText("New Zone\n<size=12>\"The Slime Kingdom\"<size=10> is Unleashed!", main.ZoneSpritesAry[0]));
             main.TutorialController.ResetChallenge();
             main.TutorialController.ShowChallenge();
             StartCoroutine(main.InstantiateLogText("New Challenge\n<size=12>\"Fairy\"<size=10> is Unleashed!", main.TutorialController.iconSpriteAry[2]));
  
             main.TutorialController.isUpgradeIcon10 = true;
             main.TutorialController.ResetUpgradeIcon();
             main.TutorialController.ShowUpgradeIcon();
             StartCoroutine(main.InstantiateLogText("New Upgrade is Unleashed!", main.UpStoneSpriteAry[2]));
  
  
             //main.TutorialController.ResetZone();
             //main.TutorialController.ShowZone();
             //StartCoroutine(main.InstantiateLogText("New Zone\n<size=12>\"Ball Zone\"<size=10> is Unleashed!",main.ZoneSpritesAry[2]));
             //main.TutorialController.ResetChallenge();
             //main.TutorialController.ShowChallenge();
             //StartCoroutine(main.InstantiateLogText("New Challenge\n<size=12>\"Golem\"<size=10> is Unleashed!", main.TutorialController.iconSpriteAry[6]));
         }
         main.TutorialController.isUpgradeIcon10 = true;
  
     }
  
     //public override bool ClearCondition()
     //{
     //    if (dungeonFloorNum == dungeonMaxFloorNum+1 && GameObject.FindGameObjectsWithTag("enemy").Length == 0)
     //    {
     //        dungeonFloorNum = dungeonMaxFloorNum;
     //        return true;
     //    }
     //    else
     //    {
     //        return false;
     //    }
     //}
     [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
     double[] NS = new double[] { 500, 15, 0, 0, 0, 100 };
     [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
     double[] BS = new double[] { 1000, 25, 0, 50, 0, 100 };
     [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
     double[] NB = new double[] { 300, 25, 0, 20, 0, 100 };
     double[] YB = new double[] { 500, 0, 25, 0, 20, 100 };
     [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
     double[] NSpider = new double[] { 2000, 30, 0, 5, 0, 100 };
     [NamedArrayAttribute(new string[] { "HP", "ATK", "MATK", "DEF", "MDEF", "GOLD" })]
     double[] RF = new double[] { 50000, 30, 30, 50, 50, 100000 };
  
     //public override void InstantiateEnemies(int dungeonFloorNum)
     //{
     //    if (main.GameController.currentDungeon == dungeon)
     //    {
     //        switch (dungeonFloorNum)
     //        {
     //            case 0:
     //                InstantiateEnemy(0, new Vector3(-160, 0), NS);
     //                InstantiateEnemy(0, new Vector3(-120, 120), NS);
     //                InstantiateEnemy(0, new Vector3(-80, 0), NS);
     //                InstantiateEnemy(0, new Vector3(-40, 120), NS);
     //                InstantiateEnemy(0, new Vector3(0, 0), NS);
     //                InstantiateEnemy(0, new Vector3(40, 120), NS);
     //                InstantiateEnemy(0, new Vector3(80, 0), NS);
     //                InstantiateEnemy(0, new Vector3(120, 120), NS);
     //                InstantiateEnemy(0, new Vector3(160, 0), NS);
     //                InstantiateEnemy(1, new Vector3(140, 60), BS);
     //                InstantiateEnemy(1, new Vector3(100, 60), BS);
     //                InstantiateEnemy(1, new Vector3(60, 60), BS);
     //                InstantiateEnemy(1, new Vector3(20, 60), BS);
     //                InstantiateEnemy(1, new Vector3(-20, 60), BS);
     //                InstantiateEnemy(1, new Vector3(-60, 60), BS);
     //                InstantiateEnemy(1, new Vector3(-100, 60), BS);
     //                InstantiateEnemy(1, new Vector3(-140, 60), BS);
     //                break;
     //            case 1:
     //                InstantiateEnemy(0, new Vector3(-160, 160),NS);
     //                InstantiateEnemy(0, new Vector3(-120, 120), NS);
     //                InstantiateEnemy(0, new Vector3(-80, 160), NS);
     //                InstantiateEnemy(0, new Vector3(-40, 120), NS);
     //                InstantiateEnemy(0, new Vector3(0, 160), NS);
     //                InstantiateEnemy(0, new Vector3(40, 120), NS);
     //                InstantiateEnemy(0, new Vector3(80, 160), NS);
     //                InstantiateEnemy(0, new Vector3(120, 120), NS);
     //                InstantiateEnemy(0, new Vector3(160, 160), NS);
     //                InstantiateEnemy(0, new Vector3(-160, 80),NS);
     //                InstantiateEnemy(0, new Vector3(-120, 40), NS);
     //                InstantiateEnemy(0, new Vector3(-80, 80), NS);
     //                InstantiateEnemy(0, new Vector3(-40, 40), NS);
     //                InstantiateEnemy(0, new Vector3(0, 80), NS);
     //                InstantiateEnemy(0, new Vector3(40, 40), NS);
     //                InstantiateEnemy(0, new Vector3(80, 80), NS);
     //                InstantiateEnemy(0, new Vector3(120, 40), NS);
     //                InstantiateEnemy(0, new Vector3(160, 80), NS);
     //                InstantiateSquare(0, new Vector3(-60, -40), NS, 3);
     //                InstantiateSquare(0, new Vector3(60, -40), NS, 3);
     //                break;
     //            case 2:
     //                InstantiateEnemy(0, new Vector3(0, 160), NS);
     //                InstantiateEnemy(0, new Vector3(0, 80), NS);
     //                InstantiateEnemy(0, new Vector3(0, 0), NS);
     //                InstantiateEnemy(17, new Vector3(140, 120), YB);
     //                InstantiateEnemy(17, new Vector3(-140, 120), YB);
     //                InstantiateEnemy(0, new Vector3(0, -80), NS);
     //                InstantiateEnemy(17, new Vector3(80, 40), YB);
     //                InstantiateEnemy(17, new Vector3(-80, 40), YB);
     //                break;
     //            case 3:
     //                InstantiateSquare(17, new Vector3(0, 40), YB, 3);
     //                break;
     //            case 4:
     //                InstantiateSquare(0, new Vector3(-100, 100), NS, 4);
     //                InstantiateSquare(0, new Vector3(100, 100), NS, 4);
     //                InstantiateSquare(0, new Vector3(100, -100), NS, 4);
     //                InstantiateSquare(0, new Vector3(-100, -100), NS, 4);
     //                InstantiateEnemy(1, new Vector3(0, 160), BS);
     //                InstantiateEnemy(1, new Vector3(0, 120), BS);
     //                InstantiateEnemy(1, new Vector3(0, 80), BS);
     //                InstantiateEnemy(1, new Vector3(0, 40), BS);
     //                InstantiateEnemy(1, new Vector3(0, 0), BS);
     //                InstantiateEnemy(1, new Vector3(0, -40), BS);
     //                InstantiateEnemy(1, new Vector3(0, -80), BS);
     //                InstantiateEnemy(1, new Vector3(-160, 0), BS);
     //                InstantiateEnemy(1, new Vector3(-120, 0), BS);
     //                InstantiateEnemy(1, new Vector3(-80, 0), BS);
     //                InstantiateEnemy(1, new Vector3(-40, 0), BS);
     //                InstantiateEnemy(1, new Vector3(0, 0), BS);
     //                InstantiateEnemy(1, new Vector3(40, 0), BS);
     //                InstantiateEnemy(1, new Vector3(80, 0), BS);
     //                InstantiateEnemy(1, new Vector3(120, 0), BS);
     //                InstantiateEnemy(1, new Vector3(160, 0), BS);
     //                break;
     //            case 5:
     //                InstantiateSquare(0, new Vector3(-100, 100), NS, 4);
     //                InstantiateSquare(0, new Vector3(100, 100), NS, 4);
     //                InstantiateSquare(0, new Vector3(100, -100), NS, 4);
     //                InstantiateSquare(0, new Vector3(-100, -100), NS, 4);
     //                InstantiateEnemy(15, new Vector3(0, 160), NB);
     //                InstantiateEnemy(15, new Vector3(0, 120), NB);
     //                InstantiateEnemy(15, new Vector3(0, 80), NB);
     //                InstantiateEnemy(15, new Vector3(0, 40), NB);
     //                InstantiateEnemy(15, new Vector3(0, 0), NB);
     //                InstantiateEnemy(15, new Vector3(0, -40), NB);
     //                InstantiateEnemy(15, new Vector3(0, -80), NB);
     //                InstantiateEnemy(15, new Vector3(-160, 0), NB);
     //                InstantiateEnemy(15, new Vector3(-120, 0), NB);
     //                InstantiateEnemy(15, new Vector3(-80, 0), NB);
     //                InstantiateEnemy(15, new Vector3(-40, 0), NB);
     //                InstantiateEnemy(15, new Vector3(0, 0), NB);
     //                InstantiateEnemy(15, new Vector3(40, 0), NB);
     //                InstantiateEnemy(15, new Vector3(80, 0), NB);
     //                InstantiateEnemy(15, new Vector3(120, 0), NB);
     //                InstantiateEnemy(15, new Vector3(160, 0), NB);
     //                break;
     //            case 6:
     //                InstantiateEnemy(0, new Vector3(0, 160), NS);
     //                InstantiateEnemy(0, new Vector3(0, 80), NS);
     //                InstantiateEnemy(0, new Vector3(0, 0), NS);
     //                InstantiateEnemy(17, new Vector3(140, 120), YB);
     //                InstantiateEnemy(17, new Vector3(-140, 120), YB);
     //                InstantiateEnemy(0, new Vector3(0, -80), NS);
     //                InstantiateEnemy(17, new Vector3(80, 40), YB);
     //                InstantiateEnemy(17, new Vector3(-80, 40), YB);
     //                break;
     //            case 7:
     //                InstantiateEnemy(0, new Vector3(130, -60), NS);
     //                InstantiateEnemy(0, new Vector3(-130, -60), NS);
     //                InstantiateEnemy(0, new Vector3(60, -90), NS);
     //                InstantiateEnemy(0, new Vector3(-60, -90), NS);
     //                InstantiateEnemy(1, new Vector3(-120, -120), BS);
     //                InstantiateEnemy(1, new Vector3(120, -120), BS);
     //                InstantiateEnemy(1, new Vector3(100, 30), BS);
     //                InstantiateEnemy(1, new Vector3(-100, 30), BS);
     //                InstantiateEnemy(17, new Vector3(0, 0), YB);
     //                InstantiateEnemy(17, new Vector3(40, 90), YB);
     //                InstantiateEnemy(17, new Vector3(-40, 90), YB);
     //                InstantiateEnemy(17, new Vector3(140, 160), YB);
     //                InstantiateEnemy(17, new Vector3(-140, 160), YB);
     //                break;
     //            case 8:
     //                InstantiateEnemy(1, new Vector3(-160, 0), BS);
     //                InstantiateEnemy(1, new Vector3(-120, 120), BS);
     //                InstantiateEnemy(1, new Vector3(-80, 0), BS);
     //                InstantiateEnemy(1, new Vector3(-40, 120), BS);
     //                InstantiateEnemy(1, new Vector3(0, 0), BS);
     //                InstantiateEnemy(1, new Vector3(40, 120), BS);
     //                InstantiateEnemy(1, new Vector3(80, 0), BS);
     //                InstantiateEnemy(1, new Vector3(120, 120), BS);
     //                InstantiateEnemy(1, new Vector3(160, 0), BS);
     //                InstantiateEnemy(17, new Vector3(140, 60), YB);
     //                InstantiateEnemy(17, new Vector3(100, 60), YB);
     //                InstantiateEnemy(17, new Vector3(60, 60), YB);
     //                InstantiateEnemy(17, new Vector3(20, 60), YB);
     //                InstantiateEnemy(17, new Vector3(-20, 60), YB);
     //                InstantiateEnemy(17, new Vector3(-60, 60), YB);
     //                InstantiateEnemy(17, new Vector3(-100, 60), YB);
     //                InstantiateEnemy(17, new Vector3(-140, 60), YB);
     //                break;
     //            case 9:
     //                InstantiateSquare(0, new Vector3(-100, 100), NS, 4);
     //                InstantiateSquare(0, new Vector3(100, 100), NS, 4);
     //                InstantiateSquare(0, new Vector3(100, -100), NS, 4);
     //                InstantiateSquare(0, new Vector3(-100, -100), NS, 4);
     //                InstantiateEnemy(17, new Vector3(0, 160), YB);
     //                InstantiateEnemy(17, new Vector3(0, 120), YB);
     //                InstantiateEnemy(17, new Vector3(0, 80), YB);
     //                InstantiateEnemy(17, new Vector3(0, 40), YB);
     //                InstantiateEnemy(17, new Vector3(0, 0), YB);
     //                InstantiateEnemy(17, new Vector3(0, -40), YB);
     //                InstantiateEnemy(17, new Vector3(0, -80), YB);
     //                InstantiateEnemy(17, new Vector3(-160, 0), YB);
     //                InstantiateEnemy(17, new Vector3(-120, 0), YB);
     //                InstantiateEnemy(17, new Vector3(-80, 0), YB);
     //                InstantiateEnemy(17, new Vector3(-40, 0), YB);
     //                InstantiateEnemy(17, new Vector3(0, 0), YB);
     //                InstantiateEnemy(17, new Vector3(40, 0), YB);
     //                InstantiateEnemy(17, new Vector3(80, 0), YB);
     //                InstantiateEnemy(17, new Vector3(120, 0), YB);
     //                InstantiateEnemy(17, new Vector3(160, 0), YB);
     //                break;
     //            case 10:
     //                InstantiateEnemy(58, new Vector3(-100, 160), NSpider);
     //                InstantiateEnemy(58, new Vector3(100, 160), NSpider);
     //                InstantiateEnemy(0, new Vector3(0, 120), NS);
     //                InstantiateEnemy(58, new Vector3(-60, 80), NSpider);
     //                InstantiateEnemy(58, new Vector3(60, 80), NSpider);
     //                InstantiateEnemy(0, new Vector3(0, 40), NS);
     //                InstantiateEnemy(58, new Vector3(-120, 0), NSpider);
     //                InstantiateEnemy(58, new Vector3(120, 0), NSpider);
     //                break;
     //            case 11:
     //                InstantiateEnemy(58, new Vector3(0, 160), NSpider);
     //                InstantiateEnemy(58, new Vector3(0, 80), NSpider);
     //                InstantiateEnemy(58, new Vector3(0, 0), NSpider);
     //                InstantiateEnemy(0, new Vector3(140, 20), NS);
     //                InstantiateEnemy(0, new Vector3(-140, 20), NS);
     //                InstantiateEnemy(58, new Vector3(0, -80), NSpider);
     //                InstantiateEnemy(0, new Vector3(80, 100), NS);
     //                InstantiateEnemy(0, new Vector3(-80, 100), NS);
     //                break;
     //            case 12:
     //                InstantiateEnemy(58, new Vector3(130, -60), NSpider);
     //                InstantiateEnemy(58, new Vector3(-130, -60), NSpider);
     //                InstantiateEnemy(1, new Vector3(60, -90), BS);
     //                InstantiateEnemy(1, new Vector3(-60, -90), BS);
     //                InstantiateEnemy(58, new Vector3(-120, -120), NSpider);
     //                InstantiateEnemy(58, new Vector3(120, -120), NSpider);
     //                InstantiateEnemy(58, new Vector3(100, 30), NSpider);
     //                InstantiateEnemy(58, new Vector3(-100, 30), NSpider);
     //                InstantiateEnemy(0, new Vector3(0, -30), NS);
     //                InstantiateEnemy(58, new Vector3(40, 90), NSpider);
     //                InstantiateEnemy(58, new Vector3(-40, 90), NSpider);
     //                InstantiateEnemy(17, new Vector3(140, 160), YB);
     //                InstantiateEnemy(17, new Vector3(-140, 160), YB);
     //                break;
     //            case 13:
     //                InstantiateEnemy(58, new Vector3(-150, 0), NSpider);
     //                InstantiateEnemy(58, new Vector3(0, 75), NSpider);
     //                InstantiateEnemy(58, new Vector3(150, 0), NSpider);
     //                InstantiateEnemy(58, new Vector3(0, 0), NSpider);
     //                InstantiateEnemy(58, new Vector3(100, 160), NSpider);
     //                InstantiateEnemy(58, new Vector3(160, 100), NSpider);
     //                InstantiateEnemy(58, new Vector3(-100, 160), NSpider);
     //                InstantiateEnemy(58, new Vector3(-160, 100), NSpider);
     //                InstantiateEnemy(58, new Vector3(0, 150), NSpider);
     //                break;
     //            case 14:
     //                InstantiateEnemy(92, new Vector3(0, 80), RF);
     //                break;
  
     //            default:
     //                break;
     //        }
  
     //    }
     //}


}
