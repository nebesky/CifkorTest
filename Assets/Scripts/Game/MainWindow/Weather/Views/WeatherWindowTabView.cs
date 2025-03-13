using UnityEngine;

namespace Game.MainWindow.Weather
{
    public class WeatherWindowTabView : AbstractWindowTabView
    {
        [SerializeField] private WeatherPanelView  _weatherPanelView;

        public void SetWeather(string temperature, Sprite icon)
        {
            SetTemperature(temperature);
            
            _weatherPanelView.SetIcon(icon);
        }

        public void SetWeather(string temperature)
        {
            SetTemperature(temperature);
        }

        private void SetTemperature(string temperature)
        {
            _weatherPanelView.SetText("Today: " + temperature);
        }

        public void ShowLoading()
        {
            _weatherPanelView.ShowLoading();
        }

        public void ShowPanel()
        {
            _weatherPanelView.ShowPanel();
        }
    }
}