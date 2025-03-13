using System;

namespace Engine.Network.NetworkService
{
    public interface INetworkService<T>
    {
        void Fetch(string url, Action<T> onComplete);
        void CancelLoad(string url);
    }
}