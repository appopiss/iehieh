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
    SPD,
    HP_mul,
    MP_mul,
    ATK_mul,
    MATK_mul,
    DEF_mul,
    MDEF_mul,
    GoldGain,
    SlimeBankEfficiency,
    Proficiency,
    Resource,
    NitroGain,
    WorkerPower,
    ArtifactPower,
    ATKPro,
    MATKPro,
    DEFPro,
    MDEFPro,
    GoldGain_Extra,
    FireResistance,
    IceResistance,
    LightResistance,
    DarkResistance,
    DebuffResistance,
    AntiMagicPower
}
//AwakeÇ≈é´èëÇìoò^Ç∑ÇÈ
public class ArtifactPrototypeRepository
{
    //Singleton
    private static List<ArtifactPrototype> ArtifactPrototypes = new List<ArtifactPrototype>()
    {
        new SlimeBronzeStatue(),
        new BatBronzeStatue(),
        new SpiderBronzeStatue(),
        new FairyBronzeStatue(),
        new FoxBronzeStatue(),
        new DevilfishBronzeStatue(),

        new SlimeIronStatue(),
        new BatIronStatue(),
        new SpiderIronStatue(),
        new FairyIronStatue(),
        new FoxIronStatue(),
        new DevilFishIronStatue(),

        new SlimeGoldenStatue(),
        new BatGoldenStatue(),
        new SpiderGoldenStatue(),
        new FairyGoldenStatue(),
        new FoxGoldenStatue(),
        new DevilFishGoldenstatue(),
        new UnicornGoldenStatue()
    };
    private static List<IEffect> EffectPrototypes = new List<IEffect>()
    {
        new BasicEffect(EffectType.HP_add, "HP", Calway.add),
        new BasicEffect(EffectType.MP_add, "MP", Calway.add),
        new BasicEffect(EffectType.ATK_add, "ATK", Calway.add),
        new BasicEffect(EffectType.DEF_add, "DEF", Calway.add),
        new BasicEffect(EffectType.MATK_add, "MATK", Calway.add),
        new BasicEffect(EffectType.MDEF_add, "MDEF", Calway.add),
        new BasicEffect(EffectType.HP_mul, "HP", Calway.mul),
        new BasicEffect(EffectType.MP_mul, "MP", Calway.mul),
        new BasicEffect(EffectType.ATK_mul, "ATK", Calway.mul),
        new BasicEffect(EffectType.MATK_mul, "MATK", Calway.mul),
        new BasicEffect(EffectType.DEF_mul, "DEF", Calway.mul),
        new BasicEffect(EffectType.MDEF_mul, "MDEF", Calway.mul),
        new BasicEffect(EffectType.GoldGain, "Gold Gain", Calway.mul),
        new BasicEffect(EffectType.SlimeBankEfficiency, "Slime Bank Efficiency", Calway.mul),
        new BasicEffect(EffectType.Proficiency, "Proficiency", Calway.mul),
        new BasicEffect(EffectType.Resource, "Resource", Calway.mul),
        new BasicEffect(EffectType.NitroGain, "Nitro Gain", Calway.mul),
        new BasicEffect(EffectType.WorkerPower, "Worker Power", Calway.mul),
        new BasicEffect(EffectType.ArtifactPower, "Artifact Power", Calway.mul)
    };

    public static ArtifactPrototype GetPrototype(int id)
    {
        return ArtifactPrototypes[id];
    }
    public static IEnumerable<ArtifactPrototype> GetPrototypes()
    {
        return ArtifactPrototypes;
    }
    public static IEffect GetEffect(EffectType type)
    {
        return EffectPrototypes[(int)type];
    }
    public static IEnumerable<IEffect> GetEffects()
    {
        return EffectPrototypes;
    }
}


//èÓïÒÇê√ìIÇ…ê∂ê¨ÇµÇΩÇÁÇ«Ç§Ç»ÇÈÇæÇÎÇ§Ç©ÅH
//à¯êîÇ≈ArtifactÇéÛÇØéÊÇÈÇÊÇ§Ç…Ç∑ÇÈÅH
public abstract class ArtifactPrototype
{
    public abstract string Name { get; }
    public abstract long maxLevel { get;}
    public abstract long maxMaxLevel { get; }
    public abstract BasicEffect effect { get; }
    public abstract double EffectValue(ILevel level,  int quality);
    protected virtual double aug(ILevel level, int quality) => (level.level + 1) * (1 + (float)quality / 100f);
    protected virtual double costFactor(ILevel level, int quality) => level.level + Math.Floor((float)quality / 10);
    public virtual IArtifactTransaction GetTransactionInfo(ILevel level, int quality)
    {
        var tier1cost = new ArtifactMaterialSingleTransaction(ArtifactMaterial.ID.MysteriousStone, new LinearCost(1, 2, level));
        var tier2cost = new ArtifactMaterialSingleTransaction(ArtifactMaterial.ID.BlessingPowder, new LinearCost(1, 1, level));
        return new NormalArtifactTransaction(new ArtifactMaterialTransaction(tier1cost), new ArtifactMaterialTransaction(tier1cost, tier2cost), 5);
    }
    protected IArtifactTransaction BronzeTransaction(ILevel level, int quality, ArtifactMaterial.ID id)
    {
        var tier1cost = new ArtifactMaterialSingleTransaction(id,
            new MaterialCost((l, q) => 10 * costFactor(level, quality), level, quality));
        var tier2cost = new ArtifactMaterialSingleTransaction(ArtifactMaterial.ID.BlessingPowder,
            new MaterialCost((l, q) => 1, level, quality));
        return new NormalArtifactTransaction(new ArtifactMaterialTransaction(tier1cost), new ArtifactMaterialTransaction(tier1cost, tier2cost), 10);
    }
    protected IArtifactTransaction SilverTransaction(ILevel level, int quality, (ArtifactMaterial.ID id1, ArtifactMaterial.ID id2) id)
    {
        var tier1cost = new ArtifactMaterialTransaction(
            new ArtifactMaterialSingleTransaction(id.id1, new MaterialCost((l, q) => 50 * costFactor(level, quality), level, quality)),
            new ArtifactMaterialSingleTransaction(id.id2, new MaterialCost((l, q) => 50 * costFactor(level, quality), level, quality))
       );
        var tier2cost = new ArtifactMaterialSingleTransaction(ArtifactMaterial.ID.BlessingPowder,
            new MaterialCost((l, q) => 1, level, quality));
        return new NormalArtifactTransaction(tier1cost, new ArtifactMaterialTransaction(tier2cost), 10);
    }
    protected IArtifactTransaction GoldenTransaction(ILevel level, int quality, (ArtifactMaterial.ID id1, ArtifactMaterial.ID id2, ArtifactMaterial.ID id3) id)
    {
        var tier1cost = new ArtifactMaterialTransaction(
            new ArtifactMaterialSingleTransaction(id.id1, new MaterialCost((l, q) => 100 * costFactor(level, quality), level, quality)),
            new ArtifactMaterialSingleTransaction(id.id2, new MaterialCost((l, q) => 100 * costFactor(level, quality), level, quality)),
            new ArtifactMaterialSingleTransaction(id.id3, new MaterialCost((l, q) => 100 * costFactor(level, quality), level, quality))
       );
        var tier2cost = new ArtifactMaterialSingleTransaction(ArtifactMaterial.ID.BlessingPowder,
            new MaterialCost((l, q) => 1, level, quality));
        return new NormalArtifactTransaction(tier1cost, new ArtifactMaterialTransaction(tier2cost), 10);
    }
    public IArtifactTimeCalculator GetTimeCaltulator = new ArtifactTimeCaltulator();
}
public class SlimeBronzeStatue : ArtifactPrototype
{
    public override string Name => "Slime Bronze Statue";
    public override long maxLevel => 10;
    public override long maxMaxLevel => 20;
    public override BasicEffect effect => new BasicEffect((BasicEffect)ArtifactPrototypeRepository.GetEffect(EffectType.HP_add));
    public override double EffectValue(ILevel level, int quality) => 10 * aug(level, quality);
    public override IArtifactTransaction GetTransactionInfo(ILevel level, int quality) => BronzeTransaction(level, quality, ArtifactMaterial.ID.MysteriousStone);
}
public class BatBronzeStatue : ArtifactPrototype
{
    public override string Name => "Bat Bronze Statue";
    public override long maxLevel => 10;
    public override long maxMaxLevel => 20;
    public override BasicEffect effect => new BasicEffect((BasicEffect)ArtifactPrototypeRepository.GetEffect(EffectType.MP_add));
    public override double EffectValue(ILevel level, int quality) => 5 * aug(level, quality);
    public override IArtifactTransaction GetTransactionInfo(ILevel level, int quality) => BronzeTransaction(level, quality, ArtifactMaterial.ID.MysteriousCrystal);
}
public class SpiderBronzeStatue : ArtifactPrototype
{
    public override string Name => "Spider Bronze Statue";
    public override long maxLevel => 10;
    public override long maxMaxLevel => 20;
    public override BasicEffect effect => new BasicEffect((BasicEffect)ArtifactPrototypeRepository.GetEffect(EffectType.ATK_add));
    public override double EffectValue(ILevel level, int quality) => 1 * aug(level, quality);
    public override IArtifactTransaction GetTransactionInfo(ILevel level, int quality) => BronzeTransaction(level, quality, ArtifactMaterial.ID.MysteriousStone);
}
public class FairyBronzeStatue : ArtifactPrototype
{
    public override string Name => "Fairy Bronze Statue";
    public override long maxLevel => 10;
    public override long maxMaxLevel => 20;
    public override BasicEffect effect => new BasicEffect((BasicEffect)ArtifactPrototypeRepository.GetEffect(EffectType.MATK_add));
    public override double EffectValue(ILevel level, int quality) => 1 * aug(level, quality);
    public override IArtifactTransaction GetTransactionInfo(ILevel level, int quality) => BronzeTransaction(level, quality, ArtifactMaterial.ID.MysteriousCrystal);
}
public class FoxBronzeStatue : ArtifactPrototype
{
    public override string Name => "Fox Bronze Statue";
    public override long maxLevel => 10;
    public override long maxMaxLevel => 20;
    public override BasicEffect effect => new BasicEffect((BasicEffect)ArtifactPrototypeRepository.GetEffect(EffectType.DEF_add));
    public override double EffectValue(ILevel level, int quality) => 1 * aug(level, quality);
    public override IArtifactTransaction GetTransactionInfo(ILevel level, int quality) => BronzeTransaction(level, quality, ArtifactMaterial.ID.MysteriousStone);
}
public class DevilfishBronzeStatue : ArtifactPrototype
{
    public override string Name => "Devil Fish Bronze Statue";
    public override long maxLevel => 10;
    public override long maxMaxLevel => 20;
    public override BasicEffect effect => new BasicEffect((BasicEffect)ArtifactPrototypeRepository.GetEffect(EffectType.MDEF_add));
    public override double EffectValue(ILevel level, int quality) => 1 * aug(level, quality);
    public override IArtifactTransaction GetTransactionInfo(ILevel level, int quality) => BronzeTransaction(level, quality, ArtifactMaterial.ID.MysteriousCrystal);
}

public class SlimeIronStatue : ArtifactPrototype
{
    public override string Name => "Slime Iron Statue";
    public override long maxLevel => 5;
    public override long maxMaxLevel => 10;
    public override BasicEffect effect => new BasicEffect((BasicEffect)ArtifactPrototypeRepository.GetEffect(EffectType.HP_mul));
    public override double EffectValue(ILevel level, int quality) => 10 * aug(level, quality) * 0.01;
    public override IArtifactTransaction GetTransactionInfo(ILevel level, int quality) => 
        SilverTransaction(level, quality, (ArtifactMaterial.ID.MysteriousStone, ArtifactMaterial.ID.MysteriousLeaf));
}
public class BatIronStatue : ArtifactPrototype
{
    public override string Name => "Bat Iron Statue";
    public override long maxLevel => 5;
    public override long maxMaxLevel => 10;
    public override BasicEffect effect => new BasicEffect((BasicEffect)ArtifactPrototypeRepository.GetEffect(EffectType.MP_mul));
    public override double EffectValue(ILevel level, int quality) => 5 * aug(level, quality) * 0.01;
    public override IArtifactTransaction GetTransactionInfo(ILevel level, int quality) =>
        SilverTransaction(level, quality, (ArtifactMaterial.ID.MysteriousCrystal, ArtifactMaterial.ID.MysteriousLeaf));
}
public class SpiderIronStatue : ArtifactPrototype
{
    public override string Name => "Spider Iron Statue";
    public override long maxLevel => 5;
    public override long maxMaxLevel => 10;
    public override BasicEffect effect => new BasicEffect((BasicEffect)ArtifactPrototypeRepository.GetEffect(EffectType.ATK_mul));
    public override double EffectValue(ILevel level, int quality) => 1 * aug(level, quality) * 0.01;
    public override IArtifactTransaction GetTransactionInfo(ILevel level, int quality) =>
        SilverTransaction(level, quality, (ArtifactMaterial.ID.MysteriousStone, ArtifactMaterial.ID.MysteriousLeaf));
}
public class FairyIronStatue : ArtifactPrototype
{
    public override string Name => "Fairy Iron Statue";
    public override long maxLevel => 5;
    public override long maxMaxLevel => 10;
    public override BasicEffect effect => new BasicEffect((BasicEffect)ArtifactPrototypeRepository.GetEffect(EffectType.MATK_mul));
    public override double EffectValue(ILevel level, int quality) => 1 * aug(level, quality) * 0.01;
    public override IArtifactTransaction GetTransactionInfo(ILevel level, int quality) =>
        SilverTransaction(level, quality, (ArtifactMaterial.ID.MysteriousCrystal, ArtifactMaterial.ID.MysteriousLeaf));
}
public class FoxIronStatue : ArtifactPrototype
{
    public override string Name => "Slime Bronze Statue";
    public override long maxLevel => 5;
    public override long maxMaxLevel => 10;
    public override BasicEffect effect => new BasicEffect((BasicEffect)ArtifactPrototypeRepository.GetEffect(EffectType.DEF_mul));
    public override double EffectValue(ILevel level, int quality) => 1 * aug(level, quality) * 0.01;
    public override IArtifactTransaction GetTransactionInfo(ILevel level, int quality) =>
        SilverTransaction(level, quality, (ArtifactMaterial.ID.MysteriousStone, ArtifactMaterial.ID.MysteriousLeaf));
}
public class DevilFishIronStatue : ArtifactPrototype
{
    public override string Name => "Devil Fish Iron Statue";
    public override long maxLevel => 5;
    public override long maxMaxLevel => 10;
    public override BasicEffect effect => new BasicEffect((BasicEffect)ArtifactPrototypeRepository.GetEffect(EffectType.MDEF_mul));
    public override double EffectValue(ILevel level, int quality) => 1 * aug(level, quality) * 0.01;
    public override IArtifactTransaction GetTransactionInfo(ILevel level, int quality) =>
        SilverTransaction(level, quality, (ArtifactMaterial.ID.MysteriousCrystal, ArtifactMaterial.ID.MysteriousLeaf));
}
public class SlimeGoldenStatue : ArtifactPrototype
{
    public override string Name => "Slime Golden Statue";
    public override long maxLevel => 5;
    public override long maxMaxLevel => 10;
    public override BasicEffect effect => new BasicEffect((BasicEffect)ArtifactPrototypeRepository.GetEffect(EffectType.GoldGain));
    public override double EffectValue(ILevel level, int quality) => 1 * aug(level, quality) * 0.01;
    public override IArtifactTransaction GetTransactionInfo(ILevel level, int quality) =>
        GoldenTransaction(level, quality, (ArtifactMaterial.ID.MysteriousStone, ArtifactMaterial.ID.MysteriousCrystal,ArtifactMaterial.ID.MysteriousLeaf));
}
public class BatGoldenStatue : ArtifactPrototype
{
    public override string Name => "Bat Golden Statue";
    public override long maxLevel => 5;
    public override long maxMaxLevel => 10;
    public override BasicEffect effect => new BasicEffect((BasicEffect)ArtifactPrototypeRepository.GetEffect(EffectType.SlimeBankEfficiency));
    public override double EffectValue(ILevel level, int quality) => 1 * aug(level, quality) * 0.01;
    public override IArtifactTransaction GetTransactionInfo(ILevel level, int quality) =>
    GoldenTransaction(level, quality, (ArtifactMaterial.ID.MysteriousStone, ArtifactMaterial.ID.MysteriousCrystal, ArtifactMaterial.ID.MysteriousLeaf));

}
public class SpiderGoldenStatue : ArtifactPrototype
{
    public override string Name => "Spider Golden Statue";
    public override long maxLevel => 5;
    public override long maxMaxLevel => 10;
    public override BasicEffect effect => new BasicEffect((BasicEffect)ArtifactPrototypeRepository.GetEffect(EffectType.Proficiency));
    public override double EffectValue(ILevel level, int quality) => 1 * aug(level, quality) * 0.01;
    public override IArtifactTransaction GetTransactionInfo(ILevel level, int quality) =>
    GoldenTransaction(level, quality, (ArtifactMaterial.ID.MysteriousStone, ArtifactMaterial.ID.MysteriousCrystal, ArtifactMaterial.ID.MysteriousLeaf));

}
public class FairyGoldenStatue : ArtifactPrototype
{
    public override string Name => "Fairy Golden Statue";
    public override long maxLevel => 5;
    public override long maxMaxLevel => 10;
    public override BasicEffect effect => new BasicEffect((BasicEffect)ArtifactPrototypeRepository.GetEffect(EffectType.Resource));
    public override double EffectValue(ILevel level, int quality) => 1 * aug(level, quality) * 0.01;
    public override IArtifactTransaction GetTransactionInfo(ILevel level, int quality) =>
    GoldenTransaction(level, quality, (ArtifactMaterial.ID.MysteriousStone, ArtifactMaterial.ID.MysteriousCrystal, ArtifactMaterial.ID.MysteriousLeaf));

}
public class FoxGoldenStatue : ArtifactPrototype
{
    public override string Name => "Fox Golden Statue";
    public override long maxLevel => 5;
    public override long maxMaxLevel => 10;
    public override BasicEffect effect => new BasicEffect((BasicEffect)ArtifactPrototypeRepository.GetEffect(EffectType.NitroGain));
    public override double EffectValue(ILevel level, int quality) => 1 * aug(level, quality) * 0.01;
    public override IArtifactTransaction GetTransactionInfo(ILevel level, int quality) =>
    GoldenTransaction(level, quality, (ArtifactMaterial.ID.MysteriousStone, ArtifactMaterial.ID.MysteriousCrystal, ArtifactMaterial.ID.MysteriousLeaf));

}
public class DevilFishGoldenstatue : ArtifactPrototype
{
    public override string Name => "Devil Fish Golden Statue";
    public override long maxLevel => 5;
    public override long maxMaxLevel => 10;
    public override BasicEffect effect => new BasicEffect((BasicEffect)ArtifactPrototypeRepository.GetEffect(EffectType.WorkerPower));
    public override double EffectValue(ILevel level, int quality) => 5 * aug(level, quality) * 0.01;
    public override IArtifactTransaction GetTransactionInfo(ILevel level, int quality) =>
    GoldenTransaction(level, quality, (ArtifactMaterial.ID.MysteriousStone, ArtifactMaterial.ID.MysteriousCrystal, ArtifactMaterial.ID.MysteriousLeaf));

}
public class UnicornGoldenStatue : ArtifactPrototype
{
    public override string Name => "Unicorn Golden Statue";
    public override long maxLevel => 5;
    public override long maxMaxLevel => 10;
    public override BasicEffect effect => new BasicEffect((BasicEffect)ArtifactPrototypeRepository.GetEffect(EffectType.ArtifactPower));
    public override double EffectValue(ILevel level, int quality) => 1 * aug(level, quality) * 0.01;
    public override IArtifactTransaction GetTransactionInfo(ILevel level, int quality) =>
    GoldenTransaction(level, quality, (ArtifactMaterial.ID.MysteriousStone, ArtifactMaterial.ID.MysteriousCrystal, ArtifactMaterial.ID.MysteriousLeaf));

}

