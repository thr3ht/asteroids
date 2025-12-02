using _Project.Scripts.Core;
using Zenject;

namespace _Project.Scripts.Enemies.Asteroid
{
    public class AsteroidFactory : _Project.Scripts.Core.Factory<global::_Project.Scripts.Enemies.Asteroid.Asteroid>
    {
        public AsteroidFactory(DiContainer container, global::_Project.Scripts.Enemies.Asteroid.Asteroid prefab, ObjectPool<global::_Project.Scripts.Enemies.Asteroid.Asteroid> objectPool) : base(container,
            prefab, objectPool)
        {
        }
    }
}