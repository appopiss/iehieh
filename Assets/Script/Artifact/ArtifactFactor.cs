using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using static UsefulMethod;
using TMPro;
using static ARTIFACT.StatusKind;
using static ARTIFACT.CalWay;

public class ArtifactFactor : BASE {

    public TextMeshProUGUI StatusText1, StatusText2;
    public SlimeSet slimeSet;

    public double GetValue(ARTIFACT.StatusKind statusKind, ARTIFACT.CalWay calWay)
    {
        double value = 0;
        //現在装備されているもの！
        foreach (ARTIFACT arti in main.NewArtifacts)
        {
            foreach (ARTIFACT.Status status in arti.gameObject.GetComponentsInChildren<ARTIFACT.Status>())
            {
                //現在の装備されている値を表示する．
                if (status.statusKind == statusKind && status.calWay == calWay&&arti.isEquipped)
                {
                    value += status.GetValue();
                }
                //パーマネントリワードを表示する．
                if (status.statusKind == statusKind && status.calWay == calWay&&status.ParmanentEffect != null)
                {
                    value += status.ParmanentEffect();
                }
            }
        }
        return value;
    }
    public double M_hp, A_hp, M_mp, A_mp, M_atk, A_atk, M_matk, A_matk, M_def, A_def, M_mdef, A_mdef, A_spd, M_spd, P_damage, P_def, MA_atk, MA_def, M_exp, prof, M_drop, M_gold, A_gold, M_stone, M_crystal, M_leaf;
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
        P_damage = GetValue(physicalATK, mul);
        P_def = GetValue(physicalDEF, mul);
        MA_atk = GetValue(magicalATK, mul);
        MA_def = GetValue(magicalDEF, mul);
        M_exp = GetValue(exp, mul);
        prof = GetValue( ARTIFACT.StatusKind.prof, mul);
        M_drop = GetValue(drop, mul);
        M_gold = GetValue(gold, mul);
        A_gold = GetValue(gold, add);
        M_stone = GetValue(stone, mul);
        M_crystal = GetValue(crystal, mul);
        M_leaf = GetValue(leaf, mul);
    }
    public double MUL_HP()
    {
        return M_hp;
    }
    public double ADD_HP()
    {
        return A_hp;
    }
    public double MUL_MP()
    {
        return M_mp;
    }
    public double ADD_MP()
    {
        return A_mp;
    }
    public double ADD_ATK()
    {
        return A_atk;
    }
    public double MUL_ATK()
    {
        return M_atk;
    }
    public double ADD_MATK()
    {
        return A_matk;
    }
    public double MUL_MATK()
    {
        return M_matk;
    }
    public double ADD_DEF()
    {
        return A_def;
    }
    public double MUL_DEF()
    {
        return M_def;
    }
    public double ADD_MDEF()
    {
        return A_mdef;
    }
    public double MUL_MDEF()
    {
        return M_mdef;
    }
    public double ADD_SPD()
    {
        return A_spd;
    }
    public double MUL_SPD()
    {
        return M_spd;
    }
    public double PhysicalDamage()
    {
        return P_damage;
    }

    public double PhysicalDef()
    {
        return P_def;
    }

    public double MagicalAtk()
    {
        return MA_atk;
    }

    public double MagicalDef()
    {
        return MA_def;
    }

    public double MUL_EXP()
    {
        return M_exp;
    }

    public double PROF()
    {
        return prof;
    }

    public double DROP()
    {
        return M_drop;
    }

    public double GOLD()
    {
        return M_gold;
    }
    public double ADD_GOLD()
    {
        return A_gold;
    }
    public double Stone()
    {
        return M_stone;
    }
    public double Crystal()
    {
        return M_crystal;
    }
    public double Leaf()
    {
        return M_leaf;
    }

    public double DodgeRate;
    public double DebuffResistance;
    public double SpeedRate;
    public int maxNum = 12;


    private void Awake()
    {
        StartBASE();
    }

    public string[] ShowStatus()
    {
        StringBuilder text1 = new StringBuilder();
        StringBuilder text2 = new StringBuilder();
        //1
        if(GOLD() > 0)
        {
            text1.Append(main.TextEdit(new string[] { "- Gold + ", percent(GOLD()), "\n" }));
            //text1 += "- Gold + " + percent(GOLD()) + "\n";
        }
        if (ADD_GOLD() > 0)
        {
            text1.Append(main.TextEdit(new string[] { "- Gold + ", tDigit(ADD_GOLD()), "\n" }));
            //text1 += "- Gold + " + tDigit(ADD_GOLD())+ "\n";
        }
        //2
        if (Stone()> 0)
        {
            text1.Append(main.TextEdit(new string[] { "- Stone + ", percent(Stone()), "\n" }));
            //text1 += "- Stone + " + percent(Stone()) + "\n";
        }
        //3
        if (Crystal() > 0)
        {
            text1.Append(main.TextEdit(new string[] { "- Crystal + ", percent(Crystal()), "\n" }));
            //text1 += "- Crystal + " + percent(Crystal()) + "\n";
        }
        //4
        if (Leaf() > 0)
        {
            text1.Append(main.TextEdit(new string[] { "- Leaf + ", percent(Leaf()), "\n" }));
            //text1 += "- Leaf + " + percent(Leaf()) + "\n";
        }
        //5
        if (ADD_HP() > 0)
        {
            text1.Append(main.TextEdit(new string[] { "- HP + ", tDigit(ADD_HP()), "\n" }));
            //text1 += "- HP + " + tDigit(ADD_HP()) + "\n";
        }
        //1
        if (MUL_HP() > 0)
        {
            text1.Append(main.TextEdit(new string[] { "- HP + ", percent(MUL_HP()), "\n" }));
            //text1 += "- HP + " + percent(MUL_HP()) + "\n";
        }
        //7
        if (ADD_MP() > 0)
        {
            text1.Append(main.TextEdit(new string[] { "- MP + ", tDigit(ADD_MP()), "\n" }));
            //text1 += "- MP + " + tDigit(ADD_MP()) + "\n";
        }
        //6
        if (MUL_MP() > 0)
        {
            text1.Append(main.TextEdit(new string[] { "- MP + ", percent(MUL_MP()), "\n" }));
            //text1 += "- MP + " + percent(MUL_MP()) + "\n";
        }
        //8
        if (PhysicalDamage() > 0)
        {
            text1.Append(main.TextEdit(new string[] { "- Physical Dmg + ", percent(PhysicalDamage()), "\n" }));
            //text1 += "- Physical Dmg + " + percent(PhysicalDamage()) + "\n";
        }
        //9
        if (MagicalAtk() > 0)
        {
            text1.Append(main.TextEdit(new string[] { "- Magical Dmg + ", percent(MagicalAtk()), "\n" }));
            //text1 += "- Magical Dmg + " + percent(MagicalAtk()) + "\n";
        }
        //10
        if (PhysicalDef() > 0)
        {
            if (GetLine(text1.ToString()) <= maxNum)
            {
                text1.Append(main.TextEdit(new string[] { "- Physical DEF + ", percent(PhysicalDef()), "\n" }));
                //text1 += "- Physical DEF + " + percent(PhysicalDef()) + "\n";
            }
            else
            {
                text2.Append(main.TextEdit(new string[] { "- Physical DEF + ", percent(PhysicalDef()), "\n" }));
                //text2 += "- Physical DEF + " + percent(PhysicalDef()) + "\n";
            }
        }
        //11 (ここから改行の可能性が出てくる．)
        if (MagicalDef() > 0)
        {
            if(GetLine(text1.ToString()) <= maxNum)
                text1.Append(main.TextEdit(new string[] { "- Magical DEF + ", percent(MagicalDef()), "\n" }));
            //text1 += "- Magical DEF + " + percent(MagicalDef()) + "\n";
            else
                text2.Append(main.TextEdit(new string[] { "- Magical DEF + ", percent(MagicalDef()), "\n" }));
        }
        if (MUL_EXP() > 0)
        {
            if (GetLine(text1.ToString()) <= maxNum)
                text1.Append(main.TextEdit(new string[] { "- EXP + ", percent(MUL_EXP()), "\n" }));
            //text1 += "- EXP + " + percent(MUL_EXP()) + "\n";
            else
                text2.Append(main.TextEdit(new string[] { "- EXP + ", percent(MUL_EXP()), "\n" }));
            //text2 += "- EXP + " + percent(MUL_EXP()) + "\n";
        }
        if (PROF() > 0)
        {
            if (GetLine(text1.ToString()) <= maxNum)
                text1.Append(main.TextEdit(new string[] { "- Skill Proficiency + ", percent(PROF()), "\n" }));
            //text1 += "- Skill Proficiency + " + percent(PROF()) + "\n";
            else
                text1.Append(main.TextEdit(new string[] { "- Skill Proficiency + ", percent(PROF()), "\n" }));
            //text2 += "- Skill Proficiency + " + percent(PROF()) + "\n";
        }
        if (DROP() > 0)
        {
            if (GetLine(text1.ToString()) <= maxNum)
                text1.Append(main.TextEdit(new string[] { "- Drop Chance + ", percent(DROP()), "\n" }));
            //text1 += "- Drop chance + " + percent(DROP()) + "\n";
            else
                text2.Append(main.TextEdit(new string[] { "- Drop Chance + ", percent(DROP()), "\n" }));
            //text2 += "- Drop chance  + " + percent(DROP()) + "\n";
        }
        if (ADD_ATK() > 0)
        {
            if (GetLine(text1.ToString()) <= maxNum)
                text1.Append(main.TextEdit(new string[] { "- ATK + ", tDigit(ADD_ATK()), "\n" }));
            //text1 += "- ATK + " + tDigit(ADD_ATK()) + "\n";
            else
                text2.Append(main.TextEdit(new string[] { "- ATK + ", tDigit(ADD_ATK()), "\n" }));
            //text2 += "- ATK + " + tDigit(ADD_ATK()) + "\n";
        }
        if (MUL_ATK() > 0)
        {
            if (GetLine(text1.ToString()) <= maxNum)
                text1.Append(main.TextEdit(new string[] { "- ATK + ", percent(MUL_ATK()), "\n" }));
            //text1 += "- ATK + " + percent(MUL_ATK()) + "\n";
            else
                text2.Append(main.TextEdit(new string[] { "- ATK + ", percent(MUL_ATK()), "\n" }));
            //text2 += "- ATK + " + percent(MUL_ATK()) + "\n";
        }
        if (ADD_MATK() > 0)
        {
            if (GetLine(text1.ToString()) <= maxNum)
                text1.Append(main.TextEdit(new string[] { "- MATK + ", tDigit(ADD_MATK()), "\n" }));
            //text1 += "- ATK + " + percent(MUL_ATK()) + "\n";
            else
                text2.Append(main.TextEdit(new string[] { "- MATK + ", tDigit(ADD_MATK()), "\n" }));
            //text2 += "- ATK + " + percent(MUL_ATK()) + "\n";

          // if (GetLine(text1.ToString) <= 9)
          //     text1 += "- MATK + " + tDigit(ADD_MATK()) + "\n";
          // else
          //     text2 += "- MATK + " + tDigit(ADD_MATK()) + "\n";
        }
        if (MUL_MATK() > 0)
        {
            if (GetLine(text1.ToString()) <= maxNum)
                text1.Append(main.TextEdit(new string[] { "- MATK + ", percent(MUL_MATK()), "\n" }));
            //text1 += "- ATK + " + percent(MUL_ATK()) + "\n";
            else
                text2.Append(main.TextEdit(new string[] { "- MATK + ", percent(MUL_MATK()), "\n" }));
            //text2 += "- ATK + " + percent(MUL_ATK()) + "\n";

           // if (GetLine(text1) <= 9)
           //     text1 += "- MATK + " + percent(MUL_MATK()) + "\n";
           // else
           //     text2 += "- MATK + " + percent(MUL_MATK()) + "\n";
        }
        if (ADD_DEF() > 0)
        {
            if (GetLine(text1.ToString()) <= maxNum)
                text1.Append(main.TextEdit(new string[] { "- DEF + ", tDigit(ADD_DEF()), "\n" }));
            //text1 += "- ATK + " + percent(MUL_ATK()) + "\n";
            else
                text2.Append(main.TextEdit(new string[] { "- DEF + ", tDigit(ADD_DEF()), "\n" }));
            //text2 += "- ATK + " + percent(MUL_ATK()) + "\n";

          //  if (GetLine(text1) <= 9)
          //      text1 += "- DEF + " + tDigit(ADD_DEF()) + "\n";
          //  else
          //      text2 += "- DEF + " + tDigit(ADD_DEF()) + "\n";
        }
        if (MUL_DEF() > 0)
        {
            if (GetLine(text1.ToString()) <= maxNum)
                text1.Append(main.TextEdit(new string[] { "- DEF + ", percent(MUL_DEF()), "\n" }));
            //text1 += "- ATK + " + percent(MUL_ATK()) + "\n";
            else
                text2.Append(main.TextEdit(new string[] { "- DEF + ", percent(MUL_DEF()), "\n" }));
            //text2 += "- ATK + " + percent(MUL_ATK()) + "\n";

           // if (GetLine(text1) <= 9)
           //     text1 += "- DEF + " + percent(MUL_DEF()) + "\n";
           // else
           //     text2 += "- DEF + " + percent(MUL_DEF()) + "\n";
        }
        if (ADD_MDEF() > 0)
        {
            if (GetLine(text1.ToString()) <= maxNum)
                text1.Append(main.TextEdit(new string[] { "- MDEF + ", tDigit(ADD_MDEF()), "\n" }));
            //text1 += "- ATK + " + percent(MUL_ATK()) + "\n";
            else
                text2.Append(main.TextEdit(new string[] { "- MDEF + ", tDigit(ADD_MDEF()), "\n" }));
            //text2 += "- ATK + " + percent(MUL_ATK()) + "\n";

           // if (GetLine(text1) <= 9)
           //     text1 += "- MDEF + " + tDigit(ADD_MDEF()) + "\n";
           // else
           //     text2 += "- MDEF + " + tDigit(ADD_MDEF()) + "\n";
        }
        if (MUL_MDEF() > 0)
        {
            if (GetLine(text1.ToString()) <= maxNum)
                text1.Append(main.TextEdit(new string[] { "- MDEF + ", percent(MUL_MDEF()), "\n" }));
            //text1 += "- ATK + " + percent(MUL_ATK()) + "\n";
            else
                text2.Append(main.TextEdit(new string[] { "- MDEF + ", percent(MUL_MDEF()), "\n" }));
            //text2 += "- ATK + " + percent(MUL_ATK()) + "\n";
           //
           // if (GetLine(text1) <= 9)
           //     text1 += "- MDEF + " + percent(MUL_MDEF()) + "\n";
           // else
           //     text2 += "- MDEF + " + percent(MUL_MDEF()) + "\n";
        }
        if (ADD_SPD() > 0)
        {
            if (GetLine(text1.ToString()) <= maxNum)
                text1.Append(main.TextEdit(new string[] { "- SPD + ", tDigit(ADD_SPD()), "\n" }));
            //text1 += "- ATK + " + percent(MUL_ATK()) + "\n";
            else
                text2.Append(main.TextEdit(new string[] { "- SPD + ", tDigit(ADD_SPD()), "\n" }));
            //text2 += "- ATK + " + percent(MUL_ATK()) + "\n";

           // if (GetLine(text1) <= 9)
           //     text1 += "- SPD + " + tDigit(ADD_SPD()) + "\n";
           // else
           //     text2 += "- SPD + " + tDigit(ADD_SPD()) + "\n";
        }
        if (MUL_SPD() > 0)
        {
            if (GetLine(text1.ToString()) <= maxNum)
                text1.Append(main.TextEdit(new string[] { "- SPD + ", percent(MUL_SPD()), "\n" }));
            //text1 += "- ATK + " + percent(MUL_ATK()) + "\n";
            else
                text2.Append(main.TextEdit(new string[] { "- SPD + ", percent(MUL_SPD()), "\n" }));

           // //text2 += "- ATK + " + percent(MUL_ATK()) + "\n";
           // if (GetLine(text1) <= 9)
           //     text1 += "- SPD + " + percent(MUL_SPD()) + "\n";
           // else
           //     text2 += "- SPD + " + percent(MUL_SPD()) + "\n";
        }

        return new string[] { text1.ToString(), text2.ToString() };
    }
    public IEnumerator UpdateStatus()
    {
        while (true)
        {
            //yield return new WaitUntil(() => main.GameController.currentCanvas == main.GameController.ArtifactCanvas);
            StatusText1.text = ShowStatus()[0];
            StatusText2.text = ShowStatus()[1];
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void Start()
    {
        StartCoroutine(UpdateStatus());
        UpdateValue();
    }

    int GetLine(string str)
    {
        string before = str;
        string after = str.Replace("\n", "");
        int ret = before.Length - after.Length;
        return ret;
    }

    public string percent(double d)
    {
        return tDigit(d * 100,1) + "%";

    }
}
