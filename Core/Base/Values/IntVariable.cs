using System;
using UnityEngine;

//Inspo SO: https://unity.com/how-to/architect-game-code-scriptable-objects
namespace Assets._Scripts.Core.Base
{
    [CreateAssetMenu(fileName = "New IntVariable", menuName = "Omen Global Values/IntVariable", order = 0)]
    public class IntVariable : ScriptableObject, ISerializationCallbackReceiver
    {
        public int InitialValue;
        public int MaxValue;

        [NonSerialized]
        public int RuntimeValue;

        public void OnAfterDeserialize()
        {
            RuntimeValue = InitialValue;
        }

        public void OnBeforeSerialize() { }
    }
}
