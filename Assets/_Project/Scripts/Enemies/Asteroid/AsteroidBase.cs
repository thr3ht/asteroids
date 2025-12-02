using _Project.Scripts.Core;
using _Project.Scripts.Core.Config;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Enemies.Asteroid
{
    public abstract class AsteroidBase : Enemy
    {
        private const float FULL_CIRCLE_OFFSET = 360f;

        protected EnemyConfig _config;
        protected EnemyMovement _movement;
        protected WorldBounds _worldBounds;
        protected Vector2 _direction;
        protected float _rotation;
        protected float _rotationSpeed;
        protected SignalBus _signalBus;

        [Inject]
        public void Construct(WorldBounds worldBounds, EnemyConfig config, SignalBus signalBus)
        {
            _worldBounds = worldBounds;
            _config = config;
            _signalBus = signalBus;
        }

        public virtual void Activate(Vector2 position, Vector2 direction)
        {
            _movement = new EnemyMovement(position, GetSpeed());

            _movement.Body.SetPosition(position);
            _direction = direction.normalized;
            _rotation = Random.Range(0f, FULL_CIRCLE_OFFSET);
            _rotationSpeed = Random.Range(-_config.AsteroidRotationSpeed, _config.AsteroidRotationSpeed);

            transform.position = position;
            transform.rotation = Quaternion.Euler(0f, 0f, _rotation);
            gameObject.SetActive(true);

            Collider collider = GetComponent<Collider>();

            if (collider != null)
            {
                collider.enabled = true;
            }

            InitHealth(_config.AsteroidHealth);
        }

        public void Deactivate()
        {
            foreach (Transform child in transform)
            {
                GameObject childObject = child.gameObject;
                AsteroidFragment fragment = childObject.GetComponent<AsteroidFragment>();

                if (fragment != null)
                {
                    childObject.SetActive(false);
                }
                else
                {
                    childObject.SetActive(true);
                }
            }

            gameObject.SetActive(false);
        }

        protected abstract float GetSpeed();

        protected virtual void Update()
        {
            float deltaTime = Time.deltaTime;

            UpdateRotation(deltaTime);

            if (_movement.Body.Velocity.magnitude > 0.1f)
            {
                _direction = _movement.Body.Velocity.normalized;
            }

            UpdateMovement(deltaTime);

            Vector2 position = _movement.Body.Position;

            ApplyWorldBounds(position);
            UpdateTransform(position);
        }

        private void UpdateMovement(float deltaTime)
        {
            _movement.Update(deltaTime, _direction);
        }

        private void UpdateRotation(float deltaTime)
        {
            _rotation += _rotationSpeed * deltaTime;
            _rotation = Mathf.Repeat(_rotation, FULL_CIRCLE_OFFSET);
        }

        private void UpdateTransform(Vector2 position)
        {
            transform.position = position;
            transform.rotation = Quaternion.Euler(0f, 0f, _rotation);
        }

        private void ApplyWorldBounds(Vector2 position)
        {
            Vector2 wrapped = _worldBounds.GetWrappedPosition(position);
            _movement.Body.SetPosition(wrapped);
        }
    }
}