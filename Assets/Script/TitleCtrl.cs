using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using UnityEngine.EventSystems;
using static UsefulMethod;
using static BASE;

public class TitleCtrl : BASE, IPointerDownHandler {

    public static bool isLoaded;
    public AudioSource bgm;
    public RectTransform[] ClassImage;
    public Image LogoImage;
    public AudioClip zakoBgm;

    public void OnPointerDown(PointerEventData eventData)
    {
        if(eventData.pointerId == -1)
        {
            StartGame();
        }
    }
    public void StartGame()
    {
        if (!isFirstClicked)
        {
            //if(!isPlayBgm)
            //    bgm.Play();
            bgm.Stop();
            StartCoroutine(MoveImage());
            isLoaded = true;
            isFirstClicked = true;
        }
    }

    bool isFirstClicked;
    // Use this for initialization
    void Awake () {
		StartBASE();
        StartCoroutine(ChangeTitleLogo());
        isFirstClicked = false;
    }

    int jobIndex;
    Image[] CashedClassImage = new Image[3];

	// Use this for initialization
	void Start () {
        CashedClassImage[0] = ClassImage[0].gameObject.GetComponent<Image>();
        CashedClassImage[1] = ClassImage[1].gameObject.GetComponent<Image>();
        CashedClassImage[2] = ClassImage[2].gameObject.GetComponent<Image>();
    }

    //public RuntimeAnimatorController warrior;
    //public GameObject warriorPrefab;

    Vector2 X = new Vector2(1, 0);
    Vector2 Y = new Vector2(0, 1);
    Color clear = new Color(0, 0, 0, 1);
    IEnumerator MoveImage()
    {
        //yield return new WaitForSeconds(0.5f);
        main.sound.MustPlaySound(main.sound.magicalAtkClip);

        //warriorPrefab.GetComponent<Animator>().runtimeAnimatorController = warrior;
        
        for (int i = 0; i < 10; i++)
        {
            ClassImage[0].anchoredPosition += X * 41f;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(0.1f);
        main.sound.MustPlaySound(main.sound.magicalAtkClip);
        for (int i = 0; i < 10; i++)
        {
            ClassImage[1].anchoredPosition -= X * 41f;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(0.1f);
        //ClassImage[2].anchoredPosition += Y * 760;
        main.sound.MustPlaySound(main.sound.magicalAtkClip);
        for (int i = 0; i < 10; i++)
        {
            ClassImage[2].anchoredPosition += Y * 34;
            yield return new WaitForSeconds(0.01f);
        }
        setActive(ClassImage[3].gameObject);
        setActive(ClassImage[4].gameObject);
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 30; i++)
        {
            CashedClassImage[0].color -= clear / 30f;
            CashedClassImage[1].color -= clear / 30f;
            CashedClassImage[2].color -= clear / 30f;
            yield return new WaitForSeconds(0.0166f);
        }
        yield return new WaitForSeconds(0.5f);

        Destroy(ClassImage[0].gameObject);
        Destroy(ClassImage[1].gameObject);
        Destroy(ClassImage[2].gameObject);
        Destroy(ClassImage[3].gameObject);
        Destroy(ClassImage[4].gameObject);
        bgm.clip = zakoBgm;
        bgm.Play();

        //isPlayBgm = true;
        if (main.GameController.isJobbed)
            main.dungeonAry[(int)main.GameController.currentDungeon].TryDungeon();
        main.ally.currentHp = main.ally.HP();
        isFirstClicked = false;
        if (main.platform == Platform.crazygames)
        {
            setActive(main.LinkCanvas);
            setActive(main.openAdsButton);
        }
        Destroy(gameObject);
    }

    IEnumerator ChangeTitleLogo()
    {
            for (int i = 0; i < 60; i++)
            {
                LogoImage.color -= clear / 60f;
                yield return new WaitForSeconds(0.1f);
            }
        while (true)
        {
            for (int i = 0; i < 5; i++)
            {
                text.color += clear / 5f;
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(0.25f);
            for (int i = 0; i < 5; i++)
            {
                text.color -= clear / 5f;
                yield return new WaitForSeconds(0.1f);
            }
        }

    }
    public TextMeshProUGUI text;

    bool isPlayBgm;
    // Update is called once per frame
    void Update () {
		
	}
}
