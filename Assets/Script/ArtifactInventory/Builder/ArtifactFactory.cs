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
        ILevel ilevel = new MockLevel();
        _artifact.ilevel = ilevel;
        //IDをもとにプロトタイプ生成
        var prototype = ArtifactPrototypeRepository.GetPrototype(_artifact.id);
        _artifact.ArtifactName = prototype.Name;

        var timeLevel = new TimeBasedLevel(prototype.maxLevel);
        var func = prototype.GetTransactionInfo(ilevel, _artifact.quality).GetTransactionInfo(ilevel);
        Func<float> time = () => prototype.GetTimeCaltulator.GetRequiredTime(_artifact.quality, ilevel);
        var timeManager = new TimeBasedLevelUp(ilevel, timeLevel, () => func, time);

        _artifact.timeManager = timeManager;

        //エフェクトの生成
        var effect = prototype.effect;
        effect.value = () => prototype.EffectValue(ilevel, _artifact.quality);
        _artifact.mainEffect = effect;

        //オプショナルエフェクトの作成
        IOptionEffectBuilder builder;
        switch (basicInfoSet)
        {
            case BronzeInfoSetting bronze:
                builder = new BronzeOptionBuilder(); break;
            case SilverInfoSetting silver:
                builder = new SilverOptionBuilder(); break;
            case GoldInfoSetting gold:
                builder = new GoldOptionBuilder(); break;
            default:
                builder = new BronzeOptionBuilder(); break;
        }
        _artifact.optEffects = builder.GetEffects();
        return _artifact;
    }
}
