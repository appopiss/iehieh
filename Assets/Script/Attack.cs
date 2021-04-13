using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Attack : BASE {

    public double damage;
    public double mDamage;
    public double critDamage;
    public double abnormalDamage;
    [NonSerialized]
    public bool isDestroyAfterCollide;
    public bool isEnemyAttack;
    public SKILL.DamageKind damageKind;//0物理　1魔法　2クリティ //
    public Main.Debuff thisDebuff;
    public Action CollisionEvent = () => { };
    public RectTransform thisRect;
    public RectTransform targetRect;

    public void AwakeAttack()
    {
        StartBASE();
        thisRect = gameObject.GetComponent<RectTransform>();
        targetRect = main.ally1.GetComponent<RectTransform>();
    }
}
