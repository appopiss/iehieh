using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using System.Runtime.InteropServices;
using static BASE;

public class AGIUnity : MonoBehaviour
{

	// This is the AGIUnity class. The purpose of this class is to make all the calls to the main JS AGI library. Feel free to make changes to or add to the functions in the AGIUnity region as you so need.
	// Especially the contents of functions with data such as SetUsername to use data elsewhere instead of throwing the data to the output textbox. This was the method used for the examples only.

	// All of the external links to JS functions are made in the region

	#region JSLibLinks

	[DllImport ("__Internal")]
	public static extern bool HasAGI ();

	[DllImport ("__Internal")]
	public static extern bool GetAGI ();

	[DllImport ("__Internal")]
	public static extern void GetUser ();

	[DllImport ("__Internal")]
	public static extern void SaveGame (string key, int data);

	[DllImport ("__Internal")]
	public static extern void LoadGame (string key);

	[DllImport ("__Internal")]
	public static extern void EraseGame (string key);

	[DllImport ("__Internal")]
	public static extern void IncrementGame (string key, int data);

	[DllImport ("__Internal")]
	public static extern void DecrementGame (string key, int data);

	[DllImport ("__Internal")]
	public static extern void GetQuests ();

	[DllImport ("__Internal")]
	public static extern void SubmitQuest (string id, float progress);

	[DllImport ("__Internal")]
	public static extern void ResetQuest (string id);

    /*
	[DllImport ("__Internal")]
	public static extern void ShowStorefront ();
    */

	[DllImport("__Internal")]
	public static extern void ShowStorefront(string sku);

	[DllImport ("__Internal")]
	public static extern void RetrievePurchases ();

	[DllImport ("__Internal")]
	public static extern void ConsumePurchase (string k, int q);

	[DllImport ("__Internal")]
	public static extern void OpenPage (string url);

    //買い物する時はこちらを使う
    public static void ShowStore(string sku)
    {
        if (!HasAGI())
        {
			instance.InstantiateConfirmWindow();
        }
        else
        {
			ShowStorefront(sku);
        }
    }

	#endregion

	#region AGIUnity

	public Text output;
	// This is a text output you can use for debugging for this example.
	public RawImage avatar;
	// Set the image you'd like to display a user avatar in here for this example.

	private static AGIUnity instance;
    // Singleton

    //WindowPrefab
    public GameObject ConfirmWindow;
	public Transform KredsCanvas;

	// Initialising the AGI. This is a singleton class and should not be destroyed on load to preserve data between scenes.
	private void Start ()
	{
		if (instance != null) {
			Destroy (gameObject);   
			return;
		}
		instance = this;
		DontDestroyOnLoad (gameObject);
		GetAGI();
		RetrievePurchases();
	}

	// Called from the AGI connection in JS. Dev could store username if desired.
	void SetUsername (string u)
	{
		output.text = u;
	}

	// Called from the AGI connection in JS. Dev could store UID if desired.
	void SetUID (string u)
	{
		// Store/use UID if desired
	}

	// Used when the Avatar link is received
	void SetAvatar (string a)
	{
		StartCoroutine ("GetAvatar", a);
	}

	// A coroutine to display the user's Avatar after it has loaded in
	IEnumerator GetAvatar (string a)
	{
		UnityWebRequest www = UnityWebRequestTexture.GetTexture (a);
		yield return www.SendWebRequest ();
		avatar.texture = DownloadHandlerTexture.GetContent (www);
		avatar.gameObject.SetActive (true);
	}

	// Ask the AGI to save the data value with the key's name
	public static void SaveData (string key, int data)
	{
		SaveGame (key, data);
	}

	// When a score is successfully saved
	void SaveSuccessful (string key)
	{
		output.text = key + " saved.";
	}

	// If the AGI fails to save a score
	void SaveFailed (string key)
	{
		output.text = key + " failed to save.";
	}

	// Used when a score is loaded. Details are in one string split by a & symbol.
	void SaveLoaded (string data)
	{
		string[] dataSplit = data.Split ('&');
		output.text = "Loaded: " + dataSplit [0] + " with value of " + dataSplit [1];
	}

	// When a score is successfully erased
	void EraseSuccessful (string key)
	{
		output.text = key + " erased.";
	}

	// If the AGI fails to delete a save
	void EraseFailed (string key)
	{
		output.text = key + " failed to erase.";
	}

	// When a score is successfully incremented. Details are in one string split by a & symbol.
	void IncrementSuccessful (string key)
	{
		string[] keySplit = key.Split ('&');
		output.text = keySplit [0] + " incremented to " + keySplit [1];
	}

	// If the AGI fails to increment a save
	void IncrementFailed (string key)
	{
		output.text = key + " failed to increment.";
	}

	// When a score is successfully decremented. Details are in one string split by a & symbol.
	void DecrementSuccessful (string key)
	{
		string[] keySplit = key.Split ('&');
		output.text = keySplit [0] + " decremented to " + keySplit [1];
	}

	// If the AGI fails to decrement a save
	void DecrementFailed (string key)
	{
		output.text = key + " failed to decrement.";
	}

	// Used when retrieving all consumables. Details are in one string split by a & symbol.
	void RetrievedConsumable (string product)
	{
		string[] productSplit = product.Split ('&');
		output.text = output.text + "\n" + productSplit [0] + " total quantity: " + productSplit [1];
	}

	// Used when a consumable purchase has been made (purchase amount may not match item's total)
	// Details are in one string split by a & symbol.
	void PurchasedConsumable (string product)
	{
		string[] productSplit = product.Split ('&');
		//ここに購入した商品を書いていく？
        //買った瞬間一個消費する！
		//ConsumePurchase(productSplit[0], 1);
        switch (productSplit[0])        
        {
			case "ieh-500_epic_coin:1":
				main.S.EC1 += 1;
				break;
			case "ieh-1050_epic_coin:1":
				main.S.EC2 += 1;
				break;
			case "ieh-2650_epic_coin:1":
				main.S.EC3 += 1;
				break;
			case "ieh-5500_epic_coin:1":
				main.S.EC4 += 1;
				break;
			case "ieh-12000_epic_coin:1":
				main.S.EC5 += 1;
				break;
			case "ieh-18500_epic_coin:1":
				main.S.EC6 += 1;
				break;
			case "ieh-31000_epic_coin:1":
				main.S.EC7 += 1;
				break;
			case "ieh-70000_epic_coin:1":
				main.S.EC8 += 1;
				break;

			case "ieh-500_epic_coin_x2:1":
				main.S.ECF1 += 1;
				break;
			case "ieh-1050_epic_coin_x2:1":
				main.S.ECF2 += 1;
				break;
			case "ieh-2650_epic_coin_x2:1":
				main.S.ECF3 += 1;
				break;
			case "ieh-5500_epic_coin_x2:1":
				main.S.ECF4 += 1;
				break;
			case "ieh-12000_epic_coin_x2:1":
				main.S.ECF5 += 1;
				break;
			case "ieh-18500_epic_coin_x2:1":
				main.S.ECF6 += 1;
				break;

			case "ieh-starter_bundle:1":
				main.S.ECS1 += 1;
				main.S.GoldCapByKreds += 500;
				main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.MonsterFluid] += 500;
				main.Log("Gained <color=green>Monster Fluid * 500", 5f);
				main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.RedChili] += 10;
				main.Log("Gained <color=green>Red Chili * 10", 5f);
				break;
			case "ieh-global_skill_slot_bundle:1":
				main.S.ECS4 += 1;
				main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.MonsterFluid] += 5000;
				main.Log("Gained <color=green>Monster Fluid * 5000", 5f);
				main.ArtiCtrl.CurrentMaterial[ArtiCtrl.MaterialList.RedChili] += 50;
				main.Log("Gained <color=green>Red Chili * 50", 5f);
				main.skillSetController.UnleashGrobalSkillSlot();
				StartCoroutine(main.InstantiateLogText("Extra Global Skill Slot is Unleashed!", main.TutorialController.iconSpriteAry[3]));
				break;
		}
	}

	// Used when an unlockable product is purchased. Details are in one string split by a & symbol.
	void RetrievedUnlockable (string product)
	{
		string[] productSplit = product.Split ('&');
		output.text = output.text + "\n" + productSplit [0] + " unlock state is: " + productSplit [1];
	}

	// When a consumable object is used successfully. Details are in one string split by a & symbol.
	void ConsumeSuccessful (string key)
	{
		string[] keySplit = key.Split ('&');
		output.text = keySplit [0] + " consumed. Remaining: " + keySplit [1];
	}

	// When a consume failed. This also can cause a browser crash.
	void ConsumeFailed (string key)
	{
		output.text = key + " failed to consume.";
	}

	// When a new user plays the game and has no quest information.
	void NoQuestInfo ()
	{
		// Submit some default quest values.
		SubmitQuest ("easy_quest", 0);
		SubmitQuest ("hard_quest", 0);
	}

	// When a quest is retrieved. Details are in one string split by a & symbol.
	void QuestRetrieved (string quest)
	{
		string[] questSplit = quest.Split ('&');
		output.text = output.text + "\n" + questSplit [0] + " progress: " + questSplit [1];
	}

	// When a quest is successfully reset
	void QuestResetSuccessful (string quest)
	{
		output.text = "Quest: " + quest + " has been reset.";
	}

	// If the AGI fails to reset a quest (not actually implemented in example JSLib file).
	void QuestResetFailed (string quest)
	{
		output.text = "Failed to reset quest: " + quest;
	}

	// When a quest is submitted successfully. Details are in one string split by a & symbol.
	void QuestSubmitSuccessful (string quest)
	{
		string[] questSplit = quest.Split ('&');
		output.text = questSplit [0] + " submitted. Progress: " + questSplit [1];
	}

	// If the AGI fails to submit a quest (not actually implemented in example JSLib file).
	void QuestSubmitFailed (string quest)
	{
		output.text = "Failed to submit quest: " + quest;
	}

    //
    public void InstantiateConfirmWindow()
    {
		 ConfirmWindow = Instantiate(main.cc.ConfirmWindow, KredsCanvas);
    }

    #endregion

}