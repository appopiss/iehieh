using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.Serialization;
using Cysharp.Threading.Tasks;
using System;
using System.Linq;
using IdleLibrary.Inventory;

[System.Serializable]
public class Artifact : ITEM, ILevel
{
    public long level { get => _level; set => _level = value; }
    [OdinSerialize] long _level;
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
            $"\n- Anti-Magid Power : {antimagicPower}" +
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
        string text = "[Effect]\n\n";
        effects.ForEach((x) => text += x.Text() + "\n");
        return text;
    }

    [OdinSerialize] public List<IEffect> effects = new List<IEffect>();
    [OdinSerialize] public TimeBasedLevelUp timeManager;
    public int quality;
    public double antimagicPower;
}