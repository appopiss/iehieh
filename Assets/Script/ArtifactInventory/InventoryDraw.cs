using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Cysharp.Threading.Tasks;
using UniRx.Triggers;
using UniRx;
using System;
using IdleLibrary.UI;
using IdleLibrary;
using IdleLibrary.Inventory;

public class InventoryDraw : MonoBehaviour, IObserver
{
    public Sprite[] sprites;
    //public Sprite defaultSprite;
    public Sprite lockedSprite;
    public Transform MouseImageCanvas;
    GameObject _itemIconWithMouse;
    bool isPopUpInitialized;
    [SerializeField] Popup_UI pop, statsBreakdownPop;
    [SerializeField] GameObject mouseImagePre;
    [SerializeField] GameObject StatsBreakdownIcon;

    void Awake()
    {
        GameObject.FindObjectsOfType<Subject>().ToList().ForEach(x => x.Attach(this));
    }

    //itemの状態を更新します。
    public void _Update(ISubject subject)
    {
        if (subject is Inventory)
        {
            var inventory_mono = subject as Inventory;
            var input = inventory_mono.input;

            //ポップアップの設定

            if (!isPopUpInitialized)
            {
                new Popup(() => input.hoveredInventory != null && input.hoveredInventory.GetItem(input.cursorId).isSet, pop.gameObject);
                pop.UpdateAsObservable().Where(_ => pop.gameObject.activeSelf).Subscribe(_ =>
                {
                    if (!input.hoveredInventory.GetItem(input.cursorId).isSet) return;
                    pop.UpdateUI(
                        IdleLibrary.UI.LocationKind.Corner,
                        input.hoveredInventory.GetItem(input.cursorId),
                        sprites[input.hoveredInventory.GetItem(input.cursorId).id]);
                });

                new Popup(StatsBreakdownIcon, statsBreakdownPop.gameObject);
                statsBreakdownPop.UpdateAsObservable().Where(_ => statsBreakdownPop.gameObject.activeSelf).Subscribe(_ =>
                {
                    statsBreakdownPop.UpdateUI(
                        IdleLibrary.UI.LocationKind.MouseFollow,
                        inventory_mono.effectCalculator
                        );
                });


                isPopUpInitialized = true;
            }

            //アイテム画像の更新
            foreach (var info in inventory_mono.UIInfo)
            {
                int index = 0;
                foreach (var item in info.inventory.GetItems())
                {
                    if (index >= info.items.Count) continue;
                    if (item == null) continue;
                    //アイテム画像
                    info.items[index].transform.GetChild(0).GetComponent<Image>().sprite = item.isSet ? sprites[item.id] : lockedSprite;
                    info.items[index].transform.GetChild(1).gameObject.SetActive(item.isLocked);
                    index++;
                }
            }

            //マウスにくっつくウインドウの設定(後々柔軟に変えられるようにしたい)
            if (_itemIconWithMouse == null)
            {
                _itemIconWithMouse = Instantiate(mouseImagePre, MouseImageCanvas);
                _itemIconWithMouse.GetOrAddComponent<ObservableEventTrigger>().OnPointerUpAsObservable().Subscribe(_ =>
                {
                    _itemIconWithMouse.SetActive(false);
                });
                _itemIconWithMouse.GetComponent<Image>().raycastTarget = false;
                _itemIconWithMouse.transform.GetChild(0).GetComponent<Image>().raycastTarget = false;
            }
            if (input.inputItem.id == -1)
            {
                _itemIconWithMouse.SetActive(false);
            }
            else
            {
                _itemIconWithMouse.SetActive(true);
                _itemIconWithMouse.transform.GetChild(0).GetComponent<Image>().sprite = sprites[input.inputItem.id];
                _itemIconWithMouse.transform.position = Input.mousePosition;
                if (Input.GetMouseButtonUp(0))
                {
                    input.ReleaseItem();
                }
            }
        }
    }
}
