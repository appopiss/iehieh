using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//[DefaultExecutionOrder(-2)]
public class saveCtrl : BASE
{
    public Coroutine save;
    //ロードの処理
    void getSaveKey()
    {
        //SaveR
        //データが無かったとしたら
        if (saveClass.GetObject<SaveR>(keyList.resetSaveKey) == null)
        {
            main.SR = new SaveR();
        }
        else
        {
            main.SR = saveClass.GetObject<SaveR>(keyList.resetSaveKey);
        }

        //Save
        if (saveClass.GetObject<Save>(keyList.permanentSaveKey) == null)
        {
            main.S = new Save();
        }
        else
        {
            main.S=saveClass.GetObject<Save>(keyList.permanentSaveKey);
        }


        //SaveWar
        if (saveClass.GetObject<saveWar>(keyList.War_saveKey) == null)
        {
            main.saveWar = new saveWar();
        }
        else
        {
            main.saveWar = saveClass.GetObject<saveWar>(keyList.War_saveKey);
        }


        //SaveWiz
        if (saveClass.GetObject<saveWiz>(keyList.Wiz_saveKey) == null)
        {
            main.saveWiz = new saveWiz();
        }
        else
        {
            main.saveWiz = saveClass.GetObject<saveWiz>(keyList.Wiz_saveKey);
        }


        //saveAng
        if (saveClass.GetObject<saveAng>(keyList.Ang_saveKey) == null)
        {
            main.saveAng = new saveAng();
        }
        else
        {
            main.saveAng = saveClass.GetObject<saveAng>(keyList.Ang_saveKey);
        }
        //saveRein
        if (saveClass.GetObject<saveRein>(keyList.reincarnationSaveKey) == null)
        {
            main.ST = new saveRein();
        }
        else
        {
            main.ST = saveClass.GetObject<saveRein>(keyList.reincarnationSaveKey);
        }
        //OdinSave
        if (saveClass.GetObject<SaveO>(keyList.odinSaveKey) == null)
        {
            main.SO = new SaveO();
        }
        else
        {
            main.SO = saveClass.GetObject<SaveO>(keyList.odinSaveKey);
        }
    }

    //セーブの処理
    public void setSaveKey()
    {
        saveClass.SetObject(keyList.resetSaveKey, main.SR);
        saveClass.SetObject(keyList.permanentSaveKey, main.S);
        saveClass.SetObject(keyList.reincarnationSaveKey, main.ST);
        saveClass.SetObject(keyList.Wiz_saveKey, main.saveWiz);
        saveClass.SetObject(keyList.War_saveKey, main.saveWar);
        saveClass.SetObject(keyList.Ang_saveKey, main.saveAng);
        saveClass.SetObject(keyList.odinSaveKey, main.SO);
    }


    private void Awake()
    {
        StartBASE();
        for (int i = 0; i < main.Ascends.Length; i++)
        {
            main.Ascends[i].upgradeId = i;
        }
        getSaveKey();
    }

    // Start is called before the first frame update
    void Start()
    {
        save = StartCoroutine(doSave());
    }
    
    IEnumerator doSave()
    {
        var wait = new WaitForSeconds(1.0f);
        while (true)
        {
            yield return wait;
            //常に現在の時刻をセーブし続けている．
            main.lastTime = DateTime.Now;
            setSaveKey();
        }
    }
}
