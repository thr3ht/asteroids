using _Project.Scripts.Core;
using _Project.Scripts.Core.Config;
using UniRx;
using Zenject;

namespace _Project.Scripts.Player
{
    public class PlayerHealth
    {
        private readonly ReactiveProperty<int> _currentHealth;
        private readonly SignalBus _signalBus;
        private readonly PlayerConfig _playerConfig;

        public IReadOnlyReactiveProperty<int> HealthData => _currentHealth;
        public bool IsAlive => _currentHealth.Value > 0;

        public PlayerHealth(SignalBus signalBus, PlayerConfig playerConfig)
        {
            _signalBus = signalBus;
            _playerConfig = playerConfig;
            _currentHealth = new ReactiveProperty<int>(_playerConfig.Health);
        }

        public void OnPlayerHit()
        {
            _currentHealth.Value -= 1;

            if (_currentHealth.Value <= 0)
            {
                HandleDeath();
            }
        }

        public void ResetHealth()
        {
            _currentHealth.Value = _playerConfig.Health;
        }

        public void AddHealth(int value)
        {
            _currentHealth.Value += value;
        }

        private void HandleDeath()
        {
            _signalBus.Fire<PlayerDiedSignal>();
        }
    }
}