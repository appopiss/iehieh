using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using static UsefulMethod;
using static SkillSetController;

public class SKILLSET : BASE, IPointerEnterHandler, IPointerExitHandler
{

    public Button skillSet1aButton;
    //public SKILL currentSkill { get => main.SR.currentSkill[slotId]; set => main.SR.currentSkill[slotId] = value; }
    public virtual SKILL currentSkill { get; set; }
    //slotId 0...真ん中のスキル 1~6 左側 7~14 右側
    public virtual int saveSkillId { get; set; }
    public int slotId;
    public bool isOver;
    public virtual bool canEquipped { get; set; }
    public Image thisImage;
    Image rangeImage;


    public virtual void SkillSlotSet()
    {
        if (canEquipped && !isSameEquipped())
        {
            for (int i = main.jobNum; i < main.jobNum + 10; i++)
            {
                if (main.skillSetController.chosenSkill == main.skillsForCoolTime[i] && slotId != 0)
                {
                    currentSkill = main.skillSetController.chosenSkill;
                    main.sound.MustPlaySound(main.sound.equipClip);
                    saveSkillId = i+1;
                    SkillSetSave();
                    main.ally.condition = ALLY.Condition.MoveMode;
                    if (main.skillSetController.mouseObject != null)
                        Destroy(main.skillSetController.mouseObject);
                    if (!main.TutorialController.isSkillSet)
                    {
                        //main.TutorialController.ManualToggle.gameObject.GetComponent<RectTransform>().anchoredPosition += new Vector2(-10000, 0);
                        main.TutorialController.isSkillSet = true;
                        main.TutorialController.ResetMenu();
                        main.TutorialController.ShowMenu();
                        StartCoroutine(main.InstantiateLogText("New Content\n<size=12>\"EXPLORE\"<size=10> is Unleashed!",main.ChallengeSpriteAry[1]));
                    }
                }
            }

            for (int i = main.jobNum; i < main.jobNum + 4; i++)//これはスキルが増えるたびに+を増やす
            {
                if (main.skillSetController.chosenSkill == main.skillsForCoolTime[30+i] && slotId != 0)
                {
                    currentSkill = main.skillSetController.chosenSkill;
                    main.sound.MustPlaySound(main.sound.equipClip);
                    saveSkillId = 30+i + 1;
                    SkillSetSave();
                    main.ally.condition = ALLY.Condition.MoveMode;
                    if (main.skillSetController.mouseObject != null)
                        Destroy(main.skillSetController.mouseObject);
                }
            }

            //if (main.jobNum == 0 & main.skillSetController.chosenSkill == main.skillsForCoolTime[30] && slotId != 0)
            //{
            //    currentSkill = main.skillSetController.chosenSkill;
            //    main.sound.MustPlaySound(main.sound.equipClip);
            //    saveSkillId = 30 + 1;
            //    SkillSetSave();
            //    main.ally.condition = ALLY.Condition.MoveMode;
            //    if (main.skillSetController.mouseObject != null)
            //        Destroy(main.skillSetController.mouseObject);
            //}
            //if (main.jobNum == 10 & main.skillSetController.chosenSkill == main.skillsForCoolTime[40] && slotId != 0)
            //{
            //    currentSkill = main.skillSetController.chosenSkill;
            //    main.sound.MustPlaySound(main.sound.equipClip);
            //    saveSkillId = 40 + 1;
            //    SkillSetSave();
            //    main.ally.condition = ALLY.Condition.MoveMode;
            //    if (main.skillSetController.mouseObject != null)
            //        Destroy(main.skillSetController.mouseObject);
            //}
            //if (main.jobNum == 20 & main.skillSetController.chosenSkill == main.skillsForCoolTime[50] && slotId != 0)
            //{
            //    currentSkill = main.skillSetController.chosenSkill;
            //    main.sound.MustPlaySound(main.sound.equipClip);
            //    saveSkillId = 50 + 1;
            //    SkillSetSave();
            //    main.ally.condition = ALLY.Condition.MoveMode;
            //    if (main.skillSetController.mouseObject != null)
            //        Destroy(main.skillSetController.mouseObject);
            //}

        }

    }

    public bool isSameEquipped()
    {
        for (int i = 0; i < main.skillSlotCanvasAry.Length; i++)
        {
            if (main.skillSlotCanvasAry[i].currentSkill == main.skillSetController.chosenSkill)
            {
                return true;
            }
        }
        return false;
    }
    public virtual void SkillSetSave()
    {
        if (slotId == 0)
            return;

        switch (main.S.job)
        {
            case ALLY.Job.Warrior:
                switch (main.S.SkillSetSaveID)
                {
                    case 0:
                        main.S.WarSaveSkillId1[slotId] = saveSkillId;
                        break;
                    case 1:
                        main.S.WarSaveSkillId2[slotId] = saveSkillId;
                        break;
                    case 2:
                        main.S.WarSaveSkillId3[slotId] = saveSkillId;
                        break;
                    case 3:
                        main.S.WarSaveSkillId4[slotId] = saveSkillId;
                        break;
                    case 4:
                        main.S.WarSaveSkillId5[slotId] = saveSkillId;
                        break;
                    default:
                        break;
                }
                break;
            case ALLY.Job.Wizard:
                switch (main.S.SkillSetSaveID)
                {
                    case 0:
                        main.S.WizSaveSkillId1[slotId] = saveSkillId;
                        break;
                    case 1:
                        main.S.WizSaveSkillId2[slotId] = saveSkillId;
                        break;
                    case 2:
                        main.S.WizSaveSkillId3[slotId] = saveSkillId;
                        break;
                    case 3:
                        main.S.WizSaveSkillId4[slotId] = saveSkillId;
                        break;
                    case 4:
                        main.S.WizSaveSkillId5[slotId] = saveSkillId;
                        break;
                    default:
                        break;
                }
                break;
            case ALLY.Job.Angel:
                switch (main.S.SkillSetSaveID)
                {
                    case 0:
                        main.S.AngSaveSkillId1[slotId] = saveSkillId;
                        break;
                    case 1:
                        main.S.AngSaveSkillId2[slotId] = saveSkillId;
                        break;
                    case 2:
                        main.S.AngSaveSkillId3[slotId] = saveSkillId;
                        break;
                    case 3:
                        main.S.AngSaveSkillId4[slotId] = saveSkillId;
                        break;
                    case 4:
                        main.S.AngSaveSkillId5[slotId] = saveSkillId;
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }

    }

    public virtual IEnumerator SkillSetLoad()
    {
        while (true)
        {
            if (slotId == 0)
                break;
            yield return new WaitUntil(() => main.skillSetController.isPushedSkillSetButton == true);
            switch (main.S.job)
            {
                case ALLY.Job.Warrior:
                    switch (main.S.SkillSetSaveID)
                    {
                        case 0:
                            saveSkillId = main.S.WarSaveSkillId1[slotId];
                            break;
                        case 1:
                            saveSkillId = main.S.WarSaveSkillId2[slotId];
                            break;
                        case 2:
                            saveSkillId = main.S.WarSaveSkillId3[slotId];
                            break;
                        case 3:
                            saveSkillId = main.S.WarSaveSkillId4[slotId];
                            break;
                        case 4:
                            saveSkillId = main.S.WarSaveSkillId5[slotId];
                            break;
                        default:
                            break;
                    }
                    break;
                case ALLY.Job.Wizard:
                    switch (main.S.SkillSetSaveID)
                    {
                        case 0:
                            saveSkillId = main.S.WizSaveSkillId1[slotId];
                            break;
                        case 1:
                            saveSkillId = main.S.WizSaveSkillId2[slotId];
                            break;
                        case 2:
                            saveSkillId = main.S.WizSaveSkillId3[slotId];
                            break;
                        case 3:
                            saveSkillId = main.S.WizSaveSkillId4[slotId];
                            break;
                        case 4:
                            saveSkillId = main.S.WizSaveSkillId5[slotId];
                            break;
                        default:
                            break;
                    }
                    break;
                case ALLY.Job.Angel:
                    switch (main.S.SkillSetSaveID)
                    {
                        case 0:
                            saveSkillId = main.S.AngSaveSkillId1[slotId];
                            break;
                        case 1:
                            saveSkillId = main.S.AngSaveSkillId2[slotId];
                            break;
                        case 2:
                            saveSkillId = main.S.AngSaveSkillId3[slotId];
                            break;
                        case 3:
                            saveSkillId = main.S.AngSaveSkillId4[slotId];
                            break;
                        case 4:
                            saveSkillId = main.S.AngSaveSkillId5[slotId];
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

    // Use this for initialization
    public void SkillSetAwake()
    {
        StartBASE();
    }
    // Use this for initialization
    public void SkillSetStart()
    {
        thisImage = gameObject.GetComponent<Image>();
        rangeImage = main.ally.GetComponent<Image>();
        setFalse(main.ally1.transform.GetChild(1).gameObject);
        skillSet1aButton.onClick.AddListener(SkillSlotSet);
        SkillChange();
        StartCoroutine(SkillSetLoad());
    }

    public void SkillChange()
    {
        currentSkill = null;

        if (currentSkill == null && saveSkillId != 0)
        {
            currentSkill = main.skillsForCoolTime[saveSkillId - 1];
        }
    }


    public Vector3 oneO = new Vector3(1, 0);
    Vector2 rangeVector = new Vector2(0, 0);
    Vector3 coolTimeVector = new Vector3(0, 0);
    // Update is called once per frame
    public virtual void SkillSetUpdate()
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
                if (thisImage.sprite != main.SkillSlotEmptyImage)
                {
                    thisImage.sprite = null;
                    thisImage.sprite = main.SkillSlotEmptyImage;
                }
            }
            else
            {
                if (thisImage.sprite != main.Sprites[currentSkill.skillIndex])
                {
                    thisImage.sprite = null;
                    thisImage.sprite = main.Sprites[currentSkill.skillIndex];
                }
            }
        }

        if (isOver)
       {
            if (Input.GetMouseButton(1) && slotId != 0)//右クリック
            {
                    currentSkill = null;
                    saveSkillId = 0;
                SkillSetSave();
                //gameObject.transform.GetChild(1).GetComponent<RectTransform>().localScale = oneO;
            }

        }


        //}

        //射程距離の実装
        if (isOver && currentSkill != null)
        {
            rangeVector.x = currentSkill.attackRange * 2;
            rangeVector.y = currentSkill.attackRange * 2;
            setActive(main.ally1.transform.GetChild(1).gameObject);
            main.ally1.transform.GetChild(1).GetComponent<RectTransform>().sizeDelta = rangeVector;
        }


        //クールタイムを反映させる．
        if (currentSkill != null)
        {
            coolTimeVector.x = 1;
            coolTimeVector.y = Mathf.Clamp(currentSkill.currentCoolTime, 0, 1);
            gameObject.transform.GetChild(1).GetComponent<RectTransform>().localScale = coolTimeVector;
        }
        else
            gameObject.transform.GetChild(1).GetComponent<RectTransform>().localScale = oneO;
    }

    //public void OnPointerDown(PointerEventData eventData)
    //{ //
    //  // if (eventData.pointerId ==-2&&slotId != 0)
    //  // {
    //  //     currentSkill = null;
    //  //     gameObject.transform.GetChild(1).GetComponent<RectTransform>().localScale = new Vector3(1, 0);
    //  // }
    //  //
    //}

    public void OnPointerEnter(PointerEventData eventData)
    {
        isOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOver = false;
        setFalse(main.ally1.transform.GetChild(1).gameObject);
    }
}
