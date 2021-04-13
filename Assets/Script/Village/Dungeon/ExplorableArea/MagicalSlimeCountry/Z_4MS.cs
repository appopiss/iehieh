using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Z_4MS : DUNGEON
{
    // Use this for initialization
    void Awake () {
        AwakeDungeon(Main.Dungeon.Z_MS4, "Slime Guard Station", 0, 56, 900, true,"6-4");
        gameObject.AddComponent<M_clear>().awake(215);
        gameObject.AddComponent<M_hp>().awake(216, 0.95f);
        gameObject.AddComponent<M_onlyBase>().awake(217);
        gameObject.AddComponent<M_material>().awake(218, ArtiCtrl.MaterialList.OddMagicalHat, 100);
        gameObject.AddComponent<M_time>().awake(219, 1);

    }

    // Use this for initialization
    void Start () {
        StartDungeon();
        areaDifficultyFactor = 420;
    }

    // Update is called once per frame
    void Update () {
        UpdateDungeon();

            explain = "Despite every fiber of your being telling you to leave this place and never look back, you edge forward into town. The first stop is the gate guard station. Still no sign of any solid being anywhere, aside from the bits and pieces of skeletons that you presume were once the guards here. However, there are more colorful slimes that seem hellbent on making you look like those skeletons. They're intelligent enough to use magic, but they can't even say hello first?";
        if (!isDungeon)
        {
            rewardExplain = "- Ruined Spellbook\n- <color=green>Odd Magical Hat";
        }
        else
        {
            rewardExplain = "- Ruined Spellbook";
        }
    }

    public override void GetReward()
    {
        main.Log("<color=orange>Area Clear !");
        getMaterial(ArtiCtrl.MaterialList.RuinedSpellBook);
        main.Log("Gain <color=green>Ruined Spellbook");
        if (!isDungeon)
        {
            getMaterial(ArtiCtrl.MaterialList.OddMagicalHat);
            main.Log("Gain <color=green>Odd Magical Hat");
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
                    InstantiateSeven(ENEMY.MonsterTable.RareSlimes, new Vector3(0, -20));
                    InstantiateEnemy(ChooseEnemyByTable(ENEMY.MonsterTable.BossMSlimes), new Vector3(0, 100));
                    break;
                default:
                    InstantiateSquare(ENEMY.MonsterTable.CommonBats, new Vector3(0, 20), 5, 50);
                    break;
            }
        }
    }


}
