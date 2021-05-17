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
    [OdinSerialize] private Action recordedAction;

    public void OnClaim()
    {
        //宝箱のリストに追加する処理を書きます。
        switch (UnityEngine.Random.Range(0, 3))
        {
            case 0: BASE.main.SO.tier1chest.RegisterAction(recordedAction); break;
            case 1: BASE.main.SO.tier2chest.RegisterAction(recordedAction); break;
            case 2: BASE.main.SO.tier3chest.RegisterAction(recordedAction); break;
        }
    }

    //デリゲートはローカル変数を保存しないので、事前に抽選結果は保存しておく必要あり
    [OdinSerialize] private Artifact recordArtifact;
    [OdinSerialize] private (ArtifactMaterial.ID material, double num) recordMaterial;

    public void OnStart()
    {
        Action action = () => { };

        //artifactだったら
        if (UnityEngine.Random.Range(0, 2) == 0)
        {
            var ArtifactFactory = new ArtifactFactory();
            var artifact = ArtifactFactory.CreateArtifact();
            //ここで保存
            recordArtifact = artifact;
            action = () =>
            {
                BASE.main.Confirm($"You got new artifact!\n" + recordArtifact.Text());
                BASE.main.inventory_mono.inventoryInfo.inventory.SetItemByOrder(recordArtifact);
            };
        }
        //素材だったら
        else
        {
            //なにかしらの方法でrecordMaterialを決める
            recordMaterial = (ArtifactMaterial.ID.MysteriousStone, 2);
            action = () =>
            {
                BASE.main.Confirm($"You got some materials for artifacts!");
                BASE.main.SO.artifactMaterials[(int)recordMaterial.material] += recordMaterial.num;
            };
        }
        recordedAction = action;
    }

}