using _Project.Scripts.Core.StateMachine;
using _Project.Scripts.Enemies.Asteroid;
using _Project.Scripts.Enemies.Ship;
using _Project.Scripts.UI.Storage;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Game.States
{
    public class GameState : State
    {
        private AsteroidSpawner _asteroidSpawner;
        private ShipSpawner _shipSpawner;
        private MenuStorage _menuStorage;

        [Inject]
        public void Construct(
            AsteroidSpawner asteroidSpawner,
            ShipSpawner shipSpawner,
            MenuStorage menuStorage)
        {
            _asteroidSpawner = asteroidSpawner;
            _shipSpawner = shipSpawner;
            _menuStorage = menuStorage;
        }

        private void OnEnable()
        {
            Time.timeScale = 1;

            _menuStorage.SetMenuVisible(false);
            _asteroidSpawner.SpawnInitial();
        }

        private void Update()
        {
            _asteroidSpawner.Update(Time.deltaTime);
            _shipSpawner.Update(Time.deltaTime);
        }
    }
}