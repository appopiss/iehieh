using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using IdleLibrary;
using System.Linq;
using System;

public class ExpeditionController : MonoBehaviour
{
    [SerializeField] private EXPEDITION[] expeditions;
    [NonSerialized] public OpenClose thisOpenClose;
    [NonSerialized] public int unleashedNumFromQuest;
    public Sprite[] monsterSprites1, monsterSprites2;
    public void OfflineBonus(float timeSec)
    {
        for (int i = 0; i < expeditions.Length; i++)
        {
            if (expeditions[i].expedition.IsStarted())
            {
                expeditions[i].expedition.IncreaseCurrentTime(timeSec);
            }
        }
    }
    int UnleashedNum()
    {
        return unleashedNumFromQuest;
    }
    public void UpdateUnleashExpedition()
    {
        for (int i = 0; i < expeditions.Length; i++)
        {
            if (i < UnleashedNum()) expeditions[i].thisCanvas.enabled = true;
            else expeditions[i].thisCanvas.enabled = false;
        }
    }
    private void Awake()
    {
        thisOpenClose = gameObject.GetComponent<OpenClose>();
        thisOpenClose.openAction += UpdateUnleashExpedition;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (thisOpenClose.isOpen)
            expeditions.ToList().ForEach((x) => x.UpdateUI());
        
    }
}
