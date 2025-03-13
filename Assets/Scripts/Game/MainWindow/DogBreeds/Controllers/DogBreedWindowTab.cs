using Engine.Network.Responses;
using Engine.NetworkRequestService;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.MainWindow.DogBreeds
{
    public class DogBreedWindowTab : AbstractWindowTab
    {
        private DogBreedsWindowTabView  _view;
        private readonly INetworkManager _networkManager;
        private readonly IDogFactory _dogFactory;
        private readonly Transform _dogContainerTransform;
        
        public DogBreedWindowTab(
            DogBreedsWindowTabView view,
            IDogFactory dogFactory,
            INetworkManager networkManager,
            Transform dogContainerTransform) : base(view)
        {
            _view = view;
            _networkManager = networkManager;
            _dogFactory = dogFactory;
            _dogContainerTransform = dogContainerTransform;
        }

        protected override void OnBeforeOpen()
        {
            _networkManager.FetchDogList(OnComplete);

            base.OnBeforeOpen();
        }

        private void OnComplete(DogsResponse response)
        {
            var i = 0;

            foreach (var dogBreedElement in response.Breeds)
            {
                _dogFactory.CreateDogUIElement(
                    (++i).ToString(),
                    dogBreedElement.Id,
                    dogBreedElement.Name);
            }
        }

        protected override void OnBeforeClose() 
        {
            foreach (Transform child in _dogContainerTransform)
                Object.Destroy(child.gameObject);
            
            _networkManager.CancelFetchDog();

            base.OnBeforeClose();
        }
    }
}