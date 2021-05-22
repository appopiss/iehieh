using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static Another.Main;
using Another;
using static UsefulMethod;
using Cysharp.Threading.Tasks;
using TMPro;
using static Another.LocalizedText;
using System.Linq;

namespace Another
{
    public class AREA : DOWNINFO
    {
        [NonSerialized] public int id;//11:1-1, 23:2-3を示す
        [SerializeField] Image iconMonsterImage;
        [SerializeField] TextMeshProUGUI infoText, missionText, missionRewardText, areaMasteryText;
        [SerializeField] private GameObject silverFrameObject;

        protected override void Awake()
        {
            base.Awake();
            infoSize = new Vector2(800f, 330f);
        }
        // Start is called before the first frame update
        void Start()
        {
            iconButton.onClick.AddListener(() => main.areaCtrl.StartArea(id));
        }

        // Update is called once per frame
        void Update()
        {
            UpdateUI();
        }
        void UpdateUI()
        {
            infoText.text = main.areaCtrl.InfoString(id);
            iconImage.sprite = main.areaCtrl.backgroundSprites[id];
            EnemySpecies tempSpecies = (EnemySpecies)(id / 10 - 1);
            EnemyColor tempColor = EnemyColor.Normal;
            switch (id % 10)
            {
                case 1:
                    tempColor = EnemyColor.Normal;
                    break;
                case 2:
                    tempColor = EnemyColor.Blue;
                    break;
                case 3:
                    tempColor = EnemyColor.Yellow;
                    break;
                case 4:
                    tempColor = EnemyColor.Boss;
                    break;
                case 5:
                    tempColor = EnemyColor.Red;
                    break;
                case 6:
                    tempColor = EnemyColor.Green;
                    break;
                case 7:
                    tempColor = EnemyColor.Purple;
                    break;
                case 8:
                    tempColor = EnemyColor.Boss;
                    break;
            }
            iconMonsterImage.sprite = main.battleCtrl.enemyCtrl.Sprites(tempSpecies, tempColor, false);
            missionText.text = MissionString();
            missionRewardText.text = MissionRewardString();
            areaMasteryText.text = main.areaCtrl.MasteryString(id);
            if (main.areaCtrl.currentAreaId == id) setActive(silverFrameObject);
            else setFalse(silverFrameObject);
        }
        //MissionText
        [NonSerialized] public List<Mission> missions = new List<Mission>();
        public void SetMission()
        {
            missions = new List<Mission>();
            missions.Add(new Mission(id, MissionKind.Clear));
            switch (id)
            {
                case 11:
                    missions.Add(new Mission(id, MissionKind.OnlyBase));
                    missions.Add(new Mission(id, MissionKind.Time, 5));
                    missions.Add(new Mission(id, MissionKind.Hp));
                    missions.Add(new Mission(id, MissionKind.ClearNum, 250));
                    break;
                case 12:
                    missions.Add(new Mission(id, MissionKind.SpendTime, 3600));
                    missions.Add(new Mission(id, MissionKind.Gold, 1000));
                    missions.Add(new Mission(id, MissionKind.OnlyBase));
                    missions.Add(new Mission(id, MissionKind.TimeOver, 300));
                    break;
                default:
                    break;
            }
            missions.Add(new Mission(id, MissionKind.All));
        }
        string MissionString()
        {
            string tempString = optStr + "<size=16><u>" + localized.Basic(BasicWord.Mission) + "</u><size=8>\n";
            for (int i = 0; i < missions.Count(); i++)
            {
                if (missions[i].IsCompleted())
                    tempString += "<color=green>";
                tempString += optStr + "\n</size><size=16>- " + missions[i].String() + "</color>";
            }
            return tempString;
        }
        string MissionRewardString()
        {
            string tempString = optStr + "<size=16>  <size=8>\n";
            long tempEC = 10;
            for (int i = 0; i < missions.Count(); i++)
            {
                if (missions[i].IsCompleted())
                    tempString += "<color=green>";
                if (i == 0 || i == 1) tempEC = 10;
                else if (i == 2 || i == 3) tempEC = 25;
                else if (i == 4) tempEC = 55;
                else tempEC = 200;
                tempString += optStr + "\n</size><size=16>" + tempEC.ToString() + "</color>";
            }
            return tempString;
        }
    }
    public enum MissionKind
    {
        Clear,
        ClearNum,
        Hp,
        OnlyBase,
        NoEq,
        Time,
        TimeOver,
        SpendTime,
        Capture,
        Gather,
        Defeat,
        Gold,
        NoDmg,
        All,
    }
    public class Mission
    {
        int areaId;
        public MissionKind kind;
        public double value;
        public Mission(int areaId, MissionKind kind, double value = 0)
        {
            this.areaId = areaId;
            this.kind = kind;
            this.value = value;
        }
        public string String()
        {
            return localized.Mission(areaId, kind, value);
        }
        public bool IsCompleted()
        {
            switch (kind)
            {
                case MissionKind.Clear:
                    return main.S.AAreaClearedNum[areaId] >= 1;
                case MissionKind.ClearNum:
                    return main.S.AAreaClearedNum[areaId] >= value;
                case MissionKind.Hp:
                    return main.S.AIsMaxHp[areaId];
                case MissionKind.OnlyBase:
                    return main.S.AIsOnlyBase[areaId];
                case MissionKind.NoEq:
                    return main.S.AIsNoEq[areaId];
                case MissionKind.Time:
                    return main.S.AMinClearTime[areaId] > 0 && main.S.AMinClearTime[areaId] <= value;
                case MissionKind.TimeOver:
                    return main.S.AMaxClearTime[areaId] >= value;
                case MissionKind.SpendTime:
                    return main.S.ASpendTime[areaId] >= value;
                case MissionKind.Capture:
                    break;
                case MissionKind.Gather:
                    break;
                case MissionKind.Defeat:
                    break;
                case MissionKind.Gold:
                    return main.S.AMaxGoldGained[areaId] >= value;
                case MissionKind.NoDmg:
                    return main.S.AIsNoDmg[areaId];
                case MissionKind.All:
                    return main.S.AIsMissionAll[areaId];
                default:
                    break;
            }
            return false;
        }
    }
}
