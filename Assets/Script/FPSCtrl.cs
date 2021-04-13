using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;

public class FPSCtrl : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (main.toggles[15].isOn && main.GameController.battleMode == GameController.BattleMode.challange)
			Application.targetFrameRate = 60;
		else
			Application.targetFrameRate = -1;
    }
}
