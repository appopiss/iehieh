using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IdleLibrary.Inventory;
using IdleLibrary;
using System;
using System.Runtime;
using static ArtifactBuilderUtility;

//プロトタイプを使って生成してみる
public class ArtifactBuilder
{
    public Artifact BuildArtifact(IBasicInfoSet basicInfoSet)
    {
        var _artifact = new Artifact(-1);
        _artifact = basicInfoSet.GetArtifact(_artifact);
        //IDをもとにプロトタイプ生成
        var prototype = ArtifactPrototypeRepository.GetPrototype(_artifact.id);
        _artifact.ArtifactName = prototype.Name;

        var timeLevel = new TimeBasedLevel(prototype.maxLevel);
        var func = prototype.GetTransactionInfo(_artifact, _artifact.quality).GetTransactionInfo(_artifact);
        Func<float> time = () => prototype.GetTimeCaltulator.GetRequiredTime(_artifact.quality, _artifact);
        var timeManager = new TimeBasedLevelUp(_artifact, timeLevel, () => func, time);

        _artifact.timeManager = timeManager;

        //エフェクトの生成
        var effect = prototype.effect;
        effect.value = () => prototype.EffectValue(_artifact, _artifact.quality);
        _artifact.mainEffect = effect;

        //オプショナルエフェクトの作成
        IOptionEffectBuilder builder;
        switch (basicInfoSet)
        {
            case BronzeInfoSetting bronze:
                builder = new BronzeOptionBuilder(); break;

            default:
                builder = new BronzeOptionBuilder(); break;
        }
        _artifact.optEffects = builder.GetEffects();
        return _artifact;
    }
}
