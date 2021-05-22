using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static Another.Main;
using static Another.LocalizedText;
using static UsefulMethod;
using Cysharp.Threading.Tasks;
using TMPro;
using Another;

namespace Another
{
    public enum Menu
    {
        Upgrade,
        Skill,
        Explore,
        Craft,
    }
    public class SwitchMenu : MonoBehaviour
    {
        static Vector3 openScale = new Vector3(0.6f, 0.5f, 0f);//Menuを開いた時のLocalScale
        static Vector2 normalStatusVec = new Vector2(0, 70f);//StatusCanvasの初期値
        static Vector2 normalScreenVec = new Vector2(0, -Screen.height);
        static float moveY = 830f;
        static int openFrame = 10;
        public GameObject showscreen;
        public GameObject[] menuScreens;
        public Button[] menuButtons;
        public Button buymodeButton;
        public Button closeButton;
        [SerializeField] TextMeshProUGUI titleText;
        private TextMeshProUGUI buymodeText;
        [NonSerialized] public bool isShow;
        [NonSerialized] public Menu currentMenu;
        [NonSerialized] public RectTransform showscreenRect;
        [NonSerialized] public Canvas[] menuScreensCanvas;
        [NonSerialized] public CanvasGroup[] menuScreensCanvasGroup;
        [NonSerialized] public Action action;

        private void Awake()
        {
            showscreenRect = showscreen.GetComponent<RectTransform>();
            buymodeText = buymodeButton.gameObject.GetComponentInChildren<TextMeshProUGUI>();
            menuScreensCanvas = new Canvas[menuScreens.Length];
            for (int i = 0; i < menuScreens.Length; i++)
            {
                menuScreensCanvas[i] = menuScreens[i].GetComponent<Canvas>();
            }
            menuScreensCanvasGroup = new CanvasGroup[menuScreens.Length];
            for (int i = 0; i < menuScreens.Length; i++)
            {
                menuScreensCanvasGroup[i] = menuScreens[i].GetComponent<CanvasGroup>();
            }
        }
        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < menuButtons.Length; i++)
            {
                int count = i;
                menuButtons[i].onClick.AddListener(() => OpenMenu((Menu)count));
            }
            closeButton.onClick.AddListener(CloseMenu);
            for (int i = 0; i < menuScreens.Length; i++)
            {
                CanvasEnable((Menu)i, false);
            }
            buymodeButton.onClick.AddListener(SwitchBuyMode);
        }

        void CanvasEnable(Menu menu, bool enabled)
        {
            menuScreensCanvas[(int)menu].enabled = enabled;
            menuScreensCanvasGroup[(int)menu].interactable = enabled;
            menuScreensCanvasGroup[(int)menu].blocksRaycasts = enabled;
        }
        async void OpenMenu(Menu menu)
        {
            if (isShow && currentMenu != menu) CanvasEnable(currentMenu, false);
            currentMenu = menu;
            CanvasEnable(currentMenu, true);
            UpdateUI();

            if (isShow)
                return;

            isShow = true;
            main.battleCtrl.thisRect.localScale = Vector3.one;
            main.statusCtrl.thisRect.anchoredPosition = normalStatusVec;
            showscreenRect.anchoredPosition = Vector2.down * 760f;
            for (int i = 0; i < openFrame; i++)
            {
                main.battleCtrl.thisRect.localScale -= (Vector3.one - openScale) / openFrame;
                main.statusCtrl.thisRect.anchoredPosition += Vector2.up * moveY / openFrame;
                showscreenRect.anchoredPosition += Vector2.up * moveY / openFrame;
                await UniTask.DelayFrame(1);
            }
            main.battleCtrl.thisRect.localScale = openScale;
            main.statusCtrl.thisRect.anchoredPosition = normalStatusVec + Vector2.up * moveY;
            showscreenRect.anchoredPosition = Vector2.down * 760f + Vector2.up * moveY;

            closeButton.interactable = true;
            action();
        }
        async void CloseMenu()
        {
            if (!isShow)
                return;
            isShow = false;

            main.battleCtrl.thisRect.localScale = openScale;
            main.statusCtrl.thisRect.anchoredPosition = normalStatusVec + Vector2.up * moveY;
            showscreenRect.anchoredPosition = Vector2.down * 730f + Vector2.up * moveY;
            for (int i = 0; i < openFrame; i++)
            {
                main.battleCtrl.thisRect.localScale += (Vector3.one - openScale) / openFrame;
                main.statusCtrl.thisRect.anchoredPosition -= Vector2.up * moveY / openFrame;
                showscreenRect.anchoredPosition -= Vector2.up * moveY / openFrame;
                await UniTask.DelayFrame(1);
            }
            main.battleCtrl.thisRect.localScale = Vector3.one;
            main.statusCtrl.thisRect.anchoredPosition = normalStatusVec;
            showscreenRect.anchoredPosition = normalScreenVec;
            CanvasEnable(currentMenu, false);
            closeButton.interactable = false;
        }
        void SwitchBuyMode()
        {
            if (main.S.buyModeId < main.buyModeNumArray.Length - 1)
                main.S.buyModeId++;
            else
                main.S.buyModeId = 0;
            UpdateUI();
        }
        void UpdateUI()
        {
            //Text
            buymodeText.text = "x " + tDigit(main.BuyModeNum());
            titleText.text = localized.Menu(currentMenu);
        }
    }
}

