using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;

public class ShowPlayTime : BASE {

	// Use this for initialization
	void Awake () {
		StartBASE();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (main.GameController.currentCanvas == main.GameController.InventoryCanvas)
        {
			gameObject.GetComponent<TextMeshProUGUI>().text = "Play Time : " + DoubleTimeToDate(main.S.realAllTime);
			main.Texts[31].text = "Rebirth Time : " + DoubleTimeToDate(main.SR.realRebirthTime);
		}
	}
}
