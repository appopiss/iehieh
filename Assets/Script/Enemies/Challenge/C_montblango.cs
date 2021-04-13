using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;
using static QuestCtrl.QuestId;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;

public class C_montblango : C_ENEMY
{
    /*
    攻撃された時の処理を追加する場合は，Attacked()をOverrideする．
    */

    public override bool isDefeatedByOnce { get => main.S.C_M_isDefeatedOnce; set => main.S.C_M_isDefeatedOnce = value; }

    Slider ExtraSlider;
    Image thisImage;
    Attack hariAttack;
    bool isAllyInRange;
    double hariDamage;
    double igaDamage;
    float moveSpeed = 5.0f;
    public Sprite Shape1, Shape2, Cute, Block;
    public Sprite ieh2Shape1, ieh2Shape2, ieh2Cute, ieh2Block;
    public GameObject hari;
    bool ToRight = false;
    public static bool isCute;

    /*
    enum Condition
    {
        normal,
        block,
        cute
    }
    Condition thisCondition;
    */

    public override void KakuteiDrop()
    {
        //main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.SlimeCore] += 1;
    }

    private void Awake()
    {
        isSpecialSprite = true;
        //どうでもいい
        AwakeEnemy(1, 1, 1f,atkKind.both,true);
        enemyKind = EnemyKind.Montblango;

        AwakeCEenemy();
        thisImage = gameObject.GetComponent<Image>();
        thisImage.sprite = Shape1;
        hariAttack = gameObject.GetComponentInChildren<Attack>();
        ExtraSlider = gameObject.transform.GetChild(2).GetComponent<Slider>();
        setFalse(ExtraSlider.gameObject);
        //boolの初期化
        isCute = false;
        main.montblangoIsBig = false;

    }

    public override double DropModifier()
    {
        return Mathf.Min(3.0f, 1.0f + (DropFactor * main.QuestCtrl.Quests[(int)montblango].clearedNum));
    }


    private void Update()
    {
        main.BossHpSlider.value = (float)(currentHp / HP());
        main.BossHpSlider.GetComponentInChildren<TextMeshProUGUI>().text
= "ATK : " + tDigit(ATK()) + "    MATK : " + tDigit(MATK()) + "    DEF : " + tDigit(DEF()) + "    MDEF : " + tDigit(MDEF());
        main.BossHpSlider.transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>().text
                    = "Montblango  ( Lv " + (main.QuestCtrl.Quests[(int)montblango].clearedNum + 1) + " )  : " + tDigit(currentHp) + " / " + tDigit(HP());
        if(vectorAbs(gameObject.GetComponent<RectTransform>().anchoredPosition - main.ally1.GetComponent<RectTransform>().anchoredPosition)
            < gameObject.GetComponent<RectTransform>().sizeDelta.x*0.5)
        {
            isAllyInRange = true;
        }
        else
        {
            isAllyInRange = false;
        }
    }

    public override float SliderSpeed()
    {
        return Mathf.Max(1.0f * Mathf.Pow(0.98f, main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.montblango].clearedNum), 0.1f);
    }


    Coroutine walkCor;
    Coroutine currentFillSliderCor;
    private void Start()
    {
        int factor = main.QuestCtrl.Quests[(int)montblango].clearedNum;
        InputStatus = new double[] {
            Math.Pow(10, (1 + factor)) * 1E19 * 5,//1E23, //HP
            Math.Pow(10, (1 + factor*0.25)) * 1E6,//1E10, //ATK
            0, //MATK
            Math.Pow(10, (1 + (factor))) * 1E99, //DEF
            Math.Pow(10, (1 + (factor))) * 1E99, //MDEF
            Math.Pow(10, (1 + (factor*0.1))) * 500, //Gold
            1E6 * Math.Pow(10, (1 + (factor*0.025)//Exp
            ))
        };
        moveSpeed = 5.0f;
        StartEnemy();
        setActive(main.BossHpSlider.gameObject);
        if (isPurchasedCostumeDLC)
        {
            Shape1 = ieh2Shape1;
            Shape2 = ieh2Shape2;
            Cute = ieh2Cute;
            Block = ieh2Block;
        }
        StartCoroutine(changeSprite());
        StartCoroutine(SpanDamage());
        StartCoroutine(SideWalk());
        StartCoroutine(Ahegao());
    }

    int atkNum;
    int atkMode = 0;
    public override IEnumerator Move()
    {
        while (true)
        {
            yield return new WaitUntil(() => thisImage.sprite != Cute);
            int rand = UnityEngine.Random.Range(0, 10000);

             if (rand <= 3500)
             {
                 atkMode = 1;
             }
             else if (rand <= 7000)
             {
                 atkMode = 2;
             }
             else if (rand <= 10000)
             {
                 atkMode = 5;
             }

            if (atkNum >= 5 && atkNum % 5 == 0)
                atkMode = 3;
            if (!main.montblangoIsBig && currentHp/HP() <= 0.5f)
            {
                atkMode = 4;
                main.montblangoIsBig = true;
            }
            switch (atkMode)
            {
                case 1:
                    yield return HormingShot();
                    break;
                case 2:
                    yield return DiffusionShot();
                    break;
                case 3:
                    yield return IgaIgaMode();
                    break;
                case 4:
                    yield return Enlarge();
                    break;
                case 5://IgaStay
                    yield return IgaStay();
                    break;
            }
            atkNum++;
        }
    }
    public override void Attacked()
    {
        if (thisImage.sprite != Block)
        {
            if (colliderInfo.gameObject.name == "FireStorm6b(Clone)" || colliderInfo.gameObject.name == "FireStorm6(Clone)" || colliderInfo.gameObject.name == "FireStorm")
            {
                if (!ExtraSlider.gameObject.activeSelf)
                    setActive(ExtraSlider.gameObject);

                ExtraSlider.value += 0.0005f;
            }
            if (colliderInfo.gameObject.name == "Fire(Clone)")
            {
                if (!ExtraSlider.gameObject.activeSelf)
                    setActive(ExtraSlider.gameObject);

                ExtraSlider.value += 0.0001f;
            }
            if (colliderInfo.gameObject.name == "MeteoStrike(Clone)" || colliderInfo.gameObject.name == "MeteoStrike2(Clone)" || colliderInfo.gameObject.name == "MeteoStrike3(Clone)" || colliderInfo.gameObject.name == "MeteoStrike4(Clone)")
            {
                if (!ExtraSlider.gameObject.activeSelf)
                    setActive(ExtraSlider.gameObject);

                ExtraSlider.value += 0.0025f;
            }            
        }
        else
        {
            if (colliderInfo.gameObject.name == "FireStorm6b(Clone)" || colliderInfo.gameObject.name == "FireStorm6(Clone)" || colliderInfo.gameObject.name == "FireStorm")
            {
                if (!ExtraSlider.gameObject.activeSelf)
                    setActive(ExtraSlider.gameObject);

                ExtraSlider.value += 0.005f;
            }
            if (colliderInfo.gameObject.name == "Fire(Clone)")
            {
                if (!ExtraSlider.gameObject.activeSelf)
                    setActive(ExtraSlider.gameObject);

                ExtraSlider.value += 0.001f;
            }
            if (colliderInfo.gameObject.name == "MeteoStrike(Clone)" || colliderInfo.gameObject.name == "MeteoStrike2(Clone)" || colliderInfo.gameObject.name == "MeteoStrike3(Clone)" || colliderInfo.gameObject.name == "MeteoStrike4(Clone)")
            {
                if (!ExtraSlider.gameObject.activeSelf)
                    setActive(ExtraSlider.gameObject);

                ExtraSlider.value += 0.025f;
            }
        }
    }

    public double tempDef;
    public double tempMDef;
    public IEnumerator Ahegao()
    {
        while (true)
        {
            yield return ExtraSlider.gameObject;
            yield return new WaitUntil(() => ExtraSlider.value >= 1.0f);
            ExtraSlider.value = 0;
            thisImage.sprite = Cute;
            isCute = true;
            foreach (var iga in igastay)
            {
                if(iga!=null)
                    iga.GetComponent<IgaIga>().isIgastay = false;
            }
            igastayNum = 0;
            main.GameController.ChangeFieldSprite();
            StopCoroutine(currentFillSliderCor);
            tempDef = initialDef;
            tempMDef = initialMDef;
            initialDef = 0;
            initialMDef = 0;
            yield return new WaitForSeconds(10.0f);
            initialDef = tempDef;
            initialMDef = tempMDef;
            thisImage.sprite = Shape1;
            isCute = false;
            main.GameController.ChangeFieldSprite();

        }
    }
    public void OnDestroy()
    {
        igastayNum = 0;
        foreach (var iga in igastay)
        {
            if (iga != null)
                iga.GetComponent<IgaIga>().isIgastay = false;
        }
        isCute = false;
        main.GameController.ChangeFieldSprite();
    }
    public IEnumerator changeSprite()
    {
        bool tempBool = false;
        while (true)
        {
            yield return new WaitUntil(() => thisImage.sprite == Shape1 || thisImage.sprite == Shape2);
            if (thisImage.sprite == Block || thisImage.sprite == Cute)
                thisImage.sprite = Shape1;

            gameObject.GetComponent<Image>().sprite = tempBool ? Shape1 : Shape2;
            tempBool = !tempBool;
            yield return new WaitForSeconds(0.5f);
        }
    }

    public IEnumerator SpanDamage()
    {
        while (true)
        {
            yield return new WaitUntil(() => isAllyInRange);
            yield return new WaitUntil(() => thisImage.sprite == Block);
            if(isAllyInRange)
            {
                main.ally.currentHp -= main.ally.HP() * 0.25;
                main.ally.InstantiateDamage(hariDamage, SKILL.DamageKind.physical);
            }
            yield return new WaitForSeconds(0.05f);
        }
    }
    public GameObject[] igastay = new GameObject[30];
    public int igastayNum;
    public IEnumerator IgaStay()
    {
        yield return currentFillSliderCor = StartCoroutine(FillSlider(1.5f, Color.yellow));
        if (igastayNum >= 30)
            igastayNum = 0;
        igastay[igastayNum] = Instantiate(hari, main.Transforms[1]);
        igastay[igastayNum].AddComponent<IgaIga>().TargetPosition =
            main.ally1.GetComponent<RectTransform>().anchoredPosition - gameObject.GetComponent<RectTransform>().anchoredPosition;
        igastay[igastayNum].GetComponent<IgaIga>().MontblangoPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
        igastay[igastayNum].GetComponent<IgaIga>().isIgastay = true;
        igastay[igastayNum].GetComponent<IgaIga>().damage = main.ally.HP()*4;
        igastay[igastayNum].GetComponent<IgaIga>().speed = 30;
        igastay[igastayNum].GetComponent<RectTransform>().sizeDelta *= 3;
        igastay[igastayNum].GetComponent<CircleCollider2D>().radius *= 3;
        igastayNum++;
    }

    public IEnumerator Enlarge()
    {
        yield return currentFillSliderCor = StartCoroutine(FillSlider(8.0f, Color.black));
        InstantiateLine("I'll show you my hidden move ...", Color.black);
        moveSpeed = 10.0f;
        //2.25倍にする
        RectTransform thisRect = gameObject.GetComponent<RectTransform>();
        while(thisRect.localScale.x <= 2.25f)
        {
            thisRect.localScale += new Vector3(0.1f, 0.1f);
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }

    public IEnumerator SideWalk()
    {
        Vector2 moveDirection = new Vector2(0,0);

        while (true)
        {
            yield return new WaitUntil(() => thisImage.sprite == Shape1 || thisImage.sprite == Shape2);
            if (ToRight)
                moveDirection = new Vector2(1,0);
            else
                moveDirection = new Vector2(-1,0);

            if (gameObject.GetComponent<RectTransform>().anchoredPosition.x >= 200)
                ToRight = false;
            else if (gameObject.GetComponent<RectTransform>().anchoredPosition.x <= -200)
                ToRight = true;

            gameObject.GetComponent<RectTransform>().anchoredPosition += moveDirection * moveSpeed * 0.75f * (1f - 0.75f * Convert.ToInt32(isDebuff[(int)Main.Debuff.cold]))*(1f - 0.5f*Convert.ToInt32(isDebuff[(int)Main.Debuff.freeze]));
            yield return new WaitForSeconds(0.017f);
        }
    }

    //public IEnumerator NormalAttack()
    //{
    //    yield return currentFillSliderCor = StartCoroutine(FillSlider(1.0f, Color.red));
    //    GameObject game;
    //    game = Instantiate(main.animationObject[8], main.Transforms[1]);
    //    game.GetComponent<Attack>().damage = ATK()*0.25;
    //    game.GetComponent<Attack>().damageKind = SKILL.DamageKind.physical;
    //    game.GetComponent<RectTransform>().anchoredPosition = main.ally1.GetComponent<RectTransform>().anchoredPosition;
    //    yield return new WaitForSeconds(game.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    //    Destroy(game);
    //}

    //public IEnumerator InstantiateWall(GameObject animatedObj, RectTransform transform)
    //{
    //    GameObject game;
    //    game = Instantiate(animatedObj, transform);
    //    game.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
    //    game.GetComponent<RectTransform>().sizeDelta *= 2.5f;
    //    yield return new WaitForSeconds(game.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    //    Destroy(game);
    //}

    public IEnumerator HormingShot()
    {
        yield return currentFillSliderCor = StartCoroutine(FillSlider(1.0f, Color.blue));
        GameObject[] igaigas = new GameObject[30];
        for(int i=0; i < 30; i++)
        {
            igaigas[i] = Instantiate(hari, main.Transforms[1]);
            igaigas[i].AddComponent<IgaIga>().TargetPosition = 
                main.ally1.GetComponent<RectTransform>().anchoredPosition - gameObject.GetComponent<RectTransform>().anchoredPosition;
            igaigas[i].GetComponent<IgaIga>().MontblangoPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
            igaigas[i].GetComponent<IgaIga>().damage = ATK();
            igaigas[i].GetComponent<IgaIga>().speed = 20;
            igaigas[i].GetComponent<IgaIga>().isDestroyAfterCollide = true;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public IEnumerator DiffusionShot()
    {
        yield return currentFillSliderCor = StartCoroutine(FillSlider(1.0f, Color.gray));
        int partingNum = 12;
        int repeatNum = 5;
        for (int repeat = 0; repeat < repeatNum; repeat++)
        {
            GameObject[] igaigas = new GameObject[partingNum];
            float Noise = UnityEngine.Random.Range(0f, 1.0f) * 2 * Mathf.PI / partingNum;
            for (int i = 0; i < partingNum; i++)
            {
                igaigas[i] = Instantiate(hari, main.Transforms[1]);
                igaigas[i].AddComponent<IgaIga>().TargetPosition =
                    RadianToVector(2 * Mathf.PI / partingNum * i + Noise);
                igaigas[i].GetComponent<IgaIga>().MontblangoPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
                igaigas[i].GetComponent<IgaIga>().damage = ATK()*5;
                igaigas[i].GetComponent<IgaIga>().speed = 20;
                igaigas[i].GetComponent<IgaIga>().isDestroyAfterCollide = true;
            }
            yield return new WaitForSeconds(0.25f);
        }
    }

    public IEnumerator IgaIgaMode()
    {
        yield return currentFillSliderCor = StartCoroutine(FillSlider(3.0f, Color.green));
        thisImage.sprite = Block;
        yield return new WaitForSeconds(5.0f);
        if(thisImage.sprite != Cute)
            thisImage.sprite = Shape1;
    }
    
    public class IgaIga : Attack
    {
        public Vector2 TargetPosition;
        public Vector2 StayPosition;
        public Vector2 MontblangoPosition;
        public float speed = 20;
        public bool isIgastay;
        private void Awake()
        {
            AwakeAttack();
            isEnemyAttack = true;
        }

        private void Start()
        {
            if (main.montblangoIsBig)
                gameObject.GetComponent<RectTransform>().sizeDelta *= 2;
            gameObject.GetComponent<RectTransform>().anchoredPosition = MontblangoPosition;
            StartCoroutine(Move());
            StartCoroutine(DestroyThis());
        }

        public IEnumerator Move()
        {
            if (!isIgastay)
            {
                while (true)
                {
                    thisRect.anchoredPosition += normalize(TargetPosition) * speed;
                    yield return new WaitForSeconds(0.05f);
                }
            }
            else
            {               
                for (int i = 0; i < vectorAbs(TargetPosition)/speed; i++)
                {
                    thisRect.anchoredPosition += normalize(TargetPosition) * speed;
                    yield return new WaitForSeconds(0.05f);
                }
            }

        }

        public IEnumerator DestroyThis()
        {
            if (!isIgastay)
                yield return new WaitForSeconds(5.0f);
            else
                yield return new WaitUntil(() => !isIgastay || main.GameController.battleMode != GameController.BattleMode.challange);
            Destroy(gameObject);
        }
    }



}
