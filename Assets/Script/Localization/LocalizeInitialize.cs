using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;
using TMPro;
using UniRx.Async;

public enum Language
{
	eng,
	jp,
    chi,
}
public interface ILocalizedText
{
	void UpdateText(Language lang);
}

public class LocalizeInitialize : BASE {
    
	public static Language language { get => main.S.language; set => main.S.language = value; }
	public GameObject parent;
	public TMP_FontAsset engFont, jpFont, chiFont;
	public TMP_FontAsset oswaltFont;
	public TMP_FontAsset robotoFont;
	public TextMeshProUGUI[] oswaltFonts;
	public TextMeshProUGUI[] robotoFonts, engFonts;
	List<ILocalizedText> texts = new List<ILocalizedText>();
	public GameObject languageWindow;
	public Button openLanguageButton, openLanguageButton2;
	public Button quitButton;
	public Button[] languageButtons;
	public TextMeshProUGUI[] defaultFontText;//元のフォントを崩したくないやつ
	TMP_FontAsset[] defaultFonts;

	public static void SetFont(params TextMeshProUGUI[] texts)
	{
		foreach (var item in texts)
		{
			switch (LocalizeInitialize.language)
			{
				case Language.eng:
					item.font = main.local.engFont;
					break;
				case Language.jp:
					item.font = main.local.jpFont;
					break;
				case Language.chi:
					item.font = main.local.chiFont;
					break;
			}
		}
	}

	// Use this for initialization
	void Start() {
		//Localizeがついたコンポーネントをすべて取得します。
		foreach (var item in gameObject.GetComponents<ILocalizedText>())
		{
			texts.Add(item);
		}

		defaultFonts = new TMP_FontAsset[defaultFontText.Length];
        for (int i = 0; i < defaultFontText.Length; i++)
        {
			defaultFonts[i] = defaultFontText[i].font;
		}

		ChangeAsset(language);
		openLanguageButton.onClick.AddListener(() => setActive(languageWindow));
		openLanguageButton2.onClick.AddListener(() => {setActive(languageWindow); languageWindow.GetComponent<RectTransform>().anchoredPosition = new Vector2(-460, 100); });
		quitButton.onClick.AddListener(() => setFalse(languageWindow));
        for (int i = 0; i < languageButtons.Length; i++)
        {
			int count = i;
			languageButtons[count].onClick.AddListener(()=>ChangeAsset((Language)count));
		}
	}

	void UpdateText(Language lang)
    {
		//Textを一括変更します。
		foreach (var item in texts)
		{
			item.UpdateText(lang);
		}
	}

	//メニューで選択するたびに呼びます
	void ChangeAsset(Language lang)
    {
		language = lang;
		UpdateText(lang);
		//アセットの選択をします。
		foreach (GameObject game in GetAllChildren.GetAllTMP(parent))
		{
			if (game.HasComponent<TextMeshProUGUI>())
			{
				//ここでアセットを代入します。
				switch (lang)
				{
					case Language.eng:
						//game.GetComponent<TextMeshProUGUI>().font = engFont;
						break;
					case Language.jp:
						game.GetComponent<TextMeshProUGUI>().font = jpFont;
						break;
					case Language.chi:
						game.GetComponent<TextMeshProUGUI>().font = chiFont;
						break;
				}
			}
		}

		//英字で始まる場合はfontをenglishに戻します。
		if (lang != Language.eng)
        {

			//アセットの選択をします。
			foreach (GameObject game in GetAllChildren.GetAllTMP(parent))
			{
				if (game.HasComponent<TextMeshProUGUI>())
				{
					TextMeshProUGUI tempText = game.GetComponent<TextMeshProUGUI>();
					try
					{
						foreach (var item in tempText?.text)
						{
							//スペースか数字なら続けます。
							if (Char.IsWhiteSpace(item) || IsAsciiDigit(item))
								continue;

							//英字であれば英語のアセットに戻します。
							if (IsUpperLatin(item))
							{
								tempText.font = engFont;
								break;
							}
						}
					}catch(Exception e)
                    {
						//例外を無視しあす。
                    }
				}
			}
		}
		//オズワルトフォントは元に戻します。(翻訳したものは削除します。)
		foreach (var item in oswaltFonts)
		{
			if (item != null)
				item.font = oswaltFont;
		}
		foreach (var item in robotoFonts)
		{
			item.font = robotoFont;
		}
		foreach (var item in engFonts)
		{
			item.font = engFont;
		}
        //元のフォントに戻したいやつは戻します
        for (int i = 0; i < defaultFontText.Length; i++)
        {
			defaultFontText[i].font = defaultFonts[i];
        }
	}

	public static bool IsUpperLatin(char c)
	{
		//半角英字と全角英字の大文字の時はTrue
		return ('A' <= c && c <= 'Z') || ('a' <= c && c <= 'z');
	}
	public static bool IsAsciiDigit(char c)
	{
		return '0' <= c && c <= '9';
	}
}
