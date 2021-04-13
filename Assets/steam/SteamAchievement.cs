#if UNITY_ANDROID || UNITY_IOS || UNITY_TIZEN || UNITY_TVOS || UNITY_WEBGL || UNITY_WSA || UNITY_PS4 || UNITY_WII || UNITY_XBOXONE || UNITY_SWITCH
#define DISABLESTEAMWORKS
#endif

#if !DISABLESTEAMWORKS
using Steamworks;
using UnityEngine;
using System.Collections;
using System.ComponentModel;
using static BASE;
using System;


// This is a port of StatsAndAchievements.cpp from SpaceWar, the official Steamworks Example.
class SteamAchievement : MonoBehaviour
{
	private enum Achievement : int
	{
		ACHIEVEMENT_TUTORIAL,
        ACHIEVEMENT_SLIME,
        ACHIEVEMENT_GOLEM,
        ACHIEVEMENT_DEATHPIDER,
        ACHIEVEMENT_FAIRY,
        ACHIEVEMENT_BANANOON,
        ACHIEVEMENT_MONTBLANGO,
        ACHIEVEMENT_OCTOBADDIE,
        ACHIEVEMENT_DISTORTIONSLIME,
        ACHIEVEMENT_BANK,
        ACHIEVEMENT_QUEST,
        ACHIEVEMENT_DARKRITUAL,
        ACHIEVEMENT_LOWERSKILL,
        ACHIEVEMENT_CRAFT_D,
        ACHIEVEMENT_CRAFT_C,
        ACHIEVEMENT_CRAFT_B,
        ACHIEVEMENT_CRAFT_A,
        ACHIEVEMENT_CRAFT_S,
        ACHIEVEMENT_BRAVE,
        ACHIEVEMENT_KING,
        ACHIEVEMENT_EPICHERO,
        ACHIEVEMENT_CURSE,
        ACHIEVEMENT_CHILI,
        ACHIEVEMENT_RAINBOWFISH
	};

	private Achievement_t[] m_Achievements = new Achievement_t[] {
		new Achievement_t(Achievement.ACHIEVEMENT_TUTORIAL, "Beginning of Adventure", "Complete the tutorial!"),
		new Achievement_t(Achievement.ACHIEVEMENT_SLIME, "Slime King Slayer", "Defeat Slime King!"),
        new Achievement_t(Achievement.ACHIEVEMENT_GOLEM, "Golem Slayer", "Defeat Golem!"),
		new Achievement_t(Achievement.ACHIEVEMENT_DEATHPIDER, "Deathpider Slayer", "Defeat Deathpider!"),
        new Achievement_t(Achievement.ACHIEVEMENT_FAIRY, "Fairy Slayer", "Defeat Fairy!"),
		new Achievement_t(Achievement.ACHIEVEMENT_BANANOON, "Bananoon Slayer", "Defeat Bananoon!"),
		new Achievement_t(Achievement.ACHIEVEMENT_MONTBLANGO, "Montblango Slayer", "Defeat Montblango!"),
		new Achievement_t(Achievement.ACHIEVEMENT_OCTOBADDIE, "Octobaddie Slayer", "Defeat Octobaddie!"),
		new Achievement_t(Achievement.ACHIEVEMENT_DISTORTIONSLIME, "Distortion Slime Slayer", "Defeat Distortion Slime!"),
		new Achievement_t(Achievement.ACHIEVEMENT_BANK, "Bank Manager", "Achieve 10000 Reputations!"),
		new Achievement_t(Achievement.ACHIEVEMENT_QUEST, "Quest Master", "Complete all the quests except repeatble ones!"),
		new Achievement_t(Achievement.ACHIEVEMENT_DARKRITUAL, "Darkside Hero", "Achieve all Gems Lv100 in Dark Ritual!"),
		new Achievement_t(Achievement.ACHIEVEMENT_LOWERSKILL, "Skill Master", "Fill the skill progress bar (Class Passives) for all 3 classes!"),
		new Achievement_t(Achievement.ACHIEVEMENT_CRAFT_D, "Beginner Collector", "Craft all equipments of Rank D!"),
		new Achievement_t(Achievement.ACHIEVEMENT_CRAFT_C, "Experienced Collector", "Craft all equipments of Rank C!"),
		new Achievement_t(Achievement.ACHIEVEMENT_CRAFT_B, "Insatiable Collector", "Craft all equipments of Rank B!"),
		new Achievement_t(Achievement.ACHIEVEMENT_CRAFT_A, "Greedy Collector", "Craft all equipments of Rank A!"),
		new Achievement_t(Achievement.ACHIEVEMENT_CRAFT_S, "Legendary Collector", "Craft all equipments of Rank S!"),
		new Achievement_t(Achievement.ACHIEVEMENT_BRAVE, "Brave Adventurer", "Complete Area 8-8!"),
		new Achievement_t(Achievement.ACHIEVEMENT_KING, "King of Adventurer", "Complete all Mission Milestones!"),
		new Achievement_t(Achievement.ACHIEVEMENT_EPICHERO, "Epic Hero", "Achieve Lv 100 for all Reincarnation Skills!"),
		new Achievement_t(Achievement.ACHIEVEMENT_CURSE, "Cursed Hero", "Complete 3 curses (Road of Warrior 2, Road of Wizard 2 and Road of Angel 2)!"),
		new Achievement_t(Achievement.ACHIEVEMENT_CHILI, "Red Chili Lover", "Collect 100 Red Chills!"),
		new Achievement_t(Achievement.ACHIEVEMENT_RAINBOWFISH, "Famous Fisherman", "Collect 100 Rainbow Fish!"),
	};

	// Our GameID
	private CGameID m_GameID;

	// Did we get the stats from Steam?
	private bool m_bRequestedStats;
	private bool m_bStatsValid;

	// Should we store stats this frame?
	private bool m_bStoreStats;

	protected Callback<UserStatsReceived_t> m_UserStatsReceived;
	protected Callback<UserStatsStored_t> m_UserStatsStored;
	protected Callback<UserAchievementStored_t> m_UserAchievementStored;

	//これはIEH用
	void CheckSteamAchievement()
	{
		foreach (Achievement_t achievement in m_Achievements)
		{
			if (achievement.m_bAchieved)
				main.S.isAchievedSteam[(int)achievement.m_eAchievementID] = true;
		}
	}


	void OnEnable()
	{
		//IEH用
		CheckSteamAchievement();

		if (!SteamManager.Initialized)
			return;

		// Cache the GameID for use in the Callbacks
		m_GameID = new CGameID(SteamUtils.GetAppID());

		m_UserStatsReceived = Callback<UserStatsReceived_t>.Create(OnUserStatsReceived);
		m_UserStatsStored = Callback<UserStatsStored_t>.Create(OnUserStatsStored);
		m_UserAchievementStored = Callback<UserAchievementStored_t>.Create(OnAchievementStored);

		// These need to be reset to get the stats upon an Assembly reload in the Editor.
		m_bRequestedStats = false;
		m_bStatsValid = false;
	}

	private void Update()
	{
		if (!SteamManager.Initialized)
			return;

		CheckSteamAchievement();

		if (!m_bRequestedStats)
		{
			// Is Steam Loaded? if no, can't get stats, done
			if (!SteamManager.Initialized)
			{
				m_bRequestedStats = true;
				return;
			}

			// If yes, request our stats
			bool bSuccess = SteamUserStats.RequestCurrentStats();

			// This function should only return false if we weren't logged in, and we already checked that.
			// But handle it being false again anyway, just ask again later.
			m_bRequestedStats = bSuccess;
		}

		if (!m_bStatsValid)
			return;

		// Get info from sources

		// Evaluate achievements
		foreach (Achievement_t achievement in m_Achievements)
		{
			if (achievement.m_bAchieved)
				continue;

            if (achievement.ThisCondition())
            {
				UnlockAchievement(achievement);
			}
		}

		//Store stats in the Steam database if necessary
		if (m_bStoreStats)
		{

			bool bSuccess = SteamUserStats.StoreStats();
			// If this failed, we never sent anything to the server, try
			// again later.
			m_bStoreStats = !bSuccess;
		}
	}


	//-----------------------------------------------------------------------------
	// Purpose: Unlock this achievement
	//-----------------------------------------------------------------------------
	private void UnlockAchievement(Achievement_t achievement)
	{
		achievement.m_bAchieved = true;

		// the icon may change once it's unlocked
		//achievement.m_iIconImage = 0;
		main.S.isAchievedSteam[(int)achievement.m_eAchievementID] = true;
		main.Log("Achievement Unlocked!", 10f);
		// mark it down
		SteamUserStats.SetAchievement(achievement.m_eAchievementID.ToString());

		// Store stats end of frame
		m_bStoreStats = true;
	}

	//-----------------------------------------------------------------------------
	// Purpose: We have stats data from Steam. It is authoritative, so update
	//			our data with those results now.
	//-----------------------------------------------------------------------------
	private void OnUserStatsReceived(UserStatsReceived_t pCallback)
	{
		if (!SteamManager.Initialized)
			return;

		// we may get callbacks for other games' stats arriving, ignore them
		if ((ulong)m_GameID == pCallback.m_nGameID)
		{
			if (EResult.k_EResultOK == pCallback.m_eResult)
			{
				Debug.Log("Received stats and achievements from Steam\n");

				m_bStatsValid = true;

				// load achievements
				foreach (Achievement_t ach in m_Achievements)
				{
					bool ret = SteamUserStats.GetAchievement(ach.m_eAchievementID.ToString(), out ach.m_bAchieved);
					if (ret)
					{
						ach.m_strName = SteamUserStats.GetAchievementDisplayAttribute(ach.m_eAchievementID.ToString(), "name");
						ach.m_strDescription = SteamUserStats.GetAchievementDisplayAttribute(ach.m_eAchievementID.ToString(), "desc");
					}
					else
					{
						Debug.LogWarning("SteamUserStats.GetAchievement failed for Achievement " + ach.m_eAchievementID + "\nIs it registered in the Steam Partner site?");
					}
				}

				// load stats
				//SteamUserStats.GetStat("NumGames", out m_nTotalGamesPlayed);
			}
			else
			{
				Debug.Log("RequestStats - failed, " + pCallback.m_eResult);
			}
		}
	}

	//-----------------------------------------------------------------------------
	// Purpose: Our stats data was stored!
	//-----------------------------------------------------------------------------
	private void OnUserStatsStored(UserStatsStored_t pCallback)
	{
		// we may get callbacks for other games' stats arriving, ignore them
		if ((ulong)m_GameID == pCallback.m_nGameID)
		{
			if (EResult.k_EResultOK == pCallback.m_eResult)
			{
				Debug.Log("StoreStats - success");
			}
			else if (EResult.k_EResultInvalidParam == pCallback.m_eResult)
			{
				// One or more stats we set broke a constraint. They've been reverted,
				// and we should re-iterate the values now to keep in sync.
				Debug.Log("StoreStats - some failed to validate");
				// Fake up a callback here so that we re-load the values.
				UserStatsReceived_t callback = new UserStatsReceived_t();
				callback.m_eResult = EResult.k_EResultOK;
				callback.m_nGameID = (ulong)m_GameID;
				OnUserStatsReceived(callback);
			}
			else
			{
				Debug.Log("StoreStats - failed, " + pCallback.m_eResult);
			}
		}
	}

	//-----------------------------------------------------------------------------
	// Purpose: An achievement was stored
	//-----------------------------------------------------------------------------
	private void OnAchievementStored(UserAchievementStored_t pCallback)
	{
		// We may get callbacks for other games' stats arriving, ignore them
		if ((ulong)m_GameID == pCallback.m_nGameID)
		{
			if (0 == pCallback.m_nMaxProgress)
			{
				Debug.Log("Achievement '" + pCallback.m_rgchAchievementName + "' unlocked!");
			}
			else
			{
				Debug.Log("Achievement '" + pCallback.m_rgchAchievementName + "' progress callback, (" + pCallback.m_nCurProgress + "," + pCallback.m_nMaxProgress + ")");
			}
		}
	}

	private class Achievement_t
	{
		public Achievement m_eAchievementID;
		public string m_strName;
		public string m_strDescription;
		public bool m_bAchieved;
		public Func<bool> ThisCondition = () => false;

		/// <summary>
		/// Creates an Achievement. You must also mirror the data provided here in https://partner.steamgames.com/apps/achievements/yourappid
		/// </summary>
		/// <param name="achievement">The "API Name Progress Stat" used to uniquely identify the achievement.</param>
		/// <param name="name">The "Display Name" that will be shown to players in game and on the Steam Community.</param>
		/// <param name="desc">The "Description" that will be shown to players in game and on the Steam Community.</param>
		public Achievement_t(Achievement achievementID, string name, string desc)
		{
			m_eAchievementID = achievementID;
			m_strName = name;
			m_strDescription = desc;
			m_bAchieved = false;
			S_Achievements conditions = new S_Achievements();
			conditions.SetConditions();
			ThisCondition = conditions.SteamAchievementConditions[(int)m_eAchievementID];
		}
	}
}
#endif