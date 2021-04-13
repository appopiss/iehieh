using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class DestroyTutorial01 : BASE {

	// Use this for initialization
	void Awake () {
		StartBASE();
        gameObject.GetComponent<RectTransform>().anchoredPosition += new Vector2(10000, 0);
    }

	// Use this for initialization
	void Start () {
        if (main.S.isSkillTreeOpen)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update() {
        if (main.S.isSkillTreeOpen)
        {
            Destroy(gameObject);
        }
    }
}
