using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;

public class RPmanager : BASE {

	// Use this for initialization
	//double initialTime;
	//long initialPoint;
	static long tempMaterialPoint;
    //Awakeで処理だけしてしまって、startでboolをtrueにする。
	void Awake () {
		StartBASE();
	}

	public double SEFactor;
	public double SEFactorFromSkill;
	public long SpiritEssence()
    {
		CalculateSEPoint();
		double tempPoint;
		tempPoint = 0;
		tempPoint += main.S.SRPfromTime;     //PlayTime
		tempPoint += main.S.SRPfromRebirth;//Rebirth回数(1000cap)
		tempPoint += main.S.SRPfromEquipment;//Evolution回数
		tempPoint += main.S.SRPfromBankCap;//BankCapUpgradeのレベル
		tempPoint += main.S.SRPfromMaterial;//MaterialのGold換算の四乗根
		tempPoint += main.S.SRPfromMontblango;//Montblangoの最高討伐Level*100
		tempPoint += main.S.SRPfromLevel;//最高レベル
		tempPoint += main.S.SRPfromMission;//Missionによるもの
		tempPoint += main.S.SRPfromQuest;//Questによるもの
		tempPoint += main.S.SRPfromPrevious;//前回までの通算！
		tempPoint -= main.S.SRPinstantConsumed;//InstantTicketで買った分
		tempPoint -= main.S.SRPconsumed;
		if (tempPoint > 1e11d)
			tempPoint = 1e11d;
		return (long)tempPoint;
    }
	int temp = 0;
	double SEfactorFromReincarnation => SumMulDelegate(main.cc.cf.SeMul);
	public void CalculateSEPoint()
    {
		SEFactor = main.rein.R_upgrades[(int)R_UPGRADE.R_upgradeId.SpiritEssenceMore].GetCurrentValue();
		SEFactorFromSkill = main.warriorSkillAry[10].pas2 + main.wizardSkillAry[10].pas2 + main.angelSkillAry[10].pas2;
        //PlayTime
		main.S.SRPfromTime = (long)(5000 * (1 - 1.0 / (Math.Pow(1.2, main.S.reincarnationTime / 1.0 / 7 / 24 / 3600))));
		main.S.SRPfromTime = (long)(main.S.SRPfromTime * (1d + SEFactor) * (1d + SEFactorFromSkill) * SEfactorFromReincarnation);
		if (main.S.ReincarnationNum >= 1)//2周目以降は２倍！最大10000
			main.S.SRPfromTime = main.S.SRPfromTime * 2;
		//Rebirth
		main.S.SRPfromRebirth = Math.Min(main.S.AscendNumWhileReincarnation, 1000);
		main.S.SRPfromRebirth = (long)(main.S.SRPfromRebirth * (1d + SEFactor) * (1d + SEFactorFromSkill) * SEfactorFromReincarnation);
		//装備
		main.S.SRPfromEquipment = equipmentSEfactor();
		main.S.SRPfromEquipment = (long)(main.S.SRPfromEquipment * (1d + SEFactor));
		//BankCapによるポイント
		main.S.SRPfromBankCap = main.bankCtrl.BankUpgrades[(int)B_Upgrade.UpgradeId.BankCap].level * 3;
		main.S.SRPfromBankCap = (long)(main.S.SRPfromBankCap * (1d + SEFactor) * (1d + SEFactorFromSkill) * SEfactorFromReincarnation);
		//Material
		main.S.SRPfromMaterial = main.S.SRPfromMaterialBase;
		main.S.SRPfromMaterial = (long)(main.S.SRPfromMaterial * (1d + SEFactor) * (1d + SEFactorFromSkill) * SEfactorFromReincarnation);
		//Level
		main.S.SRPfromLevel = (long)(20 * Math.Pow((main.S.maxLevelReachedWhileReincarnation + 1), 0.5));
		main.S.SRPfromLevel = (long)(main.S.SRPfromLevel * (1d + SEFactor) * (1d + SEFactorFromSkill) * SEfactorFromReincarnation);
		//Montblango
		main.S.SRPfromMontblango = main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.montblango].maxClaredNum * 200;
		main.S.SRPfromMontblango = (long)(main.S.SRPfromMontblango * (1d + SEFactor) * (1d + SEFactorFromSkill) * SEfactorFromReincarnation);
		//Mission
		main.S.SRPfromMission = main.TotalSEfromMission();
		main.S.SRPfromMission = (long)(main.S.SRPfromMission * (1d + SEFactor) * (1d + SEFactorFromSkill) * SEfactorFromReincarnation);
		//Quest
		main.S.SRPfromQuest = ACHIEVEMENT.TotalSE();
		main.S.SRPfromQuest = (long)(main.S.SRPfromQuest * (1d + SEFactor) * (1d + SEFactorFromSkill) * SEfactorFromReincarnation);
	}
	long equipmentSEfactor()
    {
		temp = 0;
		foreach (ARTIFACT arti in main.NewArtifacts)
		{
			switch (arti.rank)//ランクに応じてポイント
			{
				case ARTIFACT.Rank.D:
					temp += arti.EvolutionNum * 3;
					break;
				case ARTIFACT.Rank.C:
					temp += arti.EvolutionNum * 7;
					break;
				case ARTIFACT.Rank.B:
					temp += arti.EvolutionNum * 15;
					break;
				case ARTIFACT.Rank.A:
					temp += arti.EvolutionNum * 40;
					break;
				case ARTIFACT.Rank.Epic:
					temp += arti.EvolutionNum * 30;
					break;
			}
		}
		return temp;
	}

	IEnumerator FirstAdjustmentOfPoint()//タイトルでロードされるのをまつ。
    {
		yield return new WaitUntil(() => TitleCtrl.isLoaded == true);
		yield return new WaitForSeconds(1.0f);

		tempMaterialPoint = (long)Math.Pow(TotalGoldFromMaterial(), 0.28);
		if (!main.S.isAfterVer1100)
		{
			//いったんポイント全てリセット
			main.S.SRPfromTime = 0;
			main.S.SRPfromRebirth = 0;
			main.S.SRPfromEquipment = 0;
			main.S.SRPfromBankCap = 0;
			main.S.SRPfromMaterial = 0;
			main.S.SRPfromMaterialBase = 0;
			main.S.SRPfromMontblango = 0;
			main.S.SRPfromLevel = 0;
			main.S.SRPfromMission = 0;
			main.S.SRPfromQuest = 0;
			main.S.SRPfromPrevious = 0;
			main.S.SRPconsumed = 0;
			main.S.SRPinstantConsumed = 0;
			main.S.RP = 0;

			//時間を合わせる
			main.S.reincarnationTime = main.S.allTime;
			//リバースした回数
			//main.S.SRP += main.S.AscendNum;
			main.S.AscendNumWhileReincarnation = main.S.AscendNum;
			//materialによるポイント
			//main.S.SRP += tempMaterialPoint;
			main.S.SRPfromMaterialBase = (long)Math.Pow(TotalGoldFromMaterial()*30, 0.28) + (long)(equipmentSEfactor() * 0.75);
			main.S.totalMissionCleared = MissionCount();
		}
		//main.S.SRPfromMaterialBase = (long)Math.Pow(TotalGoldFromMaterial() * 30, 0.28) + (long)(equipmentSEfactor() * 0.75);
		//initialTime = main.S.reincarnationTime;
		//initialPoint = (long)(5000 * (1 - 1.0 / (Math.Pow(1.2, initialTime / 1.0 / 7 / 24 / 3600))));
		//まだレインカーネーションしていないときは、ポイントをたす
		//if (!main.S.isAfterReincarnationImplemented)
		//{
		//	//main.S.SRP += initialPoint;
		//	main.S.SRPfromTime = initialPoint;
		//}
		main.S.isAfterVer1100 = true;
		//StartCoroutine(UpdatePlayTimePoint());
	}

	public int MissionCount()
	{
			int tempNum = 0;
			foreach (DUNGEON dungeon in main.dungeonAry)
			{
				if (!dungeon.gameObject.HasComponent<MISSION>())
				{
					continue;
				}

				if (dungeon.isMissionCompleted)
					tempNum++;

				foreach (MISSION mission in dungeon.gameObject.GetComponentsInChildren<MISSION>())
				{
					if (mission.isCleared)
					{
						tempNum++;
					}
				}
			}
		return tempNum;
	}

	//public static void GetPointFromBank(int factor = 1)
	//   {
	//	//main.S.SRP += 1;
	//	main.S.SRPfromBankCap += 1 * factor;
	//}
	//public static void GetPointFromEquipment(int factor = 1)
	//{
	//	//main.S.SRP += 1;
	//	main.S.SRPfromEquipment += 1 * factor;
	//}
	//public static void GetPointFromRebirth(int factor = 1)
	//{
	//	//main.S.SRP += 1;
	//	main.S.SRPfromRebirth += 1 * factor;
	//}

	double TotalGoldFromMaterial()
    {
		double temp = 0;
		foreach (ArtiCtrl.MaterialList material in Enum.GetValues(typeof(ArtiCtrl.MaterialList)))
		{
			temp += InventoryCtrl.MaterialInfo(material).sellPrice * main.ArtiCtrl.CurrentMaterial[material];
		}
		return temp;
	}
    public static void UpdateMaterialPoint()
    {
		double temp = 0;
		long tempPoint = 0;
		foreach (ArtiCtrl.MaterialList material in Enum.GetValues(typeof(ArtiCtrl.MaterialList)))
		{
			temp += InventoryCtrl.MaterialInfo(material).sellPrice * main.ArtiCtrl.CurrentMaterial[material];
		}
        if((long)Math.Pow(temp,0.28) > tempMaterialPoint)
        {
			//tempPoint = (long)Math.Pow(temp - tempMaterialPoint, 0.28);
			tempPoint = (long)Math.Pow(temp, 0.28) - tempMaterialPoint;
			//main.S.SRP += tempPoint;
			main.S.SRPfromMaterialBase += tempPoint;
			tempMaterialPoint = (long)Math.Pow(temp,0.28);
		}
		else
        {
			return;
		}
	}

	// Use this for initialization
	void Start () {
		StartCoroutine(FirstAdjustmentOfPoint());
		//debug用
		//main.dungeonAry[(int)Main.Dungeon.Z_slimePools].isDungeon = true;
		//Materialによるポイント

	}
	
	// Update is called once per frame
	void Update () {
		
	}

  //  IEnumerator UpdatePlayTimePoint()
  //  {
		////double tempTime = 0;
		//long tempNum = 0;
  //      while (true)
  //      {
		//	tempNum = (long)(5000 * (1 - 1.0 / (Math.Pow(1.2, main.S.reincarnationTime / 1.0 / 7 / 24 / 3600))));
  //          if (tempNum > initialPoint)
  //          {
		//		//main.S.SRP += tempNum - initialPoint;
  //              main.S.SRPfromTime += tempNum - initialPoint;
		//		initialPoint = tempNum;
  //          }
		//	yield return new WaitForSecondsRealtime(1.0f);
  //      }
  //  }
}
