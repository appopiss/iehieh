using System.Collections.Generic;
using UnityEngine;

public class CrazyEvents : MonoBehaviour
{

    static CrazyEvents instance;
    public static CrazyEvents Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (CrazyEvents)FindObjectOfType(typeof(CrazyEvents));

                if (instance)
                {
                    return instance;
                }
                else
                {
                    instance = new GameObject("CrazyEvents").AddComponent<CrazyEvents>();
                    instance.Initialize();
                    DontDestroyOnLoad(instance);
                }
            }

            return instance;
        }
    }

    void Initialize()
    {
        //Add CrazyEventsOff; Scripting Define Symbol in Build Settings to disable CrazyEventsOff
#if CrazyEventsOff
		return;
#endif

        CrazySDK.Instance.Initialize(); // call initialize once, must be done so that javascript can communicate with Unity

        Debug.Log("CrazyEvents: Initialized!");
    }

    public void HappyTime()
    {
        CrazySDK.Instance.HappyTime();
    }

    public void GameplayStart()
    {
        CrazySDK.Instance.GameplayStart();
    }

    public void GameplayStop()
    {
        CrazySDK.Instance.GameplayStop();
    }

    public string InviteLink(Dictionary<string, string> parameters)
    {
        return CrazySDK.Instance.InviteLink(parameters);
    }

    public bool IsInviteLink()
    {
        return CrazySDK.Instance.IsInviteLink();
    }

    public string GetInviteLinkParameter(string key)
    {
        return CrazySDK.Instance.GetInviteLinkParameter(key);
    }

    public void CopyToClipboard(string text)
    {
        CrazySDK.Instance.CopyToClipboardTest(text);
    }
}

