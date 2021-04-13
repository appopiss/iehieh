using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class ResourceUpMove : BASE
{
    // Use this for initialization
    void Awake()
    {
        StartBASE();
    }
    Vector2 size;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(Move());
        size = new Vector2(0.25f, 0.25f);
    }

    IEnumerator Move()
    {
        float randx = UnityEngine.Random.Range(-10, 10);
        float randy = UnityEngine.Random.Range(-10, 10);
        float randv = UnityEngine.Random.Range(2,5);
        Vector3 plusposition = normalize(new Vector3(randx, randy))*randv;
        for (int i = 0; i < 20; i++)
        {
            gameObject.GetComponent<RectTransform>().position += plusposition;
            gameObject.GetComponent<RectTransform>().sizeDelta -= size;
            yield return new WaitForSeconds(0.016f);
        }
        Destroy(gameObject);
    }
    public static Vector3 normalize(Vector3 vector)
    {
        float x = vector.x;
        float y = vector.y;
        if (x == 0 && y == 0) { return new Vector3(0, 0); }
        float normalizeFactor = 1.0f / Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2));
        Vector3 vector3 = new Vector3(x * normalizeFactor, y * normalizeFactor);
        return vector3;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
