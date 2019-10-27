using Source.Components;
using UnityEngine;
using UnityEngine.Serialization;

namespace Source.Systems
{
    /**
     * Class `AxisPosition2DSystem` reads two controller axis and updates player in-game Axis.
     * 
     * For each axis, the formula used is `x = av * speed * Time.deltaTime * dampening` where:
     *   + x - is the axis to be updated
     *   + av - is the axis value read from the controller
     *   + speed - is the movement speed of the pawn. It's expected values are in [0, Inf)
     *   + dampening - is the movement movement's dampening effect. It's values are  in [0 - 1) where 0 is full speed
     *                 and 1 is full stop
     * Dampening can be used for simulating different environments like water or jump control
     */
    public class AxisPosition2DSystem: MonoBehaviour
    {
        [SerializeField] private Vector2DValue controller = null;
        [SerializeField] private FloatValue speed = null;
        [SerializeField] private string xAxisName = "Horizontal";
        [SerializeField] private string yAxisName = "Vertical";
        // Start is called before the first frame update
        
        private void Start()
        {
            Debug.Assert(controller != null, "A controller 2D axis must be assigned to this object");
            Debug.Assert(speed != null, "A FloatValue for speed must be assigned to this object");
            Debug.Assert(yAxisName != null, "The name of the Y axis must be set");
            Debug.Assert(xAxisName != null, "The name of the X axis must be set");
            controller.X = 0;
            controller.Y = 0;
            if (Mathf.Abs(speed - 0.0001f) <= 0) speed.value = 1f;
        }

        private void Update()
        {
            controller.X = Input.GetAxis(xAxisName) * speed * Time.deltaTime;
            controller.Y = Input.GetAxis(yAxisName) * speed * Time.deltaTime;
        }
    }
}
