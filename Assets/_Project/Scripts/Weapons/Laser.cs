using _Project.Scripts.Core;
using _Project.Scripts.Core.Config;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Weapons
{
    public class Laser : MonoBehaviour, IPoolObject
    {
        private const float ANGLE_OFFSET = 90f;
        
        private WeaponsConfig _config;
        private LineRenderer _lineRenderer;
        private BoxCollider _collider;

        private Vector2 _startPosition;
        private Vector2 _direction;
        private float _laserLength;
        private float _lifeTime;
        private float _laserWidth;

        [Inject]
        public void Construct(WeaponsConfig config)
        {
            _config = config;
        }

        public void Activate(Vector2 position, Vector2 direction)
        {
            _startPosition = position;
            _direction = direction.normalized;
            _lifeTime = 0f;
            _laserLength = _config.LaserLight;
            _laserWidth = _config.LaserWidth;

            Vector2 endPosition = _startPosition + _direction * _laserLength;

            _lineRenderer.positionCount = 2;
            _lineRenderer.SetPosition(0, _startPosition);
            _lineRenderer.SetPosition(1, endPosition);
            _lineRenderer.enabled = true;

            transform.position = _startPosition;

            float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle - ANGLE_OFFSET);

            _collider.center = new Vector3(0f, _laserLength / 2f, 0f);
            _collider.size = new Vector3(_laserWidth, _laserLength, _laserWidth);
            _collider.enabled = true;

            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            _lineRenderer.enabled = false;
            _collider.enabled = false;
            gameObject.SetActive(false);
        }

        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();
            _collider = GetComponent<BoxCollider>();
        }

        private void Update()
        {
            float deltaTime = Time.deltaTime;

            LifeTimeHandle(deltaTime);

            if (CheckDespawn())
            {
                Deactivate();
            }
        }

        private void LifeTimeHandle(float deltaTime)
        {
            _lifeTime += deltaTime;
        }

        private bool CheckDespawn()
        {
            return _lifeTime >= _config.LaserMaxLifeTime;
        }
    }
}