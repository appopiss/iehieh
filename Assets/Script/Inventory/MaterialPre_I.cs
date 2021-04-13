using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using static UsefulMethod;
using static ArtiCtrl.MaterialList;
using TMPro;

public class MaterialPre_I : BASE {
    public enum materialKind
    {
        material,
        consume,

    }
    public ArtiCtrl.MaterialList rscKind;
    public ArtiCtrl.ConsumeItemList itemKind;
    materialKind paraKind;
    TextMeshProUGUI nameText, numText,costText;
    Button sellButton, sellMaxButton;
    public Button button;
    public EnterExitEvent EEEvent;
    public string Name;
    public double sellPrice;
    public string flavorText;
    public int ID;

    public MaterialPre_I StartMaterialInventory(Transform parentTra, ArtiCtrl.MaterialList RscKind,double sellPrice,string text)
    {
        var obj = Instantiate(this, parentTra);
        obj.AwakeMaterial();
        obj.rscKind = RscKind;
        obj.paraKind = materialKind.material;
        obj.sellPrice = sellPrice;
        obj.flavorText = text;
        return obj;
    }

    public MaterialPre_I StartConsumeInventory(Transform parentTra, ArtiCtrl.ConsumeItemList ItemKind,double sellPrice,string text)
    {
        var obj = Instantiate(this, parentTra);
        obj.AwakeMaterial();
        obj.itemKind = ItemKind;
        obj.paraKind = materialKind.consume;
        obj.flavorText = text;
        return obj;
    }

    public void SetEffect(UnityAction action)
    {
        button.gameObject.SetActive(true);
        if (action != null)
        {
            button.onClick.AddListener(action);
        }
    }

    public void UpdateMaterial()
    {
        if(main.GameController.currentCanvas != main.GameController.ArtifactCanvas)
        {
            return;
        }
        LocalizeInitialize.SetFont(nameText);
        switch (paraKind)
        {
            case materialKind.material:
                /* active|false */
                if (main.ArtiCtrl.CurrentMaterial[rscKind]>=1)
                {
                    setActive(gameObject);
                }
                else
                {
                    setFalse(gameObject);
                }
                /* Text */
                nameText.text = (Name == null || Name == "") ? main.ArtiCtrl.ConvertEnum(rscKind) : Name;
                numText.text = "x " + tDigit(main.ArtiCtrl.CurrentMaterial[rscKind]);
                costText.text = "" + tDigit(sellPrice);
                break;
            case materialKind.consume:
                /* active|false */
                if (main.ArtiCtrl.consumeItemNum[(int)itemKind] >= 1)
                {
                    setActive(gameObject);
                }
                else
                {
                    setFalse(gameObject);
                }
                /* Text */
                nameText.text = (Name == null || Name == "") ? itemKind.ToString() : Name;
                numText.text = "x" + tDigit(main.ArtiCtrl.consumeItemNum[(int)itemKind]);
                break;
            default:
                break;
        }
    }

    public void AwakeMaterial()
    {
        StartBASE();

        nameText = GetComponentsInChildren<TextMeshProUGUI>()[0];
        numText = GetComponentsInChildren<TextMeshProUGUI>()[1];
        costText = GetComponentsInChildren<TextMeshProUGUI>()[2];
        sellButton = GetComponentsInChildren<Button>()[0];
        sellMaxButton = GetComponentsInChildren<Button>()[1];

        EEEvent = GetComponent<EnterExitEvent>();
        //EEEvent.RightClickEvent = SellThis;
        EEEvent.EnterEvent = ShowThisText;
        sellButton.onClick.AddListener(SellThis);
        sellMaxButton.onClick.AddListener(SellThisMax);
    }

    public void SellThis()
    {
        if (main.ArtiCtrl.CurrentMaterial[rscKind] == 0)
            return;

       main.ArtiCtrl.CurrentMaterial[rscKind] -= 1;

        double gold = sellPrice;

       double sabun = main.MaxGold() - main.SR.gold;
       if (main.SR.gold + gold >= main.MaxGold())
       {
           main.SR.gold += sabun;
           main.S.TempStoreSlimeCoin +=  gold - sabun;
       }
       else
       {
           main.SR.gold += gold;
       }
    }

    public void ShowThisText()
    {
        main.Texts[30].text = flavorText;
    }

    public void SellThisMax()
    {
        if (main.ArtiCtrl.CurrentMaterial[rscKind] == 0)
            return;

        if (sellPrice == 0)
            return;

        if (main.MaxGold() - main.SR.gold < sellPrice)
            return;

        double goldSabun = main.MaxGold() - main.SR.gold;
        double tempNum = 0;
        int count = 0;
        while(tempNum <= goldSabun && count <= main.ArtiCtrl.CurrentMaterial[rscKind])
        {
            tempNum += sellPrice;
            count++;
        }
        double gold = tempNum;

        double sabun = main.MaxGold() - main.SR.gold;
        if (main.SR.gold + gold >= main.MaxGold())
        {
            main.SR.gold += sabun;
            main.S.TempStoreSlimeCoin += gold - sabun;
        }
        else
        {
            main.SR.gold += gold;
        }
        main.ArtiCtrl.CurrentMaterial[rscKind] = Math.Max(main.ArtiCtrl.CurrentMaterial[rscKind] - count, 0);
    }


}
