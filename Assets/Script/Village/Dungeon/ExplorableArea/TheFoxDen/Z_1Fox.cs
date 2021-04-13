using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_1Fox : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_fox1, "Hidden Passage",29, 44, 0, true,"5-1");
        gameObject.AddComponent<M_clear>().awake(160);
        gameObject.AddComponent<M_hp>().awake(161, 0.95f);
        gameObject.AddComponent<M_material>().awake(162, ArtiCtrl.MaterialList.FoxTail, 1000);
        gameObject.AddComponent<M_gold>().awake(163, 450000);
        gameObject.AddComponent<M_onlyBase>().awake(164);
    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 155;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "You heard a rumor started by a local hunter about a strange passage underneath a large tree that he had found while hunting foxes. You decided to check it out yourself, because you can't seem to help but explore the most dangerous sounding places you hear about. Following the directions to the large tree, you find the hidden passage that spirals down under the roots of the tree. Having crawled into the hole, you noticed that the deeper you went, the larger the tunnel became to where you could eventually stand up. Despite being able to still see out of the hole at the surface, you're fairly certain the hole did not widen at this depth that you would be able to stand. How very curious! you think to yourself. You have no idea whether you are shrinking or the tunnel is growing, but your sense of adventure is invigorated and you now want to know where this passage leads. The thought occurs to you that had your clothes not shrunk with you, that you'd be exploring this tunnel naked.";
        if (!isDungeon)
        {
            rewardExplain = "- Fox Pelt\n- <color=green>Monster Fluid * 200</color>";
        }
        else
        {
            rewardExplain = "- Fox Pelt";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.FairyDust);
        main.Log("Gain <color=green>Fox Pelt");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.MonsterFluid);
            main.Log("Gain <color=green>Monster Fluid * 100");
            isDungeon = true;
            main.TutorialController.ResetZone();
            main.TutorialController.ShowZone();
        }
    }
    public override void InstantiateEnemies(int dungeonFloorNum)
    {
        if (main.GameController.currentDungeon == dungeon)
        {
            switch (dungeonFloorNum)
            {
                case 0:
                    InstantiateHolLine(ENEMY.MonsterTable.NormalFoxes, new Vector3(0, 160), 3, 120);
                    InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 80), 3, 100);
                    InstantiateAround4(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 0));
                    InstantiateAround3(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -80));
                    break;
                case 9:
                    InstantiateSquare(ENEMY.MonsterTable.NormalFoxes, new Vector3(0, 30), 4, 100);
                    break;
                case 19:
                    InstantiateSquare(ENEMY.MonsterTable.NormalFoxes, new Vector3(0, 30), 5, 80);
                    break;
                case 29:
                    InstantiateSquare(ENEMY.MonsterTable.NormalFoxes, new Vector3(0, 30), 6, 60);
                    break;
                default:
                    rand = UnityEngine.Random.Range(0, 5);
                    if (rand == 1)
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.NormalFoxes, new Vector3(0, 160), 3, 120);
                        InstantiateAround6(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 120));
                        InstantiateAround7(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 0));
                    }
                    else if (rand == 2)
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.NormalFoxes, new Vector3(0, 160), 4, 100);
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 80), 3, 100);
                        InstantiateAround4(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 0));
                        InstantiateAround5(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -80));
                    }
                    else if (rand == 3)
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 160), 3, 100);
                        InstantiateHolLine(ENEMY.MonsterTable.NormalFoxes, new Vector3(0, 80), 4, 100);
                        InstantiateAround4(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 0));
                        InstantiateAround5(ENEMY.MonsterTable.UncommonBats, new Vector3(0, -80));
                    }
                    else
                    {
                        InstantiateHolLine(ENEMY.MonsterTable.NormalFoxes, new Vector3(0, 160), 3, 120);
                        InstantiateHolLine(ENEMY.MonsterTable.UncommonBats, new Vector3(0, 80), 3, 100);
                        InstantiateAround4(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, 0));
                        InstantiateAround3(ENEMY.MonsterTable.UncommonSlimes, new Vector3(0, -80));
                    }
                    break;
            }
        }

    }
    int rand;
}
