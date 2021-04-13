using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;

public class InstantiateAchievementLog : BASE
{

    // Use this for initialization
    void Awake()
    {
        StartBASE();
    }

    // Use this for initialization
    void Start()
    {
        StartCoroutine(MoveObject(gameObject));

    }

    public bool canLog;
    public IEnumerator MoveObject(GameObject game)
    {
        yield return new WaitUntil(()=>canLog);
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 5; i++)
        {
            game.GetComponentInChildren<RectTransform>().anchoredPosition += new Vector2(-42.5f, 0);
            yield return new WaitForSeconds(0.020f);
        }
        yield return new WaitForSeconds(5f);
        //for (int i = 0; i < 40; i++)
        //{
        //    game.GetComponentInChildren<TextMeshProUGUI>().color += new Color(0, 0, 0, -0.050f);
        //    game.GetComponentsInChildren<Image>()[0].color += new Color(0, 0, 0, -0.025f);
        //    game.GetComponentsInChildren<Image>()[1].color += new Color(0, 0, 0, -0.050f);
        //    game.GetComponentsInChildren<Image>()[2].color += new Color(0, 0, 0, -0.050f);
        //    game.transform.GetChild(1).GetComponent<Image>().color += new Color(0, 0, 0, -0.050f);
        //    game.GetComponent<Image>().color += new Color(0, 0, 0, -0.025f);
        //    yield return new WaitForSeconds(0.025f);
        //}
        //yield return new WaitForSeconds(0f);
        main.isLogging = false;
        if (GameObject.FindGameObjectsWithTag("logText").Length > 1)
        {
            main.LogShowCanvas.gameObject.GetComponentsInChildren<InstantiateAchievementLog>()[1].canLog = true;
        }
        Destroy(game);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
