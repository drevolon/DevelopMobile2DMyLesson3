using Controllers;
using Profile;
using Tools;
using UnityEngine;

public class GameController : BaseController
{
    private readonly Transform _placeForUi;

    public GameController(ProfilePlayer profilePlayer, Transform placeForUi)
    {
        _placeForUi = placeForUi;
        var leftMoveDiff = new SubscriptionProperty<float>();
        var rightMoveDiff = new SubscriptionProperty<float>();
        
        var tapeBackgroundController = new TapeBackgroundController(leftMoveDiff, rightMoveDiff);
        AddController(tapeBackgroundController);
        
        var inputGameController = new InputGameController(leftMoveDiff, rightMoveDiff, profilePlayer.CurrentCar);
        AddController(inputGameController);
            
        var carController = new CarController(_placeForUi);
        AddController(carController);
    }
}

