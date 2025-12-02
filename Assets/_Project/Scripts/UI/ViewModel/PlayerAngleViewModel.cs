using System;
using _Project.Scripts.UI.Storage;
using MVVM;
using UniRx;
using Zenject;

namespace _Project.Scripts.UI.ViewModel
{
    public sealed class PlayerAngleViewModel : IInitializable, IDisposable, IViewModel
    {
        [Data("Angle")] public readonly ReactiveProperty<string> Angle = new();

        private readonly PlayerAngleStorage _playerAngleStorage;

        public PlayerAngleViewModel(PlayerAngleStorage playerAngleStorage)
        {
            _playerAngleStorage = playerAngleStorage;
        }

        public void Initialize()
        {
            OnAngleChanged(_playerAngleStorage.Angle);
            _playerAngleStorage.OnAngleChanged += OnAngleChanged;
        }

        public void Dispose()
        {
            _playerAngleStorage.OnAngleChanged -= OnAngleChanged;
        }

        private void OnAngleChanged(float angle)
        {
            Angle.Value = "Angle: " + angle;
        }
    }
}