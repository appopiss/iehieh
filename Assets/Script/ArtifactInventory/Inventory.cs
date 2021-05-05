using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UniRx;
using UniRx.Triggers;
using Cysharp.Threading.Tasks;
using System.Linq;
using IdleLibrary.Inventory;
using IdleLibrary;
using static BASE;

public partial class Save
{
	public IdleLibrary.Inventory.InventoryForSave inventory, equipmentInventory;
}

public class Inventory : Subject
{
	public GameObject item;
	public TextMeshProUGUI inventoryItemInfoText;

	public Transform canvas;
	[NonSerialized]
	public List<GameObject> items = new List<GameObject>();

	public Transform EquipmentCanvas;
	[NonSerialized]
	public List<GameObject> EquippedItems = new List<GameObject>();

	public List<InventoryInfo> UIInfoList = new List<InventoryInfo>();
	public InputItem inputItem = new InputItem();

	public InventoryInfo inventory;
	public InventoryInfo equipmentInventory;

	// Use this for initialization
	void Awake()
	{
		inventory = new InventoryInfo(new IdleLibrary.Inventory.Inventory(inputItem, main.S.inventory), canvas, items, item, inputItem);
		equipmentInventory = new InventoryInfo(new IdleLibrary.Inventory.Inventory(inputItem, main.S.equipmentInventory), EquipmentCanvas, EquippedItems, item, inputItem);

		//UIと紐づける
		UIInfoList.Add(inventory);
		UIInfoList.Add(equipmentInventory);

		//アクションを設定
		//inventory.AddLeftAction(new SwapItem(inventory.inventory));
		//クリックじゃなくてドラッグアンドドロップにもできる
		var swap = new SwapItem(inventory.inventory, inputItem);
		inventory.RegisterHoldAction(swap, new Releaseitem(inputItem), swap);
		//inventory.AddLeftAction(new ShowInfoToTextField(inventory.inventory, inventoryItemInfoText));
		inventory.AddLeftAction(new LockItem(inventory.inventory), KeyCode.L);
		inventory.AddLeftAction(new DeleteItem(inventory.inventory), KeyCode.D);
		inventory.AddRightaction(new RevertItemToOtherInventory(inventory.inventory, equipmentInventory.inventory));

		//equipmentInventory.AddLeftAction(new SwapItem(equipmentInventory.inventory));
		var swap2 = new SwapItem(equipmentInventory.inventory, inputItem);
		equipmentInventory.RegisterHoldAction(swap2, new Releaseitem(inputItem), swap2);
		equipmentInventory.AddRightaction(new RevertItemToOtherInventory(equipmentInventory.inventory, inventory.inventory));

		//Canvasの外に出たらcursorIdを-1にする
		//canvas.gameObject.GetOrAddComponent<ObservableEventTrigger>().OnPointerExitAsObservable()
		//	.Subscribe(_ => inputItem.cursorId = -1);

		SaveInventory();
		Notify();
	}

	private async void SaveInventory()
	{
		while (true)
		{
			main.S.inventory = inventory.inventory.saveData;
			main.S.equipmentInventory = equipmentInventory.inventory.saveData;
			await UniTask.DelayFrame(60);
		}
	}
	private void Update()
	{
		Notify();
		if (Input.GetMouseButtonDown(1))
		{
			inputItem.ReleaseItem();
		}
		if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
		{
			Notify();
		}
	}
}
