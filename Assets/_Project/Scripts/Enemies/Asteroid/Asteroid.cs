using _Project.Scripts.Core;
using _Project.Scripts.Core.Physics;
using UnityEngine;

namespace _Project.Scripts.Enemies.Asteroid
{
    public class Asteroid : AsteroidBase, IPoolObject
    {
        private const float FULL_CIRCLE_OFFSET = 360f;
        
        protected override float GetSpeed()
        {
            return _config.AsteroidSpeed;
        }

        protected override void Update()
        {
            if (!AllFragmentsDeactivated())
            {
                Deactivate();
            }
            else
            {
                base.Update();
            }
        }

        protected override void HandleDeath()
        {
            _signalBus.Fire(new AsteroidDiedSignal(_config.AsteroidScore));

            foreach (Transform child in transform)
            {
                GameObject childObject = child.gameObject;
                AsteroidFragment fragment = childObject.GetComponent<AsteroidFragment>();

                if (fragment != null)
                {
                    float randomAngle = Random.Range(0f, FULL_CIRCLE_OFFSET) * Mathf.Deg2Rad;
                    Vector2 direction = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));

                    fragment.Activate(transform.position, direction);
                }
                else
                {
                    childObject.SetActive(false);
                }
            }

            Collider parentCollider = GetComponent<Collider>();
            parentCollider.enabled = false;
        }

        private bool AllFragmentsDeactivated()
        {
            bool hasActiveFragments = false;

            foreach (Transform child in transform)
            {
                if (child.gameObject.activeSelf)
                {
                    hasActiveFragments = true;
                    break;
                }
            }

            return hasActiveFragments;
        }

        public PhysicsBody GetPhysicsBody()
        {
            return _movement.Body;
        }
    }
}