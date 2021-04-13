using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

//これは動的に張り付ける．
public class UnlockBank : BASE {

    bool isUnlocked;
    public Func<bool> UnlockCondition;
    public int orderId;
    B_Upgrade thisUpgrade;

	// Use this for initialization
	void Awake () {
		StartBASE();
        orderId = gameObject.GetComponent<B_Upgrade>().iconOrder;
	}

	// Use this for initialization
	void Start () {
        thisUpgrade = gameObject.GetComponent<B_Upgrade>();
        if (UnlockCondition() || thisUpgrade.level > 1)
        {
            Unlock();
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (!isUnlocked && (UnlockCondition()|| thisUpgrade.level > 1))
        {
            Unlock();
        }
	}

    void Unlock() {

        if (main.bankCtrl.ParentCanvas.childCount == 0)
        {
            gameObject.transform.SetParent(main.bankCtrl.ParentCanvas);
            isUnlocked = true;
            return;
        }

        foreach (Transform child in main.bankCtrl.ParentCanvas)
        {
            if(orderId < (int)child.GetComponent<UnlockBank>().orderId)
            {
                gameObject.transform.SetParent(main.bankCtrl.ParentCanvas);
                gameObject.transform.SetSiblingIndex(child.GetSiblingIndex());
                isUnlocked = true;
                return;
            }
        }

        gameObject.transform.SetParent(main.bankCtrl.ParentCanvas);
        gameObject.transform.SetAsLastSibling();
        isUnlocked = true;

    }
}
