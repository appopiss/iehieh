using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;
using System;

public class C_ENEMY : ENEMY
{
    [NonSerialized]
    public Slider AttackSlider;
    [NonSerialized]
    public Image Fill;
    public float DropFactor = 0.03f;
    public virtual double DropModifier()
    {
        return 1.0f;
    }
    public virtual float SliderSpeed()
    {
        return 1.0f;
    }

    public float ColdFactor()
    {
        if (isDebuff[(int)Main.Debuff.cold])
            return 1.25f;
        else
            return 1.0f;
    }

    public float FreezeFactor()
    {
        if (isDebuff[(int)Main.Debuff.freeze])
            return 1.5f;
        else
            return 1.0f;
    }
    public void AwakeCEenemy()
    {
        AttackSlider = gameObject.transform.GetChild(1).GetComponent<Slider>();
        Fill = AttackSlider.transform.GetChild(1).GetChild(0).GetComponent<Image>();
        setFalse(AttackSlider.gameObject);
    }

    public IEnumerator FillSlider(float interval,Color color)
    {
        setActive(AttackSlider.gameObject);
        Fill.color = color;
        AttackSlider.value = 0;
        for (int i = 0; i < 50; i++)
        {
            AttackSlider.value += 1.0f / 50f;
            yield return new WaitForSeconds(interval * SliderSpeed() * ColdFactor() * FreezeFactor() / 50);
        }
        setFalse(AttackSlider.gameObject);
    }

    public override void Drop()
    {
        double dropFactor = main.ArtifactFactor.DROP();
        foreach (KeyValuePair<ArtiCtrl.MaterialList, int> material in DropMaterial.GetTable())
        {
            int randomNum = UnityEngine.Random.Range(0, 10000);
            if (randomNum < material.Value * dropFactor * DropModifier())
            {
                main.ArtiCtrl.CurrentMaterial[material.Key] += 1;
                main.DeathPanel.C_materials[material.Key] += 1;
            }
        }
        //確定ドロップ
        if (main.S.isMission384Completed)
            KakuteiDrop();
    }
    public virtual void KakuteiDrop() { }

}
