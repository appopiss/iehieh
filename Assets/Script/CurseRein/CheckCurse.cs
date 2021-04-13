using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;

public class CheckCurse : BASE {

	// Use this for initialization
	void Awake () {
		StartBASE();
	}

    Button button;
	// Use this for initialization
	void Start () {
        button = gameObject.GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
		if(main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.montblango].clearedNum >= 1)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
	}
}
