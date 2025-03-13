using UnityEngine;

namespace Game.MainWindow.DogBreeds
{
    public class DogFactory : IDogFactory
    {
        private readonly GameObject _dogUIPrefab;
        private readonly Transform _parentTransform;
        
        public DogFactory(GameObject dogUIPrefab, Transform parentTransform)
        {
            _dogUIPrefab = dogUIPrefab;
            _parentTransform = parentTransform;
        }
        
        public IDogUIElement CreateDogUIElement(string order, string id, string name)
        {
            if (_dogUIPrefab == null)
            {
                Debug.LogError("Dog UI Prefab is not assigned in DogUIFactory!");
                return null;
            }

            GameObject newDogUI = Object.Instantiate(_dogUIPrefab, _parentTransform);

            var dogUIComponent = newDogUI.GetComponent<DogUIComponent>();
            
            if (dogUIComponent != null)
            {
                dogUIComponent.SetData(order, id, name);
            }
            else
            {
                Debug.LogWarning("DogUIComponent not found on prefab!");
            }

            return null;
        }
    }
}