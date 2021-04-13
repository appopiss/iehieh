using UnityEngine;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

// Ad positions
public enum CrazyAdType
{
    midgame,
    rewarded
}

// Ad events
public enum CrazySDKEvent
{
    adStarted, // fired when ad starts playing
    adFinished, // fired when ad has finished (either when completed or when user pressed skip)
    adCompleted, // fired when user has completely watched the ad
    adError, // fired when an error occurs, also fired when no ad is available
    adblockDetectionExecuted, // fired when adblock detection has run
}

// Initialization Object received from gameframe
public class InitializationObject
{
    public string gameLink;
}

public class CrazySDK : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern string InitSDK(string version, string objectName);

    [DllImport("__Internal")]
    private static extern void RequestAdSDK(string str);

    [DllImport("__Internal")]
    private static extern void HappyTimeSDK();

    [DllImport("__Internal")]
    private static extern void GameplayStartSDK();

    [DllImport("__Internal")]
    private static extern void GameplayStopSDK();

    [DllImport("__Internal")]
    private static extern void RequestInviteUrlSDK(string url);

    [DllImport("__Internal")]
    private static extern void CopyToClipboard(string text);

    [DllImport("__Internal")]
    private static extern string GetUrlParameters();

    public static string sdkVersion = "1.7.1";

    private static CrazySDK instance = null;

    private Dictionary<CrazySDKEvent, List<EventCallback>> eventListeners;
    private bool isInitialized = false;

    private bool requestInProgress = false;
    private bool adblockDetectionExecuted = false;
    private bool hasAdblock = false;
    private InitializationObject initObj;

    private CrazySDK()
    {
        eventListeners = new Dictionary<CrazySDKEvent, List<EventCallback>>();
    }

    public static CrazySDK Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (CrazySDK)FindObjectOfType(typeof(CrazySDK));

                if (instance)
                {
                    return instance;
                }
                else
                {
                    instance = new GameObject("CrazySDK").AddComponent<CrazySDK>();
                    DontDestroyOnLoad(instance);
                }

            }

            return instance;
        }
    }

    public void Initialize()
    {
        if (IsInitialized())
        {
            return;
        }
        if (Debug.isDebugBuild)
        {
            Debug.LogWarning("[CrazySDK] Development Build");
        }

        isInitialized = true;

#if (!UNITY_EDITOR)
		CrazySDK.InitSDK(CrazySDK.sdkVersion, this.name);
#else
        this.initObj = new InitializationObject();
        this.initObj.gameLink = "https://www.crazygames.com/game/yourFabulousGameHere";
#endif
    }

    public bool IsInitialized()
    {
        return (initObj != null && isInitialized);
    }

    public void RequestAd(CrazyAdType adType = CrazyAdType.midgame)
    {
        DebugLog("Requesting Ad");

        if (!this.IsInitialized())
        {
            DebugLog("Initialize CrazySDK first");
            return;
        }
        if (requestInProgress)
        {
            DebugLog("Request in progress");
            return;
        }
        requestInProgress = true;
#if (!UNITY_EDITOR)
		CrazySDK.RequestAdSDK(adType.ToString());
#else
        AdEvent("adError");
#endif
    }

    public void HappyTime()
    {
        DebugLog("Happy time!");

        if (!this.IsInitialized())
        {
            DebugLog("Initialize CrazySDK first");
            return;
        }

#if (!UNITY_EDITOR)
		CrazySDK.HappyTimeSDK();
#else
        DebugLog("Happytime simulation yeah! Here have a cookie :D");
#endif
    }

    public void GameplayStart()
    {
        DebugLog("Gameplay start called");

        if (!this.IsInitialized())
        {
            DebugLog("Initialize CrazySDK first");
            return;
        }

#if (!UNITY_EDITOR)
		CrazySDK.GameplayStartSDK();
#else
        DebugLog("Gameplay start simulation for unity editor");
#endif
    }

    public void GameplayStop()
    {
        DebugLog("Gameplay start called");

        if (!this.IsInitialized())
        {
            DebugLog("Initialize CrazySDK first");
            return;
        }

#if (!UNITY_EDITOR)
		CrazySDK.GameplayStopSDK();
#else
        DebugLog("Gameplay stop simulation for unity editor");
#endif
    }

    public string InviteLink(Dictionary<string, string> parameters)
    {
        DebugLog("Invite link called");

        if (!this.IsInitialized())
        {
            DebugLog("Initialize CrazySDK first");
            return null;
        }

        string queryFromParams = "utm_source=invite";
        foreach (KeyValuePair<string, string> parameter in parameters)
        {
            string paramString = string.Format("{0}={1}", parameter.Key, parameter.Value);
            queryFromParams = string.Format("{0}&{1}", queryFromParams, paramString);
        }

        string gameLink = this.GetGameLink();
        string template = gameLink.Contains("?") ? "{0}&{1}" : "{0}?{1}";
        string inviteLink = string.Format(template, gameLink, queryFromParams);

#if (!UNITY_EDITOR)
		CrazySDK.RequestInviteUrlSDK(inviteLink);
#else
        DebugLog("Invite link simulation for unity editor");
#endif

        return inviteLink;
    }

    public void CopyToClipboardTest(string text)
    {
        CrazySDK.CopyToClipboard(text);
    }

    public bool IsInviteLink()
    {
#if (!UNITY_EDITOR)
        string utmSource = GetUrlParameter("utm_source");
        return utmSource == "invite";
#else
        Debug.Log("Cannot parse url in Unity editor, try running it in a browser");
        return false;
#endif
    }

    public string GetInviteLinkParameter(string key)
    {
#if (!UNITY_EDITOR)
        return GetUrlParameter(key);
#else
        Debug.Log("Cannot parse url in Unity editor, try running it in a browser");
        return "";
#endif
    }

    private string GetUrlParameter(string key)
    {
        Regex _regex = new Regex(@"[?&](\w[\w.]*)=([^?&]+)");
        string paramsStr = CrazySDK.GetUrlParameters();
        var match = _regex.Match(paramsStr);
        var parameters = new Dictionary<string, string>();
        while (match.Success)
        {
            parameters.Add(match.Groups[1].Value, match.Groups[2].Value);
            match = match.NextMatch();
        }

        try
        {
            return parameters[key];
        }
        catch
        {
            return null;
        }
    }

    public string GetGameLink()
    {
        if (this.initObj != null)
        {
            return this.initObj.gameLink;
        }
        return null;
    }

    public delegate void EventCallback();

    public void AddEventListener(CrazySDKEvent eventType, EventCallback callback)
    {
        //DebugLog("Adding event listener " + eventType.ToString());

        if (!eventListeners.ContainsKey(eventType))
        {
            eventListeners.Add(eventType, new List<EventCallback>());
        }

        eventListeners[eventType].Add(callback);
    }

    public void RemoveEventListener(CrazySDKEvent eventType, EventCallback callback)
    {
        //DebugLog("Removing event listener");

        if (eventListeners.ContainsKey(eventType))
        {
            eventListeners[eventType].Remove(callback);
        }
    }

    public void RemoveEventListenersForEvent(CrazySDKEvent eventType)
    {
        DebugLog("Removing all event listener for " + eventType.ToString());

        eventListeners.Remove(eventType);
    }

    public void RemoveAllEventListeners()
    {
        DebugLog("Removing all event listeners");

        eventListeners.Clear();
    }

    public void AdEvent(string eventName)
    {
        if (!this.IsInitialized())
        {
            return;
        }
        CrazySDKEvent parsedEvent = (CrazySDKEvent)System.Enum.Parse(typeof(CrazySDKEvent), eventName);
        HandleEvent(parsedEvent);
        CallCallbacks(parsedEvent);
    }

    public void InitCallback(string initObjJSON)
    {
        this.initObj = JsonUtility.FromJson<InitializationObject>(initObjJSON);
    }

    public bool HasAdblock()
    {
        if (!adblockDetectionExecuted)
        {
            DebugLog("Adblock detection has not finished");
        }
        return hasAdblock;
    }

    public bool AdblockDetectionExecuted()
    {
        return adblockDetectionExecuted;
    }

    public void AdblockDetected()
    {
        Adblock(true);
    }

    public void AdblockNotDetected()
    {
        Adblock(false);
    }

    private void HandleEvent(CrazySDKEvent ev)
    {
        switch (ev)
        {
            case CrazySDKEvent.adFinished:
            case CrazySDKEvent.adError:
                requestInProgress = false;
                break;

            default:
                break;
        }
    }

    private void Adblock(bool detected)
    {
        this.adblockDetectionExecuted = true;
        this.hasAdblock = detected;
        CallCallbacks(CrazySDKEvent.adblockDetectionExecuted);
    }

    private void CallCallbacks(CrazySDKEvent ev)
    {
        if (eventListeners.ContainsKey(ev))
        {
            foreach (EventCallback callback in eventListeners[ev])
            {
                callback();
            }
        }
    }

    private void DebugLog(string msg)
    {
        if (Debug.isDebugBuild)
        {
            Debug.Log("[CrazySDK] " + msg);
        }
    }
}
