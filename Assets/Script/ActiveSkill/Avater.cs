using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Avater : A_SKILL, IPointerDownHandler
{
    public override float CoolTime { get => main.SR.warrior14; set => main.SR.warrior14 = value; }
    public Ally_avater avater1;
    public Ally_avater avater2;

    private void Awake()
    {
        AwakeSkill();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSkill();
        StartCoroutine(ChangeSprite1());
        StartCoroutine(ChangeSprite2());
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

        avater1 = Instantiate(main.avaterPre, main.allyCanvas.transform);
        avater2 = Instantiate(main.avaterPre, main.allyCanvas.transform);

        avater1.hp = main.ally1.GetComponent<ALLY>().HP()*0.1;
        avater1.currentHp = main.ally1.GetComponent<ALLY>().HP()*0.1;
        avater1.atk = main.ally1.GetComponent<ALLY>().Atk();
        avater1.def = main.ally1.GetComponent<ALLY>().Def();
        avater1.mDef = main.ally1.GetComponent<ALLY>().MDef();
        avater1.mAtk = main.ally1.GetComponent<ALLY>().MAtk();
        avater1.speed = main.ally1.GetComponent<ALLY>().Speed();
        avater1.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(30, -30);

        avater2.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(-30, -30);
        avater2.hp = main.ally1.GetComponent<ALLY>().HP() * 0.1;
        avater2.currentHp = main.ally1.GetComponent<ALLY>().HP()*0.1;
        avater2.atk = main.ally1.GetComponent<ALLY>().Atk();
        avater2.def = main.ally1.GetComponent<ALLY>().Def();
        avater2.mDef = main.ally1.GetComponent<ALLY>().MDef();
        avater2.mAtk = main.ally1.GetComponent<ALLY>().MAtk();
        avater2.speed = main.ally1.GetComponent<ALLY>().Speed();
        yield return null;
    }

    public IEnumerator ChangeSprite1()
    {
        while (true)
        {
            if (avater1 != null)
            {
                avater1.GetComponent<Image>().sprite = null;
                avater1.GetComponent<Image>().sprite = main.ally1.GetComponent<ALLY>().sprites[4];
                yield return new WaitForSeconds(0.5f);
                if (avater1 != null)
                {
                    avater1.GetComponent<Image>().sprite = null;
                    avater1.GetComponent<Image>().sprite = main.ally1.GetComponent<ALLY>().sprites[5];
                    yield return new WaitForSeconds(0.5f);
                }
            }
            else
            {
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
    public IEnumerator ChangeSprite2()
    {
        while (true)
        {
            if (avater2 != null)
            {
                avater2.GetComponent<Image>().sprite = null;
                avater2.GetComponent<Image>().sprite = main.ally1.GetComponent<ALLY>().sprites[4];
                yield return new WaitForSeconds(0.5f);
                if (avater2 != null)
                {
                    avater2.GetComponent<Image>().sprite = null;
                    avater2.GetComponent<Image>().sprite = main.ally1.GetComponent<ALLY>().sprites[5];
                    yield return new WaitForSeconds(0.5f);
                }
            }
            else
            {
                yield return new WaitForSeconds(0.5f);
            }
        }
    }

}
