using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ALLY.Condition;
using static UsefulMethod;
using UnityEngine.UI;
using TMPro;
using System;
using static QuestCtrl.QuestId;



public class C_RedFairy : C_ENEMY
{
    bool isBigFired;

    public override bool isDefeatedByOnce { get => main.S.C_F_isDefeatedOnce; set => main.S.C_F_isDefeatedOnce = value; }

    private void Awake()
    {
        AwakeEnemy(1, 1, 1f,atkKind.both,true);

        AwakeCEenemy();
    }

    public override void KakuteiDrop()
    {
        main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.FairyCore] += 1;
    }

    public override double DropModifier()
    {
        return Mathf.Min(3.0f, 1.0f + (DropFactor * main.QuestCtrl.Quests[(int)fairy].clearedNum));
    }

    private void Update()
    {
        main.BossHpSlider.value = (float)(currentHp / HP());

        if (!isEnhanced)
        {
            main.BossHpSlider.GetComponentInChildren<TextMeshProUGUI>().text
                = "ATK : " + tDigit(ATK()) + "    MATK : " + tDigit(MATK()) + "    DEF : " + tDigit(DEF()) + "    MDEF : " + tDigit(MDEF());
        }
        else
        {
            main.BossHpSlider.GetComponentInChildren<TextMeshProUGUI>().text
    = "ATK : " + tDigit(ATK()) + "   <color=\"green\"> MATK : " + tDigit(MATK()) + "</color>    DEF : " + tDigit(DEF()) + "    MDEF : " + tDigit(MDEF());
        }

        main.BossHpSlider.transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>().text
                        = "Fairy Queen  ( Lv " + (main.QuestCtrl.Quests[(int)fairy].clearedNum + 1) + " )  : " + tDigit(currentHp) + " / " + tDigit(HP());
    }
    int factor;
    private void Start()
    {
        enemyKind = EnemyKind.FairyQueen;
        factor = main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.fairy].clearedNum; 
        InputStatus = new double[] { Math.Pow(10, (1 + (factor*0.1))) * 2500000000000, Math.Pow(10, (1 + (factor*0.05))) *
            20000,  Math.Pow(10, (1 + (factor*0.05))) * 20000, Math.Pow(10, (1 + (factor*0.05))) * 1000, Math.Pow(10, (1 + (factor*0.05))) * 1000, Math.Pow(10, (1 + (factor*0.05))) * 300, 3000000 * Math.Pow(10, (1 + (factor*0.05))) };
        StartEnemy();
        setActive(main.BossHpSlider.gameObject);
    }
    //ゴーレムの攻撃パターン
    //1. 範囲内に敵がいれば殴りつけるか，火炎攻撃
    //2. 範囲外に敵がいれば火炎攻撃
    //3. HPが半分を下回るとMATKを上げるバフをかける．
    //4. 何もしない　at

    int rand;
    int atkMode;
    bool isEnhanced = false;

    public override IEnumerator Move()
    {
        isBigFired = false;
        while (true)
        {
            atkMode = 0;
            rand = UnityEngine.Random.Range(0, 10000);
            //範囲内に敵がいた場合
            if (vectorAbs(main.ally1.GetComponent<RectTransform>().anchoredPosition - thisRect.anchoredPosition) <= 100)
            {
                //殴り25%火炎65%何もしない10%
                if (rand <= 2500)
                {
                    atkMode = 0;
                }
                else if (rand <= 9500)
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
                if (rand <= 9500)
                {
                    atkMode = 2;
                }
                else
                {
                    atkMode = 3;
                }
            }

            if (isEnhanced)
            {
                if (rand <= 8500)
                {
                    atkMode = 2;
                }
                else if (rand <= 9500)
                {
                    atkMode = 1;
                }
                else
                {
                    atkMode = 3;
                }
            }

            if (isBigFired)
            {
                if (rand <= 5000)
                {
                    atkMode = 2;
                }
                else if (rand <= 8000)
                {
                    atkMode = 4;
                }
                else
                {
                    atkMode = 3;
                }
            }

            //最後のあがき・・・
            if (currentHp <= HP() / 4 && !isBigFired)
            {
                atkMode = 4;
                isBigFired = true;
            }

            //先にエンハンスする．
            if(currentHp <= HP() / 2 && !isEnhanced)
            {
                atkMode = 1;
                isEnhanced = true;
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
    float buffFactor;

    public float SliderFactor()
    {
        return Mathf.Pow(0.98f, main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.fairy].clearedNum) * (1/(1+buffFactor));
    }

    public override float SliderSpeed()
    {
        return 1.0f*SliderFactor();
    }


    //これをレベルで可変にできるようにしたいね！
    public IEnumerator Fire()
    {
        Vector2 thisPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
        yield return FillSlider(0.25f, Color.magenta);
        GameObject[] fires = new GameObject[6];
        Vector2[] vector2s = { new Vector2(100, 0)+ thisPosition, new Vector2(-100, 0)+ thisPosition,
            new Vector2(150, -150)+ thisPosition, new Vector2(-150, -150)+ thisPosition
           ,new Vector2(100, -250)+ thisPosition, new Vector2(-100, -250)+ thisPosition};
        for (int i = 0; i < fires.Length; i++)
        {
            fires[i] = Instantiate(main.animationObject[51], main.Transforms[1]);
            fires[i].AddComponent<FireAttack>();
            fires[i].GetComponent<FireAttack>().mDamage = MATK();
            fires[i].GetComponent<FireAttack>().damageKind = SKILL.DamageKind.magical;
            fires[i].GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
            fires[i].GetComponent<BoxCollider2D>().enabled = false;
        }
        StartCoroutine(MoveObject(fires[0], vector2s[0]));
        StartCoroutine(MoveObject(fires[1], vector2s[1]));
        StartCoroutine(MoveObject(fires[2], vector2s[2])); 
        StartCoroutine(MoveObject(fires[3], vector2s[3]));
        StartCoroutine(MoveObject(fires[4], vector2s[4]));
        yield return StartCoroutine(MoveObject(fires[5], vector2s[5]));
        yield return FillSlider(0.25f, Color.magenta);
        for(int i = 0; i < fires.Length; i++)
        {
            fires[i].GetComponent<BoxCollider2D>().enabled = true;
            fires[i].GetComponent<FireAttack>().TargetPosition = main.ally.GetComponent<RectTransform>().anchoredPosition
                -fires[i].GetComponent<RectTransform>().anchoredPosition;
            fires[i].GetComponent<FireAttack>().speed = 20f;
            yield return FillSlider(0.25f, Color.magenta);
        }
    }

    public IEnumerator BigFire()
    {
        InstantiateLine("I'll definitely burn you !!!", Color.red);
        Vector2 thisPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
        GameObject fire = Instantiate(main.animationObject[51], main.Transforms[1]);
        fire.AddComponent<FireAttack>();
        fire.GetComponent<FireAttack>().mDamage = MATK() * 10;
        fire.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(0,120);
        fire.GetComponent<RectTransform>().localScale *= 3f;
        fire.GetComponent<Image>().raycastTarget = false;
        yield return FillSlider(3.5f, Color.black);
        fire.GetComponent<FireAttack>().TargetPosition = main.ally.GetComponent<RectTransform>().anchoredPosition - (gameObject.GetComponent<RectTransform>().anchoredPosition);
        fire.GetComponent<FireAttack>().speed = 20f;
        fire.GetComponent<Image>().raycastTarget = true;
    }

    public IEnumerator MoveObject(GameObject game, Vector2 targetPosition)
    {
        while (!isRange(10f, targetPosition, game))
        {
            game.GetComponent<RectTransform>().anchoredPosition += normalize(targetPosition - game.GetComponent<RectTransform>().anchoredPosition)*15f;
            yield return new WaitForSeconds(0.02f);
        }
    }

    public IEnumerator Enhance()
    {
        yield return FillSlider(1.0f,Color.green);
        InstantiateLine("I'll show you the true power !", Color.red);
        StartCoroutine(InstantiateEnhance(main.animationObject[32], gameObject.GetComponent<RectTransform>()));
        initialMAtk *= 2f;
        buffFactor += 0.5f;
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
        yield return FillSlider(0.25f,Color.red);
        GameObject game;
        game = Instantiate(main.animationObject[8], main.Transforms[1]);
        game.GetComponent<Attack>().damage = ATK();
        game.GetComponent<Attack>().damageKind = SKILL.DamageKind.physical;
        game.GetComponent<RectTransform>().anchoredPosition = main.ally1.GetComponent<RectTransform>().anchoredPosition;
        yield return new WaitForSeconds(game.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        Destroy(game);
    }


    public class FireAttack : Attack
    {

        //遠距離攻撃用のクラス
        public float speed;
        public Vector2 TargetPosition;
        private void Awake()
        {
            AwakeAttack();
            isDestroyAfterCollide = true;
            isEnemyAttack = true;
        }

        private void Start()
        {
            StartCoroutine(Move());
            TargetPosition = targetRect.anchoredPosition - (gameObject.GetComponent<RectTransform>().anchoredPosition);
        }

        public IEnumerator Move()
        {
            while (true)
            {
                //TargetPosition = targetRect.anchoredPosition - (gameObject.GetComponent<RectTransform>().anchoredPosition);
                thisRect.anchoredPosition += normalize(TargetPosition) * speed;
                yield return new WaitForSeconds(0.02f);
            }
        }
    }


}
