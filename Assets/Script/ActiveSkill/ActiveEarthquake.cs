using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ActiveEarthquake : A_SKILL, IPointerDownHandler
{
    public override float CoolTime { get => main.SR.earthquake; set => main.SR.earthquake = value; }

    private void Awake()
    {
        AwakeSkill();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSkill();
        cooltimeFactor = main.skillsForCoolTime[31].CooltimeFactor();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSkill();
    }

    public override bool Condition()
    {
        return base.Condition();
    }

    public override IEnumerator DoSkill()
    {
        if (main.missionCondition.whenActiveSkill())
        {
            if (!main.ZoneCtrl.isHidden)
                main.S.activeSkillAt15 += 1;
            else
                main.S.hidden_activeSkillAt15 += 1;
        }

        main.ally1.GetComponent<ALLY>().condition = ALLY.Condition.BattleMode;
        GameObject game;
        game = Instantiate(main.animationObject[58], main.Transforms[3]);
        game.GetComponent<Attack>().damage = main.skillsForCoolTime[31].Damage();
        game.GetComponent<Attack>().damageKind = SKILL.DamageKind.physical;
        game.GetComponent<Attack>().thisDebuff = Main.Debuff.knockback;
        yield return new WaitForSeconds(game.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        Destroy(game);
        game = Instantiate(main.animationObject[58], main.Transforms[3]);
        game.GetComponent<Attack>().damage = main.skillsForCoolTime[31].Damage();
        game.GetComponent<Attack>().damageKind = SKILL.DamageKind.physical;
        game.GetComponent<Attack>().thisDebuff = Main.Debuff.atkDown;
        yield return new WaitForSeconds(game.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        Destroy(game);
        if (main.skillsForCoolTime[31].attackNum >= 3)
        {
            game = Instantiate(main.animationObject[58], main.Transforms[3]);
            game.GetComponent<Attack>().damage = main.skillsForCoolTime[31].Damage();
            game.GetComponent<Attack>().damageKind = SKILL.DamageKind.physical;
            game.GetComponent<Attack>().thisDebuff = Main.Debuff.knockback;
            yield return new WaitForSeconds(game.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
            Destroy(game);
            if (main.skillsForCoolTime[31].attackNum >= 4)
            {
                game = Instantiate(main.animationObject[58], main.Transforms[3]);
                game.GetComponent<Attack>().damage = main.skillsForCoolTime[31].Damage();
                game.GetComponent<Attack>().damageKind = SKILL.DamageKind.physical;
                game.GetComponent<Attack>().thisDebuff = Main.Debuff.mAtkDown;
                yield return new WaitForSeconds(game.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
                Destroy(game);
                if (main.skillsForCoolTime[31].attackNum >= 5)
                {
                    game = Instantiate(main.animationObject[58], main.Transforms[3]);
                    game.GetComponent<Attack>().damage = main.skillsForCoolTime[31].Damage();
                    game.GetComponent<Attack>().damageKind = SKILL.DamageKind.physical;
                    game.GetComponent<Attack>().thisDebuff = Main.Debuff.knockback;
                    yield return new WaitForSeconds(game.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
                    Destroy(game);
                }
            }
        }

        main.ally1.GetComponent<ALLY>().condition = ALLY.Condition.MoveMode;

    }
}
