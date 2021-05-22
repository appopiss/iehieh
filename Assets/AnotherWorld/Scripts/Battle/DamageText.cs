using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static UsefulMethod;
using TMPro;

namespace Another
{
    public class DamageText : MonoBehaviour
    {
        [NonSerialized] public int id;
        RectTransform thisRect;
        TextMeshProUGUI thisText;
        static Vector2[] resetPos = new Vector2[3]
        {
        new Vector2(-32,-16),
        Vector2.zero,
        new Vector2(32,16)
        };
        public void ShowText(string text)
        {
            thisRect.anchoredPosition = resetPos[id];
            thisText.text = text;
        }
        void Awake()
        {
            thisRect = gameObject.GetComponent<RectTransform>();
            thisText = gameObject.GetComponent<TextMeshProUGUI>();
        }
        // Update is called once per frame
        void Update()
        {
            thisRect.anchoredPosition += Vector2.up;
            if (thisRect.anchoredPosition.y >= 16 * (id + 1))
                setFalse(gameObject);
        }
    }
}
