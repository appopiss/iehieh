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
	public Chest tier1chest, tier2chest, tier3chest;
	public double[] artifactMaterials;
}

//新しい素材...
public class ArtifactMaterial : NUMBER, IText
{
	private readonly ID id;
    public override double Number { get => main.SO.artifactMaterials[(int)id]; set => main.SO.artifactMaterials[(int)id] = value; }
    public enum ID
    {
		//Tier1
		MysteriousStone,
		BlessingPowder
    }
	public ArtifactMaterial(int id)
    {
		this.id = (ID)id;
    }
	public string Text() => id switch
	{
		ID.MysteriousStone => "Mysterious Stone",
		ID.BlessingPowder => "Blessing Powder",
		_ => ""
	};
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

	//宝箱
	[SerializeField] Button chest1, chest2, chest3;



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

		main.SO.tier1chest = main.SO.tier1chest ?? new Chest();
		main.SO.tier2chest = main.SO.tier2chest ?? new Chest();
		main.SO.tier3chest = main.SO.tier3chest ?? new Chest();
		chest1.onClick.AddListener(() => main.SO.tier1chest.OpenChest());
		chest1.onClick.AddListener(() => main.SO.tier2chest.OpenChest());
		chest1.onClick.AddListener(() => main.SO.tier3chest.OpenChest());
	}

	private void Update()
	{
		Notify();
	}
}
