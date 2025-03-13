using UnityEngine;

namespace Engine.Unity.CoroutineManager
{
    public class CoroutineProjectManager : AbstractCoroutineManager, ICoroutineProjectManager
    {
        public CoroutineProjectManager()
        {
            Object.DontDestroyOnLoad(_view);
        }
    }
}