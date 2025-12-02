using System;

namespace _Project.Scripts.UI.Storage
{
    public sealed class LaserReloadStorage
    {
        public event Action<float> OnLaserReloadChanged;

        public float LaserReload { get; private set; }

        public void SetLaserReload(float laserReload)
        {
            LaserReload = laserReload;
            OnLaserReloadChanged?.Invoke(laserReload);
        }
    }
}