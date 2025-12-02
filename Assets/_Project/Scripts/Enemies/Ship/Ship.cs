using _Project.Scripts.Core;
using _Project.Scripts.Core.Config;
using _Project.Scripts.Core.Physics;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Enemies.Ship
{
    public class Ship : Enemy, IPoolObject
    {
        private const float ANGLE_OFFSET = 90f;
        
        private SignalBus _signalBus;
        private EnemyConfig _config;
        private EnemyMovement _movement;
        private WorldBounds _worldBounds;
        private Vector2 _direction;
        private Player.Player _player;

        private float _rotation;
        private float _rotationSpeed;
        private float _repulsionCooldown = 0f;

        [Inject]
        public void Construct(SignalBus signalBus, WorldBounds worldBounds, EnemyConfig config, Player.Player player)
        {
            _signalBus = signalBus;
            _worldBounds = worldBounds;
            _config = config;
            _player = player;
        }

        public PhysicsBody GetPhysicsBody()
        {
            return _movement.Body;
        }

        public void SetRepulsionCooldown(float cooldown)
        {
            _repulsionCooldown = cooldown;
        }

        public void Activate(Vector2 position, Vector2 direction)
        {
            _movement = new EnemyMovement(position, _config.ShipSpeed);

            _movement.Body.SetPosition(position);

            transform.position = position;

            gameObject.SetActive(true);

            _rotationSpeed = _config.ShipRotationSpeed;

            InitHealth(_config.ShipHealth);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }

        protected override void HandleDeath()
        {
            _signalBus.Fire(new ShipDiedSignal(_config.ShipScore));

            Deactivate();
        }

        private void Update()
        {
            float deltaTime = Time.deltaTime;

            if (_repulsionCooldown > 0f)
            {
                _repulsionCooldown -= deltaTime;
            }

            Vector2 playerPosition = _player.transform.position;
            Vector2 myPosition = _movement.Body.Position;

            if (_movement.Body.Velocity.magnitude > 0.1f && _repulsionCooldown > 0f)
            {
                _direction = _movement.Body.Velocity.normalized;
            }
            else
            {
                _direction = (playerPosition - myPosition).normalized;
                float targetRotation = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg - ANGLE_OFFSET;

                UpdateRotation(deltaTime, targetRotation);
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

        private void UpdateRotation(float deltaTime, float targetRotation)
        {
            _rotation = Mathf.MoveTowardsAngle(_rotation, targetRotation, _rotationSpeed * deltaTime);
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