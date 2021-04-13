using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using static UsefulMethod;
using static SkillSetController;

public class SkillSet2 : SKILLSET, IPointerEnterHandler, IPointerExitHandler
{
    public override SKILL currentSkill { get => main.SR.currentGrobalSkill[slotId]; set => main.SR.currentGrobalSkill[slotId] = value; }
    public override bool canEquipped { get => main.S.SlotG_canEquipped[slotId]; set => main.S.SlotG_canEquipped[slotId] = value; }
    public override int saveSkillId { get => main.SR.saveGrobalSkillId[slotId]; set => main.SR.saveGrobalSkillId[slotId] = value; }
    //public override bool canEquipped { get => main.S.canEquipped[slotId]; set => main.S.canEquipped[slotId] = value; }

    public override void SkillSlotSet()
    {
        if (canEquipped && !isSameEquipped())
        {
            if (CanSkillSet())
            {
                currentSkill = main.skillSetController.chosenSkill;
                main.sound.MustPlaySound(main.sound.equipClip);
                for (int i = 0; i < 30; i++)
                {
                    if (currentSkill == main.skillsForCoolTime[i])
                    {
                        saveSkillId = i+1;
                    }
                }
                SkillSetSave();
                if (!main.S.isGlobalSlotEquipped)
                {
                    main.S.isGlobalSlotEquipped = true;
                }
                main.ally1.GetComponent<ALLY>().condition = ALLY.Condition.MoveMode;
                if (main.skillSetController.mouseObject != null)
                    Destroy(main.skillSetController.mouseObject);
            }
        }
    }

    public override void SkillSetSave()
    {
        switch (main.S.job)
        {
            case ALLY.Job.Warrior:
                switch (main.S.SkillSetSaveID)
                {
                    case 0:
                        main.S.WarSaveSkillId1[slotId + 20] = saveSkillId;
                        break;
                    case 1:
                        main.S.WarSaveSkillId2[slotId + 20] = saveSkillId;
                        break;
                    case 2:
                        main.S.WarSaveSkillId3[slotId + 20] = saveSkillId;
                        break;
                    case 3:
                        main.S.WarSaveSkillId4[slotId + 20] = saveSkillId;
                        break;
                    case 4:
                        main.S.WarSaveSkillId5[slotId + 20] = saveSkillId;
                        break;
                    default:
                        break;
                }
                break;
            case ALLY.Job.Wizard:
                switch (main.S.SkillSetSaveID)
                {
                    case 0:
                        main.S.WizSaveSkillId1[slotId + 20] = saveSkillId;
                        break;
                    case 1:
                        main.S.WizSaveSkillId2[slotId + 20] = saveSkillId;
                        break;
                    case 2:
                        main.S.WizSaveSkillId3[slotId + 20] = saveSkillId;
                        break;
                    case 3:
                        main.S.WizSaveSkillId4[slotId + 20] = saveSkillId;
                        break;
                    case 4:
                        main.S.WizSaveSkillId5[slotId + 20] = saveSkillId;
                        break;
                    default:
                        break;
                }
                break;
            case ALLY.Job.Angel:
                switch (main.S.SkillSetSaveID)
                {
                    case 0:
                        main.S.AngSaveSkillId1[slotId + 20] = saveSkillId;
                        break;
                    case 1:
                        main.S.AngSaveSkillId2[slotId + 20] = saveSkillId;
                        break;
                    case 2:
                        main.S.AngSaveSkillId3[slotId + 20] = saveSkillId;
                        break;
                    case 3:
                        main.S.AngSaveSkillId4[slotId + 20] = saveSkillId;
                        break;
                    case 4:
                        main.S.AngSaveSkillId5[slotId + 20] = saveSkillId;
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }

    }

    public override IEnumerator SkillSetLoad()
    {
        while (true)
        {
            yield return new WaitUntil(() => main.skillSetController.isPushedSkillSetButton == true);
            switch (main.S.job)
            {
                case ALLY.Job.Warrior:
                    switch (main.S.SkillSetSaveID)
                    {
                        case 0:
                            saveSkillId = main.S.WarSaveSkillId1[slotId + 20];
                            break;
                        case 1:
                            saveSkillId = main.S.WarSaveSkillId2[slotId + 20];
                            break;
                        case 2:
                            saveSkillId = main.S.WarSaveSkillId3[slotId + 20];
                            break;
                        case 3:
                            saveSkillId = main.S.WarSaveSkillId4[slotId + 20];
                            break;
                        case 4:
                            saveSkillId = main.S.WarSaveSkillId5[slotId + 20];
                            break;
                        default:
                            break;
                    }
                    break;
                case ALLY.Job.Wizard:
                    switch (main.S.SkillSetSaveID)
                    {
                        case 0:
                            saveSkillId = main.S.WizSaveSkillId1[slotId + 20];
                            break;
                        case 1:
                            saveSkillId = main.S.WizSaveSkillId2[slotId + 20];
                            break;
                        case 2:
                            saveSkillId = main.S.WizSaveSkillId3[slotId + 20];
                            break;
                        case 3:
                            saveSkillId = main.S.WizSaveSkillId4[slotId + 20];
                            break;
                        case 4:
                            saveSkillId = main.S.WizSaveSkillId5[slotId + 20];
                            break;
                        default:
                            break;
                    }
                    break;
                case ALLY.Job.Angel:
                    switch (main.S.SkillSetSaveID)
                    {
                        case 0:
                            saveSkillId = main.S.AngSaveSkillId1[slotId + 20];
                            break;
                        case 1:
                            saveSkillId = main.S.AngSaveSkillId2[slotId + 20];
                            break;
                        case 2:
                            saveSkillId = main.S.AngSaveSkillId3[slotId + 20];
                            break;
                        case 3:
                            saveSkillId = main.S.AngSaveSkillId4[slotId + 20];
                            break;
                        case 4:
                            saveSkillId = main.S.AngSaveSkillId5[slotId + 20];
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            SkillChange();
        }
    }

    public bool CanSkillSet()
    {
        if (!main.MissionMileStone.IsGlobalSkill())
        {
            for (int i = main.jobNum; i < main.jobNum + 10; i++)
            {
                if (main.skillSetController.chosenSkill == main.skillsForCoolTime[i])
                {
                    return false;
                }
            }
            for (int i = 30; i < 60; i++)
            {
                if (main.skillSetController.chosenSkill == main.skillsForCoolTime[i])
                    return false;
            }
            return true;
        }
        else
        {
            for (int i = 30; i < 60; i++)
            {
                if (main.skillSetController.chosenSkill == main.skillsForCoolTime[i])
                    return false;
            }
            return true;
        }
    }

    public override void SkillSetUpdate()
    {
        //スキルスロット解禁
        if (!canEquipped)
        {
            thisImage.sprite = null;
            thisImage.sprite = main.canNotEquipSprite;
        }
        else
        {
            if (currentSkill == null)
            {
                thisImage.sprite = null;
                thisImage.sprite = main.SkillSlotEmptyImage;
            }
            else
            {
                thisImage.sprite = null;
                thisImage.sprite = main.Sprites[currentSkill.skillIndex];
            }

        }
        if (isOver)
        {
            if (Input.GetMouseButton(1))//右クリック
            {
                currentSkill = null;
                saveSkillId = 0;
                SkillSetSave();
            }

        }


        //}

        //射程距離の実装
        if (isOver && currentSkill != null)
        {
            setActive(main.ally1.transform.GetChild(1).gameObject);
            main.ally1.transform.GetChild(1).GetComponent<RectTransform>().sizeDelta = new Vector2(currentSkill.attackRange, currentSkill.attackRange) * 2;
        }




        //クールタイムを反映させる．
        if (currentSkill != null)
        {
            gameObject.transform.GetChild(1).GetComponent<RectTransform>().localScale = new Vector3(1, Mathf.Clamp(currentSkill.currentCoolTime, 0, 1));
        }
        else
            gameObject.transform.GetChild(1).GetComponent<RectTransform>().localScale = oneO;
    }


    // Use this for initialization
    void Awake()
    {
        StartBASE();
        SkillSetAwake();
    }

    // Use this for initialization
    void Start()
    {
        SkillSetStart();
        gameObject.GetComponent<Plain_PopText>().ActiveCondition = () => currentSkill == null;
        popText = gameObject.GetComponent<Plain_PopText>();
    }
    Plain_PopText popText;
    // Update is called once per frame
    void Update()
    {
        SkillSetUpdate();
        if (canEquipped && currentSkill == null)
        {
            popText.text = "Put another class skill here";
        }
        else
        {
            setFalse(popText.window);
        }
    }
}
