using System;

namespace _Project.Scripts.UI.Storage
{
    public sealed class PlayerPositionStorage
    {
        public event Action<float, float> OnPositionChanged;

        public float PositionX { get; private set; }
        public float PositionY { get; private set; }

        public void SetPosition(float positionX, float positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
            OnPositionChanged?.Invoke(PositionX, PositionY);
        }
    }
}