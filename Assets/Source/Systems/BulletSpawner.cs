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
        }
        // Start is called before the first frame update
        [SerializeField] private bool hidePivot = true;
        [SerializeField] private bool hideInitialPosition = true;
        [SerializeField] private GameObject bulletModel = null;
        [SerializeField] private int bulletCount = 3;
        [SerializeField] private MeshRenderer pivot = null;
        [SerializeField] private MeshRenderer initialPosition = null;
        [SerializeField] private float speed = 1;
        [SerializeField] private Vector2 bulletDirection = Vector2.right;
        [SerializeField] private float despawnRadius = 5;
        [SerializeField] private float bulletTimeInterval = 100;

        private int _bulletIdx;
        private BulletData[] _bullets;
        private float _timeFromLastShoot = 0;

        private void Start()
        {
            if (pivot != null && hidePivot) pivot.enabled = false;
            if (initialPosition != null && hideInitialPosition) initialPosition.enabled = false;
        
            _bullets = new BulletData[bulletCount];
            _bulletIdx = 0;
        
            for (var i = 0; i < bulletCount; i++)
            {
                _bullets[i] = new BulletData();
                _bullets[i].Active = false;
                _bullets[i].Model = Instantiate(bulletModel, Vector3.zero, Quaternion.identity);
                _bullets[i].Model.SetActive(false);
                _bullets[i].Direction = bulletDirection;
            }

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
            var distance = Vector3.Distance(transform.position, bullet.Model.transform.position);
            if (distance > despawnRadius) DespawnBullet(bullet);
        }

        private void DespawnBullet(BulletData bullet)
        {
            bullet.Active = false;
            bullet.Model.transform.localPosition = Vector3.zero;
            bullet.Model.SetActive(false);
        }

        private void SpawnBullet(BulletData bullet)
        {
            bullet.Active = true;
            bullet.Model.transform.position = initialPosition.transform.position;
            bullet.Model.SetActive(true);
            bullet.Direction = transform.rotation.eulerAngles * bulletDirection;
        }
    }
}
