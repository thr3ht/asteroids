using UnityEngine;
using Zenject;

namespace _Project.Scripts.Core
{
    public abstract class Factory<T> where T : Component, IPoolObject
    {
        private readonly DiContainer _container;
        private readonly T _prefab;
        private readonly ObjectPool<T> _objectPool;

        protected Factory(DiContainer container, T prefab, ObjectPool<T> objectPool)
        {
            _container = container;
            _prefab = prefab;
            _objectPool = objectPool;
        }

        public void Spawn(Vector2 position, Vector2 direction)
        {
            T item = GetOrCreate();

            if (item != null)
            {
                item.Activate(position, direction);
            }
        }

        public void Despawn(T item)
        {
            if (item == null)
            {
                return;
            }

            item.Deactivate();
        }

        private T GetOrCreate()
        {
            if (!_objectPool.CanAddObject())
            {
                return null;
            }

            T item = _objectPool.GetInactiveObject();

            if (item == null)
            {
                item = _container.InstantiatePrefabForComponent<T>(_prefab);
                _objectPool.AddObject(item);
            }

            return item;
        }
    }
}