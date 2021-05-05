using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static UsefulMethod;
using UnityEngine.SceneManagement;


public class ZoneCtrl : BASE {

    public GameObject currentCanvas;
    public Transform ZoneSelectCanvas;
    public Transform[] ZoneCanvas;
    public Transform[] ZoneChangeCanvas;
    public Button[] ZoneButton;

    public ENEMY[] EnemyAry;

    public ENEMY[] Slime;
    public ENEMY[] Bat;
    public ENEMY[] Fairy;
    public ENEMY[] Spider;
    public ENEMY[] Fox;
    public ENEMY[] NineTail;
    public ENEMY[] DevilFish;
    public ENEMY[] Blob;

    public Sprite[] SlimeZone;
    public Sprite[] BatZone;
    public Sprite[] FairyZone;
    public Sprite[] SpiderZone;
    public Sprite[] FoxZone;
    public Sprite[] MSlimeZone;
    public Sprite[] DevilFishZone;
    public Sprite[] BlobZone;

    public DUNGEON[] SlimeZoneButton;
    public DUNGEON[] BatZoneButton;
    public DUNGEON[] FairyZoneButton;
    public DUNGEON[] SpiderZoneButton;
    public DUNGEON[] FoxZoneButton;
    public DUNGEON[] MSlimeZoneButton;
    public DUNGEON[] DevilFishZoneButton;
    public DUNGEON[] BlobZoneButton;

    public bool isHidden;
    public Image background;
    public Button hiddenButton;
    public TextMeshProUGUI hiddenText;

    public void ActivateHidden()
    {
        if (main.S.isUnleashedHidden)
        {
            setActive(hiddenButton.gameObject);
            main.MissionMileStoneHidden.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(250, -45);
        }
        else
        {
            setFalse(hiddenButton.gameObject);
            main.MissionMileStoneHidden.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(-800, -45);
        }
    }
    void ConfirmWarp()
    {
        if (!isHidden)
        {
            GameObject confirm = Instantiate(main.P_texts[40], main.DeathShowCanvas);
            confirm.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = "Are you sure to warp into the hidden areas?\n\nHidden Area is a kind of parallel world, where much stronger monsters spawn. If you continue, it will bring you back to the title screen once and warp you to the hidden areas. You can also freely return to the normal areas through this button.";
            confirm.transform.GetChild(2).gameObject.GetComponent<Button>().onClick.AddListener(() => Destroy(confirm));
            confirm.transform.GetChild(3).gameObject.GetComponent<Button>().onClick.AddListener(() => StartCoroutine(ChangeHidden()));
        }
        else
        {
            GameObject confirm = Instantiate(main.P_texts[40], main.DeathShowCanvas);
            string curseCautionText = "";
            if (CURSE_RAIN.IsRoad3()) curseCautionText = "\n <color=red>Caution </color=red>\nThe current curse will be failed if you do this.";
            confirm.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = "Are you sure to warp into the normal areas?\n\n If you continue, it will bring you back to the title screen once and warp you to the normal areas. You can also freely warp to the hidden areas through this button." + curseCautionText;
            confirm.transform.GetChild(2).gameObject.GetComponent<Button>().onClick.AddListener(() => Destroy(confirm));
            confirm.transform.GetChild(3).gameObject.GetComponent<Button>().onClick.AddListener(() => StartCoroutine(ChangeHidden()));
        }
    }


    void ChangeUI()
    {
        if (isHidden)
        {
            background.color = Color.magenta;
            hiddenText.text = "Normal";
        }
        else
        {
            background.color = Color.green;
            hiddenText.text = "Hidden";
        }
    }
    IEnumerator ChangeHidden()
    {
        hiddenButton.interactable = false;
        Time.timeScale = 0;

        if (main.S.isHidden)
            main.S.isHidden = false;
        else
            main.S.isHidden = true;
        main.saveCtrl.setSaveKey();
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("main");
        //SlimeZoneButton[0].PrepareDungeon();
        //ChangeUI();
        //for (int i = 0; i < SlimeZoneButton.Length; i++)
        //{
        //    SlimeZoneButton[i].ChangeTextColor();
        //}
        //for (int i = 0; i < BatZoneButton.Length; i++)
        //{
        //    BatZoneButton[i].ChangeTextColor();
        //}
        //for (int i = 0; i < FairyZoneButton.Length; i++)
        //{
        //    FairyZoneButton[i].ChangeTextColor();
        //}
        //for (int i = 0; i < SpiderZoneButton.Length; i++)
        //{
        //    SpiderZoneButton[i].ChangeTextColor();
        //}
        //for (int i = 0; i < FoxZoneButton.Length; i++)
        //{
        //    FoxZoneButton[i].ChangeTextColor();
        //}
        //for (int i = 0; i < MSlimeZoneButton.Length; i++)
        //{
        //    MSlimeZoneButton[i].ChangeTextColor();
        //}
        //for (int i = 0; i < DevilFishZoneButton.Length; i++)
        //{
        //    DevilFishZoneButton[i].ChangeTextColor();
        //}
        //for (int i = 0; i < BlobZoneButton.Length; i++)
        //{
        //    BlobZoneButton[i].ChangeTextColor();
        //}

        //hiddenButton.interactable = true;
    }

    // Use this for initialization
    void Awake () {
		StartBASE();
        //ここの順番は絶対に変えない
        isHidden = main.S.isHidden;

        currentCanvas = ZoneChangeCanvas[0].gameObject;
        for (int i = 0; i < ZoneChangeCanvas.Length; i++)
        {
            int count = i;
            ZoneButton[count].onClick.AddListener(() => setSibling(count));
        }
        ActivateHidden();
        hiddenButton.onClick.AddListener(ConfirmWarp);
        ChangeUI();
    }

	// Use this for initialization
	void Start () {

    }

    public void setSibling(int count)
    {
        if(currentCanvas == ZoneChangeCanvas[count])
        {
            return;
        }
        else
        {
            currentCanvas.GetComponent<RectTransform>().anchoredPosition += new Vector2(-500,0);
            ZoneChangeCanvas[count].GetComponent<RectTransform>().anchoredPosition += new Vector2(500,0);
            currentCanvas = ZoneChangeCanvas[count].gameObject;
        }
    }
	
	// Update is called once per frame
	void Update () {
	}



}
