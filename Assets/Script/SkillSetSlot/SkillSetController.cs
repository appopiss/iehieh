using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static QuestCtrl.QuestId;


public class SkillSetController : BASE {

    //public skill chosenSkill;
    public SKILL chosenSkill;
    public GameObject mouseObject;
    public Button[] SkillSetSaveButtons;

    // Use this for initialization
    void Awake () {
		StartBASE();
        main.S.Slot_canEquipped[0] = true;
        main.S.Slot_canEquipped[1] = true;
    }

	// Use this for initialization
	void Start () {
        //main.warriorSkillAry[0].GetComponent<Button>().onClick.AddListener(() => chosenSkill = skill.SwordAttack);
        for (int i = 0; i < 10; i++)
        {
            int count = i;
            main.warriorSkillAry[i].GetComponent<Button>().onClick.AddListener( () => {
                chosenSkill = main.skillsForCoolTime[count];
                main.sound.MustPlaySound(main.sound.skillChooseClip);
                if (mouseObject != null)
                    Destroy(mouseObject);
                mouseObject = Instantiate(main.mouseObject, main.WindowShowCanvas);
                mouseObject.GetComponent<Image>().sprite = main.warriorSkillAry[count].GetComponent<Image>().sprite;
                });
            main.wizardSkillAry[i].GetComponent<Button>().onClick.AddListener(() => {
                chosenSkill = main.skillsForCoolTime[count + 10];
                main.sound.MustPlaySound(main.sound.skillChooseClip);
                if (mouseObject != null)
                    Destroy(mouseObject);
                mouseObject = Instantiate(main.mouseObject, main.WindowShowCanvas);
                mouseObject.GetComponent<Image>().sprite = main.wizardSkillAry[count].GetComponent<Image>().sprite;
            });
            main.angelSkillAry[i].GetComponent<Button>().onClick.AddListener(() => {
                chosenSkill = main.skillsForCoolTime[count + 20];
                main.sound.MustPlaySound(main.sound.skillChooseClip);
                if (mouseObject != null)
                    Destroy(mouseObject);
                mouseObject = Instantiate(main.mouseObject, main.WindowShowCanvas);
                mouseObject.GetComponent<Image>().sprite = main.angelSkillAry[count].GetComponent<Image>().sprite;
            });
        }
        for (int i = 0; i < 4; i++)//ReinSkill
        {
            int count = i;
            //WarriorSpirit
            main.warriorSkillAry[10+i].GetComponent<Button>().onClick.AddListener(() => {
                chosenSkill = main.skillsForCoolTime[30+count];
                main.sound.MustPlaySound(main.sound.skillChooseClip);
                if (mouseObject != null)
                    Destroy(mouseObject);
                mouseObject = Instantiate(main.mouseObject, main.WindowShowCanvas);
                mouseObject.GetComponent<Image>().sprite = main.warriorSkillAry[10+count].GetComponent<Image>().sprite;
            });
            //WizSpirit
            main.wizardSkillAry[10+i].GetComponent<Button>().onClick.AddListener(() => {
                chosenSkill = main.skillsForCoolTime[40+count];
                main.sound.MustPlaySound(main.sound.skillChooseClip);
                if (mouseObject != null)
                    Destroy(mouseObject);
                mouseObject = Instantiate(main.mouseObject, main.WindowShowCanvas);
                mouseObject.GetComponent<Image>().sprite = main.wizardSkillAry[10+count].GetComponent<Image>().sprite;
            });
            //AngelSpirit
            main.angelSkillAry[10+i].GetComponent<Button>().onClick.AddListener(() => {
                chosenSkill = main.skillsForCoolTime[50+count];
                main.sound.MustPlaySound(main.sound.skillChooseClip);
                if (mouseObject != null)
                    Destroy(mouseObject);
                mouseObject = Instantiate(main.mouseObject, main.WindowShowCanvas);
                mouseObject.GetComponent<Image>().sprite = main.angelSkillAry[10+count].GetComponent<Image>().sprite;
            });
        }
        //Get Offline Bonus

        StartCoroutine(CalculateCurrentDPS());
        StartCoroutine(CalculateCurrentEXP());
        StartCoroutine(CalculateCurrentGOLD());

        for (int i = 0; i < 5; i++)
        {
            int count = i;
            SkillSetSaveButtons[count].onClick.AddListener(() => SkillSetSaveButtonChange(count));
        }
        SkillSetSaveButtonActivate();
    }
    

    public void SkillSetSaveButtonActivate()//BuyPremiumで買った時に呼ぶ
    {
        if (main.S.SkillSetSaveBuyNum >= 1)
            setActive(SkillSetSaveButtons[0].gameObject);
        else
            setFalse(SkillSetSaveButtons[0].gameObject);
        if (main.S.SkillSetSaveBuyNum >= 2)
            setActive(SkillSetSaveButtons[1].gameObject);
        else
            setFalse(SkillSetSaveButtons[1].gameObject);
        if (main.S.SkillSetSaveBuyNum >= 3)
            setActive(SkillSetSaveButtons[2].gameObject);
        else
            setFalse(SkillSetSaveButtons[2].gameObject);
        if (main.S.SkillSetSaveBuyNum >= 4)
            setActive(SkillSetSaveButtons[3].gameObject);
        else
            setFalse(SkillSetSaveButtons[3].gameObject);
        if (main.S.SkillSetSaveBuyNum >= 5)
            setActive(SkillSetSaveButtons[4].gameObject);
        else
            setFalse(SkillSetSaveButtons[4].gameObject);
        if (main.S.SkillSetSaveBuyNum >= 1 || main.S.SkillSetSaveLoad)
            SkillSetSaveButtons[main.S.SkillSetSaveID].onClick.Invoke();
    }

    public void SkillSetSaveButtonChange(int num)
    {
        main.S.SkillSetSaveID = num;

        for (int i = 0; i < main.S.SkillSetSaveBuyNum; i++)
        {
            if (i == main.S.SkillSetSaveID)
                SkillSetSaveButtons[i].GetComponent<Image>().color = orange;
            else
                SkillSetSaveButtons[i].GetComponent<Image>().color = Color.white;
        }
        isPushedSkillSetButton = true;
    }
    public bool isPushedSkillSetButton;

    public void UnleashSkillSlot()
    {
        for(int i=0; i<main.S.Slot_canEquipped.Length; i++)
        {
            if (!main.S.Slot_canEquipped[i])
            {
                main.S.Slot_canEquipped[i] = true;
                return;
            }
        }
    }

    //R4スキル用・その職業でいくつ装備してるか
    public int JobSkillSetNum(ALLY.Job job)
    {
        int tempValue = 0;
        int tempId = 0;
        for (int i = 0; i < main.skillSlotCanvasAry.Length; i++)
        {
            tempId = main.skillSlotCanvasAry[i].saveSkillId - 1;
            if (tempId >= 0)
            {
                switch (job)
                {
                    case ALLY.Job.Warrior:
                        if (tempId / 10 == 0 || tempId / 10 == 3)
                            tempValue++;
                        break;
                    case ALLY.Job.Wizard:
                        if (tempId / 10 == 1 || tempId / 10 == 4)
                            tempValue++;
                        break;
                    case ALLY.Job.Angel:
                        if (tempId / 10 == 2 || tempId / 10 == 5)
                            tempValue++;
                        break;
                    default:
                        break;

                }
            }
        }
        if ((main.S.job == ALLY.Job.Wizard || main.S.job == ALLY.Job.Angel) && job == main.S.job)
            tempValue++;
        return tempValue;
    }
    public void ResetSkillSlot()
    {
        for (int i = 2; i < 7; i++)
        {
            main.skillSlotCanvasAry[i].currentSkill = null;
            main.skillSlotCanvasAry[i].saveSkillId = 0;
            main.S.Slot_canEquipped[i] = false;
        }
        if (main.S.ExtraSkillSlot)
            UnleashSkillSlot();
    }

    public void UnleashGrobalSkillSlot()
    {
        for (int i = 0; i < main.S.SlotG_canEquipped.Length; i++)
        {
            if (!main.S.SlotG_canEquipped[i])
            {
                main.S.SlotG_canEquipped[i] = true;
                return;
            }
        }
    }
    int tempID;
    public void ResetGrobalSkillSlot()
    {
        tempID = main.S.SkillSetSaveID;
        for (int j = 0; j < 5; j++)
        {
            main.S.SkillSetSaveID = j;
            for (int i = 0; i < 8; i++)
            {
                main.skillSlotCanvasAry[7 + i].currentSkill = null;
                main.skillSlotCanvasAry[7 + i].saveSkillId = 0;
                main.skillSlotCanvasAry[7 + i].SkillSetSave();
                main.S.SlotG_canEquipped[i] = false;
            }
        }
        main.S.SkillSetSaveID = tempID;
        if (main.S.ExtraGlobalSkillSlot)
            UnleashGrobalSkillSlot();
        if (main.S.ExtraGlobalSkillSlotFirst)
            UnleashGrobalSkillSlot();
        if (main.S.ECS4>=1)
            UnleashGrobalSkillSlot();
        if (main.S.isGlobalSlotbyMissionMilestone)
            UnleashGrobalSkillSlot();
        if (main.S.dlcGlobalGotFixed)//DLC
            UnleashGrobalSkillSlot();
        return;
    }

    // Update is called once per frame
    void Update () {
        if (!isSkillFilled())
        {
            main.ally.targetEnemy = null;
            main.ally.condition = ALLY.Condition.MoveMode;
        }
        //main.Texts[4].text = "Total DPS  " + tDigit(DPS());
        main.Texts[5].text = "DPS : " + tDigit(currentDPS, 2);
        //main.Texts[23].text = "EXP : " + tDigit(currentEXP);
        //main.Texts[24].text = "GOLD : " + tDigit(currentGOLD);

    }

    public bool isSkillFilled()
    {
        foreach (SKILLSET skill in main.skillSlotCanvasAry)
        {
            if(skill.currentSkill != null)
            {
                return true;
            }
        }
        return false;
    }

    public double DPS()
    {
        double DPS = 0;
        foreach(SKILLSET skills in main.skillSlotCanvasAry)
        {
            if (skills.currentSkill != null && skills.currentSkill.attackRange!=0)
            {
                DPS += skills.currentSkill.Damage() / skills.currentSkill.AttackInterval();
            }
        }
        return DPS;
    }

    //獲得MP計算
    public double GainMPDPS()
    {
        double GainMPDPS = 0;
        foreach(SKILLSET skills in main.skillSlotCanvasAry)
        {
            if(skills.currentSkill != null)
            {
                if(skills.currentSkill.ConsumeMp() < 0)
                {
                    if (skills.currentSkill.isReinSkill)
                        GainMPDPS += (-1)*skills.currentSkill.ConsumeMp();
                    else
                        GainMPDPS += (-1) * skills.currentSkill.ConsumeMp() / skills.currentSkill.AttackInterval();
                }

            }
        }

        return GainMPDPS;
    }

    //DPS
    public double[] storeDPS = new double[60];
    public double currentDPS { get => main.SR.currentDPS; set => main.SR.currentDPS = value; }
    public double dps;

    public IEnumerator CalculateCurrentDPS()
    {
        while (true)
        {
            for (int i = 0; i < storeDPS.Length; i++)
            {
                //赤ブドウ
                storeDPS[i] = dps;
                dps = 0;
                currentDPS = calculateMean(storeDPS);
                yield return new WaitForSeconds(1.0f);
            }
        }
    }

    //EXP
    public double[] storeEXP = new double[60];
    public double currentEXP { get => main.SR.currentEXP; set => main.SR.currentEXP = value; }
    public double exp;

    public IEnumerator CalculateCurrentEXP()
    {
        while (true)
        {
            for (int i = 0; i < storeEXP.Length; i++)
            {
                //赤ブドウ
                storeEXP[i] = exp;
                exp = 0;
                currentEXP = calculateMean(storeEXP);
                yield return new WaitForSeconds(1.0f);
            }
        }
    }

    //GOLD
    public double[] storeGOLD = new double[60];
    public double currentGOLD { get => main.SR.currentGOLD; set => main.SR.currentGOLD = value; }
    public double gold;

    public IEnumerator CalculateCurrentGOLD()
    {
        while (true)
        {
            for (int i = 0; i < storeGOLD.Length; i++)
            {
                //赤ブドウ
                storeGOLD[i] = gold;
                gold = 0;
                currentGOLD = calculateMean(storeGOLD);
                yield return new WaitForSeconds(1.0f);
            }
        }
    }

    public void GetOfflineBonus()
    {
        float factor = DeltaTimeFloat(DateTime.FromBinary(Convert.ToInt64(main.S.lastTime)));
        main.ally1.GetComponent<ALLY>().currentExp += factor * currentEXP;
        main.SR.gold += factor * currentGOLD;
    }

    public double calculateMean(double[] array)
    {
        double ans = 0;
        for (int i = 0; i < array.Length; i++)
        {
            ans += array[i];
        }

        return ans / array.Length;
    }
}
