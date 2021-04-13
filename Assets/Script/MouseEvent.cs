using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

public class MouseEvent : BASE {

    //450,510
    public bool isOver;
    public GameObject window;
    public Vector2 factor;
    public ENEMY targetEnemy;

    // Use this for initialization
    void Awake () {
		StartBASE();
	}

	// Use this for initialization
	void Start () {
        window = Instantiate(main.P_texts[3], main.WindowShowCanvas);
        factor = new Vector2(-575f, -345f);
    }
	
	// Update is called once per frame
	void Update () {
        if (main.mouseEvent.isOver && targetEnemy != null && Input.GetMouseButtonDown(0))
        {
            main.ally.targetEnemy = null;
            main.ally.condition = ALLY.Condition.MoveMode;
            GameObject[] taggedEnemy = GameObject.FindGameObjectsWithTag("enemy");

            foreach (GameObject game in taggedEnemy)
            {
                game.GetComponent<ENEMY>().isTargetted = false;
            }

            targetEnemy.isTargetted = true;
        }
        if (main.mouseEvent.isOver && targetEnemy != null)
        {
            setActive(main.mouseEvent.window);
            main.mouseEvent.window.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = targetEnemy.EnemyName;
            main.mouseEvent.window.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = tDigit(targetEnemy.currentHp) + " / " + tDigit(targetEnemy.HP())
                + "  ( " + percent(targetEnemy.currentHp/ targetEnemy.HP(),0) + " )";
            if(targetEnemy.isDebuff[(int)Main.Debuff.atkDown])
                main.mouseEvent.window.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "<color=red>"+tDigit(targetEnemy.ATK());
            else
                main.mouseEvent.window.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = tDigit(targetEnemy.ATK());

            if (targetEnemy.isDebuff[(int)Main.Debuff.mAtkDown])
                main.mouseEvent.window.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "<color=red>" + tDigit(targetEnemy.MATK());
            else
                main.mouseEvent.window.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = tDigit(targetEnemy.MATK());

            if (targetEnemy.isDebuff[(int)Main.Debuff.defDown])
                main.mouseEvent.window.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = "<color=red>" + tDigit(targetEnemy.DEF());
            else
                main.mouseEvent.window.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = tDigit(targetEnemy.DEF());

            if (targetEnemy.isDebuff[(int)Main.Debuff.defDown])
                main.mouseEvent.window.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text = "<color=red>" + tDigit(targetEnemy.MDEF());
            else
                main.mouseEvent.window.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text = tDigit(targetEnemy.MDEF());

            main.mouseEvent.window.transform.GetChild(6).GetComponent<TextMeshProUGUI>().text = tDigit(targetEnemy.initialAttackSpeed,2);
            main.mouseEvent.window.transform.GetChild(7).GetComponent<TextMeshProUGUI>().text = tDigit(Math.Min(targetEnemy.AttackRange,300));
        }
        else
        {
            setFalse(main.mouseEvent.window);
        }
        if (window != null)
        {
            window.GetComponent<RectTransform>().anchoredPosition = new Vector2(244, 195);
        }

    }
}
