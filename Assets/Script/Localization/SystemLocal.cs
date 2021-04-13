using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static BASE;
using static UsefulMethod;

public class SystemLocal : MonoBehaviour
{
    public TextMeshProUGUI[] texts;
    string[] tempExplain;
    float[] tempFontsize;

    public void UpdateText(Language lang)
    {
        LocalizeInitialize.SetFont(texts);
        switch (lang)
        {
            case Language.jp:
                texts[0].fontSize = 10f;
                texts[0].text = "画面サイズ";
                texts[1].fontSize = 10f;
                texts[1].text = "ヘルプ";
                texts[2].fontSize = 10f;
                texts[2].text = "ステータス";
                texts[3].fontSize = 10f;
                texts[3].text = "BGM";
                texts[4].fontSize = 10f;
                texts[4].text = "効果音";
                texts[5].text = "ダメージ非表示";
                texts[6].text = "数値を指数表示にする";
                texts[7].text = "ログを非表示にする";
                texts[8].text = "自動で次のエリアに挑戦する";
                texts[9].text = "リザルト画面を時短表示する";
                texts[10].text = "チャレンジ終了後にオートムーブにする";
                texts[11].text = "スライムコイン(SC)所持数を表示する";
                texts[12].text = "常にオートムーブにする";
                texts[13].text = "SC所持数が上限に達するまでQueueを待つ";
                texts[14].text = "パフォーマンスモード";
                texts[15].text = "カスタムレンジ";
                texts[16].text = "言語";
                texts[17].fontSize = 10f;
                texts[17].text = "ローカルセーブ";
                texts[18].fontSize = 10f;
                texts[18].text = "ローカルロード";
                texts[19].fontSize = 10f;
                texts[19].text = "クラウドセーブ";
                texts[20].fontSize = 10f;
                texts[20].text = "クラウドロード";
                texts[21].fontSize = 10f;
                texts[21].text = "ハードリセット";
                break;
            case Language.chi:
                texts[0].text = "分辨率";
                texts[1].fontSize = 10f;
                texts[1].text = "帮助";
                texts[2].fontSize = 10f;
                texts[2].text = "属性";
                texts[3].fontSize = 10f;
                texts[3].text = "BGM";
                texts[4].fontSize = 10f;
                texts[4].text = "SFX";
                texts[5].text = "关闭伤害显示";
                texts[6].text = "切换资源显示";
                texts[7].text = "关闭经验值/金币显示";
                texts[8].text = "自动探险下一关";
                texts[9].text = "跳过战报界面";
                texts[10].text = "从挑战关卡回来普通关卡时会切换成自动移动模式";
                texts[11].text = "切换金币/史莱姆币显示";
                texts[12].text = "在没有手动移动的状况下，会切换成自动移动模式";
                texts[13].text = "排列研发史莱姆科技时，得等到SC直到上限才会研发";
                texts[14].text = "极简模式";
                texts[15].text = "自定攻击范围";
                texts[16].text = "语言";
                texts[17].fontSize = 10f;
                texts[17].text = "本地存档";
                texts[18].fontSize = 10f;
                texts[18].text = "本地读档";
                texts[19].fontSize = 10f;
                texts[19].text = "云存档";
                texts[20].fontSize = 10f;
                texts[20].text = "云读档";
                texts[21].fontSize = 10f;
                texts[21].text = "删档";
                break;
            default:
                for (int i = 0; i < texts.Length; i++)
                {
                    texts[i].text = tempExplain[i];
                    texts[i].fontSize = tempFontsize[i];
                }
                break;
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        tempExplain = new string[texts.Length];
        tempFontsize = new float[texts.Length];
        for (int i = 0; i < texts.Length; i++)
        {
            tempExplain[i] = texts[i].text;
            tempFontsize[i] = texts[i].fontSize;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText(LocalizeInitialize.language);
    }
}
