using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEffectKind
{
    public static string goldGain => LocalizeInitialize.language switch
    {
        Language.eng => "Gold Gain",
        Language.jp => "�S�[���h�l��",
        Language.chi => "?",
        _ => ""
    };
    public static string expGain = "EXP Gain";
    public static string hp_add = "HP";
}