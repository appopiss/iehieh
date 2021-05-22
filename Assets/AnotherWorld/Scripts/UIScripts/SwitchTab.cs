using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static Main;
using static UsefulMethod;
using static UsefulStatic;
using Cysharp.Threading.Tasks;
using TMPro;

public class SwitchTab : MonoBehaviour
{
    public bool isSwitchCanvas = true, isTextColorChange;
    public Button[] tabButtons;
    public Canvas[] tabCanvas;
    public int initShowTabId;
    public Color normalColor = Color.white;
    public Color selectedColor = Color.yellow;
    [NonSerialized] public CanvasGroup[] tabCanvasGroup;
    [NonSerialized] public TextMeshProUGUI[] tabButtonTexts;
    [NonSerialized] public int currentTabId;
    [NonSerialized] public Action action;

    public void ButtonInteractable(int id, bool interactable)
    {
        tabButtons[id].interactable = interactable;
    }
    void OpenTab(int id)
    {
        if (isTextColorChange) TextColorChange(tabButtonTexts[id], selectedColor);
        for (int i = 0; i < tabButtons.Length; i++)
        {
            if (i != id)
            {
                if (isSwitchCanvas) CanvasEnable(i, false);
                if (isTextColorChange) TextColorChange(tabButtonTexts[i], normalColor);
            }
        }
        if (isSwitchCanvas) CanvasEnable(id, true);
        currentTabId = id;
        if (action != null) action();
    }
    void CanvasEnable(int id, bool enabled)
    {
        tabCanvas[id].enabled = enabled;
        tabCanvasGroup[id].interactable = enabled;
        tabCanvasGroup[id].blocksRaycasts = enabled;
    }
    void TextColorChange(TextMeshProUGUI text, Color color)
    {
        text.color = color;
    }
    private void Awake()
    {
        if (isSwitchCanvas)
        {
            tabCanvasGroup = new CanvasGroup[tabCanvas.Length];
            for (int i = 0; i < tabCanvas.Length; i++)
            {
                tabCanvasGroup[i] = tabCanvas[i].gameObject.GetOrAddComponent<CanvasGroup>();
            }
        }
        if (isTextColorChange)
        {
            tabButtonTexts = new TextMeshProUGUI[tabButtons.Length];
            for (int i = 0; i < tabButtons.Length; i++)
            {
                tabButtonTexts[i] = tabButtons[i].gameObject.GetComponentInChildren<TextMeshProUGUI>();
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < tabButtons.Length; i++)
        {
            int count = i;
            tabButtons[i].onClick.AddListener(() => OpenTab(count));
        }
        tabButtons[initShowTabId].onClick.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
