using Source.Components;
using UnityEngine;
using UnityEngine.Serialization;

namespace Source.Systems
{
    public class PositionXyController : MonoBehaviour
    {
        [SerializeField] private AxisXyValue controller;
        [SerializeField] private SpeedValue speed;
        [SerializeField] private string xAxisName = "Horizontal";
        [SerializeField] private string yAxisName = "Vertical";
        // Start is called before the first frame update
        private void Start()
        {
            controller.x = 0;
            controller.y = 0;
        }

        // Update is called once per frame
        private void Update()
        {
            controller.x = Input.GetAxis(xAxisName) * speed.value * Time.deltaTime;
            controller.y = Input.GetAxis(yAxisName) * speed.value * Time.deltaTime; 
        }
    }
}
