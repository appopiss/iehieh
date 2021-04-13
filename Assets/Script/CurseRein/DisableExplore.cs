using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;

public class DisableExplore : BASE {

    // Update is called once per frame
    void Update () {
		if(main.cc.CurrentCurseId == CurseId.curse_of_explore)
        {
            main.buttons[8].interactable = false;
        }
	}
}
