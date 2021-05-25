using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OptionalEffectCalculator : IEffectCalculator
{
    //必要なパラメータはコンストラクタで受け取る(現状必要なのはレベル)
    private readonly ILevel level;
    public OptionalEffectCalculator(ILevel level)
    {
        this.level = level;
    }
    private double GenerateRandomFactor(long min, long max)
    {
        return UnityEngine.Random.Range(min, max + 1);
    }

    //ここのswitch式を編集する
    public Func<double> Value(EffectType type)
    {
        double aug = Math.Pow(GenerateRandomFactor(level.level, level.level + 1), 2);
        Func<double> result = type switch
        {
            //ここに追加していく
            EffectType.HP_add => () => 10 * aug,
            EffectType.MP_add => () => 5 * aug,

            _ => () => 0
        };

        return result;
    }

}
