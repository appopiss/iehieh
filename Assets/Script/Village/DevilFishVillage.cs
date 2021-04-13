using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UsefulMethod;

public class DevilFishVillage : BASE {


    public int floorNum3 { get => main.GameController.floorNum3; set => main.GameController.floorNum3 = value; }
    public int maxFloorNum3 { get => main.GameController.maxFloorNum3; set => main.GameController.maxFloorNum3 = value; }
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

        if (floorNum3 < Stage2WaveNum)
        {
            currentStage = Main.CurrentStage.stage1;
        }
        else if (floorNum3 >= Stage2WaveNum && floorNum3 < Stage3WaveNum)
        {
            currentStage = Main.CurrentStage.stage2;
        }
        else if (floorNum3 >= Stage3WaveNum && floorNum3 < Stage4WaveNum)
        {
            currentStage = Main.CurrentStage.stage3;
        }
        else if (floorNum3 >= Stage4WaveNum && floorNum3 < Stage5WaveNum)
        {
            currentStage = Main.CurrentStage.stage4;
        }
        else if (floorNum3 >= Stage5WaveNum && floorNum3 < Stage6WaveNum)
        {
            currentStage = Main.CurrentStage.stage5;
        }
        else if (floorNum3 >= Stage6WaveNum && floorNum3 < Stage7WaveNum)
        {
            currentStage = Main.CurrentStage.stage6;
        }
        else if (floorNum3 >= Stage7WaveNum && floorNum3 < Stage8WaveNum)
        {
            currentStage = Main.CurrentStage.stage7;
        }
        else if (floorNum3 >= Stage8WaveNum)
        {
            currentStage = Main.CurrentStage.stage8;
        }
        else
        {
            currentStage = Main.CurrentStage.stage1;
        }

        //Stage開放
        if (maxFloorNum3 >= Stage1WaveNum)
        {
            main.StageChangeButtonAry[24].SetActive(true);
        }
        if (maxFloorNum3 >= Stage2WaveNum)
        {
            main.StageChangeButtonAry[25].SetActive(true);
        }
        if (maxFloorNum3 >= Stage3WaveNum)
        {
            main.StageChangeButtonAry[26].SetActive(true);
        }
        if (maxFloorNum3 >= Stage4WaveNum)
        {
            main.StageChangeButtonAry[27].SetActive(true);
        }
        if (maxFloorNum3 >= Stage5WaveNum)
        {
            main.StageChangeButtonAry[28].SetActive(true);
        }
        if (maxFloorNum3 >= Stage6WaveNum)
        {
            main.StageChangeButtonAry[29].SetActive(true);
        }
        if (maxFloorNum3 >= Stage7WaveNum)
        {
            main.StageChangeButtonAry[30].SetActive(true);
        }
        if (maxFloorNum3 >= Stage8WaveNum)
        {
            main.StageChangeButtonAry[31].SetActive(true);
        }

        switch (currentStage)
        {
            case Main.CurrentStage.stage1:
                Field.GetComponent<Image>().sprite = main.StageSpriteAry[24];
                main.Texts[0].text = "STAGE 1\n<size=50%>WAVE  " + (floorNum3 + 1 - Stage1WaveNum).ToString() + " / " + (Stage2WaveNum - Stage1WaveNum).ToString();
                break;
            case Main.CurrentStage.stage2:
                Field.GetComponent<Image>().sprite = main.StageSpriteAry[25];
                main.Texts[0].text = "STAGE 2\n<size=50%>WAVE  " + (floorNum3 + 1 - Stage2WaveNum).ToString() + " / " + (Stage3WaveNum - Stage2WaveNum).ToString();
                break;
            case Main.CurrentStage.stage3:
                Field.GetComponent<Image>().sprite = main.StageSpriteAry[26];
                main.Texts[0].text = "STAGE 3\n<size=50%>WAVE  " + (floorNum3 + 1 - Stage3WaveNum).ToString() + " / " + (Stage4WaveNum - Stage3WaveNum).ToString();
                break;
            case Main.CurrentStage.stage4:
                Field.GetComponent<Image>().sprite = main.StageSpriteAry[27];
                main.Texts[0].text = "STAGE 4\n<size=50%>WAVE  " + (floorNum3 + 1 - Stage4WaveNum).ToString() + " / " + (Stage5WaveNum - Stage4WaveNum).ToString();
                break;
            case Main.CurrentStage.stage5:
                Field.GetComponent<Image>().sprite = main.StageSpriteAry[28];
                main.Texts[0].text = "STAGE 5\n<size=50%>WAVE  " + (floorNum3 + 1 - Stage5WaveNum).ToString() + " / " + (Stage6WaveNum - Stage5WaveNum).ToString();
                break;
            case Main.CurrentStage.stage6:
                Field.GetComponent<Image>().sprite = main.StageSpriteAry[29];
                main.Texts[0].text = "STAGE 6\n<size=50%>WAVE  " + (floorNum3 + 1 - Stage6WaveNum).ToString() + " / " + (Stage7WaveNum - Stage6WaveNum).ToString();
                break;
            case Main.CurrentStage.stage7:
                Field.GetComponent<Image>().sprite = main.StageSpriteAry[30];
                main.Texts[0].text = "STAGE 7\n<size=50%>WAVE  " + (floorNum3 + 1 - Stage7WaveNum).ToString() + " / " + (Stage8WaveNum - Stage7WaveNum).ToString();
                break;
            case Main.CurrentStage.stage8:
                Field.GetComponent<Image>().sprite = main.StageSpriteAry[31];
                main.Texts[0].text = "STAGE 8\n<size=50%>WAVE  " + (floorNum3 + 1 - Stage8WaveNum).ToString() + " / ∞";
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

        //main.StageChangeButtonAry[24].GetComponent<Button>().onClick.AddListener(() => { floorNum3 = Stage1WaveNum; main.GameController.initStage(); });
        //main.StageChangeButtonAry[25].GetComponent<Button>().onClick.AddListener(() => { floorNum3 = Stage2WaveNum; main.GameController.initStage(); });
        //main.StageChangeButtonAry[26].GetComponent<Button>().onClick.AddListener(() => { floorNum3 = Stage3WaveNum; main.GameController.initStage(); });
        //main.StageChangeButtonAry[27].GetComponent<Button>().onClick.AddListener(() => { floorNum3 = Stage4WaveNum; main.GameController.initStage(); });
        //main.StageChangeButtonAry[28].GetComponent<Button>().onClick.AddListener(() => { floorNum3 = Stage5WaveNum; main.GameController.initStage(); });
        //main.StageChangeButtonAry[29].GetComponent<Button>().onClick.AddListener(() => { floorNum3 = Stage6WaveNum; main.GameController.initStage(); });
        //main.StageChangeButtonAry[30].GetComponent<Button>().onClick.AddListener(() => { floorNum3 = Stage7WaveNum; main.GameController.initStage(); });
        //main.StageChangeButtonAry[31].GetComponent<Button>().onClick.AddListener(() => { floorNum3 = Stage8WaveNum; main.GameController.initStage(); });


    }

    public void InstantiateEnemies3(int floorNum3)
    {
        switch (floorNum3)
        {
            case 0:
                InstantiateEnemy(43, new Vector3(120, 160));
                InstantiateEnemy(43, new Vector3(60, 100));
                InstantiateEnemy(43, new Vector3(0, 40));
                InstantiateEnemy(43, new Vector3(-60, -20));
                break;
            case 1:
                for (int i = 0; i < 5; i++)
                {
                    InstantiateEnemy(43, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 2:
                for (int i = 0; i < 5; i++)
                {
                    InstantiateEnemy(43, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 3:
                for (int i = 0; i < 5; i++)
                {
                    InstantiateEnemy(43, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 4:
                InstantiateEnemy(43, new Vector3(120, 0 + 50));
                InstantiateEnemy(43, new Vector3(60, 60 + 50));
                InstantiateEnemy(43, new Vector3(60, -60 + 50));
                InstantiateEnemy(43, new Vector3(0, 120 + 50));
                InstantiateEnemy(43, new Vector3(0, -120 + 50));
                InstantiateEnemy(43, new Vector3(-60, 60 + 50));
                InstantiateEnemy(43, new Vector3(-60, -60 + 50));
                InstantiateEnemy(43, new Vector3(-120, 0 + 50));
                break;
            case 5:
                for (int i = 0; i < 8; i++)
                {
                    InstantiateEnemy(43, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 6:
                for (int i = 0; i < 8; i++)
                {
                    InstantiateEnemy(43, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 7:
                for (int i = 0; i < 8; i++)
                {
                    InstantiateEnemy(43, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 8:
                for (int i = 0; i < 8; i++)
                {
                    InstantiateEnemy(43, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 9:
                InstantiateEnemy(43, new Vector3(120, 0 + 50));
                InstantiateEnemy(43, new Vector3(60, 60 + 50));
                InstantiateEnemy(43, new Vector3(60, -60 + 50));
                InstantiateEnemy(43, new Vector3(0, 120 + 50));
                InstantiateEnemy(43, new Vector3(0, -120 + 50));
                InstantiateEnemy(43, new Vector3(30, 90 + 50));
                InstantiateEnemy(43, new Vector3(30, -90 + 50));
                InstantiateEnemy(43, new Vector3(90, 30 + 50));
                InstantiateEnemy(43, new Vector3(90, -30 + 50));
                break;

            //Stage2
            case 10:
                InstantiateEnemy(44, new Vector3(-120, 60 + 50));
                InstantiateEnemy(43, new Vector3(120, 60 + 50));
                break;
            case 11:
                InstantiateEnemy(44, new Vector3(-120, 60 + 50));
                InstantiateEnemy(43, new Vector3(120, 60 + 50));
                InstantiateEnemy(43, new Vector3(-120, 50));
                InstantiateEnemy(44, new Vector3(120, 50));
                break;
            case 12:
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(43, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 2; i++)
                {
                    InstantiateEnemy(44, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 13:
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(43, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 2; i++)
                {
                    InstantiateEnemy(44, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 14:
                InstantiateEnemy(43, new Vector3(120, 0 + 50));
                InstantiateEnemy(44, new Vector3(60, 60 + 50));
                InstantiateEnemy(44, new Vector3(60, -60 + 50));
                InstantiateEnemy(43, new Vector3(0, 120 + 50));
                InstantiateEnemy(43, new Vector3(0, -120 + 50));
                InstantiateEnemy(44, new Vector3(-60, 60 + 50));
                InstantiateEnemy(44, new Vector3(-60, -60 + 50));
                InstantiateEnemy(43, new Vector3(-120, 0 + 50));
                break;
            case 15:
                for (int i = 0; i < 4; i++)
                {
                    InstantiateEnemy(43, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 4; i++)
                {
                    InstantiateEnemy(44, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 16:
                for (int i = 0; i < 4; i++)
                {
                    InstantiateEnemy(43, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 4; i++)
                {
                    InstantiateEnemy(44, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 17:
                for (int i = 0; i < 4; i++)
                {
                    InstantiateEnemy(43, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 4; i++)
                {
                    InstantiateEnemy(44, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 18:
                for (int i = 0; i < 4; i++)
                {
                    InstantiateEnemy(43, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 4; i++)
                {
                    InstantiateEnemy(44, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 19:
                InstantiateEnemy(44, new Vector3(120, 0 + 50));
                InstantiateEnemy(44, new Vector3(60, 60 + 50));
                InstantiateEnemy(44, new Vector3(60, -60 + 50));
                InstantiateEnemy(44, new Vector3(0, 120 + 50));
                InstantiateEnemy(44, new Vector3(0, -120 + 50));
                InstantiateEnemy(43, new Vector3(-60, 60 + 50));
                InstantiateEnemy(43, new Vector3(-60, -60 + 50));
                InstantiateEnemy(43, new Vector3(-120, 0 + 50));
                InstantiateEnemy(44, new Vector3(0, 0 + 50));
                InstantiateEnemy(43, new Vector3(0, 90 + 50));
                InstantiateEnemy(43, new Vector3(0, -90 + 50));
                break;

            //Stage3
            case 20:
                for (int i = 0; i < 6; i++)
                {
                    InstantiateEnemy(43, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 6; i++)
                {
                    InstantiateEnemy(44, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 21:
                for (int i = 0; i < 6; i++)
                {
                    InstantiateEnemy(43, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 6; i++)
                {
                    InstantiateEnemy(44, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 22:
                for (int i = 0; i < 6; i++)
                {
                    InstantiateEnemy(43, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 6; i++)
                {
                    InstantiateEnemy(44, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 23:
                for (int i = 0; i < 6; i++)
                {
                    InstantiateEnemy(43, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 6; i++)
                {
                    InstantiateEnemy(44, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 24:
                InstantiateEnemy(44, new Vector3(120, 0 + 50));
                InstantiateEnemy(44, new Vector3(60, 60 + 50));
                InstantiateEnemy(44, new Vector3(60, -60 + 50));
                InstantiateEnemy(44, new Vector3(0, 120 + 50));
                InstantiateEnemy(44, new Vector3(0, -120 + 50));
                InstantiateEnemy(43, new Vector3(-60, 60 + 50));
                InstantiateEnemy(43, new Vector3(-60, -60 + 50));
                InstantiateEnemy(43, new Vector3(-120, 0 + 50));
                InstantiateEnemy(44, new Vector3(0, 0 + 50));
                InstantiateEnemy(43, new Vector3(0, 90 + 50));
                InstantiateEnemy(43, new Vector3(0, -90 + 50));
                InstantiateEnemy(43, new Vector3(-160, -90));
                InstantiateEnemy(44, new Vector3(160, -90));
                InstantiateEnemy(43, new Vector3(-80, -150));
                InstantiateEnemy(44, new Vector3(80, -150));
                break;
            case 25:
                for (int i = 0; i < 8; i++)
                {
                    InstantiateEnemy(43, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 8; i++)
                {
                    InstantiateEnemy(44, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 26:
                for (int i = 0; i < 8; i++)
                {
                    InstantiateEnemy(43, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 8; i++)
                {
                    InstantiateEnemy(44, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 27:
                for (int i = 0; i < 8; i++)
                {
                    InstantiateEnemy(43, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 8; i++)
                {
                    InstantiateEnemy(44, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 28:
                for (int i = 0; i < 8; i++)
                {
                    InstantiateEnemy(43, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 8; i++)
                {
                    InstantiateEnemy(44, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 29:
                InstantiateEnemy(43, new Vector3(30, 0 + 0));
                InstantiateEnemy(43, new Vector3(60, 40 + 0));
                InstantiateEnemy(43, new Vector3(60, -40 + 0));
                InstantiateEnemy(43, new Vector3(90, 80 + 0));
                InstantiateEnemy(43, new Vector3(90, -80 + 0));
                InstantiateEnemy(43, new Vector3(120, 120 + 0));
                InstantiateEnemy(43, new Vector3(120, -120 + 0));
                InstantiateEnemy(43, new Vector3(150, 160 + 0));
                InstantiateEnemy(43, new Vector3(150, -160 + 0));
                InstantiateEnemy(44, new Vector3(-30, 0 + 0));
                InstantiateEnemy(44, new Vector3(-60, 40 + 0));
                InstantiateEnemy(44, new Vector3(-60, -40 + 0));
                InstantiateEnemy(44, new Vector3(-90, 80 + 0));
                InstantiateEnemy(44, new Vector3(-90, -80 + 0));
                InstantiateEnemy(44, new Vector3(-120, 120 + 0));
                InstantiateEnemy(44, new Vector3(-120, -120 + 0));
                InstantiateEnemy(44, new Vector3(-150, 160 + 0));
                InstantiateEnemy(44, new Vector3(-150, -160 + 0));
                break;

            //Stage4
            case 30:
                InstantiateEnemy(45, new Vector3(0, 160));
                break;
            case 31:
                InstantiateEnemy(43, new Vector3(0, 160));
                InstantiateEnemy(45, new Vector3(-60, 100));
                InstantiateEnemy(43, new Vector3(-120, 40));
                break;
            case 32:
                InstantiateEnemy(44, new Vector3(0, 160));
                InstantiateEnemy(45, new Vector3(-120, 40));
                InstantiateEnemy(44, new Vector3(0, -80));
                break;
            case 33:
                InstantiateEnemy(43, new Vector3(0, 160));
                InstantiateEnemy(44, new Vector3(-60, 100));
                InstantiateEnemy(45, new Vector3(-120, 40));
                InstantiateEnemy(44, new Vector3(-60, -20));
                InstantiateEnemy(43, new Vector3(0, -80));
                break;
            case 34:
                InstantiateEnemy(43, new Vector3(0, 160));
                InstantiateEnemy(44, new Vector3(60, 100));
                InstantiateEnemy(45, new Vector3(120, 40));
                InstantiateEnemy(44, new Vector3(60, -20));
                InstantiateEnemy(43, new Vector3(0, -80));
                break;
            case 35:
                InstantiateEnemy(44, new Vector3(0, 160));
                InstantiateEnemy(45, new Vector3(60, 100));
                InstantiateEnemy(44, new Vector3(120, 40));
                InstantiateEnemy(45, new Vector3(60, -20));
                InstantiateEnemy(44, new Vector3(0, -80));
                break;
            case 36:
                for (int i = 0; i < 5; i++)
                {
                    InstantiateEnemy(43, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 5; i++)
                {
                    InstantiateEnemy(44, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 2; i++)
                {
                    InstantiateEnemy(45, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 37:
                for (int i = 0; i < 5; i++)
                {
                    InstantiateEnemy(43, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 5; i++)
                {
                    InstantiateEnemy(44, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 2; i++)
                {
                    InstantiateEnemy(45, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 38:
                for (int i = 0; i < 5; i++)
                {
                    InstantiateEnemy(43, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 5; i++)
                {
                    InstantiateEnemy(44, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(45, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 39:
                InstantiateEnemy(45, new Vector3(160, 160));
                InstantiateEnemy(45, new Vector3(80, 160));
                InstantiateEnemy(45, new Vector3(0, 160));
                InstantiateEnemy(45, new Vector3(-80, 160));
                InstantiateEnemy(45, new Vector3(-160, 160));
                break;

            //Stage5
            case 40:
                for (int i = 0; i < 15; i++)
                {
                    InstantiateEnemy(43, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 41:
                for (int i = 0; i < 10; i++)
                {
                    InstantiateEnemy(44, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 42:
                for (int i = 0; i < 5; i++)
                {
                    InstantiateEnemy(45, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 43:
                InstantiateEnemy(46, new Vector3(0, 100));
                break;
            case 44:
                InstantiateEnemy(46, new Vector3(0, 100));
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(43, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(44, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(45, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 45:
                for (int i = 0; i < 20; i++)
                {
                    InstantiateEnemy(43, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 46:
                for (int i = 0; i < 15; i++)
                {
                    InstantiateEnemy(44, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 47:
                for (int i = 0; i < 10; i++)
                {
                    InstantiateEnemy(45, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 48:
                InstantiateEnemy(46, new Vector3(0, 100));
                break;
            case 49:
                InstantiateEnemy(46, new Vector3(0, 100));
                for (int i = 0; i < 5; i++)
                {
                    InstantiateEnemy(43, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 5; i++)
                {
                    InstantiateEnemy(44, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 5; i++)
                {
                    InstantiateEnemy(45, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 50:
                for (int i = 0; i < 15; i++)
                {
                    InstantiateEnemy(43, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 15; i++)
                {
                    InstantiateEnemy(44, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 51:
                for (int i = 0; i < 15; i++)
                {
                    InstantiateEnemy(43, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 15; i++)
                {
                    InstantiateEnemy(44, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 52:
                for (int i = 0; i < 15; i++)
                {
                    InstantiateEnemy(43, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 15; i++)
                {
                    InstantiateEnemy(44, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 53:
                for (int i = 0; i < 15; i++)
                {
                    InstantiateEnemy(43, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 15; i++)
                {
                    InstantiateEnemy(44, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 54:
                InstantiateEnemy(46, new Vector3(0, 100));
                for (int i = 0; i < 10; i++)
                {
                    InstantiateEnemy(45, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 55:
                for (int i = 0; i < 20; i++)
                {
                    InstantiateEnemy(43, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 20; i++)
                {
                    InstantiateEnemy(44, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 56:
                for (int i = 0; i < 20; i++)
                {
                    InstantiateEnemy(43, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 20; i++)
                {
                    InstantiateEnemy(44, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 57:
                for (int i = 0; i < 20; i++)
                {
                    InstantiateEnemy(43, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 20; i++)
                {
                    InstantiateEnemy(44, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 58:
                for (int i = 0; i < 20; i++)
                {
                    InstantiateEnemy(43, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 20; i++)
                {
                    InstantiateEnemy(44, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 59:
                InstantiateEnemy(46, new Vector3(0, 0));
                for (int i = 0; i < 10; i++)
                {
                    InstantiateEnemy(45, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;

            //Stage6
            case 60:
                for (int i = 0; i < 2; i++)
                {
                    InstantiateEnemy(47, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 2; i++)
                {
                    InstantiateEnemy(48, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 61:
                for (int i = 0; i < 2; i++)
                {
                    InstantiateEnemy(47, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 2; i++)
                {
                    InstantiateEnemy(48, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 62:
                for (int i = 0; i < 2; i++)
                {
                    InstantiateEnemy(47, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 2; i++)
                {
                    InstantiateEnemy(48, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 63:
                for (int i = 0; i < 2; i++)
                {
                    InstantiateEnemy(47, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 2; i++)
                {
                    InstantiateEnemy(48, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 64:
                for (int i = 0; i < 2; i++)
                {
                    InstantiateEnemy(47, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 2; i++)
                {
                    InstantiateEnemy(48, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 2; i++)
                {
                    InstantiateEnemy(45, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 2; i++)
                {
                    InstantiateEnemy(44, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 2; i++)
                {
                    InstantiateEnemy(43, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 65:
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(47, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(48, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 66:
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(47, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(48, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 67:
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(47, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(48, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 68:
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(47, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(48, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 69:
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(47, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(48, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(45, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(44, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(43, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 70:
                for (int i = 0; i < 4; i++)
                {
                    InstantiateEnemy(47, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 4; i++)
                {
                    InstantiateEnemy(48, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 71:
                for (int i = 0; i < 4; i++)
                {
                    InstantiateEnemy(47, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 4; i++)
                {
                    InstantiateEnemy(48, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 72:
                for (int i = 0; i < 4; i++)
                {
                    InstantiateEnemy(47, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 4; i++)
                {
                    InstantiateEnemy(48, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 73:
                for (int i = 0; i < 4; i++)
                {
                    InstantiateEnemy(47, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 4; i++)
                {
                    InstantiateEnemy(48, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 74:
                for (int i = 0; i < 4; i++)
                {
                    InstantiateEnemy(47, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 4; i++)
                {
                    InstantiateEnemy(48, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 4; i++)
                {
                    InstantiateEnemy(45, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 4; i++)
                {
                    InstantiateEnemy(44, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 4; i++)
                {
                    InstantiateEnemy(43, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 75:
                for (int i = 0; i < 5; i++)
                {
                    InstantiateEnemy(47, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 5; i++)
                {
                    InstantiateEnemy(48, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 76:
                for (int i = 0; i < 5; i++)
                {
                    InstantiateEnemy(47, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 5; i++)
                {
                    InstantiateEnemy(48, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 77:
                for (int i = 0; i < 5; i++)
                {
                    InstantiateEnemy(47, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 5; i++)
                {
                    InstantiateEnemy(48, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 78:
                for (int i = 0; i < 5; i++)
                {
                    InstantiateEnemy(47, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 5; i++)
                {
                    InstantiateEnemy(48, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 79:
                for (int i = 0; i < 5; i++)
                {
                    InstantiateEnemy(47, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 5; i++)
                {
                    InstantiateEnemy(48, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 5; i++)
                {
                    InstantiateEnemy(45, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 5; i++)
                {
                    InstantiateEnemy(44, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                for (int i = 0; i < 5; i++)
                {
                    InstantiateEnemy(43, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;

            //Stage7
            case 80:
                for (int i = 0; i < 3; i++)
                {
                    InstantiateEnemy(49, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 81:
                for (int i = 0; i < 4; i++)
                {
                    InstantiateEnemy(49, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 82:
                for (int i = 0; i < 5; i++)
                {
                    InstantiateEnemy(49, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 83:
                for (int i = 0; i < 6; i++)
                {
                    InstantiateEnemy(49, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 84:
                for (int i = 0; i < 7; i++)
                {
                    InstantiateEnemy(49, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 85:
                for (int i = 0; i < 8; i++)
                {
                    InstantiateEnemy(49, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 86:
                for (int i = 0; i < 9; i++)
                {
                    InstantiateEnemy(49, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 87:
                for (int i = 0; i < 10; i++)
                {
                    InstantiateEnemy(49, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 88:
                for (int i = 0; i < 11; i++)
                {
                    InstantiateEnemy(49, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 89:
                for (int i = 0; i < 12; i++)
                {
                    InstantiateEnemy(49, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 90:
                for (int i = 0; i < 13; i++)
                {
                    InstantiateEnemy(49, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 91:
                for (int i = 0; i < 14; i++)
                {
                    InstantiateEnemy(49, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 92:
                for (int i = 0; i < 15; i++)
                {
                    InstantiateEnemy(49, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 93:
                for (int i = 0; i < 16; i++)
                {
                    InstantiateEnemy(49, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 94:
                for (int i = 0; i < 17; i++)
                {
                    InstantiateEnemy(49, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 95:
                for (int i = 0; i < 18; i++)
                {
                    InstantiateEnemy(49, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 96:
                for (int i = 0; i < 19; i++)
                {
                    InstantiateEnemy(49, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 97:
                for (int i = 0; i < 20; i++)
                {
                    InstantiateEnemy(49, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 98:
                for (int i = 0; i < 25; i++)
                {
                    InstantiateEnemy(49, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;
            case 99:
                for (int i = 0; i < 30; i++)
                {
                    InstantiateEnemy(49, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                }
                break;

            default:
                InstantiateEnemy(43, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                InstantiateEnemy(44, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                InstantiateEnemy(45, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                InstantiateEnemy(46, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                InstantiateEnemy(47, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                InstantiateEnemy(48, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
                InstantiateEnemy(49, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-160, 160)));
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
            gameObject.GetComponentsInChildren<TextMeshProUGUI>()[0].text = maxFloorNum3 + "%";
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
