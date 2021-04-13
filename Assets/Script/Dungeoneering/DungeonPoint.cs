using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;

public interface IPoint
{
    void GetPoint();
}
public class DungeonPoint : IPoint{

	DUNGEON thisDungeon;
    public DungeonPoint(DUNGEON thisDungeon)
    {
        this.thisDungeon = thisDungeon;
    }
    public void GetPoint()
    {
        
    }
}
