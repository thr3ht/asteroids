using System;
using _Project.Scripts.UI.Storage;
using MVVM;
using UniRx;
using Zenject;

namespace _Project.Scripts.UI.ViewModel
{
    public sealed class PlayerHealthViewModel : IInitializable, IDisposable, IViewModel
    {
        [Data("Health")] public readonly ReactiveProperty<int> Health = new();

        private readonly PlayerHealthStorage _playerHealthStorage;

        public PlayerHealthViewModel(PlayerHealthStorage playerHealthStorage)
        {
            _playerHealthStorage = playerHealthStorage;
        }

        public void Initialize()
        {
            OnHealthChanged(_playerHealthStorage.Health);
            _playerHealthStorage.OnHealthChanged += OnHealthChanged;
        }

        public void Dispose()
        {
            _playerHealthStorage.OnHealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged(int health)
        {
            Health.Value = health;
        }
    }
}