using System;
using UnityEngine;

//Inspo SO: https://unity.com/how-to/architect-game-code-scriptable-objects
namespace Assets._Scripts.Core.Base
{
    [CreateAssetMenu(fileName = "New BoolVariable", menuName = "Omen Global Values/BoolVariable", order = 0)]
    public class BoolVariable : ScriptableObject, ISerializationCallbackReceiver
    {
        public bool InitialValue;

        [NonSerialized]
        public bool RuntimeValue;

        public void OnAfterDeserialize()
        {
            RuntimeValue = InitialValue;
        }

        public void OnBeforeSerialize() { }
    }
}
