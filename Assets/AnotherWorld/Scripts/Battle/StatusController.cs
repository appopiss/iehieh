using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Another;
using static Another.Main;
using static UsefulMethod;
using static Another.LocalizedText;

public partial class Save
{
    public double ACurrentGold;
    public double ACurrentSlimeCoin;
    public double ACurrentStone;
    public double ACurrentCrystal;
    public double ACurrentLeaf;
}
namespace Another
{
    public enum Resource
    {
        Gold,
        SlimeCoin,
        Stone,
        Crystal,
        Leaf,
    }
    public class StatusController : MonoBehaviour
    {
        public Button autoMoveButton;
        public Button rangeButton;
        //public Button hpInfoButton;
        public Image autoMoveImage;
        public TextMeshProUGUI[] resourceTexts;
        public TextMeshProUGUI rangeText;
        public TextMeshProUGUI hpInfoText;
        public TextMeshProUGUI statusText;
        //public FixedJoystick joystick;
        public Image hpBar, mpBar, expBar, goldBar;

        private double currentGold { get => main.S.ACurrentGold; set => main.S.ACurrentGold = value; }
        private double currentSlimeCoin { get => main.S.ACurrentSlimeCoin; set => main.S.ACurrentSlimeCoin = value; }
        private double currentStone { get => main.S.ACurrentStone; set => main.S.ACurrentStone = value; }
        private double currentCrystal { get => main.S.ACurrentCrystal; set => main.S.ACurrentCrystal = value; }
        private double currentLeaf { get => main.S.ACurrentLeaf; set => main.S.ACurrentLeaf = value; }
        public Sprite[] autoMoveSprites;

        [NonSerialized] public RectTransform thisRect;
        [NonSerialized] public bool isAutoMove;
        [NonSerialized] public bool isInfo;
        [NonSerialized] public int rangeId;
        [NonSerialized] public float currentRange = 100f;
        [NonSerialized] public float[] range = new float[] { 100, 200, 300 };
        Ally ally;

        public double GoldCap()
        {
            return main.battleCtrl.ally.TotalStats(Stats.GoldCap);
        }
        public float CurrentGoldPercent()
        {
            return Mathf.Clamp((float)(currentGold / GoldCap()), 0, 1);
        }
        public double SlimeCoinCap()
        {
            return main.battleCtrl.ally.TotalStats(Stats.SlimeCoinCap);
        }
        //Resource
        public bool IsEnoughCost(Resource resource, double value)
        {
            switch (resource)
            {
                case Resource.Gold:
                    return currentGold >= value;
                case Resource.SlimeCoin:
                    return currentSlimeCoin >= value;
                case Resource.Stone:
                    return currentStone >= value;
                case Resource.Crystal:
                    return currentCrystal >= value;
                case Resource.Leaf:
                    return currentLeaf >= value;
                default:
                    return currentGold >= value;
            }
        }
        //Resourceの値を変えるときは必ずこれを参照する
        public void ChangeCurrentResource(Resource resource, double value)
        {
            double tempValue = 0;
            switch (resource)
            {
                case Resource.Gold:
                    tempValue = currentGold;
                    tempValue += value;
                    if (tempValue < 0) tempValue = 0;
                    if (tempValue == Mathf.Infinity) tempValue = 1e300d;
                    if (tempValue > GoldCap()) tempValue = GoldCap();
                    currentGold = tempValue;
                    //Log
                    if (value > 0) main.Log(optStr + localized.Resource(Resource.Gold) + " + " + tDigit(value));
                    break;
                case Resource.SlimeCoin:
                    tempValue = currentSlimeCoin;
                    tempValue += value;
                    if (tempValue < 0) tempValue = 0;
                    if (tempValue == Mathf.Infinity) tempValue = 1e300d;
                    if (tempValue > SlimeCoinCap()) tempValue = SlimeCoinCap();
                    currentSlimeCoin = tempValue;
                    break;
                case Resource.Stone:
                    tempValue = currentStone;
                    tempValue += value;
                    if (tempValue < 0) tempValue = 0;
                    if (tempValue == Mathf.Infinity) tempValue = 1e300d;
                    currentStone = tempValue;
                    break;
                case Resource.Crystal:
                    tempValue = currentCrystal;
                    tempValue += value;
                    if (tempValue < 0) tempValue = 0;
                    if (tempValue == Mathf.Infinity) tempValue = 1e300d;
                    currentCrystal = tempValue;
                    break;
                case Resource.Leaf:
                    tempValue = currentLeaf;
                    tempValue += value;
                    if (tempValue < 0) tempValue = 0;
                    if (tempValue == Mathf.Infinity) tempValue = 1e300d;
                    currentLeaf = tempValue;
                    break;
            }
        }

        private void Awake()
        {
            thisRect = gameObject.GetComponent<RectTransform>();
            ally = main.battleCtrl.ally;
        }
        // Start is called before the first frame update
        void Start()
        {
            autoMoveButton.onClick.AddListener(SwitchMove);
            rangeButton.onClick.AddListener(SwitchRange);
            SwitchMove();
        }
        void SwitchMove()
        {
            isAutoMove = !isAutoMove;
            if (isAutoMove)
            {
                autoMoveImage.sprite = autoMoveSprites[0];
            }
            else
            {
                autoMoveImage.sprite = autoMoveSprites[1];
            }
        }
        void SwitchRange()
        {
            rangeId = (1 + rangeId) % range.Length;
            currentRange = range[rangeId];
            rangeText.text = optStr + "<size=26>" + currentRange.ToString();
        }
        void SwitchInfo()
        {
            isInfo = !isInfo;
            if (isInfo)
                setActive(hpInfoText.gameObject);
            else
                setFalse(hpInfoText.gameObject);
        }

        // Update is called once per frame
        void Update()
        {
            resourceTexts[0].text = optStr + "<size=20>" + "<sprite=\"resource\" index=0>" + tDigit(currentGold) + " / " + tDigit(GoldCap());
            resourceTexts[1].text = optStr + "<size=20>" + "<sprite=\"resource\" index=2>" + tDigit(currentStone);
            resourceTexts[2].text = optStr + "<size=20>" + "<sprite=\"resource\" index=3>" + tDigit(currentCrystal);
            resourceTexts[3].text = optStr + "<size=20>" + "<sprite=\"resource\" index=4>" + tDigit(currentLeaf);
            statusText.text = optStr + "<size=20>"
                + localized.Class(ally.currentClass) + " Lv " + tDigit(ally.Level()) + "  "
                + localized.Stat(Stats.Atk, true) + " " + tDigit(ally.TotalStats(Stats.Atk)) + "  "
                + localized.Stat(Stats.MAtk, true) + " " + tDigit(ally.TotalStats(Stats.MAtk)) + "  "
                + localized.Stat(Stats.Def, true) + " " + tDigit(ally.TotalStats(Stats.Def)) + "  "
                + localized.Stat(Stats.MDef, true) + " " + tDigit(ally.TotalStats(Stats.MDef)) + "  "
                + localized.Stat(Stats.Spd, true) + " " + tDigit(ally.TotalStats(Stats.Spd)) + "\n"
                + localized.Stat(Stats.FireRes, true) + " " + percent(ally.TotalElementResistance(Element.Fire)) + "  "
                + localized.Stat(Stats.IceRes, true) + " " + percent(ally.TotalElementResistance(Element.Ice)) + "  "
                + localized.Stat(Stats.ThunderRes, true) + " " + percent(ally.TotalElementResistance(Element.Thunder)) + "  "
                + localized.Stat(Stats.LightRes, true) + " " + percent(ally.TotalElementResistance(Element.Light)) + "  "
                + localized.Stat(Stats.DarkRes, true) + " " + percent(ally.TotalElementResistance(Element.Dark));
            hpBar.fillAmount = (float)ally.HpPercent();
            mpBar.fillAmount = (float)ally.MpPercent();
            expBar.fillAmount = ally.CurrentExpPercent();
            goldBar.fillAmount = CurrentGoldPercent();

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) { if (isAutoMove) SwitchMove(); ally.MoveHorizontal(1); }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) { if (isAutoMove) SwitchMove(); ally.MoveHorizontal(-1); }
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) { if (isAutoMove) SwitchMove(); ally.MoveVertical(1); }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) { if (isAutoMove) SwitchMove(); ally.MoveVertical(-1); }

            //if (isInfo)
            //{
            //    hpInfoText.text = optStr
            //        + "<size=20>EXP : " + tDigit(ally.exp) + " / " + tDigit(ally.CurrentRequiredExp()) + " (" + percent(ally.CurrentExpPercent(), 3) + ")"
            //        + "<size=24>\nHP : " + tDigit(ally.currentHp) + " / " + tDigit(ally.TotalStats(Stats.Hp))
            //        + "\nMP : " + tDigit(ally.currentMp) + " / " + tDigit(ally.TotalStats(Stats.Mp));
            //}
            //if (joystick.Horizontal != 0 || joystick.Vertical != 0)
            //{
            //    main.battleCtrl.ally.MoveHorizontal(joystick.Horizontal);
            //    main.battleCtrl.ally.MoveVertical(joystick.Vertical);
            //}
        }
    }
}
