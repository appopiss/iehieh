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
        EffectPrototypes.Add(MakeArtifactPrototype(new BasicEffect(EffectType.HP_add, "HP+", Calway.add)));
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
