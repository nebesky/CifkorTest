using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.MainWindow.Weather
{
    public class WeatherPanelView : MonoBehaviour, IWeatherPanelView
    {
        [SerializeField] private TextMeshProUGUI _temperatureText;
        [SerializeField] private Image _iconImage;
        [SerializeField] private GameObject _loadingView;

        public void SetText(string temperature)
        {
            _temperatureText.text = temperature;
        }

        public void SetIcon(Sprite sprite)
        {
            if (_iconImage != null && sprite != null)
            {
                _iconImage.sprite = sprite;
            }
        }

        public void ShowLoading()
        {
            _loadingView.SetActive(true);
        }

        public void ShowPanel()
        {
            _loadingView.SetActive(false);
        }
    }
}