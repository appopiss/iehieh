using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IdleLibrary.Inventory;
using IdleLibrary;
using System;

//Inventoryのアイテムを受け取り、エフェクトを計算する！
//一回inventoryでやるが、後々抽象化したい
public class EffectCalculator : IText
{
    private IdleLibrary.Inventory.Inventory inventory;
    public EffectCalculator(IdleLibrary.Inventory.Inventory inventory)
    {
        this.inventory = inventory;
    }
    private Dictionary<Enum, double> calculateDic = new Dictionary<Enum, double>();
    //ArtifactPrototype protoEffects = new ArtifactPrototype();
    void _UpdateValue(params IEffect[] Effects)
    {
        foreach (var effects in Effects)
        {
            //IStatsBreakdownなら
            if (effects is IStatsBreakdown)
            {
                Debug.Log(effects.effectType == null);
                var stats = effects as IStatsBreakdown;
                if (calculateDic.ContainsKey(effects.effectType))
                {
                    calculateDic[effects.effectType] += stats.Value();
                }
                else
                {
                    calculateDic.Add(effects.effectType, stats.Value());
                }
            }
        }
    }
    public void UpdateValue()
    {
        calculateDic.Clear();
        foreach (var item in inventory.GetItems())
        {
            if(item is Artifact)
            {
                var artifact = item as Artifact;
                _UpdateValue(artifact.mainEffect);
                _UpdateValue(artifact.optEffects.ToArray());
            }
        }

        //テキストの更新 IEffectのインスタンスを取ってこれないので断念...プロトタイプありきの実装だった
        string text = "";
        /*
        foreach (var effects in calculateDic)
        {  
           if(calculateDic.ContainsKey(effects.Key))
               text += UsefulMethod.optStr + stats.StatsBreakdownText(calculateDic[effects.Key]) + "\n";
        }
        */
        _text = text;
    }
    private string _text;
    public string Text() => _text;
}
