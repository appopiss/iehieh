using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using UnityEngine.SceneManagement;

public class HardReset : BASE {

	// Use this for initialization
	void Awake () {
		StartBASE();
	}

	// Use this for initialization
	void Start () {
        pressNum = 0;
        gameObject.GetComponent<Button>().onClick.AddListener(reset);
        text.text = "Press 10 times to reset";

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public int pressNum;

    public TMPro.TextMeshProUGUI text;
    private void reset()
    {
        pressNum += 1;
        text.text = "Press " + tDigit(10 - pressNum) + " times to reset";
        if (pressNum >= 10)
        {
            PlayerPrefs.DeleteKey(keyList.resetSaveKey);
            PlayerPrefs.DeleteKey(keyList.permanentSaveKey);
            PlayerPrefs.DeleteKey(keyList.War_saveKey);
            PlayerPrefs.DeleteKey(keyList.Ang_saveKey);
            PlayerPrefs.DeleteKey(keyList.Wiz_saveKey);
            SceneManager.LoadScene("main");
        }
    }
}
    