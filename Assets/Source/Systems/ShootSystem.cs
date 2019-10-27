using Source.Components;
using UnityEngine;

namespace Source.Systems
{
    public class ShootSystem : MonoBehaviour
    {
        [SerializeField] private BulletSpawner bulletSpawner = null;

        private void Start()
        {
            Debug.Assert(bulletSpawner != null, "This object requires a bullet spawner");
        }
    }
}
