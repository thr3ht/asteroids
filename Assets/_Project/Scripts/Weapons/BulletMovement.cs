using _Project.Scripts.Core.Physics;
using UnityEngine;

namespace _Project.Scripts.Weapons
{
    public class BulletMovement
    {
        private readonly PhysicsBody _body;
        private readonly float _speed;
    
        public PhysicsBody Body => _body;

        public BulletMovement(Vector2 startPosition, float speed)
        {
            _speed = speed;
            _body = new PhysicsBody(startPosition, 1f);
        }

        public void Update(float deltaTime, Vector2 direction)
        {
            _body.SetVelocity(direction * _speed);
            _body.ApplyMovement(deltaTime);
        }
    }
}