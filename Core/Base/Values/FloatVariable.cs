using System;
using UnityEngine;

//Inspo SO: https://unity.com/how-to/architect-game-code-scriptable-objects
namespace Assets._Scripts.Core.Base
{
    [CreateAssetMenu(fileName = "New FloatVariable", menuName = "Omen Global Values/FloatVariable", order = 0)]
    public class FloatVariable : ScriptableObject, ISerializationCallbackReceiver
    {
        public float InitialValue;
        public float MaxValue;

        [NonSerialized]
        public float RuntimeValue;

        public void OnAfterDeserialize()
        {
            RuntimeValue = InitialValue;
        }

        public void OnBeforeSerialize() { }
    }
}
