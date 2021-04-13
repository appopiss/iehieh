using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//API_Identifierは小文字のみが好ましい。アンダーバーは使用可能
public class KredsTemplate : BASE
{
    public Action purchase_success_action;
    public Action purchase_failed_action;
    public Action use_success_action;
    public Action use_failed_action;
    string API_Identifier;

    //ButtonにAddComponentした後に呼ぶ
    public void Initialize(string identifier,
        Action purchase_success_action, Action purchase_failed_action,
        Action use_success_action, Action use_failed_action)
    {
        this.API_Identifier = identifier;
        this.purchase_success_action = purchase_success_action;
        this.purchase_failed_action = purchase_failed_action;
        this.use_success_action = use_success_action;
        this.use_failed_action = use_failed_action;

        gameObject.name = API_Identifier;
        gameObject.GetComponent<Button>().onClick.AddListener(Purchase);
        ItemRequest();
    }

    private void Awake()
    {
        StartBASE();
    }

    //Purchase()で呼ばれる
    public void OnPurchaseResult(string success)
    {
        if (success == "true")
        {
            purchase_success_action?.Invoke();
            ItemRequest();

        }
        else
        {
            purchase_failed_action?.Invoke();
        }
    }

    public void Purchase()
    {
        Application.ExternalEval(@"
             kongregate.mtx.purchaseItems(['" + API_Identifier + @"'], function(result) {
             var unityObject = kongregateUnitySupport.getUnityObject();
             var success = String(result.success);
             unityObject.SendMessage('" + API_Identifier + @"','OnPurchaseResult', success);
            });
        ");

    }

    public void ItemRequest()
    {
        Application.ExternalEval(@"
        kongregate.mtx.requestUserItemList(null , function(result) {
            console.log('User item list received, success: ' + result.success);
            var unityObject = kongregateUnitySupport.getUnityObject();
                if (result.success)
                {
                  for (var i = 0; i < result.data.length; i++)
                  {
                    var item = result.data[i];
                    console.log((i + 1) + '. ' + item.identifier + ', ' +
                                item.id + ',' + item.data + ', ' + item.remaining_uses);
                    if(item.identifier == '" + API_Identifier + @"'){
                        if(item.remaining_uses == null){
                            unityObject.SendMessage('" + API_Identifier + @"','UseItem', 'true');
                        }else{
                            kongregate.mtx.useItemInstance(item.id, onUseResult);
                        }
                        break;
                    }
                }
            }
        })

        function onUseResult(result) {
                console.log('Item use result successful: ' + result.success);
                var unityObject = kongregateUnitySupport.getUnityObject();
                   var success = String(result.success);
                 unityObject.SendMessage('" + API_Identifier + @"','UseItem',success);
}

        ");
    }

    //上のonUseResultで呼ばれる
    public void UseItem(string success)
    {
        if (success == "true")
        {
            use_success_action?.Invoke();
        }
        else if (success == "false")
        {
            use_failed_action?.Invoke();
        }
    }
}
