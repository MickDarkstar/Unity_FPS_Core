using UnityEngine;

namespace Assets._Scripts.Core.Singletons
{
    /// <summary>
    /// Base class for persistent and undestructible singletons.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the deriving class.
    /// </typeparam>
    public abstract class SingletonBase<T> : MonoBehaviour where T : Component
    {
        private static T instance;
        protected static T Instance
        {
            get
            {
                Init();
                return instance;
            }
        }

        protected static void Init()
        {
            if (instance == null || instance.Equals(null))
            {
                instance = new GameObject().AddComponent<T>();
                instance.gameObject.hideFlags = HideFlags.HideAndDontSave;
            }
        }

        #region Regeneration

        private bool quitting = false;

        private void OnApplicationQuit()
        {
            quitting = true;
        }

        private void OnDestroy()
        {
            if (!quitting)
            {
                instance = null;
                Init();
            }
        }

        #endregion
    }
}
