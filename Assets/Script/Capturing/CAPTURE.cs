using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CAPTURE : BASE{

    //ENEMY thisEnemy;
    static bool canUse;
    public Image cooltime;

	// Use this for initialization
	void Awake () {
		StartBASE();
        //thisEnemy = gameObject.GetComponent<ENEMY>();
        canUse = false;
	}

    static Color black;
	// Use this for initialization
	void Start () {
        StartCoroutine(CaptureCoolTime());
        black = new Color(1f, 1f, 1f,0);
	}
	
	// Update is called once per frame
	void Update () {
        if (main.mouseEvent.isOver)
        {
            if (Input.GetMouseButtonDown(1)&&canUse&&main.alchemyController.trapNum>0)
            {
                StartCoroutine(Capture(main.mouseEvent.targetEnemy));
            }
        }
	}

    static int chance;
    public static int DropChance(ENEMY targetEnemy)
    {
        chance=0;
        if (targetEnemy.isBoss)
        {
            if (targetEnemy.TotalEachEnemyKilled == 0)
            {
                chance = 0;
            }
            else
            {
                if (targetEnemy.hpRate() >= 0.99)
                {
                    chance = main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.healthyCapture].level * 100;
                }
                else if (targetEnemy.hpRate() <= 0.05)
                {
                    chance = 250;
                    chance += main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.capture].level * 50;

                }
            }
        }
        else
        {
            if(targetEnemy.hpRate() >= 0.99)
            {
                chance = main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.healthyCapture].level * 200 + 1000
                    + main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.capture].level * 100;
            }
            else
            {
                chance = 9900 - (int)(10000 * targetEnemy.hpRate()) + 1000
                    + main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.capture].level * 100;
            }
        }

        chance *= (int)(1+main.MissionMileStone.TrapBonus());
        return Math.Min(Math.Max(chance,0),10000);//最大100%（結局キャップなし）
    }

    static void DestroyTrap()
    {
        for (int i = 0; i < main.alchemyController.AlchemyInventory.childCount; i++)
        {
            if (main.alchemyController.AlchemyInventory.GetChild(i).GetComponent<CONSUMEITEM>().materialName == ALCHEMY.MaterialName.Traps)
            {
                Destroy(main.alchemyController.AlchemyInventory.GetChild(i).GetComponent<CONSUMEITEM>().gameObject);
                return;
            }
        }

    }

    public IEnumerator Capture(ENEMY targetEnemy)
    {
        if (targetEnemy.gameObject.HasComponent<C_ENEMY>())
        {
            main.Log("<color=red>You can't capture this monster!");
            yield break;
        }
        if (main.alchemyController.trapNum > 0)
        {
            main.alchemyController.trapNum -= 1;
        }
        else
        {
            yield break;
        }
        DestroyTrap();
        canUse = false;
        //cooltime.fillAmount = 1.0f;
        //ここからがキャプチャの処理
        StartCoroutine(ActualCapture(targetEnemy));
    }
    public IEnumerator ActualCapture(ENEMY targetEnemy, bool isAuto = false)
    {
        GameObject capture;
        capture = Instantiate(main.Capture, targetEnemy.gameObject.transform);
        capture.GetComponent<RectTransform>().sizeDelta = new Vector2(targetEnemy.gameObject.GetComponent<RectTransform>().sizeDelta.x,
            targetEnemy.gameObject.GetComponent<RectTransform>().sizeDelta.y);
        //Debug.Log(DropChance(targetEnemy));
        if (isAuto || UnityEngine.Random.Range(0, 10000) <= DropChance(targetEnemy))
        {
            targetEnemy.InstantiateText("Captured!", Color.blue);
            main.Log("<color=green>Capture Success!");
            targetEnemy.TotalEnemiesCaptured += 1;
            main.S.totalEnemyCaptured += 1;
            targetEnemy.gameObject.GetComponent<ENEMY>().MoveSpeed = 0;
            for (int i = 0; i < 5; i++)
            {
                targetEnemy.gameObject.GetComponent<Image>().color -= black / 5;
                yield return new WaitForSeconds(0.1f);
            }
            Destroy(targetEnemy.gameObject);
        }
        else
        {
            targetEnemy.InstantiateText("Miss!!!", Color.blue);
            main.Log("<color=red>Capture Failed");
        }
    }

    public IEnumerator CaptureCoolTime()//一回クールタイム1秒にしてみた
    {
        while (true)
        {
            yield return new WaitUntil(() => !canUse);
            for(int i = 0; i < 2; i++)
            {
                //cooltime.fillAmount -= 1.0f / 6;
                yield return new WaitForSeconds(0.5f);
            }
            canUse = true;
        }
    }



  //  public void OnPointerDown(PointerEventData eventData)
  //  {
  //      //トラップを持っていなければreturn
  //     // if (main.alchemyController.trapNum == 0)
  //     //     return;
  //
  //      if (eventData.pointerId == -2)
  //      {
  //          StartCoroutine(Capture());
  //      }
  //  }
}
