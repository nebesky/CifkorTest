using System;
using Game.MainWindow.DogBreeds;
using Game.MainWindow.Weather;

namespace Game.MainWindow
{
    public class MainWindow : IDisposable
    {
        private readonly MainWindowView _mainWindowView;
        private readonly WeatherWindowTab _weatherWindowTab;
        private readonly DogBreedWindowTab _dogBreedWindowTab;

        public MainWindow(MainWindowView mainWindowView,
            WeatherWindowTab weatherWindowTab,
            DogBreedWindowTab dogBreedWindowTab)
        {
            _mainWindowView = mainWindowView;
            _weatherWindowTab = weatherWindowTab;
            _dogBreedWindowTab = dogBreedWindowTab;
            
            _mainWindowView.OnWeatherTabClick += MainWindowViewOnWeatherTabClick;
            _mainWindowView.OnDogBreedTabClick += MainWindowViewOnDogBreedTabClick;
        }

        private void MainWindowViewOnDogBreedTabClick()
        {
            _weatherWindowTab.SetVisible(false);
            _dogBreedWindowTab.SetVisible(true);
        }

        private void MainWindowViewOnWeatherTabClick()
        {
            _dogBreedWindowTab.SetVisible(false);
            _weatherWindowTab.SetVisible(true);
        }

        public void Dispose()
        {
            _mainWindowView.OnWeatherTabClick -= MainWindowViewOnWeatherTabClick;
            _mainWindowView.OnDogBreedTabClick -= MainWindowViewOnDogBreedTabClick;
        }
    }
}