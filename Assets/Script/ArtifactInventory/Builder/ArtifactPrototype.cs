using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using IdleLibrary.Inventory;
using System.Linq;

public enum ArtifactType
{
    SlimeBronze,
    BatBronze,
    SpiderBronze,
    FairyBronze,
    FoxBronze,
    DevilfishBronze,
    SlimeIron,
    BatIron,
    SpiderIron,
    FairyIron,
    FoxIron,
    DevilfishIron,
    gold1,
    gold2,
    gold3,
    gold4,
    gold5,
    gold6,
    gold7,
    gold8,
    gold9
}
public enum EffectType
{
    HP_add,
    MP_add,
    ATK_add,
    DEF_add,
    MATK_add,
    MDEF_add,
    HP_mul,
    MP_mul,
    ATK_mul,
    MATK_mul,
    DEF_mul,
    MDEF_mul,

}
//AwakeÇ≈é´èëÇìoò^Ç∑ÇÈ
public class ArtifactPrototype
{
    //Singleton
    private List<Artifact> EffectPrototypes = new List<Artifact>();
    public ArtifactPrototype()
    {
        EffectPrototypes.Add(MakeArtifactPrototype(new BronzeInfoSetting(), new TimeBasedLevel(10), new NormalArtifactTransaction())
    }
    public Artifact GetArtifact(ArtifactType type)
    {
        return EffectPrototypes[(int)type];
    }
    
    public Artifact MakeArtifactPrototype(
        IBasicInfoSet basicInfoSet,
        TimeBasedLevel levelInfo,
        IArtifactTransaction transaction,
        IArtifactTimeCalculator time,
        IEffect mainEffect)
    {
        var _artifact = new Artifact(-1);
        _artifact = basicInfoSet.GetArtifact(_artifact);

        //levelê›íË
        _artifact.level = 1;
        var timeManager = new TimeBasedLevelUp(_artifact, levelInfo,
            () => transaction.GetTransactionInfo(_artifact),
            () => time.GetRequiredTime(_artifact.quality, _artifact));

        _artifact.timeManager = timeManager;

        //Effectê›íË
        _artifact.mainEffect = mainEffect;

        return _artifact;
    }

    public class ArtifactBuilder
    {
        private Artifact artifact;
        public ArtifactBuilder()
        {
            artifact = new Artifact(-1);
        }
        public Artifact SetBasicInfo(IBasicInfoSet basicInfoSet)
        {
            return basicInfoSet.GetArtifact(artifact);
        }
    }
}
