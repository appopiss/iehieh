using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;

public class InstantiateThunder : BASE {

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
        yield return new WaitForSeconds(0.1f);
        Destroy(game);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
