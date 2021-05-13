using UnityEngine;

public static class saveClass
{
    /// <summary>
    /// 指定されたオブジェクトの情報を保存します
    /// </summary>
    public static void SetObject<T>(string key, T obj)
    {
        string json = "";
        if (key == keyList.odinSaveKey)
        {
            json = IdleLibrary.Save_Odin.GetJsonFromOdinSave(obj);
        }
        else
        {
            json = JsonUtility.ToJson(obj);
        }
        PlayerPrefs.SetString(key, json);
    }
     
    /// <summary>
    /// 指定されたオブジェクトの情報を読み込みます
    /// </summary>
    public static T GetObject<T>(string key)
    {
        T obj;
        var json = PlayerPrefs.GetString(key);
        if (key == keyList.odinSaveKey)
        {
            obj = IdleLibrary.Save_Odin.Load<T>(json);
        }
        else
        {
            obj = JsonUtility.FromJson<T>(json);
        }

        return obj;
    }
}