using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Engine.Unity.CoroutineManager;

namespace Engine.Network.NetworkService
{
    public abstract class AbstractNetworkService<T> : INetworkService<T>
    {
        protected Queue<string> _requestQueue = new();
        protected HashSet<string> _pendingRequests = new();
        protected Dictionary<string, List<Action<T>>> _callbacksByUrl = new();
        
        protected bool _isProcessing;
        protected string _currentRequestUrl;

        protected ICoroutineProjectManager _coroutineProjectManager;

        protected abstract IEnumerator ProcessRequest(string url, Action<T> onComplete);

        protected AbstractNetworkService(ICoroutineProjectManager coroutineProjectManager)
        {
            _coroutineProjectManager = coroutineProjectManager;
        }

        public void Fetch(string url, Action<T> onComplete)
        {
            if (_pendingRequests.Contains(url))
            {
                _callbacksByUrl[url].Add(onComplete);
                
                return;
            }

            _callbacksByUrl[url] = new List<Action<T>> { onComplete };

            _requestQueue.Enqueue(url);
            _pendingRequests.Add(url);

            TryStartNextLoad();
        }

        public void CancelLoad(string url)
        {
            if (url == _currentRequestUrl)
            {
                _coroutineProjectManager.StopAllCoroutines();
                _isProcessing = false;
                _currentRequestUrl = null;
            }
            else
            {
                _requestQueue = new Queue<string>(_requestQueue.Where(item => item != url));
            }

            _callbacksByUrl.Remove(url);
            _pendingRequests.Remove(url);

            TryStartNextLoad();
        }

        protected void TryStartNextLoad()
        {
            if (_isProcessing || _requestQueue.Count == 0)
                return;

            string url = _requestQueue.Dequeue();

            _currentRequestUrl = url;
            _isProcessing = true;

            _coroutineProjectManager.StartCoroutine(ProcessRequest(url, result => OnRequestCompleted(url, result)));
        }

        private void OnRequestCompleted(string url, T result)
        {
            if (_callbacksByUrl.TryGetValue(url, out var callbacks))
            {
                foreach (var callback in callbacks)
                {
                    callback?.Invoke(result);
                }

                _callbacksByUrl.Remove(url);
            }

            _pendingRequests.Remove(url);
            _currentRequestUrl = null;
            _isProcessing = false;

            TryStartNextLoad();
        }
    }
}