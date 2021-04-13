using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ALLY.Condition;    
using static UsefulMethod;



public class Red : ENEMY
{
    GameObject mpSlider;
    bool isChanting;

    private void Awake()
    {
        AwakeEnemy(8, 4, 0.5f);

        switch (main.GameController.floorNum)
        {
            case 5:
                initialHp = 900;
                currentHp = 900;
                initialMAtk = 15;
                initialGold = 9600;
                break;
            case 6:
                initialHp = 900;
                currentHp = 900;
                initialMAtk = 20;
                initialGold = 14010;
                break;
            case 7:
                initialHp = 900;
                currentHp = 900;
                initialMAtk = 25;
                initialGold = 21300;
                break;
            case 8:
                initialHp = 1200;
                currentHp = 1200;
                initialMAtk = 30;
                initialGold = 34523;
                break;
            case 9:
                initialHp = 1500;
                currentHp = 1500;
                initialMAtk = 35;
                initialGold = 51023;
                break;
            default:
                break;
        }
    }
    private void Start()
    {
        StartEnemy();
        mpSlider = gameObject.transform.GetChild(1).gameObject;
    }

    private void Update()
    {
        if (isChanting&&mahouzin!=null)
        {
            setActive(mahouzin);
        }
        else if(mahouzin!=null)
        {
            setFalse(mahouzin);
        }
    }

    public override void Dead()
    {
        Destroy(mahouzin);
    }

    public override void Attacking()
    {
       StartCoroutine(InstantiateAnimation(main.animationObject[19], targetEnemyPosition, initialMAtk, 0, SKILL.DamageKind.magical));
       //StartCoroutine(InstantiateMahouzin());
    }

    public IEnumerator InstantiateAnimation(GameObject animatedObj, RectTransform transform, double damage = 0, double consumeMp = 0,
     SKILL.DamageKind damageKind = SKILL.DamageKind.physical)
    {
        GameObject game;
        game = Instantiate(animatedObj, main.Transforms[1]);
        switch (damageKind)
        {
            case SKILL.DamageKind.physical:
                game.GetComponent<Attack>().damage = damage;
                game.GetComponent<Attack>().damageKind = SKILL.DamageKind.physical;
                break;
            case SKILL.DamageKind.magical:
                game.GetComponent<Attack>().mDamage = damage;
                game.GetComponent<Attack>().damageKind = SKILL.DamageKind.magical;
                break;
            default:
                break;
        }
        game.GetComponent<RectTransform>().anchoredPosition = transform.anchoredPosition;
        //yield return new WaitForSeconds(game.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        //GameObject mahouzin;
        mahouzin = Instantiate(main.animationObject[23], main.Transforms[3]);
        mahouzin.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
        setActive(mpSlider);
        isChanting = true;
        for (int i = 0; i < 50; i++)
        {
            mpSlider.GetComponent<Slider>().value = (float)i * 0.02f;
            if (mahouzin != null)
            {
                mahouzin.transform.Rotate(new Vector3(0, 0, 90) * 0.1f);
            }
            yield return new WaitForSeconds(AttackSpeed() / 50);
        }
        isChanting = false;
        Destroy(game);
    }

   // public IEnumerator InstantiateMahouzin()
   // {
   //     GameObject mahouzin;
   //     mahouzin = Instantiate(main.animationObject[23], main.Transforms[3]);
   //     mahouzin.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
   //     setActive(mpSlider);
   //     for (int i = 0; i < 50; i++)
   //     {
   //         mpSlider.GetComponent<Slider>().value = (float)i * 0.02f;
   //         mahouzin.transform.Rotate(new Vector3(0, 0, 90) * 0.1f);
   //         yield return new WaitForSeconds(initialAttackSpeed / 50);
   //     }
   //     Destroy(mahouzin);
   // }
    public override IEnumerator Move()
    {
        while (true)
        {

            switch (condition)
            {
                case MoveMode:
                    Vector2 moveDistance = targetEnemyPosition.anchoredPosition - thisRect.anchoredPosition;
                    //  thisRect.anchoredPosition += normalize(moveDistance) * 3.0f;
                    if (vectorAbs(moveDistance) <= 150)
                    {
                        condition = BattleMode;
                    }
                    yield return new WaitForSeconds(0.1f);
                    break;
                case BattleMode:
                    yield return new WaitForSeconds(AttackSpeed());
                    yield return new WaitUntil(() => !isChanting);
                    Attacking();
                    break;
            }

        }
    }


}
