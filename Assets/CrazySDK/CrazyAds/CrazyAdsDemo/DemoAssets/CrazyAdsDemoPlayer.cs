
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class CrazyAdsDemoPlayer : MonoBehaviour
{

    [SerializeField] CrazyAdType adType = CrazyAdType.midgame;

    Vector3 pushForce = Vector3.right * 2;
    Vector3 startPos;
    Rigidbody rb;


    private void Start()
    {
        rb=GetComponent<Rigidbody>();
        startPos=transform.position;
    }


    void FixedUpdate()
    {
        transform.Translate(pushForce*Time.fixedDeltaTime);

        if (transform.position.y < -20) 
        {

            print("Player Died!  Starting Ad Break!");

            if(adType==CrazyAdType.rewarded) CrazyAds.Instance.beginAdBreakRewarded(respawn); 
            else CrazyAds.Instance.beginAdBreak(respawn);
        }

    }


    void respawn()
    {
        print("Ad Finished!  So respawning player!");
        
        transform.position=startPos;
        rb.velocity=Vector3.zero;
    }


}
