using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IdleLibrary;
using IdleLibrary.Inventory;

//最も簡単な例
public class SampleExpeditionReward : IReward
{
    private IdleLibrary.Inventory.Inventory inventory;
    public SampleExpeditionReward(IdleLibrary.Inventory.Inventory inventory)
    {
        this.inventory = inventory;
    }
    public void Reward()
    {
        var ArtifactFactory = new ItemFactory();
        var artifact = ArtifactFactory.CreateRandomItem();
        inventory.SetItemByOrder(artifact);
    }

    public string Text()
    {
        return "ランダムにアーティファクトを獲得します";
    }
}