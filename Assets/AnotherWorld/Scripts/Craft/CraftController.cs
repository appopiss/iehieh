//using System.Collections;
//using System.Collections.Generic;
//using System;
//using UnityEngine;
//using UnityEngine.UI;
//using static Another.Main;
//using static UsefulMethod;
//using TMPro;
//using Another;
//using static Another.LocalizedText;
//using System.Linq;
//using static Another.Material;

//public class CraftController : MonoBehaviour
//{
//    public EQUIPMENT[] equipmentD, equipmentC, equipmentB, equipmentA, equipmentS;
//    public Sprite[] equipmentDsprite, equipmentCsprite, equipmentBsprite, equipmentAsprite, equipmentSsprite;
//    [NonSerialized] public EQUIPMENT[] equipments;
//    [NonSerialized] public Sprite[] equipmentSprites;
//    public int EquipmentSlotNum()
//    {
//        return 3;
//    }
//    public int CurrentEquippedNum()
//    {
//        int tempNum = 0;
//        for (int i = 0; i < equipments.Length; i++)
//        {
//            if (equipments[i].isEquipped) tempNum++;
//        }
//        return tempNum;
//    }
//    public bool CanEquipEq()
//    {
//        return CurrentEquippedNum() < EquipmentSlotNum();
//    }
//    public bool IsEnoughCost(Another.Material material, double value)
//    {
//        return main.S.AMaterials[(int)material] >= value;
//    }

//    public double TotalStatsAddFactors(Stats stats)
//    {
//        double tempValue = 0;
//        for (int i = 0; i < equipments.Length; i++)
//        {
//            tempValue += equipments[i].statsAddFactors[(int)stats];
//        }
//        return tempValue;
//    }
//    public double TotalStatsMulFactors(Stats stats)
//    {
//        double tempValue = 0;
//        for (int i = 0; i < equipments.Length; i++)
//        {
//            tempValue += equipments[i].statsMulFactors[(int)stats];
//        }
//        return tempValue;
//    }

//    private void Awake()
//    {
//        for (int i = 0; i < equipmentD.Length; i++)
//        {
//            equipmentD[i].grade = Grade.D;
//        }
//        for (int i = 0; i < equipmentC.Length; i++)
//        {
//            equipmentC[i].grade = Grade.C;
//        }
//        for (int i = 0; i < equipmentB.Length; i++)
//        {
//            equipmentB[i].grade = Grade.B;
//        }
//        for (int i = 0; i < equipmentA.Length; i++)
//        {
//            equipmentA[i].grade = Grade.A;
//        }
//        for (int i = 0; i < equipmentS.Length; i++)
//        {
//            equipmentS[i].grade = Grade.S;
//        }
//        List<EQUIPMENT> tempEqList = new List<EQUIPMENT>(equipmentD.Length + equipmentC.Length + equipmentB.Length + equipmentA.Length + equipmentS.Length);
//        tempEqList.AddRange(equipmentD);
//        tempEqList.AddRange(equipmentC);
//        tempEqList.AddRange(equipmentB);
//        tempEqList.AddRange(equipmentA);
//        tempEqList.AddRange(equipmentS);
//        equipments = tempEqList.ToArray();
//        List<Sprite> tempEqSpriteList = new List<Sprite>(equipmentDsprite.Length + equipmentCsprite.Length + equipmentBsprite.Length + equipmentAsprite.Length + equipmentSsprite.Length);
//        tempEqSpriteList.AddRange(equipmentDsprite);
//        tempEqSpriteList.AddRange(equipmentCsprite);
//        tempEqSpriteList.AddRange(equipmentBsprite);
//        tempEqSpriteList.AddRange(equipmentAsprite);
//        tempEqSpriteList.AddRange(equipmentSsprite);
//        equipmentSprites = tempEqSpriteList.ToArray();
//    }

//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
//    }

//    string InventoryLineString(int id)
//    {
//        return optStr + ((Another.Material)id).ToString() + "   *   " + tDigit(main.S.AMaterials[id]);
//    }
//    string InventoryString()
//    {
//        string tempString = "<size=26>";
//        for (int i = 0; i < main.S.AMaterials.Length; i++)
//        {
//            if (main.S.AMaterials[i] > 0)
//                tempString += InventoryLineString(i) + "\n";
//        }
//        return tempString;
//    }
//}
//public enum Equipment
//{
//    //Grade D
//    DullHeroSword,
//    BrittleHeroStaff,
//    FlimsyHeroWing,
//    OldHeroCloak,
//    SlimeSword,
//    SlimeRing,
//    SlimeHat,
//    BatCloak,
//    BatShoes,
//    HerbloreGuide,
//    //C
//    StoneHeroSword,
//    CrystalHeroStaff,
//    LeafHeroWing,
//    StoneHeroCloak,
//    SlimeStick,
//    AmberRing,
//    AzurePendant,
//    BindingSilk,
//    FairyBoots,
//    VenomSword,
//    //B
//    CrystalHeroSword,
//    LeafHeroStaff,
//    StoneHeroWing,
//    CrystalHeroCloak,
//    MagicalFairyWing,
//    FoxHat,
//    FoxCoat,
//    FoxBoots,
//    GolemShield,
//    HealingStaff,
//    //A
//    LeafHeroSword,
//    StoneHeroStaff,
//    CrystalHeroWing,
//    LeafHeroCloak,
//    GolemCrest,
//    ScaleArmor,
//    ArtificialGill,
//    ScaleRing,
//    GoldenAmulet,
//    BananaCutter,
//    //S
//    LegendWarrior,
//    LegendWizard,
//    LegendAngel,
//    LegendWarriorRein,
//    LegendWizardRein,
//    LegendAngelRein,

//}
//public enum Calculation
//{
//    Add,
//    Mul,
//}
//public enum Grade
//{
//    D,
//    C,
//    B,
//    A,
//    S
//}

