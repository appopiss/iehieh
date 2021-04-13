using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using static UsefulMethod;
using TMPro;
using static ArtiCtrl;
using static ARTIFACT.StatusKind;
using static ARTIFACT.CalWay;

[System.Serializable]
public class SampleTable : Serialize.TableBase<ArtiCtrl.MaterialList, int, SamplePair>
{


}
[System.Serializable]
public class SamplePair : Serialize.KeyAndValue<ArtiCtrl.MaterialList, int>
{

    public SamplePair(ArtiCtrl.MaterialList key, int value, double tei) : base(key, value, tei)
    {

    }
}

public class ARTIFACT : BASE, IPointerDownHandler
{

    public GameObject window;
    public GameObject completeWindow;
    GameObject upgradeWindow;
    GameObject hatena;
    GameObject equipText;
    TextMeshProUGUI eqText;
    GameObject EvolutionNumText;
    Button hatenaButton;
    Button upgradeButton;
    GameObject P_title;
    GameObject ParmanentEffectObject;
    //GameObject making;
    Blink blink;
    public enum CalculateWay
    {
        exp,
        add,
        log
    }
    public enum Rank
    {
        D,
        C,
        B,
        A,
        Epic
    }
    public enum SetItem
    {
        Nothing,
        Slime,
        Bat,
        Fairy,
        Fox,
        Golem
    }
    public SetItem setItem;
    public Rank rank;
    public string Name;
    [TextAreaAttribute(10, 100)]//hight:10,width:100
    public string Effect;
    public Func<string> EffectText;
    public enum Condition
    {
        locked,
        complete
    }
    public Condition condition { get => main.S.condition[(int)artifactName]; set => main.S.condition[(int)artifactName] = value; }
    public bool isEquipped { get => main.S.isEquipped[(int)artifactName]; set => main.S.isEquipped[(int)artifactName] = value; }
    public bool isFavoriteEquipped { get => main.S.isFavoriteEquipped[(int)artifactName]; set => main.S.isFavoriteEquipped[(int)artifactName] = value; }
    public int level { get => main.S.level[(int)artifactName]; set => main.S.level[(int)artifactName] = value; }
    public SampleTable RequiredMaterial;
    public SampleTable UpgradeMaterial;
    public SampleTable EvolutionMaterial;
    //public int ArtifactId;
    public ArtifactName artifactName;
    bool canNotEvolve;
    public bool stayAfterReincarnation = false;
    public string ParmanentEffectText()
    {
        string text = "";
        int tempIndex = 0;
        foreach (Status status in gameObject.GetComponents<Status>())
        {
            if (status.statusKind == other)
            {
                continue;
            }

            if (tempIndex == 0)
            {
                text += status.ParmanentValueText();
            }
            else
            {
                text += "\n" + status.ParmanentValueText();
            }
            tempIndex += 1;

        }
        return text;
    }



    int maxLevel = 100;
    public bool canNotPowerUp;
    public int IncrementFactorByEvolution;
    public int MaxLevel()
    {
        return maxLevel + IncrementFactorByEvolution * (EvolutionNum * (EvolutionNum + 1) / 2);//級数
    }
    //パッシブ計算だけで使う関数だよ
    public int MaxLevel(int i)
    {
        return maxLevel + i * IncrementFactorByEvolution;
    }
    public void ADD_RequiredMaterial(ArtiCtrl.MaterialList material, int RequiredNum)
    {
        SamplePair pair1 = new SamplePair(material, RequiredNum, 0);
        RequiredMaterial.list.Add(pair1);
    }
    public void ADD_UpgradeMaterial(ArtiCtrl.MaterialList material, int RequiredNum, int increment)
    {
        SamplePair pair1 = new SamplePair(material, RequiredNum, increment);
        UpgradeMaterial.list.Add(pair1);
    }
    public void ADD_EvolutionMaterial(ArtiCtrl.MaterialList material, int RequiredNum, int addNum)
    {
        SamplePair pair1 = new SamplePair(material, RequiredNum, addNum);
        EvolutionMaterial.list.Add(pair1);
    }
    public int EvolutionNum { get => main.S.evolutionNum[(int)artifactName]; set => main.S.evolutionNum[(int)artifactName] = value; }

    // Use this for initialization
    void Awake()
    {
        StartBASE();
        hatena = gameObject.transform.GetChild(0).gameObject;
        blink = gameObject.GetComponentInChildren<Blink>();
        hatenaButton = gameObject.transform.GetChild(0).GetComponent<Button>();
        equipText = gameObject.transform.GetChild(1).gameObject;
        eqText = equipText.GetComponent<TextMeshProUGUI>();
        upgradeButton = gameObject.transform.GetChild(2).GetComponent<Button>();
        upgradeButton.onClick.AddListener(Upgrade);
        setFalse(P_title);
        setFalse(ParmanentEffectObject);
        InstantiateWindow();
        InstantiateCompleteWindow();
        P_title = completeWindow.transform.GetChild(6).gameObject;
        ParmanentEffectObject = completeWindow.transform.GetChild(7).gameObject;
        EvolutionNumText = gameObject.transform.GetChild(4).gameObject;
        setFalse(EvolutionNumText);
        RequiredMaterial = new SampleTable();
        RequiredMaterial.list = new List<SamplePair>();
        UpgradeMaterial = new SampleTable();
        UpgradeMaterial.list = new List<SamplePair>();
        EvolutionMaterial = new SampleTable();
        EvolutionMaterial.list = new List<SamplePair>();
        //デフォルト値を設定
        maxLevel = 100;
        IncrementFactorByEvolution = 10;
        switch (artifactName)
        {
            case ArtifactName.DullHeroSword:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, other, add, 0);
                gameObject.GetComponent<Status>().FreeText = () =>
                     "Unleash Warrior Active Skill";
                //↓これは，進化するたびにATK+10のパーマネントボーナスがもらえることを意味する．
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, ATK, add, 2, () => EvolutionNum * 10, () => 2 + EvolutionNum * 0.1);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, MP, add, 1, () => EvolutionNum * 5, () => 1 + EvolutionNum * 0.05);
                maxLevel = 30;
                IncrementFactorByEvolution = 2;
                ADD_RequiredMaterial(MaterialList.Stone, 5);
                ADD_UpgradeMaterial(MaterialList.MonsterFluid, 10, 5);
                ADD_UpgradeMaterial(MaterialList.OozeStainedCloth, 5, 1);
                ADD_EvolutionMaterial(MaterialList.RelicStone, 2, 1);
                ADD_EvolutionMaterial(MaterialList.Stone, 7, 2);
                break;
            case ArtifactName.BrittleHeroStaff:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, other, add, 0);
                gameObject.GetComponent<Status>().FreeText = () =>
                     "Unleash Wizard Active Skill";
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, MATK, add, 2, () => EvolutionNum * 10, () => 2 + EvolutionNum * 0.1);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, MP, add, 1, () => EvolutionNum * 5, () => 1 + EvolutionNum * 0.05);
                maxLevel = 30;
                IncrementFactorByEvolution = 2;
                ADD_RequiredMaterial(MaterialList.Crystal, 5);
                ADD_UpgradeMaterial(MaterialList.MonsterFluid, 10, 5);
                ADD_UpgradeMaterial(MaterialList.OozeStainedCloth, 5, 1);
                ADD_EvolutionMaterial(MaterialList.RelicStone, 2, 1);
                ADD_EvolutionMaterial(MaterialList.Crystal, 7, 2);
                break;
            case ArtifactName.FlimsyHeroWing:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, other, add, 0);
                gameObject.GetComponent<Status>().FreeText = () =>
                     "Unleash Angel Active Skill";
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, ATK, add, 1, () => EvolutionNum * 5, () => 1 + EvolutionNum * 0.05);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, MATK, add, 1, () => EvolutionNum * 5, () => 1 + EvolutionNum * 0.05);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, MP, add, 1, () => EvolutionNum * 5, () => 1 + EvolutionNum * 0.05);
                maxLevel = 30;
                IncrementFactorByEvolution = 2;
                ADD_RequiredMaterial(MaterialList.Leaf, 5);
                ADD_UpgradeMaterial(MaterialList.MonsterFluid, 10, 5);
                ADD_UpgradeMaterial(MaterialList.OozeStainedCloth, 5, 1);
                ADD_EvolutionMaterial(MaterialList.RelicStone, 2, 1);
                ADD_EvolutionMaterial(MaterialList.Leaf, 7, 2);
                break;
            case ArtifactName.OldHeroCloak:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, HP, mul, 0.002, () => EvolutionNum * 0.01, () => (EvolutionNum * 0.0001) + 0.002);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, DEF, add, 1, () => EvolutionNum * 5, () => EvolutionNum * 0.25 + 1);
                maxLevel = 30;
                IncrementFactorByEvolution = 2;
                ADD_RequiredMaterial(MaterialList.MonsterFluid, 1);
                ADD_UpgradeMaterial(MaterialList.MonsterFluid, 5, 2);
                ADD_EvolutionMaterial(MaterialList.CarvedIdol, 2, 1);
                break;
            //gameObject.AddComponent<Status>().AwakeStatus(artifactName, HP, add, 2, () => EvolutionNum * 50);
            //gameObject.AddComponent<Status>().AwakeStatus(artifactName, MP, add, 1, () => EvolutionNum * 25);
            //maxLevel = 50;
            //IncrementFactorByEvolution = 25;
            //ADD_RequiredMaterial(MaterialList.MonsterFluid, 1);
            //ADD_UpgradeMaterial(MaterialList.MonsterFluid, 10);
            //ADD_EvolutionMaterial(MaterialList.CarvedIdol, 1, 1);
            //break;
            case ArtifactName.SlimeSword:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, HP, add, 10, () => EvolutionNum * 20, () => (EvolutionNum * 1) + 10);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, ATK, mul, 0.001, () => EvolutionNum * 0.01, () => 0.001 + (EvolutionNum * 0.0005));
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, other, add, 1);
                gameObject.GetComponents<Status>()[2].FreeText
                    = () =>
                    {
                        if (main.slimeSet.SetSlime)
                        {
                            if (!main.slimeSet.SetSlime4)
                            {
                                return "Slime Costume\n- Slime Ball DPS : " + tDigit(main.slimeSet.SlimeBallDamage() / main.slimeSet.SlimeBallInterval());
                            }
                            else
                            {
                                return "Slime Costume\n- Slime Ball DPS : " + tDigit(main.slimeSet.SlimeBallDamage() / main.slimeSet.SlimeBallInterval()) + " * " + (int)(Math.Min(4 + main.NewArtifacts[(int)ArtifactName.SlimeStick].level / 10, 8));
                            }
                        }
                        else
                        {
                            return "???\n- ???";
                        }
                    };
                maxLevel = 10;
                IncrementFactorByEvolution = 3;
                ADD_RequiredMaterial(MaterialList.MonsterFluid, 50);
                ADD_RequiredMaterial(MaterialList.GooeySludge, 7);
                ADD_RequiredMaterial(MaterialList.OilOfSlime, 1);
                ADD_UpgradeMaterial(MaterialList.GooeySludge, 5, 2);
                ADD_UpgradeMaterial(MaterialList.OilOfSlime, 5, 2);
                ADD_EvolutionMaterial(MaterialList.CarvedIdol, 11, 2);
                ADD_EvolutionMaterial(MaterialList.OilOfSlime, 8, 2);
                break;
            case ArtifactName.SlimeRing:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, stone, mul, 0.2, () => EvolutionNum * 2, () => 0.2 + 0.1 * (main.NewArtifacts[(int)artifactName].EvolutionNum));
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, crystal, mul, 0.2, () => EvolutionNum * 2, () => 0.2 + 0.1 * (main.NewArtifacts[(int)artifactName].EvolutionNum));
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, leaf, mul, 0.2, () => EvolutionNum * 2, () => 0.2 + 0.1 * (main.NewArtifacts[(int)artifactName].EvolutionNum));
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, other, add, 1);
                gameObject.GetComponents<Status>()[3].FreeText
                    = () =>
                    {
                        if (main.slimeSet.SetSlime)
                        {
                            if (!main.slimeSet.SetSlime4)
                            {
                                return "Slime Costume\n- Slime Ball DPS : " + tDigit(main.slimeSet.SlimeBallDamage() / main.slimeSet.SlimeBallInterval());
                            }
                            else
                            {
                                return "Slime Costume\n- Slime Ball DPS : " + tDigit(main.slimeSet.SlimeBallDamage() / main.slimeSet.SlimeBallInterval()) + " * " + (int)(Math.Min(4 + main.NewArtifacts[(int)ArtifactName.SlimeStick].level / 10, 8));
                            }
                        }
                        else
                        {
                            return "???\n- ???";
                        }
                    };
                maxLevel = 20;
                IncrementFactorByEvolution = 2;
                ADD_RequiredMaterial(MaterialList.MonsterFluid, 200);
                ADD_RequiredMaterial(MaterialList.OilOfSlime, 3);
                ADD_UpgradeMaterial(MaterialList.MonsterFluid, 20, 5);
                ADD_UpgradeMaterial(MaterialList.GooeySludge, 10, 2);
                ADD_EvolutionMaterial(MaterialList.RelicStone, 12, 2);
                ADD_EvolutionMaterial(MaterialList.OilOfSlime, 9, 1);
                break;
            case ArtifactName.SlimeHat:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, MDEF, add, 1, () => EvolutionNum * 10, () => (EvolutionNum * 0.25) + 1);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, exp, mul, 0.005, () => EvolutionNum * 0.05, () => 0.005 + (EvolutionNum * 0.001));
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, other, add, 1);
                gameObject.GetComponents<Status>()[2].FreeText
                    = () =>
                    {
                        if (main.slimeSet.SetSlime)
                        {
                            if (!main.slimeSet.SetSlime4)
                            {
                                return "Slime Costume\n- Slime Ball DPS : " + tDigit(main.slimeSet.SlimeBallDamage() / main.slimeSet.SlimeBallInterval());
                            }
                            else
                            {
                                return "Slime Costume\n- Slime Ball DPS : " + tDigit(main.slimeSet.SlimeBallDamage() / main.slimeSet.SlimeBallInterval()) + " * " + (int)(Math.Min(4 + main.NewArtifacts[(int)ArtifactName.SlimeStick].level / 10, 8));
                            }
                        }
                        else
                        {
                            return "???\n- ???";
                        }
                    };
                maxLevel = 10;
                IncrementFactorByEvolution = 3;
                ADD_RequiredMaterial(MaterialList.MonsterFluid, 50);
                ADD_RequiredMaterial(MaterialList.OozeStainedCloth, 30);
                ADD_RequiredMaterial(MaterialList.CarvedIdol, 2);
                ADD_UpgradeMaterial(MaterialList.OozeStainedCloth, 10, 5);
                ADD_UpgradeMaterial(MaterialList.CarvedIdol, 1, 2);
                ADD_EvolutionMaterial(MaterialList.OilOfSlime, 11, 2);
                ADD_EvolutionMaterial(MaterialList.OozeStainedCloth, 50, 5);
                break;
            case ArtifactName.BatCloak:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, spd, add, 5, () => EvolutionNum * 20, () => (EvolutionNum * 0.1) + 5);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, prof, mul, 0.1, () => EvolutionNum * 0.5, () => (EvolutionNum * 0.01) + 0.1);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, other, add, 1);
                gameObject.GetComponents<Status>()[2].FreeText
                    = () =>
                    {
                        if (main.ally.SetEffectObject.GetComponent<BatSet>().isBatSet())
                        {
                            return "Dodge Chance : + " + percent(main.ally.SetEffectObject.GetComponent<BatSet>().CalculateDodgeRate());
                        }
                        else
                        {
                            return "???";
                        }
                    };
                maxLevel = 30;
                IncrementFactorByEvolution = 3;
                ADD_RequiredMaterial(MaterialList.BatPelt, 20);
                ADD_RequiredMaterial(MaterialList.BatWing, 10);
                ADD_UpgradeMaterial(MaterialList.BatPelt, 5, 5);
                ADD_UpgradeMaterial(MaterialList.BatWing, 10, 2);
                ADD_EvolutionMaterial(MaterialList.BatPelt, 35, 5);
                ADD_EvolutionMaterial(MaterialList.BatWing, 15, 2);
                ADD_EvolutionMaterial(MaterialList.BatTooth, 3, 1);
                break;
            case ArtifactName.BatShoes:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, MP, add, 5, () => EvolutionNum * 30, () => 5 + EvolutionNum * 1);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, spd, add, 10, () => EvolutionNum * 50, () => 10 + EvolutionNum * 2);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, other, add, 1);
                gameObject.GetComponents<Status>()[2].FreeText
                    = () =>
                    {
                        if (main.ally.SetEffectObject.GetComponent<BatSet>().isBatSet())
                        {
                            return "Dodge Chance : + " + percent(main.ally.SetEffectObject.GetComponent<BatSet>().CalculateDodgeRate());
                        }
                        else
                        {
                            return "???";
                        }
                    };
                maxLevel = 20;
                IncrementFactorByEvolution = 3;
                ADD_RequiredMaterial(MaterialList.BatWing, 30);
                ADD_RequiredMaterial(MaterialList.BatFeet, 1);
                ADD_UpgradeMaterial(MaterialList.BatWing, 15, 2);
                ADD_UpgradeMaterial(MaterialList.BatFeet, 2, 1);
                ADD_EvolutionMaterial(MaterialList.BatPelt, 55, 10);
                ADD_EvolutionMaterial(MaterialList.BatWing, 25, 5);
                ADD_EvolutionMaterial(MaterialList.BatFeet, 3, 3);
                break;
            case ArtifactName.HerbloreGuide:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, other, mul, 0.0001);
                gameObject.GetComponent<Status>().FreeText = () =>
                      "You may gain special materials to use for alchemy.\n- Gain Chance : " + percent(gameObject.GetComponent<Status>().GetValue()) + " while moving.";
                maxLevel = 500;
                canNotEvolve = true;
                ADD_RequiredMaterial(MaterialList.NatureShard, 1);
                ADD_UpgradeMaterial(MaterialList.NatureShard, 5, 0);
                ADD_UpgradeMaterial(MaterialList.NatureCrystal, 1, 0);
                break;

            //RankC
            case ArtifactName.StoneHeroSword:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, ATK, add, 4, () => EvolutionNum * 20, () => 4 + EvolutionNum * 0.2);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, stone, mul, 0.25, () => EvolutionNum * 5, () => (EvolutionNum * 0.02) + 0.25);
                maxLevel = 30;
                IncrementFactorByEvolution = 3;
                ADD_RequiredMaterial(MaterialList.Stone, 9);
                ADD_RequiredMaterial(MaterialList.FrostShard, 5);
                ADD_UpgradeMaterial(MaterialList.MonsterFluid, 50, 10);
                ADD_UpgradeMaterial(MaterialList.RelicStone, 4, 1);
                ADD_EvolutionMaterial(MaterialList.Stone, 12, 2);
                ADD_EvolutionMaterial(MaterialList.FrostShard, 1, 1);
                break;
            case ArtifactName.CrystalHeroStaff:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, MATK, add, 4, () => EvolutionNum * 20, () => 4 + EvolutionNum * 0.2);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, crystal, mul, 0.25, () => EvolutionNum * 5, () => (EvolutionNum * 0.02) + 0.25);
                maxLevel = 30;
                IncrementFactorByEvolution = 3;
                ADD_RequiredMaterial(MaterialList.Crystal, 9);
                ADD_RequiredMaterial(MaterialList.FlameShard, 5);
                ADD_UpgradeMaterial(MaterialList.MonsterFluid, 50, 10);
                ADD_UpgradeMaterial(MaterialList.RelicStone, 4, 1);
                ADD_EvolutionMaterial(MaterialList.Crystal, 12, 2);
                ADD_EvolutionMaterial(MaterialList.FlameShard, 1, 1);
                break;
            case ArtifactName.LeafHeroWing:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, ATK, add, 2, () => EvolutionNum * 10, () => 2 + EvolutionNum * 0.1);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, MATK, add, 2, () => EvolutionNum * 10, () => 2 + EvolutionNum * 0.1);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, leaf, mul, 0.25, () => EvolutionNum * 5, () => (EvolutionNum * 0.02) + 0.25);
                maxLevel = 30;
                IncrementFactorByEvolution = 3;
                ADD_RequiredMaterial(MaterialList.Leaf, 9);
                ADD_RequiredMaterial(MaterialList.LightningShard, 2);
                ADD_UpgradeMaterial(MaterialList.MonsterFluid, 50, 10);
                ADD_UpgradeMaterial(MaterialList.RelicStone, 4, 1);
                ADD_EvolutionMaterial(MaterialList.Leaf, 12, 1);
                ADD_EvolutionMaterial(MaterialList.LightningShard, 1, 1);
                break;
            case ArtifactName.StoneHeroCloak:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, HP, mul, 0.01, () => EvolutionNum * 0.1, () => 0.01 + 0.001 * EvolutionNum);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, DEF, mul, 0.005, () => EvolutionNum * 0.02, () => (EvolutionNum * 0.001) + 0.005);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, MDEF, mul, 0.005, () => EvolutionNum * 0.02, () => (EvolutionNum * 0.001) + 0.005);
                maxLevel = 30;
                IncrementFactorByEvolution = 3;
                ADD_RequiredMaterial(MaterialList.MonsterFluid, 200);
                ADD_RequiredMaterial(MaterialList.RelicStone, 30);
                ADD_UpgradeMaterial(MaterialList.RelicStone, 5, 1);
                ADD_UpgradeMaterial(MaterialList.MonsterFluid, 50, 5);
                ADD_EvolutionMaterial(MaterialList.RelicStone, 15, 5);
                ADD_EvolutionMaterial(MaterialList.NatureCrystal, 1, 1);
                break;
            case ArtifactName.SlimeStick:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, other, mul, 0.0001, () => 0, () => 0.0001);
                gameObject.GetComponent<Status>().FreeText = () =>
                      "Regenerate MP : " + percent(gameObject.GetComponent<Status>().GetValue()) + " / s";
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, MP, add, 5, () => EvolutionNum * 30, () => EvolutionNum + 5);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, MATK, mul, 0.005, () => EvolutionNum * 0.02, () => (EvolutionNum * 0.001) + 0.005);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, other, add, 1);
                gameObject.GetComponents<Status>()[3].FreeText
                    = () =>
                    {
                        if (main.slimeSet.SetSlime)
                        {
                            if (!main.slimeSet.SetSlime4)
                            {
                                return "Slime Costume\n- Slime Ball DPS : " + tDigit(main.slimeSet.SlimeBallDamage() / main.slimeSet.SlimeBallInterval());
                            }
                            else
                            {
                                return "Slime Costume\n- Slime Ball DPS : " + tDigit(main.slimeSet.SlimeBallDamage() / main.slimeSet.SlimeBallInterval()) + " * " + (int)(Math.Min(4 + main.NewArtifacts[(int)ArtifactName.SlimeStick].level / 10, 8));
                            }
                        }
                        else
                        {
                            return "???\n- ???";
                        }
                    };
                maxLevel = 20;
                IncrementFactorByEvolution = 3;
                ADD_RequiredMaterial(MaterialList.MonsterFluid, 100);
                ADD_RequiredMaterial(MaterialList.GooeySludge, 50);
                ADD_RequiredMaterial(MaterialList.SlimeEyeBall, 3);
                ADD_RequiredMaterial(MaterialList.SlimeCrown, 1);
                ADD_UpgradeMaterial(MaterialList.MonsterFluid, 100, 50);
                ADD_UpgradeMaterial(MaterialList.OozeStainedCloth, 30, 15);
                ADD_UpgradeMaterial(MaterialList.OilOfSlime, 10, 5);
                ADD_EvolutionMaterial(MaterialList.GooeySludge, 55, 5);
                ADD_EvolutionMaterial(MaterialList.OilOfSlime, 21, 1);
                ADD_EvolutionMaterial(MaterialList.ShinySlimeCrown, 1, 1);
                break;
            case ArtifactName.AmberRing:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, gold, add, 1, () => EvolutionNum * 2, () => 1 + (EvolutionNum * 0.25));
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, other, mul, 0.0005, () => 0, () => 0.0005);
                gameObject.GetComponents<Status>()[1].FreeText = () =>
                "Critical Chance : " + percent(gameObject.GetComponent<ARTIFACT>().level * 0.0005);
                maxLevel = 10;
                IncrementFactorByEvolution = 1;
                ADD_RequiredMaterial(MaterialList.SpiderBlood, 50);
                ADD_RequiredMaterial(MaterialList.FairyCoin, 1);
                ADD_RequiredMaterial(MaterialList.GoldenShard, 5);
                ADD_RequiredMaterial(MaterialList.GoldenCrystal, 1);
                ADD_UpgradeMaterial(MaterialList.GoldenShard, 2, 2);
                ADD_UpgradeMaterial(MaterialList.SpiderBlood, 20, 10);
                ADD_UpgradeMaterial(MaterialList.FairyCoin, 1, 1);
                ADD_EvolutionMaterial(MaterialList.SpiderBlood, 100, 100);
                ADD_EvolutionMaterial(MaterialList.FairyHeart, 5, 5);
                ADD_EvolutionMaterial(MaterialList.GoldenShard, 20, 20);
                ADD_EvolutionMaterial(MaterialList.GoldenCrystal, 5, 5);
                break;
            case ArtifactName.AzurePendant:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, MP, add, 20, () => EvolutionNum * 100, () => EvolutionNum * 5 + 20);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, exp, mul, .025, () => EvolutionNum * 0.05, () => (EvolutionNum * 0.001) + .025);
                maxLevel = 10;
                IncrementFactorByEvolution = 3;
                ADD_RequiredMaterial(MaterialList.RelicStone, 30);
                ADD_RequiredMaterial(MaterialList.EnchantedCloth, 30);
                ADD_RequiredMaterial(MaterialList.FairyHeart, 1);
                ADD_RequiredMaterial(MaterialList.AncientCoin, 3);
                ADD_UpgradeMaterial(MaterialList.FairyDust, 50, 10);
                ADD_UpgradeMaterial(MaterialList.EnchantedCloth, 15, 5);
                ADD_UpgradeMaterial(MaterialList.FairyCoin, 2, 1);
                ADD_EvolutionMaterial(MaterialList.FairyCoin, 3, 1);
                ADD_EvolutionMaterial(MaterialList.AncientCoin, 3, 1);
                ADD_EvolutionMaterial(MaterialList.ManaShard, 1, 1);
                break;
            case ArtifactName.BindingSilk:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, drop, mul, 0.005, () => EvolutionNum * 0.025, () => 0.005 + EvolutionNum * 0.0005);
                maxLevel = 10;
                IncrementFactorByEvolution = 1;
                ADD_RequiredMaterial(MaterialList.SpiderBlood, 500);
                ADD_RequiredMaterial(MaterialList.SpiderFang, 200);
                ADD_RequiredMaterial(MaterialList.SpiderSilk, 100);
                ADD_RequiredMaterial(MaterialList.VenomSoakedCloth, 3);
                ADD_UpgradeMaterial(MaterialList.SpiderBlood, 250, 125);
                ADD_UpgradeMaterial(MaterialList.SpiderFang, 100, 50);
                ADD_UpgradeMaterial(MaterialList.SpiderSilk, 50, 25);
                ADD_UpgradeMaterial(MaterialList.VenomSoakedCloth, 1, 1);
                ADD_EvolutionMaterial(MaterialList.SpiderHeart, 15, 15);
                ADD_EvolutionMaterial(MaterialList.WebbedCore, 3, 3);
                ADD_EvolutionMaterial(MaterialList.SpiderIronSilk, 1, 2);
                ADD_EvolutionMaterial(MaterialList.DeathpiderCore, 1, 1);
                break;
            case ArtifactName.GolemShield:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, DEF, add, 50, () => EvolutionNum * 50, () => 50 + (main.NewArtifacts[(int)artifactName].EvolutionNum) * 5);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, MDEF, add, 50, () => EvolutionNum * 50, () => 50 + (main.NewArtifacts[(int)artifactName].EvolutionNum) * 5);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, physicalDEF, mul, 0.001, () => EvolutionNum * 0.005, () => (EvolutionNum * 0.0002) + 0.001);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, magicalDEF, mul, 0.001, () => EvolutionNum * 0.005, () => (EvolutionNum * 0.0002) + 0.001);
                maxLevel = 10;
                IncrementFactorByEvolution = 4;
                ADD_RequiredMaterial(MaterialList.RobustBone, 1);
                ADD_UpgradeMaterial(MaterialList.RobustBone, 1, 0);
                ADD_EvolutionMaterial(MaterialList.RobustBone, 2, 2);
                ADD_EvolutionMaterial(MaterialList.GolemShard, 1, 1);
                break;

            //これも反映してない
            case ArtifactName.VenomSword:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, other, add, 0.00025);
                gameObject.GetComponent<Status>().FreeText = () =>
                "Poison Attack Chance : " + percent(main.NewArtifacts[(int)artifactName].level * 0.00025, 3) + "\n- Poison Damage : 0.01% of Enemy's HP / s";
                maxLevel = 100;
                canNotEvolve = true;
                ADD_RequiredMaterial(MaterialList.VenomSoakedCloth, 50);
                ADD_RequiredMaterial(MaterialList.FairyDust, 100);
                ADD_RequiredMaterial(MaterialList.BloodOfFairy, 10);
                ADD_RequiredMaterial(MaterialList.PoisonShard, 5);
                ADD_UpgradeMaterial(MaterialList.VenomSoakedCloth, 50, 0);
                ADD_UpgradeMaterial(MaterialList.BloodOfFairy, 10, 0);
                ADD_UpgradeMaterial(MaterialList.PoisonShard, 10, 0);
                ADD_UpgradeMaterial(MaterialList.PoisonCrystal, 3, 0);

                break;


            //RankB
            case ArtifactName.CrystalHeroSword:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, physicalATK, mul, 0.020, () => EvolutionNum * 0.1, () => 0.02 + (main.NewArtifacts[(int)artifactName].EvolutionNum) * 0.005);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, crystal, mul, 1, () => EvolutionNum * 5);
                maxLevel = 20;
                IncrementFactorByEvolution = 5;
                ADD_RequiredMaterial(MaterialList.Crystal, 25);
                ADD_RequiredMaterial(MaterialList.RelicStone, 100);
                ADD_RequiredMaterial(MaterialList.AncientCoin, 5);
                ADD_UpgradeMaterial(MaterialList.MonsterFluid, 100, 50);
                ADD_UpgradeMaterial(MaterialList.RelicStone, 50, 10);
                ADD_EvolutionMaterial(MaterialList.Crystal, 27, 1);
                ADD_EvolutionMaterial(MaterialList.RelicStone, 150, 50);
                ADD_EvolutionMaterial(MaterialList.AncientCoin, 6, 2);
                break;
            case ArtifactName.LeafHeroStaff:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, magicalATK, mul, 0.020, () => EvolutionNum * 0.1, () => 0.02 + (main.NewArtifacts[(int)artifactName].EvolutionNum) * 0.005);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, leaf, mul, 1, () => EvolutionNum * 5);
                maxLevel = 20;
                IncrementFactorByEvolution = 5;
                ADD_RequiredMaterial(MaterialList.Leaf, 25);
                ADD_RequiredMaterial(MaterialList.CarvedIdol, 100);
                ADD_RequiredMaterial(MaterialList.AncientCoin, 5);
                ADD_UpgradeMaterial(MaterialList.MonsterFluid, 100, 50);
                ADD_UpgradeMaterial(MaterialList.CarvedIdol, 50, 10);
                ADD_EvolutionMaterial(MaterialList.Leaf, 27, 1);
                ADD_EvolutionMaterial(MaterialList.CarvedIdol, 150, 50);
                ADD_EvolutionMaterial(MaterialList.AncientCoin, 6, 2);
                break;
            case ArtifactName.StoneHeroWing:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, physicalATK, mul, 0.010, () => EvolutionNum * 0.05, () => 0.01 + (main.NewArtifacts[(int)artifactName].EvolutionNum) * 0.0025);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, magicalATK, mul, 0.010, () => EvolutionNum * 0.05, () => 0.01 + (main.NewArtifacts[(int)artifactName].EvolutionNum) * 0.0025);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, stone, mul, 1, () => EvolutionNum * 5);
                maxLevel = 20;
                IncrementFactorByEvolution = 5;
                ADD_RequiredMaterial(MaterialList.Stone, 25);
                ADD_RequiredMaterial(MaterialList.RelicStone, 50);
                ADD_RequiredMaterial(MaterialList.CarvedIdol, 50);
                ADD_RequiredMaterial(MaterialList.AncientCoin, 5);
                ADD_UpgradeMaterial(MaterialList.MonsterFluid, 100, 50);
                ADD_UpgradeMaterial(MaterialList.RelicStone, 25, 5);
                ADD_UpgradeMaterial(MaterialList.CarvedIdol, 25, 5);
                ADD_EvolutionMaterial(MaterialList.Stone, 27, 1);
                ADD_EvolutionMaterial(MaterialList.RelicStone, 75, 25);
                ADD_EvolutionMaterial(MaterialList.CarvedIdol, 75, 25);
                ADD_EvolutionMaterial(MaterialList.AncientCoin, 6, 2);
                break;
            case ArtifactName.CrystalHeroCloak:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, MP, mul, 0.01, () => EvolutionNum * 0.1, () => 0.01 + 0.005 * EvolutionNum);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, DEF, mul, 0.01, () => EvolutionNum * 0.1, () => (EvolutionNum * 0.0025) + 0.01);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, MDEF, mul, 0.01, () => EvolutionNum * 0.1, () => (EvolutionNum * 0.0025) + 0.01);
                maxLevel = 20;
                IncrementFactorByEvolution = 5;
                ADD_RequiredMaterial(MaterialList.MonsterFluid, 500);
                ADD_RequiredMaterial(MaterialList.OozeStainedCloth, 250);
                ADD_RequiredMaterial(MaterialList.SpiderSilk, 20);
                ADD_RequiredMaterial(MaterialList.EnchantedCloth, 5);
                ADD_UpgradeMaterial(MaterialList.MonsterFluid, 100, 50);
                ADD_UpgradeMaterial(MaterialList.OozeStainedCloth, 50, 25);
                ADD_UpgradeMaterial(MaterialList.SpiderSilk, 2, 1);
                ADD_UpgradeMaterial(MaterialList.EnchantedCloth, 2, 1);
                ADD_EvolutionMaterial(MaterialList.MonsterFluid, 500, 500);
                ADD_EvolutionMaterial(MaterialList.OozeStainedCloth, 250, 250);
                ADD_EvolutionMaterial(MaterialList.EnchantedCloth, 5, 5);
                ADD_EvolutionMaterial(MaterialList.AncientCoin, 6, 2);
                break;

            case ArtifactName.MagicalFairyWing:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, MATK, add, 50, () => EvolutionNum * 500, () => 50 + (main.NewArtifacts[(int)artifactName].EvolutionNum * 10));
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, spd, mul, 0.01, () => EvolutionNum * 0.1, () => 0.01 + (main.NewArtifacts[(int)artifactName].EvolutionNum * 0.0025));
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, other, add, 1);
                gameObject.GetComponents<Status>()[2].FreeText
                    = () =>
                    {
                        if (main.ally.SetEffectObject.GetComponent<FairySet>().isFairySet())
                        {
                            return "Fairy Costume\n- Move Speed : + " + percent(main.ally.SetEffectObject.GetComponent<FairySet>().CalculateSpeedRate());
                        }
                        else
                        {
                            return "???\n- ???";
                        }
                    };
                maxLevel = 30;
                IncrementFactorByEvolution = 5;
                ADD_RequiredMaterial(MaterialList.FairyDust, 250);
                ADD_RequiredMaterial(MaterialList.FairyWing, 100);
                ADD_RequiredMaterial(MaterialList.BloodOfFairy, 10);
                ADD_RequiredMaterial(MaterialList.EnchantedSapling, 1);
                ADD_UpgradeMaterial(MaterialList.FairyDust, 250, 250);
                ADD_UpgradeMaterial(MaterialList.FairyWing, 100, 100);
                ADD_UpgradeMaterial(MaterialList.FairyCoin, 25, 25);
                ADD_UpgradeMaterial(MaterialList.BloodOfFairy, 10, 5);
                ADD_EvolutionMaterial(MaterialList.FairyDust, 250, 250);
                ADD_EvolutionMaterial(MaterialList.FairyWing, 100, 100);
                ADD_EvolutionMaterial(MaterialList.MysticGemStone, 2, 2);
                ADD_EvolutionMaterial(MaterialList.EnchantedSapling, 1, 1);
                break;
            case ArtifactName.FairyBoots:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, spd, add, 50, () => EvolutionNum * 250, () => 50 + (main.NewArtifacts[(int)artifactName].EvolutionNum * 10));
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, prof, mul, 0.25, () => EvolutionNum * 1, () => (EvolutionNum * 0.05) + 0.25);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, other, add, 1);
                gameObject.GetComponents<Status>()[2].FreeText
                    = () =>
                    {
                        if (main.ally.SetEffectObject.GetComponent<FairySet>().isFairySet())
                        {
                            return "Fairy Costume\n- Move Speed : + " + percent(main.ally.SetEffectObject.GetComponent<FairySet>().CalculateSpeedRate());
                        }
                        else
                        {
                            return "???\n- ???";
                        }
                    };
                maxLevel = 30;
                IncrementFactorByEvolution = 5;
                ADD_RequiredMaterial(MaterialList.FairyDust, 100);
                ADD_RequiredMaterial(MaterialList.FairyCoin, 50);
                ADD_RequiredMaterial(MaterialList.FairyHeart, 5);
                ADD_RequiredMaterial(MaterialList.FairyQueenDust, 1);
                ADD_UpgradeMaterial(MaterialList.FairyDust, 100, 100);
                ADD_UpgradeMaterial(MaterialList.FairyCoin, 50, 50);
                ADD_UpgradeMaterial(MaterialList.FairyHeart, 5, 5);
                ADD_UpgradeMaterial(MaterialList.MysticGemStone, 1, 0);
                ADD_EvolutionMaterial(MaterialList.EnchantedCloth, 1, 1);
                ADD_EvolutionMaterial(MaterialList.FairyHeart, 5, 5);
                ADD_EvolutionMaterial(MaterialList.MysticGemStone, 1, 1);
                ADD_EvolutionMaterial(MaterialList.FairyQueenDust, 1, 1);
                break;


            case ArtifactName.FoxHat:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, ATK, add, 10, () => EvolutionNum * 100, () => 10 + (main.NewArtifacts[(int)artifactName].EvolutionNum * 2));
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, exp, mul, 0.05, () => EvolutionNum * 0.1, () => (EvolutionNum * 0.0025) + 0.05);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, other, add, 1);
                gameObject.GetComponents<Status>()[2].FreeText
                    = () =>
                    {
                        if (main.ally.SetEffectObject.GetComponent<FoxSet>().isFoxSet())
                        {
                            return "Fox Costume\n- Debuff Resistances : + " + percent(main.ally.SetEffectObject.GetComponent<FoxSet>().CalculateResistanceRate());
                        }
                        else
                        {
                            return "???\n- ???";
                        }
                    };
                maxLevel = 10;
                IncrementFactorByEvolution = 2;
                ADD_RequiredMaterial(MaterialList.FoxPelt, 30);
                ADD_RequiredMaterial(MaterialList.FoxTail, 15);
                ADD_UpgradeMaterial(MaterialList.FoxPelt, 30, 10);
                ADD_UpgradeMaterial(MaterialList.FoxTail, 15, 5);
                ADD_EvolutionMaterial(MaterialList.FoxPelt, 150, 50);
                ADD_EvolutionMaterial(MaterialList.FoxTail, 75, 25);
                ADD_EvolutionMaterial(MaterialList.FoxEye, 2, 1);
                break;
            case ArtifactName.FoxCoat:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, HP, add, 1000, () => EvolutionNum * 20000, () => EvolutionNum * 250 + 1000);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, MP, add, 200, () => EvolutionNum * 2000, () => EvolutionNum * 50 + 200);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, other, add, 1);
                gameObject.GetComponents<Status>()[2].FreeText
                    = () =>
                    {
                        if (main.ally.SetEffectObject.GetComponent<FoxSet>().isFoxSet())
                        {
                            return "Fox Costume\n- Debuff Resistances : + " + percent(main.ally.SetEffectObject.GetComponent<FoxSet>().CalculateResistanceRate());
                        }
                        else
                        {
                            return "???\n- ???";
                        }
                    };

                maxLevel = 50;
                IncrementFactorByEvolution = 5;
                ADD_RequiredMaterial(MaterialList.MonsterFluid, 100);
                ADD_RequiredMaterial(MaterialList.FoxPelt, 100);
                ADD_RequiredMaterial(MaterialList.FoxTail, 50);
                ADD_RequiredMaterial(MaterialList.FoxEar, 10);
                ADD_UpgradeMaterial(MaterialList.MonsterFluid, 100, 20);
                ADD_UpgradeMaterial(MaterialList.FoxPelt, 50, 10);
                ADD_UpgradeMaterial(MaterialList.FoxTail, 15, 5);
                ADD_UpgradeMaterial(MaterialList.FoxEar, 3, 1);
                ADD_EvolutionMaterial(MaterialList.EnchantedCloth, 3, 1);
                ADD_EvolutionMaterial(MaterialList.IntactNineTail, 5, 5);
                ADD_EvolutionMaterial(MaterialList.WhiteFoxPelt, 1, 2);
                break;
            case ArtifactName.FoxBoots:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, MDEF, add, 10, () => EvolutionNum * 10, () => 10 + (main.NewArtifacts[(int)artifactName].EvolutionNum));
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, drop, mul, 0.01, () => EvolutionNum * 0.05, () => 0.01 + EvolutionNum * 0.001);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, other, add, 1);
                gameObject.GetComponents<Status>()[2].FreeText
                    = () =>
                    {
                        if (main.ally.SetEffectObject.GetComponent<FoxSet>().isFoxSet())
                        {
                            return "Fox Costume\n- Debuff Resistances : + " + percent(main.ally.SetEffectObject.GetComponent<FoxSet>().CalculateResistanceRate());
                        }
                        else
                        {
                            return "???\n- ???";
                        }
                    };

                maxLevel = 10;
                IncrementFactorByEvolution = 1;
                ADD_RequiredMaterial(MaterialList.FoxPelt, 500);
                ADD_RequiredMaterial(MaterialList.FoxTail, 200);
                ADD_RequiredMaterial(MaterialList.FoxHeart, 3);
                ADD_RequiredMaterial(MaterialList.FoxCore, 1);
                ADD_UpgradeMaterial(MaterialList.FoxPelt, 250, 125);
                ADD_UpgradeMaterial(MaterialList.FoxTail, 100, 50);
                ADD_UpgradeMaterial(MaterialList.FoxHeart, 3, 1);
                ADD_UpgradeMaterial(MaterialList.FoxCore, 1, 1);
                ADD_EvolutionMaterial(MaterialList.FoxHeart, 5, 1);
                ADD_EvolutionMaterial(MaterialList.FoxCore, 3, 1);
                ADD_EvolutionMaterial(MaterialList.BlackPearl, 6, 2);
                ADD_EvolutionMaterial(MaterialList.BananoonCore, 1, 1);
                break;
            case ArtifactName.HealingStaff:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, other, mul, 0.00001, () => 0, () => 0.00001);
                gameObject.GetComponent<Status>().FreeText = () =>
                      "Heal your wounds while losing MP.\n- Regenerate HP : " + percent(gameObject.GetComponent<Status>().GetValue(), 3) + " / s\n- Lost MP : " + tDigit(1000 + main.NewArtifacts[(int)ArtifactName.HealingStaff].level * 50) + " / s";
                maxLevel = 100;
                ADD_RequiredMaterial(MaterialList.OilOfSlime, 500);
                ADD_RequiredMaterial(MaterialList.SlimeEyeBall, 50);
                ADD_RequiredMaterial(MaterialList.RuinedSpellBook, 25);
                ADD_RequiredMaterial(MaterialList.SlimeSceptre, 2);
                ADD_UpgradeMaterial(MaterialList.OilOfSlime, 1000, 0);
                ADD_UpgradeMaterial(MaterialList.SlimeEyeBall, 100, 0);
                ADD_UpgradeMaterial(MaterialList.RuinedSpellBook, 50, 0);
                ADD_UpgradeMaterial(MaterialList.SlimeSceptre, 5, 0);
                break;

            //RankA
            case ArtifactName.LeafHeroSword:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, ATK, add, 100, () => EvolutionNum * 250, () => 100 + 25 * (main.NewArtifacts[(int)artifactName].EvolutionNum));
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, ATK, mul, 0.1, () => EvolutionNum * 0.25, () => 0.1 + 0.05 * (main.NewArtifacts[(int)artifactName].EvolutionNum));
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, leaf, mul, 5, () => EvolutionNum * 20);
                maxLevel = 5;
                IncrementFactorByEvolution = 1;
                ADD_RequiredMaterial(MaterialList.Leaf, 82);
                ADD_RequiredMaterial(MaterialList.NatureCrystal, 100);
                ADD_RequiredMaterial(MaterialList.ManaShard, 1);
                ADD_RequiredMaterial(MaterialList.BlackPearl, 3);
                ADD_UpgradeMaterial(MaterialList.MonsterFluid, 1000, 500);
                ADD_UpgradeMaterial(MaterialList.NatureCrystal, 50, 25);
                ADD_UpgradeMaterial(MaterialList.RobustBone, 3, 1);
                ADD_UpgradeMaterial(MaterialList.BlackPearl, 1, 0);
                ADD_EvolutionMaterial(MaterialList.Leaf, 84, 2);
                ADD_EvolutionMaterial(MaterialList.NatureCrystal, 100, 50);
                ADD_EvolutionMaterial(MaterialList.ManaShard, 1, 1);
                ADD_EvolutionMaterial(MaterialList.BlackPearl, 3, 1);
                break;

            case ArtifactName.StoneHeroStaff:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, MATK, add, 100, () => EvolutionNum * 250, () => 100 + 25 * (main.NewArtifacts[(int)artifactName].EvolutionNum));
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, MATK, mul, 0.1, () => EvolutionNum * 0.25, () => 0.1 + 0.05 * (main.NewArtifacts[(int)artifactName].EvolutionNum));
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, stone, mul, 5, () => EvolutionNum * 20);
                maxLevel = 5;
                IncrementFactorByEvolution = 1;
                ADD_RequiredMaterial(MaterialList.Stone, 82);
                ADD_RequiredMaterial(MaterialList.FrostCrystal, 100);
                ADD_RequiredMaterial(MaterialList.ManaShard, 1);
                ADD_RequiredMaterial(MaterialList.BlackPearl, 3);
                ADD_UpgradeMaterial(MaterialList.MonsterFluid, 1000, 500);
                ADD_UpgradeMaterial(MaterialList.FrostCrystal, 50, 25);
                ADD_UpgradeMaterial(MaterialList.FairyQueenDust, 3, 1);
                ADD_UpgradeMaterial(MaterialList.BlackPearl, 1, 0);
                ADD_EvolutionMaterial(MaterialList.Stone, 84, 2);
                ADD_EvolutionMaterial(MaterialList.FrostCrystal, 100, 50);
                ADD_EvolutionMaterial(MaterialList.ManaShard, 1, 1);
                ADD_EvolutionMaterial(MaterialList.BlackPearl, 3, 1);
                break;


            case ArtifactName.CrystalHeroWing:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, physicalATK, mul, 0.25, () => EvolutionNum * 1, () => 0.25 + (main.NewArtifacts[(int)artifactName].EvolutionNum) * 0.05);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, magicalATK, mul, 0.25, () => EvolutionNum * 1, () => 0.25 + (main.NewArtifacts[(int)artifactName].EvolutionNum) * 0.05);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, crystal, mul, 5, () => EvolutionNum * 20);
                maxLevel = 5;
                IncrementFactorByEvolution = 1;
                ADD_RequiredMaterial(MaterialList.Crystal, 82);
                ADD_RequiredMaterial(MaterialList.LightningCrystal, 100);
                ADD_RequiredMaterial(MaterialList.ManaShard, 1);
                ADD_RequiredMaterial(MaterialList.BlackPearl, 3);
                ADD_UpgradeMaterial(MaterialList.MonsterFluid, 1000, 500);
                ADD_UpgradeMaterial(MaterialList.LightningCrystal, 50, 25);
                ADD_UpgradeMaterial(MaterialList.PotentVenomSample, 3, 1);
                ADD_UpgradeMaterial(MaterialList.BlackPearl, 1, 0);
                ADD_EvolutionMaterial(MaterialList.Crystal, 84, 2);
                ADD_EvolutionMaterial(MaterialList.LightningCrystal, 100, 50);
                ADD_EvolutionMaterial(MaterialList.ManaShard, 1, 1);
                ADD_EvolutionMaterial(MaterialList.BlackPearl, 3, 1);
                break;

            case ArtifactName.LeafHeroCloak:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, HP, add, 1000, () => EvolutionNum * 5000, () => 1000 + 200 * EvolutionNum);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, HP, mul, 0.5, () => EvolutionNum * 2, () => (EvolutionNum * 0.1) + 0.5);
                maxLevel = 10;
                IncrementFactorByEvolution = 2;
                ADD_RequiredMaterial(MaterialList.EnchantedCloth, 2500);
                ADD_RequiredMaterial(MaterialList.SeveredTentacle, 1);
                ADD_RequiredMaterial(MaterialList.ManaCrystal, 1);
                ADD_RequiredMaterial(MaterialList.BlackPearl, 3);
                ADD_UpgradeMaterial(MaterialList.MonsterFluid, 1000, 500);
                ADD_UpgradeMaterial(MaterialList.EnchantedCloth, 100, 25);
                ADD_UpgradeMaterial(MaterialList.ShinySlimeCrown, 3, 1);
                ADD_UpgradeMaterial(MaterialList.BlackPearl, 1, 0);
                ADD_EvolutionMaterial(MaterialList.EnchantedCloth, 2500, 500);
                ADD_EvolutionMaterial(MaterialList.SeveredTentacle, 1, 1);
                ADD_EvolutionMaterial(MaterialList.ManaShard, 1, 1);
                ADD_EvolutionMaterial(MaterialList.BlackPearl, 3, 1);
                break;

            case ArtifactName.ScaleArmor:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, DEF, add, 1000, () => EvolutionNum * 5000, () => 1000 + (main.NewArtifacts[(int)artifactName].EvolutionNum) * 200);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, MDEF, add, 1000, () => EvolutionNum * 5000, () => 1000 + (main.NewArtifacts[(int)artifactName].EvolutionNum) * 200);
                maxLevel = 10;
                IncrementFactorByEvolution = 2;
                ADD_RequiredMaterial(MaterialList.MonsterFluid, 10000);
                ADD_RequiredMaterial(MaterialList.FishScales, 1000);
                ADD_RequiredMaterial(MaterialList.ManaShard, 3);
                ADD_RequiredMaterial(MaterialList.BlackPearl, 10);
                ADD_UpgradeMaterial(MaterialList.MonsterFluid, 1000, 200);
                ADD_UpgradeMaterial(MaterialList.FishScales, 1000, 200);
                ADD_UpgradeMaterial(MaterialList.BlackPearl, 1, 0);
                ADD_EvolutionMaterial(MaterialList.FishScales, 1000, 500);
                ADD_EvolutionMaterial(MaterialList.ManaShard, 6, 3);
                ADD_EvolutionMaterial(MaterialList.OctopusEye, 1, 1);
                ADD_EvolutionMaterial(MaterialList.BlackPearl, 15, 5);
                break;

            case ArtifactName.ArtificialGill:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, other, mul, 0.0001);
                gameObject.GetComponent<Status>().FreeText = () =>
                {
                    return "Purifying Mysterious Water + " + percent(level * 0.01d * (1+EvolutionNum));
                };
                maxLevel = 100;
                IncrementFactorByEvolution = 0;
                ADD_RequiredMaterial(MaterialList.FishScales, 500);
                ADD_RequiredMaterial(MaterialList.SharpFin, 100);
                ADD_RequiredMaterial(MaterialList.FishTeeth, 50);
                ADD_RequiredMaterial(MaterialList.FishTail, 5);
                ADD_UpgradeMaterial(MaterialList.FishScales, 500, 100);
                ADD_UpgradeMaterial(MaterialList.SharpFin, 100, 20);
                ADD_UpgradeMaterial(MaterialList.FishTeeth, 50, 10);
                ADD_UpgradeMaterial(MaterialList.FishTail, 5, 1);
                ADD_EvolutionMaterial(MaterialList.ManaCrystal, 10, 5);
                ADD_EvolutionMaterial(MaterialList.DevilFishCore, 3, 3);
                ADD_EvolutionMaterial(MaterialList.SeveredTentacle, 1, 1);
                ADD_EvolutionMaterial(MaterialList.BlackPearl, 10, 10);
                break;

            case ArtifactName.ScaleRing:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, other, mul, 0.0001);
                gameObject.GetComponent<Status>().FreeText = () =>
                {
                    return "Reduces debuff effect by " + percent(Math.Min(0.25d + level * 0.001d,0.75)); 
                };
                maxLevel = 500;
                canNotEvolve = true;
                ADD_RequiredMaterial(MaterialList.FishScales, 2000);
                ADD_RequiredMaterial(MaterialList.SharpFin, 500);
                ADD_RequiredMaterial(MaterialList.FishTail, 100);
                ADD_RequiredMaterial(MaterialList.DevilFishCore, 1);
                ADD_UpgradeMaterial(MaterialList.FishScales, 2000, 0);
                ADD_UpgradeMaterial(MaterialList.SharpFin, 500, 0);
                ADD_UpgradeMaterial(MaterialList.FishTail, 100, 0);
                ADD_UpgradeMaterial(MaterialList.SmallTreasureChest, 2, 0);
                break;

            case ArtifactName.GolemCrest:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, DEF, mul, 0.25, () => EvolutionNum * 2.5, () => 0.25 + (main.NewArtifacts[(int)artifactName].EvolutionNum) * 0.05);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, MDEF, mul, 0.25, () => EvolutionNum * 2.5, () => 0.25 + (main.NewArtifacts[(int)artifactName].EvolutionNum) * 0.05);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, exp, mul, 0.10, () => EvolutionNum * 0.5, () => 0.1 + (main.NewArtifacts[(int)artifactName].EvolutionNum) * 0.02);
                maxLevel = 10;
                IncrementFactorByEvolution = 4;
                ADD_RequiredMaterial(MaterialList.RobustBone, 20);
                ADD_RequiredMaterial(MaterialList.GolemShard, 5);
                ADD_RequiredMaterial(MaterialList.GolemCore, 1);
                ADD_RequiredMaterial(MaterialList.BlackPearl, 10);
                ADD_UpgradeMaterial(MaterialList.RobustBone, 4, 1);
                ADD_UpgradeMaterial(MaterialList.GolemShard, 1, 0);
                ADD_UpgradeMaterial(MaterialList.BlackPearl, 2, 0);
                ADD_EvolutionMaterial(MaterialList.RobustBone, 25, 5);
                ADD_EvolutionMaterial(MaterialList.GolemShard, 6, 1);
                ADD_EvolutionMaterial(MaterialList.GolemCore, 2, 1);
                ADD_EvolutionMaterial(MaterialList.BlackPearl, 10, 5);
                break;

            case ArtifactName.GoldenAmulet:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, other, mul, 0.0001);
                gameObject.GetComponent<Status>().FreeText = () =>
                {
                    if (EvolutionNum < 4)
                        return "Drop Slot + " + (EvolutionNum + 1);
                    else
                        return "Drop Slot + 5 (max)";
                };
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, drop, mul, 0.01, () => EvolutionNum * 0.05, () => 0.01 + EvolutionNum * 0.0025);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, gold, add, 3, () => EvolutionNum * 10, () => 3 + (EvolutionNum * 0.5));
                maxLevel = 10;
                IncrementFactorByEvolution = 1;
                ADD_RequiredMaterial(MaterialList.GoldenCrystal, 500);
                ADD_RequiredMaterial(MaterialList.ManaCrystal, 5);
                ADD_RequiredMaterial(MaterialList.OctobaddieCore, 1);
                ADD_RequiredMaterial(MaterialList.BlackPearl, 10);
                ADD_UpgradeMaterial(MaterialList.GoldenShard, 500, 500);
                ADD_UpgradeMaterial(MaterialList.GoldenCrystal, 50, 50);
                ADD_UpgradeMaterial(MaterialList.SlimeKingCore, 1, 0);
                ADD_UpgradeMaterial(MaterialList.BlackPearl, 3, 1);
                ADD_EvolutionMaterial(MaterialList.GoldenCrystal, 1000, 500);
                ADD_EvolutionMaterial(MaterialList.ManaCrystal, 10, 5);
                ADD_EvolutionMaterial(MaterialList.OctobaddieCore, 2, 1);
                ADD_EvolutionMaterial(MaterialList.BlackPearl, 15, 5);
                break;

            case ArtifactName.BananaCutter:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, other, mul, 0.0001);
                gameObject.GetComponent<Status>().FreeText = () =>
                      "Throws " + (level+1) + " Bananas";
                maxLevel = 3;
                IncrementFactorByEvolution = 1;
                ADD_RequiredMaterial(MaterialList.RottenBanana, 50);
                ADD_RequiredMaterial(MaterialList.RipeBanana, 10);
                ADD_RequiredMaterial(MaterialList.BananoonCore, 1);
                ADD_UpgradeMaterial(MaterialList.RottenBanana, 50, 10);
                ADD_UpgradeMaterial(MaterialList.RipeBanana, 10, 2);
                ADD_UpgradeMaterial(MaterialList.BananoonCore, 1, 0);
                ADD_EvolutionMaterial(MaterialList.RottenBanana, 60, 10);
                ADD_EvolutionMaterial(MaterialList.RipeBanana, 12, 2);
                ADD_EvolutionMaterial(MaterialList.BananoonCore, 1, 0);
                break;
                //HS所持数によって、ステータスをアップさせる。所持数×20%
            case ArtifactName.LegendWarrior:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, other, mul, 0.0001);
                gameObject.GetComponent<Status>().FreeText = () =>
                      "Increase All Stats by " + (20 + level * 5) + "% and "
                      + (level * 100) + "% Skill Effeciency for each Heart Stone you have. \n<color=red>This Effect only applies for Warrior</color=red>\n" +
                      "(This effect does not show in the stats breakdown below)\n" +
                      "\n[ Current Effect ] Heart Stone You have ("+main.S.RP+")\n-Stats <color=green>" + main.S.RP * (20 + level * 5) + "%</color=green>" +
                      "\n-Skill Proficiency <color=green>" + main.S.RP * (level * 100) + "%</color=green>";
                maxLevel = 30;
                canNotEvolve = true;
                stayAfterReincarnation = true;
                ADD_RequiredMaterial(MaterialList.WarriorSoul, 1);
                ADD_UpgradeMaterial(MaterialList.WarriorSoul, 1, 0);
                ADD_UpgradeMaterial(MaterialList.DarkMatter, 3, 0);
                break;
            case ArtifactName.LegendWizard:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, other, mul, 0.0001);
                gameObject.GetComponent<Status>().FreeText = () =>
                      "Increase All Stats by " + (20 + level * 5) + "% and "
                      + (level * 100) + "% Skill Effeciency for each Heart Stone you have. \n<color=red>This Effect only applies for Wizard</color=red>\n" +
                      "(This effect does not show in the stats breakdown below)\n" +
                      "\n[ Current Effect ] Heart Stone You have (" + main.S.RP + ")\n-Stats <color=green>" + main.S.RP * (20 + level * 5) + "%</color=green>" +
                      "\n-Skill Proficiency <color=green>" + main.S.RP * (level * 100) + "%</color=green>";
                maxLevel = 30;
                stayAfterReincarnation = true;
                canNotEvolve = true;
                ADD_RequiredMaterial(MaterialList.WizardSoul, 1);
                ADD_UpgradeMaterial(MaterialList.WizardSoul, 1, 0);
                ADD_UpgradeMaterial(MaterialList.DarkMatter, 3, 0);
                break;
            case ArtifactName.LegendAngel:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, other, mul, 0.0001);
                gameObject.GetComponent<Status>().FreeText = () =>
                      "Increase All Stats by " + (20 + level * 5) + "% and "
                      + (level * 100) + "% Skill Effeciency for each Heart Stone you have. \n<color=red>This Effect only applies for Angel</color=red>\n" +
                      "(This effect does not show in the stats breakdown below)\n" +
                      "\n[ Current Effect ] Heart Stone You have (" + main.S.RP + ")\n-Stats <color=green>" + main.S.RP * (20 + level * 5) + "%</color=green>" +
                      "\n-Skill Proficiency <color=green>" + main.S.RP * (level * 100) + "%</color=green>";
                maxLevel = 30;
                canNotEvolve = true;
                stayAfterReincarnation = true;
                ADD_RequiredMaterial(MaterialList.AngelSoul, 1);
                ADD_UpgradeMaterial(MaterialList.AngelSoul, 1, 0);
                ADD_UpgradeMaterial(MaterialList.DarkMatter, 3, 0);
                break;
            case ArtifactName.LegendWarriorRein:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, other, mul, 0.0001);
                gameObject.GetComponent<Status>().FreeText = () =>
                      "The sword attack turns into a full range attack.\n Instead, the damage dealt is reduced to " +5 * level +  "%.";
                maxLevel = 20;
                canNotEvolve = true;
                stayAfterReincarnation = true;
                ADD_RequiredMaterial(MaterialList.ProofOfWarrior, 1);
                ADD_UpgradeMaterial(MaterialList.ProofOfWarrior, 1, 0);
                ADD_UpgradeMaterial(MaterialList.DarkMatter, 5, 0);
                break;
            case ArtifactName.LegendWizardRein:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, other, mul, 0.0001);
                gameObject.GetComponent<Status>().FreeText = () =>
                      "The staff attack turns into a full range attack.\n Instead, the damage dealt is reduced to " + 5 * level + "%.";
                maxLevel = 20;
                canNotEvolve = true;
                stayAfterReincarnation = true;
                ADD_RequiredMaterial(MaterialList.ProofOfWizard, 1);
                ADD_UpgradeMaterial(MaterialList.ProofOfWizard, 1, 0);
                ADD_UpgradeMaterial(MaterialList.DarkMatter, 5, 0);
                break;
            case ArtifactName.LegendAngelRein:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, other, mul, 0.0001);
                gameObject.GetComponent<Status>().FreeText = () =>
                      "The wing attack turns into a full range attack.\n Instead, the damage dealt is reduced to " + 5 * level + "%.";
                maxLevel = 20;
                canNotEvolve = true;
                stayAfterReincarnation = true;
                ADD_RequiredMaterial(MaterialList.ProofOfAngel, 1);
                ADD_UpgradeMaterial(MaterialList.ProofOfAngel, 1, 0);
                ADD_UpgradeMaterial(MaterialList.DarkMatter, 5, 0);
                break;
            default:
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, stone, mul, 0.001);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, crystal, mul, 0.001);
                gameObject.AddComponent<Status>().AwakeStatus(artifactName, leaf, mul, 0.001);
                maxLevel = 10;
                ADD_RequiredMaterial(MaterialList.BlackPearl, 100);
                break;
        }
    }

    public enum ArtifactName
    {
        //RankD
        DullHeroSword = 0,
        BrittleHeroStaff = 1,
        FlimsyHeroWing = 2,
        OldHeroCloak = 3,
        SlimeSword = 4,
        SlimeRing = 5,
        SlimeHat = 6,
        BatCloak = 7,
        BatShoes = 8,
        HerbloreGuide = 9,

        //RankC
        StoneHeroSword = 10,
        CrystalHeroStaff = 11,
        LeafHeroWing = 12,
        StoneHeroCloak = 13,
        SlimeStick = 14,
        AmberRing = 21,
        AzurePendant = 17,
        BindingSilk = 15,
        FairyBoots = 16,
        VenomSword = 22,

        //RankB
        CrystalHeroSword = 23,
        LeafHeroStaff = 24,
        StoneHeroWing = 25,
        CrystalHeroCloak = 26,
        MagicalFairyWing = 30,
        FoxHat = 27,
        FoxCoat = 28,
        FoxBoots = 29,
        GolemShield = 18,
        HealingStaff = 20,


        //RankA
        LeafHeroSword = 31,
        StoneHeroStaff = 32,
        CrystalHeroWing = 33,
        LeafHeroCloak = 34,
        GolemCrest = 19,
        ScaleArmor = 35,
        ArtificialGill = 36,
        ScaleRing = 37,
        GoldenAmulet = 38,
        BananaCutter = 39,

        //Rank Epic
        LegendWarrior = 40,
        LegendWizard = 41,
        LegendAngel = 42,
        LegendWarriorRein = 43,
        LegendWizardRein = 44,
        LegendAngelRein = 45,

    }
    public enum StatusKind
    {
        other,
        gold,
        stone,
        crystal,
        leaf,
        physicalATK,
        magicalATK,
        physicalDEF,
        magicalDEF,
        HP,
        MP,
        spd,
        drop,
        prof,
        exp,
        ATK,
        MATK,
        DEF,
        MDEF
    }
    //ステータス1個につき1つのコンポネントで管理してみる．
    public class Status : BASE
    {
        double value;
        public StatusKind statusKind;
        public CalWay calWay;
        public ArtifactName artifactName;
        public Func<string> FreeText;
        public Func<double> valueAfterEvolve;
        public Func<double> ParmanentEffect;
        TextMeshProUGUI statusExplainText;
        string tempText;
        public void AwakeStatus(ArtifactName artifactName, StatusKind statusKind, CalWay calWay, double value,
            Func<double> ParmanentEffect = null, Func<double> valueAfterEvolve = null)
        {
            StartBASE();
            this.value = value;
            this.statusKind = statusKind;
            this.calWay = calWay;
            this.artifactName = artifactName;
            if (valueAfterEvolve == null)
            {
                this.valueAfterEvolve = () => value * (main.NewArtifacts[(int)artifactName].EvolutionNum + 1);
            }
            else
            {
                this.valueAfterEvolve = valueAfterEvolve;
            }
            if (ParmanentEffect == null)
            {
                this.ParmanentEffect = () => 0;
            }
            else
            {
                this.ParmanentEffect = ParmanentEffect;
            }
            statusExplainText = Instantiate(main.EffectText, main.NewArtifacts[(int)artifactName].completeWindow.transform.GetChild(3));
        }

        //completeWindow.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text
        public double GetValue()
        {
            if (main.NewArtifacts[(int)artifactName].EvolutionNum == 0)
            {
                return main.NewArtifacts[(int)artifactName].level * value;
            }
            else
            {
                return main.NewArtifacts[(int)artifactName].level * valueAfterEvolve();
            }
        }



        public string ParmanentValueText()
        {
            string text = "";
            switch (calWay)
            {
                case CalWay.add:
                    tempText = tDigit(ParmanentEffect(), 1);
                    break;
                case CalWay.mul:
                    tempText = percent(ParmanentEffect());
                    break;
            }
            switch (statusKind)
            {
                case StatusKind.HP:
                    text = "- HP : + " + tempText;
                    break;
                case StatusKind.MP:
                    text = "- MP : + " + tempText;
                    break;
                case StatusKind.gold:
                    text = "- Gold Gain : + " + tempText;
                    break;
                case StatusKind.stone:
                    text = "- Stone Produce : + " + tempText;
                    break;
                case StatusKind.crystal:
                    text = "- Crystal Produce : + " + tempText;
                    break;
                case StatusKind.leaf:
                    text = "- Leaf Produce : + " + tempText;
                    break;
                case StatusKind.physicalATK:
                    text = "- Physical Damage : + " + tempText;
                    break;
                case StatusKind.physicalDEF:
                    text = "- Physical Damage Cut : + " + tempText;
                    break;
                case StatusKind.magicalATK:
                    text = "- Magical Damage : + " + tempText;
                    break;
                case StatusKind.magicalDEF:
                    text = "- Magical Damage Cut : + " + tempText;
                    break;
                case StatusKind.drop:
                    text = "- Drop Chance : + " + tempText;
                    break;
                case StatusKind.prof:
                    text = "- Skill Proficiency : + " + tempText;
                    break;
                case StatusKind.exp:
                    text = "- Gained EXP : + " + tempText;
                    break;
                case StatusKind.spd:
                    text = "- SPD : + " + tempText;
                    break;
                case StatusKind.ATK:
                    text = "- ATK : + " + tempText;
                    break;
                case StatusKind.MATK:
                    text = "- MATK : + " + tempText;
                    break;
                case StatusKind.DEF:
                    text = "- DEF : + " + tempText;
                    break;
                case StatusKind.MDEF:
                    text = "- MDEF : + " + tempText;
                    break;
            }

            return text;
        }
        public string IncrementValue()
        {
            if (main.NewArtifacts[(int)artifactName].EvolutionNum == 0)
            {
                //return tDigit(value);

                if (calWay == CalWay.add)
                {
                    return tDigit(value, 2);
                }
                else
                {
                    return percent(value, 2);
                }
            }
            else
            {
                if (calWay == CalWay.add)
                {
                    if (value < 1)
                    {
                        return tDigit(valueAfterEvolve(), 2);
                    }
                    else
                    {
                        return tDigit(valueAfterEvolve(), 2);
                    }
                }
                else
                {
                    return percent(valueAfterEvolve(), 2);
                }
            }
        }



        private void Update()
        {
            if (!main.NewArtifacts[(int)artifactName].window.activeSelf && !main.NewArtifacts[(int)artifactName].completeWindow.activeSelf)
            {
                return;
            }
            if (main.NewArtifacts[(int)artifactName].completeWindow.activeSelf)
            {
                switch (calWay)
                {
                    case CalWay.add:
                        if (main.NewArtifacts[(int)artifactName].EvolutionNum >= 1)
                            tempText = tDigit(main.NewArtifacts[(int)artifactName].level * valueAfterEvolve()) + "   ( + " + IncrementValue() + " / level )";
                        else
                            tempText = tDigit(main.NewArtifacts[(int)artifactName].level * value) + "   ( + " + IncrementValue() + " / level )";
                        break;
                    case CalWay.mul:
                        if (main.NewArtifacts[(int)artifactName].EvolutionNum >= 1)
                            tempText = percent(main.NewArtifacts[(int)artifactName].level * valueAfterEvolve()) + "   ( + " + IncrementValue() + " / level )";
                        else
                            tempText = percent(main.NewArtifacts[(int)artifactName].level * value) + "   ( + " + IncrementValue() + " / level )";
                        break;
                }
                switch (statusKind)
                {
                    case StatusKind.HP:
                        statusExplainText.text = "- HP : + " + tempText;
                        break;
                    case StatusKind.MP:
                        statusExplainText.text = "- MP : + " + tempText;
                        break;
                    case StatusKind.gold:
                        statusExplainText.text = "- Gold Gain : + " + tempText;
                        break;
                    case StatusKind.stone:
                        statusExplainText.text = "- Stone Produce : + " + tempText;
                        break;
                    case StatusKind.crystal:
                        statusExplainText.text = "- Crystal Produce : + " + tempText;
                        break;
                    case StatusKind.leaf:
                        statusExplainText.text = "- Leaf Produce : + " + tempText;
                        break;
                    case StatusKind.physicalATK:
                        statusExplainText.text = "- Physical Damage : + " + tempText;
                        break;
                    case StatusKind.physicalDEF:
                        statusExplainText.text = "- Physical Damage Cut : + " + tempText;
                        break;
                    case StatusKind.magicalATK:
                        statusExplainText.text = "- Magical Damage : + " + tempText;
                        break;
                    case StatusKind.magicalDEF:
                        statusExplainText.text = "- Magical Damage Cut : + " + tempText;
                        break;
                    case StatusKind.drop:
                        statusExplainText.text = "- Drop Chance : + " + tempText;
                        break;
                    case StatusKind.prof:
                        statusExplainText.text = "- Skill Profiency : + " + tempText;
                        break;
                    case StatusKind.exp:
                        statusExplainText.text = "- Gained EXP : + " + tempText;
                        break;
                    case StatusKind.spd:
                        statusExplainText.text = "- SPD : + " + tempText;
                        break;
                    case StatusKind.ATK:
                        statusExplainText.text = "- ATK : + " + tempText;
                        break;
                    case StatusKind.MATK:
                        statusExplainText.text = "- MATK : + " + tempText;
                        break;
                    case StatusKind.DEF:
                        statusExplainText.text = "- DEF : + " + tempText;
                        break;
                    case StatusKind.MDEF:
                        statusExplainText.text = "- MDEF : + " + tempText;
                        break;
                    case StatusKind.other:
                        statusExplainText.text = "- " + FreeText();
                        break;


                }
            }



        }


    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (condition != Condition.complete)
        {
            return;
        }

        //左クリック：装備する．
        if (eventData.pointerId == -1)
        {
            if (main.craftCtrl.currentEquippedNum() < main.craftCtrl.maxEquippedNum())
            {
                isEquipped = true;
                main.sound.MustPlaySound(main.sound.equipClip);
                if (artifactName == ArtifactName.DullHeroSword && !main.S.isWarActiveSkill)
                {
                    setActive(main.TutorialController.WarActiveSkillCanvas.gameObject);
                    main.S.isWarActiveSkill = true;
                }
                if (artifactName == ArtifactName.BrittleHeroStaff && !main.S.isWizActiveSkill)
                {
                    setActive(main.TutorialController.WizActiveSkillCanvas.gameObject);
                    main.S.isWizActiveSkill = true;
                }
                if (artifactName == ArtifactName.FlimsyHeroWing && !main.S.isAngActiveSkill)
                {
                    setActive(main.TutorialController.AngActiveSkillCanvas.gameObject);
                    //main.TutorialController.AngActiveSkillCanvas.gameObject.GetComponent<RectTransform>().anchoredPosition += new Vector2(-10000, 0);
                    main.S.isAngActiveSkill = true;
                }
            }
        }
        //右クリック : 装備を外す．
        else if (eventData.pointerId == -2)
        {
            if (isEquipped)
            {
                main.sound.MustPlaySound(main.sound.notEquipClip);
                isEquipped = false;
                isFavoriteEquipped = false;
            }
        }
        main.ArtifactFactor.UpdateValue();

    }
    // Use this for initialization
    void Start()
    {
        hatenaButton.onClick.AddListener(Make);


        //デバッグ用
        //condition = Condition.complete;
        //level++;
        //GetAscendPoint();
        //Destroy(making);

        if (condition != Condition.locked)
        {
            Destroy(hatena);
        }

        //過去のユーザーのため．
        if (level > MaxLevel())
        {
            level = MaxLevel();
        }

    }
    public void InstantiateWindow()
    {
        window = Instantiate(main.P_texts[5], main.WindowShowCanvas);
        gameObject.AddComponent<EventTrigger>().triggers = new List<EventTrigger.Entry>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry2.eventID = EventTriggerType.PointerExit;
        entry.callback.AddListener((x) => UsefulMethod.setActive(window));
        entry2.callback.AddListener((x) => UsefulMethod.setFalse(window)); //ラムダ式の右側は追加するメソッドです。
        gameObject.GetComponent<EventTrigger>().triggers.Add(entry);
        gameObject.GetComponent<EventTrigger>().triggers.Add(entry2);
    }
    public void InstantiateCompleteWindow()
    {
        completeWindow = Instantiate(main.P_texts[8], main.WindowShowCanvas);
        gameObject.AddComponent<EventTrigger>().triggers = new List<EventTrigger.Entry>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry2.eventID = EventTriggerType.PointerExit;
        entry.callback.AddListener((x) => UsefulMethod.setActive(completeWindow));
        entry2.callback.AddListener((x) => UsefulMethod.setFalse(completeWindow)); //ラムダ式の右側は追加するメソッドです。
        gameObject.GetComponent<EventTrigger>().triggers.Add(entry);
        gameObject.GetComponent<EventTrigger>().triggers.Add(entry2);
    }
    public void InstantiateUpgradeWindow()
    {
        upgradeWindow = Instantiate(main.P_texts[10], main.WindowShowCanvas);
        upgradeButton.gameObject.AddComponent<EventTrigger>().triggers = new List<EventTrigger.Entry>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry2.eventID = EventTriggerType.PointerExit;
        entry.callback.AddListener((x) => UsefulMethod.setActive(upgradeWindow));
        entry2.callback.AddListener((x) => UsefulMethod.setFalse(upgradeWindow)); //ラムダ式の右側は追加するメソッドです。
        upgradeButton.gameObject.GetComponent<EventTrigger>().triggers.Add(entry);
        upgradeButton.gameObject.GetComponent<EventTrigger>().triggers.Add(entry2);
    }
    // Update is called once per frame
    void Update()
    {
        updateText();
        if (!completeWindow.activeSelf)
            return;
        if (Input.GetKeyDown(KeyCode.M) && completeWindow.activeSelf)
        {
            MaxUpgrade();
        }
        if (Input.GetKeyDown(KeyCode.E) && completeWindow.activeSelf)
        {
            EvoluteEquipment();
        }
        if (isEquipped)//装備中のものにのみ、Favoriteできる
        {
            if (main.S.FavoriteEquip && Input.GetKeyDown(KeyCode.F) && completeWindow.activeSelf)
            {
                FavoriteEquip();
            }
        }
    }
    void FavoriteEquip()
    {
        if (isFavoriteEquipped)
            isFavoriteEquipped = false;
        else
        {
            if(main.craftCtrl.CanFavorite())
                isFavoriteEquipped = true;
        }
    }
    public void EvoluteEquipment()
    {
        if (condition != Condition.complete)
            return;

        if (level != MaxLevel())
            return;

        if (!CanEvolution())
            return;

        if (canNotEvolve)
            return;

        foreach (SamplePair material in EvolutionMaterial.GetList())
        {
            switch (material.Key)
            {
                case MaterialList.Stone:
                    main.SR.stone -= Math.Pow(10, EvolutionCost(material));
                    break;
                case MaterialList.Crystal:
                    main.SR.cristal -= Math.Pow(10, EvolutionCost(material));
                    break;
                case MaterialList.Leaf:
                    main.SR.leaf -= Math.Pow(10, EvolutionCost(material));
                    break;
                default:
                    main.ArtiCtrl.CurrentMaterial[material.Key] -= EvolutionCost(material);
                    break;
            }
        }

        level = 0;
        EvolutionNum += 1;
        //switch (rank)//ランクに応じてポイント
        //{
        //    case Rank.D:
        //        RPmanager.GetPointFromEquipment(1);
        //        break;
        //    case Rank.C:
        //        RPmanager.GetPointFromEquipment(2);
        //        break;
        //    case Rank.B:
        //        RPmanager.GetPointFromEquipment(3);
        //        break;
        //    case Rank.A:
        //        RPmanager.GetPointFromEquipment(4);
        //        break;
        //    case Rank.Epic:
        //        RPmanager.GetPointFromEquipment(5);
        //        break;
        //}

        main.ArtifactFactor.UpdateValue();
    }
    public void updateText()
    {
        if (main.GameController.currentCanvas == main.GameController.ArtifactCanvas)
        {
            switch (condition)
            {
                case Condition.locked:
                    setFalse(completeWindow);
                    LockWindow();
                    if (CanUnlock())
                    {
                        if (hatenaButton != null)
                            hatenaButton.interactable = true;
                        blink.canBlink = true;
                    }
                    else
                    {
                        if (hatenaButton != null)
                            hatenaButton.interactable = false;
                        blink.canBlink = false;
                    }
                    upgradeButton.interactable = false;
                    upgradeButton.transform.GetComponentInChildren<TextMeshProUGUI>().text = "???";
                    upgradeButton.GetComponent<Image>().raycastTarget = false;
                    break;

                case Condition.complete:
                    setFalse(window);
                    if (isEquipped)
                    {
                        setActive(equipText);
                        if (isFavoriteEquipped)
                            eqText.text = "EF";
                        else
                            eqText.text = "E";
                    }
                    else
                    {
                        setFalse(equipText);
                    }
                    if (CanUnlock() && !canNotPowerUp)
                    {
                        upgradeButton.interactable = true;
                    }
                    else
                    {
                        upgradeButton.interactable = false;
                    }
                    CompleteWindow();
                    ShowEffect();
                    //upgradeButton.interactable = true;
                    upgradeButton.transform.GetComponentInChildren<TextMeshProUGUI>().text = "LEVEL UP";
                    upgradeButton.GetComponent<Image>().raycastTarget = true;
                    //UpgradeWindow();
                    //if (upgradeWindow.activeSelf) { setFalse(completeWindow); } else { setActive(completeWindow); }
                    break;
            }

        }
    }
    public bool CanEvolution()
    {
        foreach (SamplePair material in EvolutionMaterial.GetList())
        {
            switch (material.Key)
            {
                case MaterialList.Stone:
                    if (main.SR.stone < Math.Pow(10, EvolutionCost(material)))
                    {
                        return false;
                    }
                    break;
                case MaterialList.Crystal:
                    if (main.SR.cristal < Math.Pow(10, EvolutionCost(material)))
                    {
                        return false;
                    }
                    break;
                case MaterialList.Leaf:
                    if (main.SR.leaf < Math.Pow(10, EvolutionCost(material)))
                    {
                        return false;
                    }
                    break;
                default:
                    if (main.ArtiCtrl.CurrentMaterial[material.Key] < EvolutionCost(material))
                    {
                        return false;
                    }
                    break;
            }
        }
        return true;
    }
    public bool CanUnlock()
    {
        if (level >= MaxLevel())
            return false;

        if (condition == Condition.locked)
        {
            foreach (SamplePair material in RequiredMaterial.GetList())
            {
                switch (material.Key)
                {
                    case MaterialList.Stone:
                        if (main.SR.stone < Math.Pow(10, cost(material)))
                        {
                            return false;
                        }
                        break;
                    case MaterialList.Crystal:
                        if (main.SR.cristal < Math.Pow(10, cost(material)))
                        {
                            return false;
                        }
                        break;
                    case MaterialList.Leaf:
                        if (main.SR.leaf < Math.Pow(10, cost(material)))
                        {
                            return false;
                        }
                        break;
                    default:
                        if (main.ArtiCtrl.CurrentMaterial[material.Key] < cost(material))
                        {
                            return false;
                        }
                        break;
                }
            }
        }
        else if (condition == Condition.complete)
        {
            foreach (SamplePair material in UpgradeMaterial.GetList())
            {
                if (main.ArtiCtrl.CurrentMaterial[material.Key] < cost(material))
                {
                    return false;
                }
            }
        }
        return true;
    }
    public void Unlock()
    {
        Make();
        Destroy(hatena);
    }
    public void Upgrade()
    {
        if (!CanUnlock()) { return; }
        foreach (SamplePair material in UpgradeMaterial.GetList())
        {
            switch (material.Key)
            {
                case MaterialList.Stone:
                    main.SR.stone -= Math.Pow(10, cost(material));
                    break;
                case MaterialList.Crystal:
                    main.SR.cristal -= Math.Pow(10, cost(material));
                    break;
                case MaterialList.Leaf:
                    main.SR.leaf -= Math.Pow(10, cost(material));
                    break;
                default:
                    main.ArtiCtrl.CurrentMaterial[material.Key] -= cost(material);
                    break;
            }
        }
        level++;
        GetAscendPoint();
        main.ArtifactFactor.UpdateValue();

    }
    public void MaxUpgrade()
    {
        if (!CanUnlock())
            return;

        //ここのアルゴリズムを変えよう。
        /*
        while (CanUnlock())
        {
            Upgrade();
        }
        */

        //ここから
        int levelSa = MaxLevel() - level;
        //incrementをminにする
        int increment = 99999;
        //main.ArtiCtrl.CurrentMaterial[material.Key] -= cost(material);
        foreach (SamplePair material in UpgradeMaterial.GetList())
        {
            if (main.ArtiCtrl.CurrentMaterial[material.Key] >= cost(material) * levelSa)
            {
                //main.ArtiCtrl.CurrentMaterial[material.Key] -= cost(material) * levelSa;
                increment = Math.Min(levelSa, increment);
            }
            else
            {
                increment = Math.Min(main.ArtiCtrl.CurrentMaterial[material.Key] / cost(material), increment);
                //main.ArtiCtrl.CurrentMaterial[material.Key] -= cost(material) * increment;
            }
        }
        foreach (SamplePair material in UpgradeMaterial.GetList())
        {
            main.ArtiCtrl.CurrentMaterial[material.Key] -= cost(material) * increment;
        }
        level += increment;
        for (int i = 0; i < increment; i++)
        {
            GetAscendPoint();
        }
        main.ArtifactFactor.UpdateValue();
    }
    public int cost(SamplePair material)
    {
        return material.Value + EvolutionNum * (int)material.tei;
    }
    public int EvolutionCost(SamplePair material)
    {
        return material.Value + EvolutionNum * (int)material.tei;
    }
    public void Make()
    {
        foreach (SamplePair material in RequiredMaterial.GetList())
        {
            switch (material.Key)
            {
                case MaterialList.Stone:
                    main.SR.stone -= Math.Pow(10, material.Value);
                    break;
                case MaterialList.Crystal:
                    main.SR.cristal -= Math.Pow(10, material.Value);
                    break;
                case MaterialList.Leaf:
                    main.SR.leaf -= Math.Pow(10, material.Value);
                    break;
                default:
                    main.ArtiCtrl.CurrentMaterial[material.Key] -= material.Value;
                    break;
            }
        }
        StartCoroutine(Making());
    }
    public IEnumerator Making()
    {
        while (true)
        {
            condition = Condition.complete;
            level++;
            GetAscendPoint();
            Destroy(hatena);
            yield break;
        }
    }
    public void GetAscendPoint()
    {
        long value = 1;
        switch (rank)
        {
            case Rank.D:
                value = 1;
                break;
            case Rank.C:
                value = 2;
                break;
            case Rank.B:
                value = 3;
                break;
            case Rank.A:
                value = 5;
                break;
            case Rank.Epic:
                value = 10;
                break;
        }
        value = (long)(value * main.RebirthPointFactor());

        switch (main.ally.job)
        {
            case ALLY.Job.Warrior:
                main.WarP += value;
                main.tempWarP += value;
                break;
            case ALLY.Job.Wizard:
                main.WizP += value;
                main.tempWizP += value;
                break;
            case ALLY.Job.Angel:
                main.AngP += value;
                main.tempAngP += value;
                break;
            default:
                break;
        }

        main.SR.JP_craft += value;
    }
    public string showMaterial()
    {
        string text = "<size=12>";
        List<SamplePair> sample = new List<SamplePair>();
        if (condition == Condition.locked)
            sample = RequiredMaterial.GetList();
        else if (condition == Condition.complete)
            sample = UpgradeMaterial.GetList();

        if (level == MaxLevel())
            sample = EvolutionMaterial.GetList();
        if (level < MaxLevel())
        {
            foreach (SamplePair material in sample)
            {
                 text += "- " + main.ArtiCtrl.ConvertEnum(material.Key);
                 text += "\n";
            }

            //Max Costに必要な個数をかく
            if (condition != Condition.locked)
            {
                text += CraftLocal.max();
                foreach (SamplePair material in sample)
                {
                    text += "- " + main.ArtiCtrl.ConvertEnum(material.Key);
                    text += "\n";
                }
            }
        }
        else
        {
            foreach (SamplePair material in sample)
            {
                text += "- " + main.ArtiCtrl.ConvertEnum(material.Key);
                text += "\n";
            }
            //Evolveした後に必要な素材をかく。
            sample = UpgradeMaterial.GetList();
            text += CraftLocal.evolute();
            foreach (SamplePair material in sample)
            {
                text += "- " + main.ArtiCtrl.ConvertEnum(material.Key);
                text += "\n";
            }

            if (!canNotEvolve)
            {
                text += CraftLocal.cannotEvole(this);
            }
        }

        return text;
    }
    public string showMaterialNum()
    {
        string text = "<size=12>";
        List<SamplePair> sample = new List<SamplePair>();
        if (condition == Condition.locked)
            sample = RequiredMaterial.GetList();
        else if (condition == Condition.complete)
            sample = UpgradeMaterial.GetList();

        if (level == MaxLevel())
            sample = EvolutionMaterial.GetList();

        //レベルとのさを取っておく
        int levelSa = MaxLevel() - level;
        if (level < MaxLevel())
        {
            foreach (SamplePair material in sample)
            {
                switch (material.Key)
                {
                    case MaterialList.Stone:
                        if (main.SR.stone < Math.Pow(10, cost(material)))
                        {
                            text += optStr + "<color=\"red\">" + tDigit(main.SR.stone) + "</color> / " + tDigit(Math.Pow(10, cost(material)));
                        }
                        else
                        {
                            text += optStr + "<color=\"green\">" + tDigit(main.SR.stone) + "</color> / " + tDigit(Math.Pow(10, cost(material)));
                        }
                        text += optStr + "\n";
                        break;
                    case MaterialList.Crystal:
                        if (main.SR.cristal < Math.Pow(10, cost(material)))
                        {
                            text += optStr + "<color=\"red\">" + tDigit(main.SR.cristal) + "</color> / " + tDigit(Math.Pow(10, cost(material)));

                        }
                        else
                        {
                            text += optStr + "<color=\"green\">" + tDigit(main.SR.cristal) + "</color> / " + tDigit(Math.Pow(10, cost(material)));
                        }
                        text += optStr + "\n";
                        break;
                    case MaterialList.Leaf:
                        if (main.SR.leaf < Math.Pow(10, cost(material)))
                        {
                            text += optStr + "<color=\"red\">" + tDigit(main.SR.leaf) + "</color> / " + tDigit(Math.Pow(10, cost(material)));
                        }
                        else
                        {
                            text += optStr + "<color=\"green\">" + tDigit(main.SR.leaf) + "</color> / " + tDigit(Math.Pow(10, cost(material)));
                        }
                        text += optStr + "\n";
                        break;
                    default:
                        if (main.ArtiCtrl.CurrentMaterial[material.Key] < cost(material))
                        {
                            text += optStr + "<color=\"red\">" + tDigit(main.ArtiCtrl.CurrentMaterial[material.Key]) + "</color> / " + tDigit(cost(material));
                        }
                        else
                        {
                            text += optStr + "<color=\"green\">" + tDigit(main.ArtiCtrl.CurrentMaterial[material.Key]) + "</color> / " + tDigit(cost(material));
                        }

                        text += optStr + "\n";
                        break;
                }
            }

            //次の強化で必要な素材を表示
            //material.Value + EvolutionNum * (int)material.tei;
            //参照するmaterialをアップグレードのものに変更
            if (condition != Condition.locked)
            {
                text += optStr + "\n\n";
                foreach (SamplePair material in sample)
                {
                    switch (material.Key)
                    {
                        case MaterialList.Stone:
                            if (main.SR.stone < Math.Pow(10, cost(material)) * levelSa)
                            {
                                text += optStr + "<color=\"red\">" + tDigit(main.SR.stone) + "</color> / " + tDigit(Math.Pow(10, cost(material)) * levelSa);
                            }
                            else
                            {
                                text += optStr + "<color=\"green\">" + tDigit(main.SR.stone) + "</color> / " + tDigit(Math.Pow(10, cost(material)) * levelSa);
                            }
                            break;
                        case MaterialList.Crystal:
                            if (main.SR.cristal < Math.Pow(10, cost(material)) * levelSa)
                            {
                                text += optStr + "<color=\"red\">" + tDigit(main.SR.cristal) + "</color> / " + tDigit(Math.Pow(10, cost(material)) * levelSa);
                            }
                            else
                            {
                                text += optStr + "<color=\"green\">" + tDigit(main.SR.cristal) + "</color> / " + tDigit(Math.Pow(10, cost(material)) * levelSa);
                            }
                            break;
                        case MaterialList.Leaf:
                            if (main.SR.leaf < Math.Pow(10, cost(material)) * levelSa)
                            {
                                text += optStr + "<color=\"red\">" + tDigit(main.SR.leaf) + "</color> / " + tDigit(Math.Pow(10, cost(material)) * levelSa);
                            }
                            else
                            {
                                text += optStr + "<color=\"green\">" + tDigit(main.SR.leaf) + "</color> / " + tDigit(Math.Pow(10, cost(material)) * levelSa);
                            }
                            break;
                        default:
                            if (main.ArtiCtrl.CurrentMaterial[material.Key] < cost(material) * levelSa)
                            {
                                text += optStr + "<color=\"red\">" + tDigit(main.ArtiCtrl.CurrentMaterial[material.Key]) + "</color> / " + tDigit(cost(material) * levelSa);
                            }
                            else
                            {
                                text += optStr + "<color=\"green\">" + tDigit(main.ArtiCtrl.CurrentMaterial[material.Key]) + "</color> / " + tDigit(cost(material) * levelSa);
                            }
                            break;
                    }
                    text += optStr + "\n";
                }
            }

        }
        else
        {
            foreach (SamplePair material in sample)
            {
                switch (material.Key)
                {
                    case MaterialList.Stone:
                        if (main.SR.stone < Math.Pow(10, EvolutionCost(material)))
                        {
                            text += optStr + "<color=\"red\">" + tDigit(main.SR.stone) + "</color> / " + tDigit(Math.Pow(10, EvolutionCost(material)));
                        }
                        else
                        {
                            text += optStr + "<color=\"green\">" + tDigit(main.SR.stone) + "</color> / " + tDigit(Math.Pow(10, EvolutionCost(material)));
                        }
                        text += optStr + "\n";
                        break;
                    case MaterialList.Crystal:
                        if (main.SR.cristal < Math.Pow(10, EvolutionCost(material)))
                        {
                            text += optStr + "<color=\"red\">" + tDigit(main.SR.cristal) + "</color> / " + tDigit(Math.Pow(10, EvolutionCost(material)));

                        }
                        else
                        {
                            text += optStr + "<color=\"green\">" + tDigit(main.SR.cristal) + "</color> / " + tDigit(Math.Pow(10, EvolutionCost(material)));
                        }
                        text += optStr + "\n";
                        break;
                    case MaterialList.Leaf:
                        if (main.SR.leaf < Math.Pow(10, EvolutionCost(material)))
                        {
                            text += optStr + "<color=\"red\">" + tDigit(main.SR.leaf) + "</color> / " + tDigit(Math.Pow(10, EvolutionCost(material)));
                        }
                        else
                        {
                            text += optStr + "<color=\"green\">" + tDigit(main.SR.leaf) + "</color> / " + tDigit(Math.Pow(10, EvolutionCost(material)));
                        }
                        text += optStr + "\n";
                        break;
                    default:
                        if (main.ArtiCtrl.CurrentMaterial[material.Key] < EvolutionCost(material))
                        {
                            text += optStr + "<color=\"red\">" + tDigit(main.ArtiCtrl.CurrentMaterial[material.Key]) + "</color> / " + tDigit(EvolutionCost(material));
                        }
                        else
                        {
                            text += optStr + "<color=\"green\">" + tDigit(main.ArtiCtrl.CurrentMaterial[material.Key]) + "</color> / " + tDigit(EvolutionCost(material));
                        }
                        text += optStr + "\n";
                        break;
                }
            }

            //次の強化で必要な素材を表示
            //material.Value + EvolutionNum * (int)material.tei;
            //参照するmaterialをアップグレードのものに変更
            sample = UpgradeMaterial.GetList();
            text += optStr + "\n\n";
            foreach(SamplePair material in sample)
            {
                int nextNum  = material.Value + (EvolutionNum+1)* (int)material.tei;
                string color = main.ArtiCtrl.CurrentMaterial[material.Key] >= nextNum ? "<color=\"yellow\">" : "<color=\"red\">";
                switch (material.Key)
                {
                    default:
                        text += optStr + color + tDigit(main.ArtiCtrl.CurrentMaterial[material.Key]) + "</color> / " + tDigit(nextNum);
                        break;
                }
                text += optStr + "\n";
            }

        }
        return text;
    }
    public void LockWindow()
    {


        if (window.activeSelf)
        {
            //window.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "???";
            LocalizeInitialize.SetFont(window.transform.GetChild(1).GetComponent<TextMeshProUGUI>());
            //フォントいじくる
            window.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = showMaterial();
            window.transform.GetChild(1).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = showMaterialNum();

            //if (window != null)
            //{
            //    if (Input.mousePosition.y >= 250 && Input.mousePosition.x >= 400)
            //    {
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(-250.0f, -50.0f);
            //    }
            //    else if (Input.mousePosition.y >= 250 && Input.mousePosition.x < 400)
            //    {
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(50.0f, -50.0f);
            //    }
            //    else if (Input.mousePosition.y < 250 && Input.mousePosition.x > 400)
            //    {
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(-250.0f, 50.0f);
            //    }
            //    else if (Input.mousePosition.y < 250 && Input.mousePosition.x < 400)
            //    {
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(50.0f, -50.0f);
            //    }
            //}
        }
    }
    public void CompleteWindow()
    {
        if (EvolutionNum >= 1)
        {
            setActive(EvolutionNumText);
            EvolutionNumText.GetComponent<TextMeshProUGUI>().text = optStr + "<color=orange>*" + EvolutionNum;
        }
        if (completeWindow.activeSelf)
        {
            LocalizeInitialize.SetFont(completeWindow.transform.GetChild(0).GetComponent<TextMeshProUGUI>());
            LocalizeInitialize.SetFont(completeWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>());
            LocalizeInitialize.SetFont(completeWindow.transform.GetChild(2).GetComponent<TextMeshProUGUI>());
            LocalizeInitialize.SetFont(completeWindow.transform.GetChild(4).GetComponent<TextMeshProUGUI>());
            LocalizeInitialize.SetFont(completeWindow.transform.GetChild(5).GetComponent<TextMeshProUGUI>());
            LocalizeInitialize.SetFont(completeWindow.transform.GetChild(6).GetComponent<TextMeshProUGUI>());
            LocalizeInitialize.SetFont(completeWindow.transform.GetChild(7).GetComponent<TextMeshProUGUI>());
            completeWindow.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = CraftLocal.window2();
            completeWindow.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = CraftLocal.window4(this);
            completeWindow.transform.GetChild(6).GetComponent<TextMeshProUGUI>().text = CraftLocal.window6();
            string white = LocalizeInitialize.language == Language.jp ? "    " : "";
            string white2 = LocalizeInitialize.language == Language.jp ? "                " : "";
            completeWindow.transform.GetChild(0).GetComponentInChildren<Image>().sprite = gameObject.GetComponent<Image>().sprite;
            if (EvolutionNum > 0)
                completeWindow.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = optStr + "                  " +white + main.ArtiCtrl.ConvertEnum(artifactName) + " + " + tDigit(EvolutionNum) + " < <color=\"green\">Lv " + level + " </color>>";
            else
                completeWindow.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = optStr + "                  "+white + main.ArtiCtrl.ConvertEnum(artifactName) + " < <color=\"green\">Lv " + level + " </color>>";

            if (setItem == SetItem.Nothing)
            {
                completeWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = optStr + "                        " + white + "- Rank : " + rank + "\n                        " + white + "- Max Level : " + MaxLevel() + "\n                        ";
            }
            else
            {
                completeWindow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = optStr + "                        " + white + "- Rank : " + rank + "\n                        " + white + "- Max Level : " + MaxLevel() + "\n                        "+ white + " - " + setItem;
            }

            //completeWindow.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = EffectText();
            if (canNotEvolve && level >= maxLevel)
            {
                completeWindow.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text = CraftLocal.cannotlevelup();
                completeWindow.transform.GetChild(5).transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "";
                setFalse(completeWindow.transform.GetChild(6).gameObject);
                setFalse(completeWindow.transform.GetChild(7).gameObject);
            }
            else
            {
                completeWindow.transform.GetChild(5).transform.GetChild(2).GetComponent<TextMeshProUGUI>()
                 .paragraphSpacing = LocalizeInitialize.language != Language.eng ? 30 : 0;
                completeWindow.transform.GetChild(5).transform.GetChild(2).GetComponent<TextMeshProUGUI>()
                 .margin = LocalizeInitialize.language != Language.eng ? new Vector4(0,0,10,0) : new Vector4(0,0,0,0);
                completeWindow.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text = showMaterial();
                completeWindow.transform.GetChild(5).transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = showMaterialNum();

            }

            if (EvolutionNum >= 1)
            {
                setActive(P_title);
                setActive(ParmanentEffectObject);
                ParmanentEffectObject.GetComponent<TextMeshProUGUI>().text = ParmanentEffectText();

            }
            else
            {
                setFalse(P_title);
                setFalse(ParmanentEffectObject);
            }

            //if (completeWindow != null)
            //{
            //    if (Input.mousePosition.y >= 300 && Input.mousePosition.x >= 400)
            //    {
            //        completeWindow.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(-250.0f, -50.0f);
            //    }
            //    else if (Input.mousePosition.y >= 300 && Input.mousePosition.x < 400)
            //    {
            //        completeWindow.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(50.0f, -50.0f);
            //    }
            //    else if (Input.mousePosition.y < 300 && Input.mousePosition.x > 400)
            //    {
            //        completeWindow.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(-250.0f, 50.0f);
            //    }
            //    else if (Input.mousePosition.y < 300 && Input.mousePosition.x < 400)
            //    {
            //        completeWindow.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(50.0f, 100.0f);
            //    }
            //}
        }
    }

    public enum CalWay
    {
        add,
        mul
    }
    public void ShowEffect()
    {
        if (condition != Condition.complete)
        {
            return;
        }

        // if (!isEquipped)
        //     return

        //  switch (ArtifactId)
        //  {
        //      case 0:
        //          Set(ref main.ArtifactFactor.atk1, 3, 0 ,add, 0.2);
        //          Set(ref main.ArtifactFactor.prof1, 0.05, 0, add,0.01);
        //          Effect = "- ATK : + " + showValue(3,add,0.2,false,1) + "\n- Gain Proficiency : + " +
        //              showValue(0.05, add, 0.01); 
        //          break;
        //      case 1:
        //          Set(ref main.ArtifactFactor.exp2, 0.15, 0, exp, 1.035);
        //          Effect = "- Gain EXP : + " + showValue(0.15,exp,1.035);
        //          break;
        //      case 2:
        //          Set(ref main.ArtifactFactor.drop3, 0.2, 0, log, 7);
        //          Effect = "- Gain Drop Chance : + " + showValue(0.2,log,7);
        //          break;
        //      case 3:
        //          Set(ref main.ArtifactFactor.gold4, 0.25, 0 ,log, 3);
        //          Effect = "- Gain Gold : + " + showValue(0.25, log, 3);
        //          break;
        //      case 4:
        //          Set(ref main.ArtifactFactor.bool5);
        //          Set(ref main.ArtifactFactor.def5,0.03,0,add,0.01);
        //          Set(ref main.ArtifactFactor.value5, 0.05, 0, add, 0.01);
        //          Effect = "- You have " + showValue(0.05, add, 0.01)+ " chance to counter the enemy's attack." +
        //              "\n- DEF :  + " + showValue(0.03, add, 0.01);
        //          break;
        //      case 5:
        //          Set(ref main.ArtifactFactor.mdef6,0.03,0,add,0.01);
        //          Set(ref main.ArtifactFactor.regen6,10,0,exp, 1.3);
        //          Effect = "- Regenerate your HP " + showValue(10, exp, 1.3,false) + " every second.\n- MDEF : + " + showValue(0.03, add, 0.01); 
        //          break;
        //      case 6:
        //          Set(ref main.ArtifactFactor.bool7);
        //          Set(ref main.ArtifactFactor.atk7, 0.03, 0,add,0.01);
        //          Set(ref main.ArtifactFactor.value7, 0.05, 0, add, 0.01);
        //          Effect = "- You have " + showValue(0.05, add, 0.01) +
        //              " chance to deal critical damage to Enemy.\n- ATK : + " + showValue(0.03, add, 0.01);
        //          break;
        //      case 7:
        //          Set(ref main.ArtifactFactor.move8, 0.1, 0,log,15);
        //          Effect = "- Move Speed : + " + showValue(0.1, log, 15);
        //          break;
        //      case 8:
        //          if(isEquipped && main.ally1.GetComponent<ALLY>().currentHp / main.ally1.GetComponent<ALLY>().HP() <= 0.3)
        //          {
        //              main.ArtifactFactor.atk9 = 0.25 + (level * 0.01);
        //          }
        //          else
        //          {
        //              main.ArtifactFactor.atk9 = 0;
        //          }
        //          Effect = "- ATK + 25% only when your HP is 30% or lower.";
        //          break;
        //      case 9:
        //          Set(ref main.ArtifactFactor.value10, 0.003, 0, add, 0.001);
        //          Set(ref main.ArtifactFactor.bool10);
        //          Effect = "- You have 1% chance to drain enemy's HP.\n- Drain Point : " + showValue(0.003, add, 0.001) + " of dealt physical damage.";
        //          break;
        //      case 10:
        //          if (isEquipped)
        //          {
        //              main.ArtifactFactor.atk11 = 0.01 * Math.Log(5 * (1 + main.S.totalEnemyKilled)) / Math.Log(5);
        //          }
        //          else
        //          {
        //              main.ArtifactFactor.atk11 = 0;
        //          }
        //          Effect = "- Increase the ATK according to total enemies killed. \n- Currently ATK : + "+
        //              percent(0.01 * Math.Log(5 * (1 + main.S.totalEnemyKilled)) / Math.Log(5));
        //          break;
        //      case 11:
        //          if (isEquipped)
        //          {
        //              main.ArtifactFactor.def12 = 0.01 * Math.Pow(main.SR.gold, 0.24);
        //          }
        //          else
        //          {
        //              main.ArtifactFactor.def12 = 0;
        //          }
        //          Effect = "- Increase the DEF according to total GOLD you have now.\n- Currently DEF : + " +
        //              percent(0.01 * Math.Pow(main.SR.gold, 0.24));
        //          break;
        //      case 12:
        //          Set(ref main.ArtifactFactor.value13, 0.04, 0, log, 5);
        //          Effect = "- You have " + showValue(0.1, log, 5) + " chance to dodge enemy's attack.";
        //          break;
        //      case 13:
        //          Set(ref main.ArtifactFactor.exp14, 0.5, 0, log, 12,main.ally1.GetComponent<ALLY>().job == ALLY.Job.Warrior);
        //          Set(ref main.ArtifactFactor.prof14, 0.5, 0, log, 9, main.ally1.GetComponent<ALLY>().job == ALLY.Job.Warrior);
        //          Effect = "- When your job is Warrior, EXP + " + showValue(0.5, log, 12) +
        //              "\n  and Gain Proficiency + " + showValue(0.5, log, 9);
        //          break;
        //      case 14:
        //          Set(ref main.ArtifactFactor.exp15, 0.5, 0, log, 12, main.ally1.GetComponent<ALLY>().job == ALLY.Job.Wizard);
        //          Set(ref main.ArtifactFactor.prof15, 0.5, 0, log, 9, main.ally1.GetComponent<ALLY>().job == ALLY.Job.Wizard);
        //          Effect = "- When your job is Wizard, EXP + " + showValue(0.5, log, 12) +
        //              "\n  and Gain Proficiency + " + showValue(0.5, log, 9);
        //          break;
        //      case 15:
        //          Set(ref main.ArtifactFactor.exp16, 0.5, 0, log, 12, main.ally1.GetComponent<ALLY>().job == ALLY.Job.Angel);
        //          Set(ref main.ArtifactFactor.prof16, 0.5, 0, log, 9, main.ally1.GetComponent<ALLY>().job == ALLY.Job.Angel);
        //          Effect = "- When your job is Angel, EXP + " + showValue(0.5, log, 12) +
        //              "\n  and Gain Proficiency + " + showValue(0.5, log, 9);
        //          break;
        //      case 16:
        //          Set(ref main.ArtifactFactor.mRegen17, 3, 0, add, 2);
        //          Effect = "- Increase your power of regenerating MP by " + showValue(3, add, 2,false);
        //          break;
        //      case 17:
        //          Set(ref main.ArtifactFactor.bool18);
        //          Set(ref main.ArtifactFactor.value18,0.3,0,add,0.05);
        //          Effect = "- While equipping this, you can attack enemy by CLICKING ENEMY.\n- You can deal" +
        //              showValue(0.3, add, 0.05) + "of current DPS damage.";
        //          break;
        //      case 18:
        //          Set(ref main.ArtifactFactor.hpRegen19, 5, 0, exp, 1.5);
        //          Set(ref main.ArtifactFactor.value19, -10, 0, add, 0.2);
        //          Effect = "- Regenerate your HP + " + showValue(5, exp, 1.5,false) + " per second\n  at the cost of " +
        //              showValue(10, add, -0.2,false) + " MP per second.";
        //          break;
        //      case 19:
        //          Set(ref main.ArtifactFactor.bool20);
        //          Set(ref main.ArtifactFactor.value20, 0.01, 0, add, 0.005);
        //          Effect = "- You can collect various herbs while you are walking. \n- Herbs are used to make various consume items.\n- Discover chance "
        //              + showValue(0.01, add, 0.005);
        //          break;
        //      case 20:
        //          Set(ref main.ArtifactFactor.bool21);
        //          Set(ref main.ArtifactFactor.value21, 3, 0, add, 1);
        //          Effect = "- You can be bananoon! Now a lot of bananas are scattered from your body! \n - Scatter " + showValue(3, add, 1, false) + " bananas per second";
        //          break;
        //          //未完成
        //      case 21:
        //          Set(ref main.ArtifactFactor.prob22, 0.05, 0, add, 0.01);
        //          Set(ref main.ArtifactFactor.value22, 2000, 0, exp, 1.7);
        //          Effect = "- You have "+showValue(0.05,exp,0.01,true)+ " chance to make an enemy POISON when you deal physical attack."+
        //              "\n Poison Damage : " + showValue(2000,exp,1.7,false);
        //          break;
        //      case 22:
        //          Set(ref main.ArtifactFactor.prob23, 0.3, 0, add, 0.01);
        //          Set(ref main.ArtifactFactor.value23, 0.1, 0, add, 0.02);
        //          Effect = "- You have " + showValue(0.05, exp, 0.01, true) + " chance to make an enemy BINDED  when you deal physical attack." +
        //              "\n Binding Effect : " + showValue(0.1, add, 0.02, false);
        //          break;
        //  }
    }
    public void Set(ref double x, double baseValue, double initValue, ARTIFACT.CalculateWay calculateWay, double factor, bool additionalCondition = true)
    {
        if (isEquipped && additionalCondition)
        {
            switch (calculateWay)
            {
                case CalculateWay.add:
                    x = baseValue + ((level - 1) * factor);
                    break;
                case CalculateWay.exp:
                    x = baseValue * (Math.Pow(factor, level - 1));
                    break;
                case CalculateWay.log:
                    if (factor == 0 || level == 0)
                        return;
                    x = baseValue * Math.Log(factor * (level)) / Math.Log(factor);
                    break;
            }
        }
        else
        {
            x = initValue;
        }
    }
    public string showValue(double baseValue, ARTIFACT.CalculateWay calculateWay, double factor, bool isPercent = true, int keta = 0)
    {
        switch (calculateWay)
        {
            case CalculateWay.add:
                if (isPercent)
                    return percent(baseValue + ((level - 1) * factor));
                else
                    return tDigit(baseValue + ((level - 1) * factor), keta);
            case CalculateWay.exp:
                if (isPercent)
                    return percent(baseValue * (Math.Pow(factor, level - 1)));
                else
                    return tDigit(baseValue * (Math.Pow(factor, level - 1)), keta);
            case CalculateWay.log:
                if (factor == 0 || level == 0)
                    return null;
                if (isPercent)
                    return percent(baseValue * Math.Log(factor * (level)) / Math.Log(factor));
                else
                    return tDigit(baseValue * Math.Log(factor * (level)) / Math.Log(factor), keta);
            default:
                return null;
        }
    }
    public void Set(ref bool x)
    {
        if (isEquipped)
        {
            x = true;
        }
        else
        {
            x = false;
        }
    }
}
