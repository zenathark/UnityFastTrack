using UnityEngine;

namespace Source.Components
{
    [CreateAssetMenu]
    public class Vector2DValue : ScriptableObject
    {
        public Vector2 value;

        public static implicit operator Vector2(Vector2DValue newValues) => newValues.value;

        public float X
        {
            get => value.x;
            set => this.value.x = value;
        }

        public float Y
        {
            get => value.y;
            set => this.value.y = value;
        }
    }
}
