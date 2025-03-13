using UnityEngine;

namespace Game.MainWindow.Weather
{
    public interface IWeatherWindowTabView
    {
        void SetWeather(string temperature, Sprite icon);
        void SetWeather(string temperature);
    }
}