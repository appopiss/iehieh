﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class ToggleSave : BASE {

    public Sprite move;
    public Sprite slimeBall;

	// Use this for initialization
	void Awake () {
		StartBASE();
	}

	// Use this for initialization
	void Start () {
        for (int i = 0; i < main.toggles.Length; i++)
        {
            main.toggles[i].isOn = false;
            main.toggles[i].isOn = main.S.toggleSave[i];
        }
        StartCoroutine(Saving());
	}
	
    IEnumerator Saving()
    {
        while (true)
        {
            for (int i = 0; i < main.toggles.Length; i++)
            {
                main.S.toggleSave[i] = main.toggles[i].isOn;
            }
            yield return new WaitForSeconds(0.16f);
        }

    }
    // Update is called once per frame
    void Update () {

    }
}
