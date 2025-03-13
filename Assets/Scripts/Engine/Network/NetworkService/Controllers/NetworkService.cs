using System;
using System.Collections;
using Engine.Unity.CoroutineManager;
using UnityEngine;
using UnityEngine.Networking;

namespace Engine.Network.NetworkService
{
    public class NetworkService : AbstractNetworkService<string>
    {
        public NetworkService(
            ICoroutineProjectManager coroutineRunner) : base(coroutineRunner) { }

        protected override IEnumerator ProcessRequest(string url, Action<string> onComplete)
        {
            using (UnityWebRequest request = UnityWebRequest.Get(url))
            {
                yield return request.SendWebRequest();

                if (request.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError($"Failed to fetch data: {request.error}");

                    onComplete?.Invoke(null);
                }
                else
                {
                    string response = request.downloadHandler.text;
                    
                    onComplete?.Invoke(response);
                }
            }

            _pendingRequests.Remove(url);
            _isProcessing = false;
            _currentRequestUrl = null;

            TryStartNextLoad();
        }
    }
}