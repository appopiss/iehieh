using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static BASE;
using static UsefulMethod;

//カースレインの報酬をここに書いていく
public class CurseReinFactor : MonoBehaviour
{

    //All Status Up(Mul)
    public List<Func<double>> AllStatusMul = new List<Func<double>>();

	//Range Up
	public List<Func<double>> RangeUp = new List<Func<double>>();

	//SE up
	public List<Func<double>> SeMul = new List<Func<double>>();

	//Gold Gain
	public List<Func<int>> GoldBonus = new List<Func<int>>();

	//ExpAdd
	public List<Func<double>> ExpBonus_Add = new List<Func<double>>();

	//Monster Gold Cap
	public List<Func<double>> MonsterGoldCap = new List<Func<double>>();

	//Regen
	public List<Func<double>> Add_HPregen = new List<Func<double>>();

	//DamageReduction(blood)
	public Func<double> Blood_DamageReduction = () => 0;

	//Profciency
	public List<Func<double>> Proficiency = new List<Func<double>>();

	//Area Mastery
	public List<Func<double>> MasteryNumDecay = new List<Func<double>>();
	public List<Func<double>> MasteryEffectMultiplier = new List<Func<double>>();

	//Resource Up
	public List<Func<double>> Stone1000 = new List<Func<double>>();
	public List<Func<double>> Crystal1000 = new List<Func<double>>();
	public List<Func<double>> Leaf1000 = new List<Func<double>>();

	//Gold Cap Bar
	public List<Func<double>> StoneGoldCap = new List<Func<double>>();
	public List<Func<double>> CrystalGoldCap = new List<Func<double>>();
	public List<Func<double>> LeafGoldCap = new List<Func<double>>();

}
