using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IdleLibrary.Inventory;
using IdleLibrary;
using System;
using static ArtifactBuilderUtility;

public class BuildBronzeArtifact
{
    public Artifact BuildArtifact(IBasicInfoSet basicInfoSet)
    {
        var _artifact = new Artifact(-1);
        _artifact = basicInfoSet.GetArtifact(_artifact);

        //TimeBased�̃��x���ݒ� (�ǂ�����Đݒ肷�邩�H)
        var timeLevel = new TimeBasedLevel();
        timeLevel.level = 1;
        timeLevel.maxLevelCap = 5;

        //�R�X�g�̐ݒ�@��{��Mysterious Stone���g���B
        var cost = ChooseMaterialCost(_artifact.quality, ArtifactMaterial.ID.MysteriousStone);
        var cost2 = ChooseMaterialCost(_artifact.quality, ArtifactMaterial.ID.BlessingPowder);
        var artifactTransaction = new ArtifactMaterialTransaction(ArtifactMaterial.ID.MysteriousStone,
            new LinearCost(cost.initialValue, cost.steep, timeLevel));
        var artifactTransaction2 = new ArtifactMaterialMultipleTransaction
            (artifactTransaction, new ArtifactMaterialTransaction(ArtifactMaterial.ID.BlessingPowder, 
            new LinearCost(cost2.initialValue, cost2.steep, timeLevel)));
        Func<(ITransaction transaction, IText text)> func = () =>
        {
            if (timeLevel.level <= 3)
            {
                return (artifactTransaction, artifactTransaction);
            }
            else
            {
                return (artifactTransaction2, artifactTransaction2);
            }
        };
        var time = ChooseTimeToLevelUp(_artifact.quality, _artifact);
        var timeManager = new TimeBasedLevelUp(_artifact, timeLevel, func, time);
        _artifact.timeManager = timeManager;
        
        //�G�t�F�N�g�̐���
        //�v�Z���@�̐���
        var mainCalculator = new MainEffectCalculator(_artifact, _artifact.quality);

        List<IEffect> effectList = new List<IEffect>();
        effectList.Add(BuildEffect(_artifact.quality, _artifact, EffectType.HP_add, mainCalculator));
        effectList.Add(BuildEffect(_artifact.quality, _artifact, EffectType.MP_add, mainCalculator));
        _artifact.effects = effectList;

        //�I�v�V���i���G�t�F�N�g�̍쐬
        var optionCalculator = new OptionalEffectCalculator(_artifact);
        List<IEffect> optionalEffectList = new List<IEffect>();
        optionalEffectList.Add(BuildEffect(_artifact.quality, _artifact, EffectType.HP_add, optionCalculator));
        _artifact.optEffects = optionalEffectList;

        return _artifact;
    }
}
