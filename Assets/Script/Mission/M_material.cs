using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class M_material : MISSION {

    //素材を何個集めたか
    public ArtiCtrl.MaterialList TargetMaterial;
    public long requiredMaterialNum;

    // Use this for initialization
    void Awake () {
		StartBASE();
        AwakeMission();
        isUpdate = true;
	}

    public void awake(int MissionId, ArtiCtrl.MaterialList TargetMaterial, long requiredMaterialNum)
    {
        this.MissionId = MissionId;
        this.TargetMaterial = TargetMaterial;
        this.requiredMaterialNum = requiredMaterialNum;
    }

    // Use this for initialization
    void Start () {
        StartMission();
       // MissionExplainText.text = "- Gather " + tDigit(requiredMaterialNum) + " " + main.ArtiCtrl.ConvertEnum(TargetMaterial)
       //     + "\n Current : " + tDigit(materialNum) + " / " + tDigit(requiredMaterialNum);
        ClearCondition = () => materialNum >= requiredMaterialNum;
	}

    protected override void ResetVariable()
    {
        materialNum = 0;
    }

    // Update is called once per frame
    void Update () {
        UpdateMission();
        if (gameObject.GetComponent<DUNGEON>().window.activeSelf)
        {
            MissionExplainText.text = MissionLocal.material(this);
        }
	}
}
