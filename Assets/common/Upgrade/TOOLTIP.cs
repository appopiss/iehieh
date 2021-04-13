using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TOOLTIP : MonoBehaviour
{
    RectTransform thisRect;
    // Start is called before the first frame update
    void Start()
    {
        thisRect = gameObject.GetComponent<RectTransform>();
        thisRect.anchoredPosition = Vector2.right * Screen.width * 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeSelf)
            SetTooltip();
    }

    public void SetTooltip()
    {
        Vector2 position = Input.mousePosition;
        if (position.x < Screen.width / 2)
        {
            if (position.y < Screen.height * (1 / 3f))
            {
                thisRect.anchorMin = Vector2.right;
                thisRect.anchorMax = Vector2.right;
                thisRect.pivot = Vector2.right;
                thisRect.anchoredPosition = -Vector2.right * 40f + Vector2.up * 40f;
            }
            else
            {
                thisRect.anchorMin = Vector2.one;
                thisRect.anchorMax = Vector2.one;
                thisRect.pivot = Vector2.one;
                thisRect.anchoredPosition = -Vector2.one * 40f;
            }
        }
        else
        {
            if (position.y < Screen.height * (1 / 3f))
            {
                thisRect.anchorMin = Vector2.zero;
                thisRect.anchorMax = Vector2.zero;
                thisRect.pivot = Vector2.zero;
                thisRect.anchoredPosition = Vector2.one * 30f;
            }
            else
            {
                thisRect.anchorMin = Vector2.up;
                thisRect.anchorMax = Vector2.up;
                thisRect.pivot = Vector2.up;
                thisRect.anchoredPosition = Vector2.right * 30f + Vector2.down * 30f;
            }
        }
    }

}
