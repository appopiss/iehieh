using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;

public class DeathPanel : BASE {

    //Information
    public double gold { get => main.SR.R_gold; set => main.SR.R_gold = value; }
    public double exp { get => main.SR.R_exp; set => main.SR.R_exp = value; }
    public double C_gold { get => main.SR.RC_gold; set => main.SR.RC_gold = value; }
    public double C_exp { get => main.SR.RC_exp; set => main.SR.RC_exp = value; }
    public float time
    {
        get => main.SR.R_time;
        set => main.SR.R_time = value;
    }
    public float C_time
    {
        get => main.SR.RC_time;
        set => main.SR.RC_time = value;
    }

    public TextMeshProUGUI titleText;
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI expText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI[] materialTexts;

    public Dictionary<ArtiCtrl.MaterialList, int> materials = new Dictionary<ArtiCtrl.MaterialList, int>();
    public Dictionary<ArtiCtrl.MaterialList, int> C_materials = new Dictionary<ArtiCtrl.MaterialList, int>();
    public int[] materialNum { get => main.SR.R_materials; set => main.SR.R_materials = value; }
    public int[] C_materialNum { get => main.SR.RC_materials; set => main.SR.RC_materials = value; }
    public bool isPanel;
    public bool isDead;
    public void initResult()
    {
        gold = 0;
        exp = 0;
        time = 0;
        for(int i = 0; i < materialNum.Length; i++)
        {
            materialNum[i] = 0;
            materials[(ArtiCtrl.MaterialList)i] = 0;
        }
        for(int i = 0; i < materialTexts.Length; i++)
        {
            materialTexts[i].text = "";
        }
    }

    public void C_initResult()
    {
        C_gold = 0;
        C_exp = 0;
        C_time = 0;
        for (int i = 0; i < materialNum.Length; i++)
        {
            C_materialNum[i] = 0;
            C_materials[(ArtiCtrl.MaterialList)i] = 0;
        }
    }

    public IEnumerator ActiveCor(GameObject game)
    {
        for (int i = 0; i < 5; i++)
        {
            if (game.HasComponent<Image>())
            {
                game.GetComponent<Image>().color += new Color(0, 0, 0, 210f / 255f / 5f);
            }
            else
            {
                game.GetComponent<TextMeshProUGUI>().color += new Color(0, 0, 0, 210f / 255f / 5f);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void AddMaterialText()
    {
        Dictionary<ArtiCtrl.MaterialList, int> tempDictionary = new Dictionary<ArtiCtrl.MaterialList, int>();
        int count = 0;
        foreach(KeyValuePair<ArtiCtrl.MaterialList,int> pair in materials)
        {
            if(pair.Value > 0)
            {
                tempDictionary.Add(pair.Key, pair.Value);
            }

            if (tempDictionary.Count >= 13)
                break;
        }
        if(tempDictionary.Count == 0)
        {
            DeathpanelLocal.nothinggain(materialTexts[0]);
            return;
        }
        else
        {
            foreach(KeyValuePair<ArtiCtrl.MaterialList, int> pair in tempDictionary)
            {
                materialTexts[count].text = main.ArtiCtrl.ConvertEnum(pair.Key) + "  × " + pair.Value;
                count++;
            }
        }

    }
    public void C_AddMaterialText()
    {
        Dictionary<ArtiCtrl.MaterialList, int> tempDictionary = new Dictionary<ArtiCtrl.MaterialList, int>();
        int count = 0;
        foreach (KeyValuePair<ArtiCtrl.MaterialList, int> pair in C_materials)
        {
            if (pair.Value > 0)
            {
                tempDictionary.Add(pair.Key, pair.Value);
            }
        }
        if (tempDictionary.Count == 0)
        {
            DeathpanelLocal.nothinggain(materialTexts[0]);
            return;
        }
        else
        {
            foreach (KeyValuePair<ArtiCtrl.MaterialList, int> pair in tempDictionary)
            {
                materialTexts[count].text = pair.Key + "  × " + pair.Value;
                count++;
            }
        }

    }

    public void FadeAwayPanel()
    {
        foreach (GameObject game in GetAllChildren.GetAllImage(main.deathPanel.gameObject))
        {
            if (game.HasComponent<Image>())
            {
                while (game.GetComponent<Image>().color.a > 0)
                {
                    game.GetComponent<Image>().color -= new Color(0, 0, 0, 0.01f);
                }
            }
            else
            {
                while (game.GetComponent<TextMeshProUGUI>().color.a > 0)
                {
                    game.GetComponent<TextMeshProUGUI>().color -= new Color(0, 0, 0, 0.01f);
                }
            }
        }
    }

   // //これをチャレンジから呼べるようにするにはどう書けば・・・？
   // public IEnumerator ShowDeathPanel()
   // {
   //     if (main.GameController.battleMode == GameController.BattleMode.challange)
   //         {
   //             yield break;
   //         }
   //
   //     else if (main.GameController.battleMode == GameController.BattleMode.normal||main.toggles[1].isOn)
   //     {
   //         yield return new WaitForSeconds(1.0f);
   //         main.GameController.battleMode = GameController.BattleMode.normal;
   //         main.GameController.initStage();
   //         main.ally1.GetComponent<ALLY>().currentHp = main.ally1.GetComponent<ALLY>().HP();
   //     }
   //     yield break;
   // }

    // Use this for initialization
    void Awake()
    {
        StartBASE();
        time = 0;
        C_time = 0;
        if (materials.Count == 0)
        {
            foreach (ArtiCtrl.MaterialList material in Enum.GetValues(typeof(ArtiCtrl.MaterialList)))
            {
                materials.Add(material, materialNum[(int)material]);
            }
            foreach (ArtiCtrl.MaterialList material in Enum.GetValues(typeof(ArtiCtrl.MaterialList)))
            {
                C_materials.Add(material, C_materialNum[(int)material]);
            }
        }
        for (int i = 0; i < materialTexts.Length; i++)
        {
            materialTexts[i].text = "";
        }
    }

    public GameObject deathImage;
	// Use this for initialization
	void Start () {
        //ほんとは後で書き直す
        //StartCoroutine(TimeElapsed());
        StartCoroutine(updateMaterial());
    }

    //public IEnumerator TimeElapsed()
    //{
    //    while (true)
    //    {
    //        time += 0.05f;
    //        C_time += 0.05f;
    //        yield return new WaitForSeconds(0.05f);
    //    }
    //}
	
	// Update is called once per frame
	void Update () {

    }

    public IEnumerator updateMaterial()
    {
        while (true)
        {
            foreach (KeyValuePair<ArtiCtrl.MaterialList, int> material in materials)
            {
                materialNum[(int)material.Key] = material.Value;
            }
            foreach (KeyValuePair<ArtiCtrl.MaterialList, int> material in C_materials)
            {
                C_materialNum[(int)material.Key] = material.Value;
            }
            yield return new WaitForSeconds(1.0f);
        }
    }
}
