using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static ARTIFACT.ArtifactName;

public class FairySet : BASE
{

    public int TotalFairyLevel()
    {
        int tempInt = 0;
        foreach (ARTIFACT arti in main.NewArtifacts)
        {
            if (arti.artifactName == FairyBoots || arti.artifactName == MagicalFairyWing)
            {
                tempInt += arti.level;
            }
        }
        return tempInt;
    }

    public double CalculateSpeedRate()
    {
        return Math.Min(0.005 * TotalFairyLevel(), 1);
    }

    // Use this for initialization
    void Awake()
    {
        StartBASE();
    }

    private void Update()
    {
        if (isFairySet())
            main.ArtifactFactor.SpeedRate = CalculateSpeedRate();
        else
            main.ArtifactFactor.SpeedRate = 0;
    }

    public bool isFairySet()
    {
        foreach (ARTIFACT arti in main.NewArtifacts)
        {
            if (arti.artifactName == FairyBoots || arti.artifactName == MagicalFairyWing)
            {
                if (!arti.isEquipped)
                    return false;
            }
        }
        return true;
    }


}
