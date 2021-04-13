using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;

public class DropInfo : BASE {

   //まず，コモンスライム（ドロップテーブル）と，その確率のリストを作る．
   public Dictionary<DropTable, int> DropInfoDic = new Dictionary<DropTable, int>();

   //↓この関数はstaticに呼べる！から安心して情報を入れよう！
   public Dictionary<DropTable,int> ReturnDropInfo(ENEMY.EnemyKind enemy)
   {
       DropInfo dropInfo = new DropInfo();
       //ここにすべて情報をぶちこんでしまう．
       switch (enemy)
       {
            case ENEMY.EnemyKind.NormalSlime:
               dropInfo.DropInfoDic.Add(DropTable.CommonSlime, 200);
               dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 200);
               dropInfo.DropInfoDic.Add(DropTable.nothing, 9600);
               break;
            case ENEMY.EnemyKind.BigSlime:
               dropInfo.DropInfoDic.Add(DropTable.CommonSlime, 400);
               dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 400);
               dropInfo.DropInfoDic.Add(DropTable.nothing, 9200);
               break;
            case ENEMY.EnemyKind.BlueSlime:
                dropInfo.DropInfoDic.Add(DropTable.CommonSlime, 200);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 200);
                dropInfo.DropInfoDic.Add(DropTable.RareBlue, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9595);
                break;
            case ENEMY.EnemyKind.YellowSlime:
                dropInfo.DropInfoDic.Add(DropTable.CommonSlime, 200);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 200);
                dropInfo.DropInfoDic.Add(DropTable.RareYellow, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9595);
                break;
            case ENEMY.EnemyKind.GreenSlime:
                dropInfo.DropInfoDic.Add(DropTable.CommonSlime, 150);
                dropInfo.DropInfoDic.Add(DropTable.UncommonSlime, 50);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 150);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 50);
                dropInfo.DropInfoDic.Add(DropTable.RareGreen, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9595);
                break;
            case ENEMY.EnemyKind.OrangeSlime:
                dropInfo.DropInfoDic.Add(DropTable.CommonSlime, 150);
                dropInfo.DropInfoDic.Add(DropTable.UncommonSlime, 50);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 150);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 50);
                dropInfo.DropInfoDic.Add(DropTable.RareOrange, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9595);
                break;
            case ENEMY.EnemyKind.RedSlime:
                dropInfo.DropInfoDic.Add(DropTable.CommonSlime, 200);
                dropInfo.DropInfoDic.Add(DropTable.UncommonSlime, 50);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 250);
                dropInfo.DropInfoDic.Add(DropTable.RareRed, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9495);
                break;
            case ENEMY.EnemyKind.PurpleSlime:
                dropInfo.DropInfoDic.Add(DropTable.UncommonSlime, 200);
                dropInfo.DropInfoDic.Add(DropTable.RareSlime, 50);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 100);
                dropInfo.DropInfoDic.Add(DropTable.RareGeneral, 20);
                dropInfo.DropInfoDic.Add(DropTable.RarePurple, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9625);
                break;
            case ENEMY.EnemyKind.SlimeBoss:
                dropInfo.DropInfoDic.Add(DropTable.UncommonSlime, 2000);
                dropInfo.DropInfoDic.Add(DropTable.RareSlime, 200);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 2000);
                dropInfo.DropInfoDic.Add(DropTable.RareGeneral, 200);
                dropInfo.DropInfoDic.Add(DropTable.RareBlack, 50);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 5550);
                break;
                //Magical
            case ENEMY.EnemyKind.MNormalslime:
               dropInfo.DropInfoDic.Add(DropTable.CommonMagicalSlime, 200);
               dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 200);
               dropInfo.DropInfoDic.Add(DropTable.nothing, 9600);
               break;
            case ENEMY.EnemyKind.MBlueslime:
                dropInfo.DropInfoDic.Add(DropTable.CommonMagicalSlime, 200);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 200);
                dropInfo.DropInfoDic.Add(DropTable.RareBlue, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9595);
                break;
            case ENEMY.EnemyKind.MYelllowSlime:
                dropInfo.DropInfoDic.Add(DropTable.CommonMagicalSlime, 200);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 200);
                dropInfo.DropInfoDic.Add(DropTable.RareYellow, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9595);
                break;
            case ENEMY.EnemyKind.MGreenSlime:
                dropInfo.DropInfoDic.Add(DropTable.CommonMagicalSlime, 150);
                dropInfo.DropInfoDic.Add(DropTable.UncommonMagicalSlime, 50);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 150);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 50);
                dropInfo.DropInfoDic.Add(DropTable.RareGreen, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9595);
                break;
            case ENEMY.EnemyKind.MOrangeSlime:
                dropInfo.DropInfoDic.Add(DropTable.CommonMagicalSlime, 150);
                dropInfo.DropInfoDic.Add(DropTable.UncommonMagicalSlime, 50);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 150);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 50);
                dropInfo.DropInfoDic.Add(DropTable.RareOrange, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9595);
                break;
            case ENEMY.EnemyKind.MRedSlime:
                dropInfo.DropInfoDic.Add(DropTable.CommonMagicalSlime, 200);
                dropInfo.DropInfoDic.Add(DropTable.UncommonMagicalSlime, 50);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 250);
                dropInfo.DropInfoDic.Add(DropTable.RareRed, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9495);
                break;
            case ENEMY.EnemyKind.MPurpleSlime:
                dropInfo.DropInfoDic.Add(DropTable.UncommonMagicalSlime, 200);
                dropInfo.DropInfoDic.Add(DropTable.RareMagicalSlime, 50);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 200);
                dropInfo.DropInfoDic.Add(DropTable.RareGeneral, 50);
                dropInfo.DropInfoDic.Add(DropTable.RarePurple, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9595);
                break;
            case ENEMY.EnemyKind.WizardSlime:
                dropInfo.DropInfoDic.Add(DropTable.UncommonMagicalSlime, 2000);
                dropInfo.DropInfoDic.Add(DropTable.RareMagicalSlime, 200);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 2000);
                dropInfo.DropInfoDic.Add(DropTable.RareGeneral, 200);
                dropInfo.DropInfoDic.Add(DropTable.RareBlack, 50);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 5550);
                break;




            case ENEMY.EnemyKind.NormalBat:
                dropInfo.DropInfoDic.Add(DropTable.CommonBat, 200);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 200);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9600);
                break;
            case ENEMY.EnemyKind.BlueBat:
                dropInfo.DropInfoDic.Add(DropTable.CommonBat, 200);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 200);
                dropInfo.DropInfoDic.Add(DropTable.RareBlue, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9595);
                break;
            case ENEMY.EnemyKind.YellowBat:
                dropInfo.DropInfoDic.Add(DropTable.CommonBat, 200);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 200);
                dropInfo.DropInfoDic.Add(DropTable.RareYellow, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9595);
                break;
            case ENEMY.EnemyKind.GreenBat:
                dropInfo.DropInfoDic.Add(DropTable.CommonBat, 150);
                dropInfo.DropInfoDic.Add(DropTable.UncommonBat, 50);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 150);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 50);
                dropInfo.DropInfoDic.Add(DropTable.RareGreen, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9595);
                break;
            case ENEMY.EnemyKind.RedBat:
                dropInfo.DropInfoDic.Add(DropTable.CommonBat, 200);
                dropInfo.DropInfoDic.Add(DropTable.UncommonBat, 50);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 200);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 50);
                dropInfo.DropInfoDic.Add(DropTable.RareRed, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9495);
                break;
            case ENEMY.EnemyKind.OrangeBat:
                dropInfo.DropInfoDic.Add(DropTable.CommonBat, 150);
                dropInfo.DropInfoDic.Add(DropTable.UncommonBat, 50);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 150);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 50);
                dropInfo.DropInfoDic.Add(DropTable.RareOrange, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9595);
                break;
            case ENEMY.EnemyKind.PurpleBat:
                dropInfo.DropInfoDic.Add(DropTable.UncommonBat, 200);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 100);
                dropInfo.DropInfoDic.Add(DropTable.RarePurple, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9695);
                break;
            case ENEMY.EnemyKind.BlackBat:
                dropInfo.DropInfoDic.Add(DropTable.UncommonBat, 2000);
                dropInfo.DropInfoDic.Add(DropTable.RareBat, 100);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 2000);
                dropInfo.DropInfoDic.Add(DropTable.RareGeneral, 100);
                dropInfo.DropInfoDic.Add(DropTable.RareBlack, 50);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 5750);
                break;
            case ENEMY.EnemyKind.NormalSpider:
                dropInfo.DropInfoDic.Add(DropTable.CommonSpider, 200);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 200);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9600);
                break;
            case ENEMY.EnemyKind.BlueSpider:
                dropInfo.DropInfoDic.Add(DropTable.CommonSpider, 200);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 200);
                dropInfo.DropInfoDic.Add(DropTable.RareBlue, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9595);
                break;
            case ENEMY.EnemyKind.YellowSpider:
                dropInfo.DropInfoDic.Add(DropTable.CommonSpider, 200);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 200);
                dropInfo.DropInfoDic.Add(DropTable.RareYellow, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9595);
                break;
            case ENEMY.EnemyKind.GreenSpider:
                dropInfo.DropInfoDic.Add(DropTable.CommonSpider, 150);
                dropInfo.DropInfoDic.Add(DropTable.UncommonSpider, 50);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 150);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 50);
                dropInfo.DropInfoDic.Add(DropTable.RareGreen, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9595);
                break;
            case ENEMY.EnemyKind.RedSpider:
                dropInfo.DropInfoDic.Add(DropTable.CommonSpider, 200);
                dropInfo.DropInfoDic.Add(DropTable.UncommonSpider, 50);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 200);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 50);
                dropInfo.DropInfoDic.Add(DropTable.RareRed, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9495);
                break;
            case ENEMY.EnemyKind.PurpleSpider:
                dropInfo.DropInfoDic.Add(DropTable.UncommonSpider, 200);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 100);
                dropInfo.DropInfoDic.Add(DropTable.RarePurple, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9695);
                break;
            case ENEMY.EnemyKind.SpiderQueen:
                dropInfo.DropInfoDic.Add(DropTable.UncommonSpider, 2500);
                dropInfo.DropInfoDic.Add(DropTable.RareSpider, 200);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 2500);
                dropInfo.DropInfoDic.Add(DropTable.RareGeneral, 200);
                dropInfo.DropInfoDic.Add(DropTable.RareBlack, 50);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 4550);
                break;
            case ENEMY.EnemyKind.NormalFairy:
                dropInfo.DropInfoDic.Add(DropTable.CommonFairy, 200);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 200);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9600);
                break;
            case ENEMY.EnemyKind.BlueFairy:
                dropInfo.DropInfoDic.Add(DropTable.CommonFairy, 200);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 200);
                dropInfo.DropInfoDic.Add(DropTable.RareBlue, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9595);
                break;
            case ENEMY.EnemyKind.YellowFairy:
                dropInfo.DropInfoDic.Add(DropTable.CommonFairy, 200);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 200);
                dropInfo.DropInfoDic.Add(DropTable.RareYellow, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9595);
                break;
            case ENEMY.EnemyKind.GreenFairy:
                dropInfo.DropInfoDic.Add(DropTable.CommonFairy, 150);
                dropInfo.DropInfoDic.Add(DropTable.UncommonFairy, 50);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 150);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 50);
                dropInfo.DropInfoDic.Add(DropTable.RareGreen, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9595);
                break;
            case ENEMY.EnemyKind.OrangeFairy:
                dropInfo.DropInfoDic.Add(DropTable.CommonFairy, 150);
                dropInfo.DropInfoDic.Add(DropTable.UncommonFairy, 50);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 150);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 50);
                dropInfo.DropInfoDic.Add(DropTable.RareOrange, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9595);
                break;
            case ENEMY.EnemyKind.RedFairy:
                dropInfo.DropInfoDic.Add(DropTable.CommonFairy, 200);
                dropInfo.DropInfoDic.Add(DropTable.UncommonFairy, 50);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 200);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 50);
                dropInfo.DropInfoDic.Add(DropTable.RareRed, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9495);
                break;
            case ENEMY.EnemyKind.PurpleFairy:
                dropInfo.DropInfoDic.Add(DropTable.UncommonFairy, 200);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 100);
                dropInfo.DropInfoDic.Add(DropTable.RarePurple, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9695);
                break;
            case ENEMY.EnemyKind.BlackFairy:
                dropInfo.DropInfoDic.Add(DropTable.UncommonFairy, 2500);
                dropInfo.DropInfoDic.Add(DropTable.RareFairy, 200);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 2500);
                dropInfo.DropInfoDic.Add(DropTable.RareGeneral, 200);
                dropInfo.DropInfoDic.Add(DropTable.RareBlack, 50);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 4550);
                break;
                //Fox
            case ENEMY.EnemyKind.OrangeFox:
                dropInfo.DropInfoDic.Add(DropTable.CommonFox, 200);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 200);
                dropInfo.DropInfoDic.Add(DropTable.RareOrange, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9595);
                break;
            case ENEMY.EnemyKind.YellowFox:
                dropInfo.DropInfoDic.Add(DropTable.CommonFox, 200);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 200);
                dropInfo.DropInfoDic.Add(DropTable.RareYellow, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9595);
                break;
            case ENEMY.EnemyKind.GreenFox:
                dropInfo.DropInfoDic.Add(DropTable.UncommonFox, 200);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 150);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 50);
                dropInfo.DropInfoDic.Add(DropTable.RareGreen, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9595);
                break;
            case ENEMY.EnemyKind.BlueFox:
                dropInfo.DropInfoDic.Add(DropTable.UncommonFox, 200);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 150);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 50);
                dropInfo.DropInfoDic.Add(DropTable.RareBlue, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9595);
                break;
            case ENEMY.EnemyKind.RedFox:
                dropInfo.DropInfoDic.Add(DropTable.UncommonFox, 200);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 100);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 100);
                dropInfo.DropInfoDic.Add(DropTable.RareRed, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9595);
                break;
            case ENEMY.EnemyKind.PurpleFox:
                dropInfo.DropInfoDic.Add(DropTable.UncommonFox, 200);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 50);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 150);
                dropInfo.DropInfoDic.Add(DropTable.RarePurple, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9595);
                break;
            case ENEMY.EnemyKind.WhiteFox:
                dropInfo.DropInfoDic.Add(DropTable.UncommonFox, 200);
                dropInfo.DropInfoDic.Add(DropTable.RareFox, 10);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 50);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 150);
                dropInfo.DropInfoDic.Add(DropTable.RareGeneral, 10);
                dropInfo.DropInfoDic.Add(DropTable.RareWhite, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9575);
                break;
            case ENEMY.EnemyKind.SkyFox:
                dropInfo.DropInfoDic.Add(DropTable.UncommonFox, 200);
                dropInfo.DropInfoDic.Add(DropTable.RareFox, 10);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 50);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 150);
                dropInfo.DropInfoDic.Add(DropTable.RareGeneral, 10);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9580);
                break;
            case ENEMY.EnemyKind.BlackFox:
                dropInfo.DropInfoDic.Add(DropTable.UncommonFox, 200);
                dropInfo.DropInfoDic.Add(DropTable.RareFox, 10);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 50);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 150);
                dropInfo.DropInfoDic.Add(DropTable.RareGeneral, 10);
                dropInfo.DropInfoDic.Add(DropTable.RareBlack, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9575);
                break;
            case ENEMY.EnemyKind.WhiteNineTailedFox:
                dropInfo.DropInfoDic.Add(DropTable.UncommonFox, 250);
                dropInfo.DropInfoDic.Add(DropTable.RareFox, 20);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 250);
                dropInfo.DropInfoDic.Add(DropTable.RareGeneral, 20);
                dropInfo.DropInfoDic.Add(DropTable.RareWhite, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9455);
                break;

                //DevilFish
            case ENEMY.EnemyKind.BlueDevilFish:
                dropInfo.DropInfoDic.Add(DropTable.CommonDevilFish, 200);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 200);
                dropInfo.DropInfoDic.Add(DropTable.RareBlue, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9595);
                break;
            case ENEMY.EnemyKind.GreenDevilFish:
                dropInfo.DropInfoDic.Add(DropTable.CommonDevilFish, 200);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 200);
                dropInfo.DropInfoDic.Add(DropTable.RareGreen, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9595);
                break;
            case ENEMY.EnemyKind.OrangeDevilFish:
                dropInfo.DropInfoDic.Add(DropTable.CommonDevilFish, 200);
                dropInfo.DropInfoDic.Add(DropTable.UncommonDevilFish, 50);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 150);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 50);
                dropInfo.DropInfoDic.Add(DropTable.RareOrange, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9595);
                break;
            case ENEMY.EnemyKind.RedDevilFish:
                dropInfo.DropInfoDic.Add(DropTable.CommonDevilFish, 200);
                dropInfo.DropInfoDic.Add(DropTable.UncommonDevilFish, 50);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 200);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 50);
                dropInfo.DropInfoDic.Add(DropTable.RareRed, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9495);
                break;
            case ENEMY.EnemyKind.SkyDevilFish:
                dropInfo.DropInfoDic.Add(DropTable.CommonDevilFish, 50);
                dropInfo.DropInfoDic.Add(DropTable.UncommonDevilFish, 150);
                dropInfo.DropInfoDic.Add(DropTable.RareDevilFish, 10);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 50);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 150);
                dropInfo.DropInfoDic.Add(DropTable.RareGeneral, 10);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9580);
                break;
            case ENEMY.EnemyKind.YellowDevilFish:
                dropInfo.DropInfoDic.Add(DropTable.CommonDevilFish, 50);
                dropInfo.DropInfoDic.Add(DropTable.UncommonDevilFish, 150);
                dropInfo.DropInfoDic.Add(DropTable.RareDevilFish, 10);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 50);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 150);
                dropInfo.DropInfoDic.Add(DropTable.RareGeneral, 10);
                dropInfo.DropInfoDic.Add(DropTable.RareYellow, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9575);
                break;
            case ENEMY.EnemyKind.PurpleDevilFish:
                dropInfo.DropInfoDic.Add(DropTable.UncommonDevilFish, 250);
                dropInfo.DropInfoDic.Add(DropTable.RareDevilFish, 20);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 250);
                dropInfo.DropInfoDic.Add(DropTable.RareGeneral, 20);
                dropInfo.DropInfoDic.Add(DropTable.RareWhite, 5);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9455);
                break;
            //Blob
            case ENEMY.EnemyKind.BlueBlob:
                dropInfo.DropInfoDic.Add(DropTable.CommonBall, 99);
                dropInfo.DropInfoDic.Add(DropTable.RareBall, 1);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 199);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 1);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9700);
                break;
            case ENEMY.EnemyKind.RedBlob:
                dropInfo.DropInfoDic.Add(DropTable.CommonBall, 99);
                dropInfo.DropInfoDic.Add(DropTable.RareBall, 1);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 199);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 1);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9700);
                break;
            case ENEMY.EnemyKind.BlueCatBlob:
                dropInfo.DropInfoDic.Add(DropTable.CommonBall, 95);
                dropInfo.DropInfoDic.Add(DropTable.RareBall, 5);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 100);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 100);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9700);
                break;
            case ENEMY.EnemyKind.RedCatBlob:
                dropInfo.DropInfoDic.Add(DropTable.CommonBall, 95);
                dropInfo.DropInfoDic.Add(DropTable.RareBall, 5);
                dropInfo.DropInfoDic.Add(DropTable.CommonGeneral, 100);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 100);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9700);
                break;
            case ENEMY.EnemyKind.BlueRabbitBlob:
                dropInfo.DropInfoDic.Add(DropTable.CommonBall, 90);
                dropInfo.DropInfoDic.Add(DropTable.RareBall, 10);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 190);
                dropInfo.DropInfoDic.Add(DropTable.RareGeneral, 10);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9700);
                break;
            case ENEMY.EnemyKind.RedRabbitBlob:
                dropInfo.DropInfoDic.Add(DropTable.CommonBall, 90);
                dropInfo.DropInfoDic.Add(DropTable.RareBall, 10);
                dropInfo.DropInfoDic.Add(DropTable.UncommonGeneral, 190);
                dropInfo.DropInfoDic.Add(DropTable.RareGeneral, 10);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9700);
                break;

            //Challenge
            case ENEMY.EnemyKind.SlimeKing:
                dropInfo.DropInfoDic.Add(DropTable.ChallengeGeneral, 100);
                dropInfo.DropInfoDic.Add(DropTable.ChallengeSlime, 400);
                dropInfo.DropInfoDic.Add(DropTable.RareSlime, 2000);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 7500);
                break;
            case ENEMY.EnemyKind.Golem:
                dropInfo.DropInfoDic.Add(DropTable.ChallengeGeneral, 100);
                dropInfo.DropInfoDic.Add(DropTable.ChallengeGolem, 400);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9500);
                break;
            case ENEMY.EnemyKind.Deathpider:
                dropInfo.DropInfoDic.Add(DropTable.ChallengeGeneral, 100);
                dropInfo.DropInfoDic.Add(DropTable.ChallengeSpider, 400);
                dropInfo.DropInfoDic.Add(DropTable.RareSpider, 2000);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 7500);
                break;
            case ENEMY.EnemyKind.FairyQueen:
                dropInfo.DropInfoDic.Add(DropTable.ChallengeGeneral, 100);
                dropInfo.DropInfoDic.Add(DropTable.ChallengeFairy, 400);
                dropInfo.DropInfoDic.Add(DropTable.RareFairy, 2000);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 7500);
                break;
            case ENEMY.EnemyKind.Bananoon:
                dropInfo.DropInfoDic.Add(DropTable.ChallengeGeneral, 100);
                dropInfo.DropInfoDic.Add(DropTable.ChallengeBananoon, 400);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9500);
                break;
            case ENEMY.EnemyKind.Octobaddie:
                dropInfo.DropInfoDic.Add(DropTable.ChallengeGeneral, 100);
                dropInfo.DropInfoDic.Add(DropTable.ChallengeOctobaddie, 400);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9500);
                break;
            case ENEMY.EnemyKind.DistortionSlime:
                dropInfo.DropInfoDic.Add(DropTable.ChallengeGeneral, 100);
                dropInfo.DropInfoDic.Add(DropTable.ChallengeDistortion, 400);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 9500);
                break;
            //MetalSlime
            case ENEMY.EnemyKind.MetalSlime:
                dropInfo.DropInfoDic.Add(DropTable.RareBlue, 1500);
                dropInfo.DropInfoDic.Add(DropTable.RareRed, 1500);
                dropInfo.DropInfoDic.Add(DropTable.RareYellow, 1500);
                dropInfo.DropInfoDic.Add(DropTable.RareGreen, 1500);
                dropInfo.DropInfoDic.Add(DropTable.RareOrange, 1500);
                dropInfo.DropInfoDic.Add(DropTable.RarePurple, 1500);
                dropInfo.DropInfoDic.Add(DropTable.ChallengeGeneral, 100);
                dropInfo.DropInfoDic.Add(DropTable.nothing, 900);
                break;
            default:
                dropInfo.DropInfoDic.Add(DropTable.nothing, 10000);
                break;
        }
        return ModifiedDropInfo(dropInfo.DropInfoDic,enemy);   
   }
   
    public Dictionary<DropTable,int> ModifiedDropInfo(Dictionary<DropTable,int> originalInfo,ENEMY.EnemyKind enemy)
    {
        Dictionary<DropTable, int> newTable = new Dictionary<DropTable, int>();
        int tempProb = 0;
        foreach(KeyValuePair<DropTable,int> pair in originalInfo)
        {
            if(pair.Key != DropTable.nothing)
            {
                double tempValue = pair.Value * main.stats.DropFactor() *
                    (1+ calculateCaptureDropRate(main.S.totalEnemiesCaptured[(int)enemy]))
                    * (1 + main.alchemyController.dropFactor);
                //チャレンジの分だけふやす
                if (main.ZoneCtrl.EnemyAry[(int)enemy].gameObject != null && main.ZoneCtrl.EnemyAry[(int)enemy].gameObject.GetComponent<C_ENEMY>())
                {
                    tempValue *= (1+main.ZoneCtrl.EnemyAry[(int)enemy].gameObject.GetComponent<C_ENEMY>().DropModifier());
                }
                newTable.Add(pair.Key, (int)Math.Min(tempValue, 10000/originalInfo.Count));
                tempProb += (int)Math.Min(tempValue, 10000/ originalInfo.Count);
            }
            else
            {
                newTable.Add(pair.Key, 10000 - tempProb);
            }
        }
        return newTable;
    }

    public float calculateCaptureDropRate(long capturedNum)
    {
        float addRate;
        if (capturedNum <= 5)
            addRate = (float)capturedNum / 5f * 0.05f;
        else if (capturedNum <= 85)
            addRate = 0.05f + (float)(capturedNum-5) / 20f * 0.05f;
        else if ( capturedNum <= 285)
            addRate = 0.25f + (float)(capturedNum - 85) / 40f * 0.05f;
        else if ( capturedNum <= 1085)
            addRate = 0.5f + (float)(capturedNum - 285) / 80f * 0.05f;
        else 
            addRate = 1f + (float)(capturedNum - 1085) / 160f * 0.05f;
        return addRate;
    }

    public ArtiCtrl.MaterialList AbsoluteDrop()
    {
        int count = 0;
        DropTable dropTable = DropTable.nothing;
        while (count <=1000)
        {
            dropTable = ChooseTable();
            if (dropTable != DropTable.nothing)
            {
                break;
            }
            count++;
        }       
        int randomNum = UnityEngine.Random.Range(0, 10000);
        int tempProb = 0;
        foreach (KeyValuePair<ArtiCtrl.MaterialList, int> pair in EachTableList(dropTable))
        {
            tempProb += pair.Value;
            if (randomNum <= tempProb)
            {
                main.ArtiCtrl.CurrentMaterial[pair.Key] += 1;
                if (!main.systemController.disableLootLog)
                    main.Log("Gained <color=yellow>" + main.ArtiCtrl.ConvertEnum(pair.Key));
                return pair.Key;
            }
        }
        return ArtiCtrl.MaterialList.nothing;
    }

    public ArtiCtrl.MaterialList RandomChooseMaterial(ENEMY.EnemyKind enemy)
    {
        Dictionary<DropTable, int> tempDic = new Dictionary<DropTable, int>();
        tempDic = ReturnDropInfo(enemy);
        DropTable dropTable = DropTable.CommonSlime;
        int tempCount = 0;

        while (tempCount <= 100)
        {
            dropTable = ChooseTable(tempDic);
            if (dropTable != DropTable.nothing
                && dropTable != DropTable.ChallengeGeneral
                && dropTable != DropTable.ChallengeSlime
                && dropTable != DropTable.ChallengeGolem
                && dropTable != DropTable.ChallengeSpider
                && dropTable != DropTable.ChallengeBananoon
                )
            {
                break;
            }

            tempCount++;
        }
        

        int randomNum = UnityEngine.Random.Range(0, 10000);
        int tempProb = 0;
        foreach (KeyValuePair<ArtiCtrl.MaterialList, int> pair in EachTableList(dropTable))
        {
            tempProb += pair.Value;
            if (randomNum <= tempProb)
            {
                return pair.Key;
            }
        }

        return ArtiCtrl.MaterialList.MonsterFluid; 
    }


    public Dictionary<ArtiCtrl.MaterialList, int> EachTableList(DropTable dropTable)
    {
        Dictionary<ArtiCtrl.MaterialList, int> eachTableList = new Dictionary<ArtiCtrl.MaterialList, int>();
        switch (dropTable)
        {
            case DropTable.CommonGeneral:
                eachTableList.Add(ArtiCtrl.MaterialList.MonsterFluid, 10000);
                break;
            case DropTable.UncommonGeneral:
                eachTableList.Add(ArtiCtrl.MaterialList.RelicStone, 5000);
                eachTableList.Add(ArtiCtrl.MaterialList.CarvedIdol, 5000);
                break;
            case DropTable.RareGeneral:
                eachTableList.Add(ArtiCtrl.MaterialList.BlackPearl, 100);
                eachTableList.Add(ArtiCtrl.MaterialList.AncientCoin, 9900);
                break;
            case DropTable.CommonSlime:
                eachTableList.Add(ArtiCtrl.MaterialList.OozeStainedCloth, 7500);
                eachTableList.Add(ArtiCtrl.MaterialList.GooeySludge, 2500);
                break;
            case DropTable.UncommonSlime:
                eachTableList.Add(ArtiCtrl.MaterialList.OilOfSlime, 9000);
                eachTableList.Add(ArtiCtrl.MaterialList.AcidicGoop, 1000);
                break;
            case DropTable.RareSlime:
                eachTableList.Add(ArtiCtrl.MaterialList.AcidicGoop, 5500);
                eachTableList.Add(ArtiCtrl.MaterialList.SlimeEyeBall, 2500);
                eachTableList.Add(ArtiCtrl.MaterialList.SlimeCrown, 1500);
                eachTableList.Add(ArtiCtrl.MaterialList.SlimeCore, 500);
                break;
            case DropTable.CommonMagicalSlime:
                eachTableList.Add(ArtiCtrl.MaterialList.OozeStainedCloth, 7500);
                eachTableList.Add(ArtiCtrl.MaterialList.GooeySludge, 2400);
                eachTableList.Add(ArtiCtrl.MaterialList.EnchantedCloth, 100);
                break;
            case DropTable.UncommonMagicalSlime:
                eachTableList.Add(ArtiCtrl.MaterialList.OilOfSlime, 8000);
                eachTableList.Add(ArtiCtrl.MaterialList.AcidicGoop, 1500);
                eachTableList.Add(ArtiCtrl.MaterialList.GlowingSludge, 500);
                break;
            case DropTable.RareMagicalSlime:
                eachTableList.Add(ArtiCtrl.MaterialList.SlimeEyeBall, 5000);
                eachTableList.Add(ArtiCtrl.MaterialList.RuinedSpellBook, 2500);
                eachTableList.Add(ArtiCtrl.MaterialList.OddMagicalHat, 2000);
                eachTableList.Add(ArtiCtrl.MaterialList.MagicSlimeCore, 500);
                break;
            case DropTable.RareBlue:
                eachTableList.Add(ArtiCtrl.MaterialList.FrostShard, 9000);
                eachTableList.Add(ArtiCtrl.MaterialList.FrostCrystal, 1000);
                break;
            case DropTable.RareRed:
                eachTableList.Add(ArtiCtrl.MaterialList.FlameShard, 9000);
                eachTableList.Add(ArtiCtrl.MaterialList.FlameCrystal, 1000);
                break;
            case DropTable.RareYellow:
                eachTableList.Add(ArtiCtrl.MaterialList.LightningShard, 9000);
                eachTableList.Add(ArtiCtrl.MaterialList.LightningCrystal, 1000);
                break;
            case DropTable.RareGreen:
                eachTableList.Add(ArtiCtrl.MaterialList.NatureShard, 9000);
                eachTableList.Add(ArtiCtrl.MaterialList.NatureCrystal, 1000);
                break;
            case DropTable.RarePurple:
                eachTableList.Add(ArtiCtrl.MaterialList.PoisonShard, 9000);
                eachTableList.Add(ArtiCtrl.MaterialList.PoisonCrystal, 1000);
                break;
            case DropTable.RareOrange:
                eachTableList.Add(ArtiCtrl.MaterialList.GoldenShard, 9000);
                eachTableList.Add(ArtiCtrl.MaterialList.GoldenCrystal, 1000);
                break;
            case DropTable.RareWhite:
                eachTableList.Add(ArtiCtrl.MaterialList.LifeShard, 9000);
                eachTableList.Add(ArtiCtrl.MaterialList.LifeCrystal, 1000);
                break;
            case DropTable.RareBlack:
                eachTableList.Add(ArtiCtrl.MaterialList.ManaShard, 9000);
                eachTableList.Add(ArtiCtrl.MaterialList.ManaCrystal, 1000);
                break;
            case DropTable.CommonBat:
                eachTableList.Add(ArtiCtrl.MaterialList.BatPelt, 5000);
                eachTableList.Add(ArtiCtrl.MaterialList.BatWing, 5000);
                break;
            case DropTable.UncommonBat:
                eachTableList.Add(ArtiCtrl.MaterialList.BatTooth, 7500);
                eachTableList.Add(ArtiCtrl.MaterialList.BatFeet, 2500);
                break;
            case DropTable.RareBat:
                eachTableList.Add(ArtiCtrl.MaterialList.BatFeet, 5000);
                eachTableList.Add(ArtiCtrl.MaterialList.IntactBatHead, 2500);
                eachTableList.Add(ArtiCtrl.MaterialList.BatHeart, 5000);
                eachTableList.Add(ArtiCtrl.MaterialList.BatCore, 2500);
                break;
            case DropTable.CommonSpider:
                eachTableList.Add(ArtiCtrl.MaterialList.SpiderBlood, 9000);
                eachTableList.Add(ArtiCtrl.MaterialList.SpiderSilk, 1000);
                break;
            case DropTable.UncommonSpider:
                eachTableList.Add(ArtiCtrl.MaterialList.SpiderFang, 7500);
                eachTableList.Add(ArtiCtrl.MaterialList.SpiderLeg, 2500);
                break;
            case DropTable.RareSpider:
                eachTableList.Add(ArtiCtrl.MaterialList.VenomSoakedCloth, 7500);
                eachTableList.Add(ArtiCtrl.MaterialList.SpiderHeart, 2000);
                eachTableList.Add(ArtiCtrl.MaterialList.WebbedCore, 500);
                break;
            case DropTable.CommonFairy:
                eachTableList.Add(ArtiCtrl.MaterialList.FairyDust, 9500);
                eachTableList.Add(ArtiCtrl.MaterialList.EnchantedCloth, 500);
                break;
            case DropTable.UncommonFairy:
                eachTableList.Add(ArtiCtrl.MaterialList.FairyWing, 7500);
                eachTableList.Add(ArtiCtrl.MaterialList.FairyCoin, 2500);
                break;
            case DropTable.RareFairy:
                eachTableList.Add(ArtiCtrl.MaterialList.BloodOfFairy, 5000);
                eachTableList.Add(ArtiCtrl.MaterialList.FairyHeart, 3500);
                eachTableList.Add(ArtiCtrl.MaterialList.MysticGemStone, 1500);
                break;
            case DropTable.CommonFox:
                eachTableList.Add(ArtiCtrl.MaterialList.FoxPelt, 8500);
                eachTableList.Add(ArtiCtrl.MaterialList.FoxTail, 1500);
                break;
            case DropTable.UncommonFox:
                eachTableList.Add(ArtiCtrl.MaterialList.FoxTail, 6000);
                eachTableList.Add(ArtiCtrl.MaterialList.FoxEar, 3000);
                eachTableList.Add(ArtiCtrl.MaterialList.FoxEye, 1000);
                break;
            case DropTable.RareFox:
                eachTableList.Add(ArtiCtrl.MaterialList.IntactNineTail, 6000);
                eachTableList.Add(ArtiCtrl.MaterialList.WhiteFoxPelt, 2500);
                eachTableList.Add(ArtiCtrl.MaterialList.FoxHeart, 1000);
                eachTableList.Add(ArtiCtrl.MaterialList.FoxCore, 500);
                break;
            case DropTable.CommonDevilFish:
                eachTableList.Add(ArtiCtrl.MaterialList.FishScales, 10000);
                break;
            case DropTable.UncommonDevilFish:
                eachTableList.Add(ArtiCtrl.MaterialList.SharpFin, 7500);
                eachTableList.Add(ArtiCtrl.MaterialList.FishTeeth, 2500);
                break;
            case DropTable.RareDevilFish:
                eachTableList.Add(ArtiCtrl.MaterialList.FishTail, 7500);
                eachTableList.Add(ArtiCtrl.MaterialList.SmallTreasureChest, 2000);
                eachTableList.Add(ArtiCtrl.MaterialList.DevilFishCore, 500);
                break;
            //Blob
            case DropTable.CommonBall:
                eachTableList.Add(ArtiCtrl.MaterialList.RubberyBlob, 10000);
                break;
            case DropTable.RareBall:
                eachTableList.Add(ArtiCtrl.MaterialList.MiniatureSword, 9500);
                eachTableList.Add(ArtiCtrl.MaterialList.BallCore, 500);
                break;

            //Challenge
            case DropTable.ChallengeGeneral:
                eachTableList.Add(ArtiCtrl.MaterialList.BlackPearl, 10000);
                break;
            case DropTable.ChallengeSlime:
                eachTableList.Add(ArtiCtrl.MaterialList.ShinySlimeCrown, 7500);
                eachTableList.Add(ArtiCtrl.MaterialList.SlimeSceptre, 2400);
                eachTableList.Add(ArtiCtrl.MaterialList.SlimeKingCore, 100);
                break;
            case DropTable.ChallengeGolem:
                eachTableList.Add(ArtiCtrl.MaterialList.RobustBone, 7500);
                eachTableList.Add(ArtiCtrl.MaterialList.GolemShard, 2400);
                eachTableList.Add(ArtiCtrl.MaterialList.GolemCore, 100);
                break;
            case DropTable.ChallengeSpider:
                eachTableList.Add(ArtiCtrl.MaterialList.PotentVenomSample, 7500);
                eachTableList.Add(ArtiCtrl.MaterialList.SpiderIronSilk, 2400);
                eachTableList.Add(ArtiCtrl.MaterialList.DeathpiderCore, 100);
                break;
            case DropTable.ChallengeFairy:
                eachTableList.Add(ArtiCtrl.MaterialList.FairyQueenDust, 7500);
                eachTableList.Add(ArtiCtrl.MaterialList.EnchantedSapling, 2400);
                eachTableList.Add(ArtiCtrl.MaterialList.FairyQueenCore, 100);
                break;
            case DropTable.ChallengeBananoon:
                eachTableList.Add(ArtiCtrl.MaterialList.RottenBanana, 7500);
                eachTableList.Add(ArtiCtrl.MaterialList.RipeBanana, 2400);
                eachTableList.Add(ArtiCtrl.MaterialList.BananoonCore, 100);
                break;
            case DropTable.ChallengeOctobaddie:
                eachTableList.Add(ArtiCtrl.MaterialList.SeveredTentacle, 7500);
                eachTableList.Add(ArtiCtrl.MaterialList.OctopusEye, 2400);
                eachTableList.Add(ArtiCtrl.MaterialList.OctobaddieCore, 100);
                break;
            case DropTable.ChallengeDistortion:
                eachTableList.Add(ArtiCtrl.MaterialList.DarkMatter, 7500);
                eachTableList.Add(ArtiCtrl.MaterialList.GrotesqueEye, 2400);
                eachTableList.Add(ArtiCtrl.MaterialList.OctobaddieCore, 100);
                break;

            default:
                break;
        }
        return eachTableList;

    }

    public string[] showDropInfo(ENEMY.EnemyKind enemy)
    {
        string tempText = "";
        string tempText2 = "";
        int tempIndex = 0;

        foreach (KeyValuePair<DropTable, int> key in ReturnDropInfo(enemy))
        {
            if (key.Key == DropTable.nothing)
                continue;
            foreach(KeyValuePair<ArtiCtrl.MaterialList,int> pair in EachTableList(key.Key))
            {
                if(tempIndex == 0)  
                {
                    if (main.S.isDropped[(int)pair.Key])
                    {
                        tempText += "- " + main.ArtiCtrl.ConvertEnum(pair.Key);
                    }
                    else
                    {
                        tempText += "- " + "???";
                    }
                    tempText2 += percent((float)pair.Value / 10000*((float)key.Value/10000));
                }
                else
                {
                    if (main.S.isDropped[(int)pair.Key])
                    {
                        tempText += "\n- " + main.ArtiCtrl.ConvertEnum(pair.Key);
                    }
                    else
                    {
                        tempText += "\n- " + "???";
                    }
                    tempText2 += "\n" + percent((float)pair.Value / 10000*((float)key.Value / 10000));
                }
                tempIndex++;
            }
        }

        return new string[] { tempText, tempText2 };
    }

    public  string percent(double d)
    {
        if (d == 0)
            return 0 + "%";

        return (d * 100).ToString("F3") + "%";

    }

    public enum DropTable
   {
       nothing,
       RareBlue,
       RareRed,
       RareYellow,
       RareGreen,
       RarePurple,
       RareOrange,
       RareWhite,
       RareBlack,
       CommonGeneral,
       UncommonGeneral,
       RareGeneral,
       CommonSlime,
       UncommonSlime,
       RareSlime,
       CommonBat,
       UncommonBat,
       RareBat,
       CommonFairy,
       UncommonFairy,
       RareFairy,
       CommonSpider,
       UncommonSpider,
       RareSpider,
       CommonMagicalSlime,
       UncommonMagicalSlime,
       RareMagicalSlime,
       CommonDevilFish,
       UncommonDevilFish,
       RareDevilFish,
       CommonBall,
       UncommonBall,
       RareBall,
       CommonFox,
       UncommonFox,
       RareFox,
       ChallengeGeneral,
       ChallengeSlime,
       ChallengeGolem,
       MetalSlime,
       ChallengeSpider,
       ChallengeFairy,
       ChallengeBananoon,
       ChallengeOctobaddie,
       ChallengeDistortion
   }
   //死んだときのドロップの処理を作る．
   public DropTable ChooseTable()
   {
       int randomNum = UnityEngine.Random.Range(0, 10000);
       int tempProb = 0;
        foreach (KeyValuePair<DropTable,int> pair in DropInfoDic)
       {
           tempProb += pair.Value;
           if (randomNum <= tempProb)
           {
               return pair.Key;
           }
       }
       return DropTable.nothing;
   }
   public DropTable ChooseTable(Dictionary<DropTable,int> table)
   {
       int randomNum = UnityEngine.Random.Range(0, 10000);
       int tempProb = 0;
       foreach (KeyValuePair<DropTable, int> pair in table)
       {
           tempProb += pair.Value;
           if (randomNum <= tempProb)
           {
               return pair.Key;
           }
       }
       return DropTable.nothing;
   }

    int tempProb = 0;
    int dropNum;

    //通常のドロップの処理
    public void Drop()
   {
        int randomNum = UnityEngine.Random.Range(0, 10000);
        tempProb = 0;
        DropTable dropTable = ChooseTable();
       foreach (KeyValuePair<ArtiCtrl.MaterialList, int> pair in EachTableList(dropTable))
       {
           tempProb += pair.Value;
           if(randomNum <= tempProb)
           {
                if (!main.isDropped[0])//これは追加するたびに
                {
                    main.isDropped[0] = true;
                }
                else if (!main.isDropped[1])
                {
                    main.isDropped[1] = true;
                }
                else if (main.SR.P_AngelDistruction && !main.isDropped[2])
                {
                    main.isDropped[2] = true;
                }
                else if (main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.Greedy].GetCurrentValue() > 0 && !main.isDropped[3])
                {
                    main.isDropped[3] = true;
                }
                else if (main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.Greedy].GetCurrentValue() > 1 && !main.isDropped[4])
                {
                    main.isDropped[4] = true;
                }
                else if (main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.Greedy].GetCurrentValue() > 2 && !main.isDropped[5])
                {
                    main.isDropped[5] = true;
                }
                else if (main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.Greedy].GetCurrentValue() > 3 && !main.isDropped[6])
                {
                    main.isDropped[6] = true;
                }
                else if (main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.Greedy].GetCurrentValue() > 4 && !main.isDropped[7])
                {
                    main.isDropped[7] = true;
                }
                else if (main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.Greedy].GetCurrentValue() > 5 && !main.isDropped[8])
                {
                    main.isDropped[8] = true;
                }
                else if (main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.Greedy].GetCurrentValue() > 6 && !main.isDropped[9])
                {
                    main.isDropped[9] = true;
                }
                else if (main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.Greedy].GetCurrentValue() > 7 && !main.isDropped[10])
                {
                    main.isDropped[10] = true;
                }
                else if (main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.Greedy].GetCurrentValue() > 8 && !main.isDropped[11])
                {
                    main.isDropped[11] = true;
                }
                else if (main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.Greedy].GetCurrentValue() > 9 && !main.isDropped[12])
                {
                    main.isDropped[12] = true;
                }
                else if (main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.Greedy].GetCurrentValue() > 10 && !main.isDropped[13])
                {
                    main.isDropped[13] = true;
                }
                else if (main.NewArtifacts[(int)ARTIFACT.ArtifactName.GoldenAmulet].isEquipped)
                {
                    if (main.NewArtifacts[(int)ARTIFACT.ArtifactName.GoldenAmulet].EvolutionNum >= 0 && !main.isDropped[14])
                    {
                        main.isDropped[14] = true;
                    }
                    else if (main.NewArtifacts[(int)ARTIFACT.ArtifactName.GoldenAmulet].EvolutionNum >= 1 && !main.isDropped[15])
                    {
                        main.isDropped[15] = true;
                    }
                    else if (main.NewArtifacts[(int)ARTIFACT.ArtifactName.GoldenAmulet].EvolutionNum >= 2 && !main.isDropped[16])
                    {
                        main.isDropped[16] = true;
                    }
                    else if (main.NewArtifacts[(int)ARTIFACT.ArtifactName.GoldenAmulet].EvolutionNum >= 3 && !main.isDropped[17])
                    {
                        main.isDropped[17] = true;
                    }
                    else if (main.NewArtifacts[(int)ARTIFACT.ArtifactName.GoldenAmulet].EvolutionNum >= 4 && !main.isDropped[18])
                    {
                        main.isDropped[18] = true;
                    }
                }
                if (main.cc.CurrentCurseId == CurseId.curse_of_monsterFluid)
                    DropMaterial(ArtiCtrl.MaterialList.MonsterFluid);
                else
                    DropMaterial(pair.Key);
                return;
           }
       }
   }
   void DropMaterial(ArtiCtrl.MaterialList material)
    {
        dropNum = 1 + main.S.SR_level[(int)R_UPGRADE.SR_upgradeID.Loot];
        main.ArtiCtrl.CurrentMaterial[material] += dropNum;
        if (main.GameController.battleMode != GameController.BattleMode.challange)
        {
            main.DeathPanel.materials[material] += dropNum;
        }
        else
        {
            main.DeathPanel.C_materials[material] += dropNum;
        }
        if (!main.systemController.disableLootLog)
        {
            if (dropNum == 1)
                main.Log("Gained <color=green>" + main.ArtiCtrl.ConvertEnum(material));
            else
                main.Log("Gained <color=green>" + main.ArtiCtrl.ConvertEnum(material) + " * " + dropNum);
        }
    }

   public void DropByTable(DropTable dropTable)
   {
       int randomNum = UnityEngine.Random.Range(0, 10000);
       int tempProb = 0;
       foreach (KeyValuePair<ArtiCtrl.MaterialList, int> pair in EachTableList(dropTable))
       {
           tempProb += pair.Value;
           if (randomNum <= tempProb)
           {
               main.ArtiCtrl.CurrentMaterial[pair.Key] += 1;
               main.Log("Gained <color=orange>" + main.ArtiCtrl.ConvertEnum(pair.Key));
               return;
           }
       }
   }



    // private void OnDestroy()
    // {
    //      if (gameObject.GetComponent<ENEMY>().currentHp <= 0)
    //         Drop();
    // }



    private void Awake()
   {
       StartBASE();
   }
}
