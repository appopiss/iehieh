using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IdleLibrary;
using IdleLibrary.Inventory;
using System;

public class MaterialShowClass : IText
{
    ArtifactMaterial[] materials;
    public MaterialShowClass()
    {
        materials = new ArtifactMaterial[Enum.GetNames(typeof(ArtifactMaterial.ID)).Length];
        for (int i = 0; i < materials.Length; i++)
        {
            int j = i;
            materials[i] = new ArtifactMaterial(j);
        }
    }
    public string Text()
    {
        string text = "";
        for (int i = 0; i < materials.Length; i++)
        {
            if(materials[i].Number == 0) { continue; }
            text += $"- {materials[i].Text()}";
            text += "\n";
        }
        return text;
    }
}
public class MaterialNumberShowClass : IText
{
    ArtifactMaterial[] materials;
    public MaterialNumberShowClass()
    {
        materials = new ArtifactMaterial[Enum.GetNames(typeof(ArtifactMaterial.ID)).Length];
        for (int i = 0; i < materials.Length; i++)
        {
            int j = i;
            materials[i] = new ArtifactMaterial(j);
        }
    }
    public string Text()
    {
        string text = "";
        for (int i = 0; i < materials.Length; i++)
        {
            if (materials[i].Number == 0) { continue; }
            text += UsefulMethod.tDigit(materials[i].Number);
            text += "\n";
        }
        return text;
    }
}
