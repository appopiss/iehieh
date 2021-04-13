using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static ARTIFACT.ArtifactName;

public class BatSet : BASE
{

    public int TotalBatLevel()
    {
        int tempInt = 0;
        foreach (ARTIFACT arti in main.NewArtifacts)
        {
            if (arti.artifactName == BatCloak || arti.artifactName == BatShoes)
            {
                tempInt += arti.level;
            }
        }
        return tempInt;
    }

    public double CalculateDodgeRate()
    {
        return 0.05 + Math.Min(0.0001 * TotalBatLevel(), 0.05);
    }

    // Use this for initialization
    void Awake()
    {
        StartBASE();
    }

    private void Update()
    {
        if (isBatSet())
            main.ArtifactFactor.DodgeRate = CalculateDodgeRate();
        else
            main.ArtifactFactor.DodgeRate = 0;
    }

    public bool isBatSet()
    {
        foreach (ARTIFACT arti in main.NewArtifacts)
        {
            if (arti.artifactName == BatCloak || arti.artifactName == BatShoes)
            {
                if (!arti.isEquipped)
                    return false;
            }
        }
        return true;
    }


}
