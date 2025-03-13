using TMPro;
using UnityEngine;

namespace Game.MainWindow.DogBreeds
{
    public class DogUIComponent : MonoBehaviour, IDogUIElement
    {
        [SerializeField] private TextMeshProUGUI _orderText;
        [SerializeField] private TextMeshProUGUI _nameText;

        private string _id;
        
        public void SetData(string order, string id, string name)
        {
            _id = id;
            _orderText.text = order;
            _nameText.text = name;
        }
    }
}