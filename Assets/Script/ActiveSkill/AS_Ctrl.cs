using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class AS_Ctrl : BASE {

	// Use this for initialization
	void Awake () {
		StartBASE();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        switch (main.ally1.GetComponent<ALLY>().job)
        {
            case ALLY.Job.Novice:
                main.AS_warrior.anchoredPosition = new Vector2(0, -600);
                main.AS_wizard.anchoredPosition = new Vector2(0, -600);
                main.AS_angel.anchoredPosition = new Vector2(0, -600);
                break;
            case ALLY.Job.Warrior:
                main.AS_warrior.anchoredPosition = new Vector2(0, 0);
                main.AS_wizard.anchoredPosition = new Vector2(0, -600);
                main.AS_angel.anchoredPosition = new Vector2(0, -600);
                break;
            case ALLY.Job.Wizard:
                main.AS_warrior.anchoredPosition = new Vector2(0, -600);
                main.AS_wizard.anchoredPosition = new Vector2(0, 0);
                main.AS_angel.anchoredPosition = new Vector2(0, -600);
                break;
            case ALLY.Job.Angel:
                main.AS_warrior.anchoredPosition = new Vector2(0, -600);
                main.AS_wizard.anchoredPosition = new Vector2(0, -600);
                main.AS_angel.anchoredPosition = new Vector2(0, 0);
                break;
        }
	}
}
