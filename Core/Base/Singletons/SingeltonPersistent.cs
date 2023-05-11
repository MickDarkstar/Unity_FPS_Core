using UnityEngine;

namespace Assets._Scripts.Core
{
    /// <summary>
    /// Persistent singleton
    /// </summary>
    public class SingletonPersistent<T> : MonoBehaviour where T : Component
    {
        private static T _instance;

        /// <summary>
        /// Retrieves singleton instance.
        /// If none, create new gameobject and add class component
        /// </summary>
        /// <value>Returns class instance</value>
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    FindExisting();
                    if (_instance == null)
                    {
                        _instance = new GameObject("Instance of " + typeof(T)).AddComponent<T>();
                    }
                }
                return _instance;

                void FindExisting()
                {
                    _instance = FindObjectOfType<T>();
                }
            }
        }

        protected virtual void Awake()// Test med nya abstract SingletonBase
        {
            if (_instance != null) Destroy(this);
            else
            {
                _instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}
