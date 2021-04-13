using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;

public class InstantiateDeath : BASE {

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
        for (int i = 0; i < 25; i++)
        {
            game.GetComponentInChildren<TextMeshProUGUI>().color += new Color(0, 0, 0, -0.01f);
            game.GetComponentInChildren<TextMeshProUGUI>().GetComponentInChildren<RectTransform>().anchoredPosition += new Vector2(0, 1.5f);
            yield return new WaitForSeconds(0.020f);
        }
        //yield return new WaitForSeconds(0f);
        Destroy(game);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
