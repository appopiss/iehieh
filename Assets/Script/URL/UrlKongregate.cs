using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrlKongregate : BASE
{
   public void onClick()
    {
        if (main.platform == Platform.steam)
            Application.OpenURL("https://www.kongregate.com/games/hapiwakuproject/incremental-epic-hero/");//""の中には開きたいWebページのURLを入力します
        else
            Application.ExternalEval(string.Format("window.open('{0}','_blank')", "https://www.kongregate.com/games/hapiwakuproject/incremental-epic-hero/"));
    }
}
