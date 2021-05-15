using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.Serialization;
using System;
using IdleLibrary.Inventory;

[Serializable]
public class Chest
{
    [OdinSerialize] List<Artifact> recordedArtifacts;
    public Chest()
    {
        
    }
}
