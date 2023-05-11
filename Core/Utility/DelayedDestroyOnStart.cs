using UnityEngine;

namespace Assets._Scripts.Game.Utility
{
    public class DelayedDestroyOnStart : MonoBehaviour
    {
        public float delay = 1f;

        void Start()
        {
            Destroy(gameObject, delay);
        }
    }
}
