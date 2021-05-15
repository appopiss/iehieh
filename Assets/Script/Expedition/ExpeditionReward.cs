using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IdleLibrary;
using IdleLibrary.Inventory;
using Sirenix.Serialization;
using System;

namespace IdleLibrary
{
    public interface IExpeditionAction
    {
        void OnStart();
        void OnClaim();
    }
}
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
    }

    public void OnStart()
    {
        Action action = () => { };

        //artifactだったら
        if (UnityEngine.Random.Range(0, 2) == 0)
        {
            var ArtifactFactory = new ArtifactFactory();
            var artifact = ArtifactFactory.CreateArtifact();
        }
        //素材だったら
        else
        {

        }
        
    }

}