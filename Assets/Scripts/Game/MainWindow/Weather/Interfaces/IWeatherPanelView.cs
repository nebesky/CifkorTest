using UnityEngine;

namespace Game.MainWindow.Weather
{
    public interface IWeatherPanelView
    {
        void SetIcon(Sprite icon);
        void SetText(string temperature);
        
        void ShowLoading();
        void ShowPanel();
    }
}