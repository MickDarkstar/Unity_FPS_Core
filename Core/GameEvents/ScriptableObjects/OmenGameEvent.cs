using System.Collections.Generic;
using UnityEngine;

//Cred: https://unity.com/how-to/architect-game-code-scriptable-objects
//https://www.kodeco.com/2826197-scriptableobject-tutorial-getting-started
namespace Assets._Scripts.Core.GameEvents
{
    [CreateAssetMenu(fileName = "New GameEvent", menuName = "GameEvent/OmenGameEvent", order = 4)]
    public class OmenGameEvent : ScriptableObject
    {
        private List<OmenGameEventListener> listeners =
            new List<OmenGameEventListener>();

        public void Raise()
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
                listeners[i].OnEventRaised();
        }

        public void RegisterListener(OmenGameEventListener listener)
        { listeners.Add(listener); }

        public void UnregisterListener(OmenGameEventListener listener)
        { listeners.Remove(listener); }
    }
}
