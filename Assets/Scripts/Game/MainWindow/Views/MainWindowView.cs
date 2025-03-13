using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.MainWindow
{
    public class MainWindowView : MonoBehaviour, IMainWindowView
    {
        public event Action OnWeatherTabClick;
        public event Action OnDogBreedTabClick;

        [SerializeField] private Button _weatherTabButton;
        [SerializeField] private Button _dogBreedTabButton;

        private void Awake()
        {
            _weatherTabButton.onClick.AddListener(
                () => OnWeatherTabClick?.Invoke());
            _dogBreedTabButton.onClick.AddListener(
                () => OnDogBreedTabClick?.Invoke());
        }
    }
}