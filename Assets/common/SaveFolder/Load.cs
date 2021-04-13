using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

public class Load : BASE, IPointerDownHandler
{
    public Button saveButton;
    public Button saveButtonOnCrazygame;
    string saveTitle, saveContent;
    string gameTitle = "IncrementalEpicHero";
    string sceneName = "main";
    bool isOver;
    public static bool isLoaded;
    AES aes = new AES();
    public static bool isLoading;

    string[] saveStrArray = new string[6];
    string[] jsonArray = new string[6];

    private void Awake()
    {
        StartBASE();
        InstantiateWindow();//ローカルセーブボーナス
    }

    void Start()
    {
        saveButton.onClick.AddListener(() => StartCoroutine(saveText()));
        saveButtonOnCrazygame.onClick.AddListener(() => StartCoroutine(saveText()));

#if UNITY_EDITOR
#elif UNITY_WEBGL
        


        Application.ExternalEval(
            @"
document.addEventListener('click', function() {

    var fileuploader = document.getElementById('fileuploader');
    if (!fileuploader) {
        fileuploader = document.createElement('input');
        fileuploader.setAttribute('style','display:none;');
        fileuploader.setAttribute('type', 'file');
        fileuploader.setAttribute('id', 'fileuploader');
//        fileuploader.setAttribute('class', 'focused');
        document.getElementsByTagName('body')[0].appendChild(fileuploader);

        fileuploader.onchange = function(e) {
        var files = e.target.files;
            for (var i = 0, f; f = files[i]; i++) {
                //window.alert(URL.createObjectURL(f));

				//var reader = new FileReader();
				//reader.readAsText(f);

                SendMessage('" + gameObject.name + @"', 'FileDialogResult', URL.createObjectURL(f));
            }
        };
    }else{
	    if (fileuploader.getAttribute('class') == 'focused') {
	        fileuploader.setAttribute('class', '');
	        fileuploader.click();

	    }
	}
});
            ");
#endif
    }
    private void Update()
    {
        if (window.activeSelf)
        {
            if (leftTimeForSaveBonus() < 1)
                window.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "- <color=green>You can gain <sprite=\"EpicCoinSprite\" index=0> 30 now!";
            else
                window.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "- You can gain <sprite=\"EpicCoinSprite\" index=0> 30 in " + UsefulMethod.DoubleTimeToDate(leftTimeForSaveBonus());
            window.transform.GetChild(2).GetComponent<Slider>().value = 1f - (float)(leftTimeForSaveBonus() / (3 * 60 * 60d));
            //if (window != null)
            //{
            //    if (Input.mousePosition.y >= 300 && Input.mousePosition.x >= 400)
            //    {
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(-250.0f, -50.0f);
            //    }
            //    else if (Input.mousePosition.y >= 300 && Input.mousePosition.x < 400)
            //    {
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(50.0f, -50.0f);
            //    }
            //    else if (Input.mousePosition.y < 300 && Input.mousePosition.x > 400)
            //    {
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(-250.0f, 50.0f);
            //    }
            //    else if (Input.mousePosition.y < 300 && Input.mousePosition.x < 400)
            //    {
            //        window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition - new Vector3(400, 300) + new Vector3(30.0f, 30.0f);
            //    }
            //}

        }
    }
    public static double leftTimeForSaveBonus()
    {
        return Math.Max(3 * 60 * 60 - (main.S.realAllTime - main.S.lastLocalSaveTime), 0);
    }
    public GameObject window;
    public void InstantiateWindow()
    {
        window = Instantiate(main.P_texts[37], main.WindowShowCanvas);
        saveButton.gameObject.AddComponent<EventTrigger>().triggers = new List<EventTrigger.Entry>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry2.eventID = EventTriggerType.PointerExit;
        entry.callback.AddListener((x) => UsefulMethod.setActive(window));
        entry2.callback.AddListener((x) => UsefulMethod.setFalse(window)); //ラムダ式の右側は追加するメソッドです。
        saveButton.gameObject.GetComponent<EventTrigger>().triggers.Add(entry);
        saveButton.gameObject.GetComponent<EventTrigger>().triggers.Add(entry2);
    }


    //Incentivized Ads 初回Bonusから呼ぶ
    public IEnumerator saveText()
    {
        //ローカルセーブボーナス！
        if (leftTimeForSaveBonus() < 1)
        {
            main.S.lastLocalSaveTime = main.S.realAllTime;
            main.S.ECbyLocalSave++;//1ずつ増やす！
        }
        main.saveCtrl.setSaveKey();
        yield return new WaitForSeconds(0.3f);

        saveTitle = gameTitle + "_" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

        saveStrArray[0] = PlayerPrefs.GetString(keyList.resetSaveKey);
        saveStrArray[1] = PlayerPrefs.GetString(keyList.permanentSaveKey);
        saveStrArray[2] = PlayerPrefs.GetString(keyList.Wiz_saveKey);
        saveStrArray[3] = PlayerPrefs.GetString(keyList.War_saveKey);
        saveStrArray[4] = PlayerPrefs.GetString(keyList.Ang_saveKey);
        saveStrArray[5] = PlayerPrefs.GetString(keyList.reincarnationSaveKey);
        //暗号化
        for (int i = 0; i < saveStrArray.Length; i++)
        {
            jsonArray[i] = null;
            jsonArray[i] = Convert.ToBase64String(aes.encrypt(System.Text.Encoding.UTF8.GetBytes(saveStrArray[i])));
            yield return jsonArray[i];
        }
        //結合
        saveContent = null;
        saveContent = string.Join("#", jsonArray);
        yield return saveContent;

#if UNITY_EDITOR
        //EditorのAssets/SaveData/にセーブ
        FileInfo file = new FileInfo(Application.dataPath + "/SaveData/" + gameTitle + "_OnEditor.txt");
        file.Directory.Create();
        File.WriteAllText(file.FullName, saveContent);

#elif UNITY_WEBGL
        Application.ExternalEval(
                    @"
		const a = document.createElement('a');
		a.href = URL.createObjectURL(new Blob(['"+ saveContent + @"'], {type: 'text/plain'}));
		a.download = '" + saveTitle + @"';

		a.style.display = 'none';
		document.body.appendChild(a);
		a.click();
		document.body.removeChild(a);
		");
#endif
    }

    public void OnPointerDown(PointerEventData eventData)
    {
#if UNITY_EDITOR
        LoadOnEditor();
#elif UNITY_WEBGL
        Application.ExternalEval(
            @"
var fileuploader = document.getElementById('fileuploader');
if (!fileuploader) {
        fileuploader = document.createElement('input');
        fileuploader.setAttribute('style','display:none;');
        fileuploader.setAttribute('type', 'file');
        fileuploader.setAttribute('id', 'fileuploader');
		fileuploader.setAttribute('class', 'focused');
        document.getElementsByTagName('body')[0].appendChild(fileuploader);

        fileuploader.onchange = function(e) {
        var files = e.target.files;
            for (var i = 0, f; f = files[i]; i++) {
                //window.alert(URL.createObjectURL(f));

				//var reader = new FileReader();
				//reader.readAsText(f);

                SendMessage('" + gameObject.name + @"', 'FileDialogResult', URL.createObjectURL(f));
            }
        };
    }
if (fileuploader) {
    fileuploader.setAttribute('class', 'focused');
}
            ");
#endif
    }

    WWW www;

    public void FileDialogResult(string fileUrl)
    {
        // isLoading = true;
        // preventError();
        // //StartCoroutine(ReadTxt(fileUrl));
        // ReadTxt(fileUrl);
        StartCoroutine(preDownLoad(fileUrl));
    }

    IEnumerator preDownLoad(string url)
    {
        isLoaded = true;
        www = new WWW(url);
        yield return www;
        preventError();
        ReadTxt(url);
    }

    void ReadTxt(string url)
    {
        //var www = new WWW(url);
        //yield return www;
        jsonArray = www.text.Split('#');
        //復号化

        for (int i = 0; i < jsonArray.Length; i++)
        {
            saveStrArray[i] = null;
            saveStrArray[i] = System.Text.Encoding.UTF8.GetString(aes.dencrypt(Convert.FromBase64String(jsonArray[i])));
            //yield return saveStrArray[i];
        }
        SaveR SRdata = JsonUtility.FromJson<SaveR>(saveStrArray[0]);
        Save Sdata = JsonUtility.FromJson<Save>(saveStrArray[1]);
        saveWiz WizData = JsonUtility.FromJson<saveWiz>(saveStrArray[2]);
        saveWar WarData = JsonUtility.FromJson<saveWar>(saveStrArray[3]);
        saveAng AngData = JsonUtility.FromJson<saveAng>(saveStrArray[4]);
        saveRein STdata = JsonUtility.FromJson<saveRein>(saveStrArray[5]);

        // yield return SRdata;
        // yield return Sdata;
        // yield return WizData;
        // yield return WarData;
        // yield return AngData;
        if (!Sdata.isNewReleasedIEH)
        {
            main.Log("Sorry, this save is incompatible with this version of Incremental Epic Heroes" );
            return;
        }
        main.SR = SRdata;
        main.S = Sdata; 
        main.saveWiz = WizData;
        main.saveWar = WarData;
        main.saveAng = AngData;
        main.ST = STdata;
        main.saveCtrl.setSaveKey();
        //yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(sceneName);
    }

    public TextAsset saveFile_Debug;
    [ContextMenu("Editorからロード")]
    void LoadOnEditor()
    {
        if(saveFile_Debug == null)
        {
            return;
        }
        preventError();
        //StartCoroutine(LoadOnEditorCor(saveFile_Debug.text));
        LoadOnEditorCor(saveFile_Debug.text);
    }

    void preventError()
    {
        //isLoading = true;
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

    void LoadOnEditorCor(string data)
    {
       // yield return new WaitForSeconds(0.1f);
       // yield return data;
        jsonArray = data.Split('#');
        //復号化
        for (int i = 0; i < jsonArray.Length; i++)
        {
            saveStrArray[i] = null;
            saveStrArray[i] = System.Text.Encoding.UTF8.GetString(aes.dencrypt(Convert.FromBase64String(jsonArray[i])));
           // yield return saveStrArray[i];
        }
        SaveR SRdata = JsonUtility.FromJson<SaveR>(saveStrArray[0]);
        Save Sdata = JsonUtility.FromJson<Save>(saveStrArray[1]);
        saveWiz WizData = JsonUtility.FromJson<saveWiz>(saveStrArray[2]);
        saveWar WarData = JsonUtility.FromJson<saveWar>(saveStrArray[3]);
        saveAng AngData = JsonUtility.FromJson<saveAng>(saveStrArray[4]);
        saveRein STdata = JsonUtility.FromJson<saveRein>(saveStrArray[5]);
        //  yield return SRdata;
        //  yield return Sdata;
        //  yield return WizData;
        //  yield return WarData;
        //  yield return AngData;
        /*
        if (!Sdata.isNewReleasedIEH)
        {
            main.Log("Sorry, this save is incompatible with this version of Incremental Epic Heroes");
            return;
        }
        */
        main.SR = SRdata;
        main.S = Sdata;
        main.saveWiz = WizData;
        main.saveWar = WarData;
        main.saveAng = AngData;
        main.ST = STdata;
        main.saveCtrl.setSaveKey();
        //yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("main");
    }
}
