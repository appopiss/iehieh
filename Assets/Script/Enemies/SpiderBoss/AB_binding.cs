using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class AB_binding : ABNORMAL
{      
    // Use this for initialization
    void Awake()
    {
        AwakeCor();
    }

    // Use this for initialization
    void Start()
    {
        StartCor();
        skillNameString = "Binding";
        effectString = "<color=red>- Move Speed : 10%" + "\n- Skill Speed : 10%";
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCor();
    }

    private void OnDestroy()
    {
        Destroy(window);
        SKILL.BindingFactor = 1.0f;
        main.ally.BindingFactor = 0f;
    }

    public override IEnumerator Effect()
    {
        yield return null;
        SKILL.BindingFactor = 10.0f;
        main.ally.BindingFactor = 9f;
    }
}
