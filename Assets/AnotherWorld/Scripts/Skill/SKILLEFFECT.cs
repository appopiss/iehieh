using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using static Main;
using static UsefulMethod;
using Cysharp.Threading.Tasks;

public class SKILLEFFECT : MonoBehaviour
{
    public bool isAnimation;
    [NonSerialized] public bool isShow;
    Image thisImage;
    RectTransform thisRect;
    static Vector2 behindPosition = Vector2.right * Screen.width * 2;//待機場所

    public async void ShowEffect(Sprite sprite, Vector2 position, float range, float showTime)
    {
        isShow = true;
        thisRect.anchoredPosition = position;
        thisRect.sizeDelta = Vector2.one * range * 2;
        thisImage.sprite = sprite;
        await UniTask.Delay((int)(showTime * 1000));
        VanishEffect();
    }

    public void VanishEffect()
    {
        thisRect.anchoredPosition = behindPosition;
        thisRect.sizeDelta = Vector2.zero;
        thisImage.sprite = null;
        isShow = false;
    }
    private void Awake()
    {
        thisImage = gameObject.GetComponent<Image>();
        thisRect = gameObject.GetComponent<RectTransform>();
        VanishEffect();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
