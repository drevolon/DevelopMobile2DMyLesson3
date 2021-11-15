using System.Runtime.CompilerServices;
using Controllers;
using Profile;
using Tools;

using UnityEngine;
using Views;

public class MainMenuController : BaseController
{
    private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/Menu"};
    private readonly ProfilePlayer _profilePlayer;
  
    private readonly MainMenuView _view;

    public MainMenuController(Transform placeForUi, ProfilePlayer profilePlayer)
    {
        _profilePlayer = profilePlayer;
        
        _view = LoadView(placeForUi);
        _view.Init(StartGame, ShowAddRequested);
    }
    
    private MainMenuView LoadView(Transform placeForUi)
    {
        var objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeForUi, false);
        AddGameObjects(objectView);
        
        return objectView.GetComponent<MainMenuView>();
    }

    private void ShowAddRequested()
    {
        
        Debug.Log("OnVideoShowSuccess");
    }

    private void OnVideoShowSuccess()
    {
        // Add model reward
    }

    private void StartGame()
    {
        _profilePlayer.CurrentState.Value = GameState.Game;
    }
}

