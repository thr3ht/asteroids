using _Project.Scripts.Core.Config;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.Player
{
    public class PlayerShield
    {
        private PlayerConfig _playerConfig;
        private PlayerParticles _particles;
        private Collider _collider;
        private PlayerUpdater _updater;

        public bool IsActive { get; private set; }

        public PlayerShield(PlayerConfig playerConfig, PlayerUpdater updater, global::_Project.Scripts.Player.Player player)
        {
            _playerConfig = playerConfig;
            _particles = player.GetComponent<PlayerParticles>();
            _collider = player.GetComponent<Collider>();
            _updater = updater;
        }

        public async UniTask ActivateShield()
        {
            IsActive = true;
            _updater.IsInputEnabled = false;
            _collider.enabled = false;
            _particles.ActivateShield();

            await UniTask.WaitForSeconds(_playerConfig.ShieldDuration);

            _particles.DeactivateShield();
            _collider.enabled = true;
            _updater.IsInputEnabled = true;
            IsActive = false;
        }
    }
}