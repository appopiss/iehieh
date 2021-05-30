using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IdleLibrary;
using IdleLibrary.Inventory;
using Sirenix.Serialization;
using System;
using static UsefulMethod;

//最も簡単な例
//どこのtierに属するかと何をするかを決める？
public class ArtifactReward : IExpeditionAction
{
    [OdinSerialize] private Action[] recordedAction;

    public void OnClaim()
    {
        int tier1Count = 0;
        int tier2Count = 0;
        int tier3Count = 0;

        for (int i = 0; i < chestTier.Length; i++)
        {
            switch (chestTier[i])
            {
                case 1: BASE.main.SO.tier1chest.RegisterAction(recordedAction[i]); tier1Count++; break;
                case 2: BASE.main.SO.tier2chest.RegisterAction(recordedAction[i]); tier2Count++; break;
                case 3: BASE.main.SO.tier3chest.RegisterAction(recordedAction[i]); tier3Count++; break;
            }
        }
        BASE.main.Confirm(optStr + "<sprite=\"chests\" index=0> x " + tDigit(tier1Count) + "\n" +
            "<sprite=\"chests\" index=1> x " + tDigit(tier2Count) + "\n" +
            "<sprite=\"chests\" index=2> x " + tDigit(tier3Count));
    }

    //デリゲートはローカル変数を保存しないので、事前に抽選結果は保存しておく必要あり
    [OdinSerialize] private List<Artifact> recordArtifact = new List<Artifact>();
    
    [OdinSerialize] private (ArtifactMaterial.ID material, double num) recordMaterial;
    [OdinSerialize] private int[] chestTier;

    public void OnStart(int chestLotteryNum, float[] chestChance)
    {
        recordArtifact = new List<Artifact>();
        chestTier = new int[chestLotteryNum];
        recordedAction = new Action[chestLotteryNum];
        for (int i = 0; i < chestLotteryNum; i++)
        {
            int rand = UnityEngine.Random.Range(0, 10000);
            Debug.Log(chestChance[2]);
            if (rand < chestChance[2] * 10000) chestTier[i] = 3;
            else if (rand < (chestChance[1] + chestChance[2]) * 10000) chestTier[i] = 2;
            else chestTier[i] = 1;

            Action action = () => { };
            int resultKind = ChooseRewardKind(chestTier[i]);
            if(resultKind == 0)
            {
                var factory = new ArtifactBuilder();
                var artifact = chestTier[i] switch
                {
                    1 => factory.BuildArtifact(new BronzeInfoSetting()),
                    2 => factory.BuildArtifact(new SilverInfoSetting()),
                    3 => factory.BuildArtifact(new GoldInfoSetting()),
                    _ => factory.BuildArtifact(new BronzeInfoSetting())
                };
                //ここで保存
                recordArtifact.Add(artifact);
                var tempArtifact = recordArtifact[recordArtifact.Count - 1];
                action = () =>
                {
                    BASE.main.Confirm($"You got new artifact!\n" + tempArtifact.Text());
                    BASE.main.inventory_mono.inventoryInfo.inventory.SetItemByOrder(tempArtifact);
                };
            }
            else
            {
                //なにかしらの方法でrecordMaterialを決める
                recordMaterial = chestTier[i] switch
                {
                    1 => (object)UnityEngine.Random.Range(0, 10000) switch
                    {
                        int prob when prob <= 3300 => (ArtifactMaterial.ID.MysteriousStone, UnityEngine.Random.Range(1,6)),
                        int prob when prob <= 6600 => (ArtifactMaterial.ID.MysteriousCrystal, UnityEngine.Random.Range(1, 6)),
                        int prob when prob <= 10000 => (ArtifactMaterial.ID.MysteriousLeaf, UnityEngine.Random.Range(1, 6)),
                        _ => (ArtifactMaterial.ID.MysteriousStone, 1),
                    },

                    2 => (object)UnityEngine.Random.Range(0, 10000) switch
                    {
                        int prob when prob <= 3300 => (ArtifactMaterial.ID.MysteriousStone, UnityEngine.Random.Range(5, 11)),
                        int prob when prob <= 6600 => (ArtifactMaterial.ID.MysteriousCrystal, UnityEngine.Random.Range(5, 11)),
                        int prob when prob <= 10000 => (ArtifactMaterial.ID.MysteriousLeaf, UnityEngine.Random.Range(5, 11)),
                        _ => (ArtifactMaterial.ID.MysteriousStone, 1),
                    },

                    3 => (object)UnityEngine.Random.Range(0, 10000) switch
                    {
                        int prob when prob <= 3300 => (ArtifactMaterial.ID.MysteriousStone, UnityEngine.Random.Range(10, 21)),
                        int prob when prob <= 6600 => (ArtifactMaterial.ID.MysteriousCrystal, UnityEngine.Random.Range(10, 21)),
                        int prob when prob <= 10000 => (ArtifactMaterial.ID.MysteriousLeaf, UnityEngine.Random.Range(10, 21)),
                        _ => (ArtifactMaterial.ID.MysteriousStone, 1),
                    },
                    _ => (ArtifactMaterial.ID.MysteriousStone, 1)
                };
                action = () =>
                {
                    BASE.main.Confirm($"You got some materials for artifacts!");
                    BASE.main.SO.artifactMaterials[(int)recordMaterial.material] += recordMaterial.num;
                };
            }

            recordedAction[i] = action;
        }
    }

    private int ChooseRewardKind(int tier)
    {
        var rand = UnityEngine.Random.Range(0, 10000);
        var result = tier switch
        {
            0 => (object)rand switch
            {
                int i when i <= 2000 => 0,
                int i when i <= 7000 => 1,
                int i when i <= 9000 => 2,
                int i when i <= 10000 => 3,
                _ => 0
            },
            1 => (object)rand switch
            {
                int i when i <= 3000 => 0,
                int i when i <= 6000 => 1,
                int i when i <= 9000 => 2,
                int i when i <= 10000 => 3,
                _ => 0
            },
            2 => (object)rand switch
            {
                int i when i <= 5000 => 0,
                int i when i <= 6500 => 1,
                int i when i <= 8000 => 2,
                int i when i <= 10000 => 3,
                _ => 0
            },
            _ => 0
        };
        return result;
    }

}