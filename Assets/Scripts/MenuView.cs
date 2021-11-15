using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Views
{
    public class MenuView : MonoBehaviour
    {
        [SerializeField] private Button _btnStartButton;
        [SerializeField] private Button _btnGameButton;
        [SerializeField] private Button _btnInventoryButton;
        [SerializeField] private Button _btnAdressablesButton;
        [SerializeField] private Button _btnExitButton;

        public void Init(UnityAction BtnStartButton, UnityAction BtnGameButton, UnityAction BtnInventoryButton,
            UnityAction BtnExitButton, UnityAction BtnAdressablesButton)
        {
            _btnStartButton.onClick.AddListener(BtnStartButton);
            _btnGameButton.onClick.AddListener(BtnGameButton);
            _btnInventoryButton.onClick.AddListener(BtnInventoryButton);
            _btnAdressablesButton.onClick.AddListener(BtnAdressablesButton);
            _btnExitButton.onClick.AddListener(BtnExitButton);
        }

        protected void OnDestroy()
        {
            _btnStartButton.onClick.RemoveAllListeners();
            _btnGameButton.onClick.RemoveAllListeners();
            _btnInventoryButton.onClick.RemoveAllListeners();
            _btnExitButton.onClick.RemoveAllListeners();
            _btnAdressablesButton.onClick.RemoveAllListeners();
        }
    }
}
