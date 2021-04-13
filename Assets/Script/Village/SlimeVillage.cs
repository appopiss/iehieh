using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UsefulMethod;

public class SlimeVillage : BASE {


    public int floorNum { get => main.GameController.floorNum; set => main.GameController.floorNum = value; }
    public int maxFloorNum { get => main.GameController.maxFloorNum; set => main.GameController.maxFloorNum = value; }
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

        if (floorNum < Stage2WaveNum)
        {
            currentStage = Main.CurrentStage.stage1;
        }
        else if (floorNum >= Stage2WaveNum && floorNum < Stage3WaveNum)
        {
            currentStage = Main.CurrentStage.stage2;
        }
        else if (floorNum >= Stage3WaveNum && floorNum < Stage4WaveNum)
        {
            currentStage = Main.CurrentStage.stage3;
        }
        else if (floorNum >= Stage4WaveNum && floorNum < Stage5WaveNum)
        {
            currentStage = Main.CurrentStage.stage4;
        }
        else if (floorNum >= Stage5WaveNum && floorNum < Stage6WaveNum)
        {
            currentStage = Main.CurrentStage.stage5;
        }
        else if (floorNum >= Stage6WaveNum && floorNum < Stage7WaveNum)
        {
            currentStage = Main.CurrentStage.stage6;
        }
        else if (floorNum >= Stage7WaveNum && floorNum < Stage8WaveNum)
        {
            currentStage = Main.CurrentStage.stage7;
        }
        else if (floorNum >= Stage8WaveNum)
        {
            currentStage = Main.CurrentStage.stage8;
        }
        else
        {
            currentStage = Main.CurrentStage.stage1;
        }


        //Stage開放
        if (maxFloorNum >= Stage1WaveNum)
        {
            main.StageChangeButtonAry[0].SetActive(true);
        }
        if (maxFloorNum >= Stage2WaveNum)
        {
            main.StageChangeButtonAry[1].SetActive(true);
        }
        if (maxFloorNum >= Stage3WaveNum)
        {
            main.StageChangeButtonAry[2].SetActive(true);
        }
        if (maxFloorNum >= Stage4WaveNum)
        {
            main.StageChangeButtonAry[3].SetActive(true);
        }
        if (maxFloorNum >= Stage5WaveNum)
        {
            main.StageChangeButtonAry[4].SetActive(true);
        }
        if (maxFloorNum >= Stage6WaveNum)
        {
            main.StageChangeButtonAry[5].SetActive(true);
        }
        if (maxFloorNum >= Stage7WaveNum)
        {
            main.StageChangeButtonAry[6].SetActive(true);
        }
        if (maxFloorNum >= Stage8WaveNum)
        {
            main.StageChangeButtonAry[7].SetActive(true);
        }

        switch (currentStage)
        {
            case Main.CurrentStage.stage1:
                Field.GetComponent<Image>().sprite = main.StageSpriteAry[0];
                main.Texts[0].text = "STAGE 1\n<size=50%>WAVE  " + (floorNum + 1 - Stage1WaveNum).ToString() + " / " + (Stage2WaveNum - Stage1WaveNum).ToString();
                break;
            case Main.CurrentStage.stage2:
                Field.GetComponent<Image>().sprite = main.StageSpriteAry[1];
                main.Texts[0].text = "STAGE 2\n<size=50%>WAVE  " + (floorNum + 1 - Stage2WaveNum).ToString() + " / " + (Stage3WaveNum - Stage2WaveNum).ToString();
                break;
            case Main.CurrentStage.stage3:
                Field.GetComponent<Image>().sprite = main.StageSpriteAry[2];
                main.Texts[0].text = "STAGE 3\n<size=50%>WAVE  " + (floorNum + 1 - Stage3WaveNum).ToString() + " / " + (Stage4WaveNum - Stage3WaveNum).ToString();
                break;
            case Main.CurrentStage.stage4:
                Field.GetComponent<Image>().sprite = main.StageSpriteAry[3];
                main.Texts[0].text = "STAGE 4\n<size=50%>WAVE  " + (floorNum + 1 - Stage4WaveNum).ToString() + " / " + (Stage5WaveNum - Stage4WaveNum).ToString();
                break;
            case Main.CurrentStage.stage5:
                Field.GetComponent<Image>().sprite = main.StageSpriteAry[4];
                main.Texts[0].text = "STAGE 5\n<size=50%>WAVE  " + (floorNum + 1 - Stage5WaveNum).ToString() + " / " + (Stage6WaveNum - Stage5WaveNum).ToString();
                break;
            case Main.CurrentStage.stage6:
                Field.GetComponent<Image>().sprite = main.StageSpriteAry[5];
                main.Texts[0].text = "STAGE 6\n<size=50%>WAVE  " + (floorNum + 1 - Stage6WaveNum).ToString() + " / " + (Stage7WaveNum - Stage6WaveNum).ToString();
                break;
            case Main.CurrentStage.stage7:
                Field.GetComponent<Image>().sprite = main.StageSpriteAry[6];
                main.Texts[0].text = "STAGE 7\n<size=50%>WAVE  " + (floorNum + 1 - Stage7WaveNum).ToString() + " / " + (Stage8WaveNum - Stage7WaveNum).ToString();
                break;
            case Main.CurrentStage.stage8:
                Field.GetComponent<Image>().sprite = main.StageSpriteAry[7];
                main.Texts[0].text = "STAGE 8\n<size=50%>WAVE  " + (floorNum + 1 - Stage8WaveNum).ToString() + " / ∞";
                break;
            default:
                break;

        }
    }

    // Use this for initialization
    void Start () {
        Stage1WaveNum = main.GameController.Stage1WaveNum;
        Stage2WaveNum = main.GameController.Stage2WaveNum;
        Stage3WaveNum = main.GameController.Stage3WaveNum;
        Stage4WaveNum = main.GameController.Stage4WaveNum;
        Stage5WaveNum = main.GameController.Stage5WaveNum;
        Stage6WaveNum = main.GameController.Stage6WaveNum;
        Stage7WaveNum = main.GameController.Stage7WaveNum;
        Stage8WaveNum = main.GameController.Stage8WaveNum;
        Field = main.GameController.Field;

        main.StageChangeButtonAry[0].GetComponent<Button>().onClick.AddListener(() => { floorNum = Stage1WaveNum; main.GameController.initStage(); });
        main.StageChangeButtonAry[1].GetComponent<Button>().onClick.AddListener(() => { floorNum = Stage2WaveNum; main.GameController.initStage(); });
        main.StageChangeButtonAry[2].GetComponent<Button>().onClick.AddListener(() => { floorNum = Stage3WaveNum; main.GameController.initStage(); });
        main.StageChangeButtonAry[3].GetComponent<Button>().onClick.AddListener(() => { floorNum = Stage4WaveNum; main.GameController.initStage(); });
        main.StageChangeButtonAry[4].GetComponent<Button>().onClick.AddListener(() => { floorNum = Stage5WaveNum; main.GameController.initStage(); });
        main.StageChangeButtonAry[5].GetComponent<Button>().onClick.AddListener(() => { floorNum = Stage6WaveNum; main.GameController.initStage(); });
        main.StageChangeButtonAry[6].GetComponent<Button>().onClick.AddListener(() => { floorNum = Stage7WaveNum; main.GameController.initStage(); });
        main.StageChangeButtonAry[7].GetComponent<Button>().onClick.AddListener(() => { floorNum = Stage8WaveNum; main.GameController.initStage(); });

    }

    public void InstantiateEnemies(int floorNum)
    {
        switch (floorNum)
        {
            case 0:
                InstantiateEnemy(0, new Vector3(0, 160));
                break;
            case 1:
                InstantiateEnemy(0, new Vector3(100, 160));
                InstantiateEnemy(0, new Vector3(-100, 160));
                break;
            case 2:
                InstantiateEnemy(0, new Vector3(-130, 0));
                InstantiateEnemy(0, new Vector3(0, 130));
                InstantiateEnemy(0, new Vector3(130, 0));
                break;
            case 3:
                InstantiateEnemy(0, new Vector3(60, 100));
                InstantiateEnemy(0, new Vector3(-60, 100));
                InstantiateEnemy(0, new Vector3(-120, 0));
                InstantiateEnemy(0, new Vector3(120, 0));
                break;
            case 4:
                InstantiateEnemy(0, new Vector3(0, 0));
                InstantiateEnemy(0, new Vector3(80, 0));
                InstantiateEnemy(0, new Vector3(-80, 0));
                InstantiateEnemy(1, new Vector3(0, 160));
                break;
            case 5:
                InstantiateEnemy(0, new Vector3(0, 160));
                InstantiateEnemy(0, new Vector3(-80, 80));
                InstantiateEnemy(0, new Vector3(80, 80));
                InstantiateEnemy(0, new Vector3(0, 0));
                break;
            case 6:
                InstantiateEnemy(0, new Vector3(0, 160));
                InstantiateEnemy(0, new Vector3(130, 130));
                InstantiateEnemy(0, new Vector3(-130, 130));
                InstantiateEnemy(0, new Vector3(0, 40));
                InstantiateEnemy(0, new Vector3(0, 100));
                break;
            case 7:
                InstantiateEnemy(0, new Vector3(0, 160));
                InstantiateEnemy(0, new Vector3(100, 160));
                InstantiateEnemy(0, new Vector3(160, 100));
                InstantiateEnemy(0, new Vector3(-100, 160));
                InstantiateEnemy(0, new Vector3(-160, 100));
                break;
            case 8:
                InstantiateEnemy(0, new Vector3(0, 0));
                InstantiateEnemy(0, new Vector3(100, 0));
                InstantiateEnemy(0, new Vector3(-100, 0));
                InstantiateEnemy(0, new Vector3(-60, 60));
                InstantiateEnemy(0, new Vector3(60, 60));
                break;
            case 9:
                InstantiateEnemy(0, new Vector3(0, 10));
                InstantiateEnemy(0, new Vector3(80, 0));
                InstantiateEnemy(0, new Vector3(160, -20));
                InstantiateEnemy(0, new Vector3(-160, -20));
                InstantiateEnemy(0, new Vector3(-80, 0));
                InstantiateEnemy(1, new Vector3(0, 160));
                break;

            //Stage2
            case 10:
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(0, new Vector3(-80 + i * 80, 0));
                }
                for (int i = 0; i < 2; i++)
                {
                    InstantiateEnemy(1, new Vector3(-50 + i * 100, 120));
                }
                break;
            case 11:
                for (int i = 0; i < 5; i++)
                {
                    InstantiateEnemy(0, new Vector3(-160 + i * 80, -50 + i * 25));
                }
                for (int i = 0; i < 1; i++)
                {
                    InstantiateEnemy(1, new Vector3(0, 160));
                }
                break;
            case 12:
                for (int i = 0; i < 5; i++)
                {
                    InstantiateEnemy(0, new Vector3(-160 + i * 80, 50 + i * -25));
                }
                for (int i = 0; i < 2; i++)
                {
                    InstantiateEnemy(1, new Vector3(-50 + i * 100, 160));
                }
                break;
            case 13:
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(0, new Vector3(-90 + i * 90, 150));
                    InstantiateEnemy(0, new Vector3(-120 + i * 120, 100));
                }
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(1, new Vector3(0, -50 + i * 50));
                }
                break;
            case 14:
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(0, new Vector3(-160 + i * 160, 0));
                }
                for (int i = 0; i < 2; i++)
                {
                    InstantiateEnemy(1, new Vector3(-80 + i * 160, 0));
                }
                InstantiateEnemy(2, new Vector3(0, 160));
                break;
            case 15:
                for (int i = 0; i < 6; i++)
                {
                    InstantiateEnemy(0, new Vector3(0, -120 + i * 60));
                }
                for (int i = 0; i < 2; i++)
                {
                    InstantiateEnemy(1, new Vector3(-100 + i * 200, 160));
                }
                break;
            case 16:
                for (int i = 0; i < 7; i++)
                {
                    InstantiateEnemy(0, new Vector3(0, -150 + i * 50));
                }
                for (int i = 0; i < 2; i++)
                {
                    InstantiateEnemy(1, new Vector3(-60 + i * 120, 160));
                    InstantiateEnemy(1, new Vector3(-100 + i * 200, 80));
                    InstantiateEnemy(1, new Vector3(-140 + i * 280, 00));
                }
                break;
            case 17:
                for (int i = 0; i < 9; i++)
                {
                    InstantiateEnemy(0, new Vector3(0, -150 + i * 40));
                }
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(1, new Vector3(-120, -80 + i * 80));
                    InstantiateEnemy(1, new Vector3(120, -80 + i * 80));
                }
                break;
            case 18:
                for (int i = 0; i < 4; i++)
                {
                    InstantiateEnemy(0, new Vector3(-160 + i * 40, 160 - i * 40));
                    InstantiateEnemy(0, new Vector3(40 + i * 40, 40 + i * 40));
                }
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(1, new Vector3(0, 0 - i * 40));
                }
                break;
            case 19:
                InstantiateEnemy(2, new Vector3(-60, 160));
                InstantiateEnemy(2, new Vector3(60, 160));
                for (int i = 0; i < 4; i++)
                {
                    InstantiateEnemy(0, new Vector3(-160 + i * 40, 160 - i * 40));
                    InstantiateEnemy(0, new Vector3(40 + i * 40, 40 + i * 40));
                }
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(1, new Vector3(0, 0 - i * 40));
                }
                break;

            //Stage3
            case 20:
                InstantiateEnemy(3, new Vector3(100, 100));
                InstantiateEnemy(3, new Vector3(-100, 100));
                InstantiateEnemy(3, new Vector3(0, 100));
                InstantiateEnemy(3, new Vector3(150, 150));
                InstantiateEnemy(3, new Vector3(-150, 150));
                InstantiateEnemy(3, new Vector3(0, 50));
                InstantiateEnemy(3, new Vector3(0, -50));
                break;
            case 21:
                InstantiateEnemy(3, new Vector3(-150, 0));
                InstantiateEnemy(3, new Vector3(0, 75));
                InstantiateEnemy(3, new Vector3(150, 0));
                InstantiateEnemy(3, new Vector3(0, 0));
                InstantiateEnemy(3, new Vector3(100, 160));
                InstantiateEnemy(3, new Vector3(160, 100));
                InstantiateEnemy(3, new Vector3(-100, 160));
                InstantiateEnemy(3, new Vector3(-160, 100));
                InstantiateEnemy(2, new Vector3(0, 150));
                break;
            case 22:
                for (int i = 0; i < 9; i++)
                {
                    InstantiateEnemy(3, new Vector3(0, -150 + i * 40));
                }
                for (int i = 0; i < 4; i++)
                {
                    InstantiateEnemy(3, new Vector3(-120, -80 + i * 80));
                    InstantiateEnemy(3, new Vector3(120, -80 + i * 80));
                }
                break;
            case 23:
                for (int i = 0; i < 7; i++)
                {
                    InstantiateEnemy(3, new Vector3(-180 + i * 60, 0));
                }
                for (int i = 0; i < 2; i++)
                {
                    InstantiateEnemy(2, new Vector3(-100 + i * 200, 160));
                }
                break;
            case 24:
                for (int i = 0; i < 9; i++)
                {
                    InstantiateEnemy(3, new Vector3(-160 + i * 40, 0));
                }
                for (int i = 0; i < 5; i++)
                {
                    InstantiateEnemy(1, new Vector3(-160 + i * 80, -60));
                    InstantiateEnemy(0, new Vector3(-160 + i * 80, -60));
                }
                InstantiateEnemy(2, new Vector3(-100, 120));
                InstantiateEnemy(2, new Vector3(100, 120));
                break;
            case 25:
                InstantiateEnemy(4, new Vector3(0, 160));
                InstantiateEnemy(3, new Vector3(100, 160));
                InstantiateEnemy(2, new Vector3(160, 100));
                InstantiateEnemy(3, new Vector3(-100, 160));
                InstantiateEnemy(2, new Vector3(-160, 100));
                break;
            case 26:
                InstantiateEnemy(4, new Vector3(0, 160));
                InstantiateEnemy(2, new Vector3(130, 130));
                InstantiateEnemy(2, new Vector3(-130, 130));
                InstantiateEnemy(2, new Vector3(0, 40));
                InstantiateEnemy(2, new Vector3(-65, 40));
                InstantiateEnemy(2, new Vector3(65, 40));
                break;
            case 27:
                InstantiateEnemy(2, new Vector3(0, 10));
                InstantiateEnemy(2, new Vector3(80, 0));
                InstantiateEnemy(2, new Vector3(160, -20));
                InstantiateEnemy(2, new Vector3(-160, -20));
                InstantiateEnemy(2, new Vector3(-80, 0));
                InstantiateEnemy(0, new Vector3(0, 70));
                InstantiateEnemy(0, new Vector3(80, 60));
                InstantiateEnemy(0, new Vector3(160, 40));
                InstantiateEnemy(0, new Vector3(-160, 40));
                InstantiateEnemy(0, new Vector3(-80, 60));
                InstantiateEnemy(4, new Vector3(0, 160));
                break;
            case 28:
                InstantiateEnemy(2, new Vector3(0, 10));
                InstantiateEnemy(2, new Vector3(80, 0));
                InstantiateEnemy(2, new Vector3(160, -20));
                InstantiateEnemy(2, new Vector3(-160, -20));
                InstantiateEnemy(2, new Vector3(-80, 0));
                InstantiateEnemy(3, new Vector3(0, 70));
                InstantiateEnemy(3, new Vector3(80, 60));
                InstantiateEnemy(3, new Vector3(160, 40));
                InstantiateEnemy(3, new Vector3(-160, 40));
                InstantiateEnemy(3, new Vector3(-80, 60));
                InstantiateEnemy(4, new Vector3(0, 160));
                break;
            case 29:
                for (int i = 0; i < 9; i++)
                {
                    InstantiateEnemy(2, new Vector3(-160 + i * 40, 0));
                }
                for (int i = 0; i < 5; i++)
                {
                    InstantiateEnemy(3, new Vector3(-160 + i * 80, -60));
                    InstantiateEnemy(1, new Vector3(-160 + i * 80, -120));
                }
                InstantiateEnemy(4, new Vector3(-100, 120));
                InstantiateEnemy(4, new Vector3(100, 120));
                break;

            //Stage4                
            case 30:
                InstantiateEnemy(6, new Vector3(0, 60));
                InstantiateEnemy(6, new Vector3(150, 60));
                InstantiateEnemy(6, new Vector3(-150, 60));
                InstantiateEnemy(6, new Vector3(80, 160));
                InstantiateEnemy(6, new Vector3(-80, 160));
                InstantiateEnemy(6, new Vector3(0, -20));
                break;
            case 31:
                InstantiateEnemy(6, new Vector3(0, 60));
                InstantiateEnemy(6, new Vector3(180, 60));
                InstantiateEnemy(6, new Vector3(-180, 60));
                InstantiateEnemy(6, new Vector3(90, 60));
                InstantiateEnemy(6, new Vector3(-90, 60));
                InstantiateEnemy(6, new Vector3(0, 120));
                InstantiateEnemy(6, new Vector3(180, 120));
                InstantiateEnemy(6, new Vector3(-180, 120));
                InstantiateEnemy(6, new Vector3(90, 120));
                InstantiateEnemy(6, new Vector3(-90, 120));
                break;
            case 32:
                InstantiateEnemy(6, new Vector3(0, 0));
                InstantiateEnemy(6, new Vector3(180, 0));
                InstantiateEnemy(6, new Vector3(-180, 0));
                InstantiateEnemy(6, new Vector3(90, 0));
                InstantiateEnemy(6, new Vector3(-90, 0));
                InstantiateEnemy(6, new Vector3(60, 60));
                InstantiateEnemy(6, new Vector3(120, 60));
                InstantiateEnemy(6, new Vector3(0, 60));
                InstantiateEnemy(6, new Vector3(-60, 60));
                InstantiateEnemy(6, new Vector3(-120, 60));
                InstantiateEnemy(6, new Vector3(0, 120));
                InstantiateEnemy(6, new Vector3(180, 120));
                InstantiateEnemy(6, new Vector3(-180, 120));
                InstantiateEnemy(6, new Vector3(90, 120));
                InstantiateEnemy(6, new Vector3(-90, 120));
                break;
            case 33:
                InstantiateEnemy(6, new Vector3(0, 0));
                InstantiateEnemy(6, new Vector3(90, 0));
                InstantiateEnemy(6, new Vector3(-90, 0));
                InstantiateEnemy(6, new Vector3(60, 60));
                InstantiateEnemy(6, new Vector3(120, 60));
                InstantiateEnemy(6, new Vector3(0, 60));
                InstantiateEnemy(6, new Vector3(-60, 60));
                InstantiateEnemy(6, new Vector3(-120, 60));
                InstantiateEnemy(6, new Vector3(0, 120));
                InstantiateEnemy(6, new Vector3(180, 120));
                InstantiateEnemy(6, new Vector3(-180, 120));
                InstantiateEnemy(6, new Vector3(90, 120));
                InstantiateEnemy(6, new Vector3(-90, 120));
                InstantiateEnemy(6, new Vector3(-60, -60));
                InstantiateEnemy(6, new Vector3(0, -60));
                InstantiateEnemy(6, new Vector3(60, -60));
                InstantiateEnemy(6, new Vector3(0, -120));
                break;
            case 34:
                InstantiateEnemy(6, new Vector3(0, 180));
                InstantiateEnemy(6, new Vector3(0, 120));
                InstantiateEnemy(6, new Vector3(0, 60));
                InstantiateEnemy(6, new Vector3(0, 0));
                InstantiateEnemy(6, new Vector3(0, -60));
                InstantiateEnemy(6, new Vector3(0, -120));
                InstantiateEnemy(6, new Vector3(60, 150));
                InstantiateEnemy(6, new Vector3(60, 90));
                InstantiateEnemy(6, new Vector3(60, 30));
                InstantiateEnemy(6, new Vector3(60, -30));
                InstantiateEnemy(6, new Vector3(60, -90));
                InstantiateEnemy(6, new Vector3(-60, 150));
                InstantiateEnemy(6, new Vector3(-60, 90));
                InstantiateEnemy(6, new Vector3(-60, 30));
                InstantiateEnemy(6, new Vector3(-60, -30));
                InstantiateEnemy(6, new Vector3(-60, -90));
                InstantiateEnemy(6, new Vector3(120, 180));
                InstantiateEnemy(6, new Vector3(120, 120));
                InstantiateEnemy(6, new Vector3(120, 60));
                InstantiateEnemy(6, new Vector3(120, 0));
                InstantiateEnemy(6, new Vector3(120, -60));
                InstantiateEnemy(6, new Vector3(120, -120));
                InstantiateEnemy(6, new Vector3(-120, 180));
                InstantiateEnemy(6, new Vector3(-120, 120));
                InstantiateEnemy(6, new Vector3(-120, 60));
                InstantiateEnemy(6, new Vector3(-120, 0));
                InstantiateEnemy(6, new Vector3(-120, -60));
                InstantiateEnemy(6, new Vector3(-120, -120));
                break;
            case 35:
                InstantiateEnemy(6, new Vector3(0, 180));
                InstantiateEnemy(6, new Vector3(0, 120));
                InstantiateEnemy(6, new Vector3(0, 60));
                InstantiateEnemy(6, new Vector3(0, 0));
                InstantiateEnemy(6, new Vector3(0, -60));
                InstantiateEnemy(6, new Vector3(0, -120));
                InstantiateEnemy(6, new Vector3(60, 150));
                InstantiateEnemy(6, new Vector3(60, 90));
                InstantiateEnemy(6, new Vector3(60, 30));
                InstantiateEnemy(6, new Vector3(60, -30));
                InstantiateEnemy(6, new Vector3(60, -90));
                InstantiateEnemy(6, new Vector3(-60, 150));
                InstantiateEnemy(6, new Vector3(-60, 90));
                InstantiateEnemy(6, new Vector3(-60, 30));
                InstantiateEnemy(6, new Vector3(-60, -30));
                InstantiateEnemy(6, new Vector3(-60, -90));
                InstantiateEnemy(6, new Vector3(120, 180));
                InstantiateEnemy(6, new Vector3(120, 120));
                InstantiateEnemy(6, new Vector3(120, 60));
                InstantiateEnemy(6, new Vector3(120, 0));
                InstantiateEnemy(6, new Vector3(120, -60));
                InstantiateEnemy(6, new Vector3(120, -120));
                InstantiateEnemy(6, new Vector3(-120, 180));
                InstantiateEnemy(6, new Vector3(-120, 120));
                InstantiateEnemy(6, new Vector3(-120, 60));
                InstantiateEnemy(6, new Vector3(-120, 0));
                InstantiateEnemy(6, new Vector3(-120, -60));
                InstantiateEnemy(6, new Vector3(-120, -120));
                InstantiateEnemy(6, new Vector3(180, 150));
                InstantiateEnemy(6, new Vector3(180, 90));
                InstantiateEnemy(6, new Vector3(180, 30));
                InstantiateEnemy(6, new Vector3(180, -30));
                InstantiateEnemy(6, new Vector3(180, -90));
                InstantiateEnemy(6, new Vector3(-180, 150));
                InstantiateEnemy(6, new Vector3(-180, 90));
                InstantiateEnemy(6, new Vector3(-180, 30));
                InstantiateEnemy(6, new Vector3(-180, -30));
                InstantiateEnemy(6, new Vector3(-180, -90));
                break;
            case 36:
                InstantiateEnemy(6, new Vector3(0, 200));
                InstantiateEnemy(6, new Vector3(0, 150));
                InstantiateEnemy(6, new Vector3(0, 100));
                InstantiateEnemy(6, new Vector3(0, 50));
                InstantiateEnemy(6, new Vector3(0, 0));
                InstantiateEnemy(6, new Vector3(0, -50));
                InstantiateEnemy(6, new Vector3(0, -100));
                InstantiateEnemy(6, new Vector3(0, -150));
                InstantiateEnemy(6, new Vector3(50, 200));
                InstantiateEnemy(6, new Vector3(50, 150));
                InstantiateEnemy(6, new Vector3(50, 100));
                InstantiateEnemy(6, new Vector3(50, 50));
                InstantiateEnemy(6, new Vector3(50, 0));
                InstantiateEnemy(6, new Vector3(50, -50));
                InstantiateEnemy(6, new Vector3(50, -100));
                InstantiateEnemy(6, new Vector3(50, -150));
                InstantiateEnemy(6, new Vector3(100, 200));
                InstantiateEnemy(6, new Vector3(100, 150));
                InstantiateEnemy(6, new Vector3(100, 100));
                InstantiateEnemy(6, new Vector3(100, 50));
                InstantiateEnemy(6, new Vector3(100, 0));
                InstantiateEnemy(6, new Vector3(100, -50));
                InstantiateEnemy(6, new Vector3(100, -100));
                InstantiateEnemy(6, new Vector3(100, -150));
                InstantiateEnemy(6, new Vector3(150, 200));
                InstantiateEnemy(6, new Vector3(150, 150));
                InstantiateEnemy(6, new Vector3(150, 100));
                InstantiateEnemy(6, new Vector3(150, 50));
                InstantiateEnemy(6, new Vector3(150, 0));
                InstantiateEnemy(6, new Vector3(150, -50));
                InstantiateEnemy(6, new Vector3(150, -100));
                InstantiateEnemy(6, new Vector3(150, -150));
                InstantiateEnemy(6, new Vector3(-50, 200));
                InstantiateEnemy(6, new Vector3(-50, 150));
                InstantiateEnemy(6, new Vector3(-50, 100));
                InstantiateEnemy(6, new Vector3(-50, 50));
                InstantiateEnemy(6, new Vector3(-50, 0));
                InstantiateEnemy(6, new Vector3(-50, -50));
                InstantiateEnemy(6, new Vector3(-50, -100));
                InstantiateEnemy(6, new Vector3(-50, -150));
                InstantiateEnemy(6, new Vector3(-100, 200));
                InstantiateEnemy(6, new Vector3(-100, 150));
                InstantiateEnemy(6, new Vector3(-100, 100));
                InstantiateEnemy(6, new Vector3(-100, 50));
                InstantiateEnemy(6, new Vector3(-100, 0));
                InstantiateEnemy(6, new Vector3(-100, -50));
                InstantiateEnemy(6, new Vector3(-100, -100));
                InstantiateEnemy(6, new Vector3(-100, -150));
                InstantiateEnemy(6, new Vector3(-150, 200));
                InstantiateEnemy(6, new Vector3(-150, 150));
                InstantiateEnemy(6, new Vector3(-150, 100));
                InstantiateEnemy(6, new Vector3(-150, 50));
                InstantiateEnemy(6, new Vector3(-150, 0));
                InstantiateEnemy(6, new Vector3(-150, -50));
                InstantiateEnemy(6, new Vector3(-150, -100));
                InstantiateEnemy(6, new Vector3(-150, -150));
                break;
            case 37:
                InstantiateEnemy(6, new Vector3(25, 175));
                InstantiateEnemy(6, new Vector3(25, 125));
                InstantiateEnemy(6, new Vector3(25, 75));
                InstantiateEnemy(6, new Vector3(25, 25));
                InstantiateEnemy(6, new Vector3(25, -25));
                InstantiateEnemy(6, new Vector3(25, -75));
                InstantiateEnemy(6, new Vector3(25, -125));
                InstantiateEnemy(6, new Vector3(25, -175));
                InstantiateEnemy(6, new Vector3(75, 175));
                InstantiateEnemy(6, new Vector3(75, 125));
                InstantiateEnemy(6, new Vector3(75, 75));
                InstantiateEnemy(6, new Vector3(75, 25));
                InstantiateEnemy(6, new Vector3(75, -25));
                InstantiateEnemy(6, new Vector3(75, -75));
                InstantiateEnemy(6, new Vector3(75, -125));
                InstantiateEnemy(6, new Vector3(75, -175));
                InstantiateEnemy(6, new Vector3(125, 175));
                InstantiateEnemy(6, new Vector3(125, 125));
                InstantiateEnemy(6, new Vector3(125, 75));
                InstantiateEnemy(6, new Vector3(125, 25));
                InstantiateEnemy(6, new Vector3(125, -25));
                InstantiateEnemy(6, new Vector3(125, -75));
                InstantiateEnemy(6, new Vector3(125, -125));
                InstantiateEnemy(6, new Vector3(125, -175));
                InstantiateEnemy(6, new Vector3(175, 175));
                InstantiateEnemy(6, new Vector3(175, 125));
                InstantiateEnemy(6, new Vector3(175, 75));
                InstantiateEnemy(6, new Vector3(175, 25));
                InstantiateEnemy(6, new Vector3(175, -25));
                InstantiateEnemy(6, new Vector3(175, -75));
                InstantiateEnemy(6, new Vector3(175, -125));
                InstantiateEnemy(6, new Vector3(175, -175));
                InstantiateEnemy(6, new Vector3(-25, 175));
                InstantiateEnemy(6, new Vector3(-25, 125));
                InstantiateEnemy(6, new Vector3(-25, 75));
                InstantiateEnemy(6, new Vector3(-25, 25));
                InstantiateEnemy(6, new Vector3(-25, -25));
                InstantiateEnemy(6, new Vector3(-25, -75));
                InstantiateEnemy(6, new Vector3(-25, -125));
                InstantiateEnemy(6, new Vector3(-25, -175));
                InstantiateEnemy(6, new Vector3(-75, 175));
                InstantiateEnemy(6, new Vector3(-75, 125));
                InstantiateEnemy(6, new Vector3(-75, 75));
                InstantiateEnemy(6, new Vector3(-75, 25));
                InstantiateEnemy(6, new Vector3(-75, -25));
                InstantiateEnemy(6, new Vector3(-75, -75));
                InstantiateEnemy(6, new Vector3(-75, -125));
                InstantiateEnemy(6, new Vector3(-75, -175));
                InstantiateEnemy(6, new Vector3(-125, 175));
                InstantiateEnemy(6, new Vector3(-125, 125));
                InstantiateEnemy(6, new Vector3(-125, 75));
                InstantiateEnemy(6, new Vector3(-125, 25));
                InstantiateEnemy(6, new Vector3(-125, -25));
                InstantiateEnemy(6, new Vector3(-125, -75));
                InstantiateEnemy(6, new Vector3(-125, -125));
                InstantiateEnemy(6, new Vector3(-125, -175));
                InstantiateEnemy(6, new Vector3(-175, 175));
                InstantiateEnemy(6, new Vector3(-175, 125));
                InstantiateEnemy(6, new Vector3(-175, 75));
                InstantiateEnemy(6, new Vector3(-175, 25));
                InstantiateEnemy(6, new Vector3(-175, -25));
                InstantiateEnemy(6, new Vector3(-175, -75));
                InstantiateEnemy(6, new Vector3(-175, -125));
                InstantiateEnemy(6, new Vector3(-175, -175));
                break;
            case 38:
                InstantiateEnemy(6, new Vector3(0, 200));
                InstantiateEnemy(6, new Vector3(0, 150));
                InstantiateEnemy(6, new Vector3(0, 100));
                InstantiateEnemy(6, new Vector3(0, 50));
                InstantiateEnemy(6, new Vector3(0, 0));
                InstantiateEnemy(6, new Vector3(0, -50));
                InstantiateEnemy(6, new Vector3(0, -100));
                InstantiateEnemy(6, new Vector3(0, -150));
                InstantiateEnemy(6, new Vector3(25, 175));
                InstantiateEnemy(6, new Vector3(25, 125));
                InstantiateEnemy(6, new Vector3(25, 75));
                InstantiateEnemy(6, new Vector3(25, 25));
                InstantiateEnemy(6, new Vector3(25, -25));
                InstantiateEnemy(6, new Vector3(25, -75));
                InstantiateEnemy(6, new Vector3(25, -125));
                InstantiateEnemy(6, new Vector3(25, -175));
                InstantiateEnemy(6, new Vector3(50, 200));
                InstantiateEnemy(6, new Vector3(50, 150));
                InstantiateEnemy(6, new Vector3(50, 100));
                InstantiateEnemy(6, new Vector3(50, 50));
                InstantiateEnemy(6, new Vector3(50, 0));
                InstantiateEnemy(6, new Vector3(50, -50));
                InstantiateEnemy(6, new Vector3(50, -100));
                InstantiateEnemy(6, new Vector3(50, -150));
                InstantiateEnemy(6, new Vector3(75, 175));
                InstantiateEnemy(6, new Vector3(75, 125));
                InstantiateEnemy(6, new Vector3(75, 75));
                InstantiateEnemy(6, new Vector3(75, 25));
                InstantiateEnemy(6, new Vector3(75, -25));
                InstantiateEnemy(6, new Vector3(75, -75));
                InstantiateEnemy(6, new Vector3(75, -125));
                InstantiateEnemy(6, new Vector3(75, -175));
                InstantiateEnemy(6, new Vector3(100, 200));
                InstantiateEnemy(6, new Vector3(100, 150));
                InstantiateEnemy(6, new Vector3(100, 100));
                InstantiateEnemy(6, new Vector3(100, 50));
                InstantiateEnemy(6, new Vector3(100, 0));
                InstantiateEnemy(6, new Vector3(100, -50));
                InstantiateEnemy(6, new Vector3(100, -100));
                InstantiateEnemy(6, new Vector3(100, -150));
                InstantiateEnemy(6, new Vector3(125, 175));
                InstantiateEnemy(6, new Vector3(125, 125));
                InstantiateEnemy(6, new Vector3(125, 75));
                InstantiateEnemy(6, new Vector3(125, 25));
                InstantiateEnemy(6, new Vector3(125, -25));
                InstantiateEnemy(6, new Vector3(125, -75));
                InstantiateEnemy(6, new Vector3(125, -125));
                InstantiateEnemy(6, new Vector3(125, -175));
                InstantiateEnemy(6, new Vector3(150, 200));
                InstantiateEnemy(6, new Vector3(150, 150));
                InstantiateEnemy(6, new Vector3(150, 100));
                InstantiateEnemy(6, new Vector3(150, 50));
                InstantiateEnemy(6, new Vector3(150, 0));
                InstantiateEnemy(6, new Vector3(150, -50));
                InstantiateEnemy(6, new Vector3(150, -100));
                InstantiateEnemy(6, new Vector3(150, -150));
                InstantiateEnemy(6, new Vector3(175, 175));
                InstantiateEnemy(6, new Vector3(175, 125));
                InstantiateEnemy(6, new Vector3(175, 75));
                InstantiateEnemy(6, new Vector3(175, 25));
                InstantiateEnemy(6, new Vector3(175, -25));
                InstantiateEnemy(6, new Vector3(175, -75));
                InstantiateEnemy(6, new Vector3(175, -125));
                InstantiateEnemy(6, new Vector3(175, -175));
                InstantiateEnemy(6, new Vector3(-25, 175));
                InstantiateEnemy(6, new Vector3(-25, 125));
                InstantiateEnemy(6, new Vector3(-25, 75));
                InstantiateEnemy(6, new Vector3(-25, 25));
                InstantiateEnemy(6, new Vector3(-25, -25));
                InstantiateEnemy(6, new Vector3(-25, -75));
                InstantiateEnemy(6, new Vector3(-25, -125));
                InstantiateEnemy(6, new Vector3(-25, -175));
                InstantiateEnemy(6, new Vector3(-50, 200));
                InstantiateEnemy(6, new Vector3(-50, 150));
                InstantiateEnemy(6, new Vector3(-50, 100));
                InstantiateEnemy(6, new Vector3(-50, 50));
                InstantiateEnemy(6, new Vector3(-50, 0));
                InstantiateEnemy(6, new Vector3(-50, -50));
                InstantiateEnemy(6, new Vector3(-50, -100));
                InstantiateEnemy(6, new Vector3(-50, -150));
                InstantiateEnemy(6, new Vector3(-75, 175));
                InstantiateEnemy(6, new Vector3(-75, 125));
                InstantiateEnemy(6, new Vector3(-75, 75));
                InstantiateEnemy(6, new Vector3(-75, 25));
                InstantiateEnemy(6, new Vector3(-75, -25));
                InstantiateEnemy(6, new Vector3(-75, -75));
                InstantiateEnemy(6, new Vector3(-75, -125));
                InstantiateEnemy(6, new Vector3(-75, -175));
                InstantiateEnemy(6, new Vector3(-100, 200));
                InstantiateEnemy(6, new Vector3(-100, 150));
                InstantiateEnemy(6, new Vector3(-100, 100));
                InstantiateEnemy(6, new Vector3(-100, 50));
                InstantiateEnemy(6, new Vector3(-100, 0));
                InstantiateEnemy(6, new Vector3(-100, -50));
                InstantiateEnemy(6, new Vector3(-100, -100));
                InstantiateEnemy(6, new Vector3(-100, -150));
                InstantiateEnemy(6, new Vector3(-125, 175));
                InstantiateEnemy(6, new Vector3(-125, 125));
                InstantiateEnemy(6, new Vector3(-125, 75));
                InstantiateEnemy(6, new Vector3(-125, 25));
                InstantiateEnemy(6, new Vector3(-125, -25));
                InstantiateEnemy(6, new Vector3(-125, -75));
                InstantiateEnemy(6, new Vector3(-125, -125));
                InstantiateEnemy(6, new Vector3(-125, -175));
                InstantiateEnemy(6, new Vector3(-150, 200));
                InstantiateEnemy(6, new Vector3(-150, 150));
                InstantiateEnemy(6, new Vector3(-150, 100));
                InstantiateEnemy(6, new Vector3(-150, 50));
                InstantiateEnemy(6, new Vector3(-150, 0));
                InstantiateEnemy(6, new Vector3(-150, -50));
                InstantiateEnemy(6, new Vector3(-150, -100));
                InstantiateEnemy(6, new Vector3(-150, -150));
                InstantiateEnemy(6, new Vector3(-175, 175));
                InstantiateEnemy(6, new Vector3(-175, 125));
                InstantiateEnemy(6, new Vector3(-175, 75));
                InstantiateEnemy(6, new Vector3(-175, 25));
                InstantiateEnemy(6, new Vector3(-175, -25));
                InstantiateEnemy(6, new Vector3(-175, -75));
                InstantiateEnemy(6, new Vector3(-175, -125));
                InstantiateEnemy(6, new Vector3(-175, -175));
                break;
            case 39:
                for (int i = 0; i < 7; i++)
                {
                    InstantiateEnemy(6, new Vector3(0, -175 + 50 * i));
                }
                for (int i = 0; i < 7; i++)
                {
                    InstantiateEnemy(6, new Vector3(25 + 25 * i, -150 + 25 * i));
                    InstantiateEnemy(6, new Vector3(-25 - 25 * i, -150 + 25 * i));
                }
                InstantiateEnemy(5, new Vector3(0, 170));
                break;

            //Stage5
            case 40:
                randomEnemyNum = UnityEngine.Random.Range(0, 6);
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-100 + 100 * i, UnityEngine.Random.Range(0, 150)));
                }
                break;
            case 41:
                randomEnemyNum = UnityEngine.Random.Range(0, 6);
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-100 + 100 * i, UnityEngine.Random.Range(0, 150)));
                }
                break;
            case 42:
                randomEnemyNum = UnityEngine.Random.Range(0, 6);
                for (int i = 0; i < 4; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-120 + 80 * i, UnityEngine.Random.Range(0, 150)));
                }
                break;
            case 43:
                randomEnemyNum = UnityEngine.Random.Range(0, 6);
                for (int i = 0; i < 4; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-120 + 80 * i, UnityEngine.Random.Range(-60, 180)));
                }
                break;
            case 44:
                randomEnemyNum = UnityEngine.Random.Range(0, 6);
                for (int i = 0; i < 5; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-120 + 60 * i, UnityEngine.Random.Range(-60, 180)));
                }
                break;
            case 45:
                randomEnemyNum = UnityEngine.Random.Range(0, 6);
                for (int i = 0; i < 5; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-120 + 60 * i, UnityEngine.Random.Range(-60, 180)));
                }
                break;
            case 46:
                randomEnemyNum = UnityEngine.Random.Range(0, 6);
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-120 + 120 * i, UnityEngine.Random.Range(60, 180)));
                }
                randomEnemyNum = UnityEngine.Random.Range(0, 6);
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-120 + 120 * i, UnityEngine.Random.Range(-60, 60)));
                }
                break;
            case 47:
                randomEnemyNum = UnityEngine.Random.Range(0, 6);
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-120 + 120 * i, UnityEngine.Random.Range(60, 180)));
                }
                randomEnemyNum = UnityEngine.Random.Range(0, 6);
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-120 + 120 * i, UnityEngine.Random.Range(-60, 60)));
                }
                break;
            case 48:
                randomEnemyNum = UnityEngine.Random.Range(0, 6);
                for (int i = 0; i < 4; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-150 + 100 * i, UnityEngine.Random.Range(60, 180)));
                }
                randomEnemyNum = UnityEngine.Random.Range(0, 6);
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-120 + 120 * i, UnityEngine.Random.Range(-60, 60)));
                }
                break;
            case 49:
                randomEnemyNum = UnityEngine.Random.Range(0, 6);
                for (int i = 0; i < 4; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-150 + 100 * i, UnityEngine.Random.Range(60, 180)));
                }
                randomEnemyNum = UnityEngine.Random.Range(0, 6);
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-120 + 120 * i, UnityEngine.Random.Range(-60, 60)));
                }
                break;
            case 50:
                randomEnemyNum = UnityEngine.Random.Range(0, 6);
                for (int i = 0; i < 4; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-150 + 100 * i, UnityEngine.Random.Range(100, 160)));
                }
                randomEnemyNum = UnityEngine.Random.Range(0, 6);
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-120 + 120 * i, UnityEngine.Random.Range(20, 100)));
                }
                randomEnemyNum = UnityEngine.Random.Range(0, 6);
                for (int i = 0; i < 2; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-60 + 120 * i, UnityEngine.Random.Range(-60, 20)));
                }
                break;
            case 51:
                randomEnemyNum = UnityEngine.Random.Range(0, 6);
                for (int i = 0; i < 4; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-150 + 100 * i, UnityEngine.Random.Range(100, 160)));
                }
                randomEnemyNum = UnityEngine.Random.Range(0, 6);
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-120 + 120 * i, UnityEngine.Random.Range(20, 100)));
                }
                randomEnemyNum = UnityEngine.Random.Range(0, 6);
                for (int i = 0; i < 2; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-60 + 120 * i, UnityEngine.Random.Range(-60, 20)));
                }
                break;
            case 52:
                randomEnemyNum = UnityEngine.Random.Range(0, 6);
                for (int i = 0; i < 6; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(0 + UnityEngine.Random.Range(-15, 15), -120 + i * 60 + UnityEngine.Random.Range(-15, 15)));
                }
                randomEnemyNum = UnityEngine.Random.Range(0, 6);
                for (int i = 0; i < 2; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-100 + i * 200 + UnityEngine.Random.Range(-15, 15), 160 + UnityEngine.Random.Range(-15, 15)));
                }
                break;
            case 53:
                randomEnemyNum = UnityEngine.Random.Range(0, 6);
                for (int i = 0; i < 7; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(0 + UnityEngine.Random.Range(-15, 15), -150 + i * 50 + UnityEngine.Random.Range(-15, 15)));
                }
                randomEnemyNum = UnityEngine.Random.Range(0, 6);
                for (int i = 0; i < 2; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-60 + i * 120 + UnityEngine.Random.Range(-15, 15), 160 + UnityEngine.Random.Range(-15, 15)));
                    InstantiateEnemy(randomEnemyNum, new Vector3(-100 + i * 200 + UnityEngine.Random.Range(-15, 15), 80 + UnityEngine.Random.Range(-15, 15)));
                    InstantiateEnemy(randomEnemyNum, new Vector3(-140 + i * 280 + UnityEngine.Random.Range(-15, 15), 00 + UnityEngine.Random.Range(-15, 15)));
                }
                break;
            case 54:
                randomEnemyNum = UnityEngine.Random.Range(0, 6);
                for (int i = 0; i < 9; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(0 + UnityEngine.Random.Range(-15, 15), -150 + i * 40 + UnityEngine.Random.Range(-15, 15)));
                }
                randomEnemyNum = UnityEngine.Random.Range(0, 6);
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-120 + UnityEngine.Random.Range(-15, 15), -80 + i * 80 + UnityEngine.Random.Range(-15, 15)));
                    InstantiateEnemy(randomEnemyNum, new Vector3(120 + UnityEngine.Random.Range(-15, 15), -80 + i * 80 + UnityEngine.Random.Range(-15, 15)));
                }
                break;
            case 55:
                randomEnemyNum = UnityEngine.Random.Range(0, 6);
                for (int i = 0; i < 4; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-160 + i * 40 + UnityEngine.Random.Range(-15, 15), 160 - i * 40 + UnityEngine.Random.Range(-15, 15)));
                    InstantiateEnemy(randomEnemyNum, new Vector3(40 + i * 40 + UnityEngine.Random.Range(-15, 15), 40 + i * 40 + UnityEngine.Random.Range(-15, 15)));
                }
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(0 + UnityEngine.Random.Range(-15, 15), 0 - i * 40 + UnityEngine.Random.Range(-15, 15)));
                }
                break;
            case 56:
                randomEnemyNum = UnityEngine.Random.Range(0, 6);
                for (int i = 0; i < 7; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(0 + UnityEngine.Random.Range(-15, 15), -150 + i * 50 + UnityEngine.Random.Range(-15, 15)));
                }
                randomEnemyNum = UnityEngine.Random.Range(0, 6);
                for (int i = 0; i < 2; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-60 + i * 120 + UnityEngine.Random.Range(-15, 15), 160 + UnityEngine.Random.Range(-15, 15)));
                    InstantiateEnemy(randomEnemyNum, new Vector3(-100 + i * 200 + UnityEngine.Random.Range(-15, 15), 80 + UnityEngine.Random.Range(-15, 15)));
                    InstantiateEnemy(randomEnemyNum, new Vector3(-140 + i * 280 + UnityEngine.Random.Range(-15, 15), 00 + UnityEngine.Random.Range(-15, 15)));
                }
                break;
            case 57:
                randomEnemyNum = UnityEngine.Random.Range(0, 6);
                for (int i = 0; i < 9; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(0 + UnityEngine.Random.Range(-15, 15), -150 + i * 40 + UnityEngine.Random.Range(-15, 15)));
                }
                randomEnemyNum = UnityEngine.Random.Range(0, 6);
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-120 + UnityEngine.Random.Range(-15, 15), -80 + i * 80 + UnityEngine.Random.Range(-15, 15)));
                    InstantiateEnemy(randomEnemyNum, new Vector3(120 + UnityEngine.Random.Range(-15, 15), -80 + i * 80 + UnityEngine.Random.Range(-15, 15)));
                }
                break;
            case 58:
                randomEnemyNum = UnityEngine.Random.Range(0, 6);
                for (int i = 0; i < 4; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(-160 + i * 40 + UnityEngine.Random.Range(-15, 15), 160 - i * 40 + UnityEngine.Random.Range(-15, 15)));
                    InstantiateEnemy(randomEnemyNum, new Vector3(40 + i * 40 + UnityEngine.Random.Range(-15, 15), 40 + i * 40 + UnityEngine.Random.Range(-15, 15)));
                }
                randomEnemyNum = UnityEngine.Random.Range(0, 6);
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(randomEnemyNum, new Vector3(0 + UnityEngine.Random.Range(-15, 15), 0 - i * 40 + UnityEngine.Random.Range(-15, 15)));
                }
                break;
            case 59:
                InstantiateEnemy(7, new Vector3(0, 50));
                break;

            //Stage6
            case 60:
                InstantiateEnemy(8, new Vector3(0, 120));
                InstantiateEnemy(8, new Vector3(0, 40));
                InstantiateEnemy(8, new Vector3(0, -40));
                break;
            case 61:
                InstantiateEnemy(9, new Vector3(0, 120));
                InstantiateEnemy(9, new Vector3(0, 40));
                InstantiateEnemy(9, new Vector3(0, -40));
                break;
            case 62:
                InstantiateEnemy(8, new Vector3(-100, -100));
                InstantiateEnemy(8, new Vector3(80, -60));
                InstantiateEnemy(8, new Vector3(40, 20));
                InstantiateEnemy(8, new Vector3(-20, 60));
                break;
            case 63:
                InstantiateEnemy(9, new Vector3(-100, -100));
                InstantiateEnemy(9, new Vector3(80, -60));
                InstantiateEnemy(9, new Vector3(40, 20));
                InstantiateEnemy(9, new Vector3(-20, 60));
                break;
            case 64:
                InstantiateEnemy(8, new Vector3(-60, -20));
                InstantiateEnemy(9, new Vector3(40, 20));
                InstantiateEnemy(8, new Vector3(-20, 60));
                InstantiateEnemy(9, new Vector3(0, 100));
                InstantiateEnemy(8, new Vector3(0, 140));
                break;
            case 65:
                InstantiateEnemy(9, new Vector3(-60, -20));
                InstantiateEnemy(8, new Vector3(40, 20));
                InstantiateEnemy(9, new Vector3(-20, 60));
                InstantiateEnemy(8, new Vector3(0, 100));
                InstantiateEnemy(9, new Vector3(0, 140));
                break;

            case 66:
                InstantiateEnemy(8, new Vector3(-100, -100));
                InstantiateEnemy(8, new Vector3(80, -60));
                InstantiateEnemy(8, new Vector3(-60, -20));
                InstantiateEnemy(8, new Vector3(40, 20));
                InstantiateEnemy(8, new Vector3(-20, 60));
                InstantiateEnemy(8, new Vector3(0, 100));
                break;
            case 67:
                InstantiateEnemy(9, new Vector3(-100, -100));
                InstantiateEnemy(9, new Vector3(80, -60));
                InstantiateEnemy(9, new Vector3(-60, -20));
                InstantiateEnemy(9, new Vector3(40, 20));
                InstantiateEnemy(9, new Vector3(-20, 60));
                InstantiateEnemy(9, new Vector3(0, 100));
                break;
            case 68:
                InstantiateEnemy(8, new Vector3(-100, -100));
                InstantiateEnemy(9, new Vector3(80, -60));
                InstantiateEnemy(8, new Vector3(-60, -20));
                InstantiateEnemy(9, new Vector3(40, 20));
                InstantiateEnemy(8, new Vector3(-20, 60));
                InstantiateEnemy(9, new Vector3(0, 100));
                InstantiateEnemy(8, new Vector3(0, 140));
                break;
            case 69:
                InstantiateEnemy(9, new Vector3(-100, -100));
                InstantiateEnemy(8, new Vector3(80, -60));
                InstantiateEnemy(9, new Vector3(-60, -20));
                InstantiateEnemy(8, new Vector3(40, 20));
                InstantiateEnemy(9, new Vector3(-20, 60));
                InstantiateEnemy(8, new Vector3(0, 100));
                InstantiateEnemy(9, new Vector3(0, 140));
                break;
            case 70:
                InstantiateEnemy(10, new Vector3(100, 100));
                InstantiateEnemy(10, new Vector3(-100, 100));
                InstantiateEnemy(10, new Vector3(0, 100));
                InstantiateEnemy(10, new Vector3(150, 150));
                InstantiateEnemy(10, new Vector3(-150, 150));
                InstantiateEnemy(10, new Vector3(0, 50));
                InstantiateEnemy(10, new Vector3(0, -50));
                break;
            case 71:
                InstantiateEnemy(10, new Vector3(-150, 0));
                InstantiateEnemy(10, new Vector3(0, 75));
                InstantiateEnemy(10, new Vector3(150, 0));
                InstantiateEnemy(10, new Vector3(0, 0));
                InstantiateEnemy(10, new Vector3(100, 160));
                InstantiateEnemy(10, new Vector3(160, 100));
                InstantiateEnemy(10, new Vector3(-100, 160));
                InstantiateEnemy(10, new Vector3(-160, 100));
                InstantiateEnemy(9, new Vector3(0, 150));
                break;
            case 72:
                for (int i = 0; i < 9; i++)
                {
                    InstantiateEnemy(10, new Vector3(0, -150 + i * 40));
                }
                break;
            case 73:
                for (int i = 0; i < 7; i++)
                {
                    InstantiateEnemy(10, new Vector3(-180 + i * 60, 0));
                }
                for (int i = 0; i < 2; i++)
                {
                    InstantiateEnemy(8, new Vector3(-100 + i * 200, 160));
                }
                break;
            case 74:
                for (int i = 0; i < 9; i++)
                {
                    InstantiateEnemy(10, new Vector3(-160 + i * 40, 0));
                }
                for (int i = 0; i < 5; i++)
                {
                    InstantiateEnemy(10, new Vector3(-160 + i * 80, -60));
                    InstantiateEnemy(10, new Vector3(-160 + i * 80, -60));
                }
                InstantiateEnemy(8, new Vector3(-100, 120));
                InstantiateEnemy(9, new Vector3(100, 120));
                break;
            case 75:
                InstantiateEnemy(10, new Vector3(0, 160));
                InstantiateEnemy(10, new Vector3(100, 160));
                InstantiateEnemy(10, new Vector3(160, 100));
                InstantiateEnemy(10, new Vector3(-100, 160));
                InstantiateEnemy(10, new Vector3(-160, 100));
                InstantiateEnemy(9, new Vector3(0, 160));
                InstantiateEnemy(9, new Vector3(100, 160));
                InstantiateEnemy(9, new Vector3(160, 100));
                InstantiateEnemy(9, new Vector3(-100, 160));
                InstantiateEnemy(9, new Vector3(-160, 100));
                break;
            case 76:
                InstantiateEnemy(7, new Vector3(100, 80));
                InstantiateEnemy(7, new Vector3(-100, 80));
                break;
            case 77:
                InstantiateEnemy(10, new Vector3(0, 0));
                InstantiateEnemy(10, new Vector3(40, 10));
                InstantiateEnemy(10, new Vector3(80, 30));
                InstantiateEnemy(10, new Vector3(120, 60));
                InstantiateEnemy(10, new Vector3(160, 100));
                InstantiateEnemy(10, new Vector3(-40, 10));
                InstantiateEnemy(10, new Vector3(-80, 30));
                InstantiateEnemy(10, new Vector3(-120, 60));
                InstantiateEnemy(10, new Vector3(-160, 100));
                InstantiateEnemy(10, new Vector3(0, 120));
                InstantiateEnemy(10, new Vector3(40, 130));
                InstantiateEnemy(10, new Vector3(80, 150));
                InstantiateEnemy(10, new Vector3(120, 180));
                InstantiateEnemy(10, new Vector3(-40, 130));
                InstantiateEnemy(10, new Vector3(-80, 150));
                InstantiateEnemy(10, new Vector3(-120, 180));
                break;
            case 78:
                InstantiateEnemy(10, new Vector3(0, 0));
                InstantiateEnemy(10, new Vector3(40, 10));
                InstantiateEnemy(10, new Vector3(80, 30));
                InstantiateEnemy(10, new Vector3(120, 60));
                InstantiateEnemy(10, new Vector3(160, 100));
                InstantiateEnemy(10, new Vector3(-40, 10));
                InstantiateEnemy(10, new Vector3(-80, 30));
                InstantiateEnemy(10, new Vector3(-120, 60));
                InstantiateEnemy(10, new Vector3(-160, 100));
                InstantiateEnemy(10, new Vector3(0, 60));
                InstantiateEnemy(10, new Vector3(40, 70));
                InstantiateEnemy(10, new Vector3(80, 90));
                InstantiateEnemy(10, new Vector3(120, 120));
                InstantiateEnemy(10, new Vector3(160, 160));
                InstantiateEnemy(10, new Vector3(-40, 70));
                InstantiateEnemy(10, new Vector3(-80, 90));
                InstantiateEnemy(10, new Vector3(-120, 120));
                InstantiateEnemy(10, new Vector3(-160, 160));
                InstantiateEnemy(10, new Vector3(0, 120));
                InstantiateEnemy(10, new Vector3(40, 130));
                InstantiateEnemy(10, new Vector3(80, 150));
                InstantiateEnemy(10, new Vector3(120, 180));
                InstantiateEnemy(10, new Vector3(-40, 130));
                InstantiateEnemy(10, new Vector3(-80, 150));
                InstantiateEnemy(10, new Vector3(-120, 180));
                InstantiateEnemy(9, new Vector3(0, 180));
                break;
            case 79:
                InstantiateEnemy(11, new Vector3(0, 80));
                break;

            //Stage7
            case 80:
                for (int i = 0; i < 8; i++)
                {
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (8 - 1), -160 + 0 * 360 / (8 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (8 - 1), -160 + 1 * 360 / (8 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (8 - 1), -160 + 2 * 360 / (8 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (8 - 1), -160 + 3 * 360 / (8 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (8 - 1), -160 + 4 * 360 / (8 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (8 - 1), -160 + 5 * 360 / (8 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (8 - 1), -160 + 6 * 360 / (8 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (8 - 1), -160 + 7 * 360 / (8 - 1)));
                }
                break;
            case 81:
                InstantiateEnemy(7, new Vector3(0, 0));
                break;
            case 82:
                for (int i = 0; i < 8; i++)
                {
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (8 - 1), -160 + 0 * 360 / (8 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (8 - 1), -160 + 1 * 360 / (8 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (8 - 1), -160 + 2 * 360 / (8 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (8 - 1), -160 + 3 * 360 / (8 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (8 - 1), -160 + 4 * 360 / (8 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (8 - 1), -160 + 5 * 360 / (8 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (8 - 1), -160 + 6 * 360 / (8 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (8 - 1), -160 + 7 * 360 / (8 - 1)));
                }
                break;
            case 83:
                InstantiateEnemy(11, new Vector3(0, 0));
                break;
            case 84:
                for (int i = 0; i < 10; i++)
                {
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (10 - 1), -160 + 0 * 360 / (10 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (10 - 1), -160 + 1 * 360 / (10 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (10 - 1), -160 + 2 * 360 / (10 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (10 - 1), -160 + 3 * 360 / (10 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (10 - 1), -160 + 4 * 360 / (10 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (10 - 1), -160 + 5 * 360 / (10 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (10 - 1), -160 + 6 * 360 / (10 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (10 - 1), -160 + 7 * 360 / (10 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (10 - 1), -160 + 8 * 360 / (10 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (10 - 1), -160 + 9 * 360 / (10 - 1)));
                }
                break;
            case 85:
                InstantiateEnemy(7, new Vector3(0, 0));
                break;
            case 86:
                for (int i = 0; i < 10; i++)
                {
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (10 - 1), -160 + 0 * 360 / (10 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (10 - 1), -160 + 1 * 360 / (10 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (10 - 1), -160 + 2 * 360 / (10 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (10 - 1), -160 + 3 * 360 / (10 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (10 - 1), -160 + 4 * 360 / (10 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (10 - 1), -160 + 5 * 360 / (10 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (10 - 1), -160 + 6 * 360 / (10 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (10 - 1), -160 + 7 * 360 / (10 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (10 - 1), -160 + 8 * 360 / (10 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (10 - 1), -160 + 9 * 360 / (10 - 1)));
                }
                break;
            case 87:
                InstantiateEnemy(11, new Vector3(0, 0));
                break;
            case 88:
                for (int i = 0; i < 12; i++)
                {
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (12 - 1), -160 + 0 * 360 / (12 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (12 - 1), -160 + 1 * 360 / (12 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (12 - 1), -160 + 2 * 360 / (12 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (12 - 1), -160 + 3 * 360 / (12 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (12 - 1), -160 + 4 * 360 / (12 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (12 - 1), -160 + 5 * 360 / (12 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (12 - 1), -160 + 6 * 360 / (12 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (12 - 1), -160 + 7 * 360 / (12 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (12 - 1), -160 + 8 * 360 / (12 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (12 - 1), -160 + 9 * 360 / (12 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (12 - 1), -160 + 10 * 360 / (12 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (12 - 1), -160 + 11 * 360 / (12 - 1)));
                }
                break;
            case 89:
                InstantiateEnemy(7, new Vector3(0, 0));
                break;
            case 90:
                for (int i = 0; i < 12; i++)
                {
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (12 - 1), -160 + 0 * 360 / (12 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (12 - 1), -160 + 1 * 360 / (12 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (12 - 1), -160 + 2 * 360 / (12 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (12 - 1), -160 + 3 * 360 / (12 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (12 - 1), -160 + 4 * 360 / (12 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (12 - 1), -160 + 5 * 360 / (12 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (12 - 1), -160 + 6 * 360 / (12 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (12 - 1), -160 + 7 * 360 / (12 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (12 - 1), -160 + 8 * 360 / (12 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (12 - 1), -160 + 9 * 360 / (12 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (12 - 1), -160 + 10 * 360 / (12 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (12 - 1), -160 + 11 * 360 / (12 - 1)));
                }
                break;
            case 91:
                InstantiateEnemy(11, new Vector3(0, 0));
                break;
            case 92:
                for (int i = 0; i < 14; i++)
                {
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (14 - 1), -160 + 0 * 360 / (14 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (14 - 1), -160 + 1 * 360 / (14 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (14 - 1), -160 + 2 * 360 / (14 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (14 - 1), -160 + 3 * 360 / (14 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (14 - 1), -160 + 4 * 360 / (14 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (14 - 1), -160 + 5 * 360 / (14 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (14 - 1), -160 + 6 * 360 / (14 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (14 - 1), -160 + 7 * 360 / (14 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (14 - 1), -160 + 8 * 360 / (14 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (14 - 1), -160 + 9 * 360 / (14 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (14 - 1), -160 + 10 * 360 / (14 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (14 - 1), -160 + 11 * 360 / (14 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (14 - 1), -160 + 12 * 360 / (14 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (14 - 1), -160 + 13 * 360 / (14 - 1)));
                }
                break;
            case 93:
                InstantiateEnemy(7, new Vector3(0, 0));
                break;
            case 94:
                for (int i = 0; i < 14; i++)
                {
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (14 - 1), -160 + 0 * 360 / (14 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (14 - 1), -160 + 1 * 360 / (14 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (14 - 1), -160 + 2 * 360 / (14 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (14 - 1), -160 + 3 * 360 / (14 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (14 - 1), -160 + 4 * 360 / (14 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (14 - 1), -160 + 5 * 360 / (14 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (14 - 1), -160 + 6 * 360 / (14 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (14 - 1), -160 + 7 * 360 / (14 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (14 - 1), -160 + 8 * 360 / (14 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (14 - 1), -160 + 9 * 360 / (14 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (14 - 1), -160 + 10 * 360 / (14 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (14 - 1), -160 + 11 * 360 / (14 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (14 - 1), -160 + 12 * 360 / (14 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (14 - 1), -160 + 13 * 360 / (14 - 1)));
                }
                break;
            case 95:
                InstantiateEnemy(11, new Vector3(0, 0));
                break;
            case 96:
                for (int i = 0; i < 10; i++)
                {
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (10 - 1), -160 + 0 * 360 / (10 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (10 - 1), -160 + 1 * 360 / (10 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (10 - 1), -160 + 2 * 360 / (10 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (10 - 1), -160 + 3 * 360 / (10 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (10 - 1), -160 + 4 * 360 / (10 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (10 - 1), -160 + 5 * 360 / (10 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (10 - 1), -160 + 6 * 360 / (10 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (10 - 1), -160 + 7 * 360 / (10 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (10 - 1), -160 + 8 * 360 / (10 - 1)));
                    InstantiateEnemy(12, new Vector3(-180 + i * 360 / (10 - 1), -160 + 9 * 360 / (10 - 1)));
                }
                for (int i = 0; i < 9; i++)
                {
                    InstantiateEnemy(13, new Vector3(-160 + i * 320 / (9 - 1), -140 + 0 * 320 / (9 - 1)));
                    InstantiateEnemy(13, new Vector3(-160 + i * 320 / (9 - 1), -140 + 1 * 320 / (9 - 1)));
                    InstantiateEnemy(13, new Vector3(-160 + i * 320 / (9 - 1), -140 + 2 * 320 / (9 - 1)));
                    InstantiateEnemy(13, new Vector3(-160 + i * 320 / (9 - 1), -140 + 3 * 320 / (9 - 1)));
                    InstantiateEnemy(13, new Vector3(-160 + i * 320 / (9 - 1), -140 + 4 * 320 / (9 - 1)));
                    InstantiateEnemy(13, new Vector3(-160 + i * 320 / (9 - 1), -140 + 5 * 320 / (9 - 1)));
                    InstantiateEnemy(13, new Vector3(-160 + i * 320 / (9 - 1), -140 + 6 * 320 / (9 - 1)));
                    InstantiateEnemy(13, new Vector3(-160 + i * 320 / (9 - 1), -140 + 7 * 320 / (9 - 1)));
                    InstantiateEnemy(13, new Vector3(-160 + i * 320 / (9 - 1), -140 + 8 * 320 / (9 - 1)));
                }
                break;
            case 97:
                InstantiateEnemy(7, new Vector3(0, 0));
                break;
            case 98:
                for (int i = 0; i < 10; i++)
                {
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (10 - 1), -160 + 0 * 360 / (10 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (10 - 1), -160 + 1 * 360 / (10 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (10 - 1), -160 + 2 * 360 / (10 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (10 - 1), -160 + 3 * 360 / (10 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (10 - 1), -160 + 4 * 360 / (10 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (10 - 1), -160 + 5 * 360 / (10 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (10 - 1), -160 + 6 * 360 / (10 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (10 - 1), -160 + 7 * 360 / (10 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (10 - 1), -160 + 8 * 360 / (10 - 1)));
                    InstantiateEnemy(13, new Vector3(-180 + i * 360 / (10 - 1), -160 + 9 * 360 / (10 - 1)));
                }

                for (int i = 0; i < 9; i++)
                {
                    InstantiateEnemy(12, new Vector3(-160 + i * 340 / (9 - 1), -140 + 0 * 340 / (9 - 1)));
                    InstantiateEnemy(12, new Vector3(-160 + i * 340 / (9 - 1), -140 + 1 * 340 / (9 - 1)));
                    InstantiateEnemy(12, new Vector3(-160 + i * 340 / (9 - 1), -140 + 2 * 340 / (9 - 1)));
                    InstantiateEnemy(12, new Vector3(-160 + i * 340 / (9 - 1), -140 + 3 * 340 / (9 - 1)));
                    InstantiateEnemy(12, new Vector3(-160 + i * 340 / (9 - 1), -140 + 4 * 340 / (9 - 1)));
                    InstantiateEnemy(12, new Vector3(-160 + i * 340 / (9 - 1), -140 + 5 * 340 / (9 - 1)));
                    InstantiateEnemy(12, new Vector3(-160 + i * 340 / (9 - 1), -140 + 6 * 340 / (9 - 1)));
                    InstantiateEnemy(12, new Vector3(-160 + i * 340 / (9 - 1), -140 + 7 * 340 / (9 - 1)));
                    InstantiateEnemy(12, new Vector3(-160 + i * 340 / (9 - 1), -140 + 8 * 340 / (9 - 1)));
                }
                break;
            case 99:
                InstantiateEnemy(11, new Vector3(0, 0));
                break;

            default:
                InstantiateEnemy(14, new Vector3(0, 50));
                break;
        }
    }

    public void InstantiateEnemy(int enemyIndex, Vector3 position)
    {
        ENEMY game;
        game = Instantiate(main.enemies[enemyIndex], position + new Vector3(575, 325), new Quaternion(0, 0, 0, 0), main.Transforms[0]);
        game.EnemyIndex = enemyIndex;
        game.gameObject.GetComponent<RectTransform>().anchoredPosition = position;//+ new Vector3(575, 325);
        //game.gameObject.GetComponent<RectTransform>().localPosition += new Vector3(0, 0, 6000);
    }


    // Update is called once per frame
    void Update () {
        gameObject.GetComponentsInChildren<TextMeshProUGUI>()[0].text = maxFloorNum + "%";
        if (main.DeathPanel.isPanel || main.GameController.battleMode == GameController.BattleMode.challange)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
        }

    }
}
