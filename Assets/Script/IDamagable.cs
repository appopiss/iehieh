using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    void InstantiateText(string str, Color color);
    double currentHp { get; set; }
    ALLY.Condition condition { get; set; }
    double currentExp { get; set; }
}
