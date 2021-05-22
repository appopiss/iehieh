using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using static Another.Main;
using static UsefulMethod;
using static Another.Skill;
using static Another.Class;
using static Another.SkillType;
using Another;

namespace Another
{
    public class DOWNINFO : MonoBehaviour
    {
        public Button infoButton;
        public Button iconButton;
        [NonSerialized] public bool isShowInfo;
        [NonSerialized] public Image iconImage;
        [NonSerialized] public RectTransform thisRect;
        [NonSerialized] public Vector2 normalSize = new Vector2(800f, 100f);
        [NonSerialized] public Vector2 infoSize = new Vector2(800f, 330f);

        public void SwitchInfo()
        {
            isShowInfo = !isShowInfo;
            thisRect.sizeDelta = isShowInfo ? infoSize : normalSize;
        }
        protected virtual void Awake()
        {
            gameObject.AddComponent<Mask>();
            iconImage = iconButton.gameObject.GetComponent<Image>();
            thisRect = gameObject.GetComponent<RectTransform>();
            infoButton.onClick.AddListener(SwitchInfo);
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
}
