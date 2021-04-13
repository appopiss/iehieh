using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static QuestCtrl.QuestId;
using System;
using TMPro;

public class Golem : C_ENEMY
{
    /*
    攻撃された時の処理を追加する場合は，Attacked()をOverrideする．
    */
    public override bool isDefeatedByOnce { get => main.S.C_G_isDefeatedOnce; set => main.S.C_G_isDefeatedOnce = value; }

    public Sprite normalMode;
    public Sprite normalMode1;
    public Sprite attackMode;
    public Sprite attackMode1;
    public Sprite guardMode;
    public Sprite guardMode1;
    public Sprite ieh2normalMode;
    public Sprite ieh2normalMode1;
    public Sprite ieh2attackMode;
    public Sprite ieh2attackMode1;
    public Sprite ieh2guardMode;
    public Sprite ieh2guardMode1;
    bool isDef;

    public override void KakuteiDrop()
    {
        main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.GolemCore] += 1;
    }

    private void Awake()
    {
        isSpecialSprite = true;
        //どうでもいい
        AwakeEnemy(1, 1, 0.5f, atkKind.both, true);


        AwakeCEenemy();
    }

    public override double DropModifier()
    {
        return Mathf.Min(3.0f, 1.0f + (DropFactor * main.QuestCtrl.Quests[(int)golem].clearedNum));
    }

    private void Update()
    {
        main.BossHpSlider.value = (float)(currentHp / HP());
        if (!isDef)
        {
            main.BossHpSlider.GetComponentInChildren<TextMeshProUGUI>().text
                = "ATK : " + tDigit(ATK()) + "    MATK : " + tDigit(MATK()) + "    DEF : " + tDigit(DEF()) + "    MDEF : " + tDigit(MDEF());
        }
        else
        {
            main.BossHpSlider.GetComponentInChildren<TextMeshProUGUI>().text
    = "ATK : " + tDigit(ATK()) + "    MATK : " + tDigit(MATK()) + "    DEF : <color=\"green\">" + tDigit(DEF()) + "</color>    MDEF : <color=\"green\">" + tDigit(MDEF());
        }
        main.BossHpSlider.transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>().text
                    = "Golem  ( Lv " + (main.QuestCtrl.Quests[(int)golem].clearedNum + 1) + " )  : " + tDigit(currentHp) + " / " + tDigit(HP());

    }

    private void Start()
    {
        enemyKind = EnemyKind.Golem;
        int factor = main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.golem].clearedNum;     
        InputStatus = new double[] { Math.Pow(10, (1 + (main.QuestCtrl.Quests[(int)golem].clearedNum * 0.1))) * 1500000000, Math.Pow(10, (1 + (factor*0.05))) *
            500, 0, Math.Pow(10, (1 + (factor*0.05))) * 500, Math.Pow(10, (1 + (factor*0.05))) * 500, Math.Pow(10, (1 + (factor*0.05))) * 150, 50000 * Math.Pow(10, (1 + (factor*0.05))) };

        //int factor = main.QuestCtrl.Quests[(int)slimes].clearedNum;
        //double[] SlimeStatus = new double[] { 300000 * Mathf.Pow(1.75f, factor), 200 * Mathf.Pow(1.44f, factor),0, 40 * Mathf.Pow(1.75f, factor), 0, Mathf.Pow(1.7f, factor) * 25000 };
        StartEnemy();
        setActive(main.BossHpSlider.gameObject);
        StartCoroutine(ChangeSpriteGolem());
    }

    //ゴーレムの攻撃パターン
    //1. 範囲内に敵がいれば殴りつけるか，岩を投げつける． atkMode = 0;
    //2. 範囲外に敵がいれば岩を投げつける．atkMode = 1;
    //3. 一定確率で硬化する atkMode = 2;
    //4. 何もしない　at
    int atkMode = 0;
    int rand;
    public override IEnumerator Move()
    {
        while (true)
        {
            rand = UnityEngine.Random.Range(0, 10000);
            //範囲内に敵がいた場合
            if (vectorAbs(main.ally1.GetComponent<RectTransform>().anchoredPosition - thisRect.anchoredPosition) <= 120)
            {
                if (rand <= 3000)
                {
                    atkMode = 0;
                }
                else if (rand <= 7000)
                {
                    atkMode = 1;
                }
                else 
                {
                    atkMode = 2;
                }
            }
            else
            {
                if (rand <= 5000)
                {
                    atkMode = 1;
                }
                else 
                {
                    atkMode = 2;
                }
            }

            switch (atkMode)
            {
                case 0:
                    gameObject.GetComponent<Image>().sprite = null;
                    if(isPurchasedCostumeDLC)
                        gameObject.GetComponent<Image>().sprite = ieh2normalMode;
                    else
                        gameObject.GetComponent<Image>().sprite = normalMode;
                    yield return NormalAttack();
                    break;
                case 1:
                    gameObject.GetComponent<Image>().sprite = null;
                    if (isPurchasedCostumeDLC)
                        gameObject.GetComponent<Image>().sprite = ieh2attackMode;
                    else
                        gameObject.GetComponent<Image>().sprite = attackMode;
                    yield return RockAttack();
                    break;
                case 2:
                    gameObject.GetComponent<Image>().sprite = null;
                    if (isPurchasedCostumeDLC)
                        gameObject.GetComponent<Image>().sprite = ieh2guardMode;
                    else
                        gameObject.GetComponent<Image>().sprite = guardMode;
                    yield return Harden();
                    break;
                case 3:
                    yield return new WaitForSeconds(1.0f);
                    break;
            }
        }
    }

    public IEnumerator ChangeSpriteGolem()
    {
        while (true)
        {
            if (isPurchasedCostumeDLC)
            {
                switch (atkMode)
                {
                    case 0:
                        if (UnityEngine.Random.Range(0, 2) <= 1)
                        {
                            gameObject.GetComponent<Image>().sprite = null;
                            gameObject.GetComponent<Image>().sprite = ieh2normalMode;
                            yield return new WaitForSeconds(2f);
                        }
                        else
                        {
                            gameObject.GetComponent<Image>().sprite = null;
                            gameObject.GetComponent<Image>().sprite = ieh2normalMode1;
                            yield return new WaitForSeconds(2f);
                        }
                        break;
                    case 1:
                        gameObject.GetComponent<Image>().sprite = null;
                        gameObject.GetComponent<Image>().sprite = ieh2attackMode;
                        yield return new WaitForSeconds(2f);
                        //gameObject.GetComponent<Image>().sprite = null;
                        //gameObject.GetComponent<Image>().sprite = attackMode1;
                        //yield return new WaitForSeconds(2f);
                        break;
                    case 2:
                        if (UnityEngine.Random.Range(0, 2) <= 1)
                        {
                            gameObject.GetComponent<Image>().sprite = null;
                            gameObject.GetComponent<Image>().sprite = ieh2guardMode;
                            yield return new WaitForSeconds(2f);
                        }
                        else
                        {
                            gameObject.GetComponent<Image>().sprite = null;
                            gameObject.GetComponent<Image>().sprite = ieh2guardMode1;
                            yield return new WaitForSeconds(2f);
                        }
                        break;

                    default:
                        yield return new WaitForSeconds(2f);
                        break;
                }

            }
            else
            {
                switch (atkMode)
                {
                    case 0:
                        if (UnityEngine.Random.Range(0, 2) <= 1)
                        {
                            gameObject.GetComponent<Image>().sprite = null;
                            gameObject.GetComponent<Image>().sprite = normalMode;
                            yield return new WaitForSeconds(2f);
                        }
                        else
                        {
                            gameObject.GetComponent<Image>().sprite = null;
                            gameObject.GetComponent<Image>().sprite = normalMode1;
                            yield return new WaitForSeconds(2f);
                        }
                        break;
                    case 1:
                        gameObject.GetComponent<Image>().sprite = null;
                        gameObject.GetComponent<Image>().sprite = attackMode;
                        yield return new WaitForSeconds(2f);
                        //gameObject.GetComponent<Image>().sprite = null;
                        //gameObject.GetComponent<Image>().sprite = attackMode1;
                        //yield return new WaitForSeconds(2f);
                        break;
                    case 2:
                        if (UnityEngine.Random.Range(0, 2) <= 1)
                        {
                            gameObject.GetComponent<Image>().sprite = null;
                            gameObject.GetComponent<Image>().sprite = guardMode;
                            yield return new WaitForSeconds(2f);
                        }
                        else
                        {
                            gameObject.GetComponent<Image>().sprite = null;
                            gameObject.GetComponent<Image>().sprite = guardMode1;
                            yield return new WaitForSeconds(2f);
                        }
                        break;

                    default:
                        yield return new WaitForSeconds(2f);
                        break;
                }
            }
        }
    }


    public IEnumerator NormalAttack()
    {
        yield return FillSlider(1.0f, Color.red);
        GameObject game;
        game = Instantiate(main.animationObject[8], main.Transforms[1]);
        game.GetComponent<Attack>().damage = ATK();
        game.GetComponent<Attack>().damageKind = SKILL.DamageKind.physical;
        game.GetComponent<RectTransform>().anchoredPosition = main.ally1.GetComponent<RectTransform>().anchoredPosition;
        yield return new WaitForSeconds(game.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        Destroy(game);
    }

    GameObject[] game = new GameObject[30];

    public IEnumerator RockAttack()
    {
        yield return FillSlider(2.0f, Color.black);
        game[0] = Instantiate(main.animationObject[50], main.Transforms[1]);
        game[0].GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(-50, 150);
        game[0].AddComponent<Rock>().TargetPosition =
            main.ally1.GetComponent<RectTransform>().anchoredPosition - (gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(-50, 150));
        game[0].GetComponent<Attack>().damage = ATK() * 1.5;
        game[0].GetComponent<Attack>().isDestroyAfterCollide = true;
        game[0].GetComponent<Rock>().speed = 30;
        yield return new WaitForSeconds(0.5f);
        game[1] = Instantiate(main.animationObject[50], main.Transforms[1]);
        game[2] = Instantiate(main.animationObject[50], main.Transforms[1]);
        game[3] = Instantiate(main.animationObject[50], main.Transforms[1]);
        game[4] = Instantiate(main.animationObject[50], main.Transforms[1]);
        game[5] = Instantiate(main.animationObject[50], main.Transforms[1]);
        game[6] = Instantiate(main.animationObject[50], main.Transforms[1]);
        game[1].GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(-200, 200);
        game[2].GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(200, 200);
        game[3].GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(-200, -200);
        game[4].GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(200, -200);
        game[5].GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(-200, 0);
        game[6].GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(200, 0);
        game[1].AddComponent<Rock>().TargetPosition =
    main.ally1.GetComponent<RectTransform>().anchoredPosition - (gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(-200, 200));
        game[2].AddComponent<Rock>().TargetPosition =
    main.ally1.GetComponent<RectTransform>().anchoredPosition - (gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(200, 200));
        game[3].AddComponent<Rock>().TargetPosition =
    main.ally1.GetComponent<RectTransform>().anchoredPosition - (gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(-200, -200));
        game[4].AddComponent<Rock>().TargetPosition =
    main.ally1.GetComponent<RectTransform>().anchoredPosition - (gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(200, -200));
        game[5].AddComponent<Rock>().TargetPosition =
    main.ally1.GetComponent<RectTransform>().anchoredPosition - (gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(200, -0));
        game[6].AddComponent<Rock>().TargetPosition =
    main.ally1.GetComponent<RectTransform>().anchoredPosition - (gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(200, 0));
        for (int i = 1; i < 7; i++)
        {
            game[i].GetComponent<Attack>().damage = ATK() * 1.5;
            game[i].GetComponent<Attack>().isDestroyAfterCollide = true;
            game[i].GetComponent<Rock>().speed = 15;
        }

    }

    public IEnumerator Harden()
    {
        yield return FillSlider(3.0f, Color.green);
        isDef = true;
        initialDef *= 1.5;
        initialMDef *= 1.5;
        StartCoroutine(InstantiateWall(main.animationObject[33], gameObject.GetComponent<RectTransform>()));

    }

    public IEnumerator InstantiateWall(GameObject animatedObj, RectTransform transform)
    {
        GameObject game;
        game = Instantiate(animatedObj, transform);
        game.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        game.GetComponent<RectTransform>().sizeDelta *= 2.5f;
        yield return new WaitForSeconds(game.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        Destroy(game);
    }

    public class Rock : Attack
    {
        public Vector2 TargetPosition;
        public float speed = 30;

        private void Awake()
        {
            AwakeAttack();
            isEnemyAttack = true;
        }

        private void Start()
        {
            StartCoroutine(Move());
            StartCoroutine(DestroyThis());
        }

        public IEnumerator Move()
        {
            while (true)
            {
                thisRect.anchoredPosition += normalize(TargetPosition) * speed;
                yield return new WaitForSeconds(0.016f);
            }
        }



        public IEnumerator DestroyThis()
        {
            yield return new WaitForSeconds(3.0f);
            Destroy(gameObject);
        }
    }
}
