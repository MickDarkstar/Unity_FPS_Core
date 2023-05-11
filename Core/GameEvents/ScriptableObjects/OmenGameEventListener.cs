using UnityEngine;
using UnityEngine.Events;

namespace Assets._Scripts.Core.GameEvents
{
    public class OmenGameEventListener : MonoBehaviour
    {
        [SerializeField] private OmenGameEvent Event;
        [SerializeField] private UnityEvent Response;

        private void OnEnable()
        { 
            Event.RegisterListener(this); 
        }

        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            Response.Invoke();
        }
    }
}
