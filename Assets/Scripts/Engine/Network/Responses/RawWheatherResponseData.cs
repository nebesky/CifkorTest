using System;

namespace Engine.Network.Responses
{
    //FOR deserialization
    [Serializable]
    public struct WeatherResponse
    {
        public WeatherProperties properties;
    }

    [Serializable]
    public struct WeatherProperties
    {
        public WeatherPeriod[] periods;
    }

    [Serializable]
    public struct WeatherPeriod
    {
        public int number;
        public string name;
        public int temperature;
        public string temperatureUnit;
        public string icon;
    }
}