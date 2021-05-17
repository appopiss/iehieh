using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IdleLibrary.Inventory;
using IdleLibrary;
using System;
using static ArtifactBuilderUtility;

//�A�C�e���쐬�p�r���_�[�C���^�[�t�F�[�X
public interface IArtifactBuilder
{
    Artifact BuildArtifact();
}

public class BuildBronzeArtifact : IArtifactBuilder
{
    public Artifact BuildArtifact()
    {
        var _artifact = new Artifact(-1);
        _artifact.level = 1;

        //�u�����Y�ŏo�Ă���id���w�肵�܂��B�Ⴆ��0~5�Ȃ�
        var id = UnityEngine.Random.Range(0, 5);
        _artifact.id = id;

        //�Ⴆ��0~40�܂ł����o�Ă��Ȃ��A�Ȃ�
        var quality = UnityEngine.Random.Range(0, 40);
        _artifact.quality = quality;

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
        List<IEffect> effectList = new List<IEffect>();
        effectList.Add(new BasicEffect(BasicEffectKind.goldGain, () => _artifact.level * 3, Calway.add));
        effectList.Add(new BasicEffect(BasicEffectKind.expGain, () => 1 + 0.1 + _artifact.level * 0.1, Calway.mul));
        _artifact.effects = effectList;

        return _artifact;
    }
}

public class ArtifactFactory
{
    private readonly IArtifactBuilder builder;
    public ArtifactFactory(IArtifactBuilder builder)
    {
        this.builder = builder;
    }
    public Artifact CreateArtifact()
    {
        return builder.BuildArtifact();
    }
}   