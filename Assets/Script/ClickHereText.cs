using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;

public class ClickHereText : BASE {

	// Use this for initialization
	void Awake () {
		StartBASE();
	}

	// Use this for initialization
	void Start () {
    }
    private void OnEnable()
    {
        StartCoroutine(Fade(gameObject));
    }

    public IEnumerator Fade(GameObject game)
    {
        while (true)
        {
            for (int i = 0; i < 20; i++)
            {
                game.GetComponentInChildren<TextMeshProUGUI>().color += new Color(0, 0, 0, -0.05f);
                yield return new WaitForSeconds(0.025f);
            }
            for (int i = 0; i < 20; i++)
            {
                game.GetComponentInChildren<TextMeshProUGUI>().color += new Color(0, 0, 0, +0.05f);
                yield return new WaitForSeconds(0.025f);
            }
            yield return new WaitForSeconds(0.5f); 
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
