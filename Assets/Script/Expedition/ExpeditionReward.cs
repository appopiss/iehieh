using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IdleLibrary;
using IdleLibrary.Inventory;
using Sirenix.Serialization;
using System;

//最も簡単な例
//どこのtierに属するかと何をするかを決める？
public class ArtifactReward : IExpeditionAction
{
    private IdleLibrary.Inventory.Inventory inventory;
    [OdinSerialize] private Action recordedAction;
    public ArtifactReward(IdleLibrary.Inventory.Inventory inventory)
    {
        this.inventory = inventory;
    }

    public void OnClaim()
    {
        //宝箱のリストに追加する処理を書きます。
        Debug.Log(recordedAction == null);
        switch (UnityEngine.Random.Range(0, 4))
        {
            case 0: BASE.main.SO.tier1chest.RegisterAction(recordedAction); break;
            case 1: BASE.main.SO.tier2chest.RegisterAction(recordedAction); break;
            case 2: BASE.main.SO.tier3chest.RegisterAction(recordedAction); break;
        }
    }

    public void OnStart()
    {
        Action action = () => { };

        //artifactだったら
        if (UnityEngine.Random.Range(0, 2) == 0)
        {
            var ArtifactFactory = new ArtifactFactory();
            var artifact = ArtifactFactory.CreateArtifact();
            action = () =>
            {
                BASE.main.Confirm($"You got new artifact!\n" + artifact.Text());
                inventory.SetItemByOrder(artifact);
            };
        }
        //素材だったら
        else
        {
            action = () =>
            {
                BASE.main.Confirm($"You got some materials for artifacts!");
                BASE.main.SO.artifactMaterials[(int)ArtifactMaterial.ID.MysteriousStone] += 1;
            };
        }
        recordedAction = action;
    }

}