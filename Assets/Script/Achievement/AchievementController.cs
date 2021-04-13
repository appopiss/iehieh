using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;

public class AchievementController : BASE {

    public ACHIEVEMENT[] achievements;
    public TextMeshProUGUI questPointText;
    public Sprite bronze, silver, gold, platina;
    private void Awake()
    {
        StartBASE();
    }

    private void Update()
    {
        questPointText.text = "Quest Point : " + tDigit(main.S.QuestPoint);
    }
}
