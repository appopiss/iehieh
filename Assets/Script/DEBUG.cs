using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class DEBUG : BASE {

	// Use this for initialization
	void Awake () {
		StartBASE();
	}

	// Use this for initialization
	void Start () {
        foreach (ArtiCtrl.MaterialList material in Enum.GetValues(typeof(ArtiCtrl.MaterialList)))
        {
            main.ArtiCtrl.CurrentMaterial[material] += 1000000;
        }
    }
	
}
