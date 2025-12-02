using _Project.Scripts.Core;
using _Project.Scripts.Core.Config;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Weapons
{
    public class Bullet : MonoBehaviour, IPoolObject
    {
        private WeaponsConfig _config;
        private BulletMovement _movement;
        private WorldBounds _worldBounds;

        private Vector2 _direction;
        private float _lifeTime;

        [Inject]
        public void Construct(WorldBounds worldBounds, WeaponsConfig config)
        {
            _worldBounds = worldBounds;
            _config = config;
        }

        public void Activate(Vector2 position, Vector2 direction)
        {
            _movement = new BulletMovement(position, _config.BulletSpeed);

            _movement.Body.SetPosition(position);
            _direction = direction.normalized;
            _lifeTime = 0f;

            transform.position = position;
            gameObject.SetActive(true);
        }

        private void Update()
        {
            float deltaTime = Time.deltaTime;

            MovementHandle(deltaTime);
            LifeTimeHandle(deltaTime);

            var position = _movement.Body.Position;

            if (CheckDespawn(position))
            {
                Deactivate();
                return;
            }

            transform.position = position;
        }

        private void MovementHandle(float deltaTime)
        {
            _movement.Update(deltaTime, _direction);
        }

        private void LifeTimeHandle(float deltaTime)
        {
            _lifeTime += deltaTime;
        }

        private bool CheckDespawn(Vector2 position)
        {
            return _lifeTime >= _config.BulletMaxLifeTime || _worldBounds.IsOutOfBounds(position);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }
    }
}