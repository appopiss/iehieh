using System.Collections.Generic;
using UnityEngine;

public class ButtonActions : MonoBehaviour
{
    public void Happytime()
    {
        CrazyEvents.Instance.HappyTime();
    }

    public void GameplayStart()
    {
        CrazyEvents.Instance.GameplayStart();
    }

    public void GameplayStop()
    {
        CrazyEvents.Instance.GameplayStop();
    }

    public void InviteLink()
    {
        Dictionary<string, string> parameters = new Dictionary<string, string>();
        parameters.Add("roomId", "1234");
        string inviteLink = CrazyEvents.Instance.InviteLink(parameters);
        Debug.Log("Invite link: " + inviteLink);
        CrazyEvents.Instance.CopyToClipboard(inviteLink);
    }

    public void ParseInviteLink()
    {
        if (CrazyEvents.Instance.IsInviteLink())
        {
            string roomId = CrazyEvents.Instance.GetInviteLinkParameter("roomId");
            if(roomId != null && roomId != "")
            {
                Debug.Log(string.Format("Correct invite url, the roomId is {0}", roomId));
            }
            else
            {
                Debug.Log("Cannot find 'roomId' parameter, try to add '?utm_source=invite&roomId=1234' at the end of the url");
            }
        }
        else
        {
            Debug.Log("Incorrect invite url, try to add '?utm_source=invite&roomId=1234' at the end of the url");
        }
#if (!UNITY_EDITOR)
       
#else
        Debug.Log("Cannot parse url in Unity editor, try running it in a browser");
#endif
    }   
}
