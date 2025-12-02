using _Project.Scripts.Core;
using _Project.Scripts.Core.StateMachine;
using _Project.Scripts.External.AdMob;
using Zenject;

namespace _Project.Scripts.Game.Transitions
{
    public class GameToMenuTransition : Transition
    {
        private SignalBus _signalBus;
        private AdSettings _adSettings;

        [Inject]
        private void Construct(SignalBus signalBus, AdSettings adSettings)
        {
            _signalBus = signalBus;
            _adSettings = adSettings;
        }

        private void OnEnable()
        {
            _signalBus.Subscribe<PlayerDiedSignal>(OnGameOver);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<PlayerDiedSignal>(OnGameOver);
        }

        private void OnGameOver(PlayerDiedSignal signal)
        {
            if (!_adSettings.ShowAds)
            {
                NeedTransit = true;
            }
        }
    }
}