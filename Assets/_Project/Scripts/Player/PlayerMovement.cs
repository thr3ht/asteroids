using _Project.Scripts.Core.Config;
using _Project.Scripts.Core.Physics;
using _Project.Scripts.Player.Inputs;
using UnityEngine;

namespace _Project.Scripts.Player
{
    public class PlayerMovement
    {
        private const float ANGLE_OFFSET = 90f;
        private const float FULL_CIRCLE_OFFSET = 360f;
        private const float HALF_CIRCLE_OFFSET = 180f;
        
        private readonly PhysicsBody _body;
        private readonly IPlayerInput _input;
        private readonly PlayerConfig _config;

        private float _rotation;
    
        public float Rotation => _rotation;
    
        public float GetAngleData() => Mathf.Repeat(Mathf.Round(-Rotation) + HALF_CIRCLE_OFFSET, FULL_CIRCLE_OFFSET) - HALF_CIRCLE_OFFSET;

        public PlayerMovement(PhysicsBody body, IPlayerInput input, PlayerConfig config)
        {
            _body = body;
            _input = input;
            _config = config;
        }

        public void Update(float deltaTime)
        {
            float thrustInput = _input.GetBoost();
            float rotationInput = _input.GetRotation();

            _rotation += rotationInput * _config.RotationSpeed * deltaTime;
            _rotation = Mathf.Repeat(_rotation, FULL_CIRCLE_OFFSET);
        
            float rad = (_rotation + ANGLE_OFFSET) * Mathf.Deg2Rad;
            Vector2 forward = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
        
            Vector2 force = forward * (_config.Acceleration * thrustInput);
        
            _body.AddForce(force, deltaTime);
        
            if (_body.Velocity.magnitude > _config.MaxSpeed)
            {
                _body.SetVelocity(_body.Velocity.normalized * _config.MaxSpeed);
            }
        
            _body.ApplyMovement(deltaTime);
        }

        public void ResetRotation()
        {
            _rotation = 0f;
        }
    }
}