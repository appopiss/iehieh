using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static KEYITEM.Effect.StatusKind;
using static KEYITEM.Effect.CalWay;

public class KeyItemFactor : BASE {

    public double GetValue(KEYITEM.Effect.StatusKind statusKind, KEYITEM.Effect.CalWay calWay)
    {
        double value = 0;
        //現在装備されているもの！
        /*
        foreach (KEYITEM item in main.keyItemCtrl.keyItems)
        {
            foreach (KEYITEM.Effect effect in item.gameObject.GetComponentsInChildren<KEYITEM.Effect>())
            {
                //現在の装備されている値を表示する．
                if (effect.statusKind == statusKind && effect.calWay == calWay)
                {
                    value += effect.growthValue();
                }
            }
        }
        */
        return value;
    }
    public double M_hp, A_hp, M_mp, A_mp, M_atk, A_atk, M_matk, A_matk, M_def, A_def, M_mdef, A_mdef, 
        A_spd, M_spd, P_damage, P_def, MA_atk, MA_def, M_exp, prof, M_drop, M_gold, A_gold, M_stone, M_crystal, M_leaf,A_goldCap,M_goldCap;
    public void UpdateValue()
    {
        M_hp = GetValue(HP, mul);
        A_hp = GetValue(HP, add);
        M_mp = GetValue(MP, mul);
        A_mp = GetValue(MP, add);
        M_atk = GetValue(ATK, mul);
        A_atk = GetValue(ATK, add);
        M_def = GetValue(DEF, mul);
        A_def = GetValue(DEF, add);
        M_matk = GetValue(MATK, mul);
        A_matk = GetValue(MATK, add);
        M_mdef = GetValue(MDEF, mul);
        A_mdef = GetValue(MDEF, add);
        M_spd = GetValue(spd, mul);
        A_spd = GetValue(spd, add);
        M_exp = GetValue(exp, mul);
        prof = GetValue(KEYITEM.Effect.StatusKind.prof, add);
        M_drop = GetValue(drop, mul);
        M_gold = GetValue(gold, mul);
        A_gold = GetValue(gold, add);
        M_stone = GetValue(stone, mul);
        M_crystal = GetValue(crystal, mul);
        M_leaf = GetValue(leaf, mul);
        A_goldCap = GetValue(goldCap, add);
        M_goldCap = GetValue(goldCap, mul);
    }
    public
    // Use this for initialization
    void Awake () {
		StartBASE();
	}

	// Use this for initialization
	void Start () {
        UpdateValue();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
