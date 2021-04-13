using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetSiblingWizard : BASE
{
    private void Awake()
    {
        StartBASE();
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(SetSibling);

    }

    public void SetSibling()
    {
        if (main.CurrentSkillTree == main.SkillTreeCanvas[1])
        {
            return;
        }
        else
        {
            if (main.S.job == ALLY.Job.Wizard)
            {
                main.JobImage.sprite = null;
                main.JobImage.sprite = main.JobSprites[1];
                main.JobImage.color = new Color(255, 255, 255, 255);
                main.SR.isReinClassSprite = false;

            }
            main.GameController.SetAllImageAndText(main.CurrentSkillTree, false);
            main.CurrentSkillTree.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, -500);
            main.SkillTreeCanvas[1].GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 500);
            main.CurrentSkillTree = main.SkillTreeCanvas[1];
            main.GameController.SetAllImageAndText(main.CurrentSkillTree, true);
        }

    }
}
