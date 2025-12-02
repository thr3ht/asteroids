using System;

namespace _Project.Scripts.UI.Storage
{
    public sealed class PlayerHealthStorage
    {
        public event Action<int> OnHealthChanged;

        public int Health { get; private set; }

        public void SetHealth(int health)
        {
            Health = health;
            OnHealthChanged?.Invoke(health);
        }
    }
}