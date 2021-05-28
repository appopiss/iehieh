using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IdleLibrary.Inventory;
using IdleLibrary;
using System;
using static ArtifactBuilderUtility;

//�v���g�^�C�v���g���Đ������Ă݂�
public class ArtifactBuilder
{
    public Artifact BuildArtifact(IBasicInfoSet basicInfoSet)
    {
        var _artifact = new Artifact(-1);
        _artifact = basicInfoSet.GetArtifact(_artifact);
        //ID�����ƂɃv���g�^�C�v����
        var prototype = new SlimeBronzeStatue();

        var timeLevel = new TimeBasedLevel(prototype.maxLevel);
        var func = prototype.GetTransactionInfo(_artifact);
        Func<float> time = () => prototype.GetTimeCaltulator.GetRequiredTime(_artifact.quality, _artifact);
        var timeManager = new TimeBasedLevelUp(_artifact, timeLevel, () => func.GetTransactionInfo(_artifact), time);

        _artifact.timeManager = timeManager;

        //�G�t�F�N�g�̐���
        var effect = prototype.effect;
        effect.value = () => prototype.EffectValue(_artifact, _artifact.quality);

        //�I�v�V���i���G�t�F�N�g�̍쐬
        /*
        var optionCalculator = new OptionalEffectCalculator(_artifact);
        List<IEffect> optionalEffectList = new List<IEffect>();
        optionalEffectList.Add(BuildEffect(_artifact.quality, _artifact, EffectType.HP_add, optionCalculator));
        _artifact.optEffects = optionalEffectList;
        */

        return _artifact;
    }
}
