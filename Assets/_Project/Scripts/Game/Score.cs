using System;
using _Project.Scripts.Core;
using UniRx;
using Zenject;

namespace _Project.Scripts.Game
{
    public class Score : IInitializable, IDisposable, IGameResettable
    {
        private readonly ReactiveProperty<int> _score = new ReactiveProperty<int>(0);
    
        private SignalBus _signalBus;
    
        public IReadOnlyReactiveProperty<int> ScoreData => _score;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<AsteroidDiedSignal>(OnAsteroidDied);
            _signalBus.Subscribe<ShipDiedSignal>(OnShipDied);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<AsteroidDiedSignal>(OnAsteroidDied);
            _signalBus.Unsubscribe<ShipDiedSignal>(OnShipDied);
        }

        public void ResetState()
        {
            _score.Value = 0;
        }

        private void OnAsteroidDied(AsteroidDiedSignal signal)
        {
            AddScore(signal.Score);
        }

        private void OnShipDied(ShipDiedSignal signal)
        {
            AddScore(signal.Score);
        }

        private void AddScore(int score)
        {
            _score.Value += score;
        }
    }
}