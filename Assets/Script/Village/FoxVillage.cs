using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UsefulMethod;

public class FoxVillage : BASE {


    public int floorNum4 { get => main.GameController.floorNum4; set => main.GameController.floorNum4 = value; }
    public int maxFloorNum4 { get => main.GameController.maxFloorNum4; set => main.GameController.maxFloorNum4 = value; }
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

        if (floorNum4 < Stage2WaveNum)
        {
            currentStage = Main.CurrentStage.stage1;
        }
        else if (floorNum4 >= Stage2WaveNum && floorNum4 < Stage3WaveNum)
        {
            currentStage = Main.CurrentStage.stage2;
        }
        else if (floorNum4 >= Stage3WaveNum && floorNum4 < Stage4WaveNum)
        {
            currentStage = Main.CurrentStage.stage3;
        }
        else if (floorNum4 >= Stage4WaveNum && floorNum4 < Stage5WaveNum)
        {
            currentStage = Main.CurrentStage.stage4;
        }
        else if (floorNum4 >= Stage5WaveNum && floorNum4 < Stage6WaveNum)
        {
            currentStage = Main.CurrentStage.stage5;
        }
        else if (floorNum4 >= Stage6WaveNum && floorNum4 < Stage7WaveNum)
        {
            currentStage = Main.CurrentStage.stage6;
        }
        else if (floorNum4 >= Stage7WaveNum && floorNum4 < Stage8WaveNum)
        {
            currentStage = Main.CurrentStage.stage7;
        }
        else if (floorNum4 >= Stage8WaveNum)
        {
            currentStage = Main.CurrentStage.stage8;
        }
        else
        {
            currentStage = Main.CurrentStage.stage1;
        }

        //Stage開放
        if (maxFloorNum4 >= Stage1WaveNum)
        {
            main.StageChangeButtonAry[32].SetActive(true);
        }
        if (maxFloorNum4 >= Stage2WaveNum)
        {
            main.StageChangeButtonAry[33].SetActive(true);
        }
        if (maxFloorNum4 >= Stage3WaveNum)
        {
            main.StageChangeButtonAry[34].SetActive(true);
        }
        if (maxFloorNum4 >= Stage4WaveNum)
        {
            main.StageChangeButtonAry[35].SetActive(true);
        }
        if (maxFloorNum4 >= Stage5WaveNum)
        {
            main.StageChangeButtonAry[36].SetActive(true);
        }
        if (maxFloorNum4 >= Stage6WaveNum)
        {
            main.StageChangeButtonAry[37].SetActive(true);
        }
        if (maxFloorNum4 >= Stage7WaveNum)
        {
            main.StageChangeButtonAry[38].SetActive(true);
        }
        if (maxFloorNum4 >= Stage8WaveNum)
        {
            main.StageChangeButtonAry[39].SetActive(true);
        }

        switch (currentStage)
        {
            case Main.CurrentStage.stage1:
                Field.GetComponent<Image>().sprite = main.StageSpriteAry[32];
                main.Texts[0].text = "STAGE 1\n<size=50%>WAVE  " + (floorNum4 + 1 - Stage1WaveNum).ToString() + " / " + (Stage2WaveNum - Stage1WaveNum).ToString();
                break;
            case Main.CurrentStage.stage2:
                Field.GetComponent<Image>().sprite = main.StageSpriteAry[33];
                main.Texts[0].text = "STAGE 2\n<size=50%>WAVE  " + (floorNum4 + 1 - Stage2WaveNum).ToString() + " / " + (Stage3WaveNum - Stage2WaveNum).ToString();
                break;
            case Main.CurrentStage.stage3:
                Field.GetComponent<Image>().sprite = main.StageSpriteAry[34];
                main.Texts[0].text = "STAGE 3\n<size=50%>WAVE  " + (floorNum4 + 1 - Stage3WaveNum).ToString() + " / " + (Stage4WaveNum - Stage3WaveNum).ToString();
                break;
            case Main.CurrentStage.stage4:
                Field.GetComponent<Image>().sprite = main.StageSpriteAry[35];
                main.Texts[0].text = "STAGE 4\n<size=50%>WAVE  " + (floorNum4 + 1 - Stage4WaveNum).ToString() + " / " + (Stage5WaveNum - Stage4WaveNum).ToString();
                break;
            case Main.CurrentStage.stage5:
                Field.GetComponent<Image>().sprite = main.StageSpriteAry[36];
                main.Texts[0].text = "STAGE 5\n<size=50%>WAVE  " + (floorNum4 + 1 - Stage5WaveNum).ToString() + " / " + (Stage6WaveNum - Stage5WaveNum).ToString();
                break;
            case Main.CurrentStage.stage6:
                Field.GetComponent<Image>().sprite = main.StageSpriteAry[37];
                main.Texts[0].text = "STAGE 6\n<size=50%>WAVE  " + (floorNum4 + 1 - Stage6WaveNum).ToString() + " / " + (Stage7WaveNum - Stage6WaveNum).ToString();
                break;
            case Main.CurrentStage.stage7:
                Field.GetComponent<Image>().sprite = main.StageSpriteAry[38];
                main.Texts[0].text = "STAGE 7\n<size=50%>WAVE  " + (floorNum4 + 1 - Stage7WaveNum).ToString() + " / " + (Stage8WaveNum - Stage7WaveNum).ToString();
                break;
            case Main.CurrentStage.stage8:
                Field.GetComponent<Image>().sprite = main.StageSpriteAry[39];
                main.Texts[0].text = "STAGE 8\n<size=50%>WAVE  " + (floorNum4 + 1 - Stage8WaveNum).ToString() + " / ∞";
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

        //main.StageChangeButtonAry[32].GetComponent<Button>().onClick.AddListener(() => { floorNum4 = Stage1WaveNum; main.GameController.initStage(); });
        //main.StageChangeButtonAry[33].GetComponent<Button>().onClick.AddListener(() => { floorNum4 = Stage2WaveNum; main.GameController.initStage(); });
        //main.StageChangeButtonAry[34].GetComponent<Button>().onClick.AddListener(() => { floorNum4 = Stage3WaveNum; main.GameController.initStage(); });
        //main.StageChangeButtonAry[35].GetComponent<Button>().onClick.AddListener(() => { floorNum4 = Stage4WaveNum; main.GameController.initStage(); });
        //main.StageChangeButtonAry[36].GetComponent<Button>().onClick.AddListener(() => { floorNum4 = Stage5WaveNum; main.GameController.initStage(); });
        //main.StageChangeButtonAry[37].GetComponent<Button>().onClick.AddListener(() => { floorNum4 = Stage6WaveNum; main.GameController.initStage(); });
        //main.StageChangeButtonAry[38].GetComponent<Button>().onClick.AddListener(() => { floorNum4 = Stage7WaveNum; main.GameController.initStage(); });
        //main.StageChangeButtonAry[39].GetComponent<Button>().onClick.AddListener(() => { floorNum4 = Stage8WaveNum; main.GameController.initStage(); });

    }

    public void InstantiateEnemies4(int floorNum4)
    {
        switch (floorNum4)
        {
            default:
                if (floorNum4 < 10)//Stage1
                {
                    for (int i = 0; i < floorNum4 + 1; i++)
                    {
                        InstantiateEnemy(71, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-120, 160)));
                    }
                }
                else if (floorNum4 >= 10 && floorNum4 < 20)
                {
                    for (int i = 0; i < (floorNum4 - 4); i++)
                    {
                        InstantiateEnemy(71, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-120, 160)));
                    }
                    for (int i = 0; i < (floorNum4 - 9); i++)
                    {
                        InstantiateEnemy(72, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-120, 160)));
                    }
                }
                else if (floorNum4 >= 20 && floorNum4 < 30)
                {
                    for (int i = 0; i < (floorNum4); i++)
                    {
                        InstantiateEnemy(71, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-120, 160)));
                    }
                }
                else if (floorNum4 >= 30 && floorNum4 < 40)
                {
                    for (int i = 0; i < (floorNum4-19); i++)
                    {
                        InstantiateEnemy(72, new Vector3(UnityEngine.Random.Range(-160, 160), UnityEngine.Random.Range(-120, 160)));
                    }
                }
                else
                {
                    randomEnemyNum = UnityEngine.Random.Range(71, 72);
                    InstantiateEnemy(randomEnemyNum, new Vector3(0, 100));
                }
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
            gameObject.GetComponentsInChildren<TextMeshProUGUI>()[0].text = maxFloorNum4 + "%";
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
