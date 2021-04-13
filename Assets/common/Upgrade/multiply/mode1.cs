using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mode1 : BASE
{
    private void Awake()
    {
        StartBASE();
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(changeMode);
    }

    void changeMode()
    {
        main.SR.buyMode = UPGRADE.buyMode.mode1;
    }
}
