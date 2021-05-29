using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IdleLibrary.Inventory;
using IdleLibrary;
using System;

//Inventory�̃A�C�e�����󂯎��A�G�t�F�N�g���v�Z����I
//���inventory�ł�邪�A��X���ۉ�������
public class EffectCalculator : IText
{
    public double GetEffectValue(EffectType type)
    {
        if (!calculateDic.ContainsKey(type))
        {
            if(ArtifactPrototypeRepository.GetEffect(type) is BasicEffect)
            {
                var basicEffect = ArtifactPrototypeRepository.GetEffect(type) as BasicEffect;
                var value = basicEffect.calway == Calway.add ? 0 : 1.0;
                return value;
            }
            else
            {
                return 0;
            }
        }

        return calculateDic[type];
    }
    private IdleLibrary.Inventory.Inventory inventory;
    public EffectCalculator(IdleLibrary.Inventory.Inventory inventory)
    {
        this.inventory = inventory;
    }
    private Dictionary<Enum, double> calculateDic = new Dictionary<Enum, double>();
    //ArtifactPrototype protoEffects = new ArtifactPrototype();
    void _UpdateValue(params IEffect[] Effects)
    {
        foreach (var effects in Effects)
        {
            //IStatsBreakdown�Ȃ�
            if (effects is IStatsBreakdown)
            {
                Debug.Log(effects.effectType == null);
                var stats = effects as IStatsBreakdown;
                if (calculateDic.ContainsKey(effects.effectType))
                {
                    calculateDic[effects.effectType] += stats.Value();
                }
                else
                {
                    calculateDic.Add(effects.effectType, stats.Value());
                }
            }
        }
    }
    public void UpdateValue()
    {
        calculateDic.Clear();
        foreach (var item in inventory.GetItems())
        {
            if(item is Artifact)
            {
                var artifact = item as Artifact;
                _UpdateValue(artifact.mainEffect);
                _UpdateValue(artifact.optEffects.ToArray());
            }
        }

        //�e�L�X�g�̍X�V IEffect�̃C���X�^���X������Ă���Ȃ��̂Œf�O...�v���g�^�C�v���肫�̎���������
        string text = "";
        foreach (var effects in ArtifactPrototypeRepository.GetEffects())
        {
            if (effects is IStatsBreakdown)
            {
                var stats = effects as IStatsBreakdown;
                if (calculateDic.ContainsKey(effects.effectType))
                    text += UsefulMethod.optStr + stats.StatsBreakdownText(calculateDic[effects.effectType]) + "\n";
            }
        }
            _text = text;
    }
    private string _text;
    public string Text() => _text;
}
