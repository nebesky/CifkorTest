using Zenject;

namespace Game.MainWindow
{
    public class CommonMainWindowInstaller : MonoInstaller<CommonMainWindowInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<MainWindowView>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container.BindInterfacesTo<MainWindow>()
                .AsSingle();
        }
    }
}