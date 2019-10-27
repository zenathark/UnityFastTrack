using UnityEngine;

namespace Source.Components
{
    [CreateAssetMenu]
    public class FloatValue : ScriptableObject
    {
        public float value;

        public static implicit operator float(FloatValue floatValue)
        {
            return floatValue.value;
        }
    }
}