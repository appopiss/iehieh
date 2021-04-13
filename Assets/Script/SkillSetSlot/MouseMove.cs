using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using static UsefulMethod;

public class MouseMove : BASE {


    // Use this for initialization
    void Awake () {
		StartBASE();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition / (Screen.height / 600f) + new Vector3(-400f,-300f);
        if (Input.GetMouseButtonDown(1))
        {
            Destroy(gameObject);
            main.skillSetController.chosenSkill = null;
        }

        if(Input.mousePosition.x/(Screen.height/600f) >=350&&Input.mousePosition.x / (Screen.height / 600f) <= 800&&Input.mousePosition.y / (Screen.height / 600f) <= 600&&Input.mousePosition.y / (Screen.height / 600f) >= 100)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(gameObject);
                main.skillSetController.chosenSkill = null;
            }
        }
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.RightShift))//グローバルスキル
        {
            if (Input.GetKey(KeyCode.Tab))
                return;
            if (Input.GetKey(KeyCode.Alpha1))
            {
                main.skillSlotCanvasAry[7].skillSet1aButton.onClick.Invoke();
                Destroy(gameObject);
                main.skillSetController.chosenSkill = null;
            }
            if (Input.GetKey(KeyCode.Alpha2))
            {
                main.skillSlotCanvasAry[8].skillSet1aButton.onClick.Invoke();
                Destroy(gameObject);
                main.skillSetController.chosenSkill = null;
            }
            if (Input.GetKey(KeyCode.Alpha3))
            {
                main.skillSlotCanvasAry[9].skillSet1aButton.onClick.Invoke();
                Destroy(gameObject);
                main.skillSetController.chosenSkill = null;
            }
            if (Input.GetKey(KeyCode.Alpha4))
            {
                main.skillSlotCanvasAry[10].skillSet1aButton.onClick.Invoke();
                Destroy(gameObject);
                main.skillSetController.chosenSkill = null;
            }
            if (Input.GetKey(KeyCode.Alpha5))
            {
                main.skillSlotCanvasAry[11].skillSet1aButton.onClick.Invoke();
                Destroy(gameObject);
                main.skillSetController.chosenSkill = null;
            }
            if (Input.GetKey(KeyCode.Alpha6))
            {
                main.skillSlotCanvasAry[12].skillSet1aButton.onClick.Invoke();
                Destroy(gameObject);
                main.skillSetController.chosenSkill = null;
            }
            if (Input.GetKey(KeyCode.Alpha7))
            {
                main.skillSlotCanvasAry[13].skillSet1aButton.onClick.Invoke();
                Destroy(gameObject);
                main.skillSetController.chosenSkill = null;
            }
            if (Input.GetKey(KeyCode.Alpha8))
            {
                main.skillSlotCanvasAry[14].skillSet1aButton.onClick.Invoke();
                Destroy(gameObject);
                main.skillSetController.chosenSkill = null;
            }

        }
        else//通常スキル
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                main.skillSlotCanvasAry[1].skillSet1aButton.onClick.Invoke();
                Destroy(gameObject);
                main.skillSetController.chosenSkill = null;
            }
            if (Input.GetKey(KeyCode.Alpha2))
            {
                main.skillSlotCanvasAry[2].skillSet1aButton.onClick.Invoke();
                Destroy(gameObject);
                main.skillSetController.chosenSkill = null;
            }
            if (Input.GetKey(KeyCode.Alpha3))
            {
                main.skillSlotCanvasAry[3].skillSet1aButton.onClick.Invoke();
                Destroy(gameObject);
                main.skillSetController.chosenSkill = null;
            }
            if (Input.GetKey(KeyCode.Alpha4))
            {
                main.skillSlotCanvasAry[4].skillSet1aButton.onClick.Invoke();
                Destroy(gameObject);
                main.skillSetController.chosenSkill = null;
            }
            if (Input.GetKey(KeyCode.Alpha5))
            {
                main.skillSlotCanvasAry[5].skillSet1aButton.onClick.Invoke();
                Destroy(gameObject);
                main.skillSetController.chosenSkill = null;
            }
            if (Input.GetKey(KeyCode.Alpha6))
            {
                main.skillSlotCanvasAry[6].skillSet1aButton.onClick.Invoke();
                Destroy(gameObject);
                main.skillSetController.chosenSkill = null;
            }

        }
    }
}
