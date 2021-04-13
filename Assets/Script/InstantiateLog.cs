using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;

public class InstantiateLog : BASE {

    public float positionY;
    public bool debugBool;
    public void showLog(string text,Color color)
    {    
        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = text;
    }
	// Use this for initialization
	void Awake () {
		StartBASE();
        StartCoroutine(FadeAway());
	}

	// Use this for initialization
	void Start () {
		
	}

    IEnumerator FadeAway()
    {
        yield return new WaitForSeconds(3.0f);
        for (int i = 0; i < 50; i++)
        {
            gameObject.GetComponentInChildren<TextMeshProUGUI>().color += new Color(0, 0, 0, -0.02f);
            gameObject.transform.GetChild(1).GetComponent<Image>().color += new Color(0, 0, 0, -0.02f);
            yield return new WaitForSeconds(0.02f);
        }
        Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        positionY = gameObject.GetComponent<RectTransform>().anchoredPosition.y;
        debugBool = gameObject.GetComponent<RectTransform>().anchoredPosition.y >= -20;
        if (gameObject.GetComponent<RectTransform>().anchoredPosition.y >=-20)
        {
           Destroy(gameObject);
        }
	}
}
