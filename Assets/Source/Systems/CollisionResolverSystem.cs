using System;
using Source.Components;
using UnityEngine;

namespace Source.Systems
{
    /**
     * This is a template
     */
    public class CollisionResolverSystem : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            switch (other.collider.tag)
            {
                case "Item":
                    HandleItem(other);
                    break;
                case "Enemy":
                    handleEnemy(other);
                    break;
            }
        }

        private void handleEnemy(Collision collider)
        {
            
        }

        private void HandleItem(Collision other)
        {
            other.gameObject.SetActive(false);
        }
    }
}