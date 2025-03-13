using Zenject;

namespace Game.MainWindow.Weather
{
    public class WeatherInstaller : MonoInstaller<CommonMainWindowInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<WeatherWindowTabView>().FromComponentInHierarchy().AsSingle();
            Container.Bind<WeatherWindowTab>().AsSingle();
        }
    }
}