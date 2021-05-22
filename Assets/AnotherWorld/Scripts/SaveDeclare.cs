using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static UsefulStatic;
using static Another.Main;

namespace Another
{
    public class SaveDeclare : MonoBehaviour
    {
        private void Awake()
        {
            //Statistics
            InitializeArray(ref main.S.AKillCount, 10 * Enum.GetNames(typeof(EnemySpecies)).Length);
            //Upgrade
            //InitializeArray(ref main.S.AUpgradeLevelsResourceStone, UpgradeController.resourceUpgradeTierNum);
            //InitializeArray(ref main.S.AUpgradeLevelsResourceCrystal, UpgradeController.resourceUpgradeTierNum);
            //InitializeArray(ref main.S.AUpgradeLevelsResourceLeaf, UpgradeController.resourceUpgradeTierNum);
            //InitializeArray(ref main.S.AUpgradeLevelsStats, Enum.GetNames(typeof(Stats)).Length);
            //InitializeArray(ref main.S.AUpgradeLevelsGoldCap, Enum.GetNames(typeof(Resource)).Length);

            //ExplorableArea
            InitializeArray(ref main.S.AAreaClearedNum, 100);
			InitializeArray(ref main.S.AIsMaxHp, 100);
			InitializeArray(ref main.S.AIsOnlyBase, 100);
			InitializeArray(ref main.S.AIsNoEq, 100);
			InitializeArray(ref main.S.AIsNoDmg, 100);
			InitializeArray(ref main.S.AMinClearTime, 100);
			InitializeArray(ref main.S.AMaxClearTime, 100);
			InitializeArray(ref main.S.ASpendTime, 100);
			InitializeArray(ref main.S.AMaxGoldGained, 100);
            InitializeArray(ref main.S.AIsMissionAll, 100);

            //SkillSlot
            //InitializeArray(ref main.S.ASkillsetsWarrior, 16);
            //InitializeArray(ref main.S.ASkillsetsGlobalWarrior, 16);
            //InitializeArray(ref main.S.ASkillsetsWizard, 16);
            //InitializeArray(ref main.S.ASkillsetsGlobalWizard, 16);
            //InitializeArray(ref main.S.ASkillsetsAngel, 16);
            //InitializeArray(ref main.S.ASkillsetsGlobalAngel, 16);
            ////Skill
            InitializeArray(ref main.S.AIsEquippedSkills, Enum.GetNames(typeof(Skill)).Length);
            InitializeArray(ref main.S.ASkillRank, Enum.GetNames(typeof(Skill)).Length);
            InitializeArray(ref main.S.ASkillLevel, Enum.GetNames(typeof(Skill)).Length);
            InitializeArray(ref main.S.ASkillProf, Enum.GetNames(typeof(Skill)).Length);

            //Craft
            InitializeArray(ref main.S.AMaterials, Enum.GetNames(typeof(Material)).Length);
            //InitializeArray(ref main.S.AIsEquippedEq, Enum.GetNames(typeof(Equipment)).Length);
            //InitializeArray(ref main.S.AEquipmentLevels, Enum.GetNames(typeof(Equipment)).Length);
            //InitializeArray(ref main.S.AEquipmentRanks, Enum.GetNames(typeof(Equipment)).Length);
        }
		// Start is called before the first frame update
		void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
