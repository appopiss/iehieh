using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;
using System;
using static QuestCtrl.QuestId;


public class C_SlimeBoss : C_ENEMY
{
    /*
    攻撃された時の処理を追加する場合は，Attacked()をOverrideする．
    */

    public override void KakuteiDrop()
    {
        main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.SlimeCore] += 1;
    }
    bool isFirstSummon;
    public override bool isDefeatedByOnce { get => main.S.C_S_isDefeatedOnce; set => main.S.C_S_isDefeatedOnce = value; }
    private void Awake()
    {
        //どうでもいい
        AwakeEnemy(1, 1, 1f, atkKind.both, true);

        AwakeCEenemy();
    }

    private void Update()
    {
        main.BossHpSlider.value = (float)(currentHp / HP());
            main.BossHpSlider.GetComponentInChildren<TextMeshProUGUI>().text
    = "ATK : " + tDigit(ATK()) + "    MATK : " + tDigit(MATK()) + "    DEF : " + tDigit(DEF()) + "    MDEF : " + tDigit(MDEF());
        main.BossHpSlider.transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>().text
                    = "King Slime  ( Lv " + (main.QuestCtrl.Quests[(int)slimes].clearedNum + 1) + " )  : " + tDigit(currentHp) + " / " + tDigit(HP());
    }

    public override double DropModifier()
    {
        return Mathf.Min(3.0f, 1.0f + (DropFactor * main.QuestCtrl.Quests[(int)slimes].clearedNum));
    }

    public override float SliderSpeed()
    {
        return base.SliderSpeed();
    }


    private void Start()
    {
        enemyKind = EnemyKind.SlimeKing;
        //ここでステータスを設定できる．
        int factor = main.QuestCtrl.Quests[(int)slimes].clearedNum;
        InputStatus = new double[] { Math.Pow(10, (1 + (factor * 0.1))) * 50000000, Math.Pow(10, (1 + (factor * 0.05))) * 100, 0, Math.Pow(10, (1 + (factor * 0.05))) * 50, Math.Pow(10, (1 + (factor * 0.05))) * 20, 100 * Math.Pow(10, (1 + (factor * 0.05))), 10000 * Math.Pow(10, (1 + (factor * 0.05))) };
        StartEnemy();
        gameObject.GetComponent<RectTransform>().sizeDelta *= (float)(Math.Pow(2, (1 + (factor * 0.001))));
        setActive(main.BossHpSlider.gameObject);
        StartCoroutine(ChangeSprite());
    }

    //スライムの攻撃パターン
    //0.通常攻撃
    //1.スライムを召喚する．
    //2.スライムたちの攻撃力を上げる．
    //3.スライムたちを回復する．
    //開幕で，スライムを3体召喚する．
    int atkMode = 0;
    public override IEnumerator Move()
    {
        while (true)
        {

            if (!isFirstSummon)
            {
                yield return InstantiateSlimes();
                isFirstSummon = true;
                continue;
            }
            int rand = UnityEngine.Random.Range(0, 10000);
            //スライムが一匹もいなかったら確定で召喚する．
            if(GameObject.FindGameObjectsWithTag("enemy").Length == 1)
            {
                yield return InstantiateSlimes();
                continue;
            }


            //範囲内に敵がいた場合
            if (vectorAbs(main.ally1.GetComponent<RectTransform>().anchoredPosition - thisRect.anchoredPosition) <= 100)
            {

                //普通に攻撃する．
                if (rand <= 5000)
                {
                    atkMode = 0;
                }
                //攻撃力を上げる
                else if (rand <= 7500)
                {
                    atkMode = 2;
                }
                //回復する
                else if (rand <= 9000)
                {
                    atkMode = 3;
                }
                //スライムを召喚する．
                else
                {
                    atkMode = 1;
                }
            }
            else
            {
                if (rand <= 4000)
                {
                    atkMode = 2;
                }
                else if (rand <= 8000)
                {
                    atkMode = 3;
                }
                else
                {
                    atkMode = 1;
                }
            }

            switch (atkMode)
            {
                case 0:
                    yield return NormalAttack();
                    break;
                case 1:
                    yield return InstantiateSlimes();
                    break;
                case 2:
                    yield return PowerUpSlimes();
                    break;
                case 3:
                    yield return HealSlimes();
                    break;
            }
        }
    }

    public IEnumerator InstantiateSlimes()
    {
        yield return FillSlider(3.0f,Color.magenta);
        InstantiateLine("My goople, <glabbleflurf> defend me!", Color.black);
        int factor = main.QuestCtrl.Quests[(int)slimes].clearedNum;
        double[] SlimeStatus = new double[] { 300000 * Math.Pow(10, (1 + (factor * 0.1))), 10 * Math.Pow(10, (1 + (factor * 0.05))), 0,0,0,0.5f * Math.Pow(10, (1 + (factor * 0.01))), 100 * Math.Pow(10, (1 + (factor * 0.05))) };
        for (int i = 0; i < Math.Min(factor/10 + 5,10); i++)
        {
            ENEMY enemy;
            enemy = main.GameController.InstantiateEnemy(14, gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(UnityEngine.Random.Range(-200, 200), UnityEngine.Random.Range(0,-200)), true,SlimeStatus);
            enemy.gameObject.AddComponent<DestroyCount>();
            enemy.MoveSpeed= 2f;
        }
    }

    public class DestroyCount : BASE
    {
        private void Awake()
        {
            StartBASE();
        }

        private void OnDestroy()
        {
            main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.slimes].GetComponent<Q_slime>().SlimeChildKilled += 1;
        }
    }

    public IEnumerator PowerUpSlimes()
    {
        yield return FillSlider(2.0f,Color.blue);
        foreach(GameObject game in GameObject.FindGameObjectsWithTag("enemy"))
        {
            game.GetComponent<ENEMY>().initialAtk *= 2;
            StartCoroutine(InstantiateEffect(main.animationObject[31], game.GetComponent<RectTransform>()));
        }
    }

    public IEnumerator HealSlimes()
    {
        yield return FillSlider(2.0f,Color.green);
        foreach (GameObject game in GameObject.FindGameObjectsWithTag("enemy"))
        {
            if (game == gameObject) { continue; }
            game.GetComponent<ENEMY>().currentHp += game.GetComponent<ENEMY>().HP();
            StartCoroutine(InstantiateEffect(main.animationObject[16], game.GetComponent<RectTransform>()));
        }
    }

    public IEnumerator NormalAttack()
    {
        yield return FillSlider(1.0f ,Color.red);
        GameObject game;
        game = Instantiate(main.animationObject[8], main.Transforms[1]);
        game.GetComponent<Attack>().damage = ATK();
        game.GetComponent<Attack>().damageKind = SKILL.DamageKind.physical;
        game.GetComponent<RectTransform>().anchoredPosition = main.ally1.GetComponent<RectTransform>().anchoredPosition;
        yield return new WaitForSeconds(game.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        Destroy(game);
    }


    public IEnumerator InstantiateEffect(GameObject animatedObj, RectTransform transform)
    {
        GameObject game;
        game = Instantiate(animatedObj, transform);
        game.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        game.GetComponent<RectTransform>().sizeDelta *= 2.0f;
        yield return new WaitForSeconds(game.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        Destroy(game);
    }
}
