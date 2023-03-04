using UnityEngine;

namespace Utilites
{
    [DefaultExecutionOrder(-1000)]
    public class SingletonMonoBehaviour<T> : MonoBehaviour where T : Component
    {
        public static T Instance { get; protected set; }

        protected virtual void Awake ()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this as T;
        }

        protected virtual void OnDestroy ()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }
    }
}
