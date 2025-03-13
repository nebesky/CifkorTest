using UnityEngine;

namespace Game.Scriptables
{
    [CreateAssetMenu(fileName = "NetworkConfig", menuName = "Configs/NetworkConfig")]
    public class NetworkConfig : ScriptableObject
    {
        public string WeatherUrl;
        public string DogBreedUrl;
        public string DogBreedListUrl;
    }
}