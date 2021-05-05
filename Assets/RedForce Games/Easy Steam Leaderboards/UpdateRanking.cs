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
        ("MISSION_MILESTONE", (x) => { }));
        missionMileStoneHiddenButton.onClick.AddListener(() => EasySteamLeaderboards.Instance.GetLeaderboard
        ("MISSION_MILESTONE_HIDDEN", (x) => { }));
    }

    async void UploadScore()
    {
        await UniTask.Delay(3000);
        while (true)
        {
            EasySteamLeaderboards.Instance.UploadScoreToLeaderboard(milestoneId, main.S.MissionCount, (result) =>
            {
                if (result.resultCode == ESL_ResultCode.Success)
                {
                    Debug.Log("Succesfully Uploaded!");
                }
                else
                {
                    Debug.Log("Failed Uploading: " + result.resultCode.ToString());
                }
            });

            EasySteamLeaderboards.Instance.UploadScoreToLeaderboard(milestoneHiddenId, main.S.MissionCountHidden, (result) =>
            {
                if (result.resultCode == ESL_ResultCode.Success)
                {
                    Debug.Log("Succesfully Uploaded!");
                }
                else
                {
                    Debug.Log("Failed Uploading: " + result.resultCode.ToString());
                }
            });
            await UniTask.Delay(1000 * 60);
        }
    }
}
#endif