using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

//これは動的に張り付ける．
public class UL_quest : BASE
{

    bool isUnlocked;
    public ACHIEVEMENT.Type type;
    public Func<bool> UnlockCondition;
    public Func<bool> ClearCondition;
    public Transform TargetCanvas;
    public Transform RepeatableCanvas;
    public Transform ClearedCanvas;
    public int orderId;

    // Use this for initialization
    void Awake()
    {
        StartBASE();
    }

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Unlocking());
    }


    void Unlock(Transform canvas)
    {
        if (canvas.childCount == 0)
        {
            gameObject.transform.SetParent(canvas);
            isUnlocked = true;
            return;
        }

        foreach (Transform child in canvas)
        {
            if (orderId < (int)child.GetComponent<UL_quest>().orderId)
            {
                gameObject.transform.SetParent(canvas);
                gameObject.transform.SetSiblingIndex(child.GetSiblingIndex());
                isUnlocked = true;
                return;
            }
        }

        gameObject.transform.SetParent(canvas);
        gameObject.transform.SetAsLastSibling();
        isUnlocked = true;
    }

    IEnumerator Unlocking()
    {

        yield return new WaitUntil(() => UnlockCondition());
        if (type == ACHIEVEMENT.Type.Limited)
        {
            Unlock(TargetCanvas);
        }
        else
        {
            Unlock(RepeatableCanvas);
        }

        //クリアしたらクリアキャンバスに打ち込む
        yield return new WaitUntil(() => ClearCondition());
        //Unlock(ClearedCanvas);
        //gameObject.GetComponent<RectTransform>().localScale *= 0.5f;

    }
}
