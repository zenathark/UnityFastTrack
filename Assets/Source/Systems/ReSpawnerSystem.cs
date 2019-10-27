using System.Collections.Generic;
using UnityEngine;

namespace Source.Systems
{
    public class ReSpawnerSystem: MonoBehaviour
    {
        [SerializeField] private List<GameObject> items = null;
        [SerializeField] private string keyName = "Jump";

        private void Start()
        {
            Debug.Assert(items != null, "An items array must be set for this object");
        }

        private void Update()
        {
            if (Input.GetButtonUp(keyName))
            {
                foreach (var e in items) e.SetActive(true);
            }
        }
    }
}
