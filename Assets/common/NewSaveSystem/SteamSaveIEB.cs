using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using UniRx.Async;
using UnityEngine;

//クラウドセーブします
public class SteamSaveIEB : ISaveLocation<string>
{
    //Macは別にする必要あり？
    private const string FILENAME = "/SteamCloud.txt";
    public async UniTask<bool?> SetUserData(string save_str)
    {
        string s = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "AppData/LocalLow/DefaultCompany/IBB");

#if UNITY_STANDALONE_WIN
        s = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "AppData/LocalLow/DefaultCompany/IBB");
#endif
#if PLATFORM_STANDALONE_OSX
        s = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Library/Application Support/DefaultCompany/IBB");
#endif
        //ファイルをセーブする。
        using (StreamWriter sw = new StreamWriter(s + FILENAME))
      　{
      　    sw.WriteLine(save_str);
      　    sw.Close();
      　}
        await UniTask.DelayFrame(1);
        return null; //結果を受け取っていないため判定できない。ユーザーは見ればわかるはずだから問題ない
    }

    public async UniTask<string> GetUserData()
    {
        var fileContent = string.Empty;
        string s = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "AppData/LocalLow/DefaultCompany/IBB");
#if UNITY_STANDALONE_WIN
        s = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "AppData/LocalLow/DefaultCompany/IBB");
#endif
#if PLATFORM_STANDALONE_OSX
        s = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Library/Application Support/DefaultCompany/IBB");
#endif
        Debug.Log(s + FILENAME);
        var filePath = s + FILENAME;
        //サーバーから取ってくる処理になります。
        if (File.Exists(filePath))
        {
            //セーブデータを取得します
            fileContent = File.ReadAllText(filePath);
            //Debug.Log(filePath);
        }
        else
        {
            Debug.Log("Fileが存在しません。");
        }

        await UniTask.WaitWhile(() => fileContent == string.Empty);
        return fileContent;
    }

    public SteamSaveIEB(string gameTitle, string gameObjectName)
    {
        this.gameTitle = gameTitle;
        this.gameObjectName = gameObjectName;
    }
    string gameObjectName;
    string gameTitle;
}