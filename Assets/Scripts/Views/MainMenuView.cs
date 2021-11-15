using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Views
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] 
        private Button _buttonStart;

        [SerializeField] private Button _showRewardedButton;
        
        public void Init(UnityAction startGame, UnityAction rewardAdRequested)
        {
            _buttonStart.onClick.AddListener(startGame);
            _showRewardedButton?.onClick.AddListener(rewardAdRequested);
        }

        protected void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
            _showRewardedButton.onClick.RemoveAllListeners();
        }
    }
}

