using UnityEngine;

namespace _Project.Scripts.Core.Physics
{
    public class PhysicsBody
    {
        private readonly float _mass;
        
        public Vector2 Position { get; private set; }
        public Vector2 Velocity { get; private set; }

        public PhysicsBody(Vector2 position, float mass = 1f)
        {
            Position = position;
            _mass = mass;
            Velocity = Vector2.zero;
        }

        public void SetPosition(Vector2 position)
        {
            Position = position;
        }

        public void SetVelocity(Vector2 velocity)
        {
            Velocity = velocity;
        }

        public void AddForce(Vector2 force, float deltaTime)
        {
            Vector2 acceleration = force / _mass;
            Velocity += acceleration * deltaTime;
        }

        public void ApplyMovement(float deltaTime)
        {
            Position += Velocity * deltaTime;
        }

        public float GetSpeedData() => Mathf.Round(Velocity.magnitude);

        public Vector2 GetPositionData()
        {
            Vector2 positionVector = Position;
            float positionX = Mathf.Round(positionVector.x);
            float positionY = Mathf.Round(positionVector.y);
            return new Vector2(positionX, positionY);
        }
    }
}