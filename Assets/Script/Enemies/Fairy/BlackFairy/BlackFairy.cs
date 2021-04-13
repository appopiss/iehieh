using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;
using UnityEngine.UI;
using TMPro;



public class BlackFairy : ENEMY
{
    Slider slider1;
    Slider slider2;
    Slider slider3;
    float attackSpeed;

    private void Awake()
    {
        AwakeEnemy(28, 22, 0.5f,atkKind.both,true);
        initialHp *= 3;
        slider1 = gameObject.transform.GetChild(1).GetComponent<Slider>();
        slider2 = gameObject.transform.GetChild(2).GetComponent<Slider>();
        slider3 = gameObject.transform.GetChild(3).GetComponent<Slider>();
        setFalse(slider1.gameObject);
        setFalse(slider2.gameObject);
        setFalse(slider3.gameObject);
    }

    private void Update()
    {
    }

    //public override void SetStatus(double hp, double atk, double matk, double def, double mdef, double gold)
    //{
    //    if (main.GameController.battleMode == GameController.BattleMode.dungeon)
    //    {
    //        base.SetStatus(25000, 10, 20, 0, 20, 5000);
    //        attackSpeed = 0.5f;
    //    }
    //}

    private void Start()
    {
        StartEnemy();
        enemyKind = EnemyKind.BlackFairy;

    }

    //ゴーレムの攻撃パターン
    //1. 範囲内に敵がいれば殴りつけるか，火炎攻撃
    //2. 範囲外に敵がいれば火炎攻撃
    //3. HPが半分を下回るとMATKを上げるバフをかける．
    //4. 何もしない　at
    public override IEnumerator Move()
    {
        bool isEnhanced = false;
        bool isBigFired = false;
        while (true)
        {
            int atkMode = 0;
            int rand = UnityEngine.Random.Range(0, 10000);
            //範囲内に敵がいた場合
            if (vectorAbs(main.ally1.GetComponent<RectTransform>().anchoredPosition - thisRect.anchoredPosition) <= 100)
            {
                //殴り25%火炎65%何もしない10%
                if (rand <= 2500)
                {
                    atkMode = 0;
                }
                else if (rand <= 9990)
                {
                    atkMode = 2;
                }
                else
                {
                    atkMode = 3;
                }
            }
            else
            {
                //火炎85%何もしない15%
                if (rand <= 9990)
                {
                    atkMode = 2;
                }
                else
                {
                    atkMode = 3;
                }
            }


            switch (atkMode)
            {
                case 0:
                    yield return NormalAttack();
                    break;
                case 1:
                    yield return Enhance();
                    break;
                case 2:
                    yield return Fire();
                    break;
                case 3:
                    yield return new WaitForSeconds(1.0f);
                    break;
                case 4:
                    yield return BigFire();
                    break;
            }
        }


    }

    public IEnumerator Fire()
    {
        Vector2 thisPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
        yield return FillSlider(slider2, 0.25f);
        GameObject[] fires = new GameObject[2];
        Vector2[] vector2s = { new Vector2(100, 0) + thisPosition, new Vector2(-100, 0) + thisPosition };
        for (int i = 0; i < fires.Length; i++)
        {
            fires[i] = Instantiate(main.animationObject[51], main.Transforms[1]);
            fires[i].AddComponent<C_RedFairy.FireAttack>();
            fires[i].GetComponent<C_RedFairy.FireAttack>().mDamage = MATK();
            fires[i].GetComponent<C_RedFairy.FireAttack>().damageKind = SKILL.DamageKind.magical;
            fires[i].GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
            fires[i].GetComponent<Image>().raycastTarget = false;
        }
        StartCoroutine(MoveObject(fires[0], vector2s[0]));
        StartCoroutine(MoveObject(fires[1], vector2s[1]));
        yield return FillSlider(slider2, 0.3f);
        for (int i = 0; i < fires.Length; i++)
        {
            if (fires[i] != null)
            {
                fires[i].GetComponent<C_RedFairy.FireAttack>().speed = 25f;
                fires[i].GetComponent<Image>().raycastTarget = true;
                fires[i].GetComponent<C_RedFairy.FireAttack>().TargetPosition = main.ally1.GetComponent<RectTransform>().anchoredPosition
                    - fires[i].GetComponent<RectTransform>().anchoredPosition;
            }
            yield return FillSlider(slider2, 0.1f);
        }
    }

    public IEnumerator BigFire()
    {
        Vector2 thisPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
        GameObject fire = Instantiate(main.animationObject[51], main.Transforms[1]);
        fire.GetComponent<C_RedFairy.FireAttack>().mDamage = MATK() * 3;
        fire.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(0, 120);
        fire.GetComponent<RectTransform>().localScale *= 3;
        fire.GetComponent<Image>().raycastTarget = false;
        yield return FillSlider(slider2, 5.0f);
        fire.GetComponent<Image>().raycastTarget = true;
        fire.GetComponent<C_RedFairy.FireAttack>().speed = 25f;
    }

    public IEnumerator MoveObject(GameObject game, Vector2 targetPosition)
    {
        while (!isRange(10f, targetPosition, game))
        {
            game.GetComponent<RectTransform>().anchoredPosition += normalize(targetPosition - game.GetComponent<RectTransform>().anchoredPosition) * 15f;
            yield return new WaitForSeconds(0.02f);
        }
    }

    public IEnumerator Enhance()
    {
        yield return FillSlider(slider3, 3.0f);
        StartCoroutine(InstantiateEnhance(main.animationObject[32], gameObject.GetComponent<RectTransform>()));
        initialMAtk *= 1.5f;
    }

    public IEnumerator InstantiateEnhance(GameObject animatedObj, RectTransform transform)
    {
        GameObject game;
        game = Instantiate(animatedObj, transform);
        game.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        game.GetComponent<RectTransform>().sizeDelta *= 2.5f;
        yield return new WaitForSeconds(game.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        Destroy(game);

    }

    public IEnumerator NormalAttack()
    {
        yield return FillSlider(slider1, 0.25f);
        GameObject game;
        game = Instantiate(main.animationObject[8], main.Transforms[1]);
        game.GetComponent<Attack>().damage = ATK();
        game.GetComponent<Attack>().damageKind = SKILL.DamageKind.physical;
        game.GetComponent<RectTransform>().anchoredPosition = main.ally1.GetComponent<RectTransform>().anchoredPosition;
        yield return new WaitForSeconds(game.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        Destroy(game);
    }

    public IEnumerator FillSlider(Slider slider, float interval)
    {
        setActive(slider.gameObject);
        slider.value = 0;
        for (int i = 0; i < 50; i++)
        {
            slider.value += 1.0f / 50f;
            yield return new WaitForSeconds(interval / 50);
        }
        setFalse(slider.gameObject);
    }



}
