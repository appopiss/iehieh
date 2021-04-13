#if UNITY_ANDROID || UNITY_IOS || UNITY_TIZEN || UNITY_TVOS || UNITY_WEBGL || UNITY_WSA || UNITY_PS4 || UNITY_WII || UNITY_XBOXONE || UNITY_SWITCH
#define DISABLESTEAMWORKS
#endif

#if !DISABLESTEAMWORKS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESL_LeaderboardFilterSelector : MonoBehaviour 
{
	public static event System.Action<ESL_LeaderboardUI.LeaderboardFilter> onFilterSelected;

	public ESL_LeaderboardUI.LeaderboardFilter filterType;

	public void OnFilterSelected()
	{
		if(onFilterSelected != null)
			onFilterSelected(filterType);
	}
}
#endif
