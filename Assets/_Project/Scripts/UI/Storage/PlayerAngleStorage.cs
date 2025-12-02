using System;

namespace _Project.Scripts.UI.Storage
{
    public sealed class PlayerAngleStorage
    {
        public event Action<float> OnAngleChanged;

        public float Angle { get; private set; }

        public void SetAngle(float angle)
        {
            Angle = angle;
            OnAngleChanged?.Invoke(Angle);
        }
    }
}