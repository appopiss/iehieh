using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSiblingAngel : BASE
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
        if (main.CurrentSkillTree == main.SkillTreeCanvas[2])
        {
            return;
        }
        else
        {
            if (main.S.job == ALLY.Job.Angel)
            {
                main.JobImage.sprite = null;
                main.JobImage.sprite = main.JobSprites[2];
                main.JobImage.color = new Color(255, 255, 255, 255);
                main.SR.isReinClassSprite = false;
            }

            main.GameController.SetAllImageAndText(main.CurrentSkillTree, false);
            main.CurrentSkillTree.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, -500);
            main.SkillTreeCanvas[2].GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 500);
            main.CurrentSkillTree = main.SkillTreeCanvas[2];
            main.GameController.SetAllImageAndText(main.CurrentSkillTree, true);
        }

    }
}
