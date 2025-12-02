using System;
using _Project.Scripts.UI.Storage;
using MVVM;
using UniRx;
using Zenject;

namespace _Project.Scripts.UI.ViewModel
{
    public sealed class LaserChargeViewModel : IInitializable, IDisposable, IViewModel
    {
        [Data("Charge")] public readonly ReactiveProperty<int> Charge = new();

        private readonly LaserChargeStorage _laserChargeStorage;

        public LaserChargeViewModel(LaserChargeStorage laserChargeStorage)
        {
            _laserChargeStorage = laserChargeStorage;
        }

        public void Initialize()
        {
            OnChargeChanged(_laserChargeStorage.Charge);
            _laserChargeStorage.OnChargeChanged += OnChargeChanged;
        }

        public void Dispose()
        {
            _laserChargeStorage.OnChargeChanged -= OnChargeChanged;
        }

        private void OnChargeChanged(int charge)
        {
            Charge.Value = charge;
        }
    }
}