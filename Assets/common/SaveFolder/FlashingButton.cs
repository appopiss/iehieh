using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;

public class FlashingButton : BASE {

	// Use this for initialization
	void Awake () {
		StartBASE();
	}

	// Use this for initialization
	void Start () {
		if (main.platform != Platform.steam)
    		StartCoroutine(Flashing());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Flashing()
    {
        while (true)
        {
			yield return new WaitUntil(() => Load.leftTimeForSaveBonus() < 1);
			gameObject.GetComponent<Image>().color = new Color(1, 1, 0, 0.8f);
			yield return new WaitForSeconds(0.5f);
			gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
			yield return new WaitForSeconds(0.5f);
		}
	}
}
