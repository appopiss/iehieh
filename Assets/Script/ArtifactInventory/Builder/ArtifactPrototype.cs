using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using IdleLibrary.Inventory;
using IdleLibrary;
using System.Linq;
using static ArtifactBuilderUtility;

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
//Awakeで辞書を登録する
/*
public class ArtifactPrototype
{
    //Singleton
    private List<Artifact> EffectPrototypes = new List<Artifact>();
    public ArtifactPrototype()
    {
        //HPからプロトタイプを作っていく
        var level = new Level();
        var timeLevel = new TimeBasedLevel(10);
        var tier1cost = new ArtifactMaterialSingleTransaction(ArtifactMaterial.ID.MysteriousStone, new LinearCost(1, 2, timeLevel));
        var tier2cost = new ArtifactMaterialSingleTransaction(ArtifactMaterial.ID.BlessingPowder, new LinearCost(1, 1, timeLevel));
        var transaction = new NormalArtifactTransaction(new ArtifactMaterialTransaction(tier1cost), new ArtifactMaterialTransaction(tier1cost, tier2cost), 5);
        var time = new ArtifactTimeCaltulator();
        var timeManager = new TimeBasedLevelUp(level, timeLevel, transaction.GetTransactionInfo(level), time.);
        var effect = new BasicEffect(EffectType.HP_add, "HP+", Calway.add);
        effect.value = () => 
        EffectPrototypes.Add(new Artifact(-1).SetTimeManager(10).SetTransactionCost());
    }
    public Artifact GetArtifact(ArtifactType type)
    {
        return EffectPrototypes[(int)type];
    }
    public IEnumerable<Artifact> GetArtifacts()
    {
        return EffectPrototypes;
    }
}
*/

//情報を静的に生成したらどうなるだろうか？
//引数でArtifactを受け取るようにする？
public abstract class ArtifactPrototype
{
    public abstract long maxLevel { get;}
    public abstract long maxMaxLevel { get; }
    public abstract BasicEffect effect { get; }
    public abstract double EffectValue(ILevel level,  int quality);
    public abstract IArtifactTransaction GetTransactionInfo(ILevel level);
    public IArtifactTimeCalculator GetTimeCaltulator = new ArtifactTimeCaltulator();
}
public class SlimeBronzeStatue : ArtifactPrototype
{
    public override long maxLevel => 10;
    public override long maxMaxLevel => 20;
    private BasicEffect _effect = new BasicEffect(EffectType.HP_add, "HP+", Calway.add); public override BasicEffect effect => _effect;
    public override double EffectValue(ILevel level, int quality) => 10 * (level.level + 1) * (1 + quality / 100);
    public override IArtifactTransaction GetTransactionInfo(ILevel level)
    {
        var tier1cost = new ArtifactMaterialSingleTransaction(ArtifactMaterial.ID.MysteriousStone, new LinearCost(1, 2, level));
        var tier2cost = new ArtifactMaterialSingleTransaction(ArtifactMaterial.ID.BlessingPowder, new LinearCost(1, 1, level));
        return new NormalArtifactTransaction(new ArtifactMaterialTransaction(tier1cost), new ArtifactMaterialTransaction(tier1cost, tier2cost), 5);
    }
}