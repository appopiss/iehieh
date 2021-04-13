using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;
using static QuestCtrl.QuestId;
using System;

public class C_octo : C_ENEMY
{
    /*
    攻撃された時の処理を追加する場合は，Attacked()をOverrideする．
    */

    public override void KakuteiDrop()
    {
        main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.OctobaddieCore] += 1;
    }


    bool isFirstSummon;
    Slider ExtraSlider;
    public Attack sumi;
    public override bool isDefeatedByOnce { get => main.S.C_O_isDefeatedOnce; set => main.S.C_O_isDefeatedOnce = value; }
    RectTransform thisRect;
    RectTransform allyRect;
    bool canBlack;
    private void Awake()
    {
        //どうでもいい
        AwakeEnemy(1, 1, 1f,atkKind.both,true);

        AwakeCEenemy();
        ExtraSlider = gameObject.transform.GetChild(2).GetComponent<Slider>();
        thisRect = gameObject.GetComponent<RectTransform>();
        allyRect = main.ally1.GetComponent<RectTransform>();
    }

    private void Update()
    {
        main.BossHpSlider.value = (float)(currentHp / HP());
        main.BossHpSlider.GetComponentInChildren<TextMeshProUGUI>().text
= "ATK : " + tDigit(ATK()) + "    MATK : " + tDigit(MATK()) + "    DEF : " + tDigit(DEF()) + "    MDEF : " + tDigit(MDEF());
        main.BossHpSlider.transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>().text
                    = "Octobaddie  ( Lv " + (main.QuestCtrl.Quests[(int)octan].clearedNum + 1) + " )  : " + tDigit(currentHp) + " / " + tDigit(HP());
    }

    public override double DropModifier()
    {
        return Mathf.Min(3.0f, 1.0f + (DropFactor * main.QuestCtrl.Quests[(int)octan].clearedNum));
    }

    public float SliderFactor()
    {
        return Mathf.Pow(0.975f, main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.octan].clearedNum);
    }

    public override float SliderSpeed()
    {
        return 1.0f * SliderFactor();
    }

    int factor;
    private void Start()
    {
        //ここでステータスを設定できる．
        factor = main.QuestCtrl.Quests[(int)octan].clearedNum;
        InputStatus = new double[] {
            Math.Pow(10, (1 + (factor*0.25))) * 1E27,//1E40, //HP
            0, //ATK
            0, //MATK
            Math.Pow(10, (1 + (factor*0.1))) * 1E6, //DEF
            Math.Pow(10, (1 + (factor*0.1))) * 1E6, //MDEF
            Math.Pow(10, (1 + (factor*0.05))) * 1000, //Gold
            Math.Pow(10, (1 + (factor*0.025))) * 5E8//Exp
        };
        StartEnemy();
        //gameObject.GetComponent<RectTransform>().sizeDelta *= (float)(1 + 0.03 * main.QuestCtrl.Quests[(int)slimes].clearedNum);
        setActive(main.BossHpSlider.gameObject);
        StartCoroutine(ChangeSprite());
        StartCoroutine(BlackOutCtrl());
    }

    int atkMode = 0;
    public override IEnumerator Move()
    {
        while (true)
        {
            int rand = UnityEngine.Random.Range(0, 10000);

            //範囲内に敵がいた場合
            if (vectorAbs(main.ally1.GetComponent<RectTransform>().anchoredPosition - thisRect.anchoredPosition) <= 110)
            {
                //高確率で自分守り
                if (rand <= 1000)
                    atkMode = 2;
                else if (rand <= 4500)
                    atkMode = 1;
                else if (rand <= 8000)
                    atkMode = 3; 
                else
                    atkMode = 4;
            }
            else
            {
                //遠距離攻撃１４
                if (rand <= 1000)
                    atkMode = 1;
                else if (rand <= 5000)
                    atkMode = 2;
                else if (rand <= 6500)
                    atkMode = 3;
                else if (rand <= 8500)
                    atkMode = 5;
                else
                    atkMode = 4;
            }
            canBlack = false;
            switch (atkMode)
             {
                 case 1:
                    yield return Attack1();
                     break;
                case 2:
                    yield return Attack2();
                    break;
                case 3:
                    yield return Attack3();
                    break;
                case 4:
                    yield return Attack4();
                    break;
                case 5:
                    yield return Attack5();
                    break;
            }
            yield return new WaitForSeconds(1.0f);

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
    //周囲に墨を纏う 緑
    public IEnumerator Attack1()
    {
        yield return FillSlider(0.5f, Color.green);
        Vector2 target = allyRect.anchoredPosition - thisRect.anchoredPosition;
        StartCoroutine(InstantiateSumi(3f, new Vector2(0, -50), new Vector2(0, 1)));
        StartCoroutine(InstantiateSumi(1.5f, new Vector2(0, 200), new Vector2(0, -1)));
        StartCoroutine(InstantiateSumi(1.5f, new Vector2(125, 150), new Vector2(-1, -1)));
        StartCoroutine(InstantiateSumi(1.5f, new Vector2(125, 0), new Vector2(-1, 0)));
        StartCoroutine(InstantiateSumi(1.5f, new Vector2(-125, 0), new Vector2(1, 0)));
        StartCoroutine(InstantiateSumi(1.5f, new Vector2(-125, 150), new Vector2(1, -1)));
        yield return new WaitForSeconds(1.0f);
    }
    //5連射する　青
    IEnumerator Attack2()
    {
        yield return FillSlider(0.5f, Color.blue);
        Vector2 target = allyRect.anchoredPosition - thisRect.anchoredPosition;
        StartCoroutine(InstantiateSumi(0.5f, new Vector2(0, 50), target));
        yield return FillSlider(0.25f, Color.blue);
        target = allyRect.anchoredPosition - thisRect.anchoredPosition;
        StartCoroutine(InstantiateSumi(0.5f, new Vector2(0, 50), target));
        yield return FillSlider(0.25f, Color.blue);
        target = allyRect.anchoredPosition - thisRect.anchoredPosition;
        StartCoroutine(InstantiateSumi(0.5f, new Vector2(0, 50), target));
        yield return FillSlider(0.25f, Color.blue);
        target = allyRect.anchoredPosition - thisRect.anchoredPosition;
        StartCoroutine(InstantiateSumi(0.5f, new Vector2(0, 50), target));
        yield return FillSlider(0.25f, Color.blue);
        target = allyRect.anchoredPosition - thisRect.anchoredPosition;
        StartCoroutine(InstantiateSumi(0.5f, new Vector2(0, 50), target));

    }

    //距離固定
    IEnumerator Attack5()
    {
        yield return FillSlider(1.0f, Color.gray);
        //真下にはなつ
        StartCoroutine(InstantiateSumi(0.7f, new Vector2(0, 50), new Vector2(0, -1)));
        yield return FillSlider(0.1f, Color.gray);
        //2Way
        StartCoroutine(InstantiateSumi(0.7f, new Vector2(0, 50), new Vector2(-0.5f, -1)));
        StartCoroutine(InstantiateSumi(0.7f, new Vector2(0, 50), new Vector2(0.5f, -1)));
        yield return FillSlider(0.1f, Color.gray);
        //3Way
        StartCoroutine(InstantiateSumi(0.7f, new Vector2(0, 50), new Vector2(-1.0f, -1)));
        StartCoroutine(InstantiateSumi(0.7f, new Vector2(0, 50), new Vector2(1.0f, -1)));
        StartCoroutine(InstantiateSumi(0.7f, new Vector2(0, 50), new Vector2(0, -1)));
    }

    //端っこに行かなきゃ　赤
    public IEnumerator Attack3()
    {
        yield return FillSlider(2.0f, Color.red);
        Vector2 target = allyRect.anchoredPosition - thisRect.anchoredPosition;
        StartCoroutine(InstantiateSumi(6, new Vector2(0, 50), new Vector2(0, 0)));
        yield return new WaitForSeconds(1.0f);
    }
    //ホーミング弾
    public IEnumerator Attack4()
    {
        yield return FillSlider(1.5f, Color.yellow);
        Vector2 target = allyRect.anchoredPosition;
        yield return FillSlider(0.1f, Color.yellow);
        StartCoroutine(InstantiateSumi(1, target, new Vector2(0, 0)));
    }


    IEnumerator BlackOut()
    {
        yield return ExtraFillSlider(ExtraSlider, 15f);
        yield return new WaitUntil(() => canBlack);
        main.QuestCtrl.sumiImage.color += new Color(0, 0, 0, 1.0f);
        while (main.QuestCtrl.OctBackground.color.a < 1.0f)
        {
            main.QuestCtrl.OctBackground.color += new Color(0,0,0,0.1f);
            yield return new WaitForSeconds(0.25f);
        }
        main.QuestCtrl.sumiImage.color = new Color(0, 0, 0, 0f);
    }
    IEnumerator BlackOutCtrl()
    {
        while (true)
        {
            //yield return new WaitUntil(() => currentHp / HP() <= 0.7f);
            yield return BlackOut();
            yield return new WaitForSeconds(10.0f);
            main.QuestCtrl.OctBackground.color = new Color(0, 0, 0, 0);
        }
    }
    public IEnumerator InstantiateSumi(float size, Vector2 position, Vector2 target)
    {
        Attack game;
        game = Instantiate(sumi, main.Transforms[1]);
        factor = Math.Min(factor, 100);
        game.damage = 1E100 * Math.Pow(10, (1 + factor));
        game.GetComponent<RectTransform>().anchoredPosition = position;
        StartCoroutine(MoveSumi(game.gameObject,target));
        for (int i = 0; i < 10; i++)
        {
            game.gameObject.GetComponent<RectTransform>().localScale += new Vector3(size / 10, size / 10);
            yield return new WaitForSeconds(0.03f);
        }
        game.isDestroyAfterCollide = false;
        yield return new WaitForSeconds(2.0f);
        Destroy(game.gameObject);
        canBlack = true;
    }
    IEnumerator MoveSumi(GameObject game, Vector2 targetPosition)
    {
        while(game != null)
        {
            game.GetComponent<RectTransform>().anchoredPosition += normalize(targetPosition) * 10f;
            yield return new WaitForSeconds(0.032f);
        }
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
    public IEnumerator ExtraFillSlider(Slider slider, float interval)
    {
        setActive(slider.gameObject);
        yield return new WaitUntil(()=>canBlack);
        slider.value = 0;
        for (int i = 0; i < 50; i++)
        {
            slider.value += 1.0f / 50f;
            yield return new WaitForSeconds(interval / 50);
        }
    }

    public override void Dead()
    {
        Application.ExternalCall("kongregate.stats.submit", "OctKill", main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.octan].maxClaredNum+1);
    }
}
