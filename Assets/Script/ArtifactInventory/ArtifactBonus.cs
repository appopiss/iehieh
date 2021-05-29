using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BASE;

public class ArtifactBonus 
{
    public static double HP_ADD => main.inventory_mono.effectCalculator.GetEffectValue(EffectType.HP_add);
    public static double MP_ADD => main.inventory_mono.effectCalculator.GetEffectValue(EffectType.MP_add);
    public static double ATK_ADD => main.inventory_mono.effectCalculator.GetEffectValue(EffectType.ATK_add);
    public static double DEF_ADD => main.inventory_mono.effectCalculator.GetEffectValue(EffectType.DEF_add);
    public static double MATK_ADD => main.inventory_mono.effectCalculator.GetEffectValue(EffectType.MATK_add);
    public static double MDEF_ADD => main.inventory_mono.effectCalculator.GetEffectValue(EffectType.MDEF_add);
    public static double HP_MUL => main.inventory_mono.effectCalculator.GetEffectValue(EffectType.HP_mul);
    public static double MP_MUL => main.inventory_mono.effectCalculator.GetEffectValue(EffectType.MP_mul);
    public static double ATK_MUL => main.inventory_mono.effectCalculator.GetEffectValue(EffectType.ATK_mul);
    public static double MATK_MUL => main.inventory_mono.effectCalculator.GetEffectValue(EffectType.MATK_mul);
    public static double DEF_MUL => main.inventory_mono.effectCalculator.GetEffectValue(EffectType.DEF_mul);
    public static double MDEF_MUL => main.inventory_mono.effectCalculator.GetEffectValue(EffectType.MDEF_mul);
    //ˆÈ‰º‚·‚×‚Ämul
    public static double GOLD_GAIN => main.inventory_mono.effectCalculator.GetEffectValue(EffectType.GoldGain);
    public static double SLIMEBANK_EFFICIENCY => main.inventory_mono.effectCalculator.GetEffectValue(EffectType.SlimeBankEfficiency);
    public static double PROFICIENCY => main.inventory_mono.effectCalculator.GetEffectValue(EffectType.Proficiency);
    public static double RESOURCE => main.inventory_mono.effectCalculator.GetEffectValue(EffectType.Resource);
    public static double NITRO_GAIN => main.inventory_mono.effectCalculator.GetEffectValue(EffectType.NitroGain);
    public static double WORKER_POWER => main.inventory_mono.effectCalculator.GetEffectValue(EffectType.WorkerPower);
    public static double ARTIFACT_POWER => main.inventory_mono.effectCalculator.GetEffectValue(EffectType.ArtifactPower);
}
