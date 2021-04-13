using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrlHapiwaku : BASE
{
   public void onClick()
    {
        if (main.platform == Platform.steam)
            Application.OpenURL("https://hapiwaku.work/2020/04/15/incremental-epic-hero/");//""の中には開きたいWebページのURLを入力します
        else
            Application.ExternalEval(string.Format("window.open('{0}','_blank')", "https://hapiwaku.work/2020/04/15/incremental-epic-hero/"));
    }
}
