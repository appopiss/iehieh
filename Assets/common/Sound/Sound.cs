using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class Sound : BASE {
    public AudioSource BGMSource;
    public AudioClip equipClip;
    public AudioClip notEquipClip;
    public AudioClip skillChooseClip;
    public AudioClip redChiliClip;
    public AudioClip attackClip;

    public AudioClip levelUpClip;
    public AudioClip enemyAtkClip;
    public AudioClip magicalAtkClip;

    public AudioClip doubleSlash;
    public AudioClip sonicSlash;


    public AudioClip positiveClip,negativeClip, craftClip1, craftClip2, saleClip, undoClip
        , click1Clip, click3Clip,upClip,endClip,jemDropClip,rareEnemyClip;

    public void PlaySound(AudioClip Clip)
    {
        if (main.S.seSliderValue > 0)
        {
            //playClip(Clip);
            if (main.SoundEffectSource.isPlaying == false) // 音が重ならないためのif文
            {
                main.SoundEffectSource.PlayOneShot(Clip);
            }
        }
    }
    public void MustPlaySound(AudioClip Clip)
    {
        if(main.S.seSliderValue > 0)
        {
            main.SoundEffectSource.PlayOneShot(Clip);
        }
    }

    /// <summary>
    /// Vol : 0.0f ~ 1.0f
    /// </summary>
    public void ChangeSEVolume(float Vol)
    {
        main.SoundEffectSource.volume = Vol;
    }

    /// <summary>
    /// Vol : 0.0f = 1.0f
    /// </summary>
    public void ChangeBGMVolume(float Vol)
    {
        BGMSource.volume = Vol;
    }

	// Use this for initialization
	void Awake () {
		StartBASE();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
