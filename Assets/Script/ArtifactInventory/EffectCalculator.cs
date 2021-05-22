using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IdleLibrary.Inventory;

//Inventoryのアイテムを受け取り、エフェクトを計算する！
//一回inventoryでやるが、後々抽象化したい
public class EffectCalculator
{
    private Dictionary<IStatsBreakdown, double> calculateDic = new Dictionary<IStatsBreakdown, double>();
    public void Update()
    {

    }
}
