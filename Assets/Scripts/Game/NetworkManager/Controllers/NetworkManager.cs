using System;
using System.Collections.Generic;
using Engine.Network.NetworkService;
using Engine.Network.Responses;
using Engine.NetworkRequestService;
using Game.MainWindow.DogBreeds.Extra;
using Game.Scriptables;
using Newtonsoft.Json;
using UnityEngine;

namespace Game.NetworkManager
{
    public class NetworkManager : INetworkManager
    {
        private readonly INetworkService<string> _dataNetworkService;
        private readonly INetworkService<Sprite> _imageNetworkService;
        private readonly NetworkConfig _networkConfig;

        protected Dictionary<string, string> _pendingImages = new();

        public NetworkManager(
            INetworkService<Sprite> imageNetworkService, 
            INetworkService<string> dataNetworkService,
            NetworkConfig networkConfig)
        {
            _imageNetworkService = imageNetworkService;
            _dataNetworkService = dataNetworkService;
            _networkConfig = networkConfig;
        }

        public void FetchDogList(Action<DogsResponse> onComplete)
        {
            _dataNetworkService.Fetch(_networkConfig.DogBreedListUrl, json =>
            {
                
                DogsApiResponse apiResponse = JsonConvert.DeserializeObject<DogsApiResponse>(json);
                DogsResponse response = DogsResponseMapper.MapToDogsResponse(apiResponse);

                onComplete?.Invoke(response);
            });
        }

        public void FetchDogBreed(Action<Sprite> onComplete)
        {
    
        }

        public void FetchWeather(Action<WeatherResponseData> onComplete)
        {
            _dataNetworkService.Fetch(_networkConfig.WeatherUrl, (json) =>
            {
                if (!string.IsNullOrEmpty(json))
                {
                    WeatherResponse weatherResponse = JsonUtility.FromJson<WeatherResponse>(json);
                    WeatherPeriod firstPeriod = weatherResponse.properties.periods[0];

                    if (!_pendingImages.ContainsKey(_networkConfig.WeatherUrl))
                        _pendingImages.Add(_networkConfig.WeatherUrl, firstPeriod.icon);
                    
                    _imageNetworkService.Fetch(firstPeriod.icon, sprite =>
                    {
                        _pendingImages.Remove(firstPeriod.icon);

                        onComplete?.Invoke(new WeatherResponseData
                        {
                            Code = 200,
                            Icon = sprite,
                            Temperature = firstPeriod.temperature + " " + firstPeriod.temperatureUnit,
                        });
                    });
                }
                else
                {
                    Debug.LogError("Received empty image URL from text service.");
                    onComplete?.Invoke(new WeatherResponseData { Code = 404 });
                }
            });
        }

        public void CancelFetchWeather()
        {
            _imageNetworkService.CancelLoad(_networkConfig.WeatherUrl);

            if (_pendingImages.ContainsKey(_networkConfig.WeatherUrl))
            {
                _dataNetworkService.CancelLoad(_pendingImages[_networkConfig.WeatherUrl]);
                _pendingImages.Remove(_networkConfig.WeatherUrl);
            }
        }

        public void CancelFetchDog()
        {
            _dataNetworkService.CancelLoad(_networkConfig.DogBreedUrl);
        }
    }
}