using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class B_autoLeaf : B_Upgrade
{
    private void Awake()
    {
        awakeText();
        initValue = 120;
        initCost = 100000;
        bottom = 1.25;
        plusValue = 0.01;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartUpgrade();
        gameObject.GetComponent<Button>().onClick.AddListener(calculate);
        StartCoroutine(AutoBuyStone());
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUpgrade();
        checkButton();
        if (!window.activeSelf)
            return;
        Name = "Auto Leaf Upgrades";
        effectExplain = "You can randomly automatically buy leaf upgrades.";
        if (level == 0)
            currentValue = "Locked";
        else
            currentValue = "Every " + tDigit(122 * Mathf.Pow(0.99f, level)) + "s";
        nextValue = "Every " + tDigit(120 * Mathf.Pow(0.99f, level + 1)) + "s";
        explain = "An old man sits off to the side of the circular room. Approaching him, he quickly swaps his hat, which has an emblem for Leaf on it. Before you can speak to question the legitimacy of his operation, he starts talking to you. \"Hey there sonny! I\'m head of the Leaf labor union! I\'ve got an exciting time share.. wait, wrong spiel.. I\'ve got an exciting opportunity for you! Do you constantly run out of gold to hire more workers to harvest your Leaf? Well let me tell you, I\'ve got loads of unemployed children, bears, and even golems just waiting to be hired for free. You, uhh, just have to pay the low, low, chance of a lifetime fee of 100,000 SC. Real slick deal, I\'m telling you. So are you interested?\" It's very clear he never saved a penny towards retirement.";
    }

    public M_UPGRADE chooseUpgrade()
    {
        List<M_UPGRADE> tempList = new List<M_UPGRADE>();
        foreach (Transform child in main.bankCtrl.LeafUpgradeCanvas)
        {
            if (child.GetComponent<M_UPGRADE>().canBuy())
            {
                tempList.Add(child.GetComponent<M_UPGRADE>());
            }
        }
        if (tempList.Count == 0)
            return null;

        int randomNum = UnityEngine.Random.Range(0, tempList.Count);
        return tempList[randomNum];
    }

    public IEnumerator AutoBuyStone()
    {
        while (true)
        {
            yield return new WaitUntil(() => level > 0);
            yield return chooseUpgrade();
            chooseUpgrade().calculate();
            yield return new WaitForSeconds(120 * Mathf.Pow(0.99f, level + 1));
        }
    }

}
