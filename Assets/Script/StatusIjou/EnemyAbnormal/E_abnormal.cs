using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class E_abnormal : BASE
{

    public double factor;
    public float duration;
    public float currentDuration;
    public Main.Debuff debuff;
    public Main.Buff buff;
    public double abnormalDamage;

    // Use this for initialization
    public void AwakeCor()
    {
        StartBASE();
    }

    // Use this for initialization
    public void StartCor()
    {
        StartCoroutine(CalculateDuration());
        StartCoroutine(Effect());
    }

    public virtual IEnumerator Effect() { yield return null; }
    public IEnumerator CalculateDuration()
    {
        while (true)
        {
            //yield return new WaitUntil(() => duration > 0);
            currentDuration += 1.0f;
            if (currentDuration >= duration) { Destroy(gameObject); }
            yield return new WaitForSeconds(1.0f);
        }
    }
}
