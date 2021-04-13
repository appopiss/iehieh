using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UsefulMethod;

public class BatVillage : BASE {


    public int floorNum1 { get => main.GameController.floorNum1; set => main.GameController.floorNum1 = value; }
    public int maxFloorNum1 { get => main.GameController.maxFloorNum1; set => main.GameController.maxFloorNum1 = value; }
    public int Stage1WaveNum;
    public int Stage2WaveNum;
    public int Stage3WaveNum;
    public int Stage4WaveNum;
    public int Stage5WaveNum;
    public int Stage6WaveNum;
    public int Stage7WaveNum;
    public int Stage8WaveNum;
    public GameObject Field;
    public Main.CurrentStage currentStage { get => main.GameController.currentStage; set => main.GameController.currentStage = value; }
    //敵の出現に使う↓
    int randomEnemyNum;

    // Use this for initialization
    void Awake () {
		StartBASE();
    }

    public void StageControl(int num)
    {
        for (int i = 0; i < num; i++)
        {
            int count = i;
            main.StageChangeButtonAry[count].SetActive(false);

        }
        for (int i = num+8; i < main.StageChangeButtonAry.Length; i++)
        {
            int count = i;
            main.StageChangeButtonAry[count].SetActive(false);
        }

        if (floorNum1 < Stage2WaveNum)
        {
            currentStage = Main.CurrentStage.stage1;
        }
        else if (floorNum1 >= Stage2WaveNum && floorNum1 < Stage3WaveNum)
        {
            currentStage = Main.CurrentStage.stage2;
        }
        else if (floorNum1 >= Stage3WaveNum && floorNum1 < Stage4WaveNum)
        {
            currentStage = Main.CurrentStage.stage3;
        }
        else if (floorNum1 >= Stage4WaveNum && floorNum1 < Stage5WaveNum)
        {
            currentStage = Main.CurrentStage.stage4;
        }
        else if (floorNum1 >= Stage5WaveNum && floorNum1 < Stage6WaveNum)
        {
            currentStage = Main.CurrentStage.stage5;
        }
        else if (floorNum1 >= Stage6WaveNum && floorNum1 < Stage7WaveNum)
        {
            currentStage = Main.CurrentStage.stage6;
        }
        else if (floorNum1 >= Stage7WaveNum && floorNum1 < Stage8WaveNum)
        {
            currentStage = Main.CurrentStage.stage7;
        }
        else if (floorNum1 >= Stage8WaveNum)
        {
            currentStage = Main.CurrentStage.stage8;
        }
        else
        {
            currentStage = Main.CurrentStage.stage1;
        }


        //Stage開放
        if (maxFloorNum1 >= Stage1WaveNum)
        {
            main.StageChangeButtonAry[8].SetActive(true);
        }
        if (maxFloorNum1 >= Stage2WaveNum)
        {
            main.StageChangeButtonAry[9].SetActive(true);
        }
        if (maxFloorNum1 >= Stage3WaveNum)
        {
            main.StageChangeButtonAry[10].SetActive(true);
        }
        if (maxFloorNum1 >= Stage4WaveNum)
        {
            main.StageChangeButtonAry[11].SetActive(true);
        }
        if (maxFloorNum1 >= Stage5WaveNum)
        {
            main.StageChangeButtonAry[12].SetActive(true);
        }
        if (maxFloorNum1 >= Stage6WaveNum)
        {
            main.StageChangeButtonAry[13].SetActive(true);
        }
        if (maxFloorNum1 >= Stage7WaveNum)
        {
            main.StageChangeButtonAry[14].SetActive(true);
        }
        if (maxFloorNum1 >= Stage8WaveNum)
        {
            main.StageChangeButtonAry[15].SetActive(true);
        }

        switch (currentStage)
        {
            case Main.CurrentStage.stage1:
                Field.GetComponent<Image>().sprite = main.StageSpriteAry[8];
                main.Texts[0].text = "STAGE 1\n<size=50%>WAVE  " + (floorNum1 + 1 - Stage1WaveNum).ToString() + " / " + (Stage2WaveNum - Stage1WaveNum).ToString();
                break;
            case Main.CurrentStage.stage2:
                Field.GetComponent<Image>().sprite = main.StageSpriteAry[9];
                main.Texts[0].text = "STAGE 2\n<size=50%>WAVE  " + (floorNum1 + 1 - Stage2WaveNum).ToString() + " / " + (Stage3WaveNum - Stage2WaveNum).ToString();
                break;
            case Main.CurrentStage.stage3:
                Field.GetComponent<Image>().sprite = main.StageSpriteAry[10];
                main.Texts[0].text = "STAGE 3\n<size=50%>WAVE  " + (floorNum1 + 1 - Stage3WaveNum).ToString() + " / " + (Stage4WaveNum - Stage3WaveNum).ToString();
                break;
            case Main.CurrentStage.stage4:
                Field.GetComponent<Image>().sprite = main.StageSpriteAry[11];
                main.Texts[0].text = "STAGE 4\n<size=50%>WAVE  " + (floorNum1 + 1 - Stage4WaveNum).ToString() + " / " + (Stage5WaveNum - Stage4WaveNum).ToString();
                break;
            case Main.CurrentStage.stage5:
                Field.GetComponent<Image>().sprite = main.StageSpriteAry[12];
                main.Texts[0].text = "STAGE 5\n<size=50%>WAVE  " + (floorNum1 + 1 - Stage5WaveNum).ToString() + " / " + (Stage6WaveNum - Stage5WaveNum).ToString();
                break;
            case Main.CurrentStage.stage6:
                Field.GetComponent<Image>().sprite = main.StageSpriteAry[13];
                main.Texts[0].text = "STAGE 6\n<size=50%>WAVE  " + (floorNum1 + 1 - Stage6WaveNum).ToString() + " / " + (Stage7WaveNum - Stage6WaveNum).ToString();
                break;
            case Main.CurrentStage.stage7:
                Field.GetComponent<Image>().sprite = main.StageSpriteAry[14];
                main.Texts[0].text = "STAGE 7\n<size=50%>WAVE  " + (floorNum1 + 1 - Stage7WaveNum).ToString() + " / " + (Stage8WaveNum - Stage7WaveNum).ToString();
                break;
            case Main.CurrentStage.stage8:
                Field.GetComponent<Image>().sprite = main.StageSpriteAry[15];
                main.Texts[0].text = "STAGE 8\n<size=50%>WAVE  " + (floorNum1 + 1 - Stage8WaveNum).ToString() + " / ∞";
                break;
            default:
                break;
        }
}

    // Use this for initialization
    void Start () {
        //Stage1WaveNum = main.GameController.Stage1WaveNum;
        //Stage2WaveNum = main.GameController.Stage2WaveNum;
        //Stage3WaveNum = main.GameController.Stage3WaveNum;
        //Stage4WaveNum = main.GameController.Stage4WaveNum;
        //Stage5WaveNum = main.GameController.Stage5WaveNum;
        //Stage6WaveNum = main.GameController.Stage6WaveNum;
        //Stage7WaveNum = main.GameController.Stage7WaveNum;
        //Stage8WaveNum = main.GameController.Stage8WaveNum;
        //Field = main.GameController.Field;

        //main.StageChangeButtonAry[8].GetComponent<Button>().onClick.AddListener(() => { floorNum1 = Stage1WaveNum;  main.GameController.initStage(); });
        //main.StageChangeButtonAry[9].GetComponent<Button>().onClick.AddListener(() => { floorNum1 = Stage2WaveNum;  main.GameController.initStage(); });
        //main.StageChangeButtonAry[10].GetComponent<Button>().onClick.AddListener(() => { floorNum1 = Stage3WaveNum; main.GameController.initStage(); });
        //main.StageChangeButtonAry[11].GetComponent<Button>().onClick.AddListener(() => { floorNum1 = Stage4WaveNum; main.GameController.initStage(); });
        //main.StageChangeButtonAry[12].GetComponent<Button>().onClick.AddListener(() => { floorNum1 = Stage5WaveNum; main.GameController.initStage(); });
        //main.StageChangeButtonAry[13].GetComponent<Button>().onClick.AddListener(() => { floorNum1 = Stage6WaveNum; main.GameController.initStage(); });
        //main.StageChangeButtonAry[14].GetComponent<Button>().onClick.AddListener(() => { floorNum1 = Stage7WaveNum; main.GameController.initStage(); });
        //main.StageChangeButtonAry[15].GetComponent<Button>().onClick.AddListener(() => { floorNum1 = Stage8WaveNum; main.GameController.initStage(); });

    }

    public void InstantiateEnemies1(int floorNum1)
    {
        switch (floorNum1)
        {
            case 0:
                InstantiateEnemy(15, new Vector3(0, 160));
                break;
            case 1:
                InstantiateEnemy(15, new Vector3(100, 160));
                InstantiateEnemy(15, new Vector3(-100, 160));
                break;
            case 2:
                InstantiateEnemy(15, new Vector3(-130, 0));
                InstantiateEnemy(15, new Vector3(0, 130));
                InstantiateEnemy(15, new Vector3(130, 0));
                break;
            case 3:
                InstantiateEnemy(15, new Vector3(60, 100));
                InstantiateEnemy(15, new Vector3(-60, 100));
                InstantiateEnemy(15, new Vector3(-120, 0));
                InstantiateEnemy(15, new Vector3(120, 0));
                break;
            case 4:
                InstantiateEnemy(15, new Vector3(0, 0));
                InstantiateEnemy(15, new Vector3(80, 0));
                InstantiateEnemy(15, new Vector3(-80, 0));
                InstantiateEnemy(16, new Vector3(0, 160));
                break;
            case 5:
                InstantiateEnemy(15, new Vector3(0, 160));
                InstantiateEnemy(15, new Vector3(-80, 80));
                InstantiateEnemy(15, new Vector3(80, 80));
                InstantiateEnemy(15, new Vector3(0, 0));
                break;
            case 6:
                InstantiateEnemy(15, new Vector3(0, 160));
                InstantiateEnemy(15, new Vector3(130, 130));
                InstantiateEnemy(15, new Vector3(-130, 130));
                InstantiateEnemy(15, new Vector3(0, 40));
                InstantiateEnemy(15, new Vector3(0, 100));
                break;
            case 7:
                InstantiateEnemy(15, new Vector3(0, 160));
                InstantiateEnemy(15, new Vector3(100, 160));
                InstantiateEnemy(15, new Vector3(160, 100));
                InstantiateEnemy(15, new Vector3(-100, 160));
                InstantiateEnemy(15, new Vector3(-160, 100));
                break;
            case 8:
                InstantiateEnemy(15, new Vector3(0, 0));
                InstantiateEnemy(15, new Vector3(100, 0));
                InstantiateEnemy(15, new Vector3(-100, 0));
                InstantiateEnemy(15, new Vector3(-60, 60));
                InstantiateEnemy(15, new Vector3(60, 60));
                break;
            case 9:
                InstantiateEnemy(15, new Vector3(0, 10));
                InstantiateEnemy(15, new Vector3(80, 0));
                InstantiateEnemy(15, new Vector3(160, -20));
                InstantiateEnemy(15, new Vector3(-160, -20));
                InstantiateEnemy(15, new Vector3(-80, 0));
                InstantiateEnemy(16, new Vector3(0, 160));
                break;

            //Stage2
            case 10:
                InstantiateEnemy(16, new Vector3(100, 100));
                InstantiateEnemy(16, new Vector3(-100, 100));
                InstantiateEnemy(15, new Vector3(0, 100));
                InstantiateEnemy(15, new Vector3(150, 150));
                InstantiateEnemy(15, new Vector3(-150, 150));
                InstantiateEnemy(16, new Vector3(0, 50));
                InstantiateEnemy(16, new Vector3(0, -50));
                break;
            case 11:
                InstantiateEnemy(15, new Vector3(-150, 0));
                InstantiateEnemy(16, new Vector3(0, 75));
                InstantiateEnemy(15, new Vector3(150, 0));
                InstantiateEnemy(16, new Vector3(0, 0));
                InstantiateEnemy(15, new Vector3(100, 160));
                InstantiateEnemy(15, new Vector3(160, 100));
                InstantiateEnemy(15, new Vector3(-100, 160));
                InstantiateEnemy(15, new Vector3(-160, 100));
                InstantiateEnemy(16, new Vector3(0, 150));
                break;
            case 12:
                for (int i = 0; i < 7; i++)
                {
                    InstantiateEnemy(15, new Vector3(-180 + i * 60, 0));
                }
                for (int i = 0; i < 2; i++)
                {
                    InstantiateEnemy(16, new Vector3(-100 + i * 200, 160));
                }
                break;
            case 13:
                for (int i = 0; i < 9; i++)
                {
                    InstantiateEnemy(15, new Vector3(-160 + i * 40, 0));
                }
                for (int i = 0; i < 5; i++)
                {
                    InstantiateEnemy(16, new Vector3(-160 + i * 80, 60));
                    InstantiateEnemy(15, new Vector3(-160 + i * 80, 120));
                }
                break;
            case 14:
                InstantiateEnemy(16, new Vector3(0, 160));
                InstantiateEnemy(16, new Vector3(100, 160));
                InstantiateEnemy(16, new Vector3(160, 100));
                InstantiateEnemy(16, new Vector3(-100, 160));
                InstantiateEnemy(16, new Vector3(-160, 100));
                break;
            case 15:
                InstantiateEnemy(16, new Vector3(0, 80));
                InstantiateEnemy(16, new Vector3(100, 80));
                InstantiateEnemy(16, new Vector3(160, 20));
                InstantiateEnemy(16, new Vector3(-100, 80));
                InstantiateEnemy(16, new Vector3(-160, 20));
                InstantiateEnemy(15, new Vector3(0, 160));
                InstantiateEnemy(15, new Vector3(100, 160));
                InstantiateEnemy(15, new Vector3(160, 100));
                InstantiateEnemy(15, new Vector3(-100, 160));
                InstantiateEnemy(15, new Vector3(-160, 100));
                break;
            case 16:
                InstantiateEnemy(15, new Vector3(0, 0));
                InstantiateEnemy(15, new Vector3(40, 10));
                InstantiateEnemy(15, new Vector3(80, 30));
                InstantiateEnemy(15, new Vector3(120, 60));
                InstantiateEnemy(15, new Vector3(160, 100));
                InstantiateEnemy(15, new Vector3(-40, 10));
                InstantiateEnemy(15, new Vector3(-80, 30));
                InstantiateEnemy(15, new Vector3(-120, 60));
                InstantiateEnemy(15, new Vector3(-160, 100));
                InstantiateEnemy(15, new Vector3(0, 120));
                InstantiateEnemy(15, new Vector3(40, 130));
                InstantiateEnemy(15, new Vector3(80, 150));
                InstantiateEnemy(15, new Vector3(120, 180));
                InstantiateEnemy(15, new Vector3(-40, 130));
                InstantiateEnemy(15, new Vector3(-80, 150));
                InstantiateEnemy(15, new Vector3(-120, 180));
                break;
            case 17:
                InstantiateEnemy(15, new Vector3(0, 0));
                InstantiateEnemy(15, new Vector3(40, 10));
                InstantiateEnemy(15, new Vector3(80, 30));
                InstantiateEnemy(15, new Vector3(120, 60));
                InstantiateEnemy(15, new Vector3(160, 100));
                InstantiateEnemy(15, new Vector3(-40, 10));
                InstantiateEnemy(15, new Vector3(-80, 30));
                InstantiateEnemy(15, new Vector3(-120, 60));
                InstantiateEnemy(15, new Vector3(-160, 100));
                InstantiateEnemy(16, new Vector3(0, 120));
                InstantiateEnemy(16, new Vector3(40, 130));
                InstantiateEnemy(16, new Vector3(80, 150));
                InstantiateEnemy(16, new Vector3(120, 180));
                InstantiateEnemy(16, new Vector3(-40, 130));
                InstantiateEnemy(16, new Vector3(-80, 150));
                InstantiateEnemy(16, new Vector3(-120, 180));
                break;
            case 18:
                InstantiateEnemy(15, new Vector3(0, 0));
                InstantiateEnemy(15, new Vector3(40, 10));
                InstantiateEnemy(15, new Vector3(80, 30));
                InstantiateEnemy(15, new Vector3(120, 60));
                InstantiateEnemy(15, new Vector3(160, 100));
                InstantiateEnemy(15, new Vector3(-40, 10));
                InstantiateEnemy(15, new Vector3(-80, 30));
                InstantiateEnemy(15, new Vector3(-120, 60));
                InstantiateEnemy(15, new Vector3(-160, 100));
                InstantiateEnemy(15, new Vector3(0, 60));
                InstantiateEnemy(15, new Vector3(40, 70));
                InstantiateEnemy(15, new Vector3(80, 90));
                InstantiateEnemy(15, new Vector3(120, 120));
                InstantiateEnemy(15, new Vector3(160, 160));
                InstantiateEnemy(15, new Vector3(-40, 70));
                InstantiateEnemy(15, new Vector3(-80, 90));
                InstantiateEnemy(15, new Vector3(-120, 120));
                InstantiateEnemy(15, new Vector3(-160, 160));
                InstantiateEnemy(15, new Vector3(0, 120));
                InstantiateEnemy(15, new Vector3(40, 130));
                InstantiateEnemy(15, new Vector3(80, 150));
                InstantiateEnemy(15, new Vector3(120, 180));
                InstantiateEnemy(15, new Vector3(-40, 130));
                InstantiateEnemy(15, new Vector3(-80, 150));
                InstantiateEnemy(15, new Vector3(-120, 180));
                InstantiateEnemy(15, new Vector3(0, 180));
                break;
            case 19:
                InstantiateEnemy(15, new Vector3(0, 0));
                InstantiateEnemy(16, new Vector3(40, 10));
                InstantiateEnemy(15, new Vector3(80, 30));
                InstantiateEnemy(16, new Vector3(120, 60));
                InstantiateEnemy(15, new Vector3(160, 100));
                InstantiateEnemy(16, new Vector3(-40, 10));
                InstantiateEnemy(15, new Vector3(-80, 30));
                InstantiateEnemy(16, new Vector3(-120, 60));
                InstantiateEnemy(15, new Vector3(-160, 100));
                InstantiateEnemy(16, new Vector3(0, 60));
                InstantiateEnemy(15, new Vector3(40, 70));
                InstantiateEnemy(16, new Vector3(80, 90));
                InstantiateEnemy(15, new Vector3(120, 120));
                InstantiateEnemy(16, new Vector3(160, 160));
                InstantiateEnemy(15, new Vector3(-40, 70));
                InstantiateEnemy(16, new Vector3(-80, 90));
                InstantiateEnemy(15, new Vector3(-120, 120));
                InstantiateEnemy(16, new Vector3(-160, 160));
                InstantiateEnemy(15, new Vector3(0, 120));
                InstantiateEnemy(16, new Vector3(40, 130));
                InstantiateEnemy(15, new Vector3(80, 150));
                InstantiateEnemy(16, new Vector3(120, 180));
                InstantiateEnemy(15, new Vector3(-40, 130));
                InstantiateEnemy(16, new Vector3(-80, 150));
                InstantiateEnemy(15, new Vector3(-120, 180));
                InstantiateEnemy(16, new Vector3(0, 180));
                break;

            //Stage3
            case 20:
                InstantiateEnemy(17, new Vector3(0, 160));
                break;
            case 21:
                InstantiateEnemy(17, new Vector3(100, 160));
                InstantiateEnemy(17, new Vector3(-100, 160));
                break;
            case 22:
                InstantiateEnemy(17, new Vector3(-130, 0));
                InstantiateEnemy(17, new Vector3(0, 130));
                InstantiateEnemy(17, new Vector3(130, 0));
                break;
            case 23:
                InstantiateEnemy(17, new Vector3(60, 100));
                InstantiateEnemy(17, new Vector3(-60, 100));
                InstantiateEnemy(17, new Vector3(-120, 0));
                InstantiateEnemy(17, new Vector3(120, 0));
                break;
            case 24:
                InstantiateEnemy(17, new Vector3(0, 0));
                InstantiateEnemy(16, new Vector3(80, 0));
                InstantiateEnemy(16, new Vector3(-80, 0));
                InstantiateEnemy(17, new Vector3(0, 160));
                break;
            case 25:
                InstantiateEnemy(17, new Vector3(0, 160));
                InstantiateEnemy(17, new Vector3(-80, 80));
                InstantiateEnemy(17, new Vector3(80, 80));
                InstantiateEnemy(17, new Vector3(0, 0));
                break;
            case 26:
                InstantiateEnemy(17, new Vector3(0, 160));
                InstantiateEnemy(17, new Vector3(130, 130));
                InstantiateEnemy(17, new Vector3(-130, 130));
                InstantiateEnemy(17, new Vector3(0, 40));
                InstantiateEnemy(17, new Vector3(0, 100));
                break;
            case 27:
                InstantiateEnemy(17, new Vector3(0, 160));
                InstantiateEnemy(17, new Vector3(100, 160));
                InstantiateEnemy(17, new Vector3(160, 100));
                InstantiateEnemy(17, new Vector3(-100, 160));
                InstantiateEnemy(17, new Vector3(-160, 100));
                break;
            case 28:
                InstantiateEnemy(17, new Vector3(0, 0));
                InstantiateEnemy(17, new Vector3(100, 0));
                InstantiateEnemy(17, new Vector3(-100, 0));
                InstantiateEnemy(17, new Vector3(-60, 60));
                InstantiateEnemy(17, new Vector3(60, 60));
                break;
            case 29:
                InstantiateEnemy(17, new Vector3(0, 10));
                InstantiateEnemy(17, new Vector3(80, 0));
                InstantiateEnemy(17, new Vector3(160, -20));
                InstantiateEnemy(17, new Vector3(-160, -20));
                InstantiateEnemy(17, new Vector3(-80, 0));
                InstantiateEnemy(17, new Vector3(0, 160));
                break;

            //Stage4
            case 30:
                InstantiateEnemy(18, new Vector3(100, 100));
                InstantiateEnemy(18, new Vector3(-100, 100));
                InstantiateEnemy(18, new Vector3(0, 100));
                InstantiateEnemy(18, new Vector3(150, 150));
                InstantiateEnemy(18, new Vector3(-150, 150));
                InstantiateEnemy(18, new Vector3(0, 50));
                InstantiateEnemy(18, new Vector3(0, -50));
                break;
            case 31:
                InstantiateEnemy(18, new Vector3(-150, 0));
                InstantiateEnemy(18, new Vector3(0, 75));
                InstantiateEnemy(18, new Vector3(150, 0));
                InstantiateEnemy(18, new Vector3(0, 0));
                InstantiateEnemy(18, new Vector3(100, 160));
                InstantiateEnemy(18, new Vector3(160, 100));
                InstantiateEnemy(18, new Vector3(-100, 160));
                InstantiateEnemy(18, new Vector3(-160, 100));
                InstantiateEnemy(18, new Vector3(0, 150));
                break;
            case 32:
                for (int i = 0; i < 7; i++)
                {
                    InstantiateEnemy(18, new Vector3(-180 + i * 60, 0));
                }
                for (int i = 0; i < 2; i++)
                {
                    InstantiateEnemy(17, new Vector3(-100 + i * 200, 160));
                }
                break;
            case 33:
                for (int i = 0; i < 9; i++)
                {
                    InstantiateEnemy(18, new Vector3(-160 + i * 40, 0));
                }
                for (int i = 0; i < 5; i++)
                {
                    InstantiateEnemy(17, new Vector3(-160 + i * 80, 60));
                    InstantiateEnemy(18, new Vector3(-160 + i * 80, 120));
                }
                break;
            case 34:
                InstantiateEnemy(15, new Vector3(0, 160));
                InstantiateEnemy(16, new Vector3(100, 160));
                InstantiateEnemy(17, new Vector3(160, 100));
                InstantiateEnemy(16, new Vector3(-100, 160));
                InstantiateEnemy(17, new Vector3(-160, 100));
                break;
            case 35:
                InstantiateEnemy(18, new Vector3(0, 80));
                InstantiateEnemy(18, new Vector3(100, 80));
                InstantiateEnemy(18, new Vector3(160, 20));
                InstantiateEnemy(18, new Vector3(-100, 80));
                InstantiateEnemy(18, new Vector3(-160, 20));
                InstantiateEnemy(17, new Vector3(0, 160));
                InstantiateEnemy(18, new Vector3(100, 160));
                InstantiateEnemy(18, new Vector3(160, 100));
                InstantiateEnemy(18, new Vector3(-100, 160));
                InstantiateEnemy(18, new Vector3(-160, 100));
                break;
            case 36:
                InstantiateEnemy(18, new Vector3(0, 0));
                InstantiateEnemy(18, new Vector3(40, 10));
                InstantiateEnemy(18, new Vector3(80, 30));
                InstantiateEnemy(18, new Vector3(120, 60));
                InstantiateEnemy(18, new Vector3(160, 100));
                InstantiateEnemy(18, new Vector3(-40, 10));
                InstantiateEnemy(18, new Vector3(-80, 30));
                InstantiateEnemy(18, new Vector3(-120, 60));
                InstantiateEnemy(18, new Vector3(-160, 100));
                InstantiateEnemy(18, new Vector3(0, 120));
                InstantiateEnemy(18, new Vector3(40, 130));
                InstantiateEnemy(18, new Vector3(80, 150));
                InstantiateEnemy(18, new Vector3(120, 180));
                InstantiateEnemy(18, new Vector3(-40, 130));
                InstantiateEnemy(18, new Vector3(-80, 150));
                InstantiateEnemy(18, new Vector3(-120, 180));
                break;
            case 37:
                InstantiateEnemy(18, new Vector3(0, 0));
                InstantiateEnemy(18, new Vector3(40, 10));
                InstantiateEnemy(18, new Vector3(80, 30));
                InstantiateEnemy(18, new Vector3(120, 60));
                InstantiateEnemy(18, new Vector3(160, 100));
                InstantiateEnemy(18, new Vector3(-40, 10));
                InstantiateEnemy(18, new Vector3(-80, 30));
                InstantiateEnemy(18, new Vector3(-120, 60));
                InstantiateEnemy(18, new Vector3(-160, 100));
                InstantiateEnemy(17, new Vector3(0, 120));
                InstantiateEnemy(17, new Vector3(40, 130));
                InstantiateEnemy(17, new Vector3(80, 150));
                InstantiateEnemy(17, new Vector3(120, 180));
                InstantiateEnemy(17, new Vector3(-40, 130));
                InstantiateEnemy(17, new Vector3(-80, 150));
                InstantiateEnemy(17, new Vector3(-120, 180));
                break;
            case 38:
                InstantiateEnemy(18, new Vector3(0, 0));
                InstantiateEnemy(18, new Vector3(40, 10));
                InstantiateEnemy(18, new Vector3(80, 30));
                InstantiateEnemy(18, new Vector3(120, 60));
                InstantiateEnemy(18, new Vector3(160, 100));
                InstantiateEnemy(18, new Vector3(-40, 10));
                InstantiateEnemy(18, new Vector3(-80, 30));
                InstantiateEnemy(18, new Vector3(-120, 60));
                InstantiateEnemy(18, new Vector3(-160, 100));
                InstantiateEnemy(18, new Vector3(0, 60));
                InstantiateEnemy(18, new Vector3(40, 70));
                InstantiateEnemy(18, new Vector3(80, 90));
                InstantiateEnemy(18, new Vector3(120, 120));
                InstantiateEnemy(18, new Vector3(160, 160));
                InstantiateEnemy(18, new Vector3(-40, 70));
                InstantiateEnemy(18, new Vector3(-80, 90));
                InstantiateEnemy(18, new Vector3(-120, 120));
                InstantiateEnemy(18, new Vector3(-160, 160));
                InstantiateEnemy(18, new Vector3(0, 120));
                InstantiateEnemy(18, new Vector3(40, 130));
                InstantiateEnemy(18, new Vector3(80, 150));
                InstantiateEnemy(18, new Vector3(120, 180));
                InstantiateEnemy(18, new Vector3(-40, 130));
                InstantiateEnemy(18, new Vector3(-80, 150));
                InstantiateEnemy(18, new Vector3(-120, 180));
                InstantiateEnemy(18, new Vector3(0, 180));
                break;
            case 39:
                InstantiateEnemy(18, new Vector3(0, -0 + 100));
                InstantiateEnemy(18, new Vector3(40, -10 + 100));
                InstantiateEnemy(18, new Vector3(80, -30 + 100));
                InstantiateEnemy(18, new Vector3(120, -60 + 100));
                InstantiateEnemy(18, new Vector3(160, -100 + 100));
                InstantiateEnemy(18, new Vector3(-40, -10 + 100));
                InstantiateEnemy(18, new Vector3(-80, -30 + 100));
                InstantiateEnemy(18, new Vector3(-120, -60 + 100));
                InstantiateEnemy(18, new Vector3(-160, -100 + 100));
                InstantiateEnemy(18, new Vector3(0, -60 + 100));
                InstantiateEnemy(18, new Vector3(40, -70 + 100));
                InstantiateEnemy(18, new Vector3(80, -90 + 100));
                InstantiateEnemy(18, new Vector3(120, -120 + 100));
                InstantiateEnemy(18, new Vector3(160, -160 + 100));
                InstantiateEnemy(18, new Vector3(-40, -70 + 100));
                InstantiateEnemy(18, new Vector3(-80, -90 + 100));
                InstantiateEnemy(18, new Vector3(-120, -120 + 100));
                InstantiateEnemy(18, new Vector3(-160, -160 + 100));
                InstantiateEnemy(18, new Vector3(0, -120 + 100));
                InstantiateEnemy(18, new Vector3(40, -130 + 100));
                InstantiateEnemy(18, new Vector3(80, -150 + 100));
                InstantiateEnemy(18, new Vector3(120, -180 + 100));
                InstantiateEnemy(18, new Vector3(-40, -130 + 100));
                InstantiateEnemy(18, new Vector3(-80, -150 + 100));
                InstantiateEnemy(18, new Vector3(-120, -180 + 100));
                InstantiateEnemy(17, new Vector3(0, 180));
                break;

            //Stage5
            case 40:
                randomEnemyNum = UnityEngine.Random.Range(15, 18);
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-100 + 100 * i, UnityEngine.Random.Range(0, 150)));
                }
                InstantiateEnemy(19, new Vector3(0, 180));
                break;
            case 41:
                randomEnemyNum = UnityEngine.Random.Range(15, 18);
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-100 + 100 * i, UnityEngine.Random.Range(0, 150)));
                }
                InstantiateEnemy(19, new Vector3(0, 180));
                break;
            case 42:
                randomEnemyNum = UnityEngine.Random.Range(15, 18);
                for (int i = 0; i < 4; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-120 + 80 * i, UnityEngine.Random.Range(0, 150)));
                }
                InstantiateEnemy(19, new Vector3(0, 180));
                break;
            case 43:
                randomEnemyNum = UnityEngine.Random.Range(15, 18);
                for (int i = 0; i < 4; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-120 + 80 * i, UnityEngine.Random.Range(-60, 180)));
                }
                break;
            case 44:
                randomEnemyNum = UnityEngine.Random.Range(15, 18);
                for (int i = 0; i < 5; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-120 + 60 * i, UnityEngine.Random.Range(-60, 180)));
                }
                InstantiateEnemy(19, new Vector3(0, 180));
                break;
            case 45:
                randomEnemyNum = UnityEngine.Random.Range(15, 18);
                for (int i = 0; i < 5; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-120 + 60 * i, UnityEngine.Random.Range(-60, 180)));
                }
                InstantiateEnemy(19, new Vector3(0, 180));
                break;
            case 46:
                randomEnemyNum = UnityEngine.Random.Range(15, 18);
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-120 + 120 * i, UnityEngine.Random.Range(60, 180)));
                }
                randomEnemyNum = UnityEngine.Random.Range(15, 18);
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-120 + 120 * i, UnityEngine.Random.Range(-60, 60)));
                }
                InstantiateEnemy(19, new Vector3(0, 180));
                break;
            case 47:
                randomEnemyNum = UnityEngine.Random.Range(15, 18);
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-120 + 120 * i, UnityEngine.Random.Range(60, 180)));
                }
                randomEnemyNum = UnityEngine.Random.Range(15, 18);
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-120 + 120 * i, UnityEngine.Random.Range(-60, 60)));
                }
                InstantiateEnemy(19, new Vector3(0, 180));
                break;
            case 48:
                randomEnemyNum = UnityEngine.Random.Range(15, 18);
                for (int i = 0; i < 4; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-150 + 100 * i, UnityEngine.Random.Range(60, 180)));
                }
                randomEnemyNum = UnityEngine.Random.Range(15, 18);
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-120 + 120 * i, UnityEngine.Random.Range(-60, 60)));
                }
                InstantiateEnemy(19, new Vector3(0, 180));
                break;
            case 49:
                randomEnemyNum = UnityEngine.Random.Range(15, 18);
                for (int i = 0; i < 4; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-150 + 100 * i, UnityEngine.Random.Range(60, 180)));
                }
                randomEnemyNum = UnityEngine.Random.Range(15, 18);
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-120 + 120 * i, UnityEngine.Random.Range(-60, 60)));
                }
                InstantiateEnemy(19, new Vector3(0, 180));
                break;
            case 50:
                randomEnemyNum = UnityEngine.Random.Range(15, 18);
                for (int i = 0; i < 4; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-150 + 100 * i, UnityEngine.Random.Range(100, 160)));
                }
                randomEnemyNum = UnityEngine.Random.Range(15, 18);
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-120 + 120 * i, UnityEngine.Random.Range(20, 100)));
                }
                randomEnemyNum = UnityEngine.Random.Range(15, 18);
                for (int i = 0; i < 2; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-60 + 120 * i, UnityEngine.Random.Range(-60, 20)));
                }
                InstantiateEnemy(19, new Vector3(0, 180));
                break;
            case 51:
                randomEnemyNum = UnityEngine.Random.Range(15, 18);
                for (int i = 0; i < 4; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-150 + 100 * i, UnityEngine.Random.Range(100, 160)));
                }
                randomEnemyNum = UnityEngine.Random.Range(15, 18);
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-120 + 120 * i, UnityEngine.Random.Range(20, 100)));
                }
                randomEnemyNum = UnityEngine.Random.Range(15, 18);
                for (int i = 0; i < 2; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-60 + 120 * i, UnityEngine.Random.Range(-60, 20)));
                }
                InstantiateEnemy(19, new Vector3(0, 180));
                break;
            case 52:
                randomEnemyNum = UnityEngine.Random.Range(15, 18);
                for (int i = 0; i < 6; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(0 + UnityEngine.Random.Range(-15, 15), -120 + i * 60 + UnityEngine.Random.Range(-15, 15)));
                }
                randomEnemyNum = UnityEngine.Random.Range(15, 18);
                for (int i = 0; i < 2; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-100 + i * 200 + UnityEngine.Random.Range(-15, 15), 160 + UnityEngine.Random.Range(-15, 15)));
                }
                InstantiateEnemy(19, new Vector3(0, 180));
                break;
            case 53:
                randomEnemyNum = UnityEngine.Random.Range(15, 18);
                for (int i = 0; i < 7; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(0 + UnityEngine.Random.Range(-15, 15), -150 + i * 50 + UnityEngine.Random.Range(-15, 15)));
                }
                randomEnemyNum = UnityEngine.Random.Range(15, 18);
                for (int i = 0; i < 2; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-60 + i * 120 + UnityEngine.Random.Range(-15, 15), 160 + UnityEngine.Random.Range(-15, 15)));
                    InstantiateEnemy(randomEnemyNum, new Vector3(-100 + i * 200 + UnityEngine.Random.Range(-15, 15), 80 + UnityEngine.Random.Range(-15, 15)));
                    InstantiateEnemy(randomEnemyNum, new Vector3(-140 + i * 280 + UnityEngine.Random.Range(-15, 15), 00 + UnityEngine.Random.Range(-15, 15)));
                }
                InstantiateEnemy(19, new Vector3(0, 180));
                break;
            case 54:
                randomEnemyNum = UnityEngine.Random.Range(15, 18);
                for (int i = 0; i < 9; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(0 + UnityEngine.Random.Range(-15, 15), -150 + i * 40 + UnityEngine.Random.Range(-15, 15)));
                }
                randomEnemyNum = UnityEngine.Random.Range(15, 18);
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-120 + UnityEngine.Random.Range(-15, 15), -80 + i * 80 + UnityEngine.Random.Range(-15, 15)));
                    InstantiateEnemy(randomEnemyNum, new Vector3(120 + UnityEngine.Random.Range(-15, 15), -80 + i * 80 + UnityEngine.Random.Range(-15, 15)));
                }
                InstantiateEnemy(19, new Vector3(0, 180));
                break;
            case 55:
                randomEnemyNum = UnityEngine.Random.Range(15, 18);
                for (int i = 0; i < 4; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-160 + i * 40 + UnityEngine.Random.Range(-15, 15), 160 - i * 40 + UnityEngine.Random.Range(-15, 15)));
                    InstantiateEnemy(randomEnemyNum, new Vector3(40 + i * 40 + UnityEngine.Random.Range(-15, 15), 40 + i * 40 + UnityEngine.Random.Range(-15, 15)));
                }
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(0 + UnityEngine.Random.Range(-15, 15), 0 - i * 40 + UnityEngine.Random.Range(-15, 15)));
                }
                InstantiateEnemy(19, new Vector3(0, 180));
                break;
            case 56:
                randomEnemyNum = UnityEngine.Random.Range(15, 18);
                for (int i = 0; i < 7; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(0 + UnityEngine.Random.Range(-15, 15), -150 + i * 50 + UnityEngine.Random.Range(-15, 15)));
                }
                randomEnemyNum = UnityEngine.Random.Range(15, 18);
                for (int i = 0; i < 2; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-60 + i * 120 + UnityEngine.Random.Range(-15, 15), 160 + UnityEngine.Random.Range(-15, 15)));
                    InstantiateEnemy(randomEnemyNum, new Vector3(-100 + i * 200 + UnityEngine.Random.Range(-15, 15), 80 + UnityEngine.Random.Range(-15, 15)));
                    InstantiateEnemy(randomEnemyNum, new Vector3(-140 + i * 280 + UnityEngine.Random.Range(-15, 15), 00 + UnityEngine.Random.Range(-15, 15)));
                }
                InstantiateEnemy(19, new Vector3(0, 180));
                break;
            case 57:
                randomEnemyNum = UnityEngine.Random.Range(15, 18);
                for (int i = 0; i < 9; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(0 + UnityEngine.Random.Range(-15, 15), -150 + i * 40 + UnityEngine.Random.Range(-15, 15)));
                }
                randomEnemyNum = UnityEngine.Random.Range(15, 18);
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-120 + UnityEngine.Random.Range(-15, 15), -80 + i * 80 + UnityEngine.Random.Range(-15, 15)));
                    InstantiateEnemy(randomEnemyNum, new Vector3(120 + UnityEngine.Random.Range(-15, 15), -80 + i * 80 + UnityEngine.Random.Range(-15, 15)));
                }
                InstantiateEnemy(19, new Vector3(0, 180));
                break;
            case 58:
                randomEnemyNum = UnityEngine.Random.Range(15, 18);
                for (int i = 0; i < 4; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-160 + i * 40 + UnityEngine.Random.Range(-15, 15), 160 - i * 40 + UnityEngine.Random.Range(-15, 15)));
                    InstantiateEnemy(randomEnemyNum, new Vector3(40 + i * 40 + UnityEngine.Random.Range(-15, 15), 40 + i * 40 + UnityEngine.Random.Range(-15, 15)));
                }
                randomEnemyNum = UnityEngine.Random.Range(15, 18);
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(0 + UnityEngine.Random.Range(-15, 15), 0 - i * 40 + UnityEngine.Random.Range(-15, 15)));
                }
                InstantiateEnemy(19, new Vector3(0, 180));
                break;
            case 59:
                InstantiateEnemy(19, new Vector3(0, 180));
                InstantiateEnemy(19, new Vector3(180, 60));
                InstantiateEnemy(19, new Vector3(-180, 60));
                InstantiateEnemy(19, new Vector3(0, 60));
                InstantiateEnemy(19, new Vector3(0, -60));
                break;

            //Stage6
            case 60:
                InstantiateEnemy(20, new Vector3(0, 120));
                InstantiateEnemy(20, new Vector3(0, 40));
                InstantiateEnemy(20, new Vector3(0, -40));
                break;
            case 61:
                InstantiateEnemy(20, new Vector3(0, 120));
                InstantiateEnemy(20, new Vector3(0, 40));
                InstantiateEnemy(20, new Vector3(0, -40));
                InstantiateEnemy(18, new Vector3(0, 180));
                InstantiateEnemy(18, new Vector3(180, 60));
                InstantiateEnemy(18, new Vector3(-180, 60));
                InstantiateEnemy(18, new Vector3(0, 60));
                InstantiateEnemy(18, new Vector3(0, -60));
                break;
            case 62:
                InstantiateEnemy(20, new Vector3(-100, -100));
                InstantiateEnemy(20, new Vector3(80, -60));
                InstantiateEnemy(20, new Vector3(40, 20));
                InstantiateEnemy(20, new Vector3(-20, 60));
                InstantiateEnemy(18, new Vector3(0, 180));
                InstantiateEnemy(18, new Vector3(180, 60));
                InstantiateEnemy(18, new Vector3(-180, 60));
                InstantiateEnemy(18, new Vector3(0, 60));
                InstantiateEnemy(18, new Vector3(0, -60));
                break;
            case 63:
                InstantiateEnemy(20, new Vector3(-100, -100));
                InstantiateEnemy(20, new Vector3(80, -60));
                InstantiateEnemy(20, new Vector3(40, 20));
                InstantiateEnemy(20, new Vector3(-20, 60));
                InstantiateEnemy(19, new Vector3(0, 0));
                break;
            case 64:
                InstantiateEnemy(20, new Vector3(-60, -20));
                InstantiateEnemy(18, new Vector3(40, 20));
                InstantiateEnemy(20, new Vector3(-20, 60));
                InstantiateEnemy(18, new Vector3(0, 100));
                InstantiateEnemy(20, new Vector3(0, 140));
                break;
            case 65:
                InstantiateEnemy(18, new Vector3(-60, -20));
                InstantiateEnemy(20, new Vector3(40, 20));
                InstantiateEnemy(18, new Vector3(-20, 60));
                InstantiateEnemy(20, new Vector3(0, 100));
                InstantiateEnemy(18, new Vector3(0, 140));
                break;

            case 66:
                InstantiateEnemy(18, new Vector3(-100, -100));
                InstantiateEnemy(18, new Vector3(80, -60));
                InstantiateEnemy(18, new Vector3(-60, -20));
                InstantiateEnemy(18, new Vector3(40, 20));
                InstantiateEnemy(18, new Vector3(-20, 60));
                InstantiateEnemy(18, new Vector3(0, 100));
                break;
            case 67:
                InstantiateEnemy(20, new Vector3(-100, -100));
                InstantiateEnemy(20, new Vector3(80, -60));
                InstantiateEnemy(20, new Vector3(-60, -20));
                InstantiateEnemy(20, new Vector3(40, 20));
                InstantiateEnemy(20, new Vector3(-20, 60));
                InstantiateEnemy(20, new Vector3(0, 100));
                break;
            case 68:
                InstantiateEnemy(18, new Vector3(-100, -100));
                InstantiateEnemy(20, new Vector3(80, -60));
                InstantiateEnemy(18, new Vector3(-60, -20));
                InstantiateEnemy(20, new Vector3(40, 20));
                InstantiateEnemy(18, new Vector3(-20, 60));
                InstantiateEnemy(20, new Vector3(0, 100));
                InstantiateEnemy(18, new Vector3(0, 140));
                break;
            case 69:
                InstantiateEnemy(20, new Vector3(-100, -100));
                InstantiateEnemy(18, new Vector3(80, -60));
                InstantiateEnemy(20, new Vector3(-60, -20));
                InstantiateEnemy(18, new Vector3(40, 20));
                InstantiateEnemy(20, new Vector3(-20, 60));
                InstantiateEnemy(18, new Vector3(0, 100));
                InstantiateEnemy(20, new Vector3(0, 140));
                break;
            case 70:
                InstantiateEnemy(20, new Vector3(100, 100));
                InstantiateEnemy(20, new Vector3(-100, 100));
                InstantiateEnemy(20, new Vector3(0, 100));
                InstantiateEnemy(20, new Vector3(150, 150));
                InstantiateEnemy(20, new Vector3(-150, 150));
                InstantiateEnemy(20, new Vector3(0, 50));
                InstantiateEnemy(20, new Vector3(0, -50));
                break;
            case 71:
                InstantiateEnemy(20, new Vector3(-150, 0));
                InstantiateEnemy(20, new Vector3(0, 75));
                InstantiateEnemy(20, new Vector3(150, 0));
                InstantiateEnemy(20, new Vector3(0, 0));
                InstantiateEnemy(20, new Vector3(100, 160));
                InstantiateEnemy(20, new Vector3(160, 100));
                InstantiateEnemy(20, new Vector3(-100, 160));
                InstantiateEnemy(20, new Vector3(-160, 100));
                InstantiateEnemy(19, new Vector3(0, 150));
                break;
            case 72:
                for (int i = 0; i < 9; i++)
                {
                    InstantiateEnemy(20, new Vector3(0, -150 + i * 40));
                }
                break;
            case 73:
                for (int i = 0; i < 7; i++)
                {
                    InstantiateEnemy(20, new Vector3(-180 + i * 60, 0));
                }
                for (int i = 0; i < 2; i++)
                {
                    InstantiateEnemy(18, new Vector3(-100 + i * 200, 160));
                }
                break;
            case 74:
                for (int i = 0; i < 9; i++)
                {
                    InstantiateEnemy(20, new Vector3(-160 + i * 40, 0));
                }
                for (int i = 0; i < 5; i++)
                {
                    InstantiateEnemy(18, new Vector3(-160 + i * 80, -60));
                    InstantiateEnemy(18, new Vector3(-160 + i * 80, -60));
                }
                InstantiateEnemy(19, new Vector3(-100, 120));
                InstantiateEnemy(19, new Vector3(100, 120));
                break;
            case 75:
                InstantiateEnemy(19, new Vector3(0, 160));
                InstantiateEnemy(19, new Vector3(100, 160));
                InstantiateEnemy(19, new Vector3(160, 100));
                InstantiateEnemy(19, new Vector3(-100, 160));
                InstantiateEnemy(19, new Vector3(-160, 100));
                InstantiateEnemy(20, new Vector3(0, 80));
                InstantiateEnemy(20, new Vector3(100, 80));
                InstantiateEnemy(20, new Vector3(160, 20));
                InstantiateEnemy(20, new Vector3(-100, 80));
                InstantiateEnemy(20, new Vector3(-160, 20));
                break;
            case 76:
                InstantiateEnemy(19, new Vector3(100, 80));
                InstantiateEnemy(19, new Vector3(-100, 80));
                InstantiateEnemy(19, new Vector3(0, 0));
                InstantiateEnemy(19, new Vector3(0, 160));
                InstantiateEnemy(19, new Vector3(100, -80));
                InstantiateEnemy(19, new Vector3(-100, -80));
                InstantiateEnemy(19, new Vector3(0, -160));
                break;
            case 77:
                InstantiateEnemy(20, new Vector3(0, 0));
                InstantiateEnemy(20, new Vector3(40, 10));
                InstantiateEnemy(20, new Vector3(80, 30));
                InstantiateEnemy(20, new Vector3(120, 60));
                InstantiateEnemy(20, new Vector3(160, 100));
                InstantiateEnemy(20, new Vector3(-40, 10));
                InstantiateEnemy(20, new Vector3(-80, 30));
                InstantiateEnemy(20, new Vector3(-120, 60));
                InstantiateEnemy(20, new Vector3(-160, 100));
                InstantiateEnemy(20, new Vector3(0, 120));
                InstantiateEnemy(20, new Vector3(40, 130));
                InstantiateEnemy(20, new Vector3(80, 150));
                InstantiateEnemy(20, new Vector3(120, 180));
                InstantiateEnemy(20, new Vector3(-40, 130));
                InstantiateEnemy(20, new Vector3(-80, 150));
                InstantiateEnemy(20, new Vector3(-120, 180));
                break;
            case 78:
                InstantiateEnemy(20, new Vector3(0, 0));
                InstantiateEnemy(20, new Vector3(40, 10));
                InstantiateEnemy(20, new Vector3(80, 30));
                InstantiateEnemy(20, new Vector3(120, 60));
                InstantiateEnemy(20, new Vector3(160, 100));
                InstantiateEnemy(20, new Vector3(-40, 10));
                InstantiateEnemy(20, new Vector3(-80, 30));
                InstantiateEnemy(20, new Vector3(-120, 60));
                InstantiateEnemy(20, new Vector3(-160, 100));
                InstantiateEnemy(20, new Vector3(0, 60));
                InstantiateEnemy(20, new Vector3(40, 70));
                InstantiateEnemy(20, new Vector3(80, 90));
                InstantiateEnemy(20, new Vector3(120, 120));
                InstantiateEnemy(20, new Vector3(160, 160));
                InstantiateEnemy(20, new Vector3(-40, 70));
                InstantiateEnemy(20, new Vector3(-80, 90));
                InstantiateEnemy(20, new Vector3(-120, 120));
                InstantiateEnemy(20, new Vector3(-160, 160));
                InstantiateEnemy(20, new Vector3(0, 120));
                InstantiateEnemy(20, new Vector3(40, 130));
                InstantiateEnemy(20, new Vector3(80, 150));
                InstantiateEnemy(20, new Vector3(120, 180));
                InstantiateEnemy(20, new Vector3(-40, 130));
                InstantiateEnemy(20, new Vector3(-80, 150));
                InstantiateEnemy(20, new Vector3(-120, 180));
                InstantiateEnemy(20, new Vector3(0, 180));
                break;
            case 79:
                InstantiateEnemy(20, new Vector3(0, 80));
                break;

            //Stage7
            case 80:
                for (int i = 0; i < 8; i++)
                {
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (8 - 1), -160 + 0 * 360 / (8 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (8 - 1), -160 + 1 * 360 / (8 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (8 - 1), -160 + 2 * 360 / (8 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (8 - 1), -160 + 3 * 360 / (8 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (8 - 1), -160 + 4 * 360 / (8 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (8 - 1), -160 + 5 * 360 / (8 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (8 - 1), -160 + 6 * 360 / (8 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (8 - 1), -160 + 7 * 360 / (8 - 1)));
                }
                break;
            case 81:
                InstantiateEnemy(21, new Vector3(0, 60));
                break;
            case 82:
                for (int i = 0; i < 8; i++)
                {
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (8 - 1), -160 + 0 * 360 / (8 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (8 - 1), -160 + 1 * 360 / (8 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (8 - 1), -160 + 2 * 360 / (8 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (8 - 1), -160 + 3 * 360 / (8 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (8 - 1), -160 + 4 * 360 / (8 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (8 - 1), -160 + 5 * 360 / (8 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (8 - 1), -160 + 6 * 360 / (8 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (8 - 1), -160 + 7 * 360 / (8 - 1)));
                }
                break;
            case 83:
                InstantiateEnemy(21, new Vector3(0, 60));
                break;
            case 84:
                for (int i = 0; i < 10; i++)
                {
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (10 - 1), -160 + 0 * 360 / (10 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (10 - 1), -160 + 1 * 360 / (10 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (10 - 1), -160 + 2 * 360 / (10 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (10 - 1), -160 + 3 * 360 / (10 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (10 - 1), -160 + 4 * 360 / (10 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (10 - 1), -160 + 5 * 360 / (10 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (10 - 1), -160 + 6 * 360 / (10 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (10 - 1), -160 + 7 * 360 / (10 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (10 - 1), -160 + 8 * 360 / (10 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (10 - 1), -160 + 9 * 360 / (10 - 1)));
                }
                break;
            case 85:
                InstantiateEnemy(21, new Vector3(0, 60));
                break;
            case 86:
                for (int i = 0; i < 10; i++)
                {
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (10 - 1), -160 + 0 * 360 / (10 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (10 - 1), -160 + 1 * 360 / (10 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (10 - 1), -160 + 2 * 360 / (10 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (10 - 1), -160 + 3 * 360 / (10 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (10 - 1), -160 + 4 * 360 / (10 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (10 - 1), -160 + 5 * 360 / (10 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (10 - 1), -160 + 6 * 360 / (10 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (10 - 1), -160 + 7 * 360 / (10 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (10 - 1), -160 + 8 * 360 / (10 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (10 - 1), -160 + 9 * 360 / (10 - 1)));
                }
                break;
            case 87:
                InstantiateEnemy(21, new Vector3(0, 60));
                break;
            case 88:
                for (int i = 0; i < 8; i++)
                {
                    InstantiateEnemy(15, new Vector3(-180 + i * 360 / (8 - 1), -160 + 0 * 360 / (8 - 1)));
                    InstantiateEnemy(16, new Vector3(-180 + i * 360 / (8 - 1), -160 + 1 * 360 / (8 - 1)));
                    InstantiateEnemy(17, new Vector3(-180 + i * 360 / (8 - 1), -160 + 2 * 360 / (8 - 1)));
                    InstantiateEnemy(19, new Vector3(-180 + i * 360 / (8 - 1), -160 + 3 * 360 / (8 - 1)));
                    InstantiateEnemy(15, new Vector3(-180 + i * 360 / (8 - 1), -160 + 4 * 360 / (8 - 1)));
                    InstantiateEnemy(16, new Vector3(-180 + i * 360 / (8 - 1), -160 + 5 * 360 / (8 - 1)));
                    InstantiateEnemy(17, new Vector3(-180 + i * 360 / (8 - 1), -160 + 6 * 360 / (8 - 1)));
                    InstantiateEnemy(19, new Vector3(-180 + i * 360 / (8 - 1), -160 + 7 * 360 / (8 - 1)));
                }
                break;
            case 89:
                InstantiateEnemy(21, new Vector3(0, 60));
                break;
            case 90:
                for (int i = 0; i < 12; i++)
                {
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (12 - 1), -160 + 0 * 360 / (12 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (12 - 1), -160 + 1 * 360 / (12 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (12 - 1), -160 + 2 * 360 / (12 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (12 - 1), -160 + 3 * 360 / (12 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (12 - 1), -160 + 4 * 360 / (12 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (12 - 1), -160 + 5 * 360 / (12 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (12 - 1), -160 + 6 * 360 / (12 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (12 - 1), -160 + 7 * 360 / (12 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (12 - 1), -160 + 8 * 360 / (12 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (12 - 1), -160 + 9 * 360 / (12 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (12 - 1), -160 + 10 * 360 / (12 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (12 - 1), -160 + 11 * 360 / (12 - 1)));
                }
                break;
            case 91:
                InstantiateEnemy(21, new Vector3(0, 60));
                break;
            case 92:
                for (int i = 0; i < 14; i++)
                {
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (14 - 1), -160 + 0 * 360 / (14 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (14 - 1), -160 + 1 * 360 / (14 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (14 - 1), -160 + 2 * 360 / (14 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (14 - 1), -160 + 3 * 360 / (14 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (14 - 1), -160 + 4 * 360 / (14 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (14 - 1), -160 + 5 * 360 / (14 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (14 - 1), -160 + 6 * 360 / (14 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (14 - 1), -160 + 7 * 360 / (14 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (14 - 1), -160 + 8 * 360 / (14 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (14 - 1), -160 + 9 * 360 / (14 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (14 - 1), -160 + 10 * 360 / (14 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (14 - 1), -160 + 11 * 360 / (14 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (14 - 1), -160 + 12 * 360 / (14 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (14 - 1), -160 + 13 * 360 / (14 - 1)));
                }
                break;
            case 93:
                InstantiateEnemy(21, new Vector3(0, 60));
                break;
            case 94:
                for (int i = 0; i < 14; i++)
                {
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (14 - 1), -160 + 0 * 360 / (14 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (14 - 1), -160 + 1 * 360 / (14 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (14 - 1), -160 + 2 * 360 / (14 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (14 - 1), -160 + 3 * 360 / (14 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (14 - 1), -160 + 4 * 360 / (14 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (14 - 1), -160 + 5 * 360 / (14 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (14 - 1), -160 + 6 * 360 / (14 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (14 - 1), -160 + 7 * 360 / (14 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (14 - 1), -160 + 8 * 360 / (14 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (14 - 1), -160 + 9 * 360 / (14 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (14 - 1), -160 + 10 * 360 / (14 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (14 - 1), -160 + 11 * 360 / (14 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (14 - 1), -160 + 12 * 360 / (14 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (14 - 1), -160 + 13 * 360 / (14 - 1)));
                }
                break;
            case 95:
                InstantiateEnemy(21, new Vector3(0, 60));
                break;
            case 96:
                for (int i = 0; i < 10; i++)
                {
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (10 - 1), -160 + 0 * 360 / (10 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (10 - 1), -160 + 1 * 360 / (10 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (10 - 1), -160 + 2 * 360 / (10 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (10 - 1), -160 + 3 * 360 / (10 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (10 - 1), -160 + 4 * 360 / (10 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (10 - 1), -160 + 5 * 360 / (10 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (10 - 1), -160 + 6 * 360 / (10 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (10 - 1), -160 + 7 * 360 / (10 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (10 - 1), -160 + 8 * 360 / (10 - 1)));
                    InstantiateEnemy(18, new Vector3(-180 + i * 360 / (10 - 1), -160 + 9 * 360 / (10 - 1)));
                }
                for (int i = 0; i < 9; i++)
                {
                    InstantiateEnemy(20, new Vector3(-160 + i * 320 / (9 - 1), -140 + 0 * 320 / (9 - 1)));
                    InstantiateEnemy(20, new Vector3(-160 + i * 320 / (9 - 1), -140 + 1 * 320 / (9 - 1)));
                    InstantiateEnemy(20, new Vector3(-160 + i * 320 / (9 - 1), -140 + 2 * 320 / (9 - 1)));
                    InstantiateEnemy(20, new Vector3(-160 + i * 320 / (9 - 1), -140 + 3 * 320 / (9 - 1)));
                    InstantiateEnemy(20, new Vector3(-160 + i * 320 / (9 - 1), -140 + 4 * 320 / (9 - 1)));
                    InstantiateEnemy(20, new Vector3(-160 + i * 320 / (9 - 1), -140 + 5 * 320 / (9 - 1)));
                    InstantiateEnemy(20, new Vector3(-160 + i * 320 / (9 - 1), -140 + 6 * 320 / (9 - 1)));
                    InstantiateEnemy(20, new Vector3(-160 + i * 320 / (9 - 1), -140 + 7 * 320 / (9 - 1)));
                    InstantiateEnemy(20, new Vector3(-160 + i * 320 / (9 - 1), -140 + 8 * 320 / (9 - 1)));
                }
                break;
            case 97:
                InstantiateEnemy(21, new Vector3(0, 60));
                break;
            case 98:
                for (int i = 0; i < 10; i++)
                {
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (10 - 1), -160 + 0 * 360 / (10 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (10 - 1), -160 + 1 * 360 / (10 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (10 - 1), -160 + 2 * 360 / (10 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (10 - 1), -160 + 3 * 360 / (10 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (10 - 1), -160 + 4 * 360 / (10 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (10 - 1), -160 + 5 * 360 / (10 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (10 - 1), -160 + 6 * 360 / (10 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (10 - 1), -160 + 7 * 360 / (10 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (10 - 1), -160 + 8 * 360 / (10 - 1)));
                    InstantiateEnemy(20, new Vector3(-180 + i * 360 / (10 - 1), -160 + 9 * 360 / (10 - 1)));
                }

                for (int i = 0; i < 9; i++)
                {
                    InstantiateEnemy(18, new Vector3(-160 + i * 340 / (9 - 1), -140 + 0 * 340 / (9 - 1)));
                    InstantiateEnemy(18, new Vector3(-160 + i * 340 / (9 - 1), -140 + 1 * 340 / (9 - 1)));
                    InstantiateEnemy(18, new Vector3(-160 + i * 340 / (9 - 1), -140 + 2 * 340 / (9 - 1)));
                    InstantiateEnemy(18, new Vector3(-160 + i * 340 / (9 - 1), -140 + 3 * 340 / (9 - 1)));
                    InstantiateEnemy(18, new Vector3(-160 + i * 340 / (9 - 1), -140 + 4 * 340 / (9 - 1)));
                    InstantiateEnemy(18, new Vector3(-160 + i * 340 / (9 - 1), -140 + 5 * 340 / (9 - 1)));
                    InstantiateEnemy(18, new Vector3(-160 + i * 340 / (9 - 1), -140 + 6 * 340 / (9 - 1)));
                    InstantiateEnemy(18, new Vector3(-160 + i * 340 / (9 - 1), -140 + 7 * 340 / (9 - 1)));
                    InstantiateEnemy(18, new Vector3(-160 + i * 340 / (9 - 1), -140 + 8 * 340 / (9 - 1)));
                }
                break;
            case 99:
                InstantiateEnemy(21, new Vector3(0, 60));
                break;

            default:
                InstantiateEnemy(57, new Vector3(0, 0));

                break;
        }
    }

    public void InstantiateEnemy(int enemyIndex, Vector3 position, bool isChallange = false)
    {
        ENEMY game;
        if (isChallange)
        {
            game = Instantiate(main.C_enemies[enemyIndex], position + new Vector3(575, 325), new Quaternion(0, 0, 0, 0), main.Transforms[0]);
        }
        else
        {
            game = Instantiate(main.enemies[enemyIndex], position + new Vector3(575, 325), new Quaternion(0, 0, 0, 0), main.Transforms[0]);
        }
        game.gameObject.GetComponent<RectTransform>().anchoredPosition = position;//+ new Vector3(575, 325);
        //game.gameObject.GetComponent<RectTransform>().localPosition += new Vector3(0, 0, 6000);
    }


    // Update is called once per frame
    void Update () {
            gameObject.GetComponentsInChildren<TextMeshProUGUI>()[0].text = maxFloorNum1 + "%";
        if (main.DeathPanel.isPanel|| main.GameController.battleMode == GameController.BattleMode.challange)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
        }

    }
}
