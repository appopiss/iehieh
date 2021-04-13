using UnityEngine;
using System.Collections;
using TMPro;

public class FPScalculate : BASE
{
    int frameCount;
    float nextTime;
    TextMeshProUGUI FPSText;

    // Use this for initialization
    void Start()
    {
        nextTime = Time.time + 1;
        FPSText = gameObject.GetComponent<TextMeshProUGUI>();
        
    }
    
    // Update is called once per frame
    void Update()
    {
        frameCount++;

        if (Time.time >= nextTime)
        {
            // 1秒経ったらFPSを表示
            if (main.GameController.currentCanvas == main.GameController.InventoryCanvas)
            {
                frameCount *= (int)Time.timeScale;
                FPSText.text = frameCount.ToString();
            }
                frameCount = 15;
            nextTime += 1;
        }
    }
}