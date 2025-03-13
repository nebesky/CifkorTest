using System;
using System.Collections;
using System.Collections.Generic;
using Engine.Unity.CoroutineManager;
using UnityEngine;
using UnityEngine.Networking;

namespace Engine.Network.NetworkService
{
    public class NetworkImageService : AbstractNetworkService<Sprite>
    {
        private readonly Dictionary<string, Sprite> _cache = new ();

        public NetworkImageService(
            ICoroutineProjectManager coroutineProjectManager) : base(coroutineProjectManager) { }

        protected override IEnumerator ProcessRequest(string url, Action<Sprite> onComplete)
        {
            if (_cache.ContainsKey(url))
            {
                onComplete?.Invoke(_cache[url]);
            }
            else
            {
                using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(url))
                {
                    yield return request.SendWebRequest();

                    if (request.result != UnityWebRequest.Result.Success)
                    {
                        Debug.LogError($"Failed to load image: {request.error}");

                        onComplete?.Invoke(null);
                    }
                    else
                    {
                        Texture2D texture = DownloadHandlerTexture.GetContent(request);
                        Sprite sprite = Sprite.Create(
                            texture,
                            new Rect(Vector2.zero, new Vector2(texture.width, texture.height)),
                            Vector2.zero);

                        _cache[url] = sprite;

                        onComplete?.Invoke(sprite);
                    }
                }

                _pendingRequests.Remove(url);
                _isProcessing = false;
                _currentRequestUrl = null;
            }

            TryStartNextLoad();
        }
    }
}