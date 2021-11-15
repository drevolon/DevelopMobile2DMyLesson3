using System;
using System.Collections;
using System.Collections.Generic;
using Profile;
using Tools;
using UnityEngine;
using Views;
using Object = UnityEngine.Object;

public class MainMenuControllerMy: BaseController
{
    
    private readonly ResourcePath _viewPath = new ResourcePath { PathResource = "Prefabs/Menu" };

    private MenuView _menuView;
    private ProfilePlayer _profilePlayer;

    public MainMenuControllerMy(Transform placeForUI, ProfilePlayer profilePlayer)
    {
        _profilePlayer = profilePlayer;
        _menuView = LoadMenu(placeForUI);
        _menuView.Init(StartButton, GameButton, InventoryButton, ExitButton, AdressablesButton);
    }

    private void AdressablesButton()
    {
        throw new NotImplementedException();
    }

    private MenuView LoadMenu(Transform placeForUI)
    {
        GameObject objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeForUI, false);
        AddGameObjects(objectView);
        return objectView.GetComponent<MenuView>();
    }

    private void ExitButton()
    {
        Debug.Log("exitButton");
    }

    private void InventoryButton()
    {
        Debug.Log("inventoryButton");
        _profilePlayer.CurrentState.Value = GameState.Inventory;
    }

    private void GameButton()
    {
        Debug.Log("gameButton");
    }

    public void StartButton()
    {
        Debug.Log("startButton");
        
        _profilePlayer.CurrentState.Value = GameState.Game;

    }
}

internal class ResourcePath
{
    private string _pathResource;
    public string PathResource { get; set; }
}

