using System;

namespace Game.MainWindow
{
    public interface IMainWindowView
    {
        event Action OnWeatherTabClick;
        event Action OnDogBreedTabClick;
    }
}