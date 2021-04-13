using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAT : ENEMY
{
    new public MileStoneKind MileStoneKind = MileStoneKind.mp;

    public override void SetMileStoneKind()
    {
        mileStoneKind = MileStoneKind.mp;
    }
}
