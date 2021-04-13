using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;

public class VersionUpdates : BASE {

	// Use this for initialization
	void Awake () {
		StartBASE();
	}

	// Use this for initialization
	void Start () {
		if (!main.S.isAfterVer1102)
		{
			if (main.S.SRPfromMaterialBase >= 5000)
			{
				main.S.SRPfromMaterialBase = 5000;
			}
			if (main.S.SRPfromPrevious - main.S.SRPconsumed >= 30000)
				main.S.SRPfromPrevious = 30000 + main.S.SRPconsumed;

            foreach (ENEMY enemy in main.ZoneCtrl.EnemyAry)
            {
				if (enemy == null)
					continue;
				if (enemy.gameObject.HasComponent<C_ENEMY>())
                {
					main.S.totalEnemiesCaptured[(int)enemy.enemyKind] = 0;
				}
			}
			main.S.isAfterVer1102 = true;
		}

        if (!main.S.isAfterVer1103)
        {
			main.S.InstantReincarnationNum = 1;
			foreach (R_UPGRADE upgrades in main.SR_upgrades)
			{
				main.S.SR_level[(int)upgrades.SR_thisId] = 0;
				upgrades.tempLevel = 0;
			}
			main.S.SRPconsumed = 0;
			main.S.SRPinstantConsumed = 0;
			main.rein.ResetAssignment();
			if (main.S.SRPfromPrevious >= (long)(main.S.ReincarnationNum * 30000 * (1 + main.rein.R_upgrades[(int)R_UPGRADE.R_upgradeId.SpiritEssenceMore].GetCurrentValue())))
				main.S.SRPfromPrevious = (long)(main.S.ReincarnationNum * 30000 * (1 + main.rein.R_upgrades[(int)R_UPGRADE.R_upgradeId.SpiritEssenceMore].GetCurrentValue()));
			main.S.isAfterVer1103 = true;
        }

	}

	// Update is called once per frame
	void Update () {
		
	}
}
