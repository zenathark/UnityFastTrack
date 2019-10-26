using Source.Components;
using UnityEngine;
using UnityEngine.Serialization;

namespace Source.Systems
{
    public class MovementXy: MonoBehaviour
    {
        [SerializeField] private Transform pawnTransform;
        [SerializeField] private AxisXyValue controller;
        [SerializeField] private PositionXyValue playerPosition;

        private void Update()
        {
            pawnTransform.Translate(controller.x,0,controller.y);
            var newPosition = pawnTransform.position;
            playerPosition.x = newPosition.x;
            playerPosition.y = newPosition.z;
        }
    }
}