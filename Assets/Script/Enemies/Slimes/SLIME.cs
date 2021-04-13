using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class SLIME : ENEMY {

    new MileStoneKind MileStoneKind = MileStoneKind.hp;

    public override void SetMileStoneKind()
    {
        mileStoneKind = MileStoneKind.hp;
    }
}
