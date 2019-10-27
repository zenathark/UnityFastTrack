using System;
using Source.Components;
using UnityEngine;

namespace Source.Systems
{
    public class CollisionDetectionSystem : MonoBehaviour
    {
        [SerializeField] private ColliderCollection colliders = null;

        private void Start()
        {
            Debug.Assert(colliders != null, "A Collision Collection must be assigned for this system");
        }

        private void OnCollisionEnter(Collision other)
        {
            colliders.Add(other.collider);
        }
    }
}
