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
        //Idを決めます。
        var id = UnityEngine.Random.Range(0, 5);
        item.id = id;

        //クオリティを決めます
        var quality = UnityEngine.Random.Range(0, 100);
        item.quality = quality;

        //TimeBasedActionの設定
        //例えばレベル3までは単一素材　レベル５からは複数素材が必要
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