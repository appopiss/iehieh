using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetSiblingsReinWarrior : BASE
{
    private void Awake()
    {
        StartBASE();
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(SetSibling);
        if (main.rein.R_upgrades[(int)R_UPGRADE.R_upgradeId.NewWarrior].GetCurrentValue() >= 1)
        {
            gameObject.GetComponent<Button>().interactable = true;
            gameObject.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
            gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "                                 R  Warrior  ";
            gameObject.transform.GetChild(0).GetComponent<Image>().gameObject.SetActive(true);

        }
        else
        {
            gameObject.GetComponent<Button>().interactable = false;
            gameObject.GetComponentInChildren<TextMeshProUGUI>().color = Color.gray;
            gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "???";
            gameObject.transform.GetChild(0).GetComponent<Image>().gameObject.SetActive(false);
        }
    }

    public void SetSibling()
    {   
        if(main.CurrentSkillTree == main.SkillTreeCanvas[3])
        {
            return;
        }
        else
        {
            if (main.S.job == ALLY.Job.Warrior)
            {
                main.JobImage.sprite = null;
                main.JobImage.sprite = main.JobSprites[3];
                main.JobImage.color = new Color(255, 255, 255, 255);
                main.SR.isReinClassSprite = true;
            }

            main.GameController.SetAllImageAndText(main.CurrentSkillTree, false);
            main.CurrentSkillTree.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, -500);
            main.SkillTreeCanvas[3].GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 500);
            main.CurrentSkillTree = main.SkillTreeCanvas[3];
            main.GameController.SetAllImageAndText(main.CurrentSkillTree, true);
        }

    }
}
