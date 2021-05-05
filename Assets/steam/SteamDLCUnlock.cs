#if UNITY_ANDROID || UNITY_IOS || UNITY_TIZEN || UNITY_TVOS || UNITY_WEBGL || UNITY_WSA || UNITY_PS4 || UNITY_WII || UNITY_XBOXONE || UNITY_SWITCH
#define DISABLESTEAMWORKS
#endif

#if !DISABLESTEAMWORKS
using Steamworks;
#endif
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using static BASE;

public class SteamDLCUnlock : MonoBehaviour {
#if !DISABLESTEAMWORKS
    AppId_t dlc_starter = new AppId_t(1555850);
    AppId_t dlc_global = new AppId_t(1555851);
    AppId_t dlc_nitro = new AppId_t(1555852);
    AppId_t dlc_goldcap = new AppId_t(1555853);
    AppId_t dlc_ieh2support = new AppId_t(1580930);

    AppId_t[] m_AppList;//ユーザーのライブラリにあるアプリケーションリスト
    AppId_t yourchronicleAppId = new AppId_t(1546320);

    // Start is called before the first frame update
    void Start()
    {
        if (!SteamManager.Initialized)
        {
            main.Log("Failed to initialize steamworks",100);

            main.S.dlcStarter = false;
            main.S.dlcGlobal = false;
            main.S.dlcNitro = false;
            main.S.dlcGold = false;
            //デバッグ用
            //main.S.dlcIeh2 = true;

            return;
        }

        if (SteamApps.BIsAppInstalled(yourchronicleAppId))
            main.S.isInstalledYC = true;

        //if (SteamApps.GetEarliestPurchaseUnixTime(dlc_starter) < 1613746800)
        //    SteamApps.UninstallDLC(dlc_starter);
        //if (SteamApps.GetEarliestPurchaseUnixTime(dlc_global) < 1613746800)
        //{
        //    SteamApps.UninstallDLC(dlc_global);
        //    main.S.dlcGlobalGot = false;
        //}
        //if (SteamApps.GetEarliestPurchaseUnixTime(dlc_nitro) < 1613746800)
        //    SteamApps.UninstallDLC(dlc_nitro);
        //if (SteamApps.GetEarliestPurchaseUnixTime(dlc_goldcap) < 1613746800)
        //    SteamApps.UninstallDLC(dlc_goldcap);

        //main.Log("DLC STARTER" + SteamApps.GetEarliestPurchaseUnixTime(dlc_starter),500);
        //main.Log("DLC GLOBAL" + SteamApps.GetEarliestPurchaseUnixTime(dlc_global), 500);
        //main.Log("DLC NITRO" + SteamApps.GetEarliestPurchaseUnixTime(dlc_nitro), 500);
        //main.Log("DLC gold" + SteamApps.GetEarliestPurchaseUnixTime(dlc_goldcap), 500);

        main.S.dlcStarter = SteamApps.BIsDlcInstalled(dlc_starter);
        main.S.dlcGlobal = SteamApps.BIsDlcInstalled(dlc_global);
        main.S.dlcNitro = SteamApps.BIsDlcInstalled(dlc_nitro);
        main.S.dlcGold = SteamApps.BIsDlcInstalled(dlc_goldcap);
        main.GameController.isDlcIEH2 = SteamApps.BIsDlcInstalled(dlc_ieh2support);

        //Debug
        //main.GameController.isDlcIEH2 = true;

        if (main.S.dlcStarter)
            main.S.dlcStarterECGot = true;
        if (main.S.dlcGlobal)
            main.S.dlcGlobalECGot = true;
        if (main.S.dlcNitro)
            main.S.dlcNitroECGot = true;
        if (main.S.dlcGold)
            main.S.dlcGoldECGot = true;
        if (main.GameController.isDlcIEH2)
            main.S.dlcIeh2ECGot = true;

        //DLC GlobalSkillSlot
        if (main.S.dlcGlobal)
        {
            if (!main.S.dlcGlobalGotFixed)
            {
                main.skillSetController.UnleashGrobalSkillSlot();
                main.S.dlcGlobalGotFixed = true;
            }
        }

        CheckDLC();
    }

    async void CheckDLC()
    {
        while (true)
        {
            main.S.dlcStarter = SteamApps.BIsDlcInstalled(dlc_starter);
            main.S.dlcGlobal = SteamApps.BIsDlcInstalled(dlc_global);
            main.S.dlcNitro = SteamApps.BIsDlcInstalled(dlc_nitro);
            main.S.dlcGold = SteamApps.BIsDlcInstalled(dlc_goldcap);
            main.GameController.isDlcIEH2 = SteamApps.BIsDlcInstalled(dlc_ieh2support);
            await UniTask.Delay(3000);
        }
    }
#endif

}
