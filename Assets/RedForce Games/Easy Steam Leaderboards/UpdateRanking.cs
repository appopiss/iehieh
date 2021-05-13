#if UNITY_ANDROID || UNITY_IOS || UNITY_TIZEN || UNITY_TVOS || UNITY_WEBGL || UNITY_WSA || UNITY_PS4 || UNITY_WII || UNITY_XBOXONE || UNITY_SWITCH
#define DISABLESTEAMWORKS
#endif

#if !DISABLESTEAMWORKS
using Steamworks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasySteamLeaderboard;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;
using static BASE;

public class UpdateRanking : MonoBehaviour
{
    public Button missionMileStoneButton, missionMileStoneHiddenButton;
    static readonly string milestoneId = "MISSION_MILESTONE";
    static readonly string milestoneHiddenId = "MISSION_MILESTONE_HIDDEN";
    // Start is called before the first frame update
    void Start()
    {
        UploadScore();
        missionMileStoneButton.onClick.AddListener(() => EasySteamLeaderboards.Instance.GetLeaderboard
        (milestoneId, (result) =>
        {
            if (result.resultCode == ESL_ResultCode.Success)
            {
                main.Log("Global Entries Count : " + result.GlobalEntries.Count, 10);
                main.Log("Local Steam User Rank : " + result.SteamUserEntry.GlobalRank, 10);
                Debug.Log("Global Entries Count : " + result.GlobalEntries.Count);
                Debug.Log("Local Steam User Rank : " + result.SteamUserEntry.GlobalRank);
            }
            else
            {
                main.Log("Failed Fetching: " + result.resultCode.ToString(), 10);
                Debug.Log("Failed Fetching : " + result.resultCode.ToString());
            }
        }
        ));
        missionMileStoneHiddenButton.onClick.AddListener(() => EasySteamLeaderboards.Instance.GetLeaderboard
        (milestoneHiddenId, (x) => { }));

        //Debug:
        missionMileStoneButton.onClick.AddListener(() =>
        {
            EasySteamLeaderboards.Instance.UploadScoreToLeaderboard(milestoneId, main.S.MissionCount, (result) =>
            {
                if (result.resultCode == ESL_ResultCode.Success)
                {
                    main.Log("Succesfully Uploaded!", 10);
                    Debug.Log("Succesfully Uploaded!");
                }
                else
                {
                    main.Log("Failed Uploading: " + result.resultCode.ToString(), 10);
                    Debug.Log("Failed Uploading: " + result.resultCode.ToString());
                }
            });
        });
    }

    async void UploadScore()
    {
        main.Log("called UpdateScore", 10);
        await UniTask.Delay(600);//(3000);Debug
        int i = 0;
        while (true)
        {
            i++;
            main.Log("called UpdateScore" + i.ToString(), 10);

            EasySteamLeaderboards.Instance.UploadScoreToLeaderboard(milestoneId, main.S.MissionCount, (result) =>
            {
                if (result.resultCode == ESL_ResultCode.Success)
                {
                    main.Log("Succesfully Uploaded!", 10);
                    Debug.Log("Succesfully Uploaded!");
                }
                else
                {
                    main.Log("Failed Uploading: " + result.resultCode.ToString(), 10);
                    Debug.Log("Failed Uploading: " + result.resultCode.ToString());
                }
            });

            EasySteamLeaderboards.Instance.UploadScoreToLeaderboard(milestoneHiddenId, main.S.MissionCountHidden, (result) =>
            {
                if (result.resultCode == ESL_ResultCode.Success)
                {
                    main.Log("Succesfully Uploaded! Hidden", 10);
                    Debug.Log("Succesfully Uploaded!");
                }
                else
                {
                    main.Log("Failed Uploading Hidden : " + result.resultCode.ToString(), 10);
                    Debug.Log("Failed Uploading: " + result.resultCode.ToString());
                }
            });
            await UniTask.Delay(10 * 1000);//Debug(1000 * 60);
        }
    }
}
#endif