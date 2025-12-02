using System;
using _Project.Scripts.Player;
using _Project.Scripts.UI.Storage;
using UniRx;
using Zenject;

namespace _Project.Scripts.Game
{
    public class UIService : IInitializable, IDisposable
    {
        private readonly PlayerFacade _playerFacade;
        private readonly Score _score;

        private readonly PlayerSpeedStorage _playerSpeedStorage;
        private readonly PlayerAngleStorage _playerAngleStorage;
        private readonly PlayerPositionStorage _playerPositionStorage;
        private readonly LaserChargeStorage _laserChargeStorage;
        private readonly LaserReloadStorage _laserReloadStorage;
        private readonly PlayerHealthStorage _playerHealthStorage;
        private readonly ScoreStorage _scoreStorage;

        private CompositeDisposable _disposables = new();

        [Inject]
        public UIService(
            PlayerFacade playerFacade,
            Score score,
            PlayerSpeedStorage playerSpeedStorage,
            PlayerAngleStorage playerAngleStorage,
            PlayerPositionStorage playerPositionStorage,
            LaserChargeStorage laserChargeStorage,
            LaserReloadStorage laserReloadStorage,
            PlayerHealthStorage playerHealthStorage,
            ScoreStorage scoreStorage)
        {
            _playerFacade = playerFacade;
            _score = score;
            _playerSpeedStorage = playerSpeedStorage;
            _playerAngleStorage = playerAngleStorage;
            _playerPositionStorage = playerPositionStorage;
            _laserChargeStorage = laserChargeStorage;
            _laserReloadStorage = laserReloadStorage;
            _playerHealthStorage = playerHealthStorage;
            _scoreStorage = scoreStorage;
        }

        public void Initialize()
        {
            _playerFacade.HealthData
                .Subscribe(health => _playerHealthStorage.SetHealth(health))
                .AddTo(_disposables);
            
            _score.ScoreData
                .Subscribe(score => _scoreStorage.SetScore(score))
                .AddTo(_disposables);
            
            _playerFacade.SpeedData
                .Subscribe(speed => _playerSpeedStorage.SetSpeed(speed))
                .AddTo(_disposables);

            _playerFacade.AngleData
                .Subscribe(angle => _playerAngleStorage.SetAngle(angle))
                .AddTo(_disposables);

            _playerFacade.PositionData
                .Subscribe(position => _playerPositionStorage.SetPosition(position.x, position.y))
                .AddTo(_disposables);

            _playerFacade.LaserChargeData
                .Subscribe(laserCharge => _laserChargeStorage.SetCharge(laserCharge))
                .AddTo(_disposables);

            _playerFacade.LaserReloadData
                .Subscribe(laserReload => _laserReloadStorage.SetLaserReload(laserReload))
                .AddTo(_disposables);
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}