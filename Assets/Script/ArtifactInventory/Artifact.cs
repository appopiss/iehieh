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
        Debug.Log($"Effect {(mainEffect as BasicEffect).value == null}\n time{timeManager.requiredTimeSec == null}\n timeManager {timeManager.transactionsInfo().text == null}");
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
        text += optStr + "\n[Optional Effect]";
        optEffects.ForEach((x) => text += optStr + x.Text() + "\n");
        return text;
    }

    [OdinSerialize] public IEffect mainEffect;
    [OdinSerialize] public List<IEffect> optEffects = new List<IEffect>();
    [OdinSerialize] public TimeBasedLevelUp timeManager;
    public int quality;
    public double antimagicPower;

}