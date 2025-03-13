using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Engine.Unity.CoroutineManager
{
    public abstract class AbstractCoroutineManager : ICoroutineManager
    {
        private readonly Dictionary<string, Sprite> _cache = new ();
        protected CoroutineManagerView _view;

        protected AbstractCoroutineManager()
        {
            var gameObject = new GameObject("CoroutineManager");
            _view = gameObject.AddComponent<CoroutineManagerView>();
        }

        public Coroutine StartCoroutine(IEnumerator routine)
        {
            return _view.StartCoroutine(routine);
        }
 
        public Coroutine StartCoroutineRepeat(Action action, float interval)
        {
            return _view.StartCoroutine(RepeatingCoroutine(action, interval));
        }

        private IEnumerator RepeatingCoroutine(Action action, float interval)
        {
            while (true)
            {
                action?.Invoke();

                yield return new WaitForSeconds(interval);
            }
        }

        public void StopCoroutine(IEnumerator routine)
        {
            _view.StopCoroutine(routine);
        }

        public void StopCoroutine(Coroutine routine)
        {
            if (_view != null)
                _view.StopCoroutine(routine);
        }

        public void StopAllCoroutines()
        {
            _view.StopAllCoroutines();
        }

        public Coroutine StartAfterTimeout(float timeout, Action callback)
        {
            return _view.StartCoroutine(PauseInternal(timeout, callback));
        }

        public void StartOnNextFrame(Action callback)
        {
            _view.StartCoroutine(PauseInternal(0.0f, callback));
        }

        private IEnumerator PauseInternal(float timeout, Action callback)
        {
            yield return new WaitForSeconds(timeout);
            callback.Invoke();
        }
    }
}