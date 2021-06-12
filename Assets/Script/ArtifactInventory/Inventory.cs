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
[Serializable]
public class ArtifactMaterial : NUMBER, IText
{
	[OdinSerialize] private readonly ID id;
    public override double Number { get => main.SO.artifactMaterials[(int)id]; set => main.SO.artifactMaterials[(int)id] = value; }
    public enum ID
    {
		//Tier1
		MysteriousStone,
		MysteriousCrystal,
		MysteriousLeaf,
		//Tier2
		BlessingPowder,
		BlessingShard
    }
	public ArtifactMaterial(int id)
    {
		this.id = (ID)id;
    }
	public string Text() => id switch
	{
		ID.MysteriousStone => "Mysterious Stone",
		ID.MysteriousCrystal => "Mysterious Crystal",
		ID.MysteriousLeaf => "Mysterious Leaf",
		ID.BlessingPowder => "Blessing Powder",
		ID.BlessingShard => "Blessing Shard",
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

	//Material表示
	[SerializeField] TextMeshProUGUI materialText, materialNumberText;
	IText materialShow;
	IText materialNumberShow;

	//StatsBreakdown表示
	public EffectCalculator effectCalculator;

	// Use this for initialization
	void Awake()
	{
		inventoryInfo = new InventoryInfo(new IdleLibrary.Inventory.Inventory(inputItem, ref BASE.main.SO.inventory, 12), canvas, items, item, inputItem);
		equipmentInventoryInfo = new InventoryInfo(new IdleLibrary.Inventory.Inventory(inputItem, ref BASE.main.SO.equipmentInventory, 3), EquipmentCanvas, EquippedItems, item, inputItem);
		inventoryInfo.inventory.extraInventoryNum.RegisterMultiplier(new MultiplierInfo(() => main.rein.SR_upgrades[(int)R_UPGRADE.SR_upgradeID.ArtifactInventory].GetCurrentValue(), MultiplierType.add));
		equipmentInventoryInfo.inventory.extraInventoryNum.RegisterMultiplier(new MultiplierInfo(() => main.rein.R_upgrades[(int)R_UPGRADE.R_upgradeId.ArtifactEquipSlot].GetCurrentValue(), MultiplierType.add));

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
		inventoryInfo.AddLeftAction(new DeleteItemWithConfirm(inventoryInfo.inventory), KeyCode.D);
		inventoryInfo.AddRightaction(new RevertItemToOtherInventory(inventoryInfo.inventory, equipmentInventoryInfo.inventory));
		inventoryInfo.AddLeftAction(new LevelUpArtifact(inventoryInfo.inventory), KeyCode.E);

		//equipmentInventory.AddLeftAction(new SwapItem(equipmentInventory.inventory));
		var swap2 = new StackAndSwapItem(equipmentInventoryInfo.inventory);
		equipmentInventoryInfo.RegisterHoldAction(swap2, new Releaseitem(inputItem), swap2);
		equipmentInventoryInfo.AddRightaction(new RevertItemToOtherInventory(equipmentInventoryInfo.inventory, inventoryInfo.inventory));
		equipmentInventoryInfo.AddLeftAction(new LevelUpArtifact(equipmentInventoryInfo.inventory), KeyCode.E);

		main.SO.tier1chest = main.SO.tier1chest ?? new Chest();
		main.SO.tier2chest = main.SO.tier2chest ?? new Chest();
		main.SO.tier3chest = main.SO.tier3chest ?? new Chest();
		chest1.onClick.AddListener(() => main.SO.tier1chest.OpenChest());
		chest2.onClick.AddListener(() => main.SO.tier2chest.OpenChest());
		chest3.onClick.AddListener(() => main.SO.tier3chest.OpenChest());

		materialShow = new MaterialShowClass();
		materialNumberShow = new ColorText(new MaterialNumberShowClass(), Color.green);

		effectCalculator = new EffectCalculator(equipmentInventoryInfo.inventory);

		ArtifactUpdate();
	}

	private void Update()
	{
		Notify();
		chest1.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = UsefulMethod.tDigit(main.SO.tier1chest.ChestNum);
		chest2.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = UsefulMethod.tDigit(main.SO.tier2chest.ChestNum);
		chest3.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = UsefulMethod.tDigit(main.SO.tier3chest.ChestNum);
	}

	async void ArtifactUpdate()
    {
        while(true){
			await UniTask.Delay(1000, delayType: DelayType.Realtime);
			foreach (var item in equipmentInventoryInfo.inventory.GetItems())
            {
				if (!(item is Artifact)) continue;
				var artifact = item as Artifact;
				artifact.timeManager.UpdatePerSec();
            }
			materialText.text = materialShow.Text();
			materialNumberText.text = materialNumberShow.Text();
			//効果の更新
			effectCalculator.UpdateValue();
        }
    }
}
