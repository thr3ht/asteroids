using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Project.Scripts.Core
{
    public class ObjectPool<T> where T : Component
    {
        private readonly List<T> _objectPool = new List<T>();
        private readonly int? _maxActiveObjectsCount;

        public ObjectPool(int? maxActiveObjectsCount = null)
        {
            _maxActiveObjectsCount = maxActiveObjectsCount;
        }

        public T GetInactiveObject()
        {
            if (!CanAddObject())
            {
                return null;
            }

            return _objectPool.FirstOrDefault(item => item != null && !item.gameObject.activeSelf);
        }

        public void AddObject(T item)
        {
            if (item != null && !_objectPool.Contains(item))
            {
                _objectPool.Add(item);
            }
        }

        public bool CanAddObject()
        {
            if (!_maxActiveObjectsCount.HasValue)
            {
                return true;
            }

            int activeObjects = _objectPool.Count(item => item != null && item.gameObject.activeSelf);

            return activeObjects < _maxActiveObjectsCount.Value;
        }

        public IEnumerable<T> GetAllActiveObjects()
        {
            return _objectPool.Where(item => item != null && item.gameObject.activeSelf);
        }
    }
}