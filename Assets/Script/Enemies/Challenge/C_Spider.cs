using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static QuestCtrl.QuestId;
using System;
using TMPro;

public class C_Spider : C_ENEMY
{
    /*
    攻撃された時の処理を追加する場合は，Attacked()をOverrideする．
    */
    public override bool isDefeatedByOnce { get => main.S.C_D_isDefeatedOnce; set => main.S.C_D_isDefeatedOnce = value; }

    Slider ExtraSlider;
    float attackSpeed;
    public GameObject BindingObject;
    public GameObject Poison;
    public GameObject Acid;

    public double poisonDamage;

    public override void KakuteiDrop()
    {
        main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.DeathpiderCore] += 1;
    }
    private void Awake()
    {
        //どうでもいい
        AwakeEnemy(1, 1, 0.5f,atkKind.both,true);

        AwakeCEenemy();
        ExtraSlider = gameObject.transform.GetChild(4).GetComponent<Slider>();
        setFalse(ExtraSlider.gameObject);
        enemyKind = EnemyKind.Deathpider;

        statsText = main.BossHpSlider.GetComponentInChildren<TextMeshProUGUI>();
    }
    TextMeshProUGUI statsText;
    private void Update()
    {
        main.BossHpSlider.value = (float)(currentHp / HP());
        statsText.text = main.TextEdit(new string[] { "ATK : ", tDigit(ATK()), "    MATK : ", tDigit(MATK()), "    DEF : ", tDigit(DEF()), "    MDEF : ", tDigit(MDEF()) });
        main.BossHpSlider.transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>().text
                    = "Deathpider  ( Lv " + (main.QuestCtrl.Quests[(int)spider].clearedNum + 1) + " )  : " + tDigit(currentHp) + " / " + tDigit(HP());

    }


    int factor;
    private void Start()
    {
        factor = main.QuestCtrl.Quests[(int)spider].clearedNum;
        InputStatus = new double[] { Math.Pow(10, (1 + (main.QuestCtrl.Quests[(int)spider].clearedNum * 0.1))) * 10000000000, Math.Pow(10, (1 + (factor*0.05))) *
            5000,  Math.Pow(10, (1 + (factor*0.05))) * 5000, Math.Pow(10, (1 + (factor*0.05))) * 4000, Math.Pow(10, (1 + (factor*0.05))) * 4000, Math.Pow(10, (1 + (factor*0.05))) * 200, 100000 * Math.Pow(10, (1 + (factor*0.05))) };
        poisonDamage = main.ally.currentHp * 0.02;
        StartEnemy();
        setActive(main.BossHpSlider.gameObject);
    }

    public override double DropModifier()
    {
        return Mathf.Min(3.0f, 1.0f + (DropFactor * main.QuestCtrl.Quests[(int)spider].clearedNum));
    }


    int atkMode = 0;
    int attackCount;
    //atkMode = 0: 縛り糸
    //atkMode = 1 : 通常攻撃
    //atkMode = 2 : 毒攻撃
    //atkMode = 3 : ATK, MATK低下
    public override IEnumerator Move()
    {
        while (true)
        {
            int rand = UnityEngine.Random.Range(0, 10000);
            if (attackCount % 5 == 0)
            {
                yield return Binding();
                attackCount++;
                continue;
            }
            //範囲内に敵がいた場合
            if (vectorAbs(main.ally1.GetComponent<RectTransform>().anchoredPosition - thisRect.anchoredPosition) <= 100)
            {
                if (rand <= 2000)
                {
                    atkMode = 1;
                }
                else if (rand <= 3000)
                {
                    atkMode = 2;
                }
                else if (rand <= 7000)
                {
                    atkMode = 3;
                }
                else if (rand <= 10000)
                {
                    atkMode = 4;
                }
            }
            else
            {

                if (rand <= 2000)
                {
                    atkMode = 2;
                }
                else if (rand <= 6500)
                {
                    atkMode = 3;
                }
                else if (rand <= 10000)
                {
                    atkMode = 4;
                }
            }

            switch (atkMode)
            {
                case 1:
                    yield return NormalAttack();
                    break;
                case 2:
                    yield return PoisonAttack();
                    break;
                case 3:
                    yield return AcidAttack();
                    break;
                case 4:
                    yield return CallingChildren();
                    break;
            }

            attackCount++;
        }
    }

    public IEnumerator NormalAttack()
    {
        yield return FillSlider(0.5f,Color.red);
        GameObject game;
        game = Instantiate(main.animationObject[8], main.Transforms[1]);
        game.GetComponent<Attack>().damage = ATK();
        game.GetComponent<Attack>().damageKind = SKILL.DamageKind.physical;
        game.GetComponent<RectTransform>().anchoredPosition = main.ally1.GetComponent<RectTransform>().anchoredPosition;
        yield return new WaitForSeconds(game.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        Destroy(game);
    }

    public IEnumerator Binding()
    {
        bool isBinded = false;
        yield return FillSlider(1f,Color.gray);
        GameObject game;
        game = Instantiate(BindingObject, main.Transforms[1]);
        game.GetComponent<RectTransform>().anchoredPosition = main.ally1.GetComponent<RectTransform>().anchoredPosition;
        foreach (Transform child in main.StatusIconCanvas.transform)
        {
            if (child.GetComponent<ABNORMAL>().debuff == Main.Debuff.binding)
            {
                child.GetComponent<ABNORMAL>().currentDuration = 0;
                isBinded = true;
            }
        }
        if (!isBinded)
            Instantiate(main.StatusIcons[8], main.StatusIconCanvas);
    }

    public IEnumerator PoisonAttack()
    {
        yield return FillSlider(1f,Color.magenta);
        GameObject game;
        game = Instantiate(Poison, main.Transforms[1]);
        game.GetComponent<RectTransform>().anchoredPosition = main.ally1.GetComponent<RectTransform>().anchoredPosition;
        game.GetComponent<Attack>().damage = MATK()*1.5;
        game.GetComponent<Attack>().abnormalDamage = poisonDamage;
        game.GetComponent<Attack>().damageKind = SKILL.DamageKind.magical;
        yield return new WaitForSeconds(1f);
        Destroy(game);
    }

    GameObject[] game = new GameObject[30];
    Vector2 target = new Vector2(0, -1);

    public IEnumerator AcidAttack()
    {
        yield return FillSlider(1.0f,Color.yellow);

        int rand = UnityEngine.Random.Range(0, 10000);
        if (rand <= 2500)
        {
            for (int i = 0; i < 8; i++)
            {
                game[i] = Instantiate(Acid, main.Transforms[1]);
                game[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(-180 + i * (360 / 7), 200);
                game[i].AddComponent<Rock>().TargetPosition = target;
                game[i].GetComponent<Attack>().damage = MATK() * 5;
                game[i].GetComponent<Attack>().damageKind = SKILL.DamageKind.magical;
                game[i].GetComponent<Attack>().isDestroyAfterCollide = false;
                game[i].GetComponent<Rock>().speed = 20;
                yield return new WaitForSeconds(0.1f);
            }
        }
        else if (rand <= 5000)
        {
            for (int i = 0; i < 9; i++)
            {
                game[i] = Instantiate(Acid, main.Transforms[1]);
                game[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(180 - i * (360 / 8), 200);
                game[i].AddComponent<Rock>().TargetPosition = target;
                game[i].GetComponent<Attack>().damage = MATK() * 5;
                game[i].GetComponent<Attack>().damageKind = SKILL.DamageKind.magical;
                game[i].GetComponent<Attack>().isDestroyAfterCollide = false;
                game[i].GetComponent<Rock>().speed = 20;
                yield return new WaitForSeconds(0.1f);
            }
        }
        else if (rand <= 7500)
        {
            for (int i = 0; i < 5; i++)
            {
                game[i] = Instantiate(Acid, main.Transforms[1]);
                game[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(0 + i * (180 / 4), 200);
                game[i].AddComponent<Rock>().TargetPosition = target;
                game[i].GetComponent<Attack>().damage = MATK() * 5;
                game[i].GetComponent<Attack>().damageKind = SKILL.DamageKind.magical;
                game[i].GetComponent<Attack>().isDestroyAfterCollide = false;
                game[i].GetComponent<Rock>().speed = 20;
                yield return new WaitForSeconds(0.1f);
            }
            for (int i = 0; i < 4; i++)
            {
                game[i] = Instantiate(Acid, main.Transforms[1]);
                game[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(0 - i * (180 / 3), 200);
                game[i].AddComponent<Rock>().TargetPosition = target;
                game[i].GetComponent<Attack>().damage = MATK() * 5;
                game[i].GetComponent<Attack>().damageKind = SKILL.DamageKind.magical;
                game[i].GetComponent<Attack>().isDestroyAfterCollide = false;
                game[i].GetComponent<Rock>().speed = 20;
                yield return new WaitForSeconds(0.1f);
            }
        }
        else if (rand <= 10000)
        {
            for (int i = 0; i < 5; i++)
            {
                game[i] = Instantiate(Acid, main.Transforms[1]);
                game[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(0 - i * (180 / 4), 200);
                game[i].AddComponent<Rock>().TargetPosition = target;
                game[i].GetComponent<Attack>().damage = MATK() * 5;
                game[i].GetComponent<Attack>().damageKind = SKILL.DamageKind.magical;
                game[i].GetComponent<Attack>().isDestroyAfterCollide = false;
                game[i].GetComponent<Rock>().speed = 20;
                yield return new WaitForSeconds(0.1f);
            }
            for (int i = 0; i < 5; i++)
            {
                game[i] = Instantiate(Acid, main.Transforms[1]);
                game[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(0 + i * (180 / 4), 200);
                game[i].AddComponent<Rock>().TargetPosition = target;
                game[i].GetComponent<Attack>().damage = MATK() * 5;
                game[i].GetComponent<Attack>().damageKind = SKILL.DamageKind.magical;
                game[i].GetComponent<Attack>().isDestroyAfterCollide = false;
                game[i].GetComponent<Rock>().speed = 20;
                yield return new WaitForSeconds(0.1f);
            }
        }
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
    ENEMY[] enemy = new ENEMY[30];


    public IEnumerator CallingChildren()
    {
        yield return FillSlider(1.5f, Color.magenta);
        int factor = main.QuestCtrl.Quests[(int)spider].clearedNum;
        //double[] SpiderStatus = new double[] { 50000000 * Mathf.Pow(1.55f, factor), 500 * Mathf.Pow(1.55f, factor), 1000 * Mathf.Pow(1.55f, factor), 1000 * Mathf.Pow(1.55f, factor), 1000 * Mathf.Pow(1.55f, factor), 50 * Mathf.Pow(1.15f, factor), 2000 * Mathf.Pow(1.25f, factor) };
        for (int i = 0; i < Math.Min(main.QuestCtrl.Quests[(int)spider].clearedNum + 4,30); i++)
        {
            enemy[i] = main.GameController.InstantiateEnemy(12, gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(UnityEngine.Random.Range(-200, 200), UnityEngine.Random.Range(0, -200)), true);
            enemy[i].initialHp *= 1000 * main.QuestCtrl.Quests[(int)spider].clearedNum;
            enemy[i].initialAtk *= (10 + main.QuestCtrl.Quests[(int)spider].clearedNum);
            enemy[i].initialMAtk *= (10 + main.QuestCtrl.Quests[(int)spider].clearedNum);
            //enemy.gameObject.AddComponent<DestroyCount>();
        }
    }
    //public class DestroyCount : BASE
    //{
    //    private void Awake()
    //    {
    //        StartBASE();
    //    }

    //    private void OnDestroy()
    //    {
    //        main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.slimes].GetComponent<Q_slime>().SlimeChildKilled += 1;
    //    }
    //}


    public IEnumerator InstantiateWall(GameObject animatedObj, RectTransform transform)
    {
        GameObject game;
        game = Instantiate(animatedObj, transform);
        game.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        game.GetComponent<RectTransform>().sizeDelta *= 2.5f;
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
