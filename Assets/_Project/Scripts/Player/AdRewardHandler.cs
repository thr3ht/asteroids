using System;
using _Project.Scripts.Core;
using Zenject;

namespace _Project.Scripts.Player
{
    public class AdRewardHandler : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly PlayerHealth _playerHealth;

        public AdRewardHandler(SignalBus signalBus, PlayerHealth playerHealth)
        {
            _signalBus = signalBus;
            _playerHealth = playerHealth;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<RewardedAdWatchedSignal>(OnAdWatched);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<RewardedAdWatchedSignal>(OnAdWatched);
        }

        private void OnAdWatched()
        {
            _playerHealth.AddHealth(1);
        }
    }
}