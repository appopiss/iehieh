using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UsefulMethod;
using IdleLibrary;

public class PopupConfirm : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI descriptionText, buttonText;
    [SerializeField] private Button closeButton, confirmButton;
    private Action confirmAction;
    public void UpdateUI(IText descriptionText, IText buttonText = null, Action confirmAction = null)
    {
        this.descriptionText.text = descriptionText.Text();
        this.buttonText.text = buttonText == null ? "OK" : buttonText.Text();
        this.confirmAction = confirmAction == null ? () => Close() : confirmAction;
    }
    public void UpdateUI(string descriptionText, string buttonText = null, Action confirmAction = null)
    {
        this.descriptionText.text = descriptionText;
        this.buttonText.text = buttonText == null ? "OK" : buttonText;
        this.confirmAction = confirmAction == null ? () => Close() : confirmAction;
    }
    private void OnEnable()
    {
        closeButton.onClick.AddListener(Close);
        confirmButton.onClick.AddListener(() => confirmAction());
    }
    void Close()
    {
        setFalse(gameObject);
    }
}
