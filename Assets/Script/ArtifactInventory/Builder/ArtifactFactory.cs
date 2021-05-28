using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IdleLibrary.Inventory;
using IdleLibrary;
using System;
using static ArtifactBuilderUtility;

//プロトタイプを使って生成してみる
public class ArtifactBuilder
{
    public Artifact BuildArtifact(IBasicInfoSet basicInfoSet)
    {
        var _artifact = new Artifact(-1);
        _artifact = basicInfoSet.GetArtifact(_artifact);
        //IDをもとにプロトタイプ生成
        var prototype = new SlimeBronzeStatue();

        var timeLevel = new TimeBasedLevel(prototype.maxLevel);
        var func = prototype.GetTransactionInfo(_artifact);
        Func<float> time = () => prototype.GetTimeCaltulator.GetRequiredTime(_artifact.quality, _artifact);
        var timeManager = new TimeBasedLevelUp(_artifact, timeLevel, () => func.GetTransactionInfo(_artifact), time);

        _artifact.timeManager = timeManager;

        //エフェクトの生成
        var effect = prototype.effect;
        effect.value = () => prototype.EffectValue(_artifact, _artifact.quality);

        //オプショナルエフェクトの作成
        /*
        var optionCalculator = new OptionalEffectCalculator(_artifact);
        List<IEffect> optionalEffectList = new List<IEffect>();
        optionalEffectList.Add(BuildEffect(_artifact.quality, _artifact, EffectType.HP_add, optionCalculator));
        _artifact.optEffects = optionalEffectList;
        */

        return _artifact;
    }
}
