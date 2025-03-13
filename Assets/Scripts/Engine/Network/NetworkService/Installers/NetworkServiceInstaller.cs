using Zenject;

namespace Engine.Network.NetworkService
{
    public class NetworkServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<NetworkService>()
                .AsSingle();
            
            Container.BindInterfacesTo<NetworkImageService>()
                .AsSingle();
        }
    }
}