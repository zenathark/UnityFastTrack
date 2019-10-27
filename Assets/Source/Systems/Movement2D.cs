using System;
using Source.Components;
using UnityEngine;


namespace Source.Systems
{
    /**
     * Class `Movement2D` is a system that updates the player's pawn to a new position. It requires a `Transform`
     * object that belongs to the player's pawn, a `Vector2DValue` that represents the 2D axis value of the controller,
     * and a `Vector2DValue` that holds the current player's position.
     */
    public class Movement2D : MonoBehaviour
    {
        [SerializeField] private Transform pawnTransform = null;
        [SerializeField] private Vector2DValue axis = null;
        [SerializeField] private Vector2DValue playerPosition = null;

        private void Start()
        {
            Debug.Assert(pawnTransform != null, "A Pawn must be assigned to this object");
            Debug.Assert(axis != null, "A controller 2D Axis must be assigned to this object");
            Debug.Assert(playerPosition != null, "A position 2D Axis must be assigned to this object");
        }

        private void Update()
        {
            pawnTransform.Translate(axis.X, 0, axis.Y);
            var newPosition = pawnTransform.position;
            playerPosition.X = newPosition.x;
            playerPosition.Y = newPosition.z;
        }

    }
}