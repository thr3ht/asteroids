using System;
using _Project.Scripts.UI.Storage;
using MVVM;
using UniRx;
using Zenject;

namespace _Project.Scripts.UI.ViewModel
{
    public sealed class PlayerSpeedViewModel : IInitializable, IDisposable, IViewModel
    {
        [Data("Speed")] public readonly ReactiveProperty<string> Speed = new();

        private readonly PlayerSpeedStorage _playerSpeedStorage;

        public PlayerSpeedViewModel(PlayerSpeedStorage playerSpeedStorage)
        {
            _playerSpeedStorage = playerSpeedStorage;
        }

        public void Initialize()
        {
            OnSpeedChanged(_playerSpeedStorage.Speed);
            _playerSpeedStorage.OnSpeedChanged += OnSpeedChanged;
        }

        public void Dispose()
        {
            _playerSpeedStorage.OnSpeedChanged -= OnSpeedChanged;
        }

        private void OnSpeedChanged(float speed)
        {
            Speed.Value = "Speed: " + speed;
        }
    }
}