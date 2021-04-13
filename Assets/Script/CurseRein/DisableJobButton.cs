using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;

public class DisableJobButton : BASE {

	Button button;
	public ALLY.Job targetJob;
	// Use this for initialization
	void Awake () {
		button = gameObject.GetComponent<Button>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (main.cc.CurrentCurseId != CurseId.road_of_angel
            && main.cc.CurrentCurseId != CurseId.road_of_warrior
            && main.cc.CurrentCurseId != CurseId.road_of_wizard
			&& main.cc.CurrentCurseId != CurseId.curse_of_warrior2
			&& main.cc.CurrentCurseId != CurseId.curse_of_wizard2
			&& main.cc.CurrentCurseId != CurseId.curse_of_angel2
			&& main.cc.CurrentCurseId != CurseId.curse_of_warrior3
			&& main.cc.CurrentCurseId != CurseId.curse_of_wizard3
			&& main.cc.CurrentCurseId != CurseId.curse_of_angel3
			)
			return;

        switch (main.cc.CurrentCurseId)
        {
			case CurseId.normal:
				button.interactable = true;
				break;
			case CurseId.road_of_warrior:
				if (targetJob != ALLY.Job.Warrior)
					button.interactable = false;
				break;
			case CurseId.curse_of_warrior2:
				if (targetJob != ALLY.Job.Warrior)
					button.interactable = false;
				break;
			case CurseId.curse_of_warrior3:
				if (targetJob != ALLY.Job.Warrior)
					button.interactable = false;
				break;
			case CurseId.road_of_wizard:
				if (targetJob != ALLY.Job.Wizard)
					button.interactable = false;
				break;
			case CurseId.curse_of_wizard2:
				if (targetJob != ALLY.Job.Wizard)
					button.interactable = false;
				break;
			case CurseId.curse_of_wizard3:
				if (targetJob != ALLY.Job.Wizard)
					button.interactable = false;
				break;
			case CurseId.road_of_angel:
				if (targetJob != ALLY.Job.Angel)
					button.interactable = false;
				break;
			case CurseId.curse_of_angel2:
				if (targetJob != ALLY.Job.Angel)
					button.interactable = false;
				break;
			case CurseId.curse_of_angel3:
				if (targetJob != ALLY.Job.Angel)
					button.interactable = false;
				break;
		}
	}
}
