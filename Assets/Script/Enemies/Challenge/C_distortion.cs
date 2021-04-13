using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;
using static QuestCtrl.QuestId;
using System;

public class C_distortion : C_ENEMY
{
    /*
    攻撃された時の処理を追加する場合は，Attacked()をOverrideする．
    */
    public override bool isDefeatedByOnce { get => main.S.C_Dis_isDefeatedOnce; set => main.S.C_Dis_isDefeatedOnce = value; }

    Slider ExtraSlider;
    float attackSpeed;
    bool isDef;
    long bananaNum;

    public GameObject circle;
    public GameObject cross1;
    public GameObject cross2;

    public override void KakuteiDrop()
    {
        main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.DarkMatter] += 1;
    }
    private void Awake()
    {
        AwakeEnemy(1, 1, 1f,atkKind.both,true);
        AwakeCEenemy();
        ExtraSlider = gameObject.transform.GetChild(2).GetComponent<Slider>();
        setFalse(ExtraSlider.gameObject);
    }

    private void Update()
    {
        main.BossHpSlider.value = (float)(currentHp / HP());
        main.BossHpSlider.GetComponentInChildren<TextMeshProUGUI>().text
= "ATK : " + tDigit(ATK()) + "    MATK : " + tDigit(MATK()) + "    DEF : " + tDigit(DEF()) + "    MDEF : " + tDigit(MDEF());
        main.BossHpSlider.transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>().text
                    = "Distortion Slime  ( Lv " + (factor + 1) + " )  : " + tDigit(currentHp) + " / " + tDigit(HP());

        if (bananalevel > 0 && bananalevel < 7)
            ExtraSlider.value = (float)bananaNum / (float)RequiredBananaNum();
    }
    int factor;

    private void Start()
    {
        factor = main.QuestCtrl.Quests[(int)distortion].clearedNum;
        InputStatus = new double[] {
            Math.Pow(10, (1 + (factor))) * 9E99 * 5.55 * 1.25,//1E40がデフォルト, //HP
            Math.Pow(10, (1 + (factor))) * 9E99 * 5.55, //ATK
            Math.Pow(10, (1 + (factor))) * 9E99 * 5.55, //MATK
            Math.Pow(10, (1 + (factor))) * 9E99 * 5.55, //DEF
            Math.Pow(10, (1 + (factor))) * 9E99 * 5.55, //MDEF
            Math.Pow(10, (1 + (factor*0.025))) * 5000, //Gold
            Math.Pow(10, (1 + (factor*0.01))) * 3E15//Exp
        };
        StartEnemy();
        setActive(main.BossHpSlider.gameObject);
        StartCoroutine(ExtraAttack());
        StartCoroutine(LINE());
        StartCoroutine(RanAway());
        main.Field.color = new Color(0, 0, 0, 0);
    }

    public override double DropModifier()
    {
        return Mathf.Min(3.0f, 1.0f + (DropFactor * factor));
    }


    int atkMode = 0;
    int attackCount;
    //atkMode = 0 : HPを半分に減らす（黒）
    //atkMode = 1 : 超ダメージ
    //atkMode = 2 : MPを0にする（紫）
    //atkMode = 3 : Buffをすべて消す(灰色)
    //atkMode = 4 : 体力超回復(緑)
    //atkMode = 5 : 防御を上げる(オレンジ)
    //バナナを当てるごとに弱体化（使うスキルが減っていく）していく。
    public override IEnumerator Move()
    {
        while (true)
        {
            atkMode = 9;
            int rand = UnityEngine.Random.Range(0, 10000);
            
            if (rand <= 2000&&!isGravityDisabled)
            {
                atkMode = 0;
            }
            else if (rand <= 4000&&!isGrandCrossDisabled)
            {
                atkMode = 1;
            }
            else if (rand <= 6000&&!isMpDisabled)
            {
                atkMode = 2;
            }
            else if (rand <= 8000&&!isDebuffDisabled)
            {
                atkMode = 3;
            }
            else if (rand <= 10000&&!isHealDisabled)
            {
                atkMode = 4;
            }

            if (!isDef && rand <= 2000&&!isDefDisabled)
            {
                atkMode = 5;
                isDef = true;
            }

            atkMode = 0;
            switch (atkMode)
            {
                case 0:
                    yield return DarkMatter();
                    break;
                case 1:
                    yield return GrandCross();
                    break;
                case 2:
                    yield return DestroyMP();
                    break;
                case 3:
                    yield return DestroyBuff();
                    break;
                case 4:
                    yield return Healing();
                    break;
                case 5:
                    yield return DefUp();
                    break;
                case 9:
                    //何もしない
                    yield return new WaitForSeconds(1.0f);
                    break;
            }
        }
    }
    public override void Attacked()
    {
        if(colliderInfo.gameObject.name == "myBanana(Clone)")
        {
            if (bananaNum < 100000000) 
                bananaNum++;
        }
    }
    bool isHealDisabled;
    bool isDebuffDisabled;
    bool isDefDisabled;
    bool isMpDisabled;
    bool isGravityDisabled;
    bool isGrandCrossDisabled;
    IEnumerator LINE()
    {
        //1:Move
        yield return new WaitUntil(() => bananaNum >= RequiredBananaNum());
        setActive(ExtraSlider.gameObject);
        LevelUp();
        InstantiateLine("Oh my banana!", Color.black);
        /*
         * ここに正規のステータスを入れる
         */
        initialHp = Math.Pow(10, (1 + (factor * 0.25))) * 1E40;//Area7-8の雑魚がE35だった
        currentHp = HP();
        initialAtk = Math.Pow(10, (1 + (factor * 0.25))) * 1E18;
        initialMAtk = 0;
        initialDef = Math.Pow(10, (1 + (factor * 0.12))) * 1E10;
        initialMDef = Math.Pow(10, (1 + (factor * 0.12))) * 1E10;
        yield return new WaitForSeconds(2.0f);

        //2:heal
        yield return new WaitUntil(() => bananaNum >= RequiredBananaNum());
        LevelUp();
        InstantiateLine("My power seems to be weakened...", Color.green);
        currentHp *= 0.75d;
        initialAtk *= 0.75d;
        initialDef *= 0.75d;
        initialMDef *= 0.75d;
        isHealDisabled = true;
        yield return new WaitForSeconds(2.0f);

        //3:debuff
        yield return new WaitUntil(() => bananaNum >= RequiredBananaNum());
        LevelUp();
        InstantiateLine("My power seems to be weakened...", Color.grey);
        currentHp *= 0.70d;
        initialAtk *= 0.70d;
        initialDef *= 0.70d;
        initialMDef *= 0.70d;
        isDebuffDisabled = true;
        yield return new WaitForSeconds(2.0f);

        //4:mp
        yield return new WaitUntil(() => bananaNum >= RequiredBananaNum());
        LevelUp();
        InstantiateLine("My power seems to be weakened...", new Color(1,0,1));
        currentHp *= 0.65d;
        initialAtk *= 0.65d;
        initialDef *= 0.65d;
        initialMDef *= 0.65d;
        isMpDisabled = true;
        yield return new WaitForSeconds(2.0f);

        //5:gravity
        yield return new WaitUntil(() => bananaNum >= RequiredBananaNum());
        LevelUp();
        InstantiateLine("My power seems to be weakened...", Color.black);
        currentHp *= 0.60d;
        initialAtk *= 0.60d;
        initialDef *= 0.60d;
        initialMDef *= 0.60d;
        isDebuffDisabled = true;
        yield return new WaitForSeconds(2.0f);

        //6:def
        yield return new WaitUntil(() => bananaNum >= RequiredBananaNum());
        LevelUp();
        InstantiateLine("My power seems to be weaken.ed..", Color.magenta);
        currentHp *= 0.55d;
        initialAtk *= 0.55d;
        initialDef *= 0.55d;
        initialMDef *= 0.55d;
        isDefDisabled = true;
        yield return new WaitForSeconds(2.0f);

        //7:grandcross
        yield return new WaitUntil(() => bananaNum >= RequiredBananaNum());
        setFalse(ExtraSlider.gameObject);
        LevelUp();
        InstantiateLine("My power seems to be weakened...", Color.cyan);
        currentHp *= 0.50d;
        initialAtk *= 0.50d;
        initialDef *= 0.50d;
        initialMDef *= 0.50d;
        isDebuffDisabled = true;
        yield return new WaitForSeconds(2.0f);
    }

    int bananalevel;
    void LevelUp()
    {
        bananalevel++;
        bananaNum = 0;
    }
    float moveSpeedFactor()
    {
        switch (bananalevel)
        {
            case 0:
                return 0f;
            case 1:
                return 15f;
            case 2:
                return 12f;
            case 3:
                return 9f;
            case 4:
                return 6f;
            case 5:
                return 3f;
            case 6:
                return 1f;
            default:
                return 0f;
        }
    }


    int RequiredBananaNum()
    {
        if (bananalevel == 0)
            return 1;

        return (int)(10 * bananalevel); //10,20,30,40,50,60
    }
    

    public IEnumerator ExtraAttack()
    {
        while (true)
        {
            //yield return ExtraFillSlider(ExtraSlider, 1.5f);
            yield return new WaitForSeconds(1.0f);
            GameObject game2;
            game2 = Instantiate(cross2, gameObject.transform);
            game2.transform.SetAsFirstSibling();
            game2.GetComponent<Image>().color = new Color(1f, 0, 0, 1f/Mathf.Max(bananalevel,1));
            game2.GetComponent<Attack>().damage = ATK() * UnityEngine.Random.Range(1, 10);
            //game2.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
            ////デバフを全て解除する。
            //for (int i = 0; i < isDebuff.Length; i++)
            //{
            //    isDebuff[i] = false;
            //}
            //yield return NormalAttack();
        }
    }

    public IEnumerator RanAway()//バナナを一回受けると常に移動
    {
        yield return new WaitUntil(() => moveSpeedFactor() > 0);
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            Vector2 targetPosition = new Vector2(UnityEngine.Random.Range(-225f, 225f), UnityEngine.Random.Range(-225f, 125f));
            Vector2 direction = targetPosition -
                gameObject.GetComponent<RectTransform>().anchoredPosition;
            while (!isRange(10f, targetPosition, gameObject))
            {
                gameObject.GetComponent<RectTransform>().anchoredPosition += normalize(direction) * moveSpeedFactor();
                yield return new WaitForSeconds(0.05f);
            }
        }
    }


    public IEnumerator NormalAttack()
    {
        GameObject game;
        game = Instantiate(main.animationObject[8], main.Transforms[1]);
        game.GetComponent<Attack>().damage = ATK();
        game.GetComponent<Attack>().damageKind = SKILL.DamageKind.physical;
        game.GetComponent<RectTransform>().anchoredPosition = main.ally1.GetComponent<RectTransform>().anchoredPosition;
        yield return new WaitForSeconds(game.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        Destroy(game);
    }

    public IEnumerator DarkMatter()
    {
        yield return FillSlider(3.0f,Color.black);
        GameObject game;
        game = Instantiate(circle, main.Transforms[1]);
        game.GetComponent<Image>().color = Color.black;
        game.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
        yield return new WaitUntil(() => game == null);
        main.ally.currentHp = 1;
    }

    public IEnumerator GrandCross()
    {
        yield return FillSlider(3.0f,Color.cyan);
        for (int i = 0; i < 10; i++)
        {
            main.Field.color += new Color(0, 0, 0, 0.7f / 10);
            yield return new WaitForSeconds(0.05f);
        }
        //GameObject game;
        //game = Instantiate(cross1, main.Transforms[1]);
        //game.GetComponent<Attack>().damage = ATK()*UnityEngine.Random.Range(1,10);
        //game.GetComponent<RectTransform>().anchoredPosition = main.ally1.GetComponent<RectTransform>().anchoredPosition;
        //yield return new WaitForSeconds(1.0f);
        //game.GetComponent<Image>().raycastTarget = false;
        //game.GetComponent<BoxCollider2D>().enabled = false;

        GameObject game2;   
        game2 = Instantiate(cross2, main.Transforms[1]);
        game2.transform.SetAsFirstSibling();
        game2.GetComponent<Attack>().damage = ATK() * UnityEngine.Random.Range(1, 10);
        game2.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
        yield return new WaitUntil(() => game2 == null);
        for (int i = 0; i < 10; i++)
        {
            main.Field.color += new Color(0, 0, 0, -0.7f / 10);
            yield return new WaitForSeconds(0.05f);
        }
    }

    public IEnumerator DestroyMP()
    {
        yield return FillSlider(3.0f, new Color(1.0f, 0, 1.0f));
        GameObject game;
        game = Instantiate(circle, main.Transforms[1]);
        game.GetComponent<Image>().color = new Color(1.0f, 0, 1.0f);
        game.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
        yield return new WaitUntil(() => game == null);
        main.ally.currentMp = 0;
    }

    public IEnumerator DestroyBuff()
    {
        yield return FillSlider(3.0f,Color.gray);
        GameObject game;
        game = Instantiate(circle, main.Transforms[1]);
        game.GetComponent<Image>().color = Color.gray;
        game.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
        yield return new WaitUntil(() => game == null);
        foreach (Transform child in main.StatusIconCanvas.transform)
        {
            if (child.GetComponent<ABNORMAL>().buff != Main.Buff.nothing)
            {
                Destroy(child.gameObject);
            }
        }
    }

    public IEnumerator Healing()
    {
        yield return FillSlider(3.0f,Color.green);
        GameObject game;
        game = Instantiate(circle, main.Transforms[1]);
        game.GetComponent<Image>().color = Color.green;
        game.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
        for (int i = 0; i < 20; i++)
        {
            if(currentHp < HP())
            {
                currentHp += HP() * 0.0075;
            }
            yield return new WaitForSeconds(0.05f);
        }
    }

    public IEnumerator DefUp()
    {
        yield return FillSlider(3.0f,Color.magenta);
        GameObject game;
        game = Instantiate(circle, main.Transforms[1]);
        game.GetComponent<Image>().color = Color.magenta;
        game.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
        yield return new WaitUntil(() => game == null);
        initialDef *= 4;
        initialMDef *= 4;
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

    //public IEnumerator ExtraFillSlider(Slider slider, float interval)
    //{
    //    setActive(slider.gameObject);
    //    slider.value = 0;
    //    for (int i = 0; i < 50; i++)
    //    {
    //        slider.value += 1.0f / 50f;
    //        yield return new WaitForSeconds(interval / 50);
    //    }
    //}
}
