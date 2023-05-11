namespace Assets._Scripts.GameEvents
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;

    // Todo: kör SingletonBase<EventManagerUnityEvents> istället, borde vara liknande lösning på singletons
    public class EventManagerUnityEvents : MonoBehaviour
    {
        private Dictionary<string, UnityEvent> eventDictionary;

        private static EventManagerUnityEvents eventManager;

        public static EventManagerUnityEvents instance
        {
            get
            {
                if (!eventManager)
                {
                    eventManager = FindObjectOfType(typeof(EventManagerUnityEvents)) as EventManagerUnityEvents;

                    if (!eventManager)
                    {
                        Debug.LogError("There needs to be one active EventManagerUnityEvents script on a GameObject in your scene.");
                    }
                    else
                    {
                        eventManager.Init();
                    }
                }

                return eventManager;
            }
        }

        void Init()
        {
            if (eventDictionary == null)
            {
                eventDictionary = new Dictionary<string, UnityEvent>();
            }
        }

        public static void StartListening(string eventName, UnityAction listener)
        {
            UnityEvent thisEvent = null;
            if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.AddListener(listener);
            }
            else
            {
                thisEvent = new UnityEvent();
                thisEvent.AddListener(listener);
                instance.eventDictionary.Add(eventName, thisEvent);
            }
        }

        public static void StopListening(string eventName, UnityAction listener)
        {
            if (eventManager == null) return;
            UnityEvent thisEvent = null;
            if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.RemoveListener(listener);
            }
        }

        public static void TriggerEvent(string eventName)
        {
            UnityEvent thisEvent = null;
            if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.Invoke();
            }
        }
    }
}
