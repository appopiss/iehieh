using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;

public class InstantiateLine : BASE {

	// Use this for initialization
	void Awake () {
		StartBASE();
	}

	// Use this for initialization
	void Start () {
        StartCoroutine(destroyObject(gameObject));
	}

    public IEnumerator destroyObject(GameObject game)
    {
        for (int i = 0; i < 20; i++)
        {
            game.GetComponentInChildren<TextMeshProUGUI>().color += new Color(0, 0, 0, 0.05f);
            yield return new WaitForSeconds(0.025f);
        }
        yield return new WaitForSeconds(3.0f);
        for (int i = 0; i < 20; i++)
        {
            game.GetComponentInChildren<TextMeshProUGUI>().color += new Color(0, 0, 0, -0.05f);
            game.GetComponentInChildren<RectTransform>().anchoredPosition += new Vector2(0, 2.5f);
            yield return new WaitForSeconds(0.025f);
        }
        //yield return new WaitForSeconds(0.5f);
        Destroy(game);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
