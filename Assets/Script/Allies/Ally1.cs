using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally1 : ALLY
{
    public override double currentHp { get => main.SR.currentHp; set
            {
            if (main.cc.CurrentCurseId == CurseId.curse_of_blood && main.SR.currentHp < value)
            {

            }
            else
            {
                main.SR.currentHp = value;
            }
            }
    }
    public override double currentMp { get => main.SR.currentMp; set {
            if(main.cc.CurrentCurseId == CurseId.curse_of_blood && main.SR.currentMp > value && value < MP())
            {
                main.SR.currentHp -= main.SR.currentMp - value;
            }
            else
            {
                main.SR.currentMp = value;
            }
        } }
    public override int saveLevel { get => main.SR.level; set => main.SR.level = value; }
    public override double currentExp { get => main.SR.currentExp; set => main.SR.currentExp = value; }
    private void Awake()
    {
        AwakeAlly(100, 10,5,5, 0,0,1f);
    }

    private void Start()
    {
        StartAlly();
    }

    private void Update()
    {
        UpdateAlly();
    }
}
