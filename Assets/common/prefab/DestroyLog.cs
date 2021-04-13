using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;

public class DestroyLog : BASE
{

    public float positionY;
    public float DestroyTime;
    // Use this for initialization
    void Awake()
    {
        StartBASE();
    }

    // Use this for initialization
    void Start()
    {
        StartCoroutine(FadeAway());
        StartCoroutine(DestroyY());
    }

    IEnumerator FadeAway()
    {
        yield return new WaitForSeconds(DestroyTime);
        for (int i = 0; i < 50; i++)
        {
            gameObject.GetComponent<TextMeshProUGUI>().color += new Color(0, 0, 0, -0.02f);
            yield return new WaitForSeconds(0.02f);
        }
        Destroy(gameObject);
    }
    IEnumerator DestroyY()
    {
        yield return new WaitForSeconds(0.017f);
        yield return new WaitUntil(() => positionY > 0);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
