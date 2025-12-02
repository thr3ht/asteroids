using _Project.Scripts.Core;
using _Project.Scripts.Core.StateMachine;
using Zenject;

namespace _Project.Scripts.Game.Transitions
{
    public class MenuToGameTransition : Transition
    {
        private SignalBus _signalBus;

        [Inject]
        private void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        private void OnEnable()
        {
            _signalBus.Subscribe<RestartGameSignal>(OnGameRestart);
        }
    
        private void OnDisable()
        {
            _signalBus.Unsubscribe<RestartGameSignal>(OnGameRestart);
        }
    
        private void OnGameRestart()
        {
            NeedTransit = true;
        }
    }
}