using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rein_temp : BASE
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() =>
        {
            //消す処理
            PlayerPrefs.DeleteKey(keyList.War_saveKey);
            //必ず直前に1回セーブする
            foreach (WARRIOR_SKILL skill in main.skillList.WarriorSkills)
            {
                if (skill.SkillKind == SkillList.WarriorSkill.sword)
                {
                    skill.P_level = 1;
                    skill.canGetExp = true;
                }
                else
                {
                    skill.P_level = 0;
                    skill.canGetExp = false;
                }

                skill.P_exp = 0;
                for (int i = 1; i < main.skillSlotCanvasAry.Length; i++)
                {
                    main.skillSlotCanvasAry[i].currentSkill = null;
                }
            }
            main.saveCtrl.setSaveKey();
        });
    }

    private void Awake()
    {
        StartBASE();
    }
}
