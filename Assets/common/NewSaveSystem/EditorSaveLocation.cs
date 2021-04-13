using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UniRx.Async;
using UnityEngine;

public class EditorSaveLocation : ISaveLocation<string>
{
    public async UniTask<string> GetUserData()
    {
        if(saveFile_textAsset == null)
        {
            throw new Exception("セーブデータをアタッチしてください。");
        }
        await UniTask.DelayFrame(100);
        return saveFile_textAsset.text;
    }

    public async UniTask<bool?> SetUserData(string save_str)
    {
        FileInfo file = new FileInfo(Application.dataPath + "/SaveData/" + gameTitle + "_OnEditor.txt");
        file.Directory.Create();
        File.WriteAllText(file.FullName, save_str);
        BASE.main.Log("セーブしました。Assets/SavaData/にテキストデータが書き出されます。");
        await UniTask.DelayFrame(1);
        return true;
    }

    public EditorSaveLocation(string gameTitle, TextAsset saveFile_textAsset)
    {
        this.gameTitle = gameTitle;
        this.saveFile_textAsset = saveFile_textAsset;
    }
    string gameTitle;
    TextAsset saveFile_textAsset;
}
