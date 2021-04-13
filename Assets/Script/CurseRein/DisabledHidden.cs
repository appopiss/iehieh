using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;

public class DisabledHidden : BASE {

	public Button hiddenButton;
	// Use this for initialization
	void Awake () {
		StartBASE();
		hiddenButton = main.ZoneCtrl.hiddenButton;
	}

	// Use this for initialization
	void Start () {
		if (
	 main.cc.CurrentCurseId == CurseId.curse_of_warrior3
	|| main.cc.CurrentCurseId == CurseId.curse_of_wizard3
	|| main.cc.CurrentCurseId == CurseId.curse_of_angel3)
		{
			if (!main.ZoneCtrl.isHidden)
            {
				main.cc.isCanceled = true;
				//main.cc.CurrentCurseId = CurseId.normal;元はこれでした
			}
		}

        if (main.cc.CurrentCurseId == CurseId.curse_of_metal)
        {
            if (main.ZoneCtrl.isHidden)
            {
				main.cc.isCanceled = true;
				//main.cc.CurrentCurseId = CurseId.normal;
			}
		}

	}

	// Update is called once per frame
	void Update() { }
}
