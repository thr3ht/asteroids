using _Project.Scripts.Core;
using _Project.Scripts.Core.Config;
using _Project.Scripts.Enemies.Asteroid;
using _Project.Scripts.Enemies.Ship;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure.Installers
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private Asteroid _asteroidPrefab;
        [SerializeField] private Ship _shipPrefab;

        private EnemyConfig _config;

        [Inject]
        public void Construct(EnemyConfig config)
        {
            _config = config;
        }

        public override void InstallBindings()
        {
            Container
                .Bind<ObjectPool<Asteroid>>()
                .FromInstance(new ObjectPool<Asteroid>(_config.AsteroidMaxCount))
                .AsSingle();

            Container
                .Bind<AsteroidFactory>()
                .AsSingle()
                .WithArguments(_asteroidPrefab);

            Container
                .Bind<AsteroidSpawner>()
                .AsSingle();

            Container
                .Bind<ObjectPool<Ship>>()
                .FromInstance(new ObjectPool<Ship>(_config.ShipMaxCount))
                .AsSingle();

            Container
                .Bind<ShipFactory>()
                .AsSingle()
                .WithArguments(_shipPrefab);

            Container
                .Bind<ShipSpawner>()
                .AsSingle();
        }
    }
}