using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrlTwitter : BASE
{
   public void onClick()
    {
        if (main.platform == Platform.steam) 
            Application.OpenURL("https://twitter.com/ieh_hapiwaku");//""の中には開きたいWebページのURLを入力します
        else
            Application.ExternalEval(string.Format("window.open('{0}','_blank')", "https://twitter.com/ieh_hapiwaku"));
    }
}
