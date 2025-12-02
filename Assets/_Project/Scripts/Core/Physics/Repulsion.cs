using UnityEngine;

namespace _Project.Scripts.Core.Physics
{
    public class Repulsion
    {
        private readonly float _force;

        public Repulsion(float force)
        {
            _force = force;
        }

        public void ApplyRepulsion(PhysicsBody body1, Vector2 position1, PhysicsBody body2, Vector2 position2)
        {
            Vector2 direction = (position1 - position2).normalized;
        
            Vector2 currentVelocity1 = body1.Velocity;
            Vector2 repulsionVelocity1 = direction * _force;
            body1.SetVelocity(currentVelocity1 + repulsionVelocity1);
        
            Vector2 currentVelocity2 = body2.Velocity;
            Vector2 repulsionVelocity2 = -direction * _force;
            body2.SetVelocity(currentVelocity2 + repulsionVelocity2);
        }
    }
}