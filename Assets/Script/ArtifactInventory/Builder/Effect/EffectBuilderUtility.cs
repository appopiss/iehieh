using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using IdleLibrary.Inventory;

public partial class ArtifactBuilderUtility
{
    public static IEffect BuildEffect(int quality, ILevel level, EffectType effectType, IEffectCalculator calculator)
    {
        var prototype = new EffectPrototype();
        var result = prototype.GetEffect(effectType).Clone();
        var value = calculator.Value(effectType);

        if(result is BasicEffect)
        {
            Debug.Log("effect‘ã“ü‚µ‚½‚æ");
            (result as BasicEffect).value = value;
        }

        return result;
    }
}

