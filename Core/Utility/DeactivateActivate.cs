using UnityEngine;
using UnityEngine.Events;

namespace Assets._Scripts.Core.Utility
{
    public class DeactivateActivate : MonoBehaviour
    {
        public UnityEvent onActivate;
        public void Activate()
        {
            gameObject.SetActive(true);
         
            if(onActivate != null && !onActivate.Equals(null))
                onActivate.Invoke();
        }

        public UnityEvent onDeactivate;
        public void Deactivate()
        {
            gameObject.SetActive(false);

            if (onDeactivate != null && !onDeactivate.Equals(null))
                onDeactivate.Invoke();
        }
    }
}
