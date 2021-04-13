using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrlWiki : BASE
{
   public void onClick()
    {
        if (main.platform == Platform.steam)
            Application.OpenURL("https://incremental-epic-hero.fandom.com/wiki/Incremental_Epic_Hero_Wiki");//""の中には開きたいWebページのURLを入力します
        else
            Application.ExternalEval(string.Format("window.open('{0}','_blank')", "https://incremental-epic-hero.fandom.com/wiki/Incremental_Epic_Hero_Wiki"));
    }
}
