using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmWindow : MonoBehaviour
{
    public Button okButton;
    public Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        okButton.onClick.AddListener(() => Destroy(gameObject));
        quitButton.onClick.AddListener(() => Destroy(gameObject));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
