using System;
using System.Collections.Generic;
using _Project.Scripts.Core;
using _Project.Scripts.Enemies.Asteroid;
using _Project.Scripts.Enemies.Ship;
using _Project.Scripts.Weapons;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Game
{
    public class GameResetService : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly List<IGameResettable> _resettables;
        
        private readonly ObjectPool<Asteroid> _asteroidPool;
        private readonly ObjectPool<Ship> _shipPool;
        private readonly ObjectPool<Bullet> _bulletPool;
        private readonly ObjectPool<Laser> _laserPool;
        
        private readonly AsteroidSpawner _asteroidSpawner;
        private readonly ShipSpawner _shipSpawner;

        public GameResetService(
            SignalBus signalBus, 
            List<IGameResettable> resettables,
            ObjectPool<Asteroid> asteroidPool,
            ObjectPool<Ship> shipPool,
            ObjectPool<Bullet> bulletPool,
            ObjectPool<Laser> laserPool,
            AsteroidSpawner asteroidSpawner,
            ShipSpawner shipSpawner)
        {
            _signalBus = signalBus;
            _resettables = resettables;
            _asteroidPool = asteroidPool;
            _shipPool = shipPool;
            _bulletPool = bulletPool;
            _laserPool = laserPool;
            _asteroidSpawner = asteroidSpawner;
            _shipSpawner = shipSpawner;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<RestartGameSignal>(OnRestart);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<RestartGameSignal>(OnRestart);
        }

        private void OnRestart()
        {
            foreach (var resettable in _resettables)
            {
                resettable.ResetState();
            }
            
            DeactivateAllInPool(_asteroidPool);
            DeactivateAllInPool(_shipPool);
            DeactivateAllInPool(_bulletPool);
            DeactivateAllInPool(_laserPool);

            _asteroidSpawner.ResetTimer();
            _shipSpawner.ResetTimer();
            
            _asteroidSpawner.SpawnInitial();
        }

        private void DeactivateAllInPool<T>(ObjectPool<T> pool) where T : Component, IPoolObject
        {
            foreach (var item in pool.GetAllActiveObjects())
            {
                item.Deactivate();
            }
        }
    }
}