using Game.MainWindow.DogBreeds;
using UnityEngine;
using Zenject;

namespace Game.MainWindow.Weather
{
    public class DogBreedInstaller : MonoInstaller<DogBreedInstaller>
    {
        [SerializeField] private GameObject _dogUIPrefab;
        [SerializeField] private Transform _parentTransform;
        
        public override void InstallBindings()
        {
            Container.Bind<DogBreedsWindowTabView>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container.Bind<DogBreedWindowTab>()
                .AsSingle()
                .WithArguments(_parentTransform);
            
            Container.Bind<IDogFactory>()
                .To<DogFactory>()
                .AsSingle()
                .WithArguments(_dogUIPrefab, _parentTransform);
        }
    }
}