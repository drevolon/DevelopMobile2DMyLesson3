using System.Collections.Generic;
using Profile;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] 
    private Transform _placeForUi;
    [SerializeField]
    private List<ItemConfig> _itemsConfig;
    
    private MainController _mainController;

    private void Awake()
    {
        
        var profilePlayer = new ProfilePlayer(15f);
        profilePlayer.CurrentState.Value = GameState.Start;
        _mainController = new MainController(_placeForUi, profilePlayer, _itemsConfig);
        
    }

    protected void OnDestroy()
    {
        _mainController?.Dispose();
    }
}
