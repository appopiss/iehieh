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
    private List<IEffect> EffectPrototypes = new List<IEffect>();
    public ArtifactPrototype()
    {
        EffectPrototypes.Add(new BasicEffect(EffectType.HP_add, "HP", Calway.add));
        EffectPrototypes.Add(new BasicEffect(EffectType.MP_add, "MP", Calway.add));
        EffectPrototypes.Add(new BasicEffect(EffectType.ATK_add, "ATK", Calway.add));
        EffectPrototypes.Add(new BasicEffect(EffectType.DEF_add, "DEF", Calway.add));
        EffectPrototypes.Add(new BasicEffect(EffectType.MATK_add, "MATK", Calway.add));
        EffectPrototypes.Add(new BasicEffect(EffectType.MDEF_add, "MDEF", Calway.add));
        EffectPrototypes.Add(new BasicEffect(EffectType.HP_mul, "HP", Calway.mul));
        EffectPrototypes.Add(new BasicEffect(EffectType.MP_mul, "MP", Calway.mul));
        EffectPrototypes.Add(new BasicEffect(EffectType.ATK_mul, "ATK", Calway.mul));
        EffectPrototypes.Add(new BasicEffect(EffectType.MATK_mul, "MATK", Calway.mul));
        EffectPrototypes.Add(new BasicEffect(EffectType.DEF_mul, "DEF", Calway.mul));
        EffectPrototypes.Add(new BasicEffect(EffectType.MDEF_mul, "MDEF", Calway.mul));
    }
    public IEffect GetEffect(EffectType type)
    {
        Debug.Log(EffectPrototypes.Count);
        IEffect effect = EffectPrototypes.Where(x => (EffectType)x.effectType == type).Single();
        return effect;
    }
    public IEnumerable<IEffect> GetEffects()
    {
        return EffectPrototypes;
    }
    
    public Artifact MakeArtifactPrototype(IBasicInfoSet basicInfoSet, TimeBasedLevel levelInfo, IArtifactTransaction transaction, IArtifactTimeCalculator time)
    {
        var _artifact = new Artifact(-1);
        _artifact = basicInfoSet.GetArtifact(_artifact);

        //levelê›íË
        _artifact.level = 1;

    }
}
