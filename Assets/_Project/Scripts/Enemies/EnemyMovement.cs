using _Project.Scripts.Core.Physics;
using UnityEngine;

namespace _Project.Scripts.Enemies
{
    public class EnemyMovement
    {
        private readonly PhysicsBody _body;
        private readonly float _speed;
    
        public PhysicsBody Body => _body;

        public EnemyMovement(Vector2 startPosition, float speed)
        {
            _speed = speed;
            _body = new PhysicsBody(startPosition, 1f);
        }

        public void Update(float deltaTime, Vector2 direction)
        {
            Vector2 targetVelocity = direction * _speed;
        
            _body.SetVelocity(targetVelocity);
            _body.ApplyMovement(deltaTime);
        }
    }
}