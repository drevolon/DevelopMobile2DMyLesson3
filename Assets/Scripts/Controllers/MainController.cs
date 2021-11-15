using System.Collections.Generic;
using Controllers;
using Profile;
using UnityEngine;

public class MainController : BaseController
{
    private MainMenuControllerMy _mainMenuController;
    private GameController _gameController;
    private readonly Transform _placeForUi;
    private readonly ProfilePlayer _profilePlayer;
    private InventoryController _inventoryController;

    private InventoryModel _inventoryModel;
    private ItemsRepository _itemsRepository;
    private List<ItemConfig> _itemsConfig;

    public MainController(Transform placeForUi, ProfilePlayer profilePlayer, List<ItemConfig> itemsConfig)
    {
        _profilePlayer = profilePlayer;
        _itemsConfig = itemsConfig;

        _placeForUi = placeForUi;
        OnChangeGameState(_profilePlayer.CurrentState.Value);
        profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
    }

    protected override void OnDispose()
    {
        _mainMenuController?.Dispose();
        _gameController?.Dispose();
        _profilePlayer.CurrentState.UnSubscriptionOnChange(OnChangeGameState);
        base.OnDispose();
    }

    private void OnChangeGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                _mainMenuController = new MainMenuControllerMy(_placeForUi, _profilePlayer);
                _gameController?.Dispose();
                break;
            case GameState.Game:
                _gameController = new GameController(_profilePlayer, _placeForUi);
                _mainMenuController?.Dispose();
                break;

            case GameState.Inventory:
                //_inventoryController = new InventoryController(_inventoryModel, _itemsRepository);
                _inventoryController = new InventoryController(_itemsConfig);
                _inventoryController.ShowInventory();
                break;
            default:
                _mainMenuController?.Dispose();
                _gameController?.Dispose();
                break;
        }
    }
}
