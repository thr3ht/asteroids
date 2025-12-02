using _Project.Scripts.Core.Config;
using UnityEngine;

namespace _Project.Scripts.Weapons
{
    public class LaserWeapon : Weapon
    {
        private const float ANGLE_OFFSET = 90f;
        
        private readonly LaserFactory _factory;

        private readonly Transform _shotPoint;
        private readonly float _laserCooldown;
        private readonly int _laserMaxCharge;
        private readonly float _laserReloadTime;

        private float _cooldown;
        private float _reloadTime;
        private int _laserCharge;

        public float ReloadTime => _reloadTime;
        public float LaserReloadTime => _laserReloadTime;
        public int LaserCharge => _laserCharge;

        public LaserWeapon(LaserFactory factory,
            Transform shotPoint,
            WeaponsConfig config)
        {
            _factory = factory;
            _shotPoint = shotPoint;
            _laserCooldown = config.LaserCooldown;
            _laserMaxCharge = config.LaserMaxCharge;
            _laserReloadTime = config.LaserReloadTime;
            _reloadTime = _laserReloadTime;
            _laserCharge = _laserMaxCharge;
        }

        public override void Update(float deltaTime)
        {
            if (_cooldown > 0f)
            {
                _cooldown -= deltaTime;
            }

            if (_laserCharge < _laserMaxCharge)
            {
                _reloadTime -= deltaTime;

                if (_reloadTime <= 0f)
                {
                    _laserCharge += 1;
                    _reloadTime = _laserReloadTime;
                }
            }
        }

        public override void Fire()
        {
            if (_cooldown > 0f || _laserCharge == 0)
            {
                return;
            }

            _cooldown = _laserCooldown;

            float rad = (_shotPoint.eulerAngles.z + ANGLE_OFFSET) * Mathf.Deg2Rad;
            Vector2 forward = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));

            _factory.Spawn(_shotPoint.position, forward);

            _laserCharge -= 1;
        }

        public void ResetState()
        {
            _laserCharge = _laserMaxCharge;
            _reloadTime = _laserReloadTime;
            _cooldown = 0f;
        }
    }
}