using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Deselect : BASE, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        main.skillSetController.chosenSkill = null;
    }

    public void Awake()
    {
        StartBASE();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
