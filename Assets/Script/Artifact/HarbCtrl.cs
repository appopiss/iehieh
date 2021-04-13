using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static ACHIEVEMENT.QuestList;

public class HarbCtrl : BASE {

    RectTransform allyRect;
	// Use this for initialization
	void Awake () {
		StartBASE();
        allyRect = main.ally1.GetComponent<RectTransform>();
	}

	// Use this for initialization
	void Start () {
        StartCoroutine(GetHarb());
        StartCoroutine(GetRainbowFish());
        StartCoroutine(GetChili());
	}

	// Update is called once per frame
	void Update () {
	}

    public bool MoveCondition()
    {
        bool auto;
        bool manual;
        auto = main.ally.condition == ALLY.Condition.MoveMode && main.GameController.isAuto;
        manual = !main.GameController.isAuto && main.ally.Direction(ALLY.direction.down) || main.ally.Direction(ALLY.direction.up) ||
            main.ally.Direction(ALLY.direction.right) || main.ally.Direction(ALLY.direction.left);
        return auto || manual;
    }


    bool CanRainbowFishFind()
    {
        if (main.S.isReinbowFishPurchase)
            return main.quests[(int)StrangeErrand].isSeen[3] && MoveCondition();
        else
            return main.quests[(int)StrangeErrand].isSeen[3] && MoveCondition() && main.GameController.ChallengeField.sprite == main.ChallengeSpriteAry[11];
    }
    public IEnumerator GetRainbowFish()
    {
        int randomNum;
        while (true)
        {
            yield return new WaitUntil(CanRainbowFishFind);
            if (main.S.isReinbowFishPurchase)
                randomNum = UnityEngine.Random.Range(0, 100000);
            else
                randomNum = UnityEngine.Random.Range(0, 1000000);
            if (!main.S.isRainbowFish)  
            {
                if (randomNum <= 10)
                {
                    getMaterial(ArtiCtrl.MaterialList.RainbowFish);
                    main.Log("Gain <color=orange>Rainbow Fish");
                    main.S.isRainbowFish = true;
                }
            }
            else
            {
                if (randomNum <= 3)
                {
                    getMaterial(ArtiCtrl.MaterialList.RainbowFish);
                    main.Log("Gain <color=orange>Rainbow Fish");
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    public IEnumerator GetChili()
    {
        while (true)
        {
            yield return new WaitUntil(() =>MoveCondition() && isRange(25, new Vector2(164, 85), allyRect.anchoredPosition)
            &&main.GameController.ChallengeField.sprite
            == main.ChallengeSpriteAry[7]&&!main.GameController.isChili);
            getMaterial(ArtiCtrl.MaterialList.RedChili);
            main.SoundEffectSource.PlayOneShot(main.sound.redChiliClip);
            main.Log("Gain <color=orange>Red Chili");
            main.GameController.isChili = true;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public double HerbChance()
    {
        if (!main.NewArtifacts[(int)ARTIFACT.ArtifactName.HerbloreGuide].isEquipped)
            return 0;
        else
            return 10000 * main.NewArtifacts[(int)ARTIFACT.ArtifactName.HerbloreGuide].GetComponent<ARTIFACT.Status>().GetValue();
    }

    int dropNum;
    public IEnumerator GetHarb()
    {
        while (true)
        {
            yield return new WaitUntil(MoveCondition);
            if (UnityEngine.Random.Range(0, 10000) < HerbChance())
            {
                dropNum = 1 + main.S.SR_level[(int)R_UPGRADE.SR_upgradeID.Loot];
                int randomNum = UnityEngine.Random.Range(0, 10000);
                if (randomNum <= 5000)
                {
                    getMaterial(ArtiCtrl.MaterialList.Herb);
                    if (!main.systemController.disableLootLog)
                    {
                        if (dropNum == 1)
                            main.Log("Gain <color=orange>Herb");
                        else
                            main.Log("Gain <color=orange>Herb * " + dropNum);

                    }
                }
                else if (randomNum <= 7500)
                {
                    getMaterial(ArtiCtrl.MaterialList.Berry);
                    if (!main.systemController.disableLootLog)
                    {
                        if (dropNum == 1)
                            main.Log("Gain <color=orange>Berry");
                        else
                            main.Log("Gain <color=orange>Berry * " + dropNum);

                    }
                }
                else if (randomNum <= 10000)
                {
                    getMaterial(ArtiCtrl.MaterialList.MagicSeed);
                    if (!main.systemController.disableLootLog)
                    {
                        if (dropNum == 1)
                            main.Log("Gain <color=orange>Magic Seed");
                        else
                            main.Log("Gain <color=orange>Magic Seed * " + dropNum);
                    }
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void getMaterial(ArtiCtrl.MaterialList material)
    {
        dropNum = 1 + main.S.SR_level[(int)R_UPGRADE.SR_upgradeID.Loot];
        main.ArtiCtrl.CurrentMaterial[material] += dropNum;
        //Debug.Log(main.ArtiCtrl.CurrentMaterial[material]);
        if (main.GameController.battleMode != GameController.BattleMode.challange)
        {
            main.DeathPanel.materials[material] += dropNum;
        }
        else
        {
            main.DeathPanel.C_materials[material] += dropNum;
        }
        if (material == ArtiCtrl.MaterialList.RedChili)
            main.S.TotalChiliGathered++;

        if (material == ArtiCtrl.MaterialList.RainbowFish)
            main.S.TotalReinbowFishGathered++;
    }
}
