using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class sword14 : A_SKILL,IPointerDownHandler
{
    public override float CoolTime { get => main.SR.warrior14; set => main.SR.warrior14 = value; }

    private void Awake()
    {
        AwakeSkill();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSkill();
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
        for (int i = 0; i < 14; i++)
        {
            yield return new WaitUntil(AttackCondition);
            if (main.ally.targetEnemy != null)
            {
                StartCoroutine(main.InstantiateAnimation(main.animationObject[1],
                    main.ally1.GetComponent<ALLY>().targetEnemy.GetComponent<RectTransform>(), main.skillSetController.DPS() * 0.5, 0, SKILL.DamageKind.physical));
            }
            else
            {
                yield return main.ally.SearchEnemy();
                StartCoroutine(main.InstantiateAnimation(main.animationObject[1],
                                main.ally1.GetComponent<ALLY>().SearchEnemy().GetComponent<RectTransform>(), main.skillSetController.DPS() * 0.5, 0, SKILL.DamageKind.physical));
            }

            yield return new WaitForSeconds(0.1f);
        }
    }
}
