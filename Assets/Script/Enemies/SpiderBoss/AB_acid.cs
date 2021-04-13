using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class AB_acid : ABNORMAL
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
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCor();
    }

    private void OnDestroy()
    {
        SKILL.BindingFactor = 1.0f;
    }

    public override IEnumerator Effect()
    {
        yield return null;
        SKILL.BindingFactor = 5.0f;
    }
}
