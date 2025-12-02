using System;
using _Project.Scripts.UI.Storage;
using MVVM;
using UniRx;
using Zenject;

namespace _Project.Scripts.UI.ViewModel
{
    public sealed class LaserReloadViewModel : IInitializable, IDisposable, IViewModel
    {
        [Data("LaserReload")] public readonly ReactiveProperty<float> LaserReload = new();

        private readonly LaserReloadStorage _laserReloadStorage;

        public LaserReloadViewModel(LaserReloadStorage laserReloadStorage)
        {
            _laserReloadStorage = laserReloadStorage;
        }

        public void Initialize()
        {
            OnLaserReloadChanged(_laserReloadStorage.LaserReload);
            _laserReloadStorage.OnLaserReloadChanged += OnLaserReloadChanged;
        }

        public void Dispose()
        {
            _laserReloadStorage.OnLaserReloadChanged -= OnLaserReloadChanged;
        }

        private void OnLaserReloadChanged(float value)
        {
            LaserReload.Value = value;
        }
    }
}