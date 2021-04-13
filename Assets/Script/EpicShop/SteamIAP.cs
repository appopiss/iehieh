#if UNITY_ANDROID || UNITY_IOS || UNITY_TIZEN || UNITY_TVOS || UNITY_WEBGL || UNITY_WSA || UNITY_PS4 || UNITY_WII || UNITY_XBOXONE || UNITY_SWITCH
#define DISABLESTEAMWORKS
#endif

#if !DISABLESTEAMWORKS
using Steamworks;
#endif
using System.Net.Http;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;
using UniRx.Async;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static BASE;

public class SteamIAP : MonoBehaviour
{
    string itemId = "";
    string amount = "";
    string description = "";
    Action OnApproved = () => { };
    public void Initialize(string itemId, string amount, string description, Action OnApproved)
    {
        this.itemId = itemId;
        this.amount = amount;
        this.description = description;
        this.OnApproved = OnApproved;
        gameObject.GetComponent<Button>().onClick.AddListener(Buy);
    }
#if !DISABLESTEAMWORKS

    //ボタンを押すたびに呼ばれます。
    async void Buy()
    {
        KredsCtrl.isTxn = true;
        KredsCtrl.isPurchaseApprovedBySteam = 0;
        //SteamIdです
        CSteamID userId = SteamUser.GetSteamID();
        ulong id = userId.m_SteamID;
        //言語を取得します。
        string language = SteamApps.GetCurrentGameLanguage();
        var result = await KredsCtrl.httpClient.GetAsync(@"https://partner.steam-api.com/ISteamMicroTxn/GetUserInfo/v2/?key=" + KredsCtrl.SteamWebAPIKey
            + "&steamid=" + id).AsUniTask();
        string s = await result.Content.ReadAsStringAsync();
        JObject jObject = JObject.Parse(s);
        //通貨です。
        string currency = jObject["response"]["params"]["currency"].ToString();

        int orderId = UnityEngine.Random.Range(1, int.MaxValue);
        var parameters = new Dictionary<string, string>()
            {
            {"key", KredsCtrl.SteamWebAPIKey },
            {"orderid", orderId.ToString() },
            {"steamid", id.ToString() },
            {"appid", KredsCtrl.appId },
            {"itemcount", 1.ToString() },
            {"language", "en" },
            {"currency", "USD" },
            {"itemid[0]", itemId },
            {"qty[0]", 1.ToString() },
            {"amount[0]", amount },
            {"description[0]", description },
            };
        var content = new FormUrlEncodedContent(parameters);
        var result2 = await KredsCtrl.httpClient.PostAsync($"https://partner.steam-api.com/ISteamMicroTxn/InitTxn/v3/"
            , content);
        //もしresult2がFailureだった場x合はreturnします。
        /*
        string s2 = await result2.Content.ReadAsStringAsync();
        JObject jObject2 = JObject.Parse(s2);
        string isFailure = jObject["response"]["result"].ToString();
        if(isFailure == "Failure")
        {
            KredsCtrl.isTxn = false;
            Instantiate(main.P_texts[41]);
            return;
        }
        */
        //タイムアウトの処理を書きます。10秒待っても画面が出てこなければ...例外を返します。
        await UniTask.WaitUntil(() => KredsCtrl.isPurchaseApprovedBySteam != 0);
        if (KredsCtrl.isPurchaseApprovedBySteam == -1)
        {
            main.Log("Purchase denied");
            KredsCtrl.isTxn = false;
            return;
        }
        else if (KredsCtrl.isPurchaseApprovedBySteam == 1)
        {
            main.Log("Purchase approved");
            //ここに購入の処理を書きます。
            OnApproved();
        }
        KredsCtrl.isTxn = false;
    }
#else
    void Buy() { }
#endif

}

