using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class InventoryController : BaseController, IInventoryController
{
    private readonly IInventoryModel _inventoryModel;
    private readonly IItemsRepository _itemsRepository;
    private readonly IInventoryView _inventoryWindowView;

    public InventoryController(
        [NotNull] IInventoryModel inventoryModel,
        [NotNull] IItemsRepository itemsRepository,
        [NotNull] IInventoryView inventoryView)
    {
        _inventoryModel
            = inventoryModel ?? throw new ArgumentNullException(nameof(inventoryModel));
        _itemsRepository
            = itemsRepository ?? throw new ArgumentNullException(nameof(itemsRepository));
        _inventoryWindowView
            = inventoryView ?? throw new ArgumentNullException(nameof(inventoryView));
    }

    public InventoryController(InventoryModel inventoryModel, ItemsRepository upgradeItemsRepository)
    {
        Debug.Log("Input Inventory");
    }

    public InventoryController(List<ItemConfig> itemConfigs)
    {
        _inventoryModel = new InventoryModel();
        _itemsRepository = new ItemsRepository(itemConfigs);
        _inventoryWindowView = new InventoryView();

    }
    public void ShowInventory(Action callback)
    {
        throw new NotImplementedException();
    }
    public void ShowInventory()
    {
        foreach (var item in _itemsRepository.Items.Values)
        {
            _inventoryModel.EquipItem(item);

            var equippedItems = _inventoryModel.GetEquippedItems();
            _inventoryWindowView.Display(equippedItems);
        }
    }
    public void HideInventory()
    {
        throw new NotImplementedException();
    }
}