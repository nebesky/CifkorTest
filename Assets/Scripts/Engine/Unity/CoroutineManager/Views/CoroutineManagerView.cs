using UnityEngine;

namespace Engine.Unity.CoroutineManager
{
    public class CoroutineManagerView : MonoBehaviour
    {
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}