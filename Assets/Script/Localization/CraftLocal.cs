using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;

public class CraftLocal : BASE {

    static string[] defaultEquipName = new string[Enum.GetValues(typeof(ARTIFACT.ArtifactName)).Length];
    void GetDefaultName()
    {
        for (int i = 0; i < defaultEquipName.Length; i++)
        {
            defaultEquipName[i] = main.NewArtifacts[i].Name;
        }
    }
    void Awake()
    {
        GetDefaultName();
    }
	//素材はartictrlに書いてしまったので、装備名を...
	public static string GetEquipmentName(ARTIFACT.ArtifactName name)
    {
      if (LocalizeInitialize.language == Language.jp)
      {
          switch (name)
          {
              case ARTIFACT.ArtifactName.DullHeroSword:
                  return "なまくらの剣";
              case ARTIFACT.ArtifactName.BrittleHeroStaff:
                  return "もろい杖";
              case ARTIFACT.ArtifactName.FlimsyHeroWing:
                  return "薄っぺらい羽";
              case ARTIFACT.ArtifactName.OldHeroCloak:
                  return "古い服";
              case ARTIFACT.ArtifactName.SlimeSword:
                  return "スライムソード";
              case ARTIFACT.ArtifactName.SlimeRing:
                  return "スライムリング";
              case ARTIFACT.ArtifactName.SlimeHat:
                  return "スライムハット";
              case ARTIFACT.ArtifactName.BatCloak:
                  return "こうもりの服";
              case ARTIFACT.ArtifactName.BatShoes:
                  return "こうもりの靴";
              case ARTIFACT.ArtifactName.HerbloreGuide:
                  return "薬草学の知識";
              case ARTIFACT.ArtifactName.StoneHeroSword:
                  return "ストーンソード";
              case ARTIFACT.ArtifactName.CrystalHeroStaff:
                  return "クリスタルスタッフ";
              case ARTIFACT.ArtifactName.LeafHeroWing:
                  return "リーフウィング";
              case ARTIFACT.ArtifactName.StoneHeroCloak:
                  return "石の服";
              case ARTIFACT.ArtifactName.SlimeStick:
                  return "スライムスティック";
              case ARTIFACT.ArtifactName.AmberRing:
                  return "琥珀色の指輪";
              case ARTIFACT.ArtifactName.AzurePendant:
                  return "紺碧のペンダント";
              case ARTIFACT.ArtifactName.BindingSilk:
                  return "バインディングシルク";
              case ARTIFACT.ArtifactName.FairyBoots:
                  return "妖精のブーツ";
              case ARTIFACT.ArtifactName.VenomSword:
                  return "猛毒の剣";
              case ARTIFACT.ArtifactName.CrystalHeroSword:
                  return "クリスタルソード";
              case ARTIFACT.ArtifactName.LeafHeroStaff:
                  return "リーフスタッフ";
              case ARTIFACT.ArtifactName.StoneHeroWing:
                  return "ストーンウィング";
              case ARTIFACT.ArtifactName.LeafHeroCloak:
                  return "リーフの服";
              case ARTIFACT.ArtifactName.GolemCrest:
                  return "ゴーレムの紋章";
              case ARTIFACT.ArtifactName.ScaleArmor:
                  return "魚鱗の鎧";
              case ARTIFACT.ArtifactName.ArtificialGill:
                  return "人口エラ";
              case ARTIFACT.ArtifactName.ScaleRing:
                  return "鱗の指輪";
              case ARTIFACT.ArtifactName.CrystalHeroCloak:
                  return "クリスタルの服";
              case ARTIFACT.ArtifactName.MagicalFairyWing:
                  return "魔法の妖精の羽";
              case ARTIFACT.ArtifactName.FoxHat:
                  return "狐の帽子";
              case ARTIFACT.ArtifactName.FoxCoat:
                  return "狐のコート";
              case ARTIFACT.ArtifactName.FoxBoots:
                  return "狐のブーツ";
              case ARTIFACT.ArtifactName.GolemShield:
                  return "ゴーレムシールド";
              case ARTIFACT.ArtifactName.HealingStaff:
                  return "回復の杖";
              case ARTIFACT.ArtifactName.GoldenAmulet:
                  return "黄金のアミュレット";
              case ARTIFACT.ArtifactName.BananaCutter:
                  return "バナナカッター";
              case ARTIFACT.ArtifactName.LegendWarrior:
                  return "伝説の戦士の剣";
              case ARTIFACT.ArtifactName.LegendWizard:
                  return "伝説の魔法使いの杖";
              case ARTIFACT.ArtifactName.LegendAngel:
                  return "伝説の天使の羽";
              case ARTIFACT.ArtifactName.LegendWarriorRein:
                  return "転生した伝説の戦士の剣";
              case ARTIFACT.ArtifactName.LegendWizardRein:
                  return "転生した伝説の魔法使いの杖";
              case ARTIFACT.ArtifactName.LegendAngelRein:
                  return "転生した伝説の天使の羽";
          }
      }
      else if(LocalizeInitialize.language == Language.eng)
        {
            return defaultEquipName[(int)name];
        }
        return "";
    }
    public static string max()
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                return "\n<Max Cost> ( Hit M key )\n";
            case Language.jp:
                return "\n<最大まで強化するときの必要素材> (Mキーを押してください)\n";
            case Language.chi:
                return "\n<最大限度强化时所需材料> (按M键)\n";
        }
        return "\n<Max Cost> ( Hit M key )\n";
    }
    public static string evolute()
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                return "\n<After Evolution>\n";
            case Language.jp:
                return "\n<進化後に必要な素材>\n";
            case Language.chi:
                return "\n<进化后所需材料>\n";
        }
        return "\n<After Evolution>\n";
    }
    public static string cannotlevelup()
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                return "<color=red>This equipment can not be leveled up more.";
            case Language.jp:
                return "<color=red>この装備はこれ以上レベルアップできません.";
            case Language.chi:
                return "<color=red>这件装备的等级不能再高了.";
        }
        return "<color=red>This equipment can not be leveled up more.";
    }
    public static string cannotEvole(ARTIFACT arti)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                if (arti.CanEvolution())
                {
                    return  "\n<color=red>Evolve this Equipment by pressing \"E\" !\n( Level will be reset after evolution. )";
                }
                else
                {
                    return  "\n<color=red>Level Max, collect materials to evolve.";
                }
            case Language.jp:
                if (arti.CanEvolution())
                {
                    return "\n<color=red>この装備を進化させるには \"E\"ボタンを押してください.\n(進化後に装備のレベルはリセットされます.)";
                }
                else
                {
                    return "\n<color=red>最大レベルになりました. 素材を集めて進化させてください.";
                }
            case Language.chi:
                if (arti.CanEvolution())
                {
                    return "\n<color=red>按\"E\"键进化此装备! (进化后等级会被重置.)";
                }
                else
                {
                    return "\n<color=red>你现在已经到了最高级别. 请收集材料, 并加以发展.";
                }
        }
        if (arti.CanEvolution())
        {
            return "\n<color=red>Evolve this Equipment by pressing \"E\" !\n( Level will be reset after evolution. )";
        }
        else
        {
            return "\n<color=red>Level Max, collect materials to evolve.";
        }
    }
    public static string window2()
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                return "Effect";
            case Language.jp:
                return "効果";
            case Language.chi:
                return "效果";
        }
        return "Effect";
    }
    public static string window4(ARTIFACT artifact)
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                if (artifact.level == artifact.MaxLevel())
                {
                    return "Materials to evolute";
                }
                else
                {
                    return "Materials to Level Up";
                }
            case Language.jp:
                if (artifact.level == artifact.MaxLevel())
                {
                    return "進化するのに必要な素材";
                }
                else
                {
                    return "レベルアップするのに必要な素材";
                }
            case Language.chi:
                if (artifact.level == artifact.MaxLevel())
                {
                    return "蜕变的材料";
                }
                else
                {
                    return "提升等级的材料";
                }
        }
        if (artifact.level == artifact.MaxLevel())
        {
            return "Materials to evolute";
        }
        else
        {
            return "Materials to Level Up";
        }
    }


    public static string window6()
    {
        switch (LocalizeInitialize.language)
        {
            case Language.eng:
                return "Passive Effect by Evolution";
            case Language.jp:
                return "進化ボーナス";
            case Language.chi:
                return "进化的被动效应";
        }
        return "Passive Effect by Evolution";
    }
}
