using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoCtrl : POPTEXT_ManualMove
{


    // Start is called before the first frame update
    void Awake()
    {
        awakeText();
    }
    private void Start()
    {
        startText();
    }

    // Update is called once per frame
    void Update()
    {
        updateText();
        if (gameObject.GetComponent<Toggle>().isOn)
        {
            main.GameController.isAuto = false;
        }
        else
        {
            main.GameController.isAuto = true;
        }
    }
}
