using System;

namespace _Project.Scripts.UI.Storage
{
    public sealed class PlayerSpeedStorage
    {
        public event Action<float> OnSpeedChanged;

        public float Speed { get; private set; }

        public void SetSpeed(float speed)
        {
            Speed = speed;
            OnSpeedChanged?.Invoke(Speed);
        }
    }
}