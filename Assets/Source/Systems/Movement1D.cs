using Source.Components;
using UnityEngine;

namespace Source.Systems
{
    public class Movement1D : MonoBehaviour
    {
        [SerializeField] private Transform pawnTransform = null;
        [SerializeField] private FloatValue axis = null;
        [SerializeField] private FloatValue playerPosition = null;

        private void Start()
        {
            Debug.Assert(pawnTransform != null, "A Pawn must be assigned to this object");
            Debug.Assert(axis != null, "A controller 2D Axis must be assigned to this object");
            Debug.Assert(playerPosition != null, "A position 2D Axis must be assigned to this object");
        }

        private void Update()
        {
            pawnTransform.Translate(axis, 0, 0);
            var newPosition = pawnTransform.position;
            playerPosition.value = newPosition.x;
        }
    }
}