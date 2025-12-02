using _Project.Scripts.Core;
using Zenject;

namespace _Project.Scripts.Weapons
{
    public class BulletFactory : _Project.Scripts.Core.Factory<Bullet>
    {
        public BulletFactory(DiContainer container, Bullet prefab, ObjectPool<Bullet> objectPool) : base(container,
            prefab, objectPool)
        {
        }
    }
}