using Zenject;

namespace Engine.Unity.CoroutineManager
{
    public class CoroutineInstaller : MonoInstaller<CoroutineInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ICoroutineProjectManager>()
                .To<CoroutineProjectManager>()
                .AsSingle();
        }
    }
}