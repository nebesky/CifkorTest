using UnityEngine;

namespace Game.MainWindow
{
    public class AbstractWindowTabView : MonoBehaviour, IWindowTabView
    {
        public void SetParent(Transform parent)
        {
            transform.SetParent(parent, false);
        }

        public void SetVisible(bool isVisible)
        {
            gameObject.SetActive(isVisible);
        }
    }
}