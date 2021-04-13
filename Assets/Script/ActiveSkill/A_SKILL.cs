using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class A_SKILL : BASE , IPointerDownHandler {

    Image coolTimeImage;
    public ALLY.Job job;
    public float InitialCoolTime;
    public virtual float CoolTime { get; set; }
    public float cooltimeFactor;
    public float I_coolTime() {
        return InitialCoolTime + main.MissionMileStone.CoolTimeBonus() - cooltimeFactor;
    }
    Plain_PopText popText;
    public void AwakeSkill() {
        StartBASE();
        coolTimeImage = gameObject.transform.GetChild(1).GetComponent<Image>();
        popText = gameObject.AddComponent<Plain_PopText>();
    }

    public void StartSkill()
    {
    }
    private void OnEnable()
    {
        StartCoroutine(CalculateCoolTime());
        StartCoroutine(AutoCast());
    }

    public void UpdateSkill()
    {
        //クールタイムのイメージを変更する．
        UpdateCoolTime();
        if (I_coolTime() - CoolTime > 0)
            popText.text = "Unavailable ( " + DoubleTimeToDate(I_coolTime() - CoolTime) + " )";
        else
            popText.text = "<color=green>Available";
    }

    void UpdateCoolTime()
    {
        if (I_coolTime() == 0 || CoolTime < 0) { return; }
        coolTimeImage.fillAmount = (I_coolTime() - CoolTime) / I_coolTime();
    }

    public virtual bool Condition()
    {
        return main.ally.job == job;  
    }

    public bool AttackCondition()
    {
        return  main.ally.currentHp > 0 && !main.DeathPanel.isPanel;
    }

    public virtual IEnumerator DoSkill() { yield return null; }
    public IEnumerator CalculateCoolTime()
    {
        while (true)
        {
            yield return new WaitUntil(() => TitleCtrl.isLoaded);
            if (main.S.AutoActiveSkill && main.toggles[11].isOn && Condition() && CoolTime >= I_coolTime())
            {
                CoolTime = 0;
                StartCoroutine(DoSkill());
            }

            yield return new WaitUntil(() => { return Condition() && CoolTime < I_coolTime(); });
            CoolTime += 1f;
            yield return new WaitForSeconds(1f);
        }
    }
    public IEnumerator AutoCast()
    {
        while (true)
        {
            yield return new WaitUntil(() => main.S.AutoActiveSkill && main.toggles[11].isOn && Condition() && CoolTime >= I_coolTime());
                CoolTime = 0;
                StartCoroutine(DoSkill());
            yield return new WaitForSeconds(1f);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    { 
        if (CoolTime < I_coolTime())
            return;
        
        CoolTime = 0;
        StartCoroutine(DoSkill());
    }
}
