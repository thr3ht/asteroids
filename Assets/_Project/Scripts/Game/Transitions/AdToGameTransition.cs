using _Project.Scripts.Core;
using _Project.Scripts.Core.StateMachine;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Game.Transitions
{
    public class AdToGameTransition : Transition
    {
        private SignalBus _signalBus;

        [Inject]
        private void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        private void OnEnable()
        {
            _signalBus.Subscribe<RewardedAdWatchedSignal>(OnRewardedWatched);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<RewardedAdWatchedSignal>(OnRewardedWatched);
        }

        private void OnRewardedWatched()
        {
            NeedTransit = true;
            
            Time.timeScale = 1f;
        }
    }
}