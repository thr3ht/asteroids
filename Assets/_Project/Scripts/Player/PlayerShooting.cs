using _Project.Scripts.Player.Inputs;
using _Project.Scripts.Weapons;
using UnityEngine;

namespace _Project.Scripts.Player
{
    public class PlayerShooting
    {
        private readonly BulletWeapon _bulletWeapon;
        private readonly LaserWeapon _laserWeapon;
        private readonly IPlayerInput _input;

        public PlayerShooting(
            IPlayerInput input,
            BulletWeapon bulletWeapon,
            LaserWeapon laserWeapon)
        {
            _input = input;
            _bulletWeapon = bulletWeapon;
            _laserWeapon = laserWeapon;
        }

        public void Update(float deltaTime)
        {
            _bulletWeapon.Update(deltaTime);
            _laserWeapon.Update(deltaTime);

            if (_input.IsPrimaryFire())
            {
                _bulletWeapon.Fire();
            }

            if (_input.IsSecondaryFire())
            {
                _laserWeapon.Fire();
            }
        }

        public int GetLaserCharge() => _laserWeapon.LaserCharge;


        public float GetLaserReloadTime()
        {
            float laserCurrentReloadTime = _laserWeapon.ReloadTime;
            float laserMaxReloadTime = _laserWeapon.LaserReloadTime;
            return Mathf.InverseLerp(laserMaxReloadTime, 0f, laserCurrentReloadTime);
        }

        public void ResetLaser()
        {
            _laserWeapon.ResetState();
        }
    }
}