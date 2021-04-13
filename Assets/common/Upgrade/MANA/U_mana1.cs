using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class U_mana1 : M_UPGRADE
{
    private void Awake()
    {
        awakeText();
    }
    // Start is called before the first frame update
    void Start()
    {
        startText();
        StartUpgrade();
        gameObject.GetComponent<Button>().onClick.AddListener(calculate);

    }

    // Update is called once per frame
    void Update()
    {
        updateText();
        checkButton();
    }
}
