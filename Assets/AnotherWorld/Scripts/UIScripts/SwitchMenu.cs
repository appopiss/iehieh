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
        public GameObject[] menuScreens;
        public Button[] menuButtons;
        [SerializeField] TextMeshProUGUI titleText;
        [NonSerialized] public bool isShow;
        [NonSerialized] public Menu currentMenu;
        [NonSerialized] public Canvas[] menuScreensCanvas;
        [NonSerialized] public CanvasGroup[] menuScreensCanvasGroup;
        [NonSerialized] public Action action = null;

        private void Awake()
        {
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
            for (int i = 0; i < menuScreens.Length; i++)
            {
                CanvasEnable((Menu)i, false);
            }
        }

        void CanvasEnable(Menu menu, bool enabled)
        {
            menuScreensCanvas[(int)menu].enabled = enabled;
            menuScreensCanvasGroup[(int)menu].interactable = enabled;
            menuScreensCanvasGroup[(int)menu].blocksRaycasts = enabled;
        }
        void OpenMenu(Menu menu)
        {
            if (isShow && currentMenu != menu) CanvasEnable(currentMenu, false);
            currentMenu = menu;
            CanvasEnable(currentMenu, true);
            UpdateUI();

            if (isShow)
                return;

            isShow = true;
            if (action != null) action();
        }
        void CloseMenu()
        {
            if (!isShow)
                return;
            isShow = false;
            CanvasEnable(currentMenu, false);
        }
        void UpdateUI()
        {
            titleText.text = localized.Menu(currentMenu);
        }
    }
}

