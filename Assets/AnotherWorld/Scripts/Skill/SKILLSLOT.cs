using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using static Another.Main;
using static UsefulMethod;
using static Another.Skill;
using Another;
using Cysharp.Threading.Tasks;

namespace Another
{
    public class SKILLSLOT : MonoBehaviour
    {
        [NonSerialized] public bool isGlobal;
        [NonSerialized] public int id;
        [NonSerialized] public Image thisImage;
        [NonSerialized] public Image chargetimeImage;
        public Class currentClass { get => main.S.ACurrentClass; }
        public Skill skill;
        float chargetime { get => main.skillCtrl.skills[(int)skill].chargetime; }

        public void SetSkill(Skill skill)
        {
            this.skill = skill;
            UpdateSprite();
        }
        public void RemoveSkill()
        {
            skill = Nothing;
            UpdateSprite();
        }
        public bool IsSet()
        {
            return skill != Nothing;
        }
        public float ChargetimePercent()
        {
            if (IsSet())
                return chargetime / main.skillCtrl.skills[(int)skill].Interval();
            else
                return 0;
        }
        bool IsUnleashed()
        {
            if (isGlobal) return id < main.skillCtrl.GlobalSkillSlotNum();
            else return id < main.skillCtrl.NormalSkillSlotNum();
        }
        void UpdateSprite()
        {
            if (IsSet())
                thisImage.sprite = main.skillCtrl.skillSprites[(int)skill];
            else
                thisImage.sprite = IsUnleashed() ? main.skillCtrl.slotSprite : main.skillCtrl.lockSlotSprite;
            chargetimeImage.fillAmount = ChargetimePercent();
        }

        private void Awake()
        {
            thisImage = gameObject.GetComponent<Image>();
            chargetimeImage = gameObject.transform.GetChild(0).gameObject.GetComponent<Image>();
        }
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (IsSet())
                chargetimeImage.fillAmount = ChargetimePercent();
        }
    }
}

