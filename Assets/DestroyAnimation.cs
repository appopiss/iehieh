using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class DestroyAnimation : BASE {


	// Use this for initialization
	void Start () {
        StartCoroutine(destroyThis());
	}
	
    IEnumerator destroyThis()
    {
        Animator thisAnimator = gameObject.GetComponent<Animator>();
        yield return new WaitForSeconds(thisAnimator.GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject);
    }
}
