using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class KeyItemCtrl : BASE {

    public Button ActiveArtifact;
    public Button FalseArtifact;
    public GameObject ArtifactCanvas;
    public KEYITEM[] keyItems;
    bool isActive;

    void Active()
    {
        if (isActive)
            return;

        ArtifactCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(-1000, 0);
        main.GameController.SetAllImageAndText(ArtifactCanvas, true);
        isActive = true;
    }

    void False()
    {
        if (!isActive)
            return;

        ArtifactCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(1000, 0);
        main.GameController.SetAllImageAndText(ArtifactCanvas, false);
        isActive = false;
    }

	// Use this for initialization
	void Awake () {
		StartBASE();
        ActiveArtifact.onClick.AddListener(Active);
        FalseArtifact.onClick.AddListener(False);
	}

	// Use this for initialization
	void Start () {
        StartCoroutine(WaitForLoad());
    }
	
    IEnumerator WaitForLoad()
    { 
        yield return new WaitUntil(() => TitleCtrl.isLoaded);
        //main.GameController.SetAllImageAndText(ArtifactCanvas, false);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
