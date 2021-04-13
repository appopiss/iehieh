using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class BuyKreds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(Purchase);
        gameObject.name = "Kred";
        ItemRequest();
    }

    public void OnPurchaseResult(string success)
    {
        if(success == "true")
        {
           // Debug.Log("買えたよ");
            ItemRequest();
            
        }
        else
        {
           // Debug.Log("買えなかったよ");
        }
    }

    public void Purchase()
    {
        //Debug.Log("とりあえずボタンにはついてるよ");
        Application.ExternalEval(@"
             kongregate.mtx.purchaseItems(['Kred'], function(result) {
             var unityObject = kongregateUnitySupport.getUnityObject();
             var success = String(result.success);
             unityObject.SendMessage('Kred','OnPurchaseResult', success);
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
                            item.id + ',' + item.data);
                if(item.identifier == 'Kred'){
                kongregate.mtx.useItemInstance(item.id, onUseResult);
                break;
                        }
                   }
                }
                
          })

        function onUseResult(result) {
                console.log('Item use result successful: ' + result.success);
                var unityObject = kongregateUnitySupport.getUnityObject();
                   var success = String(result.success);
                 unityObject.SendMessage('Kred','Use',success);
}

        ");                   
    }

    public void Use(string success)
    {
        if(success == "true")
        {
           // Debug.Log("購入成功したよ");
        }
        else if(success == "false")
        {
           // Debug.Log("購入失敗したよ");
        }
    }

}
