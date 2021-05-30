using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IArtifactTimeCalculator
{
    float GetRequiredTime(int quality, ILevel level);
}
public class ArtifactTimeCaltulator : IArtifactTimeCalculator
{
    public float GetRequiredTime(int quality, ILevel level)
    {
        return (float)(3600 * level.level * Math.Pow(10, (float)quality / 100));
    }
}
