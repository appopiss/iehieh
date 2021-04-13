using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class NINETALES : ENEMY {

    int rand;
    public override sealed void Attacking()
    {
        if (CanAttack())
        {
            rand = UnityEngine.Random.Range(0, 10000);
            if (rand < 1000)
            {
                StartCoroutine(I_AttackObject(main.animationObject[19], targetEnemyPosition, MATK(), 0, SKILL.DamageKind.magical, Main.Debuff.mAtkDown));
            }
            else if (rand >=1000 && rand < 8000)
            {
                StartCoroutine(InstantiateFox());
            }
            else
            {
                StartCoroutine(I_AttackObject(main.animationObject[19], targetEnemyPosition, MATK(), 0, SKILL.DamageKind.magical));
            }

        }
    }

    int rand2;
    //個別に攻撃を書きたいときは，このようなコルーチンを書く．（必ず最初にFillSlider()を書く．）
    public IEnumerator InstantiateFox()
    {
        ENEMY game;
        rand2 = UnityEngine.Random.Range(0, 8);
        yield return FillSlider();
        if (rand2 == 0)
            game = main.GameController.InstantiateEnemy(65, new Vector3(UnityEngine.Random.Range(-160, 160), 160), false);
        else if (rand2 == 1)
            game = main.GameController.InstantiateEnemy(66, new Vector3(UnityEngine.Random.Range(-160, 160), 160), false);
        else if (rand2 == 2)
            game = main.GameController.InstantiateEnemy(67, new Vector3(UnityEngine.Random.Range(-160, 160), 160), false);
        else if (rand2 == 3)
            game = main.GameController.InstantiateEnemy(68, new Vector3(UnityEngine.Random.Range(-160, 160), 160), false);
        else if (rand2 == 4)
            game = main.GameController.InstantiateEnemy(69, new Vector3(UnityEngine.Random.Range(-160, 160), 160), false);
        else if (rand2 == 5)
            game = main.GameController.InstantiateEnemy(70, new Vector3(UnityEngine.Random.Range(-160, 160), 160), false);
        else if (rand2 == 6)
            game = main.GameController.InstantiateEnemy(71, new Vector3(UnityEngine.Random.Range(-160, 160), 160), false);
        else if (rand2 == 7)
            game = main.GameController.InstantiateEnemy(72, new Vector3(UnityEngine.Random.Range(-160, 160), 160), false);
        else
            game = main.GameController.InstantiateEnemy(73, new Vector3(UnityEngine.Random.Range(-160, 160), 160), false);
        game.dungeonLevelFactor = dungeonLevelFactor;
        game.areaDifficultyFactor = areaDifficultyFactor;
        game.dungeonDifficultyFactor = dungeonDifficultyFactor;

    }

    public override void SetAbnormal(Attack attack)
    {
        attack.abnormalDamage = 0.01;//50%の意味
    }
}
