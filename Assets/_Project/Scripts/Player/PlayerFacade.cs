using _Project.Scripts.Core;
using _Project.Scripts.Core.Physics;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace _Project.Scripts.Player
{
    public class PlayerFacade : IGameResettable
    {
        private readonly PlayerUpdater _updater;
        private readonly PlayerHealth _health;
        private readonly PlayerShield _shield;

        public PlayerFacade(
            PlayerUpdater updater,
            PlayerHealth health,
            PlayerShield shield)
        {
            _updater = updater;
            _health = health;
            _shield = shield;
        }

        public IReadOnlyReactiveProperty<float> SpeedData => _updater.SpeedData;
        public IReadOnlyReactiveProperty<float> AngleData => _updater.AngleData;
        public IReadOnlyReactiveProperty<Vector2> PositionData => _updater.PositionData;

        public IReadOnlyReactiveProperty<int> LaserChargeData => _updater.LaserChargeData;
        public IReadOnlyReactiveProperty<float> LaserReloadData => _updater.LaserReloadData;
        public IReadOnlyReactiveProperty<int> HealthData => _health.HealthData;
    
        public PhysicsBody GetPhysicsBody() => _updater.PhysicsBody;

        public void Update(float deltaTime)
        {
            _updater.Update(deltaTime);
        }

        public void ResetState()
        {
            _health.ResetHealth();
            _updater.ResetLaser();
            _updater.ResetTransform();
        }

        public void OnHit()
        {
            _health.OnPlayerHit();

            if (_health.IsAlive)
            {
                _shield.ActivateShield().Forget();
            }
        }
    }
}