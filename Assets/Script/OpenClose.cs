using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;
using static BASE;

public class OpenClose : BASE
{

    RectTransform thisRect;
    public Button CloseButton;
    public Button OpenButton;
    public bool isOpen;
    public bool IsOpen => isOpen;
    public bool isOpenFirst;
    public Action openAction;
    void Open()
    {
        if (isOpen)
            return;
        thisRect.anchoredPosition = Vector2.zero;
        isOpen = true;
        if (openAction != null) openAction();
    }
    void Close()
    {
        if (!isOpen)
            return;
        thisRect.anchoredPosition = Vector2.left * 800f;
        isOpen = false;
    }
    // Use this for initialization
    void Awake()
    {
        StartBASE();
        thisRect = gameObject.GetComponent<RectTransform>();
        OpenButton.onClick.AddListener(Open);
        CloseButton.onClick.AddListener(Close);
    }

    // Use this for initialization
    void Start()
    {
        if (isOpenFirst)
            isOpen = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
