using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static QuestCtrl.QuestId;
using TMPro;
using System;

public class Bananoon : C_ENEMY
{
    /*
    攻撃された時の処理を追加する場合は，Attacked()をOverrideする．
    */
    public override bool isDefeatedByOnce { get => main.S.C_B_isDefeatedOnce; set => main.S.C_B_isDefeatedOnce = value; }

    public RuntimeAnimatorController normal;
    public RuntimeAnimatorController banana;
    public RuntimeAnimatorController ieh2normal;
    public RuntimeAnimatorController ieh2banana;
    public Sprite poisonBanana;

    private void Awake()
    {
        isSpecialSprite = true;
        AwakeEnemy(1, 1, 1f,atkKind.both,true);
        enemyKind = EnemyKind.Bananoon;
        AwakeCEenemy();
    }
    public override void KakuteiDrop()
    {
        main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.BananoonCore] += 1;
    }

    public override double DropModifier()
    {
        return Mathf.Min(3.0f, 1.0f + (DropFactor * main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.banana].clearedNum));
    }

    private void Update()
    {
        main.BossHpSlider.value = (float)(currentHp / HP());
        main.BossHpSlider.GetComponentInChildren<TextMeshProUGUI>().text
                        = "ATK : " + tDigit(ATK()) + "    MATK : " + tDigit(MATK()) + "    DEF : " + tDigit(DEF()) + "    MDEF : " + tDigit(MDEF());
        main.BossHpSlider.transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>().text
                    = "Bananoon  ( Lv " + (main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.banana].clearedNum + 1) + " )  : " + tDigit(currentHp) + " / " + tDigit(HP());

    }
    int factor;
    private void Start()
    {
        if (isPurchasedCostumeDLC)
            gameObject.GetComponent<Animator>().runtimeAnimatorController = ieh2normal;
        else
            gameObject.GetComponent<Animator>().runtimeAnimatorController = normal;

        factor = main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.banana].clearedNum; 
        InputStatus = new double[] {
            Math.Pow(10, (1 + (factor*0.1))) * 1000000000000000000, //HP
            Math.Pow(10, (1 + (factor*0.05))) * 1000000, //ATK
            0, //MATK
            0, //DEF
            Math.Pow(10, (1 + (factor*0.05))) * 1000000000, //MDEF
            Math.Pow(10, (1 + (factor*0.05))) * 500, //Gold
            10000000 * Math.Pow(10, (1 + (factor*0.025)//Exp
            ))
        };
        StartEnemy();
        //gameObject.GetComponentInChildren<Slider>().gameObject.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 10000);
        setActive(main.BossHpSlider.gameObject);
    }

    public override float SliderSpeed()
    {
        return Mathf.Max(1.0f * Mathf.Pow(0.98f, main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.banana].clearedNum),0.1f);
    }

    //バナヌーンの攻撃パターン
    //1. ランダムな点に逃げる．atkMode = 0;
    //2. バナナ乱射 atkMode =1;
    //3. 攻撃 atkMode = 2;
    //4. やばいバナナ atkMode = 3;
    int atkMode;
    int rand;
    public override IEnumerator Move()
    {
        while (true)
        {
            atkMode = 0;
            rand = UnityEngine.Random.Range(0, 10000);

            if(currentHp/HP() >= 0.5)
            {
                if (vectorAbs(main.ally1.GetComponent<RectTransform>().anchoredPosition - thisRect.anchoredPosition) <= 100)
                {
                    if (rand <= 5000)
                    {
                        atkMode = 0;
                    }
                    else if (rand <= 7500)
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
                    if (rand <= 7500)
                    {
                        atkMode = 0;
                    }
                    else
                    {
                        atkMode = 1;
                    }
                }
            }
            else
            {
                    if (rand <= 5000)
                    {
                        atkMode = 0;
                    }
                    else if (rand <= 7500)
                    {
                        atkMode = 1;
                    }
                    else
                    {
                        atkMode = 3;
                    }
            }
            switch (atkMode)
            {
                case 0:
                    yield return RanAway();
                    break;
                case 1:
                    yield return BananaFire();
                    break;
                case 2:
                    yield return NormalAttack();
                    break;
                case 3:
                    yield return BananaFireTogether();
                    break;
            }
            if (isPurchasedCostumeDLC)
                gameObject.GetComponent<Animator>().runtimeAnimatorController = ieh2normal;
            else
                gameObject.GetComponent<Animator>().runtimeAnimatorController = normal;
        }
    }

    public IEnumerator NormalAttack()
    {
        yield return FillSlider(0.5f, Color.red);
        GameObject game;
        game = Instantiate(main.animationObject[8], main.Transforms[1]);
        game.GetComponent<Attack>().damage = ATK();
        game.GetComponent<Attack>().damageKind = SKILL.DamageKind.physical;
        game.GetComponent<RectTransform>().anchoredPosition = main.ally1.GetComponent<RectTransform>().anchoredPosition;
        yield return new WaitForSeconds(game.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        Destroy(game);
    }


    public IEnumerator RanAway()
    {
        if (isPurchasedCostumeDLC)
            gameObject.GetComponent<Animator>().runtimeAnimatorController = ieh2normal;
        else
            gameObject.GetComponent<Animator>().runtimeAnimatorController = normal;
        yield return FillSlider(0.5f, Color.blue);
        Vector2 targetPosition = new Vector2(UnityEngine.Random.Range(-225f, 225f), UnityEngine.Random.Range(-225f, 125f));
        Vector2 direction = targetPosition -
            gameObject.GetComponent<RectTransform>().anchoredPosition;
        while (!isRange(10f, targetPosition, gameObject))
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition += normalize(direction) * 15f;
            yield return new WaitForSeconds(0.05f);
        }
    }
    GameObject game;
    public IEnumerator BananaFire()
    {
        if(isPurchasedCostumeDLC)
            gameObject.GetComponent<Animator>().runtimeAnimatorController = ieh2banana;
        else
            gameObject.GetComponent<Animator>().runtimeAnimatorController = banana;
        yield return FillSlider(2.0f,Color.yellow);
        for (int i = 0; i < 30 + factor; i++)
        {
            game = Instantiate(main.animationObject[52], main.Transforms[1]);
            if (UnityEngine.Random.Range(0, 10000) <= 1200)
            {
                game.GetComponent<Image>().sprite = poisonBanana;
                game.GetComponent<Attack>().thisDebuff = Main.Debuff.poison;
                game.GetComponent<Attack>().abnormalDamage = main.ally.currentHp * 0.05;
            }
            game.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
            game.GetComponent<D_Attack>().speed = 0f;
            game.GetComponent<Attack>().damage = ATK() * 3;
            game.GetComponent<Attack>().damageKind = SKILL.DamageKind.physical;
            StartCoroutine(MoveBanana(game));
            yield return new WaitForSeconds(0.05f * SliderSpeed());
        }
    }
    GameObject game2;
    public IEnumerator BananaFireTogether()
    {
        if(isPurchasedCostumeDLC)
            gameObject.GetComponent<Animator>().runtimeAnimatorController = ieh2banana;
        else
            gameObject.GetComponent<Animator>().runtimeAnimatorController = banana;
        yield return FillSlider(2.0f,Color.black);
        for (int i = 0; i < 30 + factor; i++)
        {
            game2 = Instantiate(main.animationObject[52], main.Transforms[1]);
            if (UnityEngine.Random.Range(0, 10000) <= 1200)
            {
                game2.GetComponent<Image>().sprite = poisonBanana;
                game2.GetComponent<Attack>().thisDebuff = Main.Debuff.poison;
                game2.GetComponent<Attack>().abnormalDamage = main.ally.currentHp * 0.05;
            }
            game2.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
            game2.GetComponent<D_Attack>().speed = 0f;
            game2.GetComponent<Attack>().damage = ATK() * 3;
            game2.GetComponent<Attack>().damageKind = SKILL.DamageKind.physical;
            StartCoroutine(MoveBananaTogether(game2));
            yield return new WaitForSeconds(0.05f * SliderSpeed());
        }
    }
    //Vector2 random;
    public IEnumerator MoveBanana(GameObject game)
    {
        Vector2 random = randomVec();
        for (int i = 0; i < 75; i++)
        {
            if(game!=null)
                game.GetComponent<RectTransform>().anchoredPosition += random * 20f;
            yield return new WaitForSeconds(0.02f);
        }

        if (game != null)
            Destroy(game);
    }

    Vector2 random2;
    public IEnumerator MoveBananaTogether(GameObject game)
    {
        random2 = randomVec();
        for (int i = 0; i < 75; i++)
        {
            game.GetComponent<RectTransform>().anchoredPosition += random2 * 20f;
            yield return new WaitForSeconds(0.02f);
        }

        if (game != null)
            Destroy(game);
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

}
