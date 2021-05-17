using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ArtifactBuilderUtility
{
    public static (double initialValue, double steep) ChooseMaterialCost(int quality, ArtifactMaterial.ID id)
    {
        (double initialValue, double steep) result = id switch
        {
            ArtifactMaterial.ID.MysteriousStone => (object)quality switch
            {
                int i when i <= 20 => (1, 3),
                int i when i <= 40 => (1, 5),
                int i when i <= 60 => (2, 7),
                int i when i <= 80 => (2, 9),
                _ => (1, 1)
            },

            ArtifactMaterial.ID.BlessingPowder => (object)quality switch
            {
                int i when i <= 20 => (1, 1),
                int i when i <= 40 => (1, 2),
                int i when i <= 60 => (2, 2),
                int i when i <= 80 => (2, 3),
                _ => (1, 1)
            },

            _ => (1,1)
        };
        return result;
    }

    public static Func<float> ChooseTimeToLevelUp(int quality, ILevel level)
    {
        Func<float> result = (object)quality switch
        {
            int i when i <= 20 => () => 10 * 60 * (level.level + 1),
            int i when i <= 40 => () => 30 * 60 * (level.level + 1),
            int i when i <= 60 => () => 60 * 60 * (level.level + 1),
            int i when i <= 80 => () => 200 * 60 * (level.level + 1),
            _ => () => 10 * 60 * (level.level + 1),
        };
        return result;
    }
}
