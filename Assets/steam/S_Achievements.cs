using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using static BASE;

public class S_Achievements
{
    public Func<bool>[] SteamAchievementConditions = new Func<bool>[24];
    public void SetConditions()
    {
        SteamAchievementConditions[0] = () => main.dungeonAry[(int)Main.Dungeon.slimeHideout].isDungeon;
        SteamAchievementConditions[1] = () => main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.slimes].isCleared;
        SteamAchievementConditions[2] = () => main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.golem].isCleared;
        SteamAchievementConditions[3] = () => main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.spider].isCleared;
        SteamAchievementConditions[4] = () => main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.fairy].isCleared;
        SteamAchievementConditions[5] = () => main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.banana].isCleared;
        SteamAchievementConditions[6] = () => main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.montblango].isCleared;
        SteamAchievementConditions[7] = () => main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.octan].isCleared;
        SteamAchievementConditions[8] = () => main.QuestCtrl.Quests[(int)QuestCtrl.QuestId.distortion].isCleared;
        SteamAchievementConditions[9] = () => main.S.slimeReputation >= 10000;
        SteamAchievementConditions[10] = () => IsQuestAllCopmleted();
        SteamAchievementConditions[11] = () => GemIsAllOverLv100();
        SteamAchievementConditions[12] = () => IsAllSkillOver200Lv();
        SteamAchievementConditions[13] = () => IsCraftAll(ARTIFACT.Rank.D);
        SteamAchievementConditions[14] = () => IsCraftAll(ARTIFACT.Rank.C);
        SteamAchievementConditions[15] = () => IsCraftAll(ARTIFACT.Rank.B);
        SteamAchievementConditions[16] = () => IsCraftAll(ARTIFACT.Rank.A);
        SteamAchievementConditions[17] = () => IsCraftAll(ARTIFACT.Rank.Epic);
        SteamAchievementConditions[18] = () => main.dungeonAry[(int)Main.Dungeon.Z_BB8].isDungeon;
        SteamAchievementConditions[19] = () => main.MissionCount >= 384;
        SteamAchievementConditions[20] = () => IsReinSkillOver100Lv();
        SteamAchievementConditions[21] = () => IsThreeCursesCleared() ;
        SteamAchievementConditions[22] = () => main.S.TotalChiliGathered >= 100;
        SteamAchievementConditions[23] = () => main.S.TotalReinbowFishGathered >= 100;
    }

    bool IsQuestAllCopmleted()
    {
        foreach (var item in main.quests)
        {
            if(item.questType == ACHIEVEMENT.Type.Limited && item.clearNum == item.MaxClearNum)
            {
                continue;
            }
            else
            {
                return false;
            }
        }
        return true;
    }
    bool GemIsAllOverLv100()
    {
        foreach(var item in main.jems)
        {
            if(item.JemLevel < 100)
            {
                return false;
            }
            else
            {
                continue;
            }
        }
        return true;
    }
    bool IsCraftAll(ARTIFACT.Rank rank)
    {
        foreach(var item in main.NewArtifacts)
        {
            if (item.rank != rank)
                continue;

            if(item.condition == ARTIFACT.Condition.complete)
            {   
                continue;
            }
            else
            {
                return false;
            }
        }
        return true;
    }
    bool IsAllSkillOver200Lv()
    {
        foreach (var item in main.skillList.WarriorSkills)
        {
            if(item.P_level < 200)
                return false;
            else
                continue;
        }
        foreach (var item in main.skillList.WizardSkills)
        {
            if (item.P_level < 200)
                return false;
            else
                continue;
        }
        foreach (var item in main.skillList.AngelSkills)
        {
            if (item.P_level < 200)
                return false;
            else
                continue;
        }
        return true;
    }
    bool IsReinSkillOver100Lv()
    {

        if (main.warriorSkillAry[10].P_level >= 100 && main.warriorSkillAry[11].P_level >= 100 && main.warriorSkillAry[12].P_level >= 100)
        { }
        else
        {
            return false;
        }
        if (main.wizardSkillAry[10].P_level >= 100 && main.wizardSkillAry[11].P_level >= 100 && main.wizardSkillAry[12].P_level >= 100)
        { }
        else
        {
            return false;
        }
        if (main.angelSkillAry[10].P_level >= 100 && main.angelSkillAry[11].P_level >= 100 && main.angelSkillAry[12].P_level >= 100)
        { }
        else
        {
            return false;
        }
        return true;
    }
    bool IsThreeCursesCleared()
    {
        if(main.S.CurseReinClearNum[(int)CurseId.curse_of_warrior2] >= 1
            && main.S.CurseReinClearNum[(int)CurseId.curse_of_wizard2] >= 1
            && main.S.CurseReinClearNum[(int)CurseId.curse_of_angel2] >= 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
