using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;

public class KredsForDebug : BASE {

    public Button buyButton;

	// Use this for initializationx
	void Awake () {
		StartBASE();
        buyButton = gameObject.GetComponent<Button>();
    }

    void Start()
    {
        buyButton.onClick.AddListener(GetKreds);    
    }

    void GetKreds()
    {
        main.S.ECbyKreds += 10;
    }

    // Update is called once per frame
    void Update () {

    }
}
