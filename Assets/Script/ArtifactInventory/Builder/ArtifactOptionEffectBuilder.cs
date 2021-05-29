using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IdleLibrary;
using IdleLibrary.Inventory;

public interface IOptionEffectBuilder
{
    List<IEffect> GetEffects();
}

/*
public class BronzeOptionBuilder : IOptionEffectBuilder
{

}
*/