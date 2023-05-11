//Cred to: http://bernardopacheco.net/using-an-event-manager-to-decouple-your-game-in-unity
namespace Assets._Scripts.GameEvents
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    // Todo: kör SingletonBase<EventManagerMagicStrings> istället, borde vara liknande lösning på singletons

    /// <summary>
    /// Kan inte användas i ScriptableObjects, pga DontDestroyOnLoad
    /// </summary>
    public class EventManagerMagicStrings : MonoBehaviour
    {
        private Dictionary<string, Action<Dictionary<string, OmenEvent>>> eventDictionary;

        private static EventManagerMagicStrings eventManager;

        public static EventManagerMagicStrings instance
        {
            get
            {
                if (!eventManager)
                {
                    eventManager = FindObjectOfType(typeof(EventManagerMagicStrings)) as EventManagerMagicStrings;

                    if (!eventManager)
                    {
                        Debug.LogError("There needs to be one active EventManagerMagicStrings script on a GameObject in your scene.");
                    }
                    else
                    {
                        eventManager.Init();

                        //  Sets this to not be destroyed when reloading scene
                        DontDestroyOnLoad(eventManager);
                    }
                }
                return eventManager;
            }
        }

        void Init()
        {
            if (eventDictionary == null)
            {
                eventDictionary = new Dictionary<string, Action<Dictionary<string, OmenEvent>>>();
            }
        }

        public static void StartListening(string eventName, Action<Dictionary<string, OmenEvent>> listener)
        {
            Action<Dictionary<string, OmenEvent>> thisEvent;

            if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent += listener;
                instance.eventDictionary[eventName] = thisEvent;
            }
            else
            {
                thisEvent += listener;
                instance.eventDictionary.Add(eventName, thisEvent);
            }
        }

        public static void StopListening(string eventName, Action<Dictionary<string, OmenEvent>> listener)
        {
            if (eventManager == null) return;
            Action<Dictionary<string, OmenEvent>> thisEvent;
            if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent -= listener;
                instance.eventDictionary[eventName] = thisEvent;
            }
        }

        public static void TriggerEvent(string eventName, Dictionary<string, OmenEvent> message)
        {
            Action<Dictionary<string, OmenEvent>> thisEvent;
            if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
                thisEvent.Invoke(message);
        }

        public class EventTopics
        {
            /// <summary>
            /// Event topics for IHasLife type
            /// </summary>
            public static class HasLifeEvents
            {
                public static string Killed = "Killed";
            }

            /// <summary>
            /// Event topics for Collectible type
            /// </summary>
            public static class CollectibleEvents
            {
                public static string Collected = "Collected";
            }
        }
    }

    public class OmenEvent
    {
        public string EventName;
        public string JsonData;
        public float Value;
        public int Number;
    }
}
