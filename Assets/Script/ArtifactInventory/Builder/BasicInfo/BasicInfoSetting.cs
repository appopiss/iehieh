using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBasicInfoSet
{
    Artifact GetArtifact(Artifact artifact);
}
public abstract class BaseBasicInfoSet : IBasicInfoSet
{
    public Artifact GetArtifact(Artifact artifact)
    {
        artifact.level = 1;
        artifact.id = ChooseId();
        artifact.quality = ChooseQuality();
        artifact.antimagicPower = ChooseAntiMagicPower(artifact.quality);
        return artifact;
    }
    protected abstract int ChooseId();
    protected abstract int ChooseQuality();
    protected abstract double ChooseAntiMagicPower(int quality);
}
public class BronzeInfoSetting : BaseBasicInfoSet
{
    protected override int ChooseId() => UnityEngine.Random.Range(0, 6);
    protected override int ChooseQuality() => UnityEngine.Random.Range(1, 40);
    protected override double ChooseAntiMagicPower(int quality) => quality * UnityEngine.Random.Range(1.2f, 1.5f);
}
public class SilverInfoSetting : BaseBasicInfoSet
{
    protected override int ChooseId() => UnityEngine.Random.Range(6,12);
    protected override int ChooseQuality() => UnityEngine.Random.Range(15, 70);
    protected override double ChooseAntiMagicPower(int quality) => quality * UnityEngine.Random.Range(1.2f, 1.5f);
}
public class GoldInfoSetting : BaseBasicInfoSet
{
    protected override int ChooseId() => UnityEngine.Random.Range(12, 18);
    protected override int ChooseQuality() => UnityEngine.Random.Range(30, 100);
    protected override double ChooseAntiMagicPower(int quality) => quality * UnityEngine.Random.Range(1.2f, 1.5f);
}
