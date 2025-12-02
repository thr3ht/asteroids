using _Project.Scripts.Core.Config;
using UnityEngine;

namespace _Project.Scripts.Weapons
{
    public class BulletWeapon : Weapon
    {
        private const float ANGLE_OFFSET = 90f;
        
        private readonly BulletFactory _factory;
        private readonly Transform _shotPoint;
        private readonly float _bulletCooldown;

        private float _cooldown;

        public BulletWeapon(
            BulletFactory factory,
            Transform shotPoint,
            WeaponsConfig config)
        {
            _factory = factory;
            _shotPoint = shotPoint;
            _bulletCooldown = config.BulletCooldown;
        }

        public override void Update(float deltaTime)
        {
            if (_cooldown > 0f)
            {
                _cooldown -= deltaTime;
            }
        }

        public override void Fire()
        {
            if (_cooldown > 0f)
            {
                return;
            }

            _cooldown = _bulletCooldown;

            float rad = (_shotPoint.eulerAngles.z + ANGLE_OFFSET) * Mathf.Deg2Rad;
            Vector2 forward = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));

            _factory.Spawn(_shotPoint.position, forward);
        }
    }
}