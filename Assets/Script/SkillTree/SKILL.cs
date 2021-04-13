using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using static UsefulMethod;
using static BASE;

[Serializable]
public class SKILL : POPTEXT_SL {

    [NonSerialized]
    public int skillIndex;
    [NonSerialized]
    public bool isUnlocked;
    [NonSerialized]
    public Image hideImage;
    public enum DamageKind
    {
        nothing,
        physical,
        magical,
        electrical,
        divine,
        banana,
    }
    public enum Attribute
    {
        normal,
        fire,
        ice,
        thunder
    }
    public DamageKind damageKind;
    public Attribute attribute;
    public TextMeshProUGUI DpsText;

    public bool IsEquipped() {
        for (int i = 0; i < main.skillSlotCanvasAry.Length; i++)
        {
            if (main.skillSlotCanvasAry[i].currentSkill == main.skillsForCoolTime[skillIndex])
            {
                return true;
            }

        }
        return false;
    }
    public Enum list;

    [NonSerialized]
    public GameObject skillCanvas;

    //スキルボタン
    [NonSerialized]
    public Button S_button;
    //スキルの系統の名前
    [NonSerialized]
    public string skillLineage;
    //熟練度の経験値
    public virtual double P_exp { get; set; }
    public virtual bool canGetExp { get; set; }
    public virtual int P_level { get; set; }

    public long BuffedLevel()
    {
        if (skillIndex == 52)
            return P_level;
        if (P_level == 0)
            return 0;
        else if (main.angelSkillAry[12].IsEquipped())
        {
            if (isReinSkill)
                return P_level + (long)(main.angelSkillAry[12].pas1 * main.angelSkillAry[12].Damage());
            else
                return P_level + (long)main.angelSkillAry[12].Damage();
        }
        else if (main.angelSkillAry[12].P_level>100 && (main.S.job==ALLY.Job.Angel || main.MissionMileStone.IsSkillPassiveEffect()))
        {
            if (isReinSkill)
                return P_level + (long)(main.angelSkillAry[12].pas1 * main.angelSkillAry[12].Damage() * 0.5d);
            else
                return P_level + (long)(main.angelSkillAry[12].Damage() * 0.5d);
        }
        else
            return P_level;
    }
    public string BuffedLevelString()
    {
        if (skillIndex == 52)
            return P_level.ToString();

        if (P_level == 0)
            return "0";
        else if (main.angelSkillAry[12].IsEquipped())
        {
            if(isReinSkill)
                return P_level.ToString() + "+" + (long)(main.angelSkillAry[12].pas1 * main.angelSkillAry[12].Damage()) + "</B>";
            else
                return P_level.ToString() + "+" + (long)(main.angelSkillAry[12].Damage()) + "</B>";
        }
        else if (main.angelSkillAry[12].P_level > 100 && (main.S.job == ALLY.Job.Angel || main.MissionMileStone.IsSkillPassiveEffect()))
        {
            if (isReinSkill)
                return P_level.ToString() + "+" + (long)(main.angelSkillAry[12].pas1 * main.angelSkillAry[12].Damage()*0.5d) + "</B>";
            else
                return P_level.ToString() + "+" + (long)(main.angelSkillAry[12].Damage()*0.5d) + "</B>";
        }
        else
            return P_level.ToString();
    }
    public virtual double Chance() { return 0; }

    [NonSerialized]
    public double buffProfFactor;
    [NonSerialized]
    public double warriorFactor;
    [NonSerialized]
    public double wizardFactor;
    [NonSerialized]
    public double angelFactor;
    [NonSerialized]
    public GameObject thisAnimationObject;
    public virtual void GetProf() { }
    public virtual float CooltimeFactor() { return 0f; }
    //↓回復系，バフ系のみOverrideを許すよ
    public virtual void DoSkill()
    {
        if (!ManualCanAttack())
            return;

        if (searchEnemy() != null)
        {
            StartCoroutine(main.InstantiateAnimation(thisAnimationObject, searchEnemy().GetComponent<RectTransform>(), Damage(), ConsumeMp(), damageKind));
            if (skillIndex >= main.jobNum && skillIndex < main.jobNum + 10) 
                GetProf();
        }
        else
        {
            GameObject EmptyObject = Instantiate(main.EmptyObject, main.Transforms[1]);
            EmptyObject.GetComponent<RectTransform>().anchoredPosition = main.ally.GetComponent<RectTransform>().anchoredPosition + InitialManualVector;
            StartCoroutine(main.InstantiateAnimation(thisAnimationObject, EmptyObject.GetComponent<RectTransform>(), Damage(), ConsumeMp(), damageKind, Main.Debuff.nothing,this));
        }
    }
    public Vector2 InitialManualVector = new Vector2(0, 10);
    public double ProfFactor()
    {
        return (1 + main.ArtifactFactor.PROF()) * (1 + main.Ascends[14].calculateCurrentValue()) * (1 + main.jems[(int)JEM.ID.Prof].Effect())
            * LegendaryEffect.SkillEfficiencyBonus() * SumMulDelegate(main.cc.cf.Proficiency)
                    * (1d + main.iebCtrl.iebBonuses[(int)IEBBONUS.BonusKind.prof]);
        ;
    }
    public double culGetExp()
    {
        if (main.MissionMileStone.IsSkillPassiveEffect())//実はこれ、計算間違ってる。本当は(1+warriorFactor+wizardFactor+angelFactor)でもnerfできないのでこのままにする。
            return getExp * (1 + buffProfFactor) * 0.25 * (1 + warriorFactor) * (1 + wizardFactor) *
                (1 + angelFactor + main.angelSkillAry[9].pas1 + main.angelSkillAry[9].pas2 + main.angelSkillAry[9].pas3 + main.angelSkillAry[13].pas2)
                * ProfFactor();

        if (main.ally.job == ALLY.Job.Warrior)
            return getExp * (1 + buffProfFactor) * 0.25 *
                (1 + warriorFactor)
                * ProfFactor();
        else if (main.ally.job == ALLY.Job.Wizard)
            return getExp * (1 + buffProfFactor) * 0.25 *
                (1 + wizardFactor )
                * ProfFactor();
        else if (main.ally.job == ALLY.Job.Angel)
            return getExp * (1 + buffProfFactor) * 0.25 *
                (1 + angelFactor + main.angelSkillAry[9].pas1 + main.angelSkillAry[9].pas2 + main.angelSkillAry[9].pas3 + main.angelSkillAry[13].pas2)
                * ProfFactor();
        else
            return 1;

    }

    public bool isReinSkill;

    public void GetProExp(double factor = 1.0)
    {
        if(!isReinSkill)
            P_exp += culGetExp() * factor;
    }

    //スキルのレベル

    [NonSerialized]
    public TextMeshProUGUI levelText;

    //必要熟練度
    public virtual double P_requiredExp(){
        return 100* Math.Pow(1.75, P_level);
    }
    //必要コスト
    [NonSerialized]
    public double initialCostStone;
    [NonSerialized]
    public double initialCostCristal;
    [NonSerialized]
    public double initialCostLeaf;
    [NonSerialized]
    public float currentCoolTime;
    public virtual double CostStone()
    {
        if (initialCostStone == 0)
            return 0;
        return initialCostStone * Math.Pow(1.55, P_level);
    }
    public virtual double CostCristal()
    {
        if (initialCostCristal == 0)
            return 0;
        return initialCostCristal * Math.Pow(1.55, P_level);
    }
    public virtual double CostLeaf()
    {
        if (initialCostLeaf == 0)
            return 0;
        return initialCostLeaf * Math.Pow(1.55, P_level);
    }

    //PassiveSkillのEffect

    [NonSerialized]
    public double pas1, pas2, pas3, pas4, pas5, pas6, pas7, pas8, pas9, pas10;
    [NonSerialized]
    public double getExp;
    [NonSerialized]
    public double initialReqExp;
    public float attackRange { get { return AttackRange * (float)SumMulDelegate(main.cc.cf.RangeUp); } set => AttackRange = value; }
    float AttackRange;
    [NonSerialized]
    public bool isClick;
    [NonSerialized]
    public bool isCoolTimeFilled;

    public virtual double Damage() { return 0; }

    [NonSerialized]
    public float attackSpeedFactor;
    public virtual float AttackInterval() { return BaseAttackInterval(); }
    public static float BindingFactor = 1.0f;
    public float BaseAttackInterval() { return Mathf.Max(1f * BindingFactor / Mathf.Log10((10000f + main.ally.Speed())/1000f) * (1-main.skillprogress.intervalFactor), 0.1f); }//((main.ally1.GetComponent<ALLY>().Speed()+10000f)/10000f), 0.1f); }//SPD10000で0.5f,36000で0.1f

    public double consumeMp;//インスペクターで初期値を入れる
    [NonSerialized]
    public double mpFactor;
    public double ConsumeMp() {
        if ((consumeMp + mpFactor) >= 0)
            return (consumeMp + mpFactor) * (1 - main.skillprogress.mpFactor);
        else
            return (consumeMp + mpFactor);
    }
    
    public bool canMp() { return main.ally1.GetComponent<ALLY>().currentMp >= ConsumeMp(); }

    public virtual bool CanAttack() {

        if (main.GameController.isAuto)
        {
            return //main.ally1.GetComponent<ALLY>().condition == ALLY.Condition.BattleMode
                //&& 
                isCoolTimeFilled
                && canMp()
                && IsEquipped()
                && searchEnemy() != null
                && !main.DeathPanel.isPanel;
        }
        else
        {
            return 
                isCoolTimeFilled
               && canMp()
               && IsEquipped()
               && searchEnemy() != null
               && !main.DeathPanel.isPanel;
        }
    }
    public bool ManualCanAttack()
    {
        return canMp()&&IsEquipped() && !main.DeathPanel.isPanel; 
    }
    public virtual bool CanBuff() { return isCoolTimeFilled && canMp() && IsEquipped() && !main.DeathPanel.isPanel; ; }

    public bool updateDuration(Main.Buff buff)
    {
        foreach (Transform child in main.StatusIconCanvas.transform)
        {
            if (child.GetComponent<ABNORMAL>().buff == buff)
            {
                child.GetComponent<ABNORMAL>().currentDuration = 0;
                StartCoroutine(child.GetComponent<ABNORMAL>().Effect());
                return true;
            }
        }
        return false;
    }


    public void AwakeSkill()
    {
        StartBASE();
                //スキルキャンバス

    }
    public void StartSkill(double getExp, float attackRange, string skillLineage, float attackSpeedFactor = 1.0f, double initialCostStone = 0, double initialCostCristal = 0, double initialCostLeaf = 0, DamageKind damageKind = DamageKind.physical )
    {
        startText();
        levelText = transform.parent.GetComponentsInChildren<TextMeshProUGUI>()[2];
        this.getExp = getExp;
        //this.initialReqExp = initialReqExp;
        this.skillLineage = skillLineage;
        AttackRange = attackRange;
        //CurseRoad2のクリア分だけrangeをあげる
        //this.attackRange *= (float)SumMulDelegate(main.cc.cf.RangeUp);
        this.attackSpeedFactor = attackSpeedFactor;
        this.initialCostStone = initialCostStone;//Lv0のスキルの熟練度を1%上昇するのに必要なコスト
        this.initialCostCristal = initialCostCristal;
        this.initialCostLeaf = initialCostLeaf;
        this.damageKind = damageKind;
        DpsText = gameObject.transform.parent.GetChild(2).GetComponent<TextMeshProUGUI>();
        StartCoroutine(UpdateOneSecond());
        autoToggleCor = AutoToggle();
        StartCoroutine(autoToggleCor);

        //StartCoroutine(AutoToggleSub());
        //DpsText = Instantiate(main.skillList.DpsText, gameObject.transform);
    }
    IEnumerator UpdateOneSecond()
    {
        while (true)
        {
            if(main.GameController.currentCanvas==main.GameController.SkillTreeCanvas)
                ShowDpsText();
            yield return new WaitForSeconds(1.011f);
        }
    }
    IEnumerator autoToggleCor;
    public void OnEnable()
    {
        StartBASE();
        StartCoroutine(Attacking());
        //最初の使用時だけクールタイムなし！
        currentCoolTime = 1.0f;
        StartCoroutine(CalculateCoolTime());
        skillCanvas = transform.parent.gameObject.GetComponent<Canvas>().gameObject;
        //熟練度Upボタン
        P_button = transform.parent.gameObject.GetComponentsInChildren<Button>()[0];
        hideImage = transform.parent.gameObject.GetComponentsInChildren<Image>()[8];
        //スキルボタン
        S_button = gameObject.GetComponent<Button>();
        P_button.gameObject.AddComponent<EventTrigger>().triggers = new List<EventTrigger.Entry>();
        EventTrigger.Entry click = new EventTrigger.Entry();
        EventTrigger.Entry click2 = new EventTrigger.Entry();
        EventTrigger.Entry click3 = new EventTrigger.Entry();
        click.eventID = EventTriggerType.PointerDown;
        click2.eventID = EventTriggerType.PointerClick;
        click3.eventID = EventTriggerType.PointerExit;
        click.callback.AddListener((x) => isClick = true);
        click2.callback.AddListener((x) => isClick = false);
        click3.callback.AddListener((x) => isClick = false);//ラムダ式の右側は追加するメソッドです。
        P_button.gameObject.GetComponent<EventTrigger>().triggers.Add(click);
        P_button.gameObject.GetComponent<EventTrigger>().triggers.Add(click2);
        P_button.gameObject.GetComponent<EventTrigger>().triggers.Add(click3);

        StartCoroutine(ProficiencyUp());
        if (autoToggleCor != null)
            StartCoroutine(autoToggleCor);
        if (DpsText !=null)
            ShowDpsText();
        isAuto = false;

    }

    public void UpdateSkill()
    {
        updateText();
        if (P_exp >= P_requiredExp())
        {
            P_exp -= P_requiredExp();
            P_level++;
            ShowDpsText();
        }

        if (P_level > 0)
        {
            isUnlocked = true;
        }

        if (isUnlocked)
        {
            if (S_button != null)
                S_button.interactable = true;
        }
        else
        {
            if (S_button != null)
                S_button.interactable = false;
        }

        P_slider.value = (float)(Math.Max(P_exp, 0) / P_requiredExp());
        levelText.text = main.TextEdit(new string[] { "<color=\"green\">Lv : ", BuffedLevel().ToString() });

        //バフ
        if (main.ally1.GetComponent<ALLY>().isBuff[(int)Main.Buff.prof])
        {
            buffProfFactor = main.angelSkillAry[9].Damage() / 100;
        }
        else
            buffProfFactor = 0;

        if (canGetExp)
        {
            setFalse(hideImage.gameObject);
        }
        else
        {
            setActive(hideImage.gameObject);
        }

        //if (window2.activeSelf)
        //{
        //    if (skillIndex < 10)
        //    {
        //        window2CostText.text = main.TextEdit(new string[] { "- 1 level up / ", tDigit((CostStone()) * 100, 2), " stones" });
        //    }
        //    else if (skillIndex >= 10 && skillIndex < 20)
        //    {
        //        window2CostText.text = main.TextEdit(new string[] { "- 1 level up / ", tDigit(CostCristal() * 100, 2), " crystals" });
        //    }
        //    else if (skillIndex >= 20 && skillIndex < 30)
        //    {
        //        window2CostText.text = main.TextEdit(new string[] { "- 1 level up / ", tDigit(CostLeaf() * 100, 2), " leaves" });
        //    }
        //}
        if (window.activeSelf)
        {
            if (main.MissionMileStone.IsSkillPassiveEffect() || (skillIndex >= main.jobNum && skillIndex < main.jobNum + 10) || (skillIndex >= main.jobNum+30 && skillIndex < main.jobNum + 10+30))
            {
                windowText6.color = UnityEngine.Color.white;
                whiteLine.color= UnityEngine.Color.white;
            }
            else
            {
                windowText6.color = UnityEngine.Color.gray;
                whiteLine.color = UnityEngine.Color.gray;
            }
            //if(main.GameController.currentCanvas == main.GameController.SkillTreeCanvas)
            //    ShowDpsText();

        }
        if (window2.activeSelf)
        {
            if (canGetExp)
            {
                setFalse(window2Text5.gameObject);
                setFalse(window2Text6.gameObject);
            }
            else
            {
                setActive(window2Text5.gameObject);
                setActive(window2Text6.gameObject);
            }
        }

        if (isAuto)
        {
            isClick = true;
        }


        //if (main.SR.autoLevelUpSkill == skillIndex + 1)
        //{
        //    isClick = true;
        //}
        //else
        //{
        //    isClick = false;
        //}
    }

    IEnumerator AutoToggle()
    {
        yield return new WaitUntil(() => main.S.AutoMaxSkill);
        while (true)
        {
            yield return new WaitUntil(() => window2.activeSelf && Input.GetKeyDown(KeyCode.M));

            if (main.S.AutoMaxSkill)
            {
                if (!isAuto)
                    isAuto = true;
                else
                {
                    isAuto = false;
                    isClick = false;
                }
            }
            yield return new WaitForSeconds(0.05f);
        }
    }
    bool isAuto;
    public virtual void ShowDpsText()
    {
        if (DpsText == null)
            return;
        //↓ここで調節して
        if (damageKind == DamageKind.physical)
        {
            DpsText.text = main.TextEdit(new string[] { "<color=#00C8FF>", "DPS : ", tDigit(Damage() / AttackInterval(), 2) }) ;
        }
        else if (damageKind == DamageKind.magical)
        {
            DpsText.text = main.TextEdit(new string[] { "<color=#ffe400>", "DPS : ", tDigit(Damage() / AttackInterval(), 2) });
        }
        else
        {
            DpsText.text = main.TextEdit(new string[] { "<color=#ffffff>", "DPS : ", tDigit(Damage() / AttackInterval(), 2) });
        }
    }


    public string Color(int num, string text)
    {
        if (P_level >= num)
        {
            if (main.MissionMileStone.IsSkillPassiveEffect() || (skillIndex >= main.jobNum && skillIndex < main.jobNum + 10) || (skillIndex >= main.jobNum + 30 && skillIndex < main.jobNum + 10 + 30))
            {
                if (num < 10)
                {
                    return "< <color=\"green\">Lv     " + num + "</color> >   <color=\"green\">" + text + "</color>";
                }
                if (num >= 10 && num < 100)
                {
                    return "< <color=\"green\">Lv   " + num + "</color> >   <color=\"green\">" + text + "</color>";
                }
                else
                {
                    return "< <color=\"green\">Lv " + num + "</color> >   <color=\"green\">" + text + "</color>";
                }
            }
            else
            {
                if (num < 10)
                {
                    return "<alpha=#66>< Lv     " + num + " >   " + text + "";
                }
                if (num >= 10 && num < 100)
                {
                    return "<alpha=#66>< Lv   " + num + " >   " + text + "";
                }
                else
                {
                    return "<alpha=#66>< Lv " + num + " >   " + text + "";
                }

            }
        }
        else
        {
            if (main.MissionMileStone.IsSkillPassiveEffect() || (skillIndex >= main.jobNum && skillIndex < main.jobNum + 10) || (skillIndex >= main.jobNum + 30 && skillIndex < main.jobNum + 10 + 30))
            {
                if (num < 10)
                {
                    return "< Lv     " + num + " >   ???";
                }
                if (num >= 10 && num < 100)
                {
                    return "< Lv   " + num + " >   ???";
                }
                else
                {
                    return "< Lv " + num + " >   ???";
                }
            }
            else
            {
                if (num < 10)
                {
                    return "<alpha=#66>< Lv     " + num + " >   ???";
                }
                if (num >= 10 && num < 100)
                {
                    return "<alpha=#66>< Lv   " + num + " >   ???";
                }
                else
                {
                    return "<alpha=#66>< Lv " + num + " >   ???";
                }
            }
        }
    }

    public virtual double DebuffResistance()
    {
        return 0;
    }
    public virtual double RegenePoint()
    {
        return 0;
    }


    public virtual IEnumerator Attacking()
    {
        while (true)
        {
            yield return new WaitUntil(CanAttack);
            if (thisAnimationObject == null)
                continue;
            if (searchEnemy() == null)
                continue;
            StartCoroutine(main.InstantiateAnimation(thisAnimationObject, searchEnemy().GetComponent<RectTransform>(), Damage(), ConsumeMp(), damageKind));
            if (skillIndex >= main.jobNum && skillIndex < main.jobNum + 10)
                GetProf();
            yield return new WaitForSeconds(AttackInterval());
        }
    }

    public void AllAttack(int equipLevel)
    {
        List<ENEMY> attackableList = new List<ENEMY>();
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("enemy"))
        {
            attackableList.Add(enemy.GetComponent<ENEMY>());
        }
        if (attackableList.Count == 0) { return; }
        if(thisAnimationObject == null) { return; }
        if(equipLevel == 0) { return; }
        float EquipFactor = equipLevel * 0.05f;
        foreach (ENEMY enemy in attackableList)
        {
            StartCoroutine(main.InstantiateAnimation(thisAnimationObject,
            enemy.GetComponent<RectTransform>(), Damage() * EquipFactor, ConsumeMp(), damageKind));
        }
    }

    public IEnumerator ProficiencyUp()
    {
        while (true)
        {
            if (((skillIndex >= main.jobNum && skillIndex < main.jobNum+10) || (skillIndex >= main.jobNum+30 && skillIndex < main.jobNum+30+10)) && canGetExp && main.SR.stone >= CostStone() && main.SR.cristal >= CostCristal() && main.SR.leaf >= CostLeaf())
            {
                //if (skillIndex == 0 || skillIndex == 10 || skillIndex == 20)//チュートリアルの一番最初はslashだけ押せるようにする
                //{
                //    if(main.warriorSkillAry[1].P_level >= 1 || main.wizardSkillAry[1].P_level >= 1 || main.angelSkillAry[1].P_level >= 1)
                //    {
                //        P_button.interactable = true;
                //    }
                //    else
                //    {
                //        P_button.interactable = false;
                //    }
                //}
                //else
                //{
                //    P_button.interactable = true;
                //}
                P_button.interactable = true;

                if ((CostStone() > 0 && ZC(main.SR.stone / CostStone()) > 2000) || (CostCristal() > 0 && ZC(main.SR.cristal / CostCristal()) > 2000) || (CostLeaf() > 0 && ZC(main.SR.leaf / CostLeaf()) > 2000))
                {

                    if (isClick)
                    {
                        P_exp += P_requiredExp() / 5;//20%につき
                        main.SR.stone -= CostStone() * 20;
                        main.SR.cristal -= CostCristal() * 20;
                        main.SR.leaf -= CostLeaf() * 20;
                    }
                }
                else if ((CostStone() > 0 && ZC(main.SR.stone / CostStone()) > 1000 && ZC(main.SR.stone / CostStone()) <= 2000) || (CostCristal() > 0 && ZC(main.SR.cristal / CostCristal()) > 1000 && ZC(main.SR.cristal / CostCristal()) <= 2000) || (CostLeaf() > 0 && ZC(main.SR.leaf / CostLeaf()) > 1000 && ZC(main.SR.leaf / CostLeaf()) <= 2000))
                {
                    if (isClick)
                    {
                        P_exp += P_requiredExp() / 10;//10%につき
                        main.SR.stone -= CostStone() * 10;
                        main.SR.cristal -= CostCristal() * 10;
                        main.SR.leaf -= CostLeaf() * 10;
                    }
                }
                else if ((CostStone() > 0 && ZC(main.SR.stone / CostStone()) > 500 && ZC(main.SR.stone / CostStone()) <= 1000) || (CostCristal() > 0 && ZC(main.SR.cristal / CostCristal()) > 500 && ZC(main.SR.cristal / CostCristal()) <= 1000) || (CostLeaf() > 0 && ZC(main.SR.leaf / CostLeaf()) > 500 && ZC(main.SR.leaf / CostLeaf()) <= 1000))
                {
                    if (isClick)
                    {
                        P_exp += P_requiredExp() / 20;//5%につき
                        main.SR.stone -= CostStone() * 5;
                        main.SR.cristal -= CostCristal() * 5;
                        main.SR.leaf -= CostLeaf() * 5;
                    }
                }
                else if ((CostStone() > 0 && ZC(main.SR.stone / CostStone()) > 250 && ZC(main.SR.stone / CostStone()) <= 500) || (CostCristal() > 0 && ZC(main.SR.cristal / CostCristal()) > 250 && ZC(main.SR.cristal / CostCristal()) <= 500) || (CostLeaf() > 0 && ZC(main.SR.leaf / CostLeaf()) > 250 && ZC(main.SR.leaf / CostLeaf()) <= 500))
                {
                    if (isClick)
                    {
                        P_exp += P_requiredExp() / 40;//2.5%につき
                        main.SR.stone -= CostStone() * 2.5;
                        main.SR.cristal -= CostCristal() * 2.5;
                        main.SR.leaf -= CostLeaf() * 2.5;
                    }
                }
                else //if ((CostStone() > 0 && ZC(main.SR.stone / CostStone()) > 100 && ZC(main.SR.stone / CostStone()) <= 250) || (CostCristal() > 0 && ZC(main.SR.cristal / CostCristal()) > 100 && ZC(main.SR.cristal / CostCristal()) <= 250) || (CostLeaf() > 0 && ZC(main.SR.leaf / CostLeaf()) > 100 && ZC(main.SR.leaf / CostLeaf()) <= 250))
                {
                    if (isClick)
                    {
                        P_exp += P_requiredExp() / 100;//1%につき
                        main.SR.stone -= CostStone();
                        main.SR.cristal -= CostCristal();
                        main.SR.leaf -= CostLeaf();
                    }
                }
                //else
                //{
                //    if (isClick)
                //    {
                //        P_exp += P_requiredExp() / 200;//0.5%につき
                //        main.SR.stone -= CostStone() / 2;
                //        main.SR.cristal -= CostCristal() / 2;
                //        main.SR.leaf -= CostLeaf() / 2;
                //    }
                //}
            }
            else
            {
                P_button.interactable = false;
                isAuto = false;
                isClick = false;
            }
            yield return new WaitForSeconds(0.02f);
        }
    }


    public IEnumerator CalculateCoolTime()
    {
        while (true)
        {
            isCoolTimeFilled = true;
            if (attackRange == 0)
            {
                yield return new WaitUntil(CanBuff);
            }
            else
            {
                yield return new WaitUntil(CanAttack);
            }
            yield return null;
            currentCoolTime = 0;
            isCoolTimeFilled = false;
            if (AttackInterval() >= 2f)
            {
                for (int i = 0; i < 40; i++)
                {
                    currentCoolTime += 0.025f;
                    yield return new WaitForSeconds(AttackInterval() / 40);
                }
            }
            else if (AttackInterval() >= 1f && AttackInterval() < 2f)
            {
                for (int i = 0; i < 20; i++)
                {
                    currentCoolTime += 0.05f;
                    yield return new WaitForSeconds(AttackInterval() / 20);
                }
            }
            else if (AttackInterval() >= 0.5f && AttackInterval() < 1f)
            {
                for (int i = 0; i < 10; i++)
                {
                    currentCoolTime += 0.1f;
                    yield return new WaitForSeconds(AttackInterval() / 10);
                }
            }
            else if (AttackInterval() >= 0.25f && AttackInterval() < 0.5f)
            {
                for (int i = 0; i < 5; i++)
                {
                    currentCoolTime += 0.2f;
                    yield return new WaitForSeconds(AttackInterval() / 5);
                }
            }
            else if(AttackInterval() >= 0.20f && AttackInterval() < 0.25f)
            {
                for (int i = 0; i < 4; i++)
                {
                    currentCoolTime += 0.25f;
                    yield return new WaitForSeconds(AttackInterval() / 4);
                }
            }
            else if(AttackInterval() >= 0.15f && AttackInterval() < 0.20f)
            {
                for (int i = 0; i < 3; i++)
                {
                    currentCoolTime += 0.3333f;
                    yield return new WaitForSeconds(AttackInterval() / 3);
                }
            }
            else
            {
                for (int i = 0; i < 1; i++)
                {
                    currentCoolTime += 0.3f;
                    yield return new WaitForSeconds(AttackInterval() / 2);
                }
                for (int i = 0; i < 1; i++)
                {
                    currentCoolTime += 0.7f;
                    yield return new WaitForSeconds(AttackInterval() / 2);
                }
            }
        }
    }
    
    public ENEMY searchEnemy()
    {
        GameObject[] currentEnemies;
        currentEnemies = GameObject.FindGameObjectsWithTag("enemy");
        List<GameObject> attackableEnemes = new List<GameObject>();
        foreach(GameObject game in currentEnemies)
        {
            if(vectorAbs(main.ally1.GetComponent<RectTransform>().anchoredPosition - game.GetComponent<RectTransform>().anchoredPosition)
                -game.GetComponent<ENEMY>().buffer<= attackRange)
            {
                attackableEnemes.Add(game);
            }
        }
        if(attackableEnemes.Count == 0) { return null; } else
        {
            foreach(GameObject game in attackableEnemes)
            {
                if (game.GetComponent<ENEMY>().isTargetted)
                {
                    return game.GetComponent<ENEMY>();
                }
            }
            int randomNum = UnityEngine.Random.Range(0,attackableEnemes.Count);
            return attackableEnemes[randomNum].GetComponent<ENEMY>();
        }
    }


    public void DestroyStance()
    {
        foreach (Transform child in main.StanceIconCanvas.transform)
        {
            if (child != null)
            {
                Destroy(child.gameObject);
            }
        }
        main.SR.P_SwordAttack = false;
        main.SR.P_ShieldAttack = false;
        main.SR.P_Block = false;
        main.SR.P_StaffAttack = false;
        main.SR.P_fire = false;
        main.SR.P_ice = false;
        main.SR.P_thunder = false;
        main.SR.P_GodBless = false;
        main.SR.P_AngelDistruction = false;
        main.SR.P_HoldWing = false;
    }

    public int attackNum;

    //Passive Stance用
    public void InstantiateStance(int index, bool isAlreadyThere)
    {
        if (isAlreadyThere)
            DestroyStance();
        else
        {
            DestroyStance();
            //isAlreadyThere = true;
            Instantiate(main.StanceIcons[index], main.StanceIconCanvas);
        }
    }

}
