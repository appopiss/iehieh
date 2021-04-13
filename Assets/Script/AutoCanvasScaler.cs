using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoCanvasScaler : MonoBehaviour
{
    CanvasScaler canvasScaler;
    public int width = 1000;
    public int height = 600;
    float gameRatio;

    float thisRatio;
    float lastRatio;
    // Start is called before the first frame update
    void Start()
    {
        gameRatio = GetRatio(width, height);
        canvasScaler = GetComponent<CanvasScaler>();
        StartCoroutine(LoopCoroutine());
    }

    float GetRatio(int width, int height)
    {
        return (float)width / height;
    }

    void Judge()
    {
        thisRatio = GetRatio(Screen.width, Screen.height);
        if (thisRatio.Equals(lastRatio))
        {
            return;
        }
        lastRatio = thisRatio;

        if (thisRatio >= gameRatio)
        {
            //heightに合わせる (横に長い)
            canvasScaler.matchWidthOrHeight = 1f;
        }
        else
        {
            //widthに合わせる (縦に長い)
            canvasScaler.matchWidthOrHeight = 0f;
        }
    }

    WaitForSeconds interval = new WaitForSeconds(1f);
    IEnumerator LoopCoroutine()
    {
        while (true)
        {
            yield return interval;
            Judge();
        }
    }
}
