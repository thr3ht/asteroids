using _Project.Scripts.Core;
using _Project.Scripts.Core.Physics;
using UniRx;
using UnityEngine;

namespace _Project.Scripts.Player
{
    public class PlayerUpdater
    {
        public readonly ReactiveProperty<float> SpeedData = new();
        public readonly ReactiveProperty<float> AngleData = new();
        public readonly ReactiveProperty<Vector2> PositionData = new();

        public readonly ReactiveProperty<int> LaserChargeData = new();
        public readonly ReactiveProperty<float> LaserReloadData = new();

        private PhysicsBody _body;
        private PlayerMovement _movement;
        private PlayerShooting _shooting;
        private WorldBounds _bounds;
        private Transform _transform;

        private bool _isInputEnabled = true;

        public bool IsInputEnabled
        {
            get => _isInputEnabled;
            set => _isInputEnabled = value;
        }
    
        public PhysicsBody PhysicsBody => _body;

        public PlayerUpdater(
            PhysicsBody body,
            PlayerMovement movement,
            PlayerShooting shooting,
            WorldBounds bounds,
            global::_Project.Scripts.Player.Player player)
        {
            _body = body;
            _movement = movement;
            _shooting = shooting;
            _bounds = bounds;
            _transform = player.transform;

            _body.SetPosition(player.transform.position);
        }

        public void Update(float deltaTime)
        {
            if (_isInputEnabled)
            {
                MovementHandle(deltaTime);
                ShootingHandle(deltaTime);
            }
            else
            {
                _body.ApplyMovement(deltaTime);
                _transform.position = _body.Position;
            }

            WorldBoundsHandle();

            SpeedData.Value = _body.GetSpeedData();
            AngleData.Value = _movement.GetAngleData();
            PositionData.Value = _body.GetPositionData();

            LaserChargeData.Value = _shooting.GetLaserCharge();
            LaserReloadData.Value = _shooting.GetLaserReloadTime();
        }

        public void ResetLaser()
        {
            _shooting.ResetLaser();
        }

        public void ResetTransform()
        {
            _body.SetPosition(Vector2.zero);
            _body.SetVelocity(Vector2.zero);

            _transform.position = Vector2.zero;
            _transform.rotation = Quaternion.identity;

            _movement.ResetRotation();
        }

        private void WorldBoundsHandle()
        {
            Vector2 wrapped = _bounds.GetWrappedPosition(_body.Position);
            _body.SetPosition(wrapped);
        }

        private void MovementHandle(float deltaTime)
        {
            _movement.Update(deltaTime);
            _transform.position = _body.Position;
            _transform.rotation = Quaternion.Euler(0f, 0f, _movement.Rotation);
        }

        private void ShootingHandle(float deltaTime)
        {
            _shooting.Update(deltaTime);
        }
    }
}