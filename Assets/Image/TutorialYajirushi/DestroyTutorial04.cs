using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class DestroyTutorial04 : BASE {

	// Use this for initialization
	void Awake () {
		StartBASE();
        gameObject.GetComponent<RectTransform>().anchoredPosition += new Vector2(10000, 0);
    }

	// Use this for initialization
	void Start () {
        if (main.S.isSkillSet)
        {
            Destroy(gameObject);
        }
        StartCoroutine(SkillSet());
    }

	
    public IEnumerator SkillSet()
    {
        yield return new WaitUntil(()=>main.saveWar.SkillLevel[1] >= 1 || main.saveWiz.SkillLevel[1] >= 1 || main.saveAng.SkillLevel[1] >= 1);
        gameObject.GetComponent<RectTransform>().anchoredPosition += new Vector2(-10000, 0);
        yield return new WaitUntil(() => main.S.isSkillSet);
        if(main.TutorialController.TutorialCanvasAry[3] != null)
        main.TutorialController.TutorialCanvasAry[3].gameObject.GetComponent<RectTransform>().anchoredPosition += new Vector2(-10000, 0);
        Destroy(gameObject);
        yield break;
    }

    // Update is called once per frame
    void Update () {
    }
}
