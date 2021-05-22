using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using IdleLibrary.Inventory;

public partial class ArtifactBuilderUtility
{
    public static IEffect BuildEffect(int quality, ILevel level, EffectType effectType)
    {
        var qualityFactor = quality * 0.1;
        var prototype = new EffectPrototype();
        var result = prototype.GetEffect(effectType).Clone();

        //BasicEffect‚ÌŽ®‚ð‘ã“ü‚µ‚Ü‚·
        Func<double> effectCalculation = effectType switch
        {
            EffectType.HP_add => () => 20 * level.level * qualityFactor,
            EffectType.MP_add => () => 10 * level.level * qualityFactor,
            EffectType.ATK_add => () => level.level * qualityFactor,
            EffectType.DEF_add => () => level.level * qualityFactor,
            EffectType.MATK_add => () => level.level * qualityFactor,
            EffectType.MDEF_add => () => level.level * qualityFactor,
            EffectType.HP_mul => () => 10 * level.level * qualityFactor,
            EffectType.MP_mul => () => 10 * level.level * qualityFactor,
            EffectType.ATK_mul => () => 5 * level.level * qualityFactor,
            EffectType.DEF_mul => () => 5 * level.level * qualityFactor,
            EffectType.MDEF_mul => () => 5 * level.level * qualityFactor,

            _ => () => 0
        };

        if(result is BasicEffect)
        {
            (result as BasicEffect).value = effectCalculation;
        }

        return result;
    }
}

