using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrlDiscord : BASE
{
   public void onClick()
    {
        if (main.platform == Platform.steam)
            Application.OpenURL("https://discord.gg/HfCEuYR");//""の中には開きたいWebページのURLを入力します
        else
            Application.ExternalEval(string.Format("window.open('{0}','_blank')", "https://discord.gg/HfCEuYR"));

    }
}
