using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyThisParent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() =>
        {
            Destroy(gameObject.transform.parent.gameObject);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
