using _Project.Scripts.Core;
using _Project.Scripts.Weapons;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure.Installers
{
    public class WeaponInstaller : MonoInstaller
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Laser _laserPrefab;
        [SerializeField] private Transform _shotPoint;

        public override void InstallBindings()
        {
            Container
                .Bind<ObjectPool<Bullet>>()
                .FromInstance(new ObjectPool<Bullet>())
                .AsSingle();

            Container
                .Bind<BulletFactory>()
                .AsSingle()
                .WithArguments(_bulletPrefab);

            Container
                .Bind<ObjectPool<Laser>>()
                .FromInstance(new ObjectPool<Laser>())
                .AsSingle();

            Container
                .Bind<LaserFactory>()
                .AsSingle()
                .WithArguments(_laserPrefab);

            Container
                .Bind<BulletWeapon>()
                .AsSingle()
                .WithArguments(_shotPoint);

            Container
                .Bind<LaserWeapon>()
                .AsSingle()
                .WithArguments(_shotPoint);
        }
    }
}