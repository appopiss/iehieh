using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class D_Attack : Attack {

    //遠距離攻撃用のクラス
    public float speed;
    Vector2 TargetPosition;
    private void Awake()
    {
        StartBASE();
        thisRect = gameObject.GetComponent<RectTransform>();
        targetRect = main.ally1.GetComponent<RectTransform>();
        isDestroyAfterCollide = true;
    }

    private void Start()
    {
        StartCoroutine(Move());
    }
    // Update is called once per frame
    void Update () {
        //thisRect.anchoredPosition += normalize(targetRect.anchoredPosition - thisRect.anchoredPosition) * speed;
	}

    public IEnumerator Move()
    {
        while (true)
        {
            thisRect.anchoredPosition += normalize(targetRect.anchoredPosition - thisRect.anchoredPosition) * speed;
            yield return new WaitForSeconds(0.02f);
        }
    }
}
