using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

//これは動的に張り付ける．
public class UNLOCK : BASE
{

    bool isUnlocked;
    public Func<bool> UnlockCondition;
    public Transform TargetCanvas;
    public int orderId;

    // Use this for initialization
    void Awake()
    {
        StartBASE();
    }

    // Use this for initialization
    void Start()
    {
        if (UnlockCondition())
        {
            Unlock();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isUnlocked && UnlockCondition())
        {
            Unlock();
        }
    }

    void Unlock()
    {
        if (TargetCanvas.childCount == 0)
        {
            gameObject.transform.SetParent(TargetCanvas);
            isUnlocked = true;
            return;
        }

        foreach (Transform child in TargetCanvas)
        {
            if (orderId < (int)child.GetComponent<UNLOCK>().orderId)
            {
                gameObject.transform.SetParent(TargetCanvas);
                gameObject.transform.SetSiblingIndex(child.GetSiblingIndex());
                isUnlocked = true;
                return;
            }
        }

        gameObject.transform.SetParent(TargetCanvas);
        gameObject.transform.SetAsLastSibling();
        isUnlocked = true;
    }
}
