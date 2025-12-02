using System;
using _Project.Scripts.UI.Storage;
using MVVM;
using UniRx;
using Zenject;

namespace _Project.Scripts.UI.ViewModel
{
    public sealed class PlayerPositionViewModel : IInitializable, IDisposable, IViewModel
    {
        [Data("Position")] public readonly ReactiveProperty<string> Position = new();

        private readonly PlayerPositionStorage _playerPositionStorage;

        public PlayerPositionViewModel(PlayerPositionStorage playerPositionStorage)
        {
            _playerPositionStorage = playerPositionStorage;
        }

        public void Initialize()
        {
            OnPositionChanged(_playerPositionStorage.PositionX, _playerPositionStorage.PositionY);
            _playerPositionStorage.OnPositionChanged += OnPositionChanged;
        }

        public void Dispose()
        {
            _playerPositionStorage.OnPositionChanged -= OnPositionChanged;
        }

        private void OnPositionChanged(float positionX, float positionY)
        {
            Position.Value = $"X {positionX}: Y {positionY}";
        }
    }
}