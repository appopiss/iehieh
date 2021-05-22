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
    private IdleLibrary.Inventory.Inventory inventory;
    public EffectCalculator(IdleLibrary.Inventory.Inventory inventory)
    {
        this.inventory = inventory;
    }
    private Dictionary<Enum, double> calculateDic = new Dictionary<Enum, double>();
    public void UpdateValue(IdleLibrary.Inventory.Inventory inventory)
    {
        calculateDic.Clear();
        foreach (var item in inventory.GetItems())
        {
            if(item is Artifact)
            {
                var artifact = item as Artifact;
                foreach (var effects in artifact.effects)
                {
                    //IStatsBreakdown�Ȃ�
                    if(effects is IStatsBreakdown)
                    {
                        var stats = effects as IStatsBreakdown;
                        calculateDic[effects.effectType] += stats.Value();
                    }
                }
            }
        }

        //�e�L�X�g�̍X�V
        string text = "";
        foreach (var item in inventory.GetItems())
        {
            if (item is Artifact)
            {
                var artifact = item as Artifact;
                foreach (var effects in artifact.effects)
                {
                    //IStatsBreakdown�Ȃ�
                    if (effects is IStatsBreakdown)
                    {
                        var stats = effects as IStatsBreakdown;
                        text += stats.StatsBreakdownText(calculateDic[effects.effectType]) + "\n";
                    }
                }
            }
        }
    }
    private string _text;
    public string Text() => _text;
}
