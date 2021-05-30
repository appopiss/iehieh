using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static BASE;
using static UsefulMethod;


/// <summary>
/// NOTE:セーブの前にセーブの処理を止める必要がある
/// </summary>
public class SaveManager : MonoBehaviour
{
    string sceneName = "main";
    //UI
    [SerializeField] Button loadButton;
    [SerializeField] Button saveButton;
    [SerializeField] Button steam_loadButton;
    [SerializeField] Button steam_saveButton;
    [SerializeField] TextAsset editorSaveData;
    [SerializeField] Button ieb_loadButton;
    /*
    [SerializeField] Button playfabLoadButton;
    [SerializeField] Button playfabSaveButton;
    */

    //SaveData
    public List<ISaveElement> saveDataList = new List<ISaveElement>();

    //SaveExecutor
    ISaveExecutor local_executor;
    ISaveExecutor playfab_executor;

    private void Start()
    {
        
        //セーブデータの設定
        saveDataList.Add(new SaveElement<SaveR>(main.SR, (x) => LoadFunc(ref main.SR, x)));
        saveDataList.Add(new SaveElement<Save>(main.S, (x) => LoadFunc(ref main.S, x)));
        saveDataList.Add(new SaveElement<saveWiz>(main.saveWiz, (x) => LoadFunc(ref main.saveWiz, x)));
        saveDataList.Add(new SaveElement<saveWar>(main.saveWar, (x) => LoadFunc(ref main.saveWar, x)));
        saveDataList.Add(new SaveElement<saveAng>(main.saveAng, (x) => LoadFunc(ref main.saveAng, x)));
        saveDataList.Add(new SaveElement<saveRein>(main.ST, (x) => LoadFunc(ref main.ST, x)));
        saveDataList.Add(new SaveElement<SaveO>(main.SO, (x) => LoadFuncFromOdin(ref main.SO, x)) { IsOdinData = true }) ;

        // Local
        ISaveLocation<string> local_location = new LocalAndEditorLocation("IncrementalEpicHero", gameObject.name, editorSaveData);
        local_executor = new SaveExecutor(saveDataList, local_location, true)
            { LoadAction = AfterOverload, LoadFailureAction = LoadFailedAction };
        loadButton.onClick.AddListener(BeforeLoadAction);
        loadButton.onClick.AddListener(local_executor.Load);
        saveButton.onClick.AddListener(local_executor.Save);

        //STEAM
        ISaveLocation<string> cloud_location = new SteamSave("IncrementalEpicHero", gameObject.name);
        ISaveExecutor steam_executor = new SaveExecutor(saveDataList, cloud_location, true)
        { LoadAction = AfterOverload, LoadFailureAction = LoadFailedAction };
        steam_loadButton.onClick.AddListener(BeforeLoadAction);
        steam_loadButton.onClick.AddListener(steam_executor.Load);
        steam_saveButton.onClick.AddListener(steam_executor.Save);
        StartCoroutine(PersistCloudSave());

        //IEBLoad
        ISaveLocation<string> cloud_IEBlocation = new SteamSaveIEB("IncrementalEpicBreakers", gameObject.name);
        ISaveExecutor steam_IEBexecutor = new SaveExecutor(saveDataList, cloud_IEBlocation, true)
        { LoadAction = null, LoadFailureAction = null };
        ieb_loadButton.onClick.AddListener(steam_IEBexecutor.LoadTakeover);

        // PlayFab
        /*
        ISaveLocation<string> playfab_location = new PlayfabSaveLocation();
        playfab_executor = new SaveExecutor(saveDataList, playfab_location, false)
            { LoadAction = AfterOverload, SaveSuccessAction = SaveSuccessedInCloud, SaveFailureAction = SaveFailedInCloud,  LoadFailureAction = LoadFailedAction };
        playfabLoadButton.onClick.AddListener(BeforeLoadAction);
        playfabLoadButton.onClick.AddListener(playfab_executor.Load);
        playfabSaveButton.onClick.AddListener(playfab_executor.Save);
        playfabSaveButton.onClick.AddListener(() => StartCoroutine(DisableButtonInteractable(playfabSaveButton)));
        */

        //StartCoroutine(SaveCloudCoroutine());// SaveCoroutine
        //StartCoroutine(CoroutinePerSecond());// Called

    }


    IEnumerator PersistCloudSave()
    {
        if(main.platform != Platform.steam)
        {
            setFalse(steam_saveButton.gameObject);
            setFalse(steam_loadButton.gameObject);
            yield break;
        }
        WaitForSecondsRealtime wait = new WaitForSecondsRealtime(300f);
        while (true)
        {
            yield return wait;
            steam_saveButton.onClick.Invoke();
        }
    }



    IEnumerator SaveCloudCoroutine()
    {
        yield return new WaitUntil(() => TitleCtrl.isLoaded == true);
        yield return new WaitForSecondsRealtime(300f);//最初５分待つ
        while (true)
        {
            yield return new WaitForSecondsRealtime(3600f);//１分ごとに保存
            //playfab_executor.Save();
        }
    }

    /*
    IEnumerator CoroutinePerSecond()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(1.0f);
            playfabSaveButton.interactable = KongregateHandler.KongregateId.Length > 1;
            playfabLoadButton.interactable = KongregateHandler.KongregateId.Length > 1;
        }
    }
    */

    IEnumerator DisableButtonInteractable(Button button)
    {
        button.interactable = false;
        yield return new WaitForSecondsRealtime(10.0f);
        button.interactable = true;
    }

    void BeforeLoadAction()
    {
        Debug.Log("ロード中");
        main.Log("<color=green>Now Loading...</color>", 10f);

        foreach (var achievement in main.achievements)
        {
            if (achievement == null) { continue; }
            StopCoroutine(achievement.QuestCor);
            achievement.gameObject.SetActive(false);
        }

        StopAllCoroutines();
        Time.timeScale = 0;
        main.ArtiCtrl.UpdateMaterial = null;
        foreach (DUNGEON dungeon in main.dungeonAry)
        {
            if (dungeon.calculateSpendTimeCor != null)
            {
                dungeon.calculateSpendTimeCor = null;
            }

            if (dungeon.gameObject.HasComponent<MISSION>())
            {
                foreach (MISSION mission in dungeon.gameObject.GetComponentsInChildren<MISSION>())
                {
                    if (mission.updateJudge != null)
                    {
                        mission.updateJudge = null;
                    }
                }
            }
        }
    }


    void SaveSuccessedInLocal()
    {
        main.Log("<color=green>Local Save was successful!</color>",10f);
    }

    void SaveSuccessedInCloud()
    {
        main.Log("<color=green>Cloud Save was successful.\nYou can try again in 10 seconds</color>", 10f);
    }

    void SaveFailedInCloud()
    {
        main.Log("<color=red>Failed to Cloud Save.\nYou can try again in 10 seconds</color>", 10f);
    }

    void LoadFailedAction()
    {
        main.Log("<color=red>Failed to load</color>",10f);
        Time.timeScale = 1;
    }

    // オブジェクトに代入した後に呼ぶ関数
    void AfterOverload()
    {
        main.saveCtrl.setSaveKey(); //NOTE:saveCtrlに依存させないようにする
        SceneManager.LoadScene(sceneName);
    }


    void LoadFunc<T>(ref T obj, string save_data)
    {
        obj = JsonUtility.FromJson<T>(save_data);
    }
    void LoadFuncFromOdin(ref SaveO obj, string save_data)
    {
        obj = IdleLibrary.Save_Odin.Load<SaveO>(save_data);
    }
}
