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
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;




/// <summary>
/// API_Identifierは大文字不可。アンダーバーは可。
/// 使える回数はInfinityにすると使えない。1回と設定しよう。
/// </summary>
public class KredsCtrl : BASE {
    public Button EC1button, EC2button, EC3button, EC4button, EC5button, EC6button, EC7button, EC8button;
    public Button ECF1button, ECF2button, ECF3button, ECF4button,ECF5button,ECF6button, ECS1button, ECS2button, ECS3button, ECS4button;
    GameObject purchased1, purchased2, purchased3, purchased4, purchased5, purchased6, purchased7, purchased8,purchased9,purchased10;
    public Button GoNormalPurchaseButton;

#if !DISABLESTEAMWORKS
    public static readonly string SteamWebAPIKey = "F6724F6EF14E3AE95B7B7F14E53BEEC3";
    public static readonly string appId = "1530340";
    //Steamの承認コールバックです。
    private Callback<MicroTxnAuthorizationResponse_t> responseCallback;
    async void OnUserRespondedToTxn(MicroTxnAuthorizationResponse_t txn_callback)
    {
        if(txn_callback.m_bAuthorized == 1)
        {
            //ゲーム画面に戻るまで待ちます。
            var parameters_purshaceComplete = new Dictionary<string, string>()
             {
            {"key", SteamWebAPIKey },
            {"orderid", txn_callback.m_ulOrderID.ToString() },
            {"appid", appId },
              };
            var result_purchaseComplete = await httpClient.PostAsync($"https://partner.steam-api.com/ISteamMicroTxn/FinalizeTxn/v2/"
                , new FormUrlEncodedContent(parameters_purshaceComplete));
            //result = OKであれば購入が完了したので、アイテムを付与します。
            string str_purshaceComplete = await result_purchaseComplete.Content.ReadAsStringAsync();
            JObject jObject_purchaseComplete = JObject.Parse(str_purshaceComplete);
            string isPurchaseCompletedStr = jObject_purchaseComplete["response"]["result"].ToString();
            main.Log(isPurchaseCompletedStr);
            if (isPurchaseCompletedStr == "OK")
            {
                main.Log("Purchase completed. you are going to get item!");
                isPurchaseApprovedBySteam = 1;
            }
            else
            {
                main.Log("Purchase Failed.");
                isPurchaseApprovedBySteam = -1;
            }
        }
        else
        {
            main.Log("Purchase Denied!");
            isPurchaseApprovedBySteam = -1;
        }
    }
    //オーバーレイからゲームに戻ったときのコールバックです。
    private Callback<GameOverlayActivated_t> overlayCallback;
    void OnOverlayAction(GameOverlayActivated_t overlay_callback)
    {
        isOverlay = overlay_callback.m_bActive == 1 ? true : false;
    }
    static bool isOverlay;
    public static bool isTxn;
    //1 ... 許可されました。 2... 拒否されました。
    public static int isPurchaseApprovedBySteam = 0;
#endif
    public GameObject ClickBlockPanel;


    // Use this for initialization
    void Awake() {
		StartBASE();
        httpClient = new HttpClient();
        setFalse(ClickBlockPanel);

#if !DISABLESTEAMWORKS
        responseCallback = Callback<MicroTxnAuthorizationResponse_t>.Create(OnUserRespondedToTxn);
#endif

        purchased1 = ECF1button.transform.parent.GetChild(4).gameObject;
        purchased2 = ECF2button.transform.parent.GetChild(4).gameObject;
        purchased3 = ECF3button.transform.parent.GetChild(4).gameObject;
        purchased4 = ECF4button.transform.parent.GetChild(4).gameObject;
        purchased5 = ECS1button.transform.parent.GetChild(4).gameObject;
        //purchased6 = ECS2button.transform.parent.GetChild(4).gameObject;
        //purchased7 = ECS3button.transform.parent.GetChild(4).gameObject;
        purchased8 = ECS4button.transform.parent.GetChild(4).gameObject;

        purchased9 = ECF5button.transform.parent.GetChild(4).gameObject;
        purchased10 = ECF6button.transform.parent.GetChild(4).gameObject;

        //Bonus追加前に既に購入してくれた人用
        if (main.S.ECF1 < 1 && main.S.EC1 >= 1)
        {
            main.S.ECF1 += 1;
            main.S.EC1 -= 1;
        }
        if (main.S.ECF2 < 1 && main.S.EC2 >= 1)
        {
            main.S.ECF2 += 1;
            main.S.EC2 -= 1;
        }
        if (main.S.ECF3 < 1 && main.S.EC3 >= 1)
        {
            main.S.ECF3 += 1;
            main.S.EC3 -= 1;
        }
        if (main.S.ECF4 < 1 && main.S.EC4 >= 1)
        {
            main.S.ECF4 += 1;
            main.S.EC4 -= 1;
        }
        if (main.S.ECF5 < 1 && main.S.EC5 >= 1)
        {
            main.S.ECF5 += 1;
            main.S.EC5 -= 1;
        }
        if (main.S.ECF6 < 1 && main.S.EC6 >= 1)
        {
            main.S.ECF6 += 1;
            main.S.EC6 -= 1;
        }

    }
        
	// Use this for initialization
	void Start() {
        //各プラットフォームごと
        switch (main.platform)
        {
            case Platform.armor:
                //if Armor Games
                EC1button.onClick.AddListener(() => AGIUnity.ShowStore("ieh-500_epic_coin"));
                EC2button.onClick.AddListener(() => AGIUnity.ShowStore("ieh-1050_epic_coin"));
                EC3button.onClick.AddListener(() => AGIUnity.ShowStore("ieh-2650_epic_coin"));
                EC4button.onClick.AddListener(() => AGIUnity.ShowStore("ieh-5500_epic_coin"));
                EC5button.onClick.AddListener(() => AGIUnity.ShowStore("ieh-12000_epic_coin"));
                EC6button.onClick.AddListener(() => AGIUnity.ShowStore("ieh-18500_epic_coin"));
                EC7button.onClick.AddListener(() => AGIUnity.ShowStore("ieh-31000_epic_coin"));
                EC8button.onClick.AddListener(() => AGIUnity.ShowStore("ieh-70000_epic_coin"));
                EC1button.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "1.00$";
                EC2button.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "2.00$";
                EC3button.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "5.00$";
                EC4button.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "10.00$";
                EC5button.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "20.00$";
                EC6button.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "30.00$";
                EC7button.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "50.00$";
                EC8button.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "100.00$";

                ECF1button.onClick.AddListener(() => AGIUnity.ShowStore("ieh-500_epic_coin_x2"));
                ECF2button.onClick.AddListener(() => AGIUnity.ShowStore("ieh-1050_epic_coin_x2"));
                ECF3button.onClick.AddListener(() => AGIUnity.ShowStore("ieh-2650_epic_coin_x2"));
                ECF4button.onClick.AddListener(() => AGIUnity.ShowStore("ieh-5500_epic_coin_x2"));
                ECF5button.onClick.AddListener(() => AGIUnity.ShowStore("ieh-12000_epic_coin_x2"));
                ECF6button.onClick.AddListener(() => AGIUnity.ShowStore("ieh-18500_epic_coin_x2"));
                ECF1button.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "1.00$";
                ECF2button.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "2.00$";
                ECF3button.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "5.00$";
                ECF4button.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "10.00$";
                ECF5button.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "20.00$";
                ECF6button.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "30.00$";

                ECS1button.onClick.AddListener(() => AGIUnity.ShowStore("ieh-starter_bundle"));
                ECS4button.onClick.AddListener(() => AGIUnity.ShowStore("ieh-global_skill_slot_bundle"));
                ECS1button.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "1.00$";
                ECS4button.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "10.00$";
                GoNormalPurchaseButton.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Purchase Epic Coin";
                break;
            case Platform.kong:
                EC1button.gameObject.AddComponent<KredsTemplate>().Initialize(
                 "ec1",
                 () => main.Log("(Purchase completed.)"),
                 null,
                () => { main.S.EC1 += 1; },
                null);
                EC2button.gameObject.AddComponent<KredsTemplate>().Initialize(
                    "ec2",
                    () => main.Log("(Purchase completed.)"),
                    null,
                    () => { main.S.EC2 += 1; },
                    null);
                EC3button.gameObject.AddComponent<KredsTemplate>().Initialize(
                    "ec3",
                    () => main.Log("(Purchase completed.)"),
                    null,
                    () => { main.S.EC3 += 1; },
                    null);
                EC4button.gameObject.AddComponent<KredsTemplate>().Initialize(
                    "ec4",
                    () => main.Log("(Purchase completed.)"),
                    null,
                    () => { main.S.EC4 += 1; },
                    null);
                EC5button.gameObject.AddComponent<KredsTemplate>().Initialize(
                    "ec5",
                    () => main.Log("(Purchase completed.)"),
                    null,
                    () => { main.S.EC5 += 1; },
                    null);
                EC6button.gameObject.AddComponent<KredsTemplate>().Initialize(
                    "ec6",
                    () => main.Log("(Purchase completed.)"),
                    null,
                    () => { main.S.EC6 += 1; },
                    null);
                EC7button.gameObject.AddComponent<KredsTemplate>().Initialize(
                    "ec7",
                    () => main.Log("(Purchase completed.)"),
                    null,
                    () => { main.S.EC7 += 1; },
                    null);
                EC8button.gameObject.AddComponent<KredsTemplate>().Initialize(
                    "ec8",
                    () => main.Log("(Purchase completed.)"),
                    null,
                    () => { main.S.EC8 += 1; },
                    null);



                ECF1button.gameObject.AddComponent<KredsTemplate>().Initialize(
            "ecf1",
            () => main.Log("(Purchase completed.)"),
            null,
            () => { main.S.ECF1 += 1; },
            null);
                ECF2button.gameObject.AddComponent<KredsTemplate>().Initialize(
                    "ecf2",
                    () => main.Log("(Purchase completed.)"),
                    null,
                    () => { main.S.ECF2 += 1; },
                    null);
                ECF3button.gameObject.AddComponent<KredsTemplate>().Initialize(
                    "ecf3",
                    () => main.Log("(Purchase completed.)"),
                    null,
                    () => { main.S.ECF3 += 1; },
                    null);
                ECF4button.gameObject.AddComponent<KredsTemplate>().Initialize(
                    "ecf4",
                    () => main.Log("(Purchase completed.)"),
                    null,
                    () => { main.S.ECF4 += 1; },
                    null);
                ECF5button.gameObject.AddComponent<KredsTemplate>().Initialize(
                    "ecf5",
                    () => main.Log("(Purchase completed.)"),
                    null,
                    () => { main.S.ECF5 += 1; },
                    null);
                ECF6button.gameObject.AddComponent<KredsTemplate>().Initialize(
                    "ecf6",
                    () => main.Log("(Purchase completed.)"),
                    null,
                    () => { main.S.ECF6 += 1; },
                    null);


                ECS1button.gameObject.AddComponent<KredsTemplate>().Initialize(
            "ecs1",
            () => main.Log("(Purchase completed.)"),
            null,
            () => {
                main.S.ECS1 += 1;
                main.S.GoldCapByKreds += 500;
                main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.MonsterFluid] += 500;
                main.Log("Gained <color=green>Monster Fluid * 500", 5f);
                main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.RedChili] += 10;
                main.Log("Gained <color=green>Red Chili * 10", 5f);
            },
            null);
                ECS4button.gameObject.AddComponent<KredsTemplate>().Initialize(
                    "ecs4",
                    () => main.Log("(Purchase completed.)"),
                    null,
                    () => {
                        main.S.ECS4 += 1;
                        main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.MonsterFluid] += 5000;
                        main.Log("Gained <color=green>Monster Fluid * 5000", 5f);
                        main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.RedChili] += 50;
                        main.Log("Gained <color=green>Red Chili * 50", 5f);
                        main.skillSetController.UnleashGrobalSkillSlot();
                        StartCoroutine(main.InstantiateLogText("Extra Global Skill Slot is Unleashed!", main.TutorialController.iconSpriteAry[3]));
                    },
                    null);
                break;
            case Platform.steam:
                EC1button.gameObject.AddComponent<SteamIAP>().Initialize(
                    "100",
                    "100",
                    "500 Epic Coin",
                    ()=> main.S.EC1 += 1
                    );
                EC2button.gameObject.AddComponent<SteamIAP>().Initialize(
                    "101",
                    "200",
                    "1050 Epic Coin",
                    () => main.S.EC2 += 1
                    );
                EC3button.gameObject.AddComponent<SteamIAP>().Initialize(
                    "102",
                    "500",
                    "2650 Epic Coin",
                    () => main.S.EC3 += 1
                    );
                EC4button.gameObject.AddComponent<SteamIAP>().Initialize(
                    "103",
                    "1000",
                    "5500 Epic Coin",
                    () => main.S.EC4 += 1
                    );
                EC5button.gameObject.AddComponent<SteamIAP>().Initialize(
                    "104",
                    "2000",
                    "12000 Epic Coin",
                    () => main.S.EC5 += 1
                    );
                EC6button.gameObject.AddComponent<SteamIAP>().Initialize(
                    "105",
                    "3000",
                    "18500 Epic Coin",
                    () => main.S.EC6 += 1
                    );
                EC7button.gameObject.AddComponent<SteamIAP>().Initialize(
                    "106",
                    "5000",
                    "31000 Epic Coin",
                    () => main.S.EC7 += 1
                    );
                EC8button.gameObject.AddComponent<SteamIAP>().Initialize(
                    "107",
                    "10000",
                    "70000 Epic Coin",
                    () => main.S.EC8 += 1
                    );

                ECF1button.gameObject.AddComponent<SteamIAP>().Initialize(
                    "108",
                    "100",
                    "500 Epic Coin x 2",
                    () => main.S.ECF1 += 1
                    );
                ECF2button.gameObject.AddComponent<SteamIAP>().Initialize(
                    "109",
                    "200",
                    "1050 Epic Coin x2",
                    () => main.S.ECF2 += 1
                    );
                ECF3button.gameObject.AddComponent<SteamIAP>().Initialize(
                    "110",
                    "500",
                    "2650 Epic Coin x2",
                    () => main.S.ECF3 += 1
                    );
                ECF4button.gameObject.AddComponent<SteamIAP>().Initialize(
                    "111",
                    "1000",
                    "5500 Epic Coin x2",
                    () => main.S.ECF4 += 1
                    );
                ECF5button.gameObject.AddComponent<SteamIAP>().Initialize(
                    "112",
                    "2000",
                    "12000 Epic Coin x2",
                    () => main.S.ECF5 += 1
                    );
                ECF6button.gameObject.AddComponent<SteamIAP>().Initialize(
                    "113",
                    "3000",
                    "18500 Epic Coin x2",
                    () => main.S.ECF6 += 1
                    );

                ECS1button.gameObject.AddComponent<SteamIAP>().Initialize(
                    "114",
                    "100",
                    "Starter Bundle",
                    () =>
                    {
                        main.S.ECS1 += 1;
                        main.S.GoldCapByKreds += 500;
                        main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.MonsterFluid] += 500;
                        main.Log("Gained <color=green>Monster Fluid * 500", 5f);
                        main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.RedChili] += 10;
                        main.Log("Gained <color=green>Red Chili * 10", 5f);
                    }
                    );
                ECS4button.gameObject.AddComponent<SteamIAP>().Initialize(
                    "115",
                    "1000",
                    "Global Skill Slot Bundle",
                    () =>
                    {
                        main.S.ECS4 += 1;
                        main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.MonsterFluid] += 5000;
                        main.Log("Gained <color=green>Monster Fluid * 5000", 5f);
                        main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.RedChili] += 50;
                        main.Log("Gained <color=green>Red Chili * 50", 5f);
                        main.skillSetController.UnleashGrobalSkillSlot();
                        StartCoroutine(main.InstantiateLogText("Extra Global Skill Slot is Unleashed!", main.TutorialController.iconSpriteAry[3]));
                    }
                    );
                EC1button.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "1.00$";
                EC2button.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "2.00$";
                EC3button.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "5.00$";
                EC4button.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "10.00$";
                EC5button.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "20.00$";
                EC6button.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "30.00$";
                EC7button.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "50.00$";
                EC8button.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "100.00$";

                ECF1button.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "1.00$";
                ECF2button.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "2.00$";
                ECF3button.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "5.00$";
                ECF4button.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "10.00$";
                ECF5button.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "20.00$";
                ECF6button.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "30.00$";

                ECS1button.onClick.AddListener(() => AGIUnity.ShowStore("ieh-starter_bundle"));
                ECS4button.onClick.AddListener(() => AGIUnity.ShowStore("ieh-global_skill_slot_bundle"));
                ECS1button.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "1.00$";
                ECS4button.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "10.00$";
                GoNormalPurchaseButton.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Purchase Epic Coin";
                break;
        }
    }

    public static HttpClient httpClient;
    /*
    public class SteamIAP : MonoBehaviour
    {
        string itemId = "";
        string amount = "";
        string description = "";
        Action OnApproved = () => { };
        public void Initialize(string itemId, string amount, string description,Action OnApproved)
        {
            this.itemId = itemId;
            this.amount = amount;
            this.description = description;
            this.OnApproved = OnApproved;
            gameObject.GetComponent<Button>().onClick.AddListener(Buy);
        }
        //ボタンを押すたびに呼ばれます。
        async void Buy()
        {
            isPurchaseApprovedBySteam = 0;
            //SteamIdです
            CSteamID userId = SteamUser.GetSteamID();
            ulong id = userId.m_SteamID;
            //言語を取得します。
            string language = SteamApps.GetCurrentGameLanguage();
            var result = await httpClient.GetAsync(@"https://partner.steam-api.com/ISteamMicroTxnSandbox/GetUserInfo/v2/?key=" + KredsCtrl.SteamWebAPIKey
                + "&steamid=" + id);
            string s = await result.Content.ReadAsStringAsync();
            JObject jObject = JObject.Parse(s);
            //通貨です。
            string currency = jObject["response"]["params"]["currency"].ToString();
            Debug.Log(currency);
            //米国の場合、州を取得します。
            //Debug.Log(jObject["response"]["params"]["state"]);
            //それ以外の場合国を取得します。
            //Debug.Log(jObject["response"]["params"]["country"]);
            //注文固有のidを生成します。
            int orderId = UnityEngine.Random.Range(1, int.MaxValue);
            var parameters = new Dictionary<string, string>()
            {
            {"key", SteamWebAPIKey },
            {"orderid", orderId.ToString() },
            {"steamid", id.ToString() },
            {"appid", appId },
            {"itemcount", 1.ToString() },
            {"language", "en" },
            {"currency", "USD" },
            {"itemid[0]", itemId },
            {"qty[0]", 1.ToString() },
            {"amount[0]", amount },
            {"description[0]", description },
            };
            var content = new FormUrlEncodedContent(parameters);
            var result2 = await httpClient.PostAsync($"https://partner.steam-api.com/ISteamMicroTxnSandbox/InitTxn/v3/"
                , content);
            await UniTask.WaitUntil(() => isPurchaseApprovedBySteam != 0);
            if (isPurchaseApprovedBySteam == -1)
            {
                main.Log("Purchase denied");
                return;
            }
            else if (isPurchaseApprovedBySteam == 1)
            {
                main.Log("Purchase approved");
                //ここに購入の処理を書きます。
                OnApproved();
            }
        }
    }
    */

    // Update is called once per frame
    void Update () {
#if !DISABLESTEAMWORKS
        if (isTxn)
            setActive(ClickBlockPanel);
        else
            setFalse(ClickBlockPanel);
#endif

        if (main.S.ECF1 >= 1)
        {
            setFalse(ECF1button.gameObject);
            setActive(purchased1);
        }
        else
        {
            setActive(ECF1button.gameObject);
            setFalse(purchased1);
        }
        if (main.S.ECF2 >= 1)
        {
            setFalse(ECF2button.gameObject);
            setActive(purchased2);
        }
        else
        {
            setActive(ECF2button.gameObject);
            setFalse(purchased2);
        }
        if (main.S.ECF3 >= 1)
        {
            setFalse(ECF3button.gameObject);
            setActive(purchased3);
        }
        else
        {
            setActive(ECF3button.gameObject);
            setFalse(purchased3);
        }
        if (main.S.ECF4 >= 1)
        {
            setFalse(ECF4button.gameObject);
            setActive(purchased4);
        }
        else
        {
            setActive(ECF4button.gameObject);
            setFalse(purchased4);
        }
        if (main.S.ECF5 >= 1)
        {
            setFalse(ECF5button.gameObject);
            setActive(purchased9);
        }
        else
        {
            setActive(ECF5button.gameObject);
            setFalse(purchased9);
        }
        if (main.S.ECF6 >= 1)
        {
            setFalse(ECF6button.gameObject);
            setActive(purchased10);
        }
        else
        {
            setActive(ECF6button.gameObject);
            setFalse(purchased10);
        }


        if (main.S.ECS1 >= 1)
        {
            setFalse(ECS1button.gameObject);
            setActive(purchased5);
        }
        else
        {
            setActive(ECS1button.gameObject);
            setFalse(purchased5);
        }
        //if (main.S.ECS2 >= 1)
        //{
        //    setFalse(ECS2button.gameObject);
        //    setActive(purchased6);
        //}
        //else
        //{
        //    setActive(ECS2button.gameObject);
        //    setFalse(purchased6);
        //}
        //if (main.S.ECS3 >= 1)
        //{
        //    setFalse(ECS3button.gameObject);
        //    setActive(purchased7);
        //}
        //else
        //{
        //    setActive(ECS3button.gameObject);
        //    setFalse(purchased7);
        //}
        if (main.S.ECS4 >= 1)
        {
            setFalse(ECS4button.gameObject);
            setActive(purchased8);
        }
        else
        {
            setActive(ECS4button.gameObject);
            setFalse(purchased8);
        }
    }
}
