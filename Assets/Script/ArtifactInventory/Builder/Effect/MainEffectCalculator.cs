using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IEffectCalculator
{
    Func<double> Value(EffectType type);
}
public class MainEffectCalculator : IEffectCalculator
{
    //�K�v�ȃp�����[�^�̓R���X�g���N�^�Ŏ󂯎��(����K�v�Ȃ̂̓��x���ƃN�I���e�B)
    private readonly int quality;
    private readonly ILevel level;
    public MainEffectCalculator(ILevel level, int quality)
    {
        this.quality = quality;
        this.level = level;
    }

    //������switch����ҏW����
    public Func<double> Value(EffectType type)
    {
        double q_factor = Math.Pow(level.level, 1 + quality / 100);
        Func<double> result = type switch
        {
            //�����ɒǉ�
            EffectType.HP_add => () => 10 * level.level * q_factor,
            EffectType.MP_add => () => 5 * level.level * q_factor,

            _ => () => 0
        };

        return result;
    }
}
