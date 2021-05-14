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
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using static BASE;

public partial class SaveO
{
	public IdleLibrary.Inventory.InventoryForSave inventory, equipmentInventory;
}

public class Inventory : Subject, IInventoryUIInfo
{
	public GameObject item;
	public Transform canvas;
	[NonSerialized]
	public List<GameObject> items = new List<GameObject>();

	public Transform EquipmentCanvas;
	[NonSerialized]
	public List<GameObject> EquippedItems = new List<GameObject>();

    List<InventoryInfo> UIInfoList = new List<InventoryInfo>();
    InputItem inputItem = new InputItem();
	public InputItem input => inputItem;
	public IEnumerable<InventoryInfo> UIInfo => UIInfoList;

	public InventoryInfo inventoryInfo;
	public InventoryInfo equipmentInventoryInfo;


	// Use this for initialization
	void Awake()
	{
		inventoryInfo = new InventoryInfo(new IdleLibrary.Inventory.Inventory(inputItem, ref BASE.main.SO.inventory, 10), canvas, items, item, inputItem);
		equipmentInventoryInfo = new InventoryInfo(new IdleLibrary.Inventory.Inventory(inputItem, ref BASE.main.SO.equipmentInventory, 10), EquipmentCanvas, EquippedItems, item, inputItem);

		//UIと紐づける
		UIInfoList.Add(inventoryInfo);
		UIInfoList.Add(equipmentInventoryInfo);

		//アクションを設定
		//inventory.AddLeftAction(new SwapItem(inventory.inventory));
		//クリックじゃなくてドラッグアンドドロップにもできる
		var swap = new StackAndSwapItem(inventoryInfo.inventory);
		inventoryInfo.RegisterHoldAction(swap, new Releaseitem(inputItem), swap);
		//inventory.AddLeftAction(new ShowInfoToTextField(inventory.inventory, inventoryItemInfoText));
		inventoryInfo.AddLeftAction(new LockItem(inventoryInfo.inventory), KeyCode.L);
		inventoryInfo.AddLeftAction(new DeleteItem(inventoryInfo.inventory), KeyCode.D);
		inventoryInfo.AddRightaction(new RevertItemToOtherInventory(inventoryInfo.inventory, equipmentInventoryInfo.inventory));

		//equipmentInventory.AddLeftAction(new SwapItem(equipmentInventory.inventory));
		var swap2 = new StackAndSwapItem(equipmentInventoryInfo.inventory);
		equipmentInventoryInfo.RegisterHoldAction(swap2, new Releaseitem(inputItem), swap2);
		equipmentInventoryInfo.AddRightaction(new RevertItemToOtherInventory(equipmentInventoryInfo.inventory, inventoryInfo.inventory));

		Notify();
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
