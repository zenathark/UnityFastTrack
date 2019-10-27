using Source.Components;
using UnityEngine;
using UnityEngine.AI;

namespace Source.Systems
{
    /**
     * Class `AxisPosition1DSystem` reads one controller axis and updates player in-game Axis.
     * 
     * The formula for updating the axis used is `x = av * speed * Time.deltaTime * (1 - dampening)` where:
     *   + x - is the axis to be updated
     *   + av - is the axis value read from the controller
     *   + speed - is the movement speed of the pawn. It's expected values are in [0, Inf)
     *   + dampening - is the movement movement's dampening effect. It's values are  in [0 - 1) where 0 is full speed
     *                 and 1 is full stop
     * Dampening can be used for simulating different environments like water or jump control
     */
    public class AxisPosition1DSystem : MonoBehaviour
    {
        [SerializeField] private FloatValue axis = null;
        [SerializeField] private FloatValue speed = null;
        [SerializeField] private FloatValue dampening = null;
        [SerializeField] private string axisName = "Horizontal";
        
        
        private void Start()
        {
            Debug.Assert(axis != null, "A FloatValue for controller axis must be assigned to this object");
            Debug.Assert(speed != null, "A FloatValue for speed must be assigned to this object");
            Debug.Assert(dampening != null, "A FloatValue for speed must be assigned to this object");
            Debug.Assert(axisName != null, "The name of the axis must be set");
            axis.value = 0;
            if (Mathf.Abs(speed ) <= 0.001f) speed.value = 1f;
        }

        private void Update()
        {
            axis.value = Input.GetAxis(axisName) * speed * Time.deltaTime * (1-dampening);
        }
    }
}