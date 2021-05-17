using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IdleLibrary.Inventory;
using IdleLibrary;
using System;

public class ArtifactFactory
{
    public Artifact CreateArtifact()
    {
        var item = new Artifact(-1);
        //Id�����߂܂��B
        var id = UnityEngine.Random.Range(0, 5);
        item.id = id;

        //�N�I���e�B�����߂܂�
        var quality = UnityEngine.Random.Range(0, 100);
        item.quality = quality;

        //TimeBasedAction�̐ݒ�
        //�Ⴆ�΃��x��3�܂ł͒P��f�ށ@���x���T����͕����f�ނ��K�v
        var artifactTransaction = new ArtifactMaterialTransaction(ArtifactMaterial.ID.MysteriousStone, new LinearCost(1, 1, item));
        var artifactTransaction2 = new ArtifactMaterialMultipleTransaction(artifactTransaction, new ArtifactMaterialTransaction(ArtifactMaterial.ID.BlessingPowder, new LinearCost(0, 2, item)));
        Func<(ITransaction transaction, IText text)> func = () =>
        {
            if (item.level <= 3)
            {
                return (artifactTransaction, artifactTransaction);
            }
            else
            {
                return (artifactTransaction2, artifactTransaction2);
            }
        };
        var timeManager = new TimeBasedLevelUp(item, func, () => 10 * item.level);
        item.timeManager = timeManager;

        List<IEffect> effectList = new List<IEffect>();
        effectList.Add(new BasicEffect(BasicEffectKind.goldGain, () => item.level * 3, Calway.add));
        effectList.Add(new BasicEffect(BasicEffectKind.expGain, () => 1 + 0.1 + item.level * 0.1, Calway.mul));
        item.effects = effectList;

        return item;
    }
}   