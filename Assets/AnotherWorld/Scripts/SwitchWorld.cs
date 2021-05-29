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
            mainCanvasScaler.referenceResolution = new Vector2(960, 540);
            mainCanvasScaler.gameObject.GetComponent<AutoCanvasScaler>().width = 960;
            mainCanvasScaler.gameObject.GetComponent<AutoCanvasScaler>().height = 540;
            Screen.SetResolution(Screen.width, (int)(Screen.width * (9f / 16)), Screen.fullScreen);
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
            Screen.SetResolution(Screen.width, (int)(Screen.width * (3f / 4)), Screen.fullScreen);
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
