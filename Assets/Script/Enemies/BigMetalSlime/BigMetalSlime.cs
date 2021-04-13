using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;
using System;
using static QuestCtrl.QuestId;


public class BigMetalSlime : C_ENEMY
{
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
                    = "Big Metal  ( Lv " + 1 + " )  : " + tDigit(currentHp) + " / " + tDigit(HP());
    }

    public override float SliderSpeed()
    {
        return base.SliderSpeed();
    }

    int hpFactor() => (1 + main.cc.Curses[13].ClearNum) * 10;
    private void Start()
    {
        enemyKind = EnemyKind.SlimeKing;
        //ここでステータスを設定できる．
        InputStatus = new double[] {
            10000 * hpFactor(),
            1000 * hpFactor(),
            0,
            1e300,
            1e300,
            100,
            10000
        };
        dodgeRate = 9900;
        StartEnemy();
        setActive(main.BossHpSlider.gameObject);
        StartCoroutine(ChangeSprite());
    }

    public override IEnumerator Move()
    {
        while (true)
        {
            yield return NormalAttack();
        }
    }
    public IEnumerator NormalAttack()
    {
        yield return FillSlider(5.0f, Color.red);
        InstantiateLine("I've been struck by a strange curse!", Color.black);
        GameObject game;
        game = Instantiate(main.animationObject[8], main.Transforms[1]);
        game.GetComponent<Attack>().damage = ATK();
        game.GetComponent<Attack>().damageKind = SKILL.DamageKind.physical;
        game.GetComponent<RectTransform>().anchoredPosition = main.ally1.GetComponent<RectTransform>().anchoredPosition;
        yield return new WaitForSeconds(game.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        Destroy(game);
    }

    void Line()
    {
        int rand = UnityEngine.Random.Range(0, 3);
        switch (rand)
        {
            case 0:
                InstantiateLine("I've been struck by a strange curse!", Color.black);
                break;
            case 1:
                InstantiateLine("Please Help me!", Color.black);
                break;
            case 2:
                InstantiateLine("I can give you nothing if you beat me ...", Color.black);
                break;
        }
    }
}
