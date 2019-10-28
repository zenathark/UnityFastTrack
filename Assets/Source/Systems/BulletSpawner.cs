using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace Source.Systems
{
    public class BulletSpawner : MonoBehaviour
    {
        private class BulletData
        {
            public bool Active;
            public Vector2 Direction;
            public GameObject Model;
            public Vector3 InitialPosition;

            public BulletData(GameObject model)
            {
                Model = Instantiate(model, Vector3.zero, Quaternion.identity);
                Despawn();
            }

            public void Despawn()
            {
                Active = false;
                Model.SetActive(false);
                Direction = Vector2.zero;
                InitialPosition = Vector2.zero;
            }

            public void Spawn(Vector3 init, Vector3 direction)
            {
                Active = true;
                Model.transform.position = init;
                Model.SetActive(true);
                Direction = new Vector2(direction.x, direction.z);
                InitialPosition = init;
            }

            public float TraveledDistance() => Vector3.Distance(InitialPosition, Model.transform.position);
        }
        // Start is called before the first frame update
        [SerializeField] private bool hidePivot = true;
        [SerializeField] private bool hideInitialPosition = true;
        [SerializeField] private GameObject bulletModel = null;
        [SerializeField] private int bulletCount = 3;
        [SerializeField] private GameObject pivot = null;
        [SerializeField] private GameObject initialPosition = null;
        [SerializeField] private float speed = 1;
        [SerializeField] private float despawnRadius = 5;
        [SerializeField] private float bulletTimeInterval = 0.3f;

        private int _bulletIdx;
        private BulletData[] _bullets;
        private float _timeFromLastShoot = 0;

        private void Start()
        {
            if (pivot != null && hidePivot) pivot.GetComponent<MeshRenderer>().enabled = false;
            if (initialPosition != null && hideInitialPosition) 
                initialPosition.GetComponent<MeshRenderer>().enabled = false;
        
            _bullets = new BulletData[bulletCount];
            _bulletIdx = 0;
        
            for (var i = 0; i < bulletCount; i++) _bullets[i] = new BulletData(bulletModel);

            _timeFromLastShoot = bulletTimeInterval;
        }

        private void Update()
        {
            if (Input.GetButtonDown("Fire1")) Shoot();
            _timeFromLastShoot += Time.deltaTime;
            UpdateBullets();
        }

        public void Shoot()
        {
            if (_timeFromLastShoot < bulletTimeInterval) return;
            for (var i = 0; i < bulletCount; i++)
            {
                var idx = (_bulletIdx + i) % bulletCount;
                if (_bullets[idx].Active) continue;
                SpawnBullet(_bullets[idx]);
                _bulletIdx = idx;
                _timeFromLastShoot = 0;
                break;
            }
        }

        public void UpdateBullets()
        {
            for (var i = 0; i < bulletCount; i++)
            {
                if (!_bullets[i].Active) continue;
                UpdateModelPosition(_bullets[i]);
                OutOfRange(_bullets[i]);
            }
        }

        private void UpdateModelPosition(BulletData bullet)
        {
            var model = bullet.Model;
            var delta = Time.deltaTime * speed * bullet.Direction;
            model.transform.Translate(delta.x, 0, delta.y);       
        }

        private void OutOfRange(BulletData bullet)
        {
            if (bullet.TraveledDistance() > despawnRadius) bullet.Despawn();
        }

        private void SpawnBullet(BulletData bullet)
        {
            var init = initialPosition.transform.position;
            var direction = (init - pivot.transform.position).normalized;
            bullet.Spawn(init, direction);
        }
    }
}
