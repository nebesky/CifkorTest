using Game.Scriptables;
using UnityEngine;
using Zenject;

namespace Game.NetworkManager
{
    public class NetworkManagerInstaller : MonoInstaller
    {
        [SerializeField] private NetworkConfig _networkConfig;

        public override void InstallBindings()
        {
            Container.BindInstance(_networkConfig)
                .AsSingle();

            Container.BindInterfacesTo<NetworkManager>()
                .AsSingle();
        }
    }
}