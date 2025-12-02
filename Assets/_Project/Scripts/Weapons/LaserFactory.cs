using _Project.Scripts.Core;
using Zenject;

namespace _Project.Scripts.Weapons
{
    public class LaserFactory : _Project.Scripts.Core.Factory<Laser>
    {
        public LaserFactory(DiContainer container, Laser prefab, ObjectPool<Laser> objectPool) : base(container,
            prefab, objectPool)
        {
        }
    }
}