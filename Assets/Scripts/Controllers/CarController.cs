using Controllers;
using Tools;
using UnityEngine;
using Views;

public class CarController : BaseController
{
    private readonly Transform _placeForUi;
    private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/Car"};
    private readonly CarView _carView;

    public CarController(Transform placeForUi)
    {
        placeForUi = _placeForUi;
        _carView = LoadView(placeForUi);
    }

    private CarView LoadView(Transform placeForUi)
    {
        var objView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
        AddGameObjects(objView);
        
        return objView.GetComponent<CarView>();
    }

    public GameObject GetViewObject()
    {
        return _carView.gameObject;
    }
}

