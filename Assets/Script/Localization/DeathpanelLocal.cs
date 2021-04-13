using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static BASE;
using static UsefulMethod;

public class DeathpanelLocal : MonoBehaviour
{
    public static void nothinggain(TextMeshProUGUI text)
    {
        LocalizeInitialize.SetFont(text);
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                text.text =  "Nothing gained.";
                return;
            case Language.jp:
                text.text = "何も得られなかった.";
                return;
            case Language.chi:
                text.text = "无所获.";
                return;
            default:
                text.text = "Nothing gained.";
                return;
        }
    }
    public static void exp(TextMeshProUGUI text)
    {
        LocalizeInitialize.SetFont(text);
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                text.text = "Total EXP Gained " + tDigit(main.DeathPanel.exp);
                return;
            case Language.jp:
                text.text = "合計 " + tDigit(main.DeathPanel.exp) + "の経験値を入手しました";
                return;
            case Language.chi:
                text.text = "全部的EXP " + tDigit(main.DeathPanel.exp);
                return;
            default:
                text.text = "Total EXP Gained " + tDigit(main.DeathPanel.exp);
                return;
        }
    }
    public static void gold(TextMeshProUGUI text)
    {
        LocalizeInitialize.SetFont(text);
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                text.text = "Total Gold Gained " + tDigit(main.DeathPanel.gold);
                return;
            case Language.jp:
                text.text = "合計 " + tDigit(main.DeathPanel.exp) + "のゴールドを入手しました";
                return;
            case Language.chi:
                text.text = "全部的Gold " + tDigit(main.DeathPanel.gold);
                return;
            default:
                text.text = "Total Gold Gained " + tDigit(main.DeathPanel.gold);
                return;
        }
    }
    public static void time(TextMeshProUGUI text,float time)
    {
        LocalizeInitialize.SetFont(text);
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                text.text = "Time " + DoubleTimeToDate(time);
                return;
            case Language.jp:
                text.text = "クリアタイム : " + DoubleTimeToDate(time);
                return;
            case Language.chi:
                text.text = "完成时间 " + DoubleTimeToDate(time);
                return;

            default:
                text.text = "Time " + DoubleTimeToDate(time);
                return;
        }
    }
}
