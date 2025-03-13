using System;
using System.Collections;
using UnityEngine;

namespace Engine.Unity.CoroutineManager
{
    public interface ICoroutineManager
    {
        Coroutine StartCoroutine(IEnumerator routine);
        Coroutine StartCoroutineRepeat(Action action, float interval);
        void StopAllCoroutines();
        void StopCoroutine(IEnumerator routine);
        void StopCoroutine(Coroutine routine);
        Coroutine StartAfterTimeout(float timeout, Action callback);
        void StartOnNextFrame(Action callback);
    }
}