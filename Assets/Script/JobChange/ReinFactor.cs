using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;

public class ReinFactor : BASE {

    public double GoldCap()
    {
        return main.S.ReincarnationNum * 500;
    }
    public double RebirthPoint()
    {
        return main.S.ReincarnationNum * 0.2;
    }
    public double StatusIncrease()
    {
        return main.S.ReincarnationNum * 0.1;
    }
    //public double Trap()
    //{
    //    return main.S.ReincarnationNum * 0.001;
    //}
}
