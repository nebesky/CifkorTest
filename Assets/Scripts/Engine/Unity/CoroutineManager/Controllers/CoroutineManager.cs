using System;

namespace Engine.Unity.CoroutineManager
{
    public class CoroutineManager : AbstractCoroutineManager, IDisposable
    {
        public void Dispose()
        {
            if (_view != null)
            {
                _view.Destroy();
            }
        }
    }
}