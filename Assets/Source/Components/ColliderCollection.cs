using System.Collections.Generic;
using UnityEngine;

namespace Source.Components
{
    [CreateAssetMenu]
    public class ColliderCollection : ScriptableObject
    {
        public Queue<Collider> colliders = new Queue<Collider>();

        public void Add(Collider collider)
        {
            colliders.Enqueue(collider);   
        }
    }
}
