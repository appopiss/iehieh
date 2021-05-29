using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Another;
using static UsefulMethod;
using static Another.Main;

namespace Another
{    
    public class SwitchWorld : MonoBehaviour
    {
        public static bool isAnotherWorld;
        public Button toAnotherWorldButton, toNormalWorldButton;
        public CanvasScaler mainCanvasScaler;
        public CanvasGroup normalCanvas, anotherCanvas;
        void SwitchToAnotherWorld()
        {
            //mainCanvasScaler.referenceResolution = new Vector2(960, 540);
            mainCanvasScaler.referenceResolution = new Vector2(1067, 600);
            //mainCanvasScaler.gameObject.GetComponent<AutoCanvasScaler>().width = 960;
            //mainCanvasScaler.gameObject.GetComponent<AutoCanvasScaler>().height = 540;
            mainCanvasScaler.gameObject.GetComponent<AutoCanvasScaler>().width = 1067;
            mainCanvasScaler.gameObject.GetComponent<AutoCanvasScaler>().height = 600;
            Screen.SetResolution((int)(Screen.height * (16 / 9f)), Screen.height, Screen.fullScreen);
            anotherCanvas.alpha = 1;
            anotherCanvas.interactable = true;
            anotherCanvas.blocksRaycasts = true;
            normalCanvas.alpha = 0;
            normalCanvas.interactable = false;
            normalCanvas.blocksRaycasts = false;
            BASE.main.dungeonAry[0].gameObject.GetComponent<Button>().onClick.Invoke();
            isAnotherWorld = true;
        }
        void SwitchToNormalWorld()
        {
            mainCanvasScaler.referenceResolution = new Vector2(800, 600);
            mainCanvasScaler.gameObject.GetComponent<AutoCanvasScaler>().width = 800;
            mainCanvasScaler.gameObject.GetComponent<AutoCanvasScaler>().height = 600;
            Screen.SetResolution((int)(Screen.height * (16 / 9f)), Screen.height, Screen.fullScreen);
            normalCanvas.alpha = 1;
            normalCanvas.interactable = true;
            normalCanvas.blocksRaycasts = true;
            anotherCanvas.alpha = 0;
            anotherCanvas.interactable = false;
            anotherCanvas.blocksRaycasts = false;
            isAnotherWorld = false;
        }
        // Start is called before the first frame update
        void Start()
        {
            toAnotherWorldButton.onClick.AddListener(SwitchToAnotherWorld);
            toNormalWorldButton.onClick.AddListener(SwitchToNormalWorld);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
