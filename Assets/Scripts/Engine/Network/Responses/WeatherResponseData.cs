using UnityEngine;

namespace Engine.Network.Responses
{
    public struct WeatherResponseData
    {
        public int Code;
        public string Temperature;
        public Sprite Icon;
    }
}