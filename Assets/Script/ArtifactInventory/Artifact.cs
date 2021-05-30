using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.Serialization;
using Cysharp.Threading.Tasks;
using System;
using System.Linq;
using IdleLibrary.Inventory;
using IdleLibrary;
using static UsefulMethod;

[System.Serializable]
public class Artifact : ITEM, ILevel
{
    public long level { get; set; }
    public Artifact(int id) : base(id)
    {

    }
    public override string Text()
    {
        return $"----ARTIFACT----\n- " +
            $"ID : {id}" +
            $"\n\n- Level : {level} " +
            $"\n- Max Level : {timeManager.timeLevel.level} " +
            $"\n- Quality : {quality} " +
            $"\n- Anti-magic Power : {tDigit(antimagicPower)}" +
            $"\n- Time to Level Up : {(timeManager.currentTimesec / timeManager.requiredTimeSec()).ToString("F2")}" +
            $"\n- [Materials to Level Up]\n" + timeManager.transactionsInfo().text.Text() + 
            $"\n" + EffectText();
    }
    public override ITEM CreateNullItem()
    {
        return new Artifact(-1);
    }
    string EffectText()
    {
        string text = "[Effect]\n";
        text += optStr + mainEffect.Text() + "\n";
        if (optEffects == null) return text;
        text += optStr + "\n[Optional Effect]\n";
        optEffects.ForEach((x) => text += optStr + x.Text() + "\n");
        return text;
    }

    [OdinSerialize] public IEffect mainEffect;
    [OdinSerialize] public List<IEffect> optEffects = new List<IEffect>();
    [OdinSerialize] public TimeBasedLevelUp timeManager;
    public int quality;
    public double antimagicPower;

}