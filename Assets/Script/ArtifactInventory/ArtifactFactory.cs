using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IdleLibrary.Inventory;
using IdleLibrary;

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
        //var time = new TimeBasedLevelUp(item, new Transaction(new ArtifactMaterial((int)ArtifactMaterial.ID.BlessingPowder),new FixedCost(1)), () => item.level * 100);

        List<IEffect> effectList = new List<IEffect>();
        effectList.Add(new BasicEffect(BasicEffectKind.goldGain, () => item.level * 3, Calway.add));
        effectList.Add(new BasicEffect(BasicEffectKind.expGain, () => 1 + 0.1 + item.level * 0.1, Calway.mul));
        item.effects = effectList;

        return item;
    }
}