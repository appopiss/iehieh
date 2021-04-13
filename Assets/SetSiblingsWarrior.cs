using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSiblingsWarrior : BASE
{
    private void Awake()
    {
        StartBASE();
    }
    // Start is called before the first frame update
    void Start()
    {
        main.CurrentSkillTree = main.SkillTreeCanvas[0];
        gameObject.GetComponent<Button>().onClick.AddListener(SetSibling);
    }

    public void SetSibling()
    {   
        if(main.CurrentSkillTree == main.SkillTreeCanvas[0])
        {
            return;
        }
        else
        {
            if (main.S.job == ALLY.Job.Warrior)
            {
                main.JobImage.sprite = null;
                main.JobImage.sprite = main.JobSprites[0];
                main.JobImage.color = new Color(255, 255, 255, 255);
                main.SR.isReinClassSprite = false;

            }
            main.GameController.SetAllImageAndText(main.CurrentSkillTree, false);
            main.CurrentSkillTree.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, -500);
            main.SkillTreeCanvas[0].GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 500);
            main.CurrentSkillTree = main.SkillTreeCanvas[0];
            main.GameController.SetAllImageAndText(main.CurrentSkillTree, true);
        }

    }
}
