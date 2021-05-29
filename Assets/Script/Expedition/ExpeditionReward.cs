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
    [OdinSerialize] private Action[] recordedAction;

    public void OnClaim()
    {
        for (int i = 0; i < chestTier.Length; i++)
        {
            switch (chestTier[i])
            {
                case 1: BASE.main.SO.tier1chest.RegisterAction(recordedAction[i]); break;
                case 2: BASE.main.SO.tier2chest.RegisterAction(recordedAction[i]); break;
                case 3: BASE.main.SO.tier3chest.RegisterAction(recordedAction[i]); break;
            }
        }
    }

    //デリゲートはローカル変数を保存しないので、事前に抽選結果は保存しておく必要あり
    [OdinSerialize] private Artifact recordArtifact;
    [OdinSerialize] private (ArtifactMaterial.ID material, double num) recordMaterial;
    [OdinSerialize] private int[] chestTier;

    public void OnStart(int chestLotteryNum, float[] chestChance)
    {
        chestTier = new int[chestLotteryNum];
        recordedAction = new Action[chestLotteryNum];
        for (int i = 0; i < chestLotteryNum; i++)
        {
            int rand = UnityEngine.Random.Range(0, 10000);
            if (rand < chestChance[2] * 10000) chestTier[i] = 3;
            else if (rand < (chestChance[1] + chestChance[2]) * 10000) chestTier[i] = 2;
            else chestTier[i] = 1;

            Action action = () => { };
            //artifactだったら
            if (UnityEngine.Random.Range(0, 2) == 0)
            {
                var factory = new ArtifactBuilder();
                var artifact = factory.BuildArtifact(new BronzeInfoSetting());
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
            recordedAction[i] = action;
        }
    }

}