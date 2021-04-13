using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterButton : BASE
{

    private void Awake()
    {
        StartBASE();
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(showRegister);
    }

    public void showRegister()
    {
        main.Log("うんこ");
        Application.ExternalEval("kongregate.services.showRegistrationBox");
    }
}
