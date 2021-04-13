using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;

public class SQUID {

    //PRIVATE MEMBER
    bool isStand;
    EX_state state;
    SquidId id;
    SQUID_UI UI;
    Unlock unlock;
    float currentTime { get => main.S.EX_currentTime[(int)id];  set => main.S.EX_currentTime[(int)id] = value; }
    Hour hour { get => main.S.EX_hour[(int)id]; set => main.S.EX_hour[(int)id] = value; }
    int level { get => main.S.EX_level[(int)id]; set => main.S.EX_level[(int)id] = value; }
    double currentExp { get => main.S.EX_exp[(int)id]; set => main.S.EX_exp[(int)id] = value; }
    double RequiredExp()
    {
        return 100 * Math.Pow(1.35, level);
    }
    float RequiredTime()
    {
        switch (hour)
        {
            case Hour._1H:
                return 60;
            case Hour._4H:
                return 3600 * 4;
            case Hour._8H:
                return 3600 * 8;
            case Hour._24H:
                return 3600 * 24;
        }
        return 3600;
    }
    IEnumerator Progress()
    {
        WaitUntil wait = new WaitUntil(() => state == EX_state.working);
        WaitForSecondsRealtime time = new WaitForSecondsRealtime(0.5f);
        while (true)
        {
            yield return wait;
            currentTime += 0.5f;
            UI.enemyImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(250 * currentTime / RequiredTime(),-10);
            isStand = !isStand;
            ChangeSprite(UI.enemyImage, UI.sprite1, UI.sprite2);
            if(currentTime >= RequiredTime())
            {
                state = EX_state.completed;
            }
            yield return time;
        }
    }

    //PUBLIC MEMBER
    //Constructor
    public SQUID(SquidId id, SQUID_UI UI)
    {
        this.id = id;
        this.UI = UI;
        if(currentTime >= RequiredTime())
        {
            state = EX_state.completed;
        }else if(currentTime > 0)
        {
            state = EX_state.working;
        }
        CoroutineHandler.StartStaticCoroutine(Progress());
    }
    //ExpeditionCtrlからdepartしたときに呼ぶ
    public void Start(Hour hour)
    {
        state = EX_state.working;
        currentTime = 0;
        this.hour = hour;
    }
    //キャンセルしたときに呼ぶ
    public void Initialize()
    {
        currentTime = 0;
        state = EX_state.waiting;
        UI.enemyImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -10);
    }
    //スプライトを変更させる
    public void ChangeSprite(Image image, Sprite sprite1, Sprite sprite2)
    {
        if (state != EX_state.working)
            return;

        image.sprite = null;
        if (isStand)
            image.sprite = sprite1;
        else
            image.sprite = sprite2;
    }
    public void GetReward()
    {
        Initialize();
    }
    //IDの取得
    public SquidId GetId => id;
    public EX_state GetState => state;
    public void Update()
    {
        UI.ChangeExpText(currentExp, RequiredExp());
        UI.ChangeLevelText(level);
        UI.ChangeTimeText(currentTime, RequiredTime());
        UI.ChangeStateText(state);
    }
}
