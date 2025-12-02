using UnityEngine;

namespace _Project.Scripts.Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        private float _health;

        protected void InitHealth(float health)
        {
            _health = health;
        }

        public virtual void TakeDamage(float damage)
        {
            _health -= damage;

            if (_health <= 0)
            {
                HandleDeath();
            }
        }

        protected abstract void HandleDeath();
    }
}