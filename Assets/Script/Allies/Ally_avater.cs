using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UsefulMethod;
using static ALLY.Condition;
using System;
using TMPro;

public class Ally_avater : BASE,IDamagable
{
    public double hp;
    public double currentHp;
    public double atk;
    public double def;
    public double mAtk;
    public double mDef;
    public double speed;
    public ENEMY targetEnemy;
    public ALLY.Condition condition;
    public RectTransform thisRect;

    double IDamagable.currentHp { get => currentHp; set => currentHp = value; }
    ALLY.Condition IDamagable.condition { get => condition; set => condition = value; }
    public double currentExp { get; set; }

    private void Awake()
    {
        StartBASE();
        thisRect = gameObject.GetComponent<RectTransform>();
    }

    private void Start()
    {
        StartCoroutine(Move());
        //StartCoroutine(Attacking());
    }

    private void Update()
    {
        if (condition == BattleMode)
        {
            if (!canAttack())
            {
                condition = MoveMode;
            }
        }
    }

    private void OnDestroy()
    {
        foreach (GameObject game in GameObject.FindGameObjectsWithTag("decoyAttack"))
        {
            Destroy(game);
        }
    }

    public ENEMY SearchEnemy()
    {
        GameObject[] taggedEnemy = GameObject.FindGameObjectsWithTag("enemy");
        if (taggedEnemy == null || taggedEnemy.Length == 0) { return null; }
        float minDistance = 9999999;
        float tempDistance = 0;
        int tempIndex = 0;
        for (int i = 0; i < taggedEnemy.Length; i++)
        {
            tempDistance = vectorAbs(gameObject.GetComponent<RectTransform>().anchoredPosition - taggedEnemy[i].GetComponent<RectTransform>().anchoredPosition);
            if (tempDistance < minDistance) {
                minDistance = tempDistance;
                if(main.ally1.GetComponent<ALLY>().targetEnemy == taggedEnemy[i].GetComponent<ENEMY>()) { continue; }
                tempIndex = i;
            }
        }
        return taggedEnemy[tempIndex].GetComponent<ENEMY>();
    }

    //SPD2000で0.5倍
    public float moveSpeedFactor() { return Mathf.Min(((float)speed + 2000f) / 2000f, 10f); }

    public bool canAttack()
    {
        GameObject[] currentEnemies;
        currentEnemies = GameObject.FindGameObjectsWithTag("enemy");
        List<GameObject> attackableEnemes = new List<GameObject>();
        foreach (GameObject game in currentEnemies)
        {
            if (vectorAbs(gameObject.GetComponent<RectTransform>().anchoredPosition - game.GetComponent<RectTransform>().anchoredPosition)
                - game.GetComponent<ENEMY>().buffer <= 50)
            {
                attackableEnemes.Add(game);
            }
        }
        if (attackableEnemes.Count == 0) { return false; }
        else { return true; }
    }

    public IEnumerator Move()
    {
        while (true)
        {
            if (targetEnemy == null)
            {
                targetEnemy = SearchEnemy();
                yield return new WaitForSeconds(0.05f);
            }
            else
            {
                switch (condition)
                {
                    case MoveMode:
                        double buffer = targetEnemy.buffer;
                        Vector2 moveDistance = targetEnemy.GetComponent<RectTransform>().anchoredPosition - thisRect.anchoredPosition;
                        if (vectorAbs(moveDistance) - buffer <= 50)
                        {
                            condition = BattleMode;
                        }

                        //倍速・三倍速等遣る場合にはifで分岐させましょう!!!
                        thisRect.anchoredPosition += normalize(moveDistance) * 3f * moveSpeedFactor();
                        yield return new WaitForSeconds(0.017f);
                        break;
                    case BattleMode:
                        yield return new WaitForSeconds(0.017f);
                        break;
                }
            }
        }
    }

    public virtual double calculatedDamage
        (double damage = 0, double mDamage = 0, double critDamage = 0) { return Math.Max(Math.Max(damage - def, 0) + Math.Max(mDamage - mDef, 0) + critDamage, 1); }

    //敵からの攻撃を受けた時．
    public void OnTriggerEnter2D(Collider2D collision)
    {
        SKILL.DamageKind damageKind;
        if (collision.gameObject.HasComponent<Attack>())
        {
            damageKind = collision.GetComponent<Attack>().damageKind;
        }
        else
        {
            damageKind = SKILL.DamageKind.nothing;
        }
        double damage;
        double mDamage;
        double critDamage;

        if (collision.gameObject.tag == "enemyEffect" && collision.GetComponent<Attack>() != null)//&&collision.gameObject.tag != "effect")
        {
            damage = collision.GetComponent<Attack>().damage;
            mDamage = collision.GetComponent<Attack>().mDamage;
            critDamage = collision.GetComponent<Attack>().critDamage;
        }
        else
        {
            return;
        }
        if (collision.GetComponent<Attack>().isDestroyAfterCollide) { Destroy(collision.gameObject); }
        currentHp -= calculatedDamage(damage, mDamage, critDamage);

        //死んだときの処理
        if (currentHp <= 0)
        {
            currentHp = 0;
            Destroy(gameObject);
        }
        //InstantiateDamage(calculatedDamage(damage, mDamage, critDamage), damageKind);
    }

  //  public IEnumerator Attacking()
  //  {
  //      while (true)
  //      {
  //          yield return new WaitUntil(canAttack);
  //          targetEnemy = SearchEnemy();
  //
  //          StartCoroutine(main.InstantiateAnimation(main.animationObject[54], targetEnemy.GetComponent<RectTransform>(), atk* 2.5, 0, SKILL.DamageKind.physical));
  //          yield return new WaitForSeconds(1.0f);
  //      }
  //  }

    public void InstantiateText(string text, Color color)
    {

        GameObject Text;
        Text = Instantiate(main.prefabAry_H[0], gameObject.transform);
        Text.GetComponent<RectTransform>().anchoredPosition = new Vector2(UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-10, 10));
        Text.GetComponentInChildren<TextMeshProUGUI>().text = text;
        Text.GetComponentInChildren<TextMeshProUGUI>().color = color;
        //StartCoroutine(destroyObject(Text));
    }
}
