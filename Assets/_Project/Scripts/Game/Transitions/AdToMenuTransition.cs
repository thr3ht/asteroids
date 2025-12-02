using _Project.Scripts.Core;
using _Project.Scripts.Core.StateMachine;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Game.Transitions
{
    public class AdToMenuTransition : Transition
    {
        private SignalBus _signalBus;

        [Inject]
        private void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        private void OnEnable()
        {
            _signalBus.Subscribe<RewardedAdSkippedSignal>(OnRewardedSkipped);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<RewardedAdSkippedSignal>(OnRewardedSkipped);
        }

        private void OnRewardedSkipped()
        {
            NeedTransit = true;
            
            Time.timeScale = 0f;
        }
    }
}