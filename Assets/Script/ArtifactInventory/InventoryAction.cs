using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IdleLibrary.Inventory;
using static UsefulMethod;

public class DeleteItemWithConfirm : IInventoryAction
{
    private readonly IdleLibrary.Inventory.Inventory inventory;
    private readonly DeleteItem deleteItem;
    public DeleteItemWithConfirm(IdleLibrary.Inventory.Inventory inventory)
    {
        this.inventory = inventory;
        this.deleteItem = new DeleteItem(this.inventory);
    }
    public void Action(int index)
    {
        if (deleteItem.CanDelete(index))
        {
            var artifact = inventory.GetItem(index) as Artifact;
            var factor = artifact.level;
            if(artifact != null)
            {
                (ArtifactMaterial.ID id, long num) materialInfo = (object)artifact.quality switch
                {
                    int i when i <= 70 => (ArtifactMaterial.ID.MysteriousStone, 1 * factor),
                    int i when i <= 90 => (ArtifactMaterial.ID.MysteriousCrystal, 1 * factor),
                    int i when i <= 100 => (ArtifactMaterial.ID.MysteriousLeaf, 1 * factor),
                    _ => (ArtifactMaterial.ID.MysteriousStone, 1)
                };
                deleteItem.Action(index);
                BASE.main.Confirm($"You get {tDigit(materialInfo.num)} {materialInfo.id}!");
                BASE.main.SO.artifactMaterials[(int)materialInfo.id] += materialInfo.num;
            }
        }
    }
}
