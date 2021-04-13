using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CrazyAds : MonoBehaviour
{
    static CrazyAds instance;
    public static CrazyAds Instance
    {
        get
        {
            if (!instance)
            {
                instance = GameObject.FindObjectOfType<CrazyAds>();//first check if CrazyAds has already been added to the scene

                if (instance == null)
                {//if not found, create it..
                    GameObject prefab = (GameObject)Resources.Load("CrazyAds");
                    instance = Instantiate(prefab).GetComponent<CrazyAds>();
                }

                instance.Initialize();
                DontDestroyOnLoad(instance);
            }
            return instance;
        }
    }

    public GameObject[] activeDuringAdObjs;
    public bool freezeTimeDuringBreak = true; //Change to false if your game needs to run in background during ad breaks
    bool _isRunningAd = false;

    public bool IsRunningAd
    {
        get
        {
            return _isRunningAd;
        }
        set
        {
            _isRunningAd = value;

            //Debug.Log("IsRunningAd: "+_isRunningAd);

            AudioListener.volume = _isRunningAd ? 0 : 1;

            if (freezeTimeDuringBreak) Time.timeScale = _isRunningAd ? 0 : origTimeScale;

            Application.runInBackground = _isRunningAd ? true : origRunInBackground;

            continueBtn.gameObject.SetActive(!_isRunningAd);
            print("continueBtn: " + continueBtn.isActiveAndEnabled);

            pleaseWaitTxt.gameObject.SetActive(_isRunningAd);

            foreach (GameObject obj in activeDuringAdObjs) obj.SetActive(_isRunningAd);
        }
    }

    public delegate void AdBreakCompletedCallback();
    AdBreakCompletedCallback onCompletedAdBreak;

    public delegate void AdErrorCallback();
    AdErrorCallback onAdError;


    static float timeOfLastAdBreak;
    float origTimeScale;

    Button continueBtn;
    Text pleaseWaitTxt;
    bool origRunInBackground;

    void Initialize()
    {
        //Add CrazyAdsOff; Scripting Define Symbol in Build Settings to disable CrazyAds
#if CrazyAdsOff
        return;
#endif

        CrazySDK.Instance.Initialize(); // call initialize once, must be done so that javascript can communicate with Unity

        //Handle Events
        CrazySDK.Instance.AddEventListener(CrazySDKEvent.adError, AdError);
        CrazySDK.Instance.AddEventListener(CrazySDKEvent.adFinished, AdFinished);
        CrazySDK.Instance.AddEventListener(CrazySDKEvent.adStarted, AdStarted);
        CrazySDK.Instance.AddEventListener(CrazySDKEvent.adblockDetectionExecuted, adblockDetectionExecuted);

        continueBtn = transform.Find("Canvas").Find("ContinueBtn").GetComponent<Button>();
        continueBtn.gameObject.SetActive(false);

        pleaseWaitTxt = transform.Find("Canvas").Find("PleaseWait").GetComponent<Text>();
        pleaseWaitTxt.gameObject.SetActive(false);

        //print("CrazyAds: Initialized!");
    }

    public void beginAdBreakRewarded(AdBreakCompletedCallback completedCallback = null, AdErrorCallback errorCallback = null)
    {
        beginAdBreak(completedCallback, errorCallback, CrazyAdType.rewarded);
    }

    public void beginAdBreak(AdBreakCompletedCallback completedCallback = null, AdErrorCallback errorCallback = null, CrazyAdType adType = CrazyAdType.midgame)
    {
        origTimeScale = Time.timeScale;
        origRunInBackground = Application.runInBackground;

        onCompletedAdBreak = completedCallback;
        onAdError = errorCallback;

        float timeSinceLastAdBreak = Time.time - timeOfLastAdBreak;
        print("Time Since Last Ad Break = " + timeSinceLastAdBreak + " seconds");

        IsRunningAd = true;

        print("Requesting CrazyAd Type: " + adType.ToString());

#if UNITY_EDITOR
        print("CrazyAds: simulating ad request because we are in Editor .. game will resume in 3 seconds ..");

        if (transform.GetChild(0) && transform.GetChild(0).Find("AdSimulationPanel"))
        {
            transform.GetChild(0).Find("AdSimulationPanel").gameObject.SetActive(true);
        }

        AdStarted();

        StartCoroutine(InvokeRealtimeCoroutine(completedAdRequest, 3));

        return;
#else
        CrazySDK.Instance.RequestAd(adType);    
#endif
    }

#if UNITY_EDITOR
    private IEnumerator InvokeRealtimeCoroutine(UnityAction action, float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        action();
    }
#endif

    void completedAdRequest()
    {
        completedAdRequest(CrazySDKEvent.adCompleted);
    }

    void completedAdRequest(CrazySDKEvent e)
    {
        Debug.Log("Ad Finished");

        IsRunningAd = false;

        if (e == CrazySDKEvent.adError && onAdError != null) onAdError.Invoke();
        else if (onCompletedAdBreak != null) onCompletedAdBreak.Invoke();
    }

    #region eventListeners

    void AdError()
    {
        Debug.Log("Ad Error");
        completedAdRequest(CrazySDKEvent.adError);
    }

    void AdFinished()
    {
        Debug.Log("Ad Finished");
        completedAdRequest(CrazySDKEvent.adFinished);

    }

    void AdStarted()
    {
        Debug.Log("Ad Started");
        IsRunningAd = true;
        timeOfLastAdBreak = Time.time;
    }

    void adblockDetectionExecuted()
    {
        Debug.Log("adblockDetection Started");
    }

    #endregion
}

