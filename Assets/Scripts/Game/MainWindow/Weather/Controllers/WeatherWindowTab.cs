using Engine.Network.Responses;
using Engine.NetworkRequestService;
using Engine.Unity.CoroutineManager;

namespace Game.MainWindow.Weather
{
    public class WeatherWindowTab : AbstractWindowTab
    {
        private readonly WeatherWindowTabView _view;
        private readonly INetworkManager _networkManager;
        private readonly ICoroutineProjectManager _coroutineProjectManager;

        public WeatherWindowTab(
            WeatherWindowTabView view, 
            INetworkManager networkManager,
            ICoroutineProjectManager coroutineProjectManager) : base(view)
        {
            _view = view;
            _coroutineProjectManager = coroutineProjectManager;
            _networkManager = networkManager;

            _networkManager.FetchWeather(OnWeatherRequestLoaded);
            _coroutineProjectManager.StartCoroutineRepeat(OnCoroutineRepeat, 5f);
        }

        protected override void OnBeforeOpen()
        {
            _coroutineProjectManager.StartCoroutineRepeat(OnCoroutineRepeat, 5f);

            base.OnBeforeOpen();
        }

        protected override void OnBeforeClose()
        {
            _networkManager.CancelFetchWeather();

            base.OnBeforeClose();
        }

        private void OnCoroutineRepeat()
        {
            _networkManager.FetchWeather(OnWeatherRequestLoaded);
        }

        private void OnWeatherRequestLoaded(WeatherResponseData weatherResponseData)
        {
            if (weatherResponseData.Temperature != null && weatherResponseData.Icon)
            {
                _view.ShowPanel();
                _view.SetWeather(
                    weatherResponseData.Temperature,
                    weatherResponseData.Icon);
            }
        }
    }
}