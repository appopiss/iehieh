using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IdleLibrary;
using IdleLibrary.Inventory;

public class LevelUpArtifact : IInventoryAction
{
    private readonly IdleLibrary.Inventory.Inventory inventory;
    public LevelUpArtifact(IdleLibrary.Inventory.Inventory inventory)
    {
        this.inventory = inventory;
    }
    public void Action(int index)
    {
        ITEM item = inventory.GetItem(index);
        if (!(item is Artifact)) return;

        var artifact = item as Artifact;
        artifact.timeManager.IncreaseLevelCap(1);
    }
}
