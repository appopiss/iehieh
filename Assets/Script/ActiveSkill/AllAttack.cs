using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AllAttack : A_SKILL, IPointerDownHandler
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

        for (int i = 0; i < 3; i++)
        {
            main.ally1.GetComponent<ALLY>().condition = ALLY.Condition.BattleMode;
            yield return main.FillSlider(main.ally1.GetComponent<ALLY>().chantingSlider, 2.0f);
            List<ENEMY> attackableList = new List<ENEMY>();
            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("enemy"))
            {
                attackableList.Add(enemy.GetComponent<ENEMY>());
            }
            if (attackableList.Count == 0) { yield break; }

            foreach (ENEMY enemy in attackableList)
            {
                StartCoroutine(main.InstantiateAnimation(main.animationObject[1],
                enemy.GetComponent<RectTransform>(), main.skillSetController.DPS() * 1.2, 0, SKILL.DamageKind.magical));
            }
            main.ally1.GetComponent<ALLY>().condition = ALLY.Condition.MoveMode;
        }
    }
}
