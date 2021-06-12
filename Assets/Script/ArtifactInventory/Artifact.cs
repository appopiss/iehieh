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
public class Artifact : ITEM
{
    [OdinSerialize] public ILevel ilevel;
    public long level { get => ilevel.level; set => ilevel.level = value; }
    [OdinSerialize] public string ArtifactName { get; set; }
    public Artifact(int id) : base(id)
    {

    }
    long GetLevel(IEffect effect)
    {
        if(effect is ILevel)
        {
            var level = effect as ILevel;
            return level.level;
        }
        else
        {
            return 1;
        }
    }
    public override string Text()
    {
        string tempStr = optStr;
        tempStr += $"{ArtifactName} < <color=green>Lv {level}</color> > <color=orange>Quality {quality}</color>\n";
        tempStr += $"<color=yellow>";
        optEffects.ForEach((x) => tempStr += optStr + "[ " + x.EffectText + " Lv " + GetLevel(x) + " ] ");
        tempStr += "</color>\n\n";
        tempStr += $"Max Level : Lv {timeManager.timeLevel.level}\n";
        tempStr += "Time to Level Up : " + DoubleTimeToDate(timeManager.requiredTimeSec() - timeManager.currentTimesec) + "\n";
        tempStr += $"Anti-magic Power : {tDigit(antimagicPower)}";
        tempStr += "\n\n";
        tempStr += EffectText();
        tempStr += $"\n<u>Materials to Increase Max Level</u>\n" + timeManager.transactionsInfo().text.Text();
        return tempStr;
    }
    public override ITEM CreateNullItem()
    {
        return new Artifact(-1);
    }
    string EffectText()
    {
        string text = "<u>Effect</u>\n";
        text += optStr + "- " + mainEffect.Text() + "\n";
        if (optEffects == null||optEffects[0] is NullEffect) return text;
        text += optStr + "\n<u>Optional Effect</u>\n";
        optEffects.ForEach((x) => text += optStr + "- " + x.Text() + "\n");
        return text;
    }

    [OdinSerialize] public IEffect mainEffect;
    [OdinSerialize] public List<IEffect> optEffects = new List<IEffect>();
    [OdinSerialize] public TimeBasedLevelUp timeManager;
    public int quality;
    public double antimagicPower;

}