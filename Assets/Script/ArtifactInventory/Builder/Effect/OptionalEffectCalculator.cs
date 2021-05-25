using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OptionalEffectCalculator : IEffectCalculator
{
    //�K�v�ȃp�����[�^�̓R���X�g���N�^�Ŏ󂯎��(����K�v�Ȃ̂̓��x��)
    private readonly ILevel level;
    public OptionalEffectCalculator(ILevel level)
    {
        this.level = level;
    }
    private double GenerateRandomFactor(long min, long max)
    {
        return UnityEngine.Random.Range(min, max + 1);
    }

    //������switch����ҏW����
    public Func<double> Value(EffectType type)
    {
        double aug = Math.Pow(GenerateRandomFactor(level.level, level.level + 1), 2);
        Func<double> result = type switch
        {
            //�����ɒǉ����Ă���
            EffectType.HP_add => () => 10 * aug,
            EffectType.MP_add => () => 5 * aug,

            _ => () => 0
        };

        return result;
    }

}
