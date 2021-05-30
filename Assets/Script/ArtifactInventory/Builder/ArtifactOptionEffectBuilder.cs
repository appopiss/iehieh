using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IdleLibrary;
using IdleLibrary.Inventory;
using System;

public interface IOptionEffectBuilder
{
    List<IEffect> GetEffects();
}


public class BronzeOptionBuilder : IOptionEffectBuilder
{
    //出てくるエフェクトの一覧
    private List<IEffect> CanGetEffects = new List<IEffect>()
    {
        new OptionBasicEffect(EffectType.HP_add, "HP", Calway.add).SetMaxLevel(10).SetFactor(10).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.MP_add, "MP", Calway.add).SetMaxLevel(10).SetFactor(5).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.ATK_add, "ATK", Calway.add).SetMaxLevel(10).SetFactor(1).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.MATK_add, "MATK", Calway.add).SetMaxLevel(10).SetFactor(1).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.DEF_add, "DEF", Calway.add).SetMaxLevel(10).SetFactor(1).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.MDEF_add, "MDEF", Calway.add).SetMaxLevel(10).SetFactor(1).SetAug(x => Math.Pow(x,2)),

        new OptionBasicEffect(EffectType.HP_mul, "HP", Calway.mul).SetMaxLevel(5).SetFactor(10).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.MP_mul, "MP", Calway.mul).SetMaxLevel(5).SetFactor(5).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.ATK_mul, "ATK", Calway.mul).SetMaxLevel(5).SetFactor(1).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.MATK_mul, "MATK", Calway.mul).SetMaxLevel(5).SetFactor(1).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.DEF_mul, "DEF", Calway.mul).SetMaxLevel(5).SetFactor(1).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.MDEF_mul, "MDEF", Calway.mul).SetMaxLevel(5).SetFactor(1).SetAug(x => Math.Pow(x,2)),
    };
    public List<IEffect> GetEffects()
    {
        var effects = new List<IEffect>();
        //70%の確率でリターン
        var rand = UnityEngine.Random.Range(0, 10000);
        if (rand <= 7000) return new List<IEffect> { new NullEffect()};
        //Effectを適当に取り出す
        var result = CanGetEffects[UnityEngine.Random.Range(0, CanGetEffects.Count)].Clone();
        if(result is OptionBasicEffect)
        {
            var basicEffect = result as OptionBasicEffect;
            //初期値の代入
            basicEffect.UpdateRandomValue();
            effects.Add(basicEffect);
        }
        else
        {
            effects.Add(result);
        }
        return effects;
    }
}

public class SilverOptionBuilder : IOptionEffectBuilder
{
    //出てくるエフェクトの一覧
    private List<IEffect> CanGetEffects = new List<IEffect>()
    {
        new OptionBasicEffect(EffectType.HP_add, "HP", Calway.add).SetMaxLevel(10).SetFactor(10).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.MP_add, "MP", Calway.add).SetMaxLevel(10).SetFactor(5).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.ATK_add, "ATK", Calway.add).SetMaxLevel(10).SetFactor(1).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.MATK_add, "MATK", Calway.add).SetMaxLevel(10).SetFactor(1).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.DEF_add, "DEF", Calway.add).SetMaxLevel(10).SetFactor(1).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.MDEF_add, "MDEF", Calway.add).SetMaxLevel(10).SetFactor(1).SetAug(x => Math.Pow(x,2)),

        new OptionBasicEffect(EffectType.HP_mul, "HP", Calway.mul).SetMaxLevel(5).SetFactor(10).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.MP_mul, "MP", Calway.mul).SetMaxLevel(5).SetFactor(5).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.ATK_mul, "ATK", Calway.mul).SetMaxLevel(5).SetFactor(1).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.MATK_mul, "MATK", Calway.mul).SetMaxLevel(5).SetFactor(1).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.DEF_mul, "DEF", Calway.mul).SetMaxLevel(5).SetFactor(1).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.MDEF_mul, "MDEF", Calway.mul).SetMaxLevel(5).SetFactor(1).SetAug(x => Math.Pow(x,2)),

        new OptionBasicEffect(EffectType.SPD,"SPD", Calway.add).SetMaxLevel(2).SetFactor(1).SetAug(x => x),
        new OptionBasicEffect(EffectType.GoldGain_Extra,"Extra Gold Gain", Calway.add).SetMaxLevel(10).SetFactor(1).SetAug(x => x),
        new OptionBasicEffect(EffectType.Resource,"Resource", Calway.mul).SetMaxLevel(2).SetFactor(5).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.ATKPro,"ATK Proportion", Calway.mul).SetMaxLevel(2).SetFactor(50).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.DEFPro,"DEF Proportion", Calway.mul).SetMaxLevel(2).SetFactor(50).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.MATKPro,"MATK Proportion", Calway.mul).SetMaxLevel(2).SetFactor(50).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.MDEFPro,"MDEF Proportion", Calway.mul).SetMaxLevel(2).SetFactor(50).SetAug(x => Math.Pow(x,2)),

    };
    public List<IEffect> GetEffects()
    {
        //70%の確率でリターン
        var rand = UnityEngine.Random.Range(0, 10000);
        IEffect GetEffectRandomly()
        {
            //Effectを適当に取り出す
            var result = CanGetEffects[UnityEngine.Random.Range(0, CanGetEffects.Count)].Clone();
            if (result is OptionBasicEffect)
            {
                var basicEffect = result as OptionBasicEffect;
                //初期値の代入
                basicEffect.UpdateRandomValue();
                return basicEffect;
            }
            return result;
        }
        if (rand <= 7000)
        {
            return new List<IEffect>() { GetEffectRandomly() };
        }
        else
        {
            return new List<IEffect>() { GetEffectRandomly() , GetEffectRandomly()};
        }
        
    }
}

public class GoldOptionBuilder : IOptionEffectBuilder
{
    //出てくるエフェクトの一覧
    private List<IEffect> CanGetEffects = new List<IEffect>()
    {
        new OptionBasicEffect(EffectType.HP_add, "HP", Calway.add).SetMaxLevel(10).SetFactor(10).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.MP_add, "MP", Calway.add).SetMaxLevel(10).SetFactor(5).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.ATK_add, "ATK", Calway.add).SetMaxLevel(10).SetFactor(1).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.MATK_add, "MATK", Calway.add).SetMaxLevel(10).SetFactor(1).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.DEF_add, "DEF", Calway.add).SetMaxLevel(10).SetFactor(1).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.MDEF_add, "MDEF", Calway.add).SetMaxLevel(10).SetFactor(1).SetAug(x => Math.Pow(x,2)),

        new OptionBasicEffect(EffectType.HP_mul, "HP", Calway.mul).SetMaxLevel(5).SetFactor(10).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.MP_mul, "MP", Calway.mul).SetMaxLevel(5).SetFactor(5).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.ATK_mul, "ATK", Calway.mul).SetMaxLevel(5).SetFactor(1).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.MATK_mul, "MATK", Calway.mul).SetMaxLevel(5).SetFactor(1).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.DEF_mul, "DEF", Calway.mul).SetMaxLevel(5).SetFactor(1).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.MDEF_mul, "MDEF", Calway.mul).SetMaxLevel(5).SetFactor(1).SetAug(x => Math.Pow(x,2)),

        new OptionBasicEffect(EffectType.SPD,"SPD", Calway.add).SetMaxLevel(2).SetFactor(1).SetAug(x => x),
        new OptionBasicEffect(EffectType.GoldGain_Extra,"Extra Gold Gain", Calway.add).SetMaxLevel(10).SetFactor(1).SetAug(x => x),
        new OptionBasicEffect(EffectType.Resource,"Resource", Calway.mul).SetMaxLevel(2).SetFactor(5).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.ATKPro,"ATK Proportion", Calway.mul).SetMaxLevel(2).SetFactor(50).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.DEFPro,"DEF Proportion", Calway.mul).SetMaxLevel(2).SetFactor(50).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.MATKPro,"MATK Proportion", Calway.mul).SetMaxLevel(2).SetFactor(50).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.MDEFPro,"MDEF Proportion", Calway.mul).SetMaxLevel(2).SetFactor(50).SetAug(x => Math.Pow(x,2)),

        /*
        new OptionBasicEffect(EffectType.FireResistance,"Fire Registance", Calway.mul).SetMaxLevel(2).SetFactor(3).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.LightResistance,"Light Resistance", Calway.mul).SetMaxLevel(2).SetFactor(3).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.DarkResistance,"Dark Resistance", Calway.mul).SetMaxLevel(2).SetFactor(3).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.IceResistance,"Ice Resistance", Calway.mul).SetMaxLevel(2).SetFactor(3).SetAug(x => Math.Pow(x,2)),
        */
        new OptionBasicEffect(EffectType.DebuffResistance,"Debuff Registance", Calway.mul).SetMaxLevel(2).SetFactor(3).SetAug(x => Math.Pow(x,2)),
        new OptionBasicEffect(EffectType.ArtifactPower,"Artifact Power", Calway.add).SetMaxLevel(10).SetFactor(10).SetAug(x => Math.Pow(x,2)),

    };
    public List<IEffect> GetEffects()
    {
        //70%の確率でリターン
        var rand = UnityEngine.Random.Range(0, 10000);
        IEffect GetEffectRandomly()
        {
            //Effectを適当に取り出す
            var result = CanGetEffects[UnityEngine.Random.Range(0, CanGetEffects.Count)].Clone();
            if (result is OptionBasicEffect)
            {
                var basicEffect = result as OptionBasicEffect;
                //初期値の代入
                basicEffect.UpdateRandomValue();
                return basicEffect;
            }
            return result;
        }
        if (rand <= 3000)
        {
            return new List<IEffect>() { GetEffectRandomly() };
        }
        else if(rand <= 8000)
        {
            return new List<IEffect>() { GetEffectRandomly(), GetEffectRandomly() };
        }
        else
        {
            return new List<IEffect>() { GetEffectRandomly(), GetEffectRandomly(), GetEffectRandomly() };
        }

    }
}
