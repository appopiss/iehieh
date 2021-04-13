using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static ARTIFACT.ArtifactName;

public class FoxSet : BASE {

    public int TotalFoxLevel()
    {
        int tempInt = 0;
        foreach (ARTIFACT arti in main.NewArtifacts)
        {
            if (arti.artifactName == FoxHat || arti.artifactName == FoxCoat || arti.artifactName == FoxBoots)
            {
                tempInt += arti.level;
            }
        }
        return tempInt;
    }

    public double CalculateResistanceRate()
    {
        return 0.05 + Math.Min(0.0001 * TotalFoxLevel(), 0.85);
    }

    // Use this for initialization
    void Awake()
    {
        StartBASE();
    }

    private void Update()
    {
        if (isFoxSet())
            main.ArtifactFactor.DebuffResistance = CalculateResistanceRate();
        else
            main.ArtifactFactor.DebuffResistance = 0;
    }

    public bool isFoxSet()
    {
        foreach (ARTIFACT arti in main.NewArtifacts)
        {
            if (arti.artifactName == FoxHat || arti.artifactName == FoxCoat || arti.artifactName == FoxBoots)
            {
                if (!arti.isEquipped)
                    return false;
            }
        }
        return true;
    }
}
