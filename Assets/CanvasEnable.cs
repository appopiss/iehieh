using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;

public class CanvasEnable : BASE {

	Canvas thisCanvas;
	RectTransform thisPosition;
	bool isEnabled;
	// Use this for initialization
	void Awake () {
		StartBASE();
	}

	// Use this for initialization
	void Start () {
		thisCanvas = gameObject.GetComponent<Canvas>();
		thisPosition = gameObject.GetComponent<RectTransform>();
		isEnabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (thisPosition.anchoredPosition.x < -100 || thisPosition.anchoredPosition.x > 900 || thisPosition.anchoredPosition.y < -100 || thisPosition.anchoredPosition.y > 700)
		{
            if (isEnabled)
            {
				thisCanvas.enabled = false;
				isEnabled = false;
			}
		}
        else
        {
            if (!isEnabled)
            {
				thisCanvas.enabled = true;
				isEnabled = true;
			}

		}
	}
}
