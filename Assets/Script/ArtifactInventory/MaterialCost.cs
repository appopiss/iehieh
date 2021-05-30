using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IdleLibrary;
using Sirenix.Serialization;
using System;

public class MaterialCost : ICost
{
    [OdinSerialize] readonly Func<ILevel, int, double> func;
    [OdinSerialize] readonly ILevel level;
    [OdinSerialize] readonly int quality;
    //private CalDL cost { get; }
    public double Cost => func(level, quality);
    public MaterialCost(Func<ILevel, int, double> func, ILevel level, int quality)
    {
        this.func = func;
        this.level = level;
        this.quality = quality;
    }
}
