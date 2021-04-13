using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class DestroyTutorial06 : BASE {

	// Use this for initialization
	void Awake () {
		StartBASE();
        gameObject.GetComponent<RectTransform>().anchoredPosition += new Vector2(10000, 0);
        
    }
    

	// Use this for initialization
	void Start () {
        if (main.S.isOpenedQuest)
        {
            Destroy(gameObject);
        }
        StartCoroutine(StartWait());
    }
    IEnumerator StartWait()
    {
        yield return new WaitForSeconds(0.1f);
        if (!main.S.isOpenedQuest)
        {
            yield return new WaitUntil(()=>main.SR.isDungeon[9]);
            gameObject.GetComponent<RectTransform>().anchoredPosition += new Vector2(-10000, 0);
        }
        yield break;
    }

    // Update is called once per frame
    void Update () {
        if (main.S.isOpenedQuest)
        {
            Destroy(gameObject);
        }
    }
}
