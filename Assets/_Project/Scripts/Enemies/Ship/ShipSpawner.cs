using _Project.Scripts.Core;
using _Project.Scripts.Core.Config;
using UnityEngine;

namespace _Project.Scripts.Enemies.Ship
{
    public class ShipSpawner
    {
        private const float FULL_CIRCLE_OFFSET = 360f;
        
        private const int SPAWN_TOP = 0;
        private const int SPAWN_BOTTOM = 1;
        private const int SPAWN_LEFT = 2;
        private const int SPAWN_RIGHT = 3;
        private const int SPAWN_COUNT = 4;
        
        private readonly ShipFactory _factory;
        private readonly WorldBounds _bounds;
        private readonly EnemyConfig _config;

        private float _timeUntilNextSpawn;

        public ShipSpawner(ShipFactory factory, WorldBounds bounds, EnemyConfig config)
        {
            _factory = factory;
            _bounds = bounds;
            _config = config;

            _timeUntilNextSpawn = _config.ShipSpawnInterval;
        }

        public void Update(float deltaTime)
        {
            _timeUntilNextSpawn -= deltaTime;

            if (_timeUntilNextSpawn <= 0f)
            {
                SpawnEnemyShip();
                _timeUntilNextSpawn = _config.ShipSpawnInterval;
            }
        }

        public void ResetTimer()
        {
            _timeUntilNextSpawn = _config.ShipSpawnInterval;
        }

        private void SpawnEnemyShip()
        {
            Vector2 spawnPosition = GetRandomPosition();

            float randomAngle = Random.Range(0f, FULL_CIRCLE_OFFSET) * Mathf.Deg2Rad;
            Vector2 direction = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));

            _factory.Spawn(spawnPosition, direction);
        }

        private Vector2 GetRandomPosition()
        {
            Vector2 min = _bounds.Min;
            Vector2 max = _bounds.Max;

            float offset = 1f;

            int side = Random.Range(0, SPAWN_COUNT);

            switch (side)
            {
                case SPAWN_TOP:
                    return new Vector2(Random.Range(min.x, max.x), max.y + offset);
                case SPAWN_BOTTOM:
                    return new Vector2(Random.Range(min.x, max.x), min.y - offset);
                case SPAWN_LEFT:
                    return new Vector2(max.x + offset, Random.Range(min.y, max.y));
                default:
                    return new Vector2(min.x - offset, Random.Range(min.y, max.y));
            }
        }
    }
}