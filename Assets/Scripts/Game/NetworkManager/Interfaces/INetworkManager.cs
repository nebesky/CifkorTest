using System;
using Engine.Network.Responses;
using UnityEngine;

namespace Engine.NetworkRequestService
{
    public interface INetworkManager
    {
        void FetchDogList(Action<DogsResponse> onComplete);
        void FetchDogBreed(Action<Sprite> onComplete);
        void FetchWeather(Action<WeatherResponseData> onComplete);
        void CancelFetchWeather();
        void CancelFetchDog();
    }
}