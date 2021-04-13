using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poisonDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroyPoison());
    }

    IEnumerator destroyPoison()
    {
        yield return new WaitUntil(() => gameObject.transform.parent.gameObject.GetComponent<ENEMY>().isDebuff[(int)Main.Debuff.poison] == false);
        Destroy(gameObject);
    }
}
